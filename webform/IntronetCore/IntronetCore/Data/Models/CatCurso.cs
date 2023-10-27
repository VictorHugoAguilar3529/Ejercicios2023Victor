using System;
using System.Collections.Generic;

namespace IntronetCore.Data.Models
{
    public partial class CatCurso
    {
        public CatCurso()
        {
            Cursos = new HashSet<Curso>();
        }

        public short Id { get; set; }
        public string? Clave { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public byte? Horas { get; set; }
        public short? IdPreRequisito { get; set; }
        public bool? Activo { get; set; }

        public virtual ICollection<Curso> Cursos { get; set; }
    }
}
