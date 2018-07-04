using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Segundo_Parcial_Aplicada.Entidades
{
    public class Articulos
    {
        [Key]
        public int ArticuloId { get; set; }
        public string Descripcion { get; set; }
        public Decimal Costo { get; set; }
        public Decimal Precio { get; set; }
        public int Ganancia { get; set; }
        public int Inventario { get; set; }

        public Articulos(int articuloId, string descripcion, Decimal costo, Decimal precio, int ganancia, int inventario)
        {
            ArticuloId = articuloId;
            Descripcion = descripcion;
            Costo = costo;
            Precio = precio;
            Ganancia = ganancia;
            Inventario = inventario;
        }

        public Articulos()
        {
            this.ArticuloId = 0;
            this.Descripcion = string.Empty;
            this.Costo = 0;
            this.Precio = 0;
            Ganancia = 0;
            Inventario = 0;
        }

        public override string ToString()
        {
            return this.Descripcion;
        }
    }
}
