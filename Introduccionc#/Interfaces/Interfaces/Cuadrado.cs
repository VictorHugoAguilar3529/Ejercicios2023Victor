using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public class Cuadrado: IFigura
    {
        public Cuadrado( decimal bas)
        {
            
            this.bas = bas;
        }

        
        public decimal bas { get; set; }

        public decimal Area()
        {
            return bas * bas;
        }
        public decimal Perimetro()
        {
            return bas * 4;
        }
    }
}
