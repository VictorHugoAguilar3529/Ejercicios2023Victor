using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperacionesAritméticas
{
    internal class Calculadora
    {
        public static decimal Suma(decimal num1, decimal num2)
        {
            decimal ressultado = num1 + num2;
            Console.WriteLine("Suma = "+ressultado);
            return  ressultado;
        }
        public static decimal restar(decimal num1, decimal num2)
        {
            decimal ressultado = num1 - num2;
            Console.WriteLine("Resta = "+ressultado);
            return ressultado;
        }
        public static decimal Multiplicar(decimal num1, decimal num2)
        {
            decimal ressultado = num1 * num2;
            Console.WriteLine("Multiplicación = "+ressultado);
            return ressultado;
        }
        public static decimal Division(decimal num1, decimal num2)
        {
            decimal ressultado = num1 / num2;
            Console.WriteLine("División = "+ressultado);
            return ressultado;
        }
        public static decimal Modulo(decimal num1, decimal num2)       
        {
            decimal ressultado = num1 % num2;
            Console.WriteLine("Módulo = "+ressultado);
            return ressultado;
        }
        public static void Operecion(OperacionAritmetica operacion)
        {
            
            switch (operacion.Tip)
            {
                
                case TipoOperacion.suma:
                    Console.WriteLine("suma ");
                    Suma(operacion.num1, operacion.num2);

                    break;
                case TipoOperacion.resta:
                    Console.WriteLine("Resta");
                    restar(operacion.num1, operacion.num2);
                    break;
                case TipoOperacion.multiplicacion:
                    Console.WriteLine("Multiplicacion");
                    Multiplicar(operacion.num1, operacion.num2);
                    break;
                case TipoOperacion.division:
                    Console.WriteLine("division");
                    Division(operacion.num1, operacion.num2);
                    break;
                case TipoOperacion.modulo:
                    Console.WriteLine("Case 2");
                    Modulo(operacion.num1, operacion.num2);
                    break;
                default:
                    Console.WriteLine("Simultaneo");
                    Simultaneas(operacion.num1, operacion.num2);
                    break;
            }
        }
        public static void Simultaneas(decimal num1, decimal num2)
        {
            Calculadora Calculadora = new Calculadora();

            Console.WriteLine("Suma = " + (num1 + num2));
            Console.WriteLine("Resta = "+(num1 -num2));
            Console.WriteLine("Multiplicacioó = " + (num1 * num2));
            Console.WriteLine("División = " + (num1 / num2));
            Console.WriteLine("Módulo = " + (num1 * num2));
        }


        public static void Presentacionn()
        {
            decimal nume1;
            decimal nume2;
            byte oper;
            OperacionAritmetica operacion = new OperacionAritmetica();


            Console.WriteLine("¿cúal es la operación a realizar");
            Console.WriteLine("0-Suma");
            Console.WriteLine("1-Resta");
            Console.WriteLine("2-Multiplicación");
            Console.WriteLine("3-División");
            Console.WriteLine("4-Módulo");
            Console.WriteLine("5-Simultaneas");
            oper = Convert.ToByte(Console.ReadLine());
           
            operacion.Tip = (TipoOperacion)oper;

            Console.WriteLine("¿cúal es tu número 1?");
            operacion.num1 = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("¿cúal es tu número 2?");
            operacion.num2 = Convert.ToDecimal(Console.ReadLine());


            if (oper == 6)
            {
                Calculadora.Simultaneas(operacion.num1, operacion.num2);
            }
            else
            {
                Calculadora.Operecion(operacion);
            }

        }
    }
}
