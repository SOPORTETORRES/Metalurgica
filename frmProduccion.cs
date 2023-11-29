using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Text;
using System.Windows.Forms;
using CommonLibrary2;
using System.Drawing;

namespace Metalurgica
{
    public partial class frmProduccion : Form
    {
        private CurrentUser mUserLog=new CurrentUser() ;
        private const string COLUMNNAME_ETIQUETA_PIEZA = "ETIQUETA_PIEZA";
        private const string COLUMNNAME_PIE_ESTADO = "PIE_ESTADO";
        private const string COLUMNNAME_ESTADO = "ESTADO";
        private double  mTotalKilos=0;
        private string mIdUser ="0";
        private string mIdEtiquetaColada = "0";
        private string mEstadoMaquina = "";
        private string mIdNotificacion = "0";
        private string mMsgMaquina = "";
        private string mTipoAveria = "";
        DataTable mTblDatos = new DataTable();
        DataView mVistaPr = null;

        public frmProduccion()
        {
            InitializeComponent();
            this.dgvEtiquetasPiezas.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(dgvEtiquetasPiezas_RowPostPaint);
            this.dgvEtiquetasPiezasExcepciones.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(dgvEtiquetasPiezasExcepciones_RowPostPaint);
        }

        private void dgvEtiquetasPiezas_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvEtiquetasPiezas.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvEtiquetasPiezasExcepciones_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvEtiquetasPiezasExcepciones.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void tlbNuevo_Click(object sender, EventArgs e)
        {
            txtEtiquetaColada.Clear();
            txtObs.Clear();
            txtEtiquetaPieza.Clear();
            //limpiamos los datos 
            lblColada.Text = "";
            lblDiametro.Text = "";
            lblLargo.Text = "";
            lblNroCertificado.Text = "";
            lblKilos.Text = "";                                
            Lbl_SaldoKilosColada.Text=  "";
            Lbl_KgsProd.Text = "";
            Lbl_NroPiezas.Text = "";
            Lbl_NroEtiq.Text = "";
                                
            dgvEtiquetasPiezas.DataSource = null;
            if (cboExcepciones.Items.Count > 0)
                cboExcepciones.SelectedIndex = 0;
            dgvEtiquetasPiezasExcepciones.DataSource = null;
            lblCantidadEtiquetasPiezas.Text = "Registro(s): 0";
            lblCantidadEtiquetasPiezasExcepciones.Text = "Registro(s): 0";
            tabOperaciones.TabIndex = 0;
            mTotalKilos = 0;
            txtEtiquetaColada.Focus();
        }

        public  void IniciaFormulario(CurrentUser  iUserLog )
        {
            mUserLog = iUserLog;
            mIdUser = iUserLog.Iduser;
            ctlInformacionUsuario1.CargaDatosUserLog(iUserLog);
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
            //quitamos de forma temporal lavalidacion
            //if (txtEtiquetaColada.Text.Trim().Equals(""))
            //    sb.Append("- Colada\n");

            if (dgvEtiquetasPiezas.Rows.Count == 0 && dgvEtiquetasPiezasExcepciones.Rows.Count == 0)
                sb.Append("- Pieza(s)\n");
            //        break;
            //}
            return sb.ToString();
        }

