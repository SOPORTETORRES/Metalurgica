namespace Metalurgica.Tools
{
    partial class Frm_Tools
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
            this.Tx_rut = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.Pb_ = new System.Windows.Forms.ProgressBar();
            this.button1 = new System.Windows.Forms.Button();
            this.Btn_eliminar = new System.Windows.Forms.Button();
            this.tx_Id = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Btn_CargarDatos = new System.Windows.Forms.Button();
            this.Btn_Todos = new System.Windows.Forms.Button();
            this.Btn_SoloDif = new System.Windows.Forms.Button();
            this.Btn_CargaMonNumDoc = new System.Windows.Forms.Button();
            this.Tx_MovNumDoc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Btn_InvocarWS = new System.Windows.Forms.Button();
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
            this.groupBox1.Location = new System.Drawing.Point(6, 134);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(925, 368);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // Dtg_Datos
            // 
            this.Dtg_Datos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dtg_Datos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Dtg_Datos.Location = new System.Drawing.Point(3, 16);
            this.Dtg_Datos.Name = "Dtg_Datos";
            this.Dtg_Datos.Size = new System.Drawing.Size(919, 349);
            this.Dtg_Datos.TabIndex = 0;
            this.Dtg_Datos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dtg_Datos_CellClick);
            // 
            // Tx_rut
            // 
            this.Tx_rut.Location = new System.Drawing.Point(687, 36);
            this.Tx_rut.Name = "Tx_rut";
            this.Tx_rut.Size = new System.Drawing.Size(83, 20);
            this.Tx_rut.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(646, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "RUT";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(655, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(115, 21);
            this.button2.TabIndex = 17;
            this.button2.Text = "Detalle Cliente";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Pb_
            // 
            this.Pb_.Location = new System.Drawing.Point(163, 62);
            this.Pb_.Name = "Pb_";
            this.Pb_.Size = new System.Drawing.Size(577, 23);
            this.Pb_.TabIndex = 16;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(543, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 43);
            this.button1.TabIndex = 15;
            this.button1.Text = "Revisa Clientes";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Btn_eliminar
            // 
            this.Btn_eliminar.Location = new System.Drawing.Point(264, 12);
            this.Btn_eliminar.Name = "Btn_eliminar";
            this.Btn_eliminar.Size = new System.Drawing.Size(85, 43);
            this.Btn_eliminar.TabIndex = 14;
            this.Btn_eliminar.Text = "Elimina Registro";
            this.Btn_eliminar.UseVisualStyleBackColor = true;
            this.Btn_eliminar.Click += new System.EventHandler(this.Btn_eliminar_Click);
            // 
            // tx_Id
            // 
            this.tx_Id.Location = new System.Drawing.Point(163, 13);
            this.tx_Id.Name = "tx_Id";
            this.tx_Id.Size = new System.Drawing.Size(83, 20);
            this.tx_Id.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(122, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "label1";
            // 
            // Btn_CargarDatos
            // 
            this.Btn_CargarDatos.Location = new System.Drawing.Point(20, 13);
            this.Btn_CargarDatos.Name = "Btn_CargarDatos";
            this.Btn_CargarDatos.Size = new System.Drawing.Size(85, 43);
            this.Btn_CargarDatos.TabIndex = 11;
            this.Btn_CargarDatos.Text = "Cargar Datos";
            this.Btn_CargarDatos.UseVisualStyleBackColor = true;
            this.Btn_CargarDatos.Click += new System.EventHandler(this.Btn_CargarDatos_Click);
            // 
            // Btn_Todos
            // 
            this.Btn_Todos.Location = new System.Drawing.Point(800, 12);
            this.Btn_Todos.Name = "Btn_Todos";
            this.Btn_Todos.Size = new System.Drawing.Size(74, 21);
            this.Btn_Todos.TabIndex = 20;
            this.Btn_Todos.Text = "Ver Todos";
            this.Btn_Todos.UseVisualStyleBackColor = true;
            this.Btn_Todos.Click += new System.EventHandler(this.Btn_Todos_Click);
            // 
            // Btn_SoloDif
            // 
            this.Btn_SoloDif.Location = new System.Drawing.Point(800, 40);
            this.Btn_SoloDif.Name = "Btn_SoloDif";
            this.Btn_SoloDif.Size = new System.Drawing.Size(74, 21);
            this.Btn_SoloDif.TabIndex = 21;
            this.Btn_SoloDif.Text = "Solo Dif";
            this.Btn_SoloDif.UseVisualStyleBackColor = true;
            this.Btn_SoloDif.Click += new System.EventHandler(this.Btn_SoloDif_Click);
            // 
            // Btn_CargaMonNumDoc
            // 
            this.Btn_CargaMonNumDoc.Location = new System.Drawing.Point(248, 102);
            this.Btn_CargaMonNumDoc.Name = "Btn_CargaMonNumDoc";
            this.Btn_CargaMonNumDoc.Size = new System.Drawing.Size(85, 26);
            this.Btn_CargaMonNumDoc.TabIndex = 22;
            this.Btn_CargaMonNumDoc.Text = "Cargar Datos";
            this.Btn_CargaMonNumDoc.UseVisualStyleBackColor = true;
            this.Btn_CargaMonNumDoc.Click += new System.EventHandler(this.Btn_CargaMonNumDoc_Click);
            // 
            // Tx_MovNumDoc
            // 
            this.Tx_MovNumDoc.Location = new System.Drawing.Point(103, 106);
            this.Tx_MovNumDoc.Name = "Tx_MovNumDoc";
            this.Tx_MovNumDoc.Size = new System.Drawing.Size(121, 20);
            this.Tx_MovNumDoc.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "MovNumDoc";
            // 
            // Btn_InvocarWS
            // 
            this.Btn_InvocarWS.Location = new System.Drawing.Point(425, 100);
            this.Btn_InvocarWS.Name = "Btn_InvocarWS";
            this.Btn_InvocarWS.Size = new System.Drawing.Size(85, 26);
            this.Btn_InvocarWS.TabIndex = 25;
            this.Btn_InvocarWS.Text = "Invocar WS";
            this.Btn_InvocarWS.UseVisualStyleBackColor = true;
            this.Btn_InvocarWS.Click += new System.EventHandler(this.Btn_InvocarWS_Click);
            // 
            // Frm_Tools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 503);
            this.Controls.Add(this.Btn_InvocarWS);
            this.Controls.Add(this.Tx_MovNumDoc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Btn_CargaMonNumDoc);
            this.Controls.Add(this.Btn_SoloDif);
            this.Controls.Add(this.Btn_Todos);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Tx_rut);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Pb_);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Btn_eliminar);
            this.Controls.Add(this.tx_Id);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Btn_CargarDatos);
            this.Name = "Frm_Tools";
            this.Text = "Frm_Tools";
            this.Load += new System.EventHandler(this.Frm_Tools_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_Datos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView Dtg_Datos;
        private System.Windows.Forms.TextBox Tx_rut;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ProgressBar Pb_;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Btn_eliminar;
        private System.Windows.Forms.TextBox tx_Id;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Btn_CargarDatos;
        private System.Windows.Forms.Button Btn_Todos;
        private System.Windows.Forms.Button Btn_SoloDif;
        private System.Windows.Forms.Button Btn_CargaMonNumDoc;
        private System.Windows.Forms.TextBox Tx_MovNumDoc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Btn_InvocarWS;
    }
}