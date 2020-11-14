using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jeyo.Models
{
    public class Sexo
    {
        public int SexoId { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<Paciente> Pacientes { get; set; }
        public virtual ICollection<Medico> Medicos { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
