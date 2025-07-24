<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="ProyectoInscripcionesED.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Panel de KPIs</h2>

    <div class="row">
        <!-- Total de Usuarios Registrados -->
        <div class="col-md-4">
            <div class="card">
                <div class="card-body">
                    <h5 class="card-title">Total de Usuarios Registrados</h5>
                    <p class="card-text">
                        <strong><asp:Label ID="lblTotalUsuarios" runat="server" Text="0"></asp:Label></strong>
                    </p>
                </div>
            </div>
        </div>

        <!-- Total de Usuarios Activos -->
        <div class="col-md-4">
            <div class="card">
                <div class="card-body">
                    <h5 class="card-title">Total de Usuarios Activos</h5>
                    <p class="card-text">
                        <strong><asp:Label ID="lblUsuariosActivos" runat="server" Text="0"></asp:Label></strong>
                    </p>
                </div>
            </div>
        </div>

        <!-- Tasa de Conversión de Inscripciones -->
        <div class="col-md-4">
            <div class="card">
                <div class="card-body">
                    <h5 class="card-title">Tasa de Conversión de Inscripciones</h5>
                    <p class="card-text">
                        <strong><asp:Label ID="lblTasaConversion" runat="server" Text="0.00"></asp:Label> %</strong>
                    </p>
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <!-- Total de Inscripciones -->
        <div class="col-md-4">
            <div class="card">
                <div class="card-body">
                    <h5 class="card-title">Total de Inscripciones</h5>
                    <p class="card-text">
                        <strong><asp:Label ID="lblTotalInscripciones" runat="server" Text="0"></asp:Label></strong>
                    </p>
                </div>
            </div>
        </div>

        <!-- Tasa de Asistencia Promedio -->
        <div class="col-md-4">
            <div class="card">
                <div class="card-body">
                    <h5 class="card-title">Tasa de Asistencia Promedio</h5>
                    <p class="card-text">
                        <strong><asp:Label ID="lblTasaAsistenciaPromedio" runat="server" Text="0.00"></asp:Label> %</strong>
                    </p>
                </div>
            </div>
        </div>

        <!-- Tasa de Certificación -->
        <div class="col-md-4">
            <div class="card">
                <div class="card-body">
                    <h5 class="card-title">Tasa de Certificación</h5>
                    <p class="card-text">
                        <strong><asp:Label ID="lblTasaCertificacion" runat="server" Text="0.00"></asp:Label> %</strong>
                    </p>
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <!-- Total de Talleres Realizados -->
        <div class="col-md-4">
            <div class="card">
                <div class="card-body">
                    <h5 class="card-title">Total de Talleres Realizados</h5>
                    <p class="card-text">
                        <strong><asp:Label ID="lblTalleresRealizados" runat="server" Text="0"></asp:Label></strong>
                    </p>
                </div>
            </div>
        </div>

        <!-- Total de Certificados Emitidos -->
        <div class="col-md-4">
            <div class="card">
                <div class="card-body">
                    <h5 class="card-title">Total de Certificados Emitidos</h5>
                    <p class="card-text">
                        <strong><asp:Label ID="lblCertificadosEmitidos" runat="server" Text="0"></asp:Label></strong>
                    </p>
                </div>
            </div>
        </div>

        <!-- Tiempo Promedio de Asistencia por Taller -->
        <div class="col-md-4">
            <div class="card">
                <div class="card-body">
                    <h5 class="card-title">Tiempo Promedio de Asistencia por Taller</h5>
                    <p class="card-text">
                        <strong><asp:Label ID="lblTiempoPromedioAsistencia" runat="server" Text="0.00"></asp:Label> horas</strong>
                    </p>
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <!-- Tasa de Cancelación de Talleres -->
        <div class="col-md-4">
            <div class="card">
                <div class="card-body">
                    <h5 class="card-title">Tasa de Cancelación de Talleres</h5>
                    <p class="card-text">
                        <strong><asp:Label ID="lblTasaCancelacion" runat="server" Text="0.00"></asp:Label> %</strong>
                    </p>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
