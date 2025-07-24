using System;
using System.Data;
using System.Configuration;
using Npgsql;
using System.Web.UI.WebControls;

namespace ProyectoInscripcionesED
{
    public partial class EditarCertificado : System.Web.UI.Page
    {
        private int idCertificado;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Verificar si se ha pasado un ID en la URL
            if (Request.QueryString["id"] != null)
            {
                idCertificado = Convert.ToInt32(Request.QueryString["id"]);
            }
            else
            {
                Response.Redirect("ListaCertificados.aspx"); // Redirigir al listado si no se encuentra el ID
            }

            if (!IsPostBack)
            {
                CargarCertificado();
                CargarUsuarios();
                CargarCursos();
            }
        }

        // Método para cargar los datos del certificado
        private void CargarCertificado()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["PostgresConnection"].ToString();

            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                string sql = "SELECT usuario_id, curso_id FROM certificado WHERE id = @idCertificado";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("idCertificado", idCertificado);

                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Cargar los valores del certificado en los controles
                            ddlUsuario.SelectedValue = reader["usuario_id"].ToString();
                            ddlCurso.SelectedValue = reader["curso_id"].ToString();
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

        // Método para cargar los cursos en el DropDownList
        private void CargarCursos()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["PostgresConnection"].ToString();

            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                string sql = "SELECT id, nombre FROM curso";
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

        // Método para guardar los cambios
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            int usuarioId = int.Parse(ddlUsuario.SelectedValue);
            int cursoId = int.Parse(ddlCurso.SelectedValue);

            string connectionString = ConfigurationManager.ConnectionStrings["PostgresConnection"].ToString();

            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                // Verificar si el certificado ya existe con la misma combinación usuario_id y curso_id
                string checkSql = "SELECT COUNT(*) FROM certificado WHERE usuario_id = @usuario_id AND curso_id = @curso_id AND id != @idCertificado";
                using (NpgsqlCommand checkCmd = new NpgsqlCommand(checkSql, conn))
                {
                    checkCmd.Parameters.AddWithValue("usuario_id", usuarioId);
                    checkCmd.Parameters.AddWithValue("curso_id", cursoId);
                    checkCmd.Parameters.AddWithValue("idCertificado", idCertificado);

                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (count > 0)
                    {
                        lblMensaje.Text = "Este usuario ya tiene un certificado para este curso.";
                        lblMensaje.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                }

                // Actualizar el certificado en la base de datos
                string sql = "UPDATE certificado SET usuario_id = @usuario_id, curso_id = @curso_id WHERE id = @idCertificado";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("usuario_id", usuarioId);
                    cmd.Parameters.AddWithValue("curso_id", cursoId);
                    cmd.Parameters.AddWithValue("idCertificado", idCertificado);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        lblMensaje.Text = "Certificado actualizado correctamente.";
                        lblMensaje.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        lblMensaje.Text = "No se pudo actualizar el certificado. Intente de nuevo.";
                        lblMensaje.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
        }
    }
}
