using SystemIventory.Classes;
using SystemIventory.Classes.Entities;
using SystemIventory.Classes.DataBase;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Windows.Forms;
using SystemInventory.Classes.IModels;
using SystemInventory.Classes.Models;

namespace SystemIventory.Forms.InventoriesForms.MaterialsOrderForm
{
    public partial class MaterialsOrderForm : Form
    {
        private IDataBaseRepository _dataBaseRepository;
        private InstalledDevice _installedDevices;
        private DataOperationDocument _dataOperations;
        private List<Attachment> _listAttachments; 

        public MaterialsOrderForm(string orden_trabajo)
        {
            InitializeComponent();
            ToolTip tool_email = new ToolTip();
            tool_email.SetToolTip(checkBox1,"Enviar Confirmacion por correo");
            ToolTip tool_aplicacion = new ToolTip();
            tool_email.SetToolTip(button1, "Aplicar Pedido");
            orden.Text = orden_trabajo;
            _dataBaseRepository = DataBaseRepository.Get_Instance;
            _installedDevices = (InstalledDevice)_dataBaseRepository.GetFinalInventoryOrder(Convert.ToInt32(orden.Text)).Result;

            num_pedido.Text = ((int)_dataBaseRepository.GetIdOrder().Result).ToString("D10");
            LoadData();
            _dataOperations = new DataOperationDocument();
            _listAttachments = new List<Attachment>();
        }

        private void LoadData()
        {


            cant_docente.Value = _installedDevices.Port_docente;
            cant_preescolar.Value = _installedDevices.Port_preescolar;
            cant_estu1.Value = _installedDevices.Port_1_estudiante;
            cant_estu2.Value = _installedDevices.Port_2_estudiante;
            //replicacion
            cant_docente2.Value = _installedDevices.Port_docente;
            cant_preescolar2.Value = _installedDevices.Port_preescolar;
            cant_estu1_2.Value = _installedDevices.Port_1_estudiante;
            cant_estu2_2.Value = _installedDevices.Port_2_estudiante;

            cant_servidor.Value = _installedDevices.Servidor;
            cant_nas.Value = _installedDevices.Nas;
            cant_proyector.Value = _installedDevices.Proyector;
            cant_impresora.Value = _installedDevices.Impresora;

            //replicacion
            cant_servidor2.Value = _installedDevices.Servidor;
            cant_nas2.Value = _installedDevices.Nas;
            cant_proyector2.Value = _installedDevices.Proyector;
            cant_impresora2.Value = _installedDevices.Impresora;

            cant_audifonos.Value = _installedDevices.Audifonos;
            cant_mouse.Value = _installedDevices.Mouse;
            cant_candado2.Value = _installedDevices.Candados;

            //replicacion
            cant_audifonos2.Value = _installedDevices.Audifonos;
            cant_mouse2.Value = _installedDevices.Mouse;
            cant_candado2.Value = _installedDevices.Candados;

            cant_convertirdor.Value = _installedDevices.Convertidor;
            cant_regleta.Value = _installedDevices.Regletas;
            cant_estension.Value = _installedDevices.Extensiones;

            //replicacion
            cant_convertirdor2.Value = _installedDevices.Convertidor;
            cant_regleta2.Value = _installedDevices.Regletas;
            cant_estension2.Value = _installedDevices.Extensiones;

            //replicacion
            cant_bultoproyector2.Value = _installedDevices.Maletin_proyector;
            cant_maleport2.Value = _installedDevices.Maletin_portatil;

            cant_router2.Value = _installedDevices.Router;
            cant_switch2.Value = _installedDevices.Switch24;

            cant_interno2.Value = _installedDevices.Ap_interno;
            cant_externo2.Value = _installedDevices.Ap_externo;

            cant_parlante1_2.Value = _installedDevices.Parlantes_1;
            cant_parlante2_2.Value = _installedDevices.Parlantes_2;

            cant_bultoproyector.Value = _installedDevices.Maletin_proyector;
            cant_maleport.Value = _installedDevices.Maletin_portatil;

            cant_router.Value = _installedDevices.Router;
            cant_switch.Value = _installedDevices.Switch24;

            cant_interno.Value = _installedDevices.Ap_interno;
            cant_externo.Value = _installedDevices.Ap_externo;




            cant_parlante1.Value = _installedDevices.Parlantes_1;
            cant_parlante2.Value = _installedDevices.Parlantes_2;


            cant_unidad.Value = _installedDevices.Unidad_optica;
            cant_ups1.Value = _installedDevices.UPS_1;
            cant_ups2.Value = _installedDevices.UPS_2;

            cant_hdmi.Value = _installedDevices.Cable_hdmi;
            cant_vga.Value = _installedDevices.Cable_vga;


            cant_usb.Value = _installedDevices.Cable_usb;
            cant_cartucho.Value = _installedDevices.Cartucho_tinta;

            cant_teclado.Value = cant_servidor.Value;
            cant_mouseserver.Value = cant_servidor.Value;

            cant_blanco.Value = _installedDevices.Patch_blanco;

            cant_poe.Value = _installedDevices.Cargador_AP;

            //replicaion
            cant_parlante1_2.Value = _installedDevices.Parlantes_1;
            cant_parlante2_2.Value = _installedDevices.Parlantes_2;


            cant_unidad2.Value = _installedDevices.Unidad_optica;
            cant_ups1_2.Value = _installedDevices.UPS_1;
            cant_ups2_2.Value = _installedDevices.UPS_2;

            cant_hdmi2.Value = _installedDevices.Cable_hdmi;
            cant_vga2.Value = _installedDevices.Cable_vga;


            cant_usb2.Value = _installedDevices.Cable_usb;
            cant_cartucho2.Value = _installedDevices.Cartucho_tinta;

            cant_teclado2.Value = cant_servidor.Value;
            cant_mouseserver2.Value = cant_servidor.Value;

            cant_blanco2.Value = _installedDevices.Patch_blanco;

            cant_poe2.Value = _installedDevices.Cargador_AP;

            cant_verde.Value = _installedDevices.Patch_verde;

            cant_verde2.Value = _installedDevices.Patch_verde;

            id_pedido.Text = "Numero de Pedido: "+Convert.ToString(_installedDevices.Id_Registro);


        }
        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                _dataBaseRepository.SaveFinalInventoryOrder(_installedDevices, orden.Text, "BODEGA", num_pedido.Text);
                MessageBox.Show("Estado Actualizado", "Opciones Accesorios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (checkBox1.Checked)
                {
                    string ruta_pedido = _dataOperations.SelectOrderByType(orden.Text,"BODEGA");
                    string ruta_orden = _dataOperations.SelectWorkAction(orden.Text);
                    _listAttachments.Add(new Attachment(ruta_pedido));
                    _listAttachments.Add(new Attachment(ruta_orden));
                    OperationMail send_mail = new OperationMail(_listAttachments);
                    send_mail.SendMail();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al aplicar pedido vuelve a intentarlo\n"+ex, "Opciones Pedidos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
