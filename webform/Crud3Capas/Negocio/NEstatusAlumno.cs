using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;

namespace Negocio
{
    public class NEstatusAlumno
    {
        DEstatusAlumno dEstatusAlumno = new Datos.DEstatusAlumno();
        public List<EstatusAlumno> ConsultarTodos()
        {
            List<EstatusAlumno> estatusAlumnos = new List<EstatusAlumno>();
            estatusAlumnos = dEstatusAlumno.ConsultarTodos();
            return estatusAlumnos;
        }
    }
}
