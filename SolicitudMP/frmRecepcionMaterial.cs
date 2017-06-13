using System;
using System.Windows.Forms;
using CommonLibrary2;
using System.Drawing;

namespace Metalurgica
{
    public partial class frmRecepcionMaterial : Form
    {
        private const string COLUMNNAME_MARCA = "MARCA";
        private const string COLUMNNAME_ID = "ID";
        private const string COLUMNNAME_PRODUCTO = "PRODUCTO";
        private const string COLUMNNAME_PRODUCTO_DESCRIPCION = "DESC_PRODUCTO";
        private const string COLUMNNAME_DIAMETRO = "DIAMETRO";
        private const string COLUMNNAME_LARGO = "LARGO";
        private const string COLUMNNAME_ORIGEN = "ORIGEN";
        private const string COLUMNNAME_ORIGEN_DESCRIPCION = "DESC_ORIGEN";
        private const string COLUMNNAME_TIPO = "TIPO";
        private const string COLUMNNAME_CANTIDAD = "BARRAS_SOL";
        private const string COLUMNNAME_CANTIDAD_RECEP = "BARRAS_RECEP";
        private const string COLUMNNAME_OBS_RECEP = "OBS_RECEP";
        private Forms forms = new Forms();
        private CurrentUser mUserLog = new CurrentUser();

        public frmRecepcionMaterial()
        {
            InitializeComponent();
            this.dgvProductos.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(dgvProductos_RowPostPaint);
        }

        private void dgvProductos_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvProductos.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void tlbSelectAll_Click(object sender, EventArgs e)
        {
            //dgvProductos.CancelEdit();
            dtpFechaSolicitud.Focus();
            forms.dataGridViewRowsChecked(dgvProductos, COLUMNNAME_MARCA, true);
        }

        private void tlbUndoSelectAll_Click(object sender, EventArgs e)
        {
            //dgvProductos.CancelEdit();
            dtpFechaSolicitud.Focus();
            forms.dataGridViewRowsChecked(dgvProductos, COLUMNNAME_MARCA, false);
        }

