using SystemIventory.Classes;
using System;
using System.Windows.Forms;

namespace SystemIventory.Forms.InventoriesForms
{
    public partial class RegisterProductForm : Form
    {
        private ConnectionMysqlDatabase _mysqlConnectionDatabase;
        private MaterialsForm _materialsForm;
        public RegisterProductForm(MaterialsForm _inevenMateriales)
        {
            InitializeComponent();
            _materialsForm = _inevenMateriales;
            _mysqlConnectionDatabase = ConnectionMysqlDatabase.Get_Instance;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            _mysqlConnectionDatabase.SaveNewProduct(cod_init.Text + "" + cod.Text, textBox2.Text);
            MessageBox.Show("Datos Guardados", "Opciones Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _materialsForm.Cargar_Inventario_Materiales();
        }
    }
}
