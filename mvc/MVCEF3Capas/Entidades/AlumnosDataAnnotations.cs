using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [MetadataType(typeof(AlumnosDataAnnotations))]
    public partial class Alumnos
    {
    }
    public class AlumnosDataAnnotations
    {
        //============================================================
        [Key]
        public short id { get; set; }

        //============================================================
        [Required(ErrorMessage ="El {0} es obligatorio")]
        public string nombre { get; set; }

        //============================================================
        [StringLength(60, MinimumLength = 3, ErrorMessage = "El {0} debe tener mínimo {2} y máximo {1} caracteres")]
        [Required(ErrorMessage = "El {0} es obligatorio")]
        public string primerApellido { get; set; }

        //============================================================
        [StringLength(60, MinimumLength = 3, ErrorMessage = "El {0} debe tener mínimo {2} y máximo {1} caracteres")]
        public string segundoApellido { get; set; }

        //============================================================
        [Required(ErrorMessage = "El {0} es obligatorio")]
        [RegularExpression("[a-zA-Z0-9_]+([.][a-zA-Z0-9_]+)*@[a-zA-Z0-9_]+([.][a-zA-Z0-9_]+)*[.][a-zA-Z]{2,5}", ErrorMessage = "{0} Formato incorrecto")]
        public string correo { get; set; }

        //============================================================
        [Phone(ErrorMessage = "{0} Formato incorrecto")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "{0} Formato incorrecto")]
        public string telefono { get; set; }

        //============================================================
        [Required(ErrorMessage = "El {0} es obligatorio")]
        [DataType(DataType.Date, ErrorMessage = "Teclea una fecha")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [RangeDate("01/01/1990", "31/12/2000", ErrorMessage = "La {0} debe estar entre {1} y {2}")]
        public Nullable<System.DateTime> fechaNacimiento { get; set; }

        //============================================================
        [Required(ErrorMessage = "El {0} es obligatorio")]
        [RegularExpression("^([A-Z][AEIOUX][A-Z]{2}\\d{2}(?:0[1-9]|1[0-2])(?:0[1-9]|[12]\\d|3[01])[HM](?:AS|B[CS]|C[CLMSH]|D[FG]|G[TR]|HG|JC|M[CNS]|N[ETL]|OC|PL|Q[TR]|S[PLR]|T[CSL]|VZ|YN|ZS)[B-DF-HJ-NP-TV-Z]{3}[A-Z\\d])(\\d)$", ErrorMessage = "El {0} no tiene el formato")]
        public string curp { get; set; }

        //============================================================

        [DataType(DataType.Currency, ErrorMessage = "No es una moneda")]
        [Range(10000, 40000,ErrorMessage = "El sueldo deb estar entre $10,000 y 40,000")]
        public Nullable<decimal> sueldo { get; set; }

        //============================================================
        [Range(1, 32, ErrorMessage = "El valor debe estar entre el {1} y el {2}")]
        public Nullable<short> idEstadoOrigen { get; set; }

        //============================================================
        [Range(1, 8, ErrorMessage = "El valor debe estar entre el {1} y el {2}")]
        public Nullable<short> idEstatus { get; set; }
    }
}
