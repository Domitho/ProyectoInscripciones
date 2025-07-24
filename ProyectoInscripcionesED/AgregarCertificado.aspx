<%@ Page Title="Agregar Certificado" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarCertificado.aspx.cs" Inherits="ProyectoInscripcionesED.AgregarCertificado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <h2 class="text-center">Agregar Certificado</h2>

        <!-- Formulario para agregar el certificado -->
        <form id="formAgregarCertificado" runat="server">
            <!-- Mensaje de éxito o error -->
            <div class="alert" role="alert">
                <asp:Label ID="lblMensaje" runat="server" CssClass="d-none" ForeColor="Green"></asp:Label>
            </div>

            <!-- Seleccionar Usuario -->
            <div class="form-group">
                <label for="ddlUsuario">Usuario:</label>
                <asp:DropDownList ID="ddlUsuario" runat="server" CssClass="form-control" required>
                    <asp:ListItem Value="" Text="Seleccione un usuario"></asp:ListItem>
                </asp:DropDownList>
            </div>

            <!-- Seleccionar Curso -->
            <div class="form-group">
                <label for="ddlCurso">Curso:</label>
                <asp:DropDownList ID="ddlCurso" runat="server" CssClass="form-control" required>
                    <asp:ListItem Value="" Text="Seleccione un curso"></asp:ListItem>
                </asp:DropDownList>
            </div>

            <!-- Botón para guardar el certificado -->
            <div class="form-group text-center">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar Certificado" CssClass="btn btn-primary btn-lg" OnClick="btnGuardar_Click" />
            </div>
        </form>
    </div>
</asp:Content>
