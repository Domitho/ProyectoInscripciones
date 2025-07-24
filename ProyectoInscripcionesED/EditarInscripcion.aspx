<%@ Page Title="Editar Inscripción" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarInscripcion.aspx.cs" Inherits="ProyectoInscripcionesED.EditarInscripcion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Editar Inscripción</h2>

    <!-- Formulario para editar la inscripción -->
    <form id="formEditarInscripcion" runat="server">
        <!-- Mensaje de éxito o error -->
        <asp:Label ID="lblMensaje" runat="server" ForeColor="Green"></asp:Label><br />

        <!-- Seleccionar Usuario -->
        <div>
            <label for="ddlUsuario">Usuario:</label>
            <asp:DropDownList ID="ddlUsuario" runat="server" CssClass="form-control" required>
                <asp:ListItem Value="" Text="Seleccione un usuario"></asp:ListItem>
            </asp:DropDownList>
        </div><br />

        <!-- Seleccionar Taller -->
        <div>
            <label for="ddlTaller">Taller:</label>
            <asp:DropDownList ID="ddlTaller" runat="server" CssClass="form-control" required>
                <asp:ListItem Value="" Text="Seleccione un taller"></asp:ListItem>
            </asp:DropDownList>
        </div><br />

        <!-- Estado de la Inscripción -->
        <div>
            <label for="ddlEstado">Estado:</label>
            <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-control" required>
                <asp:ListItem Value="pendiente" Text="Pendiente"></asp:ListItem>
                <asp:ListItem Value="confirmado" Text="Confirmado"></asp:ListItem>
                <asp:ListItem Value="cancelado" Text="Cancelado"></asp:ListItem>
            </asp:DropDownList>
        </div><br />

        <!-- Botón para guardar la inscripción -->
        <div>
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar Cambios" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
        </div>
    </form>
</asp:Content>
