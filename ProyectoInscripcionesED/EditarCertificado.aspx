<%@ Page Title="Editar Certificado" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarCertificado.aspx.cs" Inherits="ProyectoInscripcionesED.EditarCertificado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Editar Certificado</h2>

    <!-- Formulario para editar el certificado -->
    <form id="formEditarCertificado" runat="server">
        <!-- Mensaje de éxito o error -->
        <asp:Label ID="lblMensaje" runat="server" ForeColor="Green"></asp:Label><br />

        <!-- Seleccionar Usuario -->
        <div>
            <label for="ddlUsuario">Usuario:</label>
            <asp:DropDownList ID="ddlUsuario" runat="server" CssClass="form-control" required>
                <asp:ListItem Value="" Text="Seleccione un usuario"></asp:ListItem>
            </asp:DropDownList>
        </div><br />

        <!-- Seleccionar Curso -->
        <div>
            <label for="ddlCurso">Curso:</label>
            <asp:DropDownList ID="ddlCurso" runat="server" CssClass="form-control" required>
                <asp:ListItem Value="" Text="Seleccione un curso"></asp:ListItem>
            </asp:DropDownList>
        </div><br />

        <!-- Botón para guardar los cambios -->
        <div>
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar Cambios" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
        </div>
    </form>
</asp:Content>
