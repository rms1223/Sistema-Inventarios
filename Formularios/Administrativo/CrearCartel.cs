using InventarioFod.Clases;
using System;
using System.Windows.Forms;

namespace InventarioFod.Formularios.Administrativo
{
    public partial class CrearCartel : Form
    {
        private Conexion_db_Mysql baseDatos;
        public CrearCartel()
        {
            InitializeComponent();
            baseDatos = Conexion_db_Mysql.Get_Instance;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            bool estado = baseDatos.Registrar_Cartel(idCartel.Text,descripcion.Text,DateTime.Now.ToString());
            if (estado)
            {
                MessageBox.Show("Datos Registrados", "Registro Cartel", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error al Registrar datos", "Registro Cartel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                
        }

    }
}
