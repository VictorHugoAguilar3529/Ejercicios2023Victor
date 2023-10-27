using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Web;

namespace WCFAlumnos2
{
    [DataContract]
    public class AportacionesIMSS
    {
        [DataMember]
        public decimal EnfermedadMaternidad { get; set; }

        [DataMember]
        public decimal InvalidezVida { get; set; }

        [DataMember]
        public decimal Retiro { get; set; }

        [DataMember]
        public decimal Cesantía { get; set; }

        [DataMember]
        public decimal Infonavit { get; set; }
    }
}