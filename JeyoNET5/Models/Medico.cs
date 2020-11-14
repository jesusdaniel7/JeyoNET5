using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jeyo.Models
{
    public class Medico
    {
        public int MedicoId { get; set; }
        public string Nombre { get; set; }
        public string Apelido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int SexoId { get; set; }
        public virtual Sexo Sexo { get; set; }
        public string Nacionalidad { get; set; }
        public string Cedula_Pasaporte { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
    }
}
