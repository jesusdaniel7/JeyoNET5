using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jeyo.Models
{
    public class Estado
    {
        public int EstadoId { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<Factura> Factura { get; set; }
    }
}
