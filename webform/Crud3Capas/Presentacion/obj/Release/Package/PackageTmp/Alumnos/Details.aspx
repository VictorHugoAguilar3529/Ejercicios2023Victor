<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="Presentacion.Alumnos.Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <formview class="form-horizontal">

        <h2>Detalles</h2>
        <div class="col-md-2">
            <asp:Label ID="lblId" runat="server" Text="Id"></asp:Label>
        </div>
        <div class="col-md-2">
            <asp:Label ID="lblNombre" runat="server" Text="nombre"></asp:Label>
        </div>
        <div class="col-md-2">
            <asp:Label ID="lblprimerApellido" runat="server" Text="primerApellido"></asp:Label>
        </div>
        <div class="col-md-2">
            <asp:Label ID="lblsegundoApellido" runat="server" Text="segundoApellido"></asp:Label>
        </div>
        <div class="col-md-2">
            <asp:Label ID="lblcorreo" runat="server" Text="correo"></asp:Label>
        </div>
        <div class="col-md-2">
            <asp:Label ID="lbltelefono" runat="server" Text="telefono"></asp:Label>
        </div>
        <div class="col-md-2">
            <asp:Label ID="lblfechaNacimiento" runat="server" Text="fechaNacimiento"></asp:Label>
        </div>
        <div class="col-md-2">
            <asp:Label ID="lblcurp" runat="server" Text="curp"></asp:Label>
        </div>
        <div class="col-md-2">
            <asp:Label ID="lblsueldo" runat="server" Text="sueldo"></asp:Label>
        </div>
        <div class="col-md-2">
            <asp:Label ID="lblidEstadoOrigen" runat="server" Text="idEstadoOrigen"></asp:Label>
        </div>
        <div class="col-md-2">
            <asp:Label ID="lblidEstatus" runat="server" Text="idEstatus"></asp:Label>
        </div>


    </formview>
    <!-- Modal -->
    <div class="modal fade" id="exampleModal">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h1 class="modal-title fs-5" id="exampleModalLabel">Calculo del IMSS</h1>
                    <button type="button" class="btn-close btn-danger" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body form-horizontal">
                    <div class="form-check">
                        <asp:Label ID="Label1" runat="server" CssClass="text-dark" Text="Enfermedad y Maternidad"></asp:Label>
                        <br />
                        <asp:Label ID="lblEnfermedad" runat="server" Text="enfermedad"></asp:Label>
                    </div>

                    <div class="form-check">
                        <asp:Label ID="Label2" runat="server" Text="invalidez"></asp:Label>
                        <br />
                        <asp:Label ID="lblInvalidez" runat="server" Text="invalidez"></asp:Label>
                    </div>

                    <div class="form-check">
                        <asp:Label ID="Label3" runat="server" Text="Retiro"></asp:Label>
                        <br />
                        <asp:Label ID="lblRetiro" runat="server" Text="retiro"></asp:Label>
                    </div>

                    <div class="form-check">
                        <asp:Label ID="Label4" runat="server" Text="Cesentía"></asp:Label>
                        <br />
                        <asp:Label ID="lblCesentia" runat="server" Text="cesentia"></asp:Label>
                    </div>

                    <div class="form-check">
                        <asp:Label ID="Label5" runat="server" Text="Infonavid"></asp:Label>
                        <br />
                        <asp:Label ID="lblInfonavid" runat="server" Text="infonavid"></asp:Label>
                    </div>

                </div>
                <div class="modal-footer">
                    <button type="button" class="btn-danger" data-bs-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="ISRModal" tabindex="-1" aria-labelledby="ISRModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h1 class="modal-title fs-5" id="ISRModalLabel">Calculo de ISR</h1>
                    <button type="button" class="btn-close btn-danger" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body form-horizontal">
                    <div class="form-check">
                        <asp:Label ID="Label6" runat="server" CssClass="text-dark" Text="Limite Inferior"></asp:Label>
                        <br />
                        <asp:Label ID="lblMLiminf" runat="server" Text="enfermedad"></asp:Label>
                    </div>

                    <div class="form-check">
                        <asp:Label ID="Label8" runat="server" Text="Limite Superior"></asp:Label>
                        <br />
                        <asp:Label ID="lblMLimS" runat="server" Text="LImite Superior"></asp:Label>
                    </div>

                    <div class="form-check">
                        <asp:Label ID="Label10" runat="server" Text="Excedente"></asp:Label>
                        <br />
                        <asp:Label ID="lblMEx" runat="server" Text="Excedente"></asp:Label>
                    </div>

                    <div class="form-check">
                        <asp:Label ID="Label12" runat="server" Text="Cuota Fija"></asp:Label>
                        <br />
                        <asp:Label ID="lblMCuotaFija" runat="server" Text="CuotaFija"></asp:Label>
                    </div>

                    <div class="form-check">
                        <asp:Label ID="Label14" runat="server" Text="ISR"></asp:Label>
                        <br />
                        <asp:Label ID="lblMIsr" runat="server" Text="ISR"></asp:Label>
                    </div>

                </div>
                <div class="modal-footer">
                    <button type="button" class="btn-danger btn-secondary" data-bs-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
    <!-- OnClientClick="modal(); return true;" -->



    <div>
        <!--<asp:Button ID="btnCalcularIMMS" runat="server" Text="CalcularIMMS" OnClientClick="CalcularIMMS(); return true;" OnClick="btnCalcularIMMS_Click"></asp:Button>-->
        <button ID="btnCalcularIMMS" onclick="CalcularIMMS();" type="button">CalcularIMMS</button>
        <asp:Button ID="btnCalcularISR" runat="server" Text="CalcularISR"  OnClick="btnCalcularISR_Click"></asp:Button>
        <asp:Label ID="lblMensaje" runat="server" Text="Label"></asp:Label>
    </div>

    <a href="index.aspx">Regresar al menu</a>

    <script type="text/javascript">
  


  



        function CalcularIMMS() {
            var urlws = 'http://localhost:50120/WAAlumnos.asmx/CalcularIMMS';
            var id = $("#<%=lblId.ClientID%>").text();
            var alumno = {id:id};
            var parametro = JSON.stringify(alumno);
                    $.ajax({
                        type: 'POST',
                        url: urlws,
                        data: parametro,
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: RecibeObjeto,
                        error: errorGenerico
                    });

                }
    
        function RecibeObjeto(resultado) {
            try {
                aportacionesIMSS = resultado.d;
                if (aportacionesIMSS != null) {
                    $("#<%=lblEnfermedad.ClientID%>").text(aportacionesIMSS.EnfermedadMaternidad);
                    $("#<%=lblInvalidez.ClientID%>").text(aportacionesIMSS.InvalidezVida);
                    $("#<%=lblRetiro.ClientID%>").text(aportacionesIMSS.Retiro);
                    $("#<%=lblCesentia.ClientID%>").text(aportacionesIMSS.Cesantía);
                    $("#<%=lblInfonavid.ClientID%>").text(aportacionesIMSS.Infonavit);
                    $("#exampleModal").modal('show');
                            }
                            else {
                                alert('La respuesta recibida es incorrecta ' + resultado.d);
                            }

                        }
                        catch (ex) {
                            alert('Error al recibir los datos');
                        }
                    }
            function errorGenerico(jqXHR, estatus, error) {
                var msg = '';
                if (jqXHR.status === 0) {
                    msg = 'No está conectado, favor de verificar su conexión.';
                }
                else if (jqXHR.status === 404) {
                    msg = 'Página no encontrada [404]';
                }
                else if (jqXHR.status === 500) {
                    msg = 'Error no hay conexión al servidor [500]';
                }
                else if (jqXHR.status === 'parseerror') {
                    msg = 'El parseo del JSON es erróneo.';
                }
                else if (jqXHR.status === 'timeout') {
                    $('body').addClass('loaded');
                }
                else if (jqXHR.status === 'abort') {
                    msg = 'La petición Ajax fue abortada.';
                }
                else {
                    msg = 'Error no conocido. ';
                    console.log(exception);
                }
                alert(msg);
            }
      
    </script>
</asp:Content>
