using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SystemIventory.Forms
{
    public partial class LoadForm : Form
    {
        private string _loadText = "Loading....";
        private System.Windows.Forms.Timer _time = new System.Windows.Forms.Timer();
        private StringBuilder _build;
        private delegate_update_string _delegateString;
        private int contador =0;


        public LoadForm()
        {
            InitializeComponent();
            _build = new StringBuilder(_loadText);
            _delegateString = new delegate_update_string(UpdateMainString);
            label1.Text = _build.ToString();
        }

        public  delegate void delegate_update_string();
        public void UpdateMainString()
        {
            
            contador++;
            label1.Text = _build.Append(".").ToString();
            label2.Image = Image.FromFile(Path.Combine(Application.StartupPath, @"Imagenes\load_whiteBlue.png"));
            if (contador == 4)
            {
                _build.Clear();
                _build.Append(_loadText);
                contador = 0;
                label2.Image = Image.FromFile(Path.Combine(Application.StartupPath, @"Imagenes\load_white.png"));
                
            } else if (contador ==2)
            {
                label2.Image = Image.FromFile(Path.Combine(Application.StartupPath, @"Imagenes\load_white.png"));
            }

            
        }

        private void AnimationMove(object sender, System.EventArgs e)
        {
            Thread.Sleep(1000);
            _delegateString();
        }
        private void LoadingForm(object sender, System.EventArgs e)
        {
            this.Focus();
            _time.Tick += new System.EventHandler(AnimationMove);
            _time.Interval = 10;
            _time.Start();
        }
    }
}
