using System;
using System.Data;
using Npgsql;
using System.Web.UI;

namespace ProyectoInscripcionesED
{
    public partial class Usuario : Page
    {
        // Cadena de conexión a la base de datos PostgreSQL
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PostgresConnection"].ConnectionString;

        // Método que se ejecuta cuando se carga la página
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.ServerVariables["REQUEST_METHOD"] == "POST")
            {
                // Obtener los datos enviados desde el formulario
                string nombres = Request.Form["nombres"];
                string apellidos = Request.Form["apellidos"];
                string correo = Request.Form["correo"];
                string telefono = Request.Form["telefono"];
                string tipoUsuario = Request.Form["tipo_usuario"];

                // Validación básica del formulario (puedes agregar más validaciones si lo necesitas)
                if (string.IsNullOrEmpty(nombres) || string.IsNullOrEmpty(apellidos) || string.IsNullOrEmpty(correo))
                {
                    Response.Write("<script>alert('Por favor, complete todos los campos requeridos.');</script>");
                    return;
                }

                // Insertar el usuario en la base de datos
                InsertarUsuario(nombres, apellidos, correo, telefono, tipoUsuario);
            }
        }

        // Método para insertar un nuevo usuario en la base de datos usando la función
        private void InsertarUsuario(string nombres, string apellidos, string correo, string telefono, string tipoUsuario)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Llamada a la función 'insertar_usuario_func'
                    using (var command = new NpgsqlCommand("SELECT insertar_usuario_func(@p_nombres, @p_apellidos, @p_correo, @p_telefono, @p_tipo_usuario);", connection))
                    {
                        // Agregar los parámetros necesarios para la función
                        command.Parameters.AddWithValue("p_nombres", nombres);
                        command.Parameters.AddWithValue("p_apellidos", apellidos);
                        command.Parameters.AddWithValue("p_correo", correo);
                        command.Parameters.AddWithValue("p_telefono", telefono);
                        command.Parameters.AddWithValue("p_tipo_usuario", tipoUsuario);

                        // Ejecutar la función y obtener el resultado (mensaje de éxito)
                        string resultado = (string)command.ExecuteScalar();  // Ejecutamos la función y obtenemos el mensaje de retorno

                        // Alerta de éxito con el mensaje devuelto por la función
                        Response.Write("<script>alert('" + resultado + "');</script>");
                    }
                }
                catch (Exception ex)
                {
                    // Manejo de errores
                    Response.Write("<script>alert('Error al insertar usuario: " + ex.Message + "');</script>");
                }
            }
        }
    }
}
