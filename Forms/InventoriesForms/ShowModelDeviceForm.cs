using SystemIventory.Classes;
using System;
using System.Windows.Forms;

namespace SystemIventory.Forms.InventoriesForms
{
    public partial class ShowModelDeviceForm : Form
    {
        private Label _idText;
        private Label _modelName;
        public ShowModelDeviceForm(Label tipo, Label nom)
        {
            InitializeComponent();
            ConnectionMysqlDatabase db = ConnectionMysqlDatabase.Get_Instance;
            dataGridView1.DataSource = db.GetAllTypeDevice();
            _idText = tipo;
            _modelName = nom;
        }
        private void DataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            foreach (DataGridViewRow item in dataGridView1.SelectedRows)
            {
                _idText.Text = item.Cells["codigo_modelo"].Value.ToString();
                _modelName.Text = item.Cells["tipo_equipo"].Value.ToString()+" - "+ item.Cells["modelo"].Value.ToString();
            }
            this.Close();
        }

        private void XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
