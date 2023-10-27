<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="Presentacion.Alumnos.Create" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <formview> 
        <div class="container">
            <h2>Agregar Alumno</h2>

                <div class="form-check">
                    <asp:Label ID="lblNombre" runat="server" CssClass="form-control col-md" Text="Nombre"></asp:Label>
                    <asp:TextBox ID="tbNombre" runat="server" CssClass="form-text border-1 border-opacity-50 col-md-2"></asp:TextBox>
                </div>
                <div >
                    <asp:RegularExpressionValidator ID="rvNombre" runat="server" ErrorMessage="No es un nombre valido" CssClass="text-danger" ControlToValidate="tbNombre" ValidationExpression="^[a-zA-Z]+(\s*[a-zA-Z]*)*[a-zA-Z]+$"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="rvNombreOb" runat="server" ErrorMessage="El nombre es requerido" ControlToValidate="tbNombre" CssClass="text-danger"></asp:RequiredFieldValidator>
                </div>


                <div class="form-check">
                    <asp:Label ID="lblprimerApellido" runat="server" Text="primerApellido" CssClass="form-control col-md"></asp:Label>
                    <asp:TextBox ID="tbprimerApellido" runat="server" class="form-text border-1 border-opacity-50 col-md-2"></asp:TextBox>
                </div>
                <div>
                    <asp:RegularExpressionValidator ID="rvPrimerAp" runat="server" ErrorMessage="No es un apellido valido" CssClass="text-danger" ControlToValidate="tbprimerApellido" ValidationExpression="^[a-zA-Z]+(\s*[a-zA-Z]*)*[a-zA-Z]+$"></asp:RegularExpressionValidator>
                </div>



                <div class="form-check">
                    <asp:Label ID="lblsegundoApellido" runat="server" Text="segundoApellido" class="col-md"></asp:Label>
                    <asp:TextBox ID="tbsegundoApellido" runat="server" class="form-text border-1 border-opacity-50 col-md-2"></asp:TextBox>
                </div>
                <div>
                    <asp:RegularExpressionValidator ID="rfvSegundoApellido" runat="server" ErrorMessage="No es un apllido valido" CssClass="text-danger" ControlToValidate="tbsegundoApellido" ValidationExpression="^[a-zA-Z]+(\s*[a-zA-Z]*)*[a-zA-Z]+$"></asp:RegularExpressionValidator>
                </div>


                <div class="form-check">
                    <asp:Label ID="lblcorreo" runat="server" Text="correo" class="col-md"></asp:Label>
                    <asp:TextBox ID="tbcorreo" runat="server" class="form-text border-1 border-opacity-50 col-md-2"></asp:TextBox>
                </div>
                <div>
                    <asp:RegularExpressionValidator ID="rvCorreoFormat" runat="server" ErrorMessage="Formato de correo no valido" CssClass="text-danger" ControlToValidate="tbcorreo" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="rvCorreoOb" runat="server" ErrorMessage="El correo es requerido" ControlToValidate="tbcorreo" CssClass="text-danger"></asp:RequiredFieldValidator>
                </div>


                <div class="form-check">
                    <asp:Label ID="lbltelefono" runat="server" Text="telefono" class="col-md"></asp:Label>
                    <asp:TextBox ID="tbtelefono" runat="server" class="form-text border-1 border-opacity-50 col-md-2"></asp:TextBox>
                </div>


                <div class="form-check">
                    <asp:Label ID="lblfechaNacimiento" runat="server" Text="fechaNacimiento" class="col-md"></asp:Label>
                    <asp:TextBox ID="tbfechaNacimiento" runat="server" class="form-text border-1 border-opacity-50 col-md-2" TextMode="Date"></asp:TextBox>
                </div>
                <div>
                    <asp:RequiredFieldValidator ID="rvFechaOb" runat="server" ErrorMessage="La fecha de nacimiento esnrequerida" ControlToValidate="tbfechaNacimiento" CssClass="text-danger"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="rvFecha" runat="server" ErrorMessage="La fecha debe de estar entre 1990 y 2023" Type="Date" MaximumValue="2000-12-31" MinimumValue="1990-01-01" ControlToValidate="tbfechaNacimiento" CssClass="text-danger"></asp:RangeValidator>
                </div>


                <div class="form-check">
                    <asp:Label ID="lblcurp" runat="server" Text="curp" class="col-md"></asp:Label>
                    <asp:TextBox ID="tbcurp" runat="server" class="form-text border-1 border-opacity-50"></asp:TextBox>
                </div>
                <div>
                    <asp:RegularExpressionValidator ID="rvcurpFormato" runat="server" ErrorMessage="Formato de curp no valido" CssClass="text-danger" ControlToValidate="tbcurp" ValidationExpression="([A-Z][AEIOUX][A-Z]{2}\d{2}(?:0[1-9]|1[0-2])(?:0[1-9]|[12]\d|3[01])[HM](?:AS|B[CS]|C[CLMSH]|D[FG]|G[TR]|HG|JC|M[CNS]|N[ETL]|OC|PL|Q[TR]|S[PLR]|T[CSL]|VZ|YN|ZS)[B-DF-HJ-NP-TV-Z]{3}[A-Z\d])(\d)$"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="rvCurpOb" runat="server" ErrorMessage="La curp es requerida" ControlToValidate="tbcurp" CssClass="text-danger"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="rvcurpVSfechana" runat="server" ErrorMessage="el campo curp no coincide con ola fecha de necimiento" CssClass="text-danger" ControlToValidate="tbcurp" ClientValidationFunction="ValidarCurpvsFechaNacimiento"></asp:CustomValidator>
                </div>


                <div class="form-check">
                    <asp:Label ID="lblsueldo" runat="server" Text="sueldo" class="col-md"></asp:Label>
                    <asp:TextBox ID="tbsueldo" runat="server" class="form-text border-1 border-opacity-50"></asp:TextBox>
                </div>
                <div>
                    <asp:RangeValidator ID="rvSueldo" runat="server" ErrorMessage="El sueldo debe de estar entre 10000 y 40000" Type="Currency" MaximumValue="40000" MinimumValue="10000" ControlToValidate="tbsueldo" CssClass="text-danger"></asp:RangeValidator>
                </div>


                <div class="form-check">
                    <asp:Label ID="lblidEstadoOrigen" runat="server" Text="idEstadoOrigen" class="col-md"></asp:Label>
                    <asp:DropDownList ID="DropDownEstado" runat="server" class="form-text border-1 border-opacity-50"></asp:DropDownList><br />
                </div>
                <div>
                    <asp:RequiredFieldValidator ID="rfvIdEstado" runat="server" ErrorMessage="El Estado de origen es requerido" ControlToValidate="DropDownEstado" CssClass="text-danger"></asp:RequiredFieldValidator>
                </div>


                <div class="form-check">
                    <asp:Label ID="lblidEstatus" runat="server" Text="idEstatus" class="col-md"></asp:Label>
                    <asp:DropDownList ID="DropDownEstatus" runat="server" class="form-text border-1 border-opacity-50"></asp:DropDownList><br />
                </div>
                <div>
                    <asp:RequiredFieldValidator ID="rvidestado" runat="server" ErrorMessage="El estatus es requerido" ControlToValidate="DropDownEstatus" CssClass="text-danger"></asp:RequiredFieldValidator>
                </div>
        </div>
    </formview>
    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" class="btn btn-success"></asp:Button>
    <a href="index.aspx" class="link-opacity-50">Regresar al menu</a>


    <script type="text/javascript">
        function ValidarCurpvsFechaNacimiento(source, args) {
            let fechaNac = $("#<%= tbfechaNacimiento.ClientID%>").val();
            let curpPartFecha = args.Value.substr(4, 6);
            let fechaNacFormatoCURP = fechaNac.substr(2, 2) + fechaNac.substr(5, 2) + fechaNac.substr(8, 2);
            args.isValid = curpPartFecha == fechaNacFormatoCURP;
        }
    </script>
</asp:Content>
