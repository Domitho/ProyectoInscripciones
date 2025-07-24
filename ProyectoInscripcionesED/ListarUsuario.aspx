<%@ Page Title="Listar Usuarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListarUsuario.aspx.cs" Inherits="ProyectoInscripcionesED.ListarUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="my-4">Lista de Usuarios</h1>

    <!-- Mostrar mensaje si no hay usuarios -->
    <asp:Label ID="lblNoUsuarios" runat="server" Text="No hay usuarios registrados." Visible="false" ForeColor="Red" />

    <form id="form1" runat="server">
        <!-- Usamos GridView para mostrar los usuarios -->
        <asp:GridView ID="GridViewUsuarios" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover" 
                      EmptyDataText="No se han encontrado usuarios" OnRowDataBound="GridViewUsuarios_RowDataBound">
            <Columns>
                <asp:BoundField DataField="usuario_id" HeaderText="ID" SortExpression="usuario_id" HeaderStyle-CssClass="table-header" />
                <asp:BoundField DataField="usuario_nombres" HeaderText="Nombres" SortExpression="usuario_nombres" HeaderStyle-CssClass="table-header" />
                <asp:BoundField DataField="usuario_apellidos" HeaderText="Apellidos" SortExpression="usuario_apellidos" HeaderStyle-CssClass="table-header" />
                <asp:BoundField DataField="usuario_correo" HeaderText="Correo" SortExpression="usuario_correo" HeaderStyle-CssClass="table-header" />
                <asp:BoundField DataField="usuario_telefono" HeaderText="Teléfono" SortExpression="usuario_telefono" HeaderStyle-CssClass="table-header" />
                <asp:BoundField DataField="usuario_tipo_usuario" HeaderText="Tipo de Usuario" SortExpression="usuario_tipo_usuario" HeaderStyle-CssClass="table-header" />
                
                <asp:TemplateField HeaderText="Acciones" HeaderStyle-CssClass="table-header">
                    <ItemTemplate>
                        <!-- Botón de Editar -->
                        <asp:Button ID="btnEditar" runat="server" Text="Editar" CommandName="Editar" CommandArgument='<%# Eval("usuario_id") %>' OnClick="btnEditar_Click" CssClass="btn btn-warning btn-sm" />

                        <!-- Botón de Eliminar -->
                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CommandName="Eliminar" CommandArgument='<%# Eval("usuario_id") %>' OnClick="btnEliminar_Click" CssClass="btn btn-danger btn-sm" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </form>
</asp:Content>
