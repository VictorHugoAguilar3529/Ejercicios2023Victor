using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puntoventa
{
    internal class Ticket
    {
        public List<IArticulo> ListaArticulos List<IArticulos>();
        

            public void Imprimir()
        {
            foreach(var item in ListaArticulos)
            {
                Console.WriteLine(item.Imprimir();
            }
        }
    }
}
