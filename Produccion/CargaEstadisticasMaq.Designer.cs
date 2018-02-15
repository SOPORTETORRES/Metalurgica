namespace Metalurgica.Produccion
{
    partial class CargaEstadisticasMaq
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
            this.Rb_noche = new System.Windows.Forms.RadioButton();
            this.Rb_dia = new System.Windows.Forms.RadioButton();
            this.Tx_Maq_nro = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Dtp_Inicio = new System.Windows.Forms.DateTimePicker();
            this.Btn_buscar = new System.Windows.Forms.Button();
            this.Dtg_Datos = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_Datos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Rb_noche);
            this.groupBox1.Controls.Add(this.Rb_dia);
            this.groupBox1.Controls.Add(this.Tx_Maq_nro);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Dtp_Inicio);
            this.groupBox1.Location = new System.Drawing.Point(4, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(388, 78);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Para la geneeracion";
            // 
            // Rb_noche
            // 
            this.Rb_noche.AutoSize = true;
            this.Rb_noche.Location = new System.Drawing.Point(258, 45);
            this.Rb_noche.Name = "Rb_noche";
            this.Rb_noche.Size = new System.Drawing.Size(88, 17);
            this.Rb_noche.TabIndex = 5;
            this.Rb_noche.Text = "Turno Noche";
            this.Rb_noche.UseVisualStyleBackColor = true;
            // 
            // Rb_dia
            // 
            this.Rb_dia.AutoSize = true;
            this.Rb_dia.Checked = true;
            this.Rb_dia.Location = new System.Drawing.Point(258, 22);
            this.Rb_dia.Name = "Rb_dia";
            this.Rb_dia.Size = new System.Drawing.Size(74, 17);
            this.Rb_dia.TabIndex = 4;
            this.Rb_dia.TabStop = true;
            this.Rb_dia.Text = "Turno Día";
            this.Rb_dia.UseVisualStyleBackColor = true;
            // 
            // Tx_Maq_nro
            // 
            this.Tx_Maq_nro.Location = new System.Drawing.Point(151, 38);
            this.Tx_Maq_nro.Name = "Tx_Maq_nro";
            this.Tx_Maq_nro.Size = new System.Drawing.Size(56, 20);
            this.Tx_Maq_nro.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(155, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Maq_nro";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Inicio";
            // 
            // Dtp_Inicio
            // 
            this.Dtp_Inicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Dtp_Inicio.Location = new System.Drawing.Point(16, 41);
            this.Dtp_Inicio.Name = "Dtp_Inicio";
            this.Dtp_Inicio.Size = new System.Drawing.Size(93, 20);
            this.Dtp_Inicio.TabIndex = 0;
            // 
            // Btn_buscar
            // 
            this.Btn_buscar.Location = new System.Drawing.Point(444, 23);
            this.Btn_buscar.Name = "Btn_buscar";
            this.Btn_buscar.Size = new System.Drawing.Size(75, 40);
            this.Btn_buscar.TabIndex = 1;
            this.Btn_buscar.Text = "Buscar";
            this.Btn_buscar.UseVisualStyleBackColor = true;
            this.Btn_buscar.Click += new System.EventHandler(this.Btn_buscar_Click);
            // 
            // Dtg_Datos
            // 
            this.Dtg_Datos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Dtg_Datos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dtg_Datos.Location = new System.Drawing.Point(4, 90);
            this.Dtg_Datos.Name = "Dtg_Datos";
            this.Dtg_Datos.Size = new System.Drawing.Size(875, 280);
            this.Dtg_Datos.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(548, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Maq_nro";
            // 
            // CargaEstadisticasMaq
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 375);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Dtg_Datos);
            this.Controls.Add(this.Btn_buscar);
            this.Controls.Add(this.groupBox1);
            this.Name = "CargaEstadisticasMaq";
            this.Text = "CargaEstadisticasMaq";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_Datos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton Rb_noche;
        private System.Windows.Forms.RadioButton Rb_dia;
        private System.Windows.Forms.TextBox Tx_Maq_nro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker Dtp_Inicio;
        private System.Windows.Forms.Button Btn_buscar;
        private System.Windows.Forms.DataGridView Dtg_Datos;
        private System.Windows.Forms.Label label3;
    }
}