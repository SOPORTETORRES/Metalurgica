﻿namespace Metalurgica.Bascula
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
            this.Tx_Carga = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Tx_Bruto = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Tx_Tara = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Tx_FechaActual = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Tx_Patente = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Btn_ObtenerTara = new System.Windows.Forms.Button();
            this.Btn_Grabar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.Btn_Grabar);
            this.groupBox1.Controls.Add(this.Btn_ObtenerTara);
            this.groupBox1.Controls.Add(this.Tx_Carga);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.Tx_Bruto);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.Tx_Tara);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.Tx_FechaActual);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Tx_Patente);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(491, 266);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ingrese los datos del pesaje de Camión";
            // 
            // Tx_Carga
            // 
            this.Tx_Carga.Location = new System.Drawing.Point(138, 200);
            this.Tx_Carga.MaxLength = 7;
            this.Tx_Carga.Name = "Tx_Carga";
            this.Tx_Carga.Size = new System.Drawing.Size(72, 23);
            this.Tx_Carga.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 206);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "Paso Carga";
            // 
            // Tx_Bruto
            // 
            this.Tx_Bruto.Location = new System.Drawing.Point(138, 157);
            this.Tx_Bruto.MaxLength = 7;
            this.Tx_Bruto.Name = "Tx_Bruto";
            this.Tx_Bruto.Size = new System.Drawing.Size(72, 23);
            this.Tx_Bruto.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Paso Bruto";
            // 
            // Tx_Tara
            // 
            this.Tx_Tara.Location = new System.Drawing.Point(138, 112);
            this.Tx_Tara.MaxLength = 7;
            this.Tx_Tara.Name = "Tx_Tara";
            this.Tx_Tara.Size = new System.Drawing.Size(72, 23);
            this.Tx_Tara.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Paso Tara";
            // 
            // Tx_FechaActual
            // 
            this.Tx_FechaActual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Tx_FechaActual.Location = new System.Drawing.Point(138, 72);
            this.Tx_FechaActual.MaxLength = 7;
            this.Tx_FechaActual.Name = "Tx_FechaActual";
            this.Tx_FechaActual.ReadOnly = true;
            this.Tx_FechaActual.Size = new System.Drawing.Size(171, 23);
            this.Tx_FechaActual.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Fecha Actual";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(209, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(274, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "(Los datos deben ser ingresados sin espacios ni guiones)";
            // 
            // Tx_Patente
            // 
            this.Tx_Patente.Location = new System.Drawing.Point(138, 35);
            this.Tx_Patente.MaxLength = 7;
            this.Tx_Patente.Name = "Tx_Patente";
            this.Tx_Patente.Size = new System.Drawing.Size(65, 23);
            this.Tx_Patente.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Patente";
            // 
            // Btn_ObtenerTara
            // 
            this.Btn_ObtenerTara.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_ObtenerTara.Location = new System.Drawing.Point(232, 111);
            this.Btn_ObtenerTara.Name = "Btn_ObtenerTara";
            this.Btn_ObtenerTara.Size = new System.Drawing.Size(83, 24);
            this.Btn_ObtenerTara.TabIndex = 11;
            this.Btn_ObtenerTara.Text = "Obtener Tara";
            this.Btn_ObtenerTara.UseVisualStyleBackColor = true;
            this.Btn_ObtenerTara.Click += new System.EventHandler(this.Btn_ObtenerTara_Click);
            // 
            // Btn_Grabar
            // 
            this.Btn_Grabar.Location = new System.Drawing.Point(364, 196);
            this.Btn_Grabar.Name = "Btn_Grabar";
            this.Btn_Grabar.Size = new System.Drawing.Size(80, 36);
            this.Btn_Grabar.TabIndex = 12;
            this.Btn_Grabar.Text = "Grabar";
            this.Btn_Grabar.UseVisualStyleBackColor = true;
            // 
            // Frm_PesajeCamion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 290);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_PesajeCamion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formulario de ingreso de pesaje de Camión";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox Tx_FechaActual;
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
    }
}