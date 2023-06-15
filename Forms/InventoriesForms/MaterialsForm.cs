using SystemIventory.Classes;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SystemIventory.Forms.InventoriesForms
{
    public partial class MaterialsForm : Form
    {
        private ConnectionMysqlDatabase _mysqlConnectionDatabase;
        private AutoCompleteStringCollection _dataCollection;
        public MaterialsForm()
        {
            InitializeComponent();
            _mysqlConnectionDatabase = ConnectionMysqlDatabase.Get_Instance;
            _dataCollection = new AutoCompleteStringCollection();
            comboBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;

            ingreso_materiales.ColumnCount = 2;
            ingreso_materiales.Columns[0].Name = "Descripcion_Material";
            ingreso_materiales.Columns[1].Name = "Cantidad";
            //orden_trabajo.Text = accion;
            orden_trabajo.Text = _mysqlConnectionDatabase.GetIdWorkActionFromType("orden_materiales").ToString("D7");
            Cargar_Inventario_Materiales();
            descripcion.Text = "INGRESO COMPRA DE MATERIALES";
            comboBox1.AutoCompleteCustomSource = _dataCollection;
        }

        public void Cargar_Inventario_Materiales()
        {
            List<string> materiales = _mysqlConnectionDatabase.GetListMaterials();

            foreach (var item in materiales)
            {
                _dataCollection.Add(item);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBox1.Text) && cant_materialesIngreso.Value !=0)
            {
                if (Verify_datos(comboBox1.Text, "Descripcion_Material"))
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
        private bool Verify_datos(string valor, string tipo_buscar)
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
                _mysqlConnectionDatabase.SaveNewOrderMaterialsWorkAction(Convert.ToInt32(orden_trabajo.Text), descripcion.Text);

                foreach (DataGridViewRow item in ingreso_materiales.Rows)
                {
                    _mysqlConnectionDatabase.UpdateNewOrderMaterialsWorkAction(item.Cells["Descripcion_Material"].Value.ToString(), Convert.ToInt32(item.Cells["Cantidad"].Value.ToString()), Convert.ToInt32(orden_trabajo.Text));
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
            RegisterProductForm registrar = new RegisterProductForm(this);
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
