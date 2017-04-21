namespace Metalurgica.Maquinas
{
    partial class Frm_Desbloqueo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Desbloqueo));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Tx_Maquina = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Tx_FechaNot = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Tx_UsuarioNot = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Tx_Motivo = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Cmb_Mecanico = new System.Windows.Forms.ComboBox();
            this.Chk_Operativa = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Tx_Obs = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Dtg_Obs = new System.Windows.Forms.DataGridView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.Btn_Salir = new System.Windows.Forms.Button();
            this.Btn_Limpiar = new System.Windows.Forms.Button();
            this.Btn_Grabar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_Obs)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Tx_Motivo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.Tx_UsuarioNot);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.Tx_FechaNot);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Tx_Maquina);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(11, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(726, 159);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos  del Bloqueo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Máquina";
            // 
            // Tx_Maquina
            // 
            this.Tx_Maquina.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Tx_Maquina.Location = new System.Drawing.Point(125, 21);
            this.Tx_Maquina.Name = "Tx_Maquina";
            this.Tx_Maquina.ReadOnly = true;
            this.Tx_Maquina.Size = new System.Drawing.Size(583, 20);
            this.Tx_Maquina.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fecha Notificación";
            // 
            // Tx_FechaNot
            // 
            this.Tx_FechaNot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Tx_FechaNot.Location = new System.Drawing.Point(127, 49);
            this.Tx_FechaNot.Name = "Tx_FechaNot";
            this.Tx_FechaNot.ReadOnly = true;
            this.Tx_FechaNot.Size = new System.Drawing.Size(145, 20);
            this.Tx_FechaNot.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(292, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Usuario";
            // 
            // Tx_UsuarioNot
            // 
            this.Tx_UsuarioNot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Tx_UsuarioNot.Location = new System.Drawing.Point(345, 49);
            this.Tx_UsuarioNot.Name = "Tx_UsuarioNot";
            this.Tx_UsuarioNot.ReadOnly = true;
            this.Tx_UsuarioNot.Size = new System.Drawing.Size(363, 20);
            this.Tx_UsuarioNot.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Motivo";
            // 
            // Tx_Motivo
            // 
            this.Tx_Motivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Tx_Motivo.Location = new System.Drawing.Point(125, 75);
            this.Tx_Motivo.Multiline = true;
            this.Tx_Motivo.Name = "Tx_Motivo";
            this.Tx_Motivo.ReadOnly = true;
            this.Tx_Motivo.Size = new System.Drawing.Size(583, 71);
            this.Tx_Motivo.TabIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Tx_Obs);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.Chk_Operativa);
            this.groupBox2.Controls.Add(this.Cmb_Mecanico);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(13, 174);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(726, 131);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos de la  Reparación";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Mecanico Asignado";
            // 
            // Cmb_Mecanico
            // 
            this.Cmb_Mecanico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cmb_Mecanico.FormattingEnabled = true;
            this.Cmb_Mecanico.Location = new System.Drawing.Point(121, 21);
            this.Cmb_Mecanico.Name = "Cmb_Mecanico";
            this.Cmb_Mecanico.Size = new System.Drawing.Size(385, 21);
            this.Cmb_Mecanico.TabIndex = 2;
            // 
            // Chk_Operativa
            // 
            this.Chk_Operativa.AutoSize = true;
            this.Chk_Operativa.Location = new System.Drawing.Point(573, 20);
            this.Chk_Operativa.Name = "Chk_Operativa";
            this.Chk_Operativa.Size = new System.Drawing.Size(107, 17);
            this.Chk_Operativa.TabIndex = 3;
            this.Chk_Operativa.Text = "Queda Operativa";
            this.Chk_Operativa.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Observaciones";
            // 
            // Tx_Obs
            // 
            this.Tx_Obs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Tx_Obs.Location = new System.Drawing.Point(121, 47);
            this.Tx_Obs.Multiline = true;
            this.Tx_Obs.Name = "Tx_Obs";
            this.Tx_Obs.Size = new System.Drawing.Size(594, 70);
            this.Tx_Obs.TabIndex = 8;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.Dtg_Obs);
            this.groupBox3.Location = new System.Drawing.Point(13, 312);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(807, 214);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Histórico de Obs";
            // 
            // Dtg_Obs
            // 
            this.Dtg_Obs.AllowUserToAddRows = false;
            this.Dtg_Obs.AllowUserToDeleteRows = false;
            this.Dtg_Obs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dtg_Obs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Dtg_Obs.Location = new System.Drawing.Point(3, 16);
            this.Dtg_Obs.Name = "Dtg_Obs";
            this.Dtg_Obs.ReadOnly = true;
            this.Dtg_Obs.Size = new System.Drawing.Size(801, 195);
            this.Dtg_Obs.TabIndex = 0;
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
            // Btn_Salir
            // 
            this.Btn_Salir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Salir.ImageIndex = 5;
            this.Btn_Salir.ImageList = this.imageList1;
            this.Btn_Salir.Location = new System.Drawing.Point(743, 32);
            this.Btn_Salir.Name = "Btn_Salir";
            this.Btn_Salir.Size = new System.Drawing.Size(75, 56);
            this.Btn_Salir.TabIndex = 29;
            this.Btn_Salir.Text = "&Salir";
            this.Btn_Salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Salir.UseVisualStyleBackColor = true;
            // 
            // Btn_Limpiar
            // 
            this.Btn_Limpiar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Limpiar.ImageIndex = 6;
            this.Btn_Limpiar.ImageList = this.imageList1;
            this.Btn_Limpiar.Location = new System.Drawing.Point(744, 120);
            this.Btn_Limpiar.Name = "Btn_Limpiar";
            this.Btn_Limpiar.Size = new System.Drawing.Size(75, 56);
            this.Btn_Limpiar.TabIndex = 28;
            this.Btn_Limpiar.Text = "&Limpiar";
            this.Btn_Limpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Limpiar.UseVisualStyleBackColor = true;
            // 
            // Btn_Grabar
            // 
            this.Btn_Grabar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Grabar.ImageIndex = 0;
            this.Btn_Grabar.ImageList = this.imageList1;
            this.Btn_Grabar.Location = new System.Drawing.Point(745, 221);
            this.Btn_Grabar.Name = "Btn_Grabar";
            this.Btn_Grabar.Size = new System.Drawing.Size(75, 56);
            this.Btn_Grabar.TabIndex = 27;
            this.Btn_Grabar.Text = "&Grabar";
            this.Btn_Grabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Grabar.UseVisualStyleBackColor = true;
            // 
            // Frm_Desbloqueo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 538);
            this.Controls.Add(this.Btn_Salir);
            this.Controls.Add(this.Btn_Limpiar);
            this.Controls.Add(this.Btn_Grabar);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_Desbloqueo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formulario de Desbloqueo de Máquinas";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_Obs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox Tx_Motivo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Tx_UsuarioNot;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Tx_FechaNot;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Tx_Maquina;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox Tx_Obs;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox Chk_Operativa;
        private System.Windows.Forms.ComboBox Cmb_Mecanico;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView Dtg_Obs;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button Btn_Salir;
        private System.Windows.Forms.Button Btn_Limpiar;
        private System.Windows.Forms.Button Btn_Grabar;
    }
}