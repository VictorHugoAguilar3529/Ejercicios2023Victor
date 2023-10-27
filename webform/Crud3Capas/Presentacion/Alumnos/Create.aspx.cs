using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;

namespace Presentacion.Alumnos
{
    public partial class Create : System.Web.UI.Page
    {
        NEstado nEstado = new NEstado();
        NEstatusAlumno nEstatusAlumno = new NEstatusAlumno();
        NAlumno nAlumno = new NAlumno();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Alumno> est = new List<Alumno>();
                List<Estado> estados = new List<Estado>();
                List<EstatusAlumno> estatusAlumnos = new List<EstatusAlumno>();
                estados = nEstado.ConsultarTodos();
                estatusAlumnos = nEstatusAlumno.ConsultarTodos();
                DropDownEstado.DataSource = estados;
                DropDownEstado.DataTextField = "nombre";
                DropDownEstado.DataValueField = "id";
                DropDownEstado.DataBind();
                DropDownEstatus.DataSource = estatusAlumnos;
                DropDownEstatus.DataTextField = "nombre";
                DropDownEstatus.DataValueField = "id";
                DropDownEstatus.DataBind();
            }

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            Alumno alumno = new Alumno();
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
            nAlumno.Agregar(alumno);
        }
    }
}