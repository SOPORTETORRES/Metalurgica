using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Metalurgica.Models;
using CommonLibrary2;
using Metalurgica.Informes;
using System.Configuration;
using System.Collections;
using System.Drawing.Printing;
using System.Diagnostics;
//using Spire.Pdf;

namespace Metalurgica
{
    public partial class Frm_IntegracionINET : Form
    {
        private string mViajesCargados = "";
        private int mIdObra = 0;
        private int mIdDespachoCamion = 0;
        private int mKilosCargados = 0;
        private int mTotalCosto = 0;
        private string mMOVNUMDOC = "0";

        private string mMsgEjecucionWs = "";
        private bool mWSIntegracionGuiaOK = true;
        private bool mWSEntradaStockOK = true;

        private string mCodigoINET = "";
        private string mCodigoGuiaINET = "";
        private int mprecioRef = 0;
        private int mTotalNeto = 0;
        private int mPrecioCostoKilo = 0;
        private string mSucursal = "";
        private string mCodigoBodega = "";
        private string mCodigoBodegaEntrada = "";
        private string mCodigoSucursal_INET = "";
        private string mTransportista = "";
        private string mpatenteCamion = "";
        private string mNombreObra = "";
        private string mRutObra = "";
        private string mPatenteCamion = "";
        private int mPrecioRef = 0;
        //private int mPrecioCostoKilo = 0;
        private bool mAgregaColumna = true;
        private string mIdObraSel = "";
        private string mSucursalTO = "";
        private string mEmpresa = "";
        private string mSoloCamionesBascula = "";

        public Frm_IntegracionINET()
        {
            InitializeComponent();
        }

        private void Frm_IntegracionINET_Load(object sender, EventArgs e)
        {

        }

        public void IniciaForm(string iEmpresa, string iSoloCamionEnBascula)
        {
            mEmpresa = iEmpresa;
            mSoloCamionesBascula = ConfigurationManager.AppSettings["SoloCamionesBascula"].ToString(); ;
            mSucursalTO = ConfigurationManager.AppSettings["Sucursal"].ToString();
            CargaCamiones(mSucursalTO, mEmpresa, mSoloCamionesBascula);
            Lbl_titulo.Text = string.Concat("Este Formulario muestra la información de despacho de la empresa ", mEmpresa.ToUpper());
            CargaSucursal();
        }

        private void CargaSucursal()
        {
            DataTable lTbl = new DataTable(); DataRow lFila = null; string lEmpresa = "";
            lEmpresa = ConfigurationManager.AppSettings["Empresa"].ToString();
            if ((mSucursalTO.ToUpper().Equals("SANTIAGO")) && (lEmpresa.ToUpper().Equals("TO")))
            {
                lTbl.Columns.Add("Sucursal");

                lFila = lTbl.NewRow();
                lFila["Sucursal"] = "Santiago";
                lTbl.Rows.Add(lFila);
                lFila = lTbl.NewRow();
                lFila["Sucursal"] = "Bodega FE Punta LC";
                lTbl.Rows.Add(lFila);

                new Forms().comboBoxFill(Cmb_Sucursal, lTbl, "Sucursal", "Sucursal", 0);
                label9.Visible = true;
                Cmb_Sucursal.Visible = true;
                btn_Ir.Visible = true;
            }

        }
        public void AgregaColumnaCheck()
        {


            DataGridViewCheckBoxColumn colcheckBox = new DataGridViewCheckBoxColumn();
            //        Dgt_Piezas.Columns.Insert(0, colcheckBox)
            this.Dtg_Camiones.Columns.Insert(0, colcheckBox);
            colcheckBox.HeaderText = "Sel";
            colcheckBox.Name = "Sel";
            colcheckBox.Width = 50;
            mAgregaColumna = false;
        }

        private void CargaCamiones(string lSucursalTO, string lEmpresa, string lBascula)
        {
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient(); int i = 0; TreeNode lNodo = null;
            DataSet lDts = new DataSet(); string lSql = ""; DataTable lTbl = new DataTable(); string lTmp = "";
            DataTable lTbl2 = new DataTable(); int j = 0; string lStrLlave = ""; string lPatente = "";
            TreeNode lNodo2 = null; int lKilos = 0; DataView lVista = null; int k = 0; string lPar1 = "";
            //string lEmpresa = "";

            lSql = string.Concat(" SP_Consultas_FacturacionPorCamion 1,'", lSucursalTO, "','','','','','',''");
            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                lTbl = lDts.Tables[0].Copy();
                Dtg_Camiones.DataSource = lTbl;

                //'Prepara la carga del árbol
                this.TR_Arbol.BeginUpdate();
                TR_Arbol.Nodes.Clear();
                for (i = 0; i < lTbl.Rows.Count; i++)
                {
                    lTmp = string.Concat(lTbl.Rows[i]["Fecha"].ToString(), " (", lTbl.Rows[i]["Kilos"].ToString(), ")");
                    lNodo = new TreeNode(lTmp);
                    lNodo.Name = "FECHA";
                    //  lNodo = new TreeNode(lTmp);
                    lSql = string.Concat(" SP_Consultas_FacturacionPorCamion 2,'", lTbl.Rows[i]["Fecha"].ToString(), "','", mSucursalTO, "','','','','',''");
                    lDts = lPx.ObtenerDatos(lSql);
                    if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                    {
                        lTbl2 = lDts.Tables[0].Copy();
                        lStrLlave = "";
                        for (j = 0; j < lTbl2.Rows.Count; j++)
                        {
                            lPatente = lTbl2.Rows[j]["Patente"].ToString();
                            if (lStrLlave.IndexOf(lPatente) < 0)
                            {
                                lStrLlave = string.Concat(lStrLlave, lPatente, "|");
                                lVista = new DataView(lTbl2, string.Concat("Patente='", lPatente, "'"), "", DataViewRowState.CurrentRows);
                                if (lVista.Count > 0)
                                {
                                    for (k = 0; k < lVista.Count; k++)
                                    {
                                        lKilos = lKilos + int.Parse(lVista[k]["Kilos"].ToString());
                                    }
                                }
                                lNodo2 = new TreeNode(string.Concat(lPatente, " (", lKilos.ToString(), ")"));
                                lNodo2.Name = "Patente";
                                if (lVista.Count > 0)
                                {
                                    for (k = 0; k < lVista.Count; k++)
                                    {
                                        lNodo2.Nodes.Add(string.Concat(lVista[k]["Codigo"].ToString(), " (", lVista[k]["Kilos"].ToString(), ")"));

                                        lNodo2.Nodes[0].ImageIndex = 0;
                                    }
                                }
                                lNodo.Nodes.Add(lNodo2);
                                lNodo.Nodes[0].ImageIndex = 2;
                                lKilos = 0;
                            }
                        }
                    }
                    TR_Arbol.Nodes.Add(lNodo);
                    TR_Arbol.Nodes[0].ImageIndex = 1;

                }

                TR_Arbol.EndUpdate();
                TR_Arbol.CollapseAll();
            }

        }

