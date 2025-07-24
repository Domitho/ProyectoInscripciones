using System;
using System.Data;
using System.Configuration;
using Npgsql;
using System.Web.UI.WebControls;

namespace ProyectoInscripcionesED
{
    public partial class AgregarCertificado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarUsuarios();
                CargarCursos();
            }
        }

        // Método para cargar los usuarios en el DropDownList
        private void CargarUsuarios()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["PostgresConnection"].ToString();

            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                string sql = "SELECT id, nombres FROM usuario";  // Suponemos que "usuario" tiene "id" y "nombre"

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

        // Método para cargar los cursos en el DropDownList
        private void CargarCursos()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["PostgresConnection"].ToString();

            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                string sql = "SELECT id, nombre FROM curso";  // Suponemos que "curso" tiene "id" y "nombre"

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        ddlCurso.Items.Clear();
                        while (reader.Read())
                        {
                            ddlCurso.Items.Add(new ListItem(reader["nombre"].ToString(), reader["id"].ToString()));
                        }
                    }
                }
            }
        }

        // Método para guardar el certificado
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            int usuarioId = int.Parse(ddlUsuario.SelectedValue);
            int cursoId = int.Parse(ddlCurso.SelectedValue);

            string connectionString = ConfigurationManager.ConnectionStrings["PostgresConnection"].ToString();

            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                // Verificar si el certificado ya existe (usuario ya tiene certificado para ese curso)
                string checkSql = "SELECT COUNT(*) FROM certificado WHERE usuario_id = @usuario_id AND curso_id = @curso_id";
                using (NpgsqlCommand checkCmd = new NpgsqlCommand(checkSql, conn))
                {
                    checkCmd.Parameters.AddWithValue("usuario_id", usuarioId);
                    checkCmd.Parameters.AddWithValue("curso_id", cursoId);

                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (count > 0)
                    {
                        lblMensaje.Text = "Este usuario ya tiene un certificado para este curso.";
                        lblMensaje.ForeColor = System.Drawing.Color.Red;
                        return;  // No insertamos el certificado si ya existe
                    }
                }

                try
                {
                    // Insertar el certificado si no existe
                    string sql = "INSERT INTO certificado (usuario_id, curso_id) VALUES (@usuario_id, @curso_id)";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("usuario_id", usuarioId);
                        cmd.Parameters.AddWithValue("curso_id", cursoId);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            lblMensaje.Text = "Certificado agregado correctamente.";
                            lblMensaje.ForeColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            lblMensaje.Text = "No se pudo agregar el certificado. Intente de nuevo.";
                            lblMensaje.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                }
                catch (PostgresException ex) when (ex.SqlState == "23505")  // Capturar el error de duplicado
                {
                    // Si ya existe la combinación usuario_id + curso_id
                    lblMensaje.Text = "Este usuario ya está certificado para este curso.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
    }
}
