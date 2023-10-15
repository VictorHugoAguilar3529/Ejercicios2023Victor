using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionCS
{
    internal class Program
    {
        static void Main(string[] args)
        {


            //invocar metodo no estatico
            /* string retornoMetodoEstatico = Saludo.SaludarEstatico(nombre);
             Console.WriteLine(retornoMetodoEstatico);*/
            // Console.WriteLine("Hola. ¿como estas " + nombre + "?");


            //invocar metodo no estatico

            //instanciar clase para crear un objeto
            Cadenas Cadenas = new Cadenas();
            Cadenas.HolaMundo();
            Console.ReadKey();
            //conca

        }
    }
}
