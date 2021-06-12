using InventarioFod.Clases;
using System;
using System.Windows.Forms;

namespace InventarioFod.Formularios.Administrativo
{
    public partial class Nuevo_Registro : Form
    {
        private Conexion_db_Mysql base_datos;
        Label cod;
        Label institu;
        Label modalidad;
        Label condicion;
        public Nuevo_Registro(Label codigo, Label institucion, Label moda, Label condi)
        {
            InitializeComponent();
            base_datos = Conexion_db_Mysql.Get_Instance;
            base_datos.Verificar_Conexion();
            cod = codigo;
            institu = institucion;
            modalidad = moda;
            condicion = condi;
        }

        private void TextBox1_Leave(object sender, EventArgs e)
        {
            string valor = base_datos.Obtener_Institucion(textBox1.Text, "reequipamiento");
            institucion.Text = valor;
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AgregarInstitucion add_institu = new AgregarInstitucion();
            add_institu.Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            cod.Text = textBox1.Text;
            institu.Text = institucion.Text;
            modalidad.Text = comboBox1.SelectedItem.ToString();
            condicion.Text = comboBox2.SelectedItem.ToString();
            this.Close();
        }

        private void XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
