using SystemIventory.Classes;
using System;
using System.Windows.Forms;

namespace SystemIventory.Forms.AdministrativesForms
{
    public partial class CreateCartelForm : Form
    {
        private ConnectionMysqlDatabase baseDatos;
        public CreateCartelForm()
        {
            InitializeComponent();
            baseDatos = ConnectionMysqlDatabase.Get_Instance;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            bool estado = baseDatos.RegisterNewCartel(idCartel.Text,descripcion.Text,DateTime.Now.ToString());
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
