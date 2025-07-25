using System;
using System.Text;
using System.Configuration;
using Npgsql;

namespace ProyectoInscripcionesED
{
    public partial class ListarUsuario : System.Web.UI.Page
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["PostgresConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListarUsuarios();
            }
        }

        private void ListarUsuarios()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<table id='tblUsuarios' class='table table-hover table-bordered align-middle' style='width:100%'>");
            sb.Append("<thead class='table-primary'>");
            sb.Append("<tr>");
            sb.Append("<th>ID</th>");
            sb.Append("<th>Nombres</th>");
            sb.Append("<th>Apellidos</th>");
            sb.Append("<th>Correo</th>");
            sb.Append("<th>Teléfono</th>");
            sb.Append("<th>Tipo</th>");
            sb.Append("<th>Acciones</th>");
            sb.Append("</tr></thead><tbody>");

            using (var conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand("SELECT * FROM listar_usuarios();", conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                int id = Convert.ToInt32(reader["usuario_id"]);
                                string tipo = reader["usuario_tipo_usuario"].ToString();
                                string badge = tipo == "Instructor" ? "bg-warning text-dark" : "bg-info text-white";

                                sb.Append("<tr>");
                                sb.Append($"<td>{id}</td>");
                                sb.Append($"<td>{reader["usuario_nombres"]}</td>");
                                sb.Append($"<td>{reader["usuario_apellidos"]}</td>");
                                sb.Append($"<td>{reader["usuario_correo"]}</td>");
                                sb.Append($"<td>{reader["usuario_telefono"]}</td>");
                                sb.Append($"<td><span class='badge {badge}'>{tipo}</span></td>");
                                sb.Append("<td>");
                                sb.Append($"<a href='EditarUsuario.aspx?usuarioId={id}' class='btn btn-sm btn-outline-warning'>✏️ Editar</a> ");
                                sb.Append($"<a href='EliminarUsuario.aspx?usuarioId={id}' class='btn btn-sm btn-outline-danger' onclick=\"return confirm('¿Eliminar este usuario?')\">🗑️ Eliminar</a>");
                                sb.Append("</td>");
                                sb.Append("</tr>");
                            }
                        }
                        else
                        {
                            sb.Append("<tr><td colspan='7' class='text-center text-muted'>No hay usuarios registrados.</td></tr>");
                        }
                    }
                }
                catch (Exception ex)
                {
                    sb.Append($"<tr><td colspan='7' class='text-center text-danger'>Error: {ex.Message}</td></tr>");
                }
            }

            sb.Append("</tbody></table>");
            ltTabla.Text = sb.ToString();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarUsuario.aspx");
        }
    }
}