using SystemIventory.Classes;
using System;
using System.Windows.Forms;
using SystemInventory.Classes.IModels;
using SystemInventory.Classes.Models;

namespace SystemIventory.Forms.Acciones
{
    public partial class SearchWorkAction : Form
    {
        private Label _orden;
        private TextBox _institucion;
        private TextBox _ordenTextBox;
        private IDataTableModel _dataTableModel;
        private string tipo_consulta = "operaciones";
        private int cod_accion = 0;
        private VerifyIdDeviceForm _revisionPlacas;
        private string _typeOrder;
        public SearchWorkAction(Label orden_tra, TextBox institu,string tipo)
        {
            InitializeComponent();
            _typeOrder = tipo;
            _dataTableModel = DataTableModel.Get_Instance;
            dataGridView1.DataSource = _dataTableModel.GetInfromationWokActionFromType(0, _typeOrder).Result;
            _orden = orden_tra;
            _institucion = institu;
        }
        public SearchWorkAction(TextBox box_orden, string _typeOrder)
        {
            InitializeComponent();
            _dataTableModel = DataTableModel.Get_Instance;
            dataGridView1.DataSource = _dataTableModel.GetInfromationWokActionFromType(0, _typeOrder).Result;
            _ordenTextBox = box_orden;
        }
        public SearchWorkAction(Label box_orden, string tipo)
        {
            InitializeComponent();
            _dataTableModel = DataTableModel.Get_Instance;
            _typeOrder = tipo;
            dataGridView1.DataSource = _dataTableModel.GetInfromationWokActionFromType(0, _typeOrder).Result;
            _orden = box_orden;
        }
        public SearchWorkAction(VerifyIdDeviceForm  revision)
        {
            InitializeComponent();
            _dataTableModel = DataTableModel.Get_Instance;
            _revisionPlacas = revision;
            tipo_consulta = "revision_placas";
            _typeOrder = VariablesName.OutputOrder;
            dataGridView1.DataSource = _dataTableModel.GetInfromationWokActionFromType(0,VariablesName.OutputOrder).Result;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _dataTableModel.GetInfromationWokActionFromType(Convert.ToInt32(txt_orden.Text), _typeOrder).Result;
        }

        private void XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            foreach (DataGridViewRow item in dataGridView1.SelectedRows)
            {
                if (!string.IsNullOrEmpty(item.Cells["Accion"].Value.ToString()))
                {
                    cod_accion = Convert.ToInt32(item.Cells["Accion"].Value.ToString());
                    if (_orden != null)
                    {
                        if (_institucion != null)
                        {
                            _orden.Text = cod_accion.ToString("D7");
                            _institucion.Text = item.Cells["descripcion"].Value.ToString();
                        }
                        else
                        {
                            _orden.Text = cod_accion.ToString("D7");
                        }
                        
                    }
                    else if (_ordenTextBox != null)
                    {
                        _ordenTextBox.Text = cod_accion.ToString("D7");
                    }
                    
                }
                
            }
            if (tipo_consulta.Equals("revision_placas"))
            {
                _revisionPlacas.Cargar_OrdenTrabajo(cod_accion);
            }
            
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _dataTableModel.GetDataListInstitutionFromWorkAction(txt_institucion.Text, "Institucion_Accion").Result;
        }

        public int GetCodeWorkAction()
        {
            return cod_accion;

        }

        private void Txt_orden_Leave(object sender, EventArgs e)
        {
            button1.Focus();
        }

        private void Txt_institucion_Leave(object sender, EventArgs e)
        {
            button2.Focus();
        }
    }
}
