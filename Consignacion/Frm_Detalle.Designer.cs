namespace Metalurgica.Consignacion
{
    partial class Frm_Detalle
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
            this.Btn_Salir = new System.Windows.Forms.Button();
            this.Dtg_Datos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_Datos)).BeginInit();
            this.SuspendLayout();
            // 
            // Btn_Salir
            // 
            this.Btn_Salir.Location = new System.Drawing.Point(712, 36);
            this.Btn_Salir.Name = "Btn_Salir";
            this.Btn_Salir.Size = new System.Drawing.Size(75, 52);
            this.Btn_Salir.TabIndex = 0;
            this.Btn_Salir.Text = "&Salir";
            this.Btn_Salir.UseVisualStyleBackColor = true;
            this.Btn_Salir.Click += new System.EventHandler(this.Btn_Salir_Click);
            // 
            // Dtg_Datos
            // 
            this.Dtg_Datos.AllowUserToAddRows = false;
            this.Dtg_Datos.AllowUserToDeleteRows = false;
            this.Dtg_Datos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dtg_Datos.Location = new System.Drawing.Point(12, 36);
            this.Dtg_Datos.Name = "Dtg_Datos";
            this.Dtg_Datos.ReadOnly = true;
            this.Dtg_Datos.Size = new System.Drawing.Size(683, 281);
            this.Dtg_Datos.TabIndex = 1;
            this.Dtg_Datos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dtg_Datos_CellDoubleClick);
            // 
            // Frm_Detalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 473);
            this.Controls.Add(this.Dtg_Datos);
            this.Controls.Add(this.Btn_Salir);
            this.Name = "Frm_Detalle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_Datos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Btn_Salir;
        private System.Windows.Forms.DataGridView Dtg_Datos;
    }
}