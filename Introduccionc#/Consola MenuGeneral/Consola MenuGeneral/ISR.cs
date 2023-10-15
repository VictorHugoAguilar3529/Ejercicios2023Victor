using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Consola_MenuGeneral
{
    internal class ISR
    {
        static decimal[,] arregloBusqueda = new decimal[21, 6];


        public static void CargarTabla(string nombreArchivo)
        {
            byte Ncolumnas = 6;
            string Tabla = "TablaISR";
            string sentenciaSql = "";
            string rutacompleta = nombreArchivo;
            

            // ALMACENAR LOS RENGLONES DEL DOCUMENTO EN UN ARRAY
            string linea;
            StreamReader archivo = new StreamReader(nombreArchivo);
            linea = archivo.ReadLine();
            
            string datoIndividual;

            for (int i = 0;  ( linea = archivo.ReadLine())!= null; i++)
            {

                for (int j = 0; j < 6; j++)
                {
                    string[] renglones =linea.Split(',');
                   
                    arregloBusqueda[i, j]  = Convert.ToDecimal(renglones[j]);
                }


            }

                    
        }//termina

        public static void Calcular(decimal sueldoMensual)
        {
            decimal sueldoQuincenal = sueldoMensual / 2;
            decimal ISR;
            decimal limInferior = 0;
            decimal subsidio = 0;
            decimal cuatoFija = 0;
            decimal exedente = 0;
            decimal resultado1 = 0;
            decimal resulado2 = 0;
            for (int i = 0; i < 20; i++)
            {
                if (sueldoQuincenal >= arregloBusqueda[i, 1]  && sueldoQuincenal <= arregloBusqueda[i, 2]  )
                {

                    
                    limInferior = arregloBusqueda[i, 1];
                    subsidio = arregloBusqueda[i, 5];
                    cuatoFija = arregloBusqueda[i, 3];
                    exedente = arregloBusqueda[i, 4];

                }

            }
            resultado1 = ((sueldoQuincenal - limInferior) * exedente)/100;
            ISR = resultado1 + cuatoFija - subsidio;

            Console.WriteLine("Impuesto = " + ISR.ToString("C2"));
        }
        public static void Presentacion()
        {
            String nombreArchivo;
            decimal sueldoMensual;

            //Pedir nombre del archivo e invocar metodo para cargar la tablas
            Console.WriteLine("¿Cual es el nombre de la tablas?");
            nombreArchivo = Console.ReadLine();
            CargarTabla(nombreArchivo);
            //C:\Users\aguil\source\bootcamp\c#\Consola MenuGeneral\TablaISR.csv

            //Pedir sueldo e invocar metodo para calcular isr
            Console.WriteLine("¿Cual es el sueldo mensual?");
            sueldoMensual =Convert.ToDecimal(Console.ReadLine());
            Calcular(sueldoMensual);

        }
    }
}
