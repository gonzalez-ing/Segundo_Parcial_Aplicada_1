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
        public string Fecha { get; set; }
        public int Cantidad { get; set; }
        public int ArticuloId { get; set; }

        public Entrada_Articulo()
        { }

        public override string ToString()
        {
            return this.Fecha;
        }
    }
}
