using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jeyo.Models
{
    public class Ingreso
    {
        public int IngresoId { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int TipoIngresoId { get; set; }
        public virtual TipoIngreso TipoIngreso { get; set; }
        public int PacienteId { get; set; }
        public virtual Paciente Paciente { get; set; }
        public int UnidadId { get; set; }
        public virtual Unidad Unidad { get; set; }
        public bool estado { get; set; } = true;
    }
}
