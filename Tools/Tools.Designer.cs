namespace Metalurgica
{
    partial class Tools
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Dtg_Datos = new System.Windows.Forms.DataGridView();
            this.Btn_CargarDatos = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tx_Id = new System.Windows.Forms.TextBox();
            this.Btn_eliminar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Pb_ = new System.Windows.Forms.ProgressBar();
            this.button2 = new System.Windows.Forms.Button();
            this.Tx_rut = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_Datos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.Dtg_Datos);
            this.groupBox1.Location = new System.Drawing.Point(3, 107);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(925, 329);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // Dtg_Datos
            // 
            this.Dtg_Datos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dtg_Datos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Dtg_Datos.Location = new System.Drawing.Point(3, 16);
            this.Dtg_Datos.Name = "Dtg_Datos";
            this.Dtg_Datos.Size = new System.Drawing.Size(919, 310);
            this.Dtg_Datos.TabIndex = 0;
            this.Dtg_Datos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dtg_Datos_CellClick);
            // 
            // Btn_CargarDatos
            // 
            this.Btn_CargarDatos.Location = new System.Drawing.Point(29, 13);
            this.Btn_CargarDatos.Name = "Btn_CargarDatos";
            this.Btn_CargarDatos.Size = new System.Drawing.Size(85, 43);
            this.Btn_CargarDatos.TabIndex = 1;
            this.Btn_CargarDatos.Text = "Cargar Datos";
            this.Btn_CargarDatos.UseVisualStyleBackColor = true;
            this.Btn_CargarDatos.Click += new System.EventHandler(this.Btn_CargarDatos_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(131, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // tx_Id
            // 
            this.tx_Id.Location = new System.Drawing.Point(172, 13);
            this.tx_Id.Name = "tx_Id";
            this.tx_Id.Size = new System.Drawing.Size(83, 20);
            this.tx_Id.TabIndex = 3;
            // 
            // Btn_eliminar
            // 
            this.Btn_eliminar.Location = new System.Drawing.Point(273, 12);
            this.Btn_eliminar.Name = "Btn_eliminar";
            this.Btn_eliminar.Size = new System.Drawing.Size(85, 43);
            this.Btn_eliminar.TabIndex = 4;
            this.Btn_eliminar.Text = "Elimina Registro";
            this.Btn_eliminar.UseVisualStyleBackColor = true;
            this.Btn_eliminar.Click += new System.EventHandler(this.Btn_eliminar_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(552, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 43);
            this.button1.TabIndex = 5;
            this.button1.Text = "Revisa Clientes";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Pb_
            // 
            this.Pb_.Location = new System.Drawing.Point(250, 74);
            this.Pb_.Name = "Pb_";
            this.Pb_.Size = new System.Drawing.Size(577, 23);
            this.Pb_.TabIndex = 6;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(664, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(115, 21);
            this.button2.TabIndex = 7;
            this.button2.Text = "Detalle Cliente";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Tx_rut
            // 
            this.Tx_rut.Location = new System.Drawing.Point(696, 36);
            this.Tx_rut.Name = "Tx_rut";
            this.Tx_rut.Size = new System.Drawing.Size(83, 20);
            this.Tx_rut.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(655, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "RUT";
            // 
            // Tools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 441);
            this.Controls.Add(this.Tx_rut);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Pb_);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Btn_eliminar);
            this.Controls.Add(this.tx_Id);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Btn_CargarDatos);
            this.Controls.Add(this.groupBox1);
            this.Name = "Tools";
            this.Text = "Tools";
            this.Load += new System.EventHandler(this.Tools_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_Datos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView Dtg_Datos;
        private System.Windows.Forms.Button Btn_CargarDatos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tx_Id;
        private System.Windows.Forms.Button Btn_eliminar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ProgressBar Pb_;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox Tx_rut;
        private System.Windows.Forms.Label label2;
    }
}