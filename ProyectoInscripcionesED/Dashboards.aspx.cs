using System;
using System.Data;
using Npgsql;
using System.Web.UI;

namespace ProyectoInscripcionesED
{
    public partial class Dashboards : Page
    {
        // Cadena de conexión a la base de datos PostgreSQL
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PostgresConnection"].ConnectionString;

        // Método que se ejecuta cuando se carga la página
        protected void Page_Load(object sender, EventArgs e)
        {
            // Si la página se está cargando por primera vez, obtener los datos para los gráficos
            if (!IsPostBack)
            {
                // Llamar a los métodos para obtener los datos y pasarlos al frontend
                CargarDatosParaGraficos();
            }
        }

        // Método para obtener los datos para los gráficos
        private void CargarDatosParaGraficos()
        {
            // Consultas SQL
            string query1 = "SELECT nombre, AVG(horas_minimas) AS promedio_horas FROM curso GROUP BY nombre;";
            string query2 = "SELECT tipo_usuario, COUNT(*) AS total FROM usuario GROUP BY tipo_usuario;";
            string query3 = "SELECT duracion_horas, COUNT(fecha) AS count_fecha FROM taller GROUP BY duracion_horas ORDER BY duracion_horas;";
            string query4 = "SELECT estado, COUNT(*) AS count_estado FROM inscripcion GROUP BY estado;";
            string query5 = @"SELECT c.nombre AS nombre, COUNT(CASE WHEN i.estado = 'cancelado' THEN 1 END) AS cancelado, 
                              COUNT(CASE WHEN i.estado = 'confirmado' THEN 1 END) AS confirmado, 
                              COUNT(CASE WHEN i.estado = 'pendiente' THEN 1 END) AS pendiente, 
                              COUNT(i.id) AS total 
                              FROM curso c 
                              JOIN taller t ON c.id = t.curso_id 
                              JOIN inscripcion i ON t.id = i.taller_id 
                              GROUP BY c.nombre;";
            string query6 = @"SELECT TO_CHAR(t.fecha, 'Month') AS mes, t.nombre AS taller, COUNT(a.id) AS asistencia 
                              FROM taller t 
                              JOIN inscripcion i ON t.id = i.taller_id 
                              JOIN asistencia a ON i.id = a.inscripcion_id 
                              WHERE a.asistio = TRUE 
                              GROUP BY mes, t.nombre ORDER BY TO_CHAR(t.fecha, 'Month');";

            // Obtener datos para cada gráfico
            var datos1 = EjecutarConsulta(query1); // Promedio de horas por curso
            var datos2 = EjecutarConsulta(query2); // Total de usuarios por tipo
            var datos3 = EjecutarConsulta(query3); // Talleres por duración
            var datos4 = EjecutarConsulta(query4); // Estado de inscripciones
            var datos5 = EjecutarConsulta(query5); // Inscripciones por curso
            var datos6 = EjecutarConsulta(query6); // Asistencia por taller y mes

            // Pasar los datos a JavaScript en el frontend (Chart.js)
            string jsonDatos1 = ConvertirADatosJSON(datos1);
            string jsonDatos2 = ConvertirADatosJSON(datos2);
            string jsonDatos3 = ConvertirADatosJSON(datos3);
            string jsonDatos4 = ConvertirADatosJSON(datos4);
            string jsonDatos5 = ConvertirADatosJSON(datos5);
            string jsonDatos6 = ConvertirADatosJSON(datos6);

            // Asignar los datos a las variables JavaScript
            ScriptManager.RegisterStartupScript(this, this.GetType(), "CargarDatos", $@"
                var datosGrafico1 = {jsonDatos1};
                var datosGrafico2 = {jsonDatos2};
                var datosGrafico3 = {jsonDatos3};
                var datosGrafico4 = {jsonDatos4};
                var datosGrafico5 = {jsonDatos5};
                var datosGrafico6 = {jsonDatos6};
            ", true);
        }

        // Método para ejecutar la consulta y devolver los resultados en un DataTable
        private DataTable EjecutarConsulta(string query)
        {
            DataTable dt = new DataTable();
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }
            return dt;
        }

        // Método para convertir los datos del DataTable a formato JSON para JavaScript
        private string ConvertirADatosJSON(DataTable dt)
        {
            var json = "[";

            foreach (DataRow row in dt.Rows)
            {
                json += "{";
                foreach (DataColumn column in dt.Columns)
                {
                    json += $"\"{column.ColumnName}\": \"{row[column]}\"";
                    if (column != dt.Columns[dt.Columns.Count - 1]) json += ", ";
                }
                json += "},";
            }

            if (json.EndsWith(","))
                json = json.Substring(0, json.Length - 1);

            json += "]";
            return json;
        }
    }
}
