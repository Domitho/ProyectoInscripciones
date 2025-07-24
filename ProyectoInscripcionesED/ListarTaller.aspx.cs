using System;
using System.Data;
using System.Configuration;
using Npgsql;
using System.Web;

namespace ProyectoInscripcionesED
{
    public partial class ListarTaller : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTalleres();
            }
        }

        // Método para cargar los talleres en el GridView
        private void CargarTalleres()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["PostgresConnection"].ToString();
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                string sql = "SELECT id, nombre, descripcion, fecha, hora_inicio, hora_fin, duracion_horas, curso_id, instructor_id FROM taller";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Usamos un DataTable para almacenar los datos y luego los vinculamos al GridView
                        DataTable dt = new DataTable();
                        dt.Load(reader);

                        // Vinculamos los datos al GridView
                        gvTalleres.DataSource = dt;
                        gvTalleres.DataBind();
                    }
                }
            }
        }

        // Manejo de los comandos (Editar, Eliminar, Detalles) de los botones en el GridView
        protected void gvTalleres_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            int idTaller = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Editar")
            {
                // Lógica para editar el taller
                Response.Redirect("EditarTaller.aspx?id=" + idTaller);
            }
            else if (e.CommandName == "Eliminar")
            {
                // Lógica para eliminar el taller
                EliminarTaller(idTaller);
            }
            else if (e.CommandName == "Detalles")
            {
                // Lógica para ver los detalles del taller
                Response.Redirect("DetallesTaller.aspx?id=" + idTaller);
            }
        }

        // Método para eliminar un taller
        private void EliminarTaller(int idTaller)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["PostgresConnection"].ToString();
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                string sql = "DELETE FROM taller WHERE id = @id";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("id", idTaller);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        // Mostrar mensaje de éxito y recargar la lista
                        lblMensaje.Text = "Taller eliminado exitosamente.";
                        lblMensaje.ForeColor = System.Drawing.Color.Green;
                        CargarTalleres();
                    }
                    else
                    {
                        lblMensaje.Text = "Error al eliminar el taller.";
                        lblMensaje.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
        }
        protected void btnAgregarTaller_Click(object sender, EventArgs e)
        {
            // Aquí puedes redirigir a la página para agregar un nuevo taller, por ejemplo:
            Response.Redirect("AgregarTaller.aspx");
        }

    }
}
