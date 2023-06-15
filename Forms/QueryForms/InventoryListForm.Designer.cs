namespace SystemIventory
{
    partial class InventoryListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InventoryListForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buscar_institucion = new System.Windows.Forms.Button();
            this.buscar_serie = new System.Windows.Forms.Button();
            this.buscar_placa = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_institucion = new System.Windows.Forms.TextBox();
            this.text_placa = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_serie = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarArchivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.t1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.t2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(8, 28);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panel1.Size = new System.Drawing.Size(798, 140);
            this.panel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.buscar_institucion);
            this.groupBox1.Controls.Add(this.buscar_serie);
            this.groupBox1.Controls.Add(this.buscar_placa);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_institucion);
            this.groupBox1.Controls.Add(this.text_placa);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_serie);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(100, 20);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(621, 100);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Consulta Equipos Asignados";
            // 
            // buscar_institucion
            // 
            this.buscar_institucion.FlatAppearance.BorderSize = 0;
            this.buscar_institucion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buscar_institucion.Image = ((System.Drawing.Image)(resources.GetObject("buscar_institucion.Image")));
            this.buscar_institucion.Location = new System.Drawing.Point(590, 33);
            this.buscar_institucion.Name = "buscar_institucion";
            this.buscar_institucion.Size = new System.Drawing.Size(26, 23);
            this.buscar_institucion.TabIndex = 9;
            this.buscar_institucion.UseVisualStyleBackColor = true;
            this.buscar_institucion.Click += new System.EventHandler(this.Button3_Click);
            // 
            // buscar_serie
            // 
            this.buscar_serie.FlatAppearance.BorderSize = 0;
            this.buscar_serie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buscar_serie.Image = ((System.Drawing.Image)(resources.GetObject("buscar_serie.Image")));
            this.buscar_serie.Location = new System.Drawing.Point(323, 33);
            this.buscar_serie.Name = "buscar_serie";
            this.buscar_serie.Size = new System.Drawing.Size(22, 23);
            this.buscar_serie.TabIndex = 8;
            this.buscar_serie.UseVisualStyleBackColor = true;
            this.buscar_serie.Click += new System.EventHandler(this.Button2_Click_2);
            // 
            // buscar_placa
            // 
            this.buscar_placa.FlatAppearance.BorderSize = 0;
            this.buscar_placa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buscar_placa.Image = ((System.Drawing.Image)(resources.GetObject("buscar_placa.Image")));
            this.buscar_placa.Location = new System.Drawing.Point(140, 32);
            this.buscar_placa.Name = "buscar_placa";
            this.buscar_placa.Size = new System.Drawing.Size(24, 24);
            this.buscar_placa.TabIndex = 7;
            this.buscar_placa.UseVisualStyleBackColor = true;
            this.buscar_placa.Click += new System.EventHandler(this.Button1_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Placa:";
            // 
            // txt_institucion
            // 
            this.txt_institucion.Location = new System.Drawing.Point(474, 36);
            this.txt_institucion.Margin = new System.Windows.Forms.Padding(2);
            this.txt_institucion.Name = "txt_institucion";
            this.txt_institucion.Size = new System.Drawing.Size(112, 21);
            this.txt_institucion.TabIndex = 6;
            this.txt_institucion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_institucion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_institucion_KeyDown);
            this.txt_institucion.Leave += new System.EventHandler(this.Txt_institucion_Leave);
            // 
            // text_placa
            // 
            this.text_placa.Location = new System.Drawing.Point(52, 37);
            this.text_placa.Margin = new System.Windows.Forms.Padding(2);
            this.text_placa.Name = "text_placa";
            this.text_placa.Size = new System.Drawing.Size(83, 21);
            this.text_placa.TabIndex = 1;
            this.text_placa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.text_placa.TextChanged += new System.EventHandler(this.Text_placa_TextChanged);
            this.text_placa.Leave += new System.EventHandler(this.Text_placa_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(366, 39);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Centro Educativo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(182, 39);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Serie";
            // 
            // txt_serie
            // 
            this.txt_serie.Location = new System.Drawing.Point(217, 37);
            this.txt_serie.Margin = new System.Windows.Forms.Padding(2);
            this.txt_serie.Name = "txt_serie";
            this.txt_serie.Size = new System.Drawing.Size(101, 21);
            this.txt_serie.TabIndex = 4;
            this.txt_serie.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.t1ToolStripMenuItem,
            this.t2ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(8, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(798, 28);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportarArchivoToolStripMenuItem});
            this.archivoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("archivoToolStripMenuItem.Image")));
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(89, 24);
            this.archivoToolStripMenuItem.Text = "Opciones";
            this.archivoToolStripMenuItem.ToolTipText = "Opciones de Archivos";
            // 
            // exportarArchivoToolStripMenuItem
            // 
            this.exportarArchivoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exportarArchivoToolStripMenuItem.Image")));
            this.exportarArchivoToolStripMenuItem.Name = "exportarArchivoToolStripMenuItem";
            this.exportarArchivoToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.exportarArchivoToolStripMenuItem.Text = "Exportar";
            this.exportarArchivoToolStripMenuItem.ToolTipText = "Exportar Archivo a Excel";
            // 
            // t1ToolStripMenuItem
            // 
            this.t1ToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.t1ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("t1ToolStripMenuItem.Image")));
            this.t1ToolStripMenuItem.Name = "t1ToolStripMenuItem";
            this.t1ToolStripMenuItem.Size = new System.Drawing.Size(32, 24);
            this.t1ToolStripMenuItem.Click += new System.EventHandler(this.T1ToolStripMenuItem_Click);
            // 
            // t2ToolStripMenuItem
            // 
            this.t2ToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.t2ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("t2ToolStripMenuItem.Image")));
            this.t2ToolStripMenuItem.Name = "t2ToolStripMenuItem";
            this.t2ToolStripMenuItem.Size = new System.Drawing.Size(32, 24);
            this.t2ToolStripMenuItem.Click += new System.EventHandler(this.T2ToolStripMenuItem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(8, 168);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(798, 326);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridView1_RowHeaderMouseDoubleClick);
            // 
            // Lista_inventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(814, 502);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimizeBox = false;
            this.Name = "Lista_inventario";
            this.Padding = new System.Windows.Forms.Padding(8, 0, 8, 8);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista_inventario";
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox text_placa;
        private System.Windows.Forms.TextBox txt_serie;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_institucion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportarArchivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem t1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem t2ToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buscar_institucion;
        private System.Windows.Forms.Button buscar_serie;
        private System.Windows.Forms.Button buscar_placa;
    }
}