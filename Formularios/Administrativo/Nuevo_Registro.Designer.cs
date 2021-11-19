namespace InventarioFod.Formularios.Administrativo
{
    partial class Nuevo_Registro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Nuevo_Registro));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Guardar = new System.Windows.Forms.Button();
            this.institucion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.xToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.id_lote = new System.Windows.Forms.TextBox();
            this.nom_modalidad = new System.Windows.Forms.TextBox();
            this.nom_condicion = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.nom_condicion);
            this.groupBox1.Controls.Add(this.nom_modalidad);
            this.groupBox1.Controls.Add(this.id_lote);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.Guardar);
            this.groupBox1.Controls.Add(this.institucion);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.linkLabel1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(600, 366);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de Registro";
            // 
            // Guardar
            // 
            this.Guardar.FlatAppearance.BorderSize = 0;
            this.Guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Guardar.Image = ((System.Drawing.Image)(resources.GetObject("Guardar.Image")));
            this.Guardar.Location = new System.Drawing.Point(387, 319);
            this.Guardar.Name = "Guardar";
            this.Guardar.Size = new System.Drawing.Size(32, 35);
            this.Guardar.TabIndex = 10;
            this.Guardar.UseVisualStyleBackColor = true;
            this.Guardar.Click += new System.EventHandler(this.Button1_Click);
            // 
            // institucion
            // 
            this.institucion.Location = new System.Drawing.Point(217, 102);
            this.institucion.Multiline = true;
            this.institucion.Name = "institucion";
            this.institucion.Size = new System.Drawing.Size(202, 50);
            this.institucion.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(87, 223);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Condición:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(89, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Modalidad";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(87, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Institucion:";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(474, 47);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(95, 13);
            this.linkLabel1.TabIndex = 2;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Agregar Institucion";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1_LinkClicked);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(217, 44);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(202, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.Leave += new System.EventHandler(this.TextBox1_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codigo Presupuestario";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(627, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // xToolStripMenuItem
            // 
            this.xToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.xToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xToolStripMenuItem.ForeColor = System.Drawing.Color.Red;
            this.xToolStripMenuItem.Name = "xToolStripMenuItem";
            this.xToolStripMenuItem.Size = new System.Drawing.Size(30, 24);
            this.xToolStripMenuItem.Text = "X";
            this.xToolStripMenuItem.Click += new System.EventHandler(this.XToolStripMenuItem_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(90, 273);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Lote:";
            // 
            // id_lote
            // 
            this.id_lote.Location = new System.Drawing.Point(219, 270);
            this.id_lote.Name = "id_lote";
            this.id_lote.Size = new System.Drawing.Size(200, 20);
            this.id_lote.TabIndex = 12;
            this.id_lote.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nom_modalidad
            // 
            this.nom_modalidad.Location = new System.Drawing.Point(217, 178);
            this.nom_modalidad.Name = "nom_modalidad";
            this.nom_modalidad.Size = new System.Drawing.Size(202, 20);
            this.nom_modalidad.TabIndex = 13;
            this.nom_modalidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nom_condicion
            // 
            this.nom_condicion.Location = new System.Drawing.Point(217, 220);
            this.nom_condicion.Name = "nom_condicion";
            this.nom_condicion.Size = new System.Drawing.Size(202, 20);
            this.nom_condicion.TabIndex = 14;
            this.nom_condicion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Nuevo_Registro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 409);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Nuevo_Registro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nuevo_Registro";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox institucion;
        private System.Windows.Forms.Button Guardar;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem xToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox id_lote;
        private System.Windows.Forms.TextBox nom_condicion;
        private System.Windows.Forms.TextBox nom_modalidad;
    }
}