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
    public class DEstado
    {
        public List<Estado> ConsultarTodos()
        {
            string _cnnString = ConfigurationManager.ConnectionStrings["InstitutoConeccion"].ConnectionString;
            List<Estado> _Estado = new List<Estado>();
            string query = $"consultarEstados";
            using (SqlConnection con = new SqlConnection(_cnnString))
            {
                SqlCommand comando = new SqlCommand(query, con);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@id", -1));
                con.Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    _Estado.Add(
                    new Estado()
                    {
                        id = Convert.ToInt32(reader["ID"]),
                        nombre = reader["nombre"].ToString()
                    }
                    );
                }
                con.Close();
            }
            return _Estado;

        }
    }
}
