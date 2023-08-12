using SystemIventory.Classes;
using SystemIventory.Forms;
using SystemIventory.Forms.InventoriesForms.usuarios;
using System;
using System.Threading;
using System.Windows.Forms;
using SystemInventory.Classes.IModels;
using SystemInventory.Classes.Models;

namespace SystemIventory
{
    public partial class MainMenuForm : Form
    {
        private OperationsRepository _mysqlConnectionDatabase;
        private IDataBaseRepository _dataBaseRepository;
        private Thread t_threadMain;
        private LoginUserForm _loginForm;
        private readonly IPanel _panelMenu;
        private string rol_user;
        public int xClick = 0, yClick = 0;
        public string AddMessageMail { get; set; }

        public MainMenuForm(LoginUserForm principal, string rol)
        {
            _loginForm = principal;
            rol_user = rol;
            _panelMenu = new PanelMenu();
            t_threadMain = new Thread(new ThreadStart(StartLoginThreadRun))
            {
                IsBackground = true
            };
            t_threadMain.Start();
            
            InitializeComponent();

            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.WindowState = FormWindowState.Maximized;
            opciones.Visible = false;
            _mysqlConnectionDatabase = OperationsRepository.Get_Instance;
            _mysqlConnectionDatabase.StatusTecnicals = true;
            _mysqlConnectionDatabase.GetLocation();
            _dataBaseRepository = DataBaseRepository.Get_Instance;

            toolStripStatusLabel2.Text = "Fecha: " + VariablesName.ActualDate;
            treeView1.ExpandAll();
            StopLoginThreadRun();
            
            ValidateUser();

            timer1.Start();
            timer2.Start();
            Validar_estadoConexion();
            


        }
        private void ValidateUser()
        {
            switch (rol_user)
            {
                case "ABI2019":
                    treeView1.Nodes[3].Remove();
                    break;
                case "AAI2019":
                    treeView1.Nodes[0].Remove();
                    treeView1.Nodes[0].Remove();
                    break;
                case "ATI2019":
                    treeView1.Nodes[0].Remove();
                    treeView1.Nodes[0].Remove();
                    treeView1.Nodes[1].Remove();
                    statusStrip2.Visible = false;
                    break;
                case "AADMIN2019":
                    opciones.Visible = true;
                    break;
                default:
                    break;
            }
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            LoadPanel(PrincipalForm._getInstance);
        }

        private void LoadPanel(object panel)
        {
            
            if (this.panel2.Controls.Count > 0)
            {
                this.panel2.Controls.RemoveAt(0);
            }

            
            Form panel_in = panel as Form;
            panel_in.TopLevel = false;
            panel_in.Dock = DockStyle.Fill;
            panel2.Controls.Add(panel_in);
            panel2.Tag = panel_in;
            panel_in.Show();
            

        }

        private void TreeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                Object panel = _panelMenu.GetPanel(e.Node.Name, rol_user);
                if (panel != null)
                {
                    LoadPanel(panel);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar vuelva a intentarlo", "Error al Iniciar", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            
            
            
        }


        private void CerraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _mysqlConnectionDatabase.CloseConnection();
            this.Close();
            _loginForm.Close();
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void DffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                //establecer fullscreen con barra de tareas abajo visible
                this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
                this.WindowState = FormWindowState.Maximized;
            }
            
        }
        private Form form_splash;
        private void StartLoginThreadRun()
        {
            form_splash = new LoadForm();
            Application.Run(form_splash);
        }
        private void StopLoginThreadRun()
        {
            if (form_splash.InvokeRequired)
            {
                form_splash.Invoke(new MethodInvoker(StopLoginThreadRun));
            }
            else
            {
                Application.ExitThread();
            }
            
        }

        private void AgregarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddUserForm addUser = new AddUserForm();
            addUser.Show();
        }

        private void MenuStrip1_MouseMove(object sender, MouseEventArgs e)
        {
            FormMove(e);
        }

        private void ToolStripStatusLabel3_Click(object sender, EventArgs e)
        {
            _mysqlConnectionDatabase.VerifyDatabaseConnection();
        }

        private void Panel2_MouseMove(object sender, MouseEventArgs e)
        {
            FormMove(e);
        }
        public void Validar_estadoConexion()
        {
            string estado = _mysqlConnectionDatabase.StatusMysqlConnection();
            _mysqlConnectionDatabase.VerifyDatabaseConnection();
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            Validar_estadoConexion();
            string message_server = _mysqlConnectionDatabase.ConnectionMessage;
            
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            count_orden.Text = _dataBaseRepository.GetPendingOrder().Result.ToString();
        }


        private void FormMove(MouseEventArgs e)
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
