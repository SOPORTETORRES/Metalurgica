namespace Metalurgica
{
    partial class frmVbDespachoCamion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVbDespachoCamion));
            this.tlsToolBar = new System.Windows.Forms.ToolStrip();
            this.tlbNuevo = new System.Windows.Forms.ToolStripButton();
            this.tlbGuardar = new System.Windows.Forms.ToolStripButton();
            this.tlbEliminar = new System.Windows.Forms.ToolStripButton();
            this.tlbDesactivar = new System.Windows.Forms.ToolStripButton();
            this.tlbActualizar = new System.Windows.Forms.ToolStripButton();
            this.tlbImprimir = new System.Windows.Forms.ToolStripButton();
            this.tlbExportar = new System.Windows.Forms.ToolStripButton();
            this.tlbSalir = new System.Windows.Forms.ToolStripButton();
            this.stsStatusStrip = new System.Windows.Forms.StatusStrip();
            this.tlsEstado = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.txtObsVb = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblObraDestino = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblPatente = new System.Windows.Forms.Label();
            this.lblTransportista = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtObs = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabOperaciones = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvDespachos = new System.Windows.Forms.DataGridView();
            this.dtpFechaDespacho = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblIdDespacho = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtEtiquetaPieza = new System.Windows.Forms.TextBox();
            this.dgvEtiquetasPiezas = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.lblCantidadEtiquetasPiezas = new System.Windows.Forms.Label();
            this.lblCantidadEtiquetasColadas = new System.Windows.Forms.Label();
            this.ctlInformacionUsuario1 = new Metalurgica.ctlInformacionUsuario();
            this.tlsToolBar.SuspendLayout();
            this.stsStatusStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabOperaciones.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDespachos)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEtiquetasPiezas)).BeginInit();
            this.SuspendLayout();
            // 
            // tlsToolBar
            // 
            this.tlsToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlbNuevo,
            this.tlbGuardar,
            this.tlbEliminar,
            this.tlbDesactivar,
            this.tlbActualizar,
            this.tlbImprimir,
            this.tlbExportar,
            this.tlbSalir});
            this.tlsToolBar.Location = new System.Drawing.Point(0, 36);
            this.tlsToolBar.Name = "tlsToolBar";
            this.tlsToolBar.Size = new System.Drawing.Size(758, 25);
            this.tlsToolBar.TabIndex = 24;
            this.tlsToolBar.Text = "toolStrip1";
            // 
            // tlbNuevo
            // 
            this.tlbNuevo.Image = global::Metalurgica.Properties.Resources.add;
            this.tlbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlbNuevo.Name = "tlbNuevo";
            this.tlbNuevo.Size = new System.Drawing.Size(62, 22);
            this.tlbNuevo.Text = "Nuevo";
            this.tlbNuevo.Visible = false;
            this.tlbNuevo.Click += new System.EventHandler(this.tlbNuevo_Click);
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
            // tlbEliminar
            // 
            this.tlbEliminar.Enabled = false;
            this.tlbEliminar.Image = global::Metalurgica.Properties.Resources.delete;
            this.tlbEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlbEliminar.Name = "tlbEliminar";
            this.tlbEliminar.Size = new System.Drawing.Size(70, 22);
            this.tlbEliminar.Text = "Eliminar";
            this.tlbEliminar.Visible = false;
            this.tlbEliminar.Click += new System.EventHandler(this.tlbEliminar_Click);
            // 
            // tlbDesactivar
            // 
            this.tlbDesactivar.Image = global::Metalurgica.Properties.Resources.cancel;
            this.tlbDesactivar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlbDesactivar.Name = "tlbDesactivar";
            this.tlbDesactivar.Size = new System.Drawing.Size(62, 22);
            this.tlbDesactivar.Text = "Anular";
            this.tlbDesactivar.Visible = false;
            this.tlbDesactivar.Click += new System.EventHandler(this.tlbDesactivar_Click);
            // 
            // tlbActualizar
            // 
            this.tlbActualizar.Image = global::Metalurgica.Properties.Resources.update;
            this.tlbActualizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlbActualizar.Name = "tlbActualizar";
            this.tlbActualizar.Size = new System.Drawing.Size(79, 22);
            this.tlbActualizar.Text = "Actualizar";
            this.tlbActualizar.Click += new System.EventHandler(this.tlbActualizar_Click);
            // 
            // tlbImprimir
            // 
            this.tlbImprimir.Image = global::Metalurgica.Properties.Resources.printer;
            this.tlbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlbImprimir.Name = "tlbImprimir";
            this.tlbImprimir.Size = new System.Drawing.Size(73, 22);
            this.tlbImprimir.Text = "Imprimir";
            this.tlbImprimir.Visible = false;
            this.tlbImprimir.Click += new System.EventHandler(this.tlbImprimir_Click);
            // 
            // tlbExportar
            // 
            this.tlbExportar.Image = global::Metalurgica.Properties.Resources.table_excel;
            this.tlbExportar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlbExportar.Name = "tlbExportar";
            this.tlbExportar.Size = new System.Drawing.Size(70, 22);
            this.tlbExportar.Text = "Exportar";
            this.tlbExportar.Click += new System.EventHandler(this.tlbExportar_Click);
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
            // stsStatusStrip
            // 
            this.stsStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlsEstado});
            this.stsStatusStrip.Location = new System.Drawing.Point(0, 495);
            this.stsStatusStrip.Name = "stsStatusStrip";
            this.stsStatusStrip.Size = new System.Drawing.Size(758, 22);
            this.stsStatusStrip.TabIndex = 25;
            this.stsStatusStrip.Text = "statusStrip1";
            // 
            // tlsEstado
            // 
            this.tlsEstado.Name = "tlsEstado";
            this.tlsEstado.Size = new System.Drawing.Size(32, 17);
            this.tlsEstado.Text = "Listo";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtObsVb);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 61);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(758, 257);
            this.panel1.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 211);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Observación Vb:";
            // 
            // txtObsVb
            // 
            this.txtObsVb.Location = new System.Drawing.Point(115, 208);
            this.txtObsVb.MaxLength = 255;
            this.txtObsVb.Multiline = true;
            this.txtObsVb.Name = "txtObsVb";
            this.txtObsVb.Size = new System.Drawing.Size(631, 43);
            this.txtObsVb.TabIndex = 0;
            this.txtObsVb.Leave += new System.EventHandler(this.txtObsVb_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Observación:";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.lblObraDestino);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Controls.Add(this.txtObs);
            this.groupBox3.Location = new System.Drawing.Point(3, 14);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1000, 188);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Datos del Despacho a Camión";
            // 
            // lblObraDestino
            // 
            this.lblObraDestino.AutoSize = true;
            this.lblObraDestino.Location = new System.Drawing.Point(112, 113);
            this.lblObraDestino.Name = "lblObraDestino";
            this.lblObraDestino.Size = new System.Drawing.Size(10, 13);
            this.lblObraDestino.TabIndex = 11;
            this.lblObraDestino.Text = ".";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Obra/Destino:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lblPatente);
            this.groupBox2.Controls.Add(this.lblTransportista);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(9, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(734, 79);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Transportista";
            // 
            // lblPatente
            // 
            this.lblPatente.AutoSize = true;
            this.lblPatente.Location = new System.Drawing.Point(75, 25);
            this.lblPatente.Name = "lblPatente";
            this.lblPatente.Size = new System.Drawing.Size(10, 13);
            this.lblPatente.TabIndex = 11;
            this.lblPatente.Text = ".";
            // 
            // lblTransportista
            // 
            this.lblTransportista.AutoSize = true;
            this.lblTransportista.Location = new System.Drawing.Point(100, 55);
            this.lblTransportista.Name = "lblTransportista";
            this.lblTransportista.Size = new System.Drawing.Size(10, 13);
            this.lblTransportista.TabIndex = 10;
            this.lblTransportista.Text = ".";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Transportista:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Patente:";
            // 
            // txtObs
            // 
            this.txtObs.Location = new System.Drawing.Point(112, 138);
            this.txtObs.MaxLength = 255;
            this.txtObs.Multiline = true;
            this.txtObs.Name = "txtObs";
            this.txtObs.ReadOnly = true;
            this.txtObs.Size = new System.Drawing.Size(631, 43);
            this.txtObs.TabIndex = 10;
            this.txtObs.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabOperaciones);
            this.panel2.Controls.Add(this.lblCantidadEtiquetasPiezas);
            this.panel2.Controls.Add(this.lblCantidadEtiquetasColadas);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 318);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(758, 177);
            this.panel2.TabIndex = 27;
            // 
            // tabOperaciones
            // 
            this.tabOperaciones.Controls.Add(this.tabPage1);
            this.tabOperaciones.Controls.Add(this.tabPage2);
            this.tabOperaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabOperaciones.Location = new System.Drawing.Point(0, 0);
            this.tabOperaciones.Name = "tabOperaciones";
            this.tabOperaciones.SelectedIndex = 0;
            this.tabOperaciones.Size = new System.Drawing.Size(758, 177);
            this.tabOperaciones.TabIndex = 9;
            this.tabOperaciones.SelectedIndexChanged += new System.EventHandler(this.tabOperaciones_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvDespachos);
            this.tabPage1.Controls.Add(this.dtpFechaDespacho);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(750, 151);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Despachos";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvDespachos
            // 
            this.dgvDespachos.AllowUserToAddRows = false;
            this.dgvDespachos.AllowUserToDeleteRows = false;
            this.dgvDespachos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDespachos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDespachos.Location = new System.Drawing.Point(6, 32);
            this.dgvDespachos.MultiSelect = false;
            this.dgvDespachos.Name = "dgvDespachos";
            this.dgvDespachos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDespachos.Size = new System.Drawing.Size(738, 113);
            this.dgvDespachos.TabIndex = 1;
            this.dgvDespachos.SelectionChanged += new System.EventHandler(this.dgvDespachos_SelectionChanged);
            this.dgvDespachos.DoubleClick += new System.EventHandler(this.dgvDespachos_DoubleClick);
            // 
            // dtpFechaDespacho
            // 
            this.dtpFechaDespacho.Location = new System.Drawing.Point(130, 6);
            this.dtpFechaDespacho.Name = "dtpFechaDespacho";
            this.dtpFechaDespacho.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaDespacho.TabIndex = 0;
            this.dtpFechaDespacho.ValueChanged += new System.EventHandler(this.dtpFechaDespacho_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(10, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Despachos del día";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lblIdDespacho);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.txtEtiquetaPieza);
            this.tabPage2.Controls.Add(this.dgvEtiquetasPiezas);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(750, 151);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Piezas";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblIdDespacho
            // 
            this.lblIdDespacho.AutoSize = true;
            this.lblIdDespacho.Location = new System.Drawing.Point(433, 12);
            this.lblIdDespacho.Name = "lblIdDespacho";
            this.lblIdDespacho.Size = new System.Drawing.Size(10, 13);
            this.lblIdDespacho.TabIndex = 13;
            this.lblIdDespacho.Text = ".";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(356, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Id Despacho:";
            // 
            // txtEtiquetaPieza
            // 
            this.txtEtiquetaPieza.Location = new System.Drawing.Point(130, 6);
            this.txtEtiquetaPieza.MaxLength = 50;
            this.txtEtiquetaPieza.Name = "txtEtiquetaPieza";
            this.txtEtiquetaPieza.Size = new System.Drawing.Size(169, 20);
            this.txtEtiquetaPieza.TabIndex = 4;
            this.txtEtiquetaPieza.Leave += new System.EventHandler(this.txtEtiquetaPieza_Leave);
            this.txtEtiquetaPieza.Validating += new System.ComponentModel.CancelEventHandler(this.txtEtiquetaPieza_Validating);
            // 
            // dgvEtiquetasPiezas
            // 
            this.dgvEtiquetasPiezas.AllowUserToAddRows = false;
            this.dgvEtiquetasPiezas.AllowUserToDeleteRows = false;
            this.dgvEtiquetasPiezas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEtiquetasPiezas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEtiquetasPiezas.Location = new System.Drawing.Point(6, 32);
            this.dgvEtiquetasPiezas.MultiSelect = false;
            this.dgvEtiquetasPiezas.Name = "dgvEtiquetasPiezas";
            this.dgvEtiquetasPiezas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEtiquetasPiezas.Size = new System.Drawing.Size(738, 113);
            this.dgvEtiquetasPiezas.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(10, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Etiqueta Pieza:";
            // 
            // lblCantidadEtiquetasPiezas
            // 
            this.lblCantidadEtiquetasPiezas.AutoSize = true;
            this.lblCantidadEtiquetasPiezas.Location = new System.Drawing.Point(14, 243);
            this.lblCantidadEtiquetasPiezas.Name = "lblCantidadEtiquetasPiezas";
            this.lblCantidadEtiquetasPiezas.Size = new System.Drawing.Size(69, 13);
            this.lblCantidadEtiquetasPiezas.TabIndex = 5;
            this.lblCantidadEtiquetasPiezas.Text = "Registro(s): 0";
            // 
            // lblCantidadEtiquetasColadas
            // 
            this.lblCantidadEtiquetasColadas.AutoSize = true;
            this.lblCantidadEtiquetasColadas.Location = new System.Drawing.Point(14, 323);
            this.lblCantidadEtiquetasColadas.Name = "lblCantidadEtiquetasColadas";
            this.lblCantidadEtiquetasColadas.Size = new System.Drawing.Size(69, 13);
            this.lblCantidadEtiquetasColadas.TabIndex = 4;
            this.lblCantidadEtiquetasColadas.Text = "Registro(s): 0";
            // 
            // ctlInformacionUsuario1
            // 
            this.ctlInformacionUsuario1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctlInformacionUsuario1.Location = new System.Drawing.Point(0, 0);
            this.ctlInformacionUsuario1.Name = "ctlInformacionUsuario1";
            this.ctlInformacionUsuario1.Size = new System.Drawing.Size(758, 36);
            this.ctlInformacionUsuario1.TabIndex = 23;
            // 
            // frmVbDespachoCamion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 517);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.stsStatusStrip);
            this.Controls.Add(this.tlsToolBar);
            this.Controls.Add(this.ctlInformacionUsuario1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmVbDespachoCamion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vb Despacho a Camión";
            this.Load += new System.EventHandler(this.frmVbDespachoCamion_Load);
            this.Shown += new System.EventHandler(this.frmVbDespachoCamion_Shown);
            this.tlsToolBar.ResumeLayout(false);
            this.tlsToolBar.PerformLayout();
            this.stsStatusStrip.ResumeLayout(false);
            this.stsStatusStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabOperaciones.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDespachos)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEtiquetasPiezas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tlsToolBar;
        private System.Windows.Forms.ToolStripButton tlbNuevo;
        private System.Windows.Forms.ToolStripButton tlbGuardar;
        private System.Windows.Forms.ToolStripButton tlbEliminar;
        private System.Windows.Forms.ToolStripButton tlbDesactivar;
        private System.Windows.Forms.ToolStripButton tlbActualizar;
        private System.Windows.Forms.ToolStripButton tlbImprimir;
        private System.Windows.Forms.ToolStripButton tlbExportar;
        private System.Windows.Forms.ToolStripButton tlbSalir;
        private ctlInformacionUsuario ctlInformacionUsuario1;
        private System.Windows.Forms.StatusStrip stsStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel tlsEstado;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblCantidadEtiquetasColadas;
        private System.Windows.Forms.Label lblCantidadEtiquetasPiezas;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblTransportista;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpFechaDespacho;
        private System.Windows.Forms.DataGridView dgvDespachos;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblObraDestino;
        private System.Windows.Forms.Label lblPatente;
        private System.Windows.Forms.TextBox txtObs;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtObsVb;
        private System.Windows.Forms.TabControl tabOperaciones;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtEtiquetaPieza;
        private System.Windows.Forms.DataGridView dgvEtiquetasPiezas;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblIdDespacho;
        private System.Windows.Forms.Label label7;
    }
}