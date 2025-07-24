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
            if (e.CommandName == "Detalles")
            {
                int idInscripcion = Convert.ToInt32(e.CommandArgument);
                // Redirigir a una página de detalles pasando el ID de la inscripción
                Response.Redirect("DetallesInscripcion.aspx?id=" + idInscripcion);
            }
        }
    

    }
}
