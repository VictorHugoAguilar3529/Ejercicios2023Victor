using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion.Alumnos
{
    public partial class Delete : System.Web.UI.Page
    {
        NAlumno nAlumno = new NAlumno();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                NAlumno na = new NAlumno();
                Alumno alumno = new Alumno();
                List<Alumno> est = new List<Alumno>();
                int id = Convert.ToInt16(Request.QueryString["id"] ?? "18");
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

        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            Alumno alumno = new Alumno();
            int id = Convert.ToInt16(Request.QueryString["id"] ?? "18");
            nAlumno.Eliminar(id);
        }
    }
}