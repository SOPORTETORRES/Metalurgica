namespace Metalurgica.Maquinas
{
    partial class Frm_MtoTotem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_MtoTotem));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.Btn_VerMaq = new System.Windows.Forms.Button();
            this.Btn_Salir = new System.Windows.Forms.Button();
            this.Btn_Limpiar = new System.Windows.Forms.Button();
            this.Btn_Grabar = new System.Windows.Forms.Button();
            this.Tx_Id = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Tx_Nombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Cmb_TipoTotem = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Tx_Obs = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Untitled (114).ico");
            this.imageList1.Images.SetKeyName(1, "Untitled (139).ico");
            this.imageList1.Images.SetKeyName(2, "Untitled (414).ico");
            this.imageList1.Images.SetKeyName(3, "Untitled (358).ico");
            this.imageList1.Images.SetKeyName(4, "Untitled (149).ico");
            this.imageList1.Images.SetKeyName(5, "Untitled (157).ico");
            this.imageList1.Images.SetKeyName(6, "Untitled (182).ico");
            // 
            // Btn_VerMaq
            // 
            this.Btn_VerMaq.Image = global::Metalurgica.Properties.Resources.help;
            this.Btn_VerMaq.Location = new System.Drawing.Point(481, 18);
            this.Btn_VerMaq.Name = "Btn_VerMaq";
            this.Btn_VerMaq.Size = new System.Drawing.Size(30, 23);
            this.Btn_VerMaq.TabIndex = 27;
            this.Btn_VerMaq.UseVisualStyleBackColor = true;
            this.Btn_VerMaq.Click += new System.EventHandler(this.Btn_VerMaq_Click);
            // 
            // Btn_Salir
            // 
            this.Btn_Salir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Salir.ImageIndex = 5;
            this.Btn_Salir.ImageList = this.imageList1;
            this.Btn_Salir.Location = new System.Drawing.Point(535, 259);
            this.Btn_Salir.Name = "Btn_Salir";
            this.Btn_Salir.Size = new System.Drawing.Size(75, 56);
            this.Btn_Salir.TabIndex = 26;
            this.Btn_Salir.Text = "&Salir";
            this.Btn_Salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Salir.UseVisualStyleBackColor = true;
            this.Btn_Salir.Click += new System.EventHandler(this.Btn_Salir_Click);
            // 
            // Btn_Limpiar
            // 
            this.Btn_Limpiar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Limpiar.ImageIndex = 6;
            this.Btn_Limpiar.ImageList = this.imageList1;
            this.Btn_Limpiar.Location = new System.Drawing.Point(535, 152);
            this.Btn_Limpiar.Name = "Btn_Limpiar";
            this.Btn_Limpiar.Size = new System.Drawing.Size(75, 56);
            this.Btn_Limpiar.TabIndex = 25;
            this.Btn_Limpiar.Text = "&Limpiar";
            this.Btn_Limpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Limpiar.UseVisualStyleBackColor = true;
            this.Btn_Limpiar.Click += new System.EventHandler(this.Btn_Limpiar_Click);
            // 
            // Btn_Grabar
            // 
            this.Btn_Grabar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Grabar.ImageIndex = 0;
            this.Btn_Grabar.ImageList = this.imageList1;
            this.Btn_Grabar.Location = new System.Drawing.Point(535, 40);
            this.Btn_Grabar.Name = "Btn_Grabar";
            this.Btn_Grabar.Size = new System.Drawing.Size(75, 56);
            this.Btn_Grabar.TabIndex = 24;
            this.Btn_Grabar.Text = "&Grabar";
            this.Btn_Grabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Grabar.UseVisualStyleBackColor = true;
            this.Btn_Grabar.Click += new System.EventHandler(this.Btn_Grabar_Click);
            // 
            // Tx_Id
            // 
            this.Tx_Id.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Tx_Id.Location = new System.Drawing.Point(482, 52);
            this.Tx_Id.Name = "Tx_Id";
            this.Tx_Id.ReadOnly = true;
            this.Tx_Id.Size = new System.Drawing.Size(32, 20);
            this.Tx_Id.TabIndex = 21;
            this.Tx_Id.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(462, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Id";
            // 
            // Tx_Nombre
            // 
            this.Tx_Nombre.Location = new System.Drawing.Point(107, 20);
            this.Tx_Nombre.Name = "Tx_Nombre";
            this.Tx_Nombre.Size = new System.Drawing.Size(369, 20);
            this.Tx_Nombre.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Nombre Tótem";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Tipo Tótem";
            // 
            // Cmb_TipoTotem
            // 
            this.Cmb_TipoTotem.FormattingEnabled = true;
            this.Cmb_TipoTotem.Location = new System.Drawing.Point(107, 51);
            this.Cmb_TipoTotem.Name = "Cmb_TipoTotem";
            this.Cmb_TipoTotem.Size = new System.Drawing.Size(317, 21);
            this.Cmb_TipoTotem.TabIndex = 29;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(12, 130);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(502, 213);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalle del H.W del Tótem";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "Obervación";
            // 
            // Tx_Obs
            // 
            this.Tx_Obs.Location = new System.Drawing.Point(107, 83);
            this.Tx_Obs.MaxLength = 50;
            this.Tx_Obs.Name = "Tx_Obs";
            this.Tx_Obs.Size = new System.Drawing.Size(369, 20);
            this.Tx_Obs.TabIndex = 32;
            // 
            // Frm_MtoTotem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 355);
            this.ControlBox = false;
            this.Controls.Add(this.Tx_Obs);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Cmb_TipoTotem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Btn_VerMaq);
            this.Controls.Add(this.Btn_Salir);
            this.Controls.Add(this.Btn_Limpiar);
            this.Controls.Add(this.Btn_Grabar);
            this.Controls.Add(this.Tx_Id);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Tx_Nombre);
            this.Controls.Add(this.label1);
            this.Name = "Frm_MtoTotem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formulario de mantenimiento de Tótem";
            this.Load += new System.EventHandler(this.Frm_MtoTotem_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button Btn_VerMaq;
        private System.Windows.Forms.Button Btn_Salir;
        private System.Windows.Forms.Button Btn_Limpiar;
        private System.Windows.Forms.Button Btn_Grabar;
        private System.Windows.Forms.TextBox Tx_Id;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Tx_Nombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox Cmb_TipoTotem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Tx_Obs;
    }
}