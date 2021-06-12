using InventarioFod.Clases;
using InventarioFod.Formularios;
using InventarioFod.Formularios.Acciones;
using InventarioFod.Formularios.Administrativo;
using InventarioFod.Formularios.Consultas.inventarios_materiales;
using InventarioFod.Formularios.Inventarios;
using InventarioFod.Formularios.Inventarios.equipos_malos;
using InventarioFod.Formularios.Inventarios.estado_ordenes;
using InventarioFod.Formularios.Inventarios.usuarios;
using InventarioFod.Reportes;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace InventarioFod
{
    public partial class MenuPrincipal : Form
    {
        private Conexion_db_Mysql base_datos;
        private Thread hilo1;
        private login_user login;
        private string rol_user;
        public int xClick = 0, yClick = 0;
        public string Mensaje_add_correo { get; set; }

        public MenuPrincipal(login_user principal, string rol)
        {
            login = principal;
            rol_user = rol;
            
            hilo1 = new Thread(new ThreadStart(StartRun))
            {
                IsBackground = true
            };
            hilo1.Start();
            
            InitializeComponent();
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.WindowState = FormWindowState.Maximized;
            opciones.Visible = false;
            base_datos = Conexion_db_Mysql.Get_Instance;
            base_datos.Estado_Tecnicos = true;
            base_datos.GET_Ubicaciones();
            
            label3.Text = "RMS " + DateTime.Now.ToString("yyyy");
            toolStripStatusLabel2.Text = "Fecha: " + Var_Name.Fecha_Actual;
            treeView1.ExpandAll();
            StopRun();
            
            Validar_usuario();

            timer1.Start();
            timer2.Start();
            Validar_estadoConexion();
            


        }
        private void Validar_usuario()
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
            Cargar_panel(Form_Principal.get_instance);
        }

        private void Cargar_panel(object panel)
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
                        panel = Form_Principal.get_instance;
                        break;
                    case "list_reequi":
                        Lista_inventario.Get_instance.Rol_Usuario = rol_user;
                        panel = Lista_inventario.Get_instance;

                        break;
                    case "rpt_acciones":
                        panel = new salida_materiales();
                        break;
                    case "verif_equipos":
                        panel = new Verificar_Equipos();
                        break;
                    case "rpt_equi_accion":
                        panel = new ReporteGeneralDeAcciones();
                        break;
                    case "aplicar_accion":
                        panel = new Aplicar_Acciones();
                        break;
                    case "nuevo_equipo":
                        panel = new Ingreso_Equipos();
                        break;
                    case "revisar_placas":
                        panel = new Revisar_placas_ordenes();
                        break;
                    case "t_equipos_instalacion":
                        panel = new Inventario_Equipos_enviar();
                        break;
                    case "materiales":
                        panel = new Materiales();
                        break;
                    case "orden_ingreso":
                        panel = new Orden_Ingreso();
                        break;
                    case "orden_salida_materiales":
                        panel = new Orden_salida_materiales();
                        break;
                    case "prepa_orden_equipos":
                        panel = new Inventarios_Equipos_enviar();
                        break;
                    case "estado_ordenes":
                        panel = new Estados_ordenes_produccion(rol_user);
                        break;
                    case "consulta_inventario_materiales":
                        panel = new Inventario_materiales();
                        break;
                    case "equipos_danados":
                        panel = new Equipos_malos();
                        break;
                    case "pedidos":
                        panel = new Pedidos();
                        break;
                    case "equi_garantia":
                        panel = new Equipos_Garantias();
                        break;
                    case "imp_orden_materiales":
                        panel = new orden_salidas("00000");
                        break;
                    case "registrar_cartel":
                        panel = new CrearCartel();
                        
                        break;
                    default:
                        break;
                }
                if (panel != null)
                {
                    Cargar_panel(panel);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar vuelva a intentarlo", "Error al Iniciar", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            
            
            
        }


        private void CerraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            base_datos.Cerrar_Conexion();
            this.Close();
            login.Close();
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
        private void StartRun()
        {
            form_splash = new Form_Cargar();
            Application.Run(form_splash);
        }
        private void StopRun()
        {
            if (form_splash.InvokeRequired)
            {
                form_splash.Invoke(new MethodInvoker(StopRun));
            }
            else
            {
                Application.ExitThread();
            }
            
        }

        private void AgregarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            agregar_usuario addUser = new agregar_usuario();
            addUser.Show();
        }

        private void MenuStrip1_MouseMove(object sender, MouseEventArgs e)
        {
            Mover_form(e);
        }

        private void ToolStripStatusLabel3_Click(object sender, EventArgs e)
        {
            base_datos.Verificar_Conexion();
        }

        private void Panel2_MouseMove(object sender, MouseEventArgs e)
        {
            Mover_form(e);
        }
        public void Validar_estadoConexion()
        {
            string estado = base_datos.Estado_Conexion();
            
            if (estado.Equals("DISPONIBLE"))
            {
                estado_conLabel.ForeColor = Color.Green;
            }
            else
            {
                estado_conLabel.ForeColor = Color.Red;
            }
            estado_conLabel.Text = estado;
            base_datos.Verificar_Conexion();
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            Validar_estadoConexion();
            string message_server = base_datos.mensaje_conexion;
            if (!message_server.Contains("ERROR"))
            {
                message_status.ForeColor = Color.Green;
            }
            else
            {
                message_status.ForeColor = Color.Red;
            }
            message_status.Text = message_server;
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            count_orden.Text = base_datos.Get_Orden_Pendientes();
        }


        private void Mover_form(MouseEventArgs e)
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
