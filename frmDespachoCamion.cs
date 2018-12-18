using System;
using System.Windows.Forms;
using CommonLibrary2;
using System.Text;
using System.Data;
using System.Drawing;
using System.Configuration;

namespace Metalurgica
{
    public partial class frmDespachoCamion : Form
    {
        private CurrentUser mUserLog = new CurrentUser();
        private const string COLUMNNAME_ETIQUETA_COLADA = "ETIQUETA_COLADA";
        private const string COLUMNNAME_ETIQUETA_PIEZA = "ETIQUETA_PIEZA";
        private double mTotalKgsCargado = 0;
        private double mKgsPorCargar = 0;
        private int mTotalPaqCargado = 0;
        private int mPaqPorCargar = 0;
        private double  mTotalPiezasCargado = 0;
        private double  mPiezasPorCargar = 0;
        private string  mViajesSel = "";
        private string mIdsViajes = "";
        private string mPiezasError = "";
        private string mSoloCamionesBascula = "";
        private bool mPrimeraVez = true;

        public frmDespachoCamion()
        {
            InitializeComponent();
            this.dgvEtiquetasPiezas.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(dgvEtiquetasPiezas_RowPostPaint);
            Clases.ClsComun lCom = new Clases.ClsComun();
            this.Text += " - versión: " + lCom.ObtenerVersionDC();  
        }

