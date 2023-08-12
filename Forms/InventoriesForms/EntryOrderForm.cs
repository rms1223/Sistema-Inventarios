
using SystemIventory.Classes;
using SystemIventory.Forms.Acciones;
using System;
using System.Windows.Forms;
using SystemInventory.Classes.IModels;
using SystemInventory.Classes.Models;

namespace SystemIventory.Forms.InventoriesForms
{
    public partial class EntryOrderForm : Form
    {
        private IDataBaseRepository _dataBaseRepository;

        DataOperationDocument _dataOperationDocument;
        public EntryOrderForm()
        {
            InitializeComponent();
            _dataBaseRepository = DataBaseRepository.Get_Instance;

            _dataOperationDocument = new DataOperationDocument(dataGridView1);
            _dataOperationDocument.LoadWorkActionInfromationInDatagridview();
            orden_trabajo.Text = ((int)_dataBaseRepository.GetIdWorkActionFromType("orden_trabajo").Result).ToString("D7");

        }

        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SearchWorkAction buscar_orden = new SearchWorkAction(orden_trabajo, institucion,VariablesName.InputOrder);
            buscar_orden.Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null && !string.IsNullOrEmpty(institucion.Text))
            {
                _dataOperationDocument.ProcessLocalWorkAction(placa.Text, VariablesName.Placa, institucion.Text + "('" + comboBox1.SelectedItem.ToString() + "')", comboBox1.SelectedItem.ToString(), 0);
                placa.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Debe ingresar los datos", "Error al guaradar datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            placa.Focus();
            
        }

        private void Buscar_serie_Click(object sender, System.EventArgs e)
        {
            if (comboBox1.SelectedItem != null && !string.IsNullOrEmpty(institucion.Text))
            {
                _dataOperationDocument.ProcessLocalWorkAction(serie.Text, VariablesName.Serial, institucion.Text + "('" + comboBox1.SelectedItem.ToString() + "')", comboBox1.SelectedItem.ToString(), 0);
                serie.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Debe ingresar los datos", "Error al guaradar datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            serie.Focus();
        }

        private void TextBox1_Leave(object sender, System.EventArgs e)
        {
            string valor = (string)_dataBaseRepository.GetInstitutionCode(textBox1.Text, "reequipamiento").Result;
            institucion.Text = valor;
            placa.Focus();
            textBox1.Text = string.Empty;
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddInstitutionForm add_institu = new AddInstitutionForm();
            add_institu.Show();
        }

        private void Guardar_Click(object sender, EventArgs e)
        {
            guardar.Enabled = false;

            if (!string.IsNullOrEmpty(institucion.Text))
            {
                _dataOperationDocument.SaveWorkActionInDatabase(orden_trabajo.Text, descripcion_orden+"/n"+institucion.Text + "('" + comboBox1.SelectedItem.ToString() + "')", VariablesName.InputOrder,false);
            }
            else
            {
                MessageBox.Show("Debe ingresar nombre de orden o institucción", "Error al guaradar Orden", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            guardar.Enabled = true;
        }

        private void Placa_TextChanged(object sender, EventArgs e)
        {
            if (placa.Text.Length == 6)
            {
                button1.Focus();
            }
        }

        private void Serie_TextChanged(object sender, EventArgs e)
        {

            if (serie.Text.Length >= 20)
            {
                buscar_serie.Focus();
            }
        }

        private void XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            descripcion_orden.Text = comboBox1.SelectedItem.ToString() + " DE EQUIPO";
        }
    }
}
