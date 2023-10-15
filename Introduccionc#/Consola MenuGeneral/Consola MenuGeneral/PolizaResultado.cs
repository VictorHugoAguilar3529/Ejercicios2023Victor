using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consola_MenuGeneral
{
    public struct PolizaResultado
    {
        public PolizaResultado(DateTime fechaTermino, decimal prima)
        {
            FechaTermino = fechaTermino;
            Prima = prima;
        }

        public DateTime FechaTermino { get; set; }
        public Decimal Prima { get; set; }
    }
}
