using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unitec.CRUD.Data
{
    public class DatAlumno: DatAbstracta
    {
        public DatAlumno() { }
        public DataTable ObtenerAlumnos()
        {
            SqlCommand com = new SqlCommand("spObtenerAlumnos", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataRow ObtenerUnAlumno(int id) 
        {
            SqlCommand com = new SqlCommand("spObtenerUnAlumno", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add(new SqlParameter() {SqlDbType = SqlDbType.Int, Value= id, ParameterName = "@Id",  });

            //SqlParameter num = new SqlParameter();   Estas cuatro lineas hacen lo ,ismo que la linea de arriba  la cual es la forma 
            //num.SqlDbType = SqlDbType.Int;           correcta de PARAMETRIZAR
            //num.SqlValue = id;
            //num.ParameterName = "@Id";
            //com.Parameters.Add(num);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt.Rows[0];
        }
        public int InsertarAlumno(string nombre, DateTime fecha, bool estatus, int sexoId, string foto, double promedio) 
        {
            SqlCommand com = new SqlCommand("spInsertarAlumno", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.NVarChar, Value = nombre, ParameterName = "@Nombre", });
            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.NVarChar, Value = fecha, ParameterName = "@Fecha", });
            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.Bit, Value = estatus, ParameterName = "@Estatus", });
            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.Int, Value = sexoId, ParameterName = "@SexoId", });
            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.NVarChar, Value = foto, ParameterName = "@Foto", });
            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.Decimal, Value = promedio, ParameterName = "@Promedio", });
            
            // @Nombre, @Fecha, @Estatus, @SexoId,  @Foto, @Promedio

            try
            {
                con.Open();
                int fila = com.ExecuteNonQuery();
                con.Close();
                return fila;
            }
            catch (Exception ex)
            {
                con.Close();
                throw new ApplicationException("No fue posible Insertar al Alumno, error en la capa de datos" + ex.Message);
            }            
        }
        public int ActualizarAlumno(int id, string nombre, DateTime fecha, bool estatus, int sexoId, string foto, double promedio)
        {
            SqlCommand com = new SqlCommand("spActualizarAlumno", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.Int, Value = id, ParameterName = "@Id", });
            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.NVarChar,Value = nombre, ParameterName = "@Nombre"});
            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.NVarChar, Value = fecha, ParameterName = "@Fecha" });
            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.Bit, Value = estatus, ParameterName = "@Estatus"});
            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.Int, Value = sexoId, ParameterName = "@SexoId"});
            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.NVarChar, Value = foto, ParameterName = "@Foto"});
            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.Decimal, Value = promedio, ParameterName = "@Promedio"});
            try
            {
                con.Open();
                int fila = com.ExecuteNonQuery();
                con.Close();
                return fila;
            }
            catch (Exception ex)
            {
                con.Close();
                throw new ApplicationException("No fue posible Actualizar el Alumno, erro en la capa de datos" + ex.Message);
            }
        }
        public int BorrarAlumno(int id)
        {
            SqlCommand com = new SqlCommand("spBorrarAlumno", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.Int, Value = id, ParameterName = "@Id", });
            try
            {
                con.Open();
                int fila = com.ExecuteNonQuery();
                con.Close();
                return fila;
            }
            catch (Exception ex)
            {
                con.Close();
                throw new ApplicationException("Error al Borrar Alumno, en capa de datos " + ex.Message);
            }
        }
        public DataTable ValidarAlumno(string mail, string password)
        {
            SqlCommand com = new SqlCommand("spValidarAlumno", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.NVarChar, Value = mail, ParameterName = "@Mail",});
            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.NVarChar, Value = password, ParameterName = "@Password",} );

            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }
    }
}
