using InventarioFod.Clases;
using InventarioFod.Clases.Manejo_De_Datos.Conexion_DB;
using InventarioFod.Clases.Notificaciones;
using InventarioFod.Formularios;
using InventarioFod.Formularios.Acciones;
using InventarioFod.Formularios.Consultas;
using InventarioFod.Formularios.Correo;
using InventarioFod.Reportes;
using System;
using System.Threading;
using System.Windows.Forms;

namespace InventarioFod
{
    public partial class MenuPrincipal : Form
    {
        private Conexion_db_Mysql base_datos;
        private Thread hilo1;
        private TelegramNotify _noti;
        public MenuPrincipal()
        {
            hilo1 = new Thread(new ThreadStart(StartRun));
            hilo1.IsBackground = true;
            hilo1.Start();
            
            InitializeComponent();
            Lectura_xml xml = new Lectura_xml();
            base_datos = Conexion_db_Mysql.getInstance;
            base_datos.Estado_Tecnicos = true;
            base_datos.GET_Ubicaciones();
            base_datos.Get_Tipos_Inventarios();
            base_datos.Get_Tecnicos();
            if (Lectura_xml.NotifyEstate)
            {
                _noti = new TelegramNotify();
                _noti.SendMessageInit();
            }
            label3.Text = "RMS " + DateTime.Now.ToString("yyyy");
            toolStripStatusLabel2.Text = "Fecha: " + DateTime.Now.ToString("dd/MM/yyyy");
            treeView1.ExpandAll();
            StopRun();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cargar_panel(principal.get_instance);
        }

        private void cargar_panel(Object panel)
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

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            Object panel = null;
            switch (e.Node.Name)
            {
                case "inven_reeequi":
                    panel = principal.get_instance;
                    break;
                case "inven_acciones":
                    panel = Form_Malas.get_instance;
                    break;
                case "addAccion":
                    panel = new CargarAcciones();
                    break;
                case "list_reequi":
                    panel = Lista_inventario.Get_instance;
                    break;
                case "add_lista":
                    panel = new AgregarLista();
                    break;
                case "list_accion":
                    panel = new Lista_Acciones();
                    break;
                case "print_list":
                    panel = new Agregar_imp_list();
                    break;
                case "consul_List":
                    panel = new Consulta_Listado();
                    break;
                case "rpt_acciones":
                    panel = new ReporteAcciones();
                    break;
                case "rpt_listas":
                    panel = new ReporteListados();
                    break;
                case "verif_equipos":
                    panel = new Verificar_Equipos();
                    break;
                case "rpt_equi_accion":
                    panel = new ReporteGeneralDeAcciones();
                    break;
                case "rpt_equiposproveedor":
                    panel = new ReporteEquiposProveedor();
                    break;
                case "aplicar_accion":
                    panel = new Aplicar_Acciones();
                    break;
                case "Send_Mail":
                    panel = new Form_Mail();
                    break;
                default:
                    break;
            }
            if (panel != null)
            {
                cargar_panel(panel);
            }
            
            
        }

        private void cerraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            base_datos.Cerrar_Conexion();
            this.Close();
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void dffToolStripMenuItem_Click(object sender, EventArgs e)
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

    }
}
