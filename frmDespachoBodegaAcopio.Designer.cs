namespace Metalurgica
{
    partial class frmDespachoBodegaAcopio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDespachoBodegaAcopio));
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtObs = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnHlpBodega = new System.Windows.Forms.Button();
            this.txtBodegaAcopio = new System.Windows.Forms.TextBox();
            this.btnCrudBodega = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvEtiquetasPiezas = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblCantidadEtiquetasPiezas = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.lblPiezasPendientesDespacho = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEtiquetaPieza = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lblCantidadEtiquetasColadas = new System.Windows.Forms.Label();
            this.tabOperaciones = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvDespachosBodegaAcopio = new System.Windows.Forms.DataGridView();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblCantidadDespachosBodegaAcopio = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblBodegaAcopio = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.ctlInformacionUsuario1 = new Metalurgica.ctlInformacionUsuario();
            this.tlsToolBar.SuspendLayout();
            this.stsStatusStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEtiquetasPiezas)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabOperaciones.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDespachosBodegaAcopio)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
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
            this.tlbActualizar.Visible = false;
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
            this.stsStatusStrip.Location = new System.Drawing.Point(0, 502);
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
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(744, 129);
            this.panel1.TabIndex = 26;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Location = new System.Drawing.Point(5, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(986, 119);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Datos del Despacho a Bodega Acopio";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.txtObs);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.btnHlpBodega);
            this.groupBox4.Controls.Add(this.txtBodegaAcopio);
            this.groupBox4.Controls.Add(this.btnCrudBodega);
            this.groupBox4.Location = new System.Drawing.Point(8, 19);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(969, 94);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Bodega";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Observación:";
            // 
            // txtObs
            // 
            this.txtObs.Location = new System.Drawing.Point(101, 45);
            this.txtObs.MaxLength = 255;
            this.txtObs.Multiline = true;
            this.txtObs.Name = "txtObs";
            this.txtObs.Size = new System.Drawing.Size(694, 43);
            this.txtObs.TabIndex = 3;
            this.txtObs.Leave += new System.EventHandler(this.txtObs_Leave);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(25, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Bodega:";
            // 
            // btnHlpBodega
            // 
            this.btnHlpBodega.Image = ((System.Drawing.Image)(resources.GetObject("btnHlpBodega.Image")));
            this.btnHlpBodega.Location = new System.Drawing.Point(207, 16);
            this.btnHlpBodega.Name = "btnHlpBodega";
            this.btnHlpBodega.Size = new System.Drawing.Size(29, 24);
            this.btnHlpBodega.TabIndex = 1;
            this.btnHlpBodega.UseVisualStyleBackColor = true;
            this.btnHlpBodega.Click += new System.EventHandler(this.btnHlpBodega_Click);
            // 
            // txtBodegaAcopio
            // 
            this.txtBodegaAcopio.Location = new System.Drawing.Point(101, 19);
            this.txtBodegaAcopio.MaxLength = 5;
            this.txtBodegaAcopio.Name = "txtBodegaAcopio";
            this.txtBodegaAcopio.Size = new System.Drawing.Size(100, 20);
            this.txtBodegaAcopio.TabIndex = 0;
            this.txtBodegaAcopio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBodegaAcopio_KeyPress);
            this.txtBodegaAcopio.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBodegaAcopio_KeyUp);
            this.txtBodegaAcopio.Leave += new System.EventHandler(this.txtBodegaAcopio_Leave);
            this.txtBodegaAcopio.Validating += new System.ComponentModel.CancelEventHandler(this.txtBodegaAcopio_Validating);
            // 
            // btnCrudBodega
            // 
            this.btnCrudBodega.Image = global::Metalurgica.Properties.Resources.application_add;
            this.btnCrudBodega.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCrudBodega.Location = new System.Drawing.Point(242, 17);
            this.btnCrudBodega.Name = "btnCrudBodega";
            this.btnCrudBodega.Size = new System.Drawing.Size(153, 23);
            this.btnCrudBodega.TabIndex = 2;
            this.btnCrudBodega.Text = "Crear nueva bodega...";
            this.btnCrudBodega.UseVisualStyleBackColor = true;
            this.btnCrudBodega.Click += new System.EventHandler(this.btnCrudBodega_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvEtiquetasPiezas);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.lblCantidadEtiquetasColadas);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 132);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(744, 280);
            this.panel2.TabIndex = 27;
            // 
            // dgvEtiquetasPiezas
            // 
            this.dgvEtiquetasPiezas.AllowUserToAddRows = false;
            this.dgvEtiquetasPiezas.AllowUserToDeleteRows = false;
            this.dgvEtiquetasPiezas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEtiquetasPiezas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEtiquetasPiezas.Location = new System.Drawing.Point(0, 30);
            this.dgvEtiquetasPiezas.MultiSelect = false;
            this.dgvEtiquetasPiezas.Name = "dgvEtiquetasPiezas";
            this.dgvEtiquetasPiezas.ReadOnly = true;
            this.dgvEtiquetasPiezas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEtiquetasPiezas.Size = new System.Drawing.Size(744, 220);
            this.dgvEtiquetasPiezas.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lblCantidadEtiquetasPiezas);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 250);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(744, 30);
            this.panel4.TabIndex = 7;
            // 
            // lblCantidadEtiquetasPiezas
            // 
            this.lblCantidadEtiquetasPiezas.AutoSize = true;
            this.lblCantidadEtiquetasPiezas.Location = new System.Drawing.Point(3, 4);
            this.lblCantidadEtiquetasPiezas.Name = "lblCantidadEtiquetasPiezas";
            this.lblCantidadEtiquetasPiezas.Size = new System.Drawing.Size(69, 13);
            this.lblCantidadEtiquetasPiezas.TabIndex = 5;
            this.lblCantidadEtiquetasPiezas.Text = "Registro(s): 0";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnActualizar);
            this.panel3.Controls.Add(this.lblPiezasPendientesDespacho);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.txtEtiquetaPieza);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(744, 30);
            this.panel3.TabIndex = 6;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Image = global::Metalurgica.Properties.Resources.update;
            this.btnActualizar.Location = new System.Drawing.Point(658, 0);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(28, 23);
            this.btnActualizar.TabIndex = 5;
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // lblPiezasPendientesDespacho
            // 
            this.lblPiezasPendientesDespacho.AutoSize = true;
            this.lblPiezasPendientesDespacho.Location = new System.Drawing.Point(604, 6);
            this.lblPiezasPendientesDespacho.Name = "lblPiezasPendientesDespacho";
            this.lblPiezasPendientesDespacho.Size = new System.Drawing.Size(13, 13);
            this.lblPiezasPendientesDespacho.TabIndex = 4;
            this.lblPiezasPendientesDespacho.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(378, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nº Etiquetas Pendientes de despacho:";
            // 
            // txtEtiquetaPieza
            // 
            this.txtEtiquetaPieza.Location = new System.Drawing.Point(111, 3);
            this.txtEtiquetaPieza.MaxLength = 50;
            this.txtEtiquetaPieza.Name = "txtEtiquetaPieza";
            this.txtEtiquetaPieza.Size = new System.Drawing.Size(169, 20);
            this.txtEtiquetaPieza.TabIndex = 0;
            this.txtEtiquetaPieza.Leave += new System.EventHandler(this.txtEtiquetaPieza_Leave);
            this.txtEtiquetaPieza.Validating += new System.ComponentModel.CancelEventHandler(this.txtEtiquetaPieza_Validating);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(7, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Etiqueta Pieza:";
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
            // tabOperaciones
            // 
            this.tabOperaciones.Controls.Add(this.tabPage1);
            this.tabOperaciones.Controls.Add(this.tabPage2);
            this.tabOperaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabOperaciones.Location = new System.Drawing.Point(0, 61);
            this.tabOperaciones.Name = "tabOperaciones";
            this.tabOperaciones.SelectedIndex = 0;
            this.tabOperaciones.Size = new System.Drawing.Size(758, 441);
            this.tabOperaciones.TabIndex = 3;
            this.tabOperaciones.SelectedIndexChanged += new System.EventHandler(this.tabOperaciones_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(750, 415);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Despacho a Bodega Productos Terminados";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvDespachosBodegaAcopio);
            this.tabPage2.Controls.Add(this.panel6);
            this.tabPage2.Controls.Add(this.panel5);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(750, 415);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Información de Despachos a Bodega  Productos Terminados";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvDespachosBodegaAcopio
            // 
            this.dgvDespachosBodegaAcopio.AllowUserToAddRows = false;
            this.dgvDespachosBodegaAcopio.AllowUserToDeleteRows = false;
            this.dgvDespachosBodegaAcopio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDespachosBodegaAcopio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDespachosBodegaAcopio.Location = new System.Drawing.Point(3, 40);
            this.dgvDespachosBodegaAcopio.MultiSelect = false;
            this.dgvDespachosBodegaAcopio.Name = "dgvDespachosBodegaAcopio";
            this.dgvDespachosBodegaAcopio.ReadOnly = true;
            this.dgvDespachosBodegaAcopio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDespachosBodegaAcopio.Size = new System.Drawing.Size(744, 342);
            this.dgvDespachosBodegaAcopio.TabIndex = 7;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.lblCantidadDespachosBodegaAcopio);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(3, 382);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(744, 30);
            this.panel6.TabIndex = 9;
            // 
            // lblCantidadDespachosBodegaAcopio
            // 
            this.lblCantidadDespachosBodegaAcopio.AutoSize = true;
            this.lblCantidadDespachosBodegaAcopio.Location = new System.Drawing.Point(3, 4);
            this.lblCantidadDespachosBodegaAcopio.Name = "lblCantidadDespachosBodegaAcopio";
            this.lblCantidadDespachosBodegaAcopio.Size = new System.Drawing.Size(69, 13);
            this.lblCantidadDespachosBodegaAcopio.TabIndex = 4;
            this.lblCantidadDespachosBodegaAcopio.Text = "Registro(s): 0";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lblBodegaAcopio);
            this.panel5.Controls.Add(this.label10);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(3, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(744, 37);
            this.panel5.TabIndex = 8;
            // 
            // lblBodegaAcopio
            // 
            this.lblBodegaAcopio.AutoSize = true;
            this.lblBodegaAcopio.Location = new System.Drawing.Point(65, 11);
            this.lblBodegaAcopio.Name = "lblBodegaAcopio";
            this.lblBodegaAcopio.Size = new System.Drawing.Size(10, 13);
            this.lblBodegaAcopio.TabIndex = 2;
            this.lblBodegaAcopio.Text = ".";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 11);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Bodega:";
            // 
            // ctlInformacionUsuario1
            // 
            this.ctlInformacionUsuario1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctlInformacionUsuario1.Location = new System.Drawing.Point(0, 0);
            this.ctlInformacionUsuario1.Name = "ctlInformacionUsuario1";
            this.ctlInformacionUsuario1.Size = new System.Drawing.Size(758, 36);
            this.ctlInformacionUsuario1.TabIndex = 23;
            // 
            // frmDespachoBodegaAcopio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 524);
            this.Controls.Add(this.tabOperaciones);
            this.Controls.Add(this.stsStatusStrip);
            this.Controls.Add(this.tlsToolBar);
            this.Controls.Add(this.ctlInformacionUsuario1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmDespachoBodegaAcopio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Despacho a Bodega  Productos Terminados";
            this.Shown += new System.EventHandler(this.frmDespachoBodegaAcopio_Shown);
            this.tlsToolBar.ResumeLayout(false);
            this.tlsToolBar.PerformLayout();
            this.stsStatusStrip.ResumeLayout(false);
            this.stsStatusStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEtiquetasPiezas)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tabOperaciones.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDespachosBodegaAcopio)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtObs;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnHlpBodega;
        private System.Windows.Forms.TextBox txtBodegaAcopio;
        private System.Windows.Forms.Button btnCrudBodega;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblCantidadEtiquetasColadas;
        private System.Windows.Forms.TextBox txtEtiquetaPieza;
        private System.Windows.Forms.DataGridView dgvEtiquetasPiezas;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblCantidadEtiquetasPiezas;
        private System.Windows.Forms.TabControl tabOperaciones;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dgvDespachosBodegaAcopio;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lblCantidadDespachosBodegaAcopio;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblBodegaAcopio;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblPiezasPendientesDespacho;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnActualizar;
    }
}