using SystemIventory.Classes;
using SystemIventory.Classes.DataBase;
using SystemIventory.Forms.Acciones;
using SystemIventory.Forms.InventoriesForms.MaterialsOrderForm;
using SystemIventory.Reports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SystemIventory
{
    public partial class PrincipalForm : Form
    {

        private static PrincipalForm instance = null;
        private DataTable dt;
        private string fecha_actual = string.Empty;
        private int contador = 1;
        private ConnectionMysqlDatabase _mysqlConnectionDatabase;
        InventoryListForm _listInventoryForm;

        ToolTip cambios = new ToolTip();

        public List<string> acciones_user { get; set; }

        DataOperationDocument _dataOperationDocument;

        public static PrincipalForm _getInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PrincipalForm();
                }
                return instance;
            }
            set
            {
                instance = value;
            }
        }

        private PrincipalForm()
        {
            InitializeComponent();

            _dataOperationDocument = new DataOperationDocument(dataGridView1);

            _dataOperationDocument.LoadWorkActionInfromationInDatagridview();



            ToolTip tip_import = new ToolTip();
            ToolTip tip_refresh = new ToolTip();
            ToolTip tip_guardar = new ToolTip();
            ToolTip limpiar = new ToolTip();
            limpiar.SetToolTip(label13, "Limpiar Datos");

            _listInventoryForm = InventoryListForm.Get_instance;

            tip_refresh.SetToolTip(label2, "Eliminar Datos");


            dt = new DataTable();

            tip_guardar.SetToolTip(guardar, "Guardar Registros");

            //cargamos los valores al combobox
            foreach (var modalidad in OperationsFileXlm.ModalityList)
            {
                comboBox1.Items.Add(modalidad);
            }

            //se utiliza para seleccionar un valor por defecto

            //cargamos el numero de estacion actual y le desplegamos al usuario 
            estacion.Value = Convert.ToDecimal(contador.ToString());

            fecha_actual = DateTime.Today.ToString("dd/MM/yyyy");
            fecha_actual = fecha_actual.Split(' ')[0];

            _mysqlConnectionDatabase = ConnectionMysqlDatabase.Get_Instance;
            comboBox1.SelectedIndex = 0;
            
            orden_trabajo.Text = _mysqlConnectionDatabase.GetIdWorkActionFromType("orden_trabajo").ToString("D7");
            cambios.SetToolTip(cambio_equipo,"Seleccionar en caso de cambios en los equipos");
        }
        private void Button1Click(object sender, EventArgs e)
        {

            _dataOperationDocument.ProcessLocalWorkAction(placa.Text, VariablesName.Placa, institucion.Text, comboBox1.SelectedItem.ToString(), Convert.ToInt32(estacion.Value));
            estacion.Value = Convert.ToDecimal(_dataOperationDocument.Count.ToString());
            placa.Text = string.Empty;
            placa.Focus();
            dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
        }

        private void Placa_TextChanged(object sender, EventArgs e)
        {
            if (placa.Text.Length==6)
            {
                button1.Focus();
            }
            
        }

        private void Button3_Click_1(object sender, EventArgs e)
        {
            _dataOperationDocument.ProcessLocalWorkAction(serie.Text, VariablesName.Serial, institucion.Text, comboBox1.SelectedItem.ToString(), Convert.ToInt32(estacion.Value));
            estacion.Value = Convert.ToDecimal(_dataOperationDocument.Count.ToString());
            serie.Text = string.Empty;
            serie.Focus();
            dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
        }

        private void Serie_TextChanged(object sender, EventArgs e)
        {
            if (serie.Text.Length >=20)
            {
                buscar_serie.Focus();
            }
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            _dataOperationDocument.Count = Convert.ToInt32(estacion.Value);
        }

        private void TextBox1_Leave(object sender, EventArgs e)
        {
            
            string valor = _mysqlConnectionDatabase.GetInstitutionCode(textBox1.Text,"reequipamiento");
            institucion.Text = valor;
            placa.Focus();
            textBox1.Text = String.Empty;
        }

        private void Label13_Click(object sender, EventArgs e)
        {
            //dt = new System._dataCollection.DataTable();
            _dataOperationDocument.ClearData();
        }
        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddInstitutionForm add_institu = new AddInstitutionForm();
            add_institu.Show();
        }


        private void T2ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void T1ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            instance = null;
            this.Close();
        }

        private void Label2_Click(object sender, EventArgs e)
        {
            guardar.Enabled = false;
            
            if (!string.IsNullOrEmpty(institucion.Text))
            {
                _dataOperationDocument.SaveWorkActionInDatabase(orden_trabajo.Text,institucion.Text,VariablesName.OutputOrder,cambio_equipo.Checked);
            }
            else
            {
                MessageBox.Show("Debe ingresar nombre de orden o institucción", "Error al guaradar Orden", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            guardar.Enabled = true;
        }

        private void Save_MouseEnter(object sender, EventArgs e)
        {
            guardar.Image = Image.FromFile(Path.Combine(Application.StartupPath, @"Imagenes\Save_enter.png"));
            guardar.ImageAlign = ContentAlignment.MiddleCenter;
        }

        private void Save_MouseLeave(object sender, EventArgs e)
        {
            guardar.Image = Image.FromFile(Path.Combine(Application.StartupPath, @"Imagenes\Save_leave.png"));
        }

        private void Label2_Click_1(object sender, EventArgs e)
        {
            contador = 1;
            institucion.Text = "";
            placa.Focus();
            estacion.Value = Convert.ToDecimal(contador);
            orden_trabajo.Text = _mysqlConnectionDatabase.GetIdWorkActionFromType("orden_trabajo").ToString("D7");
        }

        private void Label2_MouseEnter(object sender, EventArgs e)
        {
            label2.Image = Image.FromFile(Path.Combine(Application.StartupPath, @"Imagenes\delete_enter.png"));
        }

        private void Label2_MouseLeave(object sender, EventArgs e)
        {
            label2.Image = Image.FromFile(Path.Combine(Application.StartupPath, @"Imagenes\delete_leave.png"));
        }
        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SearchWorkAction buscar_orden = new SearchWorkAction(orden_trabajo,institucion,VariablesName.OutputOrder);
            buscar_orden.Show();
        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            MaterialsOrderForm PM = new MaterialsOrderForm(orden_trabajo.Text);
            PM.Show();
        }

        private void LinkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            ViewOrderReport _verPediddo = new ViewOrderReport(orden_trabajo.Text);
            _verPediddo.Show();

        }
    }
}
