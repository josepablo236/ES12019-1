﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class DefTabla
    {
        public string Nombre { get; set; }
        public List<DefColumna> columnas { get; set; }
    }
}
