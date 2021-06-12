using InventarioFod.Clases;
using System;
using System.Windows.Forms;

namespace InventarioFod.Formularios.Acciones
{
    public partial class Verificar_Equipos : Form
    {
        Manejo_Documento_Excel manejo_de_datos;
        public Verificar_Equipos()
        {
            InitializeComponent();
            manejo_de_datos = new Manejo_Documento_Excel(dataGridView1);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            manejo_de_datos.Obtener_equipo_acciones(textBox1.Text, "Acciones");
        }

        

        private void t2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
