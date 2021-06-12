using InventarioFod.Clases;
using InventarioFod.Clases.Manejo_De_Datos;
using InventarioFod.Formularios.Acciones;
using Microsoft.Reporting.WinForms;
using System;
using System.Windows.Forms;

namespace InventarioFod.Reportes
{
    public partial class salida_materiales : Form
    {
        Manejo_Datos_Reportes Datos_Reporte;

        public salida_materiales()
        {
            InitializeComponent();
            ToolTip buton = new ToolTip();
            buton.SetToolTip(button1, "Generar Reporte");

        }
        public ReportViewer GetReport()
        {
            return rptacciones;
        }
        private void ReporteAcciones_Load(object sender, EventArgs e)
        {

            this.rptacciones.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                int accion_num = Convert.ToInt32(textBox1.Text);
                Datos_Reporte = new Manejo_Datos_Reportes
                {
                    Reporte = rptacciones,
                    Nombre_Table_DataSource = "inventario_acciones",
                    Nombre_Table_DataSource_opcional = "materiales",
                    Report_Embed_Resourse = "InventarioFod.reporteacciones.rdlc",
                    Get_Parameters = new ReportParameter[]
                    {
                    new ReportParameter("accion",accion_num.ToString("D7")),
                    new ReportParameter("fecha",DateTime.Now.ToString("dd/MM/yyyy")),

                    }
                };
                if (!String.IsNullOrEmpty(textBox1.Text))
                {
                    Datos_Reporte.Generar_Reporte_Acciones(Convert.ToInt32(textBox1.Text));
                }
                else
                {
                    MessageBox.Show("Seleccione una acción", "Opciones de Acciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            

        }

        private void t1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void t2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private string GetRenderExtension(RenderingExtension extension)
        {
            switch (extension.Name)
            {
                case "PDF":
                    return ".pdf";
                case "EXCELOPENXML":
                    return ".xlsx";
                case "WORDOPENXML":
                    return ".docx";
                default:
                    break;
            }
            throw new NotImplementedException("Extencion not implements..");
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Buscar_Acciones buscar_orden = new Buscar_Acciones(textBox1,Var_Name.ORDEN_SALIDA);
            buscar_orden.Show();
        }
    }
}
