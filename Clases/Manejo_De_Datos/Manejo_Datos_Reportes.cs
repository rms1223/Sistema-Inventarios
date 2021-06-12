using Microsoft.Reporting.WinForms;
using System;
using System.Data;

namespace InventarioFod.Clases.Manejo_De_Datos
{
    class Manejo_Datos_Reportes
    {

        Conexion_db_Mysql base_datos;

        public ReportViewer Reporte { get; set; }
        public string Nombre_Table_DataSource { get; set; }
        public string Nombre_Table_DataSource_opcional { get; set; }
        public ReportParameter[] Get_Parameters { get; set; }
        public string Report_Embed_Resourse { get; set; }

        private string Fecha_Actual { get; set; }
        private DataSet Datos_db { get; set; }
        private DataSet Datos_db_opcional { get; set; }

        public Manejo_Datos_Reportes()
        {
            Fecha_Actual = DateTime.Now.ToString("dd/MM/yyyy");
            base_datos = Conexion_db_Mysql.Get_Instance;
        }

        public void Generar_Reporte_Acciones(int accion)
        {
            Datos_db = base_datos.Get_reporte_acciones(accion);
            Generar_Reporte_acciones();
        }
        public void Generar_Reporte_Pedidos(int orden,string tipo_pedido)
        {
            Datos_db = base_datos.Get_reporte_pedido(orden,tipo_pedido);
            Generar_Reporte_pedido();
        }
        public void Generar_Reporte_salida_materiales(string orden)
        {
            Datos_db = base_datos.Get_reporte_salida_materiales(Convert.ToInt32(orden));
            Generar_Reporte_pedido();
        }
        public void Generar_Reporte_General()
        {
            Datos_db = base_datos.Get_Equipos_General();
            Generar_Reporte();
        }
        public void Generar_Reporte_garantia(string tipo)
        {
            Datos_db = base_datos.Get_Equipos_Garantia(tipo);
            Generar_Reporte();
        }

        private void Generar_Reporte_pedido()
        {
            ReportDataSource rpt_data = new ReportDataSource(Nombre_Table_DataSource, Datos_db.Tables[0]);
            Reporte.LocalReport.DataSources.Clear();
            Reporte.LocalReport.DataSources.Add(rpt_data);
            Reporte.LocalReport.ReportEmbeddedResource = Report_Embed_Resourse;
            Reporte.LocalReport.Refresh();
            Reporte.Refresh();
            Reporte.LocalReport.SetParameters(Get_Parameters);
            Reporte.RefreshReport();
        }
        private void Generar_Reporte_acciones()
        {
            ReportDataSource rpt_data = new ReportDataSource(Nombre_Table_DataSource, Datos_db.Tables[0]);
            Reporte.LocalReport.DataSources.Clear();
            Reporte.LocalReport.DataSources.Add(rpt_data);
            Reporte.LocalReport.ReportEmbeddedResource = Report_Embed_Resourse;
            Reporte.LocalReport.Refresh();
            Reporte.Refresh();
            Reporte.LocalReport.SetParameters(Get_Parameters);
            Reporte.RefreshReport();
        }
        private void Generar_Reporte()
        {
            ReportDataSource rpt_data = new ReportDataSource(Nombre_Table_DataSource, Datos_db.Tables[0]);
            Reporte.LocalReport.DataSources.Clear();
            Reporte.LocalReport.DataSources.Add(rpt_data);
            Reporte.LocalReport.ReportEmbeddedResource = Report_Embed_Resourse;
            Reporte.LocalReport.Refresh();
            Reporte.Refresh();
            Reporte.LocalReport.SetParameters(Get_Parameters);
            Reporte.RefreshReport();
        }


    }
}
