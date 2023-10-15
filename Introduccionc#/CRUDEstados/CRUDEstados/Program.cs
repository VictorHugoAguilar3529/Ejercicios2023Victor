using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CRUDEstados
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Dictionary<int, Estado> _Estados = new Dictionary<int, Estado>();


            _Estados.Add(1,new Estado(1, "Queretaro"));
            _Estados.Add(2, new Estado(1, "Puebla"));
            _Estados.Add(3, new Estado(1, "CDMX")); ;


            string opcion = null;
            string buscar = null;
            do
            {
                Console.WriteLine("seleccione una opción");
                Console.WriteLine("1.- Consultar todos ");
                Console.WriteLine("2.- consultar uno");
                Console.WriteLine("3.- Agregar");
                Console.WriteLine("4.- Actualizar");
                Console.WriteLine("5.- Eliminar");
                Console.WriteLine("F.- terminar");
                opcion= Console.ReadLine();
                Console.Clear();

                switch (opcion)
                {
                    case "1":
                        Console.WriteLine("Consultas todos");
                       _Estados = Diccionario.ConcultarTodos();
                        foreach (KeyValuePair<int, Estado> kvp in _Estados)
                        {
                            Console.WriteLine("key = {0}, value = {1}", kvp.Key, kvp.Value.name);
                        }
                        break;
                    case "2":
                        Console.WriteLine("Consultar 1");
                        Console.WriteLine("cual va a buscar");
                        int busca = Convert.ToInt16( Console.ReadLine());
                        Estado estado = Diccionario.ConcultarSoloUno(busca);

                        Console.WriteLine("key = {0}, value = {1}", estado.id, estado.name);
                        

                        break;
                    case "3":
                        string p1;
                        string p2;
                        estado = new Estado();
                        Console.WriteLine("Agregar");
                        Console.WriteLine(" escriba el id a agregar");
                        estado.id=Convert.ToInt16( Console.ReadLine());
                        Console.WriteLine("escriba el nombre");
                        estado.name= Console.ReadLine();                      
                        Diccionario.Agregar(estado);
                        
                        break;
                    case "4":
                        string p3;
                        string p4;
                        estado = new Estado();
                        Console.WriteLine("Actualizar");
                        Console.WriteLine("escriba el id a actualizar");
                        estado.id =Convert.ToInt16( Console.ReadLine());
                        Console.WriteLine("escriba el nuevo nombre");
                        estado.name = Console.ReadLine();
                        Diccionario.Actualizar(estado);                    
                        break;
                    case "5":
                        
                        Console.WriteLine("Usted seleccionó la opción 5 ");
                        Console.WriteLine("key eliminar");
                        int id = Convert.ToInt32( Console.ReadLine());
                        Diccionario.Eliminar(id);

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
