using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OperacionesLINQ OperacionesLINQ = new OperacionesLINQ();
            OperacionesLINQ.CargarLists();
            OperacionesLINQ.Consultas();


            Console.ReadKey();
        }
    }
}
