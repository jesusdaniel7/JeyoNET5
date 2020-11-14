using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jeyo.Models
{
    public class HistorialClinico
    {
        public int HistorialClinicoId { get; set; }
        public int PacienteId { get; set; }
        public virtual Paciente Paciente { get; set; }
        public int IngresoId { get; set; }
        public virtual Ingreso Ingreso { get; set; }
        public int EgresoId { get; set; }
        public virtual Egreso Egreso { get; set; }
        public string Detallles { get; set; }
    }
}
