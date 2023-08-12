
using System;
using System.Windows.Forms;
using SystemInventory.Classes.IModels;
using SystemInventory.Classes.Models;

namespace SystemIventory.Forms.AdministrativesForms
{
    public partial class CreateCartelForm : Form
    {
        private IDataBaseRepository _dataBaseRepository;
        public CreateCartelForm()
        {
            InitializeComponent();
            _dataBaseRepository = DataBaseRepository.Get_Instance;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var response = _dataBaseRepository.RegisterNewCartel(idCartel.Text,descripcion.Text,DateTime.Now.ToString());
            if (response.StatusQuery)
            {
                MessageBox.Show("Datos Registrados", "Registro Cartel", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Error al Registrar datos { response.MessageQuery }", "Registro Cartel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                
        }

    }
}
