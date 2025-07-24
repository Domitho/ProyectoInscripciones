using System;
using System.Data;
using Npgsql;
using System.Web.UI;

namespace ProyectoInscripcionesED
{
    public partial class EditarUsuario : Page
    {
        // Cadena de conexión a la base de datos PostgreSQL
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PostgresConnection"].ConnectionString;

        // ID del usuario a editar
        private int usuarioId;

        // Método que se ejecuta cuando se carga la página
        protected void Page_Load(object sender, EventArgs e)
        {
            // Obtener el ID del usuario de la URL (parámetro 'usuarioId')
            if (int.TryParse(Request.QueryString["usuarioId"], out usuarioId))
            {
                if (!IsPostBack)
                {
                    // Cargar los datos del usuario en los controles del formulario
                    CargarDatosUsuario(usuarioId);
                }
            }
            else
            {
                lblMensaje.Text = "No se encontró el usuario.";
                lblMensaje.Visible = true;
            }
        }

        // Método para cargar los datos del usuario desde la base de datos
        private void CargarDatosUsuario(int usuarioId)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (var command = new NpgsqlCommand("SELECT * FROM usuario WHERE id = @usuarioId", connection))
                    {
                        command.Parameters.AddWithValue("usuarioId", usuarioId);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Rellenar los controles del formulario con los datos del usuario
                                txtNombres.Text = reader["nombres"].ToString();
                                txtApellidos.Text = reader["apellidos"].ToString();
                                txtCorreo.Text = reader["correo"].ToString();
                                txtTelefono.Text = reader["telefono"].ToString();
                                ddlTipoUsuario.SelectedValue = reader["tipo_usuario"].ToString();
                            }
                            else
                            {
                                lblMensaje.Text = "Usuario no encontrado.";
                                lblMensaje.Visible = true;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Manejo de errores
                    lblMensaje.Text = "Error al cargar los datos del usuario: " + ex.Message;
                    lblMensaje.Visible = true;
                }
            }
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            // Obtener el ID del usuario desde la URL (parámetro 'usuarioId')
            if (int.TryParse(Request.QueryString["usuarioId"], out int usuarioId))
            {
                // Actualizar los datos del usuario en la base de datos
                ActualizarUsuario(usuarioId);
            }
            else
            {
                lblMensaje.Text = "No se encontró el usuario.";
                lblMensaje.Visible = true;
            }
        }

        private void ActualizarUsuario(int usuarioId)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (var command = new NpgsqlCommand("SELECT actualizar_usuario(@usuarioId, @nombres, @apellidos, @correo, @telefono, @tipo_usuario);", connection))
                    {
                        // Agregar los parámetros para la función de actualización
                        command.Parameters.AddWithValue("usuarioId", usuarioId);
                        command.Parameters.AddWithValue("nombres", txtNombres.Text);
                        command.Parameters.AddWithValue("apellidos", txtApellidos.Text);
                        command.Parameters.AddWithValue("correo", txtCorreo.Text);
                        command.Parameters.AddWithValue("telefono", txtTelefono.Text);
                        command.Parameters.AddWithValue("tipo_usuario", ddlTipoUsuario.SelectedValue);

                        // Ejecutar la función
                        string resultado = (string)command.ExecuteScalar();

                        // Mostrar el resultado en un mensaje de alerta
                        lblMensaje.Text = resultado;
                        lblMensaje.Visible = true;
                        if (resultado == "Usuario actualizado exitosamente.")
                        {
                            lblMensaje.ForeColor = System.Drawing.Color.Green;

                            // Redirigir a la página de lista de usuarios después de la actualización
                            Response.Redirect("ListarUsuario.aspx");
                        }
                        else
                        {
                            lblMensaje.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Manejo de errores
                    lblMensaje.Text = "Error al actualizar el usuario: " + ex.Message;
                    lblMensaje.Visible = true;
                }
            }
        }   
    }
}
