namespace InventarioFod.Formularios.Inventarios
{
    partial class Orden_salida_materiales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Orden_salida_materiales));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.xToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.descripcion = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.tecnicos = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.materiales_salida = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.descripcion_material = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.orden_trabajo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.add_user = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.materiales_salida)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.add_user)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(632, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // xToolStripMenuItem
            // 
            this.xToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.xToolStripMenuItem.ForeColor = System.Drawing.Color.Red;
            this.xToolStripMenuItem.Name = "xToolStripMenuItem";
            this.xToolStripMenuItem.Size = new System.Drawing.Size(26, 20);
            this.xToolStripMenuItem.Text = "X";
            this.xToolStripMenuItem.Click += new System.EventHandler(this.XToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.groupBox1.Controls.Add(this.add_user);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.descripcion);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.tecnicos);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.materiales_salida);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Controls.Add(this.descripcion_material);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.orden_trabajo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(13, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(607, 536);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Solicitud de Materiales";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(127, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Descipcion";
            // 
            // descripcion
            // 
            this.descripcion.Location = new System.Drawing.Point(261, 83);
            this.descripcion.Multiline = true;
            this.descripcion.Name = "descripcion";
            this.descripcion.Size = new System.Drawing.Size(227, 60);
            this.descripcion.TabIndex = 11;
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(533, 494);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(37, 32);
            this.button2.TabIndex = 10;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // tecnicos
            // 
            this.tecnicos.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tecnicos.FormattingEnabled = true;
            this.tecnicos.Items.AddRange(new object[] {
            "ANDREI",
            "EDUARDO",
            "ERICK",
            "FABIAN",
            "PATRICK",
            "RANDY",
            "WALTER"});
            this.tecnicos.Location = new System.Drawing.Point(182, 474);
            this.tecnicos.Name = "tecnicos";
            this.tecnicos.Size = new System.Drawing.Size(226, 21);
            this.tecnicos.Sorted = true;
            this.tecnicos.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(127, 477);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Tecnico:";
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(528, 174);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 39);
            this.button1.TabIndex = 7;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // materiales_salida
            // 
            this.materiales_salida.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.materiales_salida.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.materiales_salida.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.materiales_salida.BackgroundColor = System.Drawing.Color.White;
            this.materiales_salida.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.materiales_salida.Location = new System.Drawing.Point(42, 264);
            this.materiales_salida.Name = "materiales_salida";
            this.materiales_salida.Size = new System.Drawing.Size(528, 192);
            this.materiales_salida.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(439, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Cantidad";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(442, 191);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(52, 20);
            this.numericUpDown1.TabIndex = 5;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown1.Leave += new System.EventHandler(this.NumericUpDown1_Leave);
            // 
            // descripcion_material
            // 
            this.descripcion_material.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.descripcion_material.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.AllSystemSources;
            this.descripcion_material.FormattingEnabled = true;
            this.descripcion_material.Location = new System.Drawing.Point(112, 190);
            this.descripcion_material.Name = "descripcion_material";
            this.descripcion_material.Size = new System.Drawing.Size(313, 21);
            this.descripcion_material.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(130, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Descripcion Material";
            // 
            // orden_trabajo
            // 
            this.orden_trabajo.AutoSize = true;
            this.orden_trabajo.ForeColor = System.Drawing.Color.Red;
            this.orden_trabajo.Location = new System.Drawing.Point(303, 30);
            this.orden_trabajo.Name = "orden_trabajo";
            this.orden_trabajo.Size = new System.Drawing.Size(35, 13);
            this.orden_trabajo.TabIndex = 1;
            this.orden_trabajo.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(127, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Numero de Orden:";
            // 
            // add_user
            // 
            this.add_user.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.add_user.Cursor = System.Windows.Forms.Cursors.Hand;
            this.add_user.Image = ((System.Drawing.Image)(resources.GetObject("add_user.Image")));
            this.add_user.Location = new System.Drawing.Point(89, 474);
            this.add_user.Name = "add_user";
            this.add_user.Size = new System.Drawing.Size(32, 21);
            this.add_user.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.add_user.TabIndex = 13;
            this.add_user.TabStop = false;
            this.add_user.Click += new System.EventHandler(this.PictureBox1_Click);
            // 
            // Orden_salida_materiales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(632, 576);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Orden_salida_materiales";
            this.Text = "orden salida materiales";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.materiales_salida)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.add_user)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem xToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label orden_trabajo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox descripcion_material;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox tecnicos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView materiales_salida;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox descripcion;
        private System.Windows.Forms.PictureBox add_user;
    }
}