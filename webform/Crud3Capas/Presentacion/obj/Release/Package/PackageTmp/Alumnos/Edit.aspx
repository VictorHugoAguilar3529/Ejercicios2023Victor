<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="Presentacion.Alumnos.Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <formview>
        <div class="container body-container">
            <div class="form-horizontal">
                <h2>Actualizar Alumno</h2>
                <div class="form-group">
                    <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
                    <asp:TextBox ID="tbNombre" runat="server" class="form-text border-1 border-opacity-50"></asp:TextBox>
                </div>
                <div>
                    <asp:RegularExpressionValidator ID="rvNombre" runat="server" ErrorMessage="No es un nombre valido" CssClass="text-danger" ControlToValidate="tbNombre" ValidationExpression="^[a-zA-Z]+(\s*[a-zA-Z]*)*[a-zA-Z]+$"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="rvNombreOb" runat="server" ErrorMessage="El nombre es requerido" ControlToValidate="tbNombre" CssClass="text-danger"></asp:RequiredFieldValidator>
                </div>


                <div class="form-group">
                    <asp:Label ID="lblprimerApellido" runat="server" Text="primerApellido"></asp:Label>
                    <asp:TextBox ID="tbprimerApellido" runat="server" class="form-text border-1 border-opacity-50"></asp:TextBox>
                </div>
                <div>
                    <asp:RegularExpressionValidator ID="rvPrimerAp" runat="server" ErrorMessage="No es un apellido valido" CssClass="text-danger" ControlToValidate="tbprimerApellido" ValidationExpression="^[a-zA-Z]+(\s*[a-zA-Z]*)*[a-zA-Z]+$"></asp:RegularExpressionValidator>
                </div>


                <div class="form-group">
                    <asp:Label ID="lblsegundoApellido" runat="server" Text="segundoApellido"></asp:Label>
                    <asp:TextBox ID="tbsegundoApellido" runat="server" class="form-text border-1 border-opacity-50"></asp:TextBox>
                </div>
                <div>
                    <asp:RegularExpressionValidator ID="rfvSegundoApellido" runat="server" ErrorMessage="No es un apllido valido" CssClass="text-danger" ControlToValidate="tbsegundoApellido" ValidationExpression="^[a-zA-Z]+(\s*[a-zA-Z]*)*[a-zA-Z]+$"></asp:RegularExpressionValidator>
                </div>


                <div class="form-group">
                    <asp:Label ID="lblcorreo" runat="server" Text="correo"></asp:Label>
                    <asp:TextBox ID="tbcorreo" runat="server" class="form-text border-1 border-opacity-50"></asp:TextBox>
                </div>
                <div>
                    <asp:RegularExpressionValidator ID="rvCorreoFormat" runat="server" ErrorMessage="Formato de correo no valido" CssClass="text-danger" ControlToValidate="tbcorreo" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="rvCorreoOb" runat="server" ErrorMessage="El correo es requerido" ControlToValidate="tbcorreo" CssClass="text-danger"></asp:RequiredFieldValidator>
                </div>


                <div class="form-group">
                    <asp:Label ID="lbltelefono" runat="server" Text="telefono"></asp:Label>
                    <asp:TextBox ID="tbtelefono" runat="server" CssClass=" form-text border-1 border-opacity-50"></asp:TextBox>
                </div>


                <div class="form-group">
                    <asp:Label ID="lblfechaNacimiento" runat="server" Text="fechaNacimiento"></asp:Label>
                    <asp:TextBox ID="tbfechaNacimiento" runat="server" TextMode="Date" class="form-text border-1 border-opacity-50"></asp:TextBox>
                </div>
                <div>
                    <asp:CustomValidator ID="cvCurpVsFechaNac" runat="server" ErrorMessage="el cambo curp no coincide con a fecha de nacimiento" CssClass="text-danger" ControlToValidate="tbcurp" OnServerValidate="cvCurpVsFechaNac_ServerValidate"></asp:CustomValidator>
                    <asp:RequiredFieldValidator ID="rvFechaOb" runat="server" ErrorMessage="La fecha de nacimiento esnrequerida" ControlToValidate="tbfechaNacimiento" CssClass="text-danger"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="rvFecha" runat="server" ErrorMessage="La fecha debe de estar entre 1990/01/01 2000/12/31" Type="Date" MaximumValue="2023-10-19" MinimumValue="2000-12-31" ControlToValidate="tbfechaNacimiento" CssClass="text-danger"></asp:RangeValidator>
                </div>


                <div class="form-group">
                    <asp:Label ID="lblcurp" runat="server" Text="curp"></asp:Label>
                    <asp:TextBox ID="tbcurp" runat="server" class="form-text border-1 border-opacity-50" OnDataBinding="tbcurp_DataBinding" OnTextChanged="tbcurp_TextChanged"></asp:TextBox>
                </div>
                <div>
                    <asp:RegularExpressionValidator ID="rvcurpFormato" runat="server" ErrorMessage="Formato de curp no valido" CssClass="text-danger" ControlToValidate="tbcurp" ValidationExpression="([A-Z][AEIOUX][A-Z]{2}\d{2}(?:0[1-9]|1[0-2])(?:0[1-9]|[12]\d|3[01])[HM](?:AS|B[CS]|C[CLMSH]|D[FG]|G[TR]|HG|JC|M[CNS]|N[ETL]|OC|PL|Q[TR]|S[PLR]|T[CSL]|VZ|YN|ZS)[B-DF-HJ-NP-TV-Z]{3}[A-Z\d])(\d)$"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="rvCurpOb" runat="server" ErrorMessage="La curp es requerida" ControlToValidate="tbcurp" CssClass="text-danger"></asp:RequiredFieldValidator>
                </div>


                <div class="form-group">
                    <asp:Label ID="lblsueldo" runat="server" Text="sueldo"></asp:Label>
                    <asp:TextBox ID="tbsueldo" runat="server" class="form-text border-1 border-opacity-50"></asp:TextBox>
                </div>
                <div>
                    <asp:RangeValidator ID="rvSueldo" runat="server" ErrorMessage="El sueldo debe de estar entre 10000 y 40000" Type="Currency" MaximumValue="40000" MinimumValue="10000" ControlToValidate="tbsueldo" CssClass="text-danger"></asp:RangeValidator>
                </div>


                <div class="form-group">
                    <asp:Label ID="lblidEstadoOrigen" runat="server" Text="idEstadoOrigen"></asp:Label>
                    <asp:DropDownList ID="DropDownEstado" runat="server" class="form-text border-1 border-opacity-50"></asp:DropDownList><br />
                </div>


                <div class="form-group">
                    <asp:Label ID="lblidEstatus" runat="server" Text="idEstatus"></asp:Label>
                    <asp:DropDownList ID="DropDownEstatus" runat="server" class="form-text border-1 border-opacity-50"></asp:DropDownList><br />
                </div>
            </div>
        </div>
    </formview>

    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" class="btn btn-success"></asp:Button>
    <a href="index.aspx">Ir a</a>
</asp:Content>
