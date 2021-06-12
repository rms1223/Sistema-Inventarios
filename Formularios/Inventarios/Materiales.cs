using InventarioFod.Clases;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace InventarioFod.Formularios.Inventarios
{
    public partial class Materiales : Form
    {
        private Conexion_db_Mysql baseDatos;
        private AutoCompleteStringCollection Data;
        public Materiales()
        {
            InitializeComponent();
            baseDatos = Conexion_db_Mysql.Get_Instance;
            Data = new AutoCompleteStringCollection();
            comboBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;

            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].Name = "Descripcion_Material";
            dataGridView1.Columns[1].Name = "Cantidad";
            //orden_trabajo.Text = accion;
            orden_trabajo.Text = baseDatos.get_num_acciones("orden_materiales").ToString("D7");
            List<string> materiales = baseDatos.Obtener_Lista_Materiales();

            foreach (var item in materiales)
            {
                Data.Add(item);
            }
            descripcion.Text = "INGRESO COMPRA DE MATERIALES";
            comboBox1.AutoCompleteCustomSource = Data;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBox1.Text) && cant_materialesIngreso.Value !=0)
            {
                if (verificar_datos(comboBox1.Text, "Descripcion_Material"))
                {
                    dataGridView1.Rows.Add(comboBox1.Text, cant_materialesIngreso.Value.ToString());
                }
                cant_materialesIngreso.Value = 0;
                comboBox1.Text = string.Empty;
                comboBox1.Focus();
            }
            else
            {
                MessageBox.Show("Debe Ingresar un material y su cantidad", "Ingreso Materiales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }            
            
        }
        private bool verificar_datos(string valor, string tipo_buscar)
        {

            bool estado = true;
            if (dataGridView1.Rows.Count != 1)
            {
                dataGridView1.AllowUserToAddRows = false;
                foreach (DataGridViewRow item in dataGridView1.Rows)
                {

                    if (item.Cells[tipo_buscar].Value.ToString().Equals(valor))
                    {
                        estado = false;
                    }
                }
                if (!estado)
                {

                    MessageBox.Show("Material ya esta asignado", "Ingreso Materiales", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                dataGridView1.AllowUserToAddRows = true;

            }
            return estado;
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            if (dataGridView1.RowCount>0)
            {
                baseDatos.Crear_Orden_Materiales(Convert.ToInt32(orden_trabajo.Text), descripcion.Text);

                foreach (DataGridViewRow item in dataGridView1.Rows)
                {
                    baseDatos.Agregar_Materiales_Inventario(item.Cells["Descripcion_Material"].Value.ToString(), Convert.ToInt32(item.Cells["Cantidad"].Value.ToString()), Convert.ToInt32(orden_trabajo.Text));
                }
                MessageBox.Show("Datos Guardados", "Opciones Materiales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
            }
            else
            {
                MessageBox.Show("Debe Ingresar Datos", "Opciones Guardado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            dataGridView1.AllowUserToAddRows = true;

            
        }


        private void XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RegistrarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Registrar_Producto registrar = new Registrar_Producto();
            registrar.Show();

        }
        private void ComboBox1_Leave(object sender, EventArgs e)
        {
            cant_materialesIngreso.Focus();
        }

        private void Cant_materialesIngreso_Leave(object sender, EventArgs e)
        {
            button1.Focus();
        }
    }
}
