using Microsoft.Reporting.WinForms;
using System;
using System.Data;

namespace SystemIventory.Classes.DataBase
{
    class DataReports
    {

        ConnectionMysqlDatabase _mysqlConnectionDatabase;

        public ReportViewer Reporte { get; set; }
        public string NameTableDataSource { get; set; }
        public string NameTableDataSourceOpcional { get; set; }
        public ReportParameter[] GetParameters { get; set; }
        public string ReportEmbedResourse { get; set; }

        private string _actualDate { get; set; }
        private DataSet _dataDataSet { get; set; }
        private DataSet _dataDataSetOptional { get; set; }

        public DataReports()
        {
            _actualDate = DateTime.Now.ToString("dd/MM/yyyy");
            _mysqlConnectionDatabase = ConnectionMysqlDatabase.Get_Instance;
        }

        public void GetDataWorkActionReport(int accion)
        {
            _dataDataSet = _mysqlConnectionDatabase.GetWorkActionReport(accion);
            GenerateWorkActionReport();
        }
        public void GetDataOrderReport(int orden,string tipo_pedido)
        {
            _dataDataSet = _mysqlConnectionDatabase.GetOrderReport(orden,tipo_pedido);
            GenerateOrderReport();
        }
        public void GetDataOutputMaterialsReport(string orden)
        {
            _dataDataSet = _mysqlConnectionDatabase.GetOuputMaterialReport(Convert.ToInt32(orden));
            GenerateOrderReport();
        }
        public void GetDataGeneralReport()
        {
            _dataDataSet = _mysqlConnectionDatabase.GetGeneralDevicesReport();
            GenerateReport();
        }
        public void GetDataWarrantyReport(string tipo)
        {
            _dataDataSet = _mysqlConnectionDatabase.GetDevicesInWarranty(tipo);
            GenerateReport();
        }

        private void GenerateOrderReport()
        {
            ReportDataSource _reportDataSource = new ReportDataSource(NameTableDataSource, _dataDataSet.Tables[0]);
            Reporte.LocalReport.DataSources.Clear();
            Reporte.LocalReport.DataSources.Add(_reportDataSource);
            Reporte.LocalReport.ReportEmbeddedResource = ReportEmbedResourse;
            Reporte.LocalReport.Refresh();
            Reporte.Refresh();
            Reporte.LocalReport.SetParameters(GetParameters);
            Reporte.RefreshReport();
        }
        private void GenerateWorkActionReport()
        {
            ReportDataSource _reportDataSource = new ReportDataSource(NameTableDataSource, _dataDataSet.Tables[0]);
            Reporte.LocalReport.DataSources.Clear();
            Reporte.LocalReport.DataSources.Add(_reportDataSource);
            Reporte.LocalReport.ReportEmbeddedResource = ReportEmbedResourse;
            Reporte.LocalReport.Refresh();
            Reporte.Refresh();
            Reporte.LocalReport.SetParameters(GetParameters);
            Reporte.RefreshReport();
        }
        private void GenerateReport()
        {
            ReportDataSource _reportDataSource = new ReportDataSource(NameTableDataSource, _dataDataSet.Tables[0]);
            Reporte.LocalReport.DataSources.Clear();
            Reporte.LocalReport.DataSources.Add(_reportDataSource);
            Reporte.LocalReport.ReportEmbeddedResource = ReportEmbedResourse;
            Reporte.LocalReport.Refresh();
            Reporte.Refresh();
            Reporte.LocalReport.SetParameters(GetParameters);
            Reporte.RefreshReport();
        }


    }
}
