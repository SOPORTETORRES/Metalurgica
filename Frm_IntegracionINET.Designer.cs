namespace Metalurgica
{
    partial class Frm_IntegracionINET
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_IntegracionINET));
            this.Dtg_Camiones = new System.Windows.Forms.DataGridView();
            this.TR_Arbol = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.Btn_INET = new System.Windows.Forms.Button();
            this.Tx_Patente = new System.Windows.Forms.TextBox();
            this.TX_Estado = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Tx_Fecha = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Btn_Imprimir = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.BTN_actualizarViaje = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_Camiones)).BeginInit();
            this.SuspendLayout();
            // 
            // Dtg_Camiones
            // 
            this.Dtg_Camiones.AllowUserToAddRows = false;
            this.Dtg_Camiones.AllowUserToDeleteRows = false;
            this.Dtg_Camiones.AllowUserToOrderColumns = true;
            this.Dtg_Camiones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Dtg_Camiones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dtg_Camiones.Location = new System.Drawing.Point(322, 89);
            this.Dtg_Camiones.Name = "Dtg_Camiones";
            this.Dtg_Camiones.Size = new System.Drawing.Size(644, 208);
            this.Dtg_Camiones.TabIndex = 0;
            this.Dtg_Camiones.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dtg_Camiones_CellContentClick);
            // 
            // TR_Arbol
            // 
            this.TR_Arbol.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.TR_Arbol.ImageIndex = 0;
            this.TR_Arbol.ImageList = this.imageList1;
            this.TR_Arbol.Location = new System.Drawing.Point(15, 69);
            this.TR_Arbol.Name = "TR_Arbol";
            this.TR_Arbol.SelectedImageIndex = 0;
            this.TR_Arbol.Size = new System.Drawing.Size(287, 479);
            this.TR_Arbol.TabIndex = 1;
            this.TR_Arbol.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TR_Arbol_AfterSelect);
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
            // 
            // Btn_INET
            // 
            this.Btn_INET.Enabled = false;
            this.Btn_INET.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_INET.ImageKey = "Untitled (358).ico";
            this.Btn_INET.ImageList = this.imageList1;
            this.Btn_INET.Location = new System.Drawing.Point(777, 6);
            this.Btn_INET.Name = "Btn_INET";
            this.Btn_INET.Size = new System.Drawing.Size(80, 57);
            this.Btn_INET.TabIndex = 2;
            this.Btn_INET.Text = "Generar Guía INET";
            this.Btn_INET.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_INET.UseVisualStyleBackColor = true;
            this.Btn_INET.Click += new System.EventHandler(this.Btn_INET_Click);
            // 
            // Tx_Patente
            // 
            this.Tx_Patente.Location = new System.Drawing.Point(447, 40);
            this.Tx_Patente.Name = "Tx_Patente";
            this.Tx_Patente.Size = new System.Drawing.Size(100, 20);
            this.Tx_Patente.TabIndex = 3;
            // 
            // TX_Estado
            // 
            this.TX_Estado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TX_Estado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TX_Estado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TX_Estado.Location = new System.Drawing.Point(322, 324);
            this.TX_Estado.Multiline = true;
            this.TX_Estado.Name = "TX_Estado";
            this.TX_Estado.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TX_Estado.Size = new System.Drawing.Size(644, 220);
            this.TX_Estado.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(322, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Nro. Patente Despacho";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(563, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Fecha Despacho";
            // 
            // Tx_Fecha
            // 
            this.Tx_Fecha.Location = new System.Drawing.Point(658, 40);
            this.Tx_Fecha.Name = "Tx_Fecha";
            this.Tx_Fecha.Size = new System.Drawing.Size(100, 20);
            this.Tx_Fecha.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(278, 23);
            this.label3.TabIndex = 9;
            this.label3.Text = "Despachos Pendientes de Integrar con INET";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(334, 297);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(609, 23);
            this.label4.TabIndex = 10;
            this.label4.Text = "Detalle del proceso de integración con INET";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Btn_Imprimir
            // 
            this.Btn_Imprimir.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Imprimir.ImageIndex = 4;
            this.Btn_Imprimir.ImageList = this.imageList1;
            this.Btn_Imprimir.Location = new System.Drawing.Point(875, 6);
            this.Btn_Imprimir.Name = "Btn_Imprimir";
            this.Btn_Imprimir.Size = new System.Drawing.Size(81, 57);
            this.Btn_Imprimir.TabIndex = 11;
            this.Btn_Imprimir.Text = "Informe Carga";
            this.Btn_Imprimir.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Imprimir.UseVisualStyleBackColor = true;
            this.Btn_Imprimir.Visible = false;
            this.Btn_Imprimir.Click += new System.EventHandler(this.Btn_Imprimir_Click);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(319, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(609, 23);
            this.label5.TabIndex = 12;
            this.label5.Text = "Despachos Pendientes de Integrar con INET";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BTN_actualizarViaje
            // 
            this.BTN_actualizarViaje.Location = new System.Drawing.Point(472, 5);
            this.BTN_actualizarViaje.Name = "BTN_actualizarViaje";
            this.BTN_actualizarViaje.Size = new System.Drawing.Size(231, 23);
            this.BTN_actualizarViaje.TabIndex = 13;
            this.BTN_actualizarViaje.Text = "Actualizar Viaje como despachado";
            this.BTN_actualizarViaje.UseVisualStyleBackColor = true;
            this.BTN_actualizarViaje.Click += new System.EventHandler(this.BTN_actualizarViaje_Click);
            // 
            // Frm_IntegracionINET
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 560);
            this.Controls.Add(this.BTN_actualizarViaje);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Btn_Imprimir);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TX_Estado);
            this.Controls.Add(this.Tx_Fecha);
            this.Controls.Add(this.Tx_Patente);
            this.Controls.Add(this.Btn_INET);
            this.Controls.Add(this.TR_Arbol);
            this.Controls.Add(this.Dtg_Camiones);
            this.Name = "Frm_IntegracionINET";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formulario de Integración de Guías con INET";
            this.Load += new System.EventHandler(this.Frm_IntegracionINET_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_Camiones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Dtg_Camiones;
        private System.Windows.Forms.TreeView TR_Arbol;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button Btn_INET;
        private System.Windows.Forms.TextBox Tx_Patente;
        internal System.Windows.Forms.TextBox TX_Estado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Tx_Fecha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Btn_Imprimir;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BTN_actualizarViaje;
    }
}