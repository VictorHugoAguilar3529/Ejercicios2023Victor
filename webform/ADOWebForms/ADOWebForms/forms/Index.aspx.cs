using ADOWebForms.ADO;
using ADOWebForms.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADOWebForms.forms
{
    public partial class Index1 : System.Web.UI.Page
    {
        List<EstatusAlumno> _listEstatus = new List<EstatusAlumno>();
        public void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarDatos();
            }
        }
        public void cargarDatos()
        {
            
            ADOEstatusAlumno aDOEstatusAlumno = new ADOEstatusAlumno();        
            _listEstatus = aDOEstatusAlumno.Cargar();
            DropDownEstatus.DataSource = _listEstatus;
            DropDownEstatus.DataTextField = "nombre";
            DropDownEstatus.DataValueField = "id";
            DropDownEstatus.DataBind();
            

        }

        public void Agregar_Click(object sender, EventArgs e)
        {
            Response.Redirect($"Create.aspx");
        }

        protected void Detalles_Click1(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(DropDownEstatus.SelectedValue);
            Response.Redirect($"Details.aspx?id={id}");
        }


        protected void Editar_Click1(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(DropDownEstatus.SelectedValue);
            Response.Redirect($"Edit.aspx?id={id}");
        }


        protected void Eliminar_Click1(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(DropDownEstatus.SelectedValue);
            Response.Redirect($"Delete.aspx?id={id}");
        }
    }
}