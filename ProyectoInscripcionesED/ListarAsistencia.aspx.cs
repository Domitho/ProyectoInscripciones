using System;
using System.Text;
using System.Configuration;
using Npgsql;

namespace ProyectoInscripcionesED
{
    public partial class ListarAsistencia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarAsistencias();
            }
        }

        private void CargarAsistencias()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<table id='tblAsistencia' class='table table-striped table-bordered' style='width:100%'>");
            sb.Append("<thead><tr><th>ID</th><th>ID Inscripción</th><th>Usuario</th><th>Asistió</th><th>Acciones</th></tr></thead><tbody>");

            string connStr = ConfigurationManager.ConnectionStrings["PostgresConnection"].ToString();

            using (NpgsqlConnection conn = new NpgsqlConnection(connStr))
            {
                conn.Open();
                string sql = @"
                    SELECT a.id,
                           a.inscripcion_id,
                           u.nombres AS usuario_nombre,
                           a.asistio
                    FROM asistencia a
                    JOIN inscripcion i ON a.inscripcion_id = i.id
                    JOIN usuario u     ON i.usuario_id    = u.id
                    ORDER BY a.id";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["id"]);
                        bool asistio = Convert.ToBoolean(reader["asistio"]);

                        sb.Append("<tr>");
                        sb.Append($"<td>{id}</td>");
                        sb.Append($"<td>{reader["inscripcion_id"]}</td>");
                        sb.Append($"<td>{reader["usuario_nombre"]}</td>");
                        sb.Append($"<td>{(asistio ? "Sí" : "No")}</td>");
                        sb.Append("<td>");
                        if (!asistio)
                        {
                            sb.Append($"<a href='MarcarAsistencia.aspx?id={id}' class='btn btn-success btn-sm' onclick=\"return confirm('¿Marcar asistencia?')\">Marcar</a>");
                        }
                        else
                        {
                            sb.Append("<span class='badge bg-success'>Asistió</span>");
                        }
                        sb.Append("</td>");
                        sb.Append("</tr>");
                    }
                }
            }

            sb.Append("</tbody></table>");
            ltTabla.Text = sb.ToString();
        }

        protected void btnAgregarAsistencia_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarAsistencia.aspx");
        }
    }
}