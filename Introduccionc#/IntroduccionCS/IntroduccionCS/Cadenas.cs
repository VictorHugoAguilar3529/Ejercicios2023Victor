using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionCS
{
    internal class Cadenas
    {
        public static void HolaMundo()
        {
            //Declaracion de variables
            string nom;
            String ap1;
            String ap2;
            byte edad;

            //recoleccion de informacion
            Console.WriteLine("¿cúal es tu nombre?");
            nom = Console.ReadLine().Trim();
            Console.WriteLine("¿cúal es tu apellido paterno?");
            ap1 = Console.ReadLine().Trim();
            Console.WriteLine("¿cúal es tu apellido materno?");
            ap2 = Console.ReadLine().Trim();
            Console.WriteLine("¿cúal es tu edad?");
            edad = Convert.ToByte(Console.ReadLine());

            //concatenacion
            String cadena1;
            String cadena2;
            cadena1 = nom + " " + ap1 + " " + ap2 ;
            //interpola
            Console.WriteLine(cadena1);
            cadena2 = $"{nom.ToUpper()} {ap1.ToUpper()} {ap2.ToUpper()} es el instructor y tiene {edad} años de edad.";
            Console.WriteLine(cadena2);
            //FormatoCompuesto
            Console.WriteLine("{0} {1} {2} tiene {3} años de edad."
            , nom, ap1, ap2, edad);

            //archivo
            string ruta = "C:\\Users\\aguil\\source\\bootcamp\\c#";
            ruta = @"C:\Users\aguil\source\bootcamp\c#";
            Console.WriteLine("el archio fue almacenado en " + ruta);

            

        }



        }
}
