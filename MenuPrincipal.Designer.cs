namespace InventarioFod
{
    partial class MenuPrincipal
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuPrincipal));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Agregar Lista", 1, 10);
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Imprimir Lista", 13, 10);
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Listas", 0, 10, new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Reequipamiento", 16, 10);
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Acciones", 3, 10);
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Inventarios", 15, 10, new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Agregar Accion", 1, 10);
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Aplicar Acciones", 17, 10);
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Acciones", 14, 10, new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8});
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Reequipamiento", 16, 10);
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Acciones", 3, 10);
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Listados", 22, 10);
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Equipos en acciones", 23, 10);
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Consultas", 18, 10, new System.Windows.Forms.TreeNode[] {
            treeNode10,
            treeNode11,
            treeNode12,
            treeNode13});
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Acciones Revisadas", 20, 10);
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Reequipamiento");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("General de Acciones", 3, 10);
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Equipos Proveedor", 21, 10);
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Reportes", 19, 10, new System.Windows.Forms.TreeNode[] {
            treeNode15,
            treeNode16,
            treeNode17,
            treeNode18});
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Enviar Correo", 25, 10);
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("Correo", 24, 10, new System.Windows.Forms.TreeNode[] {
            treeNode20});
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panelPrincipal = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cerraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelPrincipal.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.treeView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(194, 676);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(192, 95);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Teal;
            this.label3.Location = new System.Drawing.Point(0, 657);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "label3";
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.Color.White;
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.ForeColor = System.Drawing.Color.Black;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.ItemHeight = 20;
            this.treeView1.Location = new System.Drawing.Point(0, 114);
            this.treeView1.Name = "treeView1";
            treeNode1.ImageIndex = 1;
            treeNode1.Name = "add_lista";
            treeNode1.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            treeNode1.SelectedImageIndex = 10;
            treeNode1.Text = "Agregar Lista";
            treeNode2.ImageIndex = 13;
            treeNode2.Name = "print_list";
            treeNode2.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            treeNode2.SelectedImageIndex = 10;
            treeNode2.Text = "Imprimir Lista";
            treeNode3.ImageIndex = 0;
            treeNode3.Name = "Listas";
            treeNode3.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode3.SelectedImageIndex = 10;
            treeNode3.Text = "Listas";
            treeNode3.ToolTipText = "Reequipamiento de equipos";
            treeNode4.ImageIndex = 16;
            treeNode4.Name = "inven_reeequi";
            treeNode4.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            treeNode4.SelectedImageIndex = 10;
            treeNode4.Text = "Reequipamiento";
            treeNode5.ImageIndex = 3;
            treeNode5.Name = "inven_acciones";
            treeNode5.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            treeNode5.SelectedImageIndex = 10;
            treeNode5.Text = "Acciones";
            treeNode6.ImageIndex = 15;
            treeNode6.Name = "Nodo1";
            treeNode6.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            treeNode6.SelectedImageIndex = 10;
            treeNode6.Text = "Inventarios";
            treeNode7.ImageIndex = 1;
            treeNode7.Name = "addAccion";
            treeNode7.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            treeNode7.SelectedImageIndex = 10;
            treeNode7.Text = "Agregar Accion";
            treeNode8.ImageIndex = 17;
            treeNode8.Name = "aplicar_accion";
            treeNode8.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            treeNode8.SelectedImageIndex = 10;
            treeNode8.Text = "Aplicar Acciones";
            treeNode9.ImageIndex = 14;
            treeNode9.Name = "Nodo2";
            treeNode9.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            treeNode9.SelectedImageIndex = 10;
            treeNode9.Text = "Acciones";
            treeNode10.ImageIndex = 16;
            treeNode10.Name = "list_reequi";
            treeNode10.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            treeNode10.SelectedImageIndex = 10;
            treeNode10.Text = "Reequipamiento";
            treeNode11.ImageIndex = 3;
            treeNode11.Name = "list_accion";
            treeNode11.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            treeNode11.SelectedImageIndex = 10;
            treeNode11.Text = "Acciones";
            treeNode12.ImageIndex = 22;
            treeNode12.Name = "consul_List";
            treeNode12.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            treeNode12.SelectedImageIndex = 10;
            treeNode12.Text = "Listados";
            treeNode13.ImageIndex = 23;
            treeNode13.Name = "verif_equipos";
            treeNode13.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            treeNode13.SelectedImageIndex = 10;
            treeNode13.Text = "Equipos en acciones";
            treeNode14.ImageIndex = 18;
            treeNode14.Name = "Nodo0";
            treeNode14.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            treeNode14.SelectedImageIndex = 10;
            treeNode14.Text = "Consultas";
            treeNode15.ImageIndex = 20;
            treeNode15.Name = "rpt_acciones";
            treeNode15.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            treeNode15.SelectedImageIndex = 10;
            treeNode15.Text = "Acciones Revisadas";
            treeNode16.ImageKey = "Laptop_16px.png";
            treeNode16.Name = "rpt_listas";
            treeNode16.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            treeNode16.SelectedImageIndex = 10;
            treeNode16.Text = "Reequipamiento";
            treeNode17.ImageIndex = 3;
            treeNode17.Name = "rpt_equi_accion";
            treeNode17.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            treeNode17.SelectedImageIndex = 10;
            treeNode17.Text = "General de Acciones";
            treeNode18.ImageIndex = 21;
            treeNode18.Name = "rpt_equiposproveedor";
            treeNode18.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            treeNode18.SelectedImageIndex = 10;
            treeNode18.Text = "Equipos Proveedor";
            treeNode19.ImageIndex = 19;
            treeNode19.Name = "Reportes";
            treeNode19.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            treeNode19.SelectedImageIndex = 10;
            treeNode19.Text = "Reportes";
            treeNode20.ImageIndex = 25;
            treeNode20.Name = "Send_Mail";
            treeNode20.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            treeNode20.SelectedImageIndex = 10;
            treeNode20.Text = "Enviar Correo";
            treeNode21.ImageIndex = 24;
            treeNode21.Name = "Mail";
            treeNode21.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            treeNode21.SelectedImageIndex = 10;
            treeNode21.Text = "Correo";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode6,
            treeNode9,
            treeNode14,
            treeNode19,
            treeNode21});
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(193, 482);
            this.treeView1.TabIndex = 3;
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Purchase Order_32px.png");
            this.imageList1.Images.SetKeyName(1, "Add File_32px.png");
            this.imageList1.Images.SetKeyName(2, "Check Book_32px.png");
            this.imageList1.Images.SetKeyName(3, "Compare_26px.png");
            this.imageList1.Images.SetKeyName(4, "Edit Property_26px.png");
            this.imageList1.Images.SetKeyName(5, "File_32px.png");
            this.imageList1.Images.SetKeyName(6, "Checked_32px.png");
            this.imageList1.Images.SetKeyName(7, "Checked Checkbox 2_32px.png");
            this.imageList1.Images.SetKeyName(8, "Checked_32px_1.png");
            this.imageList1.Images.SetKeyName(9, "Checked Checkbox_16px.png");
            this.imageList1.Images.SetKeyName(10, "Checked Checkbox_16px_1.png");
            this.imageList1.Images.SetKeyName(11, "Add Database_16px.png");
            this.imageList1.Images.SetKeyName(12, "Microsoft Excel_16px.png");
            this.imageList1.Images.SetKeyName(13, "Print_32px.png");
            this.imageList1.Images.SetKeyName(14, "Edit Property_16px.png");
            this.imageList1.Images.SetKeyName(15, "Folder_16px.png");
            this.imageList1.Images.SetKeyName(16, "Laptop_16px.png");
            this.imageList1.Images.SetKeyName(17, "Todo List_16px.png");
            this.imageList1.Images.SetKeyName(18, "View File_16px.png");
            this.imageList1.Images.SetKeyName(19, "Bullish_48px.png");
            this.imageList1.Images.SetKeyName(20, "Report Card_48px.png");
            this.imageList1.Images.SetKeyName(21, "icons8_Multiple_Devices_32px.png");
            this.imageList1.Images.SetKeyName(22, "icons8_List_View_32px.png");
            this.imageList1.Images.SetKeyName(23, "icons8_To_Do_32px.png");
            this.imageList1.Images.SetKeyName(24, "icons8_Microsoft_Outlook_32px.png");
            this.imageList1.Images.SetKeyName(25, "icons8_Send_32px.png");
            // 
            // panelPrincipal
            // 
            this.panelPrincipal.BackColor = System.Drawing.SystemColors.Control;
            this.panelPrincipal.Controls.Add(this.menuStrip1);
            this.panelPrincipal.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelPrincipal.Location = new System.Drawing.Point(194, 0);
            this.panelPrincipal.Name = "panelPrincipal";
            this.panelPrincipal.Size = new System.Drawing.Size(1120, 23);
            this.panelPrincipal.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cerraToolStripMenuItem,
            this.dffToolStripMenuItem,
            this.ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1120, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cerraToolStripMenuItem
            // 
            this.cerraToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cerraToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cerraToolStripMenuItem.Image")));
            this.cerraToolStripMenuItem.Name = "cerraToolStripMenuItem";
            this.cerraToolStripMenuItem.Size = new System.Drawing.Size(32, 20);
            this.cerraToolStripMenuItem.Click += new System.EventHandler(this.cerraToolStripMenuItem_Click);
            // 
            // dffToolStripMenuItem
            // 
            this.dffToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.dffToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("dffToolStripMenuItem.Image")));
            this.dffToolStripMenuItem.Name = "dffToolStripMenuItem";
            this.dffToolStripMenuItem.Size = new System.Drawing.Size(32, 20);
            this.dffToolStripMenuItem.Click += new System.EventHandler(this.dffToolStripMenuItem_Click);
            // 
            // ToolStripMenuItem
            // 
            this.ToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripMenuItem.Image")));
            this.ToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.ToolStripMenuItem.Name = "ToolStripMenuItem";
            this.ToolStripMenuItem.Size = new System.Drawing.Size(32, 20);
            this.ToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.ToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(194, 652);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.statusStrip1.Size = new System.Drawing.Size(1120, 24);
            this.statusStrip1.TabIndex = 30;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStatusLabel3.Image")));
            this.toolStripStatusLabel3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(137, 19);
            this.toolStripStatusLabel3.Text = "Centro de Soporte";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(133, 19);
            this.toolStripStatusLabel1.Text = "Sistema de Inventario";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabel2.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner;
            this.toolStripStatusLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStatusLabel2.Image")));
            this.toolStripStatusLabel2.Margin = new System.Windows.Forms.Padding(10, 3, 0, 2);
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(151, 19);
            this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(194, 23);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1120, 629);
            this.panel2.TabIndex = 31;
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1314, 676);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panelPrincipal);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MenuPrincipal";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelPrincipal.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelPrincipal;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cerraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dffToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
    }
}