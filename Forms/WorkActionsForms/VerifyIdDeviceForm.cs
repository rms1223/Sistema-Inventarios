using SystemIventory.Classes;
using System;
using System.Windows.Forms;

namespace SystemIventory.Forms.Acciones
{
    public partial class VerifyIdDeviceForm : Form
    {
        DataOperationDocument _dataOperationDocument;
        public VerifyIdDeviceForm()
        {
            InitializeComponent();
            _dataOperationDocument = new DataOperationDocument(data_revision);
        }

        private void XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CargarOrdenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchWorkAction buscar_orden = new SearchWorkAction(this);
            buscar_orden.Show();
            
        }

        public void Cargar_OrdenTrabajo(int orden)
        {
            _dataOperationDocument.GetIdDeviceInWorkAction(orden.ToString(), "Acciones");
            total_equipos.Text=Convert.ToString(data_revision.RowCount - 1);
            _dataOperationDocument.DataChanges(data_eliminadas, data_agregadas);
            _dataOperationDocument.GetChanges(orden);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SearchCodeInDatagridview(textBox1.Text);

            textBox1.Focus();
        }

        private void SearchCodeInDatagridview(string codigo)
        {
            
            bool estado = false;
            data_revision.AllowUserToAddRows = false;
            foreach (DataGridViewRow item in data_revision.Rows)
            {
                if (item.Cells[VariablesName.Placa].Value.Equals(codigo))
                {
                    data_revision.Rows[item.Index].DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
                    data_revision.FirstDisplayedScrollingRowIndex = item.Index;
                    //item.Selected = true;
                    estado = true;
                    break;
                }
            }
            data_revision.AllowUserToAddRows = true;
            if (!estado)
            {
                MessageBox.Show("No existe la Placa" + codigo, "Revision de Placas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                textBox1.Text = String.Empty;
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.TextLength >=6)
            {
                button1.Focus();
            }
        }
    }
}
