using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace InventarioFod.Formularios
{
    public partial class Form_Cargar : Form
    {
        private string cargar = "Por favor espere";
        private System.Windows.Forms.Timer time = new System.Windows.Forms.Timer();
        private StringBuilder build;
        private delegate_update_string delegate_string;
        private int contador =0;


        public Form_Cargar()
        {
            InitializeComponent();
            build = new StringBuilder(cargar);
            delegate_string = new delegate_update_string(Actualizar_Cadena);
            label1.Text = build.ToString();
        }

        public  delegate void delegate_update_string();
        public void Actualizar_Cadena()
        {
            
            contador++;
            label1.Text = build.Append(".").ToString();
            label2.Image = Image.FromFile(Path.Combine(Application.StartupPath, @"Imagenes\load_whiteBlue.png"));
            if (contador == 4)
            {
                build.Clear();
                build.Append(cargar);
                contador = 0;
                label2.Image = Image.FromFile(Path.Combine(Application.StartupPath, @"Imagenes\load_white.png"));
                
            } else if (contador ==2)
            {
                label2.Image = Image.FromFile(Path.Combine(Application.StartupPath, @"Imagenes\load_white.png"));
            }

            
        }

        private void mover(object sender, System.EventArgs e)
        {
            Thread.Sleep(1000);
            delegate_string();
        }
        private void Form_Cargar_Load(object sender, System.EventArgs e)
        {
            this.Focus();
            time.Tick += new System.EventHandler(mover);
            time.Interval = 10;
            time.Start();
        }
    }
}
