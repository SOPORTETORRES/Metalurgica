namespace Metalurgica.MultiMaquina
{
    partial class FrmVisualizar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVisualizar));
            this.Gr_1 = new System.Windows.Forms.GroupBox();
            this.Lbl_Msg = new System.Windows.Forms.Label();
            this.Dtg_Asignaciones = new System.Windows.Forms.DataGridView();
            this.Btn_QuitarAsignacion = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.Btn_Salir = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Lbl_Usuario = new System.Windows.Forms.Label();
            this.Btn_SeleccionarUser = new System.Windows.Forms.Button();
            this.Gr_1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_Asignaciones)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Gr_1
            // 
            this.Gr_1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Gr_1.Controls.Add(this.Lbl_Msg);
            this.Gr_1.Controls.Add(this.Dtg_Asignaciones);
            this.Gr_1.Location = new System.Drawing.Point(12, 5);
            this.Gr_1.Name = "Gr_1";
            this.Gr_1.Size = new System.Drawing.Size(503, 548);
            this.Gr_1.TabIndex = 0;
            this.Gr_1.TabStop = false;
            // 
            // Lbl_Msg
            // 
            this.Lbl_Msg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.Lbl_Msg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Lbl_Msg.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Msg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Lbl_Msg.Location = new System.Drawing.Point(7, 20);
            this.Lbl_Msg.Name = "Lbl_Msg";
            this.Lbl_Msg.Size = new System.Drawing.Size(490, 37);
            this.Lbl_Msg.TabIndex = 1;
            this.Lbl_Msg.Text = "Para eliminar un usuario de la máquina, debe hacer click sobre el nombre del usua" +
    "rio y luego presionar el botón Quitar a Usuario";
            this.Lbl_Msg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Dtg_Asignaciones
            // 
            this.Dtg_Asignaciones.AllowUserToAddRows = false;
            this.Dtg_Asignaciones.AllowUserToDeleteRows = false;
            this.Dtg_Asignaciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Dtg_Asignaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dtg_Asignaciones.Location = new System.Drawing.Point(7, 60);
            this.Dtg_Asignaciones.Name = "Dtg_Asignaciones";
            this.Dtg_Asignaciones.ReadOnly = true;
            this.Dtg_Asignaciones.Size = new System.Drawing.Size(489, 482);
            this.Dtg_Asignaciones.TabIndex = 0;
            this.Dtg_Asignaciones.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dtg_Asignaciones_CellClick);
            this.Dtg_Asignaciones.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dtg_Asignaciones_CellContentClick);
            // 
            // Btn_QuitarAsignacion
            // 
            this.Btn_QuitarAsignacion.Enabled = false;
            this.Btn_QuitarAsignacion.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_QuitarAsignacion.ImageIndex = 0;
            this.Btn_QuitarAsignacion.ImageList = this.imageList1;
            this.Btn_QuitarAsignacion.Location = new System.Drawing.Point(535, 214);
            this.Btn_QuitarAsignacion.Name = "Btn_QuitarAsignacion";
            this.Btn_QuitarAsignacion.Size = new System.Drawing.Size(93, 66);
            this.Btn_QuitarAsignacion.TabIndex = 1;
            this.Btn_QuitarAsignacion.Text = "Quitar a Usuario";
            this.Btn_QuitarAsignacion.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_QuitarAsignacion.UseVisualStyleBackColor = true;
            this.Btn_QuitarAsignacion.Click += new System.EventHandler(this.Btn_QuitarAsignacion_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Untitled (1104).ico");
            this.imageList1.Images.SetKeyName(1, "Untitled (61).ico");
            this.imageList1.Images.SetKeyName(2, "Untitled (68).ico");
            this.imageList1.Images.SetKeyName(3, "Untitled (145).ico");
            // 
            // Btn_Salir
            // 
            this.Btn_Salir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Salir.ImageIndex = 1;
            this.Btn_Salir.ImageList = this.imageList1;
            this.Btn_Salir.Location = new System.Drawing.Point(535, 395);
            this.Btn_Salir.Name = "Btn_Salir";
            this.Btn_Salir.Size = new System.Drawing.Size(93, 66);
            this.Btn_Salir.TabIndex = 2;
            this.Btn_Salir.Text = "Salir";
            this.Btn_Salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Salir.UseVisualStyleBackColor = true;
            this.Btn_Salir.Click += new System.EventHandler(this.Btn_Salir_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Lbl_Usuario);
            this.groupBox1.Location = new System.Drawing.Point(522, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(128, 143);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Usuario Seleccionado";
            // 
            // Lbl_Usuario
            // 
            this.Lbl_Usuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Usuario.ForeColor = System.Drawing.Color.Red;
            this.Lbl_Usuario.Location = new System.Drawing.Point(10, 20);
            this.Lbl_Usuario.Name = "Lbl_Usuario";
            this.Lbl_Usuario.Size = new System.Drawing.Size(109, 113);
            this.Lbl_Usuario.TabIndex = 0;
            this.Lbl_Usuario.Text = "label1";
            this.Lbl_Usuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Btn_SeleccionarUser
            // 
            this.Btn_SeleccionarUser.Enabled = false;
            this.Btn_SeleccionarUser.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_SeleccionarUser.ImageIndex = 3;
            this.Btn_SeleccionarUser.ImageList = this.imageList1;
            this.Btn_SeleccionarUser.Location = new System.Drawing.Point(535, 298);
            this.Btn_SeleccionarUser.Name = "Btn_SeleccionarUser";
            this.Btn_SeleccionarUser.Size = new System.Drawing.Size(93, 66);
            this.Btn_SeleccionarUser.TabIndex = 4;
            this.Btn_SeleccionarUser.Text = "Seleccionar  Usuario";
            this.Btn_SeleccionarUser.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_SeleccionarUser.UseVisualStyleBackColor = true;
            this.Btn_SeleccionarUser.Click += new System.EventHandler(this.Btn_SeleccionarUser_Click);
            // 
            // FrmVisualizar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 568);
            this.ControlBox = false;
            this.Controls.Add(this.Btn_SeleccionarUser);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Btn_Salir);
            this.Controls.Add(this.Btn_QuitarAsignacion);
            this.Controls.Add(this.Gr_1);
            this.Name = "FrmVisualizar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmVisualizar";
            this.Load += new System.EventHandler(this.FrmVisualizar_Load);
            this.Gr_1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_Asignaciones)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Gr_1;
        private System.Windows.Forms.DataGridView Dtg_Asignaciones;
        private System.Windows.Forms.Label Lbl_Msg;
        private System.Windows.Forms.Button Btn_QuitarAsignacion;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button Btn_Salir;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label Lbl_Usuario;
        private System.Windows.Forms.Button Btn_SeleccionarUser;
    }
}