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

        private void Registro_Articulos_Load(object sender, EventArgs e)
        {

        }

        private Articulos LlenarClase()
        {

            Articulos articulo = new Articulos();

            articulo.ArticuloId = Convert.ToInt32(IdnumericUpDown.Value);
            articulo.Descripcion = DescripciontextBox.Text;
            articulo.Costo = Convert.ToInt32(CostoTextBox.Text);
            articulo.Ganancia = Convert.ToInt32(GananciaBox.Text);
            articulo.Precio = Convert.ToInt32(PrecioTextBox.Text);
            articulo.Inventario = 0;
            return articulo;
        }

        private Articulos Limpiar()
        {
            Articulos vehiculo = new Articulos();
            IdnumericUpDown.Value = 0;
            DescripciontextBox.Clear();
            CostoTextBox.Clear();
            PrecioTextBox.Clear();
            GananciaBox.Clear();
            InventariotextBox.Clear();


            return vehiculo;
        }

        private bool Validar(int validar)
        {

            bool paso = false;

            if (validar == 1 && IdnumericUpDown.Value == 0)
            {
                MyerrorProvider.SetError(IdnumericUpDown, "Debe Ingresar un ID");
                paso = true;

            }
            return paso;
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            MyerrorProvider.Clear();

            if (Validar(1))
            {
                MessageBox.Show("Debe Ingresar un ID");
                return;
            }

            int id = Convert.ToInt32(IdnumericUpDown.Value);
            Articulos articulo = BLL.ArticuloBLL.Buscar(id);

            if (articulo != null)
            {

                DescripciontextBox.Text = articulo.Descripcion;
                CostoTextBox.Text = articulo.Costo.ToString();
                GananciaBox.Text = articulo.Ganancia.ToString();
                PrecioTextBox.Text = articulo.Precio.ToString();
                InventariotextBox.Text = articulo.Inventario.ToString();


            }
            else
                MessageBox.Show("No se puede encontrar", "Hay Problemas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            if (Validar(2))
            {

                MessageBox.Show("Debe Llenar todos los campos");
                return;
            }

            MyerrorProvider.Clear();


            if (IdnumericUpDown.Value == 0)
                paso = BLL.ArticuloBLL.Guardar(LlenarClase());
            else
                paso = BLL.ArticuloBLL.Modificar(LlenarClase());


            if (paso)

                MessageBox.Show("Guardado", "Excelente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se puede guardar", "Hay Problemas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Limpiar();
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            MyerrorProvider.Clear();

            if (Validar(1))
            {
                MessageBox.Show("Ingrese un ID");
                return;
            }

            int id = Convert.ToInt32(IdnumericUpDown.Value);

            if (BLL.ArticuloBLL.Eliminar(id))
                MessageBox.Show("Eliminado", "Excelente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se puede eliminar", "Hay Problemas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}