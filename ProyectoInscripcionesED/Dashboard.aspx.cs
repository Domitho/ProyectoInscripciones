using System;
using System.Data;
using System.Configuration;
using Npgsql;

namespace ProyectoInscripcionesED
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarKPIs();
            }
        }

        private void CargarKPIs()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["PostgresConnection"].ToString();

            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                // 1. Total de Usuarios Registrados
                string sqlTotalUsuarios = "SELECT COUNT(DISTINCT id) FROM usuario";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sqlTotalUsuarios, conn))
                {
                    var result = cmd.ExecuteScalar();
                    lblTotalUsuarios.Text = result != DBNull.Value ? Convert.ToInt32(result).ToString() : "0";
                }

                // 2. Total de Usuarios Activos
                string sqlUsuariosActivos = "SELECT COUNT(DISTINCT usuario_id) FROM inscripcion WHERE estado = 'confirmado'";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sqlUsuariosActivos, conn))
                {
                    var result = cmd.ExecuteScalar();
                    lblUsuariosActivos.Text = result != DBNull.Value ? Convert.ToInt32(result).ToString() : "0";
                }

                // 3. Tasa de Conversión de Inscripciones
                string sqlTasaConversion = @"
                    SELECT 
                        (COUNT(DISTINCT i.id) / COUNT(DISTINCT u.id)) * 100 AS TasaConversion
                    FROM usuario u
                    LEFT JOIN inscripcion i ON u.id = i.usuario_id";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sqlTasaConversion, conn))
                {
                    var result = cmd.ExecuteScalar();
                    decimal tasaConversion = result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                    lblTasaConversion.Text = tasaConversion.ToString("0.00");
                }

                // 4. Total de Inscripciones
                string sqlTotalInscripciones = "SELECT COUNT(id) FROM inscripcion";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sqlTotalInscripciones, conn))
                {
                    var result = cmd.ExecuteScalar();
                    lblTotalInscripciones.Text = result != DBNull.Value ? Convert.ToInt32(result).ToString() : "0";
                }

                // 5. Tasa de Asistencia Promedio
                string sqlTasaAsistencia = "SELECT (COUNT(a.asistio = TRUE) / COUNT(a.asistio)) * 100 FROM asistencia a";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sqlTasaAsistencia, conn))
                {
                    var result = cmd.ExecuteScalar();
                    decimal tasaAsistencia = result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                    lblTasaAsistenciaPromedio.Text = tasaAsistencia.ToString("0.00");
                }

                // 6. Tasa de Certificación
                string sqlTasaCertificacion = @"
                    SELECT 
                        (COUNT(c.id) / COUNT(i.id)) * 100 AS TasaCertificacion
                    FROM inscripcion i
                    LEFT JOIN certificado c ON i.usuario_id = c.usuario_id AND i.taller_id = c.curso_id";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sqlTasaCertificacion, conn))
                {
                    var result = cmd.ExecuteScalar();
                    decimal tasaCertificacion = result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                    lblTasaCertificacion.Text = tasaCertificacion.ToString("0.00");
                }

                // 7. Total de Talleres Realizados
                string sqlTalleresRealizados = "SELECT COUNT(id) FROM taller";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sqlTalleresRealizados, conn))
                {
                    var result = cmd.ExecuteScalar();
                    lblTalleresRealizados.Text = result != DBNull.Value ? Convert.ToInt32(result).ToString() : "0";
                }

                // 8. Total de Certificados Emitidos
                string sqlCertificadosEmitidos = "SELECT COUNT(id) FROM certificado";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sqlCertificadosEmitidos, conn))
                {
                    var result = cmd.ExecuteScalar();
                    lblCertificadosEmitidos.Text = result != DBNull.Value ? Convert.ToInt32(result).ToString() : "0";
                }

                // 9. Tiempo Promedio de Asistencia por Taller
                string sqlTiempoPromedioAsistencia = "SELECT AVG(duracion_horas) FROM taller";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sqlTiempoPromedioAsistencia, conn))
                {
                    var result = cmd.ExecuteScalar();
                    decimal tiempoPromedioAsistencia = result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                    lblTiempoPromedioAsistencia.Text = tiempoPromedioAsistencia.ToString("0.00");
                }

                // 10. Tasa de Cancelación de Talleres
                string sqlTasaCancelacion = @"
                    SELECT 
                        (COUNT(CASE WHEN t.fecha_fin <= CURRENT_DATE THEN 1 END) / COUNT(t.id)) * 100 AS TasaCancelacion
                    FROM taller t";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sqlTasaCancelacion, conn))
                {
                    var result = cmd.ExecuteScalar();
                    decimal tasaCancelacion = result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                    lblTasaCancelacion.Text = tasaCancelacion.ToString("0.00");
                }
            }
        }
    }
}
