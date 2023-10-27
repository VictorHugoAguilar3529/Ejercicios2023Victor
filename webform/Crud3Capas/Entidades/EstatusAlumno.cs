using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EstatusAlumno
    {
        public EstatusAlumno()
        {
        }

        public EstatusAlumno(int id, string clave, string Nombre)
        {
            this.id = id;
            this.clave = clave;
            this.Nombre = Nombre;
        }

        public int id {  get; set; }
        public string clave { get; set; }
        public string Nombre { get; set; }
    }
}
