using SystemIventory.Classes;
using SystemIventory.Classes.DataBase;
using Microsoft.Reporting.WinForms;
using System;
using System.Windows.Forms;

namespace SystemIventory.Reports
{
    public partial class ViewOrderReport : Form
    {
        private DataReports _dataReports;
        private ConnectionMysqlDatabase _mysqlConnectionDatabase;
        string _idOrder = string.Empty;
        public ViewOrderReport(string orden)
        {
            InitializeComponent();
            _mysqlConnectionDatabase = ConnectionMysqlDatabase.Get_Instance;
            _idOrder = orden;
            LoadQueryReport();
        }
        

        
        private void VerPediddo_Load(object sender, EventArgs e)
        {

            this.rptpedidos.RefreshReport();
        }

        private void LoadQueryReport()
        {
            try
            {
                _dataReports = new DataReports
                {
                    Reporte = rptpedidos,
                    NameTableDataSource = "pedidos_db",
                    ReportEmbedResourse = "SystemInventory.pedidos.rdlc",
                    GetParameters = new ReportParameter[]
                {
                    new ReportParameter("fecha", DateTime.Now.ToString("dd/MM/yyyy")),
                    new ReportParameter("institucion",_mysqlConnectionDatabase.GetDescriptionWorkActionFromId(Convert.ToInt32(_idOrder)))
                }
                };
                _dataReports.GetDataOrderReport(Convert.ToInt32(_idOrder), "ADMINISTRATIVO");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al procesar" + ex);
            }
        }
    }
}
