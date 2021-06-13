using InventarioFod.Clases;
using InventarioFod.Clases.Entidades;
using InventarioFod.Formularios.Consultas;
using System;
using System.Windows.Forms;

namespace InventarioFod.Formularios.Administrativo
{
    public partial class Inventario_Equipos_enviar : Form
    {
        private Conexion_db_Mysql db_conn;
        private Equipos_Instalacion_Instituciones equipos;

        public Inventario_Equipos_enviar()
        {
            InitializeComponent();
            db_conn = Conexion_db_Mysql.Get_Instance;
            db_conn.Verificar_Conexion();
        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            equipos = db_conn.Get_Equipos_Instituciones(txt_buscar.Text, "ADMINISTRATIVO", Convert.ToInt32(num_orden.Text)) ;
            label7.Text = db_conn.Obtener_Institucion(txt_buscar.Text, "consulta");
            cargar_data();
        }


        private void cargar_data()
        {
            label5.Text = equipos.Codigo;
            label3.Text = equipos.Modalidad;
            label42.Text = equipos.Condicion;

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

            cant_hdmi.Value = equipos.Cable_hdmi;
            cant_vga.Value = equipos.Cable_vga;


            cant_usb.Value = equipos.Cable_usb;
            cant_cartucho.Value = equipos.Cartucho_tinta;

            cant_teclado.Value = cant_servidor.Value;
            cant_mouseserver.Value = cant_servidor.Value;

            cant_blanco.Value = equipos.Patch_blanco;

            cant_poe.Value = equipos.Cargador_AP;

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
            Buscar_Registro_Pedidos buscar_pedido = new Buscar_Registro_Pedidos(txt_buscar,num_orden);
            buscar_pedido.Show();
        }

    }
}
