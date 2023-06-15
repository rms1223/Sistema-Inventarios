namespace SystemIventory.Reports
{
    partial class ViewOrderReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rptpedidos = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rptpedidos
            // 
            this.rptpedidos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptpedidos.Location = new System.Drawing.Point(0, 0);
            this.rptpedidos.Name = "rptpedidos";
            this.rptpedidos.ServerReport.BearerToken = null;
            this.rptpedidos.Size = new System.Drawing.Size(964, 768);
            this.rptpedidos.TabIndex = 0;
            // 
            // VerPediddo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(964, 768);
            this.Controls.Add(this.rptpedidos);
            this.Name = "VerPediddo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Solicitud de Equipo";
            this.Load += new System.EventHandler(this.VerPediddo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptpedidos;
    }
}