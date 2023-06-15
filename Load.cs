using System.Threading;
using System.Windows.Forms;

namespace SystemIventory
{
    public partial class Load : Form
    {
        System.Windows.Forms.Timer tiempo = new System.Windows.Forms.Timer();
        private int val_suma = 2;
        public Load()
        {
            InitializeComponent();
            panel2.Left = 0;

        }

        private void iniciar_animacion(object sender, System.EventArgs e)
        {
            panel2.Left += val_suma;

            if (panel2.Left >  207)
            {
                val_suma = -2;
                panel2.BackColor = System.Drawing.Color.FromArgb(21, 250, 111);
            }
            if (panel2.Left < 0)
            {
                val_suma = 2;
                panel2.BackColor = System.Drawing.Color.FromArgb(21, 101, 250);
            }
        }
        public void Iniciar()
        {
           
            tiempo.Tick += new System.EventHandler(iniciar_animacion);
            tiempo.Interval = 10;
            tiempo.Start();
        }

        private void cargar_Load(object sender, System.EventArgs e)
        {
 
        }
    }
}
