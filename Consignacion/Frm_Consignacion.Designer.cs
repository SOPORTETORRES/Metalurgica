namespace Metalurgica.Consignacion
{
    partial class Frm_Consignacion
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
            this.Tx_GuiaDespacho = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Dtg_MP = new System.Windows.Forms.DataGridView();
            this.Btn_CargaDatos = new System.Windows.Forms.Button();
            this.Lbl_Msg = new System.Windows.Forms.Label();
            this.Tx_CB = new System.Windows.Forms.TextBox();
            this.Btn_IniciaProceso = new System.Windows.Forms.Button();
            this.Btn_Finaliza = new System.Windows.Forms.Button();
            this.Tx_NroPaq = new System.Windows.Forms.TextBox();
            this.gr_GuiaDespacho = new System.Windows.Forms.GroupBox();
            this.Btn_OK = new System.Windows.Forms.Button();
            this.gr_NroPaquetes = new System.Windows.Forms.GroupBox();
            this.Btn_OK1 = new System.Windows.Forms.Button();
            this.gr_CB = new System.Windows.Forms.GroupBox();
            this.Rb_Pistoleo1 = new System.Windows.Forms.RadioButton();
            this.Rb_Pistoleo2 = new System.Windows.Forms.RadioButton();
            this.Rb_Todos = new System.Windows.Forms.RadioButton();
            this.mn_Trazabilidad = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.verTrazabilidadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Rb_ColadasPiezas = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_MP)).BeginInit();
            this.gr_GuiaDespacho.SuspendLayout();
            this.gr_NroPaquetes.SuspendLayout();
            this.gr_CB.SuspendLayout();
            this.mn_Trazabilidad.SuspendLayout();
            this.SuspendLayout();
            // 
            // Tx_GuiaDespacho
            // 
            this.Tx_GuiaDespacho.Location = new System.Drawing.Point(12, 20);
            this.Tx_GuiaDespacho.Name = "Tx_GuiaDespacho";
            this.Tx_GuiaDespacho.Size = new System.Drawing.Size(153, 20);
            this.Tx_GuiaDespacho.TabIndex = 1;
            this.Tx_GuiaDespacho.Validating += new System.ComponentModel.CancelEventHandler(this.Tx_GuiaDespacho_Validating);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.Dtg_MP);
            this.groupBox1.Location = new System.Drawing.Point(13, 107);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(972, 319);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalle de la Carga";
            // 
            // Dtg_MP
            // 
            this.Dtg_MP.AllowUserToAddRows = false;
            this.Dtg_MP.AllowUserToDeleteRows = false;
            this.Dtg_MP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dtg_MP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Dtg_MP.Location = new System.Drawing.Point(3, 16);
            this.Dtg_MP.Name = "Dtg_MP";
            this.Dtg_MP.ReadOnly = true;
            this.Dtg_MP.Size = new System.Drawing.Size(966, 300);
            this.Dtg_MP.TabIndex = 0;
            this.Dtg_MP.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dtg_MP_CellContentClick);
            this.Dtg_MP.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Dtg_MP_MouseDown);
            // 
            // Btn_CargaDatos
            // 
            this.Btn_CargaDatos.Location = new System.Drawing.Point(203, 16);
            this.Btn_CargaDatos.Name = "Btn_CargaDatos";
            this.Btn_CargaDatos.Size = new System.Drawing.Size(27, 23);
            this.Btn_CargaDatos.TabIndex = 3;
            this.Btn_CargaDatos.Text = "Cargar Datos";
            this.Btn_CargaDatos.UseVisualStyleBackColor = true;
            this.Btn_CargaDatos.Visible = false;
            this.Btn_CargaDatos.Click += new System.EventHandler(this.Btn_CargaDatos_Click);
            // 
            // Lbl_Msg
            // 
            this.Lbl_Msg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Lbl_Msg.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Msg.ForeColor = System.Drawing.Color.Red;
            this.Lbl_Msg.Location = new System.Drawing.Point(102, 65);
            this.Lbl_Msg.Name = "Lbl_Msg";
            this.Lbl_Msg.Size = new System.Drawing.Size(689, 37);
            this.Lbl_Msg.TabIndex = 4;
            this.Lbl_Msg.Text = "Para Comenzar debe presionar el botón Iniciar Proceso.";
            this.Lbl_Msg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Tx_CB
            // 
            this.Tx_CB.Location = new System.Drawing.Point(6, 19);
            this.Tx_CB.Name = "Tx_CB";
            this.Tx_CB.Size = new System.Drawing.Size(265, 20);
            this.Tx_CB.TabIndex = 6;
            this.Tx_CB.TextChanged += new System.EventHandler(this.Tx_CB_TextChanged);
            this.Tx_CB.Validating += new System.ComponentModel.CancelEventHandler(this.Tx_CB_Validating);
            // 
            // Btn_IniciaProceso
            // 
            this.Btn_IniciaProceso.Location = new System.Drawing.Point(13, 10);
            this.Btn_IniciaProceso.Name = "Btn_IniciaProceso";
            this.Btn_IniciaProceso.Size = new System.Drawing.Size(70, 37);
            this.Btn_IniciaProceso.TabIndex = 7;
            this.Btn_IniciaProceso.Text = "Iniciar Proceso";
            this.Btn_IniciaProceso.UseVisualStyleBackColor = true;
            this.Btn_IniciaProceso.Click += new System.EventHandler(this.Btn_IniciaProceso_Click);
            // 
            // Btn_Finaliza
            // 
            this.Btn_Finaliza.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Finaliza.Location = new System.Drawing.Point(898, 10);
            this.Btn_Finaliza.Name = "Btn_Finaliza";
            this.Btn_Finaliza.Size = new System.Drawing.Size(84, 42);
            this.Btn_Finaliza.TabIndex = 8;
            this.Btn_Finaliza.Text = "Finalizar Proceso";
            this.Btn_Finaliza.UseVisualStyleBackColor = true;
            this.Btn_Finaliza.Click += new System.EventHandler(this.Btn_Finaliza_Click);
            // 
            // Tx_NroPaq
            // 
            this.Tx_NroPaq.Location = new System.Drawing.Point(26, 19);
            this.Tx_NroPaq.Name = "Tx_NroPaq";
            this.Tx_NroPaq.Size = new System.Drawing.Size(60, 20);
            this.Tx_NroPaq.TabIndex = 10;
            // 
            // gr_GuiaDespacho
            // 
            this.gr_GuiaDespacho.Controls.Add(this.Btn_OK);
            this.gr_GuiaDespacho.Controls.Add(this.Btn_CargaDatos);
            this.gr_GuiaDespacho.Controls.Add(this.Tx_GuiaDespacho);
            this.gr_GuiaDespacho.Enabled = false;
            this.gr_GuiaDespacho.Location = new System.Drawing.Point(97, 9);
            this.gr_GuiaDespacho.Name = "gr_GuiaDespacho";
            this.gr_GuiaDespacho.Size = new System.Drawing.Size(236, 50);
            this.gr_GuiaDespacho.TabIndex = 11;
            this.gr_GuiaDespacho.TabStop = false;
            this.gr_GuiaDespacho.Text = "Ingrese el Número de guía de despacho";
            // 
            // Btn_OK
            // 
            this.Btn_OK.Location = new System.Drawing.Point(169, 18);
            this.Btn_OK.Name = "Btn_OK";
            this.Btn_OK.Size = new System.Drawing.Size(29, 23);
            this.Btn_OK.TabIndex = 4;
            this.Btn_OK.Text = "Ok";
            this.Btn_OK.UseVisualStyleBackColor = true;
            this.Btn_OK.Click += new System.EventHandler(this.Btn_OK_Click);
            // 
            // gr_NroPaquetes
            // 
            this.gr_NroPaquetes.Controls.Add(this.Btn_OK1);
            this.gr_NroPaquetes.Controls.Add(this.Tx_NroPaq);
            this.gr_NroPaquetes.Enabled = false;
            this.gr_NroPaquetes.Location = new System.Drawing.Point(348, 9);
            this.gr_NroPaquetes.Name = "gr_NroPaquetes";
            this.gr_NroPaquetes.Size = new System.Drawing.Size(140, 50);
            this.gr_NroPaquetes.TabIndex = 1;
            this.gr_NroPaquetes.TabStop = false;
            this.gr_NroPaquetes.Text = "Número Paquetes";
            // 
            // Btn_OK1
            // 
            this.Btn_OK1.Location = new System.Drawing.Point(98, 17);
            this.Btn_OK1.Name = "Btn_OK1";
            this.Btn_OK1.Size = new System.Drawing.Size(29, 23);
            this.Btn_OK1.TabIndex = 11;
            this.Btn_OK1.Text = "Ok";
            this.Btn_OK1.UseVisualStyleBackColor = true;
            this.Btn_OK1.Click += new System.EventHandler(this.Btn_OK1_Click);
            // 
            // gr_CB
            // 
            this.gr_CB.Controls.Add(this.Tx_CB);
            this.gr_CB.Enabled = false;
            this.gr_CB.Location = new System.Drawing.Point(494, 9);
            this.gr_CB.Name = "gr_CB";
            this.gr_CB.Size = new System.Drawing.Size(318, 50);
            this.gr_CB.TabIndex = 1;
            this.gr_CB.TabStop = false;
            this.gr_CB.Text = "Ingrese el Código de Barras";
            // 
            // Rb_Pistoleo1
            // 
            this.Rb_Pistoleo1.AutoSize = true;
            this.Rb_Pistoleo1.Checked = true;
            this.Rb_Pistoleo1.Location = new System.Drawing.Point(825, 12);
            this.Rb_Pistoleo1.Name = "Rb_Pistoleo1";
            this.Rb_Pistoleo1.Size = new System.Drawing.Size(71, 17);
            this.Rb_Pistoleo1.TabIndex = 12;
            this.Rb_Pistoleo1.TabStop = true;
            this.Rb_Pistoleo1.Text = "Pistoleo 1";
            this.Rb_Pistoleo1.UseVisualStyleBackColor = true;
            this.Rb_Pistoleo1.CheckedChanged += new System.EventHandler(this.Rb_Pistoleo1_CheckedChanged);
            // 
            // Rb_Pistoleo2
            // 
            this.Rb_Pistoleo2.AutoSize = true;
            this.Rb_Pistoleo2.Location = new System.Drawing.Point(825, 42);
            this.Rb_Pistoleo2.Name = "Rb_Pistoleo2";
            this.Rb_Pistoleo2.Size = new System.Drawing.Size(71, 17);
            this.Rb_Pistoleo2.TabIndex = 13;
            this.Rb_Pistoleo2.Text = "Pistoleo 2";
            this.Rb_Pistoleo2.UseVisualStyleBackColor = true;
            this.Rb_Pistoleo2.CheckedChanged += new System.EventHandler(this.Rb_Pistoleo2_CheckedChanged);
            // 
            // Rb_Todos
            // 
            this.Rb_Todos.AutoSize = true;
            this.Rb_Todos.Location = new System.Drawing.Point(825, 65);
            this.Rb_Todos.Name = "Rb_Todos";
            this.Rb_Todos.Size = new System.Drawing.Size(74, 17);
            this.Rb_Todos.TabIndex = 14;
            this.Rb_Todos.Text = "Ver Todos";
            this.Rb_Todos.UseVisualStyleBackColor = true;
            this.Rb_Todos.CheckedChanged += new System.EventHandler(this.Rb_Todos_CheckedChanged);
            // 
            // mn_Trazabilidad
            // 
            this.mn_Trazabilidad.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verTrazabilidadToolStripMenuItem});
            this.mn_Trazabilidad.Name = "mn_Trazabilidad";
            this.mn_Trazabilidad.Size = new System.Drawing.Size(159, 26);
            this.mn_Trazabilidad.Text = "Ver Trazabilidad";
            this.mn_Trazabilidad.Click += new System.EventHandler(this.mn_Trazabilidad_Click);
            // 
            // verTrazabilidadToolStripMenuItem
            // 
            this.verTrazabilidadToolStripMenuItem.Image = global::Metalurgica.Properties.Resources.find;
            this.verTrazabilidadToolStripMenuItem.Name = "verTrazabilidadToolStripMenuItem";
            this.verTrazabilidadToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.verTrazabilidadToolStripMenuItem.Text = "Ver Trazabilidad";
            // 
            // Rb_ColadasPiezas
            // 
            this.Rb_ColadasPiezas.AutoSize = true;
            this.Rb_ColadasPiezas.Location = new System.Drawing.Point(825, 85);
            this.Rb_ColadasPiezas.Name = "Rb_ColadasPiezas";
            this.Rb_ColadasPiezas.Size = new System.Drawing.Size(119, 17);
            this.Rb_ColadasPiezas.TabIndex = 15;
            this.Rb_ColadasPiezas.Text = "Coladas Producidas";
            this.Rb_ColadasPiezas.UseVisualStyleBackColor = true;
            this.Rb_ColadasPiezas.CheckedChanged += new System.EventHandler(this.Rb_ColadasPiezas_CheckedChanged);
            // 
            // Frm_Consignacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 424);
            this.Controls.Add(this.Rb_ColadasPiezas);
            this.Controls.Add(this.Rb_Todos);
            this.Controls.Add(this.Rb_Pistoleo2);
            this.Controls.Add(this.Rb_Pistoleo1);
            this.Controls.Add(this.gr_CB);
            this.Controls.Add(this.gr_NroPaquetes);
            this.Controls.Add(this.gr_GuiaDespacho);
            this.Controls.Add(this.Btn_Finaliza);
            this.Controls.Add(this.Btn_IniciaProceso);
            this.Controls.Add(this.Lbl_Msg);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_Consignacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión de Consignaciones";
            this.Load += new System.EventHandler(this.Frm_Consignacion_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_MP)).EndInit();
            this.gr_GuiaDespacho.ResumeLayout(false);
            this.gr_GuiaDespacho.PerformLayout();
            this.gr_NroPaquetes.ResumeLayout(false);
            this.gr_NroPaquetes.PerformLayout();
            this.gr_CB.ResumeLayout(false);
            this.gr_CB.PerformLayout();
            this.mn_Trazabilidad.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Tx_GuiaDespacho;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView Dtg_MP;
        private System.Windows.Forms.Button Btn_CargaDatos;
        private System.Windows.Forms.Label Lbl_Msg;
        private System.Windows.Forms.TextBox Tx_CB;
        private System.Windows.Forms.Button Btn_IniciaProceso;
        private System.Windows.Forms.Button Btn_Finaliza;
        private System.Windows.Forms.TextBox Tx_NroPaq;
        private System.Windows.Forms.GroupBox gr_GuiaDespacho;
        private System.Windows.Forms.GroupBox gr_NroPaquetes;
        private System.Windows.Forms.GroupBox gr_CB;
        private System.Windows.Forms.Button Btn_OK;
        private System.Windows.Forms.Button Btn_OK1;
        private System.Windows.Forms.RadioButton Rb_Pistoleo1;
        private System.Windows.Forms.RadioButton Rb_Pistoleo2;
        private System.Windows.Forms.RadioButton Rb_Todos;
        private System.Windows.Forms.ContextMenuStrip mn_Trazabilidad;
        private System.Windows.Forms.ToolStripMenuItem verTrazabilidadToolStripMenuItem;
        private System.Windows.Forms.RadioButton Rb_ColadasPiezas;
    }
}