using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class AportacionesIMSS
    {
        public AportacionesIMSS()
        {
        }

        public AportacionesIMSS(decimal enfermedadMaternidad, decimal invalidezVida, decimal retiro, decimal cesantía, decimal infonavit)
        {
            EnfermedadMaternidad = enfermedadMaternidad;
            InvalidezVida = invalidezVida;
            Retiro = retiro;
            Cesantía = cesantía;
            Infonavit = infonavit;
        }

        public decimal EnfermedadMaternidad {  get; set; }
        public decimal InvalidezVida {  get; set; }
        public decimal Retiro {  get; set; }
        public decimal Cesantía { get; set; }
        public decimal Infonavit {  get; set; }
    }
}
