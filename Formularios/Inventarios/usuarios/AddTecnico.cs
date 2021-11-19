using InventarioFod.Clases;
using System;
using System.Windows.Forms;

namespace InventarioFod.Formularios.Inventarios.usuarios
{
    public partial class AddTecnico : Form
    {
        private readonly Conexion_db_Mysql baseDatos;
        private Orden_salida_materiales _materiales;
        public AddTecnico(Orden_salida_materiales _ordenMateriales)
        {
            InitializeComponent();
            baseDatos = Conexion_db_Mysql.Get_Instance;
            _materiales = _ordenMateriales;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            bool estado = baseDatos.Save_Tecnicos(nom_tec.Text.ToUpper());
            if (estado)
            {
                MessageBox.Show("Datos Registrados","Agregar Usuario" , MessageBoxButtons.OK, MessageBoxIcon.Information);
                nom_tec.Text = string.Empty;
                _materiales.Cargar_Tecnicos();
            }
            else
            {
                MessageBox.Show("Error al Agregar Usuario", "Agregar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
