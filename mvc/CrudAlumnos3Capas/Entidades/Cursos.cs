//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Entidades
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cursos
    {
        public short id { get; set; }
        public Nullable<short> idCatCurso { get; set; }
        public string fechaInicio { get; set; }
        public string fechatermino { get; set; }
        public Nullable<bool> activo { get; set; }
    
        public virtual CatCursos CatCursos { get; set; }
    }
}