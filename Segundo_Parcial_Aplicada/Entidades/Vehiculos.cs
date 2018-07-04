using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Segundo_Parcial_Aplicada.Entidades
{
    public class Vehiculos
    {
        [Key]
        public int VehiculoId { get; set; }
        public string Descripcion { get; set; }
        public decimal Mantenimiento { get; set; }

        public Vehiculos()
        {
            VehiculoId = 0;
            Descripcion = string.Empty;
            Mantenimiento = 0;
        }

        public override string ToString()
        {
            return this.Descripcion;
        }

    }
}
