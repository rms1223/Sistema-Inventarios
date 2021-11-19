using InventarioFod.Clases;
using InventarioFod.Clases.Manejo_De_Datos.Conexion_DB;
using InventarioFod.Formularios.Acciones;
using InventarioFod.Formularios.Inventarios.materiales_pedidos;
using InventarioFod.Reportes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace InventarioFod
{
    public partial class Form_Principal : Form
    {

        private static Form_Principal instance = null;
        private DataTable dt;
        private string fecha_actual = string.Empty;
        private int contador = 1;
        //private BaseDatos datos;
        private Conexion_db_Mysql base_datos;
        Lista_inventario lista_form;

        ToolTip cambios = new ToolTip();

        //Para el manejo de las listas a cargar por el usuario
        public List<string> acciones_user { get; set; }

        Manejo_Documento_Excel manejo_de_datos;

        public static Form_Principal get_instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Form_Principal();
                }
                return instance;
            }
            set
            {
                instance = value;
            }
        }

        private Form_Principal()
        {
            InitializeComponent();

            manejo_de_datos = new Manejo_Documento_Excel(dataGridView1);

            manejo_de_datos.Cargar_orden_trabajo();



            ToolTip tip_import = new ToolTip();
            ToolTip tip_refresh = new ToolTip();
            ToolTip tip_guardar = new ToolTip();
            ToolTip limpiar = new ToolTip();
            limpiar.SetToolTip(label13, "Limpiar Datos");

            lista_form = Lista_inventario.Get_instance;

            tip_refresh.SetToolTip(label2, "Eliminar Datos");


            dt = new DataTable();

            tip_guardar.SetToolTip(guardar, "Guardar Registros");

            //cargamos los valores al combobox
            foreach (var modalidad in Lectura_xml.Lista_Modalidad)
            {
                comboBox1.Items.Add(modalidad);
            }

            //se utiliza para seleccionar un valor por defecto

            //cargamos el numero de estacion actual y le desplegamos al usuario 
            estacion.Value = Convert.ToDecimal(contador.ToString());

            fecha_actual = DateTime.Today.ToString("dd/MM/yyyy");
            fecha_actual = fecha_actual.Split(' ')[0];

            base_datos = Conexion_db_Mysql.Get_Instance;
            comboBox1.SelectedIndex = 0;
            
            orden_trabajo.Text = base_datos.get_num_acciones("orden_trabajo").ToString("D7");
            cambios.SetToolTip(cambio_equipo,"Seleccionar en caso de cambios en los equipos");
        }
        private void button1_Click(object sender, EventArgs e)
        {

            manejo_de_datos.Procesar_datos_orden(placa.Text, Var_Name.Placa, institucion.Text, comboBox1.SelectedItem.ToString(), Convert.ToInt32(estacion.Value));
            estacion.Value = Convert.ToDecimal(manejo_de_datos.Contador.ToString());
            placa.Text = string.Empty;
            placa.Focus();
            dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
        }

        private void placa_TextChanged(object sender, EventArgs e)
        {
            if (placa.Text.Length==6)
            {
                button1.Focus();
            }
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            manejo_de_datos.Procesar_datos_orden(serie.Text, Var_Name.Serie, institucion.Text, comboBox1.SelectedItem.ToString(), Convert.ToInt32(estacion.Value));
            estacion.Value = Convert.ToDecimal(manejo_de_datos.Contador.ToString());
            serie.Text = string.Empty;
            serie.Focus();
            dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
        }

        private void serie_TextChanged(object sender, EventArgs e)
        {
            if (serie.Text.Length >=20)
            {
                buscar_serie.Focus();
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            manejo_de_datos.Contador = Convert.ToInt32(estacion.Value);
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            
            string valor = base_datos.Obtener_Institucion(textBox1.Text,"reequipamiento");
            institucion.Text = valor;
            placa.Focus();
            textBox1.Text = String.Empty;
        }

        private void label13_Click(object sender, EventArgs e)
        {
            //dt = new System.Data.DataTable();
            manejo_de_datos.Limpiar_datos();
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AgregarInstitucion add_institu = new AgregarInstitucion();
            add_institu.Show();
        }


        private void t2ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void t1ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            instance = null;
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            guardar.Enabled = false;
            
            if (!string.IsNullOrEmpty(institucion.Text))
            {
                manejo_de_datos.Guardar_datos_orden(orden_trabajo.Text,institucion.Text,Var_Name.ORDEN_SALIDA,cambio_equipo.Checked);
            }
            else
            {
                MessageBox.Show("Debe ingresar nombre de orden o institucción", "Error al guaradar Orden", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            guardar.Enabled = true;
        }

        private void guardar_MouseEnter(object sender, EventArgs e)
        {
            guardar.Image = Image.FromFile(Path.Combine(Application.StartupPath, @"Imagenes\Save_enter.png"));
            guardar.ImageAlign = ContentAlignment.MiddleCenter;
        }

        private void guardar_MouseLeave(object sender, EventArgs e)
        {
            guardar.Image = Image.FromFile(Path.Combine(Application.StartupPath, @"Imagenes\Save_leave.png"));
        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            contador = 1;
            institucion.Text = "";
            placa.Focus();
            estacion.Value = Convert.ToDecimal(contador);
            orden_trabajo.Text = base_datos.get_num_acciones("orden_trabajo").ToString("D7");
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            label2.Image = Image.FromFile(Path.Combine(Application.StartupPath, @"Imagenes\delete_enter.png"));
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.Image = Image.FromFile(Path.Combine(Application.StartupPath, @"Imagenes\delete_leave.png"));
        }
        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Buscar_Acciones buscar_orden = new Buscar_Acciones(orden_trabajo,institucion,Var_Name.ORDEN_SALIDA);
            buscar_orden.Show();
        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            Pedidos_Materiales PM = new Pedidos_Materiales(orden_trabajo.Text);
            PM.Show();
        }

        private void LinkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            VerPediddo verPediddo = new VerPediddo(orden_trabajo.Text);
            verPediddo.Show();

        }
    }
}
