using SystemIventory.Classes;
using SystemIventory.Forms.InventoriesForms.usuarios;
using System;
using System.Collections.Generic;

using System.Windows.Forms;

namespace SystemIventory.Forms.InventoriesForms
{
    public partial class OrderOutputMaterials : Form
    {
        private readonly ConnectionMysqlDatabase _mysqlConnectionDatabase;
        private AutoCompleteStringCollection _dataCollection;
        public OrderOutputMaterials()
        {
            InitializeComponent();
            ToolTip addUser = new ToolTip();
            addUser.SetToolTip(add_user,"Agregar Técnicos");
            _dataCollection = new AutoCompleteStringCollection();
            descripcion_material.AutoCompleteSource = AutoCompleteSource.CustomSource;
            materiales_salida.ColumnCount = 2;
            materiales_salida.Columns[0].Name = "Descripcion_Material";
            materiales_salida.Columns[1].Name = "Cantidad";
            _mysqlConnectionDatabase = ConnectionMysqlDatabase.Get_Instance;
            orden_trabajo.Text = _mysqlConnectionDatabase.GetIdWorkActionFromType("orden_materiales").ToString("D7");
            List<string> materiales = _mysqlConnectionDatabase.GetListMaterials();
            
            foreach (var item in materiales)
            {
                _dataCollection.Add(item);
            }
            LoadTechnicalData();
            descripcion.Text = "ORDEN DE SALIDA PEDIDOS DE MATERIALES DE LOS TECNICOS";
            descripcion_material.AutoCompleteCustomSource = _dataCollection;
        }

        public void LoadTechnicalData()
        {
            List<string> tecnicos = _mysqlConnectionDatabase.GetTecnicals();
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
                    int cantidad_material = _mysqlConnectionDatabase.GetTotalMaterialsInStockFromDescription(descripcion_material.Text);

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
                    _mysqlConnectionDatabase.SaveNewOrderMaterialsWorkAction(Convert.ToInt32(orden_trabajo.Text), descripcion.Text);


                    foreach (DataGridViewRow item in materiales_salida.Rows)
                    {
                        int cantidad = Convert.ToInt32(item.Cells["Cantidad"].Value.ToString());
                        _mysqlConnectionDatabase.SaveNewOrderMaterialsForTecnicals(item.Cells["Descripcion_Material"].Value.ToString(), cantidad, Convert.ToInt32(orden_trabajo.Text), tecnicos.SelectedItem.ToString());
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
            AddTecnicalForm _addTecnico = new AddTecnicalForm(this);
            _addTecnico.Show();
        }
    }
}
