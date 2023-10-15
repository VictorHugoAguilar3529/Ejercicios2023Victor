using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public class Triangulo: IFigura
    {
        public Triangulo( decimal bas, decimal diagonal)
        {
            this.bas = bas;
            this.diagonal = diagonal;
        }
     
        public decimal bas { get; set; }
        public decimal diagonal { get; set; }


        public decimal Area()
        {
            double d =Math.Pow( Convert.ToDouble(diagonal),2 );
            double b =Math.Pow( Convert.ToDouble(bas), 2);
            decimal h =(decimal) Math.Sqrt( d - (b/4));
            return (bas * h) / 2;
        }
        public decimal Perimetro()
        {

            decimal p =  bas + diagonal + diagonal;

            return p;
        }
    }
}