        private void TR_Arbol_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Name.ToUpper().Equals("FECHA"))
                CargaDetalleNodo(e.Node.FullPath.ToString(), "F", mSucursalTO);

            if (e.Node.Name.ToUpper().Equals("PATENTE"))
                CargaDetalleNodo(e.Node.FullPath.ToString(), "P", mSucursalTO);

        }

        private string ValidaIntegracionINET(string iPatente)
        {
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient();
            DataSet lDts = new DataSet(); string lSql = ""; DataTable lTbl = new DataTable();
            string lRes = "";
            //Si la variable de configuración  SoloCamionesBascula esta en S
            // al momento de despachar el camión este deberia haber sido pesada la tara
            if (mSoloCamionesBascula.ToUpper().Equals("S"))
            {
                lSql = String.Concat(" exec SP_CRUD_PesajeCamion 0", ",'", iPatente, "',0,'',0,0,'',0,0,'',0,10");
                lDts = lPx.ObtenerDatos(lSql);
                if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                {
                    lRes = "OK";
                    Btn_INET.Enabled = true;
                }
                else
                {
                    Btn_INET.Enabled = false;
                    lRes = " Para poder emitir la Guía de Despacho, Debe finalizar el Proceso de Pesaje en Bascula y Grabar los Datos. Verifique el Proceso ";
                    //MessageBox.Show(lRes, "Avisos Sistema", MessageBoxButtons.OK);
                }
            }
            else
            {
                //Si la variable no esta activada, no se debe validar nada 
                lRes = "OK";
                Btn_INET.Enabled = true;
            }

            return lRes;

        }

        private void CargaDetalleNodo(string iTextNodo, string iTipo, string iSucursal)
        {
            string[] split = iTextNodo.Split(new Char[] { '\\' });
            string lFecha = ""; string lPatente = ""; string[] lPartes = null; int i = 0;
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient(); DataSet lDts = new DataSet();

            string lSql = "";
            Btn_INET.Enabled = false;

            switch (iTipo)
            {
                case "P":
                    lPartes = split[0].Split(new Char[] { '(' });
                    lFecha = lPartes[0].ToString().Trim();
                    lPartes = split[1].Split(new Char[] { '(' });
                    lPatente = lPartes[0].ToString().Trim();
                    lSql = string.Concat(" SP_Consultas_FacturacionPorCamion 3,'", lFecha, "','", lPatente, "','", iSucursal, "','','','',''");

                    Btn_INET.Enabled = true;
                    break;
                case "F":
                    lPartes = split[0].Split(new Char[] { '(' });
                    lFecha = lPartes[0].ToString().Trim();
                    lSql = string.Concat(" SP_Consultas_FacturacionPorCamion 2,'", lFecha, "','','','','','',''");
                    break;

            }
            if (lSql.Trim().Length > 0)
            {
                lDts = lPx.ObtenerDatos(lSql);
                if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                {
                    Dtg_Camiones.DataSource = lDts.Tables[0].Copy();
                }
            }
            if (mAgregaColumna == true)
                AgregaColumnaCheck();


            if (iTipo == "P")
            {
                //formateamos la grilla
                Dtg_Camiones.Columns[0].Width = 60;
                Dtg_Camiones.Columns[2].Width = 60;
                Dtg_Camiones.Columns[3].Width = 250;
                Dtg_Camiones.Columns[4].Width = 80;
                Dtg_Camiones.Columns[5].Width = 60;

                for (i = 0; i < Dtg_Camiones.RowCount; i++)
                {
                    PintaGrilla(i, Dtg_Camiones.Rows[i].Cells["TipoGuiaINET"].Value.ToString());
                }
            }

            Tx_Fecha.Text = lFecha;
            Tx_Patente.Text = lPatente;
            string lValidacionINET = ValidaIntegracionINET(Tx_Patente.Text);
            if (lValidacionINET == "OK")
            {
                Btn_INET.Enabled = true;
            }
            else
            {
                Btn_INET.Enabled = false;
                MessageBox.Show(string.Concat(" Ha Ocurrido el siguiente Error: ", lValidacionINET));
            }
        }

        private void PintaGrilla(int lIndexFila, string iTipo)
        {
            Color lColor = Color.Black;


            if (iTipo.ToUpper().Equals("R"))
                lColor = Color.Yellow;

            if (iTipo.ToUpper().Equals("F"))
                lColor = Color.LightGreen;

            if (iTipo.ToUpper().Equals("FE"))
                lColor = Color.LightSalmon;

            if (iTipo.ToUpper().Equals("LC"))
                lColor = Color.LightSalmon;

            if (iTipo.ToUpper().Equals("FC"))
                lColor = Color.LightSalmon;

            // if ((lPartes[j].ToUpper().Equals("FE")) || ((lPartes[j].ToUpper().Equals("FC"))) || ((lPartes[j].ToUpper().Equals("LC"))))

            int i = 0;

            for (i = 1; i < 9; i++)
            {
                Dtg_Camiones.Rows[lIndexFila].Cells[i].Style.BackColor = lColor;
            }

        }

        private void Btn_INET_Click(object sender, EventArgs e)
        {
            int i = 0; string lSQl = ""; int lRespINET = 0; Ws_TO.Ws_ToSoapClient lDal = new Ws_TO.Ws_ToSoapClient(); int j = 0;
            string[] lPartes; int k = 0;
            Integracion_INET.Tipo_InvocaWS lRes = new Integracion_INET.Tipo_InvocaWS(); int TotalKgs = 0; int NroIT = 0;
            string lDespachosCam = ""; string lViajes = ""; List<Tipo_GuiaOC> lListaOC = new List<Tipo_GuiaOC>();
            Btn_INET.Enabled = false; int NroGuiasCreadas = 0; List<Tipo_GuiaOC> lListaOC_Rep = new List<Tipo_GuiaOC>();

            if (ValidaDatos() == true)
            {
                foreach (DataGridViewRow lRow in this.Dtg_Camiones.Rows)
                {
                    if (lRow.Cells[0].Value != null)
                        if (lRow.Cells[0].Value.ToString() == "True")
                        {
                            TotalKgs = TotalKgs + int.Parse(lRow.Cells["Kilos"].Value.ToString());
                            NroIT = NroIT + 1;

                        }
                }
                if (MessageBox.Show(string.Concat("¿Esta Seguro que desea realizar la generación de  la guía de depacho por ", TotalKgs, " kilos,  para el camión ", Tx_Patente.Text), "Avisos Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (TotalKgs > 0)   //(lDespachosCam.Length > 2)
                    {
                        //el objeto lListaOC entrega solo VIajes con un numero de OC, con lo cual las guias de reposición NO TENDRAN UNA OC
                        // Los viajes con Nro de OC pueden tener codigo de guia 330 Facturable, 333 facturable FE en punta
                        lListaOC = ObtenerGuiasPorOC();
                        //MessageBox.Show("Despues de Obtener lListaOC");
                        for (i = 0; i < lListaOC.Count; i++)
                        {
                            lDespachosCam = lListaOC[i].DespachosCamion;    //lDespachosCam.Substring(0, lDespachosCam.Length - 1);mSucursalTO
                            lViajes = lListaOC[i].Viajes;  //lViajes.Substring(0, lViajes.Length - 1);
                            lRes = InvocaWS_INET(Tx_Patente.Text, Tx_Fecha.Text, mIdObraSel, lDespachosCam, lViajes, lListaOC[i].CodigoGuiaINET);
                            lRespINET = PersisteRespuesta_INET(lRes.XML_Respuesta, Tx_Patente.Text);
                              lPartes = lViajes.Split(new Char[] { ',' }); string lIdDespacho = "";
                            for (j = 0; j < lPartes.Length; j++)
                            {
                                lIdDespacho = Obtener_IdDespacho(lPartes[j].ToString());
                                lSQl = string.Concat(" Update viaje set IdRespuestaINET=", lRespINET, ", patente='", Tx_Patente.Text, "', IdDespachoCamion=", lIdDespacho);
                                lSQl = string.Concat(lSQl, ", IdLogWsINET=", lRes.Id, " where Codigo='", lPartes[j].ToString(), "'");
                                lDal.ObtenerDatos(lSQl);
                            }
                        }
                        NroGuiasCreadas = lListaOC.Count;
                        //*************************************************************************************************************************
                        //Ahora revisamos las guias de reposición
                        lListaOC_Rep = new List<Tipo_GuiaOC>();
                        lListaOC_Rep = ObtenerGuias_DeReposicion();
                        for (i = 0; i < lListaOC_Rep.Count; i++)
                        {
                            lDespachosCam = lListaOC_Rep[i].DespachosCamion;    //lDespachosCam.Substring(0, lDespachosCam.Length - 1);
                            lViajes = lListaOC_Rep[i].Viajes;  //lViajes.Substring(0, lViajes.Length - 1);
                            lRes = InvocaWS_INET_Reposicion(Tx_Patente.Text, Tx_Fecha.Text, mIdObraSel, lDespachosCam, lViajes);
                            lRespINET = PersisteRespuesta_INET(lRes.XML_Respuesta, Tx_Patente.Text);
                             lPartes = lViajes.Split(new Char[] { ',' }); string lIdDespacho = "";
                            for (j = 0; j < lPartes.Length; j++)
                            {
                                lIdDespacho = Obtener_IdDespacho(lPartes[j].ToString());
                                lSQl = string.Concat(" Update viaje set IdRespuestaINET=", lRespINET, ", patente='", Tx_Patente.Text, "', IdDespachoCamion=", lIdDespacho);
                                lSQl = string.Concat(lSQl, ", IdLogWsINET=", lRes.Id, " where Codigo='", lPartes[j].ToString(), "'");
                                lDal.ObtenerDatos(lSQl);
                            }
                        }
                        NroGuiasCreadas = NroGuiasCreadas + lListaOC_Rep.Count;
                        //*************************************************************************************************************************

                        MessageBox.Show(string.Concat("Se han Creado ", NroGuiasCreadas, " Guía(s) para el camión patente ", Tx_Patente.Text), "Avisos Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (lRes.Err.ToString().ToUpper().Equals("N"))
                        {   //No hay Error en la invicación a INET


                        }
                        //******************************************************************************
                        // aca debemos enviara a imprimir el informe de despacho de camion. 14/06/2018
                        //https://social.msdn.microsoft.com/Forums/es-ES/898271af-4622-4165-a50d-ccbbc4d3609b/imprimir-crystal-report-por-impresora-sin-que-se-vea-en-pantalla?forum=vsrepcrystales
                        //*****************************************************************************
                    }

                    //  ******* cerramos el proceso de despacho de camion  ***************************
                    lSQl = string.Concat(" SP_CRUD_PesajeCamion 0,'", Tx_Patente.Text, "',0,'',0,0,'',0,0,'',0,11 ");
                    lDal.ObtenerDatos(lSQl);

                    //******************Imprimimos los PL
                    //  Imprimimos los PL Despacho
                    //DataSet lDts = new DataSet();string lIdIt = ""; string IdObra = ""; string IdUser = "";
                    //MessageBox.Show("Despues de Antes Camiones", "Trama de la aplicaión");
                    //  lPartes = lViajes.Split(new Char[] { ',' });
                    try
                    {
                        for (i = 0; i < lListaOC.Count; i++)
                        {

                            lViajes = lListaOC[i].Viajes;  //lViajes.Substring(0, lViajes.Length - 1);
                            lPartes = lViajes.Split(new Char[] { ',' });
                            for (k = 0; k < lPartes.Length; k++)
                            {
                                ImprimeDocumentos(lPartes[k].ToString());
                            }
                        }
                        for (i = 0; i < lListaOC_Rep.Count; i++)
                        {

                            lViajes = lListaOC_Rep[i].Viajes;  //lViajes.Substring(0, lViajes.Length - 1);
                            lPartes = lViajes.Split(new Char[] { ',' });
                            for (k = 0; k < lPartes.Length; k++)
                            {
                                ImprimeDocumentos(lPartes[k].ToString());
                            }
                        }
                        //***********
                    }
                    catch (Exception iex)
                    {
                        MessageBox.Show(string.Concat(" HA ocurrido el siguiente error:", iex.Message.ToString()), "Avisos Sistema");
                    }

                }

            }
   

            //********************************************************************************
            Btn_INET.Enabled = true;
            CargaCamiones(mSucursalTO, mEmpresa, mSoloCamionesBascula);

        




        }




        #region Impresion de Informes

        private void  ImprimeViajeDespachado(string  IdIt , string  iCodViaje , string  IdObra, string iUser )
      {
            //ObraCivil.Frm_ImprimirPL lFrm = new ObraCivil.Frm_ImprimirPL();
            //lFrm.ImprimeViajeDespacho(IdIt, iCodViaje, iUser, IdObra);

        }


        private void ImprimeDocumentos(string iViaje )
        {
            //1.- primero Resumen Despacho
            // ImprimeResumenDespacho(false);

            //2.- los PL Despachados de cada viaje
            //ImprimirInforme("HSG-896/1", true);

            //MessageBox.Show("Antes de Imprimir el Viaje ", "Avisos Sistema");
            ImprimirInforme(iViaje, true);
            //3.- Unimos los Archivos en uno 
            TerminaProceso(iViaje);

        }


        private DataTable ImpresorasInstaladas()
        {
            DataTable lTbl = new DataTable(); DataRow lFila = null;
            lTbl.Columns.Add("Impresora");

            foreach (String strPrinter in System.Drawing.Printing.PrinterSettings.InstalledPrinters)

            {
                lFila = lTbl.NewRow();
                lFila["Impresora"] = strPrinter;
                lTbl.Rows.Add(lFila);
                // MessageBox.Show(strPrinter);
            }
            return  lTbl;
        }
        private void TerminaProceso(string iViaje )
        {
            string lPathArchivo = ""; //string.Concat("C:\\TMP\\Logistica\\ImpresionPL\\HSG\\");
            Clases.ClsComun lCom = new Clases.ClsComun(); string lImp = "";int i = 0;
            string lres = ""; DataTable lTblImp = new DataTable(); string[] separators = { "-" };
            string lPathBase = ConfigurationManager.AppSettings["PathPdf"].ToString();

            string[] lPartes = iViaje.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            if (lPartes.Length > 1)
            {
                lPathArchivo = string.Concat(lPathBase, lPartes[0], "\\");
                if (Directory.Exists(lPathArchivo) == false)
                {
                    Directory.CreateDirectory(lPathArchivo);
                }
            }
                lres = lCom.UnirOdf(lPathArchivo);

            //Aqui debemos enviar a imprimir el archivo a la impresora indicada.
            //lTblImp = ImpresorasInstaladas();
            //for (i = 0; i < lTblImp.Rows.Count; i++)
            //{
            //    lImp = string.Concat(lImp, lTblImp.Rows[i]["impresora"].ToString(), " - ");
            //}
           

            SendToPrinter(lres);

            if (File.Exists(lres) == true)
                File.Delete(lres);

            DirectoryInfo di = new DirectoryInfo(lPathArchivo);
            foreach (var fi in di.GetFiles())
            {
                lImp = string.Concat(lPathArchivo, fi.ToString());
                if (File.Exists(lImp) == true )
                    File.Delete(lImp);
            }

                //  MessageBox.Show(lImp);

            }

        private void SendToPrinter(string iPath)
        {
            ProcessStartInfo info = new ProcessStartInfo();
            info.Verb = "print";                          // Seleccionar el programa para imprimir PDF por defecto
            info.FileName = iPath; //@"C:\Informes\TMP\1.pdf";         // Ruta hacia el fichero que quieres imprimir
            info.CreateNoWindow = true;                   // Hacerlo sin mostrar ventana
            info.WindowStyle = ProcessWindowStyle.Hidden; // Y de forma oculta
            //"C:\\Informes\\TMP\\"
            Process p = new Process();
            p.StartInfo = info;
            p.Start();  // Lanza el proceso

            p.WaitForInputIdle();
            System.Threading.Thread.Sleep(3000);          // Espera 3 segundos
            if (false == p.CloseMainWindow())
                p.Kill();                                  // Y cierra el programa de imprimir PDF's
        }

        public void ImprimirInforme(string iViaje, Boolean iEliminaArchivo)
        {
             DtsInformes lDtsPortada = new DtsInformes();
            DtsInformes lDtsDetalle = new DtsInformes(); Char Delimitador = '/'; Clases.ClsComun lComun = new Clases.ClsComun();
            Frm_Visualizador lFrmInf = new Frm_Visualizador();
            try
            {
                String[] lPartes = iViaje.Split(Delimitador);
                if (lPartes.Length > 0)
                {
                    if (lComun.Val(lPartes[1]) == 1)
                    {
                        lDtsPortada = CargaDatosPortada_ViajeOriginal(iViaje);
                        lFrmInf.InicializaInforme("P", lDtsPortada, iViaje, iEliminaArchivo);
                        lFrmInf.GeneraPdf();
                        lDtsDetalle = CargaDatosDetalleViajeOriginal(iViaje);
                        lFrmInf.InicializaInforme("D", lDtsDetalle, iViaje, iEliminaArchivo);
                        lFrmInf.GeneraPdf();
                        lFrmInf.Close();
                    }
                    else
                    {
                        //CargaDatosDetalle_ViajeSaldo
                        lDtsPortada = CargaDatosPortada_ViajeSaldo(iViaje);
                        //lDtsPortada = CargaDatosDetalle_ViajeSaldo(iViaje);
                        lFrmInf.InicializaInforme("P", lDtsPortada, iViaje, iEliminaArchivo);
                        lFrmInf.GeneraPdf();
                        lDtsDetalle = CargaDatosDetalle_ViajeSaldo(iViaje);
                        lFrmInf.InicializaInforme("D", lDtsDetalle, iViaje, iEliminaArchivo);
                        lFrmInf.GeneraPdf();
                        lFrmInf.Close();
                    }
                }

            }
            catch (Exception exc)
            {
                //MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw exc;
            }

            //**************************************************************************
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
        private string OBtenerValorKilo(string iIdObra)
        {
            string lSql = ""; Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient();  DataTable lTblRes = new DataTable(); string lValorKilo = "";
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
                            lTmp = lCom.FormateaMiles (lTblTmp.Rows[0]["KILOS"].ToString());// 0);// ",", "."
                            lDts.ResumenDesp.Rows[0]["PesoTotalDesp"] = lTmp;
                            lDts.ResumenDesp.Rows[0]["NroEtiquetasDesp"] = lTblTmp.Rows[0]["NroEtiquetas"].ToString();
                            //  lTmp = Replace(FormatNumber(Val(OBtenerValorKilo(IdObra)) * Val(lTblTmp.Rows(0)("KILOS").ToString), 0), ",", ".")
                            lValorKilo = lCom .Val ( OBtenerValorKilo(iIdObra));
                            lTmp = (lValorKilo * lCom.Val(lTblTmp.Rows[0]["KILOS"].ToString())).ToString();

                           lDts.ResumenDesp.Rows[0]["ValorTotal_ITDesp"] = String.Concat("$ ", lCom.FormateaMiles(lTmp.ToString ()));
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
        #endregion

        private string ObtenerIdDespachoCamion(string lViaje)
        {
            string lIdDesp = ""; int i = 0;

            for (i = 0; i < Dtg_Camiones.RowCount; i++)
            {
                if (Dtg_Camiones.Rows[i].Cells["Codigo"].Value.ToString().Equals(lViaje) == true)
                {
                    lIdDesp = Dtg_Camiones.Rows[i].Cells["IdDespacho"].Value.ToString();                    
                }
            }

            return lIdDesp;        
        }


        private List<Tipo_GuiaOC> ObtenerGuiasPorOC()
        { 
            List<Tipo_GuiaOC> lListas=new List<Tipo_GuiaOC>() ;
            Tipo_GuiaOC lGuiaOC = new Tipo_GuiaOC(); string lsql = "";
            Ws_TO.Ws_ToSoapClient lDal = new Ws_TO.Ws_ToSoapClient(); DataSet lDts = new DataSet();
            List<Tipo_GuiaOC> lListaFinal = new List<Tipo_GuiaOC>(); int i = 0;
            foreach (DataGridViewRow lRow in this.Dtg_Camiones.Rows)
            {
                if (lRow.Cells[0].Value != null)
                    if (lRow.Cells[0].Value.ToString() == "True")
                    {
          
                        lsql = string.Concat ("SP_Consultas_FacturacionPorCamion  5,'",lRow.Cells["Codigo"].Value .ToString() ,"',");
                        lsql = string.Concat(lsql ,"'','','','','',''");
                        lDts = lDal.ObtenerDatos(lsql);
                        if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                        {
                            lGuiaOC = new Tipo_GuiaOC();
                            lGuiaOC.IdIt = lDts.Tables[0].Rows[0]["IDIT"].ToString();
                            lGuiaOC.OC  = lDts.Tables[0].Rows[0]["OC"].ToString();
                            lGuiaOC.Viajes  = lDts.Tables[0].Rows[0]["Codigo"].ToString();
                            lGuiaOC .CodigoGuiaINET = lDts.Tables[0].Rows[0]["TipoGuia_INET"].ToString();
                            if (lDts.Tables[0].Rows[0]["idDespachosCamion"].ToString().Trim ().Length >1)
                                    lGuiaOC.DespachosCamion = lDts.Tables[0].Rows[0]["idDespachosCamion"].ToString();
                            else
                                lGuiaOC.DespachosCamion = ObtenerIdDespachoCamion(lDts.Tables[0].Rows[0]["Codigo"].ToString());

                            lListas.Add(lGuiaOC);
                        }
                    }
            }
            //Revisamos las listas y solo dejamos las 
            string lViajes = ""; string lDespachos = ""; string lOC_Tmp = ""; string lOC = ""; int j = 0;
            DataTable lTbl = new DataTable(); DataRow lFila = null; DataView lVista = null;

            lTbl = CreaCampo(lTbl);
            for (i = 0; i < lListas.Count ; i++)
            {
                lOC_Tmp = lListas[i].OC.ToString();
                for (j = 0; j < lListas.Count; j++)                   
                {
                    if (lListas[j].OC.ToString().Trim ().Length >0)
                    {
                        if (lOC_Tmp.IndexOf(lListas[j].OC.ToString()) > -1)
                        {
                            lVista=new DataView (lTbl,string.Concat ("OC='",lListas[j].OC.ToString(),"'"),"",DataViewRowState.CurrentRows );
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
                                lVista[0]["IdIt"] = string.Concat (lVista[0]["IdIt"] , ",",lListas[j].IdIt);
                                lVista[0]["Viajes"] = string.Concat(lVista[0]["Viajes"], ",", lListas[j].Viajes );
                                //if (lVista[0]["DespachoCamion"].ToString ().IndexOf(lListas[j].DespachosCamion.ToString ()) ==-1)
                                    lVista[0]["DespachoCamion"] = string.Concat(lVista[0]["DespachoCamion"], ",", lListas[j].DespachosCamion);

                                //if (lVista[0]["TipoGuia_INET"].ToString().IndexOf(lListas[j].CodigoGuiaINET.ToString()) == -1)
                                    lVista[0]["TipoGuia_INET"] = string.Concat(lVista[0]["TipoGuia_INET"], ",", lListas[j].CodigoGuiaINET) ; 

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
                        string[] lPartesIdIT = (lTbl.Rows[i]["IdIT"].ToString().Split(new Char[] { ',' }));
                        string[] lPartesViaje = (lTbl.Rows[i]["Viajes"].ToString().Split(new Char[] { ',' }));
                        string[] lPartes_DC = (lTbl.Rows[i]["DespachoCamion"].ToString().Split(new Char[] { ',' }));
                        string[] lPartes = (lTbl.Rows[i]["TipoGuia_INET"].ToString().Split(new Char[] { ',' }));
                        for (j = 0; j < lPartes.Length ; j++)
                        {
                            if (lPartes[j].ToUpper().Equals("F"))
                            {
                                lGuiaOC_F.OC = lTbl.Rows[i]["OC"].ToString();
                                lGuiaOC_F.IdIt  = string.Concat (lPartesIdIT[j].ToString (), ",", lGuiaOC_F.IdIt);
                                lGuiaOC_F.Viajes  = string.Concat(lPartesViaje[j].ToString(), ",", lGuiaOC_F.Viajes);
                                lGuiaOC_F.DespachosCamion = string.Concat(lPartes_DC[j].ToString(), ",", lGuiaOC_F.DespachosCamion);
                                lGuiaOC_F.CodigoGuiaINET = string.Concat(lPartes [j].ToString(), ",", lGuiaOC_F.CodigoGuiaINET);
                            }

                            if ((lPartes[j].ToUpper().Equals("FE")) || ((lPartes[j].ToUpper().Equals("FC"))) || ((lPartes[j].ToUpper().Equals("LC"))))
                            {
                                lGuiaOC_FE.OC = lTbl.Rows[i]["OC"].ToString();
                                lGuiaOC_FE.IdIt = string.Concat(lPartesIdIT[j].ToString(),",", lGuiaOC_FE.IdIt);
                                lGuiaOC_FE.Viajes = string.Concat(lPartesViaje[j].ToString(), ",", lGuiaOC_FE.Viajes);
                                lGuiaOC_FE.DespachosCamion = string.Concat(lPartes_DC[j].ToString(), ",", lGuiaOC_FE.DespachosCamion);
                                lGuiaOC_FE.CodigoGuiaINET = string.Concat(lPartes[j].ToString(), ",", lGuiaOC_FE.CodigoGuiaINET);
                            }

                        }

                        if (lGuiaOC_F.OC.Trim().Length > 0)
                        {
                            lGuiaOC = new Tipo_GuiaOC();
                            lGuiaOC.IdIt = lGuiaOC_F.IdIt.ToString ().Substring (0, lGuiaOC_F.IdIt.Length -1);
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


                        //lGuiaOC = new Tipo_GuiaOC();
                        //lGuiaOC.IdIt = lTbl.Rows[i]["IdIt"].ToString();
                        //lGuiaOC.OC = lTbl.Rows[i]["OC"].ToString();
                        //lGuiaOC.Viajes = lTbl.Rows[i]["Viajes"].ToString();
                        //lGuiaOC.DespachosCamion = lTbl.Rows[i]["DespachoCamion"].ToString();
                        //lGuiaOC.CodigoGuiaINET = lTbl.Rows[i]["TipoGuia_INET"].ToString();
                        //lListaFinal.Add(lGuiaOC);
                    }
                    
                }
            }

            return lListaFinal;        
        }


        private List<Tipo_GuiaOC> ObtenerGuias_DeReposicion()
        {
            List<Tipo_GuiaOC> lListas = new List<Tipo_GuiaOC>();
            Tipo_GuiaOC lGuiaOC = new Tipo_GuiaOC(); string lsql = "";
            Ws_TO.Ws_ToSoapClient lDal = new Ws_TO.Ws_ToSoapClient(); DataSet lDts = new DataSet();
            List<Tipo_GuiaOC> lListaFinal = new List<Tipo_GuiaOC>(); int i = 0;
            foreach (DataGridViewRow lRow in this.Dtg_Camiones.Rows)
            {
                if (lRow.Cells[0].Value != null)
                    if (lRow.Cells[0].Value.ToString() == "True")
                    {

                        lsql = string.Concat("SP_Consultas_FacturacionPorCamion  5,'", lRow.Cells["Codigo"].Value.ToString(), "',");
                        lsql = string.Concat(lsql, "'','','','','',''");
                        lDts = lDal.ObtenerDatos(lsql);
                        if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                        {
                            if (lDts.Tables[0].Rows[0]["OC"].ToString().Equals ("0"))
                            {
                                lGuiaOC = new Tipo_GuiaOC();
                                lGuiaOC.IdIt = lDts.Tables[0].Rows[0]["IDIT"].ToString();
                                lGuiaOC.OC = lDts.Tables[0].Rows[0]["OC"].ToString();
                                lGuiaOC.Viajes = lDts.Tables[0].Rows[0]["Codigo"].ToString();
                                if (lDts.Tables[0].Rows[0]["idDespachosCamion"].ToString().Trim().Length > 1)
                                    lGuiaOC.DespachosCamion = lDts.Tables[0].Rows[0]["idDespachosCamion"].ToString();
                                else
                                    lGuiaOC.DespachosCamion = ObtenerIdDespachoCamion(lDts.Tables[0].Rows[0]["Codigo"].ToString());

                                lListas.Add(lGuiaOC);

                            }
                           
                        }
                    }
            }
            //Revisamos las listas y solo dejamos las 
           // string lViajes = ""; string lDespachos = "";
            string lOC_Tmp = ""; string lOC = ""; int j = 0;
            DataTable lTbl = new DataTable(); DataRow lFila = null; DataView lVista = null;

            lTbl = CreaCampo(lTbl);
            for (i = 0; i < lListas.Count; i++)
            {
                lOC_Tmp = lListas[i].OC.ToString();
                //for (j = 0; j < lListas.Count; j++)
                //{
                    if (lListas[j].OC.ToString().Equals ("0"))
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

        private DataTable CreaCampo(DataTable iTbl)
        {
            iTbl.Columns.Add("OC");
            iTbl.Columns.Add("IdIT");
            iTbl.Columns.Add("Viajes");
            iTbl.Columns.Add("DespachoCamion");
            iTbl.Columns.Add("TipoGuia_INET");

            return iTbl;        
        }

        #region "Metodo de integración con INET"




        private string Obtener_IdDespacho(string lviaje)
        {
            string lIdDesp = ""; int i = 0;

            foreach (DataGridViewRow lRow in this.Dtg_Camiones.Rows)
            {
                if (lRow.Cells[0].Value != null)
                    if (lRow.Cells[0].Value.ToString() == "True")
                    {
                        if (lRow.Cells["codigo"].Value.ToString().Equals(lviaje))
                        {
                            lIdDesp = lRow.Cells["IdDespacho"].Value.ToString();
                        }
                    }
            }
            return lIdDesp;
        }


        private int PersisteRespuesta_INET(string lRes, string lPatente)
        {
            int lRespuesta = 0; string lSql = ""; Ws_TO.Ws_ToSoapClient lDal = new Ws_TO.Ws_ToSoapClient();
            string lXmlRes = ""; int lInicio = 0; int lFin = 0; string lIdPersistenciaINET = "";
            string TMETIP=""; string MOVSUCCOD=""; string TMECOD=""; string MOVNUMDOC=""; string DOCCOD="";
            string ATENUMREA=""; string Obs=""; DataSet lDts = new DataSet() ;
    //  ALTER  PROCEDURE [dbo].[SP_CRUD_RespuestaINET]  ")
    //@Id int,                  //@Patente varchar(10),             //@TMETIP	int,     //@MOVSUCCOD  int,
    //@TMECOD		int,        //@MOVNUMDOC	int,            //@DOCCOD		int,    //@ATENUMREA	int,
    //@Obs		varchar(max),  //@OPCION INT
            lXmlRes=lRes .Replace ("&amp;lt;","<") ;
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
                lSql=string.Concat ("SP_CRUD_RespuestaINET 0,'",lPatente,"','",TMETIP,"','",MOVSUCCOD,"','",TMECOD,"','",MOVNUMDOC,"','");
                lSql=string.Concat (lSql ,DOCCOD,"','",ATENUMREA,"','",Obs,"',1");
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


        private bool ValidaDatos()
        {
            bool lRes = true; string IdObras = ""; int i = 0; string lTmp = "";

            foreach (DataGridViewRow lRow in this.Dtg_Camiones .Rows)
            {
                if (lRow.Cells[0].Value != null)
                    if (lRow.Cells[0].Value.ToString() == "True")                        
                        {
                            IdObras = string.Concat(IdObras,  lRow.Cells["IdObra"].Value.ToString(), "|");                            
                        }                      
            }
            if (IdObras.Trim().Length > 1)
            {
                string[] lPartes = IdObras.Split(new Char[] { '|' });
                for (i = 0; i < lPartes.Length; i++)
                {
                    if (i == 0)
                    { lTmp = lPartes[i].ToString(); }
                    else
                    {
                        if (lPartes[i].ToString().Trim().Length > 0)
                            if (!lTmp.Equals(lPartes[i].ToString()))
                            {
                                lRes = false;
                            }
                    }
                }
                if (lRes == true)
                    mIdObraSel = lTmp;
                else
                    MessageBox.Show("Debe Seleccionar solo los viajes de una misma Obra para generar la guía de despacho, Revisar.", "Generación de Guía", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Debe Seleccionar algún viaje para realizar la generación de la Guía de despacho, Revisar.", "Generación de Guía", MessageBoxButtons.OK);
                lRes = false;
            }


            return lRes;
        }



          public string  ObtenerFechaActual(string  iTipoFormato )
          {
              string lRes ="";string lFecha=""; string lCar="";string vFecha = DateTime.Today.ToShortDateString();
        //Dim lRes As String = "", lFecha As String = ""
        //Dim vFecha As String = Now, lCar As String = ""
               string[] lPartes = null;
        //Dim lPartes() As String = Nothing
        try
        {
            lRes = String.Format("{0:dd/MM/yyyy}", vFecha);
            
            switch (iTipoFormato)
            {
                case "E":
                   lFecha = lRes.Substring(0, 10);
                    break;
                case "A":
                    if (lRes.IndexOf("/") > 0) // Then
                    {
                        lPartes = lRes.Substring(0, 10).Split(new Char[] { '/' });  //(new Char[] { '|' });
                        lFecha = String.Concat(lPartes[2].ToString(), "-", lPartes[1].ToString(), "-", lPartes[0].ToString());
                    }
                    if (lRes.IndexOf("-") > 0) // Then
                    {
                        lPartes = lRes.Substring(0, 10).Split(new Char[] { '-' }); ;
                        lFecha = String.Concat(lPartes[2].ToString(), "-", lPartes[1].ToString(), "-", lPartes[0].ToString());
                    }
                    break;
                //default:
                //    Console.WriteLine("Default case");
                //    break;
            }


        }
        catch (Exception exc)
        {
            MessageBox.Show(string.Concat ("Error de fecha: " , exc.Message.ToString ()));
        }
        //End Try
        //' MessageBox.Show("Retorno de la funcion ObtenerFechaActual con TipoFormato : " & iTipoFormato & " lRes=" & lFecha)
        return lFecha;

          }


            public  string ObtenerHoraActual() 
            {
                string lRes = ""; string vFecha = DateTime.Today.ToShortDateString();
                //Dim lRes As String = "",         //Dim vFecha As String = Now
                //'lRes = String.Format("{0:HH:MM:SS}", vFecha)

                lRes = vFecha.Substring (0, 8);
               // lRes = Right(vFecha, 8);
                return lRes;
            }

         private  Tipo_MovExistenciasDet   CargaObjMovExistenciaDet(string iCodProd , int  iTotalKgs , int  iPrecioCosto ,  int  iTotalCosto ) 
         {
        Tipo_MovExistenciasDet lObj=new Tipo_MovExistenciasDet ();

        try
        {
            //'Secuencia del detalle
            lObj.DMONUMSEC = "1";
            lObj.PRDCOD = iCodProd ;// '"63OGP1";
            lObj.PRDEXIPLA = "1109009";
            lObj.DMOPLACOD = "1109008";
            lObj.DMOCENCOD = "0";
            lObj.DMOITECOD = "0";
            lObj.DMOARECOD = "0";

            lObj.DMOCAN = string.Concat(iTotalKgs.ToString(), ".0000");// '"15523.0000"  '--Kilos
            lObj.DMOPREUNI = string.Concat(iPrecioCosto.ToString(), ".00");// ' "420.00"      'Precio Unitario COSTO
            lObj.DMOVALTOT = string.Concat(mTotalCosto.ToString(), ".00") ;//' "6519660.00"   '--Total
            lObj.INVMOV11 = "0.0000";
            lObj.INVMOV12 = "0.00";
            lObj.INVMOV13 = "0.00";
            lObj.INVMOV14 = "0.0000";
            lObj.INVMOV15 = "0.00";
            lObj.INVMOV16 = "0.0000";
            lObj.INVMOV17 = "0.0000";
        }
      catch (Exception exc)
        {
            lObj.ERR = exc.Message.ToString();
      }
        return lObj;
         }

        private  string   ObtenerCampo_MovNumDoc() 
        {
            string lSql=""; WsCrud .CrudSoapClient lDAL=new WsCrud.CrudSoapClient ();WsCrud .ListaDataSet lDts=new WsCrud.ListaDataSet ();
            string  lMovNumDoc="";
        //Dim lSql As String = "", lDAl As New WsCrud.CrudSoapClient, lDts As New WsCrud.ListaDataSet
        //Dim lMovNumDoc As Integer = 0

        //'       ALTER PROCEDURE [dbo].[SP_CRUD_LOG_WS_INET]
        //'@Opcion INT,                           '@Id int,                           '@IdDespachoCamion int,
        //'@PatenteCamion Varchar(50),            '@IdObra Int,                       '@XML_Enviado Varchar(max),
        //'@XML_Respuesta Varchar(max),           '@URL_WS Varchar(100),              '@Origen Varchar(30),
        //'@MOVNUMDOC int 

        lSql = "exec SP_CRUD_LOG_WS_INET 2,0,0,'',0,'','','','',0,'' ";
        lDts = lDAL.ListarAyudaSql(lSql);
        if ((lDts.MensajeError.Trim().Length == 0) && (lDts.DataSet.Tables.Count > 0 ))
            lMovNumDoc = lDts.DataSet.Tables[0].Rows[0][0].ToString();


        return lMovNumDoc;
        }

        private Tipo_MovExistenciasAll  CargaObjMovExistenciaAll(string  iObs1 ) 
        {
            Tipo_MovExistenciasAll lObj=new Tipo_MovExistenciasAll ();
        //Dim lObj As New MovExistenciasAll

        //'<SDT_MOVEXISTENCIASALL xmlns=&quot;http://www.informat.cl/ws&quot;>
        //'        <SDT_MOVEXISTENCIASALL.MOVIMIENTO>
        //'	<TMETIP>1</TMETIP>
        //'	<TMECOD>30</TMECOD>
        //'	<TMEOTRMOD>1</TMEOTRMOD>
        //'	<MOVSUCCOD>1</MOVSUCCOD>
        //'	<MOVNUMDOC>99509</MOVNUMDOC>   --Que valor debe ir aqui??? 0
        //'	<MOVFECDOC>2013-07-03</MOVFECDOC>
        //'	<MOVFECDIG>2013-07-04</MOVFECDIG>
        //'	<MOVHORDIG>02:15:36</MOVHORDIG>
        //'	<MOVREFDOC>11019</MOVREFDOC>	--Opcional enviaremos 0
        //'	<MOVBODCOD>105</MOVBODCOD>		--Bodega 105
        //'	<MOVBODSUC>1</MOVBODSUC>		--Sucursal 1
        //'	<MOVGLO1>Obra OGP-1</MOVGLO1>
        //'	<MOVGLO2/>
        //'	<MOVSIS>1</MOVSIS>
        //'	<MOVULTSEC>1</MOVULTSEC>

        //'      MessageBox.Show("Al Inicio CargaObjMovExistenciaAll")
        try
        {

            //'Indica el tipo movimiento (1=Entrada,2=salida)
            lObj.TMETIP = "1";  // 'Entrada a productos terminados
            //'Indica el código del movimiento (T)
            lObj.TMECOD = "30";
            //'Código de sucursal (T)
            lObj.MOVSUCCOD = mCodigoSucursal_INET;// '"1"    '1casa matriz stgo  2 calama
            //'Numero de movimiento  debe ser un correlativo y se debe aumentar en uno actualmente va en 90001
            //'      MessageBox.Show("Antes de ObtenerCampo_MovNumDoc.ToString ")
            mMOVNUMDOC = ObtenerCampo_MovNumDoc();

            lObj.MOVNUMDOC = mMOVNUMDOC.ToString () ;//   '"90002"
            //'Fecha del movimiento (aaaa-mm-dd)
            //'  MessageBox.Show("ANtes de ObtenerFechaActual ")
            lObj.MOVFECDOC = ObtenerFechaActual("A") ; //'  "2013-08-19"
            //'   MessageBox.Show("Fechas :" & lObj.MOVFECDOC)
            //'Fecha de digitación del movimiento (aaaa-mm-dd)
            lObj.MOVFECDIG = ObtenerFechaActual("A") ; //'  "2013-08-19"
            //'Hora del movimiento (hh:mm:ss)
            lObj.MOVHORDIG = ObtenerHoraActual();// ' "21:59:59"
            //'código de bodega (T)
            //'lObj.MOVBODCOD = "1"  '105 para santiag0  69 para calama
            lObj.MOVBODCOD = mCodigoBodega;// ' "105"  '105 para santiag0  69 para calama

            //'código de sucursal (T)
            lObj.MOVBODSUC = mCodigoSucursal_INET;// '"1"  ' '1casa matriz stgo  2 calama
            //'Glosa del movimiento (opcional)
            lObj.MOVGLO1 = iObs1; //'"PRUEBAS DE INTEGRACION";
            //'Glosa del movimiento (opcional)
            lObj.MOVGLO2 = "";
            //'Sistema (1=Existencias,4=importaciones),por defecto =1
            lObj.MOVSIS = "1";
            //'Cantidad de líneas del detalle
            lObj.MOVULTSEC = "1";
            //'Valor total sumando todas las líneas
            lObj.MOVVALTOT = String.Concat(mTotalCosto, ".00"); // ' '"6519660.00"
        }
        catch (Exception exc)
        {
            lObj.ERR = exc.Message.ToString();
        }
        return lObj;
        }


        public string CreaXmlEntradaProductosTErminados_INET(Tipo_MovExistencias  iObj ) 
        {
            string lRes=""; Tipo_EntDoc lEntDoc=new Tipo_EntDoc (); int i=0;
        //Dim lRes As String, lEntDoc As New Tipo_EntDoc, i As Integer = 0
           Tipo_DetDoc lDetDoc=new Tipo_DetDoc (); Tipo_ResumenDoc lResumenDoc=new Tipo_ResumenDoc ();
        //Dim lDetDoc As New Tipo_DetDoc, lResumenDoc As New Tipo_ResumenDoc
            string lXML="";string lRes1="";string lXmlFinal="";
        //Dim lXML As String = "", lRes1 As String = "", lXmlFinal As String = ""
            // \"
        //lRes = String.Concat("<SDT_TRANSPORTE xmlns=" & Chr(34) & "http://www.informat.cl/ws" & Chr(34) & ">" & vbCrLf
            lRes = String.Concat("<SDT_TRANSPORTE xmlns=\"http://www.informat.cl/ws\">", Environment.NewLine);
        lRes = String.Concat(lRes, "<ACCION>ins</ACCION> ", Environment.NewLine  );
        lRes = String.Concat(lRes, " <XML>",  Environment.NewLine  );
        lXML = String.Concat(lXML, "	<SDT_MOVEXISTENCIASALL xmlns=&quot;http://www.informat.cl/ws&quot;>", Environment.NewLine  );
        lXML = String.Concat(lXML, "  <SDT_MOVEXISTENCIASALL.MOVIMIENTO> ", Environment.NewLine  );

        lXML = String.Concat(lXML, "  	<TMETIP>", iObj.ExistenciasAll.TMETIP.ToString(), "</TMETIP> ", Environment.NewLine  );

        lXML = String.Concat(lXML, "  	<TMECOD>", iObj.ExistenciasAll.TMECOD.ToString(), "</TMECOD> ", Environment.NewLine  );
        lXML = String.Concat(lXML, "  	<MOVSUCCOD>", iObj.ExistenciasAll.MOVSUCCOD.ToString(), "</MOVSUCCOD> ", Environment.NewLine  );
        lXML = String.Concat(lXML, "  	<MOVNUMDOC>", iObj.ExistenciasAll.MOVNUMDOC.ToString(), "</MOVNUMDOC> ", Environment.NewLine  );
        lXML = String.Concat(lXML, "  	<MOVFECDOC>", iObj.ExistenciasAll.MOVFECDOC.ToString(), "</MOVFECDOC> ", Environment.NewLine  );
        //'lXML = String.Concat(lXML, "  	<MOVFECDOC>", "2013-12-31", "</MOVFECDOC> ", vbCrLf)
        lXML = String.Concat(lXML, "  	<MOVFECDIG>", iObj.ExistenciasAll.MOVFECDIG.ToString(), "</MOVFECDIG>  ", Environment.NewLine  );
        lXML = String.Concat(lXML, "  	<MOVHORDIG>", iObj.ExistenciasAll.MOVHORDIG.ToString(), "</MOVHORDIG>  ", Environment.NewLine  );
        lXML = String.Concat(lXML, "  	<MOVBODCOD>", iObj.ExistenciasAll.MOVBODCOD.ToString(), "</MOVBODCOD> ", Environment.NewLine  );
        lXML = String.Concat(lXML, "  	<MOVBODSUC>", iObj.ExistenciasAll.MOVBODSUC.ToString(), "</MOVBODSUC> ", Environment.NewLine  );
        lXML = String.Concat(lXML, "  	<MOVGLO1>", iObj.ExistenciasAll.MOVGLO1.ToString(), "</MOVGLO1> ", Environment.NewLine  );
        lXML = String.Concat(lXML, "  	<MOVGLO2/> ", Environment.NewLine  );
        lXML = String.Concat(lXML, "  	<MOVSIS>", iObj.ExistenciasAll.MOVSIS.ToString(), "</MOVSIS> ", Environment.NewLine  );
        lXML = String.Concat(lXML, "  	<MOVULTSEC>", iObj.ExistenciasAll.MOVULTSEC.ToString(), "</MOVULTSEC>", Environment.NewLine  );

        lXML = String.Concat(lXML, "  	<DETALLE>", Environment.NewLine  );
        lXML = String.Concat(lXML, "  	            <SDT_MOVEXISTENCIASALL.MOVIMIENTO.DET_MOVTO>", Environment.NewLine  );
        lXML = String.Concat(lXML, "  	            <DMONUMSEC>", iObj.ExistenciasDet.DMONUMSEC.ToString(), "</DMONUMSEC>", Environment.NewLine  );

        lXML = String.Concat(lXML, "  	            <PRDCOD>", iObj.ExistenciasDet.PRDCOD.ToString(), "</PRDCOD>", Environment.NewLine  );
        lXML = String.Concat(lXML, "  	            <PRDEXIPLA>", iObj.ExistenciasDet.PRDEXIPLA.ToString(), "</PRDEXIPLA>", Environment.NewLine  );
        lXML = String.Concat(lXML, "  	            <DMOPLACOD>", iObj.ExistenciasDet.DMOPLACOD.ToString(), "</DMOPLACOD>", Environment.NewLine  );
        lXML = String.Concat(lXML, "  	            <DMOCENCOD>", iObj.ExistenciasDet.DMOCENCOD.ToString(), "</DMOCENCOD>", Environment.NewLine  );
        lXML = String.Concat(lXML, "  	            <DMOITECOD>", iObj.ExistenciasDet.DMOITECOD.ToString(), "</DMOITECOD>", Environment.NewLine  );

        lXML = String.Concat(lXML, "  	            <DMOARECOD>", iObj.ExistenciasDet.DMOARECOD.ToString(), "</DMOARECOD>", Environment.NewLine  );
        lXML = String.Concat(lXML, "  	            <DMOCAN>", iObj.ExistenciasDet.DMOCAN.ToString(), "</DMOCAN>", Environment.NewLine  );
        lXML = String.Concat(lXML, "  	            <DMOPREUNI>", iObj.ExistenciasDet.DMOPREUNI.ToString(), "</DMOPREUNI>", Environment.NewLine  );
        lXML = String.Concat(lXML, "  	            <DMOVALTOT>", iObj.ExistenciasDet.DMOVALTOT.ToString(), "</DMOVALTOT>", Environment.NewLine  );
        lXML = String.Concat(lXML, "  	            <INVMOV11>", iObj.ExistenciasDet.INVMOV11.ToString(), "</INVMOV11>", Environment.NewLine  );
        lXML = String.Concat(lXML, "  	            <INVMOV12>", iObj.ExistenciasDet.INVMOV12.ToString(), "</INVMOV12>", Environment.NewLine  );
        lXML = String.Concat(lXML, "  	            <INVMOV13>", iObj.ExistenciasDet.INVMOV13.ToString(), "</INVMOV13>", Environment.NewLine  );
        lXML = String.Concat(lXML, "  	            <INVMOV14>", iObj.ExistenciasDet.INVMOV14.ToString(), "</INVMOV14>", Environment.NewLine  );
        lXML = String.Concat(lXML, "  	            <INVMOV15>", iObj.ExistenciasDet.INVMOV15.ToString(), "</INVMOV15>", Environment.NewLine  );
        lXML = String.Concat(lXML, "  	            <INVMOV16>", iObj.ExistenciasDet.INVMOV16.ToString(), "</INVMOV16>", Environment.NewLine  );
        lXML = String.Concat(lXML, "  	            <INVMOV17>", iObj.ExistenciasDet.INVMOV17.ToString(), "</INVMOV17>", Environment.NewLine  );
        lXML = String.Concat(lXML, "  	  </SDT_MOVEXISTENCIASALL.MOVIMIENTO.DET_MOVTO>", Environment.NewLine  );
        lXML = String.Concat(lXML, "</DETALLE> ", Environment.NewLine  );
        lXML = String.Concat(lXML, "<MOVVALTOT>", iObj.ExistenciasAll.MOVVALTOT.ToString(), "</MOVVALTOT> ", Environment.NewLine  );
        lXML = String.Concat(lXML, "</SDT_MOVEXISTENCIASALL.MOVIMIENTO> ", Environment.NewLine  );
        lXML = String.Concat(lXML, "</SDT_MOVEXISTENCIASALL> ", Environment.NewLine  );

        lRes1 = String.Concat(lRes1, "</XML>", Environment.NewLine  );
        lRes1 = String.Concat(lRes1, "</SDT_TRANSPORTE>", Environment.NewLine  );

        //'cambiamos los caracteres 
        //'        NOTA: Se realizó un encoding al XML con transporte, por lo cual:
        //'el signo < se reemplazó por &lt; 
        //'el signo > se reemplazó por &gt;
        lXML = lXML.Replace("<", "&lt;");
        lXML = lXML.Replace(">", "&gt;");

        lXmlFinal = string.Concat (lRes, lXML , lRes1);
        return lXmlFinal;

        }


        public  Tipo_MovExistencias  CargaObjEntradaBodegaProdTerm_INET(string  iViajesCargados , int  iIdObra , int  iIdDespachoCamion ) 
    {
        Tipo_MovExistencias lRes=new Tipo_MovExistencias (); Tipo_MovExistenciasAll  lExAll=new Tipo_MovExistenciasAll ();
        Tipo_MovExistenciasDet lExDet=new Tipo_MovExistenciasDet ();
        //Dim lRes As New MovExistencias, lExAll As New MovExistenciasAll
        //Dim lExDet As New MovExistenciasDet

        //ObtenerDatosObra(iIdObra.ToString());


        lExDet = CargaObjMovExistenciaDet(mCodigoINET, mKilosCargados, mPrecioCostoKilo, mTotalCosto);
        lExAll = CargaObjMovExistenciaAll(mViajesCargados);

        lRes.ExistenciasAll = lExAll;

        lRes.ExistenciasDet = lExDet;

        return lRes;

        }


         private Tipo_RefDoc  CargaObjRefDoc(string  iNombreObra , String iViajesCargados ) 
         {
             Tipo_RefDoc lRefDoc=new Tipo_RefDoc ();
            //Dim lRefDoc As New Tipo_RefDoc

            lRefDoc.ObsUno = string.Concat ("Pruebas de Facturacion por Camión ", iNombreObra);
            lRefDoc.ObsDos = iViajesCargados;

            return lRefDoc;
         }


           private Tipo_Cliente CargaObjCliente(string  iRut) 
           {
               Tipo_Cliente lCliente=new Tipo_Cliente ();Tipo_Identificacion lIdentificacion=new Tipo_Identificacion ();
        //Dim lCliente As New Tipo_Cliente, lIdentificacion As New Tipo_Identificacion
               Tipo_Facturacion lFacturacion=new Tipo_Facturacion ();Tipo_DireccionDespacho lDirDesp=new Tipo_DireccionDespacho ();
        //Dim lFacturacion As New TipoFacturacion, lDirDesp As New Tipo_DireccionDespacho

        //'Datos de la entidad Identificación el formato el sin puntos y con digito 
        //'Ejemplo 12669191-2
        lIdentificacion.IdCliente = iRut.Substring(0, iRut.Length - 2);   //' sin el digito Verificador
        //'lIdentificacion.IdCliente = "70"
        lIdentificacion.Secuencia = "0";
        lCliente.Identificacion = lIdentificacion;

        //'Estos datos iran en blanco ya que el cliente no es Nuevo, se deben ingresar solo para clientes
        //' nuevos
        lDirDesp.Direccion = "";
        lDirDesp.Comuna = "";
        lDirDesp.Ciudad = "";
        lCliente.DirDespacho = lDirDesp;


        //'Datos de la entidad FActuracion que son fijos
        lFacturacion.Moneda = "1";
        lFacturacion.Tasa = "1.0000";
        lFacturacion.CondVenta = "2";
        lFacturacion.Origen = "0";
        lFacturacion.DocAGenerar = mCodigoGuiaINET;  //' "330"  '' se debe leer de la Obra 
        lFacturacion.DocRef = "0";
        lFacturacion.NroDoc = "0";
        lFacturacion.Estado = "0";
        lFacturacion.Bodega_Salida = mCodigoBodega; // ' 105 ' mBodegaSalida.ToString  '105 SAntiago 69 Calama      

        //if (mCodigoGuiaINET.Equals("330"))
        //    lFacturacion.Bodega_Entrada = mCodigoBodegaEntrada; //"90"; //'mBodegaEntrada ' "90"  cuando es 330 y vacio para otro caso
        //else
        //    lFacturacion.Bodega_Entrada = ""; //' "90"  cuando es 330 y vacio para otro caso
        //Por cambio a Guia de despacho electronica
            if (mCodigoGuiaINET.Equals("350"))
                lFacturacion.Bodega_Entrada = mCodigoBodegaEntrada; //"90"; //'mBodegaEntrada ' "90"  cuando es 330 y vacio para otro caso
            else
                lFacturacion.Bodega_Entrada = ""; //' "90"  cuando es 330 y vacio para otro caso


            //definicion entregada Por lGallardo con fecha 21-01-2019
            if ((mCodigoBodega == "105") || (mCodigoBodega == "501"))
                lFacturacion.Bodega_Entrada = "90";
            else
                lFacturacion.Bodega_Entrada = "80";
        

        lFacturacion.IdVendedor = "50234350";
        lFacturacion.Sucursal_Cod = mCodigoSucursal_INET; // ' "1" ' mSucursalCod.ToString  '1 para casa Matriz y 2 Calama
        lFacturacion.ListaPrecio_Cod = "0";
        lFacturacion.Fecha_Atencion = ObtenerFechaActual("A"); //' "2013-06-01" ' ObtenerFechaActual()
        lFacturacion.Fecha_Documento = ObtenerFechaActual("A"); //'"2013-06-01" '  ObtenerFechaActual()
        lCliente.Facturacion = lFacturacion;
        return lCliente;
        }

        private List< Tipo_Items>  CargaObjItem() 
        {
            Tipo_Items lItem =new Tipo_Items (); List< Tipo_Items>   lListaItems=new List<Tipo_Items> ();
        //Dim lItem As New Tipo_Items, lListaItems As New List(Of Tipo_Items)
            Tipo_Facturacion lFacturacion = new Tipo_Facturacion(); Tipo_DireccionDespacho lDirDesp = new Tipo_DireccionDespacho();
        //Dim lFacturacion As New TipoFacturacion, lDirDesp As New Tipo_DireccionDespacho

        lItem.NumItem = "1";
        lItem.PrecioRef = mPrecioRef.ToString();// ' "460.0000"
        lItem.Cantidad = String.Concat(mKilosCargados, ".0000"); // ' "292.0000"
        lItem.Producto_Vta = mCodigoINET; // '"63OGP12"
        mTotalNeto = mPrecioRef * mKilosCargados;
        lItem.TotalDocLin = String.Concat(mTotalNeto, ".00"); //  ' "134320.00"

        //' mTotalNeto = Val(lItem.TotalDocLin)

        lListaItems.Add(lItem);
        return lListaItems;
        }


          public Tipo_DocVentaExt CargaObjEntradaINET(string  iViajesCargados ,int  iIdObra , int  iIdDespachoCamion ) 
          {
              Tipo_DocVentaExt lRes =new Tipo_DocVentaExt (); Tipo_EntDoc lEntDoc=new Tipo_EntDoc ();
        //Dim lRes As New Tipo_DocVentaExt, lEntDoc As New Tipo_EntDoc
              Tipo_DetDoc lDetDoc=new Tipo_DetDoc (); Tipo_ResumenDoc  lResumenDoc=new Tipo_ResumenDoc ();
        //Dim lDetDoc As New Tipo_DetDoc, lResumenDoc As New Tipo_ResumenDoc

                 lEntDoc.RefDoc = CargaObjRefDoc(mNombreObra, iViajesCargados);
                lEntDoc.Cliente = CargaObjCliente(mRutObra);
                lRes.EntDoc = lEntDoc;

                lDetDoc.Items = CargaObjItem();
                lRes.DetDoc = lDetDoc.Items;
                lRes.ResumenDoc = CargaObjResumenDoc(mTotalNeto);

                return lRes;

          }

        private Tipo_ResumenDoc CargaObjResumenDoc(int  iTotal ) 
        {
        //Dim lRes As New Tipo_ResumenDoc, lIva As Integer = 0, lTotalGen As Integer = 0
         Tipo_ResumenDoc lRes=new Tipo_ResumenDoc (); int  lIva=0; int  lTotalGen=0;

        //'Datos de la entidad ResumenDoc 
        lRes.TotalNeto = iTotal.ToString();//   '"6515100.00"
        lRes.CodigoDescuento = "0";
        lRes.TotalDescuento = "0.00";
        lIva = (iTotal * 19) / 100;

        lRes.TotalIVA = lIva.ToString () ;// '"1237869.00"
        lRes.TotalOtrosImpuestos = "0.00";

        lTotalGen = iTotal + lIva;
        lRes.TotalDoc = lTotalGen.ToString (); // '"7752969.00"

        return lRes;
        }


        public String  CreaXmlEntradaINET(Tipo_DocVentaExt  iObj ) 
        {
            string lRes="";Tipo_EntDoc lEntDoc=new Tipo_EntDoc (); int i=0;
        //Dim lRes As String, lEntDoc As New Tipo_EntDoc, i As Integer = 0
            Tipo_DetDoc lDetDoc=new Tipo_DetDoc ();Tipo_ResumenDoc  lResumenDoc=new Tipo_ResumenDoc ();
        //Dim lDetDoc As New Tipo_DetDoc, lResumenDoc As New Tipo_ResumenDoc

        //lRes = "<SDT_DocVentaExt xmlns="http://www.informat.cl/ws" & Chr(34) & ">" & vbCrLf
        lRes = String.Concat("<SDT_DocVentaExt xmlns=\"http://www.informat.cl/ws\">", Environment.NewLine);
        lRes = String.Concat(lRes, " <EncDoc>", Environment.NewLine);
        lRes = String.Concat(lRes, " <RefDoc>", Environment.NewLine);
        lRes = String.Concat(lRes, "  <NroRefCliente>", iObj.EntDoc.RefDoc.NroRefCliente, " </NroRefCliente> ", Environment.NewLine);
        lRes = String.Concat(lRes, "  <Modulo>", iObj.EntDoc.RefDoc.Modulo, "</Modulo> ", Environment.NewLine);
        lRes = String.Concat(lRes, "  <ObsUno>", iObj.EntDoc.RefDoc.ObsUno, "</ObsUno>", Environment.NewLine);
        lRes = String.Concat(lRes, "  <ObsDos>", iObj.EntDoc.RefDoc.ObsDos, "</ObsDos>", Environment.NewLine);
        lRes = String.Concat(lRes, "  <ObsTre>", iObj.EntDoc.RefDoc.ObsTre, "</ObsTre>", Environment.NewLine);
        lRes = String.Concat(lRes, "  <NroOrdCom>", iObj.EntDoc.RefDoc.NroOrdCom, "</NroOrdCom>", Environment.NewLine);
        lRes = String.Concat(lRes, " </RefDoc>", Environment.NewLine);
        lRes = String.Concat(lRes, "<Cliente>", Environment.NewLine);
        lRes = String.Concat(lRes, "<Identificacion>", Environment.NewLine);
        lRes = String.Concat(lRes, "<IdCliente>", iObj.EntDoc.Cliente.Identificacion.IdCliente, "</IdCliente>", Environment.NewLine);
        lRes = String.Concat(lRes, "<Secuencia>", iObj.EntDoc.Cliente.Identificacion.Secuencia, "</Secuencia>", Environment.NewLine);
        lRes = String.Concat(lRes, "</Identificacion>", Environment.NewLine);

        lRes = String.Concat(lRes, "<DireccionDespacho>", Environment.NewLine);
        lRes = String.Concat(lRes, "<Direccion>", iObj.EntDoc.Cliente.DirDespacho.Direccion, "</Direccion>", Environment.NewLine);
        lRes = String.Concat(lRes, "<Comuna>", iObj.EntDoc.Cliente.DirDespacho.Comuna, "</Comuna>", Environment.NewLine);
        lRes = String.Concat(lRes, "<Ciudad>", iObj.EntDoc.Cliente.DirDespacho.Ciudad, "</Ciudad>", Environment.NewLine);
        lRes = String.Concat(lRes, "</DireccionDespacho>", Environment.NewLine);
        lRes = String.Concat(lRes, "<Facturacion>", Environment.NewLine);
        lRes = String.Concat(lRes, "<Moneda>", iObj.EntDoc.Cliente.Facturacion.Moneda, "</Moneda>", Environment.NewLine);
        lRes = String.Concat(lRes, "<Tasa>", iObj.EntDoc.Cliente.Facturacion.Tasa, "</Tasa>", Environment.NewLine);
        lRes = String.Concat(lRes, "<CondVenta>", iObj.EntDoc.Cliente.Facturacion.CondVenta, "</CondVenta>", Environment.NewLine);
        lRes = String.Concat(lRes, "<Origen>", iObj.EntDoc.Cliente.Facturacion.Origen, "</Origen>", Environment.NewLine);
        lRes = String.Concat(lRes, "<DocAGenerar>", iObj.EntDoc.Cliente.Facturacion.DocAGenerar, "</DocAGenerar>", Environment.NewLine);
        lRes = String.Concat(lRes, "<NroDoc>", iObj.EntDoc.Cliente.Facturacion.NroDoc, "</NroDoc>", Environment.NewLine);
        lRes = String.Concat(lRes, "<Estado>", iObj.EntDoc.Cliente.Facturacion.Estado, "</Estado>", Environment.NewLine);
        lRes = String.Concat(lRes, "<Bodega_Salida>", iObj.EntDoc.Cliente.Facturacion.Bodega_Salida, "</Bodega_Salida>", Environment.NewLine);
        lRes = String.Concat(lRes, "<Bodega_Entrada>", iObj.EntDoc.Cliente.Facturacion.Bodega_Entrada, "</Bodega_Entrada>", Environment.NewLine);
        lRes = String.Concat(lRes, "<IdVendedor>", iObj.EntDoc.Cliente.Facturacion.IdVendedor, "</IdVendedor>", Environment.NewLine);
        lRes = String.Concat(lRes, "<Sucursal_Cod>", iObj.EntDoc.Cliente.Facturacion.Sucursal_Cod, "</Sucursal_Cod>", Environment.NewLine);
        lRes = String.Concat(lRes, "<ListaPrecio_Cod>", iObj.EntDoc.Cliente.Facturacion.ListaPrecio_Cod, "</ListaPrecio_Cod>", Environment.NewLine);
        lRes = String.Concat(lRes, "<Fecha_Atencion>", iObj.EntDoc.Cliente.Facturacion.Fecha_Atencion, "</Fecha_Atencion>", Environment.NewLine);
        lRes = String.Concat(lRes, "<Fecha_Documento>", iObj.EntDoc.Cliente.Facturacion.Fecha_Documento, "</Fecha_Documento>", Environment.NewLine);
        //'SE AGREGA DATOS DEL TRANSPORTISTA Y PATENTE 
        lRes = String.Concat(lRes, " <Facturacion_ext> ");
        lRes = String.Concat(lRes, "        <SDT_DocVentaExt.EncDoc.Cliente.Facturacion.FacExt_Item>" , Environment.NewLine);
        lRes = String.Concat(lRes, "                 <Facturacion_opcion>1</Facturacion_opcion>", Environment.NewLine);
        lRes = String.Concat(lRes, "                <Facturacion_datos>", mTransportista, "</Facturacion_datos>", Environment.NewLine);
        lRes = String.Concat(lRes, "        </SDT_DocVentaExt.EncDoc.Cliente.Facturacion.FacExt_Item>", Environment.NewLine);
        lRes = String.Concat(lRes, "       <SDT_DocVentaExt.EncDoc.Cliente.Facturacion.FacExt_Item>", Environment.NewLine);
        lRes = String.Concat(lRes, "                <Facturacion_opcion>2</Facturacion_opcion>", Environment.NewLine);
        lRes = String.Concat(lRes, "                <Facturacion_datos>", mPatenteCamion, "</Facturacion_datos>", Environment.NewLine);
        lRes = String.Concat(lRes, "        </SDT_DocVentaExt.EncDoc.Cliente.Facturacion.FacExt_Item>", Environment.NewLine);
        lRes = String.Concat(lRes, "</Facturacion_ext> ", Environment.NewLine);
        lRes = String.Concat(lRes, "</Facturacion>", Environment.NewLine);
        lRes = String.Concat(lRes, "</Cliente>", Environment.NewLine);

        lRes = String.Concat(lRes, "</EncDoc>", Environment.NewLine);
        lRes = String.Concat(lRes, "<DetDoc>", Environment.NewLine);
        lRes = String.Concat(lRes, "<Items>", Environment.NewLine);

       for (i = 0; i< iObj.DetDoc.Count ;i++)
       {
           lRes = String.Concat(lRes, "<SDT_DocVentaExt.DetDoc.Item>", Environment.NewLine);
            lRes = String.Concat(lRes, "<NumItem>", iObj.DetDoc[i].NumItem, "</NumItem>", Environment.NewLine);
            lRes = String.Concat(lRes, "<Producto>", Environment.NewLine);
            lRes = String.Concat(lRes, "<Producto_Vta>", iObj.DetDoc[i].Producto_Vta, "</Producto_Vta>", Environment.NewLine);
            lRes = String.Concat(lRes, "</Producto>", Environment.NewLine);
            lRes = String.Concat(lRes, "<PrecioRef>", iObj.DetDoc[i].PrecioRef, "</PrecioRef>", Environment.NewLine);
            lRes = String.Concat(lRes, "<Cantidad>", iObj.DetDoc[i].Cantidad, "</Cantidad>", Environment.NewLine);
            lRes = String.Concat(lRes, "<TotalDocLin>", iObj.DetDoc[i].TotalDocLin, "</TotalDocLin>", Environment.NewLine);
            lRes = String.Concat(lRes, "</SDT_DocVentaExt.DetDoc.Item>", Environment.NewLine);
       }


        lRes = String.Concat(lRes, "</Items>", Environment.NewLine);
        lRes = String.Concat(lRes, "</DetDoc>", Environment.NewLine);
        lRes = String.Concat(lRes, "<ResumenDoc>", Environment.NewLine);
        lRes = String.Concat(lRes, "<TotalNeto>", iObj.ResumenDoc.TotalNeto, "</TotalNeto>", Environment.NewLine);
        lRes = String.Concat(lRes, "<CodigoDescuento>", iObj.ResumenDoc.CodigoDescuento, "</CodigoDescuento>", Environment.NewLine);
        lRes = String.Concat(lRes, "<TotalDescuento>", iObj.ResumenDoc.TotalDescuento, "</TotalDescuento>", Environment.NewLine);
        lRes = String.Concat(lRes, "<TotalIVA>", iObj.ResumenDoc.TotalIVA, "</TotalIVA>", Environment.NewLine);
        lRes = String.Concat(lRes, "<TotalOtrosImpuestos>", iObj.ResumenDoc.TotalOtrosImpuestos, "</TotalOtrosImpuestos>", Environment.NewLine);
        lRes = String.Concat(lRes, "<TotalDoc>", iObj.ResumenDoc.TotalDoc, "</TotalDoc>", Environment.NewLine);
        lRes = String.Concat(lRes, "</ResumenDoc>", Environment.NewLine);
        lRes = String.Concat(lRes, "</SDT_DocVentaExt>", Environment.NewLine);

        return lRes;

        }


        private void ObtenerDatosObra(string iObra, string iDespachosCam)
    {
        string lSql="";WsCrud .CrudSoapClient lDal=new WsCrud.CrudSoapClient ();
        WsCrud.ListaDataSet lDts = new WsCrud.ListaDataSet(); int i = 0;

        //Dim lSql As String = "", lDAl As New WsCrud.CrudSoapClient, lDts As New WsCrud.ListaDataSet
        //'CREATE PROCEDURE [dbo].[SP_CRUD_OBRA]
        //'@Id int,                       '@Nombre varchar(100) ,                     '@Dir varchar(255) ,            
        //'@Encargado nvarchar(50) ,      '@Telefono nvarchar(15) ,                   '@TipoObra nvarchar(1) , 
        //'@Obs varchar(100),             '@Estado nvarchar(20) ,                     '@UsuarioCrea int , 
        //'@MovilSup nvarchar(15) ,       '@NroContrato nvarchar(15) ,                '@OC nvarchar(15) ,
        //'@PesoMaxObra real ,            '@PesoMaxIT int ,                           '@SiglaObra varchar(5) ,
        //'@Cliente varchar(500) ,        '@Sucursal varchar(100) ,                   '@CentroCosto varchar(100) ,
        //'@Codigo_INET varchar(100) ,    '@CodigoGuia_INET varchar(100),             '@RUT varchar(15),
        //'@OPCION int 

        lSql = string.Concat ("exec SP_CRUD_OBRA " , iObra , ",'','','','','','','',0,'','','',0,0,'','','','','','','','','','',2 ");
        lDts = lDal.ListarAyudaSql(lSql);
        if ((lDts.MensajeError.Trim().Length == 0) &&   (lDts.DataSet.Tables.Count > 0 ))
        {
            mNombreObra = lDts.DataSet.Tables[0].Rows[0]["Nombre"].ToString();
            mRutObra = lDts.DataSet.Tables[0].Rows[0]["Rutcliente"].ToString();
            mCodigoINET = lDts.DataSet.Tables[0].Rows[0]["Codigo_INET"].ToString();// ' "63OGP12"
            mCodigoGuiaINET = lDts.DataSet.Tables[0].Rows[0]["CodigoGuia_INET"].ToString();// ' "330 - 331 "
        }
        //' MessageBox.Show("Id Obra: " & iObra & " - CodigoINET: " & mCodigoINET)
        //'Obtenemos el precio de referencia
        //'CREATE PROCEDURE [dbo].[SP_CRUD_SERVICIOS_OBRA]
        //'@Id int,        '@IdObra int,                  '@Servicio VARCHAR(50),   '@Importe int,   
        //'@IdUsuario int, '@NombreUsuario VARCHAR(50),   '@OPCION INT 

        string  lTmp  = "";
        if (mSucursal.Equals("Stgo") == true) 
            lTmp = "Santiago";
        else
            lTmp = "Calama";
        

        lSql =string.Concat ( "exec SP_CRUD_SERVICIOS_OBRA 0," , iObra , ",'" , lTmp , "',0,0,'','',3 ");
        lDts = lDal.ListarAyudaSql(lSql);
        if ((lDts.MensajeError.Trim().Length == 0) && (lDts.DataSet.Tables.Count > 0))
             {
            mPrecioRef = int.Parse (lDts.DataSet.Tables[0].Rows[0]["ImporteServicios"].ToString ());
            mPrecioCostoKilo = int.Parse (lDts.DataSet.Tables[0].Rows[0]["PrecioCostoKg"].ToString ());
             }

        string[] lPartes = iDespachosCam.Split(new Char[] { ',' });
        mKilosCargados = 0;

        for (i = 0;i< lPartes.Length; i++)
        {
            if (lPartes[i].ToString().Length > 1)
            {
                mIdDespachoCamion = int.Parse(lPartes[i].ToString());
                //'Leemos de la base de datos los kilos cargados en el camión  a partir del IdCamion en DespachoCamion
                lSql = string.Concat("exec SP_DESPACHO_CAMION ", mIdDespachoCamion, ",'','','','','','','','','','','',12 ");
                lDts = lDal.ListarAyudaSql(lSql);
                if ((lDts.MensajeError.Trim().Length == 0) && (lDts.DataSet.Tables.Count > 0))
                {
                    mKilosCargados = mKilosCargados+int.Parse(lDts.DataSet.Tables[0].Rows[0][0].ToString());
                }
            }
        }
     
        mTotalCosto = mKilosCargados * mPrecioCostoKilo;

       //Obtenemos el codigo de la bodega de Salida
        lSql = string.Concat ( "exec SP_DESPACHO_CAMION 0,'','','','','','','','','CodigoBodega','" , mSucursal , "','',13 ");
        lDts = lDal.ListarAyudaSql(lSql);
        if ((lDts.MensajeError.Trim().Length == 0) && (lDts.DataSet.Tables.Count > 0))
        {
            mCodigoBodega = lDts.DataSet.Tables[0].Rows[0]["Par2"].ToString();
        }

        //Obtenemos el codigo de la bodega de Entrada
        lSql = string.Concat("exec SP_DESPACHO_CAMION 0,'','','','','','','','','CodigoBodegaEntrada','", mSucursal, "','',13 ");
        lDts = lDal.ListarAyudaSql(lSql);
        if ((lDts.MensajeError.Trim().Length == 0) && (lDts.DataSet.Tables.Count > 0))
        {
            mCodigoBodegaEntrada = lDts.DataSet.Tables[0].Rows[0]["Par2"].ToString();
        }
        

        string  lSucursal  = "";
        if (mSucursal.ToUpper().ToString().Equals("STGO"))
                {               lSucursal = "CasaMatriz";       }
        if (mSucursal.ToUpper().ToString().Equals("CALAMA"))
                { lSucursal = "Calama";         }

        //'Leemos de la base de datos los kilos cargados en el camión  a partir del IdCamion en DespachoCamion
        lSql = string.Concat ("exec SP_DESPACHO_CAMION 0,'','','','','','','','','CodigoSucursal','" , lSucursal , "','',13 ");
        lDts = lDal.ListarAyudaSql(lSql);
        if ((lDts.MensajeError.Trim().Length == 0)  &&  (lDts.DataSet.Tables.Count > 0))
                    {  mCodigoSucursal_INET = lDts.DataSet.Tables[0].Rows[0]["Par2"].ToString() ; }

        //'Leemos los datos del Transportista y patemte del camión  a partir del IdCamion en DespachoCamion
        lSql = string.Concat ("exec SP_DESPACHO_CAMION " , mIdDespachoCamion , ",'','','','','','','','','','','',14 ");
        lDts = lDal.ListarAyudaSql(lSql);
        if ((lDts.MensajeError.Trim().Length == 0) && (lDts.DataSet.Tables.Count > 0))
        {
            mTransportista = lDts.DataSet.Tables[0].Rows[0]["CAM_TRANSPORTISTA"].ToString();
            mPatenteCamion = lDts.DataSet.Tables[0].Rows[0]["CAM_PATENTE"].ToString();
        }

        //'mSucursalCod = 2 '105
        //'mBodegaSalida = 1 '69 ' 105

    }


         private Integracion_INET.Tipo_InvocaWS InvocaWS_INET(string ipatente, string iFecha, string IdObra, string lDespachosCam, string lViajes, string lTipoGuiaINET)
        {        
           
            Integracion_INET.Cls_LN lIntegra = new Integracion_INET.Cls_LN(); 
         WsCrud .CrudSoapClient  lDAl =new WsCrud.CrudSoapClient() ;
            WsCrud .ListaDataSet lDts=new WsCrud.ListaDataSet ();



            mIdObra = int.Parse (IdObra);
            Registry registry = new Registry();
            mSucursal = (string) registry.GetValue(Program.regeditKeyName, "Sucursal", "");
            //string lEmpresa = ConfigurationManager.AppSettings["Empresa"].ToString();

             if (mEmpresa .ToUpper ().Equals ("TOSOL"))
                 return lIntegra.InvocaWS_INET_TOSOL(ref TX_Estado, IdObra, mSucursal, lDespachosCam, lViajes);
             else
                return lIntegra.InvocaWS_INET(ref TX_Estado, IdObra, mSucursal, lDespachosCam, lViajes, lTipoGuiaINET);

       
        }

        private Integracion_INET.Tipo_InvocaWS InvocaWS_INET_Reposicion(string ipatente, string iFecha, string IdObra, string lDespachosCam, string lViajes)
        {

            Tipo_InvocaWS lResultado = new Tipo_InvocaWS();

            Tipo_DocVentaExt lImputObj = new Tipo_DocVentaExt();
            string lEstadoProceso = ""; bool lEstadoP1 = false;
            bool lEstadoP2 = false; StringWriter strDataXml = new StringWriter();

            Integracion_INET.Cls_LN lIntegra = new Integracion_INET.Cls_LN();

            string lSql = ""; WsCrud.CrudSoapClient lDAl = new WsCrud.CrudSoapClient();
            WsCrud.ListaDataSet lDts = new WsCrud.ListaDataSet();

            //try
            //{

            mIdObra = int.Parse(IdObra);
            Registry registry = new Registry();
            mSucursal = (string)registry.GetValue(Program.regeditKeyName, "Sucursal", "");
            //string lEmpresa = ConfigurationManager.AppSettings["Empresa"].ToString();

            if (mEmpresa.ToUpper().Equals("TOSOL"))
                return lIntegra.InvocaWS_INET_TOSOL_Reposicion(ref TX_Estado, IdObra, mSucursal, lDespachosCam, lViajes);
            else
                return lIntegra.InvocaWS_INET_Reposicion(ref TX_Estado, IdObra, mSucursal, lDespachosCam, lViajes);


        }

        #endregion

        private void IntegracionConINET(string iParametros)
        {
            //Dim lLog As New Cls_LN, lRes As Tipo_InvocaWS, lResultado As String = "", lViaje As String = ""
            //Dim lPartes() As String = Tx_Parametros.Text.Split("|")

            string lResultado = ""; string lViajes = ""; Models.Tipo_InvocaWS lRes = new Models.Tipo_InvocaWS();
            string[] lPartes = iParametros.Split(new Char[] { '|' });
            try
            {
                if (lPartes.Length > 0) 
                {

                    lViajes = lPartes[0].ToString();       
                    if (lResultado.ToString().Length == 0) 
                    {
                        Application.DoEvents();
                       
                    }
                }
                    else 
                {
                        //TX_Estado.Text = ""
                        //TX_Estado.Text = lResultado
                }
            
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        
        }

        private void Btn_Sel_Click(object sender, EventArgs e)
        {

        }

        private void Dtg_Camiones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        /// <summary>
        /// Imprime el  informe de despacho de carga
        /// </summary>
        /// <param name="iIdDespachos"> lista con los despachos que se cargaran en el informe</param>
        /// <param name="VerInforme"> True, para ver el informe y que el usuario lo imprima, 
        /// en caso contrario se genera el informe en un archivo </param>
        private void ImprimeInformeCarga(string iIdDespachos, Boolean VerInforme)
       
        {

            DtsInformes lDts = new DtsInformes();
            Informes.Rpt_DetalleDespacho lReport = new Informes.Rpt_DetalleDespacho();
            string lSql = ""; Ws_TO.Ws_ToSoapClient lDal = new Ws_TO.Ws_ToSoapClient(); DataSet lData = new DataSet();
            int i = 0; DataTable lTbl = new DataTable(); int lTotalKgs = 0; string lBD = "";
            string iEmpresa =  ConfigurationManager.AppSettings["Empresa"].ToString();


            //Cargamos el detalle
            lSql = "   select Codigo, isnull(round(SUM (d.KgsPaquete),0),0)  KilosCargados  ";
            lSql = string.Concat(lSql, " from DESPACHO_CAMION  , PIEZA_PRODUCCION pp,DetallePaquetesPieza d, Piezas p, Viaje v ");
            lSql = string.Concat(lSql, " where DES_CAM_ID  in (", iIdDespachos, ")   and PIE_DESPACHO_CAMION =DES_CAM_ID ");
            lSql = string.Concat(lSql, " and pp.PIE_ESTADO ='O60' and d.Id=pp.PIE_ETIQUETA_PIEZA ");
            lSql = string.Concat(lSql, " and p.Id =d.IdPieza and p.Estado <>'00'  and v.Id=d.idviaje  ");
            lSql = string.Concat(lSql, " group by Codigo");
            lData = lDal.ObtenerDatos(lSql);

            Informes.DtsInformes lDtsRpt = new DtsInformes(); Informes.DtsInformes.DetalleDataTable lTblDet = new DtsInformes.DetalleDataTable();
            DtsInformes.DetalleRow lFilaDet = null;
            //im lDtsPL As New EstadosDePagos, lTblDet As New EstadosDePagos.DatosDataTable
            for (i = 0; i < lData.Tables[0].Rows.Count; i++)
            {
                lFilaDet = lTblDet.NewDetalleRow();

                lFilaDet["ViajesCargados"] = lData.Tables[0].Rows[i]["codigo"].ToString();
                lFilaDet["Kilos"] = lData.Tables[0].Rows[i]["KilosCargados"].ToString();
                lTotalKgs = lTotalKgs + int.Parse(lData.Tables[0].Rows[i]["KilosCargados"].ToString());
                lTblDet.Rows.Add(lFilaDet);
            }
            lTblDet.TableName = "Detalle";
            lDtsRpt.Merge(lTblDet);

            //ahora la cabecera 
            DtsInformes.CabeceraDataTable lTblCab = new DtsInformes.CabeceraDataTable();
            DtsInformes.CabeceraRow  lFilaCab = null;
            //
            // Obtenemos la guia de INET a partir de un despacho
            string[] lPartes = null;
            string lGuiaINET = "";
            lPartes = iIdDespachos.Split(new Char[] { ',' });

            switch (iEmpresa.ToUpper () )
            {
                case "TO":
                    lBD = "TORRESOCARANZA";
                    break;
                case "TOSOL":
                    lBD = "TOSOL";
                    break;

            }

            lGuiaINET = lDal.ObtenerNroGuiaInet_DespachoCam(lPartes[0].ToString(), lBD);
            
            lSql = "   select MAX(des_cam_fecha) FechaDespacho, MAX(des_cam_camion) Patente ";
            lSql = string.Concat(lSql, " from DESPACHO_CAMION  , PIEZA_PRODUCCION pp,DetallePaquetesPieza d, Piezas p, Viaje v ");
            lSql = string.Concat(lSql, " where DES_CAM_ID  in (", iIdDespachos, ")   and PIE_DESPACHO_CAMION =DES_CAM_ID ");
            lSql = string.Concat(lSql, " and pp.PIE_ESTADO ='O60' and d.Id=pp.PIE_ETIQUETA_PIEZA ");
            lSql = string.Concat(lSql, " and p.Id =d.IdPieza and p.Estado <>'00'  and v.Id=d.idviaje  ");         
            lData = lDal.ObtenerDatos(lSql);
            for (i = 0; i < lData.Tables[0].Rows.Count; i++)
            {
                lFilaCab = lTblCab.NewCabeceraRow();

                lFilaCab["Patente"] = lData.Tables[0].Rows[i]["Patente"].ToString();
                lFilaCab["FechaDespacho"] = lData.Tables[0].Rows[i]["FechaDespacho"].ToString().Substring(0,10) ;
                lFilaCab["GuiaDespacho"] = lGuiaINET;
                lFilaCab["TotalKgs"] = lTotalKgs.ToString(); ;
                lTblCab.Rows.Add(lFilaCab);
            }
                      
            lDtsRpt.Merge(lTblCab);

            Frm_Visualizador lForm = new Frm_Visualizador();
            
            if (VerInforme==true )
            {
                lForm.CargarInforme(lDtsRpt);
                lForm.ShowDialog();
            }
            else
            {
                lForm.GeneraPdf_DetalleDespacho(lDtsRpt);
                lForm.Close();
                lForm.Dispose();
            }
              

        }

        private void Btn_Imprimir_Click(object sender, EventArgs e)
        {
            ImprimeResumenDespacho(true);

        }

        private void ImprimeResumenDespacho(Boolean iVerInforme)
        {

            string lIdDespachos = "";
            if (ValidaDatos() == true)
            {
                foreach (DataGridViewRow lRow in this.Dtg_Camiones.Rows)
                {
                    if (lRow.Cells[0].Value != null)
                        if (lRow.Cells[0].Value.ToString() == "True")
                        {
                            lIdDespachos = string.Concat(lIdDespachos, lRow.Cells["IdDespacho"].Value.ToString(), ",");
                        }
                }

                if (lIdDespachos.Trim().Length > 3)
                {
                    lIdDespachos = lIdDespachos.Substring(0, lIdDespachos.Length - 1);
                    ImprimeInformeCarga(lIdDespachos, iVerInforme);

                }

            }



        }

        private void BTN_actualizarViaje_Click(object sender, EventArgs e)
        {
            int i = 0; string lSql = ""; DataSet lDts = new DataSet(); Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient();
            string lIdWsINET = ""; int j = 0;

            //for (j = 0; j < TR_Arbol.Nodes .Count ; j++)
            //{
            //    TR_Arbol.HideSelection = false ;
            //    TR_Arbol.SelectedNode = TR_Arbol.Nodes[j];
            //    CargaDetalleNodo(TR_Arbol.SelectedNode.FullPath.ToString(), "F");

            //    System.Threading.Thread.Sleep(2000);
                //MessageBox.Show("Se carga nodo");
                for (i = 0; i < Dtg_Camiones.Rows.Count; i++)
                {
                    lSql = string.Concat("Select Id  from Log_WS_INET where XML_Enviado like '%", Dtg_Camiones.Rows[i].Cells["Codigo"].Value.ToString(), "%'");
                    lSql = string.Concat(lSql, "  and Origen='DespachoCamion'");
                    lDts = lPx.ObtenerDatos(lSql);
                    if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                    {
                        lIdWsINET = lDts.Tables[0].Rows[0][0].ToString();
                    }
                    else
                    {
                     lIdWsINET = "000000";
                    }
                        lSql = string.Concat(" update Viaje set idlogWsINET=", lIdWsINET, "  where Codigo='", Dtg_Camiones.Rows[i].Cells["Codigo"].Value.ToString(), "'");
                        lDts = lPx.ObtenerDatos(lSql);
                        Dtg_Camiones.Rows[i].Cells[1].Style.BackColor = Color.LightGreen;
                        Dtg_Camiones.Refresh();
                        Application.DoEvents();
                        this.Refresh();                    
                //}
            
            }
            CargaCamiones(mSucursalTO ,mEmpresa , mSoloCamionesBascula);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ImprimeResumenDespacho(false);

            ImprimeDocumentos("HSG-896/1");
        }

        private void PDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            //String m = "";
        }

        private void Cmb_Sucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (Cmb_Sucursal .SelectedValue !=null)
            //    CargaCamiones(Cmb_Sucursal.SelectedValue.ToString (), mEmpresa, mSoloCamionesBascula);
        }

        private void btn_Ir_Click(object sender, EventArgs e)
        {
            CargaCamiones(Cmb_Sucursal.SelectedValue.ToString(), mEmpresa, mSoloCamionesBascula);

        }
    }
}
