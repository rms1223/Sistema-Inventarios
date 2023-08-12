using SystemIventory.Classes;
using System;
using System.Windows.Forms;
using SystemInventory.Classes.IModels;
using SystemInventory.Classes.Models;

namespace SystemIventory
{
    public partial class InventoryListForm : Form
    {
        public PrincipalForm formulario_principal;
        private static InventoryListForm instance = null;
        private IDataBaseRepository _dataBaseRepository;
        private IDataTableModel _dataTableModel;
        private DataOperationDocument _dataOperationDocument;
        public string Rol_Usuario { get; set; }

        public static InventoryListForm Get_instance
        {
            get
            {
                if (instance==null)
                {
                    instance = new InventoryListForm();
                }
                return instance;
            }
            set
            {
                instance = value;
            }
        }

        private InventoryListForm()
        {
            InitializeComponent();
            _dataTableModel = DataTableModel.Get_Instance;
            _dataBaseRepository = DataBaseRepository.Get_Instance;

            _dataOperationDocument = new DataOperationDocument(dataGridView1);
            
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
            formulario_principal.Show();
        }
        private void DataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (Rol_Usuario.Equals(VariablesName.UserStore)|| (Rol_Usuario.Equals(VariablesName.UserAdministrator)))
            {
                DialogResult dr = MessageBox.Show("Desea Eliminar el Registro", "Eliminar Registro", MessageBoxButtons.YesNo,MessageBoxIcon.Warning);

                if (dr == DialogResult.Yes)
                {
                    foreach (DataGridViewRow item in dataGridView1.SelectedRows)
                    {
                        string placa = item.Cells[VariablesName.Placa].Value.ToString();
                        string serie = item.Cells[VariablesName.Serial].Value.ToString();
                        int accion = Convert.ToInt32(item.Cells["Orden"].Value.ToString());
                        int estacion = Convert.ToInt32(item.Cells["Numero_Estacion"].Value.ToString());
                        bool estado = _dataBaseRepository.DeleteDevice(placa, serie, accion,estacion).StatusQuery;
                        if (estado)
                        {
                            MessageBox.Show("Registro eliminado", "Datos Actualizados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dataGridView1.DataSource = _dataTableModel.GetDataListInstitutionFromWorkAction(text_placa.Text, VariablesName.Placa).Result;
                        }


                    }
                }
            }
            
            

        }
        private void T1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            instance = null;
            this.Close();
        }

        private void T2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _dataTableModel.GetDataListInstitutionFromWorkAction(text_placa.Text, VariablesName.Placa).Result;
            text_placa.Text = string.Empty;
        }

        private void Button2_Click_2(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _dataTableModel.GetDataListInstitutionFromWorkAction(txt_serie.Text, VariablesName.Serial).Result;
            txt_serie.Text = string.Empty;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            GetInstitutionName();
            txt_institucion.Text = string.Empty;
        }
       

        private void Text_placa_Leave(object sender, EventArgs e)
        {
            buscar_placa.Focus();
        }


        private void Text_placa_TextChanged(object sender, EventArgs e)
        {
            if (text_placa.TextLength >= 6)
            {
                buscar_placa.Focus();
            }
        }

        private void Txt_institucion_Leave(object sender, EventArgs e)
        {
            buscar_institucion.Focus();
            
        }
        private void GetInstitutionName()
        {
            dataGridView1.DataSource = _dataTableModel.GetDataListInstitutionFromWorkAction(txt_institucion.Text, VariablesName.Institucion).Result;
            txt_institucion.Focus();
            txt_institucion.Text = string.Empty;
        }

        private void Txt_institucion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetInstitutionName(); 
            }
        }
    }
}
