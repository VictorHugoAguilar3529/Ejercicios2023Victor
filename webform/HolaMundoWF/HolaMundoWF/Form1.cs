using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HolaMundoWF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Estado> listaEstados = new List<Estado>
        {
            new Estado{id=1, nombre= "veracruz" },
            new Estado{id=2, nombre= "Querétaro" },
            new Estado{id=3, nombre = "Puebla"}
        };

        //cbxEstados.DataSource = ListaEstados;
        //cbxEstados.DisplayMember = "nombre";
        //cbxEstados.ValueMember = "id";
        //bgvEstados.DataSources = LisEstados
        
    }
}
