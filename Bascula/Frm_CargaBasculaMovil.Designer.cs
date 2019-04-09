namespace Metalurgica.Bascula
{
    partial class Frm_CargaBasculaMovil
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
            this.Dtg_OK = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.Lbl_totalKgs = new System.Windows.Forms.Label();
            this.Btn_OK = new System.Windows.Forms.Button();
            this.Btn_Limpiar = new System.Windows.Forms.Button();
            this.Btn_NO_OK = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Tx_idPaq = new System.Windows.Forms.TextBox();
            this.Lbl_Msg = new System.Windows.Forms.Label();
            this.Lbl_Usuario = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Lbl_KgsCD = new System.Windows.Forms.Label();
            this.Lbl_KgsCon = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_OK)).BeginInit();
            this.SuspendLayout();
            // 
            // Dtg_OK
            // 
            this.Dtg_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Dtg_OK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dtg_OK.Location = new System.Drawing.Point(12, 12);
            this.Dtg_OK.Name = "Dtg_OK";
            this.Dtg_OK.Size = new System.Drawing.Size(1038, 464);
            this.Dtg_OK.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 492);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "TOTAL KILOS";
            // 
            // Lbl_totalKgs
            // 
            this.Lbl_totalKgs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Lbl_totalKgs.AutoSize = true;
            this.Lbl_totalKgs.Font = new System.Drawing.Font("Microsoft Sans Serif", 45F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_totalKgs.ForeColor = System.Drawing.Color.Red;
            this.Lbl_totalKgs.Location = new System.Drawing.Point(17, 529);
            this.Lbl_totalKgs.Name = "Lbl_totalKgs";
            this.Lbl_totalKgs.Size = new System.Drawing.Size(64, 69);
            this.Lbl_totalKgs.TabIndex = 3;
            this.Lbl_totalKgs.Text = "0";
            // 
            // Btn_OK
            // 
            this.Btn_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Btn_OK.Location = new System.Drawing.Point(496, 526);
            this.Btn_OK.Name = "Btn_OK";
            this.Btn_OK.Size = new System.Drawing.Size(90, 61);
            this.Btn_OK.TabIndex = 4;
            this.Btn_OK.Text = "OK";
            this.Btn_OK.UseVisualStyleBackColor = true;
            this.Btn_OK.Click += new System.EventHandler(this.Btn_OK_Click);
            // 
            // Btn_Limpiar
            // 
            this.Btn_Limpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Btn_Limpiar.Location = new System.Drawing.Point(620, 526);
            this.Btn_Limpiar.Name = "Btn_Limpiar";
            this.Btn_Limpiar.Size = new System.Drawing.Size(90, 61);
            this.Btn_Limpiar.TabIndex = 5;
            this.Btn_Limpiar.Text = "Limpiar";
            this.Btn_Limpiar.UseVisualStyleBackColor = true;
            this.Btn_Limpiar.Click += new System.EventHandler(this.Btn_Limpiar_Click);
            // 
            // Btn_NO_OK
            // 
            this.Btn_NO_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Btn_NO_OK.Location = new System.Drawing.Point(734, 526);
            this.Btn_NO_OK.Name = "Btn_NO_OK";
            this.Btn_NO_OK.Size = new System.Drawing.Size(90, 61);
            this.Btn_NO_OK.TabIndex = 6;
            this.Btn_NO_OK.Text = "NO   OK";
            this.Btn_NO_OK.UseVisualStyleBackColor = true;
            this.Btn_NO_OK.Click += new System.EventHandler(this.Btn_NO_OK_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button3.Location = new System.Drawing.Point(841, 526);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(90, 61);
            this.button3.TabIndex = 7;
            this.button3.Text = "Salir";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(463, 479);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(216, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Ingrese en Codigo de Barras";
            // 
            // Tx_idPaq
            // 
            this.Tx_idPaq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Tx_idPaq.Location = new System.Drawing.Point(493, 500);
            this.Tx_idPaq.Name = "Tx_idPaq";
            this.Tx_idPaq.Size = new System.Drawing.Size(162, 20);
            this.Tx_idPaq.TabIndex = 9;
            this.Tx_idPaq.TextChanged += new System.EventHandler(this.Tx_idPaq_TextChanged);
            this.Tx_idPaq.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Tx_idPaq_KeyPress);
            this.Tx_idPaq.Validating += new System.ComponentModel.CancelEventHandler(this.Tx_idPaq_Validating);
            // 
            // Lbl_Msg
            // 
            this.Lbl_Msg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Lbl_Msg.AutoSize = true;
            this.Lbl_Msg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Msg.Location = new System.Drawing.Point(975, 592);
            this.Lbl_Msg.Name = "Lbl_Msg";
            this.Lbl_Msg.Size = new System.Drawing.Size(47, 15);
            this.Lbl_Msg.TabIndex = 10;
            this.Lbl_Msg.Text = "label1";
            // 
            // Lbl_Usuario
            // 
            this.Lbl_Usuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Lbl_Usuario.AutoSize = true;
            this.Lbl_Usuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Usuario.Location = new System.Drawing.Point(661, 592);
            this.Lbl_Usuario.Name = "Lbl_Usuario";
            this.Lbl_Usuario.Size = new System.Drawing.Size(47, 15);
            this.Lbl_Usuario.TabIndex = 11;
            this.Lbl_Usuario.Text = "label1";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(294, 493);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "Kgs. C y  D";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(298, 555);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Kgs. Conectores";
            // 
            // Lbl_KgsCD
            // 
            this.Lbl_KgsCD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Lbl_KgsCD.AutoSize = true;
            this.Lbl_KgsCD.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_KgsCD.ForeColor = System.Drawing.Color.Red;
            this.Lbl_KgsCD.Location = new System.Drawing.Point(308, 516);
            this.Lbl_KgsCD.Name = "Lbl_KgsCD";
            this.Lbl_KgsCD.Size = new System.Drawing.Size(37, 39);
            this.Lbl_KgsCD.TabIndex = 14;
            this.Lbl_KgsCD.Text = "0";
            // 
            // Lbl_KgsCon
            // 
            this.Lbl_KgsCon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Lbl_KgsCon.AutoSize = true;
            this.Lbl_KgsCon.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_KgsCon.ForeColor = System.Drawing.Color.Red;
            this.Lbl_KgsCon.Location = new System.Drawing.Point(308, 577);
            this.Lbl_KgsCon.Name = "Lbl_KgsCon";
            this.Lbl_KgsCon.Size = new System.Drawing.Size(37, 39);
            this.Lbl_KgsCon.TabIndex = 15;
            this.Lbl_KgsCon.Text = "0";
            // 
            // Frm_CargaBasculaMovil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 616);
            this.ControlBox = false;
            this.Controls.Add(this.Lbl_KgsCon);
            this.Controls.Add(this.Lbl_KgsCD);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Lbl_Usuario);
            this.Controls.Add(this.Lbl_Msg);
            this.Controls.Add(this.Tx_idPaq);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.Btn_NO_OK);
            this.Controls.Add(this.Btn_Limpiar);
            this.Controls.Add(this.Btn_OK);
            this.Controls.Add(this.Lbl_totalKgs);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Dtg_OK);
            this.Name = "Frm_CargaBasculaMovil";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Carga de Paquetes desde Bascula Móvil";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.Frm_CargaBasculaMovil_Activated);
            this.Load += new System.EventHandler(this.Frm_CargaBasculaMovil_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_OK)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Dtg_OK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Lbl_totalKgs;
        private System.Windows.Forms.Button Btn_OK;
        private System.Windows.Forms.Button Btn_Limpiar;
        private System.Windows.Forms.Button Btn_NO_OK;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Tx_idPaq;
        private System.Windows.Forms.Label Lbl_Msg;
        private System.Windows.Forms.Label Lbl_Usuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label Lbl_KgsCD;
        private System.Windows.Forms.Label Lbl_KgsCon;
    }
}