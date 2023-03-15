using Metalurgica.Informes;
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

namespace Metalurgica.SolicitudMP
{
    public partial class Frm_Imprime : Form
    {
        public Frm_Imprime()
        {
            InitializeComponent();
        }

        private void Frm_Imprime_Load(object sender, EventArgs e)
        {

        }

        public void ImprimirInforme(string iIdDespachoCamion, Boolean iEliminaArchivo)
        {
            DtsInformes lDtsPortada = new DtsInformes(); string iViaje = "";
            DtsInformes lDtsDetalle = new DtsInformes(); Char Delimitador = '/'; Clases.ClsComun lComun = new Clases.ClsComun();
            Frm_Visualizador lFrmInf = null;
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient(); int i = 0;
            DataSet lDtsTmp = new DataSet();
            try
            {

                string lSql = string.Concat("   SP_Consultas_WS 202 ,'", iIdDespachoCamion, "','','','','','','' ");
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
                                //LimpiaDirectorio_PDF();
                                lDtsPortada = CargaDatosPortada_ViajeOriginal(iViaje);
                                lFrmInf.InicializaInforme("P", lDtsPortada, iViaje, iEliminaArchivo);
                                lFrmInf.GeneraPdf();
                                lDtsDetalle = CargaDatosDetalleViajeOriginal(iViaje);
                                lFrmInf.InicializaInforme("D", lDtsDetalle, iViaje, iEliminaArchivo);
                                lFrmInf.GeneraPdf();
                                lFrmInf.Close();
                                //TerminaProceso();
                            }
                            else
                            {
                                //CargaDatosDetalle_ViajeSaldo
                                //LimpiaDirectorio_PDF();
                                lDtsPortada = CargaDatosPortada_ViajeSaldo(iViaje);
                                lFrmInf.InicializaInforme("P", lDtsPortada, iViaje, iEliminaArchivo);
                                lFrmInf.GeneraPdf();
                                lDtsDetalle = CargaDatosDetalle_ViajeSaldo(iViaje);
                                lFrmInf.InicializaInforme("D", lDtsDetalle, iViaje, iEliminaArchivo);
                                lFrmInf.GeneraPdf();
                                lFrmInf.Close();
                               // TerminaProceso();
                            }
                        }

                    }
                  //  LimpiaDirectorio_PDF();
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

        private DtsInformes CargaDatosPortada_ViajeSaldo(string iViaje)
        {
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient(); int i = 0;
            ArrayList lIdsPiezas = new ArrayList(); string lRes = "";
            DataSet lDtsTmp = new DataSet();
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

        private void LimpiaDirectorio_PDF()
        {
            string iPathPdf = ConfigurationManager.AppSettings["PathPdf"].ToString();

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

        }

        private void TerminaProceso()
        {
            string lPathArchivo = ConfigurationManager.AppSettings["PathPdf"].ToString(); //string.Concat("C:\\Informes\\TMP\\");
            Clases.ClsComun lCom = new Clases.ClsComun(); int i = 0;
            string lres = ""; DataTable lTblImp = new DataTable();
            lres = lCom.UnirOdf(lPathArchivo);


            //Aca debemos incluir la opcion de imprimir varios copias de un PL
            //por defecto es 1 a menos que se ingrese en la tabla parametros 
            //campo  par2 debe ir el nro de copias

            for (i = 0; i < 2; i++)
            {

                ProcessStartInfo info = new ProcessStartInfo();
                info.Verb = "print";                          // Seleccionar el programa para imprimir PDF por defecto
                info.FileName = lres; //@"C:\Informes\TMP\1.pdf";         // Ruta hacia el fichero que quieres imprimir
                info.CreateNoWindow = true;                   // Hacerlo sin mostrar ventana
                info.WindowStyle = ProcessWindowStyle.Hidden; // Y de forma oculta
                Process p = new Process();
                p.StartInfo = info;
                p.Start();  // Lanza el proceso

                p.WaitForInputIdle();
                System.Threading.Thread.Sleep(15000);          // Espera 15 segundos
                if (false == p.CloseMainWindow())
                    p.Kill();                                  // Y cierra el programa de imprimir PDF's
            }

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
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return lDts;
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
