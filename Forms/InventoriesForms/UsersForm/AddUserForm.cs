using SystemIventory.Classes;
using SystemIventory.Classes.Entities.Security;
using System;
using System.Windows.Forms;
using SystemInventory.Classes.Entities;
using SystemInventory.Classes.IModels;
using SystemInventory.Classes.Models;
using System.Collections.Generic;

namespace SystemIventory.Forms.InventoriesForms.usuarios
{
    public partial class AddUserForm : Form
    {
        private IDataBaseRepository _dataBaseRepository;
        public AddUserForm()
        {
            InitializeComponent();
            _dataBaseRepository = DataBaseRepository.Get_Instance;
            List<string> listRols = (List<string>)_dataBaseRepository.GetRoles().Result;
            foreach (var item in listRols)
            {
                rol.Items.Add(item);
            }
        }

        private void XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
           string pass_val = UserSecurity.ProcessPasswordUser(pass.Text);
            User userLogin = new User 
            {
                UserName = user.Text,
                Password = pass_val,
                Rol = rol.SelectedItem.ToString()
            }; 
            bool estado= _dataBaseRepository.SaveUserSystem(userLogin).StatusQuery;
            if (estado)
            {
                MessageBox.Show("Datos Guardados", "Opciones Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error al ingresar los datos", "Error al ingresar datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
