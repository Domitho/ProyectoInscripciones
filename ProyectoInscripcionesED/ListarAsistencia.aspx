<%@ Page Title="Lista de Asistencias" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListarAsistencia.aspx.cs" Inherits="ProyectoInscripcionesED.ListarAsistencia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="my-4">Lista de Asistencias</h2>

    <!-- Label para mostrar mensajes de éxito o error -->
    <asp:Label ID="lblMensaje" runat="server" ForeColor="Green"></asp:Label><br />

    <form id="formListaAsistencia" runat="server">
        <!-- GridView para mostrar las asistencias -->
        <asp:GridView ID="gvAsistencia" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover" OnRowCommand="gvAsistencia_RowCommand">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="ID" SortExpression="id" HeaderStyle-CssClass="table-header" />
                <asp:BoundField DataField="inscripcion_id" HeaderText="ID Inscripción" SortExpression="inscripcion_id" HeaderStyle-CssClass="table-header" />
                <asp:BoundField DataField="usuario_nombre" HeaderText="Usuario" SortExpression="usuario_nombre" HeaderStyle-CssClass="table-header" />
                <asp:BoundField DataField="asistio" HeaderText="Asistió" SortExpression="asistio" HeaderStyle-CssClass="table-header" />
                
                <asp:TemplateField HeaderText="Acciones" HeaderStyle-CssClass="table-header">
                    <ItemTemplate>
                        &nbsp; <!-- Espaciado entre botones -->

                        <!-- Marcar Asistencia -->
                        <asp:LinkButton ID="btnMarcarAsistencia" runat="server" CommandName="MarcarAsistencia" CommandArgument='<%# Eval("id") %>' Text="Marcar Asistencia" CssClass="btn btn-success btn-sm" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </form>
</asp:Content>