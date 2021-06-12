using InventarioFod.Clases;
using System;
using System.Windows.Forms;

namespace InventarioFod.Formularios.Inventarios
{
    public partial class Registrar_Producto : Form
    {
        private Conexion_db_Mysql base_datos;
        public Registrar_Producto()
        {
            InitializeComponent();
            base_datos = Conexion_db_Mysql.Get_Instance;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            base_datos.Registrar_Producto(cod_init.Text + "" + cod.Text, textBox2.Text);
            MessageBox.Show("Datos Guardados", "Opciones Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
