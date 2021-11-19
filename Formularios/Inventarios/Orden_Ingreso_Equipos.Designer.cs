namespace InventarioFod
{
    partial class Form_Principal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Principal));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.placa = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.institucion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.serie = new System.Windows.Forms.TextBox();
            this.buscar_serie = new System.Windows.Forms.Button();
            this.estacion = new System.Windows.Forms.NumericUpDown();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cambio_equipo = new System.Windows.Forms.CheckBox();
            this.orden_trabajo = new System.Windows.Forms.Label();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.guardar = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.t1ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.t2ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.label13 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.estacion)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView1.Size = new System.Drawing.Size(1020, 325);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(66, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Placa:";
            // 
            // placa
            // 
            this.placa.ForeColor = System.Drawing.Color.Black;
            this.placa.Location = new System.Drawing.Point(137, 29);
            this.placa.Name = "placa";
            this.placa.Size = new System.Drawing.Size(178, 20);
            this.placa.TabIndex = 6;
            this.placa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.placa.TextChanged += new System.EventHandler(this.placa_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(66, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Institución";
            // 
            // institucion
            // 
            this.institucion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.institucion.ForeColor = System.Drawing.Color.Black;
            this.institucion.Location = new System.Drawing.Point(136, 79);
            this.institucion.Name = "institucion";
            this.institucion.Size = new System.Drawing.Size(247, 20);
            this.institucion.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(67, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Modalidad";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.comboBox1.ForeColor = System.Drawing.Color.Black;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(137, 117);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(127, 21);
            this.comboBox1.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(397, 123);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Numero Estación";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(397, 34);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Serie:";
            // 
            // serie
            // 
            this.serie.ForeColor = System.Drawing.Color.Black;
            this.serie.Location = new System.Drawing.Point(457, 30);
            this.serie.Margin = new System.Windows.Forms.Padding(2);
            this.serie.Name = "serie";
            this.serie.Size = new System.Drawing.Size(172, 20);
            this.serie.TabIndex = 19;
            this.serie.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.serie.TextChanged += new System.EventHandler(this.serie_TextChanged);
            // 
            // buscar_serie
            // 
            this.buscar_serie.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buscar_serie.FlatAppearance.BorderSize = 0;
            this.buscar_serie.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.buscar_serie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buscar_serie.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buscar_serie.Image = ((System.Drawing.Image)(resources.GetObject("buscar_serie.Image")));
            this.buscar_serie.Location = new System.Drawing.Point(633, 29);
            this.buscar_serie.Margin = new System.Windows.Forms.Padding(2);
            this.buscar_serie.Name = "buscar_serie";
            this.buscar_serie.Size = new System.Drawing.Size(26, 24);
            this.buscar_serie.TabIndex = 20;
            this.buscar_serie.UseVisualStyleBackColor = true;
            this.buscar_serie.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // estacion
            // 
            this.estacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.estacion.ForeColor = System.Drawing.Color.Black;
            this.estacion.Location = new System.Drawing.Point(506, 120);
            this.estacion.Margin = new System.Windows.Forms.Padding(2);
            this.estacion.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.estacion.Name = "estacion";
            this.estacion.Size = new System.Drawing.Size(54, 21);
            this.estacion.TabIndex = 22;
            this.estacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.estacion.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(522, 75);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(71, 20);
            this.textBox1.TabIndex = 23;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(397, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "Buscar Institucion: ";
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(10, 28);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.panel1.Size = new System.Drawing.Size(1020, 226);
            this.panel1.TabIndex = 25;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.linkLabel3);
            this.groupBox1.Controls.Add(this.cambio_equipo);
            this.groupBox1.Controls.Add(this.orden_trabajo);
            this.groupBox1.Controls.Add(this.linkLabel2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.guardar);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.linkLabel1);
            this.groupBox1.Controls.Add(this.estacion);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.placa);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.buscar_serie);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.serie);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.institucion);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(109, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(805, 209);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Orden de Trabajo";
            // 
            // cambio_equipo
            // 
            this.cambio_equipo.AutoSize = true;
            this.cambio_equipo.Location = new System.Drawing.Point(299, 122);
            this.cambio_equipo.Name = "cambio_equipo";
            this.cambio_equipo.Size = new System.Drawing.Size(61, 17);
            this.cambio_equipo.TabIndex = 40;
            this.cambio_equipo.Text = "Cambio";
            this.cambio_equipo.UseVisualStyleBackColor = true;
            // 
            // orden_trabajo
            // 
            this.orden_trabajo.AutoSize = true;
            this.orden_trabajo.Location = new System.Drawing.Point(183, 180);
            this.orden_trabajo.Name = "orden_trabajo";
            this.orden_trabajo.Size = new System.Drawing.Size(0, 13);
            this.orden_trabajo.TabIndex = 38;
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.BackColor = System.Drawing.Color.White;
            this.linkLabel2.ForeColor = System.Drawing.Color.Blue;
            this.linkLabel2.LinkColor = System.Drawing.Color.Blue;
            this.linkLabel2.Location = new System.Drawing.Point(279, 180);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(72, 13);
            this.linkLabel2.TabIndex = 37;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Buscar Orden";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel2_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(66, 180);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Orden de Trabajo:";
            // 
            // label2
            // 
            this.label2.Image = ((System.Drawing.Image)(resources.GetObject("label2.Image")));
            this.label2.Location = new System.Drawing.Point(733, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 26);
            this.label2.TabIndex = 17;
            this.label2.Click += new System.EventHandler(this.label2_Click_1);
            this.label2.MouseEnter += new System.EventHandler(this.label2_MouseEnter);
            this.label2.MouseLeave += new System.EventHandler(this.label2_MouseLeave);
            // 
            // guardar
            // 
            this.guardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guardar.Image = ((System.Drawing.Image)(resources.GetObject("guardar.Image")));
            this.guardar.Location = new System.Drawing.Point(722, 161);
            this.guardar.Name = "guardar";
            this.guardar.Size = new System.Drawing.Size(33, 32);
            this.guardar.TabIndex = 27;
            this.guardar.Click += new System.EventHandler(this.label2_Click);
            this.guardar.MouseEnter += new System.EventHandler(this.guardar_MouseEnter);
            this.guardar.MouseLeave += new System.EventHandler(this.guardar_MouseLeave);
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(320, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(24, 24);
            this.button1.TabIndex = 7;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(597, 79);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(95, 13);
            this.linkLabel1.TabIndex = 32;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Agregar Institución";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.t1ToolStripMenuItem1,
            this.t2ToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(10, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(1020, 28);
            this.menuStrip1.TabIndex = 30;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // t1ToolStripMenuItem1
            // 
            this.t1ToolStripMenuItem1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.t1ToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("t1ToolStripMenuItem1.Image")));
            this.t1ToolStripMenuItem1.Name = "t1ToolStripMenuItem1";
            this.t1ToolStripMenuItem1.Size = new System.Drawing.Size(32, 24);
            this.t1ToolStripMenuItem1.Click += new System.EventHandler(this.t1ToolStripMenuItem1_Click);
            // 
            // t2ToolStripMenuItem1
            // 
            this.t2ToolStripMenuItem1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.t2ToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("t2ToolStripMenuItem1.Image")));
            this.t2ToolStripMenuItem1.Name = "t2ToolStripMenuItem1";
            this.t2ToolStripMenuItem1.Size = new System.Drawing.Size(32, 24);
            this.t2ToolStripMenuItem1.Click += new System.EventHandler(this.t2ToolStripMenuItem1_Click);
            // 
            // label13
            // 
            this.label13.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label13.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label13.Image = ((System.Drawing.Image)(resources.GetObject("label13.Image")));
            this.label13.Location = new System.Drawing.Point(10, 579);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(1020, 23);
            this.label13.TabIndex = 26;
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(10, 254);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1020, 325);
            this.panel2.TabIndex = 33;
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.BackColor = System.Drawing.Color.White;
            this.linkLabel3.ForeColor = System.Drawing.Color.Blue;
            this.linkLabel3.LinkColor = System.Drawing.Color.Blue;
            this.linkLabel3.Location = new System.Drawing.Point(422, 180);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(66, 13);
            this.linkLabel3.TabIndex = 41;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "Ver Solicitud";
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel3_LinkClicked);
            // 
            // Form_Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1040, 612);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form_Principal";
            this.Padding = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventario v1.1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.estacion)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox placa;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox institucion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox serie;
        private System.Windows.Forms.Button buscar_serie;
        private System.Windows.Forms.NumericUpDown estacion;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripMenuItem t1ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem t2ToolStripMenuItem1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label guardar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.Label orden_trabajo;
        private System.Windows.Forms.CheckBox cambio_equipo;
        private System.Windows.Forms.LinkLabel linkLabel3;
    }
}

