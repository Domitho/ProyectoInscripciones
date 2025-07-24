using System;
using System.Data;
using System.Configuration;
using Npgsql;
using System.Web.UI.WebControls;

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

        // Método para cargar los certificados
        private void CargarCertificados()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["PostgresConnection"].ToString();

            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                string sql = @"
                    SELECT c.id, u.nombres AS usuario_nombre, cu.nombre AS curso_nombre
                    FROM certificado c
                    JOIN usuario u ON c.usuario_id = u.id
                    JOIN curso cu ON c.curso_id = cu.id
                ";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);

                        // Vinculamos los datos al GridView
                        gvCertificados.DataSource = dt;
                        gvCertificados.DataBind();
                    }
                }
            }
        }

        // Manejo del comando de los botones (Detalles, Editar, Eliminar)
        protected void gvCertificados_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idCertificado = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Detalles")
            {
                // Redirigir a la página de detalles con el ID del certificado
                Response.Redirect("DetallesCertificado.aspx?id=" + idCertificado);
            }
            else if (e.CommandName == "Editar")
            {
                // Redirigir a la página de edición con el ID del certificado
                Response.Redirect("EditarCertificado.aspx?id=" + idCertificado);
            }
            else if (e.CommandName == "Eliminar")
            {
                // Eliminar el certificado de la base de datos
                EliminarCertificado(idCertificado);
            }
        }

        // Método para eliminar un certificado
        // Dentro del evento RowCommand para Eliminar, Editar o Detalles:
        private void EliminarCertificado(int idCertificado)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["PostgresConnection"].ToString();

            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                string sql = "DELETE FROM certificado WHERE id = @idCertificado";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("idCertificado", idCertificado);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        lblMensaje.Text = "Certificado eliminado correctamente.";  // Mensaje de éxito
                        lblMensaje.ForeColor = System.Drawing.Color.Green;
                        CargarCertificados(); // Recargar los certificados
                    }
                    else
                    {
                        lblMensaje.Text = "No se pudo eliminar el certificado. Intente de nuevo.";  // Mensaje de error
                        lblMensaje.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
        }
        protected void btnAgregarCertificado_Click(object sender, EventArgs e)
        {
            // Aquí puedes redirigir a la página de agregar un nuevo certificado, por ejemplo:
            Response.Redirect("AgregarCertificado.aspx");
        }


    }
}
