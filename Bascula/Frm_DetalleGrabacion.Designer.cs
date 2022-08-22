namespace Metalurgica.Bascula
{
    partial class Frm_DetalleGrabacion
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Dtg_ResumenGuia = new System.Windows.Forms.DataGridView();
            this.Btn_Verificar = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Btn_Inicia = new System.Windows.Forms.Button();
            this.Btn_pruebas = new System.Windows.Forms.Button();
            this.Tx_INET = new System.Windows.Forms.TextBox();
            this.Tx_Imprime = new System.Windows.Forms.TextBox();
            this.Tx_Mail = new System.Windows.Forms.TextBox();
            this.Tx_Grabar = new System.Windows.Forms.TextBox();
            this.Btn_Salir = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_ResumenGuia)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Grabación de Datos de Pesaje";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Envío de Correo  de Notificación";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(420, 205);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Impresión de Documentos";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Integración Con INET";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Dtg_ResumenGuia);
            this.groupBox1.Controls.Add(this.Btn_Verificar);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.Btn_Inicia);
            this.groupBox1.Controls.Add(this.Btn_pruebas);
            this.groupBox1.Controls.Add(this.Tx_INET);
            this.groupBox1.Controls.Add(this.Tx_Imprime);
            this.groupBox1.Controls.Add(this.Tx_Mail);
            this.groupBox1.Controls.Add(this.Tx_Grabar);
            this.groupBox1.Controls.Add(this.Btn_Salir);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(715, 505);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tareas Finales";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // Dtg_ResumenGuia
            // 
            this.Dtg_ResumenGuia.AllowUserToAddRows = false;
            this.Dtg_ResumenGuia.AllowUserToDeleteRows = false;
            this.Dtg_ResumenGuia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dtg_ResumenGuia.Location = new System.Drawing.Point(10, 252);
            this.Dtg_ResumenGuia.Name = "Dtg_ResumenGuia";
            this.Dtg_ResumenGuia.ReadOnly = true;
            this.Dtg_ResumenGuia.Size = new System.Drawing.Size(394, 244);
            this.Dtg_ResumenGuia.TabIndex = 24;
            // 
            // Btn_Verificar
            // 
            this.Btn_Verificar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Verificar.Location = new System.Drawing.Point(234, 221);
            this.Btn_Verificar.Name = "Btn_Verificar";
            this.Btn_Verificar.Size = new System.Drawing.Size(82, 21);
            this.Btn_Verificar.TabIndex = 23;
            this.Btn_Verificar.Text = "Vincular Guía";
            this.Btn_Verificar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Verificar.UseVisualStyleBackColor = true;
            this.Btn_Verificar.Visible = false;
            this.Btn_Verificar.Click += new System.EventHandler(this.Btn_Verificar_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 221);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(214, 20);
            this.textBox1.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 205);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(217, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Vinculación de la Guía de INET en Cubigest";
            // 
            // Btn_Inicia
            // 
            this.Btn_Inicia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Inicia.Location = new System.Drawing.Point(621, 75);
            this.Btn_Inicia.Name = "Btn_Inicia";
            this.Btn_Inicia.Size = new System.Drawing.Size(82, 53);
            this.Btn_Inicia.TabIndex = 20;
            this.Btn_Inicia.Text = "Inicia Proceso";
            this.Btn_Inicia.UseVisualStyleBackColor = true;
            this.Btn_Inicia.Visible = false;
            this.Btn_Inicia.Click += new System.EventHandler(this.Btn_Inicia_Click);
            // 
            // Btn_pruebas
            // 
            this.Btn_pruebas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_pruebas.Location = new System.Drawing.Point(533, 12);
            this.Btn_pruebas.Name = "Btn_pruebas";
            this.Btn_pruebas.Size = new System.Drawing.Size(82, 53);
            this.Btn_pruebas.TabIndex = 19;
            this.Btn_pruebas.Text = "Imprimir  despacho";
            this.Btn_pruebas.UseVisualStyleBackColor = true;
            this.Btn_pruebas.Click += new System.EventHandler(this.Btn_pruebas_Click);
            // 
            // Tx_INET
            // 
            this.Tx_INET.Location = new System.Drawing.Point(12, 164);
            this.Tx_INET.Multiline = true;
            this.Tx_INET.Name = "Tx_INET";
            this.Tx_INET.ReadOnly = true;
            this.Tx_INET.Size = new System.Drawing.Size(383, 29);
            this.Tx_INET.TabIndex = 18;
            // 
            // Tx_Imprime
            // 
            this.Tx_Imprime.Location = new System.Drawing.Point(423, 221);
            this.Tx_Imprime.Name = "Tx_Imprime";
            this.Tx_Imprime.ReadOnly = true;
            this.Tx_Imprime.Size = new System.Drawing.Size(214, 20);
            this.Tx_Imprime.TabIndex = 17;
            // 
            // Tx_Mail
            // 
            this.Tx_Mail.Location = new System.Drawing.Point(12, 108);
            this.Tx_Mail.Name = "Tx_Mail";
            this.Tx_Mail.ReadOnly = true;
            this.Tx_Mail.Size = new System.Drawing.Size(383, 20);
            this.Tx_Mail.TabIndex = 16;
            // 
            // Tx_Grabar
            // 
            this.Tx_Grabar.Location = new System.Drawing.Point(12, 53);
            this.Tx_Grabar.Name = "Tx_Grabar";
            this.Tx_Grabar.ReadOnly = true;
            this.Tx_Grabar.Size = new System.Drawing.Size(383, 20);
            this.Tx_Grabar.TabIndex = 15;
            // 
            // Btn_Salir
            // 
            this.Btn_Salir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Salir.Location = new System.Drawing.Point(621, 12);
            this.Btn_Salir.Name = "Btn_Salir";
            this.Btn_Salir.Size = new System.Drawing.Size(82, 53);
            this.Btn_Salir.TabIndex = 14;
            this.Btn_Salir.Text = "Salir";
            this.Btn_Salir.UseVisualStyleBackColor = true;
            this.Btn_Salir.Click += new System.EventHandler(this.Btn_Salir_Click);
            // 
            // Frm_DetalleGrabacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 505);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_DetalleGrabacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formulario de Visualización de las Tareas de Despacho de Camión";
            this.Load += new System.EventHandler(this.Frm_DetalleGrabacion_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_ResumenGuia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox Tx_INET;
        private System.Windows.Forms.TextBox Tx_Imprime;
        private System.Windows.Forms.TextBox Tx_Mail;
        private System.Windows.Forms.TextBox Tx_Grabar;
        private System.Windows.Forms.Button Btn_Salir;
        private System.Windows.Forms.Button Btn_pruebas;
        private System.Windows.Forms.Button Btn_Inicia;
        private System.Windows.Forms.Button Btn_Verificar;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView Dtg_ResumenGuia;
    }
}