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

            ingreso_materiales.ColumnCount = 2;
            ingreso_materiales.Columns[0].Name = "Descripcion_Material";
            ingreso_materiales.Columns[1].Name = "Cantidad";
            //orden_trabajo.Text = accion;
            orden_trabajo.Text = baseDatos.get_num_acciones("orden_materiales").ToString("D7");
            Cargar_Inventario_Materiales();
            descripcion.Text = "INGRESO COMPRA DE MATERIALES";
            comboBox1.AutoCompleteCustomSource = Data;
        }

        public void Cargar_Inventario_Materiales()
        {
            List<string> materiales = baseDatos.Obtener_Lista_Materiales();

            foreach (var item in materiales)
            {
                Data.Add(item);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBox1.Text) && cant_materialesIngreso.Value !=0)
            {
                if (verificar_datos(comboBox1.Text, "Descripcion_Material"))
                {
                    ingreso_materiales.Rows.Add(comboBox1.Text, cant_materialesIngreso.Value.ToString());
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
            if (ingreso_materiales.Rows.Count != 1)
            {
                ingreso_materiales.AllowUserToAddRows = false;
                foreach (DataGridViewRow item in ingreso_materiales.Rows)
                {

                    if (item.Cells[tipo_buscar].Value.ToString().Equals(valor))
                    {
                        estado = false;
                    }
                }
                if (!estado)
                {

                    MessageBox.Show("Material ya esta asignado, Modifique la cantidad", "Ingreso Materiales", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                ingreso_materiales.AllowUserToAddRows = true;

            }
            return estado;
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            ingreso_materiales.AllowUserToAddRows = false;
            if (ingreso_materiales.RowCount>0)
            {
                baseDatos.Crear_Orden_Materiales(Convert.ToInt32(orden_trabajo.Text), descripcion.Text);

                foreach (DataGridViewRow item in ingreso_materiales.Rows)
                {
                    baseDatos.Agregar_Materiales_Inventario(item.Cells["Descripcion_Material"].Value.ToString(), Convert.ToInt32(item.Cells["Cantidad"].Value.ToString()), Convert.ToInt32(orden_trabajo.Text));
                }
                MessageBox.Show("Datos Guardados", "Opciones Materiales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ingreso_materiales.Rows.Clear();
                ingreso_materiales.Refresh();
            }
            else
            {
                MessageBox.Show("Debe Ingresar Datos", "Opciones Guardado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            ingreso_materiales.AllowUserToAddRows = true;

            
        }


        private void XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RegistrarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Registrar_Producto registrar = new Registrar_Producto(this);
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
