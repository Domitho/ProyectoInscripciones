<%@ Page Title="Listar Cursos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListarCursos.aspx.cs" Inherits="ProyectoInscripcionesED.ListarCursosPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="my-4">Lista de Cursos</h1>

    <!-- Mostrar mensaje si no hay cursos -->
    <asp:Label ID="lblNoCursos" runat="server" Text="No se han encontrado cursos." Visible="false" ForeColor="Red" />

    <form id="form1" runat="server">
        <!-- Botón para agregar nuevo curso -->
        <asp:Button ID="btnAgregarCurso" runat="server" Text="Agregar Curso" CssClass="btn btn-success mb-3" OnClick="btnAgregarCurso_Click" />

        <!-- Usamos GridView para mostrar los cursos -->
        <asp:GridView ID="GridViewCursos" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" 
                      EmptyDataText="No se han encontrado cursos">
            <Columns>
                <asp:BoundField DataField="curso_id" HeaderText="ID" SortExpression="curso_id" />
                <asp:BoundField DataField="nombre" HeaderText="Nombre" SortExpression="nombre" />
                <asp:BoundField DataField="descripcion" HeaderText="Descripción" SortExpression="descripcion" />
                <asp:BoundField DataField="fecha_inicio" HeaderText="Fecha Inicio" SortExpression="fecha_inicio" />
                <asp:BoundField DataField="fecha_fin" HeaderText="Fecha Fin" SortExpression="fecha_fin" />
                <asp:BoundField DataField="horas_minimas" HeaderText="Horas Mínimas" SortExpression="horas_minimas" />
                
                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>
                        <!-- Botón de Editar -->
                        <asp:Button ID="btnEditar" runat="server" Text="Editar" CommandName="Editar" CommandArgument='<%# Eval("curso_id") %>' OnClick="btnEditar_Click" CssClass="btn btn-warning" />

                        <!-- Botón de Eliminar -->
                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CommandName="Eliminar" CommandArgument='<%# Eval("curso_id") %>' OnClick="btnEliminar_Click" CssClass="btn btn-danger" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </form>
</asp:Content>
