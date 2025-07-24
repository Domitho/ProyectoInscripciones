<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="ProyectoInscripcionesED.Usuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="my-4">Gestión de Usuarios</h1>

    <form id="formUsuario" runat="server" method="post">
        <div class="row">
            <div class="col-md-6">
                <label for="nombres" class="form-label">Nombres</label>
                <input type="text" id="nombres" class="form-control" name="nombres" placeholder="Ingrese nombres" />
            </div>
            <div class="col-md-6">
                <label for="apellidos" class="form-label">Apellidos</label>
                <input type="text" id="apellidos" class="form-control" name="apellidos" placeholder="Ingrese apellidos" />
            </div>
            <div class="col-md-6">
                <label for="correo" class="form-label">Correo</label>
                <input type="email" id="correo" class="form-control" name="correo" placeholder="Ingrese correo" />
            </div>
            <div class="col-md-6">
                <label for="telefono" class="form-label">Teléfono</label>
                <input type="text" id="telefono" class="form-control" name="telefono" placeholder="Ingrese teléfono" />
            </div>
            <div class="col-md-6">
                <label for="tipo_usuario" class="form-label">Tipo de Usuario</label>
                <select id="tipo_usuario" class="form-select" name="tipo_usuario">
                    <option value="participante">Participante</option>
                    <option value="instructor">Instructor</option>
                </select>
            </div>
        </div>
        <button type="submit" class="btn btn-primary mt-3">Registrar Usuario</button>
    </form>
</asp:Content>
