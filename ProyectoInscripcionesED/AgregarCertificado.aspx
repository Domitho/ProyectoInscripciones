<%@ Page Title="Agregar Certificado" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarCertificado.aspx.cs" Inherits="ProyectoInscripcionesED.AgregarCertificado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <h2 class="text-center mb-4">Agregar Certificado</h2>

        <!-- Formulario para agregar el certificado -->
        <form id="formAgregarCertificado" runat="server">
            <!-- Mensaje de éxito o error -->
            <div class="alert" role="alert">
                <asp:Label ID="lblMensaje" runat="server" CssClass="d-none" ForeColor="Green"></asp:Label>
            </div>

            <!-- Seleccionar Usuario -->
            <div class="mb-3">
                <label for="ddlUsuario" class="form-label">Usuario:</label>
                <asp:DropDownList ID="ddlUsuario" runat="server" CssClass="form-select" required>
                    <asp:ListItem Value="" Text="Seleccione un usuario"></asp:ListItem>
                </asp:DropDownList>
            </div>

            <!-- Seleccionar Curso -->
            <div class="mb-3">
                <label for="ddlCurso" class="form-label">Curso:</label>
                <asp:DropDownList ID="ddlCurso" runat="server" CssClass="form-select" required>
                    <asp:ListItem Value="" Text="Seleccione un curso"></asp:ListItem>
                </asp:DropDownList>
            </div>

            <!-- Botón para guardar el certificado -->
            <div class="text-center">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar Certificado" CssClass="btn btn-primary btn-lg" OnClick="btnGuardar_Click" />
            </div>
        </form>
    </div>
</asp:Content>
