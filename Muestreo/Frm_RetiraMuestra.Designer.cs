namespace Metalurgica.Muestreo
{
    partial class Frm_RetiraMuestra
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_RetiraMuestra));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Cmb_UsuarioRetira = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Tx_FechaSolicitud = new System.Windows.Forms.TextBox();
            this.tx_KilosProducidos = new System.Windows.Forms.TextBox();
            this.Tx_KilosMuestreo = new System.Windows.Forms.TextBox();
            this.Tx_Diametro = new System.Windows.Forms.TextBox();
            this.Tx_IdMuestreo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.Btn_grabar = new System.Windows.Forms.Button();
            this.Tx_Obs = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.Tx_IdSolicitudMuestreo = new System.Windows.Forms.TextBox();
            this.Tx_ObsRetiro = new System.Windows.Forms.TextBox();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Cmb_UsuarioRetira);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(447, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(281, 71);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Datos del Usuario que Retira la Muestra";
            // 
            // Cmb_UsuarioRetira
            // 
            this.Cmb_UsuarioRetira.FormattingEnabled = true;
            this.Cmb_UsuarioRetira.Location = new System.Drawing.Point(61, 20);
            this.Cmb_UsuarioRetira.Name = "Cmb_UsuarioRetira";
            this.Cmb_UsuarioRetira.Size = new System.Drawing.Size(210, 21);
            this.Cmb_UsuarioRetira.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Usuario";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.Tx_ObsRetiro);
            this.groupBox2.Location = new System.Drawing.Point(2, 179);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(808, 244);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Observaciones del Retiro de la Muestra";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Tx_FechaSolicitud);
            this.groupBox1.Controls.Add(this.tx_KilosProducidos);
            this.groupBox1.Controls.Add(this.Tx_KilosMuestreo);
            this.groupBox1.Controls.Add(this.Tx_Diametro);
            this.groupBox1.Controls.Add(this.Tx_IdMuestreo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(7, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(432, 71);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del Muestreo  a Retirar";
            // 
            // Tx_FechaSolicitud
            // 
            this.Tx_FechaSolicitud.Location = new System.Drawing.Point(336, 37);
            this.Tx_FechaSolicitud.Name = "Tx_FechaSolicitud";
            this.Tx_FechaSolicitud.Size = new System.Drawing.Size(82, 20);
            this.Tx_FechaSolicitud.TabIndex = 15;
            // 
            // tx_KilosProducidos
            // 
            this.tx_KilosProducidos.Location = new System.Drawing.Point(242, 37);
            this.tx_KilosProducidos.Name = "tx_KilosProducidos";
            this.tx_KilosProducidos.Size = new System.Drawing.Size(63, 20);
            this.tx_KilosProducidos.TabIndex = 14;
            // 
            // Tx_KilosMuestreo
            // 
            this.Tx_KilosMuestreo.Location = new System.Drawing.Point(146, 37);
            this.Tx_KilosMuestreo.Name = "Tx_KilosMuestreo";
            this.Tx_KilosMuestreo.Size = new System.Drawing.Size(69, 20);
            this.Tx_KilosMuestreo.TabIndex = 12;
            // 
            // Tx_Diametro
            // 
            this.Tx_Diametro.Location = new System.Drawing.Point(85, 37);
            this.Tx_Diametro.Name = "Tx_Diametro";
            this.Tx_Diametro.Size = new System.Drawing.Size(40, 20);
            this.Tx_Diametro.TabIndex = 11;
            // 
            // Tx_IdMuestreo
            // 
            this.Tx_IdMuestreo.Location = new System.Drawing.Point(9, 37);
            this.Tx_IdMuestreo.Name = "Tx_IdMuestreo";
            this.Tx_IdMuestreo.Size = new System.Drawing.Size(56, 20);
            this.Tx_IdMuestreo.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(336, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Fecha Solicitud";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(236, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Kilos Producidos";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(145, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Kilos Muestreo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(83, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Diámetro";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Id Muestreo";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Untitled (332).ico");
            this.imageList1.Images.SetKeyName(1, "Untitled (158).ico");
            // 
            // Btn_grabar
            // 
            this.Btn_grabar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_grabar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_grabar.ImageIndex = 0;
            this.Btn_grabar.ImageList = this.imageList1;
            this.Btn_grabar.Location = new System.Drawing.Point(739, 15);
            this.Btn_grabar.Name = "Btn_grabar";
            this.Btn_grabar.Size = new System.Drawing.Size(75, 61);
            this.Btn_grabar.TabIndex = 7;
            this.Btn_grabar.Text = "Grabar";
            this.Btn_grabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_grabar.UseVisualStyleBackColor = true;
            this.Btn_grabar.Click += new System.EventHandler(this.Btn_grabar_Click);
            // 
            // Tx_Obs
            // 
            this.Tx_Obs.Location = new System.Drawing.Point(9, 103);
            this.Tx_Obs.Multiline = true;
            this.Tx_Obs.Name = "Tx_Obs";
            this.Tx_Obs.Size = new System.Drawing.Size(716, 68);
            this.Tx_Obs.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 85);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Observaciones";
            // 
            // Tx_IdSolicitudMuestreo
            // 
            this.Tx_IdSolicitudMuestreo.Location = new System.Drawing.Point(194, 77);
            this.Tx_IdSolicitudMuestreo.Name = "Tx_IdSolicitudMuestreo";
            this.Tx_IdSolicitudMuestreo.Size = new System.Drawing.Size(56, 20);
            this.Tx_IdSolicitudMuestreo.TabIndex = 16;
            this.Tx_IdSolicitudMuestreo.Visible = false;
            // 
            // Tx_ObsRetiro
            // 
            this.Tx_ObsRetiro.Location = new System.Drawing.Point(5, 19);
            this.Tx_ObsRetiro.Multiline = true;
            this.Tx_ObsRetiro.Name = "Tx_ObsRetiro";
            this.Tx_ObsRetiro.Size = new System.Drawing.Size(785, 215);
            this.Tx_ObsRetiro.TabIndex = 10;
            // 
            // Frm_RetiraMuestra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 425);
            this.Controls.Add(this.Tx_IdSolicitudMuestreo);
            this.Controls.Add(this.Tx_Obs);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.Btn_grabar);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_RetiraMuestra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formulario de Retiro de Muestra";
            this.Load += new System.EventHandler(this.Frm_RetiraMuestra_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button Btn_grabar;
        private System.Windows.Forms.TextBox Tx_Obs;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Tx_FechaSolicitud;
        private System.Windows.Forms.TextBox tx_KilosProducidos;
        private System.Windows.Forms.TextBox Tx_KilosMuestreo;
        private System.Windows.Forms.TextBox Tx_Diametro;
        private System.Windows.Forms.TextBox Tx_IdMuestreo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Tx_IdSolicitudMuestreo;
        private System.Windows.Forms.ComboBox Cmb_UsuarioRetira;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Tx_ObsRetiro;

    }
}