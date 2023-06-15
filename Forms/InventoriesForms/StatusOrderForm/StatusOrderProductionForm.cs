﻿using SystemIventory.Classes;
using System;
using System.Windows.Forms;

namespace SystemIventory.Forms.InventoriesForms.estado_ordenes
{
    public partial class StatusOrderProductionForm : Form
    {
        private ConnectionMysqlDatabase _mysqlConnectionDatabase;
        private string rol_usuario;
        public StatusOrderProductionForm(string rol)
        {
            InitializeComponent();
            _mysqlConnectionDatabase = ConnectionMysqlDatabase.Get_Instance;
            GetDataOrder();
            rol_usuario = rol;
            if (rol.Equals("AAI2019")|| rol.Equals("ATI2019"))
            {
                cambiar_estado.Visible = false;
            }
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (_mysqlConnectionDatabase.UpdateStatusWorkActionInProduction(Convert.ToInt32(label2.Text), comboBox1.SelectedItem.ToString()))
                {
                    GetDataOrder();
                }
                MessageBox.Show("Orden Actualizada", "Opciones Ordenes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {

                MessageBox.Show("Error al procesar datos", "Opciones Ordenes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void GetDataOrder()
        {
            dataGridView1.DataSource = _mysqlConnectionDatabase.GetStatusWorkActionInProduction("PENDIENTE");
            dataGridView2.DataSource = _mysqlConnectionDatabase.GetStatusWorkActionInProduction("EN PROCESO");
        }

        private void DataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            foreach (DataGridViewRow item in dataGridView1.SelectedRows)
            {
                label2.Text = item.Cells["Numero Orden"].Value.ToString();
            }
        }



        private void XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DataGridView2_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            foreach (DataGridViewRow item in dataGridView2.SelectedRows)
            {
                label2.Text = item.Cells["Numero Orden"].Value.ToString();
            }
        }
    }
}