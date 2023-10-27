<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="Presentacion.Alumnos.Delete" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <formview>
        <div class="container body-container">
            <div class="form-horizontal">
                <h2>Eliminar Alumno</h2>
                <div>
                    <asp:Label ID="lblId" runat="server" Text="Id"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="lblNombre" runat="server" Text="nombre"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="lblprimerApellido" runat="server" Text="primerApellido"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="lblsegundoApellido" runat="server" Text="segundoApellido"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="lblcorreo" runat="server" Text="correo"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="lbltelefono" runat="server" Text="telefono"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="lblfechaNacimiento" runat="server" Text="fechaNacimiento"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="lblcurp" runat="server" Text="curp"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="lblsueldo" runat="server" Text="sueldo"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="lblidEstadoOrigen" runat="server" Text="idEstadoOrigen"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="lblidEstatus" runat="server" Text="idEstatus"></asp:Label>
                </div>
            </div>
        </div>
    </formview>

    <asp:Button ID="Button1" runat="server" Text="Eliminar" OnClick="Delete_Click" class="btn btn-danger"></asp:Button>
    <a href="index.aspx">Regresar al menu</a>

</asp:Content>
