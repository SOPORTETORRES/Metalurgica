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
            this.Btn_PesoBruto = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.groupBox1.Size = new System.Drawing.Size(511, 325);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ingrese los datos del pesaje de Camión";
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
            this.label7.Location = new System.Drawing.Point(18, 157);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(465, 40);
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
            this.Btn_ObtenerTara.Location = new System.Drawing.Point(234, 216);
            this.Btn_ObtenerTara.Name = "Btn_ObtenerTara";
            this.Btn_ObtenerTara.Size = new System.Drawing.Size(108, 24);
            this.Btn_ObtenerTara.TabIndex = 11;
            this.Btn_ObtenerTara.Text = "Obtener Tara";
            this.Btn_ObtenerTara.UseVisualStyleBackColor = true;
            this.Btn_ObtenerTara.Click += new System.EventHandler(this.Btn_ObtenerTara_Click);
            // 
            // Tx_Carga
            // 
            this.Tx_Carga.Location = new System.Drawing.Point(139, 287);
            this.Tx_Carga.MaxLength = 7;
            this.Tx_Carga.Name = "Tx_Carga";
            this.Tx_Carga.Size = new System.Drawing.Size(72, 23);
            this.Tx_Carga.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 291);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "Paso Carga";
            // 
            // Tx_Bruto
            // 
            this.Tx_Bruto.Location = new System.Drawing.Point(140, 253);
            this.Tx_Bruto.MaxLength = 7;
            this.Tx_Bruto.Name = "Tx_Bruto";
            this.Tx_Bruto.Size = new System.Drawing.Size(72, 23);
            this.Tx_Bruto.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 259);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Paso Bruto";
            // 
            // Tx_Tara
            // 
            this.Tx_Tara.Location = new System.Drawing.Point(140, 217);
            this.Tx_Tara.MaxLength = 7;
            this.Tx_Tara.Name = "Tx_Tara";
            this.Tx_Tara.Size = new System.Drawing.Size(72, 23);
            this.Tx_Tara.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 222);
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
            this.Btn_Grabar.Location = new System.Drawing.Point(532, 30);
            this.Btn_Grabar.Name = "Btn_Grabar";
            this.Btn_Grabar.Size = new System.Drawing.Size(82, 36);
            this.Btn_Grabar.TabIndex = 12;
            this.Btn_Grabar.Text = "Grabar";
            this.Btn_Grabar.UseVisualStyleBackColor = true;
            this.Btn_Grabar.Click += new System.EventHandler(this.Btn_Grabar_Click);
            // 
            // Btn_Salir
            // 
            this.Btn_Salir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Salir.Location = new System.Drawing.Point(528, 118);
            this.Btn_Salir.Name = "Btn_Salir";
            this.Btn_Salir.Size = new System.Drawing.Size(82, 36);
            this.Btn_Salir.TabIndex = 13;
            this.Btn_Salir.Text = "Salir";
            this.Btn_Salir.UseVisualStyleBackColor = true;
            this.Btn_Salir.Click += new System.EventHandler(this.Btn_Salir_Click);
            // 
            // Btn_PesoBruto
            // 
            this.Btn_PesoBruto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_PesoBruto.Location = new System.Drawing.Point(234, 253);
            this.Btn_PesoBruto.Name = "Btn_PesoBruto";
            this.Btn_PesoBruto.Size = new System.Drawing.Size(108, 24);
            this.Btn_PesoBruto.TabIndex = 17;
            this.Btn_PesoBruto.Text = "Obtener Peso Bruto";
            this.Btn_PesoBruto.UseVisualStyleBackColor = true;
            this.Btn_PesoBruto.Click += new System.EventHandler(this.Btn_PesoBruto_Click);
            // 
            // Frm_PesajeCamion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 349);
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
    }
}