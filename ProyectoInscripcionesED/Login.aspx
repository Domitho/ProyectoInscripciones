<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProyectoInscripcionesED.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Iniciar Sesión</h2>
    <form id="formLogin" runat="server">
        <div class="form-group">
            <label for="correo">Correo:</label>
            <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control" placeholder="Correo" />
        </div>
        <div class="form-group">
            <label for="password">Contraseña:</label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="Contraseña" />
        </div>
        <div class="form-group">
            <asp:Button ID="btnLogin" runat="server" Text="Iniciar Sesión" CssClass="btn btn-primary" OnClick="btnLogin_Click" />
        </div>
    </form>
</asp:Content>
