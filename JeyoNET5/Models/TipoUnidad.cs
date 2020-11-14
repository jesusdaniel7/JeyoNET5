using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jeyo.Models
{
    public class TipoUnidad
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<Unidad> Unidad { get; set; }
    }
}
