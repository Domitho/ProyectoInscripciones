<%@ Page Title="Editar Curso" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarCurso.aspx.cs" Inherits="ProyectoInscripcionesED.EditarCurso" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="my-4">Editar Curso</h1>

    <!-- Mensaje de confirmación o error -->
    <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" Visible="false"></asp:Label>

    <!-- Formulario para editar curso -->
    <form id="form1" runat="server">
        <div class="form-group">
            <label for="txtNombre">Nombre</label>
            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" MaxLength="100" />
        </div>

        <div class="form-group">
            <label for="txtDescripcion">Descripción</label>
            <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" TextMode="MultiLine" MaxLength="1000" Rows="4" />
        </div>

        <div class="form-group">
            <label for="txtFechaInicio">Fecha de Inicio</label>
            <asp:TextBox ID="txtFechaInicio" runat="server" CssClass="form-control" TextMode="Date" />
        </div>

        <div class="form-group">
            <label for="txtFechaFin">Fecha de Fin</label>
            <asp:TextBox ID="txtFechaFin" runat="server" CssClass="form-control" TextMode="Date" />
        </div>

        <div class="form-group">
            <label for="txtHorasMinimas">Horas Mínimas</label>
            <asp:TextBox ID="txtHorasMinimas" runat="server" CssClass="form-control" MaxLength="5" />
        </div>

        <!-- Botón para guardar los cambios -->
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar Cambios" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
    </form>
</asp:Content>
