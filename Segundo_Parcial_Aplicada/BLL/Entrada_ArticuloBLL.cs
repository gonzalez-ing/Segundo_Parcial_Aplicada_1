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
    public class Entrada_ArticuloBLL
    {
        public static bool Guardar(Entrada_Articulo entrada)
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

        public static bool Modificar(Entrada_Articulo entrada)
        {

            bool paso = false;

            Contexto contexto = new Contexto();


            try
            {
                Entrada_Articulo EntradaAnt = BLL.Entrada_ArticuloBLL.Buscar(entrada.EntradaId);

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

                Entrada_Articulo entrada = contexto.Entrada.Find(id);

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


        public static Entrada_Articulo Buscar(int id)
        {

            Entrada_Articulo entrada = new Entrada_Articulo();
            Contexto contexto = new Contexto();

            try
            {
                entrada = contexto.Entrada.Find(id);
                contexto.Dispose();

            }

            catch (Exception)
            {

                throw;

            }

            return entrada;
        }


        public static List<Entrada_Articulo> GetList(Expression<Func<Entrada_Articulo, bool>> expression)
        {
            List<Entrada_Articulo> entrada = new List<Entrada_Articulo>();
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
