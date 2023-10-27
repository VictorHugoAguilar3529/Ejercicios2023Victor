using System;
using System.Collections.Generic;

namespace IntronetCore.Data.Models
{
    public partial class VAlumno
    {
        public short Id { get; set; }
        public string? Nombre { get; set; }
        public string? ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }
        public string? Correo { get; set; }
        public string? Telefono { get; set; }
        public string? Estado { get; set; }
        public string? Estatus { get; set; }
    }
}
