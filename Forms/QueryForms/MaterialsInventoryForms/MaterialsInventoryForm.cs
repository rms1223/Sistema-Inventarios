using SystemIventory.Classes;
using System;
using System.Windows.Forms;

namespace SystemIventory.Forms.Consultas.inventarios_materiales
{
    public partial class MaterialsInventoryForm : Form
    {
        private ConnectionMysqlDatabase _mysqlConnectionDatabase;
        public MaterialsInventoryForm()
        {
            InitializeComponent();
            _mysqlConnectionDatabase = ConnectionMysqlDatabase.Get_Instance;
            _mysqlConnectionDatabase.VerifyDatabaseConnection();
            inventario.DataSource = _mysqlConnectionDatabase.GetAllInventoryMaterials();
        }

        private void XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            ExportDataToExcelFile();
        }

        private void ExportDataToExcelFile()
        {
            Microsoft.Office.Interop.Excel.Application exportExcel = new Microsoft.Office.Interop.Excel.Application();
            exportExcel.Application.Workbooks.Add(true);
            int indiceColumna = 0;

            foreach (DataGridViewColumn columna in inventario.Columns)
            {
                indiceColumna++;
                exportExcel.Cells[1, indiceColumna] = columna.Name;
            }
            int indiceFila = 0;

            foreach (DataGridViewRow filas in inventario.Rows)
            {
                indiceFila++;
                indiceColumna = 0;
                foreach (DataGridViewColumn columna in inventario.Columns)
                {
                    indiceColumna++;
                    exportExcel.Cells[indiceFila + 1, indiceColumna] = filas.Cells[columna.Name].Value;
                }
            }
            exportExcel.Visible = true;

        }
    }
}
