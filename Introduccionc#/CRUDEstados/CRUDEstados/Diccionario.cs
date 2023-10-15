using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDEstados
{
    internal class Diccionario
    {
        static Dictionary<int, Estado> _Estados = new Dictionary<int, Estado>();

        public static Dictionary<int, Estado> ConcultarTodos()
        {
            return _Estados;
        }
        public static Estado ConcultarSoloUno( int id)
        {
            if (!_Estados.ContainsKey(id))
            {
                Console.WriteLine("Componente no encontrado");
            }
            return _Estados[id];
        }
        public static void Agregar(Estado estado)
        {
            _Estados.Add(estado.id,  estado);
        }
        public static void Actualizar(Estado estado)
        {
            if (_Estados.ContainsKey(estado.id))
            {
                _Estados[estado.id] = (estado);
                
            }
            
        }
        public static void Eliminar(int id)
        {
            _Estados.Remove(id);
        }
    }
}
