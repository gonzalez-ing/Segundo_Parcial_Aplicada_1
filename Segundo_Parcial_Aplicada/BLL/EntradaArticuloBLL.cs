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
    public class EntradaArticuloBLL
    {
        public static bool Guardar(EntradaArticulos entrada)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                if (contexto.Entrada.Add(entrada) != null)
                {
                    var Articulo = contexto.Articulo.Find(entrada.ArticuloId);
                    Articulo.Inventario += entrada.Cantidad;
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

        public static bool Modificar(EntradaArticulos entrada)
        {

            bool paso = false;

            Contexto contexto = new Contexto();


            try
            {
                EntradaArticulos EntradaAnt = BLL.EntradaArticuloBLL.Buscar(entrada.EntradaId);

                int diferencia;
                diferencia = entrada.Cantidad - EntradaAnt.Cantidad;
                var Articulo = contexto.Articulo.Find(entrada.ArticuloId);
                Articulo.Inventario += diferencia;

                contexto.Entry(entrada).State = EntityState.Modified;

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

                EntradaArticulos entrada = contexto.Entrada.Find(id);

                var Articulo = contexto.Articulo.Find(entrada.ArticuloId);
                Articulo.Inventario -= entrada.Cantidad;

                contexto.Entrada.Remove(entrada);
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


        public static EntradaArticulos Buscar(int id)
        {

            Contexto contexto = new Contexto();
            EntradaArticulos entradasArticulos = new EntradaArticulos();

            try
            {
                entradasArticulos = contexto.Entrada.Find(id);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return entradasArticulos;
        }


        public static List<EntradaArticulos> GetList(Expression<Func<EntradaArticulos, bool>> expression)
        {
            List<EntradaArticulos> entrada = new List<EntradaArticulos>();
            Contexto contexto = new Contexto();

            try
            {
                entrada = contexto.Entrada.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {

                throw;
            }

            return entrada;
        }
    }
}
