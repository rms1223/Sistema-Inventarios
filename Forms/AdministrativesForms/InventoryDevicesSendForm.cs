using SystemIventory.Classes;
using SystemIventory.Classes.Entities;
using System;
using System.Windows.Forms;
using SystemInventory.Classes.IModels;
using SystemInventory.Classes.Models;

namespace SystemIventory.Forms.AdministrativesForms
{
    public partial class InventoryDevicesSendForm : Form
    {
        private OperationsRepository _dataBaseTool;
        private IDataBaseRepository _dataBaseRepository;
        private InstalledDevice equipos;
        public InventoryDevicesSendForm()
        {
            InitializeComponent();
            _dataBaseRepository = DataBaseRepository.Get_Instance;
            _dataBaseTool = OperationsRepository.Get_Instance;
            _dataBaseTool.VerifyDatabaseConnection();

            orden_trabajo.Text = ((int)_dataBaseRepository.GetIdWorkActionFromType("orden_trabajo").Result).ToString("D7");
            num_pedido.Text = ((int)_dataBaseRepository.GetIdOrder().Result).ToString("D10");
        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            equipos = (InstalledDevice)_dataBaseRepository.GetDevicesInInstitutionFromCode(txt_buscar.Text,"ADMIN",0).Result;
            centro_educativo.Text = (string)_dataBaseRepository.GetInstitutionCode(txt_buscar.Text, "consulta").Result;
            cargar_data();
        }
        private void cargar_data()
        {
            codigo_text.Text = equipos.Codigo;
            modalidad_text.Text = equipos.Modalidad;
            condicion_txt.Text = equipos.Condicion;

            cant_docente.Value = equipos.Port_docente;
            cant_preescolar.Value = equipos.Port_preescolar;
            cant_estu1.Value = equipos.Port_1_estudiante;
            cant_estu2.Value = equipos.Port_2_estudiante;

            cant_servidor.Value = equipos.Servidor;
            cant_nas.Value = equipos.Nas;
            cant_proyector.Value = equipos.Proyector;
            cant_impresora.Value = equipos.Impresora;

            cant_audifonos.Value = equipos.Audifonos;
            cant_mouse.Value = equipos.Mouse;
            cant_candado.Value = equipos.Candados;

            cant_convertirdor.Value = equipos.Convertidor;
            cant_regleta.Value = equipos.Regletas;
            cant_estension.Value = equipos.Extensiones;

            cant_bultoproyector.Value = equipos.Maletin_proyector;
            cant_maleport.Value = equipos.Maletin_portatil;

            cant_router.Value = equipos.Router;
            cant_switch.Value = equipos.Switch24;

            cant_interno.Value = equipos.Ap_interno;
            cant_externo.Value = equipos.Ap_externo;

            cant_parlante1.Value = equipos.Parlantes_1;
            cant_parlante2.Value = equipos.Parlantes_2;


            cant_unidad.Value = equipos.Unidad_optica;
            cant_ups1.Value = equipos.UPS_1;
            cant_ups2.Value = equipos.UPS_2;

            cant_hdmi.Value = cant_proyector.Value;
            cant_vga.Value = cant_proyector.Value;


            cant_usb.Value = cant_impresora.Value;
            cant_cartucho.Value = cant_impresora.Value * 2;

            cant_teclado.Value = cant_servidor.Value;
            cant_mouseserver.Value = cant_servidor.Value;


            if (cant_nas.Value != 0 || cant_servidor.Value != 0)
            {
                cant_verde.Value = 1;
            }
            else
            {
                cant_verde.Value = 0;
            }


        }

