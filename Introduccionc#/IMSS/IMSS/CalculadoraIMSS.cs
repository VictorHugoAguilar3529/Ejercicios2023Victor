using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSS
{
    internal class CalculadoraIMSS
    {
        public static void Calcular(decimal SBC, decimal UMA, byte puesto)
        {
            if(puesto == 1) {
            decimal enfermedad = (  0.004m) * (SBC-(UMA * 3));           
            decimal invalidez = (  0.00625m) * SBC;
            decimal retiro = (  0.00m) * SBC;
            decimal casantia = (  0.00125m) * SBC;
            decimal infonavid = (  0.00m) * SBC;
            decimal total = enfermedad + invalidez + retiro + casantia +infonavid;
            Console.WriteLine("enfermedad: " + enfermedad.ToString("C2"));
            Console.WriteLine("invalidez: " + invalidez.ToString("C2"));
            Console.WriteLine("retiro: " + retiro.ToString("C2"));
            Console.WriteLine("casantia: " + casantia.ToString("C2"));
            Console.WriteLine("infonavid: " + infonavid.ToString("C2"));
            Console.WriteLine("total: " + total.ToString("C2"));
            }
            else
            {
            decimal enfermedad = (0.0101m) * (SBC-(UMA * 3));
            decimal invalidez = (  0.0175m) * SBC;
            decimal retiro = (  0.02m) * SBC;
            decimal casantia = (  0.03150m) * SBC;
            decimal infonavid = (  0.05m) * SBC;
            decimal total = enfermedad + invalidez + retiro + casantia +infonavid;
            Console.WriteLine("enfermedad: " + enfermedad.ToString("C2"));
            Console.WriteLine("invalidez: " + invalidez.ToString("C2"));
            Console.WriteLine("retiro: " + retiro.ToString("C2"));
            Console.WriteLine("casantia: " + casantia.ToString("C2"));
            Console.WriteLine("infonavid: " + infonavid.ToString("C2"));
            Console.WriteLine("total: " + total.ToString("C2"));
            }


        }

        public static void Presentación()
        {
            decimal SBC;
            decimal UMA;
            byte puesto;
            Console.WriteLine("¿Cual es su salario base?");
            SBC = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("¿Cual LA uma?");
            UMA = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Patron | Trabajador");
            puesto = Convert.ToByte(Console.ReadLine());
            Calcular(SBC,UMA,puesto);
        }
    }
}
