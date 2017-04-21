namespace Metalurgica
{
    partial class FrmProduccion_2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProduccion_2));
            this.ctlProduccion1 = new Metalurgica.Controls.CtlProduccion();
            this.SuspendLayout();
            // 
            // ctlProduccion1
            // 
            this.ctlProduccion1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlProduccion1.Enabled = false;
            this.ctlProduccion1.Location = new System.Drawing.Point(0, 0);
            this.ctlProduccion1.Name = "ctlProduccion1";
            this.ctlProduccion1.Size = new System.Drawing.Size(923, 576);
            this.ctlProduccion1.TabIndex = 0;
            // 
            // FrmProduccion_2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 576);
            this.Controls.Add(this.ctlProduccion1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmProduccion_2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Producción";
            this.Load += new System.EventHandler(this.FrmProduccion_2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.CtlProduccion ctlProduccion1;

    }
}