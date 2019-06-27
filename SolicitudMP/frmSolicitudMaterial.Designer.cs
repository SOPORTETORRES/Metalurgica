namespace Metalurgica
{
    partial class frmSolicitudMaterial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSolicitudMaterial));
            this.tlsToolBar = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tlbGuardar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.tlbNuevo = new System.Windows.Forms.ToolStripButton();
            this.tlbEliminar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tlbSalir = new System.Windows.Forms.ToolStripButton();
            this.tabOperaciones = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pnlResultados = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.pnlControles = new System.Windows.Forms.Panel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.Chk_Recuperado = new System.Windows.Forms.CheckBox();
            this.Tx_Kilos = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblLargo = new System.Windows.Forms.Label();
            this.lblProducto = new System.Windows.Forms.Label();
            this.cboDiametro = new System.Windows.Forms.ComboBox();
            this.numUpdCantidad = new System.Windows.Forms.NumericUpDown();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.cboOrigen = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnHlpProducto = new System.Windows.Forms.Button();
            this.txtProducto = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.Pnl_Msg = new System.Windows.Forms.Panel();
            this.PB_1 = new System.Windows.Forms.ProgressBar();
            this.Lbl_MsgCierre = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.stsStatusStrip = new System.Windows.Forms.StatusStrip();
            this.tlsEstado = new System.Windows.Forms.ToolStripStatusLabel();
            this.ctlInformacionUsuario1 = new Metalurgica.ctlInformacionUsuario();
            this.tlsToolBar.SuspendLayout();
            this.tabOperaciones.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.pnlResultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.pnlControles.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpdCantidad)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.Pnl_Msg.SuspendLayout();
            this.stsStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlsToolBar
            // 
            this.tlsToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.tlbGuardar,
            this.toolStripSeparator2,
            this.toolStripLabel2,
            this.tlbNuevo,
            this.tlbEliminar,
            this.toolStripSeparator1,
            this.tlbSalir});
            this.tlsToolBar.Location = new System.Drawing.Point(0, 22);
            this.tlsToolBar.Name = "tlsToolBar";
            this.tlsToolBar.Size = new System.Drawing.Size(920, 25);
            this.tlsToolBar.TabIndex = 24;
            this.tlsToolBar.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(56, 22);
            this.toolStripLabel1.Text = "Solicitud:";
            // 
            // tlbGuardar
            // 
            this.tlbGuardar.Image = global::Metalurgica.Properties.Resources.disk;
            this.tlbGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlbGuardar.Name = "tlbGuardar";
            this.tlbGuardar.Size = new System.Drawing.Size(69, 22);
            this.tlbGuardar.Text = "Guardar";
            this.tlbGuardar.Click += new System.EventHandler(this.tlbGuardar_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(59, 22);
            this.toolStripLabel2.Text = "Producto:";
            // 
            // tlbNuevo
            // 
            this.tlbNuevo.Image = global::Metalurgica.Properties.Resources.add;
            this.tlbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlbNuevo.Name = "tlbNuevo";
            this.tlbNuevo.Size = new System.Drawing.Size(62, 22);
            this.tlbNuevo.Text = "Nuevo";
            this.tlbNuevo.Click += new System.EventHandler(this.tlbNuevo_Click);
            // 
            // tlbEliminar
            // 
            this.tlbEliminar.Image = global::Metalurgica.Properties.Resources.delete;
            this.tlbEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlbEliminar.Name = "tlbEliminar";
            this.tlbEliminar.Size = new System.Drawing.Size(70, 22);
            this.tlbEliminar.Text = "Eliminar";
            this.tlbEliminar.Click += new System.EventHandler(this.tlbEliminar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tlbSalir
            // 
            this.tlbSalir.Image = global::Metalurgica.Properties.Resources.door_out;
            this.tlbSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlbSalir.Name = "tlbSalir";
            this.tlbSalir.Size = new System.Drawing.Size(49, 22);
            this.tlbSalir.Text = "Salir";
            this.tlbSalir.Click += new System.EventHandler(this.tlbSalir_Click);
            // 
            // tabOperaciones
            // 
            this.tabOperaciones.Controls.Add(this.tabPage1);
            this.tabOperaciones.Controls.Add(this.tabPage2);
            this.tabOperaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabOperaciones.Location = new System.Drawing.Point(0, 47);
            this.tabOperaciones.Name = "tabOperaciones";
            this.tabOperaciones.SelectedIndex = 0;
            this.tabOperaciones.Size = new System.Drawing.Size(920, 396);
            this.tabOperaciones.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pnlResultados);
            this.tabPage1.Controls.Add(this.pnlControles);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(912, 370);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Datos del Producto";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pnlResultados
            // 
            this.pnlResultados.Controls.Add(this.label8);
            this.pnlResultados.Controls.Add(this.dgvProductos);
            this.pnlResultados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlResultados.Location = new System.Drawing.Point(3, 91);
            this.pnlResultados.Name = "pnlResultados";
            this.pnlResultados.Size = new System.Drawing.Size(906, 276);
            this.pnlResultados.TabIndex = 24;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(8, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Productos:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.AllowUserToDeleteRows = false;
            this.dgvProductos.AllowUserToResizeRows = false;
            this.dgvProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Location = new System.Drawing.Point(11, 35);
            this.dgvProductos.MultiSelect = false;
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.Size = new System.Drawing.Size(883, 228);
            this.dgvProductos.TabIndex = 0;
            this.dgvProductos.DoubleClick += new System.EventHandler(this.dgvProductos_DoubleClick);
            // 
            // pnlControles
            // 
            this.pnlControles.Controls.Add(this.groupBox5);
            this.pnlControles.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlControles.Location = new System.Drawing.Point(3, 3);
            this.pnlControles.Name = "pnlControles";
            this.pnlControles.Size = new System.Drawing.Size(906, 88);
            this.pnlControles.TabIndex = 23;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.Chk_Recuperado);
            this.groupBox5.Controls.Add(this.Tx_Kilos);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.lblLargo);
            this.groupBox5.Controls.Add(this.lblProducto);
            this.groupBox5.Controls.Add(this.cboDiametro);
            this.groupBox5.Controls.Add(this.numUpdCantidad);
            this.groupBox5.Controls.Add(this.cboTipo);
            this.groupBox5.Controls.Add(this.cboOrigen);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.btnHlpProducto);
            this.groupBox5.Controls.Add(this.txtProducto);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Location = new System.Drawing.Point(5, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(883, 72);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            // 
            // Chk_Recuperado
            // 
            this.Chk_Recuperado.AutoSize = true;
            this.Chk_Recuperado.Location = new System.Drawing.Point(668, 18);
            this.Chk_Recuperado.Name = "Chk_Recuperado";
            this.Chk_Recuperado.Size = new System.Drawing.Size(103, 17);
            this.Chk_Recuperado.TabIndex = 21;
            this.Chk_Recuperado.Text = "Es  Recuperado";
            this.Chk_Recuperado.UseVisualStyleBackColor = true;
            // 
            // Tx_Kilos
            // 
            this.Tx_Kilos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Tx_Kilos.Enabled = false;
            this.Tx_Kilos.Location = new System.Drawing.Point(790, 47);
            this.Tx_Kilos.MaxLength = 50;
            this.Tx_Kilos.Name = "Tx_Kilos";
            this.Tx_Kilos.Size = new System.Drawing.Size(66, 20);
            this.Tx_Kilos.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(750, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Kilos:";
            // 
            // lblLargo
            // 
            this.lblLargo.AutoSize = true;
            this.lblLargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLargo.Location = new System.Drawing.Point(190, 50);
            this.lblLargo.Name = "lblLargo";
            this.lblLargo.Size = new System.Drawing.Size(14, 13);
            this.lblLargo.TabIndex = 18;
            this.lblLargo.Text = "0";
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Location = new System.Drawing.Point(228, 23);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(10, 13);
            this.lblProducto.TabIndex = 17;
            this.lblProducto.Text = ".";
            // 
            // cboDiametro
            // 
            this.cboDiametro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDiametro.FormattingEnabled = true;
            this.cboDiametro.Items.AddRange(new object[] {
            "GERDAU",
            "CAP"});
            this.cboDiametro.Location = new System.Drawing.Point(80, 48);
            this.cboDiametro.Name = "cboDiametro";
            this.cboDiametro.Size = new System.Drawing.Size(45, 21);
            this.cboDiametro.TabIndex = 2;
            // 
            // numUpdCantidad
            // 
            this.numUpdCantidad.Location = new System.Drawing.Point(663, 48);
            this.numUpdCantidad.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.numUpdCantidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpdCantidad.Name = "numUpdCantidad";
            this.numUpdCantidad.Size = new System.Drawing.Size(61, 20);
            this.numUpdCantidad.TabIndex = 5;
            this.numUpdCantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpdCantidad.ValueChanged += new System.EventHandler(this.numUpdCantidad_ValueChanged);
            this.numUpdCantidad.Leave += new System.EventHandler(this.numUpdCantidad_Leave);
            // 
            // cboTipo
            // 
            this.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Location = new System.Drawing.Point(481, 48);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(118, 21);
            this.cboTipo.TabIndex = 4;
            // 
            // cboOrigen
            // 
            this.cboOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOrigen.FormattingEnabled = true;
            this.cboOrigen.Items.AddRange(new object[] {
            "GERDAU",
            "CAP"});
            this.cboOrigen.Location = new System.Drawing.Point(278, 48);
            this.cboOrigen.Name = "cboOrigen";
            this.cboOrigen.Size = new System.Drawing.Size(160, 21);
            this.cboOrigen.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(444, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Tipo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(231, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Origen:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Producto:";
            // 
            // btnHlpProducto
            // 
            this.btnHlpProducto.Image = ((System.Drawing.Image)(resources.GetObject("btnHlpProducto.Image")));
            this.btnHlpProducto.Location = new System.Drawing.Point(186, 16);
            this.btnHlpProducto.Name = "btnHlpProducto";
            this.btnHlpProducto.Size = new System.Drawing.Size(29, 24);
            this.btnHlpProducto.TabIndex = 1;
            this.btnHlpProducto.UseVisualStyleBackColor = true;
            this.btnHlpProducto.Click += new System.EventHandler(this.btnHlpProducto_Click);
            // 
            // txtProducto
            // 
            this.txtProducto.Location = new System.Drawing.Point(80, 19);
            this.txtProducto.MaxLength = 50;
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.Size = new System.Drawing.Size(100, 20);
            this.txtProducto.TabIndex = 0;
            this.txtProducto.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtProducto_KeyUp);
            this.txtProducto.Validating += new System.ComponentModel.CancelEventHandler(this.txtProducto_Validating);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(605, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Cantidad:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(143, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Largo:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Diametro:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.Pnl_Msg);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(912, 370);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Observaciones";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Pnl_Msg
            // 
            this.Pnl_Msg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.Pnl_Msg.Controls.Add(this.PB_1);
            this.Pnl_Msg.Controls.Add(this.Lbl_MsgCierre);
            this.Pnl_Msg.Controls.Add(this.label9);
            this.Pnl_Msg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Pnl_Msg.Location = new System.Drawing.Point(0, 0);
            this.Pnl_Msg.Name = "Pnl_Msg";
            this.Pnl_Msg.Size = new System.Drawing.Size(912, 370);
            this.Pnl_Msg.TabIndex = 4;
            this.Pnl_Msg.Visible = false;
            // 
            // PB_1
            // 
            this.PB_1.Location = new System.Drawing.Point(101, 302);
            this.PB_1.Name = "PB_1";
            this.PB_1.Size = new System.Drawing.Size(702, 23);
            this.PB_1.TabIndex = 2;
            // 
            // Lbl_MsgCierre
            // 
            this.Lbl_MsgCierre.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Lbl_MsgCierre.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_MsgCierre.ForeColor = System.Drawing.Color.Navy;
            this.Lbl_MsgCierre.Location = new System.Drawing.Point(17, 156);
            this.Lbl_MsgCierre.Name = "Lbl_MsgCierre";
            this.Lbl_MsgCierre.Size = new System.Drawing.Size(874, 110);
            this.Lbl_MsgCierre.TabIndex = 1;
            this.Lbl_MsgCierre.Text = "Se esta realizando un cierre Automatico, espere hasta que termine el Proceso.";
            this.Lbl_MsgCierre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(17, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(874, 79);
            this.label9.TabIndex = 0;
            this.label9.Text = "Se ha detectado que el turno anterior no se ha cerrado, el sistema realizara un c" +
    "ierre automático";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // stsStatusStrip
            // 
            this.stsStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlsEstado});
            this.stsStatusStrip.Location = new System.Drawing.Point(0, 443);
            this.stsStatusStrip.Name = "stsStatusStrip";
            this.stsStatusStrip.Size = new System.Drawing.Size(920, 22);
            this.stsStatusStrip.TabIndex = 26;
            this.stsStatusStrip.Text = "statusStrip1";
            // 
            // tlsEstado
            // 
            this.tlsEstado.Name = "tlsEstado";
            this.tlsEstado.Size = new System.Drawing.Size(32, 17);
            this.tlsEstado.Text = "Listo";
            // 
            // ctlInformacionUsuario1
            // 
            this.ctlInformacionUsuario1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctlInformacionUsuario1.Location = new System.Drawing.Point(0, 0);
            this.ctlInformacionUsuario1.Name = "ctlInformacionUsuario1";
            this.ctlInformacionUsuario1.Size = new System.Drawing.Size(920, 22);
            this.ctlInformacionUsuario1.TabIndex = 23;
            // 
            // frmSolicitudMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 465);
            this.Controls.Add(this.tabOperaciones);
            this.Controls.Add(this.stsStatusStrip);
            this.Controls.Add(this.tlsToolBar);
            this.Controls.Add(this.ctlInformacionUsuario1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSolicitudMaterial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Solicitud Material";
            this.Activated += new System.EventHandler(this.frmSolicitudMaterial_Activated);
            this.Load += new System.EventHandler(this.frmSolicitudMaterial_Load);
            this.Shown += new System.EventHandler(this.frmSolicitudMaterial_Shown);
            this.tlsToolBar.ResumeLayout(false);
            this.tlsToolBar.PerformLayout();
            this.tabOperaciones.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.pnlResultados.ResumeLayout(false);
            this.pnlResultados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.pnlControles.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpdCantidad)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.Pnl_Msg.ResumeLayout(false);
            this.stsStatusStrip.ResumeLayout(false);
            this.stsStatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tlsToolBar;
        private System.Windows.Forms.ToolStripButton tlbNuevo;
        private System.Windows.Forms.ToolStripButton tlbGuardar;
        private System.Windows.Forms.ToolStripButton tlbEliminar;
        private System.Windows.Forms.ToolStripButton tlbSalir;
        private ctlInformacionUsuario ctlInformacionUsuario1;
        private System.Windows.Forms.TabControl tabOperaciones;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel pnlResultados;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel pnlControles;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnHlpProducto;
        private System.Windows.Forms.TextBox txtProducto;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.StatusStrip stsStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel tlsEstado;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ComboBox cboTipo;
        private System.Windows.Forms.ComboBox cboOrigen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numUpdCantidad;
        private System.Windows.Forms.ComboBox cboDiametro;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.Label lblLargo;
        private System.Windows.Forms.TextBox Tx_Kilos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox Chk_Recuperado;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel Pnl_Msg;
        private System.Windows.Forms.Label Lbl_MsgCierre;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ProgressBar PB_1;
    }
}