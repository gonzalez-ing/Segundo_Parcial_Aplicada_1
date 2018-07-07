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
            LLenaComboBox();
        }

        private void LLenaComboBox()
        {
            Repositorio<Articulos> repositorio = new Repositorio<Articulos>(new Contexto());
            ArticulocomboBox.DataSource = repositorio.GetList(a => true);
            ArticulocomboBox.ValueMember = "ArticuloId";
            ArticulocomboBox.DisplayMember = "Descripcion";
        }

        private Entrada_Articulo LLenaClase()
        {
            Entrada_Articulo articulo = new Entrada_Articulo();
            articulo.EntradaId = Convert.ToInt32(IdnumericUpDown.Value);
            articulo.Fecha =fechaDateTimePicker.Value.Date;
            articulo.Articulo = ArticulocomboBox.Text;
            articulo.Cantidad = Convert.ToInt32(CantidadnumericUpDown.Value);
            return articulo;
        }

        private void Registro_Entrada_Articulos_Load(object sender, EventArgs e)
        {

        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            IdnumericUpDown.Value = 0;
            fechaDateTimePicker.ResetText();
            CantidadnumericUpDown.Value = 0;
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(IdnumericUpDown.Value);
            Repositorio<Entrada_Articulo> repositorio = new Repositorio<Entrada_Articulo>(new Contexto());
            Entrada_Articulo articulo = repositorio.Buscar(id);

            if (articulo != null)
            {
                fechaDateTimePicker.Value = articulo.Fecha;
                ArticulocomboBox.Text = articulo.Articulo;
                CantidadnumericUpDown.Value = articulo.Cantidad;

            }
            else
                MessageBox.Show("No Se Puede Encontrar", "Hay Problemas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            Repositorio<Entrada_Articulo> repositorio = new Repositorio<Entrada_Articulo>(new Contexto());
            Entrada_Articulo articulo;

            if (Validar())
            {
                MessageBox.Show("Debe Llenar Todos Los Campos", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            articulo = LLenaClase();

            if (IdnumericUpDown.Value == 0)
                paso = repositorio.Guardar(articulo);
            else
                paso = repositorio.Modificar(articulo);



            if (paso)
            {
                MessageBox.Show("Guardado ", "Excelente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Inventario();
            }
            else
                MessageBox.Show("No Se Puede Guardar", "Hay Problemas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(IdnumericUpDown.Value);
            Repositorio<Entrada_Articulo> repositorio = new Repositorio<Entrada_Articulo>(new Contexto());
            Entrada_Articulo articulo = repositorio.Buscar(id);

            if (articulo != null)
            {
                repositorio.Eliminar(id);
                MessageBox.Show("Eliminado", "Excelente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("No Se Puede Eliminar", "Hay Problemas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void Inventario()
        {
            Repositorio<Articulos> repositorio = new Repositorio<Articulos>(new Contexto());
            Articulos articulo = (Articulos)ArticulocomboBox.SelectedItem;
            articulo.Inventario = (int)CantidadnumericUpDown.Value;
            repositorio.Modificar(articulo);
        }

        private bool Validar()
        {
            bool Validar = false;

            if (CantidadnumericUpDown.Value == 0)
            {
                MyErrorProvider.SetError(CantidadnumericUpDown, "Ingrese Cantidad De Entradas");
                Validar = true;
            }
            return Validar;
        }
    }
}
