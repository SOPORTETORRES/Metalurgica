namespace Metalurgica
{
    partial class frmRecepcionMaterial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRecepcionMaterial));
            this.stsStatusStrip = new System.Windows.Forms.StatusStrip();
            this.tlsEstado = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlsToolBar = new System.Windows.Forms.ToolStrip();
            this.tlbSelectAll = new System.Windows.Forms.ToolStripButton();
            this.tlbUndoSelectAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tlbGuardar = new System.Windows.Forms.ToolStripButton();
            this.tlbDesactivar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tlbActualizar = new System.Windows.Forms.ToolStripButton();
            this.tlbImprimir = new System.Windows.Forms.ToolStripButton();
            this.tlbExportar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tlbSalir = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Rb_Desmarcar = new System.Windows.Forms.RadioButton();
            this.Rb_MarcarTodas = new System.Windows.Forms.RadioButton();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFechaSolicitud = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.ctlInformacionUsuario1 = new Metalurgica.ctlInformacionUsuario();
            this.stsStatusStrip.SuspendLayout();
            this.tlsToolBar.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // stsStatusStrip
            // 
            this.stsStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlsEstado});
            this.stsStatusStrip.Location = new System.Drawing.Point(0, 409);
            this.stsStatusStrip.Name = "stsStatusStrip";
            this.stsStatusStrip.Size = new System.Drawing.Size(885, 22);
            this.stsStatusStrip.TabIndex = 29;
            this.stsStatusStrip.Text = "statusStrip1";
            // 
            // tlsEstado
            // 
            this.tlsEstado.Name = "tlsEstado";
            this.tlsEstado.Size = new System.Drawing.Size(32, 17);
            this.tlsEstado.Text = "Listo";
            // 
            // tlsToolBar
            // 
            this.tlsToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlbSelectAll,
            this.tlbUndoSelectAll,
            this.toolStripSeparator4,
            this.tlbGuardar,
            this.tlbDesactivar,
            this.toolStripSeparator2,
            this.tlbActualizar,
            this.tlbImprimir,
            this.tlbExportar,
            this.toolStripSeparator1,
            this.tlbSalir});
            this.tlsToolBar.Location = new System.Drawing.Point(0, 22);
            this.tlsToolBar.Name = "tlsToolBar";
            this.tlsToolBar.Size = new System.Drawing.Size(885, 25);
            this.tlsToolBar.TabIndex = 28;
            this.tlsToolBar.Text = "toolStrip1";
            // 
            // tlbSelectAll
            // 
            this.tlbSelectAll.Image = global::Metalurgica.Properties.Resources.to_do_list_cheked_all;
            this.tlbSelectAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlbSelectAll.Name = "tlbSelectAll";
            this.tlbSelectAll.Size = new System.Drawing.Size(115, 22);
            this.tlbSelectAll.Text = "Seleccionar todo";
            this.tlbSelectAll.Click += new System.EventHandler(this.tlbSelectAll_Click);
            // 
            // tlbUndoSelectAll
            // 
            this.tlbUndoSelectAll.Image = global::Metalurgica.Properties.Resources.to_do_list;
            this.tlbUndoSelectAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlbUndoSelectAll.Name = "tlbUndoSelectAll";
            this.tlbUndoSelectAll.Size = new System.Drawing.Size(114, 22);
            this.tlbUndoSelectAll.Text = "Anular selección";
            this.tlbUndoSelectAll.Click += new System.EventHandler(this.tlbUndoSelectAll_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tlbGuardar
            // 
            this.tlbGuardar.Image = global::Metalurgica.Properties.Resources.disk;
            this.tlbGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlbGuardar.Name = "tlbGuardar";
            this.tlbGuardar.Size = new System.Drawing.Size(69, 22);
            this.tlbGuardar.Text = "Guardar";
            this.tlbGuardar.Click += new System.EventHandler(this.tlbGuardar_Click);
            // 
            // tlbDesactivar
            // 
            this.tlbDesactivar.Image = global::Metalurgica.Properties.Resources.cancel;
            this.tlbDesactivar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlbDesactivar.Name = "tlbDesactivar";
            this.tlbDesactivar.Size = new System.Drawing.Size(62, 22);
            this.tlbDesactivar.Text = "Anular";
            this.tlbDesactivar.Click += new System.EventHandler(this.tlbDesactivar_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tlbActualizar
            // 
            this.tlbActualizar.Image = global::Metalurgica.Properties.Resources.update;
            this.tlbActualizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlbActualizar.Name = "tlbActualizar";
            this.tlbActualizar.Size = new System.Drawing.Size(79, 22);
            this.tlbActualizar.Text = "Actualizar";
            this.tlbActualizar.Click += new System.EventHandler(this.tlbActualizar_Click);
            // 
            // tlbImprimir
            // 
            this.tlbImprimir.Enabled = false;
            this.tlbImprimir.Image = global::Metalurgica.Properties.Resources.printer;
            this.tlbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlbImprimir.Name = "tlbImprimir";
            this.tlbImprimir.Size = new System.Drawing.Size(73, 22);
            this.tlbImprimir.Text = "Imprimir";
            this.tlbImprimir.Visible = false;
            this.tlbImprimir.Click += new System.EventHandler(this.tlbImprimir_Click);
            // 
            // tlbExportar
            // 
            this.tlbExportar.Image = global::Metalurgica.Properties.Resources.table_excel;
            this.tlbExportar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlbExportar.Name = "tlbExportar";
            this.tlbExportar.Size = new System.Drawing.Size(70, 22);
            this.tlbExportar.Text = "Exportar";
            this.tlbExportar.Click += new System.EventHandler(this.tlbExportar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tlbSalir
            // 
            this.tlbSalir.Image = global::Metalurgica.Properties.Resources.door_out;
            this.tlbSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlbSalir.Name = "tlbSalir";
            this.tlbSalir.Size = new System.Drawing.Size(49, 22);
            this.tlbSalir.Text = "Salir";
            this.tlbSalir.Click += new System.EventHandler(this.tlbSalir_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 47);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(885, 362);
            this.tabControl1.TabIndex = 30;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.Rb_Desmarcar);
            this.tabPage1.Controls.Add(this.Rb_MarcarTodas);
            this.tabPage1.Controls.Add(this.dgvProductos);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.dtpFechaSolicitud);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(877, 336);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Recepción";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // Rb_Desmarcar
            // 
            this.Rb_Desmarcar.AutoSize = true;
            this.Rb_Desmarcar.Location = new System.Drawing.Point(118, 7);
            this.Rb_Desmarcar.Name = "Rb_Desmarcar";
            this.Rb_Desmarcar.Size = new System.Drawing.Size(109, 17);
            this.Rb_Desmarcar.TabIndex = 14;
            this.Rb_Desmarcar.TabStop = true;
            this.Rb_Desmarcar.Text = "Desmarcar Todas";
            this.Rb_Desmarcar.UseVisualStyleBackColor = true;
            this.Rb_Desmarcar.CheckedChanged += new System.EventHandler(this.Rb_Desmarcar_CheckedChanged);
            // 
            // Rb_MarcarTodas
            // 
            this.Rb_MarcarTodas.AutoSize = true;
            this.Rb_MarcarTodas.Location = new System.Drawing.Point(19, 7);
            this.Rb_MarcarTodas.Name = "Rb_MarcarTodas";
            this.Rb_MarcarTodas.Size = new System.Drawing.Size(91, 17);
            this.Rb_MarcarTodas.TabIndex = 13;
            this.Rb_MarcarTodas.TabStop = true;
            this.Rb_MarcarTodas.Text = "Marcar Todas";
            this.Rb_MarcarTodas.UseVisualStyleBackColor = true;
            this.Rb_MarcarTodas.CheckedChanged += new System.EventHandler(this.Rb_MarcarTodas_CheckedChanged);
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.AllowUserToDeleteRows = false;
            this.dgvProductos.AllowUserToResizeRows = false;
            this.dgvProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Location = new System.Drawing.Point(8, 31);
            this.dgvProductos.MultiSelect = false;
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.Size = new System.Drawing.Size(861, 280);
            this.dgvProductos.TabIndex = 10;
            this.dgvProductos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductos_CellContentClick);
            this.dgvProductos.DoubleClick += new System.EventHandler(this.dgvProductos_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 309);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(871, 24);
            this.panel1.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(427, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Nota: En caso de una recepción parcial, haga doble clic sobre el registro.";
            // 
            // dtpFechaSolicitud
            // 
            this.dtpFechaSolicitud.Location = new System.Drawing.Point(394, 5);
            this.dtpFechaSolicitud.Name = "dtpFechaSolicitud";
            this.dtpFechaSolicitud.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaSolicitud.TabIndex = 9;
            this.dtpFechaSolicitud.ValueChanged += new System.EventHandler(this.dtpFechaSolicitud_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(275, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Solicitudes del día";
            // 
            // ctlInformacionUsuario1
            // 
            this.ctlInformacionUsuario1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctlInformacionUsuario1.Location = new System.Drawing.Point(0, 0);
            this.ctlInformacionUsuario1.Name = "ctlInformacionUsuario1";
            this.ctlInformacionUsuario1.Size = new System.Drawing.Size(885, 22);
            this.ctlInformacionUsuario1.TabIndex = 27;
            // 
            // frmRecepcionMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 431);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.stsStatusStrip);
            this.Controls.Add(this.tlsToolBar);
            this.Controls.Add(this.ctlInformacionUsuario1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRecepcionMaterial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recepción de Materias Primas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRecepcionMaterial_Load);
            this.stsStatusStrip.ResumeLayout(false);
            this.stsStatusStrip.PerformLayout();
            this.tlsToolBar.ResumeLayout(false);
            this.tlsToolBar.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip stsStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel tlsEstado;
        private System.Windows.Forms.ToolStrip tlsToolBar;
        private System.Windows.Forms.ToolStripButton tlbGuardar;
        private System.Windows.Forms.ToolStripButton tlbDesactivar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tlbActualizar;
        private System.Windows.Forms.ToolStripButton tlbImprimir;
        private System.Windows.Forms.ToolStripButton tlbExportar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tlbSalir;
        private ctlInformacionUsuario ctlInformacionUsuario1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.DateTimePicker dtpFechaSolicitud;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ToolStripButton tlbSelectAll;
        private System.Windows.Forms.ToolStripButton tlbUndoSelectAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton Rb_Desmarcar;
        private System.Windows.Forms.RadioButton Rb_MarcarTodas;
    }
}