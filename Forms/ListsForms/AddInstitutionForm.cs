using SystemIventory.Classes;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SystemIventory
{
    public partial class AddInstitutionForm : Form
    {

        public AddInstitutionForm()
        {
            InitializeComponent();
        }

        private void t1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Label3_MouseEnter(object sender, EventArgs e)
        {
            label3.Image = Image.FromFile(Path.Combine(Application.StartupPath, @"Imagenes\Save_enter.png"));
        }

        private void Label3_Click(object sender, EventArgs e)
        {
            DataOperationDocument manejo_de_datos = new DataOperationDocument();
            manejo_de_datos.SaveInstitutionInDatabase(new Classes.Entities.Institution(textBox1.Text, textBox2.Text));
            this.Close();
        }

        private void Label3_MouseLeave(object sender, EventArgs e)
        {
            label3.Image = Image.FromFile(Path.Combine(Application.StartupPath, @"Imagenes\Save_leave.png"));
        }
    }
}
