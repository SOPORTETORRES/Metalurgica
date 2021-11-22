namespace Metalurgica.Pruebas
{
    partial class Frm_Impresion
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
            this.button1 = new System.Windows.Forms.Button();
            this.dtg_Impresoras = new System.Windows.Forms.DataGridView();
            this.Btn_GeneraTurno = new System.Windows.Forms.Button();
            this.Lbl_MsgTurno = new System.Windows.Forms.Label();
            this.Btn_Api = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_Impresoras)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(555, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 38);
            this.button1.TabIndex = 0;
            this.button1.Text = "Ver Impresoras";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dtg_Impresoras
            // 
            this.dtg_Impresoras.AllowUserToAddRows = false;
            this.dtg_Impresoras.AllowUserToDeleteRows = false;
            this.dtg_Impresoras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_Impresoras.Location = new System.Drawing.Point(12, 12);
            this.dtg_Impresoras.Name = "dtg_Impresoras";
            this.dtg_Impresoras.ReadOnly = true;
            this.dtg_Impresoras.Size = new System.Drawing.Size(479, 162);
            this.dtg_Impresoras.TabIndex = 1;
            // 
            // Btn_GeneraTurno
            // 
            this.Btn_GeneraTurno.Location = new System.Drawing.Point(536, 94);
            this.Btn_GeneraTurno.Name = "Btn_GeneraTurno";
            this.Btn_GeneraTurno.Size = new System.Drawing.Size(99, 103);
            this.Btn_GeneraTurno.TabIndex = 2;
            this.Btn_GeneraTurno.Text = "Genera Turno en Log Piezas";
            this.Btn_GeneraTurno.UseVisualStyleBackColor = true;
            this.Btn_GeneraTurno.Click += new System.EventHandler(this.Btn_GeneraTurno_Click);
            // 
            // Lbl_MsgTurno
            // 
            this.Lbl_MsgTurno.AutoSize = true;
            this.Lbl_MsgTurno.Location = new System.Drawing.Point(241, 360);
            this.Lbl_MsgTurno.Name = "Lbl_MsgTurno";
            this.Lbl_MsgTurno.Size = new System.Drawing.Size(35, 13);
            this.Lbl_MsgTurno.TabIndex = 3;
            this.Lbl_MsgTurno.Text = "label1";
            // 
            // Btn_Api
            // 
            this.Btn_Api.Location = new System.Drawing.Point(102, 222);
            this.Btn_Api.Name = "Btn_Api";
            this.Btn_Api.Size = new System.Drawing.Size(98, 69);
            this.Btn_Api.TabIndex = 4;
            this.Btn_Api.Text = "API RindeGastos";
            this.Btn_Api.UseVisualStyleBackColor = true;
            this.Btn_Api.Click += new System.EventHandler(this.Btn_Api_Click);
            // 
            // Frm_Impresion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 456);
            this.Controls.Add(this.Btn_Api);
            this.Controls.Add(this.Lbl_MsgTurno);
            this.Controls.Add(this.Btn_GeneraTurno);
            this.Controls.Add(this.dtg_Impresoras);
            this.Controls.Add(this.button1);
            this.Name = "Frm_Impresion";
            this.Text = "Frm_Impresion";
            ((System.ComponentModel.ISupportInitialize)(this.dtg_Impresoras)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dtg_Impresoras;
        private System.Windows.Forms.Button Btn_GeneraTurno;
        private System.Windows.Forms.Label Lbl_MsgTurno;
        private System.Windows.Forms.Button Btn_Api;
    }
}