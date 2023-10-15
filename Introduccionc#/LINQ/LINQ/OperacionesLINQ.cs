using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class OperacionesLINQ
    {
            static List<Alumno> _Alumno = new List<Alumno>();
            static List<Estado> _Estado = new List<Estado>();
            static List<Estatus> _Estatus = new List<Estatus>();
            static List<ItemISR> _ItemISR = new List<ItemISR>();
            public static void CargarLists()
        {

            
            string leerjson;
            StreamReader leerltsAlu = new StreamReader("C:\\Users\\aguil\\source\\bootcamp\\c#\\LINQ\\Alumnos.json");
            leerjson = leerltsAlu.ReadToEnd();
            _Alumno = JsonConvert.DeserializeObject<List<Alumno>>(leerjson);
            

            
            StreamReader leerltsEstados = new StreamReader("C:\\Users\\aguil\\source\\bootcamp\\c#\\LINQ\\Estados.json");
            leerjson = leerltsEstados.ReadToEnd();
            _Estado = JsonConvert.DeserializeObject<List<Estado>>(leerjson);

            
            StreamReader leerltsEstatus = new StreamReader("C:\\Users\\aguil\\source\\bootcamp\\c#\\LINQ\\Estatus.json");
            leerjson = leerltsEstatus.ReadToEnd();
            _Estatus = JsonConvert.DeserializeObject<List<Estatus>>(leerjson);


            //crear lista TablaISr
            ItemISR leeriten = new ItemISR();            
            StreamReader leerISR = new StreamReader("C:\\Users\\aguil\\source\\bootcamp\\c#\\LINQ\\TablaISR.csv");
            string datoIndividual;
            decimal[,] arreglisr = new decimal[21, 6];

            for (int i = 0; (leerjson = leerISR.ReadLine()) != null; i++)
            {
                string[] fila = leerjson.Split(',');
                leeriten = new ItemISR();
                leeriten.limINf = Convert.ToDecimal(fila[1]);
                leeriten.limSup = Convert.ToDecimal(fila[2]);
                leeriten.cuotaFija = Convert.ToDecimal(fila[3]);
                leeriten.porExed = Convert.ToDecimal(fila[4]);
                leeriten.subsidio = Convert.ToDecimal(fila[5]);
                _ItemISR.Add(leeriten);
            }
        }


        public static void Consultas()
        {
            Console.WriteLine("7.2.1.4");
            var ltsAlum = _Alumno.FindAll(x => x.calificacion >= 6);
            Console.WriteLine("Alumnos aprobados");
            foreach (var alumno in ltsAlum) 
            {
                Console.WriteLine($" alumno = {alumno.id} {alumno.nombre} {alumno.calificacion}");
            }


            Console.WriteLine("7.2.1.5");
            decimal suma = 0;
            decimal promedio;
            int contador = 1;
            var prom = _Alumno.FindAll(x =>x.id > 0);
            foreach (Alumno alumno in _Alumno)
            {
                suma = suma + alumno.calificacion;
                contador = contador + 1;
            }
            Console.WriteLine("el promedio de las calificaciones es: "+(promedio=suma/contador));



            Console.WriteLine("7.2.1.6");
            var sumcal  = _Alumno.All(x => x.calificacion < 10);
            if(sumcal == true)
            {
                foreach (Alumno alumno in _Alumno)
                {
                    alumno.calificacion = alumno.calificacion +1;
                    Console.WriteLine($" Calificacion del alumno actualizada = {alumno.id} {alumno.nombre} {alumno.calificacion}");
                }
            }
            

            var sumcal2 = _Alumno.All(x => x.calificacion >= 6 && x.calificacion <= 7);
            if(sumcal2 == true)
            {
                foreach (Alumno alumno in _Alumno)
                {
                    alumno.calificacion = alumno.calificacion + 2;
                    Console.WriteLine($" Calificacion del alumno actualizada = {alumno.id} {alumno.nombre} {alumno.calificacion}");
                }
            }
            

            Console.WriteLine("7.2.1.7");
            var innerAlumnoEstado = from Alumno in _Alumno                    
                       join Estado in _Estado  on Alumno.idEstado equals Estado.id
                       where Alumno.idEstatus == 3
                       select new { Alumno.id, Alumno.calificacion, Estado.nombre };
            Console.WriteLine("alumnos en estatus 3");
            foreach (var alumno in innerAlumnoEstado)
            {
                
                Console.WriteLine($"  {alumno.id} {alumno.calificacion} {alumno.nombre}");
            }


            Console.WriteLine("7.2.1.8");
            var alu2 = from Alumno in _Alumno
                       join Estatus in _Estatus on Alumno.idEstatus equals Estatus.id
                       where Alumno.idEstatus == 2
                       orderby Alumno.nombre
                       select new { Alumno.id, Alumno.calificacion, Estatus.nombre };
            Console.WriteLine("alumnos en estatus 2");
            foreach (var alumno in alu2)
            {

                Console.WriteLine($"  {alumno.id} {alumno.calificacion} {alumno.nombre}");
            }
            Console.WriteLine("7.2.1.9");
            var alue2 = from Alumno in _Alumno
                       join Estatus in _Estatus on Alumno.idEstatus equals Estatus.id
                       where Alumno.idEstatus > 2
                       orderby Estatus.nombre
                       select new { Alumno.id, Alumno.calificacion, Estatus.nombre };
            foreach (var alumno in alue2)
            {

                Console.WriteLine($"  {alumno.id} {alumno.nombre} {alumno.nombre}");
            }


            Console.WriteLine("7.2.1.10");
            decimal quincenal = 18000/2;
            decimal li = 0;
            var isr = from ItemISR in _ItemISR
                      where quincenal >= ItemISR.limINf   && quincenal <= ItemISR.limSup 
                      select new { ItemISR.limINf, ItemISR.limSup, ItemISR.cuotaFija, ItemISR.porExed, ItemISR.subsidio };
          
            foreach (var ItemISR in isr)
            {
               
            decimal res1 = ((quincenal - ItemISR.limINf) * ItemISR.porExed) / 100;
             decimal   ISR = res1 + ItemISR.cuotaFija - ItemISR.subsidio;
                Console.WriteLine("ISR es "+ISR);
            }



        }
    }
}
