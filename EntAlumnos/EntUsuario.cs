﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unitec.CRUD.Business.Entity
{
    public class EntUsuario
    {
        public EntUsuario() { }
        public int id { get; set; }
        public string nombre { get; set; }
        public string mail { get; set; }
        public string password { get; set; }

    }
}
