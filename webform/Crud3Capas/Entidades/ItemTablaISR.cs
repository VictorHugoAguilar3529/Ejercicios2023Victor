using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ItemTablaISR
    {
        public ItemTablaISR()
        {
        }

        public ItemTablaISR(int id, decimal LimInf, decimal LimSup, decimal CuotaFija, decimal ExedLimInf, decimal Subsidio, decimal isr)
        {
            this.LimInf = LimInf;
            this.LimSup = LimSup;
            this.CuotaFija = CuotaFija;
            this.ExedLimInf = ExedLimInf;
            this.Subsidio = Subsidio;
            this.isr = isr;
        }

        public decimal LimInf {  get; set; }
        public decimal LimSup { get; set; }
        public decimal CuotaFija { get; set; }
        public decimal ExedLimInf { get; set; }
        public decimal Subsidio { get; set; }
        public decimal isr { get; set; }
    }
}
