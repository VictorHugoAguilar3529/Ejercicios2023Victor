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
    public partial class Details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ADOEstatusAlumno aDO = new ADOEstatusAlumno();
            EstatusAlumno es = new EstatusAlumno();
            List<EstatusAlumno> est = new List<EstatusAlumno>();
            int id = Convert.ToInt16(Request.QueryString["id ?? 18"]);
            es = aDO.Consultar(id);


            lblId.Text =Convert.ToString( es.id);
            lblCLave.Text = es.clave;
            lblNombre.Text = es.nombre;

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            
        }
    }
}