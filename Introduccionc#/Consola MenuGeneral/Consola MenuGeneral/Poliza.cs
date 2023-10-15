using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consola_MenuGeneral
{
    internal class Poliza
    {
        public static void Calcular( DateTime fechaiVigencia, string tipoPer, int cantidadPer, decimal sumaAsegurada, DateTime fechaNacimiento, string genero)
        {
            DateTime fechaTerminoPoliza;
            fechaTerminoPoliza  =DateTime.Today;
            decimal Prima;
            TimeSpan diffechas;
            int días = 0;
            int g =0;
            decimal factor;
            factor = 0;
            //int edad;
            if (tipoPer =="días")
            {
                fechaTerminoPoliza = fechaiVigencia.AddDays(cantidadPer);
                diffechas = (fechaTerminoPoliza - fechaiVigencia);
                días = diffechas.Days;
            }
            if (tipoPer == "meses")
            {
                fechaTerminoPoliza = fechaiVigencia.AddMonths(cantidadPer);
                diffechas = (fechaTerminoPoliza - fechaiVigencia);
                días = diffechas.Days;
            }
            if (tipoPer == "años")
            {
                fechaTerminoPoliza = fechaiVigencia.AddYears(cantidadPer);
                diffechas = ( fechaTerminoPoliza - fechaiVigencia);
                días = diffechas.Days;
            }
 
            int edad =DateTime.Today.Year - fechaNacimiento.Year  ;
            if(genero == "M")
            {
                g = 2;
            }
            if(genero == "F")
            {
                g = 1;
            }

            //21,6
            decimal[,] arregloBusqueda = new decimal[ 12, 4]
            {
                
                    { 0,  20, 1, 0.05m },
                    { 21, 30, 1, 0.1m },
                    { 31, 40, 1, 0.4m },
                    { 41, 50, 1, 0.5m },
                    { 51, 60, 1, 0.65m },
                    { 61, 120, 1, 0.85m },
                    { 0,  20, 2, 0.05m },
                    { 21, 30, 2, 0.1m },
                    { 31, 40, 2, 0.4m },
                    { 41, 50, 2, 0.55m },
                    { 51, 60, 2, 0.7m },
                    { 61, 120, 2, 0.9m }
                
            };
            for (int i = 0; i < 12; i++)
            {
                if (arregloBusqueda[i,0] <=edad && arregloBusqueda[i,1]>=edad && arregloBusqueda[i,2] == g)
                {
                    
                    factor = arregloBusqueda[i,3];
                    
                    
                }
                                                            
            }
            Prima = ((sumaAsegurada * factor) * (días / 360m));
            Console.WriteLine("la poliza vencera el  " + fechaTerminoPoliza);
            Console.WriteLine("la prima a pagas es de " + Prima.ToString("C2"));
        }
        public static void Presentacion()
        {
            DateTime fechaiVigencia;
            string tipoPer;
            decimal sumaAsegurada;
            DateTime fechaNacimiento;
            string genero;
            byte tiempo;
            string periodo;
            Console.WriteLine("Proporciona la fecha de inicio de Vigencia:");
            fechaiVigencia = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Proporciona para cuanto tiempo requieres la póliza (ejemplo 2 años):");
            tipoPer = Console.ReadLine();
            tiempo = Convert.ToByte(tipoPer.Substring(0, tipoPer.IndexOf(" ")));
            periodo = tipoPer.Substring(tipoPer.IndexOf(" ") + 1);
            Console.WriteLine("Proporciona la suma asegurada:");
            sumaAsegurada = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Proporciona la fecha de Nacimiento del asegurado:");
            fechaNacimiento = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Proporciona el género del asegurado M|F:");
            genero = Console.ReadLine();
            Calcular(fechaiVigencia, periodo, tiempo, sumaAsegurada, fechaNacimiento, genero);
        }
        }
}
