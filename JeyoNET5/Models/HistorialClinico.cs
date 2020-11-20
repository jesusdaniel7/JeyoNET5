using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JeyoNET5.Models
{
    public class HistorialClinico
    {
        public int HistorialClinicoId { get; set; }
        [Required]
        [DisplayName("Paciente")]
        public int PacienteId { get; set; }
        public virtual Paciente Paciente { get; set; }
        public string Detallles { get; set; }
    }
}
