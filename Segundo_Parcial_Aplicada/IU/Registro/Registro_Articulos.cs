using Segundo_Parcial_Aplicada.BLL;
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

            Articulos articulos = new Articulos();





            articulos.ArticuloId = Convert.ToInt32(IdnumericUpDown.Value);
            articulos.Descripcion = DescripciontextBox.Text;
            articulos.Costo = Decimal.Parse(CostotextBox.Text);
            articulos.Precio = Decimal.Parse(PreciotextBox.Text);
            articulos.Ganancia = int.Parse(GananciatextBox.Text);
            articulos.Inventario = int.Parse(InventariotextBox.Text);

            return articulos;



        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {

        }

        private void IdnumericUpDown_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {

        }

        private void LlenarCampo(int id)
        {


        }
    }
}