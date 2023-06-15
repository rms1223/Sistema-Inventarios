using SystemIventory.Classes;
using System;
using System.Windows.Forms;

namespace SystemIventory.Forms.Acciones.Materiales
{
    public partial class SearchOrderMaterialsForm : Form
    {
        private ConnectionMysqlDatabase _mysqlConnectionDatabase;
        private TextBox _ordenSelect;
        public SearchOrderMaterialsForm(TextBox orden)
        {
            InitializeComponent();
            _mysqlConnectionDatabase = ConnectionMysqlDatabase.Get_Instance;
            dataGridView1.DataSource = _mysqlConnectionDatabase.GetWorkActionMaterials();
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
