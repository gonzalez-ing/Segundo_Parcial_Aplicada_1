using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Segundo_Parcial_Aplicada.Entidades
{
    public class Entrada_Articulo
    {
        [Key]
        public int EntradaId { get; set; }
        public DateTime Fecha { get; set; }
        public string Articulo { get; set; }
        public int Cantidad { get; set; }

        public virtual ICollection<Entradas_Detalle> Detalle { get; set; }

        public Entrada_Articulo()
        {
            this.Detalle = new List<Entradas_Detalle>();
        }

        public void AgregarInventario(int id, int entradaId, int articuloId, int cantidad)
        {
            this.Detalle.Add(new Entradas_Detalle(id, entradaId, articuloId, cantidad));
        }

    }
}
