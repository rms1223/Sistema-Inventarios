using InventarioFod.Clases;
using System;
using System.Windows.Forms;

namespace InventarioFod.Formularios.Consultas.inventarios_materiales
{
    public partial class Inventario_materiales : Form
    {
        private Conexion_db_Mysql base_datos;
        public Inventario_materiales()
        {
            InitializeComponent();
            base_datos = Conexion_db_Mysql.Get_Instance;
            base_datos.Verificar_Conexion();
            dataGridView1.DataSource = base_datos.Get_Inventario_Materiales();
        }

        private void XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
