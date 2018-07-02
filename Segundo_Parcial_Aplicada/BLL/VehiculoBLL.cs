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
    public class VehiculoBLL
    {
        public static bool Guardar(Vehiculos vehiculo)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                if (contexto.Vehiculo.Add(vehiculo) != null)
                {
                    contexto.SaveChanges();
                    paso = true;
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;

        }

        public static bool Modificar(Vehiculos vehiculo)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {

                contexto.Entry(vehiculo).State = EntityState.Modified;
                if (contexto.SaveChanges() > 0)
                {
                    paso = true;

                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }


            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();


            try
            {
                Vehiculos Vehiculo = contexto.Vehiculo.Find(id);
                contexto.Vehiculo.Remove(Vehiculo);

                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;

        }

        public static Vehiculos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Vehiculos Vehiculo = new Vehiculos();

            try
            {
                Vehiculo = contexto.Vehiculo.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Vehiculo;
        }

        public static List<Vehiculos> GetList(Expression<Func<Vehiculos, bool>> expression)
        {
            List<Vehiculos> Vehiculo = new List<Vehiculos>();
            Contexto contexto = new Contexto();

            try
            {
                Vehiculo = contexto.Vehiculo.Where(expression).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Vehiculo;
        }


    }
}
