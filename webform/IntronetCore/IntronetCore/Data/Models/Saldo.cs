using System;
using System.Collections.Generic;

namespace IntronetCore.Data.Models
{
    public partial class Saldo
    {
        public int? Id { get; set; }
        public string Nombre { get; set; } = null!;
        public decimal? Saldo1 { get; set; }
    }
}