        private void Button2_Click(object sender, EventArgs e)
        {
            InstalledDevice equipos = new InstalledDevice();
            button2.Enabled = false;
            equipos.Codigo = codigo_text.Text;
            equipos.Modalidad = modalidad_text.Text;
            equipos.Condicion = condicion_txt.Text;
            equipos.Lote = num_lote.Text;
            equipos.observacion = observaciones.Text;

            equipos.Port_docente= Convert.ToInt32(cant_docente.Value);
            equipos.Port_preescolar= Convert.ToInt32(cant_preescolar.Value);
            equipos.Port_1_estudiante= Convert.ToInt32(cant_estu1.Value);
            equipos.Port_2_estudiante= Convert.ToInt32(cant_estu2.Value);
                                                                             
            equipos.Servidor= Convert.ToInt32(cant_servidor.Value);
            equipos.Nas= Convert.ToInt32(cant_nas.Value);
            equipos.Proyector= Convert.ToInt32(cant_proyector.Value);
            equipos.Impresora= Convert.ToInt32(cant_impresora.Value);
                                                                             
            equipos.Audifonos= Convert.ToInt32(cant_audifonos.Value);
            equipos.Mouse= Convert.ToInt32(cant_mouse.Value);
            equipos.Candados= Convert.ToInt32(cant_candado.Value);
                                                                             
            equipos.Convertidor= Convert.ToInt32(cant_convertirdor.Value);
            equipos.Regletas = Convert.ToInt32(cant_regleta.Value);
            equipos.Extensiones= Convert.ToInt32(cant_estension.Value);
                                                                             
            equipos.Maletin_proyector= Convert.ToInt32(cant_bultoproyector.Value);
            equipos.Maletin_portatil= Convert.ToInt32(cant_maleport.Value);
                                                                             
            equipos.Router= Convert.ToInt32(cant_router.Value);
            equipos.Switch24= Convert.ToInt32(cant_switch.Value);
                                                                             
            equipos.Ap_interno= Convert.ToInt32(cant_interno.Value);
            equipos.Ap_externo= Convert.ToInt32(cant_externo.Value);
                                                                             
            equipos.Parlantes_1= Convert.ToInt32(cant_parlante1.Value);
            equipos.Parlantes_2= Convert.ToInt32(cant_parlante2.Value);                                                                                                                                                      
            equipos.Unidad_optica= Convert.ToInt32(cant_unidad.Value);
            equipos.UPS_1= Convert.ToInt32(cant_ups1.Value);
            equipos.UPS_2 = Convert.ToInt32(cant_ups2.Value);
            equipos.Proyector = Convert.ToInt32(cant_proyector.Value);
            equipos.Impresora = Convert.ToInt32(cant_impresora.Value);
            equipos.Servidor = Convert.ToInt32(cant_servidor.Value); 
            equipos.Cargador_AP = Convert.ToInt32(cant_poe.Value);
            equipos.Patch_blanco = Convert.ToInt32(cant_blanco.Value);
            equipos.Patch_verde = Convert.ToInt32(cant_verde.Value);
            equipos.Cable_hdmi = Convert.ToInt32(cant_hdmi.Value);
            equipos.Cable_vga = Convert.ToInt32(cant_vga.Value);
            equipos.Cable_usb = Convert.ToInt32(cant_usb.Value);
            equipos.Cartucho_tinta = Convert.ToInt32(cant_cartucho.Value);
            equipos.Mouse = Convert.ToInt32(cant_mouse.Value);
            _dataBaseRepository.SaveFinalInventoryOrder(equipos, orden_trabajo.Text,"ADMINISTRATIVO",num_pedido.Text);
            MessageBox.Show("Estado Actualizado", "Opciones Accesorios", MessageBoxButtons.OK, MessageBoxIcon.Information);
            button2.Enabled = true;
        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void NuevoRegistroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewRegisterForm registro = new NewRegisterForm(codigo_text, centro_educativo, modalidad_text, condicion_txt, num_lote);
            registro.Show();
        }

        private void Cant_servidor_ValueChanged(object sender, EventArgs e)
        {
            cant_teclado.Value = cant_servidor.Value;
            cant_mouseserver.Value = cant_servidor.Value;
            cant_verde.Value = cant_servidor.Value;
            cant_candado.Value = cant_servidor.Value;
        }

        private void Cant_nas_ValueChanged(object sender, EventArgs e)
        {
            cant_candado.Value = cant_nas.Value;
            cant_verde.Value = cant_nas.Value;
        }

        private void Cant_impresora_ValueChanged(object sender, EventArgs e)
        {
            cant_usb.Value += 1;
            cant_cartucho.Value += 2;
        }

        private void Cant_proyector_ValueChanged(object sender, EventArgs e)
        {
            cant_bultoproyector.Value += 1;
            cant_hdmi.Value += 1;
            cant_vga.Value += 1;
        }

        private void Cant_router_ValueChanged(object sender, EventArgs e)
        {
            cant_blanco.Value += 1;
        }

        private void Cant_interno_ValueChanged(object sender, EventArgs e)
        {
            if (cant_interno.Value == 0)
            {
                cant_blanco.Value = 0;
            }
            else
            {
                cant_blanco.Value +=2;
            }
            
        }

        private void Cant_externo_ValueChanged(object sender, EventArgs e)
        {

            if (cant_externo.Value == 0)
            {
                cant_blanco.Value = 0;
            }
            else
            {
                cant_blanco.Value += 2;
            }
        }

        private void VerificarInstalacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VerifyInstallationForm verify = new VerifyInstallationForm();
            verify.Show();
        }

        private void Cant_estu1_ValueChanged(object sender, EventArgs e)
        {
            suma_articulos();
        }
        private void suma_articulos()
        {
            decimal total = (cant_estu1.Value + cant_estu2.Value + cant_docente.Value + cant_preescolar.Value);
            cant_audifonos.Value = total; 
            cant_mouse.Value = total;
            cant_maleport.Value = total;
        }

        private void Cant_estu2_ValueChanged(object sender, EventArgs e)
        {
            
            suma_articulos();
        }

        private void Cant_preescolar_ValueChanged(object sender, EventArgs e)
        {
            suma_articulos();
        }

        private void Cant_docente_ValueChanged(object sender, EventArgs e)
        {
            suma_articulos();
        }
    }
}
