using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOWinForms.ADO
{
    public interface ICRUD
    {
         List<Estatus> ConsultarTodos();
         List<Estatus> Consultar(int id);
         void Agregar(Estatus estatus);
         void Actualizar(Estatus estatus);
         void Eliminar(int id);
    }
}
