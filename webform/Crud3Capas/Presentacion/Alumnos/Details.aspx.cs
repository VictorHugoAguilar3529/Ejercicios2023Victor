using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using System.Web.Optimization;

namespace Presentacion.Alumnos
{
    public partial class Details : System.Web.UI.Page
    {
        NAlumno nAlumno = new NAlumno();
        NEstado nEstado = new NEstado();
        List<Alumno> alu = new List<Alumno>();
        NEstatusAlumno nEstatus = new NEstatusAlumno();
        protected void Page_Load(object sender, EventArgs e)
        {

            Cargar();

        }
        public void Cargar()
        {
            NAlumno na = new NAlumno();
            Alumno alumno = new Alumno();
            Estado estado = new Estado();
            EstatusAlumno estatusAlumno = new EstatusAlumno();

            
            int id = Convert.ToInt16(Request.QueryString["id"] ?? "17");
            alumno = na.Consultar(id);



            lblId.Text = Convert.ToString(alumno.id);
            lblNombre.Text = alumno.nombre;
            lblprimerApellido.Text = alumno.primerApellido;
            lblsegundoApellido.Text = alumno.segundoApellido;
            lblcorreo.Text = alumno.correo;
            lbltelefono.Text = alumno.telefono;
            lblfechaNacimiento.Text = Convert.ToString(alumno.fechaNacimiento);
            lblcurp.Text = alumno.curp;
            lblsueldo.Text = Convert.ToString(alumno.sueldo);
            lblidEstadoOrigen.Text = Convert.ToString(alumno.idEstadoOrigen);

            lblidEstatus.Text = Convert.ToString(alumno.idEstatus);
        }

        protected void btnCalcularIMMS_Click(object sender, EventArgs e)
        {
            AportacionesIMSS aportacionesIMSS = new AportacionesIMSS();
            aportacionesIMSS = nAlumno.CalcularIMMS(Convert.ToInt32( lblId.Text));

            //lblMensaje.Text= Convert.ToString($"Enfermedad:{aportacionesIMSS.EnfermedadMaternidad.ToString("c2")} , Invalidez:{aportacionesIMSS.InvalidezVida.ToString("c2")}, Retiro:{aportacionesIMSS.Retiro.ToString("c2")}, Infonavid:{aportacionesIMSS.Infonavit.ToString("c2")}");

            lblEnfermedad.Text =Convert.ToString( aportacionesIMSS.EnfermedadMaternidad.ToString("c2"));
            lblInvalidez.Text = Convert.ToString(aportacionesIMSS.InvalidezVida.ToString("c2"));
            lblRetiro.Text = Convert.ToString(aportacionesIMSS.Retiro.ToString("c2"));
            lblInfonavid.Text = Convert.ToString(aportacionesIMSS.Infonavit.ToString("c2"));

            string script = @"<script type='text/javascript'>
                                $(function (){
                                $('#exampleModal').modal('show');
                                })</script>";
            ScriptManager.RegisterStartupScript(this, GetType(),"MuestraModal", script, false);

        }

        protected void btnCalcularISR_Click(object sender, EventArgs e)
        {
            ItemTablaISR itemTablaISR = new ItemTablaISR();
            decimal quincena =Convert.ToDecimal( lblsueldo.Text)/2;
            itemTablaISR = nAlumno.CarcualarISR(Convert.ToInt16(lblId.Text));
            //lblMensaje.Text =Convert.ToString($"Limite inferior:{itemTablaISR.LimInf.ToString("c2")} , Limite Superior:{itemTablaISR.LimSup.ToString("c2")}, Excedente:{itemTablaISR.ExedLimInf.ToString("c2")}, CuotaFija:{itemTablaISR.CuotaFija.ToString("c2")}, ISR: {itemTablaISR.isr.ToString("c2")}");
            lblMLiminf.Text = Convert.ToString(itemTablaISR.LimInf.ToString("c2"));
            lblMLimS.Text = Convert.ToString(itemTablaISR.LimSup.ToString("c2"));
            lblMEx.Text = Convert.ToString(itemTablaISR.ExedLimInf.ToString("c2"));
            lblMCuotaFija.Text = Convert.ToString(itemTablaISR.CuotaFija.ToString("c2"));
            lblMIsr.Text = Convert.ToString(itemTablaISR.isr.ToString("c2"));

            string script = @"<script type='text/javascript'>
                                $(function (){
                                $('#ISRModal').modal('show');
                                })</script>";
            ScriptManager.RegisterStartupScript(this, GetType(), "MuestraISRModal", script, false);
        }
    }
}