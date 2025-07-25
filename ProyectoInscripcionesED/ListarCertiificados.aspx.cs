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
                    sb.Append("<table id='tblCertificados' class='table table-striped table-bordered' style='width:100%'>");
                    sb.Append("<thead><tr><th>ID</th><th>Usuario</th><th>Curso</th><th>Acciones</th></tr></thead><tbody>");

                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["id"]);

                        sb.Append("<tr>");
                        sb.Append($"<td>{id}</td>");
                        sb.Append($"<td>{reader["usuario_nombre"]}</td>");
                        sb.Append($"<td>{reader["curso_nombre"]}</td>");
                        sb.Append("<td>");
                        sb.Append($"<a href='EditarCertificado.aspx?id={id}' class='btn btn-warning btn-sm'>Editar</a>&nbsp;");
                        sb.Append($"<a href='EliminarCertificado.aspx?id={id}' class='btn btn-danger btn-sm' onclick=\"return confirm('¿Está seguro de eliminar?')\">Eliminar</a>");
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