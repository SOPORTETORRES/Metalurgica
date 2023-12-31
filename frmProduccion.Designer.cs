﻿namespace Metalurgica
{
    partial class frmProduccion
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProduccion));
            this.stsStatusStrip = new System.Windows.Forms.StatusStrip();
            this.tlsEstado = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlsToolBar = new System.Windows.Forms.ToolStrip();
            this.tlbNuevo = new System.Windows.Forms.ToolStripButton();
            this.tlbGuardar = new System.Windows.Forms.ToolStripButton();
            this.tlbEliminar = new System.Windows.Forms.ToolStripButton();
            this.tlbDesactivar = new System.Windows.Forms.ToolStripButton();
            this.tlbActualizar = new System.Windows.Forms.ToolStripButton();
            this.tlbImprimir = new System.Windows.Forms.ToolStripButton();
            this.tlbExportar = new System.Windows.Forms.ToolStripButton();
            this.tlbSalir = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Btn_MtoTotem = new System.Windows.Forms.Button();
            this.Btn_MtoMaq = new System.Windows.Forms.Button();
            this.Btn_NotificacionAveria = new System.Windows.Forms.Button();
            this.Lbl_NroEtiq = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.Lbl_NroPiezas = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.Lbl_KgsProd = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Lbl_SaldoKilosColada = new System.Windows.Forms.Label();
            this.Btn_VerDetalle = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.lblKilos = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblColada = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblNroCertificado = new System.Windows.Forms.Label();
            this.lblLargo = new System.Windows.Forms.Label();
            this.lblDiametro = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtObs = new System.Windows.Forms.TextBox();
            this.txtEtiquetaColada = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabOperaciones = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblCantidadEtiquetasPiezas = new System.Windows.Forms.Label();
            this.dgvEtiquetasPiezas = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvEtiquetasPiezasExcepciones = new System.Windows.Forms.DataGridView();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblCantidadEtiquetasPiezasExcepciones = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cboExcepciones = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEtiquetaPieza = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.Btn_Desbloquea = new System.Windows.Forms.Button();
            this.Chk_MultiplesColadas = new System.Windows.Forms.CheckBox();
            this.Lbl_MsgKgsProd = new System.Windows.Forms.Label();
            this.lbl_Msg = new System.Windows.Forms.Label();
            this.ctlInformacionUsuario1 = new Metalurgica.ctlInformacionUsuario();
            this.lbl_MsgBloqueo = new System.Windows.Forms.Label();
            this.stsStatusStrip.SuspendLayout();
            this.tlsToolBar.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabOperaciones.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEtiquetasPiezas)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEtiquetasPiezasExcepciones)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // stsStatusStrip
            // 
            this.stsStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlsEstado});
            this.stsStatusStrip.Location = new System.Drawing.Point(0, 481);
            this.stsStatusStrip.Name = "stsStatusStrip";
            this.stsStatusStrip.Size = new System.Drawing.Size(988, 22);
            this.stsStatusStrip.TabIndex = 26;
            this.stsStatusStrip.Text = "statusStrip1";
            // 
            // tlsEstado
            // 
            this.tlsEstado.Name = "tlsEstado";
            this.tlsEstado.Size = new System.Drawing.Size(32, 17);
            this.tlsEstado.Text = "Listo";
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
            this.tlsToolBar.Size = new System.Drawing.Size(988, 25);
            this.tlsToolBar.TabIndex = 37;
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
            this.tlbGuardar.Enabled = false;
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
            this.tlbDesactivar.Enabled = false;
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
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 61);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(988, 141);
            this.panel1.TabIndex = 38;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lbl_MsgBloqueo);
            this.groupBox1.Controls.Add(this.Btn_MtoTotem);
            this.groupBox1.Controls.Add(this.Btn_MtoMaq);
            this.groupBox1.Controls.Add(this.Btn_NotificacionAveria);
            this.groupBox1.Controls.Add(this.Lbl_NroEtiq);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.Lbl_NroPiezas);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.Lbl_KgsProd);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.Lbl_SaldoKilosColada);
            this.groupBox1.Controls.Add(this.Btn_VerDetalle);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.lblKilos);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.lblColada);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.lblNroCertificado);
            this.groupBox1.Controls.Add(this.lblLargo);
            this.groupBox1.Controls.Add(this.lblDiametro);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtObs);
            this.groupBox1.Controls.Add(this.txtEtiquetaColada);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(8, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(968, 129);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Producción";
            // 
            // Btn_MtoTotem
            // 
            this.Btn_MtoTotem.Location = new System.Drawing.Point(808, 44);
            this.Btn_MtoTotem.Name = "Btn_MtoTotem";
            this.Btn_MtoTotem.Size = new System.Drawing.Size(66, 23);
            this.Btn_MtoTotem.TabIndex = 54;
            this.Btn_MtoTotem.Text = "Mto Tótem";
            this.Btn_MtoTotem.UseVisualStyleBackColor = true;
            this.Btn_MtoTotem.Visible = false;
            this.Btn_MtoTotem.Click += new System.EventHandler(this.Btn_MtoTotem_Click);
            // 
            // Btn_MtoMaq
            // 
            this.Btn_MtoMaq.Location = new System.Drawing.Point(748, 44);
            this.Btn_MtoMaq.Name = "Btn_MtoMaq";
            this.Btn_MtoMaq.Size = new System.Drawing.Size(57, 23);
            this.Btn_MtoMaq.TabIndex = 53;
            this.Btn_MtoMaq.Text = "Mto Maq";
            this.Btn_MtoMaq.UseVisualStyleBackColor = true;
            this.Btn_MtoMaq.Visible = false;
            this.Btn_MtoMaq.Click += new System.EventHandler(this.Btn_MtoMaq_Click);
            // 
            // Btn_NotificacionAveria
            // 
            this.Btn_NotificacionAveria.Location = new System.Drawing.Point(788, 69);
            this.Btn_NotificacionAveria.Name = "Btn_NotificacionAveria";
            this.Btn_NotificacionAveria.Size = new System.Drawing.Size(77, 48);
            this.Btn_NotificacionAveria.TabIndex = 52;
            this.Btn_NotificacionAveria.Text = "Notificación de Averia";
            this.Btn_NotificacionAveria.UseVisualStyleBackColor = true;
            this.Btn_NotificacionAveria.Click += new System.EventHandler(this.Btn_NotificacionAveria_Click);
            // 
            // Lbl_NroEtiq
            // 
            this.Lbl_NroEtiq.AutoSize = true;
            this.Lbl_NroEtiq.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_NroEtiq.ForeColor = System.Drawing.Color.Black;
            this.Lbl_NroEtiq.Location = new System.Drawing.Point(699, 24);
            this.Lbl_NroEtiq.Name = "Lbl_NroEtiq";
            this.Lbl_NroEtiq.Size = new System.Drawing.Size(13, 13);
            this.Lbl_NroEtiq.TabIndex = 51;
            this.Lbl_NroEtiq.Text = "0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(623, 24);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(74, 13);
            this.label15.TabIndex = 50;
            this.label15.Text = "Nro. Etiquetas";
            // 
            // Lbl_NroPiezas
            // 
            this.Lbl_NroPiezas.AutoSize = true;
            this.Lbl_NroPiezas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_NroPiezas.ForeColor = System.Drawing.Color.Black;
            this.Lbl_NroPiezas.Location = new System.Drawing.Point(585, 24);
            this.Lbl_NroPiezas.Name = "Lbl_NroPiezas";
            this.Lbl_NroPiezas.Size = new System.Drawing.Size(13, 13);
            this.Lbl_NroPiezas.TabIndex = 49;
            this.Lbl_NroPiezas.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(527, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 13);
            this.label12.TabIndex = 48;
            this.label12.Text = "Nro.Piezas";
            // 
            // Lbl_KgsProd
            // 
            this.Lbl_KgsProd.AutoSize = true;
            this.Lbl_KgsProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_KgsProd.ForeColor = System.Drawing.Color.Black;
            this.Lbl_KgsProd.Location = new System.Drawing.Point(461, 24);
            this.Lbl_KgsProd.Name = "Lbl_KgsProd";
            this.Lbl_KgsProd.Size = new System.Drawing.Size(13, 13);
            this.Lbl_KgsProd.TabIndex = 47;
            this.Lbl_KgsProd.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(372, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 13);
            this.label8.TabIndex = 46;
            this.label8.Text = "Kilos Producidos";
            // 
            // Lbl_SaldoKilosColada
            // 
            this.Lbl_SaldoKilosColada.AutoSize = true;
            this.Lbl_SaldoKilosColada.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_SaldoKilosColada.ForeColor = System.Drawing.Color.Red;
            this.Lbl_SaldoKilosColada.Location = new System.Drawing.Point(314, 24);
            this.Lbl_SaldoKilosColada.Name = "Lbl_SaldoKilosColada";
            this.Lbl_SaldoKilosColada.Size = new System.Drawing.Size(14, 13);
            this.Lbl_SaldoKilosColada.TabIndex = 44;
            this.Lbl_SaldoKilosColada.Text = "0";
            // 
            // Btn_VerDetalle
            // 
            this.Btn_VerDetalle.Location = new System.Drawing.Point(793, 14);
            this.Btn_VerDetalle.Name = "Btn_VerDetalle";
            this.Btn_VerDetalle.Size = new System.Drawing.Size(68, 23);
            this.Btn_VerDetalle.TabIndex = 45;
            this.Btn_VerDetalle.Text = "Ver Detalle";
            this.Btn_VerDetalle.UseVisualStyleBackColor = true;
            this.Btn_VerDetalle.Click += new System.EventHandler(this.Btn_VerDetalle_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(220, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 13);
            this.label11.TabIndex = 43;
            this.label11.Text = "Saldo Kilos Colada";
            // 
            // lblKilos
            // 
            this.lblKilos.AutoSize = true;
            this.lblKilos.Location = new System.Drawing.Point(508, 52);
            this.lblKilos.Name = "lblKilos";
            this.lblKilos.Size = new System.Drawing.Size(13, 13);
            this.lblKilos.TabIndex = 42;
            this.lblKilos.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(480, 53);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 13);
            this.label10.TabIndex = 41;
            this.label10.Text = "Kilos";
            // 
            // lblColada
            // 
            this.lblColada.AutoSize = true;
            this.lblColada.Location = new System.Drawing.Point(102, 53);
            this.lblColada.Name = "lblColada";
            this.lblColada.Size = new System.Drawing.Size(10, 13);
            this.lblColada.TabIndex = 40;
            this.lblColada.Text = ".";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(19, 53);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 13);
            this.label9.TabIndex = 39;
            this.label9.Text = "Colada:";
            // 
            // lblNroCertificado
            // 
            this.lblNroCertificado.AutoSize = true;
            this.lblNroCertificado.Location = new System.Drawing.Point(714, 53);
            this.lblNroCertificado.Name = "lblNroCertificado";
            this.lblNroCertificado.Size = new System.Drawing.Size(10, 13);
            this.lblNroCertificado.TabIndex = 38;
            this.lblNroCertificado.Text = ".";
            // 
            // lblLargo
            // 
            this.lblLargo.AutoSize = true;
            this.lblLargo.Location = new System.Drawing.Point(395, 53);
            this.lblLargo.Name = "lblLargo";
            this.lblLargo.Size = new System.Drawing.Size(13, 13);
            this.lblLargo.TabIndex = 37;
            this.lblLargo.Text = "0";
            // 
            // lblDiametro
            // 
            this.lblDiametro.AutoSize = true;
            this.lblDiametro.Location = new System.Drawing.Point(275, 53);
            this.lblDiametro.Name = "lblDiametro";
            this.lblDiametro.Size = new System.Drawing.Size(13, 13);
            this.lblDiametro.TabIndex = 36;
            this.lblDiametro.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(639, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 35;
            this.label7.Text = "NºCertificado:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(351, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 34;
            this.label6.Text = "Largo:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(216, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "Diametro:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Etiqueta Colada";
            // 
            // txtObs
            // 
            this.txtObs.Location = new System.Drawing.Point(105, 80);
            this.txtObs.Multiline = true;
            this.txtObs.Name = "txtObs";
            this.txtObs.Size = new System.Drawing.Size(667, 43);
            this.txtObs.TabIndex = 1;
            this.txtObs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtObs_KeyDown);
            this.txtObs.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtObs_KeyPress);
            this.txtObs.Leave += new System.EventHandler(this.txtObs_Leave);
            // 
            // txtEtiquetaColada
            // 
            this.txtEtiquetaColada.Location = new System.Drawing.Point(104, 22);
            this.txtEtiquetaColada.Name = "txtEtiquetaColada";
            this.txtEtiquetaColada.Size = new System.Drawing.Size(110, 20);
            this.txtEtiquetaColada.TabIndex = 0;
            this.txtEtiquetaColada.TextChanged += new System.EventHandler(this.txtEtiquetaColada_TextChanged);
            this.txtEtiquetaColada.Leave += new System.EventHandler(this.txtEtiquetaColada_Leave);
            this.txtEtiquetaColada.Validating += new System.ComponentModel.CancelEventHandler(this.txtEtiquetaColada_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "Observacion";
            // 
            // tabOperaciones
            // 
            this.tabOperaciones.Controls.Add(this.tabPage1);
            this.tabOperaciones.Controls.Add(this.tabPage2);
            this.tabOperaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabOperaciones.Location = new System.Drawing.Point(0, 0);
            this.tabOperaciones.Name = "tabOperaciones";
            this.tabOperaciones.SelectedIndex = 0;
            this.tabOperaciones.Size = new System.Drawing.Size(988, 279);
            this.tabOperaciones.TabIndex = 39;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel5);
            this.tabPage1.Controls.Add(this.dgvEtiquetasPiezas);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(980, 253);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Piezas";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lblCantidadEtiquetasPiezas);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(3, 220);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(974, 30);
            this.panel5.TabIndex = 20;
            // 
            // lblCantidadEtiquetasPiezas
            // 
            this.lblCantidadEtiquetasPiezas.AutoSize = true;
            this.lblCantidadEtiquetasPiezas.Location = new System.Drawing.Point(3, 4);
            this.lblCantidadEtiquetasPiezas.Name = "lblCantidadEtiquetasPiezas";
            this.lblCantidadEtiquetasPiezas.Size = new System.Drawing.Size(69, 13);
            this.lblCantidadEtiquetasPiezas.TabIndex = 19;
            this.lblCantidadEtiquetasPiezas.Text = "Registro(s): 0";
            // 
            // dgvEtiquetasPiezas
            // 
            this.dgvEtiquetasPiezas.AllowUserToAddRows = false;
            this.dgvEtiquetasPiezas.AllowUserToDeleteRows = false;
            this.dgvEtiquetasPiezas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEtiquetasPiezas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEtiquetasPiezas.Location = new System.Drawing.Point(3, 3);
            this.dgvEtiquetasPiezas.MultiSelect = false;
            this.dgvEtiquetasPiezas.Name = "dgvEtiquetasPiezas";
            this.dgvEtiquetasPiezas.ReadOnly = true;
            this.dgvEtiquetasPiezas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEtiquetasPiezas.Size = new System.Drawing.Size(974, 247);
            this.dgvEtiquetasPiezas.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvEtiquetasPiezasExcepciones);
            this.tabPage2.Controls.Add(this.panel6);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(980, 253);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Excepciones";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvEtiquetasPiezasExcepciones
            // 
            this.dgvEtiquetasPiezasExcepciones.AllowUserToAddRows = false;
            this.dgvEtiquetasPiezasExcepciones.AllowUserToDeleteRows = false;
            this.dgvEtiquetasPiezasExcepciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEtiquetasPiezasExcepciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEtiquetasPiezasExcepciones.Location = new System.Drawing.Point(3, 33);
            this.dgvEtiquetasPiezasExcepciones.MultiSelect = false;
            this.dgvEtiquetasPiezasExcepciones.Name = "dgvEtiquetasPiezasExcepciones";
            this.dgvEtiquetasPiezasExcepciones.ReadOnly = true;
            this.dgvEtiquetasPiezasExcepciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEtiquetasPiezasExcepciones.Size = new System.Drawing.Size(974, 187);
            this.dgvEtiquetasPiezasExcepciones.TabIndex = 19;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.lblCantidadEtiquetasPiezasExcepciones);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(3, 220);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(974, 30);
            this.panel6.TabIndex = 21;
            // 
            // lblCantidadEtiquetasPiezasExcepciones
            // 
            this.lblCantidadEtiquetasPiezasExcepciones.AutoSize = true;
            this.lblCantidadEtiquetasPiezasExcepciones.Location = new System.Drawing.Point(3, 4);
            this.lblCantidadEtiquetasPiezasExcepciones.Name = "lblCantidadEtiquetasPiezasExcepciones";
            this.lblCantidadEtiquetasPiezasExcepciones.Size = new System.Drawing.Size(69, 13);
            this.lblCantidadEtiquetasPiezasExcepciones.TabIndex = 19;
            this.lblCantidadEtiquetasPiezasExcepciones.Text = "Registro(s): 0";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cboExcepciones);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(974, 30);
            this.panel2.TabIndex = 0;
            // 
            // cboExcepciones
            // 
            this.cboExcepciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboExcepciones.FormattingEnabled = true;
            this.cboExcepciones.Location = new System.Drawing.Point(106, 3);
            this.cboExcepciones.Name = "cboExcepciones";
            this.cboExcepciones.Size = new System.Drawing.Size(230, 21);
            this.cboExcepciones.TabIndex = 1;
            this.cboExcepciones.SelectedIndexChanged += new System.EventHandler(this.cboExcepciones_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Motivo:";
            // 
            // txtEtiquetaPieza
            // 
            this.txtEtiquetaPieza.Location = new System.Drawing.Point(103, 4);
            this.txtEtiquetaPieza.Name = "txtEtiquetaPieza";
            this.txtEtiquetaPieza.Size = new System.Drawing.Size(164, 20);
            this.txtEtiquetaPieza.TabIndex = 0;
            this.txtEtiquetaPieza.TextChanged += new System.EventHandler(this.txtEtiquetaPieza_TextChanged);
            this.txtEtiquetaPieza.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEtiquetaPieza_KeyPress);
            this.txtEtiquetaPieza.Leave += new System.EventHandler(this.txtEtiquetaPieza_Leave);
            this.txtEtiquetaPieza.Validating += new System.ComponentModel.CancelEventHandler(this.txtEtiquetaPieza_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Etiqueta Pieza:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.tabOperaciones);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 202);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(988, 279);
            this.panel3.TabIndex = 40;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.Btn_Desbloquea);
            this.panel4.Controls.Add(this.Chk_MultiplesColadas);
            this.panel4.Controls.Add(this.Lbl_MsgKgsProd);
            this.panel4.Controls.Add(this.lbl_Msg);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.txtEtiquetaPieza);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(988, 30);
            this.panel4.TabIndex = 0;
            // 
            // Btn_Desbloquea
            // 
            this.Btn_Desbloquea.Location = new System.Drawing.Point(574, 3);
            this.Btn_Desbloquea.Name = "Btn_Desbloquea";
            this.Btn_Desbloquea.Size = new System.Drawing.Size(148, 23);
            this.Btn_Desbloquea.TabIndex = 23;
            this.Btn_Desbloquea.Text = "Ingresar Reparación";
            this.Btn_Desbloquea.UseVisualStyleBackColor = true;
            this.Btn_Desbloquea.Visible = false;
            this.Btn_Desbloquea.Click += new System.EventHandler(this.Btn_Desbloquea_Click);
            // 
            // Chk_MultiplesColadas
            // 
            this.Chk_MultiplesColadas.AutoSize = true;
            this.Chk_MultiplesColadas.Location = new System.Drawing.Point(445, 8);
            this.Chk_MultiplesColadas.Name = "Chk_MultiplesColadas";
            this.Chk_MultiplesColadas.Size = new System.Drawing.Size(108, 17);
            this.Chk_MultiplesColadas.TabIndex = 22;
            this.Chk_MultiplesColadas.Text = "Multiples Coladas";
            this.Chk_MultiplesColadas.UseVisualStyleBackColor = true;
            this.Chk_MultiplesColadas.CheckedChanged += new System.EventHandler(this.Chk_MultiplesColadas_CheckedChanged);
            // 
            // Lbl_MsgKgsProd
            // 
            this.Lbl_MsgKgsProd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Lbl_MsgKgsProd.AutoSize = true;
            this.Lbl_MsgKgsProd.Location = new System.Drawing.Point(744, 9);
            this.Lbl_MsgKgsProd.Name = "Lbl_MsgKgsProd";
            this.Lbl_MsgKgsProd.Size = new System.Drawing.Size(181, 13);
            this.Lbl_MsgKgsProd.TabIndex = 21;
            this.Lbl_MsgKgsProd.Text = " total acumulado diariamente en kilos";
            // 
            // lbl_Msg
            // 
            this.lbl_Msg.AutoSize = true;
            this.lbl_Msg.Location = new System.Drawing.Point(274, 8);
            this.lbl_Msg.Name = "lbl_Msg";
            this.lbl_Msg.Size = new System.Drawing.Size(169, 13);
            this.lbl_Msg.TabIndex = 20;
            this.lbl_Msg.Text = "No se registran piezas procesadas";
            // 
            // ctlInformacionUsuario1
            // 
            this.ctlInformacionUsuario1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctlInformacionUsuario1.Location = new System.Drawing.Point(0, 0);
            this.ctlInformacionUsuario1.Name = "ctlInformacionUsuario1";
            this.ctlInformacionUsuario1.Size = new System.Drawing.Size(988, 36);
            this.ctlInformacionUsuario1.TabIndex = 35;
            // 
            // lbl_MsgBloqueo
            // 
            this.lbl_MsgBloqueo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lbl_MsgBloqueo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_MsgBloqueo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_MsgBloqueo.ForeColor = System.Drawing.Color.White;
            this.lbl_MsgBloqueo.Location = new System.Drawing.Point(3, 16);
            this.lbl_MsgBloqueo.Name = "lbl_MsgBloqueo";
            this.lbl_MsgBloqueo.Size = new System.Drawing.Size(962, 110);
            this.lbl_MsgBloqueo.TabIndex = 55;
            this.lbl_MsgBloqueo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_MsgBloqueo.Visible = false;
            // 
            // frmProduccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 503);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tlsToolBar);
            this.Controls.Add(this.ctlInformacionUsuario1);
            this.Controls.Add(this.stsStatusStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmProduccion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Producción";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmProduccion_Load);
            this.Shown += new System.EventHandler(this.frmProduccion_Shown);
            this.stsStatusStrip.ResumeLayout(false);
            this.stsStatusStrip.PerformLayout();
            this.tlsToolBar.ResumeLayout(false);
            this.tlsToolBar.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabOperaciones.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEtiquetasPiezas)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEtiquetasPiezasExcepciones)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip stsStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel tlsEstado;
        private ctlInformacionUsuario ctlInformacionUsuario1;
        private System.Windows.Forms.ToolStrip tlsToolBar;
        private System.Windows.Forms.ToolStripButton tlbNuevo;
        private System.Windows.Forms.ToolStripButton tlbGuardar;
        private System.Windows.Forms.ToolStripButton tlbEliminar;
        private System.Windows.Forms.ToolStripButton tlbDesactivar;
        private System.Windows.Forms.ToolStripButton tlbActualizar;
        private System.Windows.Forms.ToolStripButton tlbImprimir;
        private System.Windows.Forms.ToolStripButton tlbExportar;
        private System.Windows.Forms.ToolStripButton tlbSalir;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtObs;
        private System.Windows.Forms.TextBox txtEtiquetaColada;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabControl tabOperaciones;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtEtiquetaPieza;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvEtiquetasPiezasExcepciones;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox cboExcepciones;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCantidadEtiquetasPiezas;
        private System.Windows.Forms.Label lblNroCertificado;
        private System.Windows.Forms.Label lblLargo;
        private System.Windows.Forms.Label lblDiametro;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lblCantidadEtiquetasPiezasExcepciones;
        private System.Windows.Forms.Label lblColada;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblKilos;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label Lbl_NroEtiq;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label Lbl_NroPiezas;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label Lbl_KgsProd;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label Lbl_SaldoKilosColada;
        private System.Windows.Forms.Button Btn_VerDetalle;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbl_Msg;
        private System.Windows.Forms.Label Lbl_MsgKgsProd;
        private System.Windows.Forms.CheckBox Chk_MultiplesColadas;
        private System.Windows.Forms.Button Btn_NotificacionAveria;
        private System.Windows.Forms.Button Btn_MtoMaq;
        private System.Windows.Forms.Button Btn_MtoTotem;
        private System.Windows.Forms.DataGridView dgvEtiquetasPiezas;
        private System.Windows.Forms.Button Btn_Desbloquea;
        private System.Windows.Forms.Label lbl_MsgBloqueo;
    }
}

