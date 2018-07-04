using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Segundo_Parcial_Aplicada.Entidades
{
    public class Mantenimiento
    {
        [Key]
        public int MantenimientoId { get; set; }
        public DateTime Fecha { get; set; }
        public float Monto { get; set; }


        public virtual ICollection<Mantenimiento_Detalle> Detalle { get; set; }

        public Mantenimiento()
        {
            this.Detalle = new List<Mantenimiento_Detalle>();
        }

        public void AgregarDetalle(int id, int MantenimientoId, int VehiculoId, string Articulo, int Cantidad, int Precio)
        {
            this.Detalle.Add(new Mantenimiento_Detalle(id, MantenimientoId, VehiculoId, Articulo, Cantidad, Precio));
        }

    }
}