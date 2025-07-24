<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboards.aspx.cs" Inherits="ProyectoInscripcionesED.Dashboards" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="my-4 text-center text-primary">Panel de Indicadores</h1>
    <br/>

    <!-- Contenedor para los gráficos con diseño en 2 columnas por fila -->
    <div class="row">
        <!-- Gráfico 1: Promedio de Horas por Curso -->
        <div class="col-md-6 mb-4">
            <h3 class="text-center">Promedio de Horas por Curso</h3>
            <canvas id="chartPromedioHoras" width="400" height="200"></canvas>
        </div>

        <!-- Gráfico 2: Total de Usuarios por Tipo -->
        <div class="col-md-6 mb-4">
            <h3 class="text-center">Total de Usuarios por Tipo</h3>
            <canvas id="chartUsuariosPorTipo" width="400" height="200"></canvas>
        </div>
    </div>

    <div class="row">
        <!-- Gráfico 3: Talleres por Duración -->
        <div class="col-md-6 mb-4">
            <h3 class="text-center">Cantidad de Talleres por Duración</h3>
            <canvas id="chartTalleresPorDuracion" width="400" height="200"></canvas>
        </div>

        <!-- Gráfico 4: Estado de Inscripciones -->
        <div class="col-md-6 mb-4">
            <h3 class="text-center">Estado de Inscripciones</h3>
            <canvas id="chartInscripcionesPorEstado" width="400" height="200"></canvas>
        </div>
    </div>

    <div class="row">
        <!-- Gráfico 5: Inscripciones por Curso -->
        <div class="col-md-6 mb-4">
            <h3 class="text-center">Inscripciones por Curso</h3>
            <canvas id="chartInscripcionesPorCurso" width="400" height="200"></canvas>
        </div>

        <!-- Gráfico 6: Asistencia por Taller y Mes -->
        <div class="col-md-6 mb-4">
            <h3 class="text-center">Asistencia por Taller y Mes</h3>
            <canvas id="chartAsistenciaPorTaller" width="400" height="200"></canvas>
        </div>
    </div>

    <!-- Incluir Chart.js -->
    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/chartjs-plugin-datalabels"></script>

    <!-- Script para Generar los Gráficos -->
    <script>
        // Gráfico 1: Promedio de Horas por Curso
        var ctx1 = document.getElementById('chartPromedioHoras').getContext('2d');
        var chartPromedioHoras = new Chart(ctx1, {
            type: 'bar',
            data: {
                labels: ['Curso A', 'Curso B', 'Curso C'],
                datasets: [{
                    label: 'Promedio de Horas',
                    data: [10, 15, 12],
                    backgroundColor: 'rgba(54, 162, 235, 0.6)',
                    borderColor: 'rgba(54, 162, 235, 1)',
                    borderWidth: 1
                }]
            },
            options: {
                responsive: true,
                scales: {
                    y: {
                        beginAtZero: true
                    }
                },
                plugins: {
                    datalabels: {
                        display: true,
                        color: 'black',
                        font: {
                            weight: 'bold',
                            size: 14
                        },
                        formatter: function (value, context) {
                            return value + ' hrs';
                        }
                    }
                }
            }
        });

        // Gráfico 2: Total de Usuarios por Tipo
        var ctx2 = document.getElementById('chartUsuariosPorTipo').getContext('2d');
        var chartUsuariosPorTipo = new Chart(ctx2, {
            type: 'pie',
            data: {
                labels: ['Administrador', 'Vendedor', 'Cliente'],
                datasets: [{
                    label: 'Total de Usuarios',
                    data: [50, 30, 20],
                    backgroundColor: ['rgba(255, 99, 132, 0.6)', 'rgba(54, 162, 235, 0.6)', 'rgba(255, 206, 86, 0.6)'],
                    borderColor: ['rgba(255, 99, 132, 1)', 'rgba(54, 162, 235, 1)', 'rgba(255, 206, 86, 1)'],
                    borderWidth: 1
                }]
            },
            options: {
                responsive: true,
                plugins: {
                    datalabels: {
                        display: true,
                        color: 'black',
                        font: {
                            weight: 'bold',
                            size: 14
                        },
                        formatter: function (value, context) {
                            return value + '%';
                        }
                    }
                }
            }
        });

        // Gráfico 3: Talleres por Duración
        var ctx3 = document.getElementById('chartTalleresPorDuracion').getContext('2d');
        var chartTalleresPorDuracion = new Chart(ctx3, {
            type: 'bar',
            data: {
                labels: ['1 hora', '2 horas', '3 horas'],
                datasets: [{
                    label: 'Cantidad de Talleres',
                    data: [10, 15, 12],
                    backgroundColor: 'rgba(75, 192, 192, 0.6)',
                    borderColor: 'rgba(75, 192, 192, 1)',
                    borderWidth: 1
                }]
            },
            options: {
                responsive: true,
                scales: {
                    y: {
                        beginAtZero: true
                    }
                },
                plugins: {
                    datalabels: {
                        display: true,
                        color: 'black',
                        font: {
                            weight: 'bold',
                            size: 14
                        },
                        formatter: function (value, context) {
                            return value;
                        }
                    }
                }
            }
        });

        // Gráfico 4: Estado de Inscripciones
        var ctx4 = document.getElementById('chartInscripcionesPorEstado').getContext('2d');
        var chartInscripcionesPorEstado = new Chart(ctx4, {
            type: 'doughnut',
            data: {
                labels: ['Confirmado', 'Pendiente', 'Cancelado'],
                datasets: [{
                    label: 'Total de Inscripciones',
                    data: [10, 5, 2],
                    backgroundColor: ['rgba(255, 99, 132, 0.6)', 'rgba(54, 162, 235, 0.6)', 'rgba(255, 206, 86, 0.6)'],
                    borderColor: ['rgba(255, 99, 132, 1)', 'rgba(54, 162, 235, 1)', 'rgba(255, 206, 86, 1)'],
                    borderWidth: 1
                }]
            },
            options: {
                responsive: true,
                plugins: {
                    datalabels: {
                        display: true,
                        color: 'black',
                        font: {
                            weight: 'bold',
                            size: 14
                        },
                        formatter: function (value, context) {
                            return value;
                        }
                    }
                }
            }
        });

        // Gráfico 5: Inscripciones por Curso
        var ctx5 = document.getElementById('chartInscripcionesPorCurso').getContext('2d');
        var chartInscripcionesPorCurso = new Chart(ctx5, {
            type: 'bar',
            data: {
                labels: ['Curso A', 'Curso B', 'Curso C'],
                datasets: [{
                    label: 'Confirmado',
                    data: [5, 3, 8],
                    backgroundColor: 'rgba(75, 192, 192, 0.6)',
                    borderColor: 'rgba(75, 192, 192, 1)',
                    borderWidth: 1
                }, {
                    label: 'Pendiente',
                    data: [2, 1, 4],
                    backgroundColor: 'rgba(153, 102, 255, 0.6)',
                    borderColor: 'rgba(153, 102, 255, 1)',
                    borderWidth: 1
                }, {
                    label: 'Cancelado',
                    data: [1, 2, 3],
                    backgroundColor: 'rgba(255, 99, 132, 0.6)',
                    borderColor: 'rgba(255, 99, 132, 1)',
                    borderWidth: 1
                }]
            },
            options: {
                responsive: true,
                scales: {
                    y: {
                        beginAtZero: true
                    }
                },
                plugins: {
                    datalabels: {
                        display: true,
                        color: 'black',
                        font: {
                            weight: 'bold',
                            size: 14
                        },
                        formatter: function (value, context) {
                            return value;
                        }
                    }
                }
            }
        });

        // Gráfico 6: Asistencia por Taller y Mes
        var ctx6 = document.getElementById('chartAsistenciaPorTaller').getContext('2d');
        var chartAsistenciaPorTaller = new Chart(ctx6, {
            type: 'line',
            data: {
                labels: ['Enero', 'Febrero', 'Marzo'],
                datasets: [{
                    label: 'Taller A',
                    data: [10, 20, 30],
                    borderColor: 'rgba(75, 192, 192, 1)',
                    fill: false
                }, {
                    label: 'Taller B',
                    data: [15, 25, 35],
                    borderColor: 'rgba(153, 102, 255, 1)',
                    fill: false
                }]
            },
            options: {
                responsive: true,
                scales: {
                    y: {
                        beginAtZero: true
                    }
                },
                plugins: {
                    datalabels: {
                        display: true,
                        color: 'black',
                        font: {
                            weight: 'bold',
                            size: 14
                        },
                        formatter: function (value, context) {
                            return value;
                        }
                    }
                }
            }
        });
    </script>
</asp:Content>
