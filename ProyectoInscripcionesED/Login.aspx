<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProyectoInscripcionesED.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container d-flex justify-content-center align-items-center" style="height: 100vh;">
        <div class="card shadow-lg p-4" style="width: 100%; max-width: 400px;">
            <h3 class="text-center mb-4">Iniciar Sesión</h3>

            <form id="formLogin" runat="server">
                <!-- Campo de Correo -->
                <div class="form-group mb-3">
                    <label for="correo" class="form-label">Correo</label>
                    <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control" placeholder="Ingrese su correo" />
                </div>

                <!-- Campo de Contraseña -->
                <div class="form-group mb-4">
                    <label for="password" class="form-label">Contraseña</label>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="Ingrese su contraseña" />
                </div>

                <!-- Botón de Inicio de Sesión -->
                <div class="d-grid gap-2">
                    <asp:Button ID="btnLogin" runat="server" Text="Iniciar Sesión" CssClass="btn btn-primary btn-lg" OnClick="btnLogin_Click" />
                </div>

                <!-- Opción para recuperar la contraseña -->
                <div class="text-center mt-3">
                    <a href="#">¿Olvidaste tu contraseña?</a>
                </div>
            </form>
        </div>
    </div>
</asp:Content>
