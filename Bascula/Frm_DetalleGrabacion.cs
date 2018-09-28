using CommonLibrary2;
using Metalurgica.Informes;
using Metalurgica.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Metalurgica.Bascula
{
    public partial class Frm_DetalleGrabacion : Form
    {
        string mGrabar = "";
        string mMail = "";
        string mImprimir = "";
        string mINET = "";
        string mResultado = "";
        int  mKgsGuiaINET = 0;
        private string mEmpresa = "";
        private int mIdObra = 0;
        WsOperacion.PesajeCamion mObjCam = new WsOperacion.PesajeCamion();



        public Frm_DetalleGrabacion()
        {
            InitializeComponent();
        }

        public void IniciaForm(WsOperacion.PesajeCamion iObjCam, string iResultado, int  iKgsGuiaINET,int iIdObra)
        {
            mObjCam = iObjCam;
            mResultado = iResultado;
            mKgsGuiaINET = iKgsGuiaINET;
            mIdObra = iIdObra;

        }

        private string EnviaCorreoNotificacion(DataSet lDts,string iResultado)
        {
            string lTx = ""; string lRes = ""; DataTable lTbl = new DataTable(); DataTable lTblDespacho = new DataTable();
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient(); string lTx_Caso = "";
            string lPatente = "";   string lPesoGuia = ""; string lKgsNeto = ""; string lKgsDesarrollo = "";
            string lDesviacion = ""; string lJefeTurno = "Sin Datos "; string lResultadoPesaje = ""; string lObra = " Sin Datos ";
            string lPorDesviacion = ""; double lPGD = 0; double lPbascula = 0; double lPD = 0;
            int lPs = 0; string lDesviacionDesa = ""; string lPorDesviacionDesa = "";

            lResultadoPesaje = iResultado;


            switch (lResultadoPesaje.ToUpper())
            {
                case "+":   //Se despacha mas 
                    lTx_Caso = " Para la Obra xxx  se ha generado un <b> despacho con sobre peso </b> con los siguientes resultados";
                    break;
                case "-":      // Se despacha menos
                    lTx_Caso = " Para la Obra xxx  se ha generado un <b>  despacho con Ausencia de Material  </b> con los siguientes resultados";
                    break;
                default:
                    lTx_Caso = " Para la Obra xxx  se ha realizado un <b> despacho conforme </b> con los siguientes resultados";
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
                lTbl = lDts.Tables[0].Copy();
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

                if ((lDts.Tables.Count == 2) && (lDts.Tables[1].Rows.Count > 0))
                {
                    lTblDespacho = lDts.Tables[1].Copy();
                    lJefeTurno = lTblDespacho.Rows[0]["UsuarioDespacha"].ToString();
                    lObra = lTblDespacho.Rows[0]["Nombre"].ToString();
                }
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

        private DtsInformes CargaDatosDetalle_ViajeSaldo(string iViaje)
        {
            string iIdIt = ""; string iIdObra = "";
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient(); int i = 0;
            Frm_Visualizador lFrmInf = new Frm_Visualizador();
            DtsInformes lDts = new DtsInformes(); DataSet lDtsTmp = new DataSet();

            string lSql = string.Concat("select IdIt, IdObra  from viaje v, it where v.IdIt =it.id and Codigo ='", iViaje, "' ");
            lDtsTmp = lPx.ObtenerDatos(lSql);
            if ((lDtsTmp.Tables.Count > 0) && (lDtsTmp.Tables[0].Rows.Count > 0))
            {
                iIdIt = lDtsTmp.Tables[0].Rows[0]["IdIT"].ToString();
                iIdObra = lDtsTmp.Tables[0].Rows[0]["IdObra"].ToString();

                lDts.EnforceConstraints = false;

            }
            lDts.Merge(lPx.ObtenerDtsPL_ConDet_SaldosViaje("", iIdIt, iViaje, "I", iIdObra, "DESP"));

            return lDts;
        }

        private string OBtenerValorKilo(string iIdObra)
        {
            string lSql = ""; Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient(); DataTable lTblRes = new DataTable(); string lValorKilo = "";
            //Dim lSql As String = "", lPx As New Px_Ws.Ws_ToSoapClient, lTblRes As New DataTable, lValorKilo As String = "0"
            DataSet lDts = new DataSet();
            lSql = string.Concat("Exec SP_CRUD_SERVICIOS_OBRA  0,", iIdObra, ",'',0,0,'','',3");
            //'       @Id int,             '   @IdObra int,	            '@Servicio VARCHAR(50),
            //'   @Importe int,	         '@IdUsuario int,              '@NombreUsuario VARCHAR(50),
            //'@OPCION INT
            lDts = lPx.ObtenerDatos(lSql);
            if (lDts.Tables.Count > 0)
            {
                lValorKilo = lDts.Tables[0].Rows[0][0].ToString();
            }

            return lValorKilo;

        }

        private DataTable ObtenerDatosViajeDespachado_Saldos(String iViaje)
        {
            String lSql = ""; Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient();
            DataSet lDts = new DataSet(); DataTable lRes = new DataTable();
            //'ALTER  PROCEDURE [dbo].[SP_ConsultasGenerales]
            //'@Opcion INT,        '@Par1 Varchar(100),        '@Par2 Varchar(100),
            //'@Par3 Varchar(100),        '@Par4 Varchar(100),  '@Par5 Varchar(100)
            try
            {
                lSql = string.Concat("exec SP_Consultas_WS 24,'", iViaje, "','','','','','',''");
                lDts = lPx.ObtenerDatos(lSql);
                if (lDts.Tables.Count > 0)
                    lRes = lDts.Tables[0].Copy();

            }
            catch (Exception exc)
            { }

            return lRes;
        }

        private string ObtenerObsITAprobada(string iViaje)
        {
            string lSql = ""; Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient();
            DataSet lDts = new DataSet(); string lRes = "";


            try
            {
                lSql = string.Concat("exec SP_Consultas_WS 3,'", iViaje, "','','','','','',''");
                lDts = lPx.ObtenerDatos(lSql);
                if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                {
                    lRes = lDts.Tables[0].Rows[0][0].ToString();
                }
            }

            catch (Exception exc)
            {
                lRes = "Error al Obtener la Obs de la IT";
            }
            return lRes;
        }
        private DtsInformes CargaDatosPortada_ViajeOriginal(string iViaje)
        {
            string iIdIt = ""; string iIdObra = ""; int lValorKilo = 0;
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient(); int i = 0;
            Frm_Visualizador lFrmInf = new Frm_Visualizador(); Clases.ClsComun lCom = new Clases.ClsComun();
            DtsInformes lDts = new DtsInformes(); DataSet lDtsTmp = new DataSet();
            try
            {
                string lSql = string.Concat("select IdIt, IdObra  from viaje v, it where v.IdIt =it.id and Codigo ='", iViaje, "' ");
                lDtsTmp = lPx.ObtenerDatos(lSql);
                if ((lDtsTmp.Tables.Count > 0) && (lDtsTmp.Tables[0].Rows.Count > 0))
                {
                    iIdIt = lDtsTmp.Tables[0].Rows[0]["IdIT"].ToString();
                    iIdObra = lDtsTmp.Tables[0].Rows[0]["IdObra"].ToString();

                    lDts.EnforceConstraints = false;
                    //lDts.Merge(lPx.ObtenerDtsPL_ViajeDesp_ConSaldos("", iIdIt, iViaje, iIdObra));
                    lDts.Merge(lPx.ObtenerDtsPL_ViajeDesp("", iIdIt, iViaje, iIdObra));
                    //************************************************************************
                    DataSet lDtsTablas = new System.Data.DataSet(); DtsInformes.KilosPorDiametroRow lFila = null;
                    //Dim lDtsTablas As New DataSet, lFila As Dts_PL.KilosPorDiametroRow 
                    lDtsTablas = lPx.ObtenerDiametros_SaldosViaje(iViaje);

                    if (lDtsTablas.Tables.Count > 0)
                    {
                        for (i = 0; i < lDtsTablas.Tables[0].Rows.Count; i++)
                        {
                            lFila = lDts.KilosPorDiametro.NewKilosPorDiametroRow();
                            lFila["Diametro"] = lDtsTablas.Tables[0].Rows[i]["Diametro"].ToString();
                            lFila["Kilos"] = String.Concat(lCom.FormateaMiles(lDtsTablas.Tables[0].Rows[i]["Kilos"].ToString()), " Kilos");
                            lFila["KilosDesp"] = String.Concat(lCom.FormateaMiles(lDtsTablas.Tables[0].Rows[i]["KilosDesp"].ToString()), " Kilos");
                            lDts.KilosPorDiametro.Rows.Add(lFila);
                        }
                        lDts.ResumenDesp.Rows[0]["ObsIt"] = ObtenerObsITAprobada(iViaje);
                        DataTable lTblTmp = new DataTable(); string lTmp = "";
                        lTblTmp = ObtenerDatosViajeDespachado_Saldos(iViaje);
                        if (lTblTmp.Rows.Count > 0)
                        {
                            lTmp = lCom.FormateaMiles(lTblTmp.Rows[0]["KILOS"].ToString());// 0);// ",", "."
                            lDts.ResumenDesp.Rows[0]["PesoTotalDesp"] = lTmp;
                            lDts.ResumenDesp.Rows[0]["NroEtiquetasDesp"] = lTblTmp.Rows[0]["NroEtiquetas"].ToString();
                            //  lTmp = Replace(FormatNumber(Val(OBtenerValorKilo(IdObra)) * Val(lTblTmp.Rows(0)("KILOS").ToString), 0), ",", ".")
                            lValorKilo = lCom.Val(OBtenerValorKilo(iIdObra));
                            lTmp = (lValorKilo * lCom.Val(lTblTmp.Rows[0]["KILOS"].ToString())).ToString();

                            lDts.ResumenDesp.Rows[0]["ValorTotal_ITDesp"] = String.Concat("$ ", lCom.FormateaMiles(lTmp.ToString()));
                            //lDts.ResumenDesp.Rows[0]["ValorTotal_ITDesp"] = String.Concat("$ ", (lValorKilo * lCom.Val(lTblTmp.Rows[0]["KILOS"].ToString())).ToString());
                        }

                    }
                }
            }
            catch (Exception exc)
            {
                //MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lDts;
        }

        private DtsInformes CargaDatosDetalleViajeOriginal(string iViaje)
        {
            string iIdIt = ""; string iIdObra = "";
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient(); int i = 0;
            Frm_Visualizador lFrmInf = new Frm_Visualizador();
            DtsInformes lDts = new DtsInformes(); DataSet lDtsTmp = new DataSet();

            string lSql = string.Concat("select IdIt, IdObra  from viaje v, it where v.IdIt =it.id and Codigo ='", iViaje, "' ");
            lDtsTmp = lPx.ObtenerDatos(lSql);
            if ((lDtsTmp.Tables.Count > 0) && (lDtsTmp.Tables[0].Rows.Count > 0))
            {
                iIdIt = lDtsTmp.Tables[0].Rows[0]["IdIT"].ToString();
                iIdObra = lDtsTmp.Tables[0].Rows[0]["IdObra"].ToString();

                lDts.EnforceConstraints = false;

            }

            lDts.Merge(lPx.ObtenerDtsPL_ConDet("", iIdIt, iViaje, "I", iIdObra, "DESP"));

            return lDts;
        }

        private DtsInformes CargaDatosPortada_ViajeSaldo(string iViaje)
        {
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient(); int i = 0;
            ArrayList lIdsPiezas = new ArrayList(); string lRes = "";
            string lTmp = ""; DataSet lDtsTmp = new DataSet();
            DtsInformes dtsPl = new DtsInformes(); string iIdIt = ""; string iIdObra = "";

            string lSql = string.Concat("select IdIt, IdObra  from viaje v, it where v.IdIt =it.id and Codigo ='", iViaje, "' ");
            lDtsTmp = lPx.ObtenerDatos(lSql);
            if ((lDtsTmp.Tables.Count > 0) && (lDtsTmp.Tables[0].Rows.Count > 0))
            {
                iIdIt = lDtsTmp.Tables[0].Rows[0]["IdIT"].ToString();
                iIdObra = lDtsTmp.Tables[0].Rows[0]["IdObra"].ToString();

                dtsPl.EnforceConstraints = false;
                dtsPl.Merge(lPx.ObtenerDtsPL_ViajeDesp_ConSaldos("", iIdIt, iViaje, iIdObra));

                //'22/10/2012  ---- cargamos los datos del subreport   
                DataSet lDtsTablas = new DataSet(); DtsInformes.KilosPorDiametroRow lFila = null;
                //Dim lDtsTablas As New DataSet, lFila As Dts_PL.KilosPorDiametroRow // ', lFilaIT As Dts_PL.ResumenDespRow
                lDtsTablas = lPx.ObtenerDiametros_SaldosViaje(iViaje);
                if (lDtsTablas.Tables.Count > 0)
                {
                    for (i = 0; i < lDtsTablas.Tables[0].Rows.Count; i++)
                    {
                        lFila = dtsPl.KilosPorDiametro.NewKilosPorDiametroRow();
                        lFila["Diametro"] = lDtsTablas.Tables[0].Rows[i]["Diametro"].ToString();
                        lFila["Kilos"] = String.Concat(lDtsTablas.Tables[0].Rows[i]["Kilos"].ToString(), " Kilos");
                        lFila["KilosDesp"] = String.Concat(lDtsTablas.Tables[0].Rows[i]["KilosDesp"].ToString(), " Kilos");
                        dtsPl.KilosPorDiametro.Rows.Add(lFila);
                    }
                }

                if (dtsPl.ResumenDesp.Rows.Count > 0)
                {
                    dtsPl.ResumenDesp.Rows[0]["ObsIt"] = ObtenerObsITAprobada(iViaje);
                }
            }
            DataTable lTblTmp = new DataTable(); // string lStrTmp = "";
            Clases.ClsComun lUtil = new Clases.ClsComun();


            lTblTmp = ObtenerDatosViajeDespachado_Saldos(iViaje);
            if (lTblTmp.Rows.Count > 0)
            {

                dtsPl.ResumenDesp.Rows[0]["PesoTotalDesp"] = lTblTmp.Rows[0]["KILOS"].ToString();
                dtsPl.ResumenDesp.Rows[0]["NroEtiquetasDesp"] = lTblTmp.Rows[0]["NroEtiquetas"].ToString();
                dtsPl.ResumenDesp.Rows[0]["ValorTotal_ITDesp"] = lUtil.Val(OBtenerValorKilo(iIdObra)) * lUtil.Val(lTblTmp.Rows[0]["KILOS"].ToString());
            }

            return dtsPl;

        }

        private void LimpiaDirectorio_PDF()
        {
           string  iPathPdf = ConfigurationManager.AppSettings["PathPdf"].ToString();
          
            if (Directory.Exists(iPathPdf))
            {
                try
                {
                    foreach (var item in Directory.GetFiles(iPathPdf, "*.*"))
                    {
                        File.SetAttributes(item, FileAttributes.Normal);
                        File.Delete(item);
                    }
                }
                catch (Exception exc)
                {
                    throw exc;
                }
            }
            //----------------------------------
            //String tempFolder = @"C:\AdjuntosChat\";
            //if (Directory.Exists(tempFolder))
            //{
            //    foreach (var item in Directory.GetFiles(tempFolder, "*.*"))
            //    {
            //        File.SetAttributes(item, FileAttributes.Normal);
            //        File.Delete(item);
            //    }
            //}
            //---------------------------------

        }

        public void ImprimirInforme(string iPesajecamion, Boolean iEliminaArchivo)
        {
            DtsInformes lDtsPortada = new DtsInformes();string iViaje = "";
            DtsInformes lDtsDetalle = new DtsInformes(); Char Delimitador = '/'; Clases.ClsComun lComun = new Clases.ClsComun();
            Frm_Visualizador lFrmInf = null;
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient(); int i = 0;
            DataSet lDtsTmp = new DataSet();
            try
            {
               
                string lSql = string.Concat("   SP_Consultas_WS 131,'", iPesajecamion,"','','','','','','' ");
                lDtsTmp = lPx.ObtenerDatos(lSql);
                if ((lDtsTmp.Tables.Count > 0) && (lDtsTmp.Tables[0].Rows.Count > 0))
                {
                    for (i = 0; i < lDtsTmp.Tables[0].Rows.Count; i++)
                    {
                        lFrmInf = new Frm_Visualizador();
                        iViaje = lDtsTmp.Tables[0].Rows[i]["Codigo"].ToString();
                        String[] lPartes = iViaje.Split(Delimitador);
                        if (lPartes.Length > 0)
                        {
                            if (lComun.Val(lPartes[1]) == 1)
                            {
                                LimpiaDirectorio_PDF();
                                lDtsPortada = CargaDatosPortada_ViajeOriginal(iViaje);
                                lFrmInf.InicializaInforme("P", lDtsPortada, iViaje, iEliminaArchivo);
                                lFrmInf.GeneraPdf();
                                lDtsDetalle = CargaDatosDetalleViajeOriginal(iViaje);
                                lFrmInf.InicializaInforme("D", lDtsDetalle, iViaje, iEliminaArchivo);
                                lFrmInf.GeneraPdf();
                                lFrmInf.Close();
                                TerminaProceso();
                            }
                            else
                            {
                                //CargaDatosDetalle_ViajeSaldo
                                LimpiaDirectorio_PDF();
                                lDtsPortada = CargaDatosPortada_ViajeSaldo(iViaje);
                                lFrmInf.InicializaInforme("P", lDtsPortada, iViaje, iEliminaArchivo);
                                lFrmInf.GeneraPdf();
                                lDtsDetalle = CargaDatosDetalle_ViajeSaldo(iViaje);
                                lFrmInf.InicializaInforme("D", lDtsDetalle, iViaje, iEliminaArchivo);
                                lFrmInf.GeneraPdf();
                                lFrmInf.Close();
                                TerminaProceso();
                            }
                        }

                }
                    LimpiaDirectorio_PDF();
                    //TerminaProceso();
                }

            }
            catch (Exception exc)
            {
                //MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw exc;
            }

            //**************************************************************************
        }


        private void InicaProceso()
        {
            //Grabación
            WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
            WsOperacion.ListaDataSet lDts = new WsOperacion.ListaDataSet(); Clases.ClsComun lCom = new Clases.ClsComun();
          
            try
            {
                mObjCam = wsOperacion.GrabarDatosPesajeCamion(mObjCam);
                if (mObjCam.Id > 0)
                {
                //Grabacion OK
                    mGrabar = "OK";
                    //enviar Correo para informar.
                    lDts = wsOperacion.ObtenerDatosPesajeCamion(mObjCam.Id.ToString());
                    if (lDts.MensajeError.Trim().Length == 0)
                    {
                        mMail = EnviaCorreoNotificacion(lDts.DataSet.Copy(), mResultado);
                        Tx_Mail .Text = mMail;
                    }

                    //Impresión de Documentos.
                    ImprimirInforme(mObjCam.Id.ToString(), true);

                    // Integración INET
                    IntegraConINET();


                    MessageBox.Show("Los Datos han sido Grabados Correctamente ", "Avisos Sistema", MessageBoxButtons.OK);


                }

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Generacion e Impresion de PDF

        private void SendToPrinter(string iPath)
        {
            ProcessStartInfo info = new ProcessStartInfo();
            info.Verb = "print";                          // Seleccionar el programa para imprimir PDF por defecto
            info.FileName = iPath; //@"C:\Informes\TMP\1.pdf";         // Ruta hacia el fichero que quieres imprimir
            info.CreateNoWindow = true;                   // Hacerlo sin mostrar ventana
            info.WindowStyle = ProcessWindowStyle.Hidden; // Y de forma oculta
            Process p = new Process();
            p.StartInfo = info;
            p.Start();  // Lanza el proceso

            p.WaitForInputIdle();
            System.Threading.Thread.Sleep(3000);          // Espera 3 segundos
            if (false == p.CloseMainWindow())
                p.Kill();                                  // Y cierra el programa de imprimir PDF's
        }

        private void TerminaProceso()
        {
            string lPathArchivo = ConfigurationManager.AppSettings["PathPdf"].ToString(); //string.Concat("C:\\Informes\\TMP\\");
            Clases.ClsComun lCom = new Clases.ClsComun();
            string lres = ""; DataTable lTblImp = new DataTable();
            lres = lCom.UnirOdf(lPathArchivo);


            ProcessStartInfo info = new ProcessStartInfo();
            info.Verb = "print";                          // Seleccionar el programa para imprimir PDF por defecto
            info.FileName = lres; //@"C:\Informes\TMP\1.pdf";         // Ruta hacia el fichero que quieres imprimir
            info.CreateNoWindow = true;                   // Hacerlo sin mostrar ventana
            info.WindowStyle = ProcessWindowStyle.Hidden; // Y de forma oculta
            Process p = new Process();
            p.StartInfo = info;
            p.Start();  // Lanza el proceso

            p.WaitForInputIdle();
            System.Threading.Thread.Sleep(3000);          // Espera 3 segundos
            if (false == p.CloseMainWindow())
                p.Kill();                                  // Y cierra el programa de imprimir PDF's

        }

        #endregion


        #region Integracion INET

        private List<Tipo_GuiaOC> ObtenerGuiasPorOC(  )
        {
            List<Tipo_GuiaOC> lListas = new List<Tipo_GuiaOC>();DataTable lTblViajes = new DataTable();
            Tipo_GuiaOC lGuiaOC = new Tipo_GuiaOC(); string lsql = "";
            Ws_TO.Ws_ToSoapClient lDal = new Ws_TO.Ws_ToSoapClient(); DataSet lDts = new DataSet();
            List<Tipo_GuiaOC> lListaFinal = new List<Tipo_GuiaOC>(); int i = 0;

            lsql = string.Concat("  SP_Consultas_WS 131,'", mObjCam .Id,"','','','','','',''");
            lDts = lDal.ObtenerDatos(lsql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                lTblViajes = lDts.Tables[0].Copy();
            }

            for (i = 0; i < lTblViajes.Rows .Count; i++)
            {
                lsql = string.Concat("SP_Consultas_FacturacionPorCamion  5,'", lTblViajes.Rows [i]["Codigo"].ToString(), "',");
                lsql = string.Concat(lsql, "'','','','','',''");
                lDts = lDal.ObtenerDatos(lsql);
                if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                {
                    lGuiaOC = new Tipo_GuiaOC();
                    lGuiaOC.IdIt = lDts.Tables[0].Rows[0]["IDIT"].ToString();
                    lGuiaOC.OC = lDts.Tables[0].Rows[0]["OC"].ToString();
                    lGuiaOC.Viajes = lDts.Tables[0].Rows[0]["Codigo"].ToString();
                    lGuiaOC.CodigoGuiaINET = lDts.Tables[0].Rows[0]["TipoGuia_INET"].ToString();
                    if (lDts.Tables[0].Rows[0]["idDespachosCamion"].ToString().Trim().Length > 1)
                        lGuiaOC.DespachosCamion = lDts.Tables[0].Rows[0]["idDespachosCamion"].ToString();
                    //else
                    //    lGuiaOC.DespachosCamion = ObtenerIdDespachoCamion(lDts.Tables[0].Rows[0]["Codigo"].ToString());

                    lListas.Add(lGuiaOC);
                }
                   
            }
            //Revisamos las listas y solo dejamos las 
            string lOC_Tmp = ""; string lOC = ""; int j = 0;
            DataTable lTbl = new DataTable(); DataRow lFila = null; DataView lVista = null;

            lTbl = CreaCampo(lTbl);
            for (i = 0; i < lListas.Count; i++)
            {
                lOC_Tmp = lListas[i].OC.ToString();
                for (j = 0; j < lListas.Count; j++)
                {
                    if (lListas[j].OC.ToString().Trim().Length > 0)
                    {
                        if (lOC_Tmp.IndexOf(lListas[j].OC.ToString()) > -1)
                        {
                            lVista = new DataView(lTbl, string.Concat("OC='", lListas[j].OC.ToString(), "'"), "", DataViewRowState.CurrentRows);
                            if (lVista.Count == 0)
                            {
                                lFila = lTbl.NewRow();
                                lFila["IdIt"] = lListas[j].IdIt;
                                lFila["OC"] = lListas[j].OC;
                                lFila["Viajes"] = lListas[j].Viajes;
                                lFila["DespachoCamion"] = lListas[j].DespachosCamion;
                                lFila["TipoGuia_INET"] = lListas[j].CodigoGuiaINET;
                                lTbl.Rows.Add(lFila);
                                lListas[j].OC = "";
                            }
                            else
                            {
                                lVista[0]["IdIt"] = string.Concat(lVista[0]["IdIt"], ",", lListas[j].IdIt);
                                lVista[0]["Viajes"] = string.Concat(lVista[0]["Viajes"], ",", lListas[j].Viajes);
                                lVista[0]["DespachoCamion"] = string.Concat(lVista[0]["DespachoCamion"], ",", lListas[j].DespachosCamion);
                                lVista[0]["TipoGuia_INET"] = string.Concat(lVista[0]["TipoGuia_INET"], ",", lListas[j].CodigoGuiaINET);
                                lListas[j].OC = "";
                            }
                        }
                    }
                }
            }

            if (lTbl.Rows.Count > 0)
            {
                for (i = 0; i < lTbl.Rows.Count; i++)
                {
                    if (lTbl.Rows[i]["OC"].ToString() != "0")
                    {
                        Tipo_GuiaOC lGuiaOC_F = new Tipo_GuiaOC(); Tipo_GuiaOC lGuiaOC_FE = new Tipo_GuiaOC();
                        Tipo_GuiaOC lGuiaOC_R = new Tipo_GuiaOC();

                        string[] lPartesIdIT = (lTbl.Rows[i]["IdIT"].ToString().Split(new Char[] { ',' }));
                        string[] lPartesViaje = (lTbl.Rows[i]["Viajes"].ToString().Split(new Char[] { ',' }));
                        string[] lPartes_DC = (lTbl.Rows[i]["DespachoCamion"].ToString().Split(new Char[] { ',' }));
                        string[] lPartes = (lTbl.Rows[i]["TipoGuia_INET"].ToString().Split(new Char[] { ',' }));
                        for (j = 0; j < lPartes.Length; j++)
                        {
                            if (lPartes[j].ToUpper().Equals("F"))  // Facturacion
                            {
                                lGuiaOC_F.OC = lTbl.Rows[i]["OC"].ToString();
                                lGuiaOC_F.IdIt = string.Concat(lPartesIdIT[j].ToString(), ",", lGuiaOC_F.IdIt);
                                lGuiaOC_F.Viajes = string.Concat(lPartesViaje[j].ToString(), ",", lGuiaOC_F.Viajes);
                                lGuiaOC_F.DespachosCamion = string.Concat(lPartes_DC[j].ToString(), ",", lGuiaOC_F.DespachosCamion);
                                lGuiaOC_F.CodigoGuiaINET = string.Concat(lPartes[j].ToString(), ",", lGuiaOC_F.CodigoGuiaINET);
                            }

                            if (lPartes[j].ToUpper().Equals("FE"))  // Fierro en Punta
                            {
                                lGuiaOC_FE.OC = lTbl.Rows[i]["OC"].ToString();
                                lGuiaOC_FE.IdIt = string.Concat(lPartesIdIT[j].ToString(), ",", lGuiaOC_F.IdIt);
                                lGuiaOC_FE.Viajes = string.Concat(lPartesViaje[j].ToString(), ",", lGuiaOC_F.Viajes);
                                lGuiaOC_FE.DespachosCamion = string.Concat(lPartes_DC[j].ToString(), ",", lGuiaOC_F.DespachosCamion);
                                lGuiaOC_FE.CodigoGuiaINET = string.Concat(lPartes[j].ToString(), ",", lGuiaOC_F.CodigoGuiaINET);
                            }
                            //if (lPartes[j].ToUpper().Equals("R"))   //Reposición
                            //{
                            //    lGuiaOC_R.OC = lTbl.Rows[i]["OC"].ToString();
                            //    lGuiaOC_R.IdIt = string.Concat(lPartesIdIT[j].ToString(), ",", lGuiaOC_F.IdIt);
                            //    lGuiaOC_R.Viajes = string.Concat(lPartesViaje[j].ToString(), ",", lGuiaOC_F.Viajes);
                            //    lGuiaOC_R.DespachosCamion = string.Concat(lPartes_DC[j].ToString(), ",", lGuiaOC_F.DespachosCamion);
                            //    lGuiaOC_R.CodigoGuiaINET = string.Concat(lPartes[j].ToString(), ",", lGuiaOC_F.CodigoGuiaINET);
                            //}

                        }

                        if (lGuiaOC_F.OC.Trim().Length > 0)
                        {
                            lGuiaOC = new Tipo_GuiaOC();
                            lGuiaOC.IdIt = lGuiaOC_F.IdIt.ToString().Substring(0, lGuiaOC_F.IdIt.Length - 1);
                            lGuiaOC.OC = lGuiaOC_F.OC.ToString().Substring(0, lGuiaOC_F.OC.Length - 1);
                            lGuiaOC.Viajes = lGuiaOC_F.Viajes.ToString().Substring(0, lGuiaOC_F.Viajes.Length - 1);
                            lGuiaOC.DespachosCamion = lGuiaOC_F.DespachosCamion.ToString().Substring(0, lGuiaOC_F.DespachosCamion.Length - 1);
                            lGuiaOC.CodigoGuiaINET = lGuiaOC_F.CodigoGuiaINET.ToString().Substring(0, lGuiaOC_F.CodigoGuiaINET.Length - 1);
                            lListaFinal.Add(lGuiaOC);
                        }
                        if (lGuiaOC_FE.OC.Trim().Length > 0)
                        {
                            lGuiaOC = new Tipo_GuiaOC();
                            lGuiaOC.IdIt = lGuiaOC_FE.IdIt.ToString().Substring(0, lGuiaOC_FE.IdIt.Length - 1);
                            lGuiaOC.OC = lGuiaOC_FE.OC.ToString().Substring(0, lGuiaOC_FE.OC.Length - 1);
                            lGuiaOC.Viajes = lGuiaOC_FE.Viajes.ToString().Substring(0, lGuiaOC_FE.Viajes.Length - 1);
                            lGuiaOC.DespachosCamion = lGuiaOC_FE.DespachosCamion.ToString().Substring(0, lGuiaOC_FE.DespachosCamion.Length - 1);
                            lGuiaOC.CodigoGuiaINET = lGuiaOC_FE.CodigoGuiaINET.ToString().Substring(0, lGuiaOC_FE.CodigoGuiaINET.Length - 1);
                            lListaFinal.Add(lGuiaOC);
                        }
                        //if (lGuiaOC_R.OC.Trim().Length > 0)
                        //{
                        //    lGuiaOC = new Tipo_GuiaOC();
                        //    lGuiaOC.IdIt = lGuiaOC_R.IdIt.ToString().Substring(0, lGuiaOC_R.IdIt.Length - 1);
                        //    lGuiaOC.OC = lGuiaOC_R.OC.ToString().Substring(0, lGuiaOC_R.OC.Length - 1);
                        //    lGuiaOC.Viajes = lGuiaOC_R.Viajes.ToString().Substring(0, lGuiaOC_R.Viajes.Length - 1);
                        //    lGuiaOC.DespachosCamion = lGuiaOC_R.DespachosCamion.ToString().Substring(0, lGuiaOC_R.DespachosCamion.Length - 1);
                        //    lGuiaOC.CodigoGuiaINET = lGuiaOC_R.CodigoGuiaINET.ToString().Substring(0, lGuiaOC_R.CodigoGuiaINET.Length - 1);
                        //    lListaFinal.Add(lGuiaOC);
                        //}
                    }

                }
            }

            return lListaFinal;
        }

        private Integracion_INET.Tipo_InvocaWS InvocaWS_INET_Reposicion(string ipatente, string IdObra, string lDespachosCam, string lViajes)
        {
            Tipo_InvocaWS lResultado = new Tipo_InvocaWS();
            Tipo_DocVentaExt lImputObj = new Tipo_DocVentaExt();
            Integracion_INET.Cls_LN lIntegra = new Integracion_INET.Cls_LN();
            WsCrud.CrudSoapClient lDAl = new WsCrud.CrudSoapClient();
            WsCrud.ListaDataSet lDts = new WsCrud.ListaDataSet();
            string lSucursal = "";


            //mIdObra = int.Parse(IdObra);
            Registry registry = new Registry();
            lSucursal = (string)registry.GetValue(Program.regeditKeyName, "Sucursal", "");
            //string lEmpresa = ConfigurationManager.AppSettings["Empresa"].ToString();

            if (mEmpresa.ToUpper().Equals("TOSOL"))
                return lIntegra.InvocaWS_INET_TOSOL_Reposicion(ref Tx_INET, IdObra, lSucursal, lDespachosCam, lViajes);
            else
                return lIntegra.InvocaWS_INET_Reposicion(ref Tx_INET, IdObra, lSucursal, lDespachosCam, lViajes);


        }


        private DataTable CreaCampo(DataTable iTbl)
        {
            iTbl.Columns.Add("OC");
            iTbl.Columns.Add("IdIT");
            iTbl.Columns.Add("Viajes");
            iTbl.Columns.Add("DespachoCamion");
            iTbl.Columns.Add("TipoGuia_INET");

            return iTbl;
        }

        private List<Tipo_GuiaOC> ObtenerGuias_DeReposicion()
        {
            List<Tipo_GuiaOC> lListas = new List<Tipo_GuiaOC>(); DataTable lTblViajes = new DataTable();
            Tipo_GuiaOC lGuiaOC = new Tipo_GuiaOC(); string lsql = "";
            Ws_TO.Ws_ToSoapClient lDal = new Ws_TO.Ws_ToSoapClient(); DataSet lDts = new DataSet();
            List<Tipo_GuiaOC> lListaFinal = new List<Tipo_GuiaOC>(); int i = 0;


            //////////
            lsql = string.Concat("  SP_Consultas_WS 131,'", mObjCam.Id, "','','','','','',''");
            lDts = lDal.ObtenerDatos(lsql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                lTblViajes = lDts.Tables[0].Copy();
            }

            for (i = 0; i < lTblViajes.Rows.Count; i++)
                //////////
                //foreach (DataGridViewRow lRow in this.Dtg_Camiones.Rows)
            {
                lsql = string.Concat("SP_Consultas_FacturacionPorCamion  5,'", lTblViajes.Rows[i] ["Codigo"]. ToString(), "',");
                lsql = string.Concat(lsql, "'','','','','',''");
                lDts = lDal.ObtenerDatos(lsql);
                if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                {
                    if (lDts.Tables[0].Rows[0]["OC"].ToString().Equals("0"))
                    {
                        lGuiaOC = new Tipo_GuiaOC();
                        lGuiaOC.IdIt = lDts.Tables[0].Rows[0]["IDIT"].ToString();
                        lGuiaOC.OC = lDts.Tables[0].Rows[0]["OC"].ToString();
                        lGuiaOC.Viajes = lDts.Tables[0].Rows[0]["Codigo"].ToString();
                        if (lDts.Tables[0].Rows[0]["idDespachosCamion"].ToString().Trim().Length > 1)
                            lGuiaOC.DespachosCamion = lDts.Tables[0].Rows[0]["idDespachosCamion"].ToString();
                        //else
                        //    lGuiaOC.DespachosCamion = ObtenerIdDespachoCamion(lDts.Tables[0].Rows[0]["Codigo"].ToString());

                        lListas.Add(lGuiaOC);

                    }

                }
                    
            }
            //Revisamos las listas y solo dejamos las 
            string lViajes = ""; string lDespachos = ""; string lOC_Tmp = ""; string lOC = ""; int j = 0;
            DataTable lTbl = new DataTable(); DataRow lFila = null; DataView lVista = null;

            lTbl = CreaCampo(lTbl);
            for (i = 0; i < lListas.Count; i++)
            {
                lOC_Tmp = lListas[i].OC.ToString();
                //for (j = 0; j < lListas.Count; j++)
                //{
                if (lListas[j].OC.ToString().Equals("0"))
                {
                    if (lOC_Tmp.IndexOf(lListas[j].OC.ToString()) > -1)
                    {
                        lVista = new DataView(lTbl, string.Concat("OC='", lListas[j].OC.ToString(), "'"), "", DataViewRowState.CurrentRows);
                        if (lVista.Count == 0)
                        {
                            lFila = lTbl.NewRow();
                            lFila["IdIt"] = lListas[i].IdIt;
                            lFila["OC"] = lListas[i].OC;
                            lFila["Viajes"] = lListas[i].Viajes;
                            lFila["DespachoCamion"] = lListas[i].DespachosCamion;
                            lTbl.Rows.Add(lFila);
                            lListas[j].OC = "";
                        }
                        else
                        {
                            lVista[0]["IdIt"] = string.Concat(lVista[0]["IdIt"], ",", lListas[i].IdIt);
                            lVista[0]["Viajes"] = string.Concat(lVista[0]["Viajes"], ",", lListas[i].Viajes);
                            lVista[0]["DespachoCamion"] = string.Concat(lVista[0]["DespachoCamion"], ",", lListas[i].DespachosCamion);
                            lListas[i].OC = "";
                        }
                    }
                    //}
                }
            }

            if (lTbl.Rows.Count > 0)
            {
                for (i = 0; i < lTbl.Rows.Count; i++)
                {
                    lGuiaOC = new Tipo_GuiaOC();
                    lGuiaOC.IdIt = lTbl.Rows[i]["IdIt"].ToString();
                    lGuiaOC.OC = lTbl.Rows[i]["OC"].ToString();
                    lGuiaOC.Viajes = lTbl.Rows[i]["Viajes"].ToString();
                    lGuiaOC.DespachosCamion = lTbl.Rows[i]["DespachoCamion"].ToString();
                    lListaFinal.Add(lGuiaOC);
                }
            }

            return lListaFinal;
        }

        private int PersisteRespuesta_INET(string lRes, string lPatente)
        {
            int lRespuesta = 0; string lSql = ""; Ws_TO.Ws_ToSoapClient lDal = new Ws_TO.Ws_ToSoapClient();
            string lXmlRes = ""; int lInicio = 0; int lFin = 0; string lIdPersistenciaINET = "";
            string TMETIP = ""; string MOVSUCCOD = ""; string TMECOD = ""; string MOVNUMDOC = ""; string DOCCOD = "";
            string ATENUMREA = ""; string Obs = ""; DataSet lDts = new DataSet();
            //  ALTER  PROCEDURE [dbo].[SP_CRUD_RespuestaINET]  ")
            //@Id int,                  //@Patente varchar(10),             //@TMETIP	int,     //@MOVSUCCOD  int,
            //@TMECOD		int,        //@MOVNUMDOC	int,            //@DOCCOD		int,    //@ATENUMREA	int,
            //@Obs		varchar(max),  //@OPCION INT
            lXmlRes = lRes.Replace("&amp;lt;", "<");
            lXmlRes = lXmlRes.Replace("&amp;gt;", ">");
            try
            {
                lInicio = lXmlRes.IndexOf("<TMETIP>") + "<TMETIP>".Length; lFin = lXmlRes.IndexOf("</TMETIP>");
                TMETIP = lXmlRes.Substring(lInicio, lFin - lInicio);
                lInicio = lXmlRes.IndexOf("<MOVSUCCOD>") + "<MOVSUCCOD>".Length; lFin = lXmlRes.IndexOf("</MOVSUCCOD>");
                MOVSUCCOD = lXmlRes.Substring(lInicio, lFin - lInicio);
                lInicio = lXmlRes.IndexOf("<TMECOD>") + "<TMECOD>".Length; lFin = lXmlRes.IndexOf("</TMECOD>");
                TMECOD = lXmlRes.Substring(lInicio, lFin - lInicio);
                lInicio = lXmlRes.IndexOf("<MOVNUMDOC>") + "<MOVNUMDOC>".Length; lFin = lXmlRes.IndexOf("</MOVNUMDOC>");
                MOVNUMDOC = lXmlRes.Substring(lInicio, lFin - lInicio);
                lInicio = lXmlRes.IndexOf("<DOCCOD>") + "<DOCCOD>".Length; lFin = lXmlRes.IndexOf("</DOCCOD>");
                DOCCOD = lXmlRes.Substring(lInicio, lFin - lInicio);
                lInicio = lXmlRes.IndexOf("<ATENUMREA>") + "<ATENUMREA>".Length; lFin = lXmlRes.IndexOf("</ATENUMREA>");
                ATENUMREA = lXmlRes.Substring(lInicio, lFin - lInicio);
                //lSql = string.Concat (" SP_CRUD_RespuestaINET 0,'",lPatente,"','", 

            }
            catch (Exception exc)
            {
                Obs = exc.Message.ToString();
            }
            finally
            {
                lSql = string.Concat("SP_CRUD_RespuestaINET 0,'", lPatente, "','", TMETIP, "','", MOVSUCCOD, "','", TMECOD, "','", MOVNUMDOC, "','");
                lSql = string.Concat(lSql, DOCCOD, "','", ATENUMREA, "','", Obs, "',1");
                lDts = lDal.ObtenerDatos(lSql);
                if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                {
                    lIdPersistenciaINET = lDts.Tables[0].Rows[0][0].ToString();
                    lRespuesta = int.Parse(lIdPersistenciaINET);
                }

            }

            //End Try

            return lRespuesta;
        }


        private Integracion_INET.Tipo_InvocaWS InvocaWS_INET(string ipatente, string IdObra, string lDespachosCam, string lViajes, string lTipoGuiaINET)
        {

            Integracion_INET.Cls_LN lIntegra = new Integracion_INET.Cls_LN();
            WsCrud.CrudSoapClient lDAl = new WsCrud.CrudSoapClient();
            WsCrud.ListaDataSet lDts = new WsCrud.ListaDataSet();
            string lSucursal = "";


            //mIdObra = int.Parse(IdObra);
            Registry registry = new Registry();
            lSucursal = (string)registry.GetValue(Program.regeditKeyName, "Sucursal", "");
            //string lEmpresa = ConfigurationManager.AppSettings["Empresa"].ToString();

            if (mEmpresa.ToUpper().Equals("TOSOL"))
                return lIntegra.InvocaWS_INET_TOSOL(ref Tx_INET, IdObra, lSucursal, lDespachosCam, lViajes);
            else
                return lIntegra.InvocaWS_INET(ref Tx_INET, IdObra, lSucursal, lDespachosCam, lViajes, lTipoGuiaINET);


        }


        private string IntegraConINET()
        {
            int i = 0; string lSQl = ""; int lRespINET = 0; Ws_TO.Ws_ToSoapClient lDal = new Ws_TO.Ws_ToSoapClient();
            Integracion_INET.Tipo_InvocaWS lRes = new Integracion_INET.Tipo_InvocaWS(); int TotalKgs = 0;
            string lDespachosCam = ""; string lViajes = ""; int j = 0;
            int NroGuiasCreadas = 0; List<Tipo_GuiaOC> lListaOC = new List<Tipo_GuiaOC>();

            TotalKgs = mKgsGuiaINET;
            if (MessageBox.Show(string.Concat("¿Esta Seguro que desea realizar la generación de  la guía de depacho por ", TotalKgs, " kilos,  para el camión ", mObjCam.Patente), "Avisos Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (TotalKgs > 0)   //(lDespachosCam.Length > 2)
                {
                    //el objeto lListaOC entrega solo VIajes con un numero de OC, con lo cual las guias de reposición NO TENDRAN UNA OC
                    // Los viajes con Nro de OC pueden tener codigo de guia 330 Facturable, 333 facturable FE en punta
                    lListaOC = ObtenerGuiasPorOC();
                    for (i = 0; i < lListaOC.Count; i++)
                    {
                        lDespachosCam = lListaOC[i].DespachosCamion;    //lDespachosCam.Substring(0, lDespachosCam.Length - 1);
                        lViajes = lListaOC[i].Viajes;  //lViajes.Substring(0, lViajes.Length - 1);
                        lRes = InvocaWS_INET(mObjCam.Patente, mIdObra.ToString (), lDespachosCam, lViajes, lListaOC[i].CodigoGuiaINET);
                        lRespINET = PersisteRespuesta_INET(lRes.XML_Respuesta, mObjCam.Patente);
                        string[] lPartes = lViajes.Split(new Char[] { ',' }); 
                        for (j = 0; j < lPartes.Length; j++)
                        {
                            //lIdDespacho = Obtener_IdDespacho(lPartes[j].ToString());
                            lSQl = string.Concat(" Update viaje set IdRespuestaINET=", lRespINET, ", patente='", mObjCam.Patente, "' "); //, IdDespachoCamion=", lIdDespacho);
                            lSQl = string.Concat(lSQl, ", IdLogWsINET=", lRes.Id, " where Codigo='", lPartes[j].ToString(), "'");
                            lDal.ObtenerDatos(lSQl);

                            //lIdDespacho = Obtener_IdDespacho(lPartes[j].ToString());
                            //lSQl = string.Concat(" Update viaje set IdRespuestaINET=", lRespINET, ", patente='", mObjCam.Patente, "', IdDespachoCamion=", lIdDespacho);
                            //lSQl = string.Concat(lSQl, ", IdLogWsINET=", lRes.Id, " where Codigo='", lPartes[j].ToString(), "'");
                            //lDal.ObtenerDatos(lSQl);
                        }
                    }
                    NroGuiasCreadas = lListaOC.Count;
                    //*************************************************************************************************************************
                    //Ahora revisamos las guias de reposición
                    lListaOC = new List<Tipo_GuiaOC>();
                    lListaOC = ObtenerGuias_DeReposicion();
                    for (i = 0; i < lListaOC.Count; i++)
                    {
                        lDespachosCam = lListaOC[i].DespachosCamion;    //lDespachosCam.Substring(0, lDespachosCam.Length - 1);
                        lViajes = lListaOC[i].Viajes;  //lViajes.Substring(0, lViajes.Length - 1);
                        lRes = InvocaWS_INET_Reposicion(mObjCam.Patente, mIdObra.ToString (), lDespachosCam, lViajes);
                        lRespINET = PersisteRespuesta_INET(lRes.XML_Respuesta, mObjCam.Patente);
                        string[] lPartes = lViajes.Split(new Char[] { ',' }); string lIdDespacho = "";
                        for (j = 0; j < lPartes.Length; j++)
                        {
                            //lIdDespacho = Obtener_IdDespacho(lPartes[j].ToString());
                            lSQl = string.Concat(" Update viaje set IdRespuestaINET=", lRespINET, ", patente='", mObjCam.Patente, "' "); //, IdDespachoCamion=", lIdDespacho);
                            lSQl = string.Concat(lSQl, ", IdLogWsINET=", lRes.Id, " where Codigo='", lPartes[j].ToString(), "'");
                            lDal.ObtenerDatos(lSQl);

                            //lIdDespacho = Obtener_IdDespacho(lPartes[j].ToString());
                            //lSQl = string.Concat(" Update viaje set IdRespuestaINET=", lRespINET, ", patente='", mObjCam.Patente, "', IdDespachoCamion=", lIdDespacho);
                            //lSQl = string.Concat(lSQl, ", IdLogWsINET=", lRes.Id, " where Codigo='", lPartes[j].ToString(), "'");
                            //lDal.ObtenerDatos(lSQl);
                        }
                    }
                    NroGuiasCreadas = NroGuiasCreadas + lListaOC.Count;
                    //*************************************************************************************************************************

                    MessageBox.Show(string.Concat("Se han Creado ", NroGuiasCreadas, " Guía(s) para el camión patente ", mObjCam.Patente), "Avisos Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //if (lRes.Err.ToString().ToUpper().Equals("N"))
                    //{   //No hay Error en la invicación a INET


                    //}
                }
            }
            //}
            //  ******* cerramos el proceso de despacho de camion  ***************************
            lSQl = string.Concat(" SP_CRUD_PesajeCamion 0,'", mObjCam.Patente, "',0,'',0,0,'',0,0,'',0,11 ");
            lDal.ObtenerDatos(lSQl);
            //********************************************************************************
            return lRes.Err.ToString();
        }
        #endregion


        private void Btn_pruebas_Click(object sender, EventArgs e)
        {
            //2.- los PL Despachados de cada viaje
            //ImprimirInforme(mObjCam.Id.ToString (), true);
            ImprimirInforme("608", true);
            //3.- Unimos los Archivos en uno  

        }

        private void Frm_DetalleGrabacion_Load(object sender, EventArgs e)
        {

        }

        private void Btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_Inicia_Click(object sender, EventArgs e)
        {
            InicaProceso();
        }
    }
}
