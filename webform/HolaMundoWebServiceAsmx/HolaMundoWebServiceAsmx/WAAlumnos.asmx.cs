using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Entidades;
using Datos;
using Negocio;
namespace HolaMundoWebServiceAsmx
{
    /// <summary>
    /// Descripción breve de WAAlumnos
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class WAAlumnos : System.Web.Services.WebService
    {
        NAlumno _nAlumno = new NAlumno();

      
        [WebMethod]
        public ItemTablaISR CalcularISR(int id)
        {
            return _nAlumno.CarcualarISR(id);
        }
        [WebMethod]
        public AportacionesIMSS CalcularIMMS(int id)
        {
            return _nAlumno.CalcularIMMS(id);
        }
    }
}
