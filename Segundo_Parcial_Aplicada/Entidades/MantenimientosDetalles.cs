using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Segundo_Parcial_Aplicada.Entidades
{
    public class MantenimientosDetalles
    {
        [Key]
        public int Id { get; set; }
        public int MantenimientoId { get; set; }
        public int TallerId { get; set; }
        public int ArticulosId { get; set; }
        public string Articulo { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Importe { get; set; }

        [ForeignKey("ArticulosId")]
        public virtual Articulos articulo { get; set; }

        public MantenimientosDetalles()
        {
            Id = 0;
            MantenimientoId = 0;
        }

        public MantenimientosDetalles(int id, int mantenimientoId, int tallerId, int articulosId, string articulo, decimal cantidad, decimal precio, decimal importe)
        {
            Id = id;
            MantenimientoId = mantenimientoId;
            TallerId = tallerId;
            ArticulosId = articulosId;
            Articulo = articulo;
            Cantidad = cantidad;
            Precio = precio;
            Importe = importe;
        }

        public MantenimientosDetalles(int mantenimientoId, int articulosId, string articulo, decimal cantidad, decimal precio, decimal importe)
        {

            MantenimientoId = mantenimientoId;
            ArticulosId = articulosId;
            Articulo = articulo;
            Cantidad = cantidad;
            Precio = precio;
            Importe = importe;
        }

    }
}
