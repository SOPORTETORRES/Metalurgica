using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CommonLibrary2;
using System.Data;
using System.Collections;
using System.Xml.Serialization;
using System.IO;

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
        private const string COLUMNNAME_ES_RECUPERADO = "ES_RECUPERADO";
        private DataTable dtProductos = new DataTable();
        private Forms forms = new Forms();
        private CurrentUser mUserLog = new CurrentUser();
        private Boolean mPrimeraVez = false;


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
                            solicitud_Material_Detalle.Es_Recuperado  = row.Cells[COLUMNNAME_ES_RECUPERADO].Value.ToString() ;
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
                //int position = forms.dataGridViewSearchText(dgvProductos, COLUMNNAME_PRODUCTO, txtProducto.Text.Trim());
                //if (position != -1)
                //    dgvProductos.Rows.RemoveAt(position);

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
                if (Chk_Recuperado.Checked == true)
                    newRow[COLUMNNAME_ES_RECUPERADO] = "S";
                else
                    newRow[COLUMNNAME_ES_RECUPERADO] = "N";

                //COLUMNNAME_ES_RECUPERADO
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
            dtProductos.Columns.Add(COLUMNNAME_ES_RECUPERADO);
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

        private Boolean  VerificaCierresAnteriores()
        {
            Boolean lRes = false;
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient(); DataSet lDts = new DataSet();
            string lSql = String.Concat(" SP_ConsultasGenerales 134,'", mUserLog.IdTotem, "','','','',''");
            WsOperacion.ListaDataSet lisDts = new WsOperacion.ListaDataSet();
            //1.- Verificamos si hay SMP del turno anterior abiertas
            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                Pnl_Msg.Visible = true;
                tabOperaciones.SelectedIndex = 1;
                tabPage1.Enabled = false ;
                this.Refresh();
                Application.DoEvents();
                lRes = true ;
                //2.- Si las Hay, Se  debe hacer un cierre automatico
                // Obtenemos los datos de los consumos a realizar         
                lisDts = new WsOperacion.OperacionSoapClient().ListarSolicitudMaterial_CierreAut(mUserLog.IdTotem);
                if (lisDts.DataSet.Tables.Count > 0)
                {
                    //Realizar el cierre
                     CierreAutomatico((lisDts.DataSet.Tables[0].Copy()));

                    Pnl_Msg.Visible = false;
                    tabOperaciones.SelectedIndex = 0;
                    tabPage1.Enabled = true;
                    //3.- Enviar correo electronico a una lista de distribución y con un cuerpo por definir.
                    // Por Definir
                }


            }
            return lRes;

        }


        private void CierreAutomatico(DataTable iTbl)
        {
            Ws_TO.Ws_ToSoapClient lPX = new Ws_TO.Ws_ToSoapClient(); int i = 0; string lIds_SMP = "";
            Ws_TO.Objeto_WsINET lObjINET = new Ws_TO.Objeto_WsINET(); ArrayList lLista = new ArrayList();
            Integracion_INET.Tipo_InvocaWS lRespuestaWS_INET = new Integracion_INET.Tipo_InvocaWS();
            int lIdDetalleSM = 0;

            int counter = 0;
            string inet_msg = "", email_msg = "", newLine = Environment.NewLine, tab = "\t";

            string lCodigo = ""; string lCantidad = ""; string lFechaMov = ""; string lGlosa1 = ""; string lGlosa2 = "";

            DataTable lTblINET = new DataTable(); DataRow iFila = null;
            lTblINET.Columns.Add("Codigo", Type.GetType(("System.String")));
            lTblINET.Columns.Add("Cantidad", Type.GetType(("System.String")));
            lTblINET.Columns.Add("FechaMov", Type.GetType(("System.String")));
            lTblINET.Columns.Add("Glosa1", Type.GetType(("System.String")));
            lTblINET.Columns.Add("Glosa2", Type.GetType(("System.String")));
            lTblINET.Columns.Add("Procesado", Type.GetType(("System.String")));



            //dtpFechaRecepcion.Focus();
            counter = iTbl.Rows.Count; // forms.dataGridViewCountRowsChecked(dgvProductos, COLUMNNAME_MARCA);
            if (counter > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
                    WsOperacion.Solicitud_Material_Detalle solicitud_Material_Detalle = new WsOperacion.Solicitud_Material_Detalle();
                    int lKgsProd = 0; Clases.ClsComun lCom = new Clases.ClsComun();
                    counter = 0;
                    //foreach (DataGridViewRow row in dgvProductos.Rows)
                    PB_1.Maximum = iTbl.Rows.Count;
                    PB_1.Minimum = 0; PB_1.Value = 0;
                    for (i = 0; i < iTbl.Rows.Count; i++)
                    {
                        if (PB_1.Value < PB_1.Maximum)
                            PB_1.Value = PB_1.Value + 1;
                        else
                            PB_1.Value = PB_1.Value - 1;

                        PB_1.Refresh();Application.DoEvents();
                        //if (iTbl.Rows[i]["Marca"] != null) // (row.Cells[COLUMNNAME_MARCA].Value != null)
                        //{
                      
                        //if (((bool)row.Cells[COLUMNNAME_MARCA].Value == true) && (row.Cells["ES_RECUPERADO"].Value.ToString().Equals("N")))
                        //{
                        lKgsProd = lCom.Val(iTbl.Rows[i]["KILOS_PROD"].ToString());

                            if ((lKgsProd > 0))
                            {
                                lTblINET.Clear();
                                if (lCom.Agregar_IdSolicitud(lLista, iTbl.Rows[i]["SOL_ID"].ToString()))
                                {
                                    lLista.Add(iTbl.Rows[i]["SOL_ID"].ToString());
                                }
                                inet_msg = "";
                                if ((!iTbl.Rows [i]["ES_RECUPERADO"]. ToString().Equals("S")))
                                {
                                    lCodigo = iTbl.Rows[i][COLUMNNAME_PRODUCTO].ToString();
                                    lCantidad = iTbl.Rows[i]["KILOS_RECEP"].ToString();
                                    lFechaMov = DateTime.Now.ToString();
                                    lGlosa1 = string.Concat ( Program.currentUser.Login , " Cierre Autom. ",  (iTbl.Rows[i]["DET_ID"].ToString()) ) ;
                                    lGlosa2 = lCom.ObtenerInicioFIn_Turno_CierreAutom(  iTbl.Rows[i]["Fecha_RECEP"].ToString()); // ObtenerTurno(); // pero de la sesion anterior 

                                    iFila = lTblINET.NewRow();
                                    iFila["Codigo"] = lCodigo;
                                    iFila["Cantidad"] = lCantidad;
                                    iFila["FechaMov"] = lFechaMov;
                                    iFila["Glosa1"] = lGlosa1;
                                    iFila["Glosa2"] = lGlosa2;
                                    iFila["Procesado"] = "N";
                                    lTblINET.Rows.Add(iFila);


                                    // 1.- Se Integra con INET
                                    DataTable lTblFinal = new DataTable(); DataSet lDts = new DataSet();
                                    //lTblFinal = ObtenerDatosIntegracionINET(lTblINET);
                                    lDts.Tables.Add(lTblINET.Copy());
                                    lFechaMov = lFechaMov.Replace("/", "-");

                                    //Debemos saber que  sucursal esta haciendo la invocaión
                                    int lIdSucursal = lCom.OBtenerIdSucursal();

                                    if (lIdSucursal == 1)   //Calama
                                        lObjINET = lPX.ObtenerObjetoINET_Calama(lDts, lFechaMov, lGlosa1, lGlosa2);

                                    if (lIdSucursal == 4)   // Santiago
                                        lObjINET = lPX.ObtenerObjetoINET(lDts, lFechaMov, lGlosa1, lGlosa2);

                                    //lObjINET = lPX.ObtenerObjetoINET(lDts, lFechaMov, lGlosa1, lGlosa2);
                                    lRespuestaWS_INET = InvocarWS_INET(lObjINET);

                                    inet_msg = lCom.buscarTagError(lRespuestaWS_INET.XML_Respuesta.ToString());
                                    if (inet_msg.Trim().ToUpper().Equals("OK"))
                                    {
                                        counter++;
                                        if (email_msg.Equals(""))
                                        {
                                            email_msg += "Producto(s):" + newLine + newLine;
                                            email_msg += "Cod.Producto" + tab + "Descripción" + tab + "Cantidad" + newLine;
                                        }
                                        email_msg += iTbl.Rows[i][COLUMNNAME_PRODUCTO].ToString() + tab + iTbl.Rows[i][COLUMNNAME_PRODUCTO_DESCRIPCION].ToString() + tab + iTbl.Rows[i]["KILOS_RECEP"].ToString() + newLine;
                                    }
                                }
                                else
                                {
                                    //lIdDetalleSM = new Clases.ClsComun().Val(iTbl .Rows [i]["DET_ID"].ToString());
                                    //wsOperacion.AnularDetalleSolicitudMateriaPrima(lIdDetalleSM);
                                }
                            // 2.-  Se Registra el cierre del Producto

                            solicitud_Material_Detalle.Id = Convert.ToInt32(iTbl.Rows[i]["SOL_ID"].ToString());
                                solicitud_Material_Detalle.Producto = iTbl.Rows[i][COLUMNNAME_PRODUCTO].ToString();
                                solicitud_Material_Detalle.Usuario_Cierre = Program.currentUser.Login;
                                //solicitud_Material_Detalle.Fecha_Cierre = "";
                                solicitud_Material_Detalle.Tipo = iTbl.Rows[i][COLUMNNAME_TIPO].ToString().Substring(0, 1);
                                solicitud_Material_Detalle.Cantidad = Convert.ToInt32(iTbl.Rows[i]["KILOS_RECEP"].ToString());
                                solicitud_Material_Detalle.Inet_Msg = inet_msg;

                                solicitud_Material_Detalle = wsOperacion.GuardarCierreMaterial(solicitud_Material_Detalle, inet_msg, Program.currentUser.Login, Program.currentUser.ComputerName, Program.currentUser.IdTotem);
                                if (solicitud_Material_Detalle.MensajeError.Equals(""))
                                {
                                    //row.Cells[0].Value = false;
                                }
                                else
                                    MessageBox.Show(solicitud_Material_Detalle.MensajeError.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                lIdDetalleSM = new Clases.ClsComun().Val(iTbl.Rows[i]["DET_ID"].ToString());
                                wsOperacion.AnularDetalleSolicitudMateriaPrima(lIdDetalleSM);
                            }

                            //}
                        //}
                    }
                    for (i = 0; i < lLista.Count; i++)
                    {
                        lIds_SMP = string.Concat(lLista[i], ",", lIds_SMP);
                    }
                    lCom.EnvioCorreo(lIds_SMP, Program.currentUser.Login, "Linea de Corte");
                    // lCom.EnvioCorreo_Notificacion_RRHH(Program.currentUser.Login, "Linea de Corte");

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


        private Integracion_INET.Tipo_InvocaWS InvocarWS_INET(Ws_TO.Objeto_WsINET iObjINET)
        {
            Px_MovExistenciasINET.wsmovexiallSoapPortClient lPxMovEx = new Px_MovExistenciasINET.wsmovexiallSoapPortClient();
            Px_MovExistenciasINET.ExecuteRequest lObjEntradaMov = new Px_MovExistenciasINET.ExecuteRequest();
            Px_MovExistenciasINET.ExecuteResponse lResMovEx = new Px_MovExistenciasINET.ExecuteResponse();
            Integracion_INET.Tipo_InvocaWS lResultado = new Integracion_INET.Tipo_InvocaWS();
            Integracion_INET.MovExistencias lTipoEntradaEx = new Integracion_INET.MovExistencias();
            XmlSerializer lXmlSal = null; StringWriter strDataXml = new StringWriter(); string lEstadoProceso = "";
            String lSql = ""; WsCrud.CrudSoapClient lDAl = new WsCrud.CrudSoapClient();
            WsCrud.ListaDataSet lDts = new WsCrud.ListaDataSet(); Clases.ClsComun lCom = new Clases.ClsComun();
            //lDts As New ListaDataSet
            //DataSet   lDts =new DataSet ();

            //Integracion_INET .MovExistencias             
            try
            {
                // iEstado.Text = iEstado.Text & vbCrLf & "Cargando Objeto Entrada Bodega Productos Terminados  " : iEstado.Refresh()
                lTipoEntradaEx = lCom.CargaObjEntradaBodegaProdTerm_INET(iObjINET);
                // lObjEntradaMov.Intrasnporte = lTipoEntradaEx.ToString ();
                lObjEntradaMov.Intrasnporte = lCom.CreaXmlEntradaProductosTerminados_INET_SolicitudMP(iObjINET);// CreaXmlEntradaProductosTErminados_INET(lTipoEntradaEx);

                //    'Cargamos el log para la el invocación del WS
                //    iEstado.Text = iEstado.Text & vbCrLf & " Objeto Entrada Bodega Productos Terminados-- OK " & lResultado.Err
                //   lResultado = New Tipo_InvocaWS
                //    Application.DoEvents()
                lResultado.XML_Enviado = lObjEntradaMov.Intrasnporte;
                //    lResultado.IdDespachoCamion = mIdDespachoCamion
                lResultado.URL_WS = lPxMovEx.Endpoint.ListenUri.AbsoluteUri;
                //    iEstado.Text = iEstado.Text & vbCrLf & " Antes de  Invocar  WS INET :" & vbCrLf & lResultado.XML_Enviado : iEstado.Refresh()
                lResMovEx.Outtansporte = lPxMovEx.Execute(lObjEntradaMov.Intrasnporte);
                //Dim lXmlSal As New XmlSerializer(lResMovEx.Outtansporte.GetType)
                lXmlSal = new XmlSerializer(lResMovEx.Outtansporte.GetType());
                lXmlSal.Serialize(strDataXml, lResMovEx.Outtansporte);
                lResultado.XML_Respuesta = strDataXml.ToString();
                //    iEstado.Text = iEstado.Text & vbCrLf & "Estado P1  :" & lResultado.XML_Respuesta.ToUpper.IndexOf("OK") : iEstado.Refresh()
                if (lResultado.XML_Respuesta.ToUpper().IndexOf("OK") > -1)
                    lEstadoProceso = "OK";
                else
                    lEstadoProceso = "ER";

                lResultado.XML_Respuesta = lResultado.XML_Respuesta.Replace("&lt;", "<");
                lResultado.XML_Respuesta = lResultado.XML_Respuesta.Replace("&gt;", ">");
                lResultado.XML_Respuesta = lResultado.XML_Respuesta.Replace("&amp;lt;", "<");
                lResultado.XML_Respuesta = lResultado.XML_Respuesta.Replace("&amp;gt;", ">");
            }

            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                lSql = string.Concat("exec SP_CRUD_LOG_WS_INET 1,", lResultado.Id, ",", lResultado.IdDespachoCamion);
                lSql = string.Concat(lSql, ",'", lResultado.PatenteCamion, "',0,'", lResultado.XML_Enviado.Replace("'", "''"));
                lSql = string.Concat(lSql, "','", lResultado.XML_Respuesta, "','", lResultado.URL_WS, "','SolicitudMaterial',", lTipoEntradaEx.ExistenciasAll.MOVNUMDOC);
                lSql = string.Concat(lSql, ",'", lEstadoProceso, "'");
                lDts = lDAl.ListarAyudaSql(lSql);
            }
            return lResultado;
        }


        #endregion

        private void frmSolicitudMaterial_Load(object sender, EventArgs e)
        {
           
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

        private void button1_Click(object sender, EventArgs e)
        {
           // Clases.ClsComun lCom = new Clases.ClsComun();
           // lCom.EnvioCorreo_Notificacion_RRHH("Rbecerra", "Linea de Corte");
        }

        private void frmSolicitudMaterial_Activated(object sender, EventArgs e)
        {
            if (mPrimeraVez == false)
            {
                //if (VerificaCierresAnteriores() == false)
                //    txtProducto_KeyUp(sender, new KeyEventArgs(Keys.F1));


                mPrimeraVez = true;
            }
          
        }
    }
}