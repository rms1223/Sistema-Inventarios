using InventarioFod.Clases;
using System;
using System.Windows.Forms;

namespace InventarioFod.Formularios.Consultas
{
    public partial class Buscar_Registro_Pedidos : Form
    {
        TextBox codigo_institucion;
        TextBox orden;
        Manejo_Documento_Excel documento;
        public Buscar_Registro_Pedidos(TextBox codigo, TextBox orden_pedido)
        {
            
            InitializeComponent();
            codigo_institucion = codigo;
            orden = orden_pedido;
            documento = new Manejo_Documento_Excel(data);
            documento.Buscar_pedido_orden();

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
                    codigo_institucion.Text = item.Cells["Codigo_Institucion"].Value.ToString();
                    orden.Text = item.Cells["id_orden"].Value.ToString();
                }

            }
        }
    }
}
