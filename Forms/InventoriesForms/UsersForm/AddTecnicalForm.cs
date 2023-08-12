
using System;
using System.Windows.Forms;
using SystemInventory.Classes.IModels;
using SystemInventory.Classes.Models;

namespace SystemIventory.Forms.InventoriesForms.usuarios
{
    public partial class AddTecnicalForm : Form
    {
        private IDataBaseRepository _dataBaseRepository;
        private OrderOutputMaterials _materials;
        public AddTecnicalForm(OrderOutputMaterials _ordenMateriales)
        {
            InitializeComponent();
            _dataBaseRepository = DataBaseRepository.Get_Instance;
            _materials = _ordenMateriales;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            bool estado = _dataBaseRepository.SaveTechnical(nom_tec.Text.ToUpper()).StatusQuery;
            if (estado)
            {
                MessageBox.Show("Datos Registrados","Agregar Usuario" , MessageBoxButtons.OK, MessageBoxIcon.Information);
                nom_tec.Text = string.Empty;
                _materials.LoadTechnicalData();
            }
            else
            {
                MessageBox.Show("Error al Agregar Usuario", "Agregar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
