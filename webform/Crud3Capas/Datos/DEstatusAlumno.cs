using Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
namespace Datos
{
    public class DEstatusAlumno
    {
        public List<EstatusAlumno> ConsultarTodos()
        {
            string _cnnString = ConfigurationManager.ConnectionStrings["InstitutoConeccion"].ConnectionString;
            List<EstatusAlumno> _EstatusAlumno = new List<EstatusAlumno>();
            string query = $"consultarEstatus";
            using (SqlConnection con = new SqlConnection(_cnnString))
            {
                SqlCommand comando = new SqlCommand(query, con);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@id", -1));
                con.Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    _EstatusAlumno.Add(
                    new EstatusAlumno()
                    {
                        id = Convert.ToInt32(reader["id"]),
                        clave = reader["clave"].ToString(),
                        Nombre = reader["Nombre"].ToString()
                    }
                    );
                }
                con.Close();
            }
            return _EstatusAlumno;

        }
    }
}
