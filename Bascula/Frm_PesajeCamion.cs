using CommonLibrary2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Metalurgica.Bascula
{
    
    public partial class Frm_PesajeCamion : Form
    {
        private CurrentUser mUserLog = new CurrentUser();
        private int mIdPesajeCamion = 0;
        private int mToleranciaBascula = 0;
        private int mKilosCargadosCamion = 0;
        private int mKilosFactorCorreccion = 0;
        private int mKilosFactorCorreccionDesa = 0;
        private int mKilosCargadosCamionDesarrollo = 0;
        private string mIdCorrelativo = "";
        private DataTable mTblCamiones = new DataTable();
        private DataTable mTblCamionesDespachados = new DataTable();
        private DataTable mTblKgsAdicionales = new DataTable();
        private DataTable mTblParametro = new DataTable();
        private DataTable mTblConfTolerancia = new DataTable();
        private Boolean mBuscaDatosPatente = false;
        private string mUserAutoriza = "";
        private string mObsUserAutoriza = "";
        private double  mToteranciaExtra= 0;
        private Double mToleranciaReal = 0;
        private Double mToleranciaRealDesa = 0;
        public Frm_PesajeCamion()
        {
            InitializeComponent();
        }

        private void ObtenerTaraDesdeAccess()
        {
            string lTara = ObtenerTara();
            this.Tx_Tara.Text = lTara;
            Tx_PesoNeto.Text = "";

            Tx_PesoNeto.Text = "";
            Tx_ToleranciaReal.Text = "";

            Tx_KgsCargados.Text = "";
            Tx_DiferenciaKilos.Text = "";

            Tx_Bruto.Text = "";
            this.Tx_IdCorrCarga.Text = "";
        }

        private void Btn_ObtenerTara_Click(object sender, EventArgs e)
        {
            string lTara = ObtenerTara();
            this.Tx_Tara.Text = lTara;
            Tx_PesoNeto.Text = "";

            Tx_PesoNeto.Text = "";
            Tx_ToleranciaReal.Text = "";

            Tx_KgsCargados.Text = "";
            Tx_DiferenciaKilos.Text = "";

            Tx_Bruto.Text = "";
            this.Tx_IdCorrCarga.Text = "";


        }

        public void IniciaForm( CurrentUser iUseActivo)
        {
            mUserLog = iUseActivo;
            this.Dtp_FechaActual.Value = DateTime.Now;
            this.Dtp_FechaActual.MaxDate = DateTime.Now;
            this.Dtp_FechaActual.MinDate = DateTime.Now .AddDays(-1);
            Rb_Tara.Checked = true;
            MuestraDatosSegunCheck();
            string lToleranciaBascula = ConfigurationManager.AppSettings["ToleranciaBascula"].ToString();

            if (lToleranciaBascula.Length > 0)
                mToleranciaBascula = int.Parse(lToleranciaBascula);

            Tx_ToleranciaBascula.Text = mToleranciaBascula.ToString();

             ObtenerCamionesEnPlanta();
            Dtg_CamionEnPlanta.DataSource = mTblCamiones;

            Dtg_CamionDespachados.DataSource = mTblCamionesDespachados ;
            Dtg_Parametros.DataSource = mTblParametro;

            // formateaGrillas();
            CargaDatosDespachosSinGuiaINET();

            //RevisionGuias();
        }


        #region Metodos privados de la clase

        private void ValidaElementosAdicionales(string iTipo)
        {
            int lValor = 0;string lMsg = "";int lKgsCuartones = 0; DataView lVista = null;
            int lKgsEstrobos = 0;
            // Validamos el Ingreso de Nro de Cuartones
            if (iTipo == "C")
            {
                try
                {
                    lValor = int.Parse(Tx_nroCuartones.Text);
                    if (lValor < 0)
                        lMsg = " Solo debe Ingresar valores Enteros mayor que cero y menor que 10";
                    else
                    {
                        if (lValor > 10)
                            lMsg = " El máximo de cuartones es 10, NO puede ingresar mas de 10, Modifique la  cantidad";
                        else
                        {
                            lVista = new DataView(mTblKgsAdicionales, "Subtabla='KgsCuartones'", "", DataViewRowState.CurrentRows);
                            if (lVista.Count > 0)
                            {
                                lKgsCuartones = int.Parse(lVista[0]["Par1"].ToString());
                                lKgsCuartones = lKgsCuartones * lValor;
                                Tx_KgsCuartones.Text = lKgsCuartones.ToString();
                            }
                        }
                    }

                }
                catch
                {
                    lMsg = " Solo debe Ingresar valores Enteros mayor que cero";
                }
                if (lMsg.Trim().Length > 0)
                {
                    MessageBox.Show(lMsg, "Avisos Sistemas", MessageBoxButtons.OK);
                    Tx_nroCuartones .Focus();
                }
            }

            // Validamos el Ingreso de Nro de Estrobos
            if (iTipo == "E")
            {
                try
                {
                    lValor = int.Parse(Tx_nroEstrobos.Text);
                    if (lValor < 0)
                        lMsg = " Solo debe Ingresar valores Enteros mayor que cero";
                    else
                    {
                        if (lValor > 100)
                            lMsg = " El máximo de cuartones es 100, NO puede ingresar mas de 100, Modifique la  cantidad";
                        else
                        {
                                lVista = new DataView(mTblKgsAdicionales, "Subtabla='KgsEstrobos'", "", DataViewRowState.CurrentRows);
                                if (lVista.Count > 0)
                                {
                                    lKgsEstrobos = int.Parse(lVista[0]["Par1"].ToString());
                                    lKgsEstrobos = lKgsEstrobos * lValor;
                                    Tx_KgsEstrobos.Text = lKgsEstrobos.ToString();
                                }
                        }
                    }
                }
                catch
                {
                    lMsg = " Solo debe Ingresar valores Enteros mayor que cero";
                }

                if (lMsg.Trim().Length > 0)
                {
                    MessageBox.Show(lMsg, "Avisos Sistemas", MessageBoxButtons.OK);
                    Tx_nroEstrobos.Focus();
                }

            }
            mBuscaDatosPatente = false;
            SumaKgsAdicionales();
            mBuscaDatosPatente = true ;
        }

        private void SumaKgsAdicionales()
        {
            Clases.ClsComun lCom = new Clases.ClsComun();
            int lKgsC = 0; int lKgsE = 0;
            try
            {
                lKgsC = int.Parse(Tx_KgsCuartones.Text  );
            }
            catch
            {
                lKgsC = 0;
            }

            try
            {
                lKgsE = int.Parse(Tx_KgsEstrobos.Text );
            }
            catch
            {
                lKgsE = 0;
            }

            Tx_TotalKgs.Text = (lKgsC + lKgsE).ToString();
            Tx_PesoAdicional .Text = (lKgsC + lKgsE).ToString();
            Tx_PesoSoloFierro.Text = (lCom.Val(Tx_PesoNeto.Text) - lCom.Val(Tx_PesoAdicional.Text)).ToString ();
            CargaPesoBruto();

        }

        private void  ObtenerCamionesEnPlanta()
        {
            WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
            WsOperacion.ListaDataSet lLIstaDts = new WsOperacion.ListaDataSet(); DataTable lTbl = new DataTable();
            int i = 0; DataTable lTblParametro = new DataTable();
            lLIstaDts = wsOperacion.ObtenerCamionesEnPlanta();

            if ((lLIstaDts.DataSet != null) && (lLIstaDts.DataSet.Tables.Count > 0))
            {
                mTblCamiones = lLIstaDts.DataSet.Tables["CamionesEnPlanta"].Copy();
                mTblCamionesDespachados = lLIstaDts.DataSet.Tables["DespachosRealizados"].Copy();
                mTblKgsAdicionales = lLIstaDts.DataSet.Tables["KgsAdicionales"].Copy();
                mTblConfTolerancia = lLIstaDts.DataSet.Tables["ConfigTolerancia"].Copy();

                mTblParametro = new DataTable();
                mTblParametro.Columns.Add("Parametro",Type.GetType("System.String"));
                mTblParametro.Columns.Add("Valor", Type.GetType("System.String"));

                //Obtenemos Columna EstadoBascula
               // ObtenerEstadoProcesoBascula
               //lTbl = mTblCamiones;
                for (i = 0; i < mTblCamiones.Rows.Count; i++)
                {
                    mTblCamiones.Rows[i]["ProcesoBascula"] = ObtenerEstadoProcesoBascula(mTblCamiones.Rows[i]["IdCorrelativo"].ToString());
                }

                // Agregamos los datos de Parametros
                // Kilos adicionales
                lTbl = mTblKgsAdicionales;
                for (i = 0; i < lTbl.Rows.Count; i++)
                {
                    DataRow lFila = mTblParametro.NewRow();
                    lFila["Parametro"] = lTbl.Rows [i]["SubTabla"].ToString ();
                    lFila["Valor"] = string.Concat(lTbl.Rows[i]["Par1"].ToString(), " Kgs");
                    mTblParametro.Rows.Add(lFila);
                }
                // Tolerancia bascula
                lTbl = mTblConfTolerancia.Copy ();
                for (i = 0; i < lTbl.Rows.Count; i++)
                {
                    DataRow lFila = mTblParametro.NewRow();
                    lFila["Parametro"] = lTbl.Rows[i]["SubTabla"].ToString();
                    lFila["Valor"] = string.Concat(lTbl.Rows[i]["Par1"].ToString(), " %");
                    mTblParametro.Rows.Add(lFila);
                }

                //tolerancia sobre cotas.
                mToteranciaExtra = wsOperacion.ObtenerTotelaciaExtra();


            }


            //return lTbl;

            //        private DataTable  = new DataTable();
            //private DataTable mTblCamionesDespachados = new DataTable();

        }


        private void  EliminaRegistroPesaje( string lIdPesaje)
        {
            WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
            WsOperacion.ListaDataSet lLIstaDts = new WsOperacion.ListaDataSet(); DataTable lTbl = new DataTable();

            lLIstaDts = wsOperacion.EliminaRegistroCamion(lIdPesaje);

           
        }

        private void CerrarCicloCamion(string lIdPesaje)
        {
            WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
            WsOperacion.ListaDataSet lLIstaDts = new WsOperacion.ListaDataSet(); DataTable lTbl = new DataTable();

            lLIstaDts = wsOperacion.EliminaRegistroCamion(lIdPesaje);


        }

        private string ObtenerPesoBruto()
        {
            string lRes = "0"; string lSql = ""; Clases.SqlBascula lTipoSql = new Clases.SqlBascula();
            DataTable lTbl = new DataTable(); Clases.ClsComun lDAL = new Clases.ClsComun();
            string lFecha = DateTime.Now.ToShortDateString(); int lPesoTara = int.Parse(Tx_Tara.Text);

            lTbl = lDAL.CargaTablaRomana(lTipoSql.ObtenerSqlPesoBruto(Cmb_Patente .SelectedValue .ToString (), lFecha, lPesoTara));

            if (lTbl.Rows.Count > 0)
            {
                lRes = lTbl.Rows[0]["PesoBruto"].ToString();
                mIdCorrelativo = lTbl.Rows[0]["Correlativo"].ToString();
                Tx_IdCorrCarga.Text = mIdCorrelativo;
            }
            else
            {
                if (Tx_IdCorrCarga.Text.Equals("-"))
                {
                    lTbl = lDAL.CargaTablaRomana(lTipoSql.ObtenerSqlPesoBrutoPorFecha(Cmb_Patente.SelectedValue.ToString(), lFecha));
                    Bascula.Frm_PatentesBascula lFrm = new Bascula.Frm_PatentesBascula();
                    lFrm.IniciaForm(lTbl);
                    lFrm.ShowDialog();
                    string lCorr = ""; string lPB = "";

                    if (AppDomain.CurrentDomain.GetData("Correlativo")!=null)
                    {
                        lCorr = AppDomain.CurrentDomain.GetData("Correlativo").ToString();
                        lPB = AppDomain.CurrentDomain.GetData("PesoBruto").ToString();

                        lRes = lPB;
                        mIdCorrelativo = lCorr;
                        Tx_IdCorrCarga.Text = mIdCorrelativo;

                    }
                   
                }
                else
                    lRes = Tx_Bruto.Text;

            }
            return lRes;
        }

        private string ObtenerEstadoProcesoBascula( string IdCorrelativo)
        {
            string lRes = "0"; string lSql = ""; Clases.SqlBascula lTipoSql = new Clases.SqlBascula();
            DataTable lTbl = new DataTable(); Clases.ClsComun lDAL = new Clases.ClsComun(); int lPesoNeto = 0;
            //string lFecha = DateTime.Now.ToShortDateString(); int lPesoTara = int.Parse(Tx_Tara.Text);

            lTbl = lDAL.CargaTablaRomana(lTipoSql.ObtenerSqlEstadoProceso(IdCorrelativo));

            if (lTbl.Rows.Count > 0)
            {
                lPesoNeto = lDAL .Val ( lTbl.Rows[0]["PesoTara"].ToString());
                if (lPesoNeto > 0)
                    lRes = "S";
                else
                    lRes = "N";
            }
            return lRes;
        }


        private string ObtenerTara()
        {
            string lRes = "";string lSql = ""; Clases.SqlBascula lTipoSql=new Clases.SqlBascula ();
            DataTable lTbl = new DataTable();Clases.ClsComun lDAL = new Clases.ClsComun();
            string lFecha = Dtp_FechaActual.Value.ToShortDateString();  //DateTime.Now.ToShortDateString();

            if (Tx_Patente.Text.Length == 0)
            {
                MessageBox.Show("Debe Ingresar una Patente para poder Obtener la Tara, revisar. . . ", "Validaciones Sistema", MessageBoxButtons.OK);
            }
            else
            {
                lSql = lTipoSql.ObtenerSqlTara(Tx_Patente.Text, lFecha);
                Tx_sql.Text = lSql;
                lTbl = lDAL.CargaTablaRomana(lSql);

                if (lTbl.Rows.Count > 0)
                {
                    lRes = lTbl.Rows[0]["PesoBruto"].ToString();
                    Tx_IdCorrTara.Text = lTbl.Rows[0]["Correlativo"].ToString();
                    mIdCorrelativo = lTbl.Rows[0]["Correlativo"].ToString();
                }
            }
            return lRes;
        }

        private string ObtenerPesoCargaCamion(string iPatente)
        {
            string lres = "0";



            return lres;

        }

        private void MuestraDatosSegunCheck()
        {

            try
            {
                if (Rb_Tara.Checked == true)
                {
                    //Cmb_Patente.Visible = false;
                    //Btn_ObtenerTara.Enabled = true;
                    Gr_Tara.Enabled = true;
                    Gr_Bruto.Enabled = false;
                    Gb_Desarrollo.Enabled = false;
                }

                if (Rb_Carga.Checked == true)
                {
                    Gr_Tara.Enabled = false;
                    Gr_Bruto.Enabled = true;
                    //cargamos el desplegable con los datos de las patentes con camion cargado
                    WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
                    WsOperacion.ListaDataSet lLIstaDts = new WsOperacion.ListaDataSet(); DataTable lTbl = new DataTable();
                    DataRow lFila = null;
                    mBuscaDatosPatente = false;
                    lLIstaDts = wsOperacion.ObtenerPatentesParaCalculoCarga();
                    if (lLIstaDts.DataSet.Tables.Count > 0)
                    {
                        lTbl = lLIstaDts.DataSet.Tables[0].Copy();
                        lFila = lTbl.NewRow();
                        lFila["patente"] = "Seleccionar";
                        lTbl.Rows.Add(lFila);
                        new Forms().comboBoxFill(Cmb_Patente, lTbl, "patente", "patente", 0);
                        Cmb_Patente.SelectedText = "Seleccionar";
                    }

                    Cmb_Patente.Visible = true;
                    Btn_ObtenerTara.Enabled = false;
                    mBuscaDatosPatente = true ;
                    Gb_Desarrollo.Enabled = true;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void IniciaProcesoGrabacion()
        {
            //IniciaForm




        }


        private Boolean  GrabarDatos()
        {
                WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
                WsOperacion.PesajeCamion lObjCam = new WsOperacion.PesajeCamion();
            WsOperacion.ListaDataSet lDts = new WsOperacion.ListaDataSet();Clases.ClsComun lCom = new Clases.ClsComun();
            string lTxMsg = ""; Boolean lRes = false;
            try
            {
                if (Rb_Tara.Checked == true)
                {
                    lObjCam.Id = 0;
                    lObjCam.Patente = Tx_Patente.Text;
                    lObjCam.PesoTara = int.Parse(Tx_Tara.Text);
                    lObjCam.FechaTara = DateTime.Now.ToString();
                    lObjCam.IdUserTara = int.Parse(mUserLog.Iduser);
                    lObjCam.PesoBruto = 0;
                    lObjCam.IdDespachoCam = 0;
                    lObjCam.Estado = "PesoTara";
                    lObjCam.IdCorrelativo = lCom.Val(mIdCorrelativo.ToString ()).ToString ();
                    lObjCam.NroCuartones = lCom.Val(Tx_nroCuartones.Text).ToString();
                    lObjCam.NroEstrobos = lCom.Val(Tx_nroEstrobos.Text).ToString();
                    lObjCam.KgsCuartones = lCom.Val(Tx_KgsCuartones.Text).ToString();
                    lObjCam.KgsEstrobos = lCom.Val(Tx_KgsEstrobos.Text).ToString();
                    lObjCam = wsOperacion.GrabarDatosPesajeCamion(lObjCam);
                    if (lObjCam.errors.Trim().Length == 0)
                    {
                        MessageBox.Show(" El Camión puede  posicionarse en muelle de carga ", "Avisos Sistema", MessageBoxButtons.OK);
                        mIdCorrelativo = "0";
                        Btn_Grabar.Enabled = false;
                        lRes = true;
                    }
                    else
                    {
                        MessageBox.Show(string.Concat ("Ha ocurrido el siguiente error:",lObjCam .errors .ToString ()), "Avisos Sistema", MessageBoxButtons.OK);
                    }
                }

                if (Rb_Carga.Checked == true)
                {
                    lObjCam.Id = mIdPesajeCamion;
                    lObjCam.Patente = Cmb_Patente.SelectedValue.ToString();
                    lObjCam.PesoTara = int.Parse(Tx_Tara.Text);
                    lObjCam.PesoBruto = int.Parse(Tx_Bruto.Text); ;
                    lObjCam.IdUserPesoBruto = int.Parse(mUserLog.Iduser);
                    lObjCam.Estado = "PesoCarga";
                    lObjCam.IdCorrelativo = mIdCorrelativo;
                    lObjCam.NroCuartones = lCom.Val(Tx_nroCuartones.Text).ToString ();
                    lObjCam.NroEstrobos  = lCom.Val(Tx_nroEstrobos .Text).ToString();
                    lObjCam.KgsCuartones  = lCom.Val(Tx_KgsCuartones.Text).ToString();
                    lObjCam.KgsEstrobos = lCom.Val(Tx_KgsEstrobos.Text).ToString();
                    lObjCam.UsuarioAutoriza = mUserAutoriza;
                    lObjCam.ObsAutorizacion = mObsUserAutoriza;

                    //Aca nos enganchamos con el nuevo formulario 
                    //Para implementacion fase 1, aun no el formulario con el detalle de grabación

                    //Bascula.Frm_DetalleGrabacion lForm = new Frm_DetalleGrabacion();
                    //lForm.IniciaForm(lObjCam, Btn_PesoBruto.Tag.ToString(), lCom.Val(Tx_KgsCargados.Text));
                    //lForm.ShowDialog();



                    lObjCam = wsOperacion.GrabarDatosPesajeCamion(lObjCam);
                    if (lObjCam.Id > 0)
                    {
                        //enviar Correo para informar.
                        lDts = wsOperacion.ObtenerDatosPesajeCamion(lObjCam.Id.ToString());
                        if (lDts.MensajeError.Trim().Length == 0)
                        {
                            lTxMsg = EnviaCorreoNotificacion(lDts.DataSet.Copy());
                        }
                        MessageBox.Show("Los Datos han sido Grabados Correctamente ", "Avisos Sistema", MessageBoxButtons.OK);
                        mIdCorrelativo = "0";
                        Btn_Grabar.Enabled = false;
                        lRes = true;
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lRes;
        }

        private string EnviaCorreoNotificacion(DataSet lDts  )
        {
            string lTx = "";string lRes = "";DataTable lTbl = new DataTable();DataTable lTblDespacho = new DataTable();
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient(); string lTx_Caso = "";
            string lPatente = "";  string lPesoGuia = "";string lKgsNeto = ""; string lKgsDesarrollo = "";
            string lDesviacion= ""; string lJefeTurno = "Sin Datos "; string lResultadoPesaje = "";string lObra = " Sin Datos ";
            string lPorDesviacion = "";  double  lPGD = 0; double lPbascula = 0; double lPD = 0;
              string lDesviacionDesa = ""; string lPorDesviacionDesa = "";
            string lTxAutoriza = "";

           lResultadoPesaje = Btn_PesoBruto.Tag.ToString ();


            // Concatenamos La parte de la Autorización
            DataTable lTblAut = new DataTable(); DataTable lTblDatos = new DataTable(); DataTable lTblUser = new DataTable();

            if ((lDts.Tables.Count==3)  )
            {
                lTblAut = lDts.Tables["Autoriza"].Copy();
                lTblDatos = lDts.Tables["Datos"].Copy();
                lTblUser = lDts.Tables["Usuario"].Copy();
                lTxAutoriza = "";
                if (lTblAut.Rows.Count > 0)
                {
                    lTxAutoriza = string.Concat(" Usuario: ", lTblAut.Rows[0]["SupervisorAutoriza"].ToString(), " <BR>");
                    lTxAutoriza = string.Concat(lTxAutoriza, " Fecha Autorizacion: ", lTblAut.Rows[0]["FechaAutoriza"].ToString(), " <BR>");
                    lTxAutoriza = string.Concat(lTxAutoriza , " Observacion: ", lTblAut.Rows[0]["ObsAutoriza"].ToString(), " <BR>");
                    lTxAutoriza = string.Concat(lTxAutoriza, " Nro. Estrobos: ", lTblDatos.Rows[0]["NroEstrobos"].ToString(), " <BR>");
                    lTxAutoriza = string.Concat(lTxAutoriza, " Nro. Cuartones: ", lTblDatos.Rows[0]["NroCuartones"].ToString(), " <BR>");
                }
            }

                switch (lResultadoPesaje.ToUpper())
            {
                case "+":   //Se despacha mas 
                    lTx_Caso = " Para la Obra xxx  se ha generado un <b> despacho con sobre peso </b> con los siguientes resultados";
                    lTx_Caso = string.Concat(lTx_Caso , " <BR> ", lTxAutoriza , " <BR>");
                    
                    break;
                case "-":      // Se despacha menos
                    lTx_Caso = " Para la Obra xxx  se ha generado un <b>  despacho con Ausencia de Material  </b> con los siguientes resultados";
                    lTx_Caso = string.Concat(lTx_Caso, " <BR> ", lTxAutoriza, " <BR>");
                    break;
                default:
                    lTx_Caso = " Para la Obra xxx  se ha realizado un <b> despacho conforme </b> con los siguientes resultados";
                    lTx_Caso = string.Concat(lTx_Caso, " <BR> ", lTxAutoriza, " <BR>");
                    break;
            }
            lTx = string.Concat("<table   border='1'>    <tr>  ");
            lTx = string.Concat(lTx, "  <td style = 'color: #FFFFFF; background-color: #000000 ;font-weight: normal; font-size: small;'>Patente Camión</td> ");
            lTx = string.Concat(lTx, " <td style = 'color: #FFFFFF; background-color: #000000 ;font-weight: normal; font-size: small;'>Fecha GD</td>");
            lTx = string.Concat(lTx, " <td style = 'color: #FFFFFF; background-color: #000000 ;font-weight: normal; font-size: small;'>Peso GD&nbsp; (KG)</td> ");
            lTx = string.Concat(lTx, " <td style = 'color: #FFFFFF; background-color: #000000 ;font-weight: normal; font-size: small;'>Peso Desarrollo (KG)</td> ");
            lTx = string.Concat(lTx, " <td style = 'color: #FFFFFF; background-color: #000000 ;font-weight: normal; font-size: small;'>Peso Báscula(KG)</td> ");
            lTx = string.Concat(lTx, " <td style = 'color: #FFFFFF; background-color: #000000 ;font-weight: normal; font-size: small;'>Desviación Teórica (KG)</td>");
            lTx = string.Concat(lTx, " <td style = 'color: #FFFFFF; background-color: #000000 ;font-weight: normal; font-size: small;'>Desviación Teórica(%)</td>");

            lTx = string.Concat(lTx, " <td style = 'color: #FFFFFF; background-color: #000000 ;font-weight: normal; font-size: small;'>Desviación Desarrollo (KG)</td>");
            lTx = string.Concat(lTx, " <td style = 'color: #FFFFFF; background-color: #000000 ;font-weight: normal; font-size: small;'>Desviación Desarrollo (%)</td>");


            lTx = string.Concat(lTx, " <td style = 'color: #FFFFFF; background-color: #000000 ;font-weight: normal; font-size: small;' > Nombre Jefe Turno</td>");
            lTx = string.Concat(lTx, "  </tr> ");

            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                lTbl = lTblDatos;// lDts.Tables[0].Copy();
                lPatente = lTbl.Rows[0]["Patente"].ToString();
                lPGD = int.Parse(lTbl.Rows[0]["KgsSistema"].ToString());
                lPbascula = int.Parse(lTbl.Rows[0]["KsgBascula"].ToString());
                lPesoGuia = lPbascula.ToString("N0");
               
                lKgsNeto = lPGD.ToString("N0");
                lPD = int.Parse(lTbl.Rows[0]["KgsDesarrollo"].ToString());
                lKgsDesarrollo = lPD.ToString("N0");
               
                //lPN = int.Parse(lTbl.Rows[0]["KsgBascula"].ToString());

                // % respecto al peso teórico (Peso GD) = (peso teórico – peso báscula)/Peso teórico
                lDesviacion = (lPGD - lPbascula).ToString();
                lPorDesviacion = Math.Round((((lPGD - lPbascula) * 100) / lPGD), 2).ToString();

                // calculo  desviación desarrollo
                // % respecto al peso con desarrollo = (peso con desarrollo – peso báscula)/ Peso con desarrollo
                lDesviacionDesa= (lPD - lPbascula).ToString();

                lPorDesviacionDesa = Math.Round((((lPD - lPbascula) * 100) / lPD), 2).ToString();

                //lPD = int.Parse(lTbl.Rows[0]["KgsDesarrollo"].ToString());                                
                //lDesviacionDesa = ""; lPorDesviacionDesa = "";

                lTx = string.Concat(lTx, "  <tr> ");
                lTx = string.Concat(lTx, "  <td>", lTbl.Rows[0]["Patente"].ToString()  , "</td> ");
                lTx = string.Concat(lTx, "  <td>", lTbl.Rows[0]["FechaPesoBruto"].ToString() , "</td> ");
                lTx = string.Concat(lTx, "  <td>", lPGD.ToString("N0"), "</td> ");
                lTx = string.Concat(lTx, "  <td>", lKgsDesarrollo, "</td> ");
                lTx = string.Concat(lTx, "  <td>", lPbascula.ToString("N0"), "</td> ");
                lTx = string.Concat(lTx, "  <td>", lDesviacion, "</td> ");
                lTx = string.Concat(lTx, "  <td>", lPorDesviacion.ToString(), "</td>  ");

                lTx = string.Concat(lTx, "  <td>", lDesviacionDesa, "</td> ");
                lTx = string.Concat(lTx, "  <td>", lPorDesviacionDesa.ToString(), "</td>  ");

                //if ((lDts.Tables.Count == 2) && (lDts.Tables[1].Rows.Count > 0))
                //{
                    lTblDespacho = lTblUser;// lDts.Tables[1].Copy();
                    lJefeTurno = lTblDespacho.Rows[0]["UsuarioDespacha"].ToString();
                    lObra = lTblDespacho.Rows[0]["Nombre"].ToString();
                //}
                lTx = string.Concat(lTx, "  <td>", lJefeTurno.ToString(), "</td>   </tr>   </table>  ");

                //lTx = string.Concat(lTx, " Jefe de Turno a Cargo    :", lJefeTurno, "<Br>");
                lTx = string.Concat(lTx, " <BR> <BR> <BR> " );
                lTx = string.Concat(lTx, "  Este mensaje a sido generado de forma Automatica, favor NO responder este correo <BR>");
                lTx = string.Concat(lTx, "  Los acentos y caracteres especiales han sido eliminado del correo <BR>");

                lTx_Caso = lTx_Caso.Replace("xxx", lObra);

                lTx = string.Concat(lTx_Caso, " <BR> <BR>", lTx);

            }

            lRes = lPx.EnviaNotificacionesEnviaMsgDeNotificacion("", lTx, -900, string.Concat ("Detalle de Pesaje Camión Patente: ", lPatente));
            //if (lRes.ToUpper().Equals("OK"))

                return lRes;


        }




        #endregion

        private Boolean RevisaDatosAntesGrabacion()
        {
            Boolean lRes = true; string lMsg = "";


            if (Tx_Semaforo.BackColor == Color.Red)
            {
                WsOperacion.PesajeCamion lObjCam = new WsOperacion.PesajeCamion();
                Clases.ClsComun lCom = new Clases.ClsComun();
                lObjCam.Id = mIdPesajeCamion;
                lObjCam.Patente = Cmb_Patente.SelectedValue.ToString();
                lObjCam.PesoTara = int.Parse(Tx_Tara.Text);
                lObjCam.PesoBruto = int.Parse(Tx_Bruto.Text); ;
                lObjCam.IdUserPesoBruto = int.Parse(mUserLog.Iduser);
                lObjCam.Estado = "PesoCarga";
                lObjCam.IdCorrelativo = mIdCorrelativo;
                lObjCam.NroCuartones = lCom.Val(Tx_nroCuartones.Text).ToString();
                lObjCam.NroEstrobos = lCom.Val(Tx_nroEstrobos.Text).ToString();
                lObjCam.KgsCuartones = lCom.Val(Tx_KgsCuartones.Text).ToString();
                lObjCam.KgsEstrobos = lCom.Val(Tx_KgsEstrobos.Text).ToString();

                // Tx_ToleranciaReal.Text 
                if (Tx_Semaforo .BackColor == Color.Red)
                {
                    //if (Math.Abs (mToleranciaReal - mToteranciaExtra) < Double.Parse(Tx_ToleranciaBascula.Text))
                    //{
                        //********Solicitamos autorización del supervisor ************
                        lMsg = string.Concat(" El Despacho del Camión esta por Sobre lo Permitido.", Environment.NewLine, "   Para Realizar el Despacho debe Ingresar una Clave de Supervisor");
                        lMsg = string.Concat(lMsg, Environment.NewLine, " Para poder realizar el despacho, Ingrese Clave de supervisor ");
                        lRes = false;
                        MessageBox.Show(lMsg, "Avisos Sistema", MessageBoxButtons.OK);
                        lRes = false;
                        Bascula.Frm_AutorizaDespacho lFrm = new Frm_AutorizaDespacho();
                        lFrm.IniciaFormulario(lObjCam, mKilosCargadosCamion.ToString(), Tx_ToleranciaReal.Text, Dtp_FechaActual.Value.ToShortDateString());
                        lFrm.ShowDialog();
                        if (AppDomain.CurrentDomain.GetData("UserAutoriza") != null)
                        {
                            mUserAutoriza = AppDomain.CurrentDomain.GetData("UserAutoriza").ToString();
                            mObsUserAutoriza = AppDomain.CurrentDomain.GetData("ObsUserAutoriza").ToString();
                            if (mUserAutoriza.Trim().Length > 0)
                            {
                                GrabarDatos();
                                button1.Enabled = false;
                            }
                        }
                        //************************
                    //}
                    //else
                    //{
                    //    //********Mensaje de No se puede Grabar ************
                    //    MessageBox.Show("NO se puede realizar la Grabación de datos ya que el Camión Excede la tolerancia permitida", "Avisos Sistema", MessageBoxButtons.OK);
                    //    lRes = false;
                    //}
                }
               

                    //     if (mToleranciaReal > Double.Parse(Tx_ToleranciaBascula.Text))

                 

            }
            return lRes;

        }

        private void Btn_Grabar_Click(object sender, EventArgs e)
        {
            if (RevisaDatosAntesGrabacion ()==true )
            {
                if (GrabarDatos() == true)
                {
                    button1.Enabled = false;
                }
            }
        }

        private void Btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frm_PesajeCamion_Load(object sender, EventArgs e)
        {
              formateaGrillas();
        }

        private void Rb_Tara_CheckedChanged(object sender, EventArgs e)
        {
            if (Rb_Tara.Checked == true)
            {
                MuestraDatosSegunCheck();
            }
        }

        private void Rb_Carga_CheckedChanged(object sender, EventArgs e)
        {
            if (Rb_Carga.Checked == true)
            {
                MuestraDatosSegunCheck();
            }
        }

        private void Cmb_Patente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((Cmb_Patente.SelectedValue!=null ) && (Cmb_Patente .SelectedValue.ToString ()!="Seleccionar" ))
                {
                if (mBuscaDatosPatente == true)
                {
                    CargaDatosPesoTaraPorPatente(Cmb_Patente.SelectedValue.ToString());
                }
              
            }
        }

        private void CargaDatosPesoTaraPorPatente(string iPatente)
        {
            WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
            WsOperacion.ListaDataSet lLIstaDts = new WsOperacion.ListaDataSet(); DataTable lTbl = new DataTable();
            LimpiaDatosPesoBruto();
            lLIstaDts = wsOperacion.ObtenerPesoTaraPorPatente(iPatente);

            Tx_Tara.Text = "0";
            //mIdPesajeCamion = int.Parse(lTbl.Rows[0]["IdPesajeCamion"].ToString());
            //Tx_IdCorrTara.Text = mIdPesajeCamion.ToString();
            mKilosCargadosCamion = 0;
            mKilosCargadosCamionDesarrollo = 0; 

            if (lLIstaDts.DataSet.Tables.Count > 0)
            {
                lTbl = lLIstaDts.DataSet.Tables[0].Copy();
                if (lTbl.Rows.Count > 0)
                {
                    Tx_Tara.Text = lTbl.Rows[0]["PesoTara"].ToString();
                    mIdPesajeCamion = int.Parse(lTbl.Rows[0]["IdPesajeCamion"].ToString());
                    Tx_IdPesajeCam.Text = mIdPesajeCamion.ToString();
                    Tx_IdCorrTara.Text = mIdPesajeCamion.ToString();
                    mKilosCargadosCamion = int.Parse(lTbl.Rows[0]["KgsCargados"].ToString());
                    mKilosCargadosCamionDesarrollo = int.Parse(lTbl.Rows[0]["KgsDesarrollo"].ToString());
                     mKilosFactorCorreccion=int.Parse(lTbl.Rows[0]["KgsFC"].ToString());
                    mKilosFactorCorreccionDesa = int.Parse(lTbl.Rows[0]["KgsFC_Desa"].ToString());
                    Tx_Tara.ReadOnly = true;

                }
                else
                {
                    Tx_Tara.Text = "0";
                    mIdPesajeCamion = 0;
                    Tx_IdPesajeCam.Text = "0";
                    Tx_IdCorrTara.Text = "0";
                    mKilosCargadosCamion = 0;
                    mKilosCargadosCamionDesarrollo = 0;
                    Tx_Tara.ReadOnly = true;
                }
            }

             CargaPesoBruto();
        }

        private void CargaDatosDespachosSinGuiaINET()
        {
            WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
            WsOperacion.ListaDataSet lLIstaDts = new WsOperacion.ListaDataSet(); DataTable lTbl = new DataTable();
            LimpiaDatosPesoBruto();
            lLIstaDts = wsOperacion.ObtenerDatosGuiasSinVincular( );
            if (lLIstaDts.DataSet.Tables.Count > 0)
            {
                lTbl = lLIstaDts.DataSet.Tables[0].Copy();
                if (lTbl.Rows.Count > 0)
                {
                    Dtg_SinVincular.DataSource = lTbl;
                    Dtg_SinVincular.Columns[0].Width = 50;
                    Dtg_SinVincular.Columns[1].Width = 70;
                    Dtg_SinVincular.Columns[2].Width = 70;
                    Dtg_SinVincular.Columns[3].Width = 50;
                    //Dtg_SinVincular.Columns[0].Width = 50;
                    //Dtg_SinVincular.Columns[0].Width = 50;

                }
            }

         
        }

        private void RevisionGuias()
        {
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient();DataSet lDts = new DataSet();
            DataTable lTbl = new DataTable();

        string lSql= "  SP_ConsultasGenerales 116,' ','','','',''";
            lDts = lPx.ObtenerDatos(lSql);
       
            if (lDts.Tables.Count > 0)
            {
                lTbl = lDts.Tables[0].Copy();
                if (lTbl.Rows.Count > 0)
                {
                    Dtg_GuiasINET.DataSource = lTbl;
                    //Dtg_SinVincular.Columns[0].Width = 50;
                    //Dtg_SinVincular.Columns[1].Width = 70;
                    //Dtg_SinVincular.Columns[2].Width = 70;
                    //Dtg_SinVincular.Columns[3].Width = 50;
                    ////Dtg_SinVincular.Columns[0].Width = 50;
                    ////Dtg_SinVincular.Columns[0].Width = 50;

                }
            }


        }

        private void LimpiaDatosPesoBruto()
        {
            Tx_Bruto.Text = "0";

            Tx_Bruto.Text = "0";
            Tx_PesoNeto.Text = "0";
            Tx_PesoAdicional.Text = "0";
            Tx_PesoSoloFierro.Text = "0";
            Tx_KgsCargados.Text = "0";
            Tx_DiferenciaKilos.Text = "0";
            Tx_ToleranciaReal.Text = "0";
            Tx_KgsDesarrollo.Text = "0";
            Tx_DifDesarrollo.Text = "0";
             Tx_ToleranciaDesa  .Text = "0";

        }


        private void CargaPesoBruto()
        {
            Clases.ClsComun lCom = new Clases.ClsComun();
            int lDiferencia = 0;
            //ObtenerPesoBruto
            int lPesoBruto = int.Parse(ObtenerPesoBruto());
            int lPesoTara = int.Parse(Tx_Tara.Text);
            int lPesoGD = int.Parse(mKilosCargadosCamion.ToString());
            int lPesoDesarrollo = int.Parse(mKilosCargadosCamionDesarrollo.ToString());
            int lPesoAdicional = lCom.Val(Tx_PesoAdicional.Text );

            //Peso Bruto
            this.Tx_Bruto.Text = lPesoBruto.ToString();
            //Peso Neto
            this.Tx_PesoNeto.Text = (lPesoBruto - lPesoTara).ToString();
            //Peso Adicional
            if (Tx_TotalKgs.Text.Trim().Length == 0)
                Tx_TotalKgs.Text = "0";

            Tx_PesoAdicional.Text = Tx_TotalKgs.Text ;
            //Peso Solo Fierro
            Tx_PesoSoloFierro.Text = (lCom.Val(Tx_PesoNeto.Text) - lCom.Val(Tx_PesoAdicional.Text)).ToString();
            //Peso Guia Despacho
            Tx_KgsCargados.Text = lPesoGD.ToString ();
            
            int lSoloFierro = int.Parse(Tx_PesoSoloFierro.Text);

            //Datos del desarrollo
            Tx_KgsDesarrollo.Text = (lPesoDesarrollo - mKilosFactorCorreccionDesa).ToString ();
            lDiferencia = lCom.Val(Tx_PesoSoloFierro.Text) - (lPesoDesarrollo- mKilosFactorCorreccionDesa);
            Tx_DifDesarrollo.Text = lDiferencia.ToString();
            mToleranciaRealDesa = (double.Parse(lDiferencia.ToString()) / double.Parse(lSoloFierro.ToString())) * 100;
            Tx_ToleranciaDesa.Text = Math.Round(mToleranciaRealDesa, 2).ToString();

            // Factor de Corrección
            if (mKilosFactorCorreccion > 0)
            {
                Tx_FC.Text = mKilosFactorCorreccion.ToString ();
                Tx_KgsSiVa.Text  = (lPesoGD - mKilosFactorCorreccion).ToString();
            } else
            {
                Tx_FC.Text ="0";
                Tx_KgsSiVa.Text =  lPesoGD .ToString();

            }

            //Tolerancia Real
            //Diferencia Kg
            //***************************
            //tx_Tara.Text = lTbl.Rows[0]["PesoTara"].ToString();
            //mIdPesajeCamion = int.Parse(lTbl.Rows[0]["IdPesajeCamion"].ToString());
            //Tx_IdPesajeCam.Text = mIdPesajeCamion.ToString();
            //Tx_IdCorrTara.Text = mIdPesajeCamion.ToString();
            //mKilosCargadosCamion = int.Parse(lTbl.Rows[0]["KgsCargados"].ToString());
            //mKilosCargadosCamionDesarrollo = int.Parse(lTbl.Rows[0]["KgsDesarrollo"].ToString());
            //mKilosFactorCorreccion = int.Parse(lTbl.Rows[0]["KgsFC"].ToString());
            //mKilosFactorCorreccionDesa = int.Parse(lTbl.Rows[0]["KgsFC_Desa"].ToString());
            //Tx_Tara.ReadOnly = true;
            //**************************

            lDiferencia = lCom.Val(Tx_PesoSoloFierro.Text) - (lPesoGD); // - mKilosFactorCorreccion); // lPesoGD;
            Tx_DiferenciaKilos.Text = lDiferencia.ToString();  //lPGD.ToString("N0");
            mToleranciaReal = (double.Parse(lDiferencia.ToString()) / double.Parse(lSoloFierro.ToString())) * 100;
            Tx_ToleranciaReal.Text = Math.Round(mToleranciaReal, 2).ToString();
            

            PintaSemaforo(mToleranciaReal, 0, mToleranciaRealDesa);

            //Obtenemos el dato para el correo electronico
            Btn_PesoBruto.Tag = " ";
            if ((double.Parse(Tx_PesoNeto.Text) > mKilosCargadosCamion) && (mToleranciaReal > Double.Parse(Tx_ToleranciaBascula.Text)))
            {
                Btn_PesoBruto.Tag = "+";
            }

            if ((double.Parse(Tx_PesoNeto.Text) < mKilosCargadosCamion) && (mToleranciaReal > Double.Parse(Tx_ToleranciaBascula.Text)))
            {
                Btn_PesoBruto.Tag = "-";
            }
            Tx_PesoNeto.ReadOnly = true;


        }

        private void PintaSemaforo(double iTolCal, double iTolBascula, double iTolDesa)
        {
            Color lColor = new Color();DataView lVista = null; Clases.ClsComun lCom = new Clases.ClsComun();
            double lTolSuperior = 0; double lTolInferior = 0;

            if (mTblConfTolerancia.Rows.Count > 0)
            {
                //Obtemos la tolerancia  Inferior
                lVista = new DataView(mTblConfTolerancia, "SubTabla='ToleranciaInferior'", "", DataViewRowState.CurrentRows);
                if (lVista.Count > 0)
                    lTolInferior = lCom .CDBL (lVista[0]["Par1"].ToString ());

                //Obtemos la tolerancia Superior
                lVista = new DataView(mTblConfTolerancia, "SubTabla='ToleranciaSuperior'", "", DataViewRowState.CurrentRows);
                if (lVista.Count > 0)
                    lTolSuperior = lCom.CDBL(lVista[0]["Par1"].ToString());


            }
            //Btn_Grabar.Enabled = false;

            if ((Math.Abs (iTolCal) < lTolSuperior) || (Math.Abs(iTolDesa) < lTolSuperior))   // Esta por sobre la cota superior
                lColor = Color.Green ;
            else
                lColor = Color.Red;


            if (lColor == Color.Red)
            {
                if ((Math.Abs(iTolCal) < lTolInferior) || (Math.Abs(iTolDesa) < lTolInferior))    // Esta por bajo la cota inferior
                    lColor = Color.Green;
                else
                    lColor = Color.Red;
            }


               

            if ((iTolCal  == 0))   // Esta  entre 0 y  -2 
            {
                lColor = Color.Green;
                Btn_Grabar.Enabled = true;
            }


            Tx_Semaforo.BackColor = lColor;

            //if (lColor == Color.Red)
            //    Btn_Grabar.Enabled = false  ;
            //else
            //    Btn_Grabar.Enabled = true;


        }

        private void Btn_PesoBruto_Click(object sender, EventArgs e)
        {
            CargaPesoBruto();
        }

        private void Btn_GeneraDatos_Click(object sender, EventArgs e)
        {
            GeneraDatos();
        }

        private void GeneraDatos ()
        {
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient(); DataSet lDts = new DataSet();
            string lSql = ""; DataTable lTbl = new DataTable();string lIdPesaje = "";int i = 0;
            DataTable lTblTmp = new DataTable();
            string lNroGD = ""; string lPesoGD = ""; string lDif_basculaGD=""; string lDesviacion_GD_Bascula = "";
            string lPesoConDesarrollo = ""; string lDesviacion_PD_Bascula = "";

            try
            {
                lSql = String.Concat(" SP_CRUD_PesajeCamion 0, ' ',0,'',0,0,'',0,0,'',0,8 ");
                lDts = lPx.ObtenerDatos(lSql);
                if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                {
                    //NroGD - PesoGD - Dif_basculaGD - Desviación_GD_Bascula - PesoConDesarrollo  - Desviacion_PD_Bascula
                    lTbl = lDts.Tables[0].Copy();
                    for (i = 0; i < lTbl.Rows.Count; i++)
                    {
                        lIdPesaje = lTbl.Rows[i]["Id"].ToString();
                        lSql = String.Concat(" SP_CRUD_PesajeCamion ", lIdPesaje, ", ' ',0,'',0,0,'',0,0,'',0,9 ");
                        lDts = lPx.ObtenerDatos(lSql);
                        if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                        {
                            lTblTmp = lDts.Tables[0].Copy();
                            lNroGD = lTblTmp.Rows[0]["NroGuiaInet"].ToString(); lPesoGD = lTblTmp.Rows[0]["KgsGD"].ToString();
                            lDif_basculaGD = lTbl.Rows[i]["Dif KgsGD"].ToString(); lDesviacion_GD_Bascula = lTbl.Rows[i]["% Dif KgsGD"].ToString().Replace(",", ".");
                            lPesoConDesarrollo = lTbl.Rows[i]["ConDesarrollo"].ToString(); lDesviacion_PD_Bascula = lTbl.Rows[i]["% Dif KgsDesa"].ToString().Replace(",", ".");
                            lSql = string.Concat(" Update PesajeCamion set NroGD='", lNroGD, "',PesoGD=", lPesoGD, " ,Dif_basculaGD=", lDif_basculaGD);
                            lSql = string.Concat(lSql, ",Desviacion_GD_Bascula='", lDesviacion_GD_Bascula, "',PesoConDesarrollo=", lPesoConDesarrollo);
                            lSql = string.Concat(lSql, ",Desviacion_PD_Bascula='", lDesviacion_PD_Bascula, "' where id=", lIdPesaje);
                            lDts = lPx.ObtenerDatos(lSql);
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Dtg_CamionEnPlanta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int lIndex = e.RowIndex;
            if (lIndex > -1)
            {
                Tx_fechaTara.Text = Dtg_CamionEnPlanta.Rows[lIndex].Cells["FechaTara"].Value.ToString();
                Tx_IdPesaje .Text = Dtg_CamionEnPlanta.Rows[lIndex].Cells["Id"].Value.ToString();
                Tx_pesoTara .Text = Dtg_CamionEnPlanta.Rows[lIndex].Cells["PesoTara"].Value.ToString();
                Tx_patenteCamion.Text = Dtg_CamionEnPlanta.Rows[lIndex].Cells["Patente"].Value.ToString();
                Tx_usuario.Text = Dtg_CamionEnPlanta.Rows[lIndex].Cells["Usuario"].Value.ToString();
                Tx_KilosCargados .Text = Dtg_CamionEnPlanta.Rows[lIndex].Cells["KgsCargados"].Value.ToString();

                if (int.Parse(Tx_KilosCargados.Text) > 0)
                { 
                    Btn_eliminar.Enabled = false;
                    Btn_CerrarCiclo.Enabled = true;
                }
                else
                { 
                    Btn_eliminar.Enabled = true ;
                    Btn_CerrarCiclo.Enabled = false;
                }
            }

            
        }

        private void formateaGrillas()
        {
            try
            {
                int i = 0; int lKgscargados = 0;
                Dtg_CamionEnPlanta.Columns[0].Width = 40;
                Dtg_CamionEnPlanta.Columns[1].Width = 70;
                Dtg_CamionEnPlanta.Columns[2].Width = 110;
                Dtg_CamionEnPlanta.Columns[3].Width = 60;
                Dtg_CamionEnPlanta.Columns[4].Width = 60;
                Dtg_CamionEnPlanta.Columns[5].Width = 60;
                Dtg_CamionEnPlanta.Columns[6].Width = 80;
                Dtg_CamionEnPlanta.Columns[7].Width = 110;

                for (i = 0; i < Dtg_CamionEnPlanta.Rows.Count; i++)
                {
                    lKgscargados = int.Parse(Dtg_CamionEnPlanta.Rows[i].Cells["KgsCargados"].Value.ToString());
                    if (lKgscargados > 0)
                        PintaFila(ref Dtg_CamionEnPlanta, i, Color.LightSalmon);
                    else
                        PintaFila(ref Dtg_CamionEnPlanta, i, Color.LightGreen);

                }


                Dtg_CamionDespachados.Columns[0].Width = 40;
                Dtg_CamionDespachados.Columns[1].Width = 70;
                Dtg_CamionDespachados.Columns[2].Width = 100;
                Dtg_CamionDespachados.Columns[3].Width = 60;
                Dtg_CamionDespachados.Columns[4].Width = 60;
                Dtg_CamionDespachados.Columns[5].Width = 60;
                Dtg_CamionDespachados.Columns[6].Width = 80;
                Dtg_CamionDespachados.Columns[7].Width = 100;

                string lToleranciaBascula = ConfigurationManager.AppSettings["ToleranciaBascula"].ToString();
                decimal lTolerancia = decimal.Parse(lToleranciaBascula); decimal lPorcent = 0;
                for (i = 0; i < Dtg_CamionDespachados.Rows.Count; i++)
                {
                    lPorcent = Math.Abs(decimal.Parse(Dtg_CamionDespachados.Rows[i].Cells["% Dif KgsGD"].Value.ToString()));
                    if (lPorcent > lTolerancia)
                        PintaFila(ref Dtg_CamionDespachados, i, Color.LightSalmon);
                    else
                        PintaFila(ref Dtg_CamionDespachados, i, Color.LightGreen);

                }

                //Font lFuente = new Font("Arial", 10); Font lFuente2 = new Font("Arial",8);
                //Dtg_Parametros.Rows[0].Cells[1].Style.Font  = lFuente;
                //Dtg_Parametros.Rows[1].Cells[1].Style.Font = lFuente2;

                Dtg_Parametros.Columns[0].Width = 140;
                Dtg_Parametros.Columns[1].Width = 80;
               
            }

            catch (Exception exc)
            {
               MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
            }

        }

        private void PintaFila(ref DataGridView iGrilla , int iFila, Color iColor)
        {
            int lCol = 0;

            for (lCol = 0; lCol < iGrilla .ColumnCount ; lCol++)
            {
                iGrilla.Rows[iFila].Cells[lCol].Style.BackColor = iColor;
            }
            


        }

        private string EliminaRegistroCamion(string  iIdPesaje)
        {
            string lres = "";
            EliminaRegistroPesaje(iIdPesaje);
             ObtenerCamionesEnPlanta();
            Dtg_CamionEnPlanta.DataSource = mTblCamiones;

            return lres;

        }
        private string CierraCicloCamion(string iIdPesaje)
        {
            string lres = "";
            //EliminaRegistroPesaje(iIdPesaje);
            CerrarCicloCamion(iIdPesaje);
            Dtg_CamionEnPlanta.DataSource = mTblCamiones;

            return lres;

        }

        private void Btn_eliminar_Click(object sender, EventArgs e)
        {
            if (Tx_IdPesaje.Text .Length >0 )
            { 

            if (MessageBox .Show ("¿Esta Seguro que desea Eliminar el Registro Seleccionado?","Avisos Sistema",MessageBoxButtons.YesNo ,MessageBoxIcon.Question )== DialogResult.Yes )
              {
                    EliminaRegistroCamion(Tx_IdPesaje.Text);
            }
            }

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            formateaGrillas();
        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void Tx_nroCuartones_Validating(object sender, CancelEventArgs e)
        {
            ValidaElementosAdicionales("C");
        }

        private void Tx_nroEstrobos_Validating(object sender, CancelEventArgs e)
        {
            ValidaElementosAdicionales("E");
        }

        private void Tx_Patente_Validating(object sender, CancelEventArgs e)
        {
            ObtenerTaraDesdeAccess();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Btn_Grabar_Click(null, null);
        }

        private void Btn_VerBascula_Click(object sender, EventArgs e)
        {
            Frm_VerBascula lFrm = new Bascula.Frm_VerBascula();
            lFrm.ShowDialog();
        }

      

        private void Dtg_SinVincular_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int lIndex = e.RowIndex; int i = 0; DataRow lFila = null; int lKgs = 0;Clases.ClsComun lcom = new Clases.ClsComun();
           
            try
            { 

            if (lIndex > -1)
            {
                Cursor.Current = Cursors.WaitCursor;
                string lViaje = Dtg_SinVincular.Rows[lIndex].Cells["Viajes"].Value.ToString();
                string lIdDespacho = Dtg_SinVincular.Rows[lIndex].Cells["IdDespachoCamion"].Value.ToString();
                string lIdPesajeC = Dtg_SinVincular.Rows[lIndex].Cells["IdPesajeCamion"].Value.ToString();
                WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
                WsOperacion.ListaDataSet lLIstaDts = new WsOperacion.ListaDataSet(); DataTable lTbl = new DataTable();
                lLIstaDts = wsOperacion.ObtenerDatosPorIdDespacho(lIdDespacho, lViaje, lIdPesajeC);
                if (lLIstaDts.MensajeError.ToString().Length == 0)
                {
                    if (lLIstaDts.DataSet.Tables.Count == 4)
                    {
                        Tx_NroGuiaINET_V.Text = lLIstaDts.DataSet.Tables["DatosINET"].Rows[0]["NroGuia"].ToString();
                        Tx_kgsINET_V.Text = lLIstaDts.DataSet.Tables["DatosINET"].Rows[0]["KgsGuia"].ToString();
                        Tx_PatenteINET_V.Text = lLIstaDts.DataSet.Tables["DatosINET"].Rows[0]["Patente"].ToString();

                        Tx_obsDos.Text = lLIstaDts.DataSet.Tables["DatosINET_OBS"].Rows[0][0].ToString();

                        Dtg_Bascula.DataSource = lLIstaDts.DataSet.Tables["DatosBascula"].Copy();

                        for (i=0;i< lLIstaDts.DataSet.Tables["DetallePC"].Rows .Count;i++)
                        {
                            lKgs = lKgs + lcom.Val(lLIstaDts.DataSet.Tables["DetallePC"].Rows[i]["PesoGuiaINET"].ToString());
                        }

                        lFila = lLIstaDts.DataSet.Tables["DetallePC"].NewRow();
                        lFila["NroGuiaINET"] = "Total";
                        lFila["PesoGuiaINET"] = lKgs;
                        lLIstaDts.DataSet.Tables["DetallePC"].Rows.Add(lFila);

                        Dtg_DetallePesaje.DataSource = lLIstaDts.DataSet.Tables["DetallePC"].Copy();

                        Dtg_DetallePesaje.Columns[0].Width = 50;
                        Dtg_DetallePesaje.Columns[1].Width = 70;
                        Dtg_DetallePesaje.Columns[2].Width = 70;

                        Dtg_Bascula.Columns[0].Width = 10;
                        Dtg_Bascula.Columns[1].Width = 50;
                        Dtg_Bascula.Columns[2].Width = 50;
                        Dtg_Bascula.Columns[3].Width = 50;
                        Dtg_Bascula.Columns[4].Width = 50;
                        Dtg_Bascula.Columns[5].Width = 50;
                        Dtg_Bascula.Columns[6].Width = 50;
                    }

                }


                Cursor.Current = Cursors.Default ;

            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void LimpiaObjGrillaVinculacion()
        {
            Dtg_DetallePesaje.DataSource = null;
            Dtg_Bascula.DataSource = null;
            Tx_NroGuiaINET_V.Text = "";
            Tx_kgsINET_V.Text = "";
            Tx_obsDos.Text = "";

        }

        private void Btn_GrabarVin_Click(object sender, EventArgs e)
        {
            int i = 0;  string lSql = ""; Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient();Clases.ClsComun lCom = new Clases.ClsComun();
            string lMsg = string.Concat("¿Esta seguro que desea Vincular el Nro de guía ", Tx_NroGuiaINET_V.Text, " al detalle de Despacho Camión?");

            if (MessageBox.Show(lMsg, "Avisos Sistema", MessageBoxButtons.YesNo,MessageBoxIcon.Question)==  DialogResult.Yes )
           {
                for (i=0; i<Dtg_DetallePesaje .Rows .Count;i++ )
                {
                    if (Dtg_DetallePesaje.Rows[i].Cells["IdPesajeCamion"].Value.ToString().Trim().Length > 0)
                    {
                        lSql = String.Concat(" SP_ConsultasGenerales 115,'", Tx_NroGuiaINET_V.Text, "','", Tx_kgsINET_V.Text ,"','", Dtg_DetallePesaje.Rows[i].Cells["IdPesajeCamion"].Value.ToString(), "','", Dtg_DetallePesaje.Rows[i].Cells["Id"].Value.ToString(), "','' ");
                        
                        lPx.ObtenerDatos(lSql);
                    }
                    else
                        i = Dtg_DetallePesaje.Rows.Count;


                }

            }

            CargaDatosDespachosSinGuiaINET();
            LimpiaObjGrillaVinculacion();
        }

        private void Dtg_GuiasINET_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int lIndx = e.RowIndex;
            string lGuia = Dtg_GuiasINET.Rows[lIndx].Cells["atenum"].Value.ToString();
            Bascula.Frm_Regularizar lFrm = new Frm_Regularizar();
            lFrm.CargaDatosPorGuiaINET(lGuia,"","","");
            lFrm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IntegrarConINET();
        }

        private void IntegrarConINET()
        {
            Frm_IntegracionINET lFrm = new Frm_IntegracionINET(); string iEmpresa = "";
            if (Rb_TO.Checked == true)
                iEmpresa = "TO";

            if (RB_TOSOL.Checked == true)
                iEmpresa = "TOSOL";

            lFrm.IniciaForm(iEmpresa, "S");
            lFrm.ShowDialog(this);

        }

        private void Btn_Ver_Click(object sender, EventArgs e)
        {
            Bascula.Frm_VerDetallePesaje lFrm = new Frm_VerDetallePesaje();
            lFrm.CargaDatos(mIdPesajeCamion.ToString (),Cmb_Patente .SelectedValue .ToString() ,Tx_Tara .Text ,Tx_Bruto .Text, Tx_PesoSoloFierro .Text );
            lFrm.ShowDialog(this);
              
        }

        private void Btn_CerrarCiclo_Click(object sender, EventArgs e)
        {
            if (Tx_IdPesaje.Text.Length > 0)
            {

                if (MessageBox.Show("¿Esta Seguro que desea Cerrar el cíclo del camión seleccionado ?", "Avisos Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    EliminaRegistroCamion(Tx_IdPesaje.Text);
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Btn_ResumenTareas_Click(object sender, EventArgs e)
        {
            TareasFinales();
        }

        private void TareasFinales()
        {
            Bascula.Frm_DetalleGrabacion lfrm = new Frm_DetalleGrabacion();
            lfrm.IniciaForm(mIdPesajeCamion.ToString());
            
            lfrm.ShowDialog();
 
        }

        private void Dtg_CamionDespachados_Click(object sender, EventArgs e)
        {

        }

        private void Dtg_CamionDespachados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int lIndex = e.RowIndex;
            if (lIndex > -1)
            {
                IdPesaje_PR.Text  = Dtg_CamionDespachados.Rows[lIndex].Cells["Id"].Value.ToString();
               
                if (int.Parse(IdPesaje_PR.Text) > 0)
                {
                    Btn_ImprimePL.Enabled = true;
                }
                else
                {
                    Btn_ImprimePL.Enabled = false;
                }
            }
        }

        private void Btn_ImprimePL_Click(object sender, EventArgs e)
        {
            Bascula.Frm_DetalleGrabacion lfrm = new Frm_DetalleGrabacion();
            lfrm.IniciaForm(IdPesaje_PR.Text .ToString());

            lfrm.ShowDialog();
        }
    }
}
