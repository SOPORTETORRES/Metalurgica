namespace Metalurgica
{
    partial class Frm_Adm
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
            this.Btn_CrudCamion = new System.Windows.Forms.Button();
            this.Btn_Bedegas = new System.Windows.Forms.Button();
            this.Btn_Maquinas = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Btn_CrudCamion
            // 
            this.Btn_CrudCamion.Location = new System.Drawing.Point(12, 22);
            this.Btn_CrudCamion.Name = "Btn_CrudCamion";
            this.Btn_CrudCamion.Size = new System.Drawing.Size(124, 78);
            this.Btn_CrudCamion.TabIndex = 0;
            this.Btn_CrudCamion.Text = "Camiones";
            this.Btn_CrudCamion.UseVisualStyleBackColor = true;
            this.Btn_CrudCamion.Click += new System.EventHandler(this.Btn_CrudCamion_Click);
            // 
            // Btn_Bedegas
            // 
            this.Btn_Bedegas.Location = new System.Drawing.Point(155, 22);
            this.Btn_Bedegas.Name = "Btn_Bedegas";
            this.Btn_Bedegas.Size = new System.Drawing.Size(124, 78);
            this.Btn_Bedegas.TabIndex = 1;
            this.Btn_Bedegas.Text = "Bodegas";
            this.Btn_Bedegas.UseVisualStyleBackColor = true;
            this.Btn_Bedegas.Click += new System.EventHandler(this.button1_Click);
            // 
            // Btn_Maquinas
            // 
            this.Btn_Maquinas.Location = new System.Drawing.Point(297, 22);
            this.Btn_Maquinas.Name = "Btn_Maquinas";
            this.Btn_Maquinas.Size = new System.Drawing.Size(124, 78);
            this.Btn_Maquinas.TabIndex = 2;
            this.Btn_Maquinas.Text = "Máquinas";
            this.Btn_Maquinas.UseVisualStyleBackColor = true;
            this.Btn_Maquinas.Click += new System.EventHandler(this.Btn_Maquinas_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(443, 22);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(124, 78);
            this.button3.TabIndex = 3;
            this.button3.Text = "Salir";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Frm_Adm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 119);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.Btn_Maquinas);
            this.Controls.Add(this.Btn_Bedegas);
            this.Controls.Add(this.Btn_CrudCamion);
            this.Name = "Frm_Adm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formulario de Administración ";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Btn_CrudCamion;
        private System.Windows.Forms.Button Btn_Bedegas;
        private System.Windows.Forms.Button Btn_Maquinas;
        private System.Windows.Forms.Button button3;
    }
}