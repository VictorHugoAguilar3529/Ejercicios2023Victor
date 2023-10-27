using ADOWebForms.ADO;
using ADOWebForms.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADOWebForms.forms
{
    public partial class Create : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ADOEstatusAlumno aDOEstatusAlumno = new ADOEstatusAlumno();
            EstatusAlumno estatusAlumno = new EstatusAlumno();
            estatusAlumno.nombre = tbNombre.Text;
            estatusAlumno.clave = tbCLave.Text;
            aDOEstatusAlumno.Agregar(estatusAlumno);
            


        }
    }
}