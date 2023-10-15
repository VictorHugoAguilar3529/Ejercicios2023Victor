using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDEstatus
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            String opcion;
            do
            {
                Console.WriteLine("seleccione una opción");
                Console.WriteLine("1.- Consultar todos ");
                Console.WriteLine("2.- consultar uno");
                Console.WriteLine("3.- Agregar");
                Console.WriteLine("4.- Actualizar");
                Console.WriteLine("5.- Eliminar");
                Console.WriteLine("F.- terminar");
                opcion = Console.ReadLine();
                Console.Clear();

                switch (opcion)
                {
                    case "1":
                        Console.WriteLine("Consultas todos");
                        EstatusAlumnos estatusAlumnos = new EstatusAlumnos();
                        Lista.ConsultarTodos();
                        break;
                    case "2":
                        EstatusAlumnos estatusAlumno5 = new EstatusAlumnos();
                        Console.WriteLine("Consultar 1");
                        Console.WriteLine("Cual  va buscar ");
                        int id =Convert.ToUInt16( Console.ReadLine());
                        estatusAlumno5 = Lista.ConsultaUno(id);
                        Console.WriteLine($"id={estatusAlumno5.id}, clave={estatusAlumno5.clave}, nombre={estatusAlumno5.nombre}");
                        break;
                    case "3":
                        EstatusAlumnos estatusAlumnos3 = new EstatusAlumnos();
                        Console.WriteLine("Agregar");
                        Console.Write("Escriba eñ id a agregar");
                        estatusAlumnos3.id =Convert.ToUInt16( Console.ReadLine());
                        Console.WriteLine("Escriba la clave a agregar");
                        estatusAlumnos3.clave=Console.ReadLine();
                        Console.Write("Escriba el estatus a agregar");
                        estatusAlumnos3.nombre = Console.ReadLine();
                        Lista.Agregar(estatusAlumnos3);

                        break;
                    case "4":
                        EstatusAlumnos estatusAlumnos4 = new EstatusAlumnos();
                        Console.WriteLine("Actualizar");
                        Console.WriteLine("Escriba el id del resgiatro que quiere actualizar en la lista");
                        estatusAlumnos4.id = Convert.ToUInt16( Console.ReadLine());
                        Console.WriteLine("Escriba la nueva clave del registro");
                        estatusAlumnos4.clave=Console.ReadLine();
                        Console.WriteLine("Escriba el nuevo estatus del reguistro");
                        estatusAlumnos4.nombre = Console.ReadLine();
                        Lista.Actualizar(estatusAlumnos4);

                        break;
                    case "5":
                        EstatusAlumnos estatusAlumnos5 = new EstatusAlumnos();
                        Console.WriteLine("Usted seleccionó la opción 5 ");
                        Console.WriteLine("Escriba el id del registro que quiere eliminar");
                        estatusAlumnos5.id = Convert.ToUInt16( Console.ReadLine());
                        Lista.Eliminar(estatusAlumnos5);

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
