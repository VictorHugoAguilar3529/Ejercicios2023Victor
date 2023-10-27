using System;
using System.Collections.Generic;

namespace IntronetCore.Data.Models
{
    public partial class Curso
    {
        public Curso()
        {
            CursosInstructores = new HashSet<CursosInstructore>();
        }

        public short Id { get; set; }
        public short? IdCatCurso { get; set; }
        public string? FechaInicio { get; set; }
        public string? Fechatermino { get; set; }
        public bool? Activo { get; set; }

        public virtual CatCurso? IdCatCursoNavigation { get; set; }
        public virtual ICollection<CursosInstructore> CursosInstructores { get; set; }
    }
}
