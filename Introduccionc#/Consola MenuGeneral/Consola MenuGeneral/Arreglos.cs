using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consola_MenuGeneral
{
    internal class Arreglos
    {
        public static void Cadenas()
        {
            string nombreCompleto;
            Console.WriteLine("¿Cual ES tu nombre completo?");
            nombreCompleto = Convert.ToString(Console.ReadLine());
            string[] subs = nombreCompleto.Split();

            foreach (string sub in subs)
            {
                Console.WriteLine($"Substring: {sub}");
            }

            char[] characters = subs[1].ToCharArray();
            Console.WriteLine(subs[1].ToCharArray());
            
        }
        public static void Enteros()
        {
            int[] num = new int[4];
            
            for (int f = 0; f < 5; f++)
            {
                Console.Write("Ingrese el numero");
                num[f] = Convert.ToInt16(Console.ReadLine());
            }
            int max = num[0], min = num[0];
            for (int i = 0; i < 15; i++)
            {
                if (num[i] > max)
                {
                    max = num[i];
                }


                else if(num[i] < min);
                    min = num[i];
                
                                          
            }


            Console.WriteLine("Numero menor: " + min + " Numero meyor: "+max);
        }

        public static void ConvierteATipoOracion()
        {
            string palabra;
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;

            Console.WriteLine("Escrube algo");
            palabra=Console.ReadLine();

            string titleCase = textInfo.ToTitleCase(palabra);
            Console.WriteLine(titleCase);
        }
        }
}
