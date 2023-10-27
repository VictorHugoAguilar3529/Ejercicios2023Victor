using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ADOWinForms.ADO
{
    public class ADOEstatusAlumno: ICRUD
    {
        public ADOEstatusAlumno()
        {
        }

        public List<Estatus> Cargar()
        {
            string _cnnString = ConfigurationManager.ConnectionStrings["InstitutoConeccion"].ConnectionString;
            List<Estatus> _Estatus = new List<Estatus>();
            string query = $"select * from  EstatusAlumnos ";
            using (SqlConnection con = new SqlConnection(_cnnString))
            {
                SqlCommand comando = new SqlCommand(query, con);
                comando.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    _Estatus.Add(
                    new Estatus()
                    {
                        id = Convert.ToInt32(reader["ID"]),
                        clave = reader["clave"].ToString(),
                        nombre = reader["nombre"].ToString(),
                    }
                    );
                }
                con.Close();
            }

            return _Estatus;
        }
        public List<Estatus> ConsultarTodos()
        {
            string _cnnString = ConfigurationManager.ConnectionStrings["InstitutoConeccion"].ConnectionString;
            List<Estatus> _EstatusConTodos = new List<Estatus>();
            string query = $"select * from  EstatusAlumnos";
            using (SqlConnection con = new SqlConnection(_cnnString))
            {
                SqlCommand comando = new SqlCommand(query, con);
                comando.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    _EstatusConTodos.Add(
                    new Estatus()
                    {
                        id = Convert.ToInt32(reader["ID"]),
                        clave = reader["clave"].ToString(),
                        nombre = reader["nombre"].ToString(),
                    }
                    );
                }
                con.Close();
            }
            return _EstatusConTodos;
        }

        public List<Estatus> Consultar(int id)
        {
            string _cnnString = ConfigurationManager.ConnectionStrings["InstitutoConeccion"].ConnectionString;
            List<Estatus> _Estatus1 = new List<Estatus>();
            string query = $"select * from  EstatusAlumnos where id={id}";
            using (SqlConnection con = new SqlConnection(_cnnString))
            {
                SqlCommand comando = new SqlCommand(query, con);
                comando.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    _Estatus1.Add(
                    new Estatus()
                    {
                        id = Convert.ToInt32(reader["ID"]),
                        clave = reader["clave"].ToString(),
                        nombre = reader["nombre"].ToString(),
                    }
                    );
                }
                con.Close();
            }
            return _Estatus1;
        }
        public void Agregar(Estatus estatus)
        {

            string _cnnString = ConfigurationManager.ConnectionStrings["InstitutoConeccion"].ConnectionString;


            string query = $"insert into EstatusAlumnos (clave, nombre ) values ('{estatus.clave}','{estatus.nombre}' )";

            using (SqlConnection con = new SqlConnection(_cnnString))
            {
                SqlCommand comando = new SqlCommand(query, con);
                comando.CommandType = CommandType.Text;
                con.Open();
                comando.ExecuteNonQuery();
                con.Close();
            }
        }
        public void Actualizar(Estatus estatus)
        {
            string _cnnString = ConfigurationManager.ConnectionStrings["InstitutoConeccion"].ConnectionString;
            string nombre = "Nuevo nombre";
            string clave = "Nueva clave";
            int idEstatusAlumnos = 1;

            string query = $"update EstatusAlumnos set clave='{estatus.clave}', nombre='{estatus.nombre}' where id={estatus.id}";

            using (SqlConnection con = new SqlConnection(_cnnString))
            {
                SqlCommand comando = new SqlCommand(query, con);
                comando.CommandType = CommandType.Text;
                con.Open();
                comando.ExecuteNonQuery();
                con.Close();
            }
        }
        public void Eliminar(int id)
        {
            string _cnnString = ConfigurationManager.ConnectionStrings["InstitutoConeccion"].ConnectionString;
            string query = $"delete EstatusAlumnos where id={id}";

            using (SqlConnection con = new SqlConnection(_cnnString))
            {
                SqlCommand comando = new SqlCommand(query, con);
                comando.CommandType = CommandType.Text;
                con.Open();
                comando.ExecuteNonQuery();
                con.Close();
            }

        }

    }
}
