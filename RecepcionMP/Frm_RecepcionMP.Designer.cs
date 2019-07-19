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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Tx_OC = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Tx_FechaGD = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Tx_GuiaDesp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Dtg_Etiquetas = new System.Windows.Forms.DataGridView();
            this.Tx_EtiquetaAza = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Tx_TotalKgs = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_Etiquetas)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Tx_OC);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.Tx_FechaGD);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Tx_GuiaDesp);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(627, 83);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de la Recepción de Material";
            // 
            // Tx_OC
            // 
            this.Tx_OC.Location = new System.Drawing.Point(474, 49);
            this.Tx_OC.MaxLength = 10;
            this.Tx_OC.Name = "Tx_OC";
            this.Tx_OC.Size = new System.Drawing.Size(100, 20);
            this.Tx_OC.TabIndex = 5;
            this.Tx_OC.Validating += new System.ComponentModel.CancelEventHandler(this.Tx_OC_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(432, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ingrese el Nro de Orden de Compra";
            // 
            // Tx_FechaGD
            // 
            this.Tx_FechaGD.Location = new System.Drawing.Point(259, 49);
            this.Tx_FechaGD.MaxLength = 10;
            this.Tx_FechaGD.Name = "Tx_FechaGD";
            this.Tx_FechaGD.Size = new System.Drawing.Size(100, 20);
            this.Tx_FechaGD.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(208, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(195, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ingrese la Fecha de Guía de Despacho";
            // 
            // Tx_GuiaDesp
            // 
            this.Tx_GuiaDesp.Location = new System.Drawing.Point(34, 49);
            this.Tx_GuiaDesp.MaxLength = 10;
            this.Tx_GuiaDesp.Name = "Tx_GuiaDesp";
            this.Tx_GuiaDesp.Size = new System.Drawing.Size(100, 20);
            this.Tx_GuiaDesp.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingrese el Nro de Guía de Despacho";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.Dtg_Etiquetas);
            this.groupBox2.Location = new System.Drawing.Point(13, 103);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(627, 415);
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
            this.Dtg_Etiquetas.Size = new System.Drawing.Size(621, 396);
            this.Dtg_Etiquetas.TabIndex = 0;
            // 
            // Tx_EtiquetaAza
            // 
            this.Tx_EtiquetaAza.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Tx_EtiquetaAza.Location = new System.Drawing.Point(666, 103);
            this.Tx_EtiquetaAza.MaxLength = 100;
            this.Tx_EtiquetaAza.Name = "Tx_EtiquetaAza";
            this.Tx_EtiquetaAza.Size = new System.Drawing.Size(100, 20);
            this.Tx_EtiquetaAza.TabIndex = 7;
            this.Tx_EtiquetaAza.Validating += new System.ComponentModel.CancelEventHandler(this.Tx_EtiquetaAza_Validating);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(680, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Etiqueta Aza";
            // 
            // Tx_TotalKgs
            // 
            this.Tx_TotalKgs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Tx_TotalKgs.Location = new System.Drawing.Point(666, 206);
            this.Tx_TotalKgs.MaxLength = 10;
            this.Tx_TotalKgs.Name = "Tx_TotalKgs";
            this.Tx_TotalKgs.Size = new System.Drawing.Size(100, 20);
            this.Tx_TotalKgs.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(680, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Total Kgs";
            // 
            // Frm_RecepcionMP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 522);
            this.Controls.Add(this.Tx_TotalKgs);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Tx_EtiquetaAza);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_RecepcionMP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formulario de  Recepción de Materia  Prima";
            this.Load += new System.EventHandler(this.Frm_RecepcionMP_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_Etiquetas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox Tx_GuiaDesp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Tx_FechaGD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Tx_OC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView Dtg_Etiquetas;
        private System.Windows.Forms.TextBox Tx_EtiquetaAza;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Tx_TotalKgs;
        private System.Windows.Forms.Label label5;
    }
}