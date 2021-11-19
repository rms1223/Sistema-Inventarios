using InventarioFod.Clases;
using System;
using System.Windows.Forms;

namespace InventarioFod.Formularios.Consultas.inventarios_materiales
{
    public partial class Inventario_materiales : Form
    {
        private Conexion_db_Mysql base_datos;
        public Inventario_materiales()
        {
            InitializeComponent();
            base_datos = Conexion_db_Mysql.Get_Instance;
            base_datos.Verificar_Conexion();
            inventario.DataSource = base_datos.Get_Inventario_Materiales();
        }

        private void XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            ExportDataExcel();
        }

        private void ExportDataExcel()
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
