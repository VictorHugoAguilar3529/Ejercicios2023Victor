using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Consola_MenuGeneral
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string opcion = null;
            do
            {
                //Menu
                Console.WriteLine("1.- HolaMundo");
                Console.WriteLine("2.- Conversiopn tipo horación");
                Console.WriteLine("3.- Opción 3");
                Console.WriteLine("4.- Opción 4");
                Console.WriteLine("5.- Mostrar ArchivoCSV");
                Console.WriteLine("6.- Opción 6");
                Console.WriteLine("7.- ISR");
                Console.WriteLine("8.- Opción 8");
                Console.WriteLine("F.- Terminar");
                opcion = Convert.ToString(Console.ReadLine());
                Console.Clear();
                Arreglos Arreglos = new Arreglos();
                Poliza Poliza = new Poliza();
                Archivotxt Archivotxt = new Archivotxt();
                ISR iSR = new ISR();
                switch (opcion)
                {
                    case "1":
                        Console.WriteLine("Usted seleccionó la opción 1 ");
                        Arreglos.Cadenas();
                        break;
                    case "2":
                        Console.WriteLine("Usted seleccionó la opción 2 ");                      
                        Arreglos.Enteros();

                        break;
                    case "3":
                        Console.WriteLine("Usted seleccionó la opción 3 ");
                        Arreglos.ConvierteATipoOracion();

                        break;
                    case "4":
                        Console.WriteLine("Usted seleccionó la opción 4 ");
                        Poliza.Presentacion();
                        break;
                    case "5":
                        Console.WriteLine("Usted seleccionó la opción 5 ");                        
                        Archivotxt.Presentación();
                        break;
                    case "6":
                        String ruta;
                        Boolean res;
                        string format;
                        Console.WriteLine("Usted seleccionó la opción 6 ");
                        Console.WriteLine("proporciona la ruta del archivo");
                        ruta = Console.ReadLine();
                        Console.WriteLine("archivo nuevo?");
                        res =Convert.ToBoolean(Console.ReadLine());
                        Console.WriteLine("formato?");
                        format = Console.ReadLine();
                        Archivotxt.EscribirTxt(ruta,res,format);
                        
                        //
                        break;
                    case "7":
                        Console.WriteLine("Usted seleccionó la opción 7 ISR ");
                        ISR.Presentacion();

                        break;
                    case "F":
                        Console.WriteLine("Terminar");
                        
                        break;
                }
            }
            while (opcion != "F");
 
            
            Console.ReadKey();
            }
    }
}
