namespace Metalurgica.Maquinas
{
    partial class NotificaAveria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotificaAveria));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Rb_Averia = new System.Windows.Forms.RadioButton();
            this.Rb_cambioRollo = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.Gb_Averia = new System.Windows.Forms.GroupBox();
            this.Tx_TextoAveria = new System.Windows.Forms.TextBox();
            this.Rb_Detenida = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.Rb_Operativa = new System.Windows.Forms.RadioButton();
            this.Tx_Id = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Dtp_Fecha = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.CmbMaquinaAveria = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbOperador = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.Btn_Cargar = new System.Windows.Forms.Button();
            this.GB_Reparacion = new System.Windows.Forms.GroupBox();
            this.Tx_IdSolucion = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.Rb_RepDetenida = new System.Windows.Forms.RadioButton();
            this.Rb_RepOperativa = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.Tx_ReparacionAveria = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.Dtg_SolucionAveria = new System.Windows.Forms.DataGridView();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.Tx_Mecanico = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Btn_IngRepuesto = new System.Windows.Forms.Button();
            this.Gr_Supervisor = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.Rb_LiberarDetenida = new System.Windows.Forms.RadioButton();
            this.Rb_LiberarOperativa = new System.Windows.Forms.RadioButton();
            this.label13 = new System.Windows.Forms.Label();
            this.Tx_LiberarTotem = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.Dtg_LiberacionAveria = new System.Windows.Forms.DataGridView();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.Tx_Supervisor = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.Btn_Grabar = new System.Windows.Forms.Button();
            this.Btn_Limpiar = new System.Windows.Forms.Button();
            this.Btn_Salir = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.Gb_Averia.SuspendLayout();
            this.GB_Reparacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_SolucionAveria)).BeginInit();
            this.Gr_Supervisor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_LiberacionAveria)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Rb_Averia);
            this.groupBox1.Controls.Add(this.Rb_cambioRollo);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.Gb_Averia);
            this.groupBox1.Controls.Add(this.Tx_Id);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.Dtp_Fecha);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.CmbMaquinaAveria);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.CmbOperador);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(7, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(790, 195);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ingreso de Datos";
            // 
            // Rb_Averia
            // 
            this.Rb_Averia.AutoSize = true;
            this.Rb_Averia.Checked = true;
            this.Rb_Averia.Location = new System.Drawing.Point(577, 48);
            this.Rb_Averia.Name = "Rb_Averia";
            this.Rb_Averia.Size = new System.Drawing.Size(99, 17);
            this.Rb_Averia.TabIndex = 21;
            this.Rb_Averia.TabStop = true;
            this.Rb_Averia.Text = "Averia Máquina";
            this.Rb_Averia.UseVisualStyleBackColor = true;
            this.Rb_Averia.CheckedChanged += new System.EventHandler(this.Rb_Averia_CheckedChanged);
            // 
            // Rb_cambioRollo
            // 
            this.Rb_cambioRollo.AutoSize = true;
            this.Rb_cambioRollo.Location = new System.Drawing.Point(682, 48);
            this.Rb_cambioRollo.Name = "Rb_cambioRollo";
            this.Rb_cambioRollo.Size = new System.Drawing.Size(102, 17);
            this.Rb_cambioRollo.TabIndex = 20;
            this.Rb_cambioRollo.Text = "Cambio de Rollo";
            this.Rb_cambioRollo.UseVisualStyleBackColor = true;
            this.Rb_cambioRollo.CheckedChanged += new System.EventHandler(this.Rb_cambioRollo_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(599, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 17);
            this.label6.TabIndex = 19;
            this.label6.Text = "Tipo de notificación ";
            // 
            // Gb_Averia
            // 
            this.Gb_Averia.Controls.Add(this.Tx_TextoAveria);
            this.Gb_Averia.Controls.Add(this.Rb_Detenida);
            this.Gb_Averia.Controls.Add(this.label4);
            this.Gb_Averia.Controls.Add(this.Rb_Operativa);
            this.Gb_Averia.Location = new System.Drawing.Point(15, 75);
            this.Gb_Averia.Name = "Gb_Averia";
            this.Gb_Averia.Size = new System.Drawing.Size(769, 112);
            this.Gb_Averia.TabIndex = 18;
            this.Gb_Averia.TabStop = false;
            // 
            // Tx_TextoAveria
            // 
            this.Tx_TextoAveria.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Tx_TextoAveria.Location = new System.Drawing.Point(7, 38);
            this.Tx_TextoAveria.Multiline = true;
            this.Tx_TextoAveria.Name = "Tx_TextoAveria";
            this.Tx_TextoAveria.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Tx_TextoAveria.Size = new System.Drawing.Size(749, 66);
            this.Tx_TextoAveria.TabIndex = 8;
            this.Tx_TextoAveria.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Tx_TextoAveria_KeyPress);
            // 
            // Rb_Detenida
            // 
            this.Rb_Detenida.AutoSize = true;
            this.Rb_Detenida.Location = new System.Drawing.Point(497, 14);
            this.Rb_Detenida.Name = "Rb_Detenida";
            this.Rb_Detenida.Size = new System.Drawing.Size(145, 17);
            this.Rb_Detenida.TabIndex = 17;
            this.Rb_Detenida.TabStop = true;
            this.Rb_Detenida.Text = "Máquina queda Detenida";
            this.Rb_Detenida.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(170, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Ingrese el motivo de la notificación";
            // 
            // Rb_Operativa
            // 
            this.Rb_Operativa.AutoSize = true;
            this.Rb_Operativa.Location = new System.Drawing.Point(226, 14);
            this.Rb_Operativa.Name = "Rb_Operativa";
            this.Rb_Operativa.Size = new System.Drawing.Size(148, 17);
            this.Rb_Operativa.TabIndex = 16;
            this.Rb_Operativa.TabStop = true;
            this.Rb_Operativa.Text = "Máquina queda Operativa";
            this.Rb_Operativa.UseVisualStyleBackColor = true;
            // 
            // Tx_Id
            // 
            this.Tx_Id.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Tx_Id.Enabled = false;
            this.Tx_Id.Location = new System.Drawing.Point(509, 44);
            this.Tx_Id.Name = "Tx_Id";
            this.Tx_Id.ReadOnly = true;
            this.Tx_Id.Size = new System.Drawing.Size(48, 20);
            this.Tx_Id.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(525, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Id";
            // 
            // Dtp_Fecha
            // 
            this.Dtp_Fecha.Enabled = false;
            this.Dtp_Fecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Dtp_Fecha.Location = new System.Drawing.Point(387, 44);
            this.Dtp_Fecha.Name = "Dtp_Fecha";
            this.Dtp_Fecha.Size = new System.Drawing.Size(99, 20);
            this.Dtp_Fecha.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(387, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Fecha Notificación";
            // 
            // CmbMaquinaAveria
            // 
            this.CmbMaquinaAveria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbMaquinaAveria.FormattingEnabled = true;
            this.CmbMaquinaAveria.Location = new System.Drawing.Point(202, 44);
            this.CmbMaquinaAveria.Name = "CmbMaquinaAveria";
            this.CmbMaquinaAveria.Size = new System.Drawing.Size(173, 21);
            this.CmbMaquinaAveria.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(210, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Máquina con averia";
            // 
            // CmbOperador
            // 
            this.CmbOperador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbOperador.FormattingEnabled = true;
            this.CmbOperador.Location = new System.Drawing.Point(15, 44);
            this.CmbOperador.Name = "CmbOperador";
            this.CmbOperador.Size = new System.Drawing.Size(173, 21);
            this.CmbOperador.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Operador a Cargo";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Untitled (114).ico");
            this.imageList1.Images.SetKeyName(1, "Untitled (139).ico");
            this.imageList1.Images.SetKeyName(2, "Untitled (414).ico");
            this.imageList1.Images.SetKeyName(3, "Untitled (358).ico");
            this.imageList1.Images.SetKeyName(4, "Untitled (149).ico");
            this.imageList1.Images.SetKeyName(5, "Untitled (157).ico");
            this.imageList1.Images.SetKeyName(6, "Untitled (182).ico");
            // 
            // Btn_Cargar
            // 
            this.Btn_Cargar.Location = new System.Drawing.Point(733, -20);
            this.Btn_Cargar.Name = "Btn_Cargar";
            this.Btn_Cargar.Size = new System.Drawing.Size(75, 46);
            this.Btn_Cargar.TabIndex = 12;
            this.Btn_Cargar.Text = "Cargar";
            this.Btn_Cargar.UseVisualStyleBackColor = true;
            this.Btn_Cargar.Visible = false;
            this.Btn_Cargar.Click += new System.EventHandler(this.Btn_Cargar_Click);
            // 
            // GB_Reparacion
            // 
            this.GB_Reparacion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GB_Reparacion.Controls.Add(this.Tx_IdSolucion);
            this.GB_Reparacion.Controls.Add(this.label11);
            this.GB_Reparacion.Controls.Add(this.Rb_RepDetenida);
            this.GB_Reparacion.Controls.Add(this.Rb_RepOperativa);
            this.GB_Reparacion.Controls.Add(this.label10);
            this.GB_Reparacion.Controls.Add(this.Tx_ReparacionAveria);
            this.GB_Reparacion.Controls.Add(this.label9);
            this.GB_Reparacion.Controls.Add(this.Dtg_SolucionAveria);
            this.GB_Reparacion.Controls.Add(this.dateTimePicker1);
            this.GB_Reparacion.Controls.Add(this.label8);
            this.GB_Reparacion.Controls.Add(this.Tx_Mecanico);
            this.GB_Reparacion.Controls.Add(this.label7);
            this.GB_Reparacion.Enabled = false;
            this.GB_Reparacion.Location = new System.Drawing.Point(9, 204);
            this.GB_Reparacion.Name = "GB_Reparacion";
            this.GB_Reparacion.Size = new System.Drawing.Size(982, 253);
            this.GB_Reparacion.TabIndex = 16;
            this.GB_Reparacion.TabStop = false;
            this.GB_Reparacion.Text = "Datos de la Reparación";
            // 
            // Tx_IdSolucion
            // 
            this.Tx_IdSolucion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Tx_IdSolucion.Enabled = false;
            this.Tx_IdSolucion.Location = new System.Drawing.Point(699, 23);
            this.Tx_IdSolucion.Name = "Tx_IdSolucion";
            this.Tx_IdSolucion.ReadOnly = true;
            this.Tx_IdSolucion.Size = new System.Drawing.Size(48, 20);
            this.Tx_IdSolucion.TabIndex = 22;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(677, 26);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(16, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "Id";
            // 
            // Rb_RepDetenida
            // 
            this.Rb_RepDetenida.AutoSize = true;
            this.Rb_RepDetenida.Location = new System.Drawing.Point(708, 52);
            this.Rb_RepDetenida.Name = "Rb_RepDetenida";
            this.Rb_RepDetenida.Size = new System.Drawing.Size(145, 17);
            this.Rb_RepDetenida.TabIndex = 20;
            this.Rb_RepDetenida.TabStop = true;
            this.Rb_RepDetenida.Text = "Máquina queda Detenida";
            this.Rb_RepDetenida.UseVisualStyleBackColor = true;
            // 
            // Rb_RepOperativa
            // 
            this.Rb_RepOperativa.AutoSize = true;
            this.Rb_RepOperativa.Location = new System.Drawing.Point(555, 52);
            this.Rb_RepOperativa.Name = "Rb_RepOperativa";
            this.Rb_RepOperativa.Size = new System.Drawing.Size(148, 17);
            this.Rb_RepOperativa.TabIndex = 19;
            this.Rb_RepOperativa.TabStop = true;
            this.Rb_RepOperativa.Text = "Máquina queda Operativa";
            this.Rb_RepOperativa.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(441, 56);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(98, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Estado Reparación";
            // 
            // Tx_ReparacionAveria
            // 
            this.Tx_ReparacionAveria.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Tx_ReparacionAveria.Location = new System.Drawing.Point(17, 75);
            this.Tx_ReparacionAveria.Multiline = true;
            this.Tx_ReparacionAveria.Name = "Tx_ReparacionAveria";
            this.Tx_ReparacionAveria.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Tx_ReparacionAveria.Size = new System.Drawing.Size(952, 46);
            this.Tx_ReparacionAveria.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(129, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Ingrese detalle reparación";
            // 
            // Dtg_SolucionAveria
            // 
            this.Dtg_SolucionAveria.AllowUserToAddRows = false;
            this.Dtg_SolucionAveria.AllowUserToDeleteRows = false;
            this.Dtg_SolucionAveria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dtg_SolucionAveria.Location = new System.Drawing.Point(19, 129);
            this.Dtg_SolucionAveria.Name = "Dtg_SolucionAveria";
            this.Dtg_SolucionAveria.ReadOnly = true;
            this.Dtg_SolucionAveria.Size = new System.Drawing.Size(906, 113);
            this.Dtg_SolucionAveria.TabIndex = 15;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(512, 22);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(99, 20);
            this.dateTimePicker1.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(437, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Fecha actual";
            // 
            // Tx_Mecanico
            // 
            this.Tx_Mecanico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Tx_Mecanico.Enabled = false;
            this.Tx_Mecanico.Location = new System.Drawing.Point(115, 22);
            this.Tx_Mecanico.Name = "Tx_Mecanico";
            this.Tx_Mecanico.ReadOnly = true;
            this.Tx_Mecanico.Size = new System.Drawing.Size(307, 20);
            this.Tx_Mecanico.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Operador a Cargo";
            // 
            // Btn_IngRepuesto
            // 
            this.Btn_IngRepuesto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_IngRepuesto.Enabled = false;
            this.Btn_IngRepuesto.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_IngRepuesto.ImageIndex = 2;
            this.Btn_IngRepuesto.ImageList = this.imageList1;
            this.Btn_IngRepuesto.Location = new System.Drawing.Point(916, 83);
            this.Btn_IngRepuesto.Name = "Btn_IngRepuesto";
            this.Btn_IngRepuesto.Size = new System.Drawing.Size(67, 56);
            this.Btn_IngRepuesto.TabIndex = 23;
            this.Btn_IngRepuesto.Text = "Ingresa Repuestos";
            this.Btn_IngRepuesto.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_IngRepuesto.UseVisualStyleBackColor = true;
            this.Btn_IngRepuesto.Click += new System.EventHandler(this.Btn_IngRepuestos_Click);
            // 
            // Gr_Supervisor
            // 
            this.Gr_Supervisor.Controls.Add(this.textBox1);
            this.Gr_Supervisor.Controls.Add(this.label12);
            this.Gr_Supervisor.Controls.Add(this.Rb_LiberarDetenida);
            this.Gr_Supervisor.Controls.Add(this.Rb_LiberarOperativa);
            this.Gr_Supervisor.Controls.Add(this.label13);
            this.Gr_Supervisor.Controls.Add(this.Tx_LiberarTotem);
            this.Gr_Supervisor.Controls.Add(this.label14);
            this.Gr_Supervisor.Controls.Add(this.Dtg_LiberacionAveria);
            this.Gr_Supervisor.Controls.Add(this.dateTimePicker2);
            this.Gr_Supervisor.Controls.Add(this.label15);
            this.Gr_Supervisor.Controls.Add(this.Tx_Supervisor);
            this.Gr_Supervisor.Controls.Add(this.label16);
            this.Gr_Supervisor.Enabled = false;
            this.Gr_Supervisor.Location = new System.Drawing.Point(7, 463);
            this.Gr_Supervisor.Name = "Gr_Supervisor";
            this.Gr_Supervisor.Size = new System.Drawing.Size(869, 242);
            this.Gr_Supervisor.TabIndex = 17;
            this.Gr_Supervisor.TabStop = false;
            this.Gr_Supervisor.Text = "Datos de la Validación del Supervisor";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(699, 23);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(48, 20);
            this.textBox1.TabIndex = 22;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(677, 26);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(16, 13);
            this.label12.TabIndex = 21;
            this.label12.Text = "Id";
            // 
            // Rb_LiberarDetenida
            // 
            this.Rb_LiberarDetenida.AutoSize = true;
            this.Rb_LiberarDetenida.Location = new System.Drawing.Point(708, 52);
            this.Rb_LiberarDetenida.Name = "Rb_LiberarDetenida";
            this.Rb_LiberarDetenida.Size = new System.Drawing.Size(145, 17);
            this.Rb_LiberarDetenida.TabIndex = 20;
            this.Rb_LiberarDetenida.TabStop = true;
            this.Rb_LiberarDetenida.Text = "Máquina queda Detenida";
            this.Rb_LiberarDetenida.UseVisualStyleBackColor = true;
            // 
            // Rb_LiberarOperativa
            // 
            this.Rb_LiberarOperativa.AutoSize = true;
            this.Rb_LiberarOperativa.Location = new System.Drawing.Point(555, 52);
            this.Rb_LiberarOperativa.Name = "Rb_LiberarOperativa";
            this.Rb_LiberarOperativa.Size = new System.Drawing.Size(148, 17);
            this.Rb_LiberarOperativa.TabIndex = 19;
            this.Rb_LiberarOperativa.TabStop = true;
            this.Rb_LiberarOperativa.Text = "Máquina queda Operativa";
            this.Rb_LiberarOperativa.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(441, 56);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(98, 13);
            this.label13.TabIndex = 18;
            this.label13.Text = "Estado Reparación";
            // 
            // Tx_LiberarTotem
            // 
            this.Tx_LiberarTotem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Tx_LiberarTotem.Location = new System.Drawing.Point(17, 77);
            this.Tx_LiberarTotem.Multiline = true;
            this.Tx_LiberarTotem.Name = "Tx_LiberarTotem";
            this.Tx_LiberarTotem.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Tx_LiberarTotem.Size = new System.Drawing.Size(839, 46);
            this.Tx_LiberarTotem.TabIndex = 17;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(17, 56);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(128, 13);
            this.label14.TabIndex = 16;
            this.label14.Text = "Ingrese detalle Validación";
            // 
            // Dtg_LiberacionAveria
            // 
            this.Dtg_LiberacionAveria.AllowUserToAddRows = false;
            this.Dtg_LiberacionAveria.AllowUserToDeleteRows = false;
            this.Dtg_LiberacionAveria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dtg_LiberacionAveria.Location = new System.Drawing.Point(17, 130);
            this.Dtg_LiberacionAveria.Name = "Dtg_LiberacionAveria";
            this.Dtg_LiberacionAveria.ReadOnly = true;
            this.Dtg_LiberacionAveria.Size = new System.Drawing.Size(839, 103);
            this.Dtg_LiberacionAveria.TabIndex = 15;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Enabled = false;
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(512, 22);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(99, 20);
            this.dateTimePicker2.TabIndex = 14;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(437, 25);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(69, 13);
            this.label15.TabIndex = 13;
            this.label15.Text = "Fecha actual";
            // 
            // Tx_Supervisor
            // 
            this.Tx_Supervisor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Tx_Supervisor.Enabled = false;
            this.Tx_Supervisor.Location = new System.Drawing.Point(115, 22);
            this.Tx_Supervisor.Name = "Tx_Supervisor";
            this.Tx_Supervisor.ReadOnly = true;
            this.Tx_Supervisor.Size = new System.Drawing.Size(307, 20);
            this.Tx_Supervisor.TabIndex = 12;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(16, 25);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(91, 13);
            this.label16.TabIndex = 2;
            this.label16.Text = "Operador a Cargo";
            // 
            // Btn_Grabar
            // 
            this.Btn_Grabar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Grabar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Grabar.ImageIndex = 0;
            this.Btn_Grabar.ImageList = this.imageList1;
            this.Btn_Grabar.Location = new System.Drawing.Point(846, 6);
            this.Btn_Grabar.Name = "Btn_Grabar";
            this.Btn_Grabar.Size = new System.Drawing.Size(63, 56);
            this.Btn_Grabar.TabIndex = 13;
            this.Btn_Grabar.Text = "&Grabar";
            this.Btn_Grabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Grabar.UseVisualStyleBackColor = true;
            this.Btn_Grabar.Click += new System.EventHandler(this.Btn_Grabar_Click_1);
            // 
            // Btn_Limpiar
            // 
            this.Btn_Limpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Limpiar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Limpiar.ImageIndex = 6;
            this.Btn_Limpiar.ImageList = this.imageList1;
            this.Btn_Limpiar.Location = new System.Drawing.Point(920, 5);
            this.Btn_Limpiar.Name = "Btn_Limpiar";
            this.Btn_Limpiar.Size = new System.Drawing.Size(64, 56);
            this.Btn_Limpiar.TabIndex = 14;
            this.Btn_Limpiar.Text = "&Limpiar";
            this.Btn_Limpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Limpiar.UseVisualStyleBackColor = true;
            this.Btn_Limpiar.Click += new System.EventHandler(this.Btn_Limpiar_Click);
            // 
            // Btn_Salir
            // 
            this.Btn_Salir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Salir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Salir.ImageIndex = 5;
            this.Btn_Salir.ImageList = this.imageList1;
            this.Btn_Salir.Location = new System.Drawing.Point(847, 83);
            this.Btn_Salir.Name = "Btn_Salir";
            this.Btn_Salir.Size = new System.Drawing.Size(63, 56);
            this.Btn_Salir.TabIndex = 15;
            this.Btn_Salir.Text = "&Salir";
            this.Btn_Salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Salir.UseVisualStyleBackColor = true;
            this.Btn_Salir.Click += new System.EventHandler(this.Btn_Salir_Click);
            // 
            // NotificaAveria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 719);
            this.ControlBox = false;
            this.Controls.Add(this.Btn_IngRepuesto);
            this.Controls.Add(this.Gr_Supervisor);
            this.Controls.Add(this.GB_Reparacion);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Btn_Cargar);
            this.Controls.Add(this.Btn_Grabar);
            this.Controls.Add(this.Btn_Limpiar);
            this.Controls.Add(this.Btn_Salir);
            this.Name = "NotificaAveria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formulario de Notificación de Averias";
            this.Load += new System.EventHandler(this.NotificaAveria_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.Gb_Averia.ResumeLayout(false);
            this.Gb_Averia.PerformLayout();
            this.GB_Reparacion.ResumeLayout(false);
            this.GB_Reparacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_SolucionAveria)).EndInit();
            this.Gr_Supervisor.ResumeLayout(false);
            this.Gr_Supervisor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_LiberacionAveria)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox Tx_TextoAveria;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker Dtp_Fecha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CmbMaquinaAveria;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CmbOperador;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Tx_Id;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Btn_Cargar;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button Btn_Salir;
        private System.Windows.Forms.Button Btn_Limpiar;
        private System.Windows.Forms.Button Btn_Grabar;
        private System.Windows.Forms.RadioButton Rb_Detenida;
        private System.Windows.Forms.RadioButton Rb_Operativa;
        private System.Windows.Forms.RadioButton Rb_Averia;
        private System.Windows.Forms.RadioButton Rb_cambioRollo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox Gb_Averia;
        private System.Windows.Forms.GroupBox GB_Reparacion;
        private System.Windows.Forms.RadioButton Rb_RepDetenida;
        private System.Windows.Forms.RadioButton Rb_RepOperativa;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox Tx_ReparacionAveria;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView Dtg_SolucionAveria;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Tx_Mecanico;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox Tx_IdSolucion;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox Gr_Supervisor;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RadioButton Rb_LiberarDetenida;
        private System.Windows.Forms.RadioButton Rb_LiberarOperativa;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox Tx_LiberarTotem;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridView Dtg_LiberacionAveria;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox Tx_Supervisor;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button Btn_IngRepuesto;
    }
}