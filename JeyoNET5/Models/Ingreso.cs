using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JeyoNET5.Models
{
    public class Ingreso
    {
        public int IngresoId { get; set; }
        public DateTime FechaIngreso { get; set; }
        [Required]
        [DisplayName("Tipo de ingreso")]
        public int TipoIngresoId { get; set; }
        public virtual TipoIngreso TipoIngreso { get; set; }
        [Required]
        [DisplayName("Paciente")]
        public int PacienteId { get; set; }
        public virtual Paciente Paciente { get; set; }
        [Required]
        [DisplayName("Unidad")]
        public int UnidadId { get; set; }
        public virtual Unidad Unidad { get; set; }
        [DisplayName("Estado")]
        public bool estado { get; set; } = true;
        [DisplayName("Condicion de llegada")]
        public string CondicionLlegada { get; set; }
        [DisplayName("Centro de procedencia")]
        public string CentroProcedencia { get; set; }
        [DisplayName("Telefono alterno")]
        [Phone]
        public string TelefonoAlterno { get; set; }
        [MaxLength(50)]
        [DisplayName("Relacion con el paciente")]
        public string RelacionPaciente { get; set; }
        [MaxLength(50)]
        public string Oficio { get; set; }
        [MaxLength(300)]
        [DisplayName("Preindicaciones")]
        public string Preeindicaciones { get; set; }
        [DisplayName("Condiciones especiales")]
        public string CondicionEspecial { get; set; }
        public virtual Factura Factura { get; set; }
        public virtual ICollection<Servicio> Servicios { get; set; }

    }
}
