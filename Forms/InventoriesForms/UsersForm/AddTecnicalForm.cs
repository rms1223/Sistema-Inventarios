using SystemIventory.Classes;
using System;
using System.Windows.Forms;

namespace SystemIventory.Forms.InventoriesForms.usuarios
{
    public partial class AddTecnicalForm : Form
    {
        private readonly ConnectionMysqlDatabase _mysqlConnectionDatabase;
        private OrderOutputMaterials _materials;
        public AddTecnicalForm(OrderOutputMaterials _ordenMateriales)
        {
            InitializeComponent();
            _mysqlConnectionDatabase = ConnectionMysqlDatabase.Get_Instance;
            _materials = _ordenMateriales;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            bool estado = _mysqlConnectionDatabase.SaveTechnical(nom_tec.Text.ToUpper());
            if (estado)
            {
                MessageBox.Show("Datos Registrados","Agregar Usuario" , MessageBoxButtons.OK, MessageBoxIcon.Information);
                nom_tec.Text = string.Empty;
                _materials.LoadTechnicalData();
            }
            else
            {
                MessageBox.Show("Error al Agregar Usuario", "Agregar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
