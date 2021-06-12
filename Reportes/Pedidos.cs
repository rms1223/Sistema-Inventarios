using InventarioFod.Clases;
using InventarioFod.Clases.Manejo_De_Datos;
using InventarioFod.Formularios.Acciones;
using Microsoft.Reporting.WinForms;
using System;
using System.Windows.Forms;

namespace InventarioFod.Reportes
{
    public partial class Pedidos : Form
    {

        private Manejo_Datos_Reportes Datos_Reporte;
        private Conexion_db_Mysql basedatos;
        public Pedidos()
        {
            InitializeComponent();
            basedatos = Conexion_db_Mysql.Get_Instance;

        }

        private void Pedidos_Load(object sender, EventArgs e)
        {

            this.rptpedidos.RefreshReport();
        }
        public ReportViewer GetReport()
        {
            return rptpedidos;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                Datos_Reporte = new Manejo_Datos_Reportes
                {
                    Reporte = rptpedidos,
                    Nombre_Table_DataSource = "pedidos_db",
                    //Nombre_Table_DataSource_opcional = "pedidos_db_despacho",
                    Report_Embed_Resourse = "InventarioFod.pedidos.rdlc",
                    Get_Parameters = new ReportParameter[]
                {
                    new ReportParameter("fecha", DateTime.Now.ToString("dd/MM/yyyy")),
                    new ReportParameter("institucion",basedatos.Get_Descripcion_Orden_Trabajo(Convert.ToInt32(orden_txt.Text)))
                }
                };
                Datos_Reporte.Generar_Reporte_Pedidos(Convert.ToInt32(orden_txt.Text),tipo_pedido.Text);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al procesar"+ex);
            }
            
        }

        private void XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Tipo_pedido_Leave(object sender, EventArgs e)
        {
            btn_buscar.Focus();
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Buscar_Acciones buscar_orden = new Buscar_Acciones(orden_txt,Var_Name.ORDEN_SALIDA);
            buscar_orden.Show();
        }
    }
}
