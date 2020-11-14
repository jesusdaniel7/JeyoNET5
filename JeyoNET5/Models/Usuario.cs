using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jeyo.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apelido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int SexoId { get; set; }
        public virtual Sexo Sexo { get; set; }
        public string Cedula { get; set; }
        public string Correo { get; set; }
        public string  Direccion { get; set; }
    }
}
