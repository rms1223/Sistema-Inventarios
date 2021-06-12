
using InventarioFod.Clases;
using InventarioFod.Formularios.Acciones;
using System;
using System.Windows.Forms;

namespace InventarioFod.Formularios.Inventarios
{
    public partial class Orden_Ingreso : Form
    {
        private Conexion_db_Mysql base_datos;

        Manejo_Documento_Excel manejo_de_datos;
        public Orden_Ingreso()
        {
            InitializeComponent();
            base_datos = Conexion_db_Mysql.Get_Instance;

            manejo_de_datos = new Manejo_Documento_Excel(dataGridView1);
            manejo_de_datos.Cargar_orden_trabajo();
            orden_trabajo.Text = base_datos.get_num_acciones("orden_trabajo").ToString("D7");

        }

        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Buscar_Acciones buscar_orden = new Buscar_Acciones(orden_trabajo, institucion,Var_Name.ORDEN_ENTRADA);
            buscar_orden.Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null && !string.IsNullOrEmpty(institucion.Text))
            {
                manejo_de_datos.Procesar_datos_orden(placa.Text, Var_Name.Placa, institucion.Text + "('" + comboBox1.SelectedItem.ToString() + "')", comboBox1.SelectedItem.ToString(), 0);
                placa.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Debe ingresar los datos", "Error al guaradar datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            placa.Focus();
            
        }

        private void Buscar_serie_Click(object sender, System.EventArgs e)
        {
            if (comboBox1.SelectedItem != null && !string.IsNullOrEmpty(institucion.Text))
            {
                manejo_de_datos.Procesar_datos_orden(serie.Text, Var_Name.Serie, institucion.Text + "('" + comboBox1.SelectedItem.ToString() + "')", comboBox1.SelectedItem.ToString(), 0);
                serie.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Debe ingresar los datos", "Error al guaradar datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            serie.Focus();
        }

        private void TextBox1_Leave(object sender, System.EventArgs e)
        {
            string valor = base_datos.Obtener_Institucion(textBox1.Text, "reequipamiento");
            institucion.Text = valor;
            placa.Focus();
            textBox1.Text = string.Empty;
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AgregarInstitucion add_institu = new AgregarInstitucion();
            add_institu.Show();
        }

        private void Guardar_Click(object sender, EventArgs e)
        {
            guardar.Enabled = false;

            if (!string.IsNullOrEmpty(institucion.Text))
            {
                manejo_de_datos.Guardar_datos_orden(orden_trabajo.Text, descripcion_orden+"/n"+institucion.Text + "('" + comboBox1.SelectedItem.ToString() + "')", Var_Name.ORDEN_ENTRADA,false);
            }
            else
            {
                MessageBox.Show("Debe ingresar nombre de orden o institucción", "Error al guaradar Orden", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            guardar.Enabled = true;
        }

        private void Placa_TextChanged(object sender, EventArgs e)
        {
            if (placa.Text.Length == 6)
            {
                button1.Focus();
            }
        }

        private void Serie_TextChanged(object sender, EventArgs e)
        {

            if (serie.Text.Length >= 20)
            {
                buscar_serie.Focus();
            }
        }

        private void XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            descripcion_orden.Text = comboBox1.SelectedItem.ToString() + " DE EQUIPO";
        }
    }
}
