using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Entidades;
using Negocio;
using WCFAlumnos;
using Newtonsoft;
using Newtonsoft.Json;

namespace WCFAlumnos
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "WCFAlumnos" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione WCFAlumnos.svc o WCFAlumnos.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class WCFAlumnos : IWCFAlumnos
    {

        NAlumno _nAlumno = new NAlumno();

        public void DoWork()
        {
        }

        public AportacionesIMSS CalcularIMSS(int id)
        {
            _nAlumno = new NAlumno();
            AportacionesIMSS aportacionesIMSS = new AportacionesIMSS();
            Entidades.AportacionesIMSS apIMSS =_nAlumno.CalcularIMMS(id);
            string json = JsonConvert.SerializeObject(apIMSS);
            aportacionesIMSS = JsonConvert.DeserializeObject<AportacionesIMSS>(json);

            return aportacionesIMSS;
        }


        public ItemTablaISR CalcularISR(int id)
        {
            _nAlumno = new NAlumno();
            ItemTablaISR itemTablaISR = new ItemTablaISR();
            Entidades.ItemTablaISR itemTabla = _nAlumno.CarcualarISR(id);

            string json = JsonConvert.SerializeObject(itemTabla);
            itemTablaISR = JsonConvert.DeserializeObject<ItemTablaISR>(json);
            

            return itemTablaISR;
        }
    }
}
