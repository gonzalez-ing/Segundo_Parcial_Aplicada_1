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
        public int VehiculoId { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime ProxFecha { get; set; }
        public decimal Subtotal { get; set; }
        public decimal itbis { get; set; }
        public decimal Total { get; set; }
        public decimal Cantidad { get; set; }


        public virtual ICollection<Mantenimiento_Detalle> Detalle { get; set; }

        public Mantenimiento()
        {
            this.Detalle = new List<Mantenimiento_Detalle>();

            MantenimientoId = 0;
            Fecha = DateTime.Now;
            Subtotal = 0;
            itbis = 0;
            Total = 0;
            Cantidad = 1;

        }

        public void AgregarDetalle(int id, int mantenimientoId, int tallerId, int articulosId, string articulo, decimal cantidad, decimal precio, decimal importe)
        {
            this.Detalle.Add(new Mantenimiento_Detalle(id, mantenimientoId, tallerId, articulosId, articulo, cantidad, precio, importe));
        }
    }
}