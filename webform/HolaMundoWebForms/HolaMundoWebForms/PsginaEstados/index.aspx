<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="HolaMundoWebForms.PsginaEstados.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
    <asp:Label ID="Estados" runat="server" Text="Estados"></asp:Label>
    <asp:DropDownList ID="dd1Estados" runat="server"></asp:DropDownList>
    <asp:Button ID="btnDetalles" runat="server" Text="Button" OnClick="btnDetalles_Click" />

</asp:Content>
