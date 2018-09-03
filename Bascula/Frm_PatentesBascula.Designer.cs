namespace Metalurgica.Bascula
{
    partial class Frm_PatentesBascula
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
            this.Gtg_Patentes = new System.Windows.Forms.DataGridView();
            this.Btn_Salir = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Tx_Correlativo = new System.Windows.Forms.TextBox();
            this.Tx_PesoBruto = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Tx_fecha = new System.Windows.Forms.TextBox();
            this.Tx_hora = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Gtg_Patentes)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Gtg_Patentes
            // 
            this.Gtg_Patentes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Gtg_Patentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Gtg_Patentes.Location = new System.Drawing.Point(2, 99);
            this.Gtg_Patentes.Name = "Gtg_Patentes";
            this.Gtg_Patentes.Size = new System.Drawing.Size(793, 155);
            this.Gtg_Patentes.TabIndex = 0;
            this.Gtg_Patentes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Gtg_Patentes_CellContentClick);
            // 
            // Btn_Salir
            // 
            this.Btn_Salir.Location = new System.Drawing.Point(711, 27);
            this.Btn_Salir.Name = "Btn_Salir";
            this.Btn_Salir.Size = new System.Drawing.Size(75, 46);
            this.Btn_Salir.TabIndex = 1;
            this.Btn_Salir.Text = "Salir";
            this.Btn_Salir.UseVisualStyleBackColor = true;
            this.Btn_Salir.Click += new System.EventHandler(this.Btn_Salir_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(598, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 46);
            this.button1.TabIndex = 2;
            this.button1.Text = "Seleccionar ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Tx_hora);
            this.groupBox1.Controls.Add(this.Tx_fecha);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.Tx_PesoBruto);
            this.groupBox1.Controls.Add(this.Tx_Correlativo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(562, 80);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Seleccionados";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Correlativo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(179, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Peso Bruto";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(332, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Fecha";
            // 
            // Tx_Correlativo
            // 
            this.Tx_Correlativo.Location = new System.Drawing.Point(25, 40);
            this.Tx_Correlativo.Name = "Tx_Correlativo";
            this.Tx_Correlativo.ReadOnly = true;
            this.Tx_Correlativo.Size = new System.Drawing.Size(69, 20);
            this.Tx_Correlativo.TabIndex = 3;
            // 
            // Tx_PesoBruto
            // 
            this.Tx_PesoBruto.Location = new System.Drawing.Point(171, 40);
            this.Tx_PesoBruto.Name = "Tx_PesoBruto";
            this.Tx_PesoBruto.ReadOnly = true;
            this.Tx_PesoBruto.Size = new System.Drawing.Size(69, 20);
            this.Tx_PesoBruto.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(454, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Hora";
            // 
            // Tx_fecha
            // 
            this.Tx_fecha.Location = new System.Drawing.Point(313, 40);
            this.Tx_fecha.Name = "Tx_fecha";
            this.Tx_fecha.ReadOnly = true;
            this.Tx_fecha.Size = new System.Drawing.Size(69, 20);
            this.Tx_fecha.TabIndex = 6;
            // 
            // Tx_hora
            // 
            this.Tx_hora.Location = new System.Drawing.Point(433, 40);
            this.Tx_hora.Name = "Tx_hora";
            this.Tx_hora.ReadOnly = true;
            this.Tx_hora.Size = new System.Drawing.Size(69, 20);
            this.Tx_hora.TabIndex = 7;
            // 
            // Frm_PatentesBascula
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 258);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Btn_Salir);
            this.Controls.Add(this.Gtg_Patentes);
            this.Name = "Frm_PatentesBascula";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formulario de Seleccion de Patentes";
            this.Load += new System.EventHandler(this.Frm_PatentesBascula_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Gtg_Patentes)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView Gtg_Patentes;
        private System.Windows.Forms.Button Btn_Salir;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox Tx_hora;
        private System.Windows.Forms.TextBox Tx_fecha;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Tx_PesoBruto;
        private System.Windows.Forms.TextBox Tx_Correlativo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}