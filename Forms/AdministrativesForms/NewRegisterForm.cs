using SystemIventory.Classes;
using System;
using System.Windows.Forms;

namespace SystemIventory.Forms.AdministrativesForms
{
    public partial class NewRegisterForm : Form
    {
        private ConnectionMysqlDatabase _mysqlConnectionDatabase;
        Label cod;
        Label institu;
        Label modalidad;
        Label condicion;
        Label num_Lote;
        public NewRegisterForm(Label codigo, Label institucion, Label moda, Label condi, Label lote)
        {
            InitializeComponent();
            _mysqlConnectionDatabase = ConnectionMysqlDatabase.Get_Instance;
            _mysqlConnectionDatabase.VerifyDatabaseConnection();
            cod = codigo;
            institu = institucion;
            modalidad = moda;
            condicion = condi;
            num_Lote = lote;
        }

        private void TextBox1_Leave(object sender, EventArgs e)
        {
            string valor = _mysqlConnectionDatabase.GetInstitutionCode(textBox1.Text, "reequipamiento");
            institucion.Text = valor;
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddInstitutionForm add_institu = new AddInstitutionForm();
            add_institu.Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            cod.Text = textBox1.Text;
            institu.Text = institucion.Text;
            num_Lote.Text = id_lote.Text;
            modalidad.Text = nom_modalidad.Text;
            condicion.Text = nom_condicion.Text;
            this.Close();
        }

        private void XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
