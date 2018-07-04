using Segundo_Parcial_Aplicada.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Segundo_Parcial_Aplicada.DAL
{
    public class Contexto : DbContext
    {

        public DbSet<Vehiculos> Vehiculo { get; set; }
        public DbSet<Mantenimiento> mantenimiento { get; set; }
        public DbSet<Articulos> Articulo { get; set; }
        public DbSet<Entrada_Articulo> Entrada { get; set; }
        public DbSet<Talleres> Tallere { get; set; }

        public Contexto() : base("ConStr")
        {
  
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
