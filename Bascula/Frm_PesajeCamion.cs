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
        private DataTable mAdicionalesCamion = new DataTable();
        private Boolean mBuscaDatosPatente = false;
        private string mUserAutoriza = "";
        private string mObsUserAutoriza = "";
        private double mToteranciaExtra = 0;
        private Double mToleranciaReal = 0;
        private Double mToleranciaRealDesa = 0;
        private DataTable mTblElementosIngresado = new DataTable();
        private DataTable mTblDetalleDespacho = new DataTable();
        public Frm_PesajeCamion()
        {
            InitializeComponent();
        }

        private void ObtenerTaraDesdeAccess()
        {
            string lTara = ObtenerTara();
            this.Tx_KgsTara.Text = lTara;
            //string lAux = Cmb_PatenteTara.SelectedValue.ToString(); 


            //Tx_PesoNeto.Text = "";

            //Tx_PesoNeto.Text = "";
            //Tx_ToleranciaReal.Text = "";

            //Tx_KgsCargados.Text = "";
            //Tx_DiferenciaKilos.Text = "";

            //Tx_Bruto.Text = "";
            //this.Tx_IdCorrTara.Text = lAux;
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

        public void IniciaForm(CurrentUser iUseActivo)
        {
            mUserLog = iUseActivo;
            this.Dtp_FechaActual.Value = DateTime.Now;
            this.Dtp_FechaActual.MaxDate = DateTime.Now;
            this.Dtp_FechaActual.MinDate = DateTime.Now.AddDays(-1);
            Rb_Tara.Checked = true;
            MuestraDatosSegunCheck();
            string lToleranciaBascula = ConfigurationManager.AppSettings["ToleranciaBascula"].ToString();

            if (lToleranciaBascula.Length > 0)
                mToleranciaBascula = int.Parse(lToleranciaBascula);

            Tx_ToleranciaBascula.Text = mToleranciaBascula.ToString();

           // ObtenerCamionesEnPlanta();
            //Dtg_CamionEnPlanta.DataSource = mTblCamiones;

            //Dtg_CamionDespachados.DataSource = mTblCamionesDespachados;
            //Dtg_Parametros.DataSource = mTblParametro;
            //
            // formateaGrillas();
            //CargaDatosDespachosSinGuiaINET();
            //CargaPatentes();
            //RevisionGuias();
        }


        #region Metodos privados de la clase

        private void ValidaElementosAdicionales(string iTipo)
        {
            int lValor = 0; string lMsg = ""; int lKgsCuartones = 0; DataView lVista = null;
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
                    Tx_nroCuartones.Focus();
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
            mBuscaDatosPatente = true;
        }

        private void SumaKgsAdicionales()
        {
            Clases.ClsComun lCom = new Clases.ClsComun();
            int lKgsC = 0; int lKgsE = 0;
            try
            {
                lKgsC = int.Parse(Tx_KgsCuartones.Text);
            }
            catch
            {
                lKgsC = 0;
            }

            try
            {
                lKgsE = int.Parse(Tx_KgsEstrobos.Text);
            }
            catch
            {
                lKgsE = 0;
            }

            Tx_TotalKgs.Text = (lKgsC + lKgsE).ToString();
            Tx_PesoAdicional.Text = (lKgsC + lKgsE).ToString();
            Tx_PesoSoloFierro.Text = (lCom.Val(Tx_PesoNeto.Text) - lCom.Val(Tx_PesoAdicional.Text)).ToString();
            CargaPesoBruto();

        }

        private void ObtenerCamionesEnPlanta()
        {
            WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
            WsOperacion.ListaDataSet lLIstaDts = new WsOperacion.ListaDataSet(); DataTable lTbl = new DataTable();
            int i = 0; DataTable lTblParametro = new DataTable(); DataRow lFila = null;
            lLIstaDts = wsOperacion.ObtenerCamionesEnPlanta();

            if ((lLIstaDts.DataSet != null) && (lLIstaDts.DataSet.Tables.Count > 0))
            {
                mTblCamiones = lLIstaDts.DataSet.Tables["CamionesEnPlanta"].Copy();
                mTblCamionesDespachados = lLIstaDts.DataSet.Tables["DespachosRealizados"].Copy();
                mTblKgsAdicionales = lLIstaDts.DataSet.Tables["KgsAdicionales"].Copy();
                mTblConfTolerancia = lLIstaDts.DataSet.Tables["ConfigTolerancia"].Copy();
                mAdicionalesCamion = lLIstaDts.DataSet.Tables["AdicionalesCamion"].Copy();
                mTblParametro = new DataTable();
                mTblParametro.Columns.Add("Parametro", Type.GetType("System.String"));
                mTblParametro.Columns.Add("Valor", Type.GetType("System.String"));

                //Obtenemos Columna EstadoBascula
                // ObtenerEstadoProcesoBascula
                //lTbl = mTblCamiones;
                //for (i = 0; i < mTblCamiones.Rows.Count; i++)
                //{
                //    mTblCamiones.Rows[i]["ProcesoBascula"] = ObtenerEstadoProcesoBascula(mTblCamiones.Rows[i]["IdCorrelativo"].ToString());
                //}

                // Agregamos los datos de Parametros
                // Kilos adicionales
                lTbl = mTblKgsAdicionales;
                for (i = 0; i < lTbl.Rows.Count; i++)
                {
                    lFila = mTblParametro.NewRow();
                    lFila["Parametro"] = lTbl.Rows[i]["SubTabla"].ToString();
                    lFila["Valor"] = string.Concat(lTbl.Rows[i]["Par1"].ToString(), " Kgs");
                    mTblParametro.Rows.Add(lFila);
                }
                // Tolerancia bascula
                lTbl = mTblConfTolerancia.Copy();
                for (i = 0; i < lTbl.Rows.Count; i++)
                {
                    lFila = mTblParametro.NewRow();
                    lFila["Parametro"] = lTbl.Rows[i]["SubTabla"].ToString();
                    lFila["Valor"] = string.Concat(lTbl.Rows[i]["Par1"].ToString(), " %");
                    mTblParametro.Rows.Add(lFila);
                }
                // Adicionales Camion
                lTbl = mAdicionalesCamion.Copy();
                lFila = lTbl.NewRow();
                lFila["Par1"] = "Seleccionar";
                lFila["Id"] = "0";
                lTbl.Rows.Add(lFila);
                new Forms().comboBoxFill(Cmb_Elemento, lTbl, "id", "Par1", 0);
                Cmb_Elemento.SelectedIndex = lTbl.Rows.Count - 1;

                //********************************
                // lTbl = lLIstaDts.DataSet.Tables[0].Copy();

                //*****************************
                //tolerancia sobre cotas.
                mToteranciaExtra = wsOperacion.ObtenerTotelaciaExtra();


            }


            //return lTbl;

            //        private DataTable  = new DataTable();
            //private DataTable mTblCamionesDespachados = new DataTable();

        }


        private void EliminaRegistroPesaje(string lIdPesaje)
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
            string lRes = "0"; Clases.SqlBascula lTipoSql = new Clases.SqlBascula();
            DataTable lTbl = new DataTable(); Clases.ClsComun lDAL = new Clases.ClsComun();
            string lFecha = DateTime.Now.ToShortDateString(); int lPesoTara = int.Parse(Tx_Tara.Text);

            lTbl = lDAL.CargaTablaRomana(lTipoSql.ObtenerSqlPesoBruto(Cmb_Patente.SelectedValue.ToString(), lFecha, lPesoTara));

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

                    if (AppDomain.CurrentDomain.GetData("Correlativo") != null)
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

        private string ObtenerEstadoProcesoBascula(string IdCorrelativo)
        {
            string lRes = "0"; Clases.SqlBascula lTipoSql = new Clases.SqlBascula();
            DataTable lTbl = new DataTable(); Clases.ClsComun lDAL = new Clases.ClsComun(); int lPesoNeto = 0;
            //string lFecha = DateTime.Now.ToShortDateString(); int lPesoTara = int.Parse(Tx_Tara.Text);

            lTbl = lDAL.CargaTablaRomana(lTipoSql.ObtenerSqlEstadoProceso(IdCorrelativo));

            if (lTbl.Rows.Count > 0)
            {
                lPesoNeto = lDAL.Val(lTbl.Rows[0]["PesoTara"].ToString());
                if (lPesoNeto > 0)
                    lRes = "S";
                else
                    lRes = "N";
            }
            return lRes;
        }


        private string ObtenerTara()
        {
            string lRes = ""; string lSql = ""; Clases.SqlBascula lTipoSql = new Clases.SqlBascula();
            DataTable lTbl = new DataTable(); Clases.ClsComun lDAL = new Clases.ClsComun();
            string lFecha = Dtp_FechaActual.Value.AddDays (-1).ToShortDateString() ;  //DateTime.Now.ToShortDateString();

            if (Cmb_PatenteTara.SelectedValue .ToString() .Length == 0)
            {
                MessageBox.Show("Debe Ingresar una Patente para poder Obtener la Tara, revisar. . . ", "Validaciones Sistema", MessageBoxButtons.OK);
            }
            else
            {
                lSql = lTipoSql.ObtenerSqlTara(Cmb_PatenteTara.SelectedValue.ToString ()  , lFecha);
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
                    mBuscaDatosPatente = true;
                    Gb_Desarrollo.Enabled = true;
                }
                if (Rb_PreDespacho.Checked == true)
                {
                    Gr_Tara.Enabled = true;
                    Gr_Bruto.Enabled = true;
                    Tx_Bruto.Enabled = true;
                    Tx_Tara.Enabled = true;
                    Tx_Tara.ReadOnly = false;
                    Tx_Patente.Enabled = false;
                    CargaPesoBruto();
                    CargaDatosResumen();
                    Tx_KgsCargados.Enabled = true;
                    Tx_KgsCargados.ReadOnly = false;
                    //Tx_PesoSoloFierro.Text = (int.Parse(Tx_Bruto.Text) - int.Parse(Tx_PesoNeto.Text)).ToString ();
                    Btn_Grabar.Enabled = false;
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


        private Boolean GrabarDatos_V2()
        {
            WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
            WsOperacion.PesajeCamion lObjCam = new WsOperacion.PesajeCamion();
            WsOperacion.ListaDataSet lDts = new WsOperacion.ListaDataSet(); Clases.ClsComun lCom = new Clases.ClsComun();
            string lTxMsg = ""; Boolean lRes = false; DataSet lDtsDatos = new DataSet(); DataTable lTbl = new DataTable();
            try
            {

                //if (Btn_GrabarDespacho.Enabled == false)
                //{ 
                lObjCam.Id = mIdPesajeCamion;
                lObjCam.Patente = Cmb_PatenteCamion.SelectedValue.ToString();
                lObjCam.PesoTara = int.Parse(Tx_taraCamion.Text);
                lObjCam.PesoBruto = int.Parse(Tx_PesoBrutoCamion.Text); ;
                lObjCam.IdUserPesoBruto = int.Parse(mUserLog.Iduser);
                lObjCam.Estado = "PesoCarga";
                lObjCam.IdCorrelativo = mIdCorrelativo;
                lObjCam.NroCuartones = lCom.Val(Tx_NumeroCuartones.Text).ToString();
                lObjCam.NroEstrobos = lCom.Val(Tx_NroPallet.Text).ToString();
                lObjCam.KgsCuartones = lCom.Val(Tx_KilosCuartones.Text).ToString();
                lObjCam.KgsEstrobos = lCom.Val(Tx_KilosPallet.Text).ToString();
                lObjCam.KgsAlambre  = lCom.Val(Tx_alambre.Text   ).ToString();
                lObjCam.UsuarioAutoriza = mUserAutoriza;
                lObjCam.ObsAutorizacion = mObsUserAutoriza;

                lObjCam = wsOperacion.GrabarDatosPesajeCamion(lObjCam);
                if (lObjCam.Id > 0)
                {
                    //enviar Correo para informar.
                    lDts = wsOperacion.ObtenerDatosPesajeCamion(lObjCam.Id.ToString());
                    if (lDts.MensajeError.Trim().Length == 0)
                    {

                        lTbl = (DataTable)Dtg_RFC_.DataSource;
                        lTbl.TableName = "RFC";
                       // lDts.DataSet.Tables.Add(lTbl.Copy());
                        lTbl = new DataTable();
                        lTbl = (DataTable)Dtg_RVC.DataSource;
                        lTbl.TableName = "RVC";
                        lDts.DataSet.Tables.Add(lTbl.Copy());

                        lTxMsg =  EnviaCorreoNotificacion_DespachoConBascula (lDts.DataSet.Copy(), mIdPesajeCamion.ToString ());
                    }
                    MessageBox.Show("Los Datos han sido Grabados Correctamente ", "Avisos Sistema", MessageBoxButtons.OK);
                    mIdCorrelativo = "0";
                    Btn_GrabarDespacho.Enabled = false;
                    lRes = true;
                }
                //}

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lRes;
        }



        private Boolean GrabarDatos()
        {
            WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
            WsOperacion.PesajeCamion lObjCam = new WsOperacion.PesajeCamion();
            WsOperacion.ListaDataSet lDts = new WsOperacion.ListaDataSet(); Clases.ClsComun lCom = new Clases.ClsComun();
            string lTxMsg = ""; Boolean lRes = false;
            try
            {
                if (Rb_Tara.Checked == true)
                {
                    lObjCam.Id = 0;
                    lObjCam.Patente = Cmb_PatenteTara.SelectedValue.ToString();
                    lObjCam.PesoTara = int.Parse(Tx_KgsTara.Text);
                    lObjCam.FechaTara = DateTime.Now.ToString();
                    lObjCam.IdUserTara = int.Parse(mUserLog.Iduser);
                    lObjCam.PesoBruto = 0;
                    lObjCam.IdDespachoCam = 0;
                    lObjCam.Estado = "PesoTara";
                    lObjCam.IdCorrelativo = lCom.Val(mIdCorrelativo.ToString()).ToString();
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
                        MessageBox.Show(string.Concat("Ha ocurrido el siguiente error:", lObjCam.errors.ToString()), "Avisos Sistema", MessageBoxButtons.OK);
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
                    lObjCam.NroCuartones = lCom.Val(Tx_NroPallet .Text).ToString();
                    lObjCam.NroEstrobos = lCom.Val(Tx_nroEstrobos.Text).ToString();
                    lObjCam.KgsCuartones = lCom.Val(Tx_KgsCuartones.Text).ToString();
                    lObjCam.KgsEstrobos = lCom.Val(Tx_KilosPallet.Text).ToString();
                    lObjCam.KgsAlambre = Tx_alambre.Text;
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

        private string EnviaCorreoNotificacion(DataSet lDts)
        {
            string lTx = ""; string lRes = ""; DataTable lTbl = new DataTable(); DataTable lTblDespacho = new DataTable();
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient(); string lTx_Caso = "";
            string lPatente = ""; string lPesoGuia = ""; string lKgsNeto = ""; string lKgsDesarrollo = "";
            string lDesviacion = ""; string lJefeTurno = "Sin Datos "; string lResultadoPesaje = ""; string lObra = " Sin Datos ";
            string lPorDesviacion = ""; double lPGD = 0; double lPbascula = 0; double lPD = 0;
            string lDesviacionDesa = ""; string lPorDesviacionDesa = "";
            string lTxAutoriza = "";

            lResultadoPesaje = Btn_PesoBruto.Tag.ToString();


            // Concatenamos La parte de la Autorización
            DataTable lTblAut = new DataTable(); DataTable lTblDatos = new DataTable(); DataTable lTblUser = new DataTable();

            if ((lDts.Tables.Count == 3))
            {
                lTblAut = lDts.Tables["Autoriza"].Copy();
                lTblDatos = lDts.Tables["Datos"].Copy();
                lTblUser = lDts.Tables["Usuario"].Copy();
                lTxAutoriza = "";
                if (lTblAut.Rows.Count > 0)
                {
                    lTxAutoriza = string.Concat(" Usuario: ", lTblAut.Rows[0]["SupervisorAutoriza"].ToString(), " <BR>");
                    lTxAutoriza = string.Concat(lTxAutoriza, " Fecha Autorizacion: ", lTblAut.Rows[0]["FechaAutoriza"].ToString(), " <BR>");
                    lTxAutoriza = string.Concat(lTxAutoriza, " Observacion: ", lTblAut.Rows[0]["ObsAutoriza"].ToString(), " <BR>");
                    lTxAutoriza = string.Concat(lTxAutoriza, " Nro. Estrobos: ", lTblDatos.Rows[0]["NroEstrobos"].ToString(), " <BR>");
                    lTxAutoriza = string.Concat(lTxAutoriza, " Nro. Cuartones: ", lTblDatos.Rows[0]["NroCuartones"].ToString(), " <BR>");
                }
            }

            switch (lResultadoPesaje.ToUpper())
            {
                case "+":   //Se despacha mas 
                    lTx_Caso = " Para la Obra xxx  se ha generado un <b> despacho con sobre peso </b> con los siguientes resultados";
                    lTx_Caso = string.Concat(lTx_Caso, " <BR> ", lTxAutoriza, " <BR>");

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
                lDesviacionDesa = (lPD - lPbascula).ToString();

                lPorDesviacionDesa = Math.Round((((lPD - lPbascula) * 100) / lPD), 2).ToString();

                //lPD = int.Parse(lTbl.Rows[0]["KgsDesarrollo"].ToString());                                
                //lDesviacionDesa = ""; lPorDesviacionDesa = "";

                lTx = string.Concat(lTx, "  <tr> ");
                lTx = string.Concat(lTx, "  <td>", lTbl.Rows[0]["Patente"].ToString(), "</td> ");
                lTx = string.Concat(lTx, "  <td>", lTbl.Rows[0]["FechaPesoBruto"].ToString(), "</td> ");
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
                lTx = string.Concat(lTx, " <BR> <BR> <BR> ");
                lTx = string.Concat(lTx, "  Este mensaje a sido generado de forma Automatica, favor NO responder este correo <BR>");
                lTx = string.Concat(lTx, "  Los acentos y caracteres especiales han sido eliminado del correo <BR>");

                lTx_Caso = lTx_Caso.Replace("xxx", lObra);

                lTx = string.Concat(lTx_Caso, " <BR> <BR>", lTx);

            }

            lRes = lPx.EnviaNotificacionesEnviaMsgDeNotificacion("", lTx, -900, string.Concat("Detalle de Pesaje Camión Patente: ", lPatente));
            //if (lRes.ToUpper().Equals("OK"))

            return lRes;


        }


        private string EnviaCorreoNotificacion_DespachoConBascula(DataSet lDts, string iIddespachoCamion)
        {

            // el dataset tendra las 2 tablas de las grillas que estan en la interfax grafica

            string lTx = ""; string lRes = ""; DataTable lTbl = new DataTable(); DataTable lTblDespacho = new DataTable(); string lViajesDespachados = "";
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient(); WsOperacion.OperacionSoapClient lPxOper = new WsOperacion.OperacionSoapClient();
            string lPatente = ""; DataSet lDtsData = new DataSet(); string lAdmObra = ""; string lTblHtml = ""; string lNombreObra = ""; int i = 0;

            try
            {
                lDtsData = lPxOper.ObtenerDatosCorreo(iIddespachoCamion);
                if (lDtsData.Tables.Count > 0)
                {
                    lTblDespacho = lDtsData.Tables["obra"].Copy();
                    lPatente = lTblDespacho.Rows[0]["patente"].ToString();
                    lAdmObra = lTblDespacho.Rows[0]["encargado"].ToString();
                    lNombreObra = lTblDespacho.Rows[0]["NombreObra"].ToString();

                    lTblDespacho = new DataTable();
                    lTblDespacho = lDtsData.Tables["Viajes"].Copy();

                    for (i = 0; i < lTblDespacho.Rows.Count; i++)
                    {
                        lViajesDespachados = string.Concat(lViajesDespachados, " ", lTblDespacho.Rows[i][0].ToString(), " - ");
                    }
                }

                string lFechaActual = string.Concat(DateTime.Now.ToShortDateString(), " ", DateTime.Now.ToShortTimeString());

                //lResultadoPesaje = Btn_PesoBruto.Tag.ToString();        

                lTx = string.Concat(" Estimad@s:  <br>   A continuación se detalla información asociada a un despacho de la obra: ", lNombreObra, "  <BR>");
                lTx = string.Concat(lTx, " Fecha y hora del despacho: ", lFechaActual, "  horas <BR>  Patente camión: ", lPatente);
                lTx = string.Concat(lTx, "  <BR>  Empresa de transporte:");
                lTx = string.Concat(lTx, "  <BR>  It(s) despachada(s): ", lViajesDespachados, " <BR>  Admistrador de la obra: ", lAdmObra, " <BR> <BR> <BR> ");
               // lTx = string.Concat(lTx, "  Adicional al fierro cargado, el transporte lleva los siguientes elementos adicionales:  <BR> <BR> ");
                //lTx = string.Concat(lTx, " <b> Resumen Validación de Carga </b>  <BR> ");
                // Cargamos las tablas 

                // 20/10/2023  que queden una al lado del otro

                lTx = string.Concat(lTx, " <table align='center'  border='0'  width='100%' >    <tr>     <td>  ");
                lTblHtml = ObtenerTabla_Html("1", lDts);
                lTx = string.Concat(lTx, lTblHtml, " &nbsp &nbsp &nbsp &nbsp &nbsp  &nbsp &nbsp &nbsp </td>   <BR>    <td>  ");
                lTblHtml = ObtenerTabla_Html("2", lDts);
                lTx = string.Concat(lTx, lTblHtml, " &nbsp &nbsp &nbsp &nbsp &nbsp  &nbsp &nbsp &nbsp  </td>    <BR>    <td>  ");
                //lTx = string.Concat(lTx, "  <b> Tiempos de estadia de transporte en planta  </b>   ");

                lTblHtml = ObtenerTabla_Html("3", lDts);
                lTx = string.Concat(lTx, lTblHtml, "  </ td >   </tr>   </table>   ");
                lTx = string.Concat(lTx, " <BR>  <BR>   Atte. Logística de Salida  <br>  <br> Este mensaje ha sido generado de forma automatica, favor NO responder este correo. ");


                lRes = lPx.EnviaNotificacionesEnviaMsgDeNotificacion("", lTx, -2300, string.Concat("Detalle Pesaje Camión Patente: ", lPatente, ", Obra ", lNombreObra));

                // Concatenamos La parte de la Autorización
                //DataTable lTblAut = new DataTable(); DataTable lTblDatos = new DataTable(); DataTable lTblUser = new DataTable();

                //lRes = lPx.EnviaNotificacionesEnviaMsgDeNotificacion("", lTx, -900, string.Concat("Detalle de Pesaje Camión Patente: ", lPatente));
                //if (lRes.ToUpper().Equals("OK"))
            }
            catch (Exception iEx)
            {
            }
            return lRes;

        }

        private string EnviaCorreoNotificacion_Despacho_SIN_Bascula(DataSet lDts)
        {
            string lTx = ""; string lRes = ""; DataTable lTbl = new DataTable(); DataTable lTblDespacho = new DataTable();
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient();
            string lPatente = ""; 

    

            string lNombreObra = "DRAMATURGO LUIS RIVANO DEMOCORP"; string lFechaActual = string.Concat(DateTime.Now.ToShortDateString(), " ", DateTime.Now.ToShortTimeString());
            string lViajesDespachados = "DLR-1/1; DLR-2/1; DLR-3/1"; string lAdmObra = "Ruben Peralta"; string lTblHtml = "";

            //lResultadoPesaje = Btn_PesoBruto.Tag.ToString();

            lPatente = "HFPV99";

            lTx = string.Concat(" Estimad@s:  <br>   A continuación se detalla información asociada a un despacho de la obra:", lNombreObra, "  <BR>");
            lTx = string.Concat(lTx, " Fecha y hora del despacho: ", lFechaActual, " <BR>  Patente camión:", lPatente);
            lTx = string.Concat(lTx, "  Empresa de transporte:");
            lTx = string.Concat(lTx, "  It(s) despachada(s): ", lViajesDespachados, " <BR>  Admistrador de la obra: ", lAdmObra, " <BR> <BR> ");
            lTx = string.Concat(lTx, "  Adicional al fierro cargado, el transporte lleva los siguientes elementos adicionales:  <BR> <BR> ");

            // Cargamos las tablas 
            //lTblHtml = ObtenerTabla_Html("4");
            //lTx = string.Concat(lTx, lTblHtml, " <BR> ");
            //lTblHtml = ObtenerTabla_Html("5");
            //lTx = string.Concat(lTx, lTblHtml, " <BR> ");



            lTx = string.Concat(lTx, lTblHtml, " <BR>  <br> Este mensaje ha sido generado de forma automatica, favor NO responder este correo. <br> Los acentos y caracteres especiales han sido eliminados del correo. ");


            lRes = lPx.EnviaNotificacionesEnviaMsgDeNotificacion("", lTx, -2100, string.Concat("Detalle de Pesaje Camión Patente: ", lPatente));

            // Concatenamos La parte de la Autorización
            //DataTable lTblAut = new DataTable(); DataTable lTblDatos = new DataTable(); DataTable lTblUser = new DataTable();

            //lRes = lPx.EnviaNotificacionesEnviaMsgDeNotificacion("", lTx, -900, string.Concat("Detalle de Pesaje Camión Patente: ", lPatente));
            //if (lRes.ToUpper().Equals("OK"))

            return lRes;

        }

        #endregion

        private string ObtenerTabla_Html(string iTipo, DataSet iDtsDatos)
        {
            string lRes = ""; DataTable lTblTmp = new DataTable(); int lValorMiles = 0;
            switch (iTipo)
            {
                case "1":
                    lTblTmp = iDtsDatos.Tables["RVC"].Copy();  
                    lRes = "  <table border='1'  width='480px'>  <tr>  <td colspan='2' align='center' >  <b> Resumen Validación de Carga </b>  </td >     </tr>   ";
                    lRes = string.Concat(lRes, "  <tr>  <td bgcolor = '#0099FF' style = 'color: #FFFFFF' > Concepto </td >  <td bgcolor = '#0099FF' style = 'color: #FFFFFF' align ='right'> Valor </td >       </tr> ");
                    lValorMiles = int.Parse(lTblTmp.Rows[0]["Valor"].ToString());
                    //lRes = string.Concat(lRes, "  <tr> <td>Peso fierro real utilizado en producción (kg) </td>  <td align ='right'>",lTblTmp.Rows [0]["Valor"].ToString ()    ,"</td>   </tr> ");
                    lRes = string.Concat(lRes, "  <tr> <td>Peso fierro real utilizado en producción (kg) </td>  <td align ='right'>", lValorMiles.ToString ("N0") , "</td>   </tr> ");
                    lValorMiles = int.Parse(lTblTmp.Rows[1]["Valor"].ToString());
                    //lRes = string.Concat(lRes, "  <tr> <td>Peso neto de fierro en  báscula </td>  <td align ='right' >", lTblTmp.Rows[1]["Valor"].ToString(), "</td>  </tr> ");
                    lRes = string.Concat(lRes, "  <tr> <td>Peso neto de fierro en  báscula </td>  <td align ='right' >", lValorMiles.ToString("N0"), "</td>  </tr> ");
                    lValorMiles = int.Parse(lTblTmp.Rows[2]["Valor"].ToString());
                    lRes = string.Concat(lRes, "  <tr> <td bgcolor = '#E08305'>Diferencia fierro en báscula - fierro real producido   (kg)</td>   <td align ='right'  bgcolor = '#E08305' >  <b>  ", lValorMiles.ToString("N0") , "  </b>  </td>  </tr> ");
                    lValorMiles = int.Parse(lTblTmp.Rows[3]["Valor"].ToString());
                    lRes = string.Concat(lRes, "  <tr> <td bgcolor = '#E08305' >Porcentaje fierro báscula/ fierro real producido (%)</td>   <td align ='right' bgcolor = '#E08305'  >  <b> ", lValorMiles.ToString("N0") , " </b> </td>  </tr>  </table>");

                    break;
                case "2":
                    lTblTmp = iDtsDatos.Tables["RFC"].Copy();
                    //lRes = " <table  cellspacing='1' border='0'  >  <tr> <td align='center' > <b>Resumen fierro a cobrar</b> </td>      ";
                    //lRes = string.Concat(lRes, " ");
                    //lRes = string.Concat(lRes, " </tr>   ");
                    //lRes = "  <table border='0'  width='480px'>  <tr>  <td colspan='2' align='center' >  <b> Resumen fierro a cobrar </b>  </td >     </tr>   ";
                 
                   
                    lRes = string.Concat(" <table   width='480px'  border='1'>   ");
                    lRes = string.Concat(lRes, "  <tr>  <td colspan='2' align='center' >  <b> Resumen Fierro a Cobrar </b>  </td >     </tr>  ");

                    lRes = string.Concat(lRes, "  <tr>  <td bgcolor = '#0099FF' style = 'color: #FFFFFF' > Concepto </td >  <td bgcolor = '#0099FF' style = 'color: #FFFFFF' align ='right'> Valor </td >       </tr> ");

                    lRes = string.Concat(lRes, "  <tr>  <td>  Peso fierro real utilizado (kg)  </td>    ");
                    lValorMiles = int.Parse(lTblTmp.Rows[0]["Valor"].ToString());
                    lRes = string.Concat(lRes, "    <td align ='right' >", lValorMiles.ToString("N0"), "</td>    </tr> ");
                    lValorMiles = int.Parse(lTblTmp.Rows[1]["Valor"].ToString());
                    lRes = string.Concat(lRes, "   <tr>   <td>Peso fierro generado por desarrollo (kg)</td>    <td align ='right' >", lValorMiles.ToString("N0"), "</td>  </tr>   ");
                    lValorMiles = int.Parse(lTblTmp.Rows[2]["Valor"].ToString());
                    lRes = string.Concat(lRes, "   <tr>   <td>Peso fierro por norma 353 (1%) (kg) </td>    <td align ='right' > ", lValorMiles.ToString("N0"), "</td>  </tr>  </tr> ");
                    lValorMiles = int.Parse(lTblTmp.Rows[3]["Valor"].ToString());
                    lRes = string.Concat(lRes, "  <tr>    <td   >Peso fierro en GD (kg) </ td >    <td align ='right' > <b>  ", lValorMiles.ToString("N0") , " </b>  </td>       </tr>  </tr> ");
                    lRes = string.Concat(lRes, "  </td> </tr>  </table>   ");
                    break;
                // bgcolor="#E08305" 
                case "3":
                    lTblTmp = iDtsDatos.Tables["PBR"].Copy();
                    lRes = "  <table border='1'  width='480px'>  <tr>  <td colspan='2' align='center' >  <b> Resumen Peso báscula </b>  </td >     </tr>   ";
                    lRes = string.Concat(lRes, "  <tr>  <td bgcolor = '#0099FF' style = 'color: #FFFFFF' > Concepto </td >  <td bgcolor = '#0099FF' style = 'color: #FFFFFF' align ='right'> Valor </td >       </tr> ");
                    lValorMiles = int.Parse(lTblTmp.Rows[0]["Valor"].ToString());
                    lRes = string.Concat(lRes, "  <tr> <td>Peso bruto camión  (kg) </td>  <td align ='right'>", lValorMiles.ToString("N0"), "</td>   </tr> ");
                    lValorMiles = int.Parse(lTblTmp.Rows[1]["Valor"].ToString());
                    lRes = string.Concat(lRes, "  <tr> <td>Tara camión (kg)  </td>  <td align ='right' >", lValorMiles.ToString("N0") , "</td>  </tr> ");
                    lValorMiles = int.Parse(lTblTmp.Rows[2]["Valor"].ToString());
                    lRes = string.Concat(lRes, "  <tr> <td>Peso de Cuartones (kg)  </td>  <td align ='right' >", lValorMiles.ToString("N0"), "</td>  </tr> ");
                    lValorMiles = int.Parse(lTblTmp.Rows[3]["Valor"].ToString());
                    lRes = string.Concat(lRes, "  <tr> <td>Peso de pallets   (kg)</td>   <td align ='right'>", lValorMiles.ToString("N0"), "</td>  </tr> ");
                    lValorMiles = int.Parse(lTblTmp.Rows[4]["Valor"].ToString());
                    lRes = string.Concat(lRes, "  <tr> <td>Peso de alambre   (Kg)</td>   <td align ='right' >", lValorMiles.ToString("N0"), "</td>  </tr>  ");
                    lValorMiles = int.Parse(lTblTmp.Rows[5]["Valor"].ToString());
                    lRes = string.Concat(lRes, "  <tr> <td >Peso neto de fierro en báscula (Kg)</td>   <td align ='right'  > <b> ", lValorMiles.ToString("N0") , " </b>  </td>  </tr>  </table>");

                    break;
                case "30":
                    lRes = " <table border='1' width='550px' >  <tr>    <td colspan='3' align='center' > <b>Tiempos de estadia de transporte en planta </b> </td>     ";
                    //lRes = string.Concat(lRes, "  <td bgcolor='#0099FF' style='color: #FFFFFF' width='180px'  <b>Tiempo (minutos)  </b> </td>    ");
                    //lRes = string.Concat(lRes, "  <td bgcolor='#0099FF' style='color: #FFFFFF' width='180px'  <b>Tiempo (%)  </b> </td>  </tr>  ");Dtg_RPB


                    lRes = string.Concat(lRes, "<tr >  <tr>    <td bgcolor='#0099FF' style='color: #FFFFFF' width='221px'  <b>Concepto </b> </td>  ");
                    lRes = string.Concat(lRes, "  <td bgcolor='#0099FF' style='color: #FFFFFF' width='180px'  <b>Tiempo (minutos)  </b> </td>    ");
                    lRes = string.Concat(lRes, "  <td bgcolor='#0099FF' style='color: #FFFFFF' width='180px'  <b>Tiempo (%)  </b> </td>  </tr>  ");
                    lRes = string.Concat(lRes, "  <tr>  <td width='221px' >Espera en foso de carga</td> <td align ='right' width='180px'>20</td> <td align ='right' width='180px'>12%</td> </tr>");
                    lRes = string.Concat(lRes, "  <tr>  <td width='221px' >Carga de material</td> <td align ='right' width='67px'>120</td> <td align ='right' width='180px'>71%</td> </tr>");
                    lRes = string.Concat(lRes, "  <tr>  <td width='221px' >Salida del foso a la báscula</td> <td align ='right' width='67px'>20</td> <td align ='right' width='180px' >12%</td> </tr>");
                    lRes = string.Concat(lRes, "  <tr>  <td width='221px' >Emision GDE</td> <td align ='right' width='67px'>10</td> <td align ='right' width='180px'>6%</td> </tr>");
                    lRes = string.Concat(lRes, "  <tr>  <td width='221px' bgcolor='#FF9900' ><b>Tiempo total en planta</b></td> <td bgcolor='#FF9900'  align ='right' width='67px'><b>170</b></td> <td bgcolor='#FF9900'  align ='right' width='180px'><b>100%</b></td> </tr>");
                    lRes = string.Concat(lRes, "  </table>  ");

                    break;
                case "4": // Para el caso de envio Correo Sin  sucursal sin báscula
                    lRes = " <table  cellspacing='1'   >  <tr> <td align='center' > <b>Resumen fierro a cobrar</b> </td>    <td>&nbsp;</td>   ";
                    lRes = string.Concat(lRes, " <td align='center'> <b>Resumen peso báscula</b> </td>    <td>&nbsp;</td> ");
                    lRes = string.Concat(lRes, " <td> </td>    <td>&nbsp;</td>  </tr>   ");

                    lRes = string.Concat(lRes, " <tr> <td>  <table   width='450px'  border='1'>   <tr>    <td bgcolor='#0099FF' style='color: #FFFFFF' width='300px'  <b>Concepto </b> </td>    ");
                    lRes = string.Concat(lRes, "   <td bgcolor='#0099FF' style='color: #FFFFFF' align ='right' > <b>Valor </b> </td>   </tr> ");
                    lRes = string.Concat(lRes, "  <tr>  <td>  Peso fierro real utilizado (kg)  </td>    ");
                    lRes = string.Concat(lRes, "    <td align ='right' > 25.350 </td>    </tr> ");
                    lRes = string.Concat(lRes, "   <tr>   <td>Peso fierro generado por desarrollo (kg)</td>    <td align ='right' >25.368</td>  </tr>   ");
                    lRes = string.Concat(lRes, "   <tr>   <td>Peso fierro por norma 353 (1%) (kg) </td>    <td align ='right' > 368</td>  </tr>  </tr> ");

                    lRes = string.Concat(lRes, "  <tr>    <td>  &nbsp;  </ td >    <td> &nbsp;   </td>       </tr>  </tr> ");


                    lRes = string.Concat(lRes, "  <tr>  <td bgcolor='#FF9900'  ><b> Peso fierro en GD (kg)</b>  </td>    ");
                    lRes = string.Concat(lRes, "   <td align ='right' bgcolor='#FF9900'> <b>  26.845 </b> </td>   </tr>    </table> </td> <td>&nbsp;</td> <td> ");


                    lRes = string.Concat(lRes, "    </table> </td> <td>&nbsp;</td> <td> ");

                    lRes = string.Concat(lRes, "  </td> </tr>  </table>   ");
                    break;



                case "5": // Para el caso de envio Correo Sin  sucursal sin báscula  TIEMPOS DE ESTADIA DE TRANSPORTE EN PLANTA

                    lRes = " <table border='1' width='550px' >  <tr>    <td colspan='3' align='center' > <b>Tiempos de estadia de transporte en planta </b> </td>     ";

                    lRes = string.Concat(lRes, "<tr >  <tr>    <td bgcolor='#0099FF' style='color: #FFFFFF' width='221px'  <b>Concepto </b> </td>  ");
                    lRes = string.Concat(lRes, "  <td bgcolor='#0099FF' style='color: #FFFFFF' width='180px'  <b>Tiempo (minutos)  </b> </td>    ");
                    lRes = string.Concat(lRes, "  <td bgcolor='#0099FF' style='color: #FFFFFF' width='180px'  <b>Tiempo (%)  </b> </td>  </tr>  ");
                    //lRes = string.Concat(lRes, "  <tr>  <td width='221px' >Espera en foso de carga</td> <td align ='right' width='180px'>20</td> <td align ='right' width='180px'>12%</td> </tr>");
                    lRes = string.Concat(lRes, "  <tr>  <td width='221px' >Carga de material</td> <td align ='right' width='67px'>120</td> <td align ='right' width='180px'>71%</td> </tr>");
                    // lRes = string.Concat(lRes, "  <tr>  <td width='221px' >Salida del foso a la báscula</td> <td align ='right' width='67px'>20</td> <td align ='right' width='180px' >12%</td> </tr>");
                    lRes = string.Concat(lRes, "  <tr>  <td width='221px' >Emision GDE</td> <td align ='right' width='67px'>10</td> <td align ='right' width='180px'>6%</td> </tr>");
                    lRes = string.Concat(lRes, "  <tr>  <td width='221px' bgcolor='#FF9900' ><b>Tiempo total en planta</b></td> <td bgcolor='#FF9900'  align ='right' width='67px'><b>170</b></td> <td bgcolor='#FF9900'  align ='right' width='180px'><b>100%</b></td> </tr>");
                    lRes = string.Concat(lRes, "  </table>  ");

                    break;
            }

            return lRes;
        }

        private Boolean GrabarTara_V2()
        {
            Boolean lRes = true;Clases.ClsComun lCom = new Clases.ClsComun();
            WsOperacion.PesajeCamion lObjCam = new WsOperacion.PesajeCamion();
            WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();

            if (Tx_KgsTara.Text.Trim().Length == 0)
            {
                MessageBox.Show("Debe  seleccionar  un camión para grabar la Tara ", "Avisos sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                lObjCam.Id = 0;
                lObjCam.Patente = Cmb_PatenteTara.SelectedValue.ToString();
                lObjCam.PesoTara = int.Parse(Tx_KgsTara.Text);
                lObjCam.FechaTara = DateTime.Now.ToString();
                lObjCam.IdUserTara = int.Parse(mUserLog.Iduser);
                lObjCam.PesoBruto = 0;
                lObjCam.IdDespachoCam = 0;
                lObjCam.Estado = "PesoTara";
                lObjCam.IdCorrelativo = lCom.Val(mIdCorrelativo.ToString()).ToString();
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
                    MessageBox.Show(string.Concat("Ha ocurrido el siguiente error:", lObjCam.errors.ToString()), "Avisos Sistema", MessageBoxButtons.OK);
                }
            }
            return lRes;
        }




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
                if (Tx_Semaforo.BackColor == Color.Red)
                {
     
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
                }
            }
            return lRes;
        }


        private Boolean RevisaDatosAntesGrabacion_V_2()
        {
            Boolean lRes = true; string lMsg = ""; DataTable lTbl = new DataTable();
            WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
            WsOperacion.PesajeCamion lObjCam = new WsOperacion.PesajeCamion();
            WsOperacion.ListaDataSet lDts = new WsOperacion.ListaDataSet();
            Clases.ClsComun lCom = new Clases.ClsComun();
            // Validaciones a Implementar



            // 3- Cuando sea amarillo habilitar la grabacion


            //validar que existan datos en campos alambre - poallet y cuartones
            if (Tx_alambre.Text == "")
                lMsg = string .Concat (" Debe Ingresar el ALAMBRE, revisar ",Environment .NewLine );

            if (Tx_NroPallet.Text == "")
                lMsg = string.Concat(lMsg, " Debe Ingresar el el número de Pallet , revisar ", Environment.NewLine);

            if (Tx_NumeroCuartones.Text == "")
                lMsg = string.Concat(lMsg, " Debe Ingresar el número de cuartones , revisar ", Environment.NewLine);


            if (lMsg.Trim().Length > 0)
            {
                MessageBox.Show(lMsg, "Avisos Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lRes = false;
            }
            else
            { 
                if (Pnl_Msg.BackColor != Color.LightGreen)
            {

                lObjCam.Id = mIdPesajeCamion;
                lObjCam.Patente = Cmb_PatenteCamion.SelectedValue.ToString();
                lObjCam.PesoTara = int.Parse(Tx_taraCamion.Text);
                lObjCam.PesoBruto = int.Parse(Tx_PesoBrutoCamion.Text); ;
                lObjCam.IdUserPesoBruto = int.Parse(mUserLog.Iduser);
                lObjCam.Estado = "PesoCarga";
                lObjCam.IdCorrelativo = mIdCorrelativo;
                lObjCam.NroCuartones = lCom.Val(Tx_NumeroCuartones.Text).ToString();
                lObjCam.NroEstrobos = lCom.Val(Tx_NroPallet.Text).ToString();
                lObjCam.KgsCuartones = lCom.Val(Tx_KilosCuartones.Text).ToString();
                lObjCam.KgsEstrobos = lCom.Val(Tx_KilosPallet.Text).ToString();

                // Tx_ToleranciaReal.Text 
                //if (Pnl_Msg.BackColor == Color.Red)
                //{
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
                        //GrabarDatos_V2();
                        lRes = true;
                        Btn_GrabarDespacho.Enabled = false;
                    }
                }

            }
            }
            if (lRes == false)
            {

            }
            else
            {
                lObjCam.Id = mIdPesajeCamion;
                lObjCam.Patente = Cmb_PatenteCamion.SelectedValue.ToString();
                lObjCam.PesoTara = int.Parse(Tx_taraCamion.Text);

                lObjCam.PesoBruto = int.Parse(Tx_PesoBrutoCamion.Text); ;
                lObjCam.IdUserPesoBruto = int.Parse(mUserLog.Iduser);
                lObjCam.Estado = "PesoCarga";
                lObjCam.IdCorrelativo = mIdCorrelativo;
                lObjCam.NroCuartones = lCom.Val(Tx_NumeroCuartones.Text).ToString();
                lObjCam.NroEstrobos = lCom.Val(Tx_NroPallet.Text).ToString();
                lObjCam.KgsCuartones = lCom.Val(Tx_KilosCuartones.Text).ToString();
                lObjCam.KgsEstrobos = lCom.Val(Tx_KilosPallet.Text).ToString();
                lObjCam.KgsAlambre = lCom.Val(Tx_alambre.Text).ToString();
                lObjCam.UsuarioAutoriza = mUserAutoriza;
                lObjCam.ObsAutorizacion = mObsUserAutoriza;

                lObjCam = wsOperacion.GrabarDatosPesajeCamion(lObjCam);
                if (lObjCam.Id > 0)
                {
                    //enviar Correo para informar.
                    lDts = wsOperacion.ObtenerDatosPesajeCamion(lObjCam.Id.ToString());
                    if (lDts.MensajeError.Trim().Length == 0)
                    {

                        lTbl = (DataTable)Dtg_RFC_.DataSource;
                        lTbl.TableName = "RFC";
                        lDts.DataSet.Tables.Add(lTbl.Copy());
                        lTbl = new DataTable();
                        lTbl = (DataTable)Dtg_RVC.DataSource;
                        lTbl.TableName = "RVC";
                        lDts.DataSet.Tables.Add(lTbl.Copy());
                        lTbl = new DataTable();
                        lTbl = (DataTable)Dtg_RPB.DataSource;
                        lTbl.TableName = "PBR";
                        lDts.DataSet.Tables.Add(lTbl.Copy());

                        EnviaCorreoNotificacion_DespachoConBascula(lDts.DataSet.Copy(), mIdPesajeCamion.ToString());
                    }
                    MessageBox.Show("Los Datos han sido Grabados Correctamente ", "Avisos Sistema", MessageBoxButtons.OK);
                    mIdCorrelativo = "0";
                    Btn_GrabarDespacho.Enabled = false;
                    lRes = true;
                }
            }
            return lRes;
        }

        private void Btn_Grabar_Click(object sender, EventArgs e)
        {
            if (RevisaDatosAntesGrabacion() == true)
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
            DataRow lFila = null;
            //formateaGrillas();
            CreaEstructuraTabla();
            try
            {
                Clases.SqlBascula lTipoSql = new Clases.SqlBascula(); string lSql = "";
                Clases.ClsComun lDAL = new Clases.ClsComun(); DataTable lTbl = new DataTable();
                string lFecha =  DateTime.Now.ToShortDateString();

                //lFecha = "08/12/2023 11:11:11";

                lSql = lTipoSql.ObtenerSqlTaraInicial(lFecha);
                lTbl = lDAL.CargaTablaRomana(lSql);
                if (lTbl.Rows.Count > 0)
                {
                   // MessageBox.Show("ENTRO");
                    lFila = lTbl.NewRow();
                    lFila["patente"] = "Seleccionar";
                    lTbl.Rows.Add(lFila);
                    new Forms().comboBoxFill(Cmb_PatenteTara, lTbl, "patente", "patente", lTbl.Rows.Count - 1);
                }
                else {
                  //  MessageBox.Show(lSql);
                }
             


                ObtenerCamionesEnPlanta();
                CargaPatentes();

                OcultaTabs();
                Lbl_Msg.Visible = false;
            }
            catch (Exception iex)
            {
                MessageBox.Show(string.Concat("Ha ocurrido en siguiente error: ", iex.Message.ToString()),"Avisos sistema");
            }
        }

        private void OcultaTabs()
        {
            tabControl1.TabPages.Remove(tabPage1);
            tabControl1.TabPages.Remove(tabPage2);
            tabControl1.TabPages.Remove(tabPage3);
            tabControl1.TabPages.Remove(tabPage4);
            tabControl1.TabPages.Remove(tabPage5);

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
            if ((Cmb_Patente.SelectedValue != null) && (Cmb_Patente.SelectedValue.ToString() != "Seleccionar"))
            {
                if (mBuscaDatosPatente == true)
                {
                    CargaDatosPesoTaraPorPatente(Cmb_Patente.SelectedValue.ToString());
                }

            }
        }

        private void CargaDatosPesoTaraPorPatente(string iPatente)
        {
            WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient(); int i = 0;
            WsOperacion.ListaDataSet lLIstaDts = new WsOperacion.ListaDataSet(); DataTable lTbl = new DataTable();
            if (Tx_Bruto.Enabled == false)
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
                    Tx_IdCorrTara_.Text = mIdPesajeCamion.ToString();
                    mKilosCargadosCamion = int.Parse(lTbl.Rows[0]["KgsCargados"].ToString());
                    mKilosCargadosCamionDesarrollo = int.Parse(lTbl.Rows[0]["KgsDesarrollo"].ToString());
                    mKilosFactorCorreccion = int.Parse(lTbl.Rows[0]["KgsFC"].ToString());
                    mKilosFactorCorreccionDesa = int.Parse(lTbl.Rows[0]["KgsFC_Desa"].ToString());
                    Tx_Tara.ReadOnly = true;

                    WsOperacion.OperacionSoapClient lPxOper = new WsOperacion.OperacionSoapClient();// decimal lKgsNorma353 = 0; decimal lKgsDesarrollo = 0;
                    //WsOperacion.ListaDataSet lLIstaDts = new WsOperacion.ListaDataSet(); DataTable lTbl = new DataTable();
                    lLIstaDts = lPxOper.ObtenerDetallePesaje(mIdPesajeCamion.ToString());
                    if (lLIstaDts.DataSet.Tables.Count > 0)
                    {
                        mTblDetalleDespacho = lLIstaDts.DataSet.Tables[0].Copy();
                        if (mTblDetalleDespacho.Columns.Contains("KgsTeorico") == false)
                            mTblDetalleDespacho.Columns.Add("KgsTeorico");

                        if (mTblDetalleDespacho.Columns.Contains("KgsDesarrollo") == false)
                            mTblDetalleDespacho.Columns.Add("KgsDesarrollo");

                        for (i = 0; i < lTbl.Rows.Count; i++)
                        {
                            //lKgsNorma353 = lKgsNorma353 + decimal.Parse(lTbl.Rows[i]["KgsNorma353"].ToString());
                            //lKgsDesarrollo = lKgsDesarrollo + (decimal.Parse(lTbl.Rows[i]["KgsPaquete"].ToString()) - decimal.Parse(lTbl.Rows[i]["KgsReales"].ToString()));

                            mTblDetalleDespacho.Rows[i]["KgsTeorico"] = double.Parse(mTblDetalleDespacho.Rows[i]["Kgspaquete"].ToString()) - double.Parse(mTblDetalleDespacho.Rows[i]["KgsNorma353"].ToString());
                            mTblDetalleDespacho.Rows[i]["KgsDesarrollo"] = double.Parse(mTblDetalleDespacho.Rows[i]["KgsTeorico"].ToString()) - double.Parse(mTblDetalleDespacho.Rows[i]["KgsReales"].ToString());

                        }
                    }
                }
                else
                {
                    Tx_Tara.Text = "0";
                    mIdPesajeCamion = 0;
                    Tx_IdPesajeCam.Text = "0";
                    Tx_IdCorrTara_.Text = "0";
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
            lLIstaDts = wsOperacion.ObtenerDatosGuiasSinVincular();
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
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient(); DataSet lDts = new DataSet();
            DataTable lTbl = new DataTable();

            string lSql = "  SP_ConsultasGenerales 116,' ','','','',''";
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
            Tx_ToleranciaDesa.Text = "0";

        }


        private void CargaPesoBruto()
        {
            Clases.ClsComun lCom = new Clases.ClsComun();
            int lDiferencia = 0; int lPesoBruto = 0;
            //ObtenerPesoBruto
            if (Tx_Bruto.Enabled == false)
                lPesoBruto = int.Parse(ObtenerPesoBruto());
            else
                lPesoBruto = int.Parse(Tx_Bruto.Text);

            int lPesoTara = int.Parse(Tx_Tara.Text);
            int lPesoGD = int.Parse(mKilosCargadosCamion.ToString());
            int lPesoDesarrollo = int.Parse(mKilosCargadosCamionDesarrollo.ToString());
            int lPesoAdicional = lCom.Val(Tx_PesoAdicional.Text);

            //Peso Bruto
            if (Tx_Bruto.Enabled == false)
                this.Tx_Bruto.Text = lPesoBruto.ToString();
            //Peso Neto
            this.Tx_PesoNeto.Text = (lPesoBruto - lPesoTara).ToString();
            //Peso Adicional
            if (Tx_TotalKgs.Text.Trim().Length == 0)
                Tx_TotalKgs.Text = "0";

            Tx_PesoAdicional.Text = Tx_TotalKgs.Text;
            //Peso Solo Fierro
            Tx_PesoSoloFierro.Text = (lCom.Val(Tx_PesoNeto.Text) - lCom.Val(Tx_PesoAdicional.Text)).ToString();
            //Peso Guia Despacho
            Tx_KgsCargados.Text = lPesoGD.ToString();

            int lSoloFierro = int.Parse(Tx_PesoSoloFierro.Text);

            //Datos del desarrollo
            Tx_KgsDesarrollo.Text = (lPesoDesarrollo - mKilosFactorCorreccionDesa).ToString();
            lDiferencia = lCom.Val(Tx_PesoSoloFierro.Text) - (lPesoDesarrollo - mKilosFactorCorreccionDesa);
            Tx_DifDesarrollo.Text = lDiferencia.ToString();
            mToleranciaRealDesa = (double.Parse(lDiferencia.ToString()) / double.Parse(lSoloFierro.ToString())) * 100;
            Tx_ToleranciaDesa.Text = Math.Round(mToleranciaRealDesa, 2).ToString();

            // Factor de Corrección
            if (mKilosFactorCorreccion > 0)
            {
                Tx_FC.Text = mKilosFactorCorreccion.ToString();
                Tx_KgsSiVa.Text = (lPesoGD - mKilosFactorCorreccion).ToString();
            } else
            {
                Tx_FC.Text = "0";
                Tx_KgsSiVa.Text = lPesoGD.ToString();

            }


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

            // CargaDatosResumen();
        }

        private void CargaDatosResumen()
        {
            DataTable lTblRPB = new DataTable(); DataRow lFila = null; int i = 0; int lTotalPeso = 0; decimal lPorcentaje = 0;
            Clases.ClsComun lCom = new Clases.ClsComun(); DataTable lTblRFC = new DataTable(); DataTable lTblRVC = new DataTable();
            int lTmp = 0;
            try
            {
                // Primero Resumen Peso Bascula  Dtg_RPeso
                lTblRPB.Columns.Add("Concepto");
                lTblRPB.Columns.Add("Valor");

                lFila = lTblRPB.NewRow();
                lFila["Concepto"] = "Peso bruto bascula (kg)";
                lFila["Valor"] = Tx_PesoSoloFierro.Text;
                lTblRPB.Rows.Add(lFila);

                for (i = 0; i < Dtg_adicionales.Rows.Count; i++)
                {
                    if (Dtg_adicionales.Rows[i].Cells["Elemento"].Value != null)
                    {
                        lFila = lTblRPB.NewRow();
                        lFila["Concepto"] = Dtg_adicionales.Rows[i].Cells["Elemento"].Value.ToString();
                        lFila["Valor"] = Dtg_adicionales.Rows[i].Cells["TotalPeso"].Value.ToString();
                        lTblRPB.Rows.Add(lFila);
                    }

                }

                for (i = 0; i < lTblRPB.Rows.Count; i++)
                {
                    switch (lTblRPB.Rows[i]["Concepto"].ToString().ToUpper())
                    {
                        case "ALAMBRE":
                            lTotalPeso = lTotalPeso - lCom.Val(lTblRPB.Rows[i]["Valor"].ToString());
                            break;
                        case "PALLET":
                            lTotalPeso = lTotalPeso - lCom.Val(lTblRPB.Rows[i]["Valor"].ToString());
                            break;
                        case "CUARTÓN":
                            lTotalPeso = lTotalPeso - lCom.Val(lTblRPB.Rows[i]["Valor"].ToString());
                            break;
                        default:
                            lTotalPeso = lTotalPeso + lCom.Val(lTblRPB.Rows[i]["Valor"].ToString());
                            break;
                    }
                    //lTotalPeso = lTotalPeso - lCom.Val(lTblRPB.Rows[i]["Valor"].ToString());                   
                }
                lFila = lTblRPB.NewRow();
                lFila["Concepto"] = "Peso neto bascula (kg)";
                lFila["Valor"] = lTotalPeso;
                lTblRPB.Rows.Add(lFila);

                Dtg_RPeso.DataSource = lTblRPB;
                Dtg_RPeso.Columns["Concepto"].Width = 200;
                Dtg_RPeso.Columns["Valor"].Width = 70;
                Dtg_RPeso.Columns["Concepto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                Dtg_RPeso.Columns["Valor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                lTblRFC = lTblRPB.Clone();
                lTblRFC.Clear();
                lFila = lTblRFC.NewRow();
                lFila["Concepto"] = "Peso fierro real utilizado (kg)"; lFila["Valor"] = Tx_KgsCargados.Text; lTblRFC.Rows.Add(lFila);
                lFila = lTblRFC.NewRow();
                lFila["Concepto"] = "Peso fierro generado por desarrollo (kg)"; lFila["Valor"] = lCom.Val(Tx_KgsCargados.Text) - lCom.Val(Tx_KgsDesarrollo.Text); lTblRFC.Rows.Add(lFila);
                lFila = lTblRFC.NewRow();
                lFila["Concepto"] = "Peso fierro por norma 353 (1%) (kg)"; lFila["Valor"] = ObtenerPeso_X_Norma353(); lTblRFC.Rows.Add(lFila);

                lTmp = lCom.Val(lTblRFC.Rows[0]["Valor"].ToString()) - lCom.Val(lTblRFC.Rows[1]["Valor"].ToString()) + lCom.Val(lTblRFC.Rows[2]["Valor"].ToString());
                lFila = lTblRFC.NewRow();
                lFila["Concepto"] = "Peso fierro en GD (kg)"; lFila["Valor"] = lTmp; lTblRFC.Rows.Add(lFila); // Tx_KgsCargados.Text ; 
                Dtg_RFC.DataSource = lTblRFC;
                Dtg_RFC.Columns["Concepto"].Width = 240;
                Dtg_RFC.Columns["Valor"].Width = 60;
                //Dtg_RPeso.Columns["Concepto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                Dtg_RFC.Columns["Valor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                // Resumen Validacipon de carga
                lTblRVC = lTblRPB.Clone();
                lTblRVC.Clear();
                lFila = lTblRVC.NewRow();
                lFila["Concepto"] = "Peso fierro real utilizado (kg) "; lFila["Valor"] = Tx_KgsCargados.Text; lTblRVC.Rows.Add(lFila);
                lFila = lTblRVC.NewRow();
                lFila["Concepto"] = "Peso neto bascula (kg) "; lFila["Valor"] = Tx_PesoSoloFierro.Text; lTblRVC.Rows.Add(lFila);
                lFila = lTblRVC.NewRow();
                lTmp = lCom.Val(Tx_KgsCargados.Text) - lCom.Val(Tx_PesoSoloFierro.Text);
                lFila["Concepto"] = "Diferencia fierro real - bascula (kg) "; lFila["Valor"] = lTmp; lTblRVC.Rows.Add(lFila);
                lFila = lTblRVC.NewRow();
                lPorcentaje = ((lCom.CDBl(Tx_KgsCargados.Text) / lCom.CDBl(Tx_PesoSoloFierro.Text)));
                lFila["Concepto"] = "Porcentaje fierro real/báscula (%)"; lFila["Valor"] = Math.Round(lPorcentaje, 2); lTblRVC.Rows.Add(lFila);

                Dtg_RF_Cobrar.DataSource = lTblRVC;
                Dtg_RF_Cobrar.Columns["Concepto"].Width = 240;
                Dtg_RF_Cobrar.Columns["Valor"].Width = 60;
                //Dtg_RPeso.Columns["Concepto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                Dtg_RF_Cobrar.Columns["Valor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private string ObtenerPeso_X_Norma353()
        {
  
            WsOperacion.OperacionSoapClient lPxOper = new WsOperacion.OperacionSoapClient();
            WsOperacion.ListaDataSet lLIstaDts = new WsOperacion.ListaDataSet(); DataTable lTbl = new DataTable();
            int i = 0; DataTable lTblViajes = new DataTable(); double lTotalKgs = 0; Clases.ClsComun lCom = new Clases.ClsComun();
            lLIstaDts = lPxOper.ObtenerDetallePesaje(mIdPesajeCamion.ToString());
            if (lLIstaDts.MensajeError.Trim().Length == 0)
            {
                if ((lLIstaDts.DataSet.Tables.Count > 0) && (lLIstaDts.DataSet.Tables[0].Rows.Count > 0))
                {
                    lTbl = lLIstaDts.DataSet.Tables["DetallePesaje"].Copy();
                    for (i = 0; i < lTbl.Rows.Count; i++)
                    {
                        lTotalKgs = lTotalKgs + lCom.CDBL(lTbl.Rows[i]["KgsNorma353"].ToString());

                    }


                }
            }

            return lTotalKgs.ToString();
        }


        private void PintaSemaforo(double iTolCal, double iTolBascula, double iTolDesa)
        {
            Color lColor = new Color(); DataView lVista = null; Clases.ClsComun lCom = new Clases.ClsComun();
            double lTolSuperior = 0; double lTolInferior = 0;

            if (mTblConfTolerancia.Rows.Count > 0)
            {
                //Obtemos la tolerancia  Inferior
                lVista = new DataView(mTblConfTolerancia, "SubTabla='ToleranciaInferior'", "", DataViewRowState.CurrentRows);
                if (lVista.Count > 0)
                    lTolInferior = lCom.CDBL(lVista[0]["Par1"].ToString().Replace(".", ","));

                //Obtemos la tolerancia Superior
                lVista = new DataView(mTblConfTolerancia, "SubTabla='ToleranciaSuperior'", "", DataViewRowState.CurrentRows);
                if (lVista.Count > 0)
                    lTolSuperior = lCom.CDBL(lVista[0]["Par1"].ToString().Replace(".", ","));


            }
            //Btn_Grabar.Enabled = false;

            if ((Math.Abs(iTolCal) < lTolSuperior) || (Math.Abs(iTolDesa) < lTolSuperior))   // Esta por sobre la cota superior
                lColor = Color.Green;
            else
                lColor = Color.Red;


            if (lColor == Color.Red)
            {
                if ((Math.Abs(iTolCal) < lTolInferior) || (Math.Abs(iTolDesa) < lTolInferior))    // Esta por bajo la cota inferior
                    lColor = Color.Green;
                else
                    lColor = Color.Red;
            }




            if ((iTolCal == 0))   // Esta  entre 0 y  -2 
            {
                lColor = Color.Green;
                Btn_Grabar.Enabled = true;
            }


            //Tx_semaforoV2.BackColor = lColor;

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

        private void GeneraDatos()
        {
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient(); DataSet lDts = new DataSet();
            string lSql = ""; DataTable lTbl = new DataTable(); string lIdPesaje = ""; int i = 0;
            DataTable lTblTmp = new DataTable();
            string lNroGD = ""; string lPesoGD = ""; string lDif_basculaGD = ""; string lDesviacion_GD_Bascula = "";
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
                Tx_IdPesaje.Text = Dtg_CamionEnPlanta.Rows[lIndex].Cells["Id"].Value.ToString();
                Tx_pesoTara.Text = Dtg_CamionEnPlanta.Rows[lIndex].Cells["PesoTara"].Value.ToString();
                Tx_patenteCamion.Text = Dtg_CamionEnPlanta.Rows[lIndex].Cells["Patente"].Value.ToString();
                Tx_usuario.Text = Dtg_CamionEnPlanta.Rows[lIndex].Cells["Usuario"].Value.ToString();
                Tx_KilosCargados.Text = Dtg_CamionEnPlanta.Rows[lIndex].Cells["KgsCargados"].Value.ToString();

                if (int.Parse(Tx_KilosCargados.Text) > 0)
                {
                    Btn_eliminar.Enabled = false;
                    Btn_CerrarCiclo.Enabled = true;
                }
                else
                {
                    Btn_eliminar.Enabled = true;
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

        private void PintaFila(ref DataGridView iGrilla, int iFila, Color iColor)
        {
            int lCol = 0;

            for (lCol = 0; lCol < iGrilla.ColumnCount; lCol++)
            {
                iGrilla.Rows[iFila].Cells[lCol].Style.BackColor = iColor;
            }



        }

        private string EliminaRegistroCamion(string iIdPesaje)
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
            if (Tx_IdPesaje.Text.Length > 0)
            {

                if (MessageBox.Show("¿Esta Seguro que desea Eliminar el Registro Seleccionado?", "Avisos Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
            int lIndex = e.RowIndex; int i = 0; DataRow lFila = null; int lKgs = 0; Clases.ClsComun lcom = new Clases.ClsComun();

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

                            for (i = 0; i < lLIstaDts.DataSet.Tables["DetallePC"].Rows.Count; i++)
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


                    Cursor.Current = Cursors.Default;

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
            int i = 0; string lSql = ""; Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient(); Clases.ClsComun lCom = new Clases.ClsComun();
            string lMsg = string.Concat("¿Esta seguro que desea Vincular el Nro de guía ", Tx_NroGuiaINET_V.Text, " al detalle de Despacho Camión?");

            if (MessageBox.Show(lMsg, "Avisos Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                for (i = 0; i < Dtg_DetallePesaje.Rows.Count; i++)
                {
                    if (Dtg_DetallePesaje.Rows[i].Cells["IdPesajeCamion"].Value.ToString().Trim().Length > 0)
                    {
                        lSql = String.Concat(" SP_ConsultasGenerales 115,'", Tx_NroGuiaINET_V.Text, "','", Tx_kgsINET_V.Text, "','", Dtg_DetallePesaje.Rows[i].Cells["IdPesajeCamion"].Value.ToString(), "','", Dtg_DetallePesaje.Rows[i].Cells["Id"].Value.ToString(), "','' ");

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
            lFrm.CargaDatosPorGuiaINET(lGuia, "", "", "");
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
            lFrm.CargaDatos(mIdPesajeCamion.ToString(), Cmb_Patente.SelectedValue.ToString(), Tx_Tara.Text, Tx_Bruto.Text, Tx_PesoSoloFierro.Text);
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
                IdPesaje_PR.Text = Dtg_CamionDespachados.Rows[lIndex].Cells["Id"].Value.ToString();

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
            lfrm.IniciaForm(IdPesaje_PR.Text.ToString());

            lfrm.ShowDialog();
        }

        private void Cmb_Elemento_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargaDatosElemento(Cmb_Elemento.SelectedValue.ToString());
        }

        private void CargaDatosElemento(string lIdElemento)
        {
            DataView lVista = new DataView(mAdicionalesCamion, string.Concat("Id=", lIdElemento), "", DataViewRowState.CurrentRows);
            if (lVista.Count > 0)
            {
                Tx_PU.Text = lVista[0]["Par2"].ToString();

            }
        }

        private void Tx_Cantidad_Validating(object sender, CancelEventArgs e)
        {
            Clases.ClsComun lCom = new Clases.ClsComun();
            try
            {

                Tx_PesoTotal.Text = (lCom.Val(Tx_Cantidad.Text) * lCom.Val(Tx_PU.Text)).ToString();


            }
            catch (Exception iex)
            {

            }

        }

        private void CreaEstructuraTabla()
        {
            mTblElementosIngresado = new DataTable();
            mTblElementosIngresado.Columns.Add("Elemento");
            mTblElementosIngresado.Columns.Add("Cantidad");
            mTblElementosIngresado.Columns.Add("PU");
            mTblElementosIngresado.Columns.Add("TotalPeso");

        }

        private void Btn_Add_Click(object sender, EventArgs e)
        {
            Clases.ClsComun lDal = new Clases.ClsComun(); string lTx = ""; DataRow lFila = null;

            // validamos que tenga un elemento seleccionado
            if (Cmb_Elemento.SelectedValue.ToString().Equals("0"))
            {
                lTx = "Debe Seleccionar un elemento del desplegable. ";
                Cmb_Elemento.Focus();
            }
            if (lDal.Val(Tx_Cantidad.Text) == 0)
            {
                lTx = "Debe Ingresar una Cantidad Valida, Revisar. ";
                Tx_Cantidad.Focus();
            }
            else
            {
                switch (Cmb_Elemento.Text)
                {
                    case "Alambre":   // Sin Restriccion
                                      //lTx_Caso = " Para la Obra xxx  se ha generado un <b> despacho con sobre peso </b> con los siguientes resultados";
                                      //lTx_Caso = string.Concat(lTx_Caso, " <BR> ", lTxAutoriza, " <BR>");

                        break;
                    case "Pallet":      // debe estar entre 1 y 10
                        if ((lDal.Val(Tx_Cantidad.Text) < 0) || (lDal.Val(Tx_Cantidad.Text) > 10))
                        {
                            lTx = "Debe Ingresar una Cantidad entre 1 y 10. Revisar. ";
                            Tx_Cantidad.Focus();
                        }
                        break;
                    case "Cuartón":      // debe estar entre cero y 20
                        if ((lDal.Val(Tx_Cantidad.Text) < 0) || (lDal.Val(Tx_Cantidad.Text) > 20))
                        {
                            lTx = "Debe Ingresar una Cantidad entre 1 y 20. Revisar. ";
                            Tx_Cantidad.Focus();
                        }
                        break;
                    default:
                        lTx = "Debe Seleccionar un elemento. Revisar ";
                        Tx_Cantidad.Focus();
                        break;
                }
            }

            if (lTx.Trim().Length > 0)
                MessageBox.Show(lTx, " Avisos Sistema ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                DataView lVista = new DataView(mTblElementosIngresado, string.Concat("Elemento='", Cmb_Elemento.Text, "'"), "", DataViewRowState.CurrentRows);
                if (lVista.Count == 0)
                {
                    lFila = mTblElementosIngresado.NewRow();
                    lFila["Elemento"] = Cmb_Elemento.Text;
                    lFila["Cantidad"] = Tx_Cantidad.Text;
                    lFila["PU"] = Tx_PU.Text;
                    lFila["TotalPeso"] = lDal.Val(Tx_Cantidad.Text) * lDal.Val(Tx_PU.Text);
                    mTblElementosIngresado.Rows.Add(lFila);
                }
                else
                {
                    lVista[0]["Elemento"] = Cmb_Elemento.Text;
                    lVista[0]["Cantidad"] = Tx_Cantidad.Text;
                    lVista[0]["PU"] = Tx_PU.Text;
                    lVista[0]["TotalPeso"] = lDal.Val(Tx_Cantidad.Text) * lDal.Val(Tx_PU.Text);
                }

                Dtg_adicionales.DataSource = mTblElementosIngresado;
                Dtg_adicionales.Columns["Elemento"].Width = 90;
                Dtg_adicionales.Columns["Cantidad"].Width = 70;
                Dtg_adicionales.Columns["PU"].Width = 50;
                Dtg_adicionales.Columns["TotalPeso"].Width = 80;
            }


        }

        private void Tx_Cantidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void Tx_Bruto_TextChanged(object sender, EventArgs e)
        {

        }

        private void Tx_Bruto_Validating(object sender, CancelEventArgs e)
        {
            // CargaDatosPesoTaraPorPatente(Cmb_Patente.SelectedValue.ToString());
            MuestraDatosSegunCheck();
        }

        private void Dtg_adicionales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataSet lDts = new DataSet();
            EnviaCorreoNotificacion_DespachoConBascula(lDts,"");

        }

        private void Rb_PreDespacho_CheckedChanged(object sender, EventArgs e)
        {
            if (Rb_PreDespacho.Checked == true)
            {
                MuestraDatosSegunCheck();
            }
        }

        #region Metodos de la nueva versión de despacho camion

        private void CargaPatentes()
        {
            string lSql = "select Des_Cam_Camion as Patente,*from despacho_Camion where Des_estado in ( 'EnCarga' , 'FIN')";
            Ws_TO.Ws_ToSoapClient lDal = new Ws_TO.Ws_ToSoapClient(); DataSet lDts = new DataSet();
            DataTable lTbl = new DataTable(); DataRow lFila = null;

            lDts = lDal.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                lTbl = lDts.Tables[0].Copy();
                lFila = lTbl.NewRow();
                lFila["patente"] = "Seleccionar";
                lTbl.Rows.Add(lFila);
                new Forms().comboBoxFill(Cmb_PatenteCamion, lTbl, "patente", "patente", lTbl.Rows.Count - 1);
                //Cmb_PatenteCamion.SelectedText = "Seleccionar";
            }
        }

        private void CargaDatosPesoTaraPorPatente_PreDespacho(string iPatente)
        {
            WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient(); int i = 0;
            WsOperacion.ListaDataSet lLIstaDts = new WsOperacion.ListaDataSet(); DataTable lTbl = new DataTable();
            //if (Tx_Bruto.Enabled == false)
            //    LimpiaDatosPesoBruto();

            lLIstaDts = wsOperacion.ObtenerPesoTaraPorPatente(iPatente);

            mKilosCargadosCamion = 0;
            mKilosCargadosCamionDesarrollo = 0;

            if (lLIstaDts.DataSet.Tables.Count > 0)
            {
                lTbl = lLIstaDts.DataSet.Tables[0].Copy();
                if (lTbl.Rows.Count > 0)
                {
                    // Tx_Tara.Text = lTbl.Rows[0]["PesoTara"].ToString();
                    mIdPesajeCamion = int.Parse(lTbl.Rows[0]["IdPesajeCamion"].ToString());
                    //  Tx_IdPesajeCam.Text = mIdPesajeCamion.ToString();
                    //  Tx_IdCorrTara.Text = mIdPesajeCamion.ToString();
                    mKilosCargadosCamion = int.Parse(lTbl.Rows[0]["KgsCargados"].ToString());
                    mKilosCargadosCamionDesarrollo = int.Parse(lTbl.Rows[0]["KgsDesarrollo"].ToString());
                    mKilosFactorCorreccion = int.Parse(lTbl.Rows[0]["KgsFC"].ToString());
                    mKilosFactorCorreccionDesa = int.Parse(lTbl.Rows[0]["KgsFC_Desa"].ToString());
                    Tx_KgsPistoleados.Text = mKilosCargadosCamion.ToString();
                    //   Tx_Tara.ReadOnly = true;
                    WsOperacion.OperacionSoapClient lPxOper = new WsOperacion.OperacionSoapClient();// decimal lKgsNorma353 = 0; decimal lKgsDesarrollo = 0;
                    //WsOperacion.ListaDataSet lLIstaDts = new WsOperacion.ListaDataSet(); DataTable lTbl = new DataTable();
                    lLIstaDts = lPxOper.ObtenerDetallePesaje(mIdPesajeCamion.ToString());
                    if (lLIstaDts.DataSet.Tables.Count > 0)
                    {
                        mTblDetalleDespacho = lLIstaDts.DataSet.Tables[0].Copy();
                        if (mTblDetalleDespacho.Columns.Contains("KgsTeorico") == false)
                            mTblDetalleDespacho.Columns.Add("KgsTeorico");

                        if (mTblDetalleDespacho.Columns.Contains("KgsDesarrollo") == false)
                            mTblDetalleDespacho.Columns.Add("KgsDesarrollo");

                        for (i = 0; i < mTblDetalleDespacho.Rows.Count; i++)
                        {
                            //lKgsNorma353 = lKgsNorma353 + decimal.Parse(lTbl.Rows[i]["KgsNorma353"].ToString());
                            //lKgsDesarrollo = lKgsDesarrollo + (decimal.Parse(lTbl.Rows[i]["KgsPaquete"].ToString()) - decimal.Parse(lTbl.Rows[i]["KgsReales"].ToString()));

                            //mTblDetalleDespacho.Rows[i]["KgsTeorico"] = double.Parse(mTblDetalleDespacho.Rows[i]["Kgs paquete"].ToString()) - double.Parse(mTblDetalleDespacho.Rows[i]["Kgs Norma 353"].ToString());
                            //mTblDetalleDespacho.Rows[i]["KgsDesarrollo"] = double.Parse(mTblDetalleDespacho.Rows[i]["KgsTeorico"].ToString()) - double.Parse(mTblDetalleDespacho.Rows[i]["KgsReales"].ToString());

                            mTblDetalleDespacho.Rows[i]["KgsTeorico"] = double.Parse(mTblDetalleDespacho.Rows[i][6].ToString()) - double.Parse(mTblDetalleDespacho.Rows[i][5].ToString());
                            mTblDetalleDespacho.Rows[i]["KgsDesarrollo"] = double.Parse(mTblDetalleDespacho.Rows[i]["KgsTeorico"].ToString()) - double.Parse(mTblDetalleDespacho.Rows[i][3].ToString());
                        }
                    }

                }
                else
                {
                    //Tx_Tara.Text = "0";
                    //mIdPesajeCamion = 0;
                    //Tx_IdPesajeCam.Text = "0";
                    //Tx_IdCorrTara.Text = "0";
                    //mKilosCargadosCamion = 0;
                    //mKilosCargadosCamionDesarrollo = 0;
                    //Tx_Tara.ReadOnly = true;
                }
            }

            //CargaPesoBruto();
        }


        private void CalcularDatos()
        {
            int lPesoNeto = 0; Clases.ClsComun lCom = new Clases.ClsComun(); int lAdicionales = 0;
            int lPesoNetoCamion = 0;


            if (lCom.Val(Tx_PesoBrutoCamion.Text) > 0)
                if (lCom.Val(Tx_PesoBrutoCamion.Text) > 0)
                {
                    lPesoNeto = (lCom.Val(Tx_PesoBrutoCamion.Text) - (lCom.Val(Tx_taraCamion.Text)));

                    if (lCom.Val(Tx_alambre.Text) > 0)
                        lAdicionales = lAdicionales + lCom.Val(Tx_alambre.Text);

                    if (lCom.Val(Tx_KilosPallet.Text) > 0)
                        lAdicionales = lAdicionales + lCom.Val(Tx_KilosPallet.Text);


                    if (lCom.Val(Tx_KilosCuartones.Text) > 0)
                        lAdicionales = lAdicionales + lCom.Val(Tx_KilosCuartones.Text);

                    lPesoNetoCamion = lCom.Val(Tx_KgsPistoleados.Text) + lAdicionales;
                    Tx_PesoNetoCamion.Text = (lPesoNeto - lAdicionales).ToString();

                    // calculamos el Peso fierro real utilizado
                    DataTable lTbl = new DataTable(); int i = 0; decimal lTotalKgs = 0;
                    lTbl = mTblDetalleDespacho.Copy(); //  lLIstaDts.DataSet.Tables[0].Copy();
                    for (i = 0; i < lTbl.Rows.Count; i++)
                    {
                        lTotalKgs = lTotalKgs + (decimal.Parse(lTbl.Rows[i]["Kgs Reales"].ToString()));
                    }

                    lTotalKgs = Math.Round(lTotalKgs, 0);
                    //************************************
                    DataTable lTblRVC = new DataTable(); DataTable lTblRFC = new DataTable(); DataRow lFila = null; Boolean lSeguir = true;
                    decimal lTmp = 0; decimal lPorcentaje = 0; string lMsg = "";
                    // Resumen Validacipon de carga
                    lTblRVC.Columns.Add("Concepto");
                    lTblRVC.Columns.Add("Valor");
                    //lTblRVC = lTblRPB.Clone();
                    lTblRVC.Clear();
                    lFila = lTblRVC.NewRow();
                    lFila["Concepto"] = "Peso fierro real utilizado (kg) "; lFila["Valor"] = lTotalKgs; lTblRVC.Rows.Add(lFila);
                    lFila = lTblRVC.NewRow();
                    lFila["Concepto"] = "Peso neto bascula (kg) "; lFila["Valor"] = Tx_PesoNetoCamion.Text; lTblRVC.Rows.Add(lFila);
                    lFila = lTblRVC.NewRow();
                    lTmp = decimal.Parse(Tx_PesoNetoCamion.Text) - lTotalKgs;
                    // Peso neto bascula (kg)  -  Peso fierro real utilizado (kg)

                    lFila["Concepto"] = "Diferencia fierro  bascula - real (kg) "; lFila["Valor"] = lTmp; lTblRVC.Rows.Add(lFila);
                    lFila = lTblRVC.NewRow();

                    // 16/11/2023 definicion entregada por lgallardo
                    //(Peso neto bascula (kg)  -  Peso fierro real utilizado (kg))/Peso neto bascula (kg) 
                    lPesoNetoCamion = int.Parse (Tx_PesoNetoCamion.Text);
                    lPorcentaje = ((lTmp / lPesoNetoCamion) ) * 100;
                    lFila["Concepto"] = "Porcentaje fierro báscula/real  (%)"; lFila["Valor"] = Math.Round(lPorcentaje, 2); lTblRVC.Rows.Add(lFila);

                    Dtg_RVC.DataSource = lTblRVC;
                    Dtg_RVC.Columns["Concepto"].Width = 240;
                    Dtg_RVC.Columns["Valor"].Width = 60;
                    //Dtg_RPeso.Columns["Concepto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    Dtg_RVC.Columns["Valor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


                    if ((double.Parse(lPorcentaje.ToString()) > -1.5) && (double.Parse(lPorcentaje.ToString()) < 1.5))
                    {
                        lMsg = string.Concat("1. Despacho dentro del Rango", Environment.NewLine, "2. Grabar peso bascula ", Environment.NewLine, "3. Apretar Boton despacho final ");
                        Lbl_Msg.Text = lMsg; // " Despacho dentro del Rango,  e indicar 'Carga se encuentra dentro de los parámetros establecidos, emitir GDE' ";
                        Pnl_Msg.BackColor = Color.LightGreen;
                        Lbl_Msg.ForeColor = Color.Black;
                        lSeguir = false;
                    }
                    //else                    
                    if ((double.Parse(lPorcentaje.ToString()) > 1.5) && (lSeguir == true))
                    {
                        lMsg = string.Concat("1. Atención!! Se está enviando ", lTmp, " Kgs. de más", Environment.NewLine, "2. Revisar cuartones, pallet y alambre anotado ", Environment.NewLine, "3. Revisar si se cargó un paquete sin etiqueta o no se pistoleó alguna etiqueta ", Environment.NewLine, "4. Conversar con supervisor de producción");
                        Lbl_Msg.Text = lMsg; // "No permitir la emisión de la GDE, e indicar 'Revisar si lleva cuartones no indicados en el programa, alambre u otro, de no ser así, revisar carga'. ";
                        Pnl_Msg.BackColor = Color.LightSalmon;
                        Lbl_Msg.ForeColor = Color.Black;
                        lSeguir = false;
                    }
                    //else                    
                    if ((double.Parse(lPorcentaje.ToString()) < 1.5) && (lSeguir == true) && (lSeguir == true))
                    {
                        lMsg = string.Concat("1. Atención!! Se está enviando ", Math.Abs(lTmp), " Kgs. de menos", Environment.NewLine, "2. Revisar cuartones, pallet y alambre anotado ", Environment.NewLine, "3. Revisar si se pistoleó alguna etiqueta y no se cargó el paquete ", Environment.NewLine, "4. Conversar con supervisor de producción");
                        Lbl_Msg.Text = lMsg; //"No permitir la emisión de la GDE, e indicar 'Revisar si el camión está bien ubicado en la balanza, de lo contrario, revisar carga'";
                        Pnl_Msg.BackColor = Color.LightYellow;
                        Lbl_Msg.ForeColor = Color.Black;
                        lSeguir = false;
                    }
                }
            cargaGrilla_RFC();
            cargaGrilla_RPB();
            Lbl_Msg.Visible = true ;
        }


        private void CargaGrillaTiempos()
        {
            DataTable lTbl = new DataTable(); DataRow lFila = null; string lSql = ""; DataSet lDts = new DataSet(); Ws_TO.Ws_ToSoapClient  lPx = new Ws_TO.Ws_ToSoapClient();
            int lTiempoTotal = 0;double lPorcentaje = 0;
            lTbl.Columns.Add("Concepto");
            lTbl.Columns.Add("Tiempo_(mm)");
            lTbl.Columns.Add("Tiempo_(%)");

            lSql = " select FechaTara ,  (Select  min(pie_fecha_produccion) from  pieza_produccion  where PIE_DESPACHO_CAMION =iddespachoCam ) Pistoleo_1,  ";
            lSql = string.Concat(lSql, "  datediff(minute,fechaTara,(Select  min(pie_fecha_produccion) from  pieza_produccion  where PIE_DESPACHO_CAMION =iddespachoCam )) Espera_en_Foso_de_Carga, ");
            lSql = string.Concat(lSql, "  (Select  Max(pie_fecha_produccion) from  pieza_produccion  where PIE_DESPACHO_CAMION =iddespachoCam ) Pistoleo_2, FechaPesoBruto , ");
            lSql = string.Concat(lSql, "  datediff(minute,(Select  min(pie_fecha_produccion) from  pieza_produccion  where PIE_DESPACHO_CAMION =iddespachoCam ),(Select  Max(pie_fecha_produccion) from  pieza_produccion  where PIE_DESPACHO_CAMION =iddespachoCam )) Carga_Material,");
            lSql = string.Concat(lSql, "  datediff(minute,(Select  max(pie_fecha_produccion) from  pieza_produccion  where PIE_DESPACHO_CAMION =iddespachoCam ),FechaPesoBruto ) Salida_del_foso_a_la_bascula ");
            lSql = string.Concat(lSql, " from PesajeCamion where patente='AAAA11'  and  id=2346  ");
            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                lTiempoTotal = Convert.ToInt16(lDts.Tables[0].Rows[0]["Espera_en_Foso_de_Carga"].ToString()) + Convert.ToInt16(lDts.Tables[0].Rows[0]["Carga_Material"].ToString()) + Convert.ToInt16(lDts.Tables[0].Rows[0]["Salida_del_foso_a_la_bascula"].ToString());
                lFila = lTbl.NewRow();
                lFila["Concepto"] = "Espera en foso de carga";
                lFila["Tiempo_(mm)"] = lDts .Tables [0].Rows[0]["Espera_en_Foso_de_Carga"].ToString () ;
                lPorcentaje = (Convert.ToInt16(lFila["Tiempo_(mm)"].ToString()) / lTiempoTotal) *100 ;
                lFila["Tiempo_(%)"] = lPorcentaje.ToString ();
                lTbl.Rows.Add(lFila);

                lFila = lTbl.NewRow();
                lFila["Concepto"] = "Carga de material";
                lFila["Tiempo_(mm)"] = lDts.Tables[0].Rows[0]["Carga_Material"].ToString();
                lPorcentaje = (Convert.ToInt16(lFila["Carga_Material"].ToString()) / lTiempoTotal) * 100;
                lFila["Tiempo_(%)"] = lPorcentaje.ToString();
                lTbl.Rows.Add(lFila);

                lFila = lTbl.NewRow();
                lFila["Concepto"] = "Salida del foso a la bascula";
                lFila["Tiempo_(mm)"] = lDts.Tables[0].Rows[0]["Salida_del_foso_a_la_bascula"].ToString();
                lPorcentaje = (Convert.ToInt16(lFila["Salida_del_foso_a_la_bascula"].ToString()) / lTiempoTotal) * 100;
                lFila["Tiempo_(%)"] = lPorcentaje.ToString();
                lTbl.Rows.Add(lFila);

                lFila = lTbl.NewRow();
                lFila["Concepto"] = "Emision GDE";
                lFila["Tiempo_(mm)"] = "";
                lFila["Tiempo_(%)"] = "0";
                lTbl.Rows.Add(lFila);


            }
            



        }

        #endregion

        private void Cmb_PatenteCamion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((Cmb_PatenteCamion.SelectedValue != null) && (Cmb_PatenteCamion.SelectedValue.ToString() != "Seleccionar"))
            {
                Clases.SqlBascula lTipoSql = new Clases.SqlBascula(); string lSql = "";
                Clases.ClsComun lDAL = new Clases.ClsComun(); DataTable lTbl = new DataTable();
                DateTime lNewFecha = DateTime.Now.AddDays(-7);
                string lFecha = lNewFecha.ToShortDateString();    //DateTime.Now.ToShortDateString();
                //if (mBuscaDatosPatente == true)
                //{
                //    //CargaDatosPesoTaraPorPatente(Cmb_Patente.SelectedValue.ToString());
                //}

                //lFecha = "08/12/2023";
                lSql = lTipoSql.ObtenerSqlTara(Cmb_PatenteCamion.SelectedValue.ToString (), lFecha);
                Tx_sql.Text = lSql;
                lTbl = lDAL.CargaTablaRomana(lSql);

                if (lTbl.Rows.Count > 0)
                {
                    Tx_taraCamion.Text = lTbl.Rows[0]["PesoBruto"].ToString();
                    // Tx_IdCorrTara.Text = lTbl.Rows[0]["Correlativo"].ToString();
                    mIdCorrelativo = lTbl.Rows[0]["Correlativo"].ToString();
                    CargaDatosPesoTaraPorPatente_PreDespacho(Cmb_PatenteCamion.SelectedValue.ToString());
                    //CargaGrillaTiempos();
                    Gtd_ResumenCarga.DataSource = null;
                    Btn_VerDetalle_Click(null, null);
                }
                else // buscamos los registros de los pesajes que aun no han sido finalizados para una patente
                {
                    lSql =lTipoSql.ObtenerSqlPesoBruto(Cmb_PatenteCamion.SelectedValue.ToString(), lFecha);
                    lTbl = lDAL.CargaTablaRomana(lSql);
                    Gtd_ResumenCarga.DataSource = null;
                    if (lTbl.Rows.Count > 0)
                    {
                        Tx_taraCamion.Text = lTbl.Rows[0]["PesoBruto"].ToString();
                        // Tx_IdCorrTara.Text = lTbl.Rows[0]["Correlativo"].ToString();
                        mIdCorrelativo = lTbl.Rows[0]["Correlativo"].ToString();
                        CargaDatosPesoTaraPorPatente_PreDespacho(Cmb_PatenteCamion.SelectedValue.ToString());
                        //CargaGrillaTiempos();
                        
                        Btn_VerDetalle_Click(null, null);
                    }
                }

                Btn_GrabarDespacho.Enabled = false;
                button2.Enabled = false;
            }

        }

        private void Tx_PesoBrutoCamion_Validated(object sender, EventArgs e)
        {
            CalcularDatos();
        }

        private void Tx_alambre_Validated(object sender, EventArgs e)
        {
            CalcularDatos();
        }

        private void Tx_NroPallet_Validated(object sender, EventArgs e)
        {
            string lIdElemento = "";Clases.ClsComun lCom = new Clases.ClsComun();
            DataView lVista = new DataView(mAdicionalesCamion, string.Concat("Par1='Pallet'"), "", DataViewRowState.CurrentRows);
            if (lVista.Count > 0)
            {
                lIdElemento = lVista[0]["Id"].ToString();

                lVista = new DataView(mAdicionalesCamion, string.Concat("Id=", lIdElemento), "", DataViewRowState.CurrentRows);
                if (lVista.Count > 0)
                {
                    Tx_KilosPallet.Text =( lCom.Val ( lVista[0]["Par2"].ToString())* lCom.Val (Tx_NroPallet.Text )).ToString ()   ;
                }
            }

           

            CalcularDatos();
        }

        private void Tx_NumeroCuartones_Validated(object sender, EventArgs e)
        {
            string lIdElemento = ""; Clases.ClsComun lCom = new Clases.ClsComun();
            DataView lVista = new DataView(mAdicionalesCamion, string.Concat("Par1='Cuartón'"), "", DataViewRowState.CurrentRows);
            if (lVista.Count > 0)
            {
                lIdElemento = lVista[0]["Id"].ToString();

                lVista = new DataView(mAdicionalesCamion, string.Concat("Id=", lIdElemento), "", DataViewRowState.CurrentRows);
                if (lVista.Count > 0)
                {
                    Tx_KilosCuartones.Text = (lCom.Val(lVista[0]["Par2"].ToString()) * lCom.Val(Tx_NumeroCuartones.Text)).ToString();
                }
            }
            CalcularDatos();
        }


        private void cargaGrilla_RFC()
        {
            DataRow lFila = null; Clases.ClsComun lCom = new Clases.ClsComun(); int lAux = 0;
            decimal lKgsNorma353 = 0; decimal lKgsDesarrollo = 0; DataTable lTblRFC = new DataTable();decimal lTotalKgs = 0;
            WsOperacion.ListaDataSet lLIstaDts = new WsOperacion.ListaDataSet(); DataTable lTbl = new DataTable();
             int i = 0;
           
            try
            {
                lTbl = mTblDetalleDespacho.Copy(); //  lLIstaDts.DataSet.Tables[0].Copy();
                for (i = 0; i < lTbl.Rows.Count; i++)
                    {
                    lKgsNorma353 = lKgsNorma353 + decimal.Parse(lTbl.Rows[i]["Kg Norma 353"].ToString());
                    lKgsDesarrollo = lKgsDesarrollo + (decimal.Parse(lTbl.Rows[i]["KgsDesarrollo"].ToString()) );
                    lTotalKgs = lTotalKgs + (decimal.Parse (lTbl.Rows[i]["Kgs Reales"].ToString())) ;
                }
                lKgsDesarrollo = Math.Round(lKgsDesarrollo, 0);
                lKgsNorma353 = Math.Round(lKgsNorma353, 0);
                lTotalKgs = Math.Round(lTotalKgs, 0);
                //************** Llenamos  la grilla de Resumen Fierro a Cobrar
                lTblRFC.Columns.Add ("Concepto");
                lTblRFC.Columns.Add ("Valor");
                lFila = lTblRFC.NewRow();
                lFila["Concepto"] = "Peso fierro real utilizado (kg)"; lFila["Valor"] = lTotalKgs; lTblRFC.Rows.Add(lFila);
                lFila = lTblRFC.NewRow();
                lFila["Concepto"] = "Peso fierro generado por desarrollo (kg)"; lFila["Valor"] = lKgsDesarrollo; lTblRFC.Rows.Add(lFila);
                lFila = lTblRFC.NewRow();
                lFila["Concepto"] = "Peso fierro por norma 353 (1%) (kg)"; lFila["Valor"] = lKgsNorma353; lTblRFC.Rows.Add(lFila);

                //lAux = lCom.Val(lTblRFC.Rows[0]["Valor"].ToString()) - lCom.Val(lTblRFC.Rows[1]["Valor"].ToString()) + lCom.Val(lTblRFC.Rows[2]["Valor"].ToString());
                lAux = int.Parse (lTotalKgs.ToString ()) + int.Parse(lKgsDesarrollo.ToString ())  + int.Parse(lKgsNorma353.ToString ());
                lFila = lTblRFC.NewRow();
                lFila["Concepto"] = "Peso fierro en GD (kg)"; lFila["Valor"] = lAux; lTblRFC.Rows.Add(lFila); // Tx_KgsCargados.Text ; 

                Dtg_RFC_.DataSource = lTblRFC;
                Dtg_RFC_.Columns["Concepto"].Width = 240;
                Dtg_RFC_.Columns["Valor"].Width = 60;
                //Dtg_RPeso.Columns["Concepto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                Dtg_RFC_.Columns["Valor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            catch (Exception iex)
            {
                MessageBox.Show(string.Concat("Ha ocurrido el siguiente error: ", iex.Message.ToString()), "Avisos Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private void cargaGrilla_RPB()
        {
            DataRow lFila = null; Clases.ClsComun lCom = new Clases.ClsComun(); int lAux = 0;
            decimal lKgsNorma353 = 0; decimal lKgsDesarrollo = 0; DataTable RPB = new DataTable(); decimal lTotalKgs = 0;
            WsOperacion.ListaDataSet lLIstaDts = new WsOperacion.ListaDataSet(); DataTable lTbl = new DataTable();
 
            try
            {
                //************** Llenamos  la grilla de  Resumen peso báscula
                if (Tx_KilosCuartones.Text.Trim().Length == 0)
                    Tx_KilosCuartones.Text = "0";

                if (Tx_KilosPallet.Text.Trim().Length == 0)
                    Tx_KilosPallet.Text = "0";

                if (Tx_alambre.Text.Trim().Length == 0)
                    Tx_alambre.Text = "0";


                RPB.Columns.Add("Concepto");
                RPB.Columns.Add("Valor");
                lFila = RPB.NewRow();
                //lTotalKgs=
                    lTotalKgs = Convert.ToDecimal ( this.Dtg_RVC.Rows[1].Cells["Valor"].Value.ToString());
                lFila["Concepto"] = "Peso bruto camión (kg)"; lFila["Valor"] = Tx_PesoBrutoCamion.Text ; RPB.Rows.Add(lFila);
                lFila = RPB.NewRow();
                lFila["Concepto"] = "Tara camión (kg)"; lFila["Valor"] = Tx_taraCamion.Text  ; RPB.Rows.Add(lFila);
                lFila = RPB.NewRow();
                lFila["Concepto"] = "Peso de cuartones (kg)"; lFila["Valor"] = Tx_KilosCuartones.Text ; RPB.Rows.Add(lFila);
                lFila = RPB.NewRow();
                lFila["Concepto"] = "Peso de pallets (kg)"; lFila["Valor"] = Tx_KilosPallet.Text; RPB.Rows.Add(lFila);
                lFila = RPB.NewRow();
                lFila["Concepto"] = "Peso de alambre (kg)"; lFila["Valor"] = Tx_alambre.Text; RPB.Rows.Add(lFila);
                
                lAux = Convert.ToInt32(Tx_KilosCuartones.Text) + Convert.ToInt32(Tx_KilosPallet.Text) + Convert.ToInt32(Tx_alambre.Text)+ Convert.ToInt32(Tx_taraCamion.Text);

                lTotalKgs = Convert.ToDecimal(Tx_PesoBrutoCamion.Text);
                lFila = RPB.NewRow();
                lFila["Concepto"] = "Peso neto báscula (kg)"; lFila["Valor"] = lTotalKgs-lAux; RPB.Rows.Add(lFila);

                //lAux = lCom.Val(lTblRFC.Rows[0]["Valor"].ToString()) - lCom.Val(lTblRFC.Rows[1]["Valor"].ToString()) + lCom.Val(lTblRFC.Rows[2]["Valor"].ToString());
                //lAux = int.Parse(lTotalKgs.ToString()) + int.Parse(lKgsDesarrollo.ToString()) + int.Parse(lKgsNorma353.ToString());
                //lFila = RPB.NewRow();
                //lFila["Concepto"] = "Peso fierro en GD (kg)"; lFila["Valor"] = lAux; RPB.Rows.Add(lFila); // Tx_KgsCargados.Text ; 

                Dtg_RPB.DataSource = RPB;
                Dtg_RPB.Columns["Concepto"].Width = 240;
                Dtg_RPB.Columns["Valor"].Width = 60;
                //Dtg_RPeso.Columns["Concepto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                Dtg_RPB.Columns["Valor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            catch (Exception iex)
            {
                MessageBox.Show(string.Concat("Ha ocurrido el siguiente error: ", iex.Message.ToString()), "Avisos Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private void Btn_VerDetalle_Click(object sender, EventArgs e)
        {

            WsOperacion.OperacionSoapClient lPxOper = new WsOperacion.OperacionSoapClient(); decimal  lTotalKgsPaquete = 0; decimal lTotalKgsReales = 0;
            decimal lTotalKgsNorma353 = 0; decimal lTotalKgsTeorico = 0; decimal lTotalKgsDesarrollo = 0; DataRow lFila = null;
            WsOperacion.ListaDataSet lLIstaDts = new WsOperacion.ListaDataSet(); DataTable lTbl = new DataTable();
            DataTable lTblViajes = new DataTable(); Clases.ClsComun lCom = new Clases.ClsComun(); int i = 0;
         //   lLIstaDts = lPxOper.ObtenerDetallePesaje(mIdPesajeCamion.ToString ());
            try
            {
                // if (lLIstaDts.DataSet.Tables.Count > 0)
                //   {
                Gtd_ResumenCarga.DataSource = null;
               lTbl = mTblDetalleDespacho.Copy(); //  lLIstaDts.DataSet.Tables[0].Copy();

                if (lTbl.Columns.Contains("KgsTeorico")==false)
                      lTbl.Columns.Add("KgsTeorico");

                if (lTbl.Columns.Contains("KgsDesarrollo") == false)
                      lTbl.Columns.Add("KgsDesarrollo");

                //lTbl.Columns.Add("KgsDesarrollo");
                for (i = 0; i < lTbl.Rows.Count; i++)
                {
                    //lKgsNorma353 = lKgsNorma353 + decimal.Parse(lTbl.Rows[i]["KgsNorma353"].ToString());
                    //lKgsDesarrollo = lKgsDesarrollo + (decimal.Parse(lTbl.Rows[i]["KgsPaquete"].ToString()) - decimal.Parse(lTbl.Rows[i]["KgsReales"].ToString()));

                    lTbl.Rows[i]["KgsTeorico"] = double.Parse(lTbl.Rows[i][6].ToString()) - double.Parse(lTbl.Rows[i][5].ToString());
                    lTbl.Rows[i]["Kgs Desarrollo"] =  Math.Round (double.Parse(lTbl.Rows[i]["KgsTeorico"].ToString()) - double.Parse(lTbl.Rows[i]["Kgs Reales"].ToString()),1);

                    lTotalKgsPaquete = lTotalKgsPaquete + decimal .Parse(lTbl.Rows[i][6].ToString());
                    lTotalKgsReales = lTotalKgsReales + decimal.Parse(lTbl.Rows[i][3].ToString());
                    lTotalKgsNorma353 = lTotalKgsNorma353 + decimal.Parse(lTbl.Rows[i][5].ToString());
                    lTotalKgsTeorico = lTotalKgsTeorico + decimal.Parse(lTbl.Rows[i]["KgsTeorico"].ToString());
                    lTotalKgsDesarrollo = lTotalKgsDesarrollo + decimal.Parse(lTbl.Rows[i]["KgsDesarrollo"].ToString());

                    //decimal lTotalKgsPaquete = 0; decimal lTotalKgsReales = 0;
                    //decimal lTotalKgsNorma353 = 0; decimal lTotalKgsTeorico = 0; decimal lTotalKgsDesarrollo = 0;

                }

                lFila = lTbl.NewRow();
                lFila["Etiqueta"] = "TOTALES";
                lFila[6] = lTotalKgsPaquete;
                lFila[3] = lTotalKgsReales;
                lFila[5] = lTotalKgsNorma353;
                lFila["KgsTeorico"] = lTotalKgsTeorico;
                lFila["KgsDesarrollo"] = lTotalKgsDesarrollo;
     

                lTbl.Rows.Add(lFila);

                Gtd_ResumenCarga.DataSource = lTbl;
                Gtd_ResumenCarga.Columns["viaje"].Width = 60;
                Gtd_ResumenCarga.Columns[6].Width = 70;
                Gtd_ResumenCarga.Columns[3].Width = 65;
                Gtd_ResumenCarga.Columns[5].Width = 70;
                Gtd_ResumenCarga.Columns["KgsDesarrollo"].Width = 70;
                Gtd_ResumenCarga.Columns["KgsTeorico"].Width = 65;
                Gtd_ResumenCarga.Columns[7].Visible = false;

                Gtd_ResumenCarga.Columns["EsVaPero_NoVa"].Visible = false;
                Gtd_ResumenCarga.Columns["Id"].Visible = false;
                Gtd_ResumenCarga.Columns["Kgs Reales"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                Gtd_ResumenCarga.Columns["KgsDesarrollo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                Gtd_ResumenCarga.Columns["Kg Norma 353"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                Gtd_ResumenCarga.Columns["KgsTeorico"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                Gtd_ResumenCarga.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                Gtd_ResumenCarga.Columns["Despachador"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ;


            }
            catch (Exception iex)
            {

            }

        }

        private void Btn_DespachoFinal_Click(object sender, EventArgs e)
        {
            // con los datos de la patente, tienbe que ir a buscar los datos reales de la bascula y el campo peso bruto debe quedar en gris
            // Limpiar datos de Alambre, pallet y cuartones

             Clases.SqlBascula lTipoSql = new Clases.SqlBascula(); string lSql = ""; string lRes = "";
            Clases.ClsComun lDAL = new Clases.ClsComun(); DataTable lTbl = new DataTable();
            string lFecha = DateTime.Now.ToShortDateString();
        
            lSql = lTipoSql.ObtenerSqlPesoBrutoPorFecha (Cmb_PatenteCamion.SelectedValue.ToString(), lFecha);
            Tx_sql.Text = lSql;
            lTbl = lDAL.CargaTablaRomana(lSql);

            if (lTbl.Rows.Count > 0)
            {
                if ((Convert.ToInt64(lTbl.Rows[0]["PesoBruto"].ToString()) > 0) && (Convert.ToInt64(lTbl.Rows[0]["PesoTara"].ToString()) == 0))
                {
                    lRes = string.Concat(" Grabar Peso Final en programa Báscula ", Environment.NewLine, "  Una vez grabado  volver a presionar Despacho Final   ");
                    Btn_GrabarDespacho.Enabled = false;
                    MessageBox.Show(lRes, "Aviso sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                else
                {
                    DataSet lDts = new DataSet(); Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient();
                    lSql = string.Concat (" select * from  DESPACHO_CAMION  where  DES_CAM_CAMION ='", Cmb_PatenteCamion.SelectedValue.ToString(),"'  and  DES_ESTADO ='EnCarga' ");
                    lDts = lPx.ObtenerDatos(lSql);
                    if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                    {
                        lRes = string.Concat(" Debe  finalizar el proceso de despacho camión en tótem de despacho ", Environment.NewLine, "  Una vez grabado  volver a presionar Despacho Final   ");
                        Btn_GrabarDespacho.Enabled = false;
                        MessageBox.Show(lRes, "Aviso sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    { 
                    Tx_PesoBrutoCamion.Text = lTbl.Rows[0]["PesoBruto"].ToString();
                    Tx_PesoBrutoCamion.Enabled = false;
                    Tx_PesoNetoCamion.Text = "";

                    Tx_alambre.Text = "";
                    Tx_NroPallet.Text = "";
                    Tx_KilosPallet.Text = "";
                    Tx_NumeroCuartones.Text = "";
                    Tx_KilosCuartones.Text = "";
                    CalcularDatos();
                    Btn_GrabarDespacho.Enabled = true;
                        Btn_DespachoFinal.Enabled = false;
                        // Tx_IdCorrTara.Text = lTbl.Rows[0]["Correlativo"].ToString();
                        //mIdCorrelativo = lTbl.Rows[0]["Correlativo"].ToString();
                        //CargaDatosPesoTaraPorPatente_PreDespacho(Cmb_PatenteCamion.SelectedValue.ToString());
                    }

                }
            }

    

        }

        private void Tx_NumeroCuartones_TextChanged(object sender, EventArgs e)
        {

        }

        private void Btn_GrabarDespacho_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (RevisaDatosAntesGrabacion_V_2() == true)
            {
                //if (GrabarDatos_V2() == true)
                //{www.elmundo.es

                Btn_GrabarDespacho.Enabled = false;
                button2.Enabled = true;
                //}
            }
            Cursor.Current = Cursors.Default; 
            //Frm_AutorizaDespacho 
        }

        private void Btn_Correo_Click(object sender, EventArgs e)
        {
            DataTable lTbl = new DataTable(); DataSet lDts = new DataSet();  string lTxMsg = "";
            lTbl = (DataTable)Dtg_RFC_.DataSource;
            lTbl.TableName = "RFC";
             lDts. Tables.Add(lTbl.Copy());
            lTbl = new DataTable();
            lTbl = (DataTable)Dtg_RVC.DataSource;
            lTbl.TableName = "RVC";
            lDts.Tables.Add(lTbl.Copy());

            lTbl = (DataTable) Dtg_RPB .DataSource;
            lTbl.TableName = "RPB";
            lDts.Tables.Add(lTbl.Copy());

            lTxMsg = EnviaCorreoNotificacion_DespachoConBascula(lDts.Copy(), mIdPesajeCamion.ToString());
        }

        private void Cmb_PatenteTara_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cmb_PatenteTara.SelectedValue != null)
            {

                ObtenerTaraDesdeAccess();
            }
        }

        private void Btn_GrabarTaraV2_Click(object sender, EventArgs e)
        {
            GrabarTara_V2();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            IntegrarConINET();
        }
    }
}
