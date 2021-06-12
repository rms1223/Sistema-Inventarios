using InventarioFod.Clases;
using System;
using System.Windows.Forms;

namespace InventarioFod.Formularios.Inventarios
{
    public partial class Modelo_Materiales : Form
    {
        private Label id_text;
        private Label nombre_mod;
        public Modelo_Materiales(Label tipo, Label nom)
        {
            InitializeComponent();
            Conexion_db_Mysql db = Conexion_db_Mysql.Get_Instance;
            dataGridView1.DataSource = db.Get_Tipos_Materiales();
            id_text = tipo;
            nombre_mod = nom;
        }

        private void XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            foreach (DataGridViewRow item in dataGridView1.SelectedRows)
            {
                id_text.Text = item.Cells["codigo"].Value.ToString();
                nombre_mod.Text = item.Cells["descripcion"].Value.ToString();
            }
            this.Close();
        }
    }
}
