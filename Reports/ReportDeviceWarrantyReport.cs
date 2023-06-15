using SystemIventory.Classes.DataBase;
using Microsoft.Reporting.WinForms;
using System;
using System.Windows.Forms;

namespace SystemIventory.Reports
{
    public partial class ReportDeviceWarrantyReport : Form
    {
        DataReports _dataReports;
        public ReportDeviceWarrantyReport()
        {
            InitializeComponent();
        }

        private void LoadDevicesWarranty(object sender, EventArgs e)
        {

            this.rpt_garantia.RefreshReport();
        }

        private void XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                
                _dataReports = new DataReports
                {
                    Reporte = rpt_garantia,
                    NameTableDataSource = "equipo_garantia",
                    ReportEmbedResourse = "SystemInventory.reportegarantia.rdlc",
                    GetParameters = new ReportParameter[]
                    {

                        new ReportParameter("fecha",DateTime.Now.ToString("dd/MM/yyyy")),

                    }
                };
                _dataReports.GetDataWarrantyReport(comboBox1.SelectedItem.ToString());
            }
        }

        private void ComboBox1_Leave(object sender, EventArgs e)
        {
            buscar.Focus();
        }
    }
}
