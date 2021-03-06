using InventarioFod.Clases;
using InventarioFod.Clases.Entidades;
using System;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace InventarioFod.Formularios.Administrativo
{
    public partial class verificar_instalaciones : Form
    {
        private string url_image = string.Empty;
        private Conexion_db_Mysql datos_externa;
        public verificar_instalaciones()
        {
            InitializeComponent();
            datos_externa = Conexion_db_Mysql.Get_Instance;
            download_photo.Visible = false;

        }

        private void XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Instalaciones insta = datos_externa.Get_Datos_Instalaciones(codigo.Text);

            cod_pre.Text = insta.Codigo_pre;
            cant_ap.Text = Convert.ToString(insta.Cantidad_aps);
            descripcion.Text = insta.Descripcion;
            fecha.Text = insta.Fecha;
            if (!string.IsNullOrEmpty(insta.Documento))
            {
                url_image = insta.Documento;
                download_photo.Visible = true;
                var request = WebRequest.Create(insta.Documento);
                using (var response = request.GetResponse())
                using (var stream = response.GetResponseStream())
                {
                    pictureBox1.Image = Bitmap.FromStream(stream);
                }
            }
            

        }

        private void Download_photo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string ruta_archivo = string.Empty;
            string[] val = new Uri(url_image).Segments;
            try
            {
                SaveFileDialog file = new SaveFileDialog
                {
                    Filter = "All files (*.*)|*.*",
                    Title = "Guardar Archivo",
                    FileName = val[val.Length - 1]
                };
                if (file.ShowDialog() == DialogResult.OK)
                {
                    if (file.FileName.Equals("") == false)
                    {
                        ruta_archivo = file.FileName;
                    }
                    using (WebClient client = new WebClient())
                    {
                        client.DownloadFileAsync(new Uri(url_image),ruta_archivo);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guaradar Archivo\n"+ex);
            }

        }
    }
}
