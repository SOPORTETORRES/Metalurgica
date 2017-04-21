namespace Metalurgica
{
    partial class frmCierreMaterialAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCierreMaterialAdmin));
            this.numUpdCantidad = new System.Windows.Forms.NumericUpDown();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.lblOrigen = new System.Windows.Forms.Label();
            this.lblLargo = new System.Windows.Forms.Label();
            this.lblDiametro = new System.Windows.Forms.Label();
            this.lblProducto = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numUpdCantidad)).BeginInit();
            this.SuspendLayout();
            // 
            // numUpdCantidad
            // 
            this.numUpdCantidad.Location = new System.Drawing.Point(322, 92);
            this.numUpdCantidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpdCantidad.Name = "numUpdCantidad";
            this.numUpdCantidad.Size = new System.Drawing.Size(75, 20);
            this.numUpdCantidad.TabIndex = 33;
            this.numUpdCantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(403, 130);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 32;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(322, 130);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 31;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(230, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Cantidad (cierre):";
            // 
            // cboTipo
            // 
            this.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Items.AddRange(new object[] {
            "SOLDABLE",
            "NORMAL"});
            this.cboTipo.Location = new System.Drawing.Point(79, 91);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(118, 21);
            this.cboTipo.TabIndex = 35;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 94);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 13);
            this.label9.TabIndex = 34;
            this.label9.Text = "Tipo (cierre):";
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipo.Location = new System.Drawing.Point(77, 68);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(15, 13);
            this.lblTipo.TabIndex = 47;
            this.lblTipo.Text = "#";
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad.Location = new System.Drawing.Point(319, 68);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(15, 13);
            this.lblCantidad.TabIndex = 46;
            this.lblCantidad.Text = "#";
            // 
            // lblOrigen
            // 
            this.lblOrigen.AutoSize = true;
            this.lblOrigen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrigen.Location = new System.Drawing.Point(319, 39);
            this.lblOrigen.Name = "lblOrigen";
            this.lblOrigen.Size = new System.Drawing.Size(15, 13);
            this.lblOrigen.TabIndex = 45;
            this.lblOrigen.Text = "#";
            // 
            // lblLargo
            // 
            this.lblLargo.AutoSize = true;
            this.lblLargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLargo.Location = new System.Drawing.Point(189, 39);
            this.lblLargo.Name = "lblLargo";
            this.lblLargo.Size = new System.Drawing.Size(15, 13);
            this.lblLargo.TabIndex = 44;
            this.lblLargo.Text = "#";
            // 
            // lblDiametro
            // 
            this.lblDiametro.AutoSize = true;
            this.lblDiametro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiametro.Location = new System.Drawing.Point(76, 39);
            this.lblDiametro.Name = "lblDiametro";
            this.lblDiametro.Size = new System.Drawing.Size(15, 13);
            this.lblDiametro.TabIndex = 43;
            this.lblDiametro.Text = "#";
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProducto.Location = new System.Drawing.Point(76, 11);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(15, 13);
            this.lblProducto.TabIndex = 42;
            this.lblProducto.Text = "#";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 41;
            this.label3.Text = "Tipo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(272, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 40;
            this.label2.Text = "Origen:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 36;
            this.label4.Text = "Producto:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(261, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 39;
            this.label7.Text = "Cantidad:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(146, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 38;
            this.label6.Text = "Largo:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 37;
            this.label5.Text = "Diametro:";
            // 
            // frmCierreMaterialAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 165);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.lblOrigen);
            this.Controls.Add(this.lblLargo);
            this.Controls.Add(this.lblDiametro);
            this.Controls.Add(this.lblProducto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboTipo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.numUpdCantidad);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCierreMaterialAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cierre de Material (Administrador)";
            this.Load += new System.EventHandler(this.frmCierreMaterialAdmin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numUpdCantidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numUpdCantidad;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboTipo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Label lblOrigen;
        private System.Windows.Forms.Label lblLargo;
        private System.Windows.Forms.Label lblDiametro;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
    }
}