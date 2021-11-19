using InventarioFod.Clases;
using InventarioFod.Formularios.Inventarios.usuarios;
using System;
using System.Collections.Generic;

using System.Windows.Forms;

namespace InventarioFod.Formularios.Inventarios
{
    public partial class Orden_salida_materiales : Form
    {
        private readonly Conexion_db_Mysql baseDatos;
        private AutoCompleteStringCollection Data;
        public Orden_salida_materiales()
        {
            InitializeComponent();
            //Tooltip informacion Usuario
            ToolTip addUser = new ToolTip();
            addUser.SetToolTip(add_user,"Agregar Técnicos");


            ///Data Inventario materiales autocompletado
            Data = new AutoCompleteStringCollection();
            descripcion_material.AutoCompleteSource = AutoCompleteSource.CustomSource;
            materiales_salida.ColumnCount = 2;
            materiales_salida.Columns[0].Name = "Descripcion_Material";
            materiales_salida.Columns[1].Name = "Cantidad";
            baseDatos = Conexion_db_Mysql.Get_Instance;
            orden_trabajo.Text = baseDatos.get_num_acciones("orden_materiales").ToString("D7");
            List<string> materiales = baseDatos.Obtener_Lista_Materiales();
            
            foreach (var item in materiales)
            {
                Data.Add(item);
            }
            Cargar_Tecnicos();
            descripcion.Text = "ORDEN DE SALIDA PEDIDOS DE MATERIALES DE LOS TECNICOS";
            descripcion_material.AutoCompleteCustomSource = Data;
        }

        public void Cargar_Tecnicos()
        {
            List<string> tecnicos = baseDatos.Obtener_Tecnicos();
            this.tecnicos.Items.Clear();
            foreach (var tecnico in tecnicos)
            {
                this.tecnicos.Items.Add(tecnico);
            }
        }


        private void XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(descripcion_material.Text))
            {
                if (Verificar_Datos(descripcion_material.Text, "Descripcion_Material"))
                {
                    int cantidad_solicitada = Convert.ToInt32(numericUpDown1.Value.ToString());
                    int cantidad_material = baseDatos.Obtener_Cantidad_Material(descripcion_material.Text);

                    if (En_Stock(cantidad_material, cantidad_solicitada))
                    {
                        materiales_salida.Rows.Add(descripcion_material.Text, numericUpDown1.Value.ToString());
                        numericUpDown1.Value = 0;
                        descripcion_material.Text = string.Empty;
                    }
                    else
                    {
                        MessageBox.Show("Material Seleccionado sin Stock\nCantidad en Stock: "+cantidad_material, "Ingreso Materiales", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                }
                descripcion_material.Focus();
                
            }
            else
            {
                MessageBox.Show("Debe selecionar los datos Requeridos", "Ingreso Materiales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            
        }

        private bool En_Stock(int cantidad, int cantidad_solicitada)
        {
            if (cantidad == -1 || cantidad_solicitada > cantidad || cantidad_solicitada ==0) return false;
            return true;
        }
        private bool Verificar_Datos(string valor, string tipo_buscar)
        {

            bool estado = true;
            if (materiales_salida.Rows.Count != 1)
            {
                materiales_salida.AllowUserToAddRows = false;
                foreach (DataGridViewRow item in materiales_salida.Rows)
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
                materiales_salida.AllowUserToAddRows = true;

            }
            return estado;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            bool estado = true;
            materiales_salida.AllowUserToAddRows = false;
            if (materiales_salida.RowCount > 0 && tecnicos.SelectedItem != null)
            {
                if (!string.IsNullOrEmpty(tecnicos.SelectedItem.ToString()))
                {
                    materiales_salida.AllowUserToAddRows = false;
                    baseDatos.Crear_Orden_Materiales(Convert.ToInt32(orden_trabajo.Text), descripcion.Text);


                    foreach (DataGridViewRow item in materiales_salida.Rows)
                    {
                        int cantidad = Convert.ToInt32(item.Cells["Cantidad"].Value.ToString());
                        baseDatos.Agregar_Materiales_Lista_Inventario(item.Cells["Descripcion_Material"].Value.ToString(), cantidad, Convert.ToInt32(orden_trabajo.Text), tecnicos.SelectedItem.ToString());
                    }
                    MessageBox.Show("Datos Guardados", "Opciones Materiales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    materiales_salida.Rows.Clear();
                    materiales_salida.Refresh();
                }
                else
                {
                    MessageBox.Show("Debe ingresar nombre deL TECNICO ", "Error al guaradar Orden", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Debe Ingresar Datos", "Opciones Guardado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            

            materiales_salida.AllowUserToAddRows = true;
        }
        private void NumericUpDown1_Leave(object sender, EventArgs e)
        {
            button1.Focus();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            AddTecnico _addTecnico = new AddTecnico(this);
            _addTecnico.Show();
        }
    }
}
