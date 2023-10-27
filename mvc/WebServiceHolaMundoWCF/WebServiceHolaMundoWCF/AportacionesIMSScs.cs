using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Web;

namespace WebServiceHolaMundoWCF
{
    [DataContract]
    public class AportacionesIMSScs
    {
        [DataMember]
        public decimal LimInf { get; set; }

        [DataMember]
        public decimal LimSup { get; set; }

        [DataMember]
        public decimal CuotaFija { get; set; }

        [DataMember]
        public decimal ExedLimInf { get; set; }

        [DataMember]
        public decimal Subsidio { get; set; }

        [DataMember]
        public decimal isr { get; set; }
    }
}