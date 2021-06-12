using InventarioFod.Clases.Manejo_De_Datos;
using Microsoft.Reporting.WinForms;
using System;
using System.Windows.Forms;

namespace InventarioFod.Reportes
{
    public partial class Equipos_Garantias : Form
    {
        Manejo_Datos_Reportes Datos_Reporte;
        public Equipos_Garantias()
        {
            InitializeComponent();
        }

        private void Equipos_Garantias_Load(object sender, EventArgs e)
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
                
                Datos_Reporte = new Manejo_Datos_Reportes
                {
                    Reporte = rpt_garantia,
                    Nombre_Table_DataSource = "equipo_garantia",
                    Report_Embed_Resourse = "InventarioFod.reportegarantia.rdlc",
                    Get_Parameters = new ReportParameter[]
                    {

                        new ReportParameter("fecha",DateTime.Now.ToString("dd/MM/yyyy")),

                    }
                };
                Datos_Reporte.Generar_Reporte_garantia(comboBox1.SelectedItem.ToString());
            }
        }

        private void ComboBox1_Leave(object sender, EventArgs e)
        {
            buscar.Focus();
        }
    }
}
