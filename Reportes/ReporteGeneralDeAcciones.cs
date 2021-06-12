using InventarioFod.Clases.Manejo_De_Datos;
using Microsoft.Reporting.WinForms;
using System;
using System.Windows.Forms;

namespace InventarioFod.Reportes
{
    public partial class ReporteGeneralDeAcciones : Form
    {
        public ReporteGeneralDeAcciones()
        {
            InitializeComponent();
        }

        private void ReporteGeneralDeAcciones_Load(object sender, EventArgs e)
        {

            this.reportgeneralacciones.RefreshReport();
            this.reportgeneralacciones.RefreshReport();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            Manejo_Datos_Reportes Datos_Reporte = new Manejo_Datos_Reportes
            {
                Reporte = reportgeneralacciones,
                Nombre_Table_DataSource = "lista_general",
                Report_Embed_Resourse = "InventarioFod.reportegeneralequipos.rdlc",
                Get_Parameters = new ReportParameter[]
                {
                    new ReportParameter("fecha",DateTime.Now.ToString("dd/MM/yyyy")),
                }
                
            };
            Datos_Reporte.Generar_Reporte_General();
        }

        private void T2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
