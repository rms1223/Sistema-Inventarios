using InventarioFod.Clases;
using System;
using System.Windows.Forms;

namespace InventarioFod
{
    public partial class Lista_inventario : Form
    {
        public Form_Principal formulario_principal;
        private static Lista_inventario instance = null;
        //private BaseDatos datos;
        private Conexion_db_Mysql base_datos;
        private Manejo_Documento_Excel manejo_de_datos;
        public string Rol_Usuario { get; set; }

        public static Lista_inventario Get_instance
        {
            get
            {
                if (instance==null)
                {
                    instance = new Lista_inventario();
                }
                return instance;
            }
            set
            {
                instance = value;
            }
        }

        private Lista_inventario()
        {
            InitializeComponent();
            base_datos = Conexion_db_Mysql.Get_Instance;
            base_datos.Verificar_Conexion();
            ToolTip regresar = new ToolTip();

            
            manejo_de_datos = new Manejo_Documento_Excel(dataGridView1);
            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            formulario_principal.Show();
        }
        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (Rol_Usuario.Equals(Var_Name.Usu_Bodega)|| (Rol_Usuario.Equals(Var_Name.Usu_Administrador)))
            {
                DialogResult dr = MessageBox.Show("Desea Eliminar el Registro", "Eliminar Registro", MessageBoxButtons.YesNo,MessageBoxIcon.Warning);

                if (dr == DialogResult.Yes)
                {
                    foreach (DataGridViewRow item in dataGridView1.SelectedRows)
                    {
                        string placa = item.Cells[Var_Name.Placa].Value.ToString();
                        string serie = item.Cells[Var_Name.Serie].Value.ToString();
                        int accion = Convert.ToInt32(item.Cells["Orden"].Value.ToString());
                        int estacion = Convert.ToInt32(item.Cells["Numero_Estacion"].Value.ToString());
                        bool estado = base_datos.Eliminar_Equipo_Nuevo(placa, serie, accion,estacion);
                        if (estado)
                        {
                            MessageBox.Show("Registro eliminado", "Datos Actualizados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dataGridView1.DataSource = base_datos.Obtener_Datos_Lista_instituciones(text_placa.Text, Var_Name.Placa);
                        }


                    }
                }
            }
            
            

        }
        private void t1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            instance = null;
            this.Close();
        }

        private void t2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = base_datos.Obtener_Datos_Lista_instituciones(text_placa.Text, Var_Name.Placa);
            text_placa.Text = string.Empty;
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            dataGridView1.DataSource = base_datos.Obtener_Datos_Lista_instituciones(txt_serie.Text, Var_Name.Serie);
            txt_serie.Text = string.Empty;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            procesar_busqueda_institucion();
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
        private void procesar_busqueda_institucion()
        {
            dataGridView1.DataSource = base_datos.Obtener_Datos_Lista_instituciones(txt_institucion.Text, Var_Name.Institucion);
            txt_institucion.Focus();
            txt_institucion.Text = string.Empty;
        }

        private void Txt_institucion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                procesar_busqueda_institucion(); 
            }
        }
    }
}
