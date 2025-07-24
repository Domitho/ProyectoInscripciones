using System;
using System.Data;
using System.Web.UI;
using Npgsql;
using System.Web.Security;

namespace ProyectoInscripcionesED
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text;
            string password = txtPassword.Text; // Contraseña en texto claro

            // Establecer la cadena de conexión
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["PostgresConnection"].ToString();
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();

                // Consulta SQL para verificar el correo y la contraseña
                string query = "SELECT id, nombres, apellidos, tipo_usuario, contrasena FROM usuario WHERE correo = @correo";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@correo", correo);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Obtener la contraseña almacenada en la base de datos
                            string storedPassword = reader["contrasena"].ToString();

                            // Verificar si la contraseña ingresada coincide con la almacenada
                            if (password == storedPassword) // Comparación directa de contraseñas en texto claro
                            {
                                // Contraseña válida, guardar la información en sesión
                                Session["UserId"] = reader["id"];
                                Session["UserName"] = reader["nombres"] + " " + reader["apellidos"];
                                Session["UserType"] = reader["tipo_usuario"];

                                // Redirigir según el tipo de usuario
                                if (reader["tipo_usuario"].ToString() == "participante")
                                {
                                    Response.Redirect("Dashboard.aspx");
                                }
                                else if (reader["tipo_usuario"].ToString() == "instructor")
                                {
                                    Response.Redirect("Dashboard.aspx");
                                }
                            }
                            else
                            {
                                // Contraseña incorrecta
                                Response.Write("<script>alert('Contraseña incorrecta');</script>");
                            }
                        }
                        else
                        {
                            // Usuario no encontrado
                            Response.Write("<script>alert('Correo no registrado');</script>");
                        }
                    }
                }
            }
        }
    }
}
