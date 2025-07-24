using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoInscripcionesED
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text;
            string password = txtPassword.Text; // Contraseña en texto claro

            // Conectar a la base de datos
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["PostgresConnection"].ToString();
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();

                string query = "INSERT INTO usuario (correo, contrasena, nombres, apellidos, telefono, tipo_usuario) VALUES (@correo, @contrasena, @nombres, @apellidos, @telefono, @tipo_usuario)";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@correo", correo);
                    cmd.Parameters.AddWithValue("@contrasena", password);  // Almacenamos la contraseña en texto claro
                    cmd.Parameters.AddWithValue("@nombres", txtNombres.Text);
                    cmd.Parameters.AddWithValue("@apellidos", txtApellidos.Text);
                    cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text);
                    cmd.Parameters.AddWithValue("@tipo_usuario", ddlTipoUsuario.SelectedValue);

                    cmd.ExecuteNonQuery();
                }
            }

            // Redirigir a login o mostrar mensaje de éxito
            Response.Redirect("Login.aspx");
        }

    }
}