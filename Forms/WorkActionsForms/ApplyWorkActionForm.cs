using SystemIventory.Classes;
using System;
using System.Windows.Forms;

namespace SystemIventory.Forms.Acciones
{
    public partial class Aplicar_Acciones : Form
    {
        DataOperationDocument _dataOperationDocument;
        public Aplicar_Acciones()
        {
            InitializeComponent();
            txt_accion.Enabled = false;
            numericUpDown1.Maximum = 10000000;
            _dataOperationDocument = new DataOperationDocument(dataGridView1);
            foreach (var item in _dataOperationDocument.GetAllLocationsInDatabase())
            {
                comboBox1.Items.Add(item);
            }
            
            ToolTip btn_aplicar = new ToolTip();
            btn_aplicar.SetToolTip(button2, "Aplicar Acción");
        }

        private void T2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void DataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            foreach (DataGridViewRow item in dataGridView1.SelectedRows)
            {
                txt_accion.Text = item.Cells["Accion"].Value.ToString();
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txt_accion.Text))
            {
                _dataOperationDocument.ApplyWorkActionInDatabase(Convert.ToInt32(txt_accion.Text), comboBox1.SelectedItem.ToString());
                MessageBox.Show("Estado Actualizado", "Opciones Acciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _dataOperationDocument.GetStatusWorkActionFromDatabase(Convert.ToInt32(numericUpDown1.Value));
            }
            else
            {
                MessageBox.Show("Debe seleccionar una acción", "Opciones Acciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        private void Button1_Click(object sender, EventArgs e)
        {
            _dataOperationDocument.GetStatusWorkActionFromDatabase(Convert.ToInt32(numericUpDown1.Value));
        }
    }
}

