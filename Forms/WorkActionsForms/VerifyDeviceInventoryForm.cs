using SystemIventory.Classes;
using System;
using System.Windows.Forms;

namespace SystemIventory.Forms.Acciones
{
    public partial class VerifyDeviceInventoryForm : Form
    {
        DataOperationDocument _dataOperationDocument;
        public VerifyDeviceInventoryForm()
        {
            InitializeComponent();
            _dataOperationDocument = new DataOperationDocument(dataGridView1);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _dataOperationDocument.GetIdDeviceInWorkAction(textBox1.Text, "Acciones");
            total_equipos.Text= Convert.ToString(dataGridView1.RowCount - 1);
        }

        

        private void t2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
