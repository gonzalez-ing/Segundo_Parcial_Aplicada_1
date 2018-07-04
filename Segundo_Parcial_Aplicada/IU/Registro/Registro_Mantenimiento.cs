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
    public partial class Registro_Mantenimiento : Form
    {
        public Registro_Mantenimiento()
        {
            InitializeComponent();
        }

        private void Registro_Load(object sender, EventArgs e)
        {

        }

        private void LlenarComboBox()
        {
            Repositorio<Vehiculos> repositorio = new Repositorio<Vehiculos>(new Contexto());
            VehiculocomboBox.DataSource = repositorio.GetList(c => true);
            VehiculocomboBox.ValueMember = "VehiculoId";
            VehiculocomboBox.DisplayMember = "Descripcion";
        }

        private Mantenimiento LlenaClase()
        {
            Mantenimiento mantenimiento = new Mantenimiento();

            mantenimiento.MantenimientoId = Convert.ToInt32(IdnumericUpDown.Value);
            mantenimiento.Fecha = fechaDateTimePicker.Value;

            foreach (DataGridViewRow item in DetalledataGridView.Rows)
            {
                mantenimiento.AgregarDetalle(
                    ToInt(item.Cells["id"].Value),
                    ToInt(item.Cells["MantenimientoId"].Value),
                    ToInt(item.Cells["VehiculoId"].Value),
                    item.Cells["Articulo"].ToString(),
                    ToInt(item.Cells["Cantidad"].Value),
                    ToInt(item.Cells["Precio"].Value)
                  );
            }
            return mantenimiento;
        }

        private int ToInt(object valor)
        {
            int retorno = 0;

            int.TryParse(valor.ToString(), out retorno);

            return retorno;
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {


        }
    }
}
