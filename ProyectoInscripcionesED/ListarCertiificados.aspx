<%@ Page Title="Lista de Certificados" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="ListarCertificados.aspx.cs"
    Inherits="ProyectoInscripcionesED.ListarCertificados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!-- CSS de DataTables -->
    <link rel="stylesheet"
          href="https://cdn.datatables.net/1.13.6/css/dataTables.bootstrap5.min.css" />

    <h2 class="my-4">Lista de Certificados</h2>

    <form runat="server">
        <asp:Label ID="lblMensaje" runat="server" ForeColor="Green"></asp:Label><br />

        <asp:Button ID="btnAgregarCertificado" runat="server"
                    Text="Agregar Certificado"
                    CssClass="btn btn-success mb-3"
                    OnClick="btnAgregarCertificado_Click" />

        <!-- Literal donde inyectamos las filas -->
        <asp:Literal ID="ltFilas" runat="server"></asp:Literal>
    </form>

    <!-- Scripts -->
    <script src="https://code.jquery.com/jquery-3.7.1.min.js"></script>
    <script src="https://cdn.datatables.net/1.13.6/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.13.6/js/dataTables.bootstrap5.min.js"></script>

    <script>
        $(function () {
            $('#tblCertificados').DataTable({
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