using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unitec.CRUD.Business.Entity
{
    public class EntTodo
    {
        public EntTodo() { }

        private List<EntAlumno> alumnos;
        public List<EntAlumno> Alumnos
        {
            get { return alumnos; }
            set { alumnos = value; }
        }

        private List<EntTelefono> telefonos;
        public List<EntTelefono> Telefonos
        {
            get { return telefonos; }
            set { telefonos = value; }
        }
    }
}
