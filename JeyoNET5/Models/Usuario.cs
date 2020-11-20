using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace JeyoNET5.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        [DisplayName("Apellido")]
        public string Apelido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        [DisplayName("Sexo")]
        public int SexoId { get; set; }
        public virtual Sexo Sexo { get; set; }
        public string Cedula { get; set; }
        public string Correo { get; set; }
        public string  Direccion { get; set; }
    }
}
