using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDEstados
{
    public class Estado
    {
        public Estado()
        {
        }

        public Estado(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public int id { get; set; }
        public string name { get; set; }
    }
}
