<%@ Page Title="Lista de Inscripciones" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaInscripcion.aspx.cs" Inherits="ProyectoInscripcionesED.ListaInscripcion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Lista de Inscripciones</h2>

    <form id="formListaInscripciones" runat="server">
        <asp:GridView ID="gvInscripciones" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" OnRowCommand="gvInscripciones_RowCommand">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="ID" SortExpression="id" />
                <asp:BoundField DataField="usuario_id" HeaderText="ID Usuario" SortExpression="usuario_id" />
                <asp:BoundField DataField="taller_id" HeaderText="ID Taller" SortExpression="taller_id" />
                <asp:BoundField DataField="estado" HeaderText="Estado" SortExpression="estado" />
                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnDetalles" runat="server" CommandName="Detalles" CommandArgument='<%# Eval("id") %>' Text="Ver Detalles" CssClass="btn btn-info btn-sm" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </form>
</asp:Content>
