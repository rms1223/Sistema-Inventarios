using InventarioFod.Clases;
using System;
using System.Windows.Forms;

namespace InventarioFod.Formularios.Inventarios.equipos_malos
{
    public partial class Lista_equipos_danados : Form
    {
        private Conexion_db_Mysql db_conn;
        public Lista_equipos_danados()
        {
            InitializeComponent();
            db_conn = Conexion_db_Mysql.Get_Instance;
            dataGridView1.DataSource = db_conn.Get_Equipos_Danados();

        }

        private void XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            foreach (DataGridViewRow item in dataGridView1.SelectedRows)
            {
                placa_txt.Text = item.Cells[Var_Name.Placa].Value.ToString();
                serie_txt.Text = item.Cells[Var_Name.Serie].Value.ToString();
                dano_txt.Text = item.Cells["Daños"].Value.ToString();



            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                dataGridView1.AllowUserToAddRows = false;
                foreach (DataGridViewRow item in dataGridView1.Rows)
                {
                    string placa = placa_txt.Text;
                    string serie = serie_txt.Text;
                    string dano = dano_txt.Text;
                    string estado = comboBox1.SelectedItem.ToString();
                    db_conn.Insertar_Equipos_Danos(placa, serie, dano, estado);
                }
                dataGridView1.AllowUserToAddRows = true;
                MessageBox.Show("Datos Guardados", "Opciones Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = db_conn.Get_Equipos_Danados();
            }
            else
            {
                MessageBox.Show("Debe seleccionar estado", "Opciones Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (placa_search.Text.Length == 6)
            {
                btn_search.Focus();
            }
        }

        private void Btn_search_Click(object sender, EventArgs e)
        {
            Buscar_codigo(placa_search.Text);
        }
        private void Buscar_codigo(string codigo)
        {

            bool estado = false;
            dataGridView1.AllowUserToAddRows = false;
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                if (item.Cells[Var_Name.Placa].Value.Equals(codigo))
                {
                    dataGridView1.Rows[item.Index].DefaultCellStyle.BackColor = System.Drawing.Color.LightSkyBlue;
                    dataGridView1.FirstDisplayedScrollingRowIndex = item.Index;
                    //item.Selected = true;
                    estado = true;
                    break;
                }
            }
            dataGridView1.AllowUserToAddRows = true;
            if (!estado)
            {
                MessageBox.Show("No existe la Placa: " + codigo, "Equipos Dañados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                placa_search.Text = string.Empty;
            }
        }
    }
}
