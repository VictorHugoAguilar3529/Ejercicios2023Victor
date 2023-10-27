<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Presentacion.Alumnos.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 
   <asp:Button runat="server" Text="Agregar" ID="btnAgregar" OnClick="Agregar_Click" CssClass="btn btn-primary"></asp:Button> 
    <asp:GridView ID="GridAlumnos" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" CssClass="table table-striped" AutoGenerateColumns="False" OnCallingDataMethods="GridAlumnos_CallingDataMethods" OnSelectedIndexChanging="GridAlumnos_SelectedIndexChanging" OnSorted="GridAlumnos_Sorted" AllowPaging="True" OnPageIndexChanging="GridAlumnos_PageIndexChanging" OnRowCommand="GridAlumnos_RowCommand" PageSize="5">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="ID" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="primerApellido" HeaderText="Primer Apellido" />
            <asp:BoundField DataField="segundoApellido" HeaderText="Segundo Apellido" />
            <asp:BoundField DataField="correo" HeaderText="Correo" />
            <asp:BoundField DataField="telefono" HeaderText="Teléfono" />
            <asp:BoundField DataField="idEstadoOrigen" HeaderText="Estado" />
            <asp:BoundField DataField="idEstatus" HeaderText="Estatus" />
            <asp:ButtonField Text="Detalles" CommandName="btnDetalles" ControlStyle-CssClass="btn btn-warning btn-sm"/>
            <asp:ButtonField Text="Editar" CommandName="btnEditar" ControlStyle-CssClass="btn btn-success btn-sm"/>
            <asp:ButtonField Text="Eliminar" CommandName="btnEliminar" ControlStyle-CssClass="btn btn-danger btn-sm"/>
        </Columns>
    </asp:GridView>
</asp:Content>
