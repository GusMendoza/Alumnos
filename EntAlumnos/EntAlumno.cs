using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unitec.CRUD.Business.Entity
{
    public class EntAlumno
    {
        public EntAlumno() { }
        public int id { get; set; }
        public string nombre { get; set; }
        public DateTime fecha { get; set; }
        public bool estatus { get; set; }
        public int sexoId { get; set; }
        private EntSexo Sexo;

        public EntSexo sexo
        {
            get { return Sexo; }
            set { Sexo = value; }
        }
        
        public string foto { get; set; }
        public double promedio { get; set; }
        public string telefono { get; set; }

        //ALUM_ID, ALUM_NOMB, ALUM_FECH, ALUM_ESTA, ALUM_SEXO_ID, ALUM_FOTO, ALUM_PROM estos bienen de la base de datos
    }
}
