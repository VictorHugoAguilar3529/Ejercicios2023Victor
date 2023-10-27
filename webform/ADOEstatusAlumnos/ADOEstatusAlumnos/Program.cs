using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ADOEstatusAlumnos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string opcion=null;
            ADOEstatus ADOEstatus = new ADOEstatus();
            List<Estatus> cont = new List<Estatus>();
            List<Estatus> con1 = new List<Estatus>();
            do
            {
                Console.WriteLine("Seleccione una opción");
                Console.WriteLine("1- Consultar todos");
                Console.WriteLine("2- Consultar solo uno");
                Console.WriteLine("3- Agregar");
                Console.WriteLine("4- Actualizar");
                Console.WriteLine("5- Eliminar");
                Console.WriteLine("F- Terminar");
                opcion = Console.ReadLine();

                switch(opcion)
                {
                    case "1":
                        Console.WriteLine("");
                        cont = ADOEstatus.ConsultarTodos();
                        Console.WriteLine($" Consulta todos ");

                        foreach (Estatus estatus2 in cont)
                        {
                            Console.WriteLine($"id={estatus2.id}, clave={estatus2.clave}, nombre={estatus2.nombre}");
                        }
                        break;
                    case "2":
                        Console.WriteLine("Ingrese el id a buscar");
                        int id =Convert.ToInt16( Console.ReadLine());
                        con1 = ADOEstatus.Consultar(id);
                        Console.WriteLine($" Consulta uno ");
                        foreach (Estatus estatus3 in con1)
                        {
                            Console.WriteLine($"id={estatus3.id}, clave={estatus3.clave}, nombre={estatus3.nombre}");
                        }
                        break;
                    case "3":
                        Estatus estatus = new Estatus();
                        Console.WriteLine("Inserte una clave");
                        estatus.clave = Console.ReadLine();
                        Console.WriteLine("Inserte un nombre");
                        estatus.nombre = Console.ReadLine();
                        
                        ADOEstatus.Agregar(estatus);
                        break;
                    case "4":
                        Estatus estatus1 = new Estatus();
                        Console.WriteLine("Ingrese el id");
                        estatus1.id =Convert.ToInt16(Console.ReadLine());
                        Console.WriteLine("escriba la nueva clave");
                        estatus1.clave= Console.ReadLine();
                        Console.WriteLine("Escriba el nuevo nombre");
                        estatus1.nombre= Console.ReadLine();
                        ADOEstatus.Actualizar(estatus1);
                        break;
                    case "5":
                        Console.WriteLine("Ingrese el id a eliminar");
                        int id3 = Convert.ToInt16( Console.ReadLine());
                        ADOEstatus.Eliminar(id3);
                        break;
                }
            }
            while (opcion != "F");
            Console.ReadKey();
        }
    }
}
