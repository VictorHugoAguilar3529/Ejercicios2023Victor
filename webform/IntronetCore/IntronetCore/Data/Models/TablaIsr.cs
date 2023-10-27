using System;
using System.Collections.Generic;

namespace IntronetCore.Data.Models
{
    public partial class TablaIsr
    {
        public short Id { get; set; }
        public decimal? LimInf { get; set; }
        public decimal? LimSup { get; set; }
        public decimal? CuotaFija { get; set; }
        public decimal? ExedLimInf { get; set; }
        public decimal? Subsidio { get; set; }
    }
}
