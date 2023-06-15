using SystemIventory.Classes;
using System;
using System.Windows.Forms;

namespace SystemIventory.Forms.Acciones
{
    public partial class SearchWorkAction : Form
    {
        private Label _orden;
        private TextBox _institucion;
        private TextBox _ordenTextBox;
        private ConnectionMysqlDatabase _mysqlConnectionDatabase;
        private string tipo_consulta = "operaciones";
        private int cod_accion = 0;
        private VerifyIdDeviceForm _revisionPlacas;
        private string _typeOrder;
        public SearchWorkAction(Label orden_tra, TextBox institu,string tipo)
        {
            InitializeComponent();
            _typeOrder = tipo;
            _mysqlConnectionDatabase = ConnectionMysqlDatabase.Get_Instance;
            dataGridView1.DataSource = _mysqlConnectionDatabase.GetInfromationWokActionFromType(0, _typeOrder);
            _orden = orden_tra;
            _institucion = institu;
        }
        public SearchWorkAction(TextBox box_orden, string tipo)
        {
            InitializeComponent();
            _typeOrder = tipo;
            _mysqlConnectionDatabase = ConnectionMysqlDatabase.Get_Instance;
            dataGridView1.DataSource = _mysqlConnectionDatabase.GetInfromationWokActionFromType(0, _typeOrder);
            _ordenTextBox = box_orden;
        }
        public SearchWorkAction(Label box_orden, string tipo)
        {
            InitializeComponent();
            _typeOrder = tipo;
            _mysqlConnectionDatabase = ConnectionMysqlDatabase.Get_Instance;
            dataGridView1.DataSource = _mysqlConnectionDatabase.GetInfromationWokActionFromType(0, _typeOrder);
            _orden = box_orden;
        }
        public SearchWorkAction(VerifyIdDeviceForm  revision)
        {
            InitializeComponent();
            _revisionPlacas = revision;
            tipo_consulta = "revision_placas";
            _typeOrder = VariablesName.OutputOrder;
            _mysqlConnectionDatabase = ConnectionMysqlDatabase.Get_Instance;
            dataGridView1.DataSource = _mysqlConnectionDatabase.GetInfromationWokActionFromType(0,VariablesName.OutputOrder);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _mysqlConnectionDatabase.GetInfromationWokActionFromType(Convert.ToInt32(txt_orden.Text), _typeOrder);
        }

        private void XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            foreach (DataGridViewRow item in dataGridView1.SelectedRows)
            {
                if (!String.IsNullOrEmpty(item.Cells["Accion"].Value.ToString()))
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
            dataGridView1.DataSource = _mysqlConnectionDatabase.GetDataListInstitutionFromWorkAction(txt_institucion.Text, "Institucion_Accion");
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
