using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;

namespace Negocio
{
    public class NEstado
    {
        DEstado dEstado = new DEstado();

        public List<Estado> ConsultarTodos()
        {
            List<Estado> estados = new List<Estado>();
            estados = dEstado.ConsultarTodos();
            return estados;
        }
    }
}
