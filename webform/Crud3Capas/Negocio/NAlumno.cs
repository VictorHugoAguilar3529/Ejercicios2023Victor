using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;
using Newtonsoft;
using Newtonsoft.Json;

namespace Negocio
{
    public class NAlumno
    {
        DAlumno dAlumno = new DAlumno();
        Alumno alumno = new Alumno();
        decimal variablegbal1 =Convert.ToDecimal( ConfigurationManager.AppSettings["UMA"]);
        public List<Alumno> ConsultarTodos()
        {
            List<Alumno> listAlu = new List<Alumno>();
            listAlu = dAlumno.ConsultarTodos();


            return listAlu;
        }
        public Alumno Consultar(int id)
        {
            
            alumno = dAlumno.Consultar(id);
            return alumno;
        }

        public void Agregar(Alumno alumno)
        {
            dAlumno.Agregar(alumno);
        }
        public void Actualizar(Alumno alumno)
        {
            dAlumno.Actualizar(alumno);
        }
        public void Eliminar(int id)
        { 
            dAlumno.Eliminar(id);
        }
        public ItemTablaISR CarcualarISR(int id)
        {
            ItemTablaISR itemTablaISR = new ItemTablaISR();    
            try
            {
                redWSAlumnos.WAAlumnosSoapClient oWSASoup = new redWSAlumnos.WAAlumnosSoapClient();
                redWSAlumnos.ItemTablaISR tablaISR = oWSASoup.CalcularISR(id);
                string Json  = JsonConvert.SerializeObject(tablaISR);

                itemTablaISR = JsonConvert.DeserializeObject<ItemTablaISR>(Json);

            }
            catch
            {
            alumno = dAlumno.Consultar(id);
            decimal sueldoQuincenal =Convert.ToDecimal( alumno.sueldo) / 2;
            List<ItemTablaISR> _itemTablaISRs = new List<ItemTablaISR>();
            _itemTablaISRs = dAlumno.ConsultarTablaISR();

            itemTablaISR = _itemTablaISRs.Find(x => x.LimInf <= sueldoQuincenal && x.LimSup >= sueldoQuincenal);
            decimal res1 = ((sueldoQuincenal - itemTablaISR.LimInf) * itemTablaISR.ExedLimInf) / 100;
            itemTablaISR.isr = res1 + itemTablaISR.CuotaFija - itemTablaISR.Subsidio;
            }
          

            return itemTablaISR;
        }

        public AportacionesIMSS CalcularIMMS(int id)
        {
            alumno = dAlumno.Consultar(id);
            decimal sueldo = alumno.sueldo;
            AportacionesIMSS aportacionesIMSS = new AportacionesIMSS();
            aportacionesIMSS.EnfermedadMaternidad  = (0.004m) * (sueldo - (variablegbal1 * 3));
            aportacionesIMSS.InvalidezVida = (0.00625m) * sueldo;
            aportacionesIMSS.Retiro = (0.00m) * sueldo;
            aportacionesIMSS.Cesantía = (0.00125m) * sueldo;
            aportacionesIMSS.Infonavit = (0.00m) * sueldo;
            return aportacionesIMSS;
        }


    }
}
