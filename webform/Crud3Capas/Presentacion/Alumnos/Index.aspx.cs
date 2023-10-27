using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;
using Microsoft.Ajax.Utilities;

namespace Presentacion.Alumnos
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarGrid();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridAlumnos_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            //Detalles
        }

        protected void GridAlumnos_CallingDataMethods(object sender, CallingDataMethodsEventArgs e)
        {
            //DEtalles
        }

        protected void GridAlumnos_Sorted(object sender, EventArgs e)
        {
            //Eliminar
            Alumno alumno = new Alumno();
            NAlumno nAlumno = new NAlumno();

        }

        protected void GridAlumnos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridAlumnos.PageIndex = e.NewPageIndex;
            CargarGrid();
        }
        public void CargarGrid()
        {
            NAlumno nAlumno = new NAlumno();
            List<Alumno> alumnos = new List<Alumno>();
            alumnos = nAlumno.ConsultarTodos();
            GridAlumnos.DataSource = alumnos;
            GridAlumnos.DataBind();
        }

        protected void GridAlumnos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "Page") { return; }
            int numeroRenglon =Convert.ToInt16( e.CommandArgument);
            GridViewRow renglon = GridAlumnos.Rows[numeroRenglon];
            TableCell celda = renglon.Cells[0];
            int id =Convert.ToInt16(celda.Text);
            switch (e.CommandName)
            {
                case "btnDetalles":
                    Response.Redirect($"Details.aspx?id={id}");
                    break;
                case "btnEditar":
                    Response.Redirect($"Edit.aspx?id={id}");
                    break;
                case "btnEliminar":
                    Response.Redirect($"Delete.aspx?id={id}");
                    break;
                case "btnAgregar":
                    Response.Redirect($"Delete.aspx?id={id}");
                    break;

            }
        }

        protected void Agregar_Click(object sender, EventArgs e)
        {
            Response.Redirect($"Create.aspx");
        }
    }
}