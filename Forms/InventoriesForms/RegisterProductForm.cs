using SystemIventory.Classes;
using System;
using System.Windows.Forms;
using SystemInventory.Classes.IModels;
using SystemInventory.Classes.Models;

namespace SystemIventory.Forms.InventoriesForms
{
    public partial class RegisterProductForm : Form
    {
        private IDataBaseRepository _dataBaseRepository;
        private MaterialsForm _materialsForm;
        public RegisterProductForm(MaterialsForm _inevenMateriales)
        {
            InitializeComponent();
            _materialsForm = _inevenMateriales;
            _dataBaseRepository = DataBaseRepository.Get_Instance;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            _dataBaseRepository.SaveNewProduct(cod_init.Text + "" + cod.Text, textBox2.Text);
            MessageBox.Show("Datos Guardados", "Opciones Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _materialsForm.Cargar_Inventario_Materiales();
        }
    }
}
