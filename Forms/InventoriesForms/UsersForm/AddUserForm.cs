using SystemIventory.Classes;
using SystemIventory.Classes.Entities.Security;
using System;
using System.Windows.Forms;

namespace SystemIventory.Forms.InventoriesForms.usuarios
{
    public partial class AddUserForm : Form
    {
        private ConnectionMysqlDatabase _mysqlConnectionDatabase;
        public AddUserForm()
        {
            InitializeComponent();
            _mysqlConnectionDatabase = ConnectionMysqlDatabase.Get_Instance;
            foreach (var item in _mysqlConnectionDatabase.GetRoles())
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
           bool estado= _mysqlConnectionDatabase.SaveUserSystem(user.Text, pass_val,rol.SelectedItem.ToString());
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
