using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace JeyoNET5.Models
{
    public class Egreso
    {
        public int EgresoId { get; set; }
        [DisplayName("Fecha de ingreso")]
        public DateTime FechaEgreso { get; set; }
        [DisplayName("Tipo de egreso")]
        public int TipoEgresoId { get; set; }
        public virtual TipoEgreso TipoEgresos { get; set; }
        [DisplayName("Paciente")]
        public int PacienteId { get; set; }
        public virtual Paciente Pacientes { get; set; }
        [DisplayName("Estado")]
        public bool estado { get; set; } = true;
    }
}
