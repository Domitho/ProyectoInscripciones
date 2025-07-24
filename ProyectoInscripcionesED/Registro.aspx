<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="ProyectoInscripcionesED.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Crear Cuenta</h2>
    <form id="formRegistro" runat="server">
        <div class="form-group">
            <label for="correo">Correo:</label>
            <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control" placeholder="Correo" />
        </div>
        <div class="form-group">
            <label for="password">Contraseña:</label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="Contraseña" />
        </div>
        <div class="form-group">
            <label for="nombres">Nombres:</label>
            <asp:TextBox ID="txtNombres" runat="server" CssClass="form-control" placeholder="Nombres" />
        </div>
        <div class="form-group">
            <label for="apellidos">Apellidos:</label>
            <asp:TextBox ID="txtApellidos" runat="server" CssClass="form-control" placeholder="Apellidos" />
        </div>
        <div class="form-group">
            <label for="telefono">Teléfono:</label>
            <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" placeholder="Teléfono" />
        </div>
        <div class="form-group">
            <label for="tipo_usuario">Tipo de Usuario:</label>
            <asp:DropDownList ID="ddlTipoUsuario" runat="server" CssClass="form-control">
                <asp:ListItem Text="Participante" Value="participante" />
                <asp:ListItem Text="Instructor" Value="instructor" />
            </asp:DropDownList>
        </div>
        <div class="form-group">
            <asp:Button ID="btnRegister" runat="server" Text="Registrar" CssClass="btn btn-primary" OnClick="btnRegister_Click" />
        </div>
    </form>
</asp:Content>
