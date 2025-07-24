<%@ Page Title="Gestión de Usuarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="ProyectoInscripcionesED.Usuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <!-- Título de la página -->
        <h1 class="text-center my-4">Gestión de Usuarios</h1>

        <!-- Formulario de gestión de usuario -->
        <form id="formUsuario" runat="server" method="post">
            <!-- Card para agrupar los campos de formulario -->
            <div class="card shadow-sm">
                <div class="card-body">
                    <div class="row">
                        <!-- Campo Nombres -->
                        <div class="col-md-6 mb-3">
                            <label for="nombres" class="form-label font-weight-bold">Nombres</label>
                            <input type="text" id="nombres" class="form-control" name="nombres" placeholder="Ingrese nombres" required />
                        </div>

                        <!-- Campo Apellidos -->
                        <div class="col-md-6 mb-3">
                            <label for="apellidos" class="form-label font-weight-bold">Apellidos</label>
                            <input type="text" id="apellidos" class="form-control" name="apellidos" placeholder="Ingrese apellidos" required />
                        </div>

                        <!-- Campo Correo -->
                        <div class="col-md-6 mb-3">
                            <label for="correo" class="form-label font-weight-bold">Correo</label>
                            <input type="email" id="correo" class="form-control" name="correo" placeholder="Ingrese correo" required />
                        </div>

                        <!-- Campo Teléfono -->
                        <div class="col-md-6 mb-3">
                            <label for="telefono" class="form-label font-weight-bold">Teléfono</label>
                            <input type="text" id="telefono" class="form-control" name="telefono" placeholder="Ingrese teléfono" required />
                        </div>

                        <!-- Campo Tipo de Usuario -->
                        <div class="col-md-6 mb-3">
                            <label for="tipo_usuario" class="form-label font-weight-bold">Tipo de Usuario</label>
                            <select id="tipo_usuario" class="form-select" name="tipo_usuario" required>
                                <option value="participante">Participante</option>
                                <option value="instructor">Instructor</option>
                            </select>
                        </div>
                    </div>

                    <!-- Botón de registro -->
                    <div class="text-center">
                        <button type="submit" class="btn btn-success btn-lg">Registrar Usuario</button>
                    </div>
                </div>
            </div>
        </form>
    </div>
</asp:Content>
