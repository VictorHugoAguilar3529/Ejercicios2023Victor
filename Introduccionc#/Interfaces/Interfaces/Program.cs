using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IFigura[] figura = new IFigura[2];
            figura[0] = new Cuadrado( 20m);
            figura[1] = new Triangulo(10m,20m);
            
            foreach (IFigura figura1 in figura)
            {

                Console.WriteLine($"  nombre {figura1.ToString()} Area {figura1.Area()} perimetro {figura1.Perimetro()}");

            }
            Console.ReadKey();
            
        }
    }
}
