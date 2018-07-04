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
    public partial class Registro_Talleres : Form
    {
        public Registro_Talleres()
        {
            InitializeComponent();
        }

        private Talleres LlenarClase()
        {
            Talleres talleres = new Talleres();

            talleres.TallerId = Convert.ToInt32(IdnumericUpDown.Value);
            talleres.Nombre = NombretextBox.Text;
            return talleres;
        }

        private bool Validar(int validar)
        {

            bool paso = false;
            if (validar == 1 && IdnumericUpDown.Value == 0)
            {
                MyerrorProvider.SetError(IdnumericUpDown, "Debe Ingresar Un ID");
                paso = true;

            }
            if (validar == 2 && NombretextBox.Text == string.Empty)
            {
                MyerrorProvider.SetError(NombretextBox, "Debe Ingresar Un Nombre");
                paso = true;
            }
            return paso;

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
            Talleres talleres = BLL.TalleresBLL.Buscar(id);

            if (talleres != null)
            {

                NombretextBox.Text = talleres.Nombre;
            }
            else
                MessageBox.Show("No Se Encontro", "Hay Prblemas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            IdnumericUpDown.Value = 0;
            NombretextBox.Clear();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            if (Validar(2))
            {

                MessageBox.Show("Debe Llenar Todos Los Campos");
                return;
            }

            MyerrorProvider.Clear();

            if (IdnumericUpDown.Value == 0)
                paso = BLL.TalleresBLL.Guardar(LlenarClase());
            else
                paso = BLL.TalleresBLL.Modificar(LlenarClase());

            if (paso)

                MessageBox.Show("Guardado", "Excelente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No Se Puede Guardar", "Hay Problemas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            MyerrorProvider.Clear();

            if (Validar(1))
            {
                MessageBox.Show("Debe Ingresar Un ID");
                return;
            }

            int id = Convert.ToInt32(IdnumericUpDown.Value);

            if (BLL.TalleresBLL.Eliminar(id))
                MessageBox.Show("Eliminado", "Excelente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No Se Puede Eliminar", "Hay Problemas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Registro_Talleres_Load(object sender, EventArgs e)
        {

        }
    }
}
