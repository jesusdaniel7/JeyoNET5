using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JeyoNET5.Models
{
    public class TipoIngreso
    {
        public int TipoIngresoId { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<Ingreso> Ingreso { get; set; }
    }
}
