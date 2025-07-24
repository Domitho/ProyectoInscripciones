using System;
using System.Data;
using System.Configuration;
using Npgsql;
using System.Web.UI.WebControls;

namespace ProyectoInscripcionesED
{
    public partial class AgregarInscripcion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarUsuarios();
                CargarTalleres();
            }
        }

        // Método para cargar los usuarios en el DropDownList
        private void CargarUsuarios()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["PostgresConnection"].ToString();

            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                string sql = "SELECT id, nombres FROM usuario";  // Asumimos que "usuario" tiene un campo "id" y "nombre"

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

                string sql = "SELECT id, nombre FROM taller";  // Asumimos que "taller" tiene un campo "id" y "nombre"

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

        // Método para guardar la inscripción
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            int usuarioId = int.Parse(ddlUsuario.SelectedValue);
            int tallerId = int.Parse(ddlTaller.SelectedValue);
            string estado = ddlEstado.SelectedValue;

            string connectionString = ConfigurationManager.ConnectionStrings["PostgresConnection"].ToString();

            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                try
                {
                    // Intentar insertar la inscripción
                    string sql = "INSERT INTO inscripcion (usuario_id, taller_id, estado) VALUES (@usuario_id, @taller_id, @estado)";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("usuario_id", usuarioId);
                        cmd.Parameters.AddWithValue("taller_id", tallerId);
                        cmd.Parameters.AddWithValue("estado", estado);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            lblMensaje.Text = "Inscripción agregada correctamente.";
                            lblMensaje.ForeColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            lblMensaje.Text = "No se pudo agregar la inscripción. Intente de nuevo.";
                            lblMensaje.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                }
                catch (PostgresException ex) when (ex.SqlState == "23505") // Error de clave duplicada
                {
                    // Capturar error de clave duplicada y mostrar mensaje adecuado
                    lblMensaje.Text = "El usuario ya está inscrito en este taller.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

    }
}
