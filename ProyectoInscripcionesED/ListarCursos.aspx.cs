using System;
using System.Data;
using Npgsql;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoInscripcionesED
{
    public partial class ListarCursosPage : Page
    {
        // Cadena de conexión a la base de datos PostgreSQL
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PostgresConnection"].ConnectionString;

        // Método que se ejecuta cuando se carga la página
        protected void Page_Load(object sender, EventArgs e)
        {
            // Si la página se está cargando por primera vez, obtenemos los cursos
            if (!IsPostBack)
            {
                ListarCursos();
            }
        }

        // Método para listar los cursos desde la base de datos usando la función listar_cursos
        private void ListarCursos()
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Ejecutamos la función listar_cursos que devuelve todos los cursos
                    using (var command = new NpgsqlCommand("SELECT * FROM listar_cursos();", connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            // Verificamos si hay resultados
                            if (reader.HasRows)
                            {
                                // Enlazamos los resultados al GridView
                                GridViewCursos.DataSource = reader;
                                GridViewCursos.DataBind();
                            }
                            else
                            {
                                // Si no hay cursos, mostramos un mensaje
                                lblNoCursos.Visible = true;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Manejo de errores
                    Response.Write("<script>alert('Error al listar cursos: " + ex.Message + "');</script>");
                }
            }
        }

        // Evento para el botón de Editar
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            // Obtener el ID del curso desde el argumento del comando
            Button btn = (Button)sender;
            string cursoId = btn.CommandArgument;

            // Redirigir a la página de edición de cursos (puedes personalizar la URL de destino)
            Response.Redirect("EditarCurso.aspx?cursoId=" + cursoId);
        }

        // Evento para el botón de Eliminar
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            // Obtener el ID del curso desde el argumento del comando
            Button btn = (Button)sender;
            int cursoId = Convert.ToInt32(btn.CommandArgument);  // Asegúrate de que el cursoId sea un entero

            // Eliminar el curso de la base de datos usando la función eliminar_curso
            EliminarCurso(cursoId);
        }

        private void EliminarCurso(int cursoId)  // Asegúrate de que el parámetro sea INT
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (var command = new NpgsqlCommand("SELECT eliminar_curso(@cursoId);", connection))
                    {
                        // Agregar el parámetro para la función
                        command.Parameters.AddWithValue("cursoId", cursoId);

                        // Ejecutar la función y obtener el resultado (mensaje)
                        string resultado = (string)command.ExecuteScalar();

                        // Mostrar el resultado en un mensaje de alerta
                        Response.Write("<script>alert('" + resultado + "');</script>");

                        // Volver a cargar los cursos después de eliminar
                        ListarCursos();
                    }
                }
                catch (Exception ex)
                {
                    // Manejo de errores
                    Response.Write("<script>alert('Error al eliminar curso: " + ex.Message + "');</script>");
                }
            }
        }

    }
}
