using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JeyoNET5.Models
{
    public class Factura
    {
        public int FacturaId { get; set; }
        public string Codigo { get; set; }
        public DateTime Fecha { get; set; }
        public Double Monto { get; set; } = 0;
        public Double Descuento { get; set; } = 0;
        public Double Total { get; set; }
        public bool Estado { get; set; }
        [DisplayName("Ingreso")]
        public int IngresoId { get; set; }
        public virtual Ingreso Ingreso { get; set; }

    }
}
