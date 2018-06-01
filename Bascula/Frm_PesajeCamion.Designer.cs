namespace Metalurgica.Bascula
{
    partial class Frm_PesajeCamion
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
            this.Tx_sql = new System.Windows.Forms.TextBox();
            this.Tx_DiferenciaKilos = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.Tx_KgsCargados = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.Tx_ToleranciaReal = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.Tx_Semaforo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.Tx_ToleranciaBascula = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.Btn_PesoBruto = new System.Windows.Forms.Button();
            this.Cmb_Patente = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Rb_Carga = new System.Windows.Forms.RadioButton();
            this.Rb_Tara = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.Dtp_FechaActual = new System.Windows.Forms.DateTimePicker();
            this.Btn_ObtenerTara = new System.Windows.Forms.Button();
            this.Tx_Carga = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Tx_Bruto = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Tx_Tara = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Tx_Patente = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Btn_Grabar = new System.Windows.Forms.Button();
            this.Btn_Salir = new System.Windows.Forms.Button();
            this.Btn_GeneraDatos = new System.Windows.Forms.Button();
            this.Tx_IdCorrCarga = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.Tx_IdCorrTara = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.Tx_IdCorrCarga);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.Tx_IdCorrTara);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.Tx_sql);
            this.groupBox1.Controls.Add(this.Tx_DiferenciaKilos);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.Tx_KgsCargados);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.Tx_ToleranciaReal);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.Tx_Semaforo);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.Tx_ToleranciaBascula);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.Btn_PesoBruto);
            this.groupBox1.Controls.Add(this.Cmb_Patente);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.Dtp_FechaActual);
            this.groupBox1.Controls.Add(this.Btn_ObtenerTara);
            this.groupBox1.Controls.Add(this.Tx_Carga);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.Tx_Bruto);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.Tx_Tara);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Tx_Patente);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(8, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(579, 437);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ingrese los datos del pesaje de Camión";
            // 
            // Tx_sql
            // 
            this.Tx_sql.Location = new System.Drawing.Point(356, 388);
            this.Tx_sql.Name = "Tx_sql";
            this.Tx_sql.Size = new System.Drawing.Size(175, 23);
            this.Tx_sql.TabIndex = 28;
            // 
            // Tx_DiferenciaKilos
            // 
            this.Tx_DiferenciaKilos.Location = new System.Drawing.Point(390, 357);
            this.Tx_DiferenciaKilos.MaxLength = 7;
            this.Tx_DiferenciaKilos.Name = "Tx_DiferenciaKilos";
            this.Tx_DiferenciaKilos.ReadOnly = true;
            this.Tx_DiferenciaKilos.Size = new System.Drawing.Size(76, 23);
            this.Tx_DiferenciaKilos.TabIndex = 27;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(234, 361);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(110, 15);
            this.label12.TabIndex = 26;
            this.label12.Text = "Diferencia de KIlos";
            // 
            // Tx_KgsCargados
            // 
            this.Tx_KgsCargados.Location = new System.Drawing.Point(391, 317);
            this.Tx_KgsCargados.MaxLength = 7;
            this.Tx_KgsCargados.Name = "Tx_KgsCargados";
            this.Tx_KgsCargados.ReadOnly = true;
            this.Tx_KgsCargados.Size = new System.Drawing.Size(76, 23);
            this.Tx_KgsCargados.TabIndex = 25;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(227, 320);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(158, 15);
            this.label11.TabIndex = 24;
            this.label11.Text = "Kilos Cargados Por sistema";
            // 
            // Tx_ToleranciaReal
            // 
            this.Tx_ToleranciaReal.Location = new System.Drawing.Point(425, 280);
            this.Tx_ToleranciaReal.MaxLength = 7;
            this.Tx_ToleranciaReal.Name = "Tx_ToleranciaReal";
            this.Tx_ToleranciaReal.ReadOnly = true;
            this.Tx_ToleranciaReal.Size = new System.Drawing.Size(42, 23);
            this.Tx_ToleranciaReal.TabIndex = 23;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(382, 258);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(134, 17);
            this.label10.TabIndex = 22;
            this.label10.Text = "Tolerancia Real (%)";
            // 
            // Tx_Semaforo
            // 
            this.Tx_Semaforo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Tx_Semaforo.Location = new System.Drawing.Point(247, 406);
            this.Tx_Semaforo.Name = "Tx_Semaforo";
            this.Tx_Semaforo.ReadOnly = true;
            this.Tx_Semaforo.Size = new System.Drawing.Size(78, 23);
            this.Tx_Semaforo.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(70, 406);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(171, 17);
            this.label9.TabIndex = 20;
            this.label9.Text = "Estado Despacho Camión";
            // 
            // Tx_ToleranciaBascula
            // 
            this.Tx_ToleranciaBascula.Location = new System.Drawing.Point(425, 220);
            this.Tx_ToleranciaBascula.MaxLength = 7;
            this.Tx_ToleranciaBascula.Name = "Tx_ToleranciaBascula";
            this.Tx_ToleranciaBascula.ReadOnly = true;
            this.Tx_ToleranciaBascula.Size = new System.Drawing.Size(42, 23);
            this.Tx_ToleranciaBascula.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(372, 200);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(155, 17);
            this.label8.TabIndex = 18;
            this.label8.Text = "Tolerancia Bascula (%)";
            // 
            // Btn_PesoBruto
            // 
            this.Btn_PesoBruto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_PesoBruto.Location = new System.Drawing.Point(234, 260);
            this.Btn_PesoBruto.Name = "Btn_PesoBruto";
            this.Btn_PesoBruto.Size = new System.Drawing.Size(108, 24);
            this.Btn_PesoBruto.TabIndex = 17;
            this.Btn_PesoBruto.Text = "Obtener Peso Bruto";
            this.Btn_PesoBruto.UseVisualStyleBackColor = true;
            this.Btn_PesoBruto.Click += new System.EventHandler(this.Btn_PesoBruto_Click);
            // 
            // Cmb_Patente
            // 
            this.Cmb_Patente.FormattingEnabled = true;
            this.Cmb_Patente.Location = new System.Drawing.Point(133, 80);
            this.Cmb_Patente.Name = "Cmb_Patente";
            this.Cmb_Patente.Size = new System.Drawing.Size(89, 24);
            this.Cmb_Patente.TabIndex = 16;
            this.Cmb_Patente.SelectedIndexChanged += new System.EventHandler(this.Cmb_Patente_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Rb_Carga);
            this.groupBox2.Controls.Add(this.Rb_Tara);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(83, 23);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(350, 48);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Proceso a Realizar";
            // 
            // Rb_Carga
            // 
            this.Rb_Carga.AutoSize = true;
            this.Rb_Carga.Location = new System.Drawing.Point(230, 17);
            this.Rb_Carga.Name = "Rb_Carga";
            this.Rb_Carga.Size = new System.Drawing.Size(104, 19);
            this.Rb_Carga.TabIndex = 1;
            this.Rb_Carga.Text = "Carga Camión";
            this.Rb_Carga.UseVisualStyleBackColor = true;
            this.Rb_Carga.CheckedChanged += new System.EventHandler(this.Rb_Carga_CheckedChanged);
            // 
            // Rb_Tara
            // 
            this.Rb_Tara.AutoSize = true;
            this.Rb_Tara.Checked = true;
            this.Rb_Tara.Location = new System.Drawing.Point(111, 17);
            this.Rb_Tara.Name = "Rb_Tara";
            this.Rb_Tara.Size = new System.Drawing.Size(96, 19);
            this.Rb_Tara.TabIndex = 0;
            this.Rb_Tara.TabStop = true;
            this.Rb_Tara.Text = "Tara Camión";
            this.Rb_Tara.UseVisualStyleBackColor = true;
            this.Rb_Tara.CheckedChanged += new System.EventHandler(this.Rb_Tara_CheckedChanged);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label7.Location = new System.Drawing.Point(6, 151);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(525, 40);
            this.label7.TabIndex = 14;
            this.label7.Text = "Los camiones que no tengan registrada su TARA, no podrán ser Cargados";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Dtp_FechaActual
            // 
            this.Dtp_FechaActual.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Dtp_FechaActual.Location = new System.Drawing.Point(133, 115);
            this.Dtp_FechaActual.Name = "Dtp_FechaActual";
            this.Dtp_FechaActual.Size = new System.Drawing.Size(108, 23);
            this.Dtp_FechaActual.TabIndex = 13;
            // 
            // Btn_ObtenerTara
            // 
            this.Btn_ObtenerTara.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_ObtenerTara.Location = new System.Drawing.Point(234, 206);
            this.Btn_ObtenerTara.Name = "Btn_ObtenerTara";
            this.Btn_ObtenerTara.Size = new System.Drawing.Size(108, 24);
            this.Btn_ObtenerTara.TabIndex = 11;
            this.Btn_ObtenerTara.Text = "Obtener Tara";
            this.Btn_ObtenerTara.UseVisualStyleBackColor = true;
            this.Btn_ObtenerTara.Click += new System.EventHandler(this.Btn_ObtenerTara_Click);
            // 
            // Tx_Carga
            // 
            this.Tx_Carga.Location = new System.Drawing.Point(133, 329);
            this.Tx_Carga.MaxLength = 7;
            this.Tx_Carga.Name = "Tx_Carga";
            this.Tx_Carga.Size = new System.Drawing.Size(72, 23);
            this.Tx_Carga.TabIndex = 10;
            this.Tx_Carga.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(130, 305);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "Paso Carga";
            // 
            // Tx_Bruto
            // 
            this.Tx_Bruto.Location = new System.Drawing.Point(133, 266);
            this.Tx_Bruto.MaxLength = 7;
            this.Tx_Bruto.Name = "Tx_Bruto";
            this.Tx_Bruto.Size = new System.Drawing.Size(72, 23);
            this.Tx_Bruto.TabIndex = 8;
            this.Tx_Bruto.Text = "-";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(131, 246);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Paso Bruto";
            // 
            // Tx_Tara
            // 
            this.Tx_Tara.Location = new System.Drawing.Point(133, 215);
            this.Tx_Tara.MaxLength = 7;
            this.Tx_Tara.Name = "Tx_Tara";
            this.Tx_Tara.Size = new System.Drawing.Size(72, 23);
            this.Tx_Tara.TabIndex = 6;
            this.Tx_Tara.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(131, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Paso Tara";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Fecha Actual";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(227, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(274, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "(Los datos deben ser ingresados sin espacios ni guiones)";
            // 
            // Tx_Patente
            // 
            this.Tx_Patente.Location = new System.Drawing.Point(133, 80);
            this.Tx_Patente.MaxLength = 7;
            this.Tx_Patente.Name = "Tx_Patente";
            this.Tx_Patente.Size = new System.Drawing.Size(89, 23);
            this.Tx_Patente.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Patente";
            // 
            // Btn_Grabar
            // 
            this.Btn_Grabar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Grabar.Location = new System.Drawing.Point(600, 83);
            this.Btn_Grabar.Name = "Btn_Grabar";
            this.Btn_Grabar.Size = new System.Drawing.Size(82, 52);
            this.Btn_Grabar.TabIndex = 12;
            this.Btn_Grabar.Text = "Grabar";
            this.Btn_Grabar.UseVisualStyleBackColor = true;
            this.Btn_Grabar.Click += new System.EventHandler(this.Btn_Grabar_Click);
            // 
            // Btn_Salir
            // 
            this.Btn_Salir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Salir.Location = new System.Drawing.Point(600, 279);
            this.Btn_Salir.Name = "Btn_Salir";
            this.Btn_Salir.Size = new System.Drawing.Size(82, 53);
            this.Btn_Salir.TabIndex = 13;
            this.Btn_Salir.Text = "Salir";
            this.Btn_Salir.UseVisualStyleBackColor = true;
            this.Btn_Salir.Click += new System.EventHandler(this.Btn_Salir_Click);
            // 
            // Btn_GeneraDatos
            // 
            this.Btn_GeneraDatos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_GeneraDatos.Location = new System.Drawing.Point(600, 389);
            this.Btn_GeneraDatos.Name = "Btn_GeneraDatos";
            this.Btn_GeneraDatos.Size = new System.Drawing.Size(82, 53);
            this.Btn_GeneraDatos.TabIndex = 14;
            this.Btn_GeneraDatos.Text = "Genera Datos";
            this.Btn_GeneraDatos.UseVisualStyleBackColor = true;
            this.Btn_GeneraDatos.Click += new System.EventHandler(this.Btn_GeneraDatos_Click);
            // 
            // Tx_IdCorrCarga
            // 
            this.Tx_IdCorrCarga.Location = new System.Drawing.Point(27, 266);
            this.Tx_IdCorrCarga.MaxLength = 7;
            this.Tx_IdCorrCarga.Name = "Tx_IdCorrCarga";
            this.Tx_IdCorrCarga.Size = new System.Drawing.Size(72, 23);
            this.Tx_IdCorrCarga.TabIndex = 32;
            this.Tx_IdCorrCarga.Text = "-";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(14, 246);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(96, 17);
            this.label13.TabIndex = 31;
            this.label13.Text = "Id Corr. Carga";
            // 
            // Tx_IdCorrTara
            // 
            this.Tx_IdCorrTara.Location = new System.Drawing.Point(29, 215);
            this.Tx_IdCorrTara.MaxLength = 7;
            this.Tx_IdCorrTara.Name = "Tx_IdCorrTara";
            this.Tx_IdCorrTara.Size = new System.Drawing.Size(72, 23);
            this.Tx_IdCorrTara.TabIndex = 30;
            this.Tx_IdCorrTara.Text = "-";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(26, 195);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(88, 17);
            this.label14.TabIndex = 29;
            this.label14.Text = "Id Corr. Tara";
            // 
            // Frm_PesajeCamion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 446);
            this.Controls.Add(this.Btn_GeneraDatos);
            this.Controls.Add(this.Btn_Salir);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Btn_Grabar);
            this.Name = "Frm_PesajeCamion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formulario de ingreso de pesaje de Camión";
            this.Load += new System.EventHandler(this.Frm_PesajeCamion_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Tx_Patente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Tx_Carga;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Tx_Bruto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Tx_Tara;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Btn_Grabar;
        private System.Windows.Forms.Button Btn_ObtenerTara;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker Dtp_FechaActual;
        private System.Windows.Forms.Button Btn_Salir;
        private System.Windows.Forms.ComboBox Cmb_Patente;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton Rb_Carga;
        private System.Windows.Forms.RadioButton Rb_Tara;
        private System.Windows.Forms.Button Btn_PesoBruto;
        private System.Windows.Forms.TextBox Tx_Semaforo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox Tx_ToleranciaBascula;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Tx_ToleranciaReal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox Tx_KgsCargados;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox Tx_DiferenciaKilos;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox Tx_sql;
        private System.Windows.Forms.Button Btn_GeneraDatos;
        private System.Windows.Forms.TextBox Tx_IdCorrCarga;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox Tx_IdCorrTara;
        private System.Windows.Forms.Label label14;
    }
}