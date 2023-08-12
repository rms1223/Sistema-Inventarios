using SystemIventory.Classes;
using System;
using System.Windows.Forms;
using SystemInventory.Classes.IModels;
using SystemInventory.Classes.Models;

namespace SystemIventory.Forms.Acciones.Materiales
{
    public partial class SearchOrderMaterialsForm : Form
    {
        //private MysqlDatabaseRepository _dataBaseRepository;
        private IDataTableModel _dataTableModel;
        private TextBox _ordenSelect;
        public SearchOrderMaterialsForm(TextBox orden)
        {
            InitializeComponent();
            _dataTableModel = DataTableModel.Get_Instance;
            dataGridView1.DataSource = _dataTableModel.GetWorkActionMaterials().Result;
            _ordenSelect = orden;
        }

        private void XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //GetWorkActionMaterials();
        }

        private void DataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            foreach (DataGridViewRow item in dataGridView1.SelectedRows)
            {
                _ordenSelect.Text = item.Cells["codigo"].Value.ToString();

            }
            this.Close();
        }

    }
}
