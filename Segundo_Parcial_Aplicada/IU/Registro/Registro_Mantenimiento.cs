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
            LlenarComboBox();
        }

        private void Registro_Load(object sender, EventArgs e)
        {

        }

        private void LlenarComboBox()
        {
            Repositorio<Vehiculos> repositorio = new Repositorio<Vehiculos>(new Contexto());
            VehiculocomboBox.DataSource = repositorio.GetList(c => true);
            VehiculocomboBox.ValueMember = "VehiculoId";
            VehiculocomboBox.ValueMember = "Taller";
            VehiculocomboBox.DisplayMember = "Descripcion";
        }

        private void LlenarCampos(Mantenimiento mantenimiento)
        {
            IdnumericUpDown.Value = mantenimiento.MantenimientoId;
            fechaDateTimePicker.Value = mantenimiento.Fecha;
            DetalledataGridView.DataSource = mantenimiento.Detalle;

            DetalledataGridView.Columns["Id"].Visible = false;
            DetalledataGridView.Columns["MantenimientoId"].Visible = false;
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
                    ToInt(item.Cells["Precio"].Value),
                    ToInt(item.Cells["Importe"].Value),
                    ToInt(item.Cells["SubTotal"].Value),
                    ToInt(item.Cells["Itbis"].Value),
                    ToInt(item.Cells["Total"].Value)
                  );
            }
            return mantenimiento;
        }

        private void FiltrarPrecio()
        {
            Repositorio<Articulos> repositorio = new Repositorio<Articulos>(new Contexto());
            List<Articulos> articulo = repositorio.GetList(a => a.Descripcion == ArticulocomboBox.Text);
            foreach (var item in articulo)
            {
                PrecionumericUpDown.Value = item.Precio;
            }
        }

        private int ToInt(object valor)
        {
            int retorno = 0;

            int.TryParse(valor.ToString(), out retorno);

            return retorno;
        }

        private bool HayErrores()
        {
            bool HayErrores = false;

            if (String.IsNullOrWhiteSpace(ArticulocomboBox.Text))
            {
                MyerrorProvider.SetError(ArticulocomboBox,
                    "No Debes Dejar El Articulo Vacio");
                HayErrores = true;
            }

            return HayErrores;
        }

        private void ArticulocomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarPrecio();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(IdnumericUpDown.Value);
            Mantenimiento mantenimientos = BLL.MantenimientoBLL.Buscar(id);

            if (mantenimientos != null)
            {
                LlenarCampos(mantenimientos);
            }
            else
                MessageBox.Show("No se encontro!", "Fallo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Agregarbutton_Click(object sender, EventArgs e)
        {
            List<Mantenimiento_Detalle> detalle = new List<Mantenimiento_Detalle>();

            if (DetalledataGridView.DataSource != null)
            {
                detalle = (List<Mantenimiento_Detalle>)DetalledataGridView.DataSource;
            }

            detalle.Add(
                new Mantenimiento_Detalle(
                    id: 0,
                    mantenimientoId: (int)IdnumericUpDown.Value,
                    vehiculoId: (int)VehiculocomboBox.SelectedValue,
                    articulo: (string)ArticulocomboBox.Text,
                    cantidad: (int)CantidadnumericUpDown.Value,
                    precio: (int)PrecionumericUpDown.Value,
                    importe: (int)ImportenumericUpDown.Value,
                    Subtotal: (int)SubTotalnumericUpDown.Value,
                    itbis: (int)ItbisnumericUpDown.Value,
                    total: (int)TotalnumericUpDown.Value
                ));

            DetalledataGridView.DataSource = null;
            DetalledataGridView.DataSource = detalle;
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {

            IdnumericUpDown.Value = 0;
            fechaDateTimePicker.Value = DateTime.Now;
            CantidadnumericUpDown.Value = 0;
            PrecionumericUpDown.Value = 0;
            ImportenumericUpDown.Value = 0;
            TotalnumericUpDown.Value = 0;
            SubTotalnumericUpDown.Value = 0;
            ItbisnumericUpDown.Value = 0;

            DetalledataGridView.DataSource = null;
            MyerrorProvider.Clear();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            Mantenimiento mantenimiento;
            bool Paso = false;

            if (HayErrores())
            {
                MessageBox.Show("Favor Revise Todos Los Campos", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            mantenimiento = LlenaClase();


            if (IdnumericUpDown.Value == 0)
                Paso = BLL.MantenimientoBLL.Guardar(mantenimiento);

            Paso = BLL.MantenimientoBLL.Modificar(mantenimiento);

            if (Paso)
            {
                Nuevobutton.PerformClick();
                MessageBox.Show("Guardado!!", "Excelente",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("No Se Puede Guardar!!", "Hay Problemas",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(IdnumericUpDown.Value);

            if (BLL.MantenimientoBLL.Eliminar(id))
                MessageBox.Show("Eliminado!!", "Excelente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No Se Puede Eliminar!!", "Hay Problemas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
