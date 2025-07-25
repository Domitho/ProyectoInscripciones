using System;
using System.Text;
using System.Configuration;
using Npgsql;

namespace ProyectoInscripcionesED
{
    public partial class ListaInscripcion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarInscripciones();
            }
        }

        private void CargarInscripciones()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<table id='tblInscripciones' class='table table-hover table-bordered align-middle' style='width:100%'>");
            sb.Append("<thead class='table-primary'>");
            sb.Append("<tr>");
            sb.Append("<th>ID</th>");
            sb.Append("<th>Usuario</th>");
            sb.Append("<th>Taller</th>");
            sb.Append("<th>Estado</th>");
            sb.Append("<th>Acciones</th>");
            sb.Append("</tr>");
            sb.Append("</thead><tbody>");

            string connStr = ConfigurationManager.ConnectionStrings["PostgresConnection"].ConnectionString;

            using (var conn = new NpgsqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string sql = @"
                        SELECT i.id,
                               u.nombres AS usuario_nombre,
                               t.nombre AS taller_nombre,
                               i.estado
                        FROM inscripcion i
                        JOIN usuario u ON i.usuario_id = u.id
                        JOIN taller t ON i.taller_id = t.id
                        ORDER BY i.id";

                    using (var cmd = new NpgsqlCommand(sql, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                int id = Convert.ToInt32(reader["id"]);
                                string estado = reader["estado"].ToString();

                                sb.Append("<tr>");
                                sb.Append($"<td>{id}</td>");
                                sb.Append($"<td>{reader["usuario_nombre"]}</td>");
                                sb.Append($"<td>{reader["taller_nombre"]}</td>");
                                sb.Append($"<td><span class='badge {(estado == "Activo" ? "bg-success" : "bg-secondary")}'>{estado}</span></td>");
                                sb.Append("<td>");
                                sb.Append($"<a href='EditarInscripcion.aspx?id={id}' class='btn btn-sm btn-outline-warning'>✏️ Editar</a> ");
                                sb.Append($"<a href='EliminarInscripcion.aspx?id={id}' class='btn btn-sm btn-outline-danger' onclick=\"return confirm('¿Eliminar esta inscripción?')\">🗑️ Eliminar</a>");
                                sb.Append("</td>");
                                sb.Append("</tr>");
                            }
                        }
                        else
                        {
                            sb.Append("<tr><td colspan='5' class='text-center text-muted'>No se encontraron inscripciones.</td></tr>");
                        }
                    }
                }
                catch (Exception ex)
                {
                    sb.Append($"<tr><td colspan='5' class='text-center text-danger'>Error: {ex.Message}</td></tr>");
                }
            }

            sb.Append("</tbody></table>");
            ltTabla.Text = sb.ToString();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarInscripcion.aspx");
        }
    }
}