        private void tlbGuardar_Click(object sender, EventArgs e)
        {
            //string mensaje = validarControlesRequeridos();
            //if (mensaje.Equals(""))
            //{
            //    Cursor.Current = Cursors.WaitCursor;
            //    try
            //    {
            //        WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
            //        WsOperacion.Pieza pieza = new WsOperacion.Pieza();

            //        foreach (DataGridViewRow row in dgvEtiquetasPiezas.Rows)
            //        {
            //            pieza.Colada = txtEtiquetaColada.Text.Trim();
            //            pieza.Etiqueta = row.Cells[COLUMNNAME_ETIQUETA_PIEZA].Value.ToString();
            //            pieza.Estado = "O40";

            //            pieza = wsOperacion.RegistrarPasoaProduccionPieza(pieza, Program.currentUser.Machine, Program.currentUser.Login, Program.currentUser.ComputerName);
            //            if (pieza.MensajeError.Equals(""))
            //            {
            //                //tlbActualizar.PerformClick();
            //                //MessageBox.Show("Registro(s) guardado(s).", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            }
            //            else
            //                MessageBox.Show(pieza.MensajeError.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //        //Excepciones
            //        foreach (DataGridViewRow row in dgvEtiquetasPiezasExcepciones.Rows)
            //        {
            //            //pieza.Colada = txtEtiquetaColada.Text.Trim();
            //            //pieza.Etiqueta = row.Cells[COLUMNNAME_ETIQUETA_PIEZA].Value.ToString();
            //            //pieza.Estado = row.Cells[COLUMNNAME_PIE_ESTADO].Value.ToString();

            //            //pieza = wsOperacion.RegistrarPasoaProduccionPieza(pieza, Program.currentUser.Machine, Program.currentUser.Login, Program.currentUser.ComputerName);
            //            //if (pieza.MensajeError.Equals(""))
            //            //{
            //            //    //tlbActualizar.PerformClick();
            //            //    //MessageBox.Show("Registro(s) guardado(s).", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            //}
            //            //else
            //            //    MessageBox.Show(pieza.MensajeError.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //        //tlbNuevo.PerformClick();
            //        tlbNuevo_Click(sender, e);
            //        MessageBox.Show("Registro(s) guardado(s).", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        //}
            //        //else
            //        //    MessageBox.Show(despacho_Bodega_MP.MensajeError.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //    catch (Exception exc)
            //    {
            //        MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //    Cursor.Current = Cursors.Default;
            //}
            //else
            //    MessageBox.Show("Debe ingresar los siguientes datos requeridos:\n\n" + mensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            DataGridView dgvActiva = null;

            switch (tabOperaciones.SelectedIndex)
            {
                case 0:
                    dgvActiva = dgvEtiquetasPiezas;
                    break;
                case 1:
                    dgvActiva = dgvEtiquetasPiezasExcepciones;
                    break;
            }
            if (dgvActiva != null)
            {
                if (dgvActiva.Rows.Count > 0)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    new Excel().exportar(dgvActiva);
                    Cursor.Current = Cursors.Default;
                }
                else
                    MessageBox.Show("No existen registros a exportar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tlbSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private WsOperacion.ListaDataSet ObtenerColadasPorId(string IdColada)
        {
            Ws_TO.Ws_ToSoapClient  ldal = new  Ws_TO.Ws_ToSoapClient();
            WsOperacion.ListaDataSet listaDataSet = new WsOperacion.ListaDataSet();
            string lSql = "";
            try
            {
                listaDataSet.MensajeError = "";
//  [SP_ConsultasGenerales] @Opcion INT,  @Par1 Varchar(100),  @Par2 Varchar(100),  @Par3 Varchar(100),
//@Par4 Varchar(100),     @Par5 Varchar(100)

                lSql = string.Concat ("exec SP_ConsultasGenerales 25,'",IdColada .ToString (),"','','','',''");
                listaDataSet.DataSet = ldal.ObtenerDatos(lSql);
            }
            catch (Exception exc)
            {
                listaDataSet.MensajeError = exc.Message.ToString ();
            }
            return listaDataSet;
        }


        private void txtEtiquetaColada_Validating(object sender, CancelEventArgs e)
        {
            DataTable dt = new DataTable();
            if (!txtEtiquetaColada.Text.Trim().Equals(""))
            { 
                Cursor.Current = Cursors.WaitCursor;
                try
                {

                   //lTmp= int.TryParse(txtEtiquetaColada.Text.ToString (), lTmp);

                    lblColada.Text = ".";
                    lblDiametro.Text = ".";
                    lblLargo.Text = ".";
                    lblNroCertificado.Text = ".";

                    WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
                    WsOperacion.ListaDataSet listaDataSet = new WsOperacion.ListaDataSet();

                    string lValidaColadaEnProduccion = ConfigurationManager.AppSettings["ValidaColadaEnProduccion"].ToString().ToUpper(); 
                    //ValidaColadaEnProduccion

                    //if (lValidaColadaEnProduccion.ToString ().ToUpper ().Equals ("N") )
                    //{

                    //}

                    if (txtEtiquetaColada.Text.ToString().Trim().Length == 48)
                    {  //Debemos ir a buscar el Id Paquete Colada
                        listaDataSet = wsOperacion.obtenerIdRC_PorColada(txtEtiquetaColada.Text);
                        if (listaDataSet.MensajeError.Equals(""))
                        {
                            mIdEtiquetaColada = listaDataSet.DataSet.Tables[0].Rows[0][0].ToString();
                        }
                    }
                    else
                        mIdEtiquetaColada = txtEtiquetaColada.Text;

                    listaDataSet = wsOperacion.ObtenerRecepcionxEtiqueta_Colada(mIdEtiquetaColada);
                    //listaDataSet = wsOperacion.ObtenerRecepcionxEtiqueta_Colada(txtEtiquetaColada.Text);
                    if (listaDataSet.MensajeError.Equals(""))
                    {
                        if ((listaDataSet.DataSet.Tables[0].Rows.Count > 0) )// && (!listaDataSet.DataSet.Tables[0].Rows[0]["EnProduccion"].ToString ().Equals ("0")))
                        {
                            dt = listaDataSet.DataSet.Tables[0];                                                                              
                            lblKilos.Text = dt.Rows[0]["KILOSCalculados"].ToString();

                            //<info. colada> etiqueta_colada != colada
                            string colada = listaDataSet.DataSet.Tables[0].Rows[0]["COLADA"].ToString();
                            //listaDataSet = wsOperacion.ObtenerColadasPorNro(colada);
                            listaDataSet = ObtenerColadasPorId(colada);
                            if (listaDataSet.MensajeError.Equals(""))
                            {
                               
                                 dt = listaDataSet.DataSet.Tables[0];
                                if (dt.Rows.Count > 0)
                                {
                                     lblColada.Text = colada;
                                    lblDiametro.Text = dt.Rows[0]["DIAMETRO"].ToString();
                                    lblLargo.Text = dt.Rows[0]["LARGO"].ToString();
                                    lblNroCertificado.Text = dt.Rows[0]["NROCERTIFICADO"].ToString();
                                //obtenemos el detalle de las piezas producidas por la colada
                                    listaDataSet = wsOperacion.ObtenerDatosProduccionPorColada(mIdEtiquetaColada );
                                    //listaDataSet = wsOperacion.ObtenerDatosProduccionPorColada(txtEtiquetaColada.Text);
                                    if (listaDataSet.MensajeError.Equals(""))
                                      {
                                        if (listaDataSet.DataSet.Tables[0].Rows.Count > 0)
                                        {
                                            Lbl_SaldoKilosColada.Text = listaDataSet.DataSet.Tables[0].Rows[0]["SaldoKiloscolada"].ToString();
                                            Lbl_KgsProd.Text = listaDataSet.DataSet.Tables[0].Rows[0]["Kilosproducidos"].ToString();
                                            Lbl_NroPiezas.Text = listaDataSet.DataSet.Tables[0].Rows[0]["PiezasProducidas"].ToString();
                                            Lbl_NroEtiq.Text = listaDataSet.DataSet.Tables[0].Rows[0]["NroEtiquetas"].ToString();
                                        }
                                        else
                                        {
                                            Lbl_SaldoKilosColada.Text = lblKilos.Text;
                                              Lbl_KgsProd.Text = "0";
                                            Lbl_NroPiezas.Text = "0";
                                            Lbl_NroEtiq.Text = "0";
                                        }
                                      } 
                                   
                                    else {
                                        MessageBox.Show(listaDataSet.MensajeError.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        tlbNuevo_Click(null, null);
                                        e.Cancel = true;
                                    }
                                }
                            }
                           
                        }
                        else
                        {
                         //   MessageBox.Show("La etiqueta '" + txtEtiquetaColada.Text + "' no existe, o no ha sido enviada a producción, Revisar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            MessageBox.Show("La etiqueta '" + txtEtiquetaColada.Text + "' no existe, Revisar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            tlbNuevo_Click(null, null);
                            e.Cancel = true;
                        }
                    }
                    else
                          {
                        MessageBox.Show(listaDataSet.MensajeError.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tlbNuevo_Click(null, null);
                        e.Cancel = true;
                          }

                    if (this.Lbl_KgsProd.Text.ToString().Trim().Length > 0)
                    {
                        mTotalKilos = double.Parse(this.Lbl_KgsProd.Text);
                    }
                    
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Cursor.Current = Cursors.Default;
            }
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

        private void frmProduccion_Load(object sender, EventArgs e)
        {
            try
            {
                //Visualizamos la version
                Clases.ClsComun lCom = new Clases.ClsComun();
                this.Text += " - versión: " + lCom.ObtenerVersion();  //Application.ProductVersion;

                //Cargar motivos/excepciones
                WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
                WsOperacion.ListaDataSet listaDataSet = new WsOperacion.ListaDataSet();

                listaDataSet = wsOperacion.ObtenerMotivosExcepcionProduccion();
                if (listaDataSet.MensajeError.Equals(""))
                {
                    DataTable dataTable = listaDataSet._dataSet.Tables[0];
                    new Forms().comboBoxFill(cboExcepciones, dataTable, "par_codint", "par_descripcion", 0);
                }
                else
                    MessageBox.Show(listaDataSet.MensajeError.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);


                ActualizaKilosProducidos();
                //temp//
                //DataTable dt = new DataTable();
                //dt.Columns.Add(COLUMNNAME_ETIQUETA_PIEZA);
                //this.dgvEtiquetasPiezas.DataSource = dt;

                VerificaEstadoMaquina(mUserLog.IdMaquina.ToString () );
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void VerificaEstadoMaquina(string lIdMaquina)
        {
            //           [SP_CRUD_NOTIFICACION_AVERIA]  @Id int,
    //@IdOperador int,                  //@TipoMaquina varchar(50) ,	//@TextoIncidencia varchar(max) ,
    //@MailEnviado varchar(1) ,         //@IdUserCrea int   ,           //@Estado varchar(50),
    //@IdMaquina int,                   //@EstadoMaq varchar(10),       //@Opcion int 

            Ws_TO.Ws_ToSoapClient ldal = new Ws_TO.Ws_ToSoapClient();
            WsOperacion.ListaDataSet listaDataSet = new WsOperacion.ListaDataSet();
            string lSql = "";   Btn_Desbloquea.Visible = false ;
            try
            {
                listaDataSet.MensajeError = "";

                lSql = string.Concat("exec  SP_CRUD_NOTIFICACION_AVERIA 0,0,'','','',0,'',", lIdMaquina,",'',3 ");
                listaDataSet.DataSet = ldal.ObtenerDatos(lSql);
                if ((listaDataSet.DataSet.Tables.Count > 0) && (listaDataSet.DataSet.Tables[0].Rows.Count > 0))
                {
                    mEstadoMaquina=listaDataSet.DataSet.Tables[0].Rows[0]["EstadoMaq"].ToString().ToUpper();
                    if (listaDataSet.DataSet.Tables[0].Rows[0]["TextoIncidencia"].ToString().Equals("Cambio de Rollo"))
                    { mTipoAveria = "CB"; }
                    else
                    { mTipoAveria = "AV"; }

                    if (mEstadoMaquina.ToUpper().Equals("DET"))
                    {
                        mIdNotificacion = listaDataSet.DataSet.Tables[0].Rows[0]["Id"].ToString();
                        mMsgMaquina = string.Concat(" El Tótem Esta asociado a la Maquina ", listaDataSet.DataSet.Tables[0].Rows[0]["Maquina"].ToString() );
                        mMsgMaquina = string.Concat(mMsgMaquina, " La cual se encuentra en estado Detenida ", Environment.NewLine);
                        mMsgMaquina = string.Concat(mMsgMaquina, " Por notificación del Usuario: ", listaDataSet.DataSet.Tables[0].Rows[0]["Nombre"].ToString(), Environment.NewLine);
                        mMsgMaquina = string.Concat(mMsgMaquina, " Con el motivo de: ", listaDataSet.DataSet.Tables[0].Rows[0]["TextoIncidencia"].ToString(), Environment.NewLine);
                        mMsgMaquina = string.Concat(mMsgMaquina, " La notificación se realizo con fecha:  ", listaDataSet.DataSet.Tables[0].Rows[0]["FechaRegistro"].ToString(), Environment.NewLine);
                        groupBox1.Enabled = false;
                        tabOperaciones.Enabled = false;
                        tlsToolBar.Enabled = false;
                        lbl_MsgBloqueo.Text = mMsgMaquina;
                        lbl_MsgBloqueo.Top = groupBox1.Top; lbl_MsgBloqueo.Left = groupBox1.Left;
                        lbl_MsgBloqueo.Width = groupBox1.Width; lbl_MsgBloqueo.Height = groupBox1.Height;
                        lbl_MsgBloqueo.Visible = true;
                        txtEtiquetaPieza.Enabled = false;
                        Chk_MultiplesColadas.Enabled = false;
                        //groupBox1.Visible = false;
                        Btn_Desbloquea.Visible = true;
                          this .Refresh() ;
                    }
                    else
                    {
                        if ((listaDataSet.DataSet.Tables[0].Rows[0]["EstadoSupervisor"].ToString().Equals("NOOK")) && (mTipoAveria.ToUpper ().Equals ("AV")))
                        {
                            mIdNotificacion = listaDataSet.DataSet.Tables[0].Rows[0]["Id"].ToString();
                            mMsgMaquina = string.Concat(" El Tótem Esta asociado a la Maquina ", listaDataSet.DataSet.Tables[0].Rows[0]["Maquina"].ToString());
                            mMsgMaquina = string.Concat(mMsgMaquina, " Ha sido reparada, pero falta el OK por el supervisor de turno ", Environment.NewLine);                                                       
                            mMsgMaquina = string.Concat(mMsgMaquina, " Para que quede operativa el supervisor debe validar la mantención ",  Environment.NewLine);
                            groupBox1.Enabled = false;
                            tabOperaciones.Enabled = false;
                            tlsToolBar.Enabled = false;
                            lbl_MsgBloqueo.Text = mMsgMaquina;
                            lbl_MsgBloqueo.Top = groupBox1.Top; lbl_MsgBloqueo.Left = groupBox1.Left;
                            lbl_MsgBloqueo.Width = groupBox1.Width; lbl_MsgBloqueo.Height = groupBox1.Height;
                            lbl_MsgBloqueo.Visible = true;
                            txtEtiquetaPieza.Enabled = false;
                            Chk_MultiplesColadas.Enabled = false;
                            //groupBox1.Visible = false;
                            if (mUserLog.PerfilUsuario.ToUpper().Equals("SUPERVISOR"))
                            {
                                Btn_Desbloquea.Text = "Liberar Totém ";
                            }
                            
                            Btn_Desbloquea.Visible = true;
                            this.Refresh();
                        }
                        else
                        {
                            groupBox1.Enabled = true;
                            tabOperaciones.Enabled = true;
                            tlsToolBar.Enabled = true;
                            lbl_MsgBloqueo.Visible = false;
                            txtEtiquetaPieza.Enabled = true;
                            Chk_MultiplesColadas.Enabled = true;
                        }
                    }                       
                }
            }
            catch (Exception exc)
            {
                listaDataSet.MensajeError = exc.Message.ToString();
            }
           

        }

        private void cboExcepciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtEtiquetaPieza.Focus();
        }

        

        private void ActualizaKilosProducidos()
        {
            WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
            WsOperacion.ListaDataSet listaDataSet = new WsOperacion.ListaDataSet();
            string lMaq = mUserLog.IdMaquina.ToString ();
            string lUser = mUserLog.Login.ToString();

            listaDataSet = wsOperacion.ObtenerDatosConsultaGenerica(9, lMaq, lUser, "", "", "");
            if (listaDataSet.MensajeError.Equals(""))
            {
                if (listaDataSet.DataSet.Tables[0].Rows.Count > 0)
                {
                    Lbl_MsgKgsProd.Text = string.Concat ("Total Kilos producidos durante el día: ",listaDataSet.DataSet.Tables[0].Rows[0][0].ToString());
                }

            }
        }

        private void RegistraPiezaProducida(string iColada, string iPieza, int iNroPiezas, CurrentUser iUser, int iNroPiezasProd)
     {
         WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
         WsOperacion.Pieza pieza = new WsOperacion.Pieza(); int lIdUser = 0;
         Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient();         DataSet lDts = new DataSet();
         string lSql = ""; Clases.ClsComun lCom = new Clases.ClsComun();
         pieza.Colada = iColada;
         pieza.Etiqueta = iPieza;
         //row.Cells[COLUMNNAME_ETIQUETA_PIEZA].Value.ToString();
         pieza.Estado = "O40";
         lIdUser = int.Parse(mIdUser);
         pieza = wsOperacion.RegistrarPasoaProduccionPieza(pieza, Program.currentUser.IdMaquina , Program.currentUser.Login, Program.currentUser.ComputerName, 0, lIdUser);
         //pieza = wsOperacion.RegistrarPasoaProduccionPieza(pieza, Program.currentUser.Machine, Program.currentUser.Login, Program.currentUser.ComputerName);
         if (pieza.MensajeError.Equals(""))
         {
             //grabados el detalle
             lSql = string.Concat(" exec SP_CRUD_PaquetesProducidos 0,", iPieza, ",", iUser.IdMaquina , ",");
             lSql = string.Concat(lSql, iUser.Iduser, ",0,", iNroPiezas, ",", lCom.Val(iColada), ",", iNroPiezasProd);
             lSql = string.Concat(lSql, ",1");
             lDts = lPx.ObtenerDatos(lSql);
             //---------------------------
             //02-07-2014 Por medificaciones funcionales se puede vincular  a un paquete muchas coladas            

             lSql = string.Concat(" exec SP_CRUD_COLADASPAQUETE 0,", iPieza, ",", iPieza, ",");
             lSql = string.Concat(lSql, lCom.Val(iColada), ",", iUser.Iduser, ",", iUser.IdMaquina , ",1");
             lDts = lPx.ObtenerDatos(lSql);
                 
             //this.lbl_Res.Text = " La Etiqueta " + iPieza + " fue grabada Correctamente ";
             //this.Close();
         }
         else
         {
             //this.lbl_Res.Text = " La Etiqueta " + iPieza + " ha registrado un error, repita la operación ";
             MessageBox.Show(pieza.MensajeError.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
     }



        private bool PaqueteEstaProducido(DataTable  iTblPaquete)
           {
               bool lRes = false;
                if (iTblPaquete.Rows [0]["Pie_estado"].ToString().ToUpper().Equals ("O60"))
                {
                    //this.lbl_Res.Text = " La Etiqueta " + iPieza + " ha registrado un error, repita la operación ";
                    lRes = true;
                    MessageBox.Show("Esta etiqueta fue despachada, avisar a supervisor ", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //"Esta etiqueta fue despachada, avisar a supervisor".
                }

                   //this.lbl_Res.Text = " La Etiqueta " + iPieza + " ha registrado un error, repita la operación ";
                  // MessageBox.Show("Se ha Producido el siguiente error: " + pieza.MensajeError.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return lRes;
           }


        private void RegistraDatosConColadas()
        {                 
            DataGridView dgvActiva = null; bool lPuedeContinuar = false;
            Forms forms = new Forms(); string diametro = "";
            WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
            WsOperacion.ListaDataSet listaDataSet = new WsOperacion.ListaDataSet(); 

            if (!txtEtiquetaPieza.Text.Trim().Equals(""))
            {
                switch (tabOperaciones.SelectedIndex)
                {
                    case 0:
                        dgvActiva = dgvEtiquetasPiezas;
                        break;
                    case 1:
                        dgvActiva = dgvEtiquetasPiezasExcepciones;
                        break;
                }
                if (dgvActiva != null)
                {
                    if (forms.dataGridViewSearchText(dgvActiva, COLUMNNAME_ETIQUETA_PIEZA, txtEtiquetaPieza.Text) == -1)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        try
                        {                            
                            //listaDataSet = wsOperacion.ObtenerPieza(Convert.ToInt32(txtEtiquetaPieza.Text));
                            //22/05/2013 por solicitud de TO, para los datos a visualizar 
                            listaDataSet = wsOperacion.ObtenerDatosConsultaGenerica (8,txtEtiquetaPieza.Text ,"","","","");
                            if (listaDataSet.MensajeError.Equals(""))
                            {
                                if (listaDataSet.DataSet.Tables[0].Rows.Count > 0)
                                {
                                    //verificamos que el paquete no este  despachado
                                    if (PaqueteEstaProducido(listaDataSet.DataSet.Tables[0].Copy ())==false )
                                    {
                                        //Verifica que la colada y la pieza tengan el mismo diametro
                                        //Se desactiva la restriccion por marcha blanca 07/04/2014
                                         diametro = listaDataSet.DataSet.Tables[0].Rows[0]["DIAMETRO"].ToString();

                                        //if (lblDiametro.Text.Equals(diametro))
                                        //{
                                        if (Chk_MultiplesColadas.Checked == true)
                                        {
                                            ////abrimos el formulario para registrar las  coladas
                                            FrmConfirmaPieza lFrom = new FrmConfirmaPieza();
                                            lFrom.IniciaForm(int.Parse(txtEtiquetaPieza.Text), int.Parse(listaDataSet.DataSet.Tables[0].Rows[0]["PiezasPaq"].ToString()), Program.currentUser, txtEtiquetaColada.Text,diametro);
                                            lFrom.ShowDialog();
                                            if (lFrom.mPiezaProducida.ToUpper().Equals("S"))
                                                lPuedeContinuar = true ;
                                            else
                                                lPuedeContinuar = false;
                                        }
                                        else
                                        {
                                            ////actualizamos los datos en el servidor
                                            if (lblDiametro.Text.Equals(diametro))
                                            {
                                                double lPesoEtiqueta = 0;
                                                listaDataSet = wsOperacion.ObtenerDatosConsultaGenerica(8, txtEtiquetaPieza.Text, "", "", "", "");
                                                DataTable dataTable = listaDataSet.DataSet.Tables[0];
                                                if (dataTable.Rows.Count > 0)
                                                {
                                                    lPesoEtiqueta= double.Parse(dataTable.Rows[0]["PesoPaquete"].ToString());
                                                    //dataTable.Rows[0][COLUMNNAME_ESTADO] = (tabOperaciones.SelectedIndex == 0 ? "" : cboExcepciones.SelectedValue.ToString());
                                                    //dataTable.Rows[0][COLUMNNAME_PIE_ESTADO] = cboExcepciones.SelectedValue.ToString();
                                                    //dataTable.Rows[0][COLUMNNAME_ESTADO] = cboExcepciones.Text;
                                                }

                                                //validamos los kilos de la colada con los kilos ya producidos
                                                //Se comenta ya que aun no esta 100% en funcionamiento Recepción de colada
                                                //Cuando el Modulo este OK se debe descomentar la siguiente seccion
                                                //***********************************************************************************
                                                double KgsProducidos = double.Parse (Lbl_KgsProd.Text)  + lPesoEtiqueta;
                                                double LimiteKgs = double.Parse(ConfigurationManager.AppSettings["LimiteKgs"].ToString()) + 1;
                                                double KgsColada = double.Parse(this.lblKilos.Text); double KgsTmp =Math.Abs (KgsColada- KgsProducidos)  ;

                                                //if (mTotalKilos + double.Parse(row["PesoPaquete"].ToString()) > double.Parse(this.lblKilos.Text))
                                                if (mTotalKilos + lPesoEtiqueta > double.Parse(this.lblKilos.Text))
                                                {
                                                    if (KgsTmp < LimiteKgs)
                                                    {

                                                        int lPiezasPaq = (int)listaDataSet.DataSet.Tables[0].Rows[0]["PiezasPaq"];
                                                        RegistraPiezaProducida(mIdEtiquetaColada, txtEtiquetaPieza.Text, lPiezasPaq, mUserLog, lPiezasPaq);
                                                        //RegistraPiezaProducida(txtEtiquetaColada.Text, txtEtiquetaPieza.Text, lPiezasPaq, mUserLog, lPiezasPaq);
                                                        lPuedeContinuar = true;
                                                        string lMsgLim = (Math.Abs(double.Parse (Lbl_SaldoKilosColada.Text ) - LimiteKgs)).ToString();
                                                        MessageBox.Show(string .Concat ("La Kilos Producidos son Superiores a los de la colada, queda de limite ",lMsgLim), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("Se ha sobrepasado el Exceso de Kilos de la  colada ", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                        lPuedeContinuar = false;
                                                    }
                                                }
                                                else
                                                {
                                                    int lPiezasPaq = (int)listaDataSet.DataSet.Tables[0].Rows[0]["PiezasPaq"];
                                                    //
                                                    RegistraPiezaProducida(mIdEtiquetaColada, txtEtiquetaPieza.Text, lPiezasPaq, mUserLog, lPiezasPaq);
                                                    //RegistraPiezaProducida(txtEtiquetaColada.Text, txtEtiquetaPieza.Text, lPiezasPaq, mUserLog, lPiezasPaq);
                                                    lPuedeContinuar = true;
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("La etiqueta '" + txtEtiquetaPieza.Text + "' tiene un diametro (" + diametro + ") distinto al de la colada.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                lPuedeContinuar = false;
                                            }                                           
                                        }
                                        if (lPuedeContinuar == true)
                                        {
                                            if (dgvActiva.DataSource == null)
                                            {
                                                listaDataSet = wsOperacion.ObtenerDatosConsultaGenerica(8, txtEtiquetaPieza.Text, "", "", "", "");
                                                DataTable dataTable = listaDataSet.DataSet.Tables[0];
                                                if (dataTable.Rows.Count > 0)
                                                {
                                                    //dataTable.Rows[0][COLUMNNAME_ESTADO] = (tabOperaciones.SelectedIndex == 0 ? "" : cboExcepciones.SelectedValue.ToString());
                                                    dataTable.Rows[0][COLUMNNAME_PIE_ESTADO] = cboExcepciones.SelectedValue.ToString();
                                                    dataTable.Rows[0][COLUMNNAME_ESTADO] = cboExcepciones.Text;
                                                }
                                                //mTotalKilos =double.Parse (dataTable.Rows[0]["Pesopaquete"].ToString ());                                            

                                                mTblDatos = dataTable.Copy();
                                                //dgvActiva.DataSource = dataTable;
                                                mVistaPr = new DataView(mTblDatos, "", "FechaProduccion desc", DataViewRowState.CurrentRows);
                                                dgvActiva.DataSource = mVistaPr;
                                                dgvActiva.Columns["Obra"].Width = 500;
                                            }
                                            else
                                            {
                                                //DataTable dataTable = (DataTable)dgvActiva.DataSource;
                                                //DataRow row = dataTable.NewRow();
                                                listaDataSet = wsOperacion.ObtenerDatosConsultaGenerica(8, txtEtiquetaPieza.Text, "", "", "", "");
                                                DataRow row = mTblDatos.NewRow();
                                                foreach (DataGridViewColumn column in dgvActiva.Columns)
                                                {
                                                    row[column.Index] = listaDataSet.DataSet.Tables[0].Rows[0][column.Index];
                                                }
                                              
                                                row[COLUMNNAME_PIE_ESTADO] = cboExcepciones.SelectedValue.ToString();
                                                row[COLUMNNAME_ESTADO] = cboExcepciones.Text;
                                                mTotalKilos = mTotalKilos + double.Parse(row["PesoPaquete"].ToString());
                                                //dataTable.Rows.Add(row);
                                                mTblDatos.Rows.Add(row);
                                            }
                                            //tlbNuevo.PerformClick();
                                            //Forms forms = new Forms();
                                            if (tabOperaciones.SelectedIndex == 0)
                                                forms.dataGridViewHideColumns(dgvEtiquetasPiezas, new string[] { "ERR", "PIE_ESTADO", "ESTADO" });
                                            else
                                                forms.dataGridViewHideColumns(dgvEtiquetasPiezasExcepciones, new string[] { "ERR", "PIE_ESTADO" });

                                            forms.dataGridViewAutoSizeColumnsMode(dgvEtiquetasPiezas, DataGridViewAutoSizeColumnsMode.DisplayedCells);
                                            //tlbEstado.Text = "Registro(s): " + dgvRecepciones.Rows.Count;
                                            lblCantidadEtiquetasPiezas.Text = "Registro(s): " + dgvEtiquetasPiezas.Rows.Count;
                                            lblCantidadEtiquetasPiezasExcepciones.Text = "Registro(s): " + dgvEtiquetasPiezasExcepciones.Rows.Count;
                                            //txtEtiquetaPieza.Text = (int.Parse(txtEtiquetaPieza.Text) + 1).ToString() ;                                           

                                        }   
                                        //}
                                        //else
                                        //    MessageBox.Show("La etiqueta '" + txtEtiquetaPieza.Text + "' tiene un diametro (" + diametro + ") distinto al de la colada.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                     }
                                }

                                else
                                    MessageBox.Show("La etiqueta '" + txtEtiquetaPieza.Text + "' no existe.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    else
                    {

                    }
                   // WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
                   // WsOperacion.ListaDataSet listaDataSet = new WsOperacion.ListaDataSet();
                    //
                    if (mIdEtiquetaColada.ToString ().Trim().Length > 0)
                    //if (txtEtiquetaColada.Text.Trim().Length > 0)
                    {
                        listaDataSet = wsOperacion.ObtenerDatosProduccionPorColada(mIdEtiquetaColada);
                        //listaDataSet = wsOperacion.ObtenerDatosProduccionPorColada(txtEtiquetaColada.Text);
                        if (listaDataSet.MensajeError.Equals(""))
                        {
                            if (listaDataSet.DataSet.Tables[0].Rows.Count > 0)
                            {
                                Lbl_SaldoKilosColada.Text = listaDataSet.DataSet.Tables[0].Rows[0]["SaldoKiloscolada"].ToString();
                                Lbl_KgsProd.Text = listaDataSet.DataSet.Tables[0].Rows[0]["Kilosproducidos"].ToString();
                                Lbl_NroPiezas.Text = listaDataSet.DataSet.Tables[0].Rows[0]["PiezasProducidas"].ToString();
                                Lbl_NroEtiq.Text = listaDataSet.DataSet.Tables[0].Rows[0]["NroEtiquetas"].ToString();
                            }
                            else
                            {
                                Lbl_SaldoKilosColada.Text = lblKilos.Text;
                            }
                        }
                    }
                    ActualizaKilosProducidos();
                    txtEtiquetaPieza.Clear();
                    txtEtiquetaPieza.Focus();
                }
            }
            //lblKilos.Text = dt.Rows[0]["KILOS"].ToString();
            //01/11/2014 Segun proyecto de muestreo se agrega llamada
            //VerificaMuestreo(diametro);

        }

        private void RegistraDatosSinColadas()
        {
            DataGridView dgvActiva = null; bool lPuedeContinuar = false;
            Forms forms = new Forms(); string diametro = "";
            WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
            WsOperacion.ListaDataSet listaDataSet = new WsOperacion.ListaDataSet(); string iDiam = "";

            if (!txtEtiquetaPieza.Text.Trim().Equals(""))
            {
                switch (tabOperaciones.SelectedIndex)
                {
                    case 0:
                        dgvActiva = dgvEtiquetasPiezas;
                        break;
                    case 1:
                        dgvActiva = dgvEtiquetasPiezasExcepciones;
                        break;
                }
                if (dgvActiva != null)
                {
                    if (forms.dataGridViewSearchText(dgvActiva, COLUMNNAME_ETIQUETA_PIEZA, txtEtiquetaPieza.Text) == -1)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        try
                        {

                            //listaDataSet = wsOperacion.ObtenerPieza(Convert.ToInt32(txtEtiquetaPieza.Text));
                            //22/05/2013 por solicitud de TO, para los datos a visualizar 
                            listaDataSet = wsOperacion.ObtenerDatosConsultaGenerica(8, txtEtiquetaPieza.Text, "", "", "", "");
                            if (listaDataSet.MensajeError.Equals(""))
                            {
                                if (listaDataSet.DataSet.Tables[0].Rows.Count > 0)
                                {
                                    //verificamos que el paquete no este  despachado
                                    if (PaqueteEstaProducido(listaDataSet.DataSet.Tables[0].Copy()) == false)
                                    {                                       
                                                double lPesoEtiqueta = 0;
                                                //listaDataSet = wsOperacion.ObtenerDatosConsultaGenerica(8, txtEtiquetaPieza.Text, "", "", "", "");
                                                DataTable dataTable = listaDataSet.DataSet.Tables[0];
                                                if (dataTable.Rows.Count > 0)
                                                {
                                                    lPesoEtiqueta = double.Parse(dataTable.Rows[0]["PesoPaquete"].ToString());                                     
                                                }                                                                                               
                                                    int lPiezasPaq = (int)listaDataSet.DataSet.Tables[0].Rows[0]["PiezasPaq"];
                                                    RegistraPiezaProducida(mIdEtiquetaColada, txtEtiquetaPieza.Text, lPiezasPaq, mUserLog, lPiezasPaq);
                                                    //RegistraPiezaProducida(txtEtiquetaColada.Text, txtEtiquetaPieza.Text, lPiezasPaq, mUserLog, lPiezasPaq);
                                                    lPuedeContinuar = true;
                                            }                                            
                                        if (lPuedeContinuar == true)
                                        {
                                            if (dgvActiva.DataSource == null)
                                            {
                                                listaDataSet = wsOperacion.ObtenerDatosConsultaGenerica(8, txtEtiquetaPieza.Text, "", "", "", "");
                                                DataTable dataTable = listaDataSet.DataSet.Tables[0];
                                                if (dataTable.Rows.Count > 0)
                                                {
                                                    //dataTable.Rows[0][COLUMNNAME_ESTADO] = (tabOperaciones.SelectedIndex == 0 ? "" : cboExcepciones.SelectedValue.ToString());
                                                    dataTable.Rows[0][COLUMNNAME_PIE_ESTADO] = cboExcepciones.SelectedValue.ToString();
                                                    dataTable.Rows[0][COLUMNNAME_ESTADO] = cboExcepciones.Text;
                                                }
                                                //mTotalKilos =double.Parse (dataTable.Rows[0]["Pesopaquete"].ToString ());                                            
                                                mTblDatos = dataTable.Copy();
                                                //dgvActiva.DataSource = dataTable;
                                                mVistaPr = new DataView(mTblDatos, "", "FechaProduccion desc", DataViewRowState.CurrentRows);
                                                dgvActiva.DataSource = mVistaPr;
                                                dgvActiva.Columns["Obra"].Width = 500;
                                            }
                                            else
                                            {
                                                //DataTable dataTable = (DataTable)dgvActiva.DataSource;
                                                //DataRow row = dataTable.NewRow();
                                                listaDataSet = wsOperacion.ObtenerDatosConsultaGenerica(8, txtEtiquetaPieza.Text, "", "", "", "");
                                                DataRow row = mTblDatos.NewRow();

                                                foreach (DataGridViewColumn column in dgvActiva.Columns)
                                                {
                                                    row[column.Index] = listaDataSet.DataSet.Tables[0].Rows[0][column.Index];
                                                }

                                                row[COLUMNNAME_PIE_ESTADO] = cboExcepciones.SelectedValue.ToString();
                                                row[COLUMNNAME_ESTADO] = cboExcepciones.Text;
                                                mTotalKilos = mTotalKilos + double.Parse(row["PesoPaquete"].ToString());
                                                //dataTable.Rows.Add(row);
                                                mTblDatos.Rows.Add(row);
                                            }
                                            //tlbNuevo.PerformClick();
                                            //Forms forms = new Forms();
                                            if (tabOperaciones.SelectedIndex == 0)
                                                forms.dataGridViewHideColumns(dgvEtiquetasPiezas, new string[] { "ERR", "PIE_ESTADO", "ESTADO" });
                                            else
                                                forms.dataGridViewHideColumns(dgvEtiquetasPiezasExcepciones, new string[] { "ERR", "PIE_ESTADO" });

                                            forms.dataGridViewAutoSizeColumnsMode(dgvEtiquetasPiezas, DataGridViewAutoSizeColumnsMode.DisplayedCells);
                                            //tlbEstado.Text = "Registro(s): " + dgvRecepciones.Rows.Count;
                                            lblCantidadEtiquetasPiezas.Text = "Registro(s): " + dgvEtiquetasPiezas.Rows.Count;
                                            lblCantidadEtiquetasPiezasExcepciones.Text = "Registro(s): " + dgvEtiquetasPiezasExcepciones.Rows.Count;
                                            //txtEtiquetaPieza.Text = (int.Parse(txtEtiquetaPieza.Text) + 1).ToString() ;                                           

                                        }
                                        //}
                                        //else
                                        //    MessageBox.Show("La etiqueta '" + txtEtiquetaPieza.Text + "' tiene un diametro (" + diametro + ") distinto al de la colada.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }

                                else
                                    MessageBox.Show("La etiqueta '" + txtEtiquetaPieza.Text + "' no existe.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //}
                            //else
                            //    MessageBox.Show(listaDataSet.MensajeError.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        catch (Exception exc)
                        {
                            MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        Cursor.Current = Cursors.Default;
                    }
                    else
                    {

                    }
                    // WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
                    // WsOperacion.ListaDataSet listaDataSet = new WsOperacion.ListaDataSet();
                    //
                    if (mIdEtiquetaColada.ToString().Trim().Length > 0)
                    //if (txtEtiquetaColada.Text.Trim().Length > 0)
                    {
                        listaDataSet = wsOperacion.ObtenerDatosProduccionPorColada(mIdEtiquetaColada);
                        //listaDataSet = wsOperacion.ObtenerDatosProduccionPorColada(txtEtiquetaColada.Text);
                        if (listaDataSet.MensajeError.Equals(""))
                        {
                            if (listaDataSet.DataSet.Tables[0].Rows.Count > 0)
                            {
                                Lbl_SaldoKilosColada.Text = listaDataSet.DataSet.Tables[0].Rows[0]["SaldoKiloscolada"].ToString();
                                Lbl_KgsProd.Text = listaDataSet.DataSet.Tables[0].Rows[0]["Kilosproducidos"].ToString();
                                Lbl_NroPiezas.Text = listaDataSet.DataSet.Tables[0].Rows[0]["PiezasProducidas"].ToString();
                                Lbl_NroEtiq.Text = listaDataSet.DataSet.Tables[0].Rows[0]["NroEtiquetas"].ToString();
                            }
                            else
                            {
                                Lbl_SaldoKilosColada.Text = lblKilos.Text;
                            }
                        }
                    }
                    ActualizaKilosProducidos();
                    txtEtiquetaPieza.Clear();
                    txtEtiquetaPieza.Focus();
                }
            }
            //lblKilos.Text = dt.Rows[0]["KILOS"].ToString();
            //01/11/2014 Segun proyecto de muestreo se agrega llamada
            //VerificaMuestreo(diametro);

        }


        private void txtEtiquetaPieza_Validating(object sender, CancelEventArgs e)
        {
            string lValidarColadas = ConfigurationManager.AppSettings["ValidaColadaEnProduccion"].ToString();
            

            if (EtiquetaFueImpresa() == false)
            {

                if (lValidarColadas.ToUpper().Equals("S"))
                {
                    RegistraDatosConColadas();
                }
                else
                {
                    RegistraDatosSinColadas();
                }
            }
            
        }


        private bool  EtiquetaFueImpresa()
        {
            bool lEtiquetaImpresa = false;
            WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
            WsOperacion.ListaDataSet listaDataSet = new WsOperacion.ListaDataSet();
            Ws_TO.Ws_ToSoap lPx = new Ws_TO.Ws_ToSoapClient(); string lSql = "";
            DataSet lDts = new DataSet();DataTable lTbl =new DataTable ();

            string lMsg = "Esta etiqueta no ha sido impresa, avisar a su jefe"; string lCuerpoMsg = "";
            listaDataSet = wsOperacion.ObtenerDatosConsultaGenerica (8,txtEtiquetaPieza.Text ,"","","","");
            if (listaDataSet.MensajeError.Equals(""))
            {
                if (listaDataSet.DataSet.Tables[0].Rows.Count > 0)
                {
                    lTbl = listaDataSet.DataSet.Tables[0].Copy();
                    if (lTbl.Rows[0]["Impresa"].ToString().ToUpper().Equals("S"))
                    {
                        lEtiquetaImpresa = true;
                        // Cuando ocurra esto en pantalla de totem se indicará al operario 
                        // "Esta etiqueta no ha sido impresa, avisar a su jefe", dejando un registro en log   
                        // para ver la ocurrencia aposterior y enviando un correo a la lista definida a continuación.                            
                        //1.- Mostramos el Mensaje 
                        MessageBox.Show(lMsg, "Avisos Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //2.- Enviamos el Mail de Notificación IdOBra =-400
                        lCuerpoMsg = string.Concat("Hola estimados: ", Environment.NewLine, " Se ha detectado que la Etiqueta leida NO ha sido impresa", Environment.NewLine);
                        lCuerpoMsg = string.Concat(lCuerpoMsg, Environment.NewLine, "Los datos recopilados son:");
                        lCuerpoMsg = string.Concat(lCuerpoMsg, Environment.NewLine, "Fecha :", DateTime.Now.ToShortDateString());
                        lCuerpoMsg = string.Concat(lCuerpoMsg, Environment.NewLine, "Usuario:", mUserLog.Login);
                        lCuerpoMsg = string.Concat(lCuerpoMsg, Environment.NewLine, "Viaje:", lTbl.Rows[0]["Codigo"].ToString());
                        lCuerpoMsg = string.Concat(lCuerpoMsg, Environment.NewLine, "Id Totem:", mUserLog.IdTotem );
                        lCuerpoMsg = string.Concat(lCuerpoMsg, Environment.NewLine, "Máquina:", mUserLog.IdMaquina );
                        lCuerpoMsg = string.Concat(lCuerpoMsg, Environment.NewLine, "Número de Etiqueta:", lTbl.Rows[0]["Etiqueta"].ToString());
                        lPx.EnviaNotificacionesEnviaMsgDeNotificacion("Etiqueta", lCuerpoMsg, -400, "Etiqueta Producida Sin estar Impresa");
                        //3.- Insertamos en la Tabla de Log
                       // listaDataSet = wsOperacion.ObtenerDatosConsultaGenerica(8, txtEtiquetaPieza.Text, "", "", "", "");
                        lSql = string.Concat("SP_Consultas_WS 54,'", mUserLog.Iduser, "','", mUserLog.IdTotem ,"','",lTbl.Rows[0]["Etiqueta"].ToString(),"','" );
                        lSql = string.Concat(lSql, lTbl.Rows[0]["Codigo"].ToString(), "','",txtEtiquetaPieza.Text, "'");
                        //                    ALTER PROCEDURE [dbo].[SP_Consultas_WS]
                        //@Opcion INT,          @Par1 Varchar(100),             @Par2 Varchar(100),
                        //@Par3 Varchar(150),   @Par4 Varchar(100),             @Par5 Varchar(100),
                        //@Par6 Varchar(100),   @Par7 Varchar(100)
                        lDts = lPx.ObtenerDatos(lSql);
                    }

                }
            }           
            return lEtiquetaImpresa;
        }


        private void VerificaMuestreo(string iDiametro)
        {
    //        ALTER  PROCEDURE [dbo].[SP_CRUD_MUESTREOS]
    //@ID INT,                  //@FechaInicio VARCHAR(10),     //@FechaFin VARCHAR(10) ,    //@Diametro int,
    //@Estado VARCHAR(20),      //@KilosMuestreo int,	        //@OPCION INT

            int lIdMuestreo = 0; DataSet lDts = new DataSet(); string lSql = ""; int lKgsMuestreo = 0;
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient(); int lKgsProd = 0;
            DataTable mTblMuestreo = new DataTable(); Clases.ClsComun lCom = new Clases.ClsComun();
            
            //Revisamos que exista un muestreo para el diametro ingresado
            if (lCom.EsNumero(iDiametro) == true)
            {
                lSql = string.Concat("exec SP_CRUD_MUESTREOS  0,'','',", iDiametro, ",'',0,2");
                lDts = lPx.ObtenerDatos(lSql);
                if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                {
                    mTblMuestreo = lDts.Tables[0].Copy();
                    lIdMuestreo = (int)lDts.Tables[0].Rows[0]["Id"];
                    lKgsMuestreo = (int)lDts.Tables[0].Rows[0]["KilosMuestreo"];
                    if (lIdMuestreo > 0)  // si existe un muetreo verificamos los kilos que lleva
                    {
                        lSql = string.Concat("exec SP_CRUD_MUESTREOS ", lIdMuestreo, ",'','',0,'',0,4");
                        lDts = new DataSet();
                        lDts = lPx.ObtenerDatos(lSql);
                        if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                        {

                            lKgsProd = (int)lDts.Tables[0].Rows[0][0];
                        }
                        //Comparamos
                        //La regla es que si los Kilos Producidos son mayor que lo kilos del muestreo, debe abrir
                        //una pantalla indicando que se debe tomar la muestra de material
                        // 08/09/2014
                        lKgsProd = 33000;
                        if (lKgsProd > lKgsMuestreo)
                        {
                            Muestreo.Frm_SolicitaMuestreo lFrm = new Muestreo.Frm_SolicitaMuestreo();
                            lFrm.CargaDatos(mTblMuestreo, mUserLog, lKgsProd.ToString());
                            lFrm.ShowDialog(this);
                        }
                    }
                }
            }
        
        

            //A partir del diametro de la pieza:  si hay un muestreo vigente ==> Obtener su Id
            //                else: Insertar una muestreo nuevo y obtener su id






        }


        private void frmProduccion_Shown(object sender, EventArgs e)
        {
            txtEtiquetaPieza.Focus();
            //txtEtiquetaColada.Focus();
        }

        private void txtEtiquetaColada_Leave(object sender, EventArgs e)
        {
            txtEtiquetaColada.Text = eliminarCaracteresEspeciales(txtEtiquetaColada.Text.Trim());
        }

        private void txtObs_Leave(object sender, EventArgs e)
        {
            txtObs.Text = eliminarCaracteresEspeciales(txtObs.Text.Trim());
        }

        private void txtEtiquetaPieza_Leave(object sender, EventArgs e)
        {
            txtEtiquetaPieza.Text = eliminarCaracteresEspeciales(txtEtiquetaPieza.Text.Trim());
        }

        private void Btn_VerDetalle_Click(object sender, EventArgs e)
        {
            WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
            WsOperacion.ListaDataSet listaDataSet = new WsOperacion.ListaDataSet();
            DataTable lTbl = new DataTable(); string lTitulo = "";Clases .ClsComun iCom=new Clases.ClsComun() ;

            
            //obtenemos el detalle de las piezas producidas por la colada
            listaDataSet = wsOperacion.ObtenerDetalleProduccionPorColada(mIdEtiquetaColada );
            //listaDataSet = wsOperacion.ObtenerDetalleProduccionPorColada(txtEtiquetaColada.Text);
            if (listaDataSet.MensajeError.Equals(""))
            {
                if (listaDataSet.DataSet.Tables[0].Rows.Count > 0)
                {
                    lTitulo = string.Concat("Detalle de Piezas producidas para la colada ", txtEtiquetaColada.Text);
                    lTbl = listaDataSet.DataSet.Tables[0].Copy();
                    lTbl =iCom.SumaColumas("5,6",lTbl );
                    Frm_Detalle lFrm = new Frm_Detalle();
                    lFrm.CargaDatosGrilla(lTitulo, lTbl);
                    lFrm.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show(listaDataSet.MensajeError.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtEtiquetaPieza_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEtiquetaColada_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEtiquetaPieza_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                this.txtEtiquetaColada_Validating (null, null);
            }
        }

        private void txtObs_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtObs_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                txtEtiquetaPieza.Focus();
            }
        }

        private void Chk_MultiplesColadas_CheckedChanged(object sender, EventArgs e)
        {
            txtEtiquetaPieza.Focus();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            //VerificaMuestreo("10");
        }

        private void Btn_NotificacionAveria_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("¿Esta Seguro que desea enviar Notficación de Avería?", "Avisos Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //{ 
            
            //}

            Maquinas.NotificaAveria lFrm = new Maquinas.NotificaAveria();
            lFrm.IniciaForm(mUserLog);
            lFrm.ShowDialog();
            VerificaEstadoMaquina(mUserLog.IdMaquina.ToString());
        }


        private void EnviarNotificacionAveria()
        {
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient(); DataSet lDts = new DataSet();
            string lMsgMail = ""; string lTitulogMail = ""; string lIdMaq = ""; string lSql = ""; string lRes = "";            
            //WsOperacion.ListaDataSet listaDataSet = new WsOperacion.ListaDataSet();            
            //create PROCEDURE [dbo].[SP_Consultas_OrdenesServicio]

            // con el id de la Maq se deben obtener los datos de Descripcion de la  Maq y totem asociado
            lIdMaq = mUserLog.IdMaquina.ToString ();
            lSql=string.Concat (" SP_Consultas_OrdenesServicio 1,'",lIdMaq ,"','','','','','',''");
            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                //construimos el mensaje
                lMsgMail = string .Concat ("La Maquina ", lDts.Tables[0].Rows[0]["Maq_Nombre"].ToString() ," presenta averia, favor atender el Requerimiento ");
                lMsgMail = string.Concat(lMsgMail, Environment.NewLine, Environment.NewLine);
                lMsgMail = string.Concat(lMsgMail, " Esta Notificacion la informo el usuario: ", mUserLog.Name, " ", Environment.NewLine, Environment.NewLine);
                lMsgMail = string.Concat(lMsgMail, " Otros Datos de notificacion: ", Environment.NewLine);
                lMsgMail = string.Concat(lMsgMail, " Nombre PC: ", mUserLog.ComputerName, Environment.NewLine);
                lMsgMail = string.Concat(lMsgMail, " Id Maquina: ", mUserLog.IdMaquina, Environment.NewLine, Environment.NewLine, Environment.NewLine);
                lMsgMail = string.Concat(lMsgMail, "Este mail ha sido generado automaticamente por el sistema, por favor no responder  a esta cuenta de correo", Environment.NewLine);
                lMsgMail = string.Concat(lMsgMail, "Los Acentos y caracteres especiales  han sido eliminados para evitar problemas");

                //contruimos el titulo
                lTitulogMail = string.Concat("Notificación de Averia en maquina ", lDts.Tables[0].Rows[0]["Maq_Nombre"].ToString());

                //Enviamos el mensaje de notificación
                lRes=lPx.EnviaNotificacionesEnviaMsgDeNotificacion("NA", lMsgMail, -10, lTitulogMail);
                
                          
            }            
        
        }

        private void Btn_MtoMaq_Click(object sender, EventArgs e)
        {
            Maquinas.Frm_MtoMaquina lFrm = new Maquinas.Frm_MtoMaquina();
            lFrm.CargaDatos();
            lFrm.ShowDialog();
        }

        private void Btn_MtoTotem_Click(object sender, EventArgs e)
        {
            Maquinas.Frm_MtoTotem lFrm = new Maquinas.Frm_MtoTotem();
            //lFrm.CargaDatos();
            lFrm.ShowDialog();
        }

        private void Btn_Desbloquea_Click(object sender, EventArgs e)
        {
            //Antes de abrir el formulario debemos verificar que el usuario que accedio al programa es un mecanico
            PuedeIngresarReparacion();
           
          
        }

        private void PuedeIngresarReparacion( )
        {
    // ALTER PROCEDURE [dbo].[SP_CRUD_SOLUCION_AVERIA]
    //@Id int,                          //@IdNotificacion int,	            //@Obs varchar(max) ,
    //@IdUsuarioRegistra varchar(5) ,   //@Estado varchar(50),	            //@Par1 varchar(10),
    //@Par2 varchar(10),                //@Opcion int 


            // Si es cambio de Rollo No requiere validacion del perfil del mecanico.

            if (mTipoAveria.Equals("AV"))
            {
                Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient(); DataSet lDts = new DataSet();
                string lSql = ""; string lPerfil = mUserLog.PerfilUsuario; string lMsg = "";


                 //Verificamos el estado de la averia
                lSql = string.Concat("exec  SP_CRUD_NOTIFICACION_AVERIA 0,0,'','','',0,'',", mUserLog .IdMaquina , ",'',3 ");
                lDts = lPx.ObtenerDatos(lSql);
                if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                {
                    if (lDts.Tables[0].Rows[0]["EstadoSupervisor"].ToString().Equals("NOOK") && lDts.Tables[0].Rows[0]["EstadoMaq"].ToString().Equals("OP"))
                    {
                        if (lPerfil.ToString().ToUpper().Equals("SUPERVISOR"))
                        {
                            Maquinas.NotificaAveria lFrm = new Maquinas.NotificaAveria();
                            lFrm.IniciaForm(mUserLog);
                            lFrm.ShowDialog();
                        }
                        else
                        {
                            lMsg = String.Concat(" Solamente los Usuarios con Perfil de SUPERVISOR puedes Ingresar las liberaciones de  reparaciones ", Environment.NewLine, " No esta autorizado realizar la liberación de Reparaciones ");
                            MessageBox.Show(lMsg, "Avisos Sistema", MessageBoxButtons.OK);
                        }
                    }
                    else
                    {
                        if (lPerfil.ToString().ToUpper().Equals("MECANICO"))
                            {
                                Maquinas.NotificaAveria lFrm = new Maquinas.NotificaAveria();
                                lFrm.IniciaForm(mUserLog);
                                lFrm.ShowDialog();
                            }
                            else
                            {
                                lMsg = String.Concat(" Solamente los Usuarios con Perfil de Mecanicos puedes Ingresar las reparaciones ", Environment.NewLine, " No esta autorizado a ingresar Reparaciones ");
                                MessageBox.Show(lMsg, "Avisos Sistema", MessageBoxButtons.OK);
                            }
                        //}
                    }
                }

                 
            }

            else
            {
                Maquinas.NotificaAveria lFrm = new Maquinas.NotificaAveria();
                lFrm.IniciaForm(mUserLog);
                lFrm.ShowDialog();
            }
           
               
              VerificaEstadoMaquina(mUserLog.IdMaquina.ToString());
     
        }

    }
}