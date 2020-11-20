using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace JeyoNET5.Models
{
    public class Servicio
    {
        public int ServicioId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double Monto { get; set; }
        [DisplayName("Ingreso")]
        public int IngresoId { get; set; }
        public virtual Ingreso Ingreso { get; set; }
    }
}
