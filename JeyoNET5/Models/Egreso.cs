﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JeyoNET5.Models
{
    public class Egreso
    {
        public int EgresoId { get; set; }
        public DateTime FechaEgreso { get; set; }
        public int TipoEgresoId { get; set; }
        public virtual TipoEgreso TipoEgresos { get; set; }
        public int PacienteId { get; set; }
        public virtual Paciente Pacientes { get; set; }
        public bool estado { get; set; } = true;
    }
}
