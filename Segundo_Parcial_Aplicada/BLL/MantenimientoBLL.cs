using Segundo_Parcial_Aplicada.DAL;
using Segundo_Parcial_Aplicada.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Segundo_Parcial_Aplicada.BLL
{
    public class MantenimientoBLL
    {
        public static bool Guardar(Mantenimiento mantenimiento)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                if (contexto.mantenimiento.Add(mantenimiento) != null)
                {
                    contexto.SaveChanges();
                    paso = true;
                }

                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public static bool Modificar(Mantenimiento mantenimiento)
        {

            bool paso = false;

            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(mantenimiento).State = EntityState.Modified;
                if (contexto.SaveChanges() > 0)
                {
                    paso = true;

                }

                contexto.Dispose();
            }

            catch (Exception)
            {
                throw;
            }

            return paso;
        }


        public static bool Eliminar(int id)
        {

            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                Mantenimiento mantenimiento = contexto.mantenimiento.Find(id);

                if (mantenimiento != null)
                {
                    foreach (var item in mantenimiento.Detalle)
                    {
                        contexto.mantenimiento.Find(item.ArticulosId).Cantidad += item.Cantidad;
                    }
                    contexto.Vehiculo.Find(mantenimiento.VehiculoId).MantenimientoTotal -= mantenimiento.Total;

                    mantenimiento.Detalle.Count();
                    contexto.mantenimiento.Remove(mantenimiento);

                }
                if (contexto.SaveChanges() > 0)
                {

                    paso = true;
                }
                contexto.Dispose();


            }
            catch (Exception) { throw; }
            return paso;

        }


        public static Mantenimiento Buscar(int id)
        {

            Mantenimiento mantenimiento = new Mantenimiento();
            Contexto contexto = new Contexto();

            try
            {
                mantenimiento = contexto.mantenimiento.Find(id);
                if (mantenimiento != null)
                {
                    mantenimiento.Detalle.Count();

                    foreach (var item in mantenimiento.Detalle)
                    {

                        string s = item.articulo.Descripcion;
                    }

                }
                contexto.Dispose();
            }
            catch (Exception) { throw; }
            return mantenimiento;
        }


        public static List<MantenimientosDetalles> GetList(Expression<Func<MantenimientosDetalles, bool>> expression)
        {

            List<MantenimientosDetalles> mantenimientos = new List<MantenimientosDetalles>();
            Contexto contexto = new Contexto();

            try
            {

                mantenimientos = contexto.mantenimientos.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {

                throw;
            }

            return mantenimientos;
        }


        public static Decimal CalcularImporte(Decimal cantidad, Decimal precio)
        {
            return cantidad * precio;
        }

        public static Decimal CalcularSubTotal(Decimal importe)
        {
            return importe;
        }

        public static Decimal CalcularItbis(Decimal subtotal)
        {
            return subtotal * (decimal)0.18;
        }

        public static Decimal CalcularTotal(Decimal subtotal, Decimal itbis)
        {
            return subtotal + itbis;
        }

    }
}
