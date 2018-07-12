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

                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
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

                Vehiculos vehiculo = contexto.Vehiculo.Find(id);
                contexto.Vehiculo.Remove(vehiculo);
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


        public static Vehiculos Buscar(int id)
        {

            Vehiculos vehiculo = new Vehiculos();
            Contexto contexto = new Contexto();

            try
            {
                vehiculo = contexto.Vehiculo.Find(id);
                contexto.Dispose();

            }

            catch (Exception)
            {

                throw;

            }

            return vehiculo;

        }


        public static List<Vehiculos> GetList(Expression<Func<Vehiculos, bool>> expression)
        {

            List<Vehiculos> vehiculos = new List<Vehiculos>();
            Contexto contexto = new Contexto();

            try
            {

                vehiculos = contexto.Vehiculo.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {

                throw;
            }

            return vehiculos;
        }
    }
}
