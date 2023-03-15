namespace Metalurgica
{
    partial class frmLogin
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkRecordarUsuario = new System.Windows.Forms.CheckBox();
            this.chkRecordarClave = new System.Windows.Forms.CheckBox();
            this.BtnPrueba = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.Enabled = false;
            this.btnAceptar.Location = new System.Drawing.Point(59, 176);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(102, 27);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Iniciar sesión >>";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(167, 176);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 27);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(12, 41);
            this.txtUsuario.MaxLength = 50;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(230, 20);
            this.txtUsuario.TabIndex = 0;
            this.txtUsuario.TextChanged += new System.EventHandler(this.txtUsuario_TextChanged);
            this.txtUsuario.Leave += new System.EventHandler(this.txtUsuario_Leave);
            // 
            // txtClave
            // 
            this.txtClave.Location = new System.Drawing.Point(12, 80);
            this.txtClave.MaxLength = 50;
            this.txtClave.Name = "txtClave";
            this.txtClave.PasswordChar = 'X';
            this.txtClave.Size = new System.Drawing.Size(230, 20);
            this.txtClave.TabIndex = 1;
            this.txtClave.TextChanged += new System.EventHandler(this.txtClave_TextChanged);
            this.txtClave.Leave += new System.EventHandler(this.txtClave_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nombre de usuario:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Contraseña:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // chkRecordarUsuario
            // 
            this.chkRecordarUsuario.AutoSize = true;
            this.chkRecordarUsuario.Checked = true;
            this.chkRecordarUsuario.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRecordarUsuario.Location = new System.Drawing.Point(12, 119);
            this.chkRecordarUsuario.Name = "chkRecordarUsuario";
            this.chkRecordarUsuario.Size = new System.Drawing.Size(173, 17);
            this.chkRecordarUsuario.TabIndex = 6;
            this.chkRecordarUsuario.Text = "Recordar mi nombre de usuario";
            this.chkRecordarUsuario.UseVisualStyleBackColor = true;
            this.chkRecordarUsuario.Visible = false;
            // 
            // chkRecordarClave
            // 
            this.chkRecordarClave.AutoSize = true;
            this.chkRecordarClave.Enabled = false;
            this.chkRecordarClave.Location = new System.Drawing.Point(12, 142);
            this.chkRecordarClave.Name = "chkRecordarClave";
            this.chkRecordarClave.Size = new System.Drawing.Size(139, 17);
            this.chkRecordarClave.TabIndex = 7;
            this.chkRecordarClave.Text = "Recordar mi contraseña";
            this.chkRecordarClave.UseVisualStyleBackColor = true;
            this.chkRecordarClave.Visible = false;
            // 
            // BtnPrueba
            // 
            this.BtnPrueba.Image = global::Metalurgica.Properties.Resources.information;
            this.BtnPrueba.Location = new System.Drawing.Point(223, 136);
            this.BtnPrueba.Name = "BtnPrueba";
            this.BtnPrueba.Size = new System.Drawing.Size(23, 23);
            this.BtnPrueba.TabIndex = 16;
            this.BtnPrueba.UseVisualStyleBackColor = true;
            this.BtnPrueba.Visible = false;
            this.BtnPrueba.Click += new System.EventHandler(this.BtnPrueba_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(167, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 212);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BtnPrueba);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.txtClave);
            this.Controls.Add(this.chkRecordarClave);
            this.Controls.Add(this.chkRecordarUsuario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Shown += new System.EventHandler(this.frmLogin_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkRecordarUsuario;
        private System.Windows.Forms.CheckBox chkRecordarClave;
        private System.Windows.Forms.Button BtnPrueba;
        private System.Windows.Forms.Button button1;
    }
}

