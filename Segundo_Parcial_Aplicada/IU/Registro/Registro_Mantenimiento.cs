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

        decimal itbis = 0;
        decimal Total = 0;

        public Registro_Mantenimiento()
        {
            InitializeComponent();
            LlenarComboBox();
        }

        private void Registro_Load(object sender, EventArgs e)
        {
            DateTime fecha = Convert.ToDateTime(fechaDateTimePicker1.Text);
            fecha = fecha.AddMonths(3);

            fechaDateTimePicker1.Text = fecha.ToString();
        }
        public void Limpiar()
        {
            IdnumericUpDown.Value = 0;
            fechaDateTimePicker.Value = DateTime.Now;
            fechaDateTimePicker1.Value = DateTime.Now;
            CantidadnumericUpDown.Value = 0;
            TotalTextBox.Clear();
            ImporteTextBox.Clear();
            SubTotalTextBox.Text = 0.ToString();
            TotalTextBox.Text = 0.ToString();
            ItbisTextBox.Text = 0.ToString();
            MantenimientoDetalledataGridView.DataSource = null;

            itbis = 0;
            Total = 0;;
        }

        private int ToInt(object valor)
        {
            int retorno = 0;
            int.TryParse(valor.ToString(), out retorno);
            return retorno;

        }

        private decimal ToDecimal(object valor)
        {
            decimal retorno = 1;
            decimal.TryParse(valor.ToString(), out retorno);
            return retorno;

        }

        private void LlenarComboBox()
        {
            Repositorio<Vehiculos> vehiculo = new Repositorio<Vehiculos>(new Contexto());
            VehiculocomboBox.DataSource = vehiculo.GetList(c => true);
            VehiculocomboBox.ValueMember = "VehiculoId";
            VehiculocomboBox.DisplayMember = "Descripcion";

            Repositorio<Talleres> talleres = new Repositorio<Talleres>(new Contexto());
            TallercomboBox.DataSource = talleres.GetList(c => true);
            TallercomboBox.ValueMember = "TallerId";
            TallercomboBox.DisplayMember = "Nombre";

            Repositorio<Articulos> Entrada = new Repositorio<Articulos>(new Contexto());
            ArticulocomboBox.DataSource = Entrada.GetList(c => true);
            ArticulocomboBox.ValueMember = "ArticuloId";
            ArticulocomboBox.DisplayMember = "Descripcion";
        }

        private void LlenarCampos(Mantenimiento mantenimiento)
        {
            Limpiar();
            IdnumericUpDown.Value = mantenimiento.MantenimientoId;
            fechaDateTimePicker.Value = mantenimiento.Fecha;
            fechaDateTimePicker1.Value = mantenimiento.ProxFecha;

            MantenimientoDetalledataGridView.DataSource = mantenimiento.Detalle;

            MantenimientoDetalledataGridView.Columns["Id"].Visible = false;
            MantenimientoDetalledataGridView.Columns["MantenimientoId"].Visible = false;
            MantenimientoDetalledataGridView.Columns["TallerId"].Visible = false;
            MantenimientoDetalledataGridView.Columns["ArticulosId"].Visible = false;
            MantenimientoDetalledataGridView.Columns["Articulo"].Visible = false;
        }

        private Mantenimiento LlenaClase()
        {
            Mantenimiento mantenimiento = new Mantenimiento();

            mantenimiento.MantenimientoId = Convert.ToInt32(IdnumericUpDown.Value);
            mantenimiento.VehiculoId = Convert.ToInt32(VehiculocomboBox.SelectedValue);
            mantenimiento.Fecha = fechaDateTimePicker.Value;
            mantenimiento.ProxFecha = fechaDateTimePicker1.Value;



            foreach (DataGridViewRow item in MantenimientoDetalledataGridView.Rows)
            {

                mantenimiento.AgregarDetalle(ToInt(item.Cells["Id"].Value),
                mantenimiento.MantenimientoId,
                ToInt(item.Cells["TallerId"].Value),
                ToInt(item.Cells["ArticulosId"].Value),
                Convert.ToString(item.Cells["Articulo"].Value),
                ToDecimal(item.Cells["Cantidad"].Value),
                ToDecimal(item.Cells["Precio"].Value),
                ToDecimal(item.Cells["Importe"].Value));
            }
            return mantenimiento;
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


        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(IdnumericUpDown.Value);

            Mantenimiento mantenimiento = BLL.MantenimientoBLL.Buscar(id);


            if (mantenimiento != null)
            {
                LlenarCampos(mantenimiento);

            }
            else
                MessageBox.Show("No se puede encontrar!", "Hay Problemas",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Agregarbutton_Click(object sender, EventArgs e)
        {
            List<Mantenimiento_Detalle> detalle = new List<Mantenimiento_Detalle>();

            if (MantenimientoDetalledataGridView.DataSource != null)
            {
                detalle = (List<Mantenimiento_Detalle>)MantenimientoDetalledataGridView.DataSource;
            }

            foreach (var item in BLL.ArticuloBLL.GetList(x => x.Inventario < CantidadnumericUpDown.Value))
            {

                MessageBox.Show("No hay Nada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(ImporteTextBox.Text))
            {
                MessageBox.Show("Debe Llenar La Cantidad", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                detalle.Add(
                    new Mantenimiento_Detalle(id: 0,
                    mantenimientoId: (int)Convert.ToInt32(IdnumericUpDown.Value),
                    tallerId: (int)TallercomboBox.SelectedValue,
                       articulosId: (int)ArticulocomboBox.SelectedValue,
                            articulo: (string)BLL.ArticuloBLL.RetornarDescripcion(ArticulocomboBox.Text),
                        cantidad: Convert.ToDecimal(CantidadnumericUpDown.Value),
                        precio: Convert.ToDecimal(PrecioTextBox.Text),
                        importe: Convert.ToDecimal(ImporteTextBox.Text)));


                MantenimientoDetalledataGridView.DataSource = null;
                MantenimientoDetalledataGridView.DataSource = detalle;


                MantenimientoDetalledataGridView.Columns["Id"].Visible = false;
                MantenimientoDetalledataGridView.Columns["MantenimientoId"].Visible = false;
                MantenimientoDetalledataGridView.Columns["TallerId"].Visible = false;
                MantenimientoDetalledataGridView.Columns["ArticulosId"].Visible = false;
                MantenimientoDetalledataGridView.Columns["articulo"].Visible = false;
            }

            decimal subtotal = 0;

            foreach (var item in detalle)
            {
                subtotal += item.Importe;

            }

            SubTotalTextBox.Text = subtotal.ToString();

            itbis = BLL.MantenimientoBLL.CalcularItbis(Convert.ToDecimal(SubTotalTextBox.Text));

            ItbisTextBox.Text = itbis.ToString();

            Total = BLL.MantenimientoBLL.Total(Convert.ToDecimal(SubTotalTextBox.Text), Convert.ToDecimal(ItbisTextBox.Text));

            TotalTextBox.Text = Total.ToString();
            itbis = BLL.MantenimientoBLL.CalcularItbis(Convert.ToDecimal(SubTotalTextBox.Text));

            ItbisTextBox.Text = itbis.ToString();

            Total = BLL.MantenimientoBLL.Total(Convert.ToDecimal(SubTotalTextBox.Text), Convert.ToDecimal(ItbisTextBox.Text));

            TotalTextBox.Text = Total.ToString();

        }
            private void Nuevobutton_Click(object sender, EventArgs e)
            {
                Limpiar();
            }

            private void Guardarbutton_Click(object sender, EventArgs e)
            {

            Mantenimiento mantenimiento = LlenaClase();
            bool Paso = false;

            if (IdnumericUpDown.Value == 0)
            {
                Paso = BLL.MantenimientoBLL.Guardar(mantenimiento);
            }
            else
            {
                Paso = BLL.MantenimientoBLL.Modificar(mantenimiento);
            }

            if (Paso)
            {
                Limpiar();
                MessageBox.Show("Guardado!!", "Exito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("No se pudo guardar!!", "Fallo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        private void Eliminarbutton_Click(object sender, EventArgs e)
        {

            int id = Convert.ToInt32(IdnumericUpDown.Value);
            if (BLL.MantenimientoBLL.Eliminar(id))
            {
                MessageBox.Show("Eliminado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }
            else
                MessageBox.Show("No se pudo eliminar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void CantidadnumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            ImporteTextBox.Text = BLL.MantenimientoBLL.CalcularImporte(Convert.ToDecimal(PrecioTextBox.Text), Convert.ToInt32(CantidadnumericUpDown.Value)).ToString();
        }

        private void fechaDateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            fechaDateTimePicker.Value = fechaDateTimePicker.Value;


            DateTime fecha = Convert.ToDateTime(fechaDateTimePicker1.Text);
            fecha = fecha.AddMonths(3);

            fechaDateTimePicker1.Text = fecha.ToString();
        }

        private void RemoverBoton_Click(object sender, EventArgs e)
        {
            Mantenimiento mantenimiento = new Mantenimiento();
            if (MantenimientoDetalledataGridView.Rows.Count > 0 && MantenimientoDetalledataGridView.CurrentRow != null)
            {

                List<Mantenimiento_Detalle> detalle = (List<Mantenimiento_Detalle>)MantenimientoDetalledataGridView.DataSource;


                detalle.RemoveAt(MantenimientoDetalledataGridView.CurrentRow.Index);

                decimal subtotal = 0;

                foreach (var item in detalle)
                {
                    subtotal -= item.Importe;
                }

                subtotal *= (-1);
                SubTotalTextBox.Text = subtotal.ToString();

                itbis = BLL.MantenimientoBLL.CalcularItbis(Convert.ToDecimal(SubTotalTextBox.Text));
                ItbisTextBox.Text = itbis.ToString();

                Total = BLL.MantenimientoBLL.Total(Convert.ToDecimal(SubTotalTextBox.Text), Convert.ToDecimal(ItbisTextBox.Text));

                TotalTextBox.Text = Total.ToString();

                MantenimientoDetalledataGridView.DataSource = null;
                MantenimientoDetalledataGridView.DataSource = detalle;
            }
        }
    }
}