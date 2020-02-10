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
            this.Dtg_Etiquetas = new System.Windows.Forms.DataGridView();
            this.Tx_EtiquetaAza = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Tx_largo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.Tx_PesoBulto = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.Tx_CB = new System.Windows.Forms.TextBox();
            this.Btn_ImprimeQR = new System.Windows.Forms.Button();
            this.Tx_diametro = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.Tx_producto = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.Tx_nroBulto = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Tx_lote = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Btn_grabar = new System.Windows.Forms.Button();
            this.Btn_InicioL = new System.Windows.Forms.Button();
            this.Btn_Nueva = new System.Windows.Forms.Button();
            this.Frm_DesdeArchivo = new System.Windows.Forms.Button();
            this.Gr_datos.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_Etiquetas)).BeginInit();
            this.groupBox3.SuspendLayout();
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
            this.Gr_datos.Size = new System.Drawing.Size(747, 83);
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
            this.groupBox2.Controls.Add(this.Dtg_Etiquetas);
            this.groupBox2.Location = new System.Drawing.Point(13, 103);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1013, 415);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Etiquetas AZA ingresadas";
            // 
            // Dtg_Etiquetas
            // 
            this.Dtg_Etiquetas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dtg_Etiquetas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Dtg_Etiquetas.Location = new System.Drawing.Point(3, 16);
            this.Dtg_Etiquetas.Name = "Dtg_Etiquetas";
            this.Dtg_Etiquetas.ReadOnly = true;
            this.Dtg_Etiquetas.Size = new System.Drawing.Size(1007, 396);
            this.Dtg_Etiquetas.TabIndex = 0;
            this.Dtg_Etiquetas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dtg_Etiquetas_CellDoubleClick);
            // 
            // Tx_EtiquetaAza
            // 
            this.Tx_EtiquetaAza.Location = new System.Drawing.Point(777, 82);
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
            this.label4.Location = new System.Drawing.Point(782, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Etiqueta Aza";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.Tx_largo);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.Tx_PesoBulto);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.Tx_CB);
            this.groupBox3.Controls.Add(this.Btn_ImprimeQR);
            this.groupBox3.Controls.Add(this.Tx_diametro);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.Tx_producto);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.Tx_nroBulto);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.Tx_lote);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(896, 141);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(140, 374);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Datos Etiqueta aza";
            this.groupBox3.Visible = false;
            // 
            // Tx_largo
            // 
            this.Tx_largo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Tx_largo.Location = new System.Drawing.Point(11, 222);
            this.Tx_largo.MaxLength = 100;
            this.Tx_largo.Name = "Tx_largo";
            this.Tx_largo.Size = new System.Drawing.Size(96, 20);
            this.Tx_largo.TabIndex = 20;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 206);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(30, 13);
            this.label11.TabIndex = 19;
            this.label11.Text = "largo";
            // 
            // Tx_PesoBulto
            // 
            this.Tx_PesoBulto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Tx_PesoBulto.Location = new System.Drawing.Point(11, 271);
            this.Tx_PesoBulto.MaxLength = 100;
            this.Tx_PesoBulto.Name = "Tx_PesoBulto";
            this.Tx_PesoBulto.Size = new System.Drawing.Size(96, 20);
            this.Tx_PesoBulto.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 255);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "Peso Bulto";
            // 
            // Tx_CB
            // 
            this.Tx_CB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Tx_CB.Location = new System.Drawing.Point(7, 344);
            this.Tx_CB.MaxLength = 100;
            this.Tx_CB.Name = "Tx_CB";
            this.Tx_CB.Size = new System.Drawing.Size(124, 20);
            this.Tx_CB.TabIndex = 16;
            // 
            // Btn_ImprimeQR
            // 
            this.Btn_ImprimeQR.Location = new System.Drawing.Point(13, 311);
            this.Btn_ImprimeQR.Name = "Btn_ImprimeQR";
            this.Btn_ImprimeQR.Size = new System.Drawing.Size(102, 22);
            this.Btn_ImprimeQR.TabIndex = 15;
            this.Btn_ImprimeQR.Text = "Genera";
            this.Btn_ImprimeQR.UseVisualStyleBackColor = true;
            this.Btn_ImprimeQR.Click += new System.EventHandler(this.Btn_ImprimeQR_Click);
            // 
            // Tx_diametro
            // 
            this.Tx_diametro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Tx_diametro.Location = new System.Drawing.Point(8, 180);
            this.Tx_diametro.MaxLength = 100;
            this.Tx_diametro.Name = "Tx_diametro";
            this.Tx_diametro.Size = new System.Drawing.Size(96, 20);
            this.Tx_diametro.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 164);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Diametro";
            // 
            // Tx_producto
            // 
            this.Tx_producto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Tx_producto.Location = new System.Drawing.Point(6, 134);
            this.Tx_producto.MaxLength = 100;
            this.Tx_producto.Name = "Tx_producto";
            this.Tx_producto.Size = new System.Drawing.Size(124, 20);
            this.Tx_producto.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 118);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Producto";
            // 
            // Tx_nroBulto
            // 
            this.Tx_nroBulto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Tx_nroBulto.Location = new System.Drawing.Point(6, 81);
            this.Tx_nroBulto.MaxLength = 100;
            this.Tx_nroBulto.Name = "Tx_nroBulto";
            this.Tx_nroBulto.Size = new System.Drawing.Size(100, 20);
            this.Tx_nroBulto.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "NroBulto";
            // 
            // Tx_lote
            // 
            this.Tx_lote.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Tx_lote.Location = new System.Drawing.Point(6, 32);
            this.Tx_lote.MaxLength = 100;
            this.Tx_lote.Name = "Tx_lote";
            this.Tx_lote.Size = new System.Drawing.Size(100, 20);
            this.Tx_lote.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Lote";
            // 
            // Btn_grabar
            // 
            this.Btn_grabar.Location = new System.Drawing.Point(964, 18);
            this.Btn_grabar.Name = "Btn_grabar";
            this.Btn_grabar.Size = new System.Drawing.Size(75, 46);
            this.Btn_grabar.TabIndex = 11;
            this.Btn_grabar.Text = "Grabar";
            this.Btn_grabar.UseVisualStyleBackColor = true;
            this.Btn_grabar.Click += new System.EventHandler(this.Btn_grabar_Click);
            // 
            // Btn_InicioL
            // 
            this.Btn_InicioL.Location = new System.Drawing.Point(777, 18);
            this.Btn_InicioL.Name = "Btn_InicioL";
            this.Btn_InicioL.Size = new System.Drawing.Size(75, 46);
            this.Btn_InicioL.TabIndex = 12;
            this.Btn_InicioL.Text = "Inicio Lecturas";
            this.Btn_InicioL.UseVisualStyleBackColor = true;
            this.Btn_InicioL.Click += new System.EventHandler(this.Btn_InicioL_Click);
            // 
            // Btn_Nueva
            // 
            this.Btn_Nueva.Location = new System.Drawing.Point(867, 18);
            this.Btn_Nueva.Name = "Btn_Nueva";
            this.Btn_Nueva.Size = new System.Drawing.Size(75, 46);
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
            // Frm_RecepcionMP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 522);
            this.Controls.Add(this.Frm_DesdeArchivo);
            this.Controls.Add(this.Btn_Nueva);
            this.Controls.Add(this.Btn_InicioL);
            this.Controls.Add(this.Btn_grabar);
            this.Controls.Add(this.groupBox3);
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
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_Etiquetas)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox Tx_diametro;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox Tx_producto;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Tx_nroBulto;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox Tx_lote;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button Btn_ImprimeQR;
        private System.Windows.Forms.TextBox Tx_CB;
        private System.Windows.Forms.TextBox Tx_PesoBulto;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox Tx_largo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker Dtp_Fecha;
        private System.Windows.Forms.Button Btn_grabar;
        private System.Windows.Forms.Button Btn_InicioL;
        private System.Windows.Forms.Button Btn_Nueva;
        private System.Windows.Forms.ComboBox Cmb_Sucursal;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button Frm_DesdeArchivo;
    }
}