        private void HabilitaDesplegablePatentes(Boolean iSoloCamionesBascula)
        {
            DataTable lTbl = new DataTable();DataRow lFila = null;
            if (iSoloCamionesBascula == true)
            {
                WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
                WsOperacion.ListaDataSet listaDataSet = new WsOperacion.ListaDataSet();
                listaDataSet = wsOperacion.ObtenerPatentesParaDespacho();

                if (listaDataSet.MensajeError.ToString().Trim().Length == 0)
                {
                    if (listaDataSet.DataSet.Tables.Count > 0)
                    {
                        mPrimeraVez = true;
                        lTbl = listaDataSet.DataSet.Tables[0].Copy();
                        lFila = lTbl.NewRow();
                        lFila["Patente"] = "Seleccionar";
                        lTbl.Rows.Add(lFila);

                        new Forms().comboBoxFill(Cmb_Patentes, lTbl, "patente", "patente", 0);

                        Cmb_Patentes.SelectedIndex = lTbl.Rows.Count - 1;
                        mPrimeraVez = false;
                    }
                }
                else
                {
                    MessageBox.Show(string.Concat ("El Sistema ha encontrado el siguiente error:  ", listaDataSet.MensajeError), "Avisos Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                txtPatente.Visible = false;
                Cmb_Patentes.Visible = true;
                btnHlpCamion.Visible = true;
                //btnCrudCamion.Visible = true;
            }
            else
            {
                txtPatente.Visible = true;
                Cmb_Patentes.Visible = false ;
                btnHlpCamion.Visible = true;
                //btnCrudCamion.Visible = true;
            }
        }
        public void IniciaFormulario(CurrentUser iUserLog)
        {
            mUserLog = iUserLog;
            ctlInformacionUsuario1.CargaDatosUserLog(iUserLog);
            mSoloCamionesBascula = ConfigurationManager.AppSettings["SoloCamionesBascula"].ToString();
            if (mSoloCamionesBascula.ToUpper().Equals("S"))
            {
                HabilitaDesplegablePatentes(true);
               }
            else
            {
                HabilitaDesplegablePatentes(false);
            }

            string lCambiarProduccion = ConfigurationManager.AppSettings["CambioPR_Desp"].ToString();

            if (lCambiarProduccion.ToUpper().Equals("S"))
                Btn_Cambiar_A_PR.Visible = true;
            else
                Btn_Cambiar_A_PR.Visible  = false;

        }
        private void dgvEtiquetasPiezas_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvEtiquetasPiezas.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void tlbNuevo_Click(object sender, EventArgs e)
        {
            txtPatente.Clear();
            lblTransportista.Text = ".";
            if (cboObraDestino.Items.Count > 0)
                cboObraDestino.SelectedIndex = 0;
            txtObs.Clear();
            txtEtiquetaPieza.Clear();
            dgvEtiquetasPiezas.DataSource = null;
            lblCantidadEtiquetasPiezas.Text = "Registro(s): 0";
            mTotalKgsCargado = 0;
            txtPatente.Focus();

            lbl_TotalKgsCar.Text = "";
            this.Lbl_PiezasPorCar.Text = "";
            this.Lbl_KilosPorCar.Text = "";
            lbl_TotalPaqCar.Text = "";
            Lbl_PaqPorCar.Text = "";
            lbl_NroPiezasCar.Text = "";

            Lbl_NroPiezas.Text = "";
            Lbl_TotalKgs.Text = "";
            Lbl_TotalPaq.Text = "";
            mPiezasError = "";
            mTotalPiezasCargado = 0;
            mTotalPaqCargado = 0;
            mPaqPorCargar = 0;
            Btn_EliminaPaq.Enabled = false;
            this.tlbGuardar.Enabled = true;
            Lbl_Viajes.Text = "";
            cboObraDestino.Enabled = true;
            Btn_DevuelveCamion.Enabled = true;
        }

        private string eliminarCaracteresEspeciales(string entrada)
        {
            StringUtility stringUtility = new StringUtility();
            string salida = entrada;
            if (!salida.Trim().Equals(""))
                salida = stringUtility.removeInvalidCharacters(salida, stringUtility.RegexPattern_Address);
            return salida;
        }

        private string validarControlesRequeridos()
        {
            StringBuilder sb = new StringBuilder();
            if (mSoloCamionesBascula.ToUpper ().Equals ("N"))
            {
                if (txtPatente.Text.Trim().Equals(""))
                    sb.Append("- Camión\n");

                
            }
            else
            {
                if (ValidaPatente(Cmb_Patentes .SelectedValue .ToString ()) == false)
                {
                    sb.Append("- Patente  Camión no existe\n");
                }

            }

            //if (!txtBodegaAcopio.Text.Trim().Equals("") && !new CommonLibrary2.Information().isNumber(txtBodegaAcopio.Text))
            //    sb.Append("- Bodega Acopio (valor numérico)\n");
            if (dgvEtiquetasPiezas.Rows.Count == 0)
                sb.Append("- Pieza(s)\n");
            return sb.ToString();
        }

        private void tlbGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = validarControlesRequeridos(); string lEtiColada="";
            string lIdObra = ""; int idDespacho = 0; DataTable lTbl = new DataTable(); DataRow lFila = null;
            string lOpcionUSer = ""; string lEstado = ""; DataTable lTblViajes = new DataTable();DataSet lDtsDatos = new DataSet();
            WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
            WsOperacion.Despacho_Camion despacho_Camion = new WsOperacion.Despacho_Camion();
            WsOperacion.Despacho_Camion lDespachoCamion = new WsOperacion.Despacho_Camion();

            //Integracion_INET.Cls_LN lLogInet = new Integracion_INET.Cls_LN();
            //Integracion_INET.Tipo_InvocaWS lResWS = new Integracion_INET.Tipo_InvocaWS();

            lTbl.TableName = "Piezas";
            lTbl.Columns.Add("usuario", Type.GetType("System.String"));
            lTbl.Columns.Add("colada", Type.GetType("System.String"));
            lTbl.Columns.Add("etiqueta_pieza", Type.GetType("System.String"));

            lTblViajes.TableName = "Viajes";
            lTblViajes.Columns.Add("Codigo", Type.GetType("System.String"));

            Frm_ResumenDespacho lFrm=new Frm_ResumenDespacho ();            
            DataTable dataTable = (DataTable)dgvEtiquetasPiezas.DataSource;
            lFrm.IniciaForm(Lbl_Viajes.Text, mPiezasError, Lbl_TotalKgs.Text, lbl_TotalKgsCar.Text, Lbl_TotalPaq.Text, lbl_TotalPaqCar.Text, dataTable);
            lFrm.ShowDialog(this );
            lOpcionUSer = AppDomain.CurrentDomain.GetData("Opcion").ToString ();

            // Solo si el usuario hace click en boton aceptar se procesa el despacho del camion
            if (lOpcionUSer.ToUpper().Trim().Equals("A"))
            {
                mensaje = validarControlesRequeridos();
                if (mensaje.Equals(""))
                {
                    Cursor.Current = Cursors.WaitCursor;
                    try
                    {
                       despacho_Camion.Id = 0; lDespachoCamion.Id = 0;
                        if (mSoloCamionesBascula.ToUpper().Equals("S"))
                        {
                            despacho_Camion.Camion = Cmb_Patentes.SelectedValue.ToString ();
                        }
                        else
                        {
                            despacho_Camion.Camion = txtPatente.Text.Trim();
                        }

                        lDespachoCamion.Camion = despacho_Camion.Camion;
                        despacho_Camion.Obra_Destino = (cboObraDestino.SelectedValue == null ? "" : cboObraDestino.SelectedValue.ToString());
                        lDespachoCamion.Obra_Destino = despacho_Camion.Obra_Destino;

                        lIdObra = despacho_Camion.Obra_Destino;
                        despacho_Camion.Usuario = Program.currentUser.Login;
                        lDespachoCamion.Usuario = despacho_Camion.Usuario;
                        //despacho_Camion.Fecha = ""; 
                        despacho_Camion.Obs = txtObs.Text;
                        lDespachoCamion.Obs = despacho_Camion.Obs ;

                        //Grabmos el despacho de Camion*************************
                        // *primero las piezas que se despachan***************
                        foreach (DataGridViewRow row in dgvEtiquetasPiezas.Rows)
                        {
                            //Solo se deben procersar las que tienen el campo Estado1=POK
                            // y las que estan marcadas como Va pero No Va
                            lEstado = row.Cells["ESTADO1"].Value.ToString();
                            if (lEstado.ToString().Equals("POK"))
                            {
                                lFila = lTbl.NewRow();
                                lFila["usuario"] = Program.currentUser.Login;
                                lFila["colada"] = row.Cells[COLUMNNAME_ETIQUETA_COLADA].Value.ToString();
                                lFila["etiqueta_pieza"] = row.Cells[COLUMNNAME_ETIQUETA_PIEZA].Value.ToString();
                                lTbl.Rows.Add(lFila);
                            }
                            else
                            {
                                if (row.Cells["NOVA"].Value.ToString().ToUpper().Equals("S"))
                                {
                                    lFila = lTbl.NewRow();
                                    lFila["usuario"] = Program.currentUser.Login;
                                    lFila["colada"] = row.Cells[COLUMNNAME_ETIQUETA_COLADA].Value.ToString();
                                    lFila["etiqueta_pieza"] = row.Cells[COLUMNNAME_ETIQUETA_PIEZA].Value.ToString();
                                    lTbl.Rows.Add(lFila);
                                }
                            }
                        }
                        lDtsDatos.Tables.Add(lTbl);
                        //******ahora los Viajes
                        // Debemos recorrer todos los viajes de la grilla 
                        string lViaje = "";
                        foreach (DataGridViewRow row in this.Dtg_ResumenCarga.Rows)
                        {
                            lViaje = row.Cells["Viaje"].Value.ToString();
                            if (lViaje.ToString().IndexOf("Tot") == -1)
                            {
                                //  SP_VERIFICA_VIAJE_DESPACHO(lViaje);
                                lFila = lTblViajes .NewRow();
                                lFila["Codigo"] = lViaje;
                                lTblViajes.Rows .Add(lFila);
                            }
                        }
                        lDtsDatos.Tables.Add(lTblViajes);

                        despacho_Camion = wsOperacion.GuardarDespachoCamion(despacho_Camion, Program.currentUser.ComputerName, lDtsDatos);



                        //Insertamos la cabecera  del despacho*******************************************+
                        //despacho_Camion = wsOperacion.GuardarDespachoPiezaCamion(despacho_Camion, Program.currentUser.ComputerName);
                        //if (despacho_Camion.MensajeError.Equals(""))
                        //{
                        //     idDespacho = despacho_Camion.Id;
                        //     lDespachoCamion.Id = despacho_Camion.Id;
                        //     lDespachoCamion.CodigoViaje = Lbl_Viajes.Text;
                        //    foreach (DataGridViewRow row in dgvEtiquetasPiezas.Rows)
                        //    {
                        //        //Solo se deben procersar las que tienen el campo Estado1=POK
                        //        lEstado = row.Cells["ESTADO1"].Value.ToString();
                        //        if (lEstado.ToString().Equals("POK"))
                        //        { 

                        //        lEtiColada = row.Cells[COLUMNNAME_ETIQUETA_COLADA].Value.ToString();
                        //        //'despacho_Camion = wsOperacion.AsociarEtiquetaPiezaaCamion(idDespacho, row.Cells[COLUMNNAME_ETIQUETA_COLADA].Value.ToString(), row.Cells[COLUMNNAME_ETIQUETA_PIEZA].Value.ToString(), Program.currentUser.Login, Program.currentUser.ComputerName);

                        //       //Asociamos el detalle a la cabecera
                        //        despacho_Camion = wsOperacion.AsociarEtiquetaPiezaaCamion(idDespacho, lEtiColada, row.Cells[COLUMNNAME_ETIQUETA_PIEZA].Value.ToString(), Program.currentUser.Login, Program.currentUser.ComputerName);
                        //        if (despacho_Camion.MensajeError.Equals(""))
                        //        {
                        //            //tlbActualizar.PerformClick();
                        //            //MessageBox.Show("Registro(s) guardado(s).", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //        }
                        //        else
                        //            MessageBox.Show(despacho_Camion.MensajeError.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                        //        }
                        //    }

                        //    //invocamos el servicion que revisa el viaje una vez grabado para crear el nuevo viaje si corresponde
                        //   

                        //***********************fin Modificaciones

                        //Invocamos el metodo que revisa los bloqueos
                        wsOperacion.RevisaRN(lIdObra);

                        //    //***************************************
                        tlbNuevo_Click(sender, e);
                        MessageBox.Show("Registro(s) guardado(s).", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //}
                        //else
                        //    MessageBox.Show(despacho_Camion.MensajeError.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            else
                MessageBox.Show(" No se realizara la grabación de los datos ya que se Selecciono CANCELAR en el Resumen Despacho:\n\n" , this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

        }



        private void SP_VERIFICA_VIAJE_DESPACHO(string lCodViajes)
        {
            WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();

            bool lRes = false; string lCodigoViaje = "";
            char[] delimiterChars = { ',', '\t' };
            int i = 0;
            string[] words = lCodViajes.Split(delimiterChars);
            for (i = 0; i < words.Length; i++)
            {
                lCodigoViaje = words[i].ToString();
                string lResultado = wsOperacion.SP_VERIFICA_VIAJE_DESPACHO(lCodigoViaje);
            }

            
        }


        private void tlbEliminar_Click(object sender, EventArgs e)
        {

        }

        private void tlbDesactivar_Click(object sender, EventArgs e)
        {

        }

        private void tlbActualizar_Click(object sender, EventArgs e)
        {

        }

        private void tlbImprimir_Click(object sender, EventArgs e)
        {

        }

        private void tlbExportar_Click(object sender, EventArgs e)
        {
            if (dgvEtiquetasPiezas.Rows.Count > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                new Excel().exportar(dgvEtiquetasPiezas);
                Cursor.Current = Cursors.Default;
            }
            else
                MessageBox.Show("No existen registros a exportar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void tlbSalir_Click(object sender, EventArgs e)
        {

            ValidarSalir();
            Application.Exit();

        }

        protected virtual void ValidarSalir()
        {
            //Salir();
            // registramos que el usuario  salio de sistema 
            WsSesion.WS_SesionSoapClient lSesion = new WsSesion.WS_SesionSoapClient();
            string lRes = "";

            lRes = lSesion.RegistraLogOUT(mUserLog.Iduser.ToString(), mUserLog.IdMaquina.ToString());



        }
        private void btnCrudBodega_Click(object sender, EventArgs e)
        {
            new frmCrudBodega0().ShowDialog();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    this.SelectNextControl(this.ActiveControl, true, true, true, true);
                    //e.SuppressKeyPress = true;
                    break;
                default:
                    base.OnKeyDown(e);
                    break;
            }
        }


        private bool PiezaEstaEnViajesSeleccionados( DataTable lTbl )
        {
            bool lRes = false;            
            char[] delimiterChars = { ',', '\t' };
            int i = 0;
            string[] words = mIdsViajes.Split(delimiterChars);
            for (i = 0; i < words.Length; i++)
            {
                if ((words[i].ToString() != (lTbl.Rows[0]["IdViaje"].ToString())) & (words[i].ToString() != (lTbl.Rows[0]["IdViaje2"].ToString())))
                { lRes = false; }
                else
                {
                    lRes = true;
                    i = words.Length + 1;
                }
            }
                return lRes;
        }

        private void AgregaFila(   WsOperacion.ListaDataSet iFila)
        {
            DataRow row = null;
            DataTable dataTable = (DataTable)dgvEtiquetasPiezas.DataSource;
            row = dataTable.NewRow();

            foreach (DataGridViewColumn column in dgvEtiquetasPiezas.Columns)
            {
                row[column.Index] = iFila.DataSet.Tables[0].Rows[0][column.Index];                
            }
            dataTable.Rows.Add(row);   
        }
        private void AgregaFila(WsCrud.ListaDataSet iFila)
        {
            DataRow row = null;
            DataTable dataTable = (DataTable)dgvEtiquetasPiezas.DataSource;
            row = dataTable.NewRow();

            foreach (DataGridViewColumn column in dgvEtiquetasPiezas.Columns)
            {
                row[column.Index] = iFila.DataSet.Tables[0].Rows[0][column.Index];
            }
            dataTable.Rows.Add(row);
        }

        private string CreaMensajeMail(string iPaquete, string iEtiqueta)
        {
            string lMsg = "";
            lMsg = string.Concat(" Hola Estimados  Supervisores: ", Environment .NewLine );
            lMsg = string.Concat(lMsg," Mientras se despachaba en viaje: ", Lbl_Viajes .Text , Environment.NewLine);
            lMsg = string.Concat(lMsg, " Se detecto que el paquete Nro: ", iPaquete, " con etiqueta:", iEtiqueta, "  No se encuentra Producido. ", Environment.NewLine, Environment.NewLine);
            lMsg = string.Concat(lMsg, " Este mail ha sido enviado de forma automática por el sistema ", Environment.NewLine);

            return lMsg;
        }

        private string ObtenerEstadoPaquete(string  iIdPaquete)
        {
            string lRes = "";
            WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
            WsOperacion.ListaDataSet listaDataSet = new WsOperacion.ListaDataSet();

            listaDataSet = wsOperacion.ObtenerDatosConsultaGenerica(8, iIdPaquete.ToString (), "", "", "", "");
            if ((listaDataSet.DataSet.Tables.Count > 0) && (listaDataSet.DataSet.Tables[0].Rows.Count > 0))
                lRes = listaDataSet.DataSet.Tables[0].Rows[0]["Pie_Estado"].ToString(); 


            return lRes ;
        }
    

        private void LeePiezaCargada(string iEtiquetaPieza)
        {
            Forms forms = new Forms(); Color lColorsel = Color.Black; string lEstadoPaquete = "";
            DataView lVista = null; DataTable lTblPaq = new DataTable(); string lMsg = "";
            string lValidaPiezaProducida = ConfigurationManager.AppSettings["ValidaPaqueteProducido"].ToString().ToUpper (); 


            if (!txtEtiquetaPieza.Text.Trim().Equals(""))
            {
                if (forms.dataGridViewSearchText(dgvEtiquetasPiezas, COLUMNNAME_ETIQUETA_PIEZA, txtEtiquetaPieza.Text) > -1)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    try
                    {
                        lTblPaq = (DataTable)dgvEtiquetasPiezas.DataSource;
                            lVista = new DataView(lTblPaq, string.Concat("Etiqueta_Pieza=", iEtiquetaPieza), "", DataViewRowState.CurrentRows);
                        if (lVista.Count > 0)
                        {
                            //0000047: Envío de mail, cuando se despacha una pieza que no ha sido producida
                            //Se debe evaluar al momento de leer la pieza
                            lEstadoPaquete = ObtenerEstadoPaquete(iEtiquetaPieza);

                            if (lEstadoPaquete.ToString().Equals("O40") == false)
                            {
                                MessageBox.Show(string.Concat("La etiqueta leida No esta registrada como producida.", Environment.NewLine, "Verificar Producción de Etiqueta" ), "Control Piezas Producidas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                
                                if ((lValidaPiezaProducida.Equals("S")) && (lEstadoPaquete.ToString().Equals("O40") == false))
                                {
                                    //Visualizar mensaje y envio de mail.
                                    lMsg = CreaMensajeMail(lVista[0]["ETIQUETA_PIEZA"].ToString(), lVista[0]["ETIQUETA_COLADA"].ToString());
                                //    MessageBox.Show("El Paquete leido No esta registrado como producido. Se enviara una notificación ", "Control Piezas Producidas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient();
                                    //Las obras -100 ==> lista de  edstinatarios para notificación de piezas no Producidas
                                    lPx.EnviaNotificacionesEnviaMsgDeNotificacion(" Notificaciones Producción ", lMsg, -100, "Notificación de Despacho de Paquetes NO producidas");
                                }
                            }
                            else
                            {
                                lVista[0]["Estado1"] = "POK";
                                lVista[0]["Estado2"] = lEstadoPaquete;
                                forms.dataGridViewHideColumns(dgvEtiquetasPiezas, new string[] { "CAMION", "OBRA_DESTINO", "CAM_USUARIO", "CAM_FECHA", "CAM_OBSERVACION", "CAM_USUARIO_VB", "CAM_FECHA_VB", "CAM_OBSERVACION_VB", "PIE_ESTADO", "DES_ACO_ID", "DES_CAM_ID" });
                                forms.dataGridViewAutoSizeColumnsMode(dgvEtiquetasPiezas, DataGridViewAutoSizeColumnsMode.DisplayedCells);

                                txtEtiquetaPieza.Clear();
                                txtEtiquetaPieza.Focus();
                                lbl_TotalKgsCar.Text = Math.Round(mTotalKgsCargado, 0).ToString();
                                this.Lbl_PiezasPorCar.Text = Math.Round(mPiezasPorCargar, 0).ToString();
                                this.Lbl_KilosPorCar.Text = Math.Round(mKgsPorCargar, 0).ToString();
                                lbl_TotalPaqCar.Text = mTotalPaqCargado.ToString();
                                Lbl_PaqPorCar.Text = mPaqPorCargar.ToString();
                                lbl_NroPiezasCar.Text = mTotalPiezasCargado.ToString();
                            }                                                                                                            
                        }
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    Cursor.Current = Cursors.Default;
                }
                else
                {
                    WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
                    WsOperacion.ListaDataSet listaDataSet = new WsOperacion.ListaDataSet();                        
                    listaDataSet = wsOperacion.ObtenerPiezaProduccion(txtEtiquetaPieza.Text);
                    if (listaDataSet.MensajeError.Equals(""))
                    {
                        if (listaDataSet.DataSet.Tables[0].Rows.Count == 0)
                        {
                            // SI LA PIEZA NO EXISTE LA APP NO HACE NADA
                            //lEstadoLectura = "PNE"; //Pieza No Existe
                            //listaDataSet.DataSet.Tables[0].Rows[0]["Estado1"] = lEstadoLectura;
                            //AgregaFila(listaDataSet);
                            ////MessageBox.Show("La etiqueta '" + txtEtiquetaPieza.Text + "' no existe.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            mPiezasError = string.Concat(mPiezasError, "|", txtEtiquetaPieza.Text, "-", "PNE");
                        }
                        else
                        {
                            lMsg = string.Concat("El Paquete no corresponde al viaje seleccionado, revisar", Environment .NewLine );
                            lMsg = string.Concat(lMsg, "Viaje en despacho: ", Lbl_Viajes.Text, Environment.NewLine);
                            lMsg = string.Concat(lMsg, "Viaje del Paquete ingresado: ", listaDataSet.DataSet.Tables[0].Rows[0]["codigo"].ToString());
                            MessageBox.Show(lMsg, "Avisos Sistema ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //listaDataSet.DataSet.Tables[0].Rows[0]["codigo"].ToString, Environment.NewLine);
                            //listaDataSet.DataSet.Tables[0].Rows[0]["Estado1"] = "PNV";
                            //AgregaFila(listaDataSet);
                        }
                    }
                              
                }
            }

                    //        if (listaDataSet.MensajeError.Equals(""))
                    //        {
                    //            if (listaDataSet.DataSet.Tables[0].Rows.Count == 0)
                    //            {
                    //                // SI LA PIEZA NO EXISTE LA APP NO HACE NADA
                    //                //lEstadoLectura = "PNE"; //Pieza No Existe
                    //                //listaDataSet.DataSet.Tables[0].Rows[0]["Estado1"] = lEstadoLectura;
                    //                //AgregaFila(listaDataSet);
                    //                ////MessageBox.Show("La etiqueta '" + txtEtiquetaPieza.Text + "' no existe.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //                mPiezasError = string.Concat(mPiezasError, "|", txtEtiquetaPieza.Text, "-", "PNE");
                    //            }
                    //            else
                    //            {
                    //                //validamos el codigo del viaje                                
                    //                if (PiezaEstaEnViajesSeleccionados(listaDataSet.DataSet.Tables[0].Copy()) == false)
                    //                {
                    //                    //MessageBox.Show(" La Pieza no corresponde al viaje seleccionado, la pieza Corresponde al Viaje " + listaDataSet.DataSet.Tables[0].Rows[0]["Codigo"].ToString(), "Validaciones Sistema ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //                    lEstadoLectura = "PNV"; //Pieza No es del Viaje
                    //                    listaDataSet.DataSet.Tables[0].Rows[0]["Estado1"] = lEstadoLectura;
                    //                    lColorsel = Color.LightSalmon;
                    //                }
                    //                else
                    //                {  // la pieza leida siempre deberia existir en la grilla
                    //                    lVista=new DataView (

                    //                    if (dgvEtiquetasPiezas.DataSource == null)
                    //                    {
                    //                        dgvEtiquetasPiezas.DataSource = listaDataSet.DataSet.Tables[0];
                    //                        OcultaColumnas();
                    //                    }
                    //                    else
                    //                    {
                    //                        AgregaFila(listaDataSet);
                    //                    }




                    //                    lEstadoLectura = "POK"; //Pieza Esta OK
                    //                    listaDataSet.DataSet.Tables[0].Rows[0]["Estado1"] = lEstadoLectura;
                    //                    lColorsel = Color.LightGreen;
                    //                }


                    //                mTotalKgsCargado = mTotalKgsCargado + Convert.ToDouble(listaDataSet.DataSet.Tables[0].Rows[0]["KgsPaquete"].ToString());
                    //                mKgsPorCargar = Convert.ToDouble(Lbl_TotalKgs.Text) - mTotalKgsCargado;

                    //                mTotalPiezasCargado = mTotalPiezasCargado + Convert.ToDouble(listaDataSet.DataSet.Tables[0].Rows[0]["NroPiezas"].ToString());
                    //                this.mPiezasPorCargar = Convert.ToDouble(this.Lbl_NroPiezas.Text) - mTotalPiezasCargado;

                    //                mTotalPaqCargado = mTotalPaqCargado + 1;
                    //                mPaqPorCargar = int.Parse(this.Lbl_TotalPaq.Text) - mTotalPaqCargado;

                    //                //tlbNuevo.PerformClick();
                    //                //Forms forms = new Forms();
                    //                forms.dataGridViewHideColumns(dgvEtiquetasPiezas, new string[] { "CAMION", "OBRA_DESTINO", "CAM_USUARIO", "CAM_FECHA", "CAM_OBSERVACION", "CAM_USUARIO_VB", "CAM_FECHA_VB", "CAM_OBSERVACION_VB", "PIE_ESTADO", "DES_ACO_ID", "DES_CAM_ID" });
                    //                forms.dataGridViewAutoSizeColumnsMode(dgvEtiquetasPiezas, DataGridViewAutoSizeColumnsMode.DisplayedCells);
                    //                //tlbEstado.Text = "Registro(s): " + dgvRecepciones.Rows.Count;
                    //                lblCantidadEtiquetasPiezas.Text = "Registro(s): " + dgvEtiquetasPiezas.Rows.Count;

                    //                //}
                    //            }

                    //        }
                    //        else
                    //        {
                    //            mPiezasError = string.Concat(mPiezasError, "|", txtEtiquetaPieza.Text, "-", "EWS");
                    //            //lEstadoLectura = "EWS"; //Web Service Responde Error
                    //            //MessageBox.Show(listaDataSet.MensajeError.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); 
                    //        }
                    //    }
                    //    catch (Exception exc)
                    //    {
                    //        MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    }
                    //    Cursor.Current = Cursors.Default;
                    //}
                    //else
                    //{

                    //}
                    //txtEtiquetaPieza.Clear();
                    //txtEtiquetaPieza.Focus();
            lbl_TotalKgsCar.Text = Math.Round(mTotalKgsCargado, 0).ToString();
            this.Lbl_PiezasPorCar.Text = Math.Round(mPiezasPorCargar, 0).ToString();
            this.Lbl_KilosPorCar.Text = Math.Round(mKgsPorCargar, 0).ToString();
            lbl_TotalPaqCar.Text = mTotalPaqCargado.ToString();
            Lbl_PaqPorCar.Text = mPaqPorCargar.ToString();
            lbl_NroPiezasCar.Text = mTotalPiezasCargado.ToString();
            //mPaqPorCargar = 0;         mTotalPiezasCargado = 0;
                    //ActualizaColoresGrilla();
        
        }

        private void PosicionaEnFila(string iEtiquetaPieza)
        {
          int i = 0;
          for (i = 0; i < dgvEtiquetasPiezas.RowCount; i++)
          {
              if (dgvEtiquetasPiezas.Rows[i].Cells["ETIQUETA_PIEZA"].Value.ToString().Equals(iEtiquetaPieza))
              { 
              dgvEtiquetasPiezas.Rows [i].Selected =true ;
              //dgvEtiquetasPiezas.CurrentCell = dgvEtiquetasPiezas.Rows[i].Cells["ETIQUETA_PIEZA"];
              dgvEtiquetasPiezas.CurrentCell = dgvEtiquetasPiezas.Rows[i].Cells["IMAGEN"];                
              }
          }       
        
        }

        private void txtEtiquetaPieza_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtEtiquetaPieza.Text.Trim().Length > 0)
            {
                ProcesaEtiqueta();
            }
        }

          private void ProcesaEtiqueta()
          {
                 LeePiezaCargada(txtEtiquetaPieza.Text);
                ActualizaColoresGrilla();
                CalculaTotales();
                txtEtiquetaPieza.Text = "";
                PosicionaEnFila(txtEtiquetaPieza.Text);
            CalculaTotales();
            txtEtiquetaPieza.Focus();
          }
          
        

        private void OcultaColumnas()
            {
                dgvEtiquetasPiezas.Columns["IdViaje2"].Visible = false;
                dgvEtiquetasPiezas.Columns["UserCrea"].Visible = false;
                dgvEtiquetasPiezas.Columns["KgsPaquete"].Visible = false;
                dgvEtiquetasPiezas.Columns["Etiqueta"].Visible = false;
                dgvEtiquetasPiezas.Columns["Obs"].Visible = false;
                dgvEtiquetasPiezas.Columns["NroGuiaInet"].Visible = false;
                dgvEtiquetasPiezas.Columns["IdMov"].Visible = false;
                dgvEtiquetasPiezas.Columns["IdViaje"].Visible = false;
                dgvEtiquetasPiezas.Columns["Id"].Visible = false;
                dgvEtiquetasPiezas.Columns["TotalKgs"].Visible = false;
                dgvEtiquetasPiezas.Columns["NroLaminas"].Visible = false;
                dgvEtiquetasPiezas.Columns["NroDespacho"].Visible = false;
                dgvEtiquetasPiezas.Columns["FechaViaje"].Visible = false;
                dgvEtiquetasPiezas.Columns["IdIt"].Visible = false;
                dgvEtiquetasPiezas.Columns["Id1"].Visible = false;
                dgvEtiquetasPiezas.Columns["IdViaje1"].Visible = false;
                dgvEtiquetasPiezas.Columns["FechaRegistro"].Visible = false;
                dgvEtiquetasPiezas.Columns["FechaMod"].Visible = false;

                dgvEtiquetasPiezas.Columns["PesoRomana"].Visible = false;
                dgvEtiquetasPiezas.Columns["IdRespuestaInet"].Visible = false;
                dgvEtiquetasPiezas.Columns["Patente"].Visible = false;
                dgvEtiquetasPiezas.Columns["IdDespachoCamion"].Visible = false;
            dgvEtiquetasPiezas.Columns["NoVa"].Visible = false;

            dgvEtiquetasPiezas.Columns["Diametro"].Width = 50;
                dgvEtiquetasPiezas.Columns["Codigo"].Width = 60;
                dgvEtiquetasPiezas.Columns["Estado"].Width = 50;
                dgvEtiquetasPiezas.Columns["NroPaq"].Width = 50;
                dgvEtiquetasPiezas.Columns["IdPieza"].Width = 50;
                dgvEtiquetasPiezas.Columns["TotalPaq"].Width = 60;
                dgvEtiquetasPiezas.Columns["NroPiezas"].Width = 60;
                dgvEtiquetasPiezas.Columns["Estado2"].Width = 60;
                dgvEtiquetasPiezas.Columns["Estado1"].Width = 55;
                dgvEtiquetasPiezas.Columns["KgsPaquete1"].Width = 60;
                dgvEtiquetasPiezas.Columns["imagen"].Width = 180;

                int i = 0;
                for (i=0;i<dgvEtiquetasPiezas.RowCount ;i++)
                {
                    dgvEtiquetasPiezas.Rows[i].Height = 100; 
                }

            }
        private void OcultaColumnas_V2()
        {
          // dgvEtiquetasPiezas.Columns["Ubicacion"].Visible = false;
          //  dgvEtiquetasPiezas.Columns["Id"].Visible = false;
          //  dgvEtiquetasPiezas.Columns["ValoresVar"].Visible = false;
          //  dgvEtiquetasPiezas.Columns["FiguraB"].Visible = false;
          //  dgvEtiquetasPiezas.Columns["PiezasXEtiq"].Visible = false;
          //  //dgvEtiquetasPiezas.Columns["NroPaquetes"].Visible = false;
          //  dgvEtiquetasPiezas.Columns["Obra"].Visible = false;
          //  dgvEtiquetasPiezas.Columns["figura"].Visible = false;
          //  dgvEtiquetasPiezas.Columns["Nivel"].Visible = false;
          //  dgvEtiquetasPiezas.Columns["Elemento"].Visible = false;
          //  dgvEtiquetasPiezas.Columns["Plano"].Visible = false;



        }



        private void CalculaTotales()
        {
            int i = 0; double lKilosCargados = 0; double lPiezasCargadas = 0; int lPaquetesCargados = 0;
            string lViajes = ""; DataTable mTblResumenDespacho = new DataTable(); string[] lPartes = null;
            DataTable lTblDatos = new DataTable(); int k = 0; DataView lVista = null; string lCodigo = "";
            string lWheres = ""; DataRow lFila = null; Clases.ClsComun lCom = new Clases.ClsComun();
            double lKilosDesa = 0; double lKilosViaje = 0; double lPiezasViaje = 0;double lAvance = 0;
            double lKilosNoVa = 0;
            try
            {

                for (i = 0; i < dgvEtiquetasPiezas.RowCount; i++)
                {
                    if (lViajes.IndexOf(dgvEtiquetasPiezas.Rows[i].Cells["Codigo"].Value.ToString()) == -1)
                    {
                        lViajes = string.Concat(dgvEtiquetasPiezas.Rows[i].Cells["Codigo"].Value.ToString(), "|", lViajes);
                    }
                }

                mTblResumenDespacho.Columns.Add("Viaje", Type.GetType("System.String"));
                mTblResumenDespacho.Columns.Add("Nro.Piezas", Type.GetType("System.String"));
                mTblResumenDespacho.Columns.Add("Kgs. Teorico", Type.GetType("System.String"));
                mTblResumenDespacho.Columns.Add("Kgs. Desa", Type.GetType("System.String"));
                mTblResumenDespacho.Columns.Add("Kgs. Cargados", Type.GetType("System.String"));
                mTblResumenDespacho.Columns.Add("Kgs. NoVa", Type.GetType("System.String"));
                mTblResumenDespacho.Columns.Add("Avance", Type.GetType("System.String"));
                mTblResumenDespacho.Columns.Add("KgsXCargar", Type.GetType("System.String"));

                lTblDatos = (DataTable)dgvEtiquetasPiezas.DataSource;
                lPartes = lViajes.Split(new Char[] { '|' });
                for (i = 0; i < lPartes.Length; i++)
                {
                    if (lPartes[i].ToString().Length > 0)
                    {
                        lCodigo = lPartes[i].ToString();
                        lWheres = string.Concat("Codigo='", lCodigo, "'");
                        lPiezasCargadas = 0; lPaquetesCargados = 0; lKilosDesa = 0; lKilosViaje = 0; lPiezasViaje = 0;
                        lVista = new DataView(lTblDatos, lWheres, "", DataViewRowState.CurrentRows);
                        {
                            lKilosCargados = 0; lPiezasCargadas = 0;
                            for (k = 0; k < lVista.Count; k++)
                            {
                                lPiezasViaje = lPiezasViaje + lCom.Val(lVista[k]["NroPiezas"].ToString());
                                lKilosViaje = lKilosViaje + lCom.Val(lVista[k]["KgsPaquete1"].ToString());
                                lKilosDesa = lKilosDesa + lCom.Val(lVista[k]["KgsReales"].ToString());
                                if (lVista[k]["Estado1"].ToString().Equals("POK") || lVista[k]["Estado2"].ToString().Equals("O60"))
                                {
                                    lKilosCargados = lKilosCargados + int.Parse(lVista[k]["KgsPaquete1"].ToString());
                                    lPiezasCargadas = lPiezasCargadas + int.Parse(lVista[k]["NroPiezas"].ToString());
                                }
                                if (lVista[k]["NoVa"].ToString().ToUpper ().Equals ("S"))
                                {
                                    lKilosNoVa= lKilosNoVa+ lCom.Val(lVista[k]["KgsPaquete1"].ToString());
                                }
                                
                            }
                            //  lPesoGuia = lPbascula.ToString("N0");
                            lFila = mTblResumenDespacho.NewRow();
                            lFila["Viaje"] = lCodigo;
                            lFila["Nro.Piezas"] = lPiezasViaje;
                            lFila["Kgs. Teorico"] = lKilosViaje;
                            lFila["Kgs. Desa"] = lKilosDesa;
                            lFila["Kgs. Cargados"] = lKilosCargados;
                            lAvance = Math.Round((lKilosCargados / lKilosViaje) * 100, 2);
                            lFila["Avance"] = lAvance;
                            lAvance = lKilosViaje - lKilosCargados- lKilosNoVa;
                            lFila["KgsXCargar"] = lAvance;
                            lFila["Kgs. NoVa"] = lKilosNoVa;
                            mTblResumenDespacho.Rows.Add(lFila);
                        }
                    }
                }
                double lTotalDesa = 0; double lTotlaKilosViaje = 0; double lTotalPiezasViaje = 0; double lTotalKgsCargados = 0;
                double lTotal_NOVA = 0;
                for (i = 0; i < mTblResumenDespacho.Rows.Count; i++)
                {
                    lTotlaKilosViaje = lCom.Val(mTblResumenDespacho.Rows[i]["Kgs. Teorico"].ToString()) + lTotlaKilosViaje;
                    lTotalDesa = lCom.Val(mTblResumenDespacho.Rows[i]["Kgs. Desa"].ToString()) + lTotalDesa;

                    lTotalPiezasViaje = lCom.Val(mTblResumenDespacho.Rows[i]["Nro.Piezas"].ToString()) + lTotalPiezasViaje;
                    lTotalKgsCargados = lCom.Val(mTblResumenDespacho.Rows[i]["Kgs. Cargados"].ToString()) + lTotalKgsCargados;

                    lTotal_NOVA= lCom.Val(mTblResumenDespacho.Rows[i]["Kgs. NoVa"].ToString()) + lTotal_NOVA;
                }

                lFila = mTblResumenDespacho.NewRow();
                lFila["Viaje"] = "Totales:";
                lFila["Nro.Piezas"] = lTotalPiezasViaje;
                lFila["Kgs. Teorico"] = lTotlaKilosViaje;//.ToString("N0");
                lFila["Kgs. Desa"] = lTotalDesa;//.ToString("N0");
                lFila["Kgs. Cargados"] = lTotalKgsCargados;//.ToString("N0");
                lFila["Avance"] = "";
                lAvance = Math.Round((lTotalKgsCargados / lTotlaKilosViaje) * 100, 2);
                lFila["Avance"] = lAvance;
                lAvance = lTotlaKilosViaje - lTotalKgsCargados- lTotal_NOVA;
                lFila["KgsXCargar"] = lAvance;//.ToString("N0");
                lFila["Kgs. NoVa"] = lTotal_NOVA;

                mTblResumenDespacho.Rows.Add(lFila);

                Dtg_ResumenCarga.DataSource = mTblResumenDespacho;
                FormateaGrilla();

                Lbl_TotalKgs.Text = lTotlaKilosViaje.ToString ();
                lbl_TotalKgsCar.Text = lTotalKgsCargados.ToString();
                Lbl_TotalPaq.Text = lTotalPiezasViaje.ToString();
                lbl_TotalPaqCar.Text = "0";

                //tlbEstado.Text = "Registro(s): " + dgvRecepciones.Rows.Count;
                lblCantidadEtiquetasPiezas.Text = "Regstro(s): " + lPaquetesCargados.ToString();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void FormateaGrilla()
        {
            Dtg_ResumenCarga.Columns["Viaje"].Width = 60;

            Dtg_ResumenCarga.Columns["Nro.Piezas"].Width = 60;
            Dtg_ResumenCarga.Columns["Nro.Piezas"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            Dtg_ResumenCarga.Columns["Kgs. Teorico"].Width = 60;
            //Dtg_ResumenCarga.Columns["Kgs. Teorico"].DefaultCellStyle.Format = "N0";
            Dtg_ResumenCarga.Columns["Kgs. Teorico"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            Dtg_ResumenCarga.Columns["Kgs. Desa"].Width = 60;
            Dtg_ResumenCarga.Columns["Kgs. Desa"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            Dtg_ResumenCarga.Columns["Kgs. Cargados"].Width = 60;
            Dtg_ResumenCarga.Columns["Kgs. Cargados"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            Dtg_ResumenCarga.Columns["Avance"].Width = 50;
            Dtg_ResumenCarga.Columns["Avance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            Dtg_ResumenCarga.Columns["KgsXCargar"].Width = 70;
            Dtg_ResumenCarga.Columns["KgsXCargar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            Dtg_ResumenCarga.Columns["Kgs. NoVa"].Width = 70;
            Dtg_ResumenCarga.Columns["Kgs. NoVa"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            Dtg_ResumenCarga.RowHeadersVisible = false;
            int i = 0;int XCArgar = 0; int Cargado = 0;

            for (i = 0; i < Dtg_ResumenCarga.RowCount; i++)
            {
                XCArgar = int.Parse(Dtg_ResumenCarga.Rows[i].Cells["KgsXCargar"].Value.ToString());
                Cargado= int.Parse(Dtg_ResumenCarga.Rows[i].Cells["Kgs. Cargados"].Value.ToString());
                if (XCArgar == 0)
                    Dtg_ResumenCarga.Rows[i].Cells["KgsXCargar"].Style.BackColor = Color.LightGreen;
                else
                {
                    if (XCArgar == Cargado)
                        Dtg_ResumenCarga.Rows[i].Cells["KgsXCargar"].Style.BackColor = Color.Yellow ;
                    else
                    { Dtg_ResumenCarga.Rows[i].Cells["KgsXCargar"].Style.BackColor = Color.LightSalmon ; }
                }

            }

            //Dtg_ResumenCarga.Rows[Dtg_ResumenCarga.Rows.Count - 1].Cells[1].Style.BackColor = Color.LightSalmon;


            //dgv.Columns[columnIndex].DefaultCellStyle.Format = "N0"
        }
        private void ActualizaColoresGrilla()
        {
            int i = 0;
            this.tlbGuardar.Enabled = true;
            for (i = 0; i < dgvEtiquetasPiezas.RowCount; i++)
            {
                switch (dgvEtiquetasPiezas.Rows[i].Cells["Estado1"].Value.ToString().Trim().ToUpper())
                {
                    case "PNV":  //Pieza no es del viaje
                        PintaFila(i, Color.LightSalmon);
                        //' Dtg_Resultado.Rows[i].Cells["Codigo"].Style.BackColor = Color.LightSalmon;
                        break;
                    case "POK":  //Pieza OK
                        PintaFila(i, Color.LightGreen);
                        //Dtg_Resultado.Rows[i].Cells["Codigo"].Style.BackColor = Color.LightGreen;
                        break;
                    case "":
                        PintaFila(i, Color.Yellow );
                        if (tlbGuardar.Enabled == true)
                                this.tlbGuardar.Enabled = true;

                        break;
                    }

                //para cuando el viaje esta despachado
                switch (dgvEtiquetasPiezas.Rows[i].Cells["Estado2"].Value.ToString().Trim().ToUpper())
                {
                    case "O60": 
                        PintaFila(i, Color.LightGreen);
                        //' Dtg_Resultado.Rows[i].Cells["Codigo"].Style.BackColor = Color.LightSalmon;
                        this.tlbGuardar.Enabled = false;
                        break;
                    
                }
                //Cuando el un Va pero No Va se debe indicar en campo Estado2
                if (dgvEtiquetasPiezas.Rows[i].Cells["NoVa"].Value.ToString().ToUpper().Equals("S"))
                {
                    dgvEtiquetasPiezas.Rows[i].Cells["Etiqueta_Colada"].Style.BackColor = Color.Red   ;
                }
            }
        }

        private void PintaFila(int IndexFila, Color iColorFila)
        {
            int i = 0;
            for (i = 0; i < dgvEtiquetasPiezas.ColumnCount; i++)
            {
                dgvEtiquetasPiezas.Rows[IndexFila].Cells[i].Style.BackColor = iColorFila;

            }
        }

        private void btnCrudCamion_Click(object sender, EventArgs e)
        {
            new frmCrudCamion().ShowDialog();
            txtPatente.Focus();
        }

        private void txtCamion_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!txtPatente.Text.Trim().Equals(""))
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    lblTransportista.Text = ".";

                    if (ValidaPatente(txtPatente.Text) == false)
                    {
                        e.Cancel = true;
                    }
                       
                    
                    //WsCrud.CrudSoapClient wsCrud = new WsCrud.CrudSoapClient();
                    //WsCrud.Camion camion = new WsCrud.Camion();

                        //camion = wsCrud.ObtenerCamion(txtPatente.Text); //Patente
                        //if (camion.MensajeError.Equals(""))
                        //{
                        //    if (camion.Activo.Equals("S"))
                        //        lblTransportista.Text = camion.Transportista;
                        //    else
                        //    {
                        //        MessageBox.Show("El camión '" + txtPatente.Text + "' no existe o esta inactivo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //        e.Cancel = true;
                        //    }
                        //}
                        //else
                        //{
                        //    MessageBox.Show(camion.MensajeError.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //    e.Cancel = true;
                        //}
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Cursor.Current = Cursors.Default;
            }
        }

        private void txtPatente_Leave(object sender, EventArgs e)
        {
            txtPatente.Text = eliminarCaracteresEspeciales(txtPatente.Text.Trim()).ToUpper();;
        }

        private void frmDespachoCamion_Load(object sender, EventArgs e)
        {
            try
            {
                //Px_Ws_InterfazProd.Ws_InterfazProdSoapClient ldal = new Px_Ws_InterfazProd.Ws_InterfazProdSoapClient();
                //DataSet lDts = ldal.ObtenerTodasObrasVigentes();
                //DataTable dt = lDts.Tables[0];
                DataTable lTbl = new DataTable(); DataRow lFila;

                //WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
                //WsOperacion.ListaDataSet listaDataSet = new WsOperacion.ListaDataSet();
                //listaDataSet = wsOperacion.ObtenerTodasObrasVigentes();
                lTbl = CargaTablaObras( );

                //if (listaDataSet.MensajeError.Equals(""))
                if (lTbl .Rows .Count >0)
                {
                    lFila = lTbl.NewRow();
                    lFila["Id"] = 0; lFila["Obra"] = "Seleccionar";
                    lTbl.Rows.Add(lFila);
                    //lTbl = CargaTablaObras(listaDataSet.DataSet.Tables[0]);
                    //new Forms().comboBoxFill(cboObraDestino, listaDataSet.DataSet.Tables[0], "Id", "Obra", 0);
                    new Forms().comboBoxFill(cboObraDestino, lTbl, "Id", "Obra", 0);
                    cboObraDestino.SelectedIndex = lTbl.Rows.Count - 1;
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidaPatente(string iPatente)
        {
            WsCrud.CrudSoapClient wsCrud = new WsCrud.CrudSoapClient();
            WsCrud.Camion camion = new WsCrud.Camion();
            bool lRes = true;
            camion = wsCrud.ObtenerCamion(iPatente); //Patente
            if (camion.MensajeError.Equals(""))
            {
                if (camion.Activo.Equals("S"))
                    lblTransportista.Text = camion.Transportista;
                else
                {
                    MessageBox.Show("El camión '" + iPatente + "' no existe o esta inactivo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lRes=false ;
                }
            }
            else
            {
                MessageBox.Show(camion.MensajeError.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                lRes=false ;
            }


            return lRes;
        }

        private DataTable CargaTablaObras( )
        {
            string lTipoDespacho =   ConfigurationManager.AppSettings["MultiDespacho"].ToString();
            Clases.ClsComun lcom = new Clases.ClsComun();DataTable lTbl = new DataTable();

            if (lTipoDespacho == "S")
            {
                Gr_empresa.Visible = true;

                if (Rb_TO.Checked == true)
                    lTbl = lcom.CargaTablaObras("TO");

                if (RB_TOSOL.Checked == true)
                    lTbl = lcom.CargaTablaObras("TOSOL");
            }
            else
            {
                Gr_empresa.Visible = false;
                lTbl = lcom.CargaTablaObrasPorUsuario(mUserLog .Iduser .ToString ());
            }

            return lTbl;


        }

        private bool RevisaBloqueosObra(string iIdObra)
        {
            // Al momento de Seleccionar una  obra se debe verificar si tiene bloqueo
            //1.- bloqueo por Reglas de negocio
            //2.- Bloqueo si la obra esta en Pre - Alta

            bool lRes = true; string lSql = ""; string lMsg = ""; DataTable lTbl = new DataTable();
                WsCrud.CrudSoapClient lDAl = new WsCrud.CrudSoapClient();
            WsCrud.ListaDataSet listaDataSet = new WsCrud.ListaDataSet();   
            //  ALTER PROCEDURE [dbo].[SP_Consultas_WS]
            //@Opcion INT,              //@Par1 Varchar(100),       //@Par2 Varchar(100),    //@Par3 Varchar(150),
            //@Par4 Varchar(100),       //@Par5 Varchar(100),       //@Par6 Varchar(100),    //@Par7 Varchar(100)

            Btn_SelViajes.Enabled = true ;
            this.tlbGuardar.Enabled = true;
            lSql = string.Concat (" exec SP_Consultas_WS   46,'",iIdObra,"','','','','','',''");            
                listaDataSet = lDAl.ListarAyudaSql(lSql) ;  //ObtenerResumanPiezasPorViaje(lCodigo);
                if (listaDataSet.MensajeError.Equals(""))
                {
                    if (listaDataSet.DataSet.Tables.Count > 0)
                    {
                        lTbl = listaDataSet.DataSet.Tables[0].Copy();
                        if (lTbl.Rows[0]["EstadoAlta"].ToString().ToUpper().Equals("PREALTA") == true)
                        {
                            lMsg = "NO se pueden realizar despachos, ya que la Obra Seleccionada se encuentra en estado PREALTA";
                            lRes = false;
                            Btn_SelViajes.Enabled = false;
                            this.tlbGuardar.Enabled = false ;
                        }
                        if (lTbl.Rows[0]["BloqueoRN"].ToString().ToUpper().Equals("S") == true)
                        {
                            lMsg = "NO se pueden realizar despachos, ya que la Obra Seleccionada esta bloqueada por Reglas de Negocio";
                            lRes = false;
                            Btn_SelViajes.Enabled = false;
                            this.tlbGuardar.Enabled = false;
                        }
                    }
                }
                else
                {
                    lMsg = listaDataSet.MensajeError;
                    lRes = false;
                }

                if (lMsg.Length > 0)
                {
                    MessageBox.Show(lMsg, "Avisos Sistema", MessageBoxButtons.OK);
                }

            return lRes;
        }

        private void cargaViaje(string iIdObra)
        {
            DataTable lTbl = new DataTable();
            WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
            WsOperacion.ListaDataSet listaDataSet = new WsOperacion.ListaDataSet();

            if (RevisaBloqueosObra(iIdObra) == true)
            {
                listaDataSet = wsOperacion.ObtenerViajesPorObra(iIdObra);
                if ((listaDataSet.MensajeError.Trim().Length == 0) && (listaDataSet.DataSet.Tables.Count > 0))
                {
                    lTbl = listaDataSet.DataSet.Tables[0].Copy();
                    new Forms().comboBoxFill(CmbViaje, listaDataSet.DataSet.Tables[0], "IdViaje", "Codigo", 0);
                }
            }
        }

        private DataTable  ObtenerTablaViajesPorObra (string iIdObra)
        {
            DataTable lTbl = new DataTable();
            WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
            WsOperacion.ListaDataSet listaDataSet = new WsOperacion.ListaDataSet();
            listaDataSet = wsOperacion.ObtenerViajesPorObra(iIdObra);
            if ((listaDataSet.MensajeError.Trim().Length == 0) && (listaDataSet.DataSet.Tables.Count > 0))
            {
                lTbl = listaDataSet.DataSet.Tables[0].Copy();                
            }
            return lTbl;

        }


       private void cboObraDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((cboObraDestino.SelectedValue != null) && (cboObraDestino.SelectedValue.ToString () !="0"))
            {
                cargaViaje(cboObraDestino.SelectedValue.ToString());
                txtObs.Focus();
            }
        }

        private void frmDespachoCamion_Shown(object sender, EventArgs e)
        {
            txtPatente.Focus();
        }

        private void txtObs_Leave(object sender, EventArgs e)
        {
            txtObs.Text = eliminarCaracteresEspeciales(txtObs.Text.Trim());
        }

        private void btnHlpCamion_Click(object sender, EventArgs e)
        {
            txtPatente_KeyUp(sender, new KeyEventArgs(Keys.F1));
        }

        private void txtPatente_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                CommonHelp.frmHelp frmHelp = new CommonHelp.frmHelp();
                frmHelp.setShowHelp("Busca: Camiones", "patente", txtPatente.Text, "Muestra un listado de los camiones activos.", "SELECT patente, transportista, observacion FROM vw_camion WHERE activo = 'S'", "");
                frmHelp.ShowDialog();
                if (frmHelp.getResultRow() != null)
                {
                    txtPatente.Text = frmHelp.getResultRow()[0].ToString();
                    lblTransportista.Text = frmHelp.getResultRow()[1].ToString();
                    cboObraDestino.Focus();
                }
                frmHelp.Dispose();
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void CmbViaje_SelectedIndexChanged(object sender, EventArgs e)
        {
           // string lCodViaje = ((System.Data.DataRowView)(CmbViaje.SelectedItem)).Row.ItemArray[2].ToString ();
           // CargaResumenPiezasViaje(lCodViaje);
        }

        private  void CargaResumenPiezasViaje(string  iCodViaje)
        {
            WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
            WsOperacion.ListaDataSet listaDataSet = new WsOperacion.ListaDataSet();
            Clases.ClsComun iCom = new Clases.ClsComun(); int i = 0;int k =0;
            int lNroPiezas = 0; int lTotalKgs = 0; int lTotalPaq = 0; string lCodigo = "";
            DataTable lTbl = new DataTable(); int lTmp =0;

            //Debemos invocar el metodo una vez por cada viaje,con cada resultado se hace un merge
            char[] delimiterChars = { ',', '\t' };
            char[] delimiterChars2 = { '|', '\t' };
            string[] words = iCodViaje.Split(delimiterChars);
            for (k = 0; k < words.Length ; k++)
 {
            //lCodigo = words[k].ToString(); lTmp =0;
            string[] words2 = words[k].Split(delimiterChars2);
            lCodigo = words2[0].ToString(); ; lTmp = 0;
            //obtenemos el resumen de las piezas por viaje
            listaDataSet = wsOperacion.ObtenerResumanPiezasPorViaje(lCodigo);
            if (listaDataSet.MensajeError.Equals(""))
            {
                if (listaDataSet.DataSet.Tables[0].Rows.Count > 0)
                {
                    lTbl = listaDataSet.DataSet.Tables[0].Copy();
                    lTmp = int.Parse(lTbl.Rows[1]["NroPiezas"].ToString());
                    if (lTbl.Rows[1]["Tipo"].ToString().Equals("O") && (lTmp > 0))
                    {                                                       
                        lNroPiezas = lNroPiezas + lTmp;
                        lTotalKgs = lTotalKgs + int.Parse(lTbl.Rows[1]["TotalKgs"].ToString());
                        lTotalPaq = lTotalPaq + int.Parse(lTbl.Rows[1]["NroPaquetes"].ToString());                                
                    } 
                    else
                    {
                        if (lTbl.Rows .Count >1) 
                            {
                                lNroPiezas = lNroPiezas + int.Parse(lTbl.Rows[0]["NroPiezas"].ToString()); ;
                                lTotalKgs = lTotalKgs + int.Parse(lTbl.Rows[0]["TotalKgs"].ToString());
                                lTotalPaq = lTotalPaq + int.Parse(lTbl.Rows[0]["NroPaquetes"].ToString());
                            } 
                    } 

                    Lbl_NroPiezas.Text = lNroPiezas.ToString();
                    Lbl_TotalKgs.Text = lTotalKgs.ToString();
                    Lbl_TotalPaq.Text = lTotalPaq.ToString ();
                }
            }
            else
            {
                MessageBox.Show(listaDataSet.MensajeError.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
 }
        }


        private void CargaResumenViajeDespachado(string iCodViaje)
        {
            WsCrud.CrudSoapClient  wsOperacion = new WsCrud.CrudSoapClient();
            WsCrud.ListaDataSet listaDataSet = new WsCrud.ListaDataSet();
            Clases.ClsComun iCom = new Clases.ClsComun(); int i = 0; int k = 0; string lSql = "";
            int lNroPiezas = 0; int lTotalKgs = 0; int lTotalPaq = 0; string lCodigo = "";

            //Debemos invocar el metodo una vez por cada viaje,con cada resultado se hace un merge
            char[] delimiterChars = { ',', '\t' };
            char[] delimiterChars2 = { '|', '\t' };
            string[] words = iCodViaje.Split(delimiterChars);
            for (k = 0; k < words.Length; k++)
            {
                string[] words2 = words[k].Split(delimiterChars2);
                lCodigo = words2[0].ToString();
                //obtenemos el resumen de las piezas por viaje
                lSql = string.Concat("exec SP_COnsultasgenerales 23,", lCodigo, ",'','','',''");
                listaDataSet = wsOperacion.ListarAyudaSql(lSql);  //ObtenerResumanPiezasPorViaje(lCodigo);
                if (listaDataSet.MensajeError.Equals(""))
                {
                    if (listaDataSet.DataSet.Tables[0].Rows.Count > 0)
                    {
                        for (i = 0; i < listaDataSet.DataSet.Tables[0].Rows.Count; i++)
                        {
                            if (listaDataSet.DataSet.Tables[0].Rows[i]["NroPiezas"].ToString().Length > 0)
                                lNroPiezas = lNroPiezas + int.Parse(listaDataSet.DataSet.Tables[0].Rows[i]["NroPiezas"].ToString());

                            if (listaDataSet.DataSet.Tables[0].Rows[i]["Kilos"].ToString().Length > 0)
                                lTotalKgs = lTotalKgs + int.Parse(listaDataSet.DataSet.Tables[0].Rows[i]["Kilos"].ToString());

                            if (listaDataSet.DataSet.Tables[0].Rows[i]["NroEtiquetas"].ToString().Length > 0)
                                lTotalPaq = lTotalPaq + int.Parse(listaDataSet.DataSet.Tables[0].Rows[i]["NroEtiquetas"].ToString());

                        }
                        this.tlbGuardar.Enabled = false;
                    }
                }
                else
                {
                    MessageBox.Show(listaDataSet.MensajeError.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                lbl_NroPiezasCar.Text = lNroPiezas.ToString();
                lbl_TotalKgsCar.Text = lTotalKgs.ToString();
                lbl_TotalPaqCar.Text = lTotalPaq.ToString();
            }
        }

        private void CargaDatosCamion(string IdDespCamion)
        {
            //WsCrud.CrudSoapClient wsOperacion = new WsCrud.CrudSoapClient();
            //WsCrud.ListaDataSet listaDataSet = new WsCrud.ListaDataSet();
            //Clases.ClsComun iCom = new Clases.ClsComun(); int i = 0; int k = 0; string lSql = "";
            //int lNroPiezas = 0; int lTotalKgs = 0; int lTotalPaq = 0; string lCodigo = "";

            ////Debemos invocar el metodo una vez por cada viaje,con cada resultado se hace un merge
            //char[] delimiterChars = { ',', '\t' };
            //string[] words = iCodViaje.Split(delimiterChars);
            //for (k = 0; k < words.Length; k++)
            //{
            //    lCodigo = words[k].ToString();
            //    //obtenemos el resumen de las piezas por viaje
            //    lSql = string.Concat("exec SP_COnsultasgenerales 23,", iCodViaje, ",'','','',''");
            //    listaDataSet = wsOperacion.ListarAyudaSql(lSql);  //ObtenerResumanPiezasPorViaje(lCodigo);
            //    if (listaDataSet.MensajeError.Equals(""))
            //    {
            //        if (listaDataSet.DataSet.Tables[0].Rows.Count > 0)
            //        {
            //            for (i = 0; i < listaDataSet.DataSet.Tables[0].Rows.Count; i++)
            //            {
            //                if (listaDataSet.DataSet.Tables[0].Rows[i]["NroPiezas"].ToString().Length > 0)
            //                    lNroPiezas = lNroPiezas + int.Parse(listaDataSet.DataSet.Tables[0].Rows[i]["NroPiezas"].ToString());

            //                if (listaDataSet.DataSet.Tables[0].Rows[i]["Kilos"].ToString().Length > 0)
            //                    lTotalKgs = lTotalKgs + int.Parse(listaDataSet.DataSet.Tables[0].Rows[i]["Kilos"].ToString());

            //                if (listaDataSet.DataSet.Tables[0].Rows[i]["NroEtiquetas"].ToString().Length > 0)
            //                    lTotalPaq = lTotalPaq + int.Parse(listaDataSet.DataSet.Tables[0].Rows[i]["NroEtiquetas"].ToString());

            //            }
            //            this.tlbGuardar.Enabled = false;
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show(listaDataSet.MensajeError.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //    lbl_NroPiezasCar.Text = lNroPiezas.ToString();
            //    lbl_TotalKgsCar.Text = lTotalKgs.ToString();
            //    lbl_TotalPaqCar.Text = lTotalPaq.ToString();
            //}
        }

        DataTable AsociaEtiqueta_Pieza(DataTable iTbl, Ws_TO.PiezaTipoB[] lLista)
        {
            int i = 0; int j = 0; int lIdPaquete = 0;
            try
                {
                iTbl.Columns.Add("Imagen", System.Type.GetType("System.Byte[]"));
                iTbl.Columns.Add("NoVa", System.Type.GetType("System.String"));
                for (i = 0; i < iTbl.Rows .Count  ; i++)
            {
                lIdPaquete = int.Parse (iTbl.Rows[i]["ETIQUETA_PIEZA"].ToString ());
                for (j = 0; j < lLista.Length ; j++)
                {
                    if (lIdPaquete==lLista [j].IdDetallePieza)
                        {
                            iTbl.Rows[i]["ETIQUETA_COLADA"] = lLista[j].EtiquetaLateral ;
                            iTbl.Rows[i]["Imagen"] = lLista[j].Imagen ;
                            iTbl.Rows[i]["NoVa"] = lLista[j].EsVaPero_NoVa;
                            break;
                        } 
                } 
            }
            }
            catch (Exception exc)
            {
                MessageBox.Show(String.Concat ("Ha Ocurrido el siguiente error: ",exc.Message.ToString ()), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);           
            } 
            return iTbl;
        }

        private Ws_TO.PiezaTipoB[]  ObtenerObj(string iCodViaje, string iIdIt)
            {
                Ws_TO.PiezaTipoB[] lLista; int lCorr = 0; Clases.ClsComun lCn = new Clases.ClsComun();
                Ws_TO.Ws_ToSoapClient WsTo = new Ws_TO.Ws_ToSoapClient(); string lSQl = "";
                char[] delimiterChars2 = { '/', '\t' }; DataSet lDts = new DataSet();
                string[] words = iCodViaje.Split(delimiterChars2); string lViajeBuscar = ""; string lIt = "";
                lLista = new Ws_TO.PiezaTipoB[0];
            if (words .Length >0)
            {
                if (lCn.EsNumero(words[1].ToString ()))
                {
                    lCorr = lCn.Val(words[1].ToString());
                    if (lCorr >1)
                    {
                        lViajeBuscar = string.Concat(words[0].ToString(), "/1");
                        lSQl = string.Concat ("exec SP_Consultas_WS 29,'" , lViajeBuscar  , "','','','','','',''");                       
                        lDts = WsTo.ObtenerDatos(lSQl); 
                        if ((lDts.Tables .Count >0) && (lDts.Tables[0].Rows .Count >0  ))
                            {
                                lIt = lDts.Tables[0].Rows[0]["IdIt"].ToString();
                                lLista = WsTo.ObtenerPiezas_BELTECH(lViajeBuscar, lIt);                
                            } 
                    }
                    else
                    {
                        lLista = WsTo.ObtenerPiezas_BELTECH(iCodViaje, iIdIt);                
                    } 
                } 

            } 
             
              return lLista;
            } 

        private void CargaGrillaPiezasViajeDespachado_V2(string iCodViaje)
        {
            WsCrud.CrudSoapClient wsOperacion = new WsCrud.CrudSoapClient();
            //Ws_TO.Ws_ToSoapClient WsTo = new Ws_TO.Ws_ToSoapClient();
            WsCrud.ListaDataSet listaDataSet = new WsCrud.ListaDataSet();
            Clases.ClsComun iCom = new Clases.ClsComun(); int i = 0; int k = 0;
            int lNroPiezas = 0; int lTotalKgs = 0; int lTotalPaq = 0; string lCodigo = "";
            string lSql = ""; string lCodigoLista = "";
            Ws_TO.PiezaTipoB[] lLista; DataTable lTblTmp = new DataTable();
            string lIdIt = "";
            // List(Of PiezaTipoB)

            //Debemos invocar el metodo una vez por cada viaje,con cada resultado se hace un merge
            char[] delimiterChars = { ',', '\t' };
            char[] delimiterChars2 = { '|', '\t' };
            string[] words = iCodViaje.Split(delimiterChars);
            for (k = 0; k < words.Length; k++)
            {
                string[] words2 = words[k].Split(delimiterChars2);
                //lCodigo = words[k].ToString();
                lCodigo = words2[0].ToString();//.Replace ("'","");
                lCodigoLista = words2[0].ToString().Replace ("'","");
                lIdIt = words2[1].ToString();
                //obtenemos el resumen de las piezas por viaje
                lSql = string .Concat (" EXEC SP_PIEZA_PRODUCCION '','','', 0, 0, 0, '','',",lCodigo ,",'','',9");


                lLista = ObtenerObj(lCodigoLista, lIdIt);                
                //lLista = WsTo.ObtenerPiezas_BELTECH(lCodigoLista, lIdIt);                
                listaDataSet = wsOperacion.ListarAyudaSql(lSql);
                if (listaDataSet.MensajeError.Equals(""))
                {
                    if (listaDataSet.DataSet.Tables[0].Rows.Count > 0)
                    {
                        if (dgvEtiquetasPiezas.DataSource == null)
                        {
                            //dgvEtiquetasPiezas.DataSource = lLista;
                            //OcultaColumnas_V2();
                            lTblTmp = AsociaEtiqueta_Pieza(listaDataSet.DataSet.Tables[0], lLista);
                            dgvEtiquetasPiezas.DataSource = lTblTmp;
                            OcultaColumnas();
                        }
                        else
                        {
                            lTblTmp.Merge( AsociaEtiqueta_Pieza(listaDataSet.DataSet.Tables[0], lLista));
                            //AgregaFila(listaDataSet);
                            dgvEtiquetasPiezas.DataSource = lTblTmp;
                        }
                    }
                }
                else
                {
                    MessageBox.Show(listaDataSet.MensajeError.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                lbl_NroPiezasCar.Text = lNroPiezas.ToString();
                lbl_TotalKgsCar.Text = lTotalKgs.ToString();
                lbl_TotalPaqCar.Text = lTotalPaq.ToString();
            }
            
            for (i = 0; i < dgvEtiquetasPiezas.RowCount; i++)
            {
                dgvEtiquetasPiezas.Rows[i].Height = 100;
            }
        }

        private void CargaGrillaPiezasViajeDespachado(string iCodViaje)
        {
            WsCrud.CrudSoapClient wsOperacion = new WsCrud.CrudSoapClient();
            WsCrud.ListaDataSet listaDataSet = new WsCrud.ListaDataSet();
            Clases.ClsComun iCom = new Clases.ClsComun(); int i = 0; int k = 0;
            int lNroPiezas = 0; int lTotalKgs = 0; int lTotalPaq = 0; string lCodigo = "";
            string lSql = "";

            //Debemos invocar el metodo una vez por cada viaje,con cada resultado se hace un merge
            char[] delimiterChars = { ',', '\t' };
            string[] words = iCodViaje.Split(delimiterChars);
            for (k = 0; k < words.Length; k++)
            {
                lCodigo = words[k].ToString();
                //obtenemos el resumen de las piezas por viaje
                lSql = string.Concat(" EXEC SP_PIEZA_PRODUCCION '','','', 0, 0, 0, '','',", lCodigo, ",'','',9");
                listaDataSet = wsOperacion.ListarAyudaSql(lSql);
                if (listaDataSet.MensajeError.Equals(""))
                {
                    if (listaDataSet.DataSet.Tables[0].Rows.Count > 0)
                    {
                        if (dgvEtiquetasPiezas.DataSource == null)
                        {

                            dgvEtiquetasPiezas.DataSource = listaDataSet.DataSet.Tables[0];
                            OcultaColumnas();
                        }
                        else
                        {
                            AgregaFila(listaDataSet);
                        }
                    }
                }
                else
                {
                    MessageBox.Show(listaDataSet.MensajeError.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                lbl_NroPiezasCar.Text = lNroPiezas.ToString();
                lbl_TotalKgsCar.Text = lTotalKgs.ToString();
                lbl_TotalPaqCar.Text = lTotalPaq.ToString();
            }
        }


        private void CargaViajesSeleccionados(string iCodViaje)
        {
            WsCrud.CrudSoapClient lDAl = new WsCrud.CrudSoapClient();
            WsCrud.ListaDataSet listaDataSet = new WsCrud.ListaDataSet();
            string lSql = "";

            char[] delimiterChars = { ',', '\t' };
            char[] delimiterChars2 = { '|', '\t' };
            int i = 0;

            string[] words = iCodViaje.Split(delimiterChars);           
            for (i = 0; i < words.Length; i++)
            {
                string[] words2 = words[i].Split(delimiterChars2);
                //lSql = string.Concat("Exec SP_ConsultasGenerales 14,",words [i],",'','','',''");
                lSql = string.Concat("Exec SP_ConsultasGenerales 14,", words2[0], ",'','','',''");
                listaDataSet = lDAl.ListarAyudaSql(lSql);
                if (listaDataSet.MensajeError.Trim().Length > 0)
                {
                    MessageBox.Show(listaDataSet.MensajeError.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (listaDataSet.DataSet.Tables.Count > 0)
                    {
                        mIdsViajes = string.Concat(mIdsViajes, listaDataSet.DataSet.Tables[0].Rows[0]["IdViaje"],",");
                    }
                }
            }
            if (mIdsViajes.Length >2 )
                mIdsViajes = mIdsViajes.Substring (0,mIdsViajes .Length -1);

           
        }

        private void Btn_VerViaje_Click(object sender, EventArgs e)
        {
         
            WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
                WsOperacion.ListaDataSet listaDataSet = new WsOperacion.ListaDataSet();
            object lPiezas ;
            DataTable lTbl = new DataTable(); string lTitulo = ""; Clases.ClsComun iCom = new Clases.ClsComun();
            //string lCodViaje = ((System.Data.DataRowView)(CmbViaje.SelectedItem)).Row.ItemArray[2].ToString();

            lPiezas = wsOperacion.ObtenerDetallePiezasPorViaje(mViajesSel );

            //obtenemos el detalle de las piezas producidas por la colada
            //listaDataSet = wsOperacion.ObtenerDetallePiezasPorViaje(CmbViaje .);
            if (lPiezas !=null ) // listaDataSet.MensajeError.Equals(""))
            {

                lTitulo = string.Concat("Detalle de Piezas de  Viaje(s) ", mViajesSel);
                    Frm_Detalle lFrm = new Frm_Detalle();
                    lFrm.CargaDatosGrilla(lTitulo, lPiezas);
                    lFrm.ConfiguraGrillaPiezas();
                    lFrm.ShowDialog();
          }
            else
            {
                MessageBox.Show(listaDataSet.MensajeError.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_SelViajes_Click(object sender, EventArgs e)
        {
            DataTable lTbl = new DataTable(); ; string lTitulo = ""; string lViajes = "";
            lTbl = ObtenerTablaViajesPorObra(this.cboObraDestino.SelectedValue.ToString ());
            int k = 0; string lTmp = "";
            if (lTbl != null) // listaDataSet.MensajeError.Equals(""))
            {
                               lTitulo = string.Concat("Detalle de Piezas Del  Viaje ");
                Frm_SeleccionarViajes lFrm = new Frm_SeleccionarViajes();
                lFrm.IniciaForm (lTbl,Lbl_Viajes.Text,"PD" );
                //lFrm.ConfiguraGrillaPiezas();
                mIdsViajes = "";
                lFrm.ShowDialog();

                Lbl_Estado.Text = " Obteniendo Datos . . .";
                progressBar1.Maximum = 5;
                progressBar1.Minimum = 1;
                progressBar1.Value = 1;
                Gr_Avance.Visible = true;

                cboObraDestino.Enabled = false;
               if (lFrm .mViajesSel .ToUpper ().Equals ("S"))
                {
                    if (null != AppDomain.CurrentDomain.GetData("Viajes").ToString())
                    {
                        lViajes = AppDomain.CurrentDomain.GetData("Viajes").ToString();
                        mViajesSel = lViajes;//.Replace(",", "|");
                        //mViajesSel = " " + lViajes + " ";
                        Lbl_Viajes.Text = lViajes.Replace("'", "");

                        //++*********************************
                         char[] delimiterChars = { ',', '\t' };
                        char[] delimiterChars2 = { '|', '\t' };
                        string[] words = Lbl_Viajes.Text.Split(delimiterChars);

                        dgvEtiquetasPiezas.DataSource = null;
                        //for (k = 0; k < words.Length; k++)
                        //{
                            //lCodigo = words[k].ToString(); lTmp =0;
                            string[] words2 = words[k].Split(delimiterChars2);
                            lTmp = string.Concat(lTmp," " , words2[0].ToString());
                            //********Por modificacion solicitada por L Gallardo, se permite seleccionar Varios viajes para cargar en un Camion
                            // 30-05-2018
                            {
                              
                               // CargaResumenPiezasViaje(words2[0].ToString());

                                Lbl_Estado.Text = "Cargando Información de Piezas  . .";
                                if (progressBar1.Value < progressBar1.Maximum)
                                    progressBar1.Value = progressBar1.Value + 1;
                                else
                                    progressBar1.Value = progressBar1.Value - 1;

                                progressBar1.Refresh();
                                Application.DoEvents();
                                this.Refresh();

                                // En la variable mIdsViajes quedan los Ids de los viajes seleccionados
                                CargaViajesSeleccionados(mViajesSel);
                                Lbl_Estado.Text = "Cargando Información del Viaje   . .";
                                if (progressBar1.Value < progressBar1.Maximum)
                                    progressBar1.Value = progressBar1.Value + 1;
                                else
                                    progressBar1.Value = progressBar1.Value - 1;

                                progressBar1.Refresh();
                                Application.DoEvents();
                                this.Refresh();
                                //CargaResumenViajeDespachado(mViajesSel);
                                Lbl_Estado.Text = "Cargando Información del Despacho   . .";
                                if (progressBar1.Value < progressBar1.Maximum)
                                    progressBar1.Value = progressBar1.Value + 1;
                                else
                                    progressBar1.Value = progressBar1.Value - 1;

                                progressBar1.Refresh();
                                Application.DoEvents();
                                this.Refresh();

                                CargaGrillaPiezasViajeDespachado_V2(mViajesSel);
                                Lbl_Estado.Text = " Finalizando  .  . .";
                                if (progressBar1.Value < progressBar1.Maximum)
                                    progressBar1.Value = progressBar1.Value + 1;
                                else
                                    progressBar1.Value = progressBar1.Value - 1;

                                progressBar1.Refresh();
                                Application.DoEvents();
                                this.Refresh();

                                //OcultaColumnas();
                                Btn_EliminaPaq.Enabled = false;
                                this.tlbGuardar.Enabled = false;
                                ActualizaColoresGrilla();
                                CalculaTotales();
                                Gr_Avance.Visible = false;
                                this.Text = string.Concat(Lbl_Viajes.Text, " - ", cboObraDestino.Text, " - Despacho a Camión  1.0.0.3");
                                if (this.tlbGuardar.Enabled == false)
                                {
                                    MessageBox.Show("El Viaje seleccionado ya se Despacho. No se puede despachar Nuevamente. La infromacion que se visualiza es solo de consulta ", "Avisos Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    Btn_DevuelveCamion.Enabled = true;
                                }



                                //********************************************
                            }
                        Lbl_Viajes.Text = lTmp;
                        Btn_BasculaMovil.Enabled = true;
                        //+++++++++++++++++++++
                        //if (mViajesSel.Trim().Length > 0)
                        
                        //}        
                    }
                }
            }

        }

        private void txtEtiquetaPieza_TextChanged(object sender, EventArgs e)
        {

        }

        private void Btn_EliminaPaq_Click(object sender, EventArgs e)
        {
            if (MessageBox .Show ("¿Esta Seguro que desea eliminar el paquete seleccionado?","Despacho Camión",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes )
            {
                DataTable lTbl = new DataTable(); DataView lVista = null;
                lTbl = (DataTable) dgvEtiquetasPiezas.DataSource;
                lVista = new DataView(lTbl, string.Concat("Etiqueta_Pieza=", Btn_EliminaPaq.Tag), "", DataViewRowState.CurrentRows);
                if (lVista .Count >0)
                    lVista[0].Delete() ;
                //Dtg_Resultado.Rows[z].Cells["Codigo"].Value
                    Btn_EliminaPaq.Tag ="";
                    Btn_EliminaPaq.Enabled = false;
            }            
        }

        private void dgvEtiquetasPiezas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >-1)
 {
            if ( dgvEtiquetasPiezas.Rows[e.RowIndex].Cells["Estado1"].Value.ToString().Equals ("PNV"))
            {
             this.Btn_EliminaPaq.Tag = dgvEtiquetasPiezas.Rows[e.RowIndex].Cells[1].Value.ToString();
            this.Btn_EliminaPaq.Enabled = true;
            }
            else
            {
               this.Btn_EliminaPaq.Tag = "0";
                this.Btn_EliminaPaq.Enabled = false;
            }

 }
        }

  
        private void tlbIntegrarINET_Click(object sender, EventArgs e)
        {
            Frm_IntegracionINET lFrm = new Frm_IntegracionINET(); string iEmpresa = "";
            if (Rb_TO.Checked == true)
                iEmpresa = "TO";

            if (RB_TOSOL.Checked == true)
                iEmpresa = "TOSOL";

            lFrm.IniciaForm(iEmpresa,mSoloCamionesBascula );
            lFrm.ShowDialog(this);
        }

        private void Btn_ITDESP_Click(object sender, EventArgs e)
        {

            int i = 0; string lNroEtiqueta = "";
            if (MessageBox.Show("¿Esta Seguro que desea dejar IT como despachada?", "Avisos Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                for (i = 0; i < dgvEtiquetasPiezas.RowCount ; i++)
                {
                 
                    //ProcesaEtiqueta
                    lNroEtiqueta = dgvEtiquetasPiezas.Rows[i].Cells["Etiqueta_Pieza"].Value.ToString();
                    txtEtiquetaPieza.Text = lNroEtiqueta;
                    ProcesaEtiqueta();

                }

            }
        }

        private void Btn_DevuelveCamion_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show(string.Concat("¿Esta Seguro que desea  Anular el despacho de camión para la IT ", Lbl_Viajes.Text, "? "), "Avisos Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                AnulaDespachoCamion(Lbl_Viajes.Text);
            }
        }

        private void AnulaDespachoCamion(string iCodViaje)
        {
            WsCrud.CrudSoapClient lDAl = new WsCrud.CrudSoapClient();
            WsCrud.ListaDataSet listaDataSet = new WsCrud.ListaDataSet();
            string lSql = "";
//            ALTER  PROCEDURE [dbo].[SP_ConsultasGenerales]
            //@Opcion INT,  //@Par1 Varchar(100),           //@Par2 Varchar(100),           //@Par3 Varchar(100),
        //@Par4 Varchar(100),       //@Par5 Varchar(100)
            lSql = string.Concat(" SP_ConsultasGenerales 52,'", iCodViaje ,"','','','',''") ;

            listaDataSet = lDAl.ListarAyudaSql(lSql);

            if (listaDataSet.MensajeError.ToString().Trim().Length == 0)
            {
                MessageBox.Show("La Anulación del despacho a sido satisfactoria ", "Avisos Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);  
            }

        }

        private void RB_TOSOL_CheckedChanged(object sender, EventArgs e)
        {
            if (RB_TOSOL .Checked == true)
            {
                DataTable lTbl = new DataTable();
                lTbl = CargaTablaObras();
                if (lTbl.Rows.Count > 0)
                {
                    //lTbl = CargaTablaObras(listaDataSet.DataSet.Tables[0]);
                    //new Forms().comboBoxFill(cboObraDestino, listaDataSet.DataSet.Tables[0], "Id", "Obra", 0);
                    new Forms().comboBoxFill(cboObraDestino, lTbl, "Id", "Obra", 0);
                }
            }
        }

        private void Rb_TO_CheckedChanged(object sender, EventArgs e)
        {
            if (Rb_TO.Checked == true)
            {
                DataTable lTbl = new DataTable();
                lTbl = CargaTablaObras();
                if (lTbl.Rows.Count > 0)
                {
                    //lTbl = CargaTablaObras(listaDataSet.DataSet.Tables[0]);
                    //new Forms().comboBoxFill(cboObraDestino, listaDataSet.DataSet.Tables[0], "Id", "Obra", 0);
                    new Forms().comboBoxFill(cboObraDestino, lTbl, "Id", "Obra", 0);
                }
            }
        }

        private void Cmb_Patentes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Cmb_Patentes.SelectedValue.ToString ().Trim().Equals(""))
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    lblTransportista.Text = ".";
                    if (mPrimeraVez == false)
                    {
                        if (ValidaPatente(Cmb_Patentes.SelectedValue.ToString()) == false)
                        {
                            Cmb_Patentes.Focus();
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

        private void Btn_Cambiar_A_PR_Click(object sender, EventArgs e)
        {
            string lPath = ""; string lApp = "";
            if (MessageBox.Show("¿ Esta seguro que desea cambiar el sistema a modo Producción ? ", "Avisos Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                 MessageBox.Show("Cuando el sistema le indique menu de confirmación, Presaionar SI ", "Avisos Sistema", MessageBoxButtons.OK);
                lPath = ConfigurationManager.AppSettings["Path_Regedit"].ToString();
                lApp = "Regedit.exe";
                lPath = string.Concat(lPath, "PR_SM.reg");
                System.Diagnostics.Process.Start(lApp, lPath);
                System.Threading.Thread.Sleep(3000);
                MessageBox.Show("El Sistema se cerrara, debe iniciar nuevamente el sistema, para cambiar a Modo Producción   ", "Avisos Sistema", MessageBoxButtons.OK);
                Application.Exit();
            }
        }

        private int ObtenerMonitor(Boolean iPrimario)
        {
            Screen[] iMonitores; int i = 0; int lRes = 0;
            iMonitores = Screen.AllScreens;
            for (i = 0; i < iMonitores.Length; i++)
            {
                if (iMonitores[i].Primary == iPrimario)
                    lRes = i;

            }

            return lRes;
        }

        private void Btn_BasculaMovil_Click(object sender, EventArgs e)
        {
            Screen[] iMonitores;   string lMsg = ""; int iMonPrimario = 0; int iMonSec = 0;
            DataTable lTbl = new DataTable(); string lEtiquetasOK = ""; string lVolver = "N";

            iMonPrimario = ObtenerMonitor(true);
            iMonSec = ObtenerMonitor(false);
            iMonitores = Screen.AllScreens;

            if (iMonitores.Length == 2)
            {
                Bascula.Frm_CargaBasculaMovil lFrm = new Bascula.Frm_CargaBasculaMovil();
                lTbl = (DataTable)dgvEtiquetasPiezas.DataSource;
                lFrm.IniciaForm(lTbl, mUserLog);
                lFrm.Left = iMonitores[iMonSec].Bounds.Left;
                lFrm.Top = iMonitores[iMonSec].Bounds.Top;
                lFrm.ShowDialog();
                lEtiquetasOK = AppDomain.CurrentDomain.GetData("EtiquetasOK").ToString();
                lVolver = AppDomain.CurrentDomain.GetData("Volver").ToString();
                ProcesaEtiquetasOK(lEtiquetasOK);
                while (lVolver == "S")
                {
                    lFrm = new Bascula.Frm_CargaBasculaMovil();
                    lFrm.IniciaForm(lTbl, mUserLog);
                    lFrm.Left = iMonitores[iMonSec].Bounds.Left;
                    lFrm.Top = iMonitores[iMonSec].Bounds.Top;
                    lFrm.ShowDialog();

                    lEtiquetasOK = AppDomain.CurrentDomain.GetData("EtiquetasOK").ToString();
                    lVolver = AppDomain.CurrentDomain.GetData("Volver").ToString();
                    ProcesaEtiquetasOK(lEtiquetasOK);

                }


            }

            if (iMonitores.Length == 1)
            {
                
                lMsg = string .Concat ("El sistema a Detectado que hay solo un monitor conectado. ", Environment .NewLine );
                lMsg = string.Concat(lMsg, "¿ Desea abrir las dos Pantallas en el mismo Monitor?");
                if (MessageBox.Show(lMsg, "Avisos Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Bascula.Frm_CargaBasculaMovil lFrm = new Bascula.Frm_CargaBasculaMovil();
                    lTbl = (DataTable)dgvEtiquetasPiezas.DataSource;
                    lFrm.IniciaForm(lTbl, mUserLog);
                    //lFrm.Left = iMonitores[1].Bounds.Left;
                    //lFrm.Top = iMonitores[1].Bounds.Top;
                    lFrm.ShowDialog();
                    lEtiquetasOK = AppDomain.CurrentDomain.GetData("EtiquetasOK").ToString();
                    lVolver = AppDomain.CurrentDomain.GetData("Volver").ToString();
                    ProcesaEtiquetasOK(lEtiquetasOK);
                    while (lVolver == "S")
                    {
                        lFrm = new Bascula.Frm_CargaBasculaMovil();
                        lFrm.IniciaForm(lTbl, mUserLog);
                        //lFrm.Left = iMonitores[1].Bounds.Left;
                        //lFrm.Top = iMonitores[1].Bounds.Top;
                        lFrm.ShowDialog();

                        lEtiquetasOK = AppDomain.CurrentDomain.GetData("EtiquetasOK").ToString();
                        lVolver = AppDomain.CurrentDomain.GetData("Volver").ToString();
                        ProcesaEtiquetasOK(lEtiquetasOK);

                    }

                }
                else
                    tlbSalir_Click(null,null);


           }



           
            //  dgvEtiquetasPiezas.DataSource = lTblTmp;


            
           
        }

        private void ProcesaEtiquetasOK(string iEtiquetas)
        {
            string[] split = iEtiquetas.ToString().Split(new Char[] { '|' });
            int i = 0;Clases.ClsComun lCom = new Clases.ClsComun();

            for (i = 0; i < split.Length; i++)
            { 
                if (lCom.EsNumero (split [i].ToString ())==true )
                {
                    txtEtiquetaPieza.Text = split[i].ToString();
                    txtEtiquetaPieza_Validating(null, null);
                }
            }
        }

    }
}