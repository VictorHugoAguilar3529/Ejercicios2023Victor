<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="ADOWebForms.forms.Edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <h2>Actualizar</h2>
    <div>
        <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
        <asp:TextBox ID="tbNombre" runat="server"></asp:TextBox>
    </div>

    <div>
        <asp:Label ID="lblClave" runat="server" Text="Clave"></asp:Label>
        <asp:TextBox ID="tbCLave" runat="server"></asp:TextBox>
    </div>
    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
    <asp:LinkButton ID="LinkButton1" runat="server">Regresar a la lista</asp:LinkButton>

</asp:Content>
