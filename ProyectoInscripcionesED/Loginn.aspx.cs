using System;
using System.Data;
using System.Web.UI;
using Npgsql;

namespace ProyectoInscripcionesED
{
    public partial class Loginn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Si el usuario ya está logueado, redirigir al dashboard
            if (Session["UserId"] != null)
            {
                Response.Redirect("Dashboard.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text;
            string password = txtPassword.Text; // Contraseña en texto claro

            // Cadena de conexión a PostgreSQL
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["PostgresConnection"].ToString();
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();

                // Consulta SQL para verificar si el correo existe en la base de datos
                string query = "SELECT id, nombres, apellidos, tipo_usuario, contrasena FROM usuario WHERE correo = @correo";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@correo", correo);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) // Si el correo existe
                        {
                            string storedPassword = reader["contrasena"].ToString(); // Recuperar la contraseña en texto claro

                            // Comparar la contraseña ingresada con la almacenada
                            if (password == storedPassword)
                            {
                                // Si las credenciales son correctas, iniciar sesión
                                Session["UserId"] = reader["id"];
                                Session["UserName"] = reader["nombres"] + " " + reader["apellidos"];
                                Session["UserType"] = reader["tipo_usuario"];

                                // Redirigir al dashboard basado en el tipo de usuario
                                if (reader["tipo_usuario"].ToString() == "participante")
                                {
                                    Response.Redirect("/");
                                }
                                else if (reader["tipo_usuario"].ToString() == "instructor")
                                {
                                    Response.Redirect("/");
                                }
                            }
                            else
                            {
                                // Contraseña incorrecta
                                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Contraseña incorrecta');", true);
                            }
                        }
                        else
                        {
                            // Correo no registrado
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Correo no registrado');", true);
                        }
                    }
                }
            }
        }
    }
}
