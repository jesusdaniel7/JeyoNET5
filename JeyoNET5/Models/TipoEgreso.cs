using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jeyo.Models
{
    public class TipoEgreso
    {
        public int TipoEgresoId { get; set; }
        public string Nombre { get; set; }
        public virtual IReadOnlyCollection<Egreso> Egreso { get; set; }
    }
}
