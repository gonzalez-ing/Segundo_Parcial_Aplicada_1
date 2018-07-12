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

        private Talleres Limpiar()
        {
            Talleres taller = new Talleres();
            IdnumericUpDown.Value = 0;
            NombretextBox.Clear();

            return taller;
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
                MessageBox.Show("Debe Ingrese un ID");
                return;
            }

            int id = Convert.ToInt32(IdnumericUpDown.Value);
            Talleres taller = BLL.TalleresBLL.Buscar(id);

            if (taller != null)
            {

                NombretextBox.Text = taller.Nombre;
            }
            else
                MessageBox.Show("No se puede encontro", "Hay Problemas", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                MessageBox.Show("Llenar todos los campos marcados");
                return;
            }

            MyerrorProvider.Clear();


            if (IdnumericUpDown.Value == 0)
                paso = BLL.TalleresBLL.Guardar(LlenarClase());
            else
                paso = BLL.TalleresBLL.Modificar(LlenarClase());


            if (paso)

                MessageBox.Show("Guardado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo guardar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if (BLL.TalleresBLL.Eliminar(id))
                MessageBox.Show("Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo eliminar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Registro_Talleres_Load(object sender, EventArgs e)
        {

        }
    }
}
