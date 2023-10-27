using ADOWebForms.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ADOWebForms.ADO
{
    public interface ICRUD
    {

        List<EstatusAlumno> ConsultarTodos();
        EstatusAlumno Consultar(int id);
        void Agregar(EstatusAlumno estatusAlumno);
        void Actualizar(EstatusAlumno estatusAlumno);
        void Eliminar(int id);

    }
}
