namespace Metalurgica
{
    partial class FrmConfirmaPieza
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConfirmaPieza));
            this.Lbl_Msg = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Tx_NroPiezas = new System.Windows.Forms.TextBox();
            this.Btn_Grabar = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.Btn_Cancelar = new System.Windows.Forms.Button();
            this.lbl_Res = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Dtg_ColadasIngresadas = new System.Windows.Forms.DataGridView();
            this.Tx_Colada = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Btn_salir = new System.Windows.Forms.Button();
            this.Btn_Eliminar = new System.Windows.Forms.Button();
            this.Tx_IdDetallePaquete = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Tx_DiamPieza = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_ColadasIngresadas)).BeginInit();
            this.SuspendLayout();
            // 
            // Lbl_Msg
            // 
            this.Lbl_Msg.AutoSize = true;
            this.Lbl_Msg.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Msg.Location = new System.Drawing.Point(18, 12);
            this.Lbl_Msg.Name = "Lbl_Msg";
            this.Lbl_Msg.Size = new System.Drawing.Size(123, 19);
            this.Lbl_Msg.TabIndex = 0;
            this.Lbl_Msg.Text = "El Paquete  tiene ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(199, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Número de Piezas Producidas";
            // 
            // Tx_NroPiezas
            // 
            this.Tx_NroPiezas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tx_NroPiezas.Location = new System.Drawing.Point(224, 120);
            this.Tx_NroPiezas.Name = "Tx_NroPiezas";
            this.Tx_NroPiezas.Size = new System.Drawing.Size(52, 24);
            this.Tx_NroPiezas.TabIndex = 2;
            this.Tx_NroPiezas.Text = "00";
            // 
            // Btn_Grabar
            // 
            this.Btn_Grabar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Grabar.ImageIndex = 0;
            this.Btn_Grabar.ImageList = this.imageList1;
            this.Btn_Grabar.Location = new System.Drawing.Point(535, 16);
            this.Btn_Grabar.Name = "Btn_Grabar";
            this.Btn_Grabar.Size = new System.Drawing.Size(87, 61);
            this.Btn_Grabar.TabIndex = 0;
            this.Btn_Grabar.Text = "Grabar";
            this.Btn_Grabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Grabar.UseVisualStyleBackColor = true;
            this.Btn_Grabar.Click += new System.EventHandler(this.Btn_Grabar_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Untitled (426).ico");
            this.imageList1.Images.SetKeyName(1, "Untitled (152).ico");
            this.imageList1.Images.SetKeyName(2, "Untitled (672).ico");
            this.imageList1.Images.SetKeyName(3, "Untitled (406).ico");
            // 
            // Btn_Cancelar
            // 
            this.Btn_Cancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Cancelar.ImageIndex = 3;
            this.Btn_Cancelar.ImageList = this.imageList1;
            this.Btn_Cancelar.Location = new System.Drawing.Point(657, 16);
            this.Btn_Cancelar.Name = "Btn_Cancelar";
            this.Btn_Cancelar.Size = new System.Drawing.Size(87, 61);
            this.Btn_Cancelar.TabIndex = 1;
            this.Btn_Cancelar.Text = "Cancelar";
            this.Btn_Cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Cancelar.UseVisualStyleBackColor = true;
            this.Btn_Cancelar.Click += new System.EventHandler(this.Btn_Cancelar_Click);
            // 
            // lbl_Res
            // 
            this.lbl_Res.AutoSize = true;
            this.lbl_Res.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Res.Location = new System.Drawing.Point(26, 165);
            this.lbl_Res.Name = "lbl_Res";
            this.lbl_Res.Size = new System.Drawing.Size(0, 19);
            this.lbl_Res.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.Dtg_ColadasIngresadas);
            this.groupBox1.Controls.Add(this.Tx_Colada);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 153);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(749, 224);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalle de las Coladas Utilizadas";
            // 
            // Dtg_ColadasIngresadas
            // 
            this.Dtg_ColadasIngresadas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Dtg_ColadasIngresadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dtg_ColadasIngresadas.Location = new System.Drawing.Point(10, 55);
            this.Dtg_ColadasIngresadas.Name = "Dtg_ColadasIngresadas";
            this.Dtg_ColadasIngresadas.Size = new System.Drawing.Size(734, 162);
            this.Dtg_ColadasIngresadas.TabIndex = 2;
            this.Dtg_ColadasIngresadas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dtg_ColadasIngresadas_CellClick);
            this.Dtg_ColadasIngresadas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dtg_ColadasIngresadas_CellContentClick);
            // 
            // Tx_Colada
            // 
            this.Tx_Colada.Location = new System.Drawing.Point(116, 20);
            this.Tx_Colada.Name = "Tx_Colada";
            this.Tx_Colada.Size = new System.Drawing.Size(183, 20);
            this.Tx_Colada.TabIndex = 1;
            this.Tx_Colada.TextChanged += new System.EventHandler(this.Tx_Colada_TextChanged);
            this.Tx_Colada.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Tx_Colada_KeyPress);
            this.Tx_Colada.Validating += new System.ComponentModel.CancelEventHandler(this.Tx_Colada_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingrese la colada";
            // 
            // Btn_salir
            // 
            this.Btn_salir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_salir.ImageIndex = 2;
            this.Btn_salir.ImageList = this.imageList1;
            this.Btn_salir.Location = new System.Drawing.Point(657, 82);
            this.Btn_salir.Name = "Btn_salir";
            this.Btn_salir.Size = new System.Drawing.Size(87, 61);
            this.Btn_salir.TabIndex = 8;
            this.Btn_salir.Text = "Salir";
            this.Btn_salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_salir.UseVisualStyleBackColor = true;
            this.Btn_salir.Click += new System.EventHandler(this.Btn_salir_Click);
            // 
            // Btn_Eliminar
            // 
            this.Btn_Eliminar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Eliminar.ImageIndex = 1;
            this.Btn_Eliminar.ImageList = this.imageList1;
            this.Btn_Eliminar.Location = new System.Drawing.Point(535, 83);
            this.Btn_Eliminar.Name = "Btn_Eliminar";
            this.Btn_Eliminar.Size = new System.Drawing.Size(87, 61);
            this.Btn_Eliminar.TabIndex = 7;
            this.Btn_Eliminar.Text = "Eliminar Colada";
            this.Btn_Eliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Eliminar.UseVisualStyleBackColor = true;
            this.Btn_Eliminar.Click += new System.EventHandler(this.Btn_Eliminar_Click);
            // 
            // Tx_IdDetallePaquete
            // 
            this.Tx_IdDetallePaquete.Location = new System.Drawing.Point(482, 127);
            this.Tx_IdDetallePaquete.Name = "Tx_IdDetallePaquete";
            this.Tx_IdDetallePaquete.Size = new System.Drawing.Size(47, 20);
            this.Tx_IdDetallePaquete.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(293, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Diámetro:";
            // 
            // Tx_DiamPieza
            // 
            this.Tx_DiamPieza.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Tx_DiamPieza.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tx_DiamPieza.Location = new System.Drawing.Point(361, 120);
            this.Tx_DiamPieza.Name = "Tx_DiamPieza";
            this.Tx_DiamPieza.ReadOnly = true;
            this.Tx_DiamPieza.Size = new System.Drawing.Size(37, 24);
            this.Tx_DiamPieza.TabIndex = 11;
            this.Tx_DiamPieza.Text = "00";
            // 
            // FrmConfirmaPieza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 380);
            this.ControlBox = false;
            this.Controls.Add(this.Tx_DiamPieza);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Tx_IdDetallePaquete);
            this.Controls.Add(this.Btn_salir);
            this.Controls.Add(this.Btn_Eliminar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbl_Res);
            this.Controls.Add(this.Btn_Cancelar);
            this.Controls.Add(this.Btn_Grabar);
            this.Controls.Add(this.Tx_NroPiezas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Lbl_Msg);
            this.Name = "FrmConfirmaPieza";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Confirmación de Piezas  Producidas";
            this.Load += new System.EventHandler(this.FrmConfirmaPieza_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_ColadasIngresadas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lbl_Msg;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Tx_NroPiezas;
        private System.Windows.Forms.Button Btn_Grabar;
        private System.Windows.Forms.Button Btn_Cancelar;
        private System.Windows.Forms.Label lbl_Res;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView Dtg_ColadasIngresadas;
        private System.Windows.Forms.TextBox Tx_Colada;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button Btn_salir;
        private System.Windows.Forms.Button Btn_Eliminar;
        private System.Windows.Forms.TextBox Tx_IdDetallePaquete;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Tx_DiamPieza;
    }
}