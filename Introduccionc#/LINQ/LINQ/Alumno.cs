using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class Alumno
    {
        public Alumno() { }
        public Alumno(int id, string nombre, decimal calificacion, int idEstado, int idEstatus)
        {
            this.id = id;
            this.nombre = nombre;
            this.calificacion = calificacion;
            this.idEstado = idEstado;
            this.idEstatus = idEstatus;
        }

        public int id {  get; set; }
        public string nombre { get; set; }
        public decimal calificacion { get; set; }
        public int idEstado { get; set; }
        public int idEstatus { get;}
    }
}
