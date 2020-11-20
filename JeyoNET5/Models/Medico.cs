using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace JeyoNET5.Models
{
    public class Medico
    {
        public int MedicoId { get; set; }
        public string Nombre { get; set; }
        [DisplayName("Apellido")]
        public string Apelido { get; set; }
        [DisplayName("Fecha de nacimiento")]
        public DateTime FechaNacimiento { get; set; }
        [DisplayName("Sexo")]
        public int SexoId { get; set; }
        public virtual Sexo Sexo { get; set; }
        public string Nacionalidad { get; set; }
        [DisplayName("Cedula o pasaporte")]
        public string Cedula_Pasaporte { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
    }
}
