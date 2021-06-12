using InventarioFod.Clases;
using System;
using System.Windows.Forms;

namespace InventarioFod.Formularios.Acciones.Materiales
{
    public partial class Buscar_Orden_Materiales : Form
    {
        private Conexion_db_Mysql base_datos;
        private TextBox orden_select;
        public Buscar_Orden_Materiales(TextBox orden)
        {
            InitializeComponent();
            base_datos = Conexion_db_Mysql.Get_Instance;
            dataGridView1.DataSource = base_datos.Obtener_ordenes_materiales();
            orden_select = orden;
        }

        private void XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //Obtener_ordenes_materiales();
        }

        private void DataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            foreach (DataGridViewRow item in dataGridView1.SelectedRows)
            {
                orden_select.Text = item.Cells["codigo"].Value.ToString();

            }
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {

        }
    }
}
