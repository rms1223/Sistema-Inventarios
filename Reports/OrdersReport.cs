using SystemIventory.Classes;
using SystemIventory.Classes.DataBase;
using SystemIventory.Forms.Acciones;
using Microsoft.Reporting.WinForms;
using System;
using System.Windows.Forms;

namespace SystemIventory.Reports
{
    public partial class OrdersReport : Form
    {

        private DataReports _dataReports;
        private ConnectionMysqlDatabase _mysqlConnectionDatabase;
        public OrdersReport()
        {
            InitializeComponent();
            _mysqlConnectionDatabase = ConnectionMysqlDatabase.Get_Instance;

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
                _dataReports = new DataReports
                {
                    Reporte = rptpedidos,
                    NameTableDataSource = "pedidos_db",
                    ReportEmbedResourse = "SystemInventory.pedidos.rdlc",
                    GetParameters = new ReportParameter[]
                {
                    new ReportParameter("fecha", DateTime.Now.ToString("dd/MM/yyyy")),
                    new ReportParameter("institucion",_mysqlConnectionDatabase.GetDescriptionWorkActionFromId(Convert.ToInt32(orden_txt.Text)))
                }
                };
                _dataReports.GetDataOrderReport(Convert.ToInt32(orden_txt.Text),tipo_pedido.Text);
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
            SearchWorkAction buscar_orden = new SearchWorkAction(orden_txt,VariablesName.OutputOrder);
            buscar_orden.Show();
        }
    }
}
