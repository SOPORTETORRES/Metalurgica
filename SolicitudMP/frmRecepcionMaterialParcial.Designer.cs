namespace Metalurgica
{
    partial class frmRecepcionMaterialParcial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRecepcionMaterialParcial));
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtObs = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.numUpdCantidad = new System.Windows.Forms.NumericUpDown();
            this.lblProducto = new System.Windows.Forms.Label();
            this.lblDiametro = new System.Windows.Forms.Label();
            this.lblLargo = new System.Windows.Forms.Label();
            this.lblOrigen = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.Lbl_Kilos = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.Tx_KilosEtiqueta = new System.Windows.Forms.TextBox();
            this.Lbl_Msg = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numUpdCantidad)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cantidad (parcial):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(474, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Tipo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(265, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Origen:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Producto:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Cantidad:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(145, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Largo:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Diametro:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 120);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Observación:";
            // 
            // txtObs
            // 
            this.txtObs.Location = new System.Drawing.Point(107, 117);
            this.txtObs.MaxLength = 255;
            this.txtObs.Multiline = true;
            this.txtObs.Name = "txtObs";
            this.txtObs.Size = new System.Drawing.Size(468, 76);
            this.txtObs.TabIndex = 18;
            this.txtObs.TextChanged += new System.EventHandler(this.txtObs_TextChanged);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(419, 199);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 19;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(500, 199);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 20;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // numUpdCantidad
            // 
            this.numUpdCantidad.Location = new System.Drawing.Point(107, 89);
            this.numUpdCantidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpdCantidad.Name = "numUpdCantidad";
            this.numUpdCantidad.Size = new System.Drawing.Size(75, 20);
            this.numUpdCantidad.TabIndex = 21;
            this.numUpdCantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProducto.Location = new System.Drawing.Point(75, 10);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(15, 13);
            this.lblProducto.TabIndex = 22;
            this.lblProducto.Text = "#";
            // 
            // lblDiametro
            // 
            this.lblDiametro.AutoSize = true;
            this.lblDiametro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiametro.Location = new System.Drawing.Point(75, 38);
            this.lblDiametro.Name = "lblDiametro";
            this.lblDiametro.Size = new System.Drawing.Size(15, 13);
            this.lblDiametro.TabIndex = 23;
            this.lblDiametro.Text = "#";
            // 
            // lblLargo
            // 
            this.lblLargo.AutoSize = true;
            this.lblLargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLargo.Location = new System.Drawing.Point(188, 38);
            this.lblLargo.Name = "lblLargo";
            this.lblLargo.Size = new System.Drawing.Size(15, 13);
            this.lblLargo.TabIndex = 24;
            this.lblLargo.Text = "#";
            // 
            // lblOrigen
            // 
            this.lblOrigen.AutoSize = true;
            this.lblOrigen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrigen.Location = new System.Drawing.Point(312, 38);
            this.lblOrigen.Name = "lblOrigen";
            this.lblOrigen.Size = new System.Drawing.Size(15, 13);
            this.lblOrigen.TabIndex = 25;
            this.lblOrigen.Text = "#";
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad.Location = new System.Drawing.Point(75, 63);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(15, 13);
            this.lblCantidad.TabIndex = 26;
            this.lblCantidad.Text = "#";
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipo.Location = new System.Drawing.Point(511, 38);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(15, 13);
            this.lblTipo.TabIndex = 27;
            this.lblTipo.Text = "#";
            // 
            // Lbl_Kilos
            // 
            this.Lbl_Kilos.AutoSize = true;
            this.Lbl_Kilos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Kilos.Location = new System.Drawing.Point(314, 91);
            this.Lbl_Kilos.Name = "Lbl_Kilos";
            this.Lbl_Kilos.Size = new System.Drawing.Size(15, 13);
            this.Lbl_Kilos.TabIndex = 29;
            this.Lbl_Kilos.Text = "#";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(267, 91);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 13);
            this.label10.TabIndex = 28;
            this.label10.Text = "Kilos:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(416, 96);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 13);
            this.label9.TabIndex = 30;
            this.label9.Text = "Kilos Etiqueta:";
            // 
            // Tx_KilosEtiqueta
            // 
            this.Tx_KilosEtiqueta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tx_KilosEtiqueta.ForeColor = System.Drawing.Color.Red;
            this.Tx_KilosEtiqueta.Location = new System.Drawing.Point(495, 93);
            this.Tx_KilosEtiqueta.Name = "Tx_KilosEtiqueta";
            this.Tx_KilosEtiqueta.Size = new System.Drawing.Size(75, 20);
            this.Tx_KilosEtiqueta.TabIndex = 31;
            this.Tx_KilosEtiqueta.Text = "XXXX";
            // 
            // Lbl_Msg
            // 
            this.Lbl_Msg.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Msg.ForeColor = System.Drawing.Color.Blue;
            this.Lbl_Msg.Location = new System.Drawing.Point(37, 133);
            this.Lbl_Msg.Name = "Lbl_Msg";
            this.Lbl_Msg.Size = new System.Drawing.Size(468, 76);
            this.Lbl_Msg.TabIndex = 32;
            this.Lbl_Msg.Text = "label11";
            this.Lbl_Msg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Lbl_Msg.Visible = false;
            this.Lbl_Msg.Click += new System.EventHandler(this.Lbl_Msg_Click);
            // 
            // frmRecepcionMaterialParcial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 229);
            this.Controls.Add(this.Tx_KilosEtiqueta);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.Lbl_Kilos);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.lblOrigen);
            this.Controls.Add(this.lblLargo);
            this.Controls.Add(this.lblDiametro);
            this.Controls.Add(this.lblProducto);
            this.Controls.Add(this.numUpdCantidad);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Lbl_Msg);
            this.Controls.Add(this.txtObs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRecepcionMaterialParcial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recepcion Parcial";
            this.Load += new System.EventHandler(this.frmRecepcionMaterialParcial_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numUpdCantidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtObs;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.NumericUpDown numUpdCantidad;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.Label lblDiametro;
        private System.Windows.Forms.Label lblLargo;
        private System.Windows.Forms.Label lblOrigen;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label Lbl_Kilos;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox Tx_KilosEtiqueta;
        private System.Windows.Forms.Label Lbl_Msg;
    }
}