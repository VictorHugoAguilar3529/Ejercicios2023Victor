using System;
using System.Collections.Generic;

namespace IntronetCore.Data.Models
{
    public partial class Transaccione
    {
        public int? Id { get; set; }
        public int IdOrigen { get; set; }
        public int? IdDestino { get; set; }
        public decimal? Monto { get; set; }
    }
}
