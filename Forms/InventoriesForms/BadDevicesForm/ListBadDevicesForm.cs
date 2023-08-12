using SystemIventory.Classes;
using System;
using System.Windows.Forms;
using SystemInventory.Classes.IModels;
using SystemInventory.Classes.Models;

namespace SystemIventory.Forms.InventoriesForms.equipos_malos
{
    public partial class ListBadDevicesForm : Form
    {
        private IDataBaseRepository _dataBaseRepository;
        private IDataTableModel _dataTableModel;
        public ListBadDevicesForm()
        {
            InitializeComponent();
            _dataBaseRepository = DataBaseRepository.Get_Instance;
            _dataTableModel = DataTableModel.Get_Instance;
            dataGridView1.DataSource = _dataTableModel.GetAllDeviceDamage().Result;

        }

        private void XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            foreach (DataGridViewRow item in dataGridView1.SelectedRows)
            {
                placa_txt.Text = item.Cells[VariablesName.Placa].Value.ToString();
                serie_txt.Text = item.Cells[VariablesName.Serial].Value.ToString();
                dano_txt.Text = item.Cells["Daños"].Value.ToString();



            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                dataGridView1.AllowUserToAddRows = false;
                foreach (DataGridViewRow item in dataGridView1.Rows)
                {
                    string placa = placa_txt.Text;
                    string serie = serie_txt.Text;
                    string dano = dano_txt.Text;
                    string estado = comboBox1.SelectedItem.ToString();
                    _dataBaseRepository.SaveNewDamage(placa, serie, dano, estado);
                }
                dataGridView1.AllowUserToAddRows = true;
                MessageBox.Show("Datos Guardados", "Opciones Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = _dataTableModel.GetAllDeviceDamage().Result;
            }
            else
            {
                MessageBox.Show("Debe seleccionar estado", "Opciones Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (placa_search.Text.Length == 6)
            {
                btn_search.Focus();
            }
        }

        private void Btn_search_Click(object sender, EventArgs e)
        {
            SearchCodeInDatagridview(placa_search.Text);
        }
        private void SearchCodeInDatagridview(string codigo)
        {

            bool estado = false;
            dataGridView1.AllowUserToAddRows = false;
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                if (item.Cells[VariablesName.Placa].Value.Equals(codigo))
                {
                    dataGridView1.Rows[item.Index].DefaultCellStyle.BackColor = System.Drawing.Color.LightSkyBlue;
                    dataGridView1.FirstDisplayedScrollingRowIndex = item.Index;
                    //item.Selected = true;
                    estado = true;
                    break;
                }
            }
            dataGridView1.AllowUserToAddRows = true;
            if (!estado)
            {
                MessageBox.Show("No existe la Placa: " + codigo, "Equipos Dañados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                placa_search.Text = string.Empty;
            }
        }
    }
}
