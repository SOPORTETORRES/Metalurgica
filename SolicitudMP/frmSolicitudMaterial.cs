using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CommonLibrary2;
using System.Data;

namespace Metalurgica
{
    public partial class frmSolicitudMaterial : Form
    {
        private const string COLUMNNAME_PRODUCTO = "PRODUCTO";
        private const string COLUMNNAME_PRODUCTO_DESCRIPCION = "DESC_PRODUCTO";
        private const string COLUMNNAME_DIAMETRO = "DIAMETRO";
        private const string COLUMNNAME_LARGO = "LARGO";
        private const string COLUMNNAME_ORIGEN = "ORIGEN";
        private const string COLUMNNAME_ORIGEN_DESCRIPCION = "DESC_ORIGEN";
        private const string COLUMNNAME_TIPO = "TIPO";
        private const string COLUMNNAME_CANTIDAD = "CANTIDAD";
        private const string COLUMNNAME_KILOS = "KILOS";
        private DataTable dtProductos = new DataTable();
        private Forms forms = new Forms();
        private CurrentUser mUserLog = new CurrentUser();

        public frmSolicitudMaterial()
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

        private void btnHlpProducto_Click(object sender, EventArgs e)
        {
            txtProducto_KeyUp(sender, new KeyEventArgs(Keys.F1));
        }

        private string eliminarCaracteresEspeciales(string entrada)
        {
            StringUtility stringUtility = new StringUtility();
            string salida = entrada;
            if (!salida.Trim().Equals(""))
                salida = stringUtility.removeInvalidCharacters(salida, stringUtility.RegexPattern_Address);
            return salida;
        }

        private string validarControlesRequeridos(int opcion)
        {
            StringBuilder sb = new StringBuilder();

            if (opcion == 1) //Guardar solicitud.
            {
                if (dgvProductos.Rows.Count == 0)
                    sb.Append("- Lista producto(s)\n");
            }
            else //Agregar producto.
            {
                if (txtProducto.Text.Trim().Equals(""))
                    sb.Append("- Producto\n");
                //if (txtDiametro.Text.Trim().Equals(""))
                //    sb.Append("- Diametro\n");
                //if (!txtLargo.Text.Trim().Equals("") && !new CommonLibrary2.Information().isNumber(txtLargo.Text))
                //    sb.Append("- Largo (valor numérico)\n");
                //if (cboOrigen.Text.Trim().Equals(""))
                //    sb.Append("- Origen\n");
                //if (cboTipo.Text.Trim().Equals(""))
                //    sb.Append("- Tipo\n");
                //if (!txtCantidad.Text.Trim().Equals("") && !new CommonLibrary2.Information().isNumber(txtCantidad.Text))
                //    sb.Append("- Cantidad (valor numérico)\n");
            }
            return sb.ToString();
        }

