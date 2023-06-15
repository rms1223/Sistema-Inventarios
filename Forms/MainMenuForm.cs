using SystemIventory.Classes;
using SystemIventory.Forms;
using SystemIventory.Forms.Acciones;
using SystemIventory.Forms.AdministrativesForms;
using SystemIventory.Forms.Consultas.inventarios_materiales;
using SystemIventory.Forms.InventoriesForms;
using SystemIventory.Forms.InventoriesForms.equipos_malos;
using SystemIventory.Forms.InventoriesForms.estado_ordenes;
using SystemIventory.Forms.InventoriesForms.usuarios;
using SystemIventory.Reports;
using System;
using System.Threading;
using System.Windows.Forms;

namespace SystemIventory
{
    public partial class MainMenuForm : Form
    {
        private ConnectionMysqlDatabase _mysqlConnectionDatabase;
        private Thread t_threadMain;
        private LoginUserForm _loginForm;
        private string rol_user;
        public int xClick = 0, yClick = 0;
        public string AddMessageMail { get; set; }

        public MainMenuForm(LoginUserForm principal, string rol)
        {
            _loginForm = principal;
            rol_user = rol;
            
            t_threadMain = new Thread(new ThreadStart(StartLoginThreadRun))
            {
                IsBackground = true
            };
            t_threadMain.Start();
            
            InitializeComponent();
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.WindowState = FormWindowState.Maximized;
            opciones.Visible = false;
            _mysqlConnectionDatabase = ConnectionMysqlDatabase.Get_Instance;
            _mysqlConnectionDatabase.StatusTecnicals = true;
            _mysqlConnectionDatabase.GetInformationLocation();
            
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
                Object panel = null;
                switch (e.Node.Name)
                {
                    case "inven_reeequi":
                        panel = PrincipalForm._getInstance;
                        break;
                    case "list_reequi":
                        InventoryListForm.Get_instance.Rol_Usuario = rol_user;
                        panel = InventoryListForm.Get_instance;

                        break;
                    case "rpt_acciones":
                        panel = new salida_materiales();
                        break;
                    case "verif_equipos":
                        panel = new VerifyDeviceInventoryForm();
                        break;
                    case "rpt_equi_accion":
                        panel = new WorkActionGeneralReport();
                        break;
                    case "aplicar_accion":
                        panel = new Aplicar_Acciones();
                        break;
                    case "nuevo_equipo":
                        panel = new RegisterDeviceForm();
                        break;
                    case "revisar_placas":
                        panel = new VerifyIdDeviceForm();
                        break;
                    case "t_equipos_instalacion":
                        panel = new InventoryDevicesToSendForm();
                        break;
                    case "materiales":
                        panel = new MaterialsForm();
                        break;
                    case "orden_ingreso":
                        panel = new EntryOrderForm();
                        break;
                    case "orden_salida_materiales":
                        panel = new OrderOutputMaterials();
                        break;
                    case "prepa_orden_equipos":
                        panel = new InventoryDevicesSendForm();
                        break;
                    case "estado_ordenes":
                        panel = new StatusOrderProductionForm(rol_user);
                        break;
                    case "consulta_inventario_materiales":
                        panel = new MaterialsInventoryForm();
                        break;
                    case "equipos_danados":
                        panel = new BadDeviceForm();
                        break;
                    case "pedidos":
                        panel = new OrdersReport();
                        break;
                    case "equi_garantia":
                        panel = new ReportDeviceWarrantyReport();
                        break;
                    case "imp_orden_materiales":
                        panel = new WorkActionOutReport("00000");
                        break;
                    case "registrar_cartel":
                        panel = new CreateCartelForm();
                        
                        break;
                    default:
                        break;
                }
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
            _mysqlConnectionDatabase.CloseMysqlConnection();
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
            count_orden.Text = _mysqlConnectionDatabase.GetPendingOrder();
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
