namespace Metalurgica
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
            this.ctlGrilla1 = new Metalurgica.Controls.CtlGrilla();
            this.SuspendLayout();
            // 
            // ctlGrilla1
            // 
            this.ctlGrilla1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ctlGrilla1.Location = new System.Drawing.Point(2, 4);
            this.ctlGrilla1.Name = "ctlGrilla1";
            this.ctlGrilla1.Size = new System.Drawing.Size(837, 501);
            this.ctlGrilla1.TabIndex = 0;
            this.ctlGrilla1.Load += new System.EventHandler(this.ctlGrilla1_Load);
            // 
            // Frm_Detalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 503);
            this.Controls.Add(this.ctlGrilla1);
            this.Name = "Frm_Detalle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_Detalle";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.CtlGrilla ctlGrilla1;
    }
}