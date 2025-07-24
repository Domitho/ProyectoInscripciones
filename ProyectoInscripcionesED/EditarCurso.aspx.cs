using System;
using Npgsql;
using System.Web.UI;

namespace ProyectoInscripcionesED
{
    public partial class EditarCurso : Page
    {
        // Cadena de conexión a la base de datos PostgreSQL
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PostgresConnection"].ConnectionString;

        // El ID del curso
        private int cursoId;

        // Método que se ejecuta cuando se carga la página
        protected void Page_Load(object sender, EventArgs e)
        {
            // Obtener el ID del curso desde el parámetro de la URL (cursoId)
            if (int.TryParse(Request.QueryString["cursoId"], out cursoId))
            {
                if (!IsPostBack)
                {
                    // Cargar los datos del curso si no es un postback
                    CargarDatosCurso(cursoId);
                }
            }
            else
            {
                lblMensaje.Text = "ID de curso inválido.";
                lblMensaje.Visible = true;
            }
        }

        // Método para cargar los datos del curso en el formulario
        private void CargarDatosCurso(int cursoId)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (var command = new NpgsqlCommand("SELECT * FROM curso WHERE id = @cursoId", connection))
                    {
                        command.Parameters.AddWithValue("cursoId", cursoId);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Rellenar los controles con los datos del curso
                                txtNombre.Text = reader["nombre"].ToString();
                                txtDescripcion.Text = reader["descripcion"].ToString();
                                txtFechaInicio.Text = Convert.ToDateTime(reader["fecha_inicio"]).ToString("yyyy-MM-dd");
                                txtFechaFin.Text = Convert.ToDateTime(reader["fecha_fin"]).ToString("yyyy-MM-dd");
                                txtHorasMinimas.Text = reader["horas_minimas"].ToString();
                            }
                            else
                            {
                                lblMensaje.Text = "Curso no encontrado.";
                                lblMensaje.Visible = true;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    lblMensaje.Text = "Error al cargar los datos del curso: " + ex.Message;
                    lblMensaje.Visible = true;
                }
            }
        }

        // Evento para guardar los cambios del curso
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ActualizarCurso(cursoId);
        }

        private void ActualizarCurso(int cursoId)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Usamos ExecuteNonQuery porque no estamos esperando un valor de retorno, solo ejecutamos la actualización
                    using (var command = new NpgsqlCommand("SELECT editar_curso(@cursoId, @nombre, @descripcion, @fecha_inicio, @fecha_fin, @horas_minimas);", connection))
                    {
                        // Asignar los parámetros para la función de actualización
                        command.Parameters.AddWithValue("cursoId", cursoId);  // INT
                        command.Parameters.AddWithValue("nombre", txtNombre.Text);  // VARCHAR
                        command.Parameters.AddWithValue("descripcion", txtDescripcion.Text);  // TEXT
                        command.Parameters.AddWithValue("fecha_inicio", DateTime.Parse(txtFechaInicio.Text));  // DATE
                        command.Parameters.AddWithValue("fecha_fin", DateTime.Parse(txtFechaFin.Text));  // DATE
                        command.Parameters.AddWithValue("horas_minimas", int.Parse(txtHorasMinimas.Text));  // INT

                        // Ejecutar la función en PostgreSQL
                        command.ExecuteNonQuery();  // Usamos ExecuteNonQuery para ejecutar la actualización

                        // Mostrar el resultado en un mensaje de alerta
                        lblMensaje.Text = "Curso actualizado exitosamente.";
                        lblMensaje.Visible = true;

                        // Redirigir a la página de lista de cursos después de la actualización
                        Response.Redirect("ListarCursos.aspx");
                    }
                }
                catch (Exception ex)
                {
                    // Manejo de errores
                    lblMensaje.Text = "Error al actualizar el curso: " + ex.Message;
                    lblMensaje.Visible = true;
                }
            }
        }


    }
}
