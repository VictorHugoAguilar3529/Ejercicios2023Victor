using System;
using System.Collections.Generic;

namespace IntronetCore.Data.Models
{
    public partial class CursosAlumno
    {
        public short Id { get; set; }
        public short IdCurso { get; set; }
        public short IdAlumno { get; set; }
        public DateTime FechaInscripcion { get; set; }
        public DateTime? FechaBaja { get; set; }
        public byte? Calificacion { get; set; }
    }
}
