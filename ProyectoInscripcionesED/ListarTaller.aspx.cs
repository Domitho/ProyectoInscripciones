using System;
using System.Text;
using System.Configuration;
using Npgsql;

namespace ProyectoInscripcionesED
{
    public partial class ListarTaller : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTalleres();
            }
        }

        private void CargarTalleres()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<table id='tblTalleres' class='table table-striped table-bordered' style='width:100%'>");
            sb.Append("<thead><tr><th>ID</th><th>Nombre</th><th>Descripción</th><th>Fecha</th><th>Inicio</th><th>Fin</th><th>Duración</th><th>ID Curso</th><th>ID Instructor</th><th>Acciones</th></tr></thead><tbody>");

            string connStr = ConfigurationManager.ConnectionStrings["PostgresConnection"].ToString();

            using (NpgsqlConnection conn = new NpgsqlConnection(connStr))
            {
                conn.Open();
                string sql = @"
                    SELECT id,
                           nombre,
                           descripcion,
                           fecha::text,
                           hora_inicio::text,
                           hora_fin::text,
                           duracion_horas,
                           curso_id,
                           instructor_id
                    FROM taller
                    ORDER BY id";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["id"]);

                        sb.Append("<tr>");
                        sb.Append($"<td>{id}</td>");
                        sb.Append($"<td>{reader["nombre"]}</td>");
                        sb.Append($"<td>{reader["descripcion"]}</td>");
                        sb.Append($"<td>{reader["fecha"]}</td>");
                        sb.Append($"<td>{reader["hora_inicio"]}</td>");
                        sb.Append($"<td>{reader["hora_fin"]}</td>");
                        sb.Append($"<td>{reader["duracion_horas"]} h</td>");
                        sb.Append($"<td>{reader["curso_id"]}</td>");
                        sb.Append($"<td>{reader["instructor_id"]}</td>");
                        sb.Append("<td>");
                        sb.Append($"<a href='EditarTaller.aspx?id={id}' class='btn btn-warning btn-sm'>Editar</a>&nbsp;");
                        sb.Append($"<a href='EliminarTaller.aspx?id={id}' class='btn btn-danger btn-sm' onclick=\"return confirm('¿Eliminar este taller?')\">Eliminar</a>");
                        sb.Append("</td>");
                        sb.Append("</tr>");
                    }
                }
            }

            sb.Append("</tbody></table>");
            ltTabla.Text = sb.ToString();
        }

        protected void btnAgregarTaller_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarTaller.aspx");
        }
    }
}