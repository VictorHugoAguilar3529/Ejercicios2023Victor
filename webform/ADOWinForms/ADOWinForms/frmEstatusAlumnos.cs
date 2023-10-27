using ADOWinForms.ADO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADOWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Action action;

        private void Form1_Load(object sender, EventArgs e)
        {

            Actualizaformulario();
        }
        public void Actualizaformulario()
        {
            panel1.Visible = false;
            ADOEstatusAlumno aDOEstatusAlumno = new ADOEstatusAlumno();
            List<Estatus> _listEstatus = new List<Estatus>();
            _listEstatus = aDOEstatusAlumno.Cargar();
            comboBox1.DataSource = _listEstatus;
            comboBox1.DisplayMember = "nombre";
            comboBox1.ValueMember = "id";
            dataGridView1.DataSource = _listEstatus;
        }

        private void Agregar_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            action = Action.agregar;
        }
        private void Actualizar_click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            action = Action.actualizar;
            Estatus estatus = (Estatus)comboBox1.SelectedItem;
            textNombre.Text = estatus.nombre;
            textClave.Text = estatus.clave;
            
        }
        private void Eliminar_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            btnGuardar.Text = "Eliminar";
            action = Action.eliminar;
            Estatus estatus = (Estatus)comboBox1.SelectedItem;
            textNombre.Text = estatus.nombre;
            textClave.Text = estatus.clave;

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ADOEstatusAlumno aDOEstatusAlumno = new ADOEstatusAlumno();
            Estatus estatus = new Estatus();
            if(action == Action.agregar)
            {
                estatus.clave = textClave.Text;
                estatus.nombre = textNombre.Text;
                aDOEstatusAlumno.Agregar(estatus);
                Actualizaformulario();
            }
            else if (action == Action.actualizar)
            {
                estatus.id =Convert.ToInt16(comboBox1.SelectedValue);
                estatus.clave = textClave.Text;
                estatus.nombre = textNombre.Text;
                aDOEstatusAlumno.Actualizar(estatus);
                Actualizaformulario();
            }
            else if (action == Action.eliminar)
            {
                estatus.id= Convert.ToInt16(comboBox1.SelectedValue);
                aDOEstatusAlumno.Eliminar(estatus.id);
                Actualizaformulario();
            }
        }


    }
}
