namespace Metalurgica.SolicitudMP
{
    partial class frmVisializar
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
            this.Dtg_Datos = new System.Windows.Forms.DataGridView();
            this.Lbl_Msg = new System.Windows.Forms.Label();
            this.Btn_Dev = new System.Windows.Forms.Button();
            this.Tx_Det_Id = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_Datos)).BeginInit();
            this.SuspendLayout();
            // 
            // Dtg_Datos
            // 
            this.Dtg_Datos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Dtg_Datos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dtg_Datos.Location = new System.Drawing.Point(5, 77);
            this.Dtg_Datos.Name = "Dtg_Datos";
            this.Dtg_Datos.Size = new System.Drawing.Size(919, 459);
            this.Dtg_Datos.TabIndex = 0;
            this.Dtg_Datos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dtg_Datos_CellClick);
            this.Dtg_Datos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dtg_Datos_CellContentClick);
            // 
            // Lbl_Msg
            // 
            this.Lbl_Msg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Lbl_Msg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Msg.Location = new System.Drawing.Point(34, 14);
            this.Lbl_Msg.Name = "Lbl_Msg";
            this.Lbl_Msg.Size = new System.Drawing.Size(695, 50);
            this.Lbl_Msg.TabIndex = 1;
            this.Lbl_Msg.Text = "Detalle de solicitudes de Material realizadas por el Usuario: @User, en el Turno:" +
    " @turno ";
            this.Lbl_Msg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Btn_Dev
            // 
            this.Btn_Dev.Location = new System.Drawing.Point(756, 19);
            this.Btn_Dev.Name = "Btn_Dev";
            this.Btn_Dev.Size = new System.Drawing.Size(75, 37);
            this.Btn_Dev.TabIndex = 2;
            this.Btn_Dev.Text = "Devolución MP";
            this.Btn_Dev.UseVisualStyleBackColor = true;
            this.Btn_Dev.Visible = false;
            this.Btn_Dev.Click += new System.EventHandler(this.Btn_Dev_Click);
            // 
            // Tx_Det_Id
            // 
            this.Tx_Det_Id.Location = new System.Drawing.Point(860, 19);
            this.Tx_Det_Id.Name = "Tx_Det_Id";
            this.Tx_Det_Id.Size = new System.Drawing.Size(34, 20);
            this.Tx_Det_Id.TabIndex = 3;
            this.Tx_Det_Id.Visible = false;
            // 
            // frmVisializar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 540);
            this.Controls.Add(this.Tx_Det_Id);
            this.Controls.Add(this.Btn_Dev);
            this.Controls.Add(this.Lbl_Msg);
            this.Controls.Add(this.Dtg_Datos);
            this.Name = "frmVisializar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formulario de visualización de SMP";
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_Datos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Dtg_Datos;
        private System.Windows.Forms.Label Lbl_Msg;
        private System.Windows.Forms.Button Btn_Dev;
        private System.Windows.Forms.TextBox Tx_Det_Id;
    }
}