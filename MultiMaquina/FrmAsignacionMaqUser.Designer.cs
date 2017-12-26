namespace Metalurgica.MultiMaquina
{
    partial class FrmAsignacionMaqUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAsignacionMaqUser));
            this.label1 = new System.Windows.Forms.Label();
            this.Cmb_Sucursal = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Dtg_Maquinas = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Dtg_Usuarios = new System.Windows.Forms.DataGridView();
            this.Tx_BuscaUser = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Lbl_MaquinaSel = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.Lbl_UsuarioSel = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.Btn_Asignar = new System.Windows.Forms.Button();
            this.Btn_Salir = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_Maquinas)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_Usuarios)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Selecciones Sucursal Multi Maquina";
            // 
            // Cmb_Sucursal
            // 
            this.Cmb_Sucursal.FormattingEnabled = true;
            this.Cmb_Sucursal.Location = new System.Drawing.Point(210, 22);
            this.Cmb_Sucursal.Name = "Cmb_Sucursal";
            this.Cmb_Sucursal.Size = new System.Drawing.Size(187, 21);
            this.Cmb_Sucursal.TabIndex = 1;
            this.Cmb_Sucursal.SelectedIndexChanged += new System.EventHandler(this.Cmb_Sucursal_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.Dtg_Maquinas);
            this.groupBox1.Location = new System.Drawing.Point(9, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(488, 486);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Máquinas Disponibles  en Sucursal Seleccionada";
            // 
            // Dtg_Maquinas
            // 
            this.Dtg_Maquinas.AllowUserToAddRows = false;
            this.Dtg_Maquinas.AllowUserToDeleteRows = false;
            this.Dtg_Maquinas.AllowUserToOrderColumns = true;
            this.Dtg_Maquinas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dtg_Maquinas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Dtg_Maquinas.Location = new System.Drawing.Point(3, 16);
            this.Dtg_Maquinas.Name = "Dtg_Maquinas";
            this.Dtg_Maquinas.ReadOnly = true;
            this.Dtg_Maquinas.Size = new System.Drawing.Size(482, 467);
            this.Dtg_Maquinas.TabIndex = 0;
            this.Dtg_Maquinas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dtg_Maquinas_CellClick);
            this.Dtg_Maquinas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dtg_Maquinas_CellDoubleClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.Dtg_Usuarios);
            this.groupBox2.Controls.Add(this.Tx_BuscaUser);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(634, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(494, 539);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Usuarios para asignar a una maquina";
            // 
            // Dtg_Usuarios
            // 
            this.Dtg_Usuarios.AllowUserToAddRows = false;
            this.Dtg_Usuarios.AllowUserToDeleteRows = false;
            this.Dtg_Usuarios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Dtg_Usuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dtg_Usuarios.Location = new System.Drawing.Point(7, 67);
            this.Dtg_Usuarios.Name = "Dtg_Usuarios";
            this.Dtg_Usuarios.ReadOnly = true;
            this.Dtg_Usuarios.Size = new System.Drawing.Size(481, 461);
            this.Dtg_Usuarios.TabIndex = 3;
            this.Dtg_Usuarios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dtg_Usuarios_CellClick);
            // 
            // Tx_BuscaUser
            // 
            this.Tx_BuscaUser.Location = new System.Drawing.Point(126, 26);
            this.Tx_BuscaUser.Name = "Tx_BuscaUser";
            this.Tx_BuscaUser.Size = new System.Drawing.Size(228, 20);
            this.Tx_BuscaUser.TabIndex = 2;
            this.Tx_BuscaUser.TextChanged += new System.EventHandler(this.Tx_BuscaUser_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Búscar Usuarios";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Lbl_MaquinaSel);
            this.groupBox3.Location = new System.Drawing.Point(503, 80);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(119, 130);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Maquina Seleccionada";
            // 
            // Lbl_MaquinaSel
            // 
            this.Lbl_MaquinaSel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_MaquinaSel.ForeColor = System.Drawing.Color.Red;
            this.Lbl_MaquinaSel.Location = new System.Drawing.Point(8, 37);
            this.Lbl_MaquinaSel.Name = "Lbl_MaquinaSel";
            this.Lbl_MaquinaSel.Size = new System.Drawing.Size(100, 81);
            this.Lbl_MaquinaSel.TabIndex = 0;
            this.Lbl_MaquinaSel.Text = "Debe Seleccionar una Máquina";
            this.Lbl_MaquinaSel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.Lbl_UsuarioSel);
            this.groupBox4.Location = new System.Drawing.Point(503, 216);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(119, 130);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Usuario Seleccionado";
            // 
            // Lbl_UsuarioSel
            // 
            this.Lbl_UsuarioSel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_UsuarioSel.ForeColor = System.Drawing.Color.Red;
            this.Lbl_UsuarioSel.Location = new System.Drawing.Point(9, 42);
            this.Lbl_UsuarioSel.Name = "Lbl_UsuarioSel";
            this.Lbl_UsuarioSel.Size = new System.Drawing.Size(100, 74);
            this.Lbl_UsuarioSel.TabIndex = 1;
            this.Lbl_UsuarioSel.Text = "Debe Seleccionar un Usuario";
            this.Lbl_UsuarioSel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "images.jpg");
            this.imageList1.Images.SetKeyName(1, "Untitled (61).ico");
            // 
            // Btn_Asignar
            // 
            this.Btn_Asignar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Asignar.ImageIndex = 0;
            this.Btn_Asignar.ImageList = this.imageList1;
            this.Btn_Asignar.Location = new System.Drawing.Point(506, 353);
            this.Btn_Asignar.Name = "Btn_Asignar";
            this.Btn_Asignar.Size = new System.Drawing.Size(114, 72);
            this.Btn_Asignar.TabIndex = 6;
            this.Btn_Asignar.Text = "Asignar Usuario a Maquina";
            this.Btn_Asignar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Asignar.UseVisualStyleBackColor = true;
            this.Btn_Asignar.Click += new System.EventHandler(this.Btn_Asignar_Click);
            // 
            // Btn_Salir
            // 
            this.Btn_Salir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Salir.ImageIndex = 1;
            this.Btn_Salir.ImageList = this.imageList1;
            this.Btn_Salir.Location = new System.Drawing.Point(506, 446);
            this.Btn_Salir.Name = "Btn_Salir";
            this.Btn_Salir.Size = new System.Drawing.Size(114, 72);
            this.Btn_Salir.TabIndex = 7;
            this.Btn_Salir.Text = "Salir";
            this.Btn_Salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Salir.UseVisualStyleBackColor = true;
            this.Btn_Salir.Click += new System.EventHandler(this.Btn_Salir_Click);
            // 
            // FrmAsignacionMaqUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 559);
            this.ControlBox = false;
            this.Controls.Add(this.Btn_Salir);
            this.Controls.Add(this.Btn_Asignar);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Cmb_Sucursal);
            this.Controls.Add(this.label1);
            this.Name = "FrmAsignacionMaqUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formulario de asignación de Usuarios y Maquinas";
            this.Load += new System.EventHandler(this.FrmAsignacionMaqUser_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_Maquinas)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_Usuarios)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Cmb_Sucursal;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView Dtg_Maquinas;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView Dtg_Usuarios;
        private System.Windows.Forms.TextBox Tx_BuscaUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label Lbl_MaquinaSel;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label Lbl_UsuarioSel;
        private System.Windows.Forms.Button Btn_Asignar;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button Btn_Salir;
    }
}