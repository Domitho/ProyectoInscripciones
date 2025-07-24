using System;
using System.Data;
using System.Configuration;
using Npgsql;
using System.Web.UI.WebControls;

namespace ProyectoInscripcionesED
{
    public partial class ListaInscripcion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarInscripciones();
            }
        }

        // Método para cargar las inscripciones en el GridView
        private void CargarInscripciones()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["PostgresConnection"].ToString();
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                string sql = "SELECT i.id, i.usuario_id, i.taller_id, i.estado, u.nombres AS usuario_nombre, t.nombre AS taller_nombre " +
                             "FROM inscripcion i " +
                             "JOIN usuario u ON i.usuario_id = u.id " +
                             "JOIN taller t ON i.taller_id = t.id";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);

                        // Vinculamos los datos al GridView
                        gvInscripciones.DataSource = dt;
                        gvInscripciones.DataBind();
                    }
                }
            }
        }

        // Manejo del comando de ver detalles
        protected void gvInscripciones_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // Obtener el ID de la inscripción desde el CommandArgument
            int idInscripcion = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Detalles")
            {
                // Redirigir a la página de detalles con el ID de la inscripción
                Response.Redirect("DetallesInscripcion.aspx?id=" + idInscripcion);
            }
            else if (e.CommandName == "Editar")
            {
                // Redirigir a la página de edición con el ID de la inscripción
                Response.Redirect("EditarInscripcion.aspx?id=" + idInscripcion);
            }
            else if (e.CommandName == "Eliminar")
            {
                // Eliminar la inscripción de la base de datos
                EliminarInscripcion(idInscripcion);
            }
        }

        private void EliminarInscripcion(int idInscripcion)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["PostgresConnection"].ToString();

            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                string sql = "DELETE FROM inscripcion WHERE id = @idInscripcion";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("idInscripcion", idInscripcion);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        lblMensaje.Text = "Inscripción eliminada correctamente.";
                        lblMensaje.ForeColor = System.Drawing.Color.Green;
                        CargarInscripciones(); // Recargar las inscripciones
                    }
                    else
                    {
                        lblMensaje.Text = "No se pudo eliminar la inscripción. Intente de nuevo.";
                        lblMensaje.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            // Aquí puedes redirigir a una página para agregar una nueva inscripción, por ejemplo:
            Response.Redirect("AgregarInscripcion.aspx");
        }

    }
}
