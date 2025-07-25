using System;
using System.Text;
using System.Configuration;
using System.Data;
using Npgsql;

namespace ProyectoInscripcionesED
{
    public partial class ListarCertificados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCertificados();
            }
        }

        private void CargarCertificados()
        {
            StringBuilder sb = new StringBuilder();

            string connStr = ConfigurationManager.ConnectionStrings["PostgresConnection"].ToString();

            using (NpgsqlConnection conn = new NpgsqlConnection(connStr))
            {
                conn.Open();
                string sql = @"
                    SELECT c.id,
                           u.nombres AS usuario_nombre,
                           cu.nombre AS curso_nombre
                    FROM certificado c
                    JOIN usuario u ON c.usuario_id = u.id
                    JOIN curso   cu ON c.curso_id   = cu.id
                    ORDER BY c.id";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    sb.Append("<table id='tblCertificados' class='table table-hover table-bordered align-middle' style='width:100%'>");
                    sb.Append("<thead class='table-primary'>");
                    sb.Append("<tr>");
                    sb.Append("<th>ID</th>");
                    sb.Append("<th>Usuario</th>");
                    sb.Append("<th>Curso</th>");
                    sb.Append("<th>Acciones</th>");
                    sb.Append("</tr></thead><tbody>");

                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["id"]);

                        sb.Append("<tr>");
                        sb.Append($"<td>{id}</td>");
                        sb.Append($"<td>{reader["usuario_nombre"]}</td>");
                        sb.Append($"<td>{reader["curso_nombre"]}</td>");
                        sb.Append("<td>");
                        sb.Append($"<a href='EditarCertificado.aspx?id={id}' class='btn btn-sm btn-outline-warning'>✏️ Editar</a> ");
                        sb.Append($"<a href='EliminarCertificado.aspx?id={id}' class='btn btn-sm btn-outline-danger' onclick=\"return confirm('¿Está seguro de eliminar?')\">🗑️ Eliminar</a>");
                        sb.Append("</td>");
                        sb.Append("</tr>");
                    }

                    sb.Append("</tbody></table>");
                }
            }

            // Inyectar tabla en el Literal
            ltFilas.Text = sb.ToString();
        }

        protected void btnAgregarCertificado_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarCertificado.aspx");
        }
    }
}
