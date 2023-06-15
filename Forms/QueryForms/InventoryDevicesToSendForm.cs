using SystemIventory.Classes;
using SystemIventory.Classes.Entities;
using SystemIventory.Forms.Consultas;
using System;
using System.Windows.Forms;

namespace SystemIventory.Forms.AdministrativesForms
{
    public partial class InventoryDevicesToSendForm : Form
    {
        private ConnectionMysqlDatabase _mysqlConnectionDatabase;
        private InstalledDevice _devices;

        public InventoryDevicesToSendForm()
        {
            InitializeComponent();
            _mysqlConnectionDatabase = ConnectionMysqlDatabase.Get_Instance;
            _mysqlConnectionDatabase.VerifyDatabaseConnection();
        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            _devices = _mysqlConnectionDatabase.GetDevicesInInstitutionFromCode(txt_buscar.Text, "ADMINISTRATIVO", Convert.ToInt32(num_orden.Text)) ;
            label7.Text = _mysqlConnectionDatabase.GetInstitutionCode(txt_buscar.Text, "consulta");
            LoadData();
        }


        private void LoadData()
        {
            label5.Text = _devices.Codigo;
            label3.Text = _devices.Modalidad;
            label42.Text = _devices.Condicion;

            cant_docente.Value = _devices.Port_docente;
            cant_preescolar.Value = _devices.Port_preescolar;
            cant_estu1.Value = _devices.Port_1_estudiante;
            cant_estu2.Value = _devices.Port_2_estudiante;

            cant_servidor.Value = _devices.Servidor;
            cant_nas.Value = _devices.Nas;
            cant_proyector.Value = _devices.Proyector;
            cant_impresora.Value = _devices.Impresora;

            cant_audifonos.Value = _devices.Audifonos;
            cant_mouse.Value = _devices.Mouse;
            cant_candado.Value = _devices.Candados;

            cant_convertirdor.Value = _devices.Convertidor;
            cant_regleta.Value = _devices.Regletas;
            cant_estension.Value = _devices.Extensiones;

            cant_bultoproyector.Value = _devices.Maletin_proyector;
            cant_maleport.Value = _devices.Maletin_portatil;

            cant_router.Value = _devices.Router;
            cant_switch.Value = _devices.Switch24;

            cant_interno.Value = _devices.Ap_interno;
            cant_externo.Value = _devices.Ap_externo;

            cant_parlante1.Value = _devices.Parlantes_1;
            cant_parlante2.Value = _devices.Parlantes_2;


            cant_unidad.Value = _devices.Unidad_optica;
            cant_ups1.Value = _devices.UPS_1;
            cant_ups2.Value = _devices.UPS_2;

            cant_hdmi.Value = _devices.Cable_hdmi;
            cant_vga.Value = _devices.Cable_vga;


            cant_usb.Value = _devices.Cable_usb;
            cant_cartucho.Value = _devices.Cartucho_tinta;

            cant_teclado.Value = cant_servidor.Value;
            cant_mouseserver.Value = cant_servidor.Value;

            cant_blanco.Value = _devices.Patch_blanco;

            cant_poe.Value = _devices.Cargador_AP;

            if (cant_nas.Value != 0 || cant_servidor.Value != 0)
            {
                cant_verde.Value = 1;
            }


        }

        private void XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SearchOrderRecordForm buscar_pedido = new SearchOrderRecordForm(txt_buscar,num_orden);
            buscar_pedido.Show();
        }

    }
}
