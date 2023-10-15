using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolaMundo
{
    internal class Saludo
    {
        //definicion de metodo no estático
        public string Saludar(string nom)
        {
            return "Bienvenido " + nom;
        }
        //definicion de metodo estático
        public static string SaludarEstatico(string nom)
        {
            return "Bienvenido " + nom;
        }
    }
}
