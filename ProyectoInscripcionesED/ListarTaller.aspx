<%@ Page Title="Listar Talleres" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="ListarTaller.aspx.cs"
    Inherits="ProyectoInscripcionesED.ListarTaller" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!-- CSS DataTables -->
    <link rel="stylesheet"
          href="https://cdn.datatables.net/1.13.6/css/dataTables.bootstrap5.min.css" />

    <h2 class="my-4">Listado de Talleres</h2>

    <asp:Label ID="lblMensaje" runat="server" ForeColor="Green"></asp:Label><br />

    <form runat="server">
        <asp:Button ID="btnAgregarTaller" runat="server"
                    Text="Agregar Taller"
                    CssClass="btn btn-success mb-3"
                    OnClick="btnAgregarTaller_Click" />

        <!-- Tabla HTML con DataTables -->
        <asp:Literal ID="ltTabla" runat="server"></asp:Literal>
    </form>

    <!-- Scripts -->
    <script src="https://code.jquery.com/jquery-3.7.1.min.js"></script>
    <script src="https://cdn.datatables.net/1.13.6/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.13.6/js/dataTables.bootstrap5.min.js"></script>

    <script>
        $(function () {
            $('#tblTalleres').DataTable({
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