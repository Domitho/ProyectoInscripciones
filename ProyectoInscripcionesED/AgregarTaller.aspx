<%@ Page Title="Agregar Taller" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarTaller.aspx.cs" Inherits="ProyectoInscripcionesED.AgregarTaller" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <!-- Título de la página -->
        <h2 class="text-center mb-4">Formulario de Agregar Taller</h2>

        <!-- Mensaje de éxito o error -->
        <div class="alert d-none" role="alert" id="alertMessage">
            <asp:Label ID="lblMensaje" runat="server" CssClass="d-none" ForeColor="Green"></asp:Label>
        </div>

        <!-- Formulario de Agregar Taller -->
        <form id="formAgregarTaller" runat="server">
            <div class="card shadow-sm">
                <div class="card-body">
                    <div class="row">
                        <!-- Campo Nombre del Taller -->
                        <div class="col-md-6 mb-3">
                            <label for="txtNombre" class="form-label font-weight-bold">Nombre del Taller</label>
                            <asp:TextBox ID="txtNombre" runat="server" placeholder="Nombre del taller" CssClass="form-control" required></asp:TextBox>
                        </div>

                        <!-- Campo Descripción del Taller -->
                        <div class="col-md-6 mb-3">
                            <label for="txtDescripcion" class="form-label font-weight-bold">Descripción del Taller</label>
                            <asp:TextBox ID="txtDescripcion" runat="server" placeholder="Descripción del taller" TextMode="MultiLine" CssClass="form-control" required></asp:TextBox>
                        </div>

                        <!-- Campo Fecha del Taller -->
                        <div class="col-md-6 mb-3">
                            <label for="txtFecha" class="form-label font-weight-bold">Fecha del Taller</label>
                            <asp:TextBox ID="txtFecha" runat="server" placeholder="Fecha del taller" CssClass="form-control" TextMode="Date" required></asp:TextBox>
                        </div>

                        <!-- Campo Hora de Inicio -->
                        <div class="col-md-6 mb-3">
                            <label for="txtHoraInicio" class="form-label font-weight-bold">Hora de Inicio</label>
                            <asp:TextBox ID="txtHoraInicio" runat="server" placeholder="Hora de inicio" CssClass="form-control" TextMode="Time" required></asp:TextBox>
                        </div>

                        <!-- Campo Hora de Fin -->
                        <div class="col-md-6 mb-3">
                            <label for="txtHoraFin" class="form-label font-weight-bold">Hora de Fin</label>
                            <asp:TextBox ID="txtHoraFin" runat="server" placeholder="Hora de fin" CssClass="form-control" TextMode="Time" required></asp:TextBox>
                        </div>

                        <!-- Campo Duración -->
                        <div class="col-md-6 mb-3">
                            <label for="txtDuracion" class="form-label font-weight-bold">Duración (en horas)</label>
                            <asp:TextBox ID="txtDuracion" runat="server" placeholder="Duración (en horas)" CssClass="form-control" TextMode="Number" required></asp:TextBox>
                        </div>

                        <!-- Campo Curso -->
                        <div class="col-md-6 mb-3">
                            <label for="ddlCurso" class="form-label font-weight-bold">Seleccione un Curso</label>
                            <asp:DropDownList ID="ddlCurso" runat="server" CssClass="form-control" required>
                                <asp:ListItem Value="" Text="Seleccione un curso"></asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <!-- Campo Instructor -->
                        <div class="col-md-6 mb-3">
                            <label for="ddlInstructor" class="form-label font-weight-bold">Seleccione un Instructor</label>
                            <asp:DropDownList ID="ddlInstructor" runat="server" CssClass="form-control" required>
                                <asp:ListItem Value="" Text="Seleccione un instructor"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                    <!-- Botón de Agregar Taller -->
                    <div class="text-center">
                        <asp:Button ID="btnAgregarTaller" runat="server" Text="Agregar Taller" CssClass="btn btn-success btn-lg" OnClick="btnAgregarTaller_Click" />
                    </div>
                </div>
            </div>
        </form>
    </div>
</asp:Content>
