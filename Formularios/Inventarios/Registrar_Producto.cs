using InventarioFod.Clases;
using System;
using System.Windows.Forms;

namespace InventarioFod.Formularios.Inventarios
{
    public partial class Registrar_Producto : Form
    {
        private Conexion_db_Mysql base_datos;
        private Materiales _materiales;
        public Registrar_Producto(Materiales _inevenMateriales)
        {
            InitializeComponent();
            _materiales = _inevenMateriales;
            base_datos = Conexion_db_Mysql.Get_Instance;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            base_datos.Registrar_Producto(cod_init.Text + "" + cod.Text, textBox2.Text);
            MessageBox.Show("Datos Guardados", "Opciones Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _materiales.Cargar_Inventario_Materiales();
        }
    }
}
