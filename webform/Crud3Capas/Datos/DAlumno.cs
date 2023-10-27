using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Entidades;

namespace Datos
{
    public class DAlumno
    {
        string _cnnString = ConfigurationManager.ConnectionStrings["InstitutoConeccion"].ConnectionString;
        public List<Alumno> Cargar()
        {
            List<Alumno> _dAlumnos = new List<Alumno>();


            return _dAlumnos;
        }
        public List<Alumno> ConsultarTodos()
        {
            
            List<Alumno> _Alumnos = new List<Alumno>();
            string query = $"consultarAlumnos";
            using (SqlConnection con = new SqlConnection(_cnnString))
            {
                SqlCommand comando = new SqlCommand(query, con);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@id",-1));
                con.Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    _Alumnos.Add(new Alumno(
                            Convert.ToInt16(reader["id"]),
                            reader["nombre"].ToString(),
                            reader["primerApellido"].ToString(),
                            reader["segundoApellido"].ToString(),
                            reader["correo"].ToString(),
                            reader["telefono"].ToString(),
                            Convert.ToDateTime(reader["fechaNacimiento"]),
                            reader["curp"].ToString(),
                            reader["sueldo"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["sueldo"]),
                            Convert.ToInt16(reader["idEstadoOrigen"]),
                            Convert.ToInt16(reader["idEstatus"])));
                }
                con.Close();
            }
            return _Alumnos;

        }

        public Alumno Consultar(int id)
        {      
            Alumno alumno = new Alumno();
            string query = $"consultarAlumno";
            using (SqlConnection con = new SqlConnection(_cnnString))
            {
                SqlCommand comando = new SqlCommand(query, con);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@id",id));
                con.Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {



                    alumno.id = Convert.ToInt32(reader["id"]);
                    alumno.nombre = reader["nombre"].ToString();
                    alumno.primerApellido = reader["primerApellido"].ToString();
                    alumno.segundoApellido = reader["segundoApellido"].ToString();
                    alumno.correo = reader["correo"].ToString();
                    alumno.telefono = reader["telefono"].ToString();
                    alumno.fechaNacimiento = Convert.ToDateTime(reader["fechaNacimiento"]);
                    alumno.curp = reader["curp"].ToString();
                    alumno.sueldo = Convert.ToDecimal(reader["sueldo"]);
                    alumno.idEstadoOrigen = Convert.ToInt32(reader["idEstadoOrigen"]);
                    alumno.idEstatus = Convert.ToInt32(reader["idEstatus"]);
                }
                con.Close();
            }
            return alumno;

        }
        public void Agregar(Alumno alumno)
        {

            string query = $"agregarAlumnos";

            using (SqlConnection con = new SqlConnection(_cnnString))
            {
                SqlCommand comando = new SqlCommand(query, con);
                comando.CommandType = CommandType.StoredProcedure;
                
                comando.Parameters.Add(new SqlParameter("@nombre", alumno.nombre));
                comando.Parameters.Add(new SqlParameter("@primerApellido", alumno.primerApellido));
                comando.Parameters.Add(new SqlParameter("@segundoApellido", alumno.segundoApellido));
                comando.Parameters.Add(new SqlParameter("@correo", alumno.correo));
                comando.Parameters.Add(new SqlParameter("@telefono", alumno.telefono));
                comando.Parameters.Add(new SqlParameter("@fechaNacimiento", alumno.fechaNacimiento));
                comando.Parameters.Add(new SqlParameter("@curp", alumno.curp));
                comando.Parameters.Add(new SqlParameter("@sueldo", alumno.sueldo));
                comando.Parameters.Add(new SqlParameter("@idEstadoOrigen", alumno.idEstadoOrigen));
                comando.Parameters.Add(new SqlParameter("@idEstatus", alumno.idEstatus));
                comando.Parameters.Add(new SqlParameter("@IdAlumnoCreado", alumno.id));

                con.Open();
                comando.ExecuteNonQuery();
                con.Close();
            }
        }
        public void Actualizar(Alumno alumno)
        {
            string query = $"actualizarAlumnos";

            using (SqlConnection con = new SqlConnection(_cnnString))
            {
                SqlCommand comando = new SqlCommand(query, con);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@idAlumno", alumno.id));
                comando.Parameters.Add(new SqlParameter("@nombre", alumno.nombre));
                comando.Parameters.Add(new SqlParameter("@primerApellido", alumno.primerApellido));
                comando.Parameters.Add(new SqlParameter("@segundoApellido", alumno.segundoApellido));
                comando.Parameters.Add(new SqlParameter("@correo", alumno.correo));
                comando.Parameters.Add(new SqlParameter("@telefono", alumno.telefono));
                comando.Parameters.Add(new SqlParameter("@fechaNacimiento", alumno.fechaNacimiento));
                comando.Parameters.Add(new SqlParameter("@curp", alumno.curp));
                comando.Parameters.Add(new SqlParameter("@sueldo", alumno.sueldo));
                comando.Parameters.Add(new SqlParameter("@idEstadoOrigen", alumno.idEstadoOrigen));
                comando.Parameters.Add(new SqlParameter("@idEstatus", alumno.idEstatus));

                con.Open();
                comando.ExecuteNonQuery();
                con.Close();
            }
        }
        public void Eliminar(int id)
        {
            string query = $"eliminarAlumnos";

            using (SqlConnection con = new SqlConnection(_cnnString))
            {
                SqlCommand comando = new SqlCommand(query, con);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@idAlumno", id));
                con.Open();
                comando.ExecuteNonQuery();
                con.Close();
            }

        }
        public List<ItemTablaISR> ConsultarTablaISR()
        {
            List<ItemTablaISR> itemTablaISR = new List<ItemTablaISR>();
            string query = $"consultarTablaISR";
            using (SqlConnection con = new SqlConnection(_cnnString))
            {
                SqlCommand comando = new SqlCommand(query, con);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@id", -1));
                con.Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    itemTablaISR.Add(new ItemTablaISR(
                            Convert.ToInt16(reader["id"]),
                            reader["LimInf"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["LimInf"]),
                            reader["LimSup"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["LimSup"]),
                            reader["CuotaFija"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["CuotaFija"]),
                            reader["ExedLimInf"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["ExedLimInf"]),
                            reader["Subsidio"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Subsidio"]),
                            Convert.ToDecimal(0)));
               
                }
                con.Close();
            }
            return itemTablaISR;
        }

        }
}
