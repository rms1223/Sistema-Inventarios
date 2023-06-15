using SystemIventory.Classes;
using SystemIventory.Classes.DataBase;
using Microsoft.Reporting.WinForms;
using System;
using System.Windows.Forms;

namespace SystemIventory.Reports
{
    public partial class WorkActionOutReport : Form
    {
        string num_orden = string.Empty;
        private DataReports _dataReports;
        private ConnectionMysqlDatabase _mysqlConnectionDatabase;
        public WorkActionOutReport(string orden)
        {
            InitializeComponent();
            num_orden = orden;
            textBox1.Text = num_orden;
            _mysqlConnectionDatabase = ConnectionMysqlDatabase.Get_Instance;
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ProcessOutputMaterials();
        }
        private void ProcessOutputMaterials()
        {
            int orden = Convert.ToInt32(textBox1.Text);
            try
            {
                _dataReports = new DataReports
                {
                    
                    Reporte = rptsalida_mteriales,
                    NameTableDataSource = "DataSet1",
                    //NameTableDataSourceOpcional = "pedidos_db_despacho",
                    ReportEmbedResourse = "SystemInventory.ordensalidamateriales.rdlc",
                    GetParameters = new ReportParameter[]
                {

                    new ReportParameter("fecha", DateTime.Now.ToString("dd/MM/yyyy")),
                    new ReportParameter("Descripcion", _mysqlConnectionDatabase.GetDescriptionOutputOrderFromIdOrder(orden)),
                    new ReportParameter("Orden",orden.ToString("D7")),
                }
                };
                _dataReports.GetDataOutputMaterialsReport(textBox1.Text);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al procesar" + ex);
            }
        }
    }
}
