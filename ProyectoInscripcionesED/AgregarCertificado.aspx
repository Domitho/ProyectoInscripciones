<%@ Page Title="Agregar Certificado" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarCertificado.aspx.cs" Inherits="ProyectoInscripcionesED.AgregarCertificado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Agregar Certificado</h2>

    <!-- Formulario para agregar el certificado -->
    <form id="formAgregarCertificado" runat="server">
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

        <!-- Botón para guardar el certificado -->
        <div>
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar Certificado" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
        </div>
    </form>
</asp:Content>
