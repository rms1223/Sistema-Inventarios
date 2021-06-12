using InventarioFod.Clases;
using System;
using System.Windows.Forms;

namespace InventarioFod.Formularios.Inventarios
{
    public partial class RegistrarModelosEquipos : Form
    {
        private Conexion_db_Mysql baseDatos;
        
        public RegistrarModelosEquipos()
        {
            InitializeComponent();
            baseDatos = Conexion_db_Mysql.Get_Instance;
            label2.Text = baseDatos.GET_Siguiente_Codigo().ToString();

            foreach (var item in baseDatos.GET_Tipos_Equipos())
            {
                tipo.Items.Add(item);
            }
        }

        private void XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                int codigo_equipo = Convert.ToInt32(label2.Text);
                string tipo_equipo = tipo.SelectedItem.ToString();
                string[] tipo1 = tipo_equipo.Split('-');
                baseDatos.Guardar_Modelos_equipos(codigo_equipo, marca.Text, modelo.Text, tipo1[0]);
                MessageBox.Show("Registro de datos", "Datos Registrados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error de Registro","Error al Registrar los datos\n"+ex,MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
        }
    }
}
