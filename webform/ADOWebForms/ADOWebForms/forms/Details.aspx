<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="ADOWebForms.forms.Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Detalles</h2>
    <div>
        <asp:Label ID="lblId" runat="server" Text="Id"></asp:Label>
    </div>
    <div>
        <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
    </div>
    <div>
        <asp:Label ID="lblCLave" runat="server" Text="Clave"></asp:Label>
    </div>
    <asp:LinkButton ID="LinkButton1"  runat="server" OnClick="LinkButton1_Click">Regresar a la lista</asp:LinkButton>
</asp:Content>
