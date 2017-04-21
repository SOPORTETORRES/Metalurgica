namespace Metalurgica.DTS
{
    partial class Frm_ImportaCorrelativo
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
            this.Dtg_Corr = new System.Windows.Forms.DataGridView();
            this.Btn_Cargar = new System.Windows.Forms.Button();
            this.Btn_Salir = new System.Windows.Forms.Button();
            this.Btn_Insertar = new System.Windows.Forms.Button();
            this.Lbl_Msg = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_Corr)).BeginInit();
            this.SuspendLayout();
            // 
            // Dtg_Corr
            // 
            this.Dtg_Corr.AllowUserToAddRows = false;
            this.Dtg_Corr.AllowUserToDeleteRows = false;
            this.Dtg_Corr.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Dtg_Corr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dtg_Corr.Location = new System.Drawing.Point(9, 111);
            this.Dtg_Corr.Name = "Dtg_Corr";
            this.Dtg_Corr.ReadOnly = true;
            this.Dtg_Corr.Size = new System.Drawing.Size(1057, 438);
            this.Dtg_Corr.TabIndex = 0;
            // 
            // Btn_Cargar
            // 
            this.Btn_Cargar.Location = new System.Drawing.Point(351, 12);
            this.Btn_Cargar.Name = "Btn_Cargar";
            this.Btn_Cargar.Size = new System.Drawing.Size(78, 46);
            this.Btn_Cargar.TabIndex = 1;
            this.Btn_Cargar.Text = "Obtener Datos";
            this.Btn_Cargar.UseVisualStyleBackColor = true;
            this.Btn_Cargar.Click += new System.EventHandler(this.Btn_Cargar_Click);
            // 
            // Btn_Salir
            // 
            this.Btn_Salir.Location = new System.Drawing.Point(620, 12);
            this.Btn_Salir.Name = "Btn_Salir";
            this.Btn_Salir.Size = new System.Drawing.Size(78, 46);
            this.Btn_Salir.TabIndex = 2;
            this.Btn_Salir.Text = "Salir";
            this.Btn_Salir.UseVisualStyleBackColor = true;
            // 
            // Btn_Insertar
            // 
            this.Btn_Insertar.Location = new System.Drawing.Point(485, 12);
            this.Btn_Insertar.Name = "Btn_Insertar";
            this.Btn_Insertar.Size = new System.Drawing.Size(78, 46);
            this.Btn_Insertar.TabIndex = 3;
            this.Btn_Insertar.Text = "Insertar";
            this.Btn_Insertar.UseVisualStyleBackColor = true;
            this.Btn_Insertar.Click += new System.EventHandler(this.Btn_Insertar_Click);
            // 
            // Lbl_Msg
            // 
            this.Lbl_Msg.AutoSize = true;
            this.Lbl_Msg.Location = new System.Drawing.Point(80, 65);
            this.Lbl_Msg.Name = "Lbl_Msg";
            this.Lbl_Msg.Size = new System.Drawing.Size(35, 13);
            this.Lbl_Msg.TabIndex = 4;
            this.Lbl_Msg.Text = "label1";
            // 
            // Frm_ImportaCorrelativo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 553);
            this.Controls.Add(this.Lbl_Msg);
            this.Controls.Add(this.Btn_Insertar);
            this.Controls.Add(this.Btn_Salir);
            this.Controls.Add(this.Btn_Cargar);
            this.Controls.Add(this.Dtg_Corr);
            this.Name = "Frm_ImportaCorrelativo";
            this.Text = "Frm_ImportaCorrelativo";
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_Corr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Dtg_Corr;
        private System.Windows.Forms.Button Btn_Cargar;
        private System.Windows.Forms.Button Btn_Salir;
        private System.Windows.Forms.Button Btn_Insertar;
        private System.Windows.Forms.Label Lbl_Msg;
    }
}