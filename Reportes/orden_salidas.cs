using InventarioFod.Clases;
using InventarioFod.Clases.Manejo_De_Datos;
using Microsoft.Reporting.WinForms;
using System;
using System.Windows.Forms;

namespace InventarioFod.Reportes
{
    public partial class orden_salidas : Form
    {
        string num_orden = string.Empty;
        private Manejo_Datos_Reportes Datos_Reporte;
        private Conexion_db_Mysql basedatos;
        public orden_salidas(string orden)
        {
            InitializeComponent();
            num_orden = orden;
            textBox1.Text = num_orden;
            basedatos = Conexion_db_Mysql.Get_Instance;
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            procesar_salida_materiales();
        }
        private void procesar_salida_materiales()
        {
            int orden = Convert.ToInt32(textBox1.Text);
            try
            {
                Datos_Reporte = new Manejo_Datos_Reportes
                {
                    
                    Reporte = rptsalida_mteriales,
                    Nombre_Table_DataSource = "DataSet1",
                    //Nombre_Table_DataSource_opcional = "pedidos_db_despacho",
                    Report_Embed_Resourse = "InventarioFod.ordensalidamateriales.rdlc",
                    Get_Parameters = new ReportParameter[]
                {

                    new ReportParameter("fecha", DateTime.Now.ToString("dd/MM/yyyy")),
                    new ReportParameter("Descripcion", basedatos.Get_Descripcion_Salida_Materiales(orden)),
                    new ReportParameter("Orden",orden.ToString("D7")),
                }
                };
                Datos_Reporte.Generar_Reporte_salida_materiales(textBox1.Text);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al procesar" + ex);
            }
        }
    }
}
