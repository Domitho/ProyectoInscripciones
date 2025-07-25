<%@ Page Title="Listar Cursos" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="ListarCursos.aspx.cs"
    Inherits="ProyectoInscripcionesED.ListarCursosPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!-- CSS DataTables -->
    <link rel="stylesheet"
          href="https://cdn.datatables.net/1.13.6/css/dataTables.bootstrap5.min.css" />

    <h2 class="my-4">Lista de Cursos</h2>

    <asp:Label ID="lblMensaje" runat="server" ForeColor="Green"></asp:Label><br />

    <form runat="server">
        <asp:Button ID="btnAgregarCurso" runat="server"
                    Text="➕ Agregar Curso"
                    CssClass="btn btn-success mb-3"
                    OnClick="btnAgregarCurso_Click" />

        <!-- Tabla HTML para DataTables -->
        <asp:Literal ID="ltTabla" runat="server"></asp:Literal>
    </form>

    <!-- Scripts -->
    <script src="https://code.jquery.com/jquery-3.7.1.min.js"></script>
    <script src="https://cdn.datatables.net/1.13.6/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.13.6/js/dataTables.bootstrap5.min.js"></script>

    <script>
        $(function () {
            $('#tblCursos').DataTable({
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
