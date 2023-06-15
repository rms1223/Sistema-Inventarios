using SystemIventory.Classes;
using System;
using System.Windows.Forms;

namespace SystemIventory.Forms.InventoriesForms
{
    public partial class ModelDeviceForm : Form
    {
        private ConnectionMysqlDatabase _mysqlConnectionDatabase;
        
        public ModelDeviceForm()
        {
            InitializeComponent();
            _mysqlConnectionDatabase = ConnectionMysqlDatabase.Get_Instance;
            label2.Text = _mysqlConnectionDatabase.GetNextCodeProduct().ToString();

            foreach (var item in _mysqlConnectionDatabase.GetAllTypesDevice())
            {
                tipo.Items.Add(item);
            }
        }

        private void XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                int codigo_equipo = Convert.ToInt32(label2.Text);
                string tipo_equipo = tipo.SelectedItem.ToString();
                string[] tipo1 = tipo_equipo.Split('-');
                _mysqlConnectionDatabase.SaveModelDevice(codigo_equipo, marca.Text, modelo.Text, tipo1[0]);
                MessageBox.Show("Registro de datos", "Datos Registrados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error de Registro","Error al Registrar los datos\n"+ex,MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
        }
    }
}
