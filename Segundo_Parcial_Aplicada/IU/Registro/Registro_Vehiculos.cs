﻿using Segundo_Parcial_Aplicada.Entidades;
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
    public partial class Registro_Vehiculos : Form
    {
        public Registro_Vehiculos()
        {
            InitializeComponent();
        }

        private Vehiculos LlenarClase()
        {
            Vehiculos vehiculo = new Vehiculos();

            vehiculo.VehiculoId = Convert.ToInt32(IdnumericUpDown.Value);
            vehiculo.Descripcion = DescripciontextBox.Text;
            vehiculo.MantenimientoTotal = Convert.ToInt32(IdnumericUpDown.Value);
            return vehiculo;
        }

        private Vehiculos Limpiar()
        {
            Vehiculos vehiculo = new Vehiculos();
            IdnumericUpDown.Value = 0;
            DescripciontextBox.Clear();
            MantenimientotextBox.Clear();

            return vehiculo;
        }

        private bool Validar(int validar) 
        {

            bool paso = false;
            if (validar == 1 && IdnumericUpDown.Value == 0)
            {
                MyerrorProvider.SetError(IdnumericUpDown, "Debe Ingresar Un ID");
                paso = true;

            }
            if (validar == 2 && DescripciontextBox.Text == string.Empty)
            {
                MyerrorProvider.SetError(DescripciontextBox, "Debe Ingresar Una Descripcion");
                paso = true;
            }
            return paso;

        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            MyerrorProvider.Clear();

            if (Validar(1))
            {
                MessageBox.Show("Debe Ingresar un ID");
                return;
            }

            int id = Convert.ToInt32(IdnumericUpDown.Value);
            Vehiculos vehiculo = BLL.VehiculoBLL.Buscar(id);

            if (vehiculo != null)
            {

                DescripciontextBox.Text = vehiculo.Descripcion;
                MantenimientotextBox.Text = vehiculo.MantenimientoTotal.ToString();

            }
            else
                MessageBox.Show("No se puede encontrar", "Hay Problemas", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                MessageBox.Show("Debe Llenar todos los campos");
                return;
            }

            MyerrorProvider.Clear();


            if (IdnumericUpDown.Value == 0)
                paso = BLL.VehiculoBLL.Guardar(LlenarClase());
            else
                paso = BLL.VehiculoBLL.Modificar(LlenarClase());


            if (paso)

                MessageBox.Show("Guardado", "Excelente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se puede guardar", "Hay Problemas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Limpiar();
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            MyerrorProvider.Clear();

            if (Validar(1))
            {
                MessageBox.Show("Debe Ingresar un ID");
                return;
            }

            int id = Convert.ToInt32(IdnumericUpDown.Value);

            if (BLL.VehiculoBLL.Eliminar(id))
                MessageBox.Show("Eliminado", "Excelente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se puede eliminar", "Hay Problemas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Registro_Vehiculos_Load(object sender, EventArgs e)
        {

        }
    }
}
