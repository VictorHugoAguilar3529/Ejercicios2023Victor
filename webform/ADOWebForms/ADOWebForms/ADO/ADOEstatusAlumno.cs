using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using ADOWebForms.Entidades;

namespace ADOWebForms.ADO
{
    public class ADOEstatusAlumno : ICRUD
    {
        public ADOEstatusAlumno()
        {
        }

        public List<EstatusAlumno> Cargar()
        {
            string _cnnString = ConfigurationManager.ConnectionStrings["InstitutoConeccion"].ConnectionString;
            List<EstatusAlumno> _Estatus = new List<EstatusAlumno>();
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
                    new EstatusAlumno()
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
        public List<EstatusAlumno> ConsultarTodos()
        {
            string _cnnString = ConfigurationManager.ConnectionStrings["InstitutoConeccion"].ConnectionString;
            List<EstatusAlumno> _EstatusConTodos = new List<EstatusAlumno>();
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
                    new EstatusAlumno()
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

        public EstatusAlumno Consultar(int id)
        {
            EstatusAlumno estatus = new EstatusAlumno(); 
            string _cnnString = ConfigurationManager.ConnectionStrings["InstitutoConeccion"].ConnectionString;
            List<EstatusAlumno> _Estatus1 = new List<EstatusAlumno>();
            string query = $"select * from  EstatusAlumnos where id={id}";
            using (SqlConnection con = new SqlConnection(_cnnString))
            {
                SqlCommand comando = new SqlCommand(query, con);
                comando.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {

                    estatus.id = Convert.ToInt32(reader["ID"]);
                    estatus.clave = reader["clave"].ToString();
                    estatus.nombre = reader["nombre"].ToString();
                    
                }
                con.Close();
            }
            
            return estatus;
        }
        public void Agregar(EstatusAlumno estatusAlumno)
        {

            string _cnnString = ConfigurationManager.ConnectionStrings["InstitutoConeccion"].ConnectionString;


            string query = $"insert into EstatusAlumnos (clave, nombre ) values ('{estatusAlumno.clave}','{estatusAlumno.nombre}' )";

            using (SqlConnection con = new SqlConnection(_cnnString))
            {
                SqlCommand comando = new SqlCommand(query, con);
                comando.CommandType = CommandType.Text;
                con.Open();
                comando.ExecuteNonQuery();
                con.Close();
            }
        }
        public void Actualizar(EstatusAlumno estatusAlumno)
        {
            string _cnnString = ConfigurationManager.ConnectionStrings["InstitutoConeccion"].ConnectionString;
            string nombre = "Nuevo nombre";
            string clave = "Nueva clave";
            int idEstatusAlumnos = 1;

            string query = $"update EstatusAlumnos set clave='{estatusAlumno.clave}', nombre='{estatusAlumno.nombre}' where id={estatusAlumno.id}";

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