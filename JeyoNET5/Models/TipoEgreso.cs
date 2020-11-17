using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JeyoNET5.Models
{
    public class TipoEgreso
    {
        public int TipoEgresoId { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<Egreso> Egreso { get; set; }
    }
}
