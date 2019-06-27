namespace Metalurgica
{
    partial class frmCierreMaterial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCierreMaterial));
            this.stsStatusStrip = new System.Windows.Forms.StatusStrip();
            this.tlsEstado = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlsToolBar = new System.Windows.Forms.ToolStrip();
            this.tlbSelectAll = new System.Windows.Forms.ToolStripButton();
            this.tlbUndoSelectAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tlbGuardar = new System.Windows.Forms.ToolStripButton();
            this.tlbReprocesar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tlbActualizar = new System.Windows.Forms.ToolStripButton();
            this.tlbExportar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tlbSalir = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Rb_Desmarcar = new System.Windows.Forms.RadioButton();
            this.Rb_MarcarTodas = new System.Windows.Forms.RadioButton();
            this.lblAccion = new System.Windows.Forms.Label();
            this.cboAccion = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblNota = new System.Windows.Forms.Label();
            this.cboCriterio = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.dtpFechaRecepcion = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.ctlInformacionUsuario1 = new Metalurgica.ctlInformacionUsuario();
            this.stsStatusStrip.SuspendLayout();
            this.tlsToolBar.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // stsStatusStrip
            // 
            this.stsStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlsEstado});
            this.stsStatusStrip.Location = new System.Drawing.Point(0, 519);
            this.stsStatusStrip.Name = "stsStatusStrip";
            this.stsStatusStrip.Size = new System.Drawing.Size(1088, 22);
            this.stsStatusStrip.TabIndex = 32;
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
            this.toolStripSeparator3,
            this.tlbGuardar,
            this.tlbReprocesar,
            this.toolStripSeparator2,
            this.tlbActualizar,
            this.tlbExportar,
            this.toolStripSeparator1,
            this.tlbSalir});
            this.tlsToolBar.Location = new System.Drawing.Point(0, 22);
            this.tlsToolBar.Name = "tlsToolBar";
            this.tlsToolBar.Size = new System.Drawing.Size(1088, 25);
            this.tlsToolBar.TabIndex = 31;
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
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
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
            // tlbReprocesar
            // 
            this.tlbReprocesar.Enabled = false;
            this.tlbReprocesar.Image = global::Metalurgica.Properties.Resources.accept;
            this.tlbReprocesar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlbReprocesar.Name = "tlbReprocesar";
            this.tlbReprocesar.Size = new System.Drawing.Size(85, 22);
            this.tlbReprocesar.Text = "Reprocesar";
            this.tlbReprocesar.Click += new System.EventHandler(this.tlbReprocesar_Click);
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
            this.tabControl1.Size = new System.Drawing.Size(1088, 472);
            this.tabControl1.TabIndex = 33;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.Rb_Desmarcar);
            this.tabPage1.Controls.Add(this.Rb_MarcarTodas);
            this.tabPage1.Controls.Add(this.lblAccion);
            this.tabPage1.Controls.Add(this.cboAccion);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.cboCriterio);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.dgvProductos);
            this.tabPage1.Controls.Add(this.dtpFechaRecepcion);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1080, 446);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Recepción";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // Rb_Desmarcar
            // 
            this.Rb_Desmarcar.AutoSize = true;
            this.Rb_Desmarcar.Location = new System.Drawing.Point(107, 9);
            this.Rb_Desmarcar.Name = "Rb_Desmarcar";
            this.Rb_Desmarcar.Size = new System.Drawing.Size(109, 17);
            this.Rb_Desmarcar.TabIndex = 19;
            this.Rb_Desmarcar.TabStop = true;
            this.Rb_Desmarcar.Text = "Desmarcar Todas";
            this.Rb_Desmarcar.UseVisualStyleBackColor = true;
            // 
            // Rb_MarcarTodas
            // 
            this.Rb_MarcarTodas.AutoSize = true;
            this.Rb_MarcarTodas.Location = new System.Drawing.Point(8, 9);
            this.Rb_MarcarTodas.Name = "Rb_MarcarTodas";
            this.Rb_MarcarTodas.Size = new System.Drawing.Size(91, 17);
            this.Rb_MarcarTodas.TabIndex = 18;
            this.Rb_MarcarTodas.TabStop = true;
            this.Rb_MarcarTodas.Text = "Marcar Todas";
            this.Rb_MarcarTodas.UseVisualStyleBackColor = true;
            this.Rb_MarcarTodas.CheckedChanged += new System.EventHandler(this.Rb_MarcarTodas_CheckedChanged);
            // 
            // lblAccion
            // 
            this.lblAccion.AutoSize = true;
            this.lblAccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccion.Location = new System.Drawing.Point(792, 11);
            this.lblAccion.Name = "lblAccion";
            this.lblAccion.Size = new System.Drawing.Size(109, 13);
            this.lblAccion.TabIndex = 17;
            this.lblAccion.Text = "Acción doble clic:";
            // 
            // cboAccion
            // 
            this.cboAccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAccion.FormattingEnabled = true;
            this.cboAccion.Items.AddRange(new object[] {
            "Ver trazabilidad del producto",
            "Modificar el registro"});
            this.cboAccion.Location = new System.Drawing.Point(907, 5);
            this.cboAccion.Name = "cboAccion";
            this.cboAccion.Size = new System.Drawing.Size(164, 21);
            this.cboAccion.TabIndex = 16;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblNota);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 420);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1074, 23);
            this.panel1.TabIndex = 15;
            // 
            // lblNota
            // 
            this.lblNota.AutoSize = true;
            this.lblNota.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNota.Location = new System.Drawing.Point(9, 0);
            this.lblNota.Name = "lblNota";
            this.lblNota.Size = new System.Drawing.Size(461, 13);
            this.lblNota.TabIndex = 13;
            this.lblNota.Text = "Nota: Para ver la trazabilidad de un producto, haga doble clic sobre el  registro" +
    ".";
            // 
            // cboCriterio
            // 
            this.cboCriterio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCriterio.FormattingEnabled = true;
            this.cboCriterio.Items.AddRange(new object[] {
            "T - Todos los registros",
            "S - Con problemas en el cierre",
            "N - No informados"});
            this.cboCriterio.Location = new System.Drawing.Point(622, 5);
            this.cboCriterio.Name = "cboCriterio";
            this.cboCriterio.Size = new System.Drawing.Size(167, 21);
            this.cboCriterio.TabIndex = 14;
            this.cboCriterio.SelectedIndexChanged += new System.EventHandler(this.cboCriterio_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(564, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Criterio:";
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.AllowUserToDeleteRows = false;
            this.dgvProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Location = new System.Drawing.Point(8, 31);
            this.dgvProductos.MultiSelect = false;
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.Size = new System.Drawing.Size(1064, 383);
            this.dgvProductos.TabIndex = 10;
            this.dgvProductos.DoubleClick += new System.EventHandler(this.dgvProductos_DoubleClick);
            // 
            // dtpFechaRecepcion
            // 
            this.dtpFechaRecepcion.Location = new System.Drawing.Point(356, 5);
            this.dtpFechaRecepcion.Name = "dtpFechaRecepcion";
            this.dtpFechaRecepcion.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaRecepcion.TabIndex = 9;
            this.dtpFechaRecepcion.ValueChanged += new System.EventHandler(this.dtpFechaRecepcion_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(227, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(125, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Recepciones del día";
            // 
            // ctlInformacionUsuario1
            // 
            this.ctlInformacionUsuario1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctlInformacionUsuario1.Location = new System.Drawing.Point(0, 0);
            this.ctlInformacionUsuario1.Name = "ctlInformacionUsuario1";
            this.ctlInformacionUsuario1.Size = new System.Drawing.Size(1088, 22);
            this.ctlInformacionUsuario1.TabIndex = 30;
            // 
            // frmCierreMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 541);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.stsStatusStrip);
            this.Controls.Add(this.tlsToolBar);
            this.Controls.Add(this.ctlInformacionUsuario1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCierreMaterial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cierre";
            this.Load += new System.EventHandler(this.frmCierreMaterial_Load);
            this.stsStatusStrip.ResumeLayout(false);
            this.stsStatusStrip.PerformLayout();
            this.tlsToolBar.ResumeLayout(false);
            this.tlsToolBar.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip stsStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel tlsEstado;
        private System.Windows.Forms.ToolStrip tlsToolBar;
        private System.Windows.Forms.ToolStripButton tlbGuardar;
        private System.Windows.Forms.ToolStripButton tlbReprocesar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tlbActualizar;
        private System.Windows.Forms.ToolStripButton tlbExportar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tlbSalir;
        private ctlInformacionUsuario ctlInformacionUsuario1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.DateTimePicker dtpFechaRecepcion;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboCriterio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblNota;
        private System.Windows.Forms.ToolStripButton tlbSelectAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tlbUndoSelectAll;
        private System.Windows.Forms.Label lblAccion;
        private System.Windows.Forms.ComboBox cboAccion;
        private System.Windows.Forms.RadioButton Rb_Desmarcar;
        private System.Windows.Forms.RadioButton Rb_MarcarTodas;
    }
}