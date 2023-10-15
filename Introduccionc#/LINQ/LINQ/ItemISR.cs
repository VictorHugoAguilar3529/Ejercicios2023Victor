using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class ItemISR
    {
        public ItemISR() { }
        public ItemISR(decimal limINf, decimal limSup, decimal cuotaFija, decimal porExed, decimal subsidio)
        {
            this.limINf = limINf;
            this.limSup = limSup;
            this.cuotaFija = cuotaFija;
            this.porExed = porExed;
            this.subsidio = subsidio;
        }

        public decimal limINf {  get; set; }
        public decimal limSup { get; set;}
        public decimal cuotaFija { get; set; }
        public decimal porExed { get; set;}
        public decimal subsidio { get; set;}
    }
}
