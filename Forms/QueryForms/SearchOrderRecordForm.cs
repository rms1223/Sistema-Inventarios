using SystemIventory.Classes;
using System;
using System.Windows.Forms;

namespace SystemIventory.Forms.Consultas
{
    public partial class SearchOrderRecordForm : Form
    {
        TextBox _codigoInstitucion;
        TextBox _order;
        DataOperationDocument _dataOperationDocument;
        public SearchOrderRecordForm(TextBox codigo, TextBox orden_pedido)
        {
            
            InitializeComponent();
            _codigoInstitucion = codigo;
            _order = orden_pedido;
            _dataOperationDocument = new DataOperationDocument(data);
            _dataOperationDocument.SearchIdOrder();

        }

        private void XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Data_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            foreach (DataGridViewRow item in data.SelectedRows)
            {
                if (!String.IsNullOrEmpty(item.Cells["Codigo_Institucion"].Value.ToString()))
                {
                    _codigoInstitucion.Text = item.Cells["Codigo_Institucion"].Value.ToString();
                    _order.Text = item.Cells["id_orden"].Value.ToString();
                }

            }
        }
    }
}
