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

        public Contexto() : base("ConStr")
        {
  
        }

    }
}
