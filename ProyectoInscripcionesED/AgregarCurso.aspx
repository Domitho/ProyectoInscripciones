<%@ Page Title="Agregar Curso" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarCurso.aspx.cs" Inherits="ProyectoInscripcionesED.AgregarCurso" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <h2 class="text-center mb-4">Formulario de Agregar Curso</h2>

        <!-- Mensaje de éxito o error -->
        <div class="alert" role="alert">
            <asp:Label ID="lblMensaje" runat="server" CssClass="d-none" ForeColor="Green"></asp:Label>
        </div>

        <!-- Formulario para agregar curso -->
        <form id="formAgregarCurso" runat="server">
            <!-- Nombre del curso -->
            <div class="form-group">
                <label for="txtNombreCurso">Nombre del Curso:</label>
                <asp:TextBox ID="txtNombreCurso" runat="server" placeholder="Ingrese el nombre del curso" CssClass="form-control" required></asp:TextBox>
            </div>

            <!-- Descripción del curso -->
            <div class="form-group">
                <label for="txtDescripcionCurso">Descripción del Curso:</label>
                <asp:TextBox ID="txtDescripcionCurso" runat="server" placeholder="Describa brevemente el curso" TextMode="MultiLine" CssClass="form-control" required></asp:TextBox>
            </div>

            <!-- Fecha de inicio -->
            <div class="form-group">
                <label for="txtFechaInicio">Fecha de Inicio:</label>
                <asp:TextBox ID="txtFechaInicio" runat="server" placeholder="Seleccione la fecha de inicio" CssClass="form-control" TextMode="Date" required></asp:TextBox>
            </div>

            <!-- Fecha de fin -->
            <div class="form-group">
                <label for="txtFechaFin">Fecha de Fin:</label>
                <asp:TextBox ID="txtFechaFin" runat="server" placeholder="Seleccione la fecha de fin" CssClass="form-control" TextMode="Date" required></asp:TextBox>
            </div>

            <!-- Horas mínimas -->
            <div class="form-group">
                <label for="txtHorasMinimas">Horas Mínimas:</label>
                <asp:TextBox ID="txtHorasMinimas" runat="server" placeholder="Ingrese las horas mínimas" CssClass="form-control" TextMode="Number" required></asp:TextBox>
            </div>

            <!-- Botón para agregar curso -->
            <div class="form-group text-center">
                <asp:Button ID="btnAgregarCurso" runat="server" Text="Agregar Curso" CssClass="btn btn-success btn-lg" OnClick="btnAgregarCurso_Click" />
            </div>
        </form>
    </div>
</asp:Content>
