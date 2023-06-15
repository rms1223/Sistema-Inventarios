using SystemIventory.Classes.DataBase;
using Microsoft.Reporting.WinForms;
using System;
using System.Windows.Forms;

namespace SystemIventory.Reports
{
    public partial class WorkActionGeneralReport : Form
    {
        public WorkActionGeneralReport()
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

            DataReports _dataReports = new DataReports
            {
                Reporte = reportgeneralacciones,
                NameTableDataSource = "lista_general",
                ReportEmbedResourse = "SystemInventory.reportegeneralequipos.rdlc",
                GetParameters = new ReportParameter[]
                {
                    new ReportParameter("fecha",DateTime.Now.ToString("dd/MM/yyyy")),
                }
                
            };
            _dataReports.GetDataGeneralReport();
        }

        private void T2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
