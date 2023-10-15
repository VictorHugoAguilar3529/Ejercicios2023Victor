using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OperacionesAritméticas.TipoOperacion;

namespace OperacionesAritméticas
{
  
        public struct Resultado
        {
            public Resultado(decimal suma, decimal resta, decimal multiplicación, decimal división, decimal modulo)
            {
                Suma = suma;
                Resta = resta;
                this.multiplicación = multiplicación;
                this.división = división;
                this.modulo = modulo;
            }

            public decimal Suma { get; set; }
            public decimal Resta { get; set; }
            public decimal multiplicación { get; set; }
            public decimal división { get; set; }
            public decimal modulo { get; set; }          
        }
    
}
