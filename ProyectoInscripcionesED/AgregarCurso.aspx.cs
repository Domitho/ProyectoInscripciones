using System;
using System.Data;
using System.Configuration; // Para acceder a la configuración de web.config
using Npgsql;

namespace ProyectoInscripcionesED
{
    public partial class AgregarCurso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Lógica que puede ejecutarse al cargar la página si es necesario
        }

        protected void btnAgregarCurso_Click(object sender, EventArgs e)
        {
            // Recuperar los valores de los controles del formulario
            string nombreCurso = txtNombreCurso.Text;
            string descripcionCurso = txtDescripcionCurso.Text;
            DateTime fechaInicio = DateTime.Parse(txtFechaInicio.Text);
            DateTime fechaFin = DateTime.Parse(txtFechaFin.Text);
            int horasMinimas = int.Parse(txtHorasMinimas.Text);

            // Obtener la cadena de conexión desde web.config
            string connectionString = ConfigurationManager.ConnectionStrings["PostgresConnection"].ToString();

            try
            {
                // Crear la conexión a la base de datos PostgreSQL
                using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();

                    // Crear el comando SQL para insertar el nuevo curso sin el campo 'id'
                    string sql = "INSERT INTO curso (nombre, descripcion, fecha_inicio, fecha_fin, horas_minimas) " +
                                 "VALUES (@nombre, @descripcion, @fecha_inicio, @fecha_fin, @horas_minimas)";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                    {
                        // Parametrizar la consulta para evitar SQL injection
                        cmd.Parameters.AddWithValue("nombre", nombreCurso);
                        cmd.Parameters.AddWithValue("descripcion", descripcionCurso);
                        cmd.Parameters.AddWithValue("fecha_inicio", fechaInicio);
                        cmd.Parameters.AddWithValue("fecha_fin", fechaFin);
                        cmd.Parameters.AddWithValue("horas_minimas", horasMinimas);

                        // Ejecutar el comando SQL
                        int rowsAffected = cmd.ExecuteNonQuery();

                        // Mostrar el resultado
                        if (rowsAffected > 0)
                        {
                            lblMensaje.Text = "Curso agregado exitosamente.";
                            lblMensaje.ForeColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            lblMensaje.Text = "No se pudo agregar el curso. Intente de nuevo.";
                            lblMensaje.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                lblMensaje.Text = "Error al agregar el curso: " + ex.Message;
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}
