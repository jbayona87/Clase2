﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio.DAL
{
    public class NuevoUsuario
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Clave { get; set; }
        public Boolean Enable { get; set; }
    }
}
