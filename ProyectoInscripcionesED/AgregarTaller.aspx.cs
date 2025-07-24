using System;
using System.Data;
using System.Configuration;
using Npgsql;
using System.Web.UI.WebControls;

namespace ProyectoInscripcionesED
{
    public partial class AgregarTaller : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Cargar los cursos y los instructores en los dropdowns cuando la página se carga por primera vez
                CargarCursos();
                CargarInstructores();
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

        // Método para cargar los instructores en el DropDownList
        private void CargarInstructores()
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
                        ddlInstructor.Items.Clear();
                        while (reader.Read())
                        {
                            ddlInstructor.Items.Add(new ListItem(reader["nombres"].ToString(), reader["id"].ToString()));
                        }
                    }
                }
            }
        }

        // Método para insertar el taller en la base de datos
        protected void btnAgregarTaller_Click(object sender, EventArgs e)
        {
            string nombreTaller = txtNombre.Text;
            string descripcionTaller = txtDescripcion.Text;
            DateTime fechaTaller = DateTime.Parse(txtFecha.Text);
            TimeSpan horaInicio = TimeSpan.Parse(txtHoraInicio.Text);
            TimeSpan horaFin = TimeSpan.Parse(txtHoraFin.Text);
            int duracionHoras = int.Parse(txtDuracion.Text);
            int cursoId = int.Parse(ddlCurso.SelectedValue);
            int instructorId = int.Parse(ddlInstructor.SelectedValue);

            string connectionString = ConfigurationManager.ConnectionStrings["PostgresConnection"].ToString();

            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "INSERT INTO taller (nombre, descripcion, fecha, hora_inicio, hora_fin, duracion_horas, curso_id, instructor_id) " +
                                 "VALUES (@nombre, @descripcion, @fecha, @hora_inicio, @hora_fin, @duracion_horas, @curso_id, @instructor_id)";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("nombre", nombreTaller);
                        cmd.Parameters.AddWithValue("descripcion", descripcionTaller);
                        cmd.Parameters.AddWithValue("fecha", fechaTaller);
                        cmd.Parameters.AddWithValue("hora_inicio", horaInicio);
                        cmd.Parameters.AddWithValue("hora_fin", horaFin);
                        cmd.Parameters.AddWithValue("duracion_horas", duracionHoras);
                        cmd.Parameters.AddWithValue("curso_id", cursoId);
                        cmd.Parameters.AddWithValue("instructor_id", instructorId);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            lblMensaje.Text = "Taller agregado exitosamente.";
                            lblMensaje.ForeColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            lblMensaje.Text = "No se pudo agregar el taller. Intente de nuevo.";
                            lblMensaje.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al agregar el taller: " + ex.Message;
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}
