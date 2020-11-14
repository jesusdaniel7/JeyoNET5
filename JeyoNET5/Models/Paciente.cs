using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jeyo.Models
{
    public class Paciente
    {
        public int PacienteId { get; set; }
        public string Nombre { get; set; }
        public string Apelido { get; set; }
        public DateTime FechaNacimiento  { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int SexoId { get; set; }
        public virtual Sexo Sexo { get; set; }
        public string Nacionalidad { get; set; }
        public string Seguro { get; set; } = "Ninguno";
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public virtual ICollection<Ingreso> Ingresos { get; set; }
        public virtual ICollection<Factura> Facturas { get; set; }
        public virtual ICollection<Egreso> Egresos { get; set; }
        public virtual ICollection<HistorialClinico> HistorialClinico { get; set; }

    }
}
