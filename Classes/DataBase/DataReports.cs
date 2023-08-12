using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using SystemInventory.Classes.IModels;

namespace SystemIventory.Classes.DataBase
{
    class DataReports
    {


        public ReportViewer Reporte { get; set; }
        public string NameTableDataSource { get; set; }
        public string NameTableDataSourceOpcional { get; set; }
        public ReportParameter[] GetParameters { get; set; }
        public string ReportEmbedResourse { get; set; }

        private string _actualDate { get; set; }
        private DataSet _dataSet { get; set; }
        //private DataSet _dataDataSetOptional { get; set; }
        private IDataSetModel _dataSetModel;

        public DataReports()
        {
            _actualDate = DateTime.Now.ToString("dd/MM/yyyy");
            _dataSetModel = DataSetModel.Get_Instance;
        }

        public void GetDataWorkActionReport(int accion)
        {
            _dataSet = (DataSet) _dataSetModel.GetWorkActionReport(accion).Result;
            GenerateWorkActionReport();
        }
        public void GetDataOrderReport(int orden,string tipo_pedido)
        {
            _dataSet = (DataSet) _dataSetModel.GetOrderReport(orden, tipo_pedido).Result;
            GenerateOrderReport();
        }
        public void GetDataOutputMaterialsReport(string orden)
        {
            _dataSet = (DataSet)_dataSetModel.GetOuputMaterialReport(Convert.ToInt32(orden)).Result;
            GenerateOrderReport();
        }
        public void GetDataGeneralReport()
        {
            _dataSet = (DataSet)_dataSetModel.GetGeneralDevicesReport().Result;
            GenerateReport();
        }
        public void GetDataWarrantyReport(string tipo)
        {
            _dataSet = (DataSet)_dataSetModel.GetDevicesInWarranty(tipo).Result;
            GenerateReport();
        }

        private void GenerateOrderReport()
        {
            ReportDataSource _reportDataSource = new ReportDataSource(NameTableDataSource, _dataSet.Tables[0]);
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
            ReportDataSource _reportDataSource = new ReportDataSource(NameTableDataSource, _dataSet.Tables[0]);
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
            ReportDataSource _reportDataSource = new ReportDataSource(NameTableDataSource, _dataSet.Tables[0]);
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
