using Segundo_Parcial_Aplicada.IU.Consultas;
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
            new Registro().Show();
        }

        private void articulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Consulta().Show();
        }
    }
}
