namespace Metalurgica.RecepcionMP
{
    partial class Frm_RecepcionMP
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Gr_datos = new System.Windows.Forms.GroupBox();
            this.Cmb_Sucursal = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.Dtp_Fecha = new System.Windows.Forms.DateTimePicker();
            this.Tx_OC = new System.Windows.Forms.TextBox();
            this.Tx_TotalKgsGD = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Tx_GuiaDesp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Pnl_EtRecepcionadas = new System.Windows.Forms.Panel();
            this.Btn_AceptarRec = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Dtg_Et_recepcionadas = new System.Windows.Forms.DataGridView();
            this.Dtg_Etiquetas = new System.Windows.Forms.DataGridView();
            this.Tx_EtiquetaAza = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Btn_grabar = new System.Windows.Forms.Button();
            this.Btn_InicioL = new System.Windows.Forms.Button();
            this.Btn_Nueva = new System.Windows.Forms.Button();
            this.Frm_DesdeArchivo = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Btn_GrabaTol = new System.Windows.Forms.Button();
            this.Gr_autorizacion = new System.Windows.Forms.GroupBox();
            this.Btn_aceptar = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.Tx_clave = new System.Windows.Forms.TextBox();
            this.Btn_Cambiar = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.Tx_tolerancia = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.Gr_datos.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.Pnl_EtRecepcionadas.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_Et_recepcionadas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_Etiquetas)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.Gr_autorizacion.SuspendLayout();
            this.SuspendLayout();
            // 
            // Gr_datos
            // 
            this.Gr_datos.Controls.Add(this.Cmb_Sucursal);
            this.Gr_datos.Controls.Add(this.label12);
            this.Gr_datos.Controls.Add(this.Dtp_Fecha);
            this.Gr_datos.Controls.Add(this.Tx_OC);
            this.Gr_datos.Controls.Add(this.Tx_TotalKgsGD);
            this.Gr_datos.Controls.Add(this.label3);
            this.Gr_datos.Controls.Add(this.label5);
            this.Gr_datos.Controls.Add(this.label2);
            this.Gr_datos.Controls.Add(this.Tx_GuiaDesp);
            this.Gr_datos.Controls.Add(this.label1);
            this.Gr_datos.Location = new System.Drawing.Point(13, 13);
            this.Gr_datos.Name = "Gr_datos";
            this.Gr_datos.Size = new System.Drawing.Size(747, 84);
            this.Gr_datos.TabIndex = 0;
            this.Gr_datos.TabStop = false;
            this.Gr_datos.Text = "Datos de la Recepción de Material";
            // 
            // Cmb_Sucursal
            // 
            this.Cmb_Sucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cmb_Sucursal.FormattingEnabled = true;
            this.Cmb_Sucursal.Location = new System.Drawing.Point(327, 48);
            this.Cmb_Sucursal.Name = "Cmb_Sucursal";
            this.Cmb_Sucursal.Size = new System.Drawing.Size(129, 21);
            this.Cmb_Sucursal.TabIndex = 11;
            this.Cmb_Sucursal.Leave += new System.EventHandler(this.Cmb_Sucursal_Leave);
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(336, 26);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(104, 13);
            this.label12.TabIndex = 10;
            this.label12.Text = "Seleccione Sucursal";
            // 
            // Dtp_Fecha
            // 
            this.Dtp_Fecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Dtp_Fecha.Location = new System.Drawing.Point(183, 51);
            this.Dtp_Fecha.Name = "Dtp_Fecha";
            this.Dtp_Fecha.Size = new System.Drawing.Size(100, 20);
            this.Dtp_Fecha.TabIndex = 6;
            this.Dtp_Fecha.Leave += new System.EventHandler(this.Dtp_Fecha_Leave);
            // 
            // Tx_OC
            // 
            this.Tx_OC.Location = new System.Drawing.Point(501, 48);
            this.Tx_OC.MaxLength = 10;
            this.Tx_OC.Name = "Tx_OC";
            this.Tx_OC.Size = new System.Drawing.Size(100, 20);
            this.Tx_OC.TabIndex = 5;
            this.Tx_OC.TextChanged += new System.EventHandler(this.Tx_OC_TextChanged);
            this.Tx_OC.Leave += new System.EventHandler(this.Tx_OC_Leave);
            this.Tx_OC.Validating += new System.ComponentModel.CancelEventHandler(this.Tx_OC_Validating);
            // 
            // Tx_TotalKgsGD
            // 
            this.Tx_TotalKgsGD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Tx_TotalKgsGD.Location = new System.Drawing.Point(641, 49);
            this.Tx_TotalKgsGD.MaxLength = 10;
            this.Tx_TotalKgsGD.Name = "Tx_TotalKgsGD";
            this.Tx_TotalKgsGD.Size = new System.Drawing.Size(100, 20);
            this.Tx_TotalKgsGD.TabIndex = 9;
            this.Tx_TotalKgsGD.Leave += new System.EventHandler(this.Tx_TotalKgsGD_Leave);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(502, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 31);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ingrese el Nro de Orden de Compra";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(655, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Total Kgs G.D";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(171, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 30);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ingrese la Fecha de Guía de Despacho";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Tx_GuiaDesp
            // 
            this.Tx_GuiaDesp.Location = new System.Drawing.Point(20, 53);
            this.Tx_GuiaDesp.MaxLength = 10;
            this.Tx_GuiaDesp.Name = "Tx_GuiaDesp";
            this.Tx_GuiaDesp.Size = new System.Drawing.Size(100, 20);
            this.Tx_GuiaDesp.TabIndex = 1;
            this.Tx_GuiaDesp.Leave += new System.EventHandler(this.Tx_GuiaDesp_Leave);
            this.Tx_GuiaDesp.Validating += new System.ComponentModel.CancelEventHandler(this.Tx_GuiaDesp_Validating);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingrese el Nro de Guía de Despacho";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.Pnl_EtRecepcionadas);
            this.groupBox2.Controls.Add(this.Dtg_Etiquetas);
            this.groupBox2.Location = new System.Drawing.Point(13, 166);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1026, 368);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Etiquetas AZA ingresadas";
            // 
            // Pnl_EtRecepcionadas
            // 
            this.Pnl_EtRecepcionadas.BackColor = System.Drawing.Color.Red;
            this.Pnl_EtRecepcionadas.Controls.Add(this.Btn_AceptarRec);
            this.Pnl_EtRecepcionadas.Controls.Add(this.label8);
            this.Pnl_EtRecepcionadas.Controls.Add(this.label7);
            this.Pnl_EtRecepcionadas.Controls.Add(this.label6);
            this.Pnl_EtRecepcionadas.Controls.Add(this.groupBox1);
            this.Pnl_EtRecepcionadas.Location = new System.Drawing.Point(151, 43);
            this.Pnl_EtRecepcionadas.Name = "Pnl_EtRecepcionadas";
            this.Pnl_EtRecepcionadas.Size = new System.Drawing.Size(819, 322);
            this.Pnl_EtRecepcionadas.TabIndex = 1;
            this.Pnl_EtRecepcionadas.Visible = false;
            // 
            // Btn_AceptarRec
            // 
            this.Btn_AceptarRec.Location = new System.Drawing.Point(375, 287);
            this.Btn_AceptarRec.Name = "Btn_AceptarRec";
            this.Btn_AceptarRec.Size = new System.Drawing.Size(75, 32);
            this.Btn_AceptarRec.TabIndex = 4;
            this.Btn_AceptarRec.Text = "Aceptar";
            this.Btn_AceptarRec.UseVisualStyleBackColor = true;
            this.Btn_AceptarRec.Click += new System.EventHandler(this.Btn_AceptarRec_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(14, 66);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(622, 17);
            this.label8.TabIndex = 3;
            this.label8.Text = "Finalmente, informe de esta situación por mail a Adquisiciones para realizar el r" +
    "eclamo respectivo";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(14, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(798, 17);
            this.label7.TabIndex = 2;
            this.label7.Text = "Imprima nuevas etiquetas utilizando la información de la etiqueta QR con problema" +
    "s , pero cambiando el número de paquete.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(111, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(562, 17);
            this.label6.TabIndex = 1;
            this.label6.Text = "La(s) siguiente(s) etiqueta(s) QR ha(n) sido recepcionada(s) anteriormente:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Dtg_Et_recepcionadas);
            this.groupBox1.Location = new System.Drawing.Point(14, 86);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(796, 197);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // Dtg_Et_recepcionadas
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Dtg_Et_recepcionadas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Dtg_Et_recepcionadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Dtg_Et_recepcionadas.DefaultCellStyle = dataGridViewCellStyle2;
            this.Dtg_Et_recepcionadas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Dtg_Et_recepcionadas.Location = new System.Drawing.Point(3, 16);
            this.Dtg_Et_recepcionadas.Name = "Dtg_Et_recepcionadas";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Dtg_Et_recepcionadas.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.Dtg_Et_recepcionadas.Size = new System.Drawing.Size(790, 178);
            this.Dtg_Et_recepcionadas.TabIndex = 0;
            // 
            // Dtg_Etiquetas
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Dtg_Etiquetas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.Dtg_Etiquetas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Dtg_Etiquetas.DefaultCellStyle = dataGridViewCellStyle5;
            this.Dtg_Etiquetas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Dtg_Etiquetas.Location = new System.Drawing.Point(3, 16);
            this.Dtg_Etiquetas.Name = "Dtg_Etiquetas";
            this.Dtg_Etiquetas.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Dtg_Etiquetas.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.Dtg_Etiquetas.Size = new System.Drawing.Size(1020, 349);
            this.Dtg_Etiquetas.TabIndex = 0;
            this.Dtg_Etiquetas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dtg_Etiquetas_CellDoubleClick);
            // 
            // Tx_EtiquetaAza
            // 
            this.Tx_EtiquetaAza.Location = new System.Drawing.Point(777, 74);
            this.Tx_EtiquetaAza.MaxLength = 100;
            this.Tx_EtiquetaAza.Name = "Tx_EtiquetaAza";
            this.Tx_EtiquetaAza.Size = new System.Drawing.Size(261, 20);
            this.Tx_EtiquetaAza.TabIndex = 7;
            this.Tx_EtiquetaAza.TextChanged += new System.EventHandler(this.Tx_EtiquetaAza_TextChanged);
            this.Tx_EtiquetaAza.Validating += new System.ComponentModel.CancelEventHandler(this.Tx_EtiquetaAza_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(782, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Trama etiqueta QR";
            // 
            // Btn_grabar
            // 
            this.Btn_grabar.Location = new System.Drawing.Point(964, 18);
            this.Btn_grabar.Name = "Btn_grabar";
            this.Btn_grabar.Size = new System.Drawing.Size(75, 37);
            this.Btn_grabar.TabIndex = 11;
            this.Btn_grabar.Text = "Grabar";
            this.Btn_grabar.UseVisualStyleBackColor = true;
            this.Btn_grabar.Click += new System.EventHandler(this.Btn_grabar_Click);
            // 
            // Btn_InicioL
            // 
            this.Btn_InicioL.Location = new System.Drawing.Point(777, 18);
            this.Btn_InicioL.Name = "Btn_InicioL";
            this.Btn_InicioL.Size = new System.Drawing.Size(75, 37);
            this.Btn_InicioL.TabIndex = 12;
            this.Btn_InicioL.Text = "Inicio Lecturas";
            this.Btn_InicioL.UseVisualStyleBackColor = true;
            this.Btn_InicioL.Click += new System.EventHandler(this.Btn_InicioL_Click);
            // 
            // Btn_Nueva
            // 
            this.Btn_Nueva.Location = new System.Drawing.Point(867, 18);
            this.Btn_Nueva.Name = "Btn_Nueva";
            this.Btn_Nueva.Size = new System.Drawing.Size(75, 37);
            this.Btn_Nueva.TabIndex = 13;
            this.Btn_Nueva.Text = "Nuevo";
            this.Btn_Nueva.UseVisualStyleBackColor = true;
            this.Btn_Nueva.Click += new System.EventHandler(this.Btn_Nueva_Click);
            // 
            // Frm_DesdeArchivo
            // 
            this.Frm_DesdeArchivo.Location = new System.Drawing.Point(378, -2);
            this.Frm_DesdeArchivo.Name = "Frm_DesdeArchivo";
            this.Frm_DesdeArchivo.Size = new System.Drawing.Size(219, 21);
            this.Frm_DesdeArchivo.TabIndex = 14;
            this.Frm_DesdeArchivo.Text = "Importar desde Archivo";
            this.Frm_DesdeArchivo.UseVisualStyleBackColor = true;
            this.Frm_DesdeArchivo.Visible = false;
            this.Frm_DesdeArchivo.Click += new System.EventHandler(this.Frm_DesdeArchivo_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Btn_GrabaTol);
            this.groupBox3.Controls.Add(this.Gr_autorizacion);
            this.groupBox3.Controls.Add(this.Btn_Cambiar);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.Tx_tolerancia);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Location = new System.Drawing.Point(16, 99);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1020, 59);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Toterancia";
            // 
            // Btn_GrabaTol
            // 
            this.Btn_GrabaTol.Location = new System.Drawing.Point(503, 14);
            this.Btn_GrabaTol.Name = "Btn_GrabaTol";
            this.Btn_GrabaTol.Size = new System.Drawing.Size(78, 37);
            this.Btn_GrabaTol.TabIndex = 14;
            this.Btn_GrabaTol.Text = "Grabar Tolerancia";
            this.Btn_GrabaTol.UseVisualStyleBackColor = true;
            this.Btn_GrabaTol.Visible = false;
            this.Btn_GrabaTol.Click += new System.EventHandler(this.Btn_GrabaTol_Click);
            // 
            // Gr_autorizacion
            // 
            this.Gr_autorizacion.BackColor = System.Drawing.Color.Red;
            this.Gr_autorizacion.Controls.Add(this.Btn_aceptar);
            this.Gr_autorizacion.Controls.Add(this.label11);
            this.Gr_autorizacion.Controls.Add(this.Tx_clave);
            this.Gr_autorizacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gr_autorizacion.ForeColor = System.Drawing.Color.White;
            this.Gr_autorizacion.Location = new System.Drawing.Point(595, 7);
            this.Gr_autorizacion.Name = "Gr_autorizacion";
            this.Gr_autorizacion.Size = new System.Drawing.Size(386, 46);
            this.Gr_autorizacion.TabIndex = 13;
            this.Gr_autorizacion.TabStop = false;
            this.Gr_autorizacion.Text = "Clave de autorización";
            this.Gr_autorizacion.Visible = false;
            // 
            // Btn_aceptar
            // 
            this.Btn_aceptar.ForeColor = System.Drawing.Color.Black;
            this.Btn_aceptar.Location = new System.Drawing.Point(296, 8);
            this.Btn_aceptar.Name = "Btn_aceptar";
            this.Btn_aceptar.Size = new System.Drawing.Size(67, 32);
            this.Btn_aceptar.TabIndex = 15;
            this.Btn_aceptar.Text = "Aceptar";
            this.Btn_aceptar.UseVisualStyleBackColor = true;
            this.Btn_aceptar.Click += new System.EventHandler(this.Btn_aceptar_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(36, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(98, 15);
            this.label11.TabIndex = 1;
            this.label11.Text = "Ingrese Clave ";
            // 
            // Tx_clave
            // 
            this.Tx_clave.Location = new System.Drawing.Point(151, 17);
            this.Tx_clave.Name = "Tx_clave";
            this.Tx_clave.PasswordChar = '*';
            this.Tx_clave.Size = new System.Drawing.Size(120, 21);
            this.Tx_clave.TabIndex = 0;
            // 
            // Btn_Cambiar
            // 
            this.Btn_Cambiar.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Cambiar.Location = new System.Drawing.Point(396, 11);
            this.Btn_Cambiar.Name = "Btn_Cambiar";
            this.Btn_Cambiar.Size = new System.Drawing.Size(89, 42);
            this.Btn_Cambiar.TabIndex = 12;
            this.Btn_Cambiar.Text = "Modificar Tolerancia";
            this.Btn_Cambiar.UseVisualStyleBackColor = true;
            this.Btn_Cambiar.Click += new System.EventHandler(this.Btn_Cambiar_Click);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(330, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 17);
            this.label10.TabIndex = 11;
            this.label10.Text = "KGS";
            // 
            // Tx_tolerancia
            // 
            this.Tx_tolerancia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tx_tolerancia.Location = new System.Drawing.Point(283, 25);
            this.Tx_tolerancia.Multiline = true;
            this.Tx_tolerancia.Name = "Tx_tolerancia";
            this.Tx_tolerancia.ReadOnly = true;
            this.Tx_tolerancia.Size = new System.Drawing.Size(36, 20);
            this.Tx_tolerancia.TabIndex = 10;
            this.Tx_tolerancia.Text = "5";
            this.Tx_tolerancia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(12, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(263, 17);
            this.label9.TabIndex = 9;
            this.label9.Text = "Total Toterancia Permitida  ( + / - )";
            // 
            // Frm_RecepcionMP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 540);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.Frm_DesdeArchivo);
            this.Controls.Add(this.Btn_Nueva);
            this.Controls.Add(this.Btn_InicioL);
            this.Controls.Add(this.Btn_grabar);
            this.Controls.Add(this.Tx_EtiquetaAza);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.Gr_datos);
            this.Name = "Frm_RecepcionMP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formulario de  Recepción de Materia  Prima";
            this.Load += new System.EventHandler(this.Frm_RecepcionMP_Load);
            this.Gr_datos.ResumeLayout(false);
            this.Gr_datos.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.Pnl_EtRecepcionadas.ResumeLayout(false);
            this.Pnl_EtRecepcionadas.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_Et_recepcionadas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_Etiquetas)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.Gr_autorizacion.ResumeLayout(false);
            this.Gr_autorizacion.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox Gr_datos;
        private System.Windows.Forms.TextBox Tx_GuiaDesp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Tx_OC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView Dtg_Etiquetas;
        private System.Windows.Forms.TextBox Tx_EtiquetaAza;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Tx_TotalKgsGD;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker Dtp_Fecha;
        private System.Windows.Forms.Button Btn_grabar;
        private System.Windows.Forms.Button Btn_InicioL;
        private System.Windows.Forms.Button Btn_Nueva;
        private System.Windows.Forms.ComboBox Cmb_Sucursal;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button Frm_DesdeArchivo;
        private System.Windows.Forms.Panel Pnl_EtRecepcionadas;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView Dtg_Et_recepcionadas;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button Btn_Cambiar;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox Tx_tolerancia;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button Btn_GrabaTol;
        private System.Windows.Forms.GroupBox Gr_autorizacion;
        private System.Windows.Forms.Button Btn_aceptar;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox Tx_clave;
        private System.Windows.Forms.Button Btn_AceptarRec;
    }
}