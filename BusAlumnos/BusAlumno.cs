using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unitec.CRUD.Business.Entity;
using Unitec.CRUD.Data;

namespace Unitec.CRUD.Business
{
    public class BusAlumno
    {
        public BusAlumno() { }
        public EntTodo ObtenerAlumnos()
        {
            DataSet ds = new DatAlumno().ObtenerAlumnos();
            EntTodo todo = new EntTodo();
            List<EntAlumno> lista = new List<EntAlumno>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                EntAlumno ent = new EntAlumno();
                ent.id = Convert.ToInt32(dr["ALUM_ID"]);
                ent.nombre = dr["ALUM_NOMB"].ToString();
                ent.fecha = Convert.ToDateTime(dr["ALUM_FECH"]);
                ent.estatus = Convert.ToBoolean(dr["ALUM_ESTA"]);
                ent.sexoId = Convert.ToInt32(dr["ALUM_SEXO_ID"]);
                ent.sexo = new EntSexo();
                ent.sexo.nombre = dr["SEXO_NOMB"].ToString();
                ent.foto = dr["ALUM_FOTO"].ToString();
                ent.promedio = Convert.ToDouble(dr["ALUM_PROM"]);
                lista.Add(ent);

            }
            todo.Alumnos = lista;

            List<EntTelefono> lstTel = new List<EntTelefono>();
            foreach (DataRow dr in ds.Tables[1].Rows)
            {
                EntTelefono ent = new EntTelefono();
                ent.id = Convert.ToInt32(dr["TELE_ID"]);
                ent.alumnoId = Convert.ToInt32(dr["TELE_ALUM_ID"]);
                ent.numero = dr["TELE_NUME"].ToString();
                ent.cataTeleId = Convert.ToInt32(dr["TELE_CATA_TELE_ID"]);
                lstTel.Add(ent);
            }
            todo.Telefonos = lstTel;
            return todo;
        }
        public EntAlumno ObtenerUnAlumno(int id)
        {
            DataRow dr = new DatAlumno().ObtenerUnAlumno(id);
            EntAlumno ent = new EntAlumno();
            ent.id = Convert.ToInt32(dr["ALUM_ID"]);
            ent.nombre = dr["ALUM_NOMB"].ToString();
            ent.fecha = Convert.ToDateTime(dr["ALUM_FECH"]);
            ent.estatus = Convert.ToBoolean(dr["ALUM_ESTA"]);
            ent.sexoId = Convert.ToInt32(dr["ALUM_SEXO_ID"]);
            ent.foto = dr["ALUM_FOTO"].ToString();
            ent.promedio = Convert.ToDouble(dr["ALUM_PROM"]);
            return ent;
        }
        public void ActualizarAlumno(EntAlumno ent)
        {
            int fila = new DatAlumno().ActualizarAlumno(ent.id, ent.nombre, ent.fecha, ent.estatus, ent.sexoId, ent.foto, ent.promedio);
            if (fila != 1)
                throw new ApplicationException("Error al actualizar " + ent.nombre + " en la capa de Business");
        }
        public void InsertarAlumno(EntAlumno ent)
        {
            int fila = new DatAlumno().InsertarAlumno(ent.nombre, ent.fecha, ent.estatus, ent.sexoId, ent.foto, ent.promedio);
            if (fila != 1)
                throw new ApplicationException("Error al Insertar " + ent.nombre + " en la capa de Business");
        }
        public void BorrarAlumno(EntAlumno ent)
        {
            int fila = new DatAlumno().BorrarAlumno(ent.id);
            if (fila != 1)
                throw new ApplicationException("Error al Borrar el Alumno " + ent.nombre + " en la capa de Business");
        }
        public EntUsuario ValidarAlumno(string mail, string password)
        {
            DataTable dt = new DatAlumno().ValidarAlumno(mail, password);
            if (dt.Rows.Count > 0)
            {
                EntUsuario user = new EntUsuario();
                user.id = Convert.ToInt32(dt.Rows[0]["USER_ID"]);
                user.nombre = dt.Rows[0]["USER_NOMB"].ToString();
                user.mail = dt.Rows[0]["USER_MAIL"].ToString();
                user.password = dt.Rows[0]["USER_PASS"].ToString();
                return user;
            }
            else
            {
                throw new ApplicationException("Mail o Contraseña no validos");
            }

        }

        public List<EntSexo> ObtenerSexo()
        {
            DataTable dt = new DatAlumno().ObtenerSexo();
            List<EntSexo> lista = new List<EntSexo>();
            foreach (DataRow dr in dt.Rows)
            {
                EntSexo ent = new EntSexo();
                ent.id = Convert.ToInt32(dr["SEXO_ID"]);
                ent.nombre = dr["SEXO_NOMB"].ToString();
              
                lista.Add(ent);
            }
            return lista; 
        }
    }
}
