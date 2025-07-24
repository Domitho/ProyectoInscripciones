<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Loginn.aspx.cs" Inherits="ProyectoInscripcionesED.Loginn" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Iniciar Sesión</title>

    <!-- Vincula el archivo de Bootstrap CSS -->
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>

    <form id="form1" runat="server">
        <div class="container d-flex justify-content-center align-items-center" style="height: 100vh;">
            <div class="card shadow-lg p-4" style="width: 100%; max-width: 400px;">
                <h3 class="text-center mb-4">Iniciar Sesión</h3>

                <!-- Formulario de Login -->
                <div class="card-body">
                    <div class="form-group">
                        <label for="correo" class="form-label">Correo</label>
                        <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control" placeholder="Ingrese su correo" />
                    </div>

                    <div class="form-group">
                        <label for="password" class="form-label">Contraseña</label>
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="Ingrese su contraseña" />
                    </div>

                    <div class="d-grid gap-2">
                        <asp:Button ID="btnLogin" runat="server" Text="Iniciar Sesión" CssClass="btn btn-primary btn-lg" OnClick="btnLogin_Click" />
                    </div>

                    <div class="text-center mt-3">
                        <a href="Registro.aspx">Registrate!</a>
                    </div>
                </div>
            </div>
        </div>
    </form>

    <!-- Vincula el archivo de Bootstrap JS -->
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.5.2/dist/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>
