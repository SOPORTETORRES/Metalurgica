namespace Metalurgica.Produccion
{
    partial class Frm_VinculaQR
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Dtg_Resultado = new System.Windows.Forms.DataGridView();
            this.Tx_Id = new System.Windows.Forms.TextBox();
            this.Tx_Etiqueta = new System.Windows.Forms.TextBox();
            this.Tx_KgsEtiqueta = new System.Windows.Forms.TextBox();
            this.Tx_Vinculados = new System.Windows.Forms.TextBox();
            this.Tx_Saldo = new System.Windows.Forms.TextBox();
            this.Lbl_KgsProd = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Lbl_SaldoKilosColada = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblKilos = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblLargo = new System.Windows.Forms.Label();
            this.lblDiametro = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.Tx_etiquetaQR = new System.Windows.Forms.TextBox();
            this.lblColada = new System.Windows.Forms.Label();
            this.Lbl_Msg = new System.Windows.Forms.Label();
            this.Btn_Aceptar = new System.Windows.Forms.Button();
            this.Tx_Diam = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_Resultado)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Id Etiqueta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(193, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Etiqueta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(292, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Kgs. Etiqueta";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(398, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Kgs. Vinculados";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(516, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Kgs. Saldo";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Ingrese Colada";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.Dtg_Resultado);
            this.groupBox1.Location = new System.Drawing.Point(12, 149);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(836, 232);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Vinculaciones Realizadas";
            // 
            // Dtg_Resultado
            // 
            this.Dtg_Resultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dtg_Resultado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Dtg_Resultado.Location = new System.Drawing.Point(3, 16);
            this.Dtg_Resultado.Name = "Dtg_Resultado";
            this.Dtg_Resultado.Size = new System.Drawing.Size(830, 213);
            this.Dtg_Resultado.TabIndex = 0;
            // 
            // Tx_Id
            // 
            this.Tx_Id.BackColor = System.Drawing.Color.White;
            this.Tx_Id.Location = new System.Drawing.Point(13, 37);
            this.Tx_Id.Name = "Tx_Id";
            this.Tx_Id.ReadOnly = true;
            this.Tx_Id.Size = new System.Drawing.Size(67, 20);
            this.Tx_Id.TabIndex = 7;
            // 
            // Tx_Etiqueta
            // 
            this.Tx_Etiqueta.BackColor = System.Drawing.Color.White;
            this.Tx_Etiqueta.Location = new System.Drawing.Point(175, 37);
            this.Tx_Etiqueta.Name = "Tx_Etiqueta";
            this.Tx_Etiqueta.ReadOnly = true;
            this.Tx_Etiqueta.Size = new System.Drawing.Size(88, 20);
            this.Tx_Etiqueta.TabIndex = 8;
            // 
            // Tx_KgsEtiqueta
            // 
            this.Tx_KgsEtiqueta.BackColor = System.Drawing.Color.White;
            this.Tx_KgsEtiqueta.Location = new System.Drawing.Point(295, 37);
            this.Tx_KgsEtiqueta.Name = "Tx_KgsEtiqueta";
            this.Tx_KgsEtiqueta.ReadOnly = true;
            this.Tx_KgsEtiqueta.Size = new System.Drawing.Size(67, 20);
            this.Tx_KgsEtiqueta.TabIndex = 9;
            // 
            // Tx_Vinculados
            // 
            this.Tx_Vinculados.BackColor = System.Drawing.Color.White;
            this.Tx_Vinculados.Location = new System.Drawing.Point(401, 37);
            this.Tx_Vinculados.Name = "Tx_Vinculados";
            this.Tx_Vinculados.ReadOnly = true;
            this.Tx_Vinculados.Size = new System.Drawing.Size(67, 20);
            this.Tx_Vinculados.TabIndex = 10;
            // 
            // Tx_Saldo
            // 
            this.Tx_Saldo.BackColor = System.Drawing.Color.White;
            this.Tx_Saldo.Location = new System.Drawing.Point(513, 37);
            this.Tx_Saldo.Name = "Tx_Saldo";
            this.Tx_Saldo.ReadOnly = true;
            this.Tx_Saldo.Size = new System.Drawing.Size(67, 20);
            this.Tx_Saldo.TabIndex = 11;
            // 
            // Lbl_KgsProd
            // 
            this.Lbl_KgsProd.AutoSize = true;
            this.Lbl_KgsProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_KgsProd.ForeColor = System.Drawing.Color.Black;
            this.Lbl_KgsProd.Location = new System.Drawing.Point(253, 108);
            this.Lbl_KgsProd.Name = "Lbl_KgsProd";
            this.Lbl_KgsProd.Size = new System.Drawing.Size(13, 13);
            this.Lbl_KgsProd.TabIndex = 62;
            this.Lbl_KgsProd.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(164, 108);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 13);
            this.label8.TabIndex = 61;
            this.label8.Text = "Kilos Producidos";
            // 
            // Lbl_SaldoKilosColada
            // 
            this.Lbl_SaldoKilosColada.AutoSize = true;
            this.Lbl_SaldoKilosColada.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_SaldoKilosColada.ForeColor = System.Drawing.Color.Red;
            this.Lbl_SaldoKilosColada.Location = new System.Drawing.Point(106, 108);
            this.Lbl_SaldoKilosColada.Name = "Lbl_SaldoKilosColada";
            this.Lbl_SaldoKilosColada.Size = new System.Drawing.Size(14, 13);
            this.Lbl_SaldoKilosColada.TabIndex = 60;
            this.Lbl_SaldoKilosColada.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 108);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 13);
            this.label11.TabIndex = 59;
            this.label11.Text = "Saldo Kilos Colada";
            // 
            // lblKilos
            // 
            this.lblKilos.AutoSize = true;
            this.lblKilos.Location = new System.Drawing.Point(354, 107);
            this.lblKilos.Name = "lblKilos";
            this.lblKilos.Size = new System.Drawing.Size(13, 13);
            this.lblKilos.TabIndex = 73;
            this.lblKilos.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(326, 108);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 13);
            this.label10.TabIndex = 72;
            this.label10.Text = "Kilos";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 130);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 13);
            this.label9.TabIndex = 71;
            this.label9.Text = "Colada:";
            // 
            // lblLargo
            // 
            this.lblLargo.AutoSize = true;
            this.lblLargo.Location = new System.Drawing.Point(461, 110);
            this.lblLargo.Name = "lblLargo";
            this.lblLargo.Size = new System.Drawing.Size(13, 13);
            this.lblLargo.TabIndex = 70;
            this.lblLargo.Text = "0";
            // 
            // lblDiametro
            // 
            this.lblDiametro.AutoSize = true;
            this.lblDiametro.Location = new System.Drawing.Point(557, 110);
            this.lblDiametro.Name = "lblDiametro";
            this.lblDiametro.Size = new System.Drawing.Size(19, 13);
            this.lblDiametro.TabIndex = 69;
            this.lblDiametro.Text = "10";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(417, 109);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 68;
            this.label7.Text = "Largo:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(499, 110);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 13);
            this.label13.TabIndex = 67;
            this.label13.Text = "Diametro:";
            // 
            // Tx_etiquetaQR
            // 
            this.Tx_etiquetaQR.Location = new System.Drawing.Point(109, 69);
            this.Tx_etiquetaQR.Name = "Tx_etiquetaQR";
            this.Tx_etiquetaQR.Size = new System.Drawing.Size(472, 20);
            this.Tx_etiquetaQR.TabIndex = 0;
            this.Tx_etiquetaQR.TextChanged += new System.EventHandler(this.Tx_etiquetaQR_TextChanged);
            this.Tx_etiquetaQR.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Tx_etiquetaQR_KeyPress);
            this.Tx_etiquetaQR.Validating += new System.ComponentModel.CancelEventHandler(this.Tx_etiquetaQR_Validating);
            // 
            // lblColada
            // 
            this.lblColada.AutoSize = true;
            this.lblColada.Location = new System.Drawing.Point(70, 134);
            this.lblColada.Name = "lblColada";
            this.lblColada.Size = new System.Drawing.Size(10, 13);
            this.lblColada.TabIndex = 75;
            this.lblColada.Text = ".";
            // 
            // Lbl_Msg
            // 
            this.Lbl_Msg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Msg.ForeColor = System.Drawing.Color.Red;
            this.Lbl_Msg.Location = new System.Drawing.Point(601, 69);
            this.Lbl_Msg.Name = "Lbl_Msg";
            this.Lbl_Msg.Size = new System.Drawing.Size(228, 63);
            this.Lbl_Msg.TabIndex = 76;
            this.Lbl_Msg.Text = "Ingrese Colada";
            this.Lbl_Msg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Btn_Aceptar
            // 
            this.Btn_Aceptar.Location = new System.Drawing.Point(702, 18);
            this.Btn_Aceptar.Name = "Btn_Aceptar";
            this.Btn_Aceptar.Size = new System.Drawing.Size(95, 39);
            this.Btn_Aceptar.TabIndex = 77;
            this.Btn_Aceptar.Text = "Grabar";
            this.Btn_Aceptar.UseVisualStyleBackColor = true;
            this.Btn_Aceptar.Visible = false;
            this.Btn_Aceptar.Click += new System.EventHandler(this.Btn_Aceptar_Click);
            // 
            // Tx_Diam
            // 
            this.Tx_Diam.BackColor = System.Drawing.Color.White;
            this.Tx_Diam.Location = new System.Drawing.Point(95, 37);
            this.Tx_Diam.Name = "Tx_Diam";
            this.Tx_Diam.ReadOnly = true;
            this.Tx_Diam.Size = new System.Drawing.Size(67, 20);
            this.Tx_Diam.TabIndex = 79;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(102, 18);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 13);
            this.label12.TabIndex = 78;
            this.label12.Text = "Diámetro";
            // 
            // Frm_VinculaQR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 386);
            this.ControlBox = false;
            this.Controls.Add(this.Tx_Diam);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.Btn_Aceptar);
            this.Controls.Add(this.Lbl_Msg);
            this.Controls.Add(this.lblColada);
            this.Controls.Add(this.Tx_etiquetaQR);
            this.Controls.Add(this.lblKilos);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblLargo);
            this.Controls.Add(this.lblDiametro);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.Lbl_KgsProd);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Lbl_SaldoKilosColada);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.Tx_Saldo);
            this.Controls.Add(this.Tx_Vinculados);
            this.Controls.Add(this.Tx_KgsEtiqueta);
            this.Controls.Add(this.Tx_Etiqueta);
            this.Controls.Add(this.Tx_Id);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Frm_VinculaQR";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formulario de Vinculación Etiquetas QR y T.O.";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_Resultado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView Dtg_Resultado;
        private System.Windows.Forms.TextBox Tx_Id;
        private System.Windows.Forms.TextBox Tx_Etiqueta;
        private System.Windows.Forms.TextBox Tx_KgsEtiqueta;
        private System.Windows.Forms.TextBox Tx_Vinculados;
        private System.Windows.Forms.TextBox Tx_Saldo;
        private System.Windows.Forms.Label Lbl_KgsProd;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label Lbl_SaldoKilosColada;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblKilos;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblLargo;
        private System.Windows.Forms.Label lblDiametro;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox Tx_etiquetaQR;
        private System.Windows.Forms.Label lblColada;
        private System.Windows.Forms.Label Lbl_Msg;
        private System.Windows.Forms.Button Btn_Aceptar;
        private System.Windows.Forms.TextBox Tx_Diam;
        private System.Windows.Forms.Label label12;
    }
}