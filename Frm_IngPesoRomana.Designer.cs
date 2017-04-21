namespace Metalurgica
{
    partial class Frm_IngPesoRomana
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_IngPesoRomana));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.Btn_Grabar = new System.Windows.Forms.Button();
            this.Btn_Salir = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Tx_Dif = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.Tx_Estado = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.Tx_PesoViaje = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Tx_ViajesCargados = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Tx_FechaDespacho = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Tx_PesoRomana = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Cmb_Patente = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Cmb_Obra = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Cmb_ViajesCargados = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Dtg_Resultado = new System.Windows.Forms.DataGridView();
            this.Btn_InformeBascula = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_Resultado)).BeginInit();
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
            // 
            // Btn_Grabar
            // 
            this.Btn_Grabar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Grabar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Grabar.ImageIndex = 0;
            this.Btn_Grabar.ImageList = this.imageList1;
            this.Btn_Grabar.Location = new System.Drawing.Point(1003, 21);
            this.Btn_Grabar.Name = "Btn_Grabar";
            this.Btn_Grabar.Size = new System.Drawing.Size(75, 56);
            this.Btn_Grabar.TabIndex = 0;
            this.Btn_Grabar.Text = "&Grabar";
            this.Btn_Grabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Grabar.UseVisualStyleBackColor = true;
            this.Btn_Grabar.Click += new System.EventHandler(this.Btn_Grabar_Click);
            // 
            // Btn_Salir
            // 
            this.Btn_Salir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Salir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Salir.ImageIndex = 5;
            this.Btn_Salir.ImageList = this.imageList1;
            this.Btn_Salir.Location = new System.Drawing.Point(1003, 97);
            this.Btn_Salir.Name = "Btn_Salir";
            this.Btn_Salir.Size = new System.Drawing.Size(75, 56);
            this.Btn_Salir.TabIndex = 1;
            this.Btn_Salir.Text = "&Salir";
            this.Btn_Salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Salir.UseVisualStyleBackColor = true;
            this.Btn_Salir.Click += new System.EventHandler(this.Btn_Salir_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Tx_Dif);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.Tx_Estado);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.Tx_PesoViaje);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.Tx_ViajesCargados);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.Tx_FechaDespacho);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.Tx_PesoRomana);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.Cmb_Patente);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Cmb_Obra);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(7, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(924, 186);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ingreso de Datos";
            // 
            // Tx_Dif
            // 
            this.Tx_Dif.Location = new System.Drawing.Point(564, 149);
            this.Tx_Dif.Name = "Tx_Dif";
            this.Tx_Dif.ReadOnly = true;
            this.Tx_Dif.Size = new System.Drawing.Size(60, 23);
            this.Tx_Dif.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(561, 129);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 17);
            this.label9.TabIndex = 16;
            this.label9.Text = "Diferencia";
            // 
            // Tx_Estado
            // 
            this.Tx_Estado.Location = new System.Drawing.Point(469, 153);
            this.Tx_Estado.Name = "Tx_Estado";
            this.Tx_Estado.ReadOnly = true;
            this.Tx_Estado.Size = new System.Drawing.Size(60, 23);
            this.Tx_Estado.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(473, 129);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 17);
            this.label8.TabIndex = 14;
            this.label8.Text = "Estado";
            // 
            // Tx_PesoViaje
            // 
            this.Tx_PesoViaje.Location = new System.Drawing.Point(322, 153);
            this.Tx_PesoViaje.Name = "Tx_PesoViaje";
            this.Tx_PesoViaje.ReadOnly = true;
            this.Tx_PesoViaje.Size = new System.Drawing.Size(100, 23);
            this.Tx_PesoViaje.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(330, 129);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 17);
            this.label7.TabIndex = 12;
            this.label7.Text = "Peso Viajes";
            // 
            // Tx_ViajesCargados
            // 
            this.Tx_ViajesCargados.Location = new System.Drawing.Point(170, 65);
            this.Tx_ViajesCargados.Multiline = true;
            this.Tx_ViajesCargados.Name = "Tx_ViajesCargados";
            this.Tx_ViajesCargados.Size = new System.Drawing.Size(731, 47);
            this.Tx_ViajesCargados.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Viajes Cargados";
            // 
            // Tx_FechaDespacho
            // 
            this.Tx_FechaDespacho.Location = new System.Drawing.Point(683, 153);
            this.Tx_FechaDespacho.Name = "Tx_FechaDespacho";
            this.Tx_FechaDespacho.ReadOnly = true;
            this.Tx_FechaDespacho.Size = new System.Drawing.Size(164, 23);
            this.Tx_FechaDespacho.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(707, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Fecha Despacho";
            // 
            // Tx_PesoRomana
            // 
            this.Tx_PesoRomana.Location = new System.Drawing.Point(183, 153);
            this.Tx_PesoRomana.Name = "Tx_PesoRomana";
            this.Tx_PesoRomana.Size = new System.Drawing.Size(100, 23);
            this.Tx_PesoRomana.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(170, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Peso de la Romana";
            // 
            // Cmb_Patente
            // 
            this.Cmb_Patente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cmb_Patente.FormattingEnabled = true;
            this.Cmb_Patente.Location = new System.Drawing.Point(724, 27);
            this.Cmb_Patente.Name = "Cmb_Patente";
            this.Cmb_Patente.Size = new System.Drawing.Size(133, 24);
            this.Cmb_Patente.TabIndex = 3;
            this.Cmb_Patente.SelectedIndexChanged += new System.EventHandler(this.Cmb_Patente_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(573, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Seleccione la Patente";
            // 
            // Cmb_Obra
            // 
            this.Cmb_Obra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cmb_Obra.FormattingEnabled = true;
            this.Cmb_Obra.Location = new System.Drawing.Point(172, 27);
            this.Cmb_Obra.Name = "Cmb_Obra";
            this.Cmb_Obra.Size = new System.Drawing.Size(385, 24);
            this.Cmb_Obra.TabIndex = 1;
            this.Cmb_Obra.SelectedIndexChanged += new System.EventHandler(this.Cmb_Obra_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccione la Obra";
            // 
            // Cmb_ViajesCargados
            // 
            this.Cmb_ViajesCargados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cmb_ViajesCargados.FormattingEnabled = true;
            this.Cmb_ViajesCargados.Location = new System.Drawing.Point(595, 211);
            this.Cmb_ViajesCargados.Name = "Cmb_ViajesCargados";
            this.Cmb_ViajesCargados.Size = new System.Drawing.Size(336, 21);
            this.Cmb_ViajesCargados.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(724, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Seleccione viajes Cargados";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.Dtg_Resultado);
            this.groupBox2.Location = new System.Drawing.Point(7, 238);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1071, 308);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Seleccionar los viajes Despachados en el Camión";
            // 
            // Dtg_Resultado
            // 
            this.Dtg_Resultado.AllowUserToAddRows = false;
            this.Dtg_Resultado.AllowUserToDeleteRows = false;
            this.Dtg_Resultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dtg_Resultado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Dtg_Resultado.Location = new System.Drawing.Point(3, 16);
            this.Dtg_Resultado.Name = "Dtg_Resultado";
            this.Dtg_Resultado.ReadOnly = true;
            this.Dtg_Resultado.Size = new System.Drawing.Size(1065, 289);
            this.Dtg_Resultado.TabIndex = 0;
            this.Dtg_Resultado.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dtg_Resultado_CellContentClick);
            // 
            // Btn_InformeBascula
            // 
            this.Btn_InformeBascula.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_InformeBascula.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_InformeBascula.ImageIndex = 2;
            this.Btn_InformeBascula.ImageList = this.imageList1;
            this.Btn_InformeBascula.Location = new System.Drawing.Point(1000, 175);
            this.Btn_InformeBascula.Name = "Btn_InformeBascula";
            this.Btn_InformeBascula.Size = new System.Drawing.Size(75, 56);
            this.Btn_InformeBascula.TabIndex = 10;
            this.Btn_InformeBascula.Text = "&Informe Camión";
            this.Btn_InformeBascula.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_InformeBascula.UseVisualStyleBackColor = true;
            // 
            // Frm_IngPesoRomana
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 552);
            this.ControlBox = false;
            this.Controls.Add(this.Btn_InformeBascula);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Cmb_ViajesCargados);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Btn_Salir);
            this.Controls.Add(this.Btn_Grabar);
            this.Name = "Frm_IngPesoRomana";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formulario para el  ingreso de Pesaje de Romana a la IT";
            this.Load += new System.EventHandler(this.Frm_IngPesoRomana_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_Resultado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button Btn_Grabar;
        private System.Windows.Forms.Button Btn_Salir;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox Tx_PesoRomana;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox Cmb_Patente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox Cmb_Obra;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Cmb_ViajesCargados;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView Dtg_Resultado;
        private System.Windows.Forms.TextBox Tx_ViajesCargados;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Tx_FechaDespacho;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Tx_Estado;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Tx_PesoViaje;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox Tx_Dif;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button Btn_InformeBascula;
    }
}