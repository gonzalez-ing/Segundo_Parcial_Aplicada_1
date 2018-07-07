using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Segundo_Parcial_Aplicada.Entidades
{
    public class Entradas_Detalle
    {
        public int Id { get; set; }
        public int EntradaId { get; set; }
        public int ArticuloId { get; set; }
        public int Cantidad { get; set; }

        [ForeignKey("ArticuloId")]
        public virtual Articulos Articulo { get; set; }


        public Entradas_Detalle()
        {
            Id = 0;
            EntradaId = 0;

        }

        public Entradas_Detalle(int id, int entradaId, int articuloId, int cantidad)
        {
            Id = id;
            EntradaId = entradaId;
            ArticuloId = articuloId;
            Cantidad = cantidad;
        }
    }
}
