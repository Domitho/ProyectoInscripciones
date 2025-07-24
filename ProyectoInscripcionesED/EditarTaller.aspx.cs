using System;
using System.Data;
using System.Configuration;
using Npgsql;
using System.Web.UI.WebControls;

namespace ProyectoInscripcionesED
{
    public partial class EditarTaller : System.Web.UI.Page
    {
        private int idTaller;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                idTaller = Convert.ToInt32(Request.QueryString["id"]);
            }
            else
            {
                Response.Redirect("ListarTaller.aspx");
            }

            if (!IsPostBack)
            {
                CargarTaller();
                CargarCursos();
                CargarInstructores();
            }
        }

        private void CargarTaller()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["PostgresConnection"].ToString();

            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                string sql = "SELECT nombre, descripcion, fecha, hora_inicio, hora_fin, duracion_horas, curso_id, instructor_id FROM taller WHERE id = @idTaller";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("idTaller", idTaller);

                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtNombre.Text = reader["nombre"].ToString();
                            txtDescripcion.Text = reader["descripcion"].ToString();
                            txtFecha.Text = Convert.ToDateTime(reader["fecha"]).ToString("yyyy-MM-dd");

                            // Convertir TimeSpan a formato de cadena adecuado para TEXT (no se necesita conversión para pasar a la base de datos)
                            txtHoraInicio.Text = ((TimeSpan)reader["hora_inicio"]).ToString(@"hh\:mm");
                            txtHoraFin.Text = ((TimeSpan)reader["hora_fin"]).ToString(@"hh\:mm");

                            txtDuracion.Text = reader["duracion_horas"].ToString();
                            ddlCurso.SelectedValue = reader["curso_id"].ToString();
                            ddlInstructor.SelectedValue = reader["instructor_id"].ToString();
                        }
                    }
                }
            }
        }

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

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string descripcion = txtDescripcion.Text;
            DateTime fecha = DateTime.Parse(txtFecha.Text);

            // Convertir las horas a TimeSpan
            TimeSpan horaInicio = TimeSpan.Parse(txtHoraInicio.Text); // Usando TimeSpan
            TimeSpan horaFin = TimeSpan.Parse(txtHoraFin.Text);       // Usando TimeSpan

            int duracionHoras = int.Parse(txtDuracion.Text);
            int cursoId = int.Parse(ddlCurso.SelectedValue);
            int instructorId = int.Parse(ddlInstructor.SelectedValue);

            string connectionString = ConfigurationManager.ConnectionStrings["PostgresConnection"].ToString();

            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                string sql = "UPDATE taller SET nombre = @nombre, descripcion = @descripcion, fecha = @fecha, hora_inicio = @hora_inicio, hora_fin = @hora_fin, duracion_horas = @duracion_horas, curso_id = @curso_id, instructor_id = @instructor_id WHERE id = @idTaller";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("nombre", nombre);
                    cmd.Parameters.AddWithValue("descripcion", descripcion);
                    cmd.Parameters.AddWithValue("fecha", fecha);

                    // Pasar TimeSpan directamente
                    cmd.Parameters.AddWithValue("hora_inicio", horaInicio);
                    cmd.Parameters.AddWithValue("hora_fin", horaFin);

                    cmd.Parameters.AddWithValue("duracion_horas", duracionHoras);
                    cmd.Parameters.AddWithValue("curso_id", cursoId);
                    cmd.Parameters.AddWithValue("instructor_id", instructorId);
                    cmd.Parameters.AddWithValue("idTaller", idTaller);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        lblMensaje.Text = "Taller actualizado correctamente.";
                        lblMensaje.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        lblMensaje.Text = "No se pudo actualizar el taller. Intente de nuevo.";
                        lblMensaje.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
        }
    }
}
