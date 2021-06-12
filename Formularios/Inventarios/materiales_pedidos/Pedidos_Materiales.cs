using InventarioFod.Clases;
using InventarioFod.Clases.Entidades;
using InventarioFod.Clases.Manejo_De_Datos;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Windows.Forms;

namespace InventarioFod.Formularios.Inventarios.materiales_pedidos
{
    public partial class Pedidos_Materiales : Form
    {
        private Conexion_db_Mysql db_conn;
        private Equipos_Instalacion_Instituciones equipos;
        private Manejo_Documento_Excel manejo_documento;
        private List<Attachment> attachments; 

        public Pedidos_Materiales(string orden_trabajo)
        {
            InitializeComponent();
            ToolTip tool_email = new ToolTip();
            tool_email.SetToolTip(checkBox1,"Enviar Confirmacion por correo");
            ToolTip tool_aplicacion = new ToolTip();
            tool_email.SetToolTip(button1, "Aplicar Pedido");
            orden.Text = orden_trabajo;
            db_conn = Conexion_db_Mysql.Get_Instance;
            equipos = db_conn.Get_Equipos_Verificacion_Pedido(Convert.ToInt32(orden.Text));

            num_pedido.Text = db_conn.get_num_pedido().ToString("D10");
            cargar_data();
            manejo_documento = new Manejo_Documento_Excel();
            attachments = new List<Attachment>();
        }

        private void cargar_data()
        {


            cant_docente.Value = equipos.Port_docente;
            cant_preescolar.Value = equipos.Port_preescolar;
            cant_estu1.Value = equipos.Port_1_estudiante;
            cant_estu2.Value = equipos.Port_2_estudiante;
            //replicacion
            cant_docente2.Value = equipos.Port_docente;
            cant_preescolar2.Value = equipos.Port_preescolar;
            cant_estu1_2.Value = equipos.Port_1_estudiante;
            cant_estu2_2.Value = equipos.Port_2_estudiante;

            cant_servidor.Value = equipos.Servidor;
            cant_nas.Value = equipos.Nas;
            cant_proyector.Value = equipos.Proyector;
            cant_impresora.Value = equipos.Impresora;

            //replicacion
            cant_servidor2.Value = equipos.Servidor;
            cant_nas2.Value = equipos.Nas;
            cant_proyector2.Value = equipos.Proyector;
            cant_impresora2.Value = equipos.Impresora;

            cant_audifonos.Value = equipos.Audifonos;
            cant_mouse.Value = equipos.Mouse;
            cant_candado2.Value = equipos.Candados;

            //replicacion
            cant_audifonos2.Value = equipos.Audifonos;
            cant_mouse2.Value = equipos.Mouse;
            cant_candado2.Value = equipos.Candados;

            cant_convertirdor.Value = equipos.Convertidor;
            cant_regleta.Value = equipos.Regletas;
            cant_estension.Value = equipos.Extensiones;

            //replicacion
            cant_convertirdor2.Value = equipos.Convertidor;
            cant_regleta2.Value = equipos.Regletas;
            cant_estension2.Value = equipos.Extensiones;

            //replicacion
            cant_bultoproyector2.Value = equipos.Maletin_proyector;
            cant_maleport2.Value = equipos.Maletin_portatil;

            cant_router2.Value = equipos.Router;
            cant_switch2.Value = equipos.Switch24;

            cant_interno2.Value = equipos.Ap_interno;
            cant_externo2.Value = equipos.Ap_externo;

            cant_parlante1_2.Value = equipos.Parlantes_1;
            cant_parlante2_2.Value = equipos.Parlantes_2;

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

            cant_hdmi.Value = equipos.Cable_hdmi;
            cant_vga.Value = equipos.Cable_vga;


            cant_usb.Value = equipos.Cable_usb;
            cant_cartucho.Value = equipos.Cartucho_tinta;

            cant_teclado.Value = cant_servidor.Value;
            cant_mouseserver.Value = cant_servidor.Value;

            cant_blanco.Value = equipos.Patch_blanco;

            cant_poe.Value = equipos.Cargador_AP;

            //replicaion
            cant_parlante1_2.Value = equipos.Parlantes_1;
            cant_parlante2_2.Value = equipos.Parlantes_2;


            cant_unidad2.Value = equipos.Unidad_optica;
            cant_ups1_2.Value = equipos.UPS_1;
            cant_ups2_2.Value = equipos.UPS_2;

            cant_hdmi2.Value = equipos.Cable_hdmi;
            cant_vga2.Value = equipos.Cable_vga;


            cant_usb2.Value = equipos.Cable_usb;
            cant_cartucho2.Value = equipos.Cartucho_tinta;

            cant_teclado2.Value = cant_servidor.Value;
            cant_mouseserver2.Value = cant_servidor.Value;

            cant_blanco2.Value = equipos.Patch_blanco;

            cant_poe2.Value = equipos.Cargador_AP;

            cant_verde.Value = equipos.Patch_verde;

            cant_verde2.Value = equipos.Patch_verde;

            id_pedido.Text = "Numero de Pedido: "+Convert.ToString(equipos.Id_Registro);


        }
        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                db_conn.Insertar_Institucion_Equipos_final(equipos, orden.Text, "BODEGA", num_pedido.Text);
                MessageBox.Show("Estado Actualizado", "Opciones Accesorios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (checkBox1.Checked)
                {
                    string ruta_pedido = manejo_documento.SelectPedidoByOrden(orden.Text,"BODEGA");
                    string ruta_orden = manejo_documento.SelectOrdenTrabajo(orden.Text);
                    attachments.Add(new Attachment(ruta_pedido));
                    attachments.Add(new Attachment(ruta_orden));
                    enviar_correo send_mail = new enviar_correo(attachments);
                    send_mail.Send_mail();
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
