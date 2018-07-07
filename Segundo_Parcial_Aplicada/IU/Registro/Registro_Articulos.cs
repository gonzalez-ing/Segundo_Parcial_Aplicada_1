using Segundo_Parcial_Aplicada.BLL;
using Segundo_Parcial_Aplicada.DAL;
using Segundo_Parcial_Aplicada.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Segundo_Parcial_Aplicada.IU.Registro
{
    public partial class Registro_Articulos : Form
    {
        public Registro_Articulos()
        {
            InitializeComponent();
        }


        private Articulos LlenarClase()
        {
            Articulos articulo = new Articulos();

            articulo.ArticuloId = Convert.ToInt32(IdnumericUpDown.Value);
            articulo.Descripcion = DescripciontextBox.Text;
            articulo.Costo = Convert.ToInt32(CostonumericUpDown.Value);
            articulo.Ganancia = Convert.ToInt32(GanancianumericUpDown.Value);
            articulo.Precio = Convert.ToInt32(PrecionumericUpDown.Value);
            return articulo;
        }

        private bool Validar(int validar) 
        {

            bool paso = false;
            if (validar == 1 && IdnumericUpDown.Value == 0)
            {
                MyerrorProvider.SetError(IdnumericUpDown, "Debe Ingresar un ID");
                paso = true;

            }
            if (validar == 2 && DescripciontextBox.Text == string.Empty)
            {
                MyerrorProvider.SetError(DescripciontextBox, "Debe Ingresar una descripcion");
                paso = true;
            }
            if (validar == 2 && CostonumericUpDown.Value == 0)
            {
                MyerrorProvider.SetError(CostonumericUpDown, "Debe Ingresar un Costo");
                paso = true;
            }
            if (validar == 2 && GanancianumericUpDown.Value == 0)
            {
                MyerrorProvider.SetError(GanancianumericUpDown, "Debe Ingresar un % de ganancia");
                paso = true;
            }
            if (validar == 2 && PrecionumericUpDown.Value == 0)
            {
                MyerrorProvider.SetError(PrecionumericUpDown, "Debe Ingresar un Precio");
                paso = true;
            }
            return paso;
        }

        private void Registro_Articulos_Load(object sender, EventArgs e)
        {

        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            MyerrorProvider.Clear();

            if (Validar(1))
            {
                MessageBox.Show("Debe Ingresar Un ID");
                return;
            }

            int id = Convert.ToInt32(IdnumericUpDown.Value);
            Repositorio<Articulos> repositorio = new Repositorio<Articulos>(new Contexto());
            Articulos articulo = repositorio.Buscar(id);

            if (articulo != null)
            {

                DescripciontextBox.Text = articulo.Descripcion;
                CostonumericUpDown.Value = articulo.Costo;
                GanancianumericUpDown.Value = articulo.Ganancia;
                PrecionumericUpDown.Value = articulo.Precio;
                InventariotextBox.Text = articulo.Inventario.ToString();


            }
            else
                MessageBox.Show("No Se Encontro", "Hay Problemas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            IdnumericUpDown.Value = 0;
            DescripciontextBox.Clear();
            CostonumericUpDown.Value = 0;
            PrecionumericUpDown.Value = 0;
            GanancianumericUpDown.Value = 0;
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            Repositorio<Articulos> repositorio = new Repositorio<Articulos>(new Contexto());
            bool paso = false;
            if (Validar(2))
            {

                MessageBox.Show("Debe Llenar Todos Los Campos");
                return;
            }

            MyerrorProvider.Clear();

            if (IdnumericUpDown.Value == 0)
                paso = BLL.ArticulosBLL.Guardar(LlenarClase());
            else
                paso = BLL.ArticulosBLL.Modificar(LlenarClase());

            if (paso)

                MessageBox.Show("Guardado", "Excelente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No Se Pudo Guardar", "Hay Problemas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            MyerrorProvider.Clear();

            if (Validar(1))
            {
                MessageBox.Show("Debe Ingresar un ID");
                return;
            }

            int id = Convert.ToInt32(IdnumericUpDown.Value);
            Repositorio<Articulos> repositorio = new Repositorio<Articulos>(new Contexto());
            Articulos articulo = repositorio.Buscar(id);

            if (BLL.ArticulosBLL.Eliminar(id))
                MessageBox.Show("Eliminado", "Excelente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No Se Puede Eliminar", "Hay Problemas", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        // Calcular Ganancia
        private void GanancianumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(GanancianumericUpDown.Value) != 0)
            {
                if (Convert.ToDecimal(CostonumericUpDown.Value) != 0)
                {
                    PrecionumericUpDown.Value = ArticulosBLL.Precio(Convert.ToDecimal(CostonumericUpDown.Value), 
                        Convert.ToDecimal(GanancianumericUpDown.Value));
                }
            }

            // Calcular COSTO
            if (Convert.ToDecimal(GanancianumericUpDown.Value) != 0)
            {
                if (Convert.ToDecimal(PrecionumericUpDown.Value) != 0)
                {
                    CostonumericUpDown.Value = ArticulosBLL.Costo(Convert.ToDecimal(PrecionumericUpDown.Value), 
                        Convert.ToDecimal(GanancianumericUpDown.Value));
                }
            }
        }

        private void CostonumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            // Calculo Del Costo
            if (Convert.ToDecimal(PrecionumericUpDown.Value) != 0)
            {
                if (Convert.ToDecimal(CostonumericUpDown.Value) != 0)
                {
                    GanancianumericUpDown.Value = ArticulosBLL.PorcientoGanancia
                        (Convert.ToDecimal(PrecionumericUpDown.Value), Convert.ToDecimal(CostonumericUpDown.Value));
                }
            }

            if (Convert.ToDecimal(GanancianumericUpDown.Value) != 0)
            {
                if (Convert.ToDecimal(CostonumericUpDown.Value) != 0)
                {
                    PrecionumericUpDown.Value = ArticulosBLL.Precio(Convert.ToDecimal
                        (CostonumericUpDown.Value), Convert.ToDecimal(GanancianumericUpDown.Value));
                }
            }
        }

        private void PrecionumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            // Calculo Del Precio
            if (Convert.ToDecimal(PrecionumericUpDown.Value) != 0)
            {
                if (Convert.ToDecimal(CostonumericUpDown.Value) != 0)
                {
                    GanancianumericUpDown.Value = ArticulosBLL.PorcientoGanancia(Convert.ToDecimal
                        (PrecionumericUpDown.Value), Convert.ToDecimal(CostonumericUpDown.Value));
                }
            }

            if (Convert.ToDecimal(GanancianumericUpDown.Value) != 0)
            {
                if (Convert.ToDecimal(PrecionumericUpDown.Value) != 0)
                {
                    CostonumericUpDown.Value = ArticulosBLL.Costo(Convert.ToDecimal
                        (PrecionumericUpDown.Value), Convert.ToDecimal(GanancianumericUpDown.Value));
                }
            }
        }
    }
}