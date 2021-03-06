using InventarioFod.Clases;
using InventarioFod.Clases.Entidades;
using System;
using System.Windows.Forms;

namespace InventarioFod.Formularios.Inventarios.equipos_malos
{
    public partial class Equipos_malos : Form
    {
        private Conexion_db_Mysql base_datos;
        public Equipos_malos()
        {
            InitializeComponent();
            dataGridView1.ColumnCount = 7;
            dataGridView1.Columns[0].Name = "Placa";
            dataGridView1.Columns[1].Name = "Serie";
            dataGridView1.Columns[2].Name = "Marca";
            dataGridView1.Columns[3].Name = "Modelo";
            dataGridView1.Columns[4].Name = "Tipo_equipo";
            dataGridView1.Columns[5].Name = "Daños";
            dataGridView1.Columns[6].Name = "Estado";
            base_datos = Conexion_db_Mysql.Get_Instance;

            foreach (var item in base_datos.Get_Danos())
            {
                lista_malas.Items.Add(item);
            }
            lista_malas.Sorted = true;
        }

        private void Button2_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(placa.Text))
            {
                Equipos equi = base_datos.procesar_datos_equipos(placa.Text, Var_Name.Placa);
                string danos = string.Empty;
                if (lista_malas.SelectedItems.Count > 0)
                {
                    foreach (var item_lista in lista_malas.SelectedItems)
                    {
                        danos += item_lista + "-";
                    }
                }
                if (estado.SelectedItem != null)
                {
                    dataGridView1.Rows.Add(equi.Placa, equi.Serie, equi.Marca, equi.Modelo, equi.Tipo_equipo, danos, estado.SelectedItem.ToString());
                }
                else
                {
                    MessageBox.Show("Error debe seleccionar un Estado", "Opciones Guardado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
                dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
            }
            
        }

        private void XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BuscarEquiposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Lista_equipos_danados equi_danos = new Lista_equipos_danados();
            equi_danos.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                string placa = item.Cells["Placa"].Value.ToString();
                string serie = item.Cells["Serie"].Value.ToString();
                string dano = item.Cells["Daños"].Value.ToString();
                string estado = item.Cells["Estado"].Value.ToString();
                base_datos.Insertar_Equipos_Danos(placa,serie,dano,estado);
            }
            dataGridView1.AllowUserToAddRows = true;
            MessageBox.Show("Datos Guardados", "Opciones Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Placa_TextChanged(object sender, EventArgs e)
        {
            if (placa.Text.Length>=6)
            {
                button1.Focus();
            }
        }
    }
}
