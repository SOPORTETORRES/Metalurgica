namespace Metalurgica.Tools
{
    partial class Frm_DetalleCliente
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
            this.Dtg_LC = new System.Windows.Forms.DataGridView();
            this.Dtg_PorVinc = new System.Windows.Forms.DataGridView();
            this.Btn_RevisaDatos = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_LC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_PorVinc)).BeginInit();
            this.SuspendLayout();
            // 
            // Dtg_LC
            // 
            this.Dtg_LC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.Dtg_LC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dtg_LC.Location = new System.Drawing.Point(13, 34);
            this.Dtg_LC.Name = "Dtg_LC";
            this.Dtg_LC.Size = new System.Drawing.Size(506, 426);
            this.Dtg_LC.TabIndex = 0;
            // 
            // Dtg_PorVinc
            // 
            this.Dtg_PorVinc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.Dtg_PorVinc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dtg_PorVinc.Location = new System.Drawing.Point(525, 34);
            this.Dtg_PorVinc.Name = "Dtg_PorVinc";
            this.Dtg_PorVinc.Size = new System.Drawing.Size(506, 425);
            this.Dtg_PorVinc.TabIndex = 1;
            // 
            // Btn_RevisaDatos
            // 
            this.Btn_RevisaDatos.Location = new System.Drawing.Point(173, 3);
            this.Btn_RevisaDatos.Name = "Btn_RevisaDatos";
            this.Btn_RevisaDatos.Size = new System.Drawing.Size(271, 25);
            this.Btn_RevisaDatos.TabIndex = 2;
            this.Btn_RevisaDatos.Text = "Revisa Datos Cliente";
            this.Btn_RevisaDatos.UseVisualStyleBackColor = true;
            this.Btn_RevisaDatos.Click += new System.EventHandler(this.Btn_RevisaDatos_Click);
            // 
            // Frm_DetalleCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 463);
            this.Controls.Add(this.Btn_RevisaDatos);
            this.Controls.Add(this.Dtg_PorVinc);
            this.Controls.Add(this.Dtg_LC);
            this.Name = "Frm_DetalleCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalle  por Cliente";
            this.Load += new System.EventHandler(this.Frm_DetalleCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_LC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_PorVinc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView Dtg_LC;
        private System.Windows.Forms.DataGridView Dtg_PorVinc;
        private System.Windows.Forms.Button Btn_RevisaDatos;
    }
}