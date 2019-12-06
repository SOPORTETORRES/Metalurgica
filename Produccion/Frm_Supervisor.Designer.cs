namespace Metalurgica.Produccion
{
    partial class Frm_Supervisor
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
            this.Btn_Salir = new System.Windows.Forms.Button();
            this.Btn_Grabar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Tx_Obs = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Tx_clave = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Tx_KgsPr = new System.Windows.Forms.TextBox();
            this.Tx_KgsCierre = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Tx_Depunte = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Tx_Depunte);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.Tx_KgsCierre);
            this.groupBox1.Controls.Add(this.Tx_KgsPr);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.Btn_Salir);
            this.groupBox1.Controls.Add(this.Btn_Grabar);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.Tx_Obs);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Tx_clave);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(477, 302);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Generales de la Autorización";
            // 
            // Btn_Salir
            // 
            this.Btn_Salir.Location = new System.Drawing.Point(390, 19);
            this.Btn_Salir.Name = "Btn_Salir";
            this.Btn_Salir.Size = new System.Drawing.Size(75, 47);
            this.Btn_Salir.TabIndex = 6;
            this.Btn_Salir.Text = "Salir";
            this.Btn_Salir.UseVisualStyleBackColor = true;
            this.Btn_Salir.Click += new System.EventHandler(this.Btn_Salir_Click);
            // 
            // Btn_Grabar
            // 
            this.Btn_Grabar.Location = new System.Drawing.Point(390, 81);
            this.Btn_Grabar.Name = "Btn_Grabar";
            this.Btn_Grabar.Size = new System.Drawing.Size(75, 47);
            this.Btn_Grabar.TabIndex = 5;
            this.Btn_Grabar.Text = "Grabar";
            this.Btn_Grabar.UseVisualStyleBackColor = true;
            this.Btn_Grabar.Click += new System.EventHandler(this.Btn_Grabar_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(21, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(326, 38);
            this.label3.TabIndex = 4;
            this.label3.Text = "Esta Autorizando el cierre de una Etiqueta de Proveedor con mas de un 10%";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Tx_Obs
            // 
            this.Tx_Obs.Location = new System.Drawing.Point(12, 251);
            this.Tx_Obs.Multiline = true;
            this.Tx_Obs.Name = "Tx_Obs";
            this.Tx_Obs.Size = new System.Drawing.Size(434, 44);
            this.Tx_Obs.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(12, 236);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(434, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ingrese Clave Observación";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Tx_clave
            // 
            this.Tx_clave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tx_clave.Location = new System.Drawing.Point(152, 28);
            this.Tx_clave.Name = "Tx_clave";
            this.Tx_clave.PasswordChar = '*';
            this.Tx_clave.Size = new System.Drawing.Size(96, 26);
            this.Tx_clave.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingrese Clave Supervisor";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Peso Etiqueta Proveedor";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(154, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Peso Cierre Etiqueta";
            // 
            // Tx_KgsPr
            // 
            this.Tx_KgsPr.BackColor = System.Drawing.Color.White;
            this.Tx_KgsPr.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tx_KgsPr.Location = new System.Drawing.Point(38, 178);
            this.Tx_KgsPr.Name = "Tx_KgsPr";
            this.Tx_KgsPr.ReadOnly = true;
            this.Tx_KgsPr.Size = new System.Drawing.Size(84, 24);
            this.Tx_KgsPr.TabIndex = 9;
            this.Tx_KgsPr.Text = "123456789";
            // 
            // Tx_KgsCierre
            // 
            this.Tx_KgsCierre.BackColor = System.Drawing.Color.White;
            this.Tx_KgsCierre.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tx_KgsCierre.Location = new System.Drawing.Point(163, 178);
            this.Tx_KgsCierre.Name = "Tx_KgsCierre";
            this.Tx_KgsCierre.ReadOnly = true;
            this.Tx_KgsCierre.Size = new System.Drawing.Size(84, 24);
            this.Tx_KgsCierre.TabIndex = 10;
            this.Tx_KgsCierre.Text = "123456789";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(297, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "% Despunte";
            // 
            // Tx_Depunte
            // 
            this.Tx_Depunte.BackColor = System.Drawing.Color.White;
            this.Tx_Depunte.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tx_Depunte.Location = new System.Drawing.Point(308, 178);
            this.Tx_Depunte.Name = "Tx_Depunte";
            this.Tx_Depunte.ReadOnly = true;
            this.Tx_Depunte.Size = new System.Drawing.Size(45, 24);
            this.Tx_Depunte.TabIndex = 12;
            this.Tx_Depunte.Text = "123456789";
            // 
            // Frm_Supervisor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 302);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_Supervisor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formulario de Autorización Supervisor";
            this.Load += new System.EventHandler(this.Frm_Supervisor_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Btn_Salir;
        private System.Windows.Forms.Button Btn_Grabar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Tx_Obs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Tx_clave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Tx_Depunte;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Tx_KgsCierre;
        private System.Windows.Forms.TextBox Tx_KgsPr;
    }
}