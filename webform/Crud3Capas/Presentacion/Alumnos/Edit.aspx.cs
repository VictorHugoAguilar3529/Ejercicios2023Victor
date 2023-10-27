using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion.Alumnos
{
    public partial class Edit : System.Web.UI.Page
    {
        NEstado nEstado = new NEstado();
        NEstatusAlumno nEstatusAlumno = new NEstatusAlumno();
        NAlumno nAlumno = new NAlumno();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                NAlumno na = new NAlumno();
                Alumno alumno = new Alumno();
                Estado estado = new Estado();
                List<Alumno> est = new List<Alumno>();
                List<Estado> estados = new List<Estado>();
                List<EstatusAlumno> estatusAlumnos = new List<EstatusAlumno>();
                int id = Convert.ToInt16(Request.QueryString["id "] ?? "17");
                alumno = na.Consultar(id);
                estados = nEstado.ConsultarTodos();
                estatusAlumnos = nEstatusAlumno.ConsultarTodos();



                tbNombre.Text = alumno.nombre;
                tbprimerApellido.Text = alumno.primerApellido;
                tbsegundoApellido.Text = alumno.segundoApellido;
                tbcorreo.Text = alumno.correo;
                tbtelefono.Text = alumno.telefono;
                tbfechaNacimiento.Text = Convert.ToString(alumno.fechaNacimiento);
                tbcurp.Text = alumno.curp;
                tbsueldo.Text = Convert.ToString(alumno.sueldo);
                //tbidEstadoOrigen.Text = Convert.ToString(alumno.idEstadoOrigen);
                DropDownEstado.DataSource = estados;
                DropDownEstado.DataTextField = "nombre";
                DropDownEstado.DataValueField = "id";
                DropDownEstado.DataBind();
                //tbidEstatus.Text = Convert.ToString(alumno.idEstatus);
                DropDownEstatus.DataSource = estatusAlumnos;
                DropDownEstatus.DataTextField = "nombre";
                DropDownEstatus.DataValueField = "id";
                DropDownEstatus.DataBind();
            }

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if(IsValid)
            {

            Alumno alumno = new Alumno();
            alumno.id = Convert.ToInt16(Request.QueryString["id"] ?? "17");
            alumno.nombre = tbNombre.Text;
            alumno.primerApellido = tbprimerApellido.Text;
            alumno.segundoApellido = tbsegundoApellido.Text;
            alumno.correo = tbcorreo.Text;
            alumno.telefono = tbtelefono.Text;
            alumno.fechaNacimiento = Convert.ToDateTime(tbfechaNacimiento.Text);
            alumno.curp = tbcurp.Text;
            alumno.sueldo = Convert.ToDecimal(tbsueldo.Text);
            alumno.idEstadoOrigen = Convert.ToInt32(DropDownEstado.SelectedValue);
            alumno.idEstatus = Convert.ToInt32(DropDownEstatus.SelectedValue);
            nAlumno.Actualizar(alumno);
            }

        }

        protected void tbcurp_DataBinding(object sender, EventArgs e)
        {
           
 
            
        }

        protected void tbcurp_TextChanged(object sender, EventArgs e)
        {

        }

        protected void cvCurpVsFechaNac_ServerValidate(object source, ServerValidateEventArgs args)
        {
            var fechaNac = tbfechaNacimiento.Text;
            var curpPartFecha = args.Value.Substring(4, 6);
            var fechaNacFormatoCURP = fechaNac.Substring(2, 2) + fechaNac.Substring(5, 2) + fechaNac.Substring(8, 2);
            args.IsValid = curpPartFecha == fechaNacFormatoCURP;
        }
    }
}