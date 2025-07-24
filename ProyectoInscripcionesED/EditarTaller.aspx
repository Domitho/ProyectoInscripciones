<%@ Page Title="Editar Taller" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarTaller.aspx.cs" Inherits="ProyectoInscripcionesED.EditarTaller" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Editar Taller</h2>

    <form id="formEditarTaller" runat="server">
        <asp:Label ID="lblMensaje" runat="server" ForeColor="Green"></asp:Label>
        <br />

        <asp:TextBox ID="txtNombre" runat="server" placeholder="Nombre del taller" CssClass="form-control" required></asp:TextBox><br />

        <asp:TextBox ID="txtDescripcion" runat="server" placeholder="Descripción del taller" TextMode="MultiLine" CssClass="form-control"></asp:TextBox><br />

        <asp:TextBox ID="txtFecha" runat="server" placeholder="Fecha del taller" CssClass="form-control" TextMode="Date" required></asp:TextBox><br />

        <asp:TextBox ID="txtHoraInicio" runat="server" placeholder="Hora de inicio" CssClass="form-control" TextMode="Time" required></asp:TextBox><br />

        <asp:TextBox ID="txtHoraFin" runat="server" placeholder="Hora de fin" CssClass="form-control" TextMode="Time" required></asp:TextBox><br />

        <asp:TextBox ID="txtDuracion" runat="server" placeholder="Duración (en horas)" CssClass="form-control" TextMode="Number" required></asp:TextBox><br />

        <asp:DropDownList ID="ddlCurso" runat="server" CssClass="form-control" required>
            <asp:ListItem Value="" Text="Seleccione un curso"></asp:ListItem>
        </asp:DropDownList><br />

        <asp:DropDownList ID="ddlInstructor" runat="server" CssClass="form-control" required>
            <asp:ListItem Value="" Text="Seleccione un instructor"></asp:ListItem>
        </asp:DropDownList><br />

        <asp:Button ID="btnGuardar" runat="server" Text="Guardar Cambios" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
    </form>
</asp:Content>
