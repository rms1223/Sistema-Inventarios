using SystemIventory.Classes;
using System;
using System.Windows.Forms;
using SystemInventory.Classes.IModels;
using SystemInventory.Classes.Models;

namespace SystemIventory.Forms.Consultas.inventarios_materiales
{
    public partial class MaterialsInventoryForm : Form
    {
        private OperationsRepository _mysqlConnectionDatabase;
        private IDataTableModel _dataTableModel;
        public MaterialsInventoryForm()
        {
            InitializeComponent();
            _mysqlConnectionDatabase = OperationsRepository.Get_Instance;
            _dataTableModel = DataTableModel.Get_Instance;
            _mysqlConnectionDatabase.VerifyDatabaseConnection();
            inventario.DataSource = _dataTableModel.GetAllInventoryMaterials().Result;
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
