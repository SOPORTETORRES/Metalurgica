namespace Metalurgica.Maquinas
{
    partial class Frm_ElementosProduccion
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
            this.Btn_Aceptar = new System.Windows.Forms.Button();
            this.Btn_Salir = new System.Windows.Forms.Button();
            this.Dgt_elementos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.Lbl_Seleccionado = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Dgt_elementos)).BeginInit();
            this.SuspendLayout();
            // 
            // Btn_Aceptar
            // 
            this.Btn_Aceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Aceptar.Location = new System.Drawing.Point(509, 217);
            this.Btn_Aceptar.Name = "Btn_Aceptar";
            this.Btn_Aceptar.Size = new System.Drawing.Size(75, 57);
            this.Btn_Aceptar.TabIndex = 0;
            this.Btn_Aceptar.Text = "Aceptar";
            this.Btn_Aceptar.UseVisualStyleBackColor = true;
            this.Btn_Aceptar.Click += new System.EventHandler(this.Btn_Aceptar_Click);
            // 
            // Btn_Salir
            // 
            this.Btn_Salir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Salir.Location = new System.Drawing.Point(509, 314);
            this.Btn_Salir.Name = "Btn_Salir";
            this.Btn_Salir.Size = new System.Drawing.Size(75, 57);
            this.Btn_Salir.TabIndex = 1;
            this.Btn_Salir.Text = "Salir";
            this.Btn_Salir.UseVisualStyleBackColor = true;
            this.Btn_Salir.Click += new System.EventHandler(this.Btn_Salir_Click);
            // 
            // Dgt_elementos
            // 
            this.Dgt_elementos.AllowUserToAddRows = false;
            this.Dgt_elementos.AllowUserToDeleteRows = false;
            this.Dgt_elementos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Dgt_elementos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgt_elementos.Location = new System.Drawing.Point(9, 12);
            this.Dgt_elementos.Name = "Dgt_elementos";
            this.Dgt_elementos.ReadOnly = true;
            this.Dgt_elementos.Size = new System.Drawing.Size(448, 389);
            this.Dgt_elementos.TabIndex = 2;
            this.Dgt_elementos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgt_elementos_CellDoubleClick);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(476, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Elemento  Seleccionado";
            // 
            // Lbl_Seleccionado
            // 
            this.Lbl_Seleccionado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Lbl_Seleccionado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Lbl_Seleccionado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Seleccionado.ForeColor = System.Drawing.Color.Red;
            this.Lbl_Seleccionado.Location = new System.Drawing.Point(480, 92);
            this.Lbl_Seleccionado.Name = "Lbl_Seleccionado";
            this.Lbl_Seleccionado.Size = new System.Drawing.Size(139, 99);
            this.Lbl_Seleccionado.TabIndex = 4;
            this.Lbl_Seleccionado.Text = "label2";
            this.Lbl_Seleccionado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Frm_ElementosProduccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 407);
            this.ControlBox = false;
            this.Controls.Add(this.Lbl_Seleccionado);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Dgt_elementos);
            this.Controls.Add(this.Btn_Salir);
            this.Controls.Add(this.Btn_Aceptar);
            this.Name = "Frm_ElementosProduccion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccione un elemento de Producción que esta con problemas";
            this.Load += new System.EventHandler(this.Frm_ElementosProduccion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Dgt_elementos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_Aceptar;
        private System.Windows.Forms.Button Btn_Salir;
        private System.Windows.Forms.DataGridView Dgt_elementos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Lbl_Seleccionado;
    }
}