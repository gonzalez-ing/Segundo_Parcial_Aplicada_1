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
        public int VehiculoId { get; set; }
        public string Descripcion { get; set; }
        public int MantenimientoTotal { get; set; }

        public Vehiculos()
        { }

        public override string ToString()
        {
            return this.Descripcion;
        }

    }
}
