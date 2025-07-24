using System;
using System.Data;
using Npgsql;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoInscripcionesED
{
    public partial class ListarUsuario : Page
    {
        // Cadena de conexión a la base de datos PostgreSQL
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PostgresConnection"].ConnectionString;

        // Método que se ejecuta cuando se carga la página
        protected void Page_Load(object sender, EventArgs e)
        {
            // Si la página se está cargando por primera vez, obtenemos los usuarios
            if (!IsPostBack)
            {
                ListarUsuarios();
            }
        }

        // Método para listar los usuarios desde la base de datos usando la función listar_usuarios
        private void ListarUsuarios()
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (var command = new NpgsqlCommand("SELECT * FROM listar_usuarios();", connection))
                    {
                        // Ejecutamos la función y obtenemos los resultados
                        using (var reader = command.ExecuteReader())
                        {
                            // Verificamos si hay resultados
                            if (reader.HasRows)
                            {
                                // Enlazamos los resultados al GridView
                                GridViewUsuarios.DataSource = reader;
                                GridViewUsuarios.DataBind();
                            }
                            else
                            {
                                // Si no hay usuarios, mostramos un mensaje
                                lblNoUsuarios.Visible = true;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Manejo de errores
                    Response.Write("<script>alert('Error al listar usuarios: " + ex.Message + "');</script>");
                }
            }
        }

        // Evento RowDataBound para personalizar las filas del GridView (si es necesario)
        protected void GridViewUsuarios_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // Si la fila es de tipo de datos (no es un encabezado ni pie de página)
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Ejemplo de personalización: puedes acceder a las celdas de cada fila
                // e.g., formatear un campo o agregar clases CSS personalizadas
                // Ejemplo: colorear el fondo de una fila si el usuario es "Instructor"
                string tipoUsuario = e.Row.Cells[5].Text; // Suponiendo que el tipo de usuario está en la 6ª columna
                if (tipoUsuario == "Instructor")
                {
                    e.Row.BackColor = System.Drawing.Color.LightYellow;
                }
            }
        }

        // Evento para el botón de Editar
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            // Obtener el ID del usuario desde el argumento del comando
            Button btn = (Button)sender;
            string usuarioId = btn.CommandArgument;

            // Redirigir a la página de edición de usuarios (puedes personalizar la URL de destino)
            Response.Redirect("EditarUsuario.aspx?usuarioId=" + usuarioId);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            // Obtener el ID del usuario desde el argumento del comando
            Button btn = (Button)sender;
            string usuarioId = btn.CommandArgument;

            // Convertir el usuarioId a entero
            int usuarioIdInt;
            if (int.TryParse(usuarioId, out usuarioIdInt))
            {
                // Eliminar el usuario de la base de datos usando la función eliminar_usuario
                EliminarUsuario(usuarioIdInt);
            }
            else
            {
                // Si no se puede convertir el ID, mostrar un error
                Response.Write("<script>alert('ID de usuario no válido.');</script>");
            }
        }

        private void EliminarUsuario(int usuarioId)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (var command = new NpgsqlCommand("SELECT eliminar_usuario(@usuarioId);", connection))
                    {
                        // Agregar el parámetro para la función
                        command.Parameters.AddWithValue("usuarioId", usuarioId);

                        // Ejecutar la función
                        string resultado = (string)command.ExecuteScalar();

                        // Mostrar el resultado en un mensaje de alerta
                        Response.Write("<script>alert('" + resultado + "');</script>");

                        // Volver a cargar los usuarios después de eliminar
                        ListarUsuarios();
                    }
                }
                catch (Exception ex)
                {
                    // Manejo de errores
                    Response.Write("<script>alert('Error al eliminar usuario: " + ex.Message + "');</script>");
                }
            }
        }
    }
}
