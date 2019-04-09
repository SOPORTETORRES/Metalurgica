namespace Metalurgica.Conectores
{
    partial class Frm_CuadroProgramacion
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
            this.Dt_FechaIni = new System.Windows.Forms.DateTimePicker();
            this.Btn_DiaSel = new System.Windows.Forms.Button();
            this.Btn_Dia1 = new System.Windows.Forms.Button();
            this.Btn_Dia3 = new System.Windows.Forms.Button();
            this.Btn_Dia2 = new System.Windows.Forms.Button();
            this.Btn_Dia5 = new System.Windows.Forms.Button();
            this.Btn_Dia4 = new System.Windows.Forms.Button();
            this.Btn_Dia6 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Btn_Produccion = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Dt_FechaIni
            // 
            this.Dt_FechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Dt_FechaIni.Location = new System.Drawing.Point(138, 17);
            this.Dt_FechaIni.Name = "Dt_FechaIni";
            this.Dt_FechaIni.Size = new System.Drawing.Size(104, 20);
            this.Dt_FechaIni.TabIndex = 0;
            this.Dt_FechaIni.ValueChanged += new System.EventHandler(this.Dt_FechaIni_ValueChanged);
            // 
            // Btn_DiaSel
            // 
            this.Btn_DiaSel.Location = new System.Drawing.Point(12, 58);
            this.Btn_DiaSel.Name = "Btn_DiaSel";
            this.Btn_DiaSel.Size = new System.Drawing.Size(104, 65);
            this.Btn_DiaSel.TabIndex = 1;
            this.Btn_DiaSel.Text = "07/11/2018 \r\n320 Conectores";
            this.Btn_DiaSel.UseVisualStyleBackColor = true;
            this.Btn_DiaSel.Click += new System.EventHandler(this.Btn_DiaSel_Click);
            // 
            // Btn_Dia1
            // 
            this.Btn_Dia1.Location = new System.Drawing.Point(138, 58);
            this.Btn_Dia1.Name = "Btn_Dia1";
            this.Btn_Dia1.Size = new System.Drawing.Size(104, 65);
            this.Btn_Dia1.TabIndex = 2;
            this.Btn_Dia1.Text = "07/11/2018";
            this.Btn_Dia1.UseVisualStyleBackColor = true;
            this.Btn_Dia1.Click += new System.EventHandler(this.Btn_Dia1_Click);
            // 
            // Btn_Dia3
            // 
            this.Btn_Dia3.Location = new System.Drawing.Point(395, 58);
            this.Btn_Dia3.Name = "Btn_Dia3";
            this.Btn_Dia3.Size = new System.Drawing.Size(104, 65);
            this.Btn_Dia3.TabIndex = 4;
            this.Btn_Dia3.Text = "07/11/2018";
            this.Btn_Dia3.UseVisualStyleBackColor = true;
            this.Btn_Dia3.Click += new System.EventHandler(this.Btn_Dia3_Click);
            // 
            // Btn_Dia2
            // 
            this.Btn_Dia2.Location = new System.Drawing.Point(264, 58);
            this.Btn_Dia2.Name = "Btn_Dia2";
            this.Btn_Dia2.Size = new System.Drawing.Size(104, 65);
            this.Btn_Dia2.TabIndex = 3;
            this.Btn_Dia2.Text = "07/11/2018";
            this.Btn_Dia2.UseVisualStyleBackColor = true;
            this.Btn_Dia2.Click += new System.EventHandler(this.Btn_Dia2_Click);
            // 
            // Btn_Dia5
            // 
            this.Btn_Dia5.Location = new System.Drawing.Point(662, 58);
            this.Btn_Dia5.Name = "Btn_Dia5";
            this.Btn_Dia5.Size = new System.Drawing.Size(104, 65);
            this.Btn_Dia5.TabIndex = 6;
            this.Btn_Dia5.Text = "07/11/2018";
            this.Btn_Dia5.UseVisualStyleBackColor = true;
            this.Btn_Dia5.Click += new System.EventHandler(this.Btn_Dia5_Click);
            // 
            // Btn_Dia4
            // 
            this.Btn_Dia4.Location = new System.Drawing.Point(528, 58);
            this.Btn_Dia4.Name = "Btn_Dia4";
            this.Btn_Dia4.Size = new System.Drawing.Size(104, 65);
            this.Btn_Dia4.TabIndex = 5;
            this.Btn_Dia4.Text = "07/11/2018";
            this.Btn_Dia4.UseVisualStyleBackColor = true;
            this.Btn_Dia4.Click += new System.EventHandler(this.Btn_Dia4_Click);
            // 
            // Btn_Dia6
            // 
            this.Btn_Dia6.Location = new System.Drawing.Point(794, 58);
            this.Btn_Dia6.Name = "Btn_Dia6";
            this.Btn_Dia6.Size = new System.Drawing.Size(104, 65);
            this.Btn_Dia6.TabIndex = 7;
            this.Btn_Dia6.Text = "07/11/2018";
            this.Btn_Dia6.UseVisualStyleBackColor = true;
            this.Btn_Dia6.Click += new System.EventHandler(this.Btn_Dia6_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(12, 140);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(904, 334);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Planificación del Día";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 16);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(898, 315);
            this.dataGridView1.TabIndex = 0;
            // 
            // Btn_Produccion
            // 
            this.Btn_Produccion.Location = new System.Drawing.Point(556, 17);
            this.Btn_Produccion.Name = "Btn_Produccion";
            this.Btn_Produccion.Size = new System.Drawing.Size(144, 23);
            this.Btn_Produccion.TabIndex = 9;
            this.Btn_Produccion.Text = "Produccion Conectores";
            this.Btn_Produccion.UseVisualStyleBackColor = true;
            this.Btn_Produccion.Click += new System.EventHandler(this.Btn_Produccion_Click);
            // 
            // Frm_CuadroProgramacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 476);
            this.Controls.Add(this.Btn_Produccion);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Btn_Dia6);
            this.Controls.Add(this.Btn_Dia5);
            this.Controls.Add(this.Btn_Dia4);
            this.Controls.Add(this.Btn_Dia3);
            this.Controls.Add(this.Btn_Dia2);
            this.Controls.Add(this.Btn_Dia1);
            this.Controls.Add(this.Btn_DiaSel);
            this.Controls.Add(this.Dt_FechaIni);
            this.Name = "Frm_CuadroProgramacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formulario de Planificación de la Producción de Conectores";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker Dt_FechaIni;
        private System.Windows.Forms.Button Btn_DiaSel;
        private System.Windows.Forms.Button Btn_Dia1;
        private System.Windows.Forms.Button Btn_Dia3;
        private System.Windows.Forms.Button Btn_Dia2;
        private System.Windows.Forms.Button Btn_Dia5;
        private System.Windows.Forms.Button Btn_Dia4;
        private System.Windows.Forms.Button Btn_Dia6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button Btn_Produccion;
    }
}