using InventarioFod.Clases;
using InventarioFod.Clases.Entidades.Security;
using System;
using System.Windows.Forms;

namespace InventarioFod.Formularios.Inventarios.usuarios
{
    public partial class agregar_usuario : Form
    {
        private Conexion_db_Mysql basedatos;
        public agregar_usuario()
        {
            InitializeComponent();
            basedatos = Conexion_db_Mysql.Get_Instance;
            foreach (var item in basedatos.Get_Roles())
            {
                rol.Items.Add(item);
            }
        }

        private void XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string user_val = Usuario_Seguridad.Procesar_Nombre_Usuarios(user.Text);
            string pass_val = Usuario_Seguridad.Procesar_Pass_Usuarios(pass.Text);
           bool estado= basedatos.Insertar_Usuarios(user_val,pass_val,rol.SelectedItem.ToString());
            if (estado)
            {
                MessageBox.Show("Datos Guardados", "Opciones Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error al ingresar los datos", "Error al ingresar datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
