<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="ADOWebForms.forms.Delete" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Eliminar</h2>
    <div>
        <asp:Label ID="lblId" runat="server" Text="Id"></asp:Label>
    </div>
    <div>
        <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
    </div>
    <div>
        <asp:Label ID="lblCLave" runat="server" Text="Clave"></asp:Label>
    </div>
    <asp:Button ID="Button1" runat="server" Text="Eliminar" OnClick="Delete_Click" />
    <asp:LinkButton ID="LinkButton1" runat="server">Regresar a la lista</asp:LinkButton>
</asp:Content>
