﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Segundo_Parcial_Aplicada.Entidades
{
    public class Mantenimiento_Detalle
    {
        [Key]
        public int Id { get; set; }
        public int MantenimientoId { get; set; }
        public int VehiculoId { get; set; }
        public string Articulo { get; set; }
        public int Cantidad { get; set; }
        public int Precio { get; set; }
        public int Importe { get; set; }
        public int SubTotal { get; set; }
        public int Itbis { get; set; }
        public int Total { get; set; }

        [ForeignKey("VehiculoId")]
        public virtual Vehiculos Vehiculos { get; set; }

        [ForeignKey("TalleresId")]
        public virtual Talleres Talleres { get; set; }


        public Mantenimiento_Detalle()
        {
            this.Id = 0;
            this.MantenimientoId = 0;

        }

        public Mantenimiento_Detalle(int id, int mantenimientoId, int vehiculoId, string articulo, int cantidad, int precio, int importe, int Subtotal, int itbis, int total)
        {
            Id = id;
            MantenimientoId = mantenimientoId;
            VehiculoId = vehiculoId;
            Cantidad = cantidad;
            Precio = precio;
            Importe = importe;
            SubTotal = Subtotal;
            Total = total;
        }
    }
}
