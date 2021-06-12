using InventarioFod.Clases;
using System;
using System.Windows.Forms;

namespace InventarioFod.Formularios.Acciones
{
    public partial class Revisar_placas_ordenes : Form
    {
        Manejo_Documento_Excel Manejo_de_datos;
        public Revisar_placas_ordenes()
        {
            InitializeComponent();
            Manejo_de_datos = new Manejo_Documento_Excel(data_revision);
        }

        private void XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CargarOrdenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Buscar_Acciones buscar_orden = new Buscar_Acciones(this);
            buscar_orden.Show();
            
        }

        public void Cargar_OrdenTrabajo(int orden)
        {
            Manejo_de_datos.Obtener_equipo_acciones(orden.ToString(), "Acciones");
            total_equipos.Text=Convert.ToString(data_revision.RowCount - 1);
            Manejo_de_datos.Data_cambios(data_eliminadas, data_agregadas);
            Manejo_de_datos.Obtener_cambios(orden);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Buscar_codigo(textBox1.Text);

            textBox1.Focus();
        }

        private void Buscar_codigo(string codigo)
        {
            
            bool estado = false;
            data_revision.AllowUserToAddRows = false;
            foreach (DataGridViewRow item in data_revision.Rows)
            {
                if (item.Cells[Var_Name.Placa].Value.Equals(codigo))
                {
                    data_revision.Rows[item.Index].DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
                    data_revision.FirstDisplayedScrollingRowIndex = item.Index;
                    //item.Selected = true;
                    estado = true;
                    break;
                }
            }
            data_revision.AllowUserToAddRows = true;
            if (!estado)
            {
                MessageBox.Show("No existe la Placa" + codigo, "Revision de Placas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                textBox1.Text = String.Empty;
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.TextLength >=6)
            {
                button1.Focus();
            }
        }
    }
}
