<%@ Page Title="Lista de Certificados" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListarCertificados.aspx.cs" Inherits="ProyectoInscripcionesED.ListarCertificados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Lista de Certificados</h2>

    <!-- Label para mostrar mensajes de éxito o error -->
    <asp:Label ID="lblMensaje" runat="server" ForeColor="Green"></asp:Label><br />

    <form id="formListaCertificados" runat="server">
        <!-- GridView para mostrar los certificados -->
        <asp:GridView ID="gvCertificados" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" OnRowCommand="gvCertificados_RowCommand">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="ID" SortExpression="id" />
                <asp:BoundField DataField="usuario_nombre" HeaderText="Usuario" SortExpression="usuario_nombre" />
                <asp:BoundField DataField="curso_nombre" HeaderText="Curso" SortExpression="curso_nombre" />
                
                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>
                        <!-- Ver Detalles -->
                        <asp:LinkButton ID="btnDetalles" runat="server" CommandName="Detalles" CommandArgument='<%# Eval("id") %>' Text="Ver Detalles" CssClass="btn btn-info btn-sm" />
                        
                        &nbsp; <!-- Espaciado entre botones -->
                        
                        <!-- Editar -->
                        <asp:LinkButton ID="btnEditar" runat="server" CommandName="Editar" CommandArgument='<%# Eval("id") %>' Text="Editar" CssClass="btn btn-warning btn-sm" />
                        
                        &nbsp; <!-- Espaciado entre botones -->
                        
                        <!-- Eliminar -->
                        <asp:LinkButton ID="btnEliminar" runat="server" CommandName="Eliminar" CommandArgument='<%# Eval("id") %>' Text="Eliminar" CssClass="btn btn-danger btn-sm" OnClientClick="return confirm('¿Está seguro de que desea eliminar este certificado?');" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </form>
</asp:Content>
