using Segundo_Parcial_Aplicada.IU.Registro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Segundo_Parcial_Aplicada
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void articuloToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new Registro_Mantenimiento().Show();
        }

        private void registroArticulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Registro_Articulos().Show();
        }

        private void registroTalleresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Registro_Talleres().Show();
        }

        private void registroVehiculosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Registro_Vehiculos().Show();
        }

        private void registroEntradaArticulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Registro_Entrada_Articulos().Show();
        }
    }
}
