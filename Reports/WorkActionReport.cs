using SystemIventory.Classes;
using SystemIventory.Classes.DataBase;
using SystemIventory.Forms.Acciones;
using Microsoft.Reporting.WinForms;
using System;
using System.Windows.Forms;

namespace SystemIventory.Reports
{
    public partial class salida_materiales : Form
    {
        DataReports _dataReports;

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

        private void Button1_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                int accion_num = Convert.ToInt32(textBox1.Text);
                _dataReports = new DataReports
                {
                    Reporte = rptacciones,
                    NameTableDataSource = "inventario_acciones",
                    NameTableDataSourceOpcional = "materiales",
                    ReportEmbedResourse = "SystemInventory.reporteacciones.rdlc",
                    GetParameters = new ReportParameter[]
                    {
                    new ReportParameter("accion",accion_num.ToString("D7")),
                    new ReportParameter("fecha",DateTime.Now.ToString("dd/MM/yyyy")),

                    }
                };
                if (!String.IsNullOrEmpty(textBox1.Text))
                {
                    _dataReports.GetDataWorkActionReport(Convert.ToInt32(textBox1.Text));
                }
                else
                {
                    MessageBox.Show("Seleccione una acción", "Opciones de Acciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            

        }

        private void T1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void T2ToolStripMenuItem_Click(object sender, EventArgs e)
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
            SearchWorkAction _searchWorkaction = new SearchWorkAction(textBox1,VariablesName.OutputOrder);
            _searchWorkaction.Show();
        }
    }
}
