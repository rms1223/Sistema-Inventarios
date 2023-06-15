namespace SystemIventory
{
    partial class MainMenuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenuForm));
            System.Windows.Forms.TreeNode treeNode30 = new System.Windows.Forms.TreeNode("Ingreso Nuevo Equipo");
            System.Windows.Forms.TreeNode treeNode31 = new System.Windows.Forms.TreeNode("Crear Orden de Trabajo", 16, 10);
            System.Windows.Forms.TreeNode treeNode32 = new System.Windows.Forms.TreeNode("Crear Orden de Ingreso", 30, 10);
            System.Windows.Forms.TreeNode treeNode33 = new System.Windows.Forms.TreeNode("Ordenes", 30, 10, new System.Windows.Forms.TreeNode[] {
            treeNode31,
            treeNode32});
            System.Windows.Forms.TreeNode treeNode34 = new System.Windows.Forms.TreeNode("Crear Orden Ingreso Materiales");
            System.Windows.Forms.TreeNode treeNode35 = new System.Windows.Forms.TreeNode("Crear Orden de Salida ");
            System.Windows.Forms.TreeNode treeNode36 = new System.Windows.Forms.TreeNode("Consulta Inventario Materiales");
            System.Windows.Forms.TreeNode treeNode37 = new System.Windows.Forms.TreeNode("Imprimir Orden de Materiales");
            System.Windows.Forms.TreeNode treeNode38 = new System.Windows.Forms.TreeNode("Materiales", new System.Windows.Forms.TreeNode[] {
            treeNode34,
            treeNode35,
            treeNode36,
            treeNode37});
            System.Windows.Forms.TreeNode treeNode39 = new System.Windows.Forms.TreeNode("Inventarios", 15, 10, new System.Windows.Forms.TreeNode[] {
            treeNode30,
            treeNode33,
            treeNode38});
            System.Windows.Forms.TreeNode treeNode40 = new System.Windows.Forms.TreeNode("Aplicar Estado de Ordenes Salida", 17, 10);
            System.Windows.Forms.TreeNode treeNode41 = new System.Windows.Forms.TreeNode("Opciones Ordenes", 14, 10, new System.Windows.Forms.TreeNode[] {
            treeNode40});
            System.Windows.Forms.TreeNode treeNode42 = new System.Windows.Forms.TreeNode("Estado Ordenes en Preparación", 22, 10);
            System.Windows.Forms.TreeNode treeNode43 = new System.Windows.Forms.TreeNode("Equipos en Ordenes de Trabajo", 23, 10);
            System.Windows.Forms.TreeNode treeNode44 = new System.Windows.Forms.TreeNode("Equipos Asignados a Centro Educativo", 16, 10);
            System.Windows.Forms.TreeNode treeNode45 = new System.Windows.Forms.TreeNode("Equipos en Laboratorios");
            System.Windows.Forms.TreeNode treeNode46 = new System.Windows.Forms.TreeNode("Ordenes", 20, 10, new System.Windows.Forms.TreeNode[] {
            treeNode42,
            treeNode43,
            treeNode44,
            treeNode45});
            System.Windows.Forms.TreeNode treeNode47 = new System.Windows.Forms.TreeNode("Revisar Placas en Ordenes", 31, 10);
            System.Windows.Forms.TreeNode treeNode48 = new System.Windows.Forms.TreeNode("Ingreso de Equipos Dañados", 21, 10);
            System.Windows.Forms.TreeNode treeNode49 = new System.Windows.Forms.TreeNode("Consultas", 18, 10, new System.Windows.Forms.TreeNode[] {
            treeNode46,
            treeNode47,
            treeNode48});
            System.Windows.Forms.TreeNode treeNode50 = new System.Windows.Forms.TreeNode("Preparacion de Equipos par CE", 26, 10);
            System.Windows.Forms.TreeNode treeNode51 = new System.Windows.Forms.TreeNode("Registrar Cartel", 4, 10);
            System.Windows.Forms.TreeNode treeNode52 = new System.Windows.Forms.TreeNode("Administrativo", new System.Windows.Forms.TreeNode[] {
            treeNode50,
            treeNode51});
            System.Windows.Forms.TreeNode treeNode53 = new System.Windows.Forms.TreeNode("Ordenes Revisadas", 20, 10);
            System.Windows.Forms.TreeNode treeNode54 = new System.Windows.Forms.TreeNode("General de Equipos", 3, 10);
            System.Windows.Forms.TreeNode treeNode55 = new System.Windows.Forms.TreeNode("Pedidos", 23, 10);
            System.Windows.Forms.TreeNode treeNode56 = new System.Windows.Forms.TreeNode("Ordenes", new System.Windows.Forms.TreeNode[] {
            treeNode53,
            treeNode54,
            treeNode55});
            System.Windows.Forms.TreeNode treeNode57 = new System.Windows.Forms.TreeNode("Equipos en Garantia");
            System.Windows.Forms.TreeNode treeNode58 = new System.Windows.Forms.TreeNode("Reportes", 19, 10, new System.Windows.Forms.TreeNode[] {
            treeNode56,
            treeNode57});
            this.panel1 = new System.Windows.Forms.Panel();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.ordenes_pendientes = new System.Windows.Forms.ToolStripStatusLabel();
            this.count_orden = new System.Windows.Forms.ToolStripStatusLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panelPrincipal = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cerraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opciones = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.statusStrip2.SuspendLayout();
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
            this.panel1.Controls.Add(this.statusStrip2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.treeView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(258, 676);
            this.panel1.TabIndex = 0;
            // 
            // statusStrip2
            // 
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ordenes_pendientes,
            this.count_orden});
            this.statusStrip2.Location = new System.Drawing.Point(0, 652);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(256, 22);
            this.statusStrip2.TabIndex = 5;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // ordenes_pendientes
            // 
            this.ordenes_pendientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ordenes_pendientes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ordenes_pendientes.Name = "ordenes_pendientes";
            this.ordenes_pendientes.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.ordenes_pendientes.Size = new System.Drawing.Size(132, 17);
            this.ordenes_pendientes.Text = "Ordenes Pendientes:";
            // 
            // count_orden
            // 
            this.count_orden.ActiveLinkColor = System.Drawing.Color.Red;
            this.count_orden.ForeColor = System.Drawing.Color.Blue;
            this.count_orden.Name = "count_orden";
            this.count_orden.Size = new System.Drawing.Size(13, 17);
            this.count_orden.Text = "0";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(256, 108);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.treeView1.BackColor = System.Drawing.Color.White;
            this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.ForeColor = System.Drawing.Color.Black;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.ItemHeight = 20;
            this.treeView1.Location = new System.Drawing.Point(-1, 114);
            this.treeView1.Name = "treeView1";
            treeNode30.Name = "nuevo_equipo";
            treeNode30.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            treeNode30.SelectedImageIndex = 10;
            treeNode30.Text = "Ingreso Nuevo Equipo";
            treeNode31.ImageIndex = 16;
            treeNode31.Name = "inven_reeequi";
            treeNode31.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            treeNode31.SelectedImageIndex = 10;
            treeNode31.Text = "Crear Orden de Trabajo";
            treeNode32.ImageIndex = 30;
            treeNode32.Name = "orden_ingreso";
            treeNode32.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            treeNode32.SelectedImageIndex = 10;
            treeNode32.Text = "Crear Orden de Ingreso";
            treeNode33.ImageIndex = 30;
            treeNode33.Name = "Nodo0";
            treeNode33.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            treeNode33.SelectedImageIndex = 10;
            treeNode33.Text = "Ordenes";
            treeNode34.Name = "materiales";
            treeNode34.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            treeNode34.SelectedImageIndex = 10;
            treeNode34.Text = "Crear Orden Ingreso Materiales";
            treeNode35.Name = "orden_salida_materiales";
            treeNode35.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            treeNode35.SelectedImageIndex = 10;
            treeNode35.Text = "Crear Orden de Salida ";
            treeNode36.Name = "consulta_inventario_materiales";
            treeNode36.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            treeNode36.SelectedImageIndex = 10;
            treeNode36.Text = "Consulta Inventario Materiales";
            treeNode37.Name = "imp_orden_materiales";
            treeNode37.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            treeNode37.Text = "Imprimir Orden de Materiales";
            treeNode38.ImageIndex = 29;
            treeNode38.Name = "opciones_materiales";
            treeNode38.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            treeNode38.Text = "Materiales";
            treeNode39.ImageIndex = 15;
            treeNode39.Name = "Nodo1";
            treeNode39.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            treeNode39.SelectedImageIndex = 10;
            treeNode39.Text = "Inventarios";
            treeNode40.ImageIndex = 17;
            treeNode40.Name = "aplicar_accion";
            treeNode40.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            treeNode40.SelectedImageIndex = 10;
            treeNode40.Text = "Aplicar Estado de Ordenes Salida";
            treeNode41.ImageIndex = 14;
            treeNode41.Name = "Nodo2";
            treeNode41.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            treeNode41.SelectedImageIndex = 10;
            treeNode41.Text = "Opciones Ordenes";
            treeNode42.ImageIndex = 22;
            treeNode42.Name = "estado_ordenes";
            treeNode42.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            treeNode42.SelectedImageIndex = 10;
            treeNode42.Text = "Estado Ordenes en Preparación";
            treeNode43.ImageIndex = 23;
            treeNode43.Name = "verif_equipos";
            treeNode43.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            treeNode43.SelectedImageIndex = 10;
            treeNode43.Text = "Equipos en Ordenes de Trabajo";
            treeNode44.ImageIndex = 16;
            treeNode44.Name = "list_reequi";
            treeNode44.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            treeNode44.SelectedImageIndex = 10;
            treeNode44.Text = "Equipos Asignados a Centro Educativo";
            treeNode45.Name = "t_equipos_instalacion";
            treeNode45.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            treeNode45.SelectedImageIndex = 10;
            treeNode45.Text = "Equipos en Laboratorios";
            treeNode46.ImageIndex = 20;
            treeNode46.Name = "Nodo0";
            treeNode46.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            treeNode46.SelectedImageIndex = 10;
            treeNode46.Text = "Ordenes";
            treeNode47.ImageIndex = 31;
            treeNode47.Name = "revisar_placas";
            treeNode47.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            treeNode47.SelectedImageIndex = 10;
            treeNode47.Text = "Revisar Placas en Ordenes";
            treeNode48.ImageIndex = 21;
            treeNode48.Name = "equipos_danados";
            treeNode48.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            treeNode48.SelectedImageIndex = 10;
            treeNode48.Text = "Ingreso de Equipos Dañados";
            treeNode49.ImageIndex = 18;
            treeNode49.Name = "Nodo0";
            treeNode49.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            treeNode49.SelectedImageIndex = 10;
            treeNode49.Text = "Consultas";
            treeNode50.ImageIndex = 26;
            treeNode50.Name = "prepa_orden_equipos";
            treeNode50.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            treeNode50.SelectedImageIndex = 10;
            treeNode50.Text = "Preparacion de Equipos par CE";
            treeNode51.ImageIndex = 4;
            treeNode51.Name = "registrar_cartel";
            treeNode51.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            treeNode51.SelectedImageIndex = 10;
            treeNode51.Text = "Registrar Cartel";
            treeNode52.Name = "Nodo0";
            treeNode52.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            treeNode52.Text = "Administrativo";
            treeNode53.ImageIndex = 20;
            treeNode53.Name = "rpt_acciones";
            treeNode53.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            treeNode53.SelectedImageIndex = 10;
            treeNode53.Text = "Ordenes Revisadas";
            treeNode54.ImageIndex = 3;
            treeNode54.Name = "rpt_equi_accion";
            treeNode54.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            treeNode54.SelectedImageIndex = 10;
            treeNode54.Text = "General de Equipos";
            treeNode55.ImageIndex = 23;
            treeNode55.Name = "pedidos";
            treeNode55.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            treeNode55.SelectedImageIndex = 10;
            treeNode55.Text = "Pedidos";
            treeNode56.Name = "Nodo0";
            treeNode56.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            treeNode56.Text = "Ordenes";
            treeNode57.ImageIndex = 21;
            treeNode57.Name = "equi_garantia";
            treeNode57.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            treeNode57.SelectedImageKey = "Checked Checkbox_16px_1.png";
            treeNode57.Text = "Equipos en Garantia";
            treeNode58.ImageIndex = 19;
            treeNode58.Name = "Reportes";
            treeNode58.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            treeNode58.SelectedImageIndex = 10;
            treeNode58.Text = "Reportes";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode39,
            treeNode41,
            treeNode49,
            treeNode52,
            treeNode58});
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(258, 537);
            this.treeView1.TabIndex = 3;
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeView1_NodeMouseDoubleClick);
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
            this.imageList1.Images.SetKeyName(26, "icons8_Compose_48px.png");
            this.imageList1.Images.SetKeyName(27, "icons8_New_Product_50px.png");
            this.imageList1.Images.SetKeyName(28, "icons8_Product_50px.png");
            this.imageList1.Images.SetKeyName(29, "icons8_Product_32px.png");
            this.imageList1.Images.SetKeyName(30, "icons8_Check_32px.png");
            this.imageList1.Images.SetKeyName(31, "icons8_Search_Property_32px.png");
            // 
            // panelPrincipal
            // 
            this.panelPrincipal.BackColor = System.Drawing.SystemColors.Control;
            this.panelPrincipal.Controls.Add(this.menuStrip1);
            this.panelPrincipal.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelPrincipal.Location = new System.Drawing.Point(258, 0);
            this.panelPrincipal.Name = "panelPrincipal";
            this.panelPrincipal.Size = new System.Drawing.Size(1056, 23);
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
            this.ToolStripMenuItem,
            this.opciones});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1056, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MenuStrip1_MouseMove);
            // 
            // cerraToolStripMenuItem
            // 
            this.cerraToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cerraToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cerraToolStripMenuItem.Image")));
            this.cerraToolStripMenuItem.Name = "cerraToolStripMenuItem";
            this.cerraToolStripMenuItem.Size = new System.Drawing.Size(32, 20);
            this.cerraToolStripMenuItem.Click += new System.EventHandler(this.CerraToolStripMenuItem_Click);
            // 
            // dffToolStripMenuItem
            // 
            this.dffToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.dffToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("dffToolStripMenuItem.Image")));
            this.dffToolStripMenuItem.Name = "dffToolStripMenuItem";
            this.dffToolStripMenuItem.Size = new System.Drawing.Size(32, 20);
            this.dffToolStripMenuItem.Click += new System.EventHandler(this.DffToolStripMenuItem_Click);
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
            // opciones
            // 
            this.opciones.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.opciones.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarUsuariosToolStripMenuItem});
            this.opciones.Image = ((System.Drawing.Image)(resources.GetObject("opciones.Image")));
            this.opciones.Name = "opciones";
            this.opciones.Size = new System.Drawing.Size(118, 20);
            this.opciones.Text = "Menú Usuarios";
            // 
            // agregarUsuariosToolStripMenuItem
            // 
            this.agregarUsuariosToolStripMenuItem.Name = "agregarUsuariosToolStripMenuItem";
            this.agregarUsuariosToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.agregarUsuariosToolStripMenuItem.Text = "Agregar Usuarios";
            this.agregarUsuariosToolStripMenuItem.Click += new System.EventHandler(this.AgregarUsuariosToolStripMenuItem_Click);
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
            this.statusStrip1.Location = new System.Drawing.Point(258, 652);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.statusStrip1.Size = new System.Drawing.Size(1056, 24);
            this.statusStrip1.TabIndex = 30;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(135, 19);
            this.toolStripStatusLabel3.Text = "Centro de Distribucion";
            this.toolStripStatusLabel3.Click += new System.EventHandler(this.ToolStripStatusLabel3_Click);
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
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(81, 19);
            this.toolStripStatusLabel2.Text = "Fecha";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(258, 23);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1056, 629);
            this.panel2.TabIndex = 31;
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel2_MouseMove);
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 20000;
            this.timer2.Tick += new System.EventHandler(this.Timer2_Tick);
            // 
            // MainMenuForm
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
            this.Name = "MainMenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu Principal";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem opciones;
        private System.Windows.Forms.ToolStripMenuItem agregarUsuariosToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel count_orden;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.ToolStripStatusLabel ordenes_pendientes;
    }
}