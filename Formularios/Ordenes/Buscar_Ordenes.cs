using InventarioFod.Clases;
using System;
using System.Windows.Forms;

namespace InventarioFod.Formularios.Acciones
{
    public partial class Buscar_Acciones : Form
    {
        private Label orden;
        private TextBox institucion;
        private TextBox ordenTextBox;
        private Conexion_db_Mysql base_datos;
        private string tipo_consulta = "operaciones";
        private int cod_accion = 0;
        private Revisar_placas_ordenes revision_placas;
        private string tipo_orden;
        public Buscar_Acciones(Label orden_tra, TextBox institu,string tipo)
        {
            InitializeComponent();
            tipo_orden = tipo;
            base_datos = Conexion_db_Mysql.Get_Instance;
            dataGridView1.DataSource = base_datos.Obtener_Estados_Acciones(0, tipo_orden);
            orden = orden_tra;
            institucion = institu;
        }
        public Buscar_Acciones(TextBox box_orden, string tipo)
        {
            InitializeComponent();
            tipo_orden = tipo;
            base_datos = Conexion_db_Mysql.Get_Instance;
            dataGridView1.DataSource = base_datos.Obtener_Estados_Acciones(0, tipo_orden);
            ordenTextBox = box_orden;
        }
        public Buscar_Acciones(Label box_orden, string tipo)
        {
            InitializeComponent();
            tipo_orden = tipo;
            base_datos = Conexion_db_Mysql.Get_Instance;
            dataGridView1.DataSource = base_datos.Obtener_Estados_Acciones(0, tipo_orden);
            orden = box_orden;
        }
        public Buscar_Acciones(Revisar_placas_ordenes  revision)
        {
            InitializeComponent();
            revision_placas = revision;
            tipo_consulta = "revision_placas";
            tipo_orden = Var_Name.ORDEN_SALIDA;
            base_datos = Conexion_db_Mysql.Get_Instance;
            dataGridView1.DataSource = base_datos.Obtener_Estados_Acciones(0,Var_Name.ORDEN_SALIDA);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = base_datos.Obtener_Estados_Acciones(Convert.ToInt32(txt_orden.Text), tipo_orden);
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
                    if (orden != null)
                    {
                        if (institucion != null)
                        {
                            orden.Text = cod_accion.ToString("D7");
                            institucion.Text = item.Cells["descripcion"].Value.ToString();
                        }
                        else
                        {
                            orden.Text = cod_accion.ToString("D7");
                        }
                        
                    }
                    else if (ordenTextBox != null)
                    {
                        ordenTextBox.Text = cod_accion.ToString("D7");
                    }
                    
                }
                
            }
            if (tipo_consulta.Equals("revision_placas"))
            {
                revision_placas.Cargar_OrdenTrabajo(cod_accion);
            }
            
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = base_datos.Obtener_Datos_Lista_instituciones(txt_institucion.Text, "Institucion_Accion");
        }

        public int codigo_accion()
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
