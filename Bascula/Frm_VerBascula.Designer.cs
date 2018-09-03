namespace Metalurgica.Bascula
{
    partial class Frm_VerBascula
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
            this.Dtg_BAscula = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.Btn_Buscar = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Tx_Patente = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.Tx_Tara = new System.Windows.Forms.TextBox();
            this.Tx_bruto = new System.Windows.Forms.TextBox();
            this.Tx_pesoBascula = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_BAscula)).BeginInit();
            this.SuspendLayout();
            // 
            // Dtg_BAscula
            // 
            this.Dtg_BAscula.AllowUserToAddRows = false;
            this.Dtg_BAscula.AllowUserToDeleteRows = false;
            this.Dtg_BAscula.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Dtg_BAscula.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dtg_BAscula.Location = new System.Drawing.Point(7, 93);
            this.Dtg_BAscula.Name = "Dtg_BAscula";
            this.Dtg_BAscula.ReadOnly = true;
            this.Dtg_BAscula.Size = new System.Drawing.Size(812, 402);
            this.Dtg_BAscula.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(559, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Seleccione Fecha Inicio";
            // 
            // Btn_Buscar
            // 
            this.Btn_Buscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Buscar.Location = new System.Drawing.Point(737, 30);
            this.Btn_Buscar.Name = "Btn_Buscar";
            this.Btn_Buscar.Size = new System.Drawing.Size(75, 48);
            this.Btn_Buscar.TabIndex = 4;
            this.Btn_Buscar.Text = "Buscar";
            this.Btn_Buscar.UseVisualStyleBackColor = true;
            this.Btn_Buscar.Click += new System.EventHandler(this.Btn_Buscar_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(572, 30);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(118, 20);
            this.dateTimePicker1.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Patente";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(365, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Peso Bascula";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(273, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Peso Bruto";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(187, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Peso Tara";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(110, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Fecha Tara";
            // 
            // Tx_Patente
            // 
            this.Tx_Patente.Location = new System.Drawing.Point(30, 33);
            this.Tx_Patente.Name = "Tx_Patente";
            this.Tx_Patente.Size = new System.Drawing.Size(56, 20);
            this.Tx_Patente.TabIndex = 12;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(110, 33);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(62, 20);
            this.textBox2.TabIndex = 13;
            // 
            // Tx_Tara
            // 
            this.Tx_Tara.Location = new System.Drawing.Point(189, 33);
            this.Tx_Tara.Name = "Tx_Tara";
            this.Tx_Tara.Size = new System.Drawing.Size(56, 20);
            this.Tx_Tara.TabIndex = 14;
            // 
            // Tx_bruto
            // 
            this.Tx_bruto.Location = new System.Drawing.Point(276, 33);
            this.Tx_bruto.Name = "Tx_bruto";
            this.Tx_bruto.Size = new System.Drawing.Size(56, 20);
            this.Tx_bruto.TabIndex = 15;
            // 
            // Tx_pesoBascula
            // 
            this.Tx_pesoBascula.Location = new System.Drawing.Point(368, 33);
            this.Tx_pesoBascula.Name = "Tx_pesoBascula";
            this.Tx_pesoBascula.Size = new System.Drawing.Size(56, 20);
            this.Tx_pesoBascula.TabIndex = 16;
            // 
            // Frm_VerBascula
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 500);
            this.Controls.Add(this.Tx_pesoBascula);
            this.Controls.Add(this.Tx_bruto);
            this.Controls.Add(this.Tx_Tara);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.Tx_Patente);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.Btn_Buscar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Dtg_BAscula);
            this.Name = "Frm_VerBascula";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Datos de la Bascula";
            this.Load += new System.EventHandler(this.Frm_VerBascula_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_BAscula)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Dtg_BAscula;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Btn_Buscar;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Tx_Patente;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox Tx_Tara;
        private System.Windows.Forms.TextBox Tx_bruto;
        private System.Windows.Forms.TextBox Tx_pesoBascula;
    }
}