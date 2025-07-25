<%@ Page Title="Lista de Asistencias" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="ListarAsistencia.aspx.cs"
    Inherits="ProyectoInscripcionesED.ListarAsistencia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!-- CSS DataTables -->
    <link rel="stylesheet"
          href="https://cdn.datatables.net/1.13.6/css/dataTables.bootstrap5.min.css" />

    <h2 class="my-4">Lista de Asistencias</h2>

    <asp:Label ID="lblMensaje" runat="server" ForeColor="Green"></asp:Label><br />

    <form runat="server">
        <asp:Button ID="btnAgregarAsistencia" runat="server"
                    Text="Agregar Asistencia"
                    CssClass="btn btn-success mb-3"
                    OnClick="btnAgregarAsistencia_Click" />

        <!-- Tabla HTML para DataTables -->
        <asp:Literal ID="ltTabla" runat="server"></asp:Literal>
    </form>

    <!-- Scripts -->
    <script src="https://code.jquery.com/jquery-3.7.1.min.js"></script>
    <script src="https://cdn.datatables.net/1.13.6/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.13.6/js/dataTables.bootstrap5.min.js"></script>

    <script>
        $(function () {
            $('#tblAsistencia').DataTable({
                paging: true,
                pageLength: 20,
                searching: true,
                order: [[0, 'asc']],
                language: {
                    url: '//cdn.datatables.net/plug-ins/1.13.6/i18n/es-ES.json'
                }
            });
        });
    </script>

</asp:Content>