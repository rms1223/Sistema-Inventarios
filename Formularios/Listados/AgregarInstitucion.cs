using InventarioFod.Clases;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace InventarioFod
{
    public partial class AgregarInstitucion : Form
    {

        public AgregarInstitucion()
        {
            InitializeComponent();
        }

        private void t1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            label3.Image = Image.FromFile(Path.Combine(Application.StartupPath, @"Imagenes\Save_enter.png"));
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Manejo_Documento_Excel manejo_de_datos = new Manejo_Documento_Excel();
            manejo_de_datos.Insertar_Institucion(new Clases.Entidades.Institucion(textBox1.Text, textBox2.Text));
            this.Close();
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.Image = Image.FromFile(Path.Combine(Application.StartupPath, @"Imagenes\Save_leave.png"));
        }
    }
}