        private void tlbGuardar_Click(object sender, EventArgs e)
        {
           
            string mensaje = validarControlesRequeridos(1);
            if (mensaje.Equals(""))
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
                    WsOperacion.Solicitud_Material solicitud_Material = new WsOperacion.Solicitud_Material();
                    WsOperacion.Solicitud_Material_Detalle solicitud_Material_Detalle = new WsOperacion.Solicitud_Material_Detalle();

                    solicitud_Material.Id = 0;
                    solicitud_Material.Usuario = Program.currentUser.Login;

                    solicitud_Material = wsOperacion.GuardarSolicitudMaterial(solicitud_Material, Program.currentUser.ComputerName, Program.currentUser.IdTotem); //Program.currentUser.Totem
                    if (solicitud_Material.MensajeError.Equals(""))
                    {
                        int idSolicitud = solicitud_Material.Id;

                        foreach (DataGridViewRow row in dgvProductos.Rows)
                        {

                            // SI ESTAMOS RECEPCIONANDO Rollos debemos, el sistema debe exigir los kilos de la Etiqueta

                            solicitud_Material_Detalle.Id = idSolicitud;
                            solicitud_Material_Detalle.Producto = row.Cells[COLUMNNAME_PRODUCTO].Value.ToString();
                            solicitud_Material_Detalle.Diametro = row.Cells[COLUMNNAME_DIAMETRO].Value.ToString();
                            solicitud_Material_Detalle.Largo = row.Cells[COLUMNNAME_LARGO].Value.ToString();
                            solicitud_Material_Detalle.Origen = row.Cells[COLUMNNAME_ORIGEN].Value.ToString();
                            solicitud_Material_Detalle.Tipo = row.Cells[COLUMNNAME_TIPO].Value.ToString().Substring(0, 1);
                            solicitud_Material_Detalle.Cantidad = Convert.ToInt32(row.Cells[COLUMNNAME_CANTIDAD].Value.ToString());
                            solicitud_Material_Detalle.Kilos  = int.Parse (row.Cells[COLUMNNAME_KILOS].Value.ToString());

                            solicitud_Material_Detalle = wsOperacion.AsociarProductosaSolicitud(solicitud_Material_Detalle, Program.currentUser.Login, Program.currentUser.ComputerName, Program.currentUser.IdTotem);
                            if (solicitud_Material_Detalle.MensajeError.Equals(""))
                            {
                                //tlbActualizar.PerformClick();
                                //MessageBox.Show("Registro(s) guardado(s).", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                                MessageBox.Show(solicitud_Material.MensajeError.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        //tlbNuevo.PerformClick();
                        //tlbNuevo_Click(sender, e);
                        MessageBox.Show("Registro(s) guardado(s).", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dtProductos.Clear();
                        //Application.Exit();
                    }
                    else
                        MessageBox.Show(solicitud_Material.MensajeError.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Cursor.Current = Cursors.Default;
            }
            else
                MessageBox.Show("Debe ingresar los siguientes datos requeridos:\n\n" + mensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void tlbDesactivar_Click(object sender, EventArgs e)
        {

        }

        private void tlbNuevo_Click(object sender, EventArgs e)
        {
            ObtenerKilos();
            string mensaje = validarControlesRequeridos(2);
            if (mensaje.Equals(""))
            {
                int position = forms.dataGridViewSearchText(dgvProductos, COLUMNNAME_PRODUCTO, txtProducto.Text.Trim());
                if (position != -1)
                    dgvProductos.Rows.RemoveAt(position);

                DataRow newRow = dtProductos.NewRow();
                newRow[COLUMNNAME_PRODUCTO] = txtProducto.Text.Trim();
                newRow[COLUMNNAME_PRODUCTO_DESCRIPCION] = lblProducto.Text.Trim();
                newRow[COLUMNNAME_DIAMETRO] = cboDiametro.Text.Trim();
                newRow[COLUMNNAME_LARGO] = lblLargo.Text.Trim();
                newRow[COLUMNNAME_ORIGEN] = cboOrigen.SelectedValue.ToString();
                newRow[COLUMNNAME_ORIGEN_DESCRIPCION] = cboOrigen.Text.Trim();
                newRow[COLUMNNAME_TIPO] = cboTipo.Text.Trim();
                newRow[COLUMNNAME_CANTIDAD] = numUpdCantidad.Value; //txtCantidad.Text.Trim();
                newRow[COLUMNNAME_KILOS] = Tx_Kilos .Text ; //txtCantidad.Text.Trim();
                dtProductos.Rows.Add(newRow);

                txtProducto.Clear();
                lblProducto.Text = ".";
                cboDiametro.SelectedIndex = 0;
                lblLargo.Text = "0";
                cboOrigen.SelectedIndex = 0;
                cboTipo.SelectedIndex = 0;
                numUpdCantidad.Value = 1;
                Tx_Kilos.Text = "0";
                txtProducto.Focus();
            }
            else
                MessageBox.Show("Debe ingresar los siguientes datos requeridos:\n\n" + mensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void tlbEliminar_Click(object sender, EventArgs e)
        {
            DataGridViewRow currentRow = dgvProductos.CurrentRow;
            if (currentRow != null)
            {
                if (MessageBox.Show("¿Esta seguro que desea eliminar este registro?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                {
                    dgvProductos.Rows.Remove(currentRow);
                }
            }
        }

        private void tlbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSolicitudMaterial_Shown(object sender, EventArgs e)
        {
            //cboOrigen.SelectedIndex = 0;
            //cboTipo.SelectedIndex = 0;

            //DataTable
            dtProductos.Columns.Add(COLUMNNAME_PRODUCTO);
            dtProductos.Columns.Add(COLUMNNAME_PRODUCTO_DESCRIPCION);
            dtProductos.Columns.Add(COLUMNNAME_DIAMETRO);
            dtProductos.Columns.Add(COLUMNNAME_LARGO);
            dtProductos.Columns.Add(COLUMNNAME_ORIGEN);
            dtProductos.Columns.Add(COLUMNNAME_ORIGEN_DESCRIPCION);
            dtProductos.Columns.Add(COLUMNNAME_TIPO);
            dtProductos.Columns.Add(COLUMNNAME_CANTIDAD);
            dtProductos.Columns.Add(COLUMNNAME_KILOS);
            this.dgvProductos.DataSource = dtProductos;

            try
            {
                dgvProductos.Columns[COLUMNNAME_ORIGEN].Visible = false;
                
                
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtProducto.Focus();
        }

        private void txtProducto_KeyUp(object sender, KeyEventArgs e)
        {
            string lProdSel = ""; string lIdMaquina = mUserLog.IdMaquina.ToString();
            CommonHelp.frmHelp frmHelp = new CommonHelp.frmHelp();

            if (e.KeyCode == Keys.F1)
            {
                try
                {
                    string lSql = String.Concat(" SP_Consultas_WS 58 ,'", lIdMaquina, "','','','','','',''");

                    //frmHelp.setShowHelp("Busca: Material", "patente", txtProducto.Text, "Muestra un listado de los materiales.", "SELECT * FROM information_schema.tables", "");
                    frmHelp.setShowHelp("Busca: Material", "patente", txtProducto.Text, "Muestra un listado de los materiales.", lSql, "");

                    frmHelp.ShowDialog();
                    if (frmHelp.getResultRow() != null)
                    {
                        //txtPatente.Text = frmHelp.getResultRow()[0].ToString();
                        //lblTransportista.Text = frmHelp.getResultRow()[1].ToString();
                        //cboObraDestino.Focus();

                        string lId = frmHelp.getResultRow()["id"].ToString();  //resultRow["Id"].ToString(); 
                        string lCodigo = frmHelp.getResultRow()["Codigo"].ToString();  //resultRow["Codigo"].ToString();
                        string lDes = frmHelp.getResultRow()["Descripcion"].ToString();  // resultRow["Descripcion"].ToString();
                        string lDiam = frmHelp.getResultRow()["Diametro"].ToString();  //resultRow["Diametro"].ToString();
                        string lLargo = frmHelp.getResultRow()["Largo"].ToString();  //resultRow["Largo"].ToString();                   
                        string lEsSoldable = frmHelp.getResultRow()["Soldable"].ToString();
                        string lTipo = frmHelp.getResultRow()["Tipo"].ToString();


                        //if (AppDomain.CurrentDomain.GetData("Producto") != null)
                        //{                       
                        CargaProducto(lId, lCodigo, lDes, lDiam, lLargo, lEsSoldable, lTipo);
                        //}                                           
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    frmHelp.Dispose();
                }
            }
        }

        private void txtProducto_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!txtProducto.Text.Trim().Equals(""))
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    lblProducto.Text = ".";
                  
                    Ws_TO.Ws_ToSoapClient wsCertificacion = new Ws_TO.Ws_ToSoapClient();
                   // WsCertificacion.Ws_ToSoapClient wsCertificacion = new WsCertificacion.Ws_ToSoapClient();
                    DataSet ds = wsCertificacion.ObtenerProductosPorMaquina(Program.currentUser.IdMaquina .ToString());
                    if (ds != null)
                    { 
                        DataRow[] foundRows = ds.Tables[0].Select("Codigo = '" + txtProducto.Text.Trim() + "'");
                        if (foundRows.Length != 0)
                        {
                            lblProducto.Text = foundRows[0]["Descripcion"].ToString();
                            lblLargo.Text = foundRows[0]["Largo"].ToString();
                            //if (foundRows[0]["Tipo"].ToString().Equals("R"))
                            //{
                            //    numUpdCantidad.Value = 1;
                            //    numUpdCantidad.Enabled = false;
                            //}
                            //else
                            //    numUpdCantidad.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("El material '" + txtProducto.Text + "' no existe o esta inactivo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            e.Cancel = true;
                        }
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Cursor.Current = Cursors.Default;
            }
        }

        private void dgvProductos_DoubleClick(object sender, EventArgs e)
        {
            DataGridViewRow currentRow = dgvProductos.CurrentRow;
            if (currentRow != null)
            {
                txtProducto.Text = currentRow.Cells[COLUMNNAME_PRODUCTO].Value.ToString();
                lblProducto.Text = currentRow.Cells[COLUMNNAME_PRODUCTO_DESCRIPCION].Value.ToString();
                cboDiametro.Text = currentRow.Cells[COLUMNNAME_DIAMETRO].Value.ToString();
                lblLargo.Text = currentRow.Cells[COLUMNNAME_LARGO].Value.ToString();
                //currentRow.Cells[COLUMNNAME_ORIGEN].Value.ToString();
                cboOrigen.Text = currentRow.Cells[COLUMNNAME_ORIGEN_DESCRIPCION].Value.ToString();
                cboTipo.Text = currentRow.Cells[COLUMNNAME_TIPO].Value.ToString();
                numUpdCantidad.Value = Convert.ToInt32(currentRow.Cells[COLUMNNAME_CANTIDAD].Value.ToString());
                txtProducto.Focus();
            }
        }

        #region Metodos Publicos de la clase

        public void IniciaForm(CurrentUser iUserLog)
        {
            mUserLog = iUserLog;
            ctlInformacionUsuario1.CargaDatosUserLog(iUserLog);

            DataTable lTbl = new DataTable(); DataRow lFila = null;
            lTbl.Columns.Add("Tipo", Type.GetType("System.String"));
            lTbl.Columns.Add("Des", Type.GetType("System.String"));

            lFila = lTbl.NewRow();

            lFila["Tipo"] = "S"; lFila["Des"] = "SOLDABLE"; lTbl.Rows.Add(lFila);
            lFila = lTbl.NewRow();
            lFila["Tipo"] = "N"; lFila["Des"] = "NORMAL"; lTbl.Rows.Add(lFila);

            forms.comboBoxFill(cboTipo, lTbl, "Tipo", "Des", 0);

            //Diametro
            Ws_TO.Ws_ToSoapClient wsParametro = new Ws_TO.Ws_ToSoapClient();
            DataSet ds = wsParametro.ObtenerParametro("Diametro");
            forms.comboBoxFill(cboDiametro, ds.Tables[0], "Par1", "Par1", 0);


            //Origen
            ds = wsParametro.ObtenerParametro("Procedencia");
            forms.comboBoxFill(cboOrigen, ds.Tables[0], "Id", "Par1", 0);

        }

        #endregion




        #region Metodos Privados de la Clase

        private void CargaProducto(string IdProd, string lCod, string lDes, string lDiam, string lLargo, string lEsSoldable, string lTipo)
        {            
            Clases.ClsComun lcom = new Clases.ClsComun();

            txtProducto.Text = lCod;
            txtProducto.Tag = IdProd;
            lblProducto.Text = lDes;
            lblLargo.Text = lLargo;
            cboDiametro.SelectedValue = lcom.Val(lDiam);                                                         
            cboDiametro.Enabled = false;

            cboTipo.SelectedValue =  lEsSoldable;
            cboTipo.Enabled = false;

            cboOrigen.SelectedValue = 516;


            if (lTipo == "B")
               numUpdCantidad.Enabled = true;

            if (lTipo == "R")
            {
                numUpdCantidad.Value = 1;
                numUpdCantidad.Enabled = false;
                ObtenerKilos();
            }
                
            
        }


        #endregion

        private void frmSolicitudMaterial_Load(object sender, EventArgs e)
        {
            txtProducto_KeyUp(sender, new KeyEventArgs(Keys.F1));
        }

        private void numUpdCantidad_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numUpdCantidad_Leave(object sender, EventArgs e)
        {
            ObtenerKilos();
        }

        private void ObtenerKilos()
        {
            Clases.ClsComun lDal = new Clases.ClsComun(); string lKilos = "";
            int lCantidad = int.Parse(numUpdCantidad.Value.ToString());
            lKilos = lDal.ObtenerKilos(lblLargo.Text, cboDiametro.SelectedValue.ToString(), lCantidad);
            Tx_Kilos.Text = lKilos;
        }
    }
}