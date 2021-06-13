using InventarioFod.Clases;
using System;
using System.Windows.Forms;

namespace InventarioFod.Formularios.Inventarios.estado_ordenes
{
    public partial class Estados_ordenes_produccion : Form
    {
        private Conexion_db_Mysql basedatos;
        private string rol_usuario;
        public Estados_ordenes_produccion(string rol)
        {
            InitializeComponent();
            basedatos = Conexion_db_Mysql.Get_Instance;
            Obtener_Datos_Ordenes();
            rol_usuario = rol;
            if (rol.Equals("AAI2019")|| rol.Equals("ATI2019"))
            {
                cambiar_estado.Visible = false;
            }
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (basedatos.Actuallizar_Estado_Orden_Produccion(Convert.ToInt32(label2.Text), comboBox1.SelectedItem.ToString()))
                {
                    Obtener_Datos_Ordenes();
                }
                MessageBox.Show("Orden Actualizada", "Opciones Ordenes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {

                MessageBox.Show("Error al procesar datos", "Opciones Ordenes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void Obtener_Datos_Ordenes()
        {
            dataGridView1.DataSource = basedatos.Obtener_Estados_Ordenes_produccion("PENDIENTE");
            dataGridView2.DataSource = basedatos.Obtener_Estados_Ordenes_produccion("EN PROCESO");
        }

        private void DataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            foreach (DataGridViewRow item in dataGridView1.SelectedRows)
            {
                label2.Text = item.Cells["Numero Orden"].Value.ToString();
            }
        }



        private void XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DataGridView2_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            foreach (DataGridViewRow item in dataGridView2.SelectedRows)
            {
                label2.Text = item.Cells["Numero Orden"].Value.ToString();
            }
        }
    }
}