        private void tlbGuardar_Click(object sender, EventArgs e)
        {
            int counter = 0; string lTipoMat = ""; Clases.ClsComun lCom = new Clases.ClsComun();
            string lTmp = "";

            dtpFechaSolicitud.Focus();
            counter = forms.dataGridViewCountRowsChecked(dgvProductos, COLUMNNAME_MARCA);
            if (counter > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
                    WsOperacion.Solicitud_Material_Detalle solicitud_Material_Detalle = new WsOperacion.Solicitud_Material_Detalle();

                    foreach (DataGridViewRow row in dgvProductos.Rows)
                    {
                        if (row.Cells[COLUMNNAME_MARCA].Value != null)
                        {
                            if ((bool)row.Cells[COLUMNNAME_MARCA].Value == true)
                            {
                                // Debemos revisar el producto y si es un rollo se debe exigir los kilos de la Etiqueta
                                // a partir del producto obtenemos el Tipo, si es R (se debe exigir los kilos de la Etiqueta)
                                lTipoMat = lCom.ObtenerTipoPorProducto(row.Cells[COLUMNNAME_PRODUCTO].Value.ToString());
                                if (lTipoMat == "R")
                                {
                                    lTmp = RegistraKilosEtiquetaRollos(row);
                                }
                                else
                                    lTmp = (row.Cells["Kilos_Recep"].Value.ToString());


                                if (lCom.EsNumero (lTmp) == true)
                                {
                                    solicitud_Material_Detalle.Id = Convert.ToInt32(row.Cells[COLUMNNAME_ID].Value.ToString());
                                    solicitud_Material_Detalle.Producto = row.Cells[COLUMNNAME_PRODUCTO].Value.ToString();
                                    solicitud_Material_Detalle.Usuario_Recep = Program.currentUser.Login;
                                    solicitud_Material_Detalle.Kilos_Recepcionados = int.Parse (lTmp);
                                    //solicitud_Material_Detalle.Fecha_Recep = "";
                                    solicitud_Material_Detalle.Cantidad = Convert.ToInt32(row.Cells[COLUMNNAME_CANTIDAD].Value.ToString());
                                    solicitud_Material_Detalle.Cantidad_Recep = (String.IsNullOrEmpty(row.Cells[COLUMNNAME_CANTIDAD_RECEP].Value.ToString()) ? solicitud_Material_Detalle.Cantidad : Convert.ToInt32(row.Cells[COLUMNNAME_CANTIDAD_RECEP].Value.ToString()));
                                    solicitud_Material_Detalle.Obs_Recep = row.Cells[COLUMNNAME_OBS_RECEP].Value.ToString();

                                    solicitud_Material_Detalle = wsOperacion.GuardarRecepcionMaterial(solicitud_Material_Detalle, Program.currentUser.Login, Program.currentUser.ComputerName, Program.currentUser.IdTotem);
                                    if (solicitud_Material_Detalle.MensajeError.Equals(""))
                                        row.Cells[0].Value = false;
                                    else
                                        MessageBox.Show(solicitud_Material_Detalle.MensajeError.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                    MessageBox.Show("NO se puede completar la Operación, NO se ingresarón los kilos del Rollo a Recepcionar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                                
                            }
                        }
                    }
                    //tlbNuevo_Click(sender, e);
                    tlbActualizar.PerformClick();
                    MessageBox.Show("Proceso finalizado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Cursor.Current = Cursors.Default;
            }
            else
                MessageBox.Show("No existen registros seleccionados.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private string RegistraKilosEtiquetaRollos(DataGridViewRow iFila)
        {
            string lres = ""; string lKilosRollo = "";
         
            if (iFila != null)
            {
                frmRecepcionMaterialParcial frm = new frmRecepcionMaterialParcial();
                frm.Text = "Ingreso de Kilos para Rollos ";
                frm.producto = iFila.Cells[COLUMNNAME_PRODUCTO_DESCRIPCION].Value.ToString();
                frm.diametro = iFila.Cells[COLUMNNAME_DIAMETRO].Value.ToString();
                frm.largo = iFila.Cells[COLUMNNAME_LARGO].Value.ToString();
                frm.origen = iFila.Cells[COLUMNNAME_ORIGEN_DESCRIPCION].Value.ToString();
                frm.tipo = iFila.Cells[COLUMNNAME_TIPO].Value.ToString();
                frm.cantidad = iFila.Cells[COLUMNNAME_CANTIDAD].Value.ToString();
                frm.cantidad_parcial = (String.IsNullOrEmpty(iFila.Cells[COLUMNNAME_CANTIDAD_RECEP].Value.ToString()) ? Convert.ToInt32(iFila.Cells[COLUMNNAME_CANTIDAD].Value.ToString()) : Convert.ToInt32(iFila.Cells[COLUMNNAME_CANTIDAD_RECEP].Value.ToString()));
                frm.obs = iFila.Cells[COLUMNNAME_OBS_RECEP].Value.ToString();
                frm.Mensaje = "Ingrese los Kilos que aparecen el la Etiqueta del Rollo";
                frm.Kilos = iFila.Cells["KILOS"].Value.ToString();

                
                frm.ShowDialog(this);
                if (frm.ok)
                {
                    //iFila.Cells[COLUMNNAME_CANTIDAD_RECEP].Value = frm.cantidad_parcial.ToString();
                    //iFila.Cells[COLUMNNAME_OBS_RECEP].Value = frm.obs;
                    lKilosRollo = frm.KilosEtiquetaRollo;
                }
                frm.Dispose();
            }



            return lKilosRollo;

        }



        private void tlbDesactivar_Click(object sender, EventArgs e)
        {
            bool nuevaSolicitud = false;int lIdDetalleSM = 0; string lRes = "";
            DataGridViewRow currentRow = dgvProductos.CurrentRow;
            if (currentRow != null)
            {
                try
                {
                    if (Convert.ToInt32(currentRow.Cells["CANTIDAD_PROD"].Value.ToString()) == 0)
                    {
                        if (MessageBox.Show("¿Esta seguro que desea anular este registro?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                        {
                            Cursor.Current = Cursors.WaitCursor;

                            WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
                            WsOperacion.Solicitud_Material_Detalle solicitud_Material_Detalle = new WsOperacion.Solicitud_Material_Detalle();
                            WsOperacion.Solicitud_Material_Detalle result = new WsOperacion.Solicitud_Material_Detalle();

                            solicitud_Material_Detalle.Id = Convert.ToInt32(currentRow.Cells[COLUMNNAME_ID].Value.ToString());
                            solicitud_Material_Detalle.Producto = currentRow.Cells[COLUMNNAME_PRODUCTO].Value.ToString();
                            solicitud_Material_Detalle.Usuario_Recep = Program.currentUser.Login;
                            //solicitud_Material_Detalle.Fecha_Recep = "";
                            solicitud_Material_Detalle.Cantidad = Convert.ToInt32(currentRow.Cells[COLUMNNAME_CANTIDAD].Value.ToString());

                            lIdDetalleSM = new Clases.ClsComun().Val(currentRow.Cells["DET_ID"].Value.ToString());
                            lRes = wsOperacion.AnularDetalleSolicitudMateriaPrima(lIdDetalleSM);

                            // result = wsOperacion.AnularRecepcionMaterial(solicitud_Material_Detalle, Program.currentUser.Login, Program.currentUser.ComputerName, Program.currentUser.IdTotem);
                            // if (result.MensajeError.Equals(""))
                            if (lRes.Equals(""))
                            {
                                if (MessageBox.Show("¿Desea crear una nueva solicitud para este producto?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                                {
                                    nuevaSolicitud = true;
                                    //producto
                                    //diamtro
                                    //largo
                                    //origen
                                    //tipo
                                    //cantidad
                                    solicitud_Material_Detalle.Diametro = currentRow.Cells[COLUMNNAME_DIAMETRO].Value.ToString();
                                    solicitud_Material_Detalle.Largo = currentRow.Cells[COLUMNNAME_LARGO].Value.ToString();
                                    solicitud_Material_Detalle.Origen = currentRow.Cells[COLUMNNAME_ORIGEN].Value.ToString();
                                    crearNuevaSolicitud(solicitud_Material_Detalle);
                                }
                            }
                            else
                                MessageBox.Show(solicitud_Material_Detalle.MensajeError.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                            //tlbNuevo_Click(sender, e);
                            tlbActualizar.PerformClick();
                            if (!nuevaSolicitud)
                                MessageBox.Show("Anulacion realizada.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                    else
                    {
                        MessageBox.Show("NO Puede Anular el Producto seleccionado, ya que tiene Kilos Producidos", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                 }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Cursor.Current = Cursors.Default;
            }            
        }
                    
        private void crearNuevaSolicitud(WsOperacion .Solicitud_Material_Detalle   solicitud_Material_Detalle)
        {
            try
            {
                WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
                WsOperacion.Solicitud_Material solicitud_Material = new WsOperacion.Solicitud_Material();

                solicitud_Material.Id = 0;
                solicitud_Material.Usuario = Program.currentUser.Login;

                solicitud_Material = wsOperacion.GuardarSolicitudMaterial(solicitud_Material, Program.currentUser.ComputerName, Program.currentUser.IdTotem);
                if (solicitud_Material.MensajeError.Equals(""))
                {
                    solicitud_Material_Detalle.Id = solicitud_Material.Id;
                    solicitud_Material_Detalle = wsOperacion.AsociarProductosaSolicitud(solicitud_Material_Detalle, Program.currentUser.Login, Program.currentUser.ComputerName, Program.currentUser.IdTotem);
                    if (!solicitud_Material_Detalle.MensajeError.Equals(""))
                        MessageBox.Show(solicitud_Material.MensajeError.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show(solicitud_Material.MensajeError.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BloquearColumnas(DataGridView dgv)
        {
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                if (column.Index > 0)
                    column.ReadOnly = true;
            }
        }

        private void ActualizaColumnasRecep(DataGridView dgv)
        {
            int i = 0;
            for (i= 0; i < dgv.RowCount;i++)
            {

                if (dgv.Rows[i].Cells["BARRAS_RECEP"].Value.ToString().Equals("0"))
                {
                    dgv.Rows[i].Cells["BARRAS_RECEP"].Value = dgv.Rows[i].Cells["BARRAS_SOL"].Value;
                    dgv.Rows[i].Cells["KILOS_RECEP"].Value = dgv.Rows[i].Cells["KILOS_SOL"].Value;
                }
            }
        }


        private void tlbActualizar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                //tlbNuevo_Click(sender, e);
                WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
                WsOperacion.ListaDataSet listaDataSet = new WsOperacion.ListaDataSet();

                listaDataSet = wsOperacion.ListarSolicitudMaterial_Recepcion(dtpFechaSolicitud.Value, Program.currentUser.IdTotem);
                if (listaDataSet.MensajeError.Equals(""))
                {
                    dgvProductos.DataSource = listaDataSet.DataSet.Tables[0];
                    if (!forms.dataGridViewExistsColumn(dgvProductos, COLUMNNAME_MARCA))
                    {
                        DataGridViewCheckBoxColumn check = new DataGridViewCheckBoxColumn();
                        check.Name = COLUMNNAME_MARCA;
                        dgvProductos.Columns.Insert(0, check);
                    }
                    BloquearColumnas(dgvProductos);
                  
                    //tlbNuevo.PerformClick();
                    //tlbNuevo_Click(sender, e);
                    //ID, USUARIO, FECHA, TOTEM, COMPLETA, SOL_ID, PRODUCTO, DIAMETRO, LARGO, ORIGEN, TIPO CANTIDAD, USUARIO_RECEP, FECHA_RECEP, CANTIDAD_RECEP, OBS_RECEP, USUARIO_CIERRE, FECHA_CIERRE, INET_MSG, INET_FECHA
                    forms.dataGridViewHideColumns(dgvProductos, new string[] { "ID", "USUARIO", "FECHA", "TOTEM", "COMPLETA", "USUARIO_RECEP", "FECHA_RECEP", "USUARIO_CIERRE", "FECHA_CIERRE", "INET_MSG", "INET_FECHA" });
                    forms.dataGridViewAutoSizeColumnsMode(dgvProductos, DataGridViewAutoSizeColumnsMode.DisplayedCells);
                    tlsEstado.Text = "Registro(s): " + dgvProductos.Rows.Count;
                    ActualizaColumnasRecep(dgvProductos);
                }
                else
                    MessageBox.Show(listaDataSet.MensajeError.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Default;            
        }

        private void tlbImprimir_Click(object sender, EventArgs e)
        {

        }

        private void tlbExportar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.Rows.Count > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                new Excel().exportar(dgvProductos);
                Cursor.Current = Cursors.Default;
            }
            else
                MessageBox.Show("No existen registros a exportar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tlbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtpFechaSolicitud_ValueChanged(object sender, EventArgs e)
        {
            tlbActualizar.PerformClick();
        }

        private void frmRecepcionMaterial_Load(object sender, EventArgs e)
        {
            tlbActualizar.PerformClick();
        }

        private void dgvProductos_DoubleClick(object sender, EventArgs e)
        {
            DataGridViewRow currentRow = dgvProductos.CurrentRow;
            if (currentRow != null)
            {
                try
                {
                    frmRecepcionMaterialParcial frm = new frmRecepcionMaterialParcial();
                    frm.producto = currentRow.Cells[COLUMNNAME_PRODUCTO_DESCRIPCION].Value.ToString();
                    frm.diametro = currentRow.Cells[COLUMNNAME_DIAMETRO].Value.ToString();
                    frm.largo = currentRow.Cells[COLUMNNAME_LARGO].Value.ToString();
                    frm.origen = currentRow.Cells[COLUMNNAME_ORIGEN_DESCRIPCION].Value.ToString();
                    frm.tipo = currentRow.Cells[COLUMNNAME_TIPO].Value.ToString();
                    frm.cantidad = currentRow.Cells[COLUMNNAME_CANTIDAD].Value.ToString();
                    frm.cantidad_parcial = (String.IsNullOrEmpty(currentRow.Cells[COLUMNNAME_CANTIDAD_RECEP].Value.ToString()) ? Convert.ToInt32(currentRow.Cells[COLUMNNAME_CANTIDAD].Value.ToString()) : Convert.ToInt32(currentRow.Cells[COLUMNNAME_CANTIDAD_RECEP].Value.ToString()));
                    frm.obs = currentRow.Cells[COLUMNNAME_OBS_RECEP].Value.ToString();
                    frm.ShowDialog(this);
                    if (frm.ok)
                    {
                        currentRow.Cells[COLUMNNAME_CANTIDAD_RECEP].Value = frm.cantidad_parcial.ToString();
                        currentRow.Cells[COLUMNNAME_OBS_RECEP].Value = frm.obs;
                    }
                    frm.Dispose();
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Rb_MarcarTodas_CheckedChanged(object sender, EventArgs e)
        {
            Marca_DesmarcaTodas(true);
        }

        private void Marca_DesmarcaTodas(Boolean iValor)
        {
            int i = 0;
           

                for (i = 0; i < dgvProductos.RowCount; i++)
                {
                    dgvProductos.Rows[i].Cells["Marca"].Value = iValor;

                }
            
        
        }

        public void IniciaForm(CurrentUser iUserLog)
        {
            mUserLog = iUserLog;
            ctlInformacionUsuario1.CargaDatosUserLog(iUserLog);
        }

        private void Rb_Desmarcar_CheckedChanged(object sender, EventArgs e)
        {
            Marca_DesmarcaTodas(false);
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}