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
        public decimal Costo { get; set; }
        public int Ganancia { get; set; }
        public decimal Precio { get; set; }
        public int Inventario { get; set; }

        public Articulos()
        {
            ArticuloId = 0;
            Descripcion = string.Empty;
            Costo = 0;
            Ganancia = 0;
            Precio = 0;
            Inventario = 0;

        }

        public override string ToString()
        {
            return this.Descripcion;
        }
    }
}
