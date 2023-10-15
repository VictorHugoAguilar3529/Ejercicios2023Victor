using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CRUDEstatus
{
    internal class Lista
    {
        static List<EstatusAlumnos> _lstEstatusAlumnos = new List<EstatusAlumnos>();
       // _lstEstatusAlumnos.Add( new EstatusAlumnos(1,"PTO", "Prospecto"));
       // _lstEstatusAlumnos.Add(new EstatusAlumnos(2, "CAP", "En_capacitacion"));
       // _lstEstatusAlumnos.Add(new EstatusAlumnos(3, "PTO", "En incursion"));

        public static void ConsultarTodos()
        {


            foreach (EstatusAlumnos estatusAlumnos1 in _lstEstatusAlumnos)
            {
                Console.WriteLine($"id={estatusAlumnos1.id}, clave={estatusAlumnos1.clave}, nombre={estatusAlumnos1.nombre}");
            }
           
        }



        public static EstatusAlumnos ConsultaUno(int id)
        {
             return _lstEstatusAlumnos.Find(x => x.id == id);
        }

        public static void Agregar( EstatusAlumnos estatusAlumnos)
        {
            _lstEstatusAlumnos.Add(estatusAlumnos);
        }

        public static void Actualizar(EstatusAlumnos estatusAlumnos)
        {
            
            EstatusAlumnos estatusAlumnos1 = _lstEstatusAlumnos.Find(x => x.id == estatusAlumnos.id);
            estatusAlumnos1.clave = estatusAlumnos.clave;
            estatusAlumnos1.nombre = estatusAlumnos.nombre;
        }

        public static void Eliminar(EstatusAlumnos estatusAlumnos)
        {
            EstatusAlumnos estatusAlumnos1 = _lstEstatusAlumnos.Find(x => x.id == estatusAlumnos.id);
            _lstEstatusAlumnos.Remove(estatusAlumnos1);


        }

    }
}
