namespace Metalurgica
{
    partial class Frm_ReEtiquetar
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Lbl_Estado = new System.Windows.Forms.Label();
            this.Dgt_DatosEtiqueta = new System.Windows.Forms.DataGridView();
            this.Tx_PaqueteColada = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Btn_Re_Etiquetar = new System.Windows.Forms.Button();
            this.Tx_KilosPorAs = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Tx_BarrasPorAs = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Tx_KilosTotales = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Tx_BarrasTotales = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Dtg_NuevosPaq = new System.Windows.Forms.DataGridView();
            this.Tx_NroPaquetes = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.DTG_PaquetesColada = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Btn_Imprimir = new System.Windows.Forms.Button();
            this.Btn_Salir = new System.Windows.Forms.Button();
            this.Btn_BuscarColada = new System.Windows.Forms.Button();
            this.Cmb_Proced = new System.Windows.Forms.ComboBox();
            this.Tx_guiaDesp = new System.Windows.Forms.TextBox();
            this.Tx_Colada = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.Tx_Certificado = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.Tx_IdColada = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Tx_IdPaqueteCol = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgt_DatosEtiqueta)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_NuevosPaq)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DTG_PaquetesColada)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.Lbl_Estado);
            this.groupBox1.Controls.Add(this.Dgt_DatosEtiqueta);
            this.groupBox1.Controls.Add(this.Tx_PaqueteColada);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(787, 143);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del Paquete a dividir";
            // 
            // Lbl_Estado
            // 
            this.Lbl_Estado.AutoSize = true;
            this.Lbl_Estado.Location = new System.Drawing.Point(327, 22);
            this.Lbl_Estado.Name = "Lbl_Estado";
            this.Lbl_Estado.Size = new System.Drawing.Size(119, 13);
            this.Lbl_Estado.TabIndex = 3;
            this.Lbl_Estado.Text = "Código Paquete Colada";
            // 
            // Dgt_DatosEtiqueta
            // 
            this.Dgt_DatosEtiqueta.AllowUserToAddRows = false;
            this.Dgt_DatosEtiqueta.AllowUserToDeleteRows = false;
            this.Dgt_DatosEtiqueta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Dgt_DatosEtiqueta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgt_DatosEtiqueta.Location = new System.Drawing.Point(6, 49);
            this.Dgt_DatosEtiqueta.Name = "Dgt_DatosEtiqueta";
            this.Dgt_DatosEtiqueta.ReadOnly = true;
            this.Dgt_DatosEtiqueta.Size = new System.Drawing.Size(774, 73);
            this.Dgt_DatosEtiqueta.TabIndex = 2;
            // 
            // Tx_PaqueteColada
            // 
            this.Tx_PaqueteColada.Location = new System.Drawing.Point(188, 19);
            this.Tx_PaqueteColada.Name = "Tx_PaqueteColada";
            this.Tx_PaqueteColada.Size = new System.Drawing.Size(109, 20);
            this.Tx_PaqueteColada.TabIndex = 1;
            this.Tx_PaqueteColada.TextChanged += new System.EventHandler(this.Tx_PaqueteColada_TextChanged);
            this.Tx_PaqueteColada.Validating += new System.ComponentModel.CancelEventHandler(this.Tx_PaqueteColada_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código Paquete Colada";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.Btn_Re_Etiquetar);
            this.groupBox2.Controls.Add(this.Tx_KilosPorAs);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.Tx_BarrasPorAs);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.Tx_KilosTotales);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.Tx_BarrasTotales);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.Dtg_NuevosPaq);
            this.groupBox2.Controls.Add(this.Tx_NroPaquetes);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 167);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(778, 329);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos de los nuevos Paquetes";
            // 
            // Btn_Re_Etiquetar
            // 
            this.Btn_Re_Etiquetar.Enabled = false;
            this.Btn_Re_Etiquetar.Location = new System.Drawing.Point(635, 9);
            this.Btn_Re_Etiquetar.Name = "Btn_Re_Etiquetar";
            this.Btn_Re_Etiquetar.Size = new System.Drawing.Size(96, 44);
            this.Btn_Re_Etiquetar.TabIndex = 13;
            this.Btn_Re_Etiquetar.Text = "Crear Paquetes Colada";
            this.Btn_Re_Etiquetar.UseVisualStyleBackColor = true;
            this.Btn_Re_Etiquetar.Click += new System.EventHandler(this.Btn_Re_Etiquetar_Click);
            // 
            // Tx_KilosPorAs
            // 
            this.Tx_KilosPorAs.Location = new System.Drawing.Point(529, 32);
            this.Tx_KilosPorAs.Name = "Tx_KilosPorAs";
            this.Tx_KilosPorAs.ReadOnly = true;
            this.Tx_KilosPorAs.Size = new System.Drawing.Size(61, 20);
            this.Tx_KilosPorAs.TabIndex = 12;
            this.Tx_KilosPorAs.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(526, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Kilos Totales";
            // 
            // Tx_BarrasPorAs
            // 
            this.Tx_BarrasPorAs.Location = new System.Drawing.Point(320, 32);
            this.Tx_BarrasPorAs.Name = "Tx_BarrasPorAs";
            this.Tx_BarrasPorAs.ReadOnly = true;
            this.Tx_BarrasPorAs.Size = new System.Drawing.Size(35, 20);
            this.Tx_BarrasPorAs.TabIndex = 10;
            this.Tx_BarrasPorAs.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(290, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Nro. Barras Por Asignar";
            // 
            // Tx_KilosTotales
            // 
            this.Tx_KilosTotales.Location = new System.Drawing.Point(436, 32);
            this.Tx_KilosTotales.Name = "Tx_KilosTotales";
            this.Tx_KilosTotales.ReadOnly = true;
            this.Tx_KilosTotales.Size = new System.Drawing.Size(61, 20);
            this.Tx_KilosTotales.TabIndex = 8;
            this.Tx_KilosTotales.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(432, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Kilos Totales";
            // 
            // Tx_BarrasTotales
            // 
            this.Tx_BarrasTotales.Location = new System.Drawing.Point(219, 32);
            this.Tx_BarrasTotales.Name = "Tx_BarrasTotales";
            this.Tx_BarrasTotales.ReadOnly = true;
            this.Tx_BarrasTotales.Size = new System.Drawing.Size(32, 20);
            this.Tx_BarrasTotales.TabIndex = 6;
            this.Tx_BarrasTotales.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(186, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nro. Barras Totales";
            // 
            // Dtg_NuevosPaq
            // 
            this.Dtg_NuevosPaq.AllowUserToAddRows = false;
            this.Dtg_NuevosPaq.AllowUserToDeleteRows = false;
            this.Dtg_NuevosPaq.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Dtg_NuevosPaq.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dtg_NuevosPaq.Location = new System.Drawing.Point(6, 55);
            this.Dtg_NuevosPaq.Name = "Dtg_NuevosPaq";
            this.Dtg_NuevosPaq.Size = new System.Drawing.Size(765, 228);
            this.Dtg_NuevosPaq.TabIndex = 4;
            this.Dtg_NuevosPaq.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dtg_NuevosPaq_CellValidated);
            this.Dtg_NuevosPaq.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.Dtg_NuevosPaq_CellValidating);
            // 
            // Tx_NroPaquetes
            // 
            this.Tx_NroPaquetes.Location = new System.Drawing.Point(126, 19);
            this.Tx_NroPaquetes.Name = "Tx_NroPaquetes";
            this.Tx_NroPaquetes.Size = new System.Drawing.Size(50, 20);
            this.Tx_NroPaquetes.TabIndex = 3;
            this.Tx_NroPaquetes.Text = "0";
            this.Tx_NroPaquetes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Tx_NroPaquetes_KeyPress);
            this.Tx_NroPaquetes.Validating += new System.ComponentModel.CancelEventHandler(this.Tx_NroPaquetes_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nro. Paquetes a Crear";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(7, 8);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(853, 528);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(845, 502);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "División de Barras";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(845, 502);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Re Impresión de Etiquetas";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.DTG_PaquetesColada);
            this.groupBox5.Location = new System.Drawing.Point(3, 121);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(830, 375);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Paquetes de la Coladas";
            // 
            // DTG_PaquetesColada
            // 
            this.DTG_PaquetesColada.AllowUserToAddRows = false;
            this.DTG_PaquetesColada.AllowUserToDeleteRows = false;
            this.DTG_PaquetesColada.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DTG_PaquetesColada.Location = new System.Drawing.Point(6, 16);
            this.DTG_PaquetesColada.Name = "DTG_PaquetesColada";
            this.DTG_PaquetesColada.Size = new System.Drawing.Size(818, 351);
            this.DTG_PaquetesColada.TabIndex = 0;
            this.DTG_PaquetesColada.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DTG_PaquetesColada_CellClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.Btn_Imprimir);
            this.groupBox3.Controls.Add(this.Btn_Salir);
            this.groupBox3.Controls.Add(this.Btn_BuscarColada);
            this.groupBox3.Controls.Add(this.Cmb_Proced);
            this.groupBox3.Controls.Add(this.Tx_guiaDesp);
            this.groupBox3.Controls.Add(this.Tx_Colada);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.Tx_Certificado);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.Tx_IdColada);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.Tx_IdPaqueteCol);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(7, 7);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(830, 107);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Buscador de coladas para  Re - Imprimir";
            // 
            // Btn_Imprimir
            // 
            this.Btn_Imprimir.Location = new System.Drawing.Point(659, 21);
            this.Btn_Imprimir.Name = "Btn_Imprimir";
            this.Btn_Imprimir.Size = new System.Drawing.Size(75, 69);
            this.Btn_Imprimir.TabIndex = 26;
            this.Btn_Imprimir.Text = "Imprimir";
            this.Btn_Imprimir.UseVisualStyleBackColor = true;
            this.Btn_Imprimir.Click += new System.EventHandler(this.Btn_Imprimir_Click);
            // 
            // Btn_Salir
            // 
            this.Btn_Salir.Location = new System.Drawing.Point(743, 21);
            this.Btn_Salir.Name = "Btn_Salir";
            this.Btn_Salir.Size = new System.Drawing.Size(75, 69);
            this.Btn_Salir.TabIndex = 25;
            this.Btn_Salir.Text = "Salir";
            this.Btn_Salir.UseVisualStyleBackColor = true;
            this.Btn_Salir.Click += new System.EventHandler(this.Btn_Salir_Click);
            // 
            // Btn_BuscarColada
            // 
            this.Btn_BuscarColada.Location = new System.Drawing.Point(569, 21);
            this.Btn_BuscarColada.Name = "Btn_BuscarColada";
            this.Btn_BuscarColada.Size = new System.Drawing.Size(75, 69);
            this.Btn_BuscarColada.TabIndex = 24;
            this.Btn_BuscarColada.Text = "Buscar";
            this.Btn_BuscarColada.UseVisualStyleBackColor = true;
            this.Btn_BuscarColada.Click += new System.EventHandler(this.Btn_BuscarColada_Click);
            // 
            // Cmb_Proced
            // 
            this.Cmb_Proced.Enabled = false;
            this.Cmb_Proced.FormattingEnabled = true;
            this.Cmb_Proced.Location = new System.Drawing.Point(171, 70);
            this.Cmb_Proced.Name = "Cmb_Proced";
            this.Cmb_Proced.Size = new System.Drawing.Size(369, 21);
            this.Cmb_Proced.TabIndex = 23;
            // 
            // Tx_guiaDesp
            // 
            this.Tx_guiaDesp.Location = new System.Drawing.Point(319, 39);
            this.Tx_guiaDesp.Name = "Tx_guiaDesp";
            this.Tx_guiaDesp.ReadOnly = true;
            this.Tx_guiaDesp.Size = new System.Drawing.Size(100, 20);
            this.Tx_guiaDesp.TabIndex = 18;
            // 
            // Tx_Colada
            // 
            this.Tx_Colada.Location = new System.Drawing.Point(215, 39);
            this.Tx_Colada.Name = "Tx_Colada";
            this.Tx_Colada.ReadOnly = true;
            this.Tx_Colada.Size = new System.Drawing.Size(83, 20);
            this.Tx_Colada.TabIndex = 7;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(36, 78);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 13);
            this.label12.TabIndex = 14;
            this.label12.Text = "Procedencia";
            // 
            // Tx_Certificado
            // 
            this.Tx_Certificado.Location = new System.Drawing.Point(440, 39);
            this.Tx_Certificado.Name = "Tx_Certificado";
            this.Tx_Certificado.ReadOnly = true;
            this.Tx_Certificado.Size = new System.Drawing.Size(100, 20);
            this.Tx_Certificado.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(333, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "Guía Desp.";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(443, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 13);
            this.label11.TabIndex = 6;
            this.label11.Text = "Nro. Certificado";
            // 
            // Tx_IdColada
            // 
            this.Tx_IdColada.Location = new System.Drawing.Point(147, 38);
            this.Tx_IdColada.Name = "Tx_IdColada";
            this.Tx_IdColada.ReadOnly = true;
            this.Tx_IdColada.Size = new System.Drawing.Size(50, 20);
            this.Tx_IdColada.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(220, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Nro. Colada";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(146, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Id Colada";
            // 
            // Tx_IdPaqueteCol
            // 
            this.Tx_IdPaqueteCol.Location = new System.Drawing.Point(14, 39);
            this.Tx_IdPaqueteCol.Name = "Tx_IdPaqueteCol";
            this.Tx_IdPaqueteCol.Size = new System.Drawing.Size(109, 20);
            this.Tx_IdPaqueteCol.TabIndex = 3;
            this.Tx_IdPaqueteCol.TextChanged += new System.EventHandler(this.Tx_IdPaqueteCol_TextChanged);
            this.Tx_IdPaqueteCol.Validating += new System.ComponentModel.CancelEventHandler(this.Tx_IdPaqueteCol_Validating);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Código Paquete Colada";
            // 
            // Frm_ReEtiquetar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 538);
            this.Controls.Add(this.tabControl1);
            this.Name = "Frm_ReEtiquetar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formulario para  división de Paquetes  Colada";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgt_DatosEtiqueta)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_NuevosPaq)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DTG_PaquetesColada)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox Tx_PaqueteColada;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView Dgt_DatosEtiqueta;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView Dtg_NuevosPaq;
        private System.Windows.Forms.TextBox Tx_NroPaquetes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Lbl_Estado;
        private System.Windows.Forms.TextBox Tx_KilosTotales;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Tx_BarrasTotales;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Tx_KilosPorAs;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Tx_BarrasPorAs;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Btn_Re_Etiquetar;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView DTG_PaquetesColada;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button Btn_Imprimir;
        private System.Windows.Forms.Button Btn_Salir;
        private System.Windows.Forms.Button Btn_BuscarColada;
        internal System.Windows.Forms.ComboBox Cmb_Proced;
        internal System.Windows.Forms.TextBox Tx_guiaDesp;
        internal System.Windows.Forms.TextBox Tx_Colada;
        internal System.Windows.Forms.Label label12;
        internal System.Windows.Forms.TextBox Tx_Certificado;
        internal System.Windows.Forms.Label label10;
        internal System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox Tx_IdColada;
        internal System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Tx_IdPaqueteCol;
        private System.Windows.Forms.Label label7;
    }
}