using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unitec.CRUD.Business.Entity
{
    public class EntTelefono
    {
        public EntTelefono() { }
        public int id { get; set; }
        public int alumnoId { get; set; }
        public string numero { get; set; }
        public int cataTeleId { get; set; }


        //TELE_ID, TELE_ALUM_ID, TELE_NUME, TELE_CATA_TELE_ID
    }
}
