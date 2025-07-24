using System;
using System.Data;
using System.Configuration;
using Npgsql;
using System.Web.UI.WebControls;

namespace ProyectoInscripcionesED
{
    public partial class EditarInscripcion : System.Web.UI.Page
    {
        private int idInscripcion;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                idInscripcion = Convert.ToInt32(Request.QueryString["id"]);
            }
            else
            {
                Response.Redirect("ListaInscripcion.aspx"); // Si no se encuentra el ID, redirige al listado
            }

            if (!IsPostBack)
            {
                CargarInscripcion();
                CargarUsuarios();
                CargarTalleres();
            }
        }

        // Método para cargar la inscripción seleccionada
        private void CargarInscripcion()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["PostgresConnection"].ToString();

            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                string sql = "SELECT usuario_id, taller_id, estado FROM inscripcion WHERE id = @idInscripcion";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("idInscripcion", idInscripcion);
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Cargar los valores en los controles del formulario
                            ddlUsuario.SelectedValue = reader["usuario_id"].ToString();
                            ddlTaller.SelectedValue = reader["taller_id"].ToString();
                            ddlEstado.SelectedValue = reader["estado"].ToString();
                        }
                    }
                }
            }
        }

        // Método para cargar los usuarios en el DropDownList
        private void CargarUsuarios()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["PostgresConnection"].ToString();

            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                string sql = "SELECT id, nombres FROM usuario";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        ddlUsuario.Items.Clear();
                        while (reader.Read())
                        {
                            ddlUsuario.Items.Add(new ListItem(reader["nombres"].ToString(), reader["id"].ToString()));
                        }
                    }
                }
            }
        }

        // Método para cargar los talleres en el DropDownList
        private void CargarTalleres()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["PostgresConnection"].ToString();

            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                string sql = "SELECT id, nombre FROM taller";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        ddlTaller.Items.Clear();
                        while (reader.Read())
                        {
                            ddlTaller.Items.Add(new ListItem(reader["nombre"].ToString(), reader["id"].ToString()));
                        }
                    }
                }
            }
        }

        // Método para guardar los cambios
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            int usuarioId = int.Parse(ddlUsuario.SelectedValue);
            int tallerId = int.Parse(ddlTaller.SelectedValue);
            string estado = ddlEstado.SelectedValue;

            string connectionString = ConfigurationManager.ConnectionStrings["PostgresConnection"].ToString();

            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                string sql = "UPDATE inscripcion SET usuario_id = @usuario_id, taller_id = @taller_id, estado = @estado WHERE id = @idInscripcion";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("usuario_id", usuarioId);
                    cmd.Parameters.AddWithValue("taller_id", tallerId);
                    cmd.Parameters.AddWithValue("estado", estado);
                    cmd.Parameters.AddWithValue("idInscripcion", idInscripcion);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        lblMensaje.Text = "Inscripción actualizada correctamente.";
                        lblMensaje.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        lblMensaje.Text = "No se pudo actualizar la inscripción. Intente de nuevo.";
                        lblMensaje.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
        }
    }
}
