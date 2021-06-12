using InventarioFod.Clases;
using System;
using System.Windows.Forms;

namespace InventarioFod.Formularios.Inventarios
{
    public partial class Modelos_Equipos : Form
    {
        private Label id_text;
        private Label nombre_mod;
        public Modelos_Equipos(Label tipo, Label nom)
        {
            InitializeComponent();
            Conexion_db_Mysql db = Conexion_db_Mysql.Get_Instance;
            dataGridView1.DataSource = db.Get_Tipos_Equipos();
            id_text = tipo;
            nombre_mod = nom;
        }
        private void DataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            foreach (DataGridViewRow item in dataGridView1.SelectedRows)
            {
                id_text.Text = item.Cells["codigo_modelo"].Value.ToString();
                nombre_mod.Text = item.Cells["tipo_equipo"].Value.ToString()+" - "+ item.Cells["modelo"].Value.ToString();
            }
            this.Close();
        }

        private void XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
