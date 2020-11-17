using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JeyoNET5.Models
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
        public bool Estado { get; set; }

    }
}
