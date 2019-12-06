namespace Metalurgica.Maquinas
{
    partial class Frm_ElementosProduccion
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
            this.Btn_Aceptar = new System.Windows.Forms.Button();
            this.Btn_Salir = new System.Windows.Forms.Button();
            this.Dgt_elementos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.Lbl_Seleccionado = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Btn_Solucion = new System.Windows.Forms.Button();
            this.Pnl_Login = new System.Windows.Forms.Panel();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.Pnl_SeleccionAveria = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.lbl_Averia = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Lbl_IdNotificacion = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Btn_Reparacion = new System.Windows.Forms.Button();
            this.Btn_SalirSelNot = new System.Windows.Forms.Button();
            this.Lbl_Titulo = new System.Windows.Forms.Label();
            this.Lbl_Perfil = new System.Windows.Forms.Label();
            this.Lbl_Usuario = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Dtg_Averias = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.Dgt_elementos)).BeginInit();
            this.Pnl_Login.SuspendLayout();
            this.Pnl_SeleccionAveria.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_Averias)).BeginInit();
            this.SuspendLayout();
            // 
            // Btn_Aceptar
            // 
            this.Btn_Aceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Aceptar.Location = new System.Drawing.Point(592, 255);
            this.Btn_Aceptar.Name = "Btn_Aceptar";
            this.Btn_Aceptar.Size = new System.Drawing.Size(75, 57);
            this.Btn_Aceptar.TabIndex = 0;
            this.Btn_Aceptar.Text = "Aceptar";
            this.Btn_Aceptar.UseVisualStyleBackColor = true;
            this.Btn_Aceptar.Visible = false;
            this.Btn_Aceptar.Click += new System.EventHandler(this.Btn_Aceptar_Click);
            // 
            // Btn_Salir
            // 
            this.Btn_Salir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Salir.Location = new System.Drawing.Point(592, 352);
            this.Btn_Salir.Name = "Btn_Salir";
            this.Btn_Salir.Size = new System.Drawing.Size(75, 57);
            this.Btn_Salir.TabIndex = 1;
            this.Btn_Salir.Text = "Salir";
            this.Btn_Salir.UseVisualStyleBackColor = true;
            this.Btn_Salir.Click += new System.EventHandler(this.Btn_Salir_Click);
            // 
            // Dgt_elementos
            // 
            this.Dgt_elementos.AllowUserToAddRows = false;
            this.Dgt_elementos.AllowUserToDeleteRows = false;
            this.Dgt_elementos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Dgt_elementos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgt_elementos.Location = new System.Drawing.Point(9, 12);
            this.Dgt_elementos.Name = "Dgt_elementos";
            this.Dgt_elementos.ReadOnly = true;
            this.Dgt_elementos.Size = new System.Drawing.Size(531, 427);
            this.Dgt_elementos.TabIndex = 2;
            this.Dgt_elementos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgt_elementos_CellDoubleClick);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(559, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Elemento  Seleccionado";
            // 
            // Lbl_Seleccionado
            // 
            this.Lbl_Seleccionado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Lbl_Seleccionado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Lbl_Seleccionado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Seleccionado.ForeColor = System.Drawing.Color.Red;
            this.Lbl_Seleccionado.Location = new System.Drawing.Point(562, 17);
            this.Lbl_Seleccionado.Name = "Lbl_Seleccionado";
            this.Lbl_Seleccionado.Size = new System.Drawing.Size(139, 99);
            this.Lbl_Seleccionado.TabIndex = 4;
            this.Lbl_Seleccionado.Text = "label2";
            this.Lbl_Seleccionado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(562, 121);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 33);
            this.button1.TabIndex = 5;
            this.button1.Text = "Nueva Notificación";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Btn_Solucion
            // 
            this.Btn_Solucion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Solucion.Location = new System.Drawing.Point(561, 165);
            this.Btn_Solucion.Name = "Btn_Solucion";
            this.Btn_Solucion.Size = new System.Drawing.Size(139, 33);
            this.Btn_Solucion.TabIndex = 6;
            this.Btn_Solucion.Text = "Solucionar  Notificación";
            this.Btn_Solucion.UseVisualStyleBackColor = true;
            this.Btn_Solucion.Click += new System.EventHandler(this.Btn_Solucion_Click);
            // 
            // Pnl_Login
            // 
            this.Pnl_Login.Controls.Add(this.txtUsuario);
            this.Pnl_Login.Controls.Add(this.txtClave);
            this.Pnl_Login.Controls.Add(this.label2);
            this.Pnl_Login.Controls.Add(this.label3);
            this.Pnl_Login.Controls.Add(this.btnCancelar);
            this.Pnl_Login.Controls.Add(this.btnAceptar);
            this.Pnl_Login.Location = new System.Drawing.Point(169, 170);
            this.Pnl_Login.Name = "Pnl_Login";
            this.Pnl_Login.Size = new System.Drawing.Size(266, 173);
            this.Pnl_Login.TabIndex = 7;
            this.Pnl_Login.Visible = false;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(16, 40);
            this.txtUsuario.MaxLength = 50;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(230, 20);
            this.txtUsuario.TabIndex = 6;
            // 
            // txtClave
            // 
            this.txtClave.Location = new System.Drawing.Point(16, 79);
            this.txtClave.MaxLength = 50;
            this.txtClave.Name = "txtClave";
            this.txtClave.PasswordChar = 'X';
            this.txtClave.Size = new System.Drawing.Size(230, 20);
            this.txtClave.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Contraseña:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Nombre de usuario:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(141, 114);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 27);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(33, 114);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(102, 27);
            this.btnAceptar.TabIndex = 8;
            this.btnAceptar.Text = "Iniciar sesión >>";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // Pnl_SeleccionAveria
            // 
            this.Pnl_SeleccionAveria.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Pnl_SeleccionAveria.Controls.Add(this.label8);
            this.Pnl_SeleccionAveria.Controls.Add(this.lbl_Averia);
            this.Pnl_SeleccionAveria.Controls.Add(this.label7);
            this.Pnl_SeleccionAveria.Controls.Add(this.Lbl_IdNotificacion);
            this.Pnl_SeleccionAveria.Controls.Add(this.label6);
            this.Pnl_SeleccionAveria.Controls.Add(this.Btn_Reparacion);
            this.Pnl_SeleccionAveria.Controls.Add(this.Btn_SalirSelNot);
            this.Pnl_SeleccionAveria.Controls.Add(this.Lbl_Titulo);
            this.Pnl_SeleccionAveria.Controls.Add(this.Lbl_Perfil);
            this.Pnl_SeleccionAveria.Controls.Add(this.Lbl_Usuario);
            this.Pnl_SeleccionAveria.Controls.Add(this.label5);
            this.Pnl_SeleccionAveria.Controls.Add(this.label4);
            this.Pnl_SeleccionAveria.Controls.Add(this.Dtg_Averias);
            this.Pnl_SeleccionAveria.Location = new System.Drawing.Point(9, 12);
            this.Pnl_SeleccionAveria.Name = "Pnl_SeleccionAveria";
            this.Pnl_SeleccionAveria.Size = new System.Drawing.Size(675, 162);
            this.Pnl_SeleccionAveria.TabIndex = 8;
            this.Pnl_SeleccionAveria.Visible = false;
            // 
            // label8
            // 
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label8.Location = new System.Drawing.Point(15, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(652, 18);
            this.label8.TabIndex = 20;
            this.label8.Text = "Detalle de Notificación  Selecionada";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Averia
            // 
            this.lbl_Averia.AutoSize = true;
            this.lbl_Averia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Averia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_Averia.Location = new System.Drawing.Point(112, 105);
            this.lbl_Averia.Name = "lbl_Averia";
            this.lbl_Averia.Size = new System.Drawing.Size(37, 15);
            this.lbl_Averia.TabIndex = 19;
            this.lbl_Averia.Text = "label6";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(74, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Averia:";
            // 
            // Lbl_IdNotificacion
            // 
            this.Lbl_IdNotificacion.AutoSize = true;
            this.Lbl_IdNotificacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Lbl_IdNotificacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Lbl_IdNotificacion.Location = new System.Drawing.Point(33, 105);
            this.Lbl_IdNotificacion.Name = "Lbl_IdNotificacion";
            this.Lbl_IdNotificacion.Size = new System.Drawing.Size(37, 15);
            this.Lbl_IdNotificacion.TabIndex = 17;
            this.Lbl_IdNotificacion.Text = "label6";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Id:";
            // 
            // Btn_Reparacion
            // 
            this.Btn_Reparacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Reparacion.Location = new System.Drawing.Point(494, 38);
            this.Btn_Reparacion.Name = "Btn_Reparacion";
            this.Btn_Reparacion.Size = new System.Drawing.Size(75, 39);
            this.Btn_Reparacion.TabIndex = 15;
            this.Btn_Reparacion.Text = "Reparar";
            this.Btn_Reparacion.UseVisualStyleBackColor = true;
            this.Btn_Reparacion.Click += new System.EventHandler(this.Btn_Reparacion_Click);
            // 
            // Btn_SalirSelNot
            // 
            this.Btn_SalirSelNot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_SalirSelNot.Location = new System.Drawing.Point(575, 37);
            this.Btn_SalirSelNot.Name = "Btn_SalirSelNot";
            this.Btn_SalirSelNot.Size = new System.Drawing.Size(75, 40);
            this.Btn_SalirSelNot.TabIndex = 14;
            this.Btn_SalirSelNot.Text = "Salir";
            this.Btn_SalirSelNot.UseVisualStyleBackColor = true;
            this.Btn_SalirSelNot.Click += new System.EventHandler(this.Btn_SalirSelNot_Click);
            // 
            // Lbl_Titulo
            // 
            this.Lbl_Titulo.AutoSize = true;
            this.Lbl_Titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Titulo.ForeColor = System.Drawing.Color.Red;
            this.Lbl_Titulo.Location = new System.Drawing.Point(7, 10);
            this.Lbl_Titulo.Name = "Lbl_Titulo";
            this.Lbl_Titulo.Size = new System.Drawing.Size(537, 17);
            this.Lbl_Titulo.TabIndex = 13;
            this.Lbl_Titulo.Text = "Seleccione una Notificación a Reparar, para el elemento de Producción |";
            // 
            // Lbl_Perfil
            // 
            this.Lbl_Perfil.AutoSize = true;
            this.Lbl_Perfil.Location = new System.Drawing.Point(113, 63);
            this.Lbl_Perfil.Name = "Lbl_Perfil";
            this.Lbl_Perfil.Size = new System.Drawing.Size(35, 13);
            this.Lbl_Perfil.TabIndex = 12;
            this.Lbl_Perfil.Text = "label6";
            // 
            // Lbl_Usuario
            // 
            this.Lbl_Usuario.AutoSize = true;
            this.Lbl_Usuario.Location = new System.Drawing.Point(114, 43);
            this.Lbl_Usuario.Name = "Lbl_Usuario";
            this.Lbl_Usuario.Size = new System.Drawing.Size(35, 13);
            this.Lbl_Usuario.TabIndex = 11;
            this.Lbl_Usuario.Text = "label6";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(70, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Perfil:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Usuario Vigente:";
            // 
            // Dtg_Averias
            // 
            this.Dtg_Averias.AllowUserToAddRows = false;
            this.Dtg_Averias.AllowUserToDeleteRows = false;
            this.Dtg_Averias.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Dtg_Averias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dtg_Averias.Location = new System.Drawing.Point(10, 123);
            this.Dtg_Averias.Name = "Dtg_Averias";
            this.Dtg_Averias.ReadOnly = true;
            this.Dtg_Averias.Size = new System.Drawing.Size(640, 32);
            this.Dtg_Averias.TabIndex = 8;
            this.Dtg_Averias.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dtg_Averias_CellContentDoubleClick);
            // 
            // Frm_ElementosProduccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 445);
            this.ControlBox = false;
            this.Controls.Add(this.Pnl_Login);
            this.Controls.Add(this.Pnl_SeleccionAveria);
            this.Controls.Add(this.Btn_Solucion);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Lbl_Seleccionado);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Btn_Salir);
            this.Controls.Add(this.Btn_Aceptar);
            this.Controls.Add(this.Dgt_elementos);
            this.Name = "Frm_ElementosProduccion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccione un elemento de Producción que esta con problemas";
            this.Load += new System.EventHandler(this.Frm_ElementosProduccion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Dgt_elementos)).EndInit();
            this.Pnl_Login.ResumeLayout(false);
            this.Pnl_Login.PerformLayout();
            this.Pnl_SeleccionAveria.ResumeLayout(false);
            this.Pnl_SeleccionAveria.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_Averias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_Aceptar;
        private System.Windows.Forms.Button Btn_Salir;
        private System.Windows.Forms.DataGridView Dgt_elementos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Lbl_Seleccionado;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Btn_Solucion;
        private System.Windows.Forms.Panel Pnl_Login;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Panel Pnl_SeleccionAveria;
        private System.Windows.Forms.Label Lbl_Perfil;
        private System.Windows.Forms.Label Lbl_Usuario;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView Dtg_Averias;
        private System.Windows.Forms.Label Lbl_Titulo;
        private System.Windows.Forms.Button Btn_SalirSelNot;
        private System.Windows.Forms.Button Btn_Reparacion;
        private System.Windows.Forms.Label lbl_Averia;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label Lbl_IdNotificacion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
    }
}