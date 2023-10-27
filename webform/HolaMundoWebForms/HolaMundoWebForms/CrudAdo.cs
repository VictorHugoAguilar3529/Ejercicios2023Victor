using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HolaMundoWebForms
{
    public class CrudAdo
    {
        List<Estado> estados = new List<Estado>
        {
            new Estado {id=1, nombre="Querétaro"},
            new Estado {id=2, nombre="Puebla"},
            new Estado {id=3, nombre="CDMX"},
        };
        public List<Estado> Consultar() 
        { 
            return estados; 
        }

    }
}