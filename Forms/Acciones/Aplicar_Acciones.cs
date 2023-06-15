using InventarioFod.Clases;
using System;
using System.Windows.Forms;

namespace InventarioFod.Formularios.Acciones
{
    public partial class Aplicar_Acciones : Form
    {
        Manejo_Documento_Excel manejo_datos;
        public Aplicar_Acciones()
        {
            InitializeComponent();
            txt_accion.Enabled = false;
            numericUpDown1.Maximum = 10000000;
            manejo_datos = new Manejo_Documento_Excel(dataGridView1);
            foreach (var item in manejo_datos.Obtener_Ubicaciones())
            {
                comboBox1.Items.Add(item);
            }
            
            ToolTip btn_aplicar = new ToolTip();
            btn_aplicar.SetToolTip(button2, "Aplicar Acción");
        }

        private void t2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Aplicar_Acciones_Load(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            foreach (DataGridViewRow item in dataGridView1.SelectedRows)
            {
                txt_accion.Text = item.Cells["Accion"].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txt_accion.Text))
            {
                manejo_datos.Aplicar_Acciones(Convert.ToInt32(txt_accion.Text), comboBox1.SelectedItem.ToString());
                MessageBox.Show("Estado Actualizado", "Opciones Acciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Debe seleccionar una acción", "Opciones Acciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            manejo_datos.Obtener_Estado_Acciones(Convert.ToInt32(numericUpDown1.Value));
        }
    }
}

