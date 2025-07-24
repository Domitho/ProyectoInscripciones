<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="ProyectoInscripcionesED.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <h2 class="text-center">Crear Cuenta</h2>
        <form id="formRegistro" runat="server">
            <!-- Correo -->
            <div class="form-group">
                <label for="correo">Correo:</label>
                <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control" placeholder="Correo" />
            </div>
            
            <!-- Contraseña -->
            <div class="form-group">
                <label for="password">Contraseña:</label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="Contraseña" />
            </div>
            
            <!-- Nombres -->
            <div class="form-group">
                <label for="nombres">Nombres:</label>
                <asp:TextBox ID="txtNombres" runat="server" CssClass="form-control" placeholder="Nombres" />
            </div>
            
            <!-- Apellidos -->
            <div class="form-group">
                <label for="apellidos">Apellidos:</label>
                <asp:TextBox ID="txtApellidos" runat="server" CssClass="form-control" placeholder="Apellidos" />
            </div>
            
            <!-- Teléfono -->
            <div class="form-group">
                <label for="telefono">Teléfono:</label>
                <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" placeholder="Teléfono" />
            </div>
            
            <!-- Tipo de Usuario -->
            <div class="form-group">
                <label for="tipo_usuario">Tipo de Usuario:</label>
                <asp:DropDownList ID="ddlTipoUsuario" runat="server" CssClass="form-control">
                    <asp:ListItem Text="Selecciona el tipo de usuario" Value="" />
                    <asp:ListItem Text="Participante" Value="participante" />
                    <asp:ListItem Text="Instructor" Value="instructor" />
                </asp:DropDownList>
            </div>
            
            <!-- Botón de Registro -->
            <div class="form-group text-center">
                <asp:Button ID="btnRegister" runat="server" Text="Registrar" CssClass="btn btn-primary btn-lg" OnClick="btnRegister_Click" />
            </div>
            
            <!-- Mensaje de error o éxito -->
            <div class="form-group text-center">
                <asp:Label ID="lblMensaje" runat="server" CssClass="text-success"></asp:Label>
                <asp:Label ID="lblError" runat="server" CssClass="text-danger"></asp:Label>
            </div>
        </form>
    </div>
</asp:Content>
