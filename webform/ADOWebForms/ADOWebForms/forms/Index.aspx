<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ADOWebForms.forms.Index1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <asp:DropDownList ID="DropDownEstatus" runat="server"></asp:DropDownList><br />

    <asp:Button ID="Agregar" runat="server" Text="Agregar" OnClick="Agregar_Click"/>
    <asp:Button ID="Detalles" runat="server" Text="Detalles" OnClick="Detalles_Click1" />
    <asp:Button ID="Editar" runat="server" Text="Editar" OnClick="Editar_Click1" />
    <asp:Button ID="Eliminar" runat="server" Text="Eliminar" OnClick="Eliminar_Click1" />

</asp:Content>
