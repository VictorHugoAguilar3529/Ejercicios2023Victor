using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOEstatusAlumnos
{
    public interface ICRUDEstatus
    {
        List<Estatus> ConsultarTodos();
        List<Estatus> Consultar(int id);
        void Agregar(Estatus estatus);
        void Actualizar(Estatus estatus);
        void Eliminar(int id);

    }
}
