using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace System.ComponentModel.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class RangeDateAttribute : ValidationAttribute
    {
        public RangeDateAttribute(string fechaMinima, string fechaMaxima)
        {
            this.fechaMinima = DateTime.Parse(fechaMinima);
            this.fechaMaxima = DateTime.Parse(fechaMaxima);
        }
        public DateTime fechaMaxima { get; }
        public DateTime fechaMinima { get; }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(ErrorMessage,name, fechaMinima.ToString("dd/MM/yyyy"), fechaMaxima.ToString("dd/MM/yyyy"));
        }

        public override bool IsValid(object value)
        {
            DateTime fechaIngresada = (DateTime)value;
            return fechaIngresada >= fechaMinima && fechaIngresada <= fechaMaxima ? true: false;
        }
    }
}
