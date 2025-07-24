<%@ Page Title="Listar Talleres" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListarTaller.aspx.cs" Inherits="ProyectoInscripcionesED.ListarTaller" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Listado de Talleres</h2>

    <form id="formListarTalleres" runat="server">
        <!-- Label para mostrar mensajes de éxito o error -->
        <asp:Label ID="lblMensaje" runat="server" ForeColor="Green"></asp:Label>

        <!-- Botón para agregar un nuevo taller -->
        <asp:Button ID="btnAgregarTaller" runat="server" Text="Agregar Taller" CssClass="btn btn-success mb-3" OnClick="btnAgregarTaller_Click" />

        <!-- GridView para mostrar los talleres -->
        <asp:GridView ID="gvTalleres" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" OnRowCommand="gvTalleres_RowCommand">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="ID" SortExpression="id" />
                <asp:BoundField DataField="nombre" HeaderText="Nombre del Taller" SortExpression="nombre" />
                <asp:BoundField DataField="descripcion" HeaderText="Descripción" SortExpression="descripcion" />
                <asp:BoundField DataField="fecha" HeaderText="Fecha" SortExpression="fecha" />
                <asp:BoundField DataField="hora_inicio" HeaderText="Hora Inicio" SortExpression="hora_inicio" />
                <asp:BoundField DataField="hora_fin" HeaderText="Hora Fin" SortExpression="hora_fin" />
                <asp:BoundField DataField="duracion_horas" HeaderText="Duración (horas)" SortExpression="duracion_horas" />
                <asp:BoundField DataField="curso_id" HeaderText="ID Curso" SortExpression="curso_id" />
                <asp:BoundField DataField="instructor_id" HeaderText="ID Instructor" SortExpression="instructor_id" />

                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>
                        <!-- Botón Editar -->
                        <asp:LinkButton ID="btnEditar" runat="server" CommandName="Editar" CommandArgument='<%# Eval("id") %>' Text="Editar" CssClass="btn btn-warning btn-sm" />
                        &nbsp;
                        <!-- Botón Eliminar -->
                        <asp:LinkButton ID="btnEliminar" runat="server" CommandName="Eliminar" CommandArgument='<%# Eval("id") %>' Text="Eliminar" CssClass="btn btn-danger btn-sm" OnClientClick="return confirm('¿Estás seguro de que quieres eliminar este taller?');" />
                        &nbsp;
                       </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

    </form>
</asp:Content>
