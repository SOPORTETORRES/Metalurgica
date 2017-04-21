namespace Metalurgica.Controls
{
    partial class CtlGrilla
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.Lbl_Titulo = new System.Windows.Forms.Label();
            this.Dtg_Resultado = new System.Windows.Forms.DataGridView();
            this.Btn_Aceptar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_Resultado)).BeginInit();
            this.SuspendLayout();
            // 
            // Lbl_Titulo
            // 
            this.Lbl_Titulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Lbl_Titulo.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Lbl_Titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Titulo.ForeColor = System.Drawing.Color.White;
            this.Lbl_Titulo.Location = new System.Drawing.Point(7, 5);
            this.Lbl_Titulo.Name = "Lbl_Titulo";
            this.Lbl_Titulo.Size = new System.Drawing.Size(620, 23);
            this.Lbl_Titulo.TabIndex = 0;
            this.Lbl_Titulo.Text = "label1";
            this.Lbl_Titulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Dtg_Resultado
            // 
            this.Dtg_Resultado.AllowUserToAddRows = false;
            this.Dtg_Resultado.AllowUserToDeleteRows = false;
            this.Dtg_Resultado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Dtg_Resultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dtg_Resultado.Location = new System.Drawing.Point(7, 32);
            this.Dtg_Resultado.Name = "Dtg_Resultado";
            this.Dtg_Resultado.Size = new System.Drawing.Size(616, 462);
            this.Dtg_Resultado.TabIndex = 1;
            this.Dtg_Resultado.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dtg_Resultado_CellContentClick);
            this.Dtg_Resultado.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dtg_Resultado_CellDoubleClick);
            // 
            // Btn_Aceptar
            // 
            this.Btn_Aceptar.Location = new System.Drawing.Point(10, 6);
            this.Btn_Aceptar.Name = "Btn_Aceptar";
            this.Btn_Aceptar.Size = new System.Drawing.Size(72, 21);
            this.Btn_Aceptar.TabIndex = 2;
            this.Btn_Aceptar.Text = "Aceptar";
            this.Btn_Aceptar.UseVisualStyleBackColor = true;
            this.Btn_Aceptar.Visible = false;
            this.Btn_Aceptar.Click += new System.EventHandler(this.Btn_Aceptar_Click);
            // 
            // CtlGrilla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Btn_Aceptar);
            this.Controls.Add(this.Dtg_Resultado);
            this.Controls.Add(this.Lbl_Titulo);
            this.Name = "CtlGrilla";
            this.Size = new System.Drawing.Size(630, 501);
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_Resultado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Lbl_Titulo;
        private System.Windows.Forms.DataGridView Dtg_Resultado;
        private System.Windows.Forms.Button Btn_Aceptar;
    }
}
