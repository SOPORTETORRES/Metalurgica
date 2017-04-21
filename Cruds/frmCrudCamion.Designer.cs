namespace Metalurgica
{
    partial class frmCrudCamion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCrudCamion));
            this.tlsToolBar = new System.Windows.Forms.ToolStrip();
            this.tlbNuevo = new System.Windows.Forms.ToolStripButton();
            this.tlbGuardar = new System.Windows.Forms.ToolStripButton();
            this.tlbEliminar = new System.Windows.Forms.ToolStripButton();
            this.tlbDesactivar = new System.Windows.Forms.ToolStripButton();
            this.tlbActualizar = new System.Windows.Forms.ToolStripButton();
            this.tlbImprimir = new System.Windows.Forms.ToolStripButton();
            this.tlbExportar = new System.Windows.Forms.ToolStripButton();
            this.tlbSalir = new System.Windows.Forms.ToolStripButton();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.stsStatusStrip = new System.Windows.Forms.StatusStrip();
            this.tlbEstado = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlControles = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtObs = new System.Windows.Forms.TextBox();
            this.txtTransportista = new System.Windows.Forms.TextBox();
            this.txtPatente = new System.Windows.Forms.TextBox();
            this.chkActivo = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlResultados = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.tlsToolBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.stsStatusStrip.SuspendLayout();
            this.pnlControles.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pnlResultados.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlsToolBar
            // 
            this.tlsToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlbNuevo,
            this.tlbGuardar,
            this.tlbEliminar,
            this.tlbDesactivar,
            this.tlbActualizar,
            this.tlbImprimir,
            this.tlbExportar,
            this.tlbSalir});
            this.tlsToolBar.Location = new System.Drawing.Point(0, 0);
            this.tlsToolBar.Name = "tlsToolBar";
            this.tlsToolBar.Size = new System.Drawing.Size(697, 25);
            this.tlsToolBar.TabIndex = 24;
            this.tlsToolBar.Text = "toolStrip1";
            // 
            // tlbNuevo
            // 
            this.tlbNuevo.Image = global::Metalurgica.Properties.Resources.add;
            this.tlbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlbNuevo.Name = "tlbNuevo";
            this.tlbNuevo.Size = new System.Drawing.Size(62, 22);
            this.tlbNuevo.Text = "Nuevo";
            this.tlbNuevo.Click += new System.EventHandler(this.tlbNuevo_Click);
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
            // tlbEliminar
            // 
            this.tlbEliminar.Enabled = false;
            this.tlbEliminar.Image = global::Metalurgica.Properties.Resources.delete;
            this.tlbEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlbEliminar.Name = "tlbEliminar";
            this.tlbEliminar.Size = new System.Drawing.Size(70, 22);
            this.tlbEliminar.Text = "Eliminar";
            this.tlbEliminar.Click += new System.EventHandler(this.tlbEliminar_Click);
            // 
            // tlbDesactivar
            // 
            this.tlbDesactivar.Enabled = false;
            this.tlbDesactivar.Image = global::Metalurgica.Properties.Resources.cancel;
            this.tlbDesactivar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlbDesactivar.Name = "tlbDesactivar";
            this.tlbDesactivar.Size = new System.Drawing.Size(81, 22);
            this.tlbDesactivar.Text = "Desactivar";
            this.tlbDesactivar.Click += new System.EventHandler(this.tlbDesactivar_Click);
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
            // tlbSalir
            // 
            this.tlbSalir.Image = global::Metalurgica.Properties.Resources.door_out;
            this.tlbSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlbSalir.Name = "tlbSalir";
            this.tlbSalir.Size = new System.Drawing.Size(49, 22);
            this.tlbSalir.Text = "Salir";
            this.tlbSalir.Click += new System.EventHandler(this.tlbSalir_Click);
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetalle.Location = new System.Drawing.Point(0, 0);
            this.dgvDetalle.MultiSelect = false;
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.ReadOnly = true;
            this.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalle.Size = new System.Drawing.Size(697, 213);
            this.dgvDetalle.TabIndex = 25;
            this.dgvDetalle.DoubleClick += new System.EventHandler(this.dgvDetalle_DoubleClick);
            // 
            // stsStatusStrip
            // 
            this.stsStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlbEstado});
            this.stsStatusStrip.Location = new System.Drawing.Point(0, 396);
            this.stsStatusStrip.Name = "stsStatusStrip";
            this.stsStatusStrip.Size = new System.Drawing.Size(697, 22);
            this.stsStatusStrip.TabIndex = 26;
            this.stsStatusStrip.Text = "statusStrip1";
            // 
            // tlbEstado
            // 
            this.tlbEstado.Name = "tlbEstado";
            this.tlbEstado.Size = new System.Drawing.Size(32, 17);
            this.tlbEstado.Text = "Listo";
            // 
            // pnlControles
            // 
            this.pnlControles.Controls.Add(this.groupBox1);
            this.pnlControles.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlControles.Location = new System.Drawing.Point(0, 25);
            this.pnlControles.Name = "pnlControles";
            this.pnlControles.Size = new System.Drawing.Size(697, 158);
            this.pnlControles.TabIndex = 27;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtObs);
            this.groupBox1.Controls.Add(this.txtTransportista);
            this.groupBox1.Controls.Add(this.txtPatente);
            this.groupBox1.Controls.Add(this.chkActivo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(11, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(674, 137);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Camión";
            // 
            // txtObs
            // 
            this.txtObs.Location = new System.Drawing.Point(105, 73);
            this.txtObs.MaxLength = 255;
            this.txtObs.Multiline = true;
            this.txtObs.Name = "txtObs";
            this.txtObs.Size = new System.Drawing.Size(555, 45);
            this.txtObs.TabIndex = 6;
            this.txtObs.Leave += new System.EventHandler(this.txtObs_Leave);
            // 
            // txtTransportista
            // 
            this.txtTransportista.Location = new System.Drawing.Point(105, 46);
            this.txtTransportista.MaxLength = 100;
            this.txtTransportista.Name = "txtTransportista";
            this.txtTransportista.Size = new System.Drawing.Size(327, 20);
            this.txtTransportista.TabIndex = 5;
            this.txtTransportista.Leave += new System.EventHandler(this.txtTransportista_Leave);
            // 
            // txtPatente
            // 
            this.txtPatente.Location = new System.Drawing.Point(105, 19);
            this.txtPatente.MaxLength = 6;
            this.txtPatente.Name = "txtPatente";
            this.txtPatente.Size = new System.Drawing.Size(100, 20);
            this.txtPatente.TabIndex = 4;
            this.txtPatente.Leave += new System.EventHandler(this.txtPatente_Leave);
            // 
            // chkActivo
            // 
            this.chkActivo.AutoSize = true;
            this.chkActivo.Location = new System.Drawing.Point(25, 101);
            this.chkActivo.Name = "chkActivo";
            this.chkActivo.Size = new System.Drawing.Size(56, 17);
            this.chkActivo.TabIndex = 3;
            this.chkActivo.Text = "Activo";
            this.chkActivo.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Observación:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Transportista:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Patente:";
            // 
            // pnlResultados
            // 
            this.pnlResultados.Controls.Add(this.dgvDetalle);
            this.pnlResultados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlResultados.Location = new System.Drawing.Point(0, 183);
            this.pnlResultados.Name = "pnlResultados";
            this.pnlResultados.Size = new System.Drawing.Size(697, 213);
            this.pnlResultados.TabIndex = 28;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(212, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(447, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Debe ingresar solo letras y números sin espacios ni guiones";
            // 
            // frmCrudCamion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 418);
            this.Controls.Add(this.pnlResultados);
            this.Controls.Add(this.pnlControles);
            this.Controls.Add(this.stsStatusStrip);
            this.Controls.Add(this.tlsToolBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmCrudCamion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Camión";
            this.Shown += new System.EventHandler(this.frmCrudCamion_Shown);
            this.tlsToolBar.ResumeLayout(false);
            this.tlsToolBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.stsStatusStrip.ResumeLayout(false);
            this.stsStatusStrip.PerformLayout();
            this.pnlControles.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlResultados.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tlsToolBar;
        private System.Windows.Forms.ToolStripButton tlbNuevo;
        private System.Windows.Forms.ToolStripButton tlbGuardar;
        private System.Windows.Forms.ToolStripButton tlbEliminar;
        private System.Windows.Forms.ToolStripButton tlbDesactivar;
        private System.Windows.Forms.ToolStripButton tlbActualizar;
        private System.Windows.Forms.ToolStripButton tlbImprimir;
        private System.Windows.Forms.ToolStripButton tlbExportar;
        private System.Windows.Forms.ToolStripButton tlbSalir;
        private ctlInformacionUsuario ctlInformacionUsuario1;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.StatusStrip stsStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel tlbEstado;
        private System.Windows.Forms.Panel pnlControles;
        private System.Windows.Forms.Panel pnlResultados;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkActivo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtObs;
        private System.Windows.Forms.TextBox txtTransportista;
        private System.Windows.Forms.TextBox txtPatente;
        private System.Windows.Forms.Label label4;
    }
}