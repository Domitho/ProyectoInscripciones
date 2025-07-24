using System;
using System.Data;
using System.Configuration;
using Npgsql;
using System.Web.UI.WebControls;

namespace ProyectoInscripcionesED
{
    public partial class ListarAsistencia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarAsistencias();
            }
        }

        // Método para cargar las asistencias
        private void CargarAsistencias()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["PostgresConnection"].ToString();

            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                string sql = @"
                    SELECT a.id, a.inscripcion_id, u.nombres AS usuario_nombre, a.asistio
                    FROM asistencia a
                    JOIN inscripcion i ON a.inscripcion_id = i.id
                    JOIN usuario u ON i.usuario_id = u.id
                ";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);

                        // Vinculamos los datos al GridView
                        gvAsistencia.DataSource = dt;
                        gvAsistencia.DataBind();
                    }
                }
            }
        }

        // Manejo del comando de los botones (Detalles y Marcar Asistencia)
        protected void gvAsistencia_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idAsistencia = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Detalles")
            {
                // Redirigir a la página de detalles con el ID de la asistencia
                Response.Redirect("DetallesAsistencia.aspx?id=" + idAsistencia);
            }
            else if (e.CommandName == "MarcarAsistencia")
            {
                // Marcar la asistencia en la base de datos
                MarcarAsistencia(idAsistencia);
            }
        }

        // Método para marcar la asistencia
        // Método para marcar la asistencia
        private void MarcarAsistencia(int idAsistencia)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["PostgresConnection"].ToString();

            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                // Actualizar el valor de "asistio" para el registro seleccionado
                string sql = "UPDATE asistencia SET asistio = TRUE WHERE id = @idAsistencia";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("idAsistencia", idAsistencia);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        lblMensaje.Text = "Asistencia marcada correctamente.";  // Mensaje de éxito
                        lblMensaje.ForeColor = System.Drawing.Color.Green;
                        CargarAsistencias(); // Recargar las asistencias
                    }
                    else
                    {
                        lblMensaje.Text = "No se pudo marcar la asistencia. Intente de nuevo.";  // Mensaje de error
                        lblMensaje.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
        }

    }
}
