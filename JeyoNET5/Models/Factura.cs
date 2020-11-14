using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jeyo.Models
{
    public class Factura
    {
        public int FacturaId { get; set; }
        public string Codigo { get; set; }
        public int PacienteID { get; set; }
        public virtual Paciente Paciente { get; set; }
        public DateTime Fecha { get; set; }
        public Double Monto { get; set; } = 0;
        public Double Descuento { get; set; } = 0;
        public Double Total { get; set; }
        public int EstadoId { get; set; }
        public virtual Estado Estado { get; set; }
        public virtual ICollection<Egreso> Egresos { get; set; }

    }
}
