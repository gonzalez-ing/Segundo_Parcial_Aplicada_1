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
    public partial class Registro_Entrada_Articulos : Form
    {
        public Registro_Entrada_Articulos()
        {
            InitializeComponent();
            LlenarComboBox();
        }

        private EntradaArticulos LlenarClase()
        {

            EntradaArticulos entrada = new EntradaArticulos();

            entrada.EntradaId = Convert.ToInt32(IdnumericUpDown.Value);
            entrada.ArticuloId = (int)ArticulocomboBox.SelectedValue;
            entrada.Fecha = fechaDateTimePicker.Text;
            entrada.Cantidad = Convert.ToInt32(CantidadTextBox.Text);

            return entrada;
        }

        private EntradaArticulos Limpiar()
        {
            EntradaArticulos entrada = new EntradaArticulos();
            IdnumericUpDown.Value = 0;
            CantidadTextBox.Clear();

            return entrada;
        }

        private void LlenarComboBox()
        {
            Repositorio<Articulos> repositorio = new Repositorio<Articulos>(new Contexto());
            ArticulocomboBox.DataSource = repositorio.GetList(c => true);
            ArticulocomboBox.ValueMember = "ArticuloId";
            ArticulocomboBox.DisplayMember = "Descripcion";
        }

        private bool Validar(int validar)
        {

            bool paso = false;

            if (validar == 1 && IdnumericUpDown.Value == 0)
            {
                MyErrorProvider.SetError(IdnumericUpDown, "Debe Ingresar un ID");
                paso = true;

            }
            return paso;
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            MyErrorProvider.Clear();

            if (Validar(1))
            {
                MessageBox.Show("Debe Ingresar un ID");
                return;
            }

            int id = Convert.ToInt32(IdnumericUpDown.Value);
            EntradaArticulos entrada = BLL.EntradaArticuloBLL.Buscar(id);

            if (entrada != null)
            {

                fechaDateTimePicker.Text = entrada.Fecha;
                ArticulocomboBox.SelectedValue = entrada.ArticuloId;
                CantidadTextBox.Text = entrada.Cantidad.ToString();
            }
            else
                MessageBox.Show("No se puede encontrar", "Hay Problemas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            if (Validar(2))
            {

                MessageBox.Show("Debe Llenar todos los campos");
                return;
            }

            MyErrorProvider.Clear();


            if (IdnumericUpDown.Value == 0)
                paso = BLL.EntradaArticuloBLL.Guardar(LlenarClase());
            else
                paso = BLL.EntradaArticuloBLL.Modificar(LlenarClase());


            if (paso)

                MessageBox.Show("Guardado", "Excelente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo guardar", "Hay Problemas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Limpiar();
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            MyErrorProvider.Clear();

            if (Validar(1))
            {
                MessageBox.Show("Debe Ingresar un ID");
                return;
            }

            int id = Convert.ToInt32(IdnumericUpDown.Value);

            if (BLL.EntradaArticuloBLL.Eliminar(id))
                MessageBox.Show("Eliminado", "Excelente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se puede eliminar", "Hay Problemas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Registro_Entrada_Articulos_Load(object sender, EventArgs e)
        {

        }
    }
}
