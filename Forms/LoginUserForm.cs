using SystemIventory.Classes;
using SystemIventory.Classes.Entities.Security;
using SystemIventory.Classes.DataBase;
using System;
using System.Windows.Forms;
using SystemInventory.Classes.Entities;
using SystemInventory.Classes.IModels;
using SystemInventory.Classes.Models;

namespace SystemIventory.Forms
{
    public partial class LoginUserForm : Form
    {
        private IDataBaseRepository _dataBaseRepository;
        public int xClick = 0, yClick = 0;
        public LoginUserForm()
        {
            InitializeComponent();
            _typeSystem.SelectedIndex = 0;
            _nameSystem.Text = "RMS " + DateTime.Now.ToString("yyyy");
            _ = new OperationsFileXlm();
            error_login.Visible = false;
        }

        private void XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            InitProcessLogin();
            
        }
        private void InitProcessLogin()
        {
            try
            {
                if (select_user.SelectedItem != null)
                {

                    if (_typeSystem.SelectedItem.ToString().Equals("Sistema Nuevo"))
                    {
                        VariablesName.TypeDatabase = VariablesName.NewSystem;
                    }
                    else
                    {
                        VariablesName.TypeDatabase = VariablesName.OldSystem;
                    }
                    _dataBaseRepository = DataBaseRepository.Get_Instance;
                    var userRol = new User
                    {
                        UserName = select_user.SelectedItem.ToString(),
                        Password = UserSecurity.ProcessPasswordUser(pass.Text)
                    };
                    string rol_usuario = (string)_dataBaseRepository.GetRolSystemFromIdUser( userRol ).Result;

                    
                    /*if (string.IsNullOrEmpty(rol_usuario))
                    {
                        error_login.Visible = true;
                    }
                    else
                    {*/
                        this.Hide();
                    MainMenuForm menuPrincipal = new MainMenuForm(this, "ABI2019");//rol_usuario);
                        menuPrincipal.Show();

                    //}
                    
                }
                else
                {
                    MessageBox.Show("Ingrese el usuario y contraseña", "Opciones de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al conectar sistema"+ex,"Error de Conexión",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
        }

        private void Pass_Leave(object sender, EventArgs e)
        {
            button1.Focus();
        }

        private void Pass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InitProcessLogin();
            }
        }

        private void MenuStrip1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                xClick = e.X;
                yClick = e.Y;
            }
            else
            {
                Left += (e.X - xClick);
                Top += (e.Y - yClick);
            }
        }

    }
}
