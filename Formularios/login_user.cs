using InventarioFod.Clases;
using InventarioFod.Clases.Entidades.Security;
using InventarioFod.Clases.Manejo_De_Datos.Conexion_DB;
using System;
using System.Windows.Forms;

namespace InventarioFod.Formularios
{
    public partial class login_user : Form
    {
        private Conexion_db_Mysql basedatos;
        public int xClick = 0, yClick = 0;
        public login_user()
        {
            InitializeComponent();
            tipos_sistema.SelectedIndex = 0;
            label4.Text = "RMS-ACS " + DateTime.Now.ToString("yyyy");
            _ = new Lectura_xml();

            error_login.Visible = false;
        }

        private void XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            procesar_login();
            
        }
        private void procesar_login()
        {
            try
            {
                if (select_user.SelectedItem != null)
                {

                    if (tipos_sistema.SelectedItem.ToString().Equals("Sistema Nuevo"))
                    {
                        Var_Name.tipo_basedatos = "sistema_nuevo";
                    }
                    else
                    {
                        Var_Name.tipo_basedatos = "sistema_viejo";
                    }

                    basedatos = Conexion_db_Mysql.Get_Instance;

                    string rol_usuario = basedatos.obtener_login_usuario(select_user.SelectedItem.ToString(), Usuario_Seguridad.Procesar_Pass_Usuarios(pass.Text));
                    if (string.IsNullOrEmpty(rol_usuario))
                    {
                        error_login.Visible = true;
                    }
                    else
                    {
                        this.Hide();
                        MenuPrincipal menuPrincipal = new MenuPrincipal(this, rol_usuario);
                        menuPrincipal.Show();

                    }
                }
                else
                {
                    MessageBox.Show("Ingrese el usuario y contraseña", "Opciones de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Error al conectar sistema","Error de Conexión",MessageBoxButtons.OK,MessageBoxIcon.Error);
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
                procesar_login();
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
