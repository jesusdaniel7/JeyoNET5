using JeyoNET5.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace JeyoNET5.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Egreso> Egreso { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<HistorialClinico> HistorialClinico { get; set; }
        public DbSet<Ingreso> Ingresos { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Sexo> Sexo { get; set; }
        public DbSet<TipoEgreso> TipoEgresos { get; set; }
        public DbSet<TipoIngreso> TipoIngresos { get; set; }
        public DbSet<TipoUnidad> TipoUnidad { get; set; }
        public DbSet<Unidad> Unidades { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Servicio> Servicios { get; set; }


    }
}
