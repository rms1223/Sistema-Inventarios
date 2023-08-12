using SystemIventory.Classes;
using System;
using System.Windows.Forms;
using SystemInventory.Classes.IModels;
using SystemInventory.Classes.Models;

namespace SystemIventory.Forms.InventoriesForms
{
    public partial class ModelMaterialsForm : Form
    {
        private Label _idText;
        private Label _modelName;
        public ModelMaterialsForm(Label tipo, Label nom)
        {
            InitializeComponent();
            IDataTableModel dataTableModel = DataTableModel.Get_Instance;
            dataGridView1.DataSource = dataTableModel.GetAllTypeMaterials().Result;
            _idText = tipo;
            _modelName = nom;
        }

        private void XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            foreach (DataGridViewRow item in dataGridView1.SelectedRows)
            {
                _idText.Text = item.Cells["codigo"].Value.ToString();
                _modelName.Text = item.Cells["descripcion"].Value.ToString();
            }
            this.Close();
        }
    }
}
