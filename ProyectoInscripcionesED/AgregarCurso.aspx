<%@ Page Title="Agregar Curso" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarCurso.aspx.cs" Inherits="ProyectoInscripcionesED.AgregarCurso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Formulario de Agregar Curso</h2>
        
    <form id="formAgregarCurso" runat="server">
        <asp:Label ID="lblMensaje" runat="server" ForeColor="Green"></asp:Label>
        <br />

        <asp:TextBox ID="txtNombreCurso" runat="server" placeholder="Nombre del curso" CssClass="form-control" required></asp:TextBox><br />
        <asp:TextBox ID="txtDescripcionCurso" runat="server" placeholder="Descripción del curso" TextMode="MultiLine" CssClass="form-control" required></asp:TextBox><br />
        <asp:TextBox ID="txtFechaInicio" runat="server" placeholder="Fecha de inicio" CssClass="form-control" TextMode="Date" required></asp:TextBox><br />
        <asp:TextBox ID="txtFechaFin" runat="server" placeholder="Fecha de fin" CssClass="form-control" TextMode="Date" required></asp:TextBox><br />
        <asp:TextBox ID="txtHorasMinimas" runat="server" placeholder="Horas mínimas" CssClass="form-control" TextMode="Number" required></asp:TextBox><br />

        <asp:Button ID="btnAgregarCurso" runat="server" Text="Agregar Curso" CssClass="btn btn-primary" OnClick="btnAgregarCurso_Click" />
    </form>
</asp:Content>
