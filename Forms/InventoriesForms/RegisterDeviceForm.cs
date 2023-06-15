using ExcelDataReader;
using SystemIventory.Classes;
using SystemIventory.Forms.Acciones;
using System;
using System.IO;
using System.Windows.Forms;

namespace SystemIventory.Forms.InventoriesForms
{
    public partial class RegisterDeviceForm : Form
    {
        private ConnectionMysqlDatabase _mysqlConnectionDatabase;
        private DataOperationDocument _dataOperationDocument;
        public RegisterDeviceForm()
        {
            InitializeComponent();
            numericUpDown1.Maximum = 10000;
            numericUpDown1.Visible = false;
            numericUpDown1.Value = 9;
            _mysqlConnectionDatabase = ConnectionMysqlDatabase.Get_Instance;
            _dataOperationDocument = new DataOperationDocument(datos_equipos);
            _dataOperationDocument.LoadDataNewDeviceInDatagridview();
            _mysqlConnectionDatabase.GetAllLotes();
            foreach (var item in _mysqlConnectionDatabase.Carteles)
            {
                comboBox1.Items.Add(item);
            }
            orden_trabajo.Text = _mysqlConnectionDatabase.GetIdWorkActionFromType("orden_trabajo").ToString("D7");
            descripcionorden.Text = "INGRESO EQUIPOS NUEVOS";

        }

        private void XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowModelDeviceForm ME = new ShowModelDeviceForm(id_tipo,nombre_tipo);
            ME.Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (VerifyPlaca(txt_placa.Text))
            {
                if (!string.IsNullOrEmpty(txt_placa.Text) && !string.IsNullOrEmpty(txt_serie.Text) && comboBox1.SelectedItem != null)
                {
                    
                    _dataOperationDocument.AddNewRecordInDatagridview(id_tipo.Text, txt_placa.Text, txt_serie.Text, nombre_tipo.Text, comboBox1.SelectedItem.ToString());
                    txt_placa.Text = string.Empty;
                    txt_serie.Text = string.Empty;
                    contador_total.Text = Convert.ToString(datos_equipos.RowCount - 1);
                    datos_equipos.FirstDisplayedScrollingRowIndex = datos_equipos.RowCount - 1;
                }
                else
                {
                    MessageBox.Show("Debe Ingresar los datos requeridos", "Error al Ingresar Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("No es una placa válida por favor verificar datos al registrarlos", "Error al Ingresar Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            txt_placa.Focus();
        }
        
        private void Button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            _mysqlConnectionDatabase.VerifyDatabaseConnection();

            _dataOperationDocument.SaveNewRecordInDatabase(orden_trabajo.Text,descripcionorden.Text,nombre_tipo.Text,VariablesName.InputOrder);
            button2.Enabled = true;
        }

        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SearchWorkAction buscar_orden = new SearchWorkAction(orden_trabajo, descripcionorden,VariablesName.InputOrder);
            buscar_orden.Show();
        }

        private void RegistrarFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModelDeviceForm registrarModelosEquipos = new ModelDeviceForm();
            registrarModelosEquipos.Show();
        }


        private void Txt_placa_TextChanged(object sender, EventArgs e)
        {
            if (txt_placa.Text.Length >= 6)
            {
                txt_serie.Focus();
            }
        }

        private void Txt_serie_Leave(object sender, EventArgs e)
        {
            button1.Focus();
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                numericUpDown1.Visible = true;
            }
            else
            {
                numericUpDown1.Visible = false;
            }
        }

        private void Txt_serie_TextChanged(object sender, EventArgs e)
        {
            if (txt_serie.Text.Length>= numericUpDown1.Value)
            {
                button1.Focus();
            }
        }
        private void DataGridView1_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {
            contador_total.Text= Convert.ToString(datos_equipos.RowCount - 1);
        }

        private bool VerifyPlaca(string placa)
        {
            try
            {
                int placa_u = Convert.ToInt32(placa);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            datos_equipos.Rows.Clear();
            ImportDataFromExcelFile();
        }

        public void ImportDataFromExcelFile()
        {
            try
            {
                OpenFileDialog file = new OpenFileDialog
                {
                    Filter = VariablesName.FileExtention,
                    Title = "Seleccionar archivo: "
                };
                if (file.ShowDialog() == DialogResult.OK)
                {
                    if (file.FileName.Equals("") == false)
                    {
                        string ruta_archivo = file.FileName;
                        using (var stream = File.Open(ruta_archivo, FileMode.Open, FileAccess.Read))
                        {
                            using (var reader = ExcelReaderFactory.CreateReader(stream))
                            {
                                do
                                {
                                    while (reader.Read())
                                    {
                                        string data = Convert.ToString(reader.GetValue(0));
                                        if (!string.IsNullOrEmpty(data))
                                        {
                                            if (data.Equals("Codigo")) continue;
                                            string _codigo = Convert.ToString(reader.GetValue(0));
                                            string _placa = Convert.ToString(reader.GetValue(1));
                                            string _cartel = Convert.ToString(reader.GetValue(4));
                                            
                                            datos_equipos.Rows.Add(_codigo,_placa,
                                                 reader.GetString(2), reader.GetString(3), _cartel);
                                            contador_total.Text = Convert.ToString(datos_equipos.RowCount - 1);
                                            datos_equipos.FirstDisplayedScrollingRowIndex = datos_equipos.RowCount - 1;
                                        }

                                    }

                                } while (reader.NextResult());
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al procesar\n" + ex);

            }

        }

    }
}
