using System;
using System.Text;
using System.Configuration;
using Npgsql;

namespace ProyectoInscripcionesED
{
    public partial class ListarCursosPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListarCursos();
            }
        }

        private void ListarCursos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<table id='tblCursos' class='table table-striped table-bordered' style='width:100%'>");
            sb.Append("<thead><tr><th>ID</th><th>Nombre</th><th>Descripción</th><th>Fecha Inicio</th><th>Fecha Fin</th><th>Horas Mínimas</th><th>Acciones</th></tr></thead><tbody>");

            string connStr = ConfigurationManager.ConnectionStrings["PostgresConnection"].ConnectionString;

            using (var conn = new NpgsqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand("SELECT * FROM listar_cursos();", conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                int cursoId = Convert.ToInt32(reader["curso_id"]);

                                sb.Append("<tr>");
                                sb.Append($"<td>{cursoId}</td>");
                                sb.Append($"<td>{reader["nombre"]}</td>");
                                sb.Append($"<td>{reader["descripcion"]}</td>");
                                sb.Append($"<td>{reader["fecha_inicio"]}</td>");
                                sb.Append($"<td>{reader["fecha_fin"]}</td>");
                                sb.Append($"<td>{reader["horas_minimas"]}</td>");
                                sb.Append("<td>");
                                sb.Append($"<a href='EditarCurso.aspx?cursoId={cursoId}' class='btn btn-warning btn-sm'>Editar</a>&nbsp;");
                                sb.Append($"<a href='EliminarCurso.aspx?cursoId={cursoId}' class='btn btn-danger btn-sm' onclick=\"return confirm('¿Eliminar este curso?')\">Eliminar</a>");
                                sb.Append("</td>");
                                sb.Append("</tr>");
                            }
                        }
                        else
                        {
                            sb.Append("<tr><td colspan='7' class='text-center'>No se han encontrado cursos.</td></tr>");
                        }
                    }
                }
                catch (Exception ex)
                {
                    sb.Append($"<tr><td colspan='7' class='text-danger text-center'>Error al listar cursos: {ex.Message}</td></tr>");
                }
            }

            sb.Append("</tbody></table>");
            ltTabla.Text = sb.ToString();
        }

        protected void btnAgregarCurso_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarCurso.aspx");
        }
    }
}
