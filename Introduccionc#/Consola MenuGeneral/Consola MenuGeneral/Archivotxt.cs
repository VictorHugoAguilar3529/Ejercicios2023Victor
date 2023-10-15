using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consola_MenuGeneral
{
    internal class Archivotxt
    {
        public static void MostrarTxt(String nombre)
        {
            string linea;  //C:\Users\aguil\source\bootcamp\c#\Consola MenuGeneral\Alumnos.csv
            StreamReader arcchivo = new StreamReader(nombre);
            linea = arcchivo.ReadToEnd();
            Console.WriteLine(linea);
            arcchivo.Close();
        }
        public static void MostrarCSV(string ruta)
        {
            string linea;
            StreamReader arcchivo = new StreamReader(ruta);
            linea = arcchivo.ReadLine();
            Console.WriteLine(linea);
            linea = arcchivo.ReadLine();
            Console.WriteLine(linea);
            linea = arcchivo.ReadLine();
            Console.WriteLine(linea);
            arcchivo.Close();
        }
        public static void Presentación()
        {
            String nombre;
            String nombre2;
            Console.WriteLine("¿Cual es el nombre del archivo txt?");
            nombre = Console.ReadLine();
            MostrarTxt(nombre);

        }
        public static void EscribirTxt(string ruta, Boolean nuevo, string formato)
        {
            string nombre;
            string ap1;
            string ap2;
            string nombreCompleto;
            string res;
            byte edad;
            string nombredelarchivo = ruta;
            StreamWriter archivo = null;
            if (!File.Exists(nombredelarchivo))
            {
                Console.WriteLine("El archivo ya existe");

            }
            else
            {
                //crea archivo
                switch (formato)
                {
                    case "UTF7":
                        archivo = new StreamWriter(nombredelarchivo, nuevo, Encoding.UTF7);
                        break;
                    case "UTF8":
                        archivo = new StreamWriter(nombredelarchivo, nuevo, Encoding.UTF8);
                        break;
                    case "Unicode":
                        archivo = new StreamWriter(nombredelarchivo, nuevo, Encoding.Unicode);
                        break;
                    case "UTF32":
                        archivo = new StreamWriter(nombredelarchivo, nuevo, Encoding.UTF32);
                        break;
                    case "ASCII":
                        archivo = new StreamWriter(nombredelarchivo, nuevo, Encoding.ASCII);
                        break;
                }
                       
            }


            do
            {
                Console.WriteLine("¿Cual es el nombre del alumno?");
                nombre = Console.ReadLine();
                Console.WriteLine("¿Cual es el primer apellido del alumno?");
                ap1 = Console.ReadLine();
                Console.WriteLine("¿Cual es el segundo apellido del alumno?");
                ap2 = Console.ReadLine();
                Console.WriteLine("¿Cual es la edad del alumno?");
                nombreCompleto = nombre + " " + ap1 + " " + ap2;
                archivo.WriteLine(nombreCompleto);
                edad = Convert.ToByte(Console.ReadLine());
                archivo.WriteLine(edad);
                Console.WriteLine("¿Desea agregar otro registro si o no?");
                res = Console.ReadLine();
            }
            while (res == "si");

            archivo.Close();
        }
        }
}
