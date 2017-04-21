namespace Metalurgica
{
    partial class Frm_SeleccionarViajes
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
            this.Btn_Aceptar = new System.Windows.Forms.Button();
            this.Btn_Salir = new System.Windows.Forms.Button();
            this.Dtg_Resultado = new System.Windows.Forms.DataGridView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.Rb_Despachados = new System.Windows.Forms.RadioButton();
            this.Rb_PorDespachar = new System.Windows.Forms.RadioButton();
            this.Rb_Todos = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_Resultado)).BeginInit();
            this.SuspendLayout();
            // 
            // Btn_Aceptar
            // 
            this.Btn_Aceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Aceptar.Location = new System.Drawing.Point(605, 2);
            this.Btn_Aceptar.Name = "Btn_Aceptar";
            this.Btn_Aceptar.Size = new System.Drawing.Size(75, 51);
            this.Btn_Aceptar.TabIndex = 0;
            this.Btn_Aceptar.Text = "Aceptar";
            this.Btn_Aceptar.UseVisualStyleBackColor = true;
            this.Btn_Aceptar.Click += new System.EventHandler(this.Btn_Aceptar_Click);
            // 
            // Btn_Salir
            // 
            this.Btn_Salir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Salir.Location = new System.Drawing.Point(700, 2);
            this.Btn_Salir.Name = "Btn_Salir";
            this.Btn_Salir.Size = new System.Drawing.Size(75, 51);
            this.Btn_Salir.TabIndex = 1;
            this.Btn_Salir.Text = "Salir";
            this.Btn_Salir.UseVisualStyleBackColor = true;
            this.Btn_Salir.Click += new System.EventHandler(this.Btn_Salir_Click);
            // 
            // Dtg_Resultado
            // 
            this.Dtg_Resultado.AllowUserToAddRows = false;
            this.Dtg_Resultado.AllowUserToDeleteRows = false;
            this.Dtg_Resultado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Dtg_Resultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dtg_Resultado.Location = new System.Drawing.Point(7, 59);
            this.Dtg_Resultado.Name = "Dtg_Resultado";
            this.Dtg_Resultado.Size = new System.Drawing.Size(776, 338);
            this.Dtg_Resultado.TabIndex = 2;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(32, 32);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // Rb_Despachados
            // 
            this.Rb_Despachados.AutoSize = true;
            this.Rb_Despachados.Location = new System.Drawing.Point(44, 19);
            this.Rb_Despachados.Name = "Rb_Despachados";
            this.Rb_Despachados.Size = new System.Drawing.Size(122, 17);
            this.Rb_Despachados.TabIndex = 3;
            this.Rb_Despachados.TabStop = true;
            this.Rb_Despachados.Text = "Viajes Despachados";
            this.Rb_Despachados.UseVisualStyleBackColor = true;
            this.Rb_Despachados.CheckedChanged += new System.EventHandler(this.Rb_Despachados_CheckedChanged);
            // 
            // Rb_PorDespachar
            // 
            this.Rb_PorDespachar.AutoSize = true;
            this.Rb_PorDespachar.Checked = true;
            this.Rb_PorDespachar.Location = new System.Drawing.Point(193, 19);
            this.Rb_PorDespachar.Name = "Rb_PorDespachar";
            this.Rb_PorDespachar.Size = new System.Drawing.Size(133, 17);
            this.Rb_PorDespachar.TabIndex = 4;
            this.Rb_PorDespachar.TabStop = true;
            this.Rb_PorDespachar.Text = "Viajes Para Despachar";
            this.Rb_PorDespachar.UseVisualStyleBackColor = true;
            this.Rb_PorDespachar.CheckedChanged += new System.EventHandler(this.Rb_PorDespachar_CheckedChanged);
            // 
            // Rb_Todos
            // 
            this.Rb_Todos.AutoSize = true;
            this.Rb_Todos.Location = new System.Drawing.Point(366, 19);
            this.Rb_Todos.Name = "Rb_Todos";
            this.Rb_Todos.Size = new System.Drawing.Size(102, 17);
            this.Rb_Todos.TabIndex = 5;
            this.Rb_Todos.Text = "Todos los Viajes";
            this.Rb_Todos.UseVisualStyleBackColor = true;
            this.Rb_Todos.CheckedChanged += new System.EventHandler(this.Rb_Todos_CheckedChanged);
            // 
            // Frm_SeleccionarViajes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 400);
            this.Controls.Add(this.Rb_Todos);
            this.Controls.Add(this.Rb_PorDespachar);
            this.Controls.Add(this.Rb_Despachados);
            this.Controls.Add(this.Dtg_Resultado);
            this.Controls.Add(this.Btn_Salir);
            this.Controls.Add(this.Btn_Aceptar);
            this.Name = "Frm_SeleccionarViajes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formulario de seleccion de viajes par cargar camión";
            this.Load += new System.EventHandler(this.Frm_SeleccionarViajes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_Resultado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_Aceptar;
        private System.Windows.Forms.Button Btn_Salir;
        private System.Windows.Forms.DataGridView Dtg_Resultado;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.RadioButton Rb_Despachados;
        private System.Windows.Forms.RadioButton Rb_PorDespachar;
        private System.Windows.Forms.RadioButton Rb_Todos;
    }
}