<%@ Page Title="Lista de Inscripciones" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaInscripcion.aspx.cs" Inherits="ProyectoInscripcionesED.ListaInscripcion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Lista de Inscripciones</h2>

    <form id="formListaInscripciones" runat="server">
        <!-- Label para mostrar los mensajes -->
        <asp:Label ID="lblMensaje" runat="server" ForeColor="Green"></asp:Label><br />

        <!-- Botón para agregar nueva inscripción -->
        <asp:Button ID="btnAgregar" runat="server" Text="Agregar Inscripción" CssClass="btn btn-success mb-3" OnClick="btnAgregar_Click" />

        <!-- GridView para mostrar las inscripciones -->
        <asp:GridView ID="gvInscripciones" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" OnRowCommand="gvInscripciones_RowCommand">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="ID" SortExpression="id" />
                <asp:BoundField DataField="usuario_id" HeaderText="ID Usuario" SortExpression="usuario_id" />
                <asp:BoundField DataField="taller_id" HeaderText="ID Taller" SortExpression="taller_id" />
                <asp:BoundField DataField="estado" HeaderText="Estado" SortExpression="estado" />
                
                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>
                        &nbsp; <!-- Espaciado entre botones -->

                        <!-- Editar -->
                        <asp:LinkButton ID="btnEditar" runat="server" CommandName="Editar" CommandArgument='<%# Eval("id") %>' Text="Editar" CssClass="btn btn-warning btn-sm" />

                        &nbsp; <!-- Espaciado entre botones -->

                        <!-- Eliminar -->
                        <asp:LinkButton ID="btnEliminar" runat="server" CommandName="Eliminar" CommandArgument='<%# Eval("id") %>' Text="Eliminar" CssClass="btn btn-danger btn-sm" OnClientClick="return confirm('¿Está seguro de que desea eliminar esta inscripción?');" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </form>
</asp:Content>
