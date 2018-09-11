namespace Metalurgica.Bascula
{
    partial class Frm_AutorizaDespacho
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Btn_salir = new System.Windows.Forms.Button();
            this.Btn_Grabar = new System.Windows.Forms.Button();
            this.Tx_Clave = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.Cmb_Supervisor = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.Tx_PesoBruto = new System.Windows.Forms.TextBox();
            this.Tx_PesoNeto = new System.Windows.Forms.TextBox();
            this.Tx_Tolerancia = new System.Windows.Forms.TextBox();
            this.Tx_Dif = new System.Windows.Forms.TextBox();
            this.Tx_PesoGD = new System.Windows.Forms.TextBox();
            this.Tx_PesoSoloFE = new System.Windows.Forms.TextBox();
            this.Tx_PesoAdicional = new System.Windows.Forms.TextBox();
            this.Tx_Patente = new System.Windows.Forms.TextBox();
            this.Tx_fecha = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.Tx_PesoBruto);
            this.groupBox1.Controls.Add(this.Tx_PesoNeto);
            this.groupBox1.Controls.Add(this.Tx_Tolerancia);
            this.groupBox1.Controls.Add(this.Tx_Dif);
            this.groupBox1.Controls.Add(this.Tx_PesoGD);
            this.groupBox1.Controls.Add(this.Tx_PesoSoloFE);
            this.groupBox1.Controls.Add(this.Tx_PesoAdicional);
            this.groupBox1.Controls.Add(this.Tx_Patente);
            this.groupBox1.Controls.Add(this.Tx_fecha);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(672, 361);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del Despacho";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Btn_salir);
            this.groupBox2.Controls.Add(this.Btn_Grabar);
            this.groupBox2.Controls.Add(this.Tx_Clave);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.Cmb_Supervisor);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Location = new System.Drawing.Point(310, 33);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(330, 299);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Autorización Supervisor";
            // 
            // Btn_salir
            // 
            this.Btn_salir.Location = new System.Drawing.Point(196, 223);
            this.Btn_salir.Name = "Btn_salir";
            this.Btn_salir.Size = new System.Drawing.Size(75, 55);
            this.Btn_salir.TabIndex = 15;
            this.Btn_salir.Text = "Salir";
            this.Btn_salir.UseVisualStyleBackColor = true;
            this.Btn_salir.Click += new System.EventHandler(this.Btn_salir_Click);
            // 
            // Btn_Grabar
            // 
            this.Btn_Grabar.Location = new System.Drawing.Point(57, 227);
            this.Btn_Grabar.Name = "Btn_Grabar";
            this.Btn_Grabar.Size = new System.Drawing.Size(75, 55);
            this.Btn_Grabar.TabIndex = 14;
            this.Btn_Grabar.Text = "Grabar";
            this.Btn_Grabar.UseVisualStyleBackColor = true;
            this.Btn_Grabar.Click += new System.EventHandler(this.Btn_Grabar_Click);
            // 
            // Tx_Clave
            // 
            this.Tx_Clave.Location = new System.Drawing.Point(102, 133);
            this.Tx_Clave.Name = "Tx_Clave";
            this.Tx_Clave.PasswordChar = '*';
            this.Tx_Clave.Size = new System.Drawing.Size(100, 24);
            this.Tx_Clave.TabIndex = 13;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(54, 110);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(196, 17);
            this.label11.TabIndex = 9;
            this.label11.Text = "Ingrese Clave de Autorización";
            // 
            // Cmb_Supervisor
            // 
            this.Cmb_Supervisor.FormattingEnabled = true;
            this.Cmb_Supervisor.Location = new System.Drawing.Point(71, 59);
            this.Cmb_Supervisor.Name = "Cmb_Supervisor";
            this.Cmb_Supervisor.Size = new System.Drawing.Size(149, 26);
            this.Cmb_Supervisor.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(67, 36);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(149, 17);
            this.label10.TabIndex = 7;
            this.label10.Text = "Seleccione Supervisor";
            // 
            // Tx_PesoBruto
            // 
            this.Tx_PesoBruto.Location = new System.Drawing.Point(170, 94);
            this.Tx_PesoBruto.Name = "Tx_PesoBruto";
            this.Tx_PesoBruto.Size = new System.Drawing.Size(78, 24);
            this.Tx_PesoBruto.TabIndex = 22;
            // 
            // Tx_PesoNeto
            // 
            this.Tx_PesoNeto.Location = new System.Drawing.Point(170, 131);
            this.Tx_PesoNeto.Name = "Tx_PesoNeto";
            this.Tx_PesoNeto.Size = new System.Drawing.Size(78, 24);
            this.Tx_PesoNeto.TabIndex = 21;
            // 
            // Tx_Tolerancia
            // 
            this.Tx_Tolerancia.Location = new System.Drawing.Point(170, 308);
            this.Tx_Tolerancia.Name = "Tx_Tolerancia";
            this.Tx_Tolerancia.Size = new System.Drawing.Size(78, 24);
            this.Tx_Tolerancia.TabIndex = 20;
            // 
            // Tx_Dif
            // 
            this.Tx_Dif.Location = new System.Drawing.Point(170, 271);
            this.Tx_Dif.Name = "Tx_Dif";
            this.Tx_Dif.Size = new System.Drawing.Size(78, 24);
            this.Tx_Dif.TabIndex = 19;
            // 
            // Tx_PesoGD
            // 
            this.Tx_PesoGD.Location = new System.Drawing.Point(170, 232);
            this.Tx_PesoGD.Name = "Tx_PesoGD";
            this.Tx_PesoGD.Size = new System.Drawing.Size(78, 24);
            this.Tx_PesoGD.TabIndex = 18;
            // 
            // Tx_PesoSoloFE
            // 
            this.Tx_PesoSoloFE.Location = new System.Drawing.Point(170, 197);
            this.Tx_PesoSoloFE.Name = "Tx_PesoSoloFE";
            this.Tx_PesoSoloFE.Size = new System.Drawing.Size(78, 24);
            this.Tx_PesoSoloFE.TabIndex = 17;
            // 
            // Tx_PesoAdicional
            // 
            this.Tx_PesoAdicional.Location = new System.Drawing.Point(170, 163);
            this.Tx_PesoAdicional.Name = "Tx_PesoAdicional";
            this.Tx_PesoAdicional.Size = new System.Drawing.Size(78, 24);
            this.Tx_PesoAdicional.TabIndex = 14;
            // 
            // Tx_Patente
            // 
            this.Tx_Patente.Location = new System.Drawing.Point(199, 54);
            this.Tx_Patente.Name = "Tx_Patente";
            this.Tx_Patente.Size = new System.Drawing.Size(78, 24);
            this.Tx_Patente.TabIndex = 13;
            // 
            // Tx_fecha
            // 
            this.Tx_fecha.Location = new System.Drawing.Point(21, 55);
            this.Tx_fecha.Name = "Tx_fecha";
            this.Tx_fecha.Size = new System.Drawing.Size(100, 24);
            this.Tx_fecha.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(26, 308);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(134, 17);
            this.label9.TabIndex = 11;
            this.label9.Text = "Tolerancia Real (%)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(26, 272);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 17);
            this.label7.TabIndex = 9;
            this.label7.Text = "Diferencia (KG)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(26, 201);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 17);
            this.label8.TabIndex = 8;
            this.label8.Text = "Peso sólo fierro";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(37, 237);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 17);
            this.label6.TabIndex = 7;
            this.label6.Text = "Peso G. D.";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(31, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Peso Bruto";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(35, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "Peso Neto";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(209, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Patente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Peso Adicional";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Fecha";
            // 
            // Frm_AutorizaDespacho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 361);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_AutorizaDespacho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formulario de Autorización de Despachos fuera de Rango";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox Tx_PesoBruto;
        private System.Windows.Forms.TextBox Tx_PesoNeto;
        private System.Windows.Forms.TextBox Tx_Tolerancia;
        private System.Windows.Forms.TextBox Tx_Dif;
        private System.Windows.Forms.TextBox Tx_PesoGD;
        private System.Windows.Forms.TextBox Tx_PesoSoloFE;
        private System.Windows.Forms.TextBox Tx_PesoAdicional;
        private System.Windows.Forms.TextBox Tx_Patente;
        private System.Windows.Forms.TextBox Tx_fecha;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button Btn_salir;
        private System.Windows.Forms.Button Btn_Grabar;
        private System.Windows.Forms.TextBox Tx_Clave;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox Cmb_Supervisor;
        private System.Windows.Forms.Label label10;
    }
}