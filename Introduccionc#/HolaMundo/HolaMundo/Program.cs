using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolaMundo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string nombre;

            Console.WriteLine("¿cúal es tu nombre?");
            nombre=Console.ReadLine();

            //invocar metodo no estatico
           /* string retornoMetodoEstatico = Saludo.SaludarEstatico(nombre);
            Console.WriteLine(retornoMetodoEstatico);*/
           // Console.WriteLine("Hola. ¿como estas " + nombre + "?");


            //invocar metodo no estatico

            //instanciar clase para crear un objeto
            Saludo saludo = new Saludo();

            string retornoMetodoNoEstatico=saludo.Saludar(nombre);
            Console.WriteLine(retornoMetodoNoEstatico);

            Console.ReadKey();
        }
    }
}
