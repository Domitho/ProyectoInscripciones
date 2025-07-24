<%@ Page Title="Editar Usuario" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarUsuario.aspx.cs" Inherits="ProyectoInscripcionesED.EditarUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="my-4">Editar Usuario</h1>

    <asp:Label ID="lblMensaje" runat="server" Text="" ForeColor="Red" Visible="false" />

    <!-- Formulario de edición de usuario -->
    <form id="form1" runat="server">
        <div class="form-group">
            <label for="txtNombres">Nombres</label>
            <asp:TextBox ID="txtNombres" runat="server" CssClass="form-control" placeholder="Ingrese el nombre" MaxLength="100"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="txtApellidos">Apellidos</label>
            <asp:TextBox ID="txtApellidos" runat="server" CssClass="form-control" placeholder="Ingrese el apellido" MaxLength="100"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="txtCorreo">Correo</label>
            <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control" placeholder="Ingrese el correo" MaxLength="100"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="txtTelefono">Teléfono</label>
            <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" placeholder="Ingrese el teléfono" MaxLength="20"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="ddlTipoUsuario">Tipo de Usuario</label>
            <asp:DropDownList ID="ddlTipoUsuario" runat="server" CssClass="form-control">
                <asp:ListItem Value="participante">Participante</asp:ListItem>
                <asp:ListItem Value="instructor">Instructor</asp:ListItem>
            </asp:DropDownList>
        </div>

        <!-- Botón para guardar los cambios -->
        <button type="submit" class="btn btn-primary" id="btnGuardar">Guardar Cambios</button>
    </form>
</asp:Content>
