using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace JeyoNET5.Models
{
    public class Unidad
    {
        public int Id { get; set; }
        public int Piso { get; set; }
        public int NumeroHabitacion { get; set; }
        [DisplayName("Tipo de unidad")]
        public int TipoUnidadId { get; set; }
        public virtual TipoUnidad TipoUnidad { get; set; }
        public virtual ICollection<Ingreso> Ingresos { get; set; }
    }
}
