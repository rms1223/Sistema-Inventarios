using InventarioFod.Clases;
using InventarioFod.Clases.Manejo_De_Datos;
using Microsoft.Reporting.WinForms;
using System;
using System.Windows.Forms;

namespace InventarioFod.Reportes
{
    public partial class VerPediddo : Form
    {
        private Manejo_Datos_Reportes Datos_Reporte;
        private Conexion_db_Mysql basedatos;
        string num_orden = string.Empty;
        public VerPediddo(string orden)
        {
            InitializeComponent();
            basedatos = Conexion_db_Mysql.Get_Instance;
            num_orden = orden;
            Cargar_Solicitud();
        }
        

        
        private void VerPediddo_Load(object sender, EventArgs e)
        {

            this.rptpedidos.RefreshReport();
        }

        private void Cargar_Solicitud()
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
                    new ReportParameter("institucion",basedatos.Get_Descripcion_Orden_Trabajo(Convert.ToInt32(num_orden)))
                }
                };
                Datos_Reporte.Generar_Reporte_Pedidos(Convert.ToInt32(num_orden), "ADMINISTRATIVO");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al procesar" + ex);
            }
        }
    }
}
