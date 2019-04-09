using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data ;
using CommonLibrary2;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.IO;
using iTextSharp.text.pdf;

namespace Metalurgica.Clases
{
    public class ClsComun
    {
        public string seteoImpresora()
        {
            StringBuilder seteo = new StringBuilder();
            seteo.Append("N" + Environment.NewLine);
            seteo.Append("q680" + Environment.NewLine);
            seteo.Append("Q340,40+0" + Environment.NewLine);
            seteo.Append("R02,00" + Environment.NewLine);
            seteo.Append("S6" + Environment.NewLine);
            seteo.Append("D10" + Environment.NewLine);
            seteo.Append("ZB" + Environment.NewLine);
            return seteo.ToString();
        }

        public string ObtenerVersion()
        {

            string miVariable = ConfigurationManager.AppSettings["Version"];
            return miVariable;

        }

        public string ObtenerParametroAppConfig(string iParam)
        {

            string miVariable = ConfigurationManager.AppSettings[iParam];
            return miVariable;

        }

        public string ObtenerLoginPorTarjeta()
        {

            string miVariable = ConfigurationManager.AppSettings["LoginPorTarjeta"];
            return miVariable;

        }



        public string ObtenerVersionRC()
        {

            string miVariable = ConfigurationManager.AppSettings["VersionColada"];
            return miVariable;

        }

        public string ObtenerVersionDC()
        {

            string miVariable = ConfigurationManager.AppSettings["VersionDespachoCamion"];
            return miVariable;

        }

        public string ObtenerVersionProduccion()
        {

            string miVariable = ConfigurationManager.AppSettings["VersionProduccion"];
            return miVariable;

        }

        public string ObtenerArchivoIntegracion()
        {

            string miVariable = ConfigurationManager.AppSettings["Archivo_IntegracionINET"];
            return miVariable;

        }

        public CurrentUser ObtenerDatosEquipo()
        {
            CurrentUser lUser = new CurrentUser();
            const string userRoot = "HKEY_CURRENT_USER";
            const string subkey = "Software\\VB and VBA Program Settings\\Metalurgica";
            string regeditKeyName = userRoot + "\\" + subkey;
            lUser.Machine = Convert.ToInt16(new Registry().GetValue(regeditKeyName, "Maquina", -1));
            lUser.IdMaquina = Convert.ToInt16(new Registry().GetValue(regeditKeyName, "IdMaquina", -1));
            lUser.ComputerName = System.Environment.MachineName;

            lUser.Login = "UsrPruebas";
            lUser.Name = "Usuario de Pruebas ";

            return lUser;
        }

        public void EjecutaShell(string iPathIni, string iPar)
        {
            //lPar = stricat(Lbl_Viajes.Text, "|", lIdObra, "|0|", idDespacho);
            string lPath = ""; string lArchivoIntINET = "";
            //Obtenemos el archivo de IntegracionINET
            Clases.ClsComun lCom = new Clases.ClsComun();
            lArchivoIntINET = lCom.ObtenerArchivoIntegracion();  //Application.ProductVersion;

            const string quote = "\"";
            //  //lPath = string.Concat(quote, Application.StartupPath, "\\Integracion_INET.exe", quote, " '", lPar, "'");
            // lPath = string.Concat(quote, iPathIni, "\\Integracion_INET.exe", qte, " '", lPar, "'");
            //lPath = string.Concat(iPathIni, "\\Integracion_INET.exe");
            lPath = string.Concat(iPathIni, "\\", lArchivoIntINET);
            System.Diagnostics.Process Proceso = new System.Diagnostics.Process();         ////  startInfo = new System.Diagnostics.ProcessStartInfo(lPath);
            //  pStart.StartInfo.FileName = lPath;
            //  pStart.StartInfo.Arguments = "";
            //  pStart.StartInfo = startInfo;
            //  pStart.Start();
            //  pStart.WaitForExit();
            //Proceso.Process();
            Proceso.StartInfo.FileName = lPath; // "calc.exe";
            Proceso.StartInfo.Arguments = iPar;
            Proceso.Start();
            Proceso.WaitForExit();
        }


        public DataTable SumaColumas(String iColumnas, DataTable iTbl)
        {
            char[] delimiterChars = { ',', '\t' }; double iTotal = 0; int lcol = 0;
            string[] words = iColumnas.Split(delimiterChars);
            DataRow iFila = null; int i = 0; int j = 0;
            iFila = iTbl.NewRow();
            for (i = 0; i < words.Length; i++)
            {
                lcol = int.Parse(words[i]);
                iTotal = 0;
                for (j = 0; j < iTbl.Rows.Count; j++)
                {
                    if (iTbl.Rows[j][lcol].ToString().Trim().Length > 0)
                        iTotal = iTotal + double.Parse(iTbl.Rows[j][lcol].ToString());
                }
                iFila[lcol] = iTotal;
            }
            iTbl.Rows.Add(iFila);
            return iTbl;
        }

        public bool EsNumero(string iValor)
        {
            bool iRes = false;


            //Sencillamente, si se logra hacer la conversión, entonces es número
            try
            {
                decimal resp = Convert.ToInt64(iValor);
                iRes = true;
            }
            catch //caso contrario, es falso.
            {
                iRes = false;
            }

            return iRes;

        }

        //public DateTime  Cdate(string iValor)
        //{
        //    DateTime iRes ;


        //    //Sencillamente, si se logra hacer la conversión, entonces es número
        //    try
        //    {
        //         iRes = Convert.ToDateTime(iValor);

        //    }
        //    catch //caso contrario, es falso.
        //    {
        //        //'iRes = false;
        //    }

        //    return iRes;

        //}

        public int Val(string iValor)
        {
            int iRes = 0;

            //Sencillamente, si se logra hacer la conversión, entonces es número
            try
            {
                iRes = int.Parse(iValor);
            }
            catch (Exception exc)  //caso contrario, es falso.
            {
                iRes = -1;
            }

            return iRes;

        }


        public string  FormateaMiles(string iValor)
        {
            int iRes = 0;string lNumFormateado = "";

            //Si es un numero se debe formatear en formato de miles 1.000
            try
            {
                iRes = int.Parse(iValor);
                lNumFormateado = iRes.ToString("N0");
                lNumFormateado = lNumFormateado.Replace(",", ".");

            }
            catch (Exception exc)  //caso contrario, es falso.
            {
                lNumFormateado = iValor;
            }

            return lNumFormateado;

        }

        public double  CDBL(string iValor)
        {
            double  iRes = 0;

            //Sencillamente, si se logra hacer la conversión, entonces es número
            try
            {
                iRes = double .Parse(iValor);
            }
            catch (Exception exc)  //caso contrario, es falso.
            {
                iRes = 0;
            }

            return iRes;

        }

        public Boolean  EsFecha(string iValor)
        {
            Boolean iRes = true;DateTime lFecha    ;

            //Sencillamente, si se logra hacer la conversión, entonces es fecha
            try
            {
                lFecha = DateTime .Parse (iValor);
            }
            catch (Exception exc)  //caso contrario, es falso.
            {
                iRes = false;
            }

            return iRes;

        }

        public string ParteEntera(string iValor)
        {
            string iRes = "";
            char[] delimiterChars = { ',', '\t' };
            char[] delimiterChars2 = { '.', '\t' };


            //Sencillamente, si se logra hacer la conversión, entonces es número
            try
            {
                string[] words = iValor.Split(delimiterChars);
                if (words.Length == 1)
                {
                    words = iValor.Split(delimiterChars2);

                }

                iRes = words[0];
            }
            catch //caso contrario, es falso.
            {
                iRes = "";
            }

            return iRes;

        }

        public DataTable CargaTablaObras_PorUsuario(string iIdUser)
        {
            DataTable lTbl = new DataTable(); DataSet lDts = new DataSet(); string lSql = "";
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient();
            string lEmpresa = ConfigurationManager.AppSettings["Empresa"].ToString();
            string lCambiarProduccion = ConfigurationManager.AppSettings["CambioPR_Desp"].ToString();

            if (lCambiarProduccion.ToUpper().Equals("S"))  // solo mostramos la obra de la contrata
            //lSql = string.Concat("  Select id, Nombre Obra  from Obras where  id=610  ");
            {
                lTbl = CargaTablaObrasPorUsuario(iIdUser);
            }
            else
            {
                lSql = string.Concat("  Select id, Nombre Obra  from Obras where empresa='", lEmpresa, "' and  EstadoAlta not in ('FIN') order by nombre ");
                lDts = lPx.ObtenerDatos(lSql);
                if (lDts.Tables.Count > 0 && lDts.Tables[0].Rows.Count > 0)
                {
                    lTbl = lDts.Tables[0].Copy();
                }
            }
            return lTbl;
        }

        public DataTable CargaTablaObrasPorUsuario(String lIdUser)
        {
            DataTable lTbl = new DataTable(); DataSet lDts = new DataSet(); string lSql = "";
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient();
            string lEmpresa = ConfigurationManager.AppSettings["Empresa"].ToString();
            string lCambiarProduccion = ConfigurationManager.AppSettings["CambioPR_Desp"].ToString();
            try
            {
                if (lCambiarProduccion.ToUpper().Equals("S"))  // solo mostramos la obra de la contrata
                {
                    //  lSql = " exec SP_CRUD_Obras_Usuarios 0,0," & iUser & ",0,0,4"
                    //lTbl = lDal.CargaTabla(lSql)
                    lSql = string.Concat("  exec SP_CRUD_Obras_Usuarios 0,0," , lIdUser, ",0,0,5 ");
                    lDts = lPx.ObtenerDatos(lSql);
                    if (lDts.Tables.Count > 0 && lDts.Tables[0].Rows.Count > 0)
                    {
                        lTbl = lDts.Tables[0].Copy();
                    }
                }
                else
                {
                    lSql = string.Concat("  Select id, Nombre Obra  from Obras where empresa='", lEmpresa, "' and  EstadoAlta not in ('FIN') order by nombre ");
                    lDts = lPx.ObtenerDatos(lSql);
                    if (lDts.Tables.Count > 0 && lDts.Tables[0].Rows.Count > 0)
                    {
                        lTbl = lDts.Tables[0].Copy();
                    }
                }
            }
            catch (Exception exc)
            {
               throw exc;
            }
            return lTbl;
        }


        public DataTable CargaTablaObras(string iEmpresa)
        {
            DataTable lTbl = new DataTable(); DataSet lDts = new DataSet(); string lSql = "";
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient();
            string lEmpresa = iEmpresa;

            lSql = string.Concat("  Select id, Nombre Obra  from Obras where empresa='", lEmpresa, "' and  EstadoAlta not in ('FIN') order by nombre ");
            lDts = lPx.ObtenerDatos(lSql);
            if (lDts.Tables.Count > 0 && lDts.Tables[0].Rows.Count > 0)
            {
                lTbl = lDts.Tables[0].Copy();
            }


            return lTbl;
        }

        public string ObtenerKilos(string iLargo, string iDiametro, int iCantidad)
        {
            //El largo debe esta en Metros
            DataTable lTbl = new DataTable(); DataSet lDts = new DataSet();
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient();
            string lRes = "";

            lRes = lPx.ObtenerPesoBechtell(iLargo, iDiametro, iCantidad).ToString();

            return lRes;
        }

        public DataTable CargaTablaUsuariosAsignadosAUnaMaquina(string iNroMaquina)
        {
            DataTable lTbl = new DataTable(); DataSet lDts = new DataSet(); string lSql = "";
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient();

            lSql = string.Concat("SP_ConsultasGenerales 74,'", iNroMaquina, "','','','',''");
            lDts = lPx.ObtenerDatos(lSql);
            if (lDts.Tables.Count > 0 && lDts.Tables[0].Rows.Count > 0)
            {
                lTbl = lDts.Tables[0].Copy();
            }


            return lTbl;
        }

        public DataTable CargaTablaObras_ParaIngresoRomana()
        {
            DataTable lTbl = new DataTable(); DataSet lDts = new DataSet(); string lSql = "";
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient();
            string lEmpresa = ConfigurationManager.AppSettings["Empresa"].ToString();
            lSql = string.Concat("SP_ConsultasGenerales 53,'','','','',''");
            lDts = lPx.ObtenerDatos(lSql);
            if (lDts.Tables.Count > 0 && lDts.Tables[0].Rows.Count > 0)
            {
                lTbl = lDts.Tables[0].Copy();
            }

            return lTbl;
        }


        public DataTable CargaTabla_Maquinas()
        {
            DataTable lTbl = new DataTable(); DataSet lDts = new DataSet(); string lSql = "";
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient();
            string lIdSucursal = ConfigurationManager.AppSettings["IdSucursal"].ToString();
            lSql = string.Concat("SP_ConsultasGenerales 70,'", lIdSucursal, "','','','',''");
            lDts = lPx.ObtenerDatos(lSql);
            if (lDts.Tables.Count > 0 && lDts.Tables[0].Rows.Count > 0)
            {
                lTbl = lDts.Tables[0].Copy();
            }

            return lTbl;
        }

        public DataTable CargaTabla_MUltiMaquinas()
        {
            DataTable lTbl = new DataTable(); DataSet lDts = new DataSet(); string lSql = "";
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient();
            string lIdSucursal = ConfigurationManager.AppSettings["IdSucursal"].ToString();
            lSql = string.Concat("SP_ConsultasGenerales 103,'", lIdSucursal, "','','','',''");
            lDts = lPx.ObtenerDatos(lSql);
            if (lDts.Tables.Count > 0 && lDts.Tables[0].Rows.Count > 0)
            {
                lTbl = lDts.Tables[0].Copy();
            }

            return lTbl;
        }

        public DataTable CargaTabla_MUltiMaquinasConectores()
        {
            DataTable lTbl = new DataTable(); DataSet lDts = new DataSet(); string lSql = "";
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient();
            string lIdSucursal = ConfigurationManager.AppSettings["IdSucursal"].ToString();
            lSql = string.Concat("SP_ConsultasGenerales 119,'", lIdSucursal, "','','','',''");
            lDts = lPx.ObtenerDatos(lSql);
            if (lDts.Tables.Count > 0 && lDts.Tables[0].Rows.Count > 0)
            {
                lTbl = lDts.Tables[0].Copy();
            }

            return lTbl;
        }

        public DataTable CargaTabla_ConectoresEnProduccion()
        {
            Px_Conectores.Ws_ConectoresSoapClient lCon = new Px_Conectores.Ws_ConectoresSoapClient();
            Px_Conectores.ListaDataSet lConectores = lCon.DetalleConectoresEnProduccion();
            DataSet lDts = new DataSet();DataTable lTbl = new DataTable();


            lDts = lConectores.DataSet;
            if (lDts.Tables.Count > 0 && lDts.Tables[0].Rows.Count > 0)
            {
                lTbl = lDts.Tables[0].Copy();
            }

            return lTbl;
        }


        public DataTable   InicioProduccionConectores(string idPaquete, string idPiezaTipoB, int idMaquina, string iUser, string iObs)
        {
            DataTable lTbl = new DataTable(); DataSet lDts = new DataSet(); string lSql = "";
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient();
            
            lSql = string.Concat("SP_CRUD_PRODUCCION_CONECTORES   0,", idPaquete,",", idPiezaTipoB,",", idMaquina,",", iUser,",'", iObs ,"','','','',1");
            lDts = lPx.ObtenerDatos(lSql);
            if (lDts.Tables.Count > 0 && lDts.Tables[0].Rows.Count > 0)
            {
                lTbl = lDts.Tables[0].Copy();
            }

            return lTbl;
        }

        public string  ObtenerPesoConectores(string idPaquete)
        {
            DataTable lTbl = new DataTable(); DataSet lDts = new DataSet(); string lSql = "";
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient(); string lRes = ""; int NroConectores = 0;
            double lPesoConectores = 0; int i = 0;

            lSql = string.Concat(" [SP_ConsultasGenerales]  124,", idPaquete, ",'','','',''");
            lDts = lPx.ObtenerDatos(lSql);
            if (lDts.Tables.Count > 0 && lDts.Tables[0].Rows.Count > 0)
            {
                lTbl = lDts.Tables[0].Copy();
                if (lTbl.Rows.Count > 0)
                {
                    for (i = 0; i < lTbl.Rows.Count; i++)
                    {
                        lPesoConectores = lPesoConectores + (CDBL(lTbl.Rows[i]["KgsCon"].ToString())) ; // * Val(lTbl.Rows[i]["Cantidad"].ToString()));
                        //switch (lTbl.Rows[0]["IdForma"].ToString())
                        //{
                        //    case "1102":
                        //        NroConectores = 1;
                        //        break;
                        //    case "1103":
                        //        NroConectores = 1;
                        //        break;
                        //    case "1104":
                        //        NroConectores = 2;
                        //        break;
                        //    case "1105":
                        //        NroConectores = 1;
                        //        break;
                        //    case "1106":
                        //        NroConectores = 2;
                        //        break;

                        //    case "1206":
                        //        NroConectores = 1;
                        //        break;

                        //    case "1207":
                        //        NroConectores = 1;
                        //        break;
                        //    case "1211":
                        //        NroConectores = 1;
                        //        break;
                        //    case "1212":
                        //        NroConectores = 1;
                        //        break;
                        //}

                    }
                    

                }

            }
            return lPesoConectores.ToString(); ;
        }

        public DataTable FinProduccionConectores(string IdProdConectores, string idPiezaTipoB, string iObs)
        {
            DataTable lTbl = new DataTable(); DataSet lDts = new DataSet(); string lSql = "";
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient();

            lSql = string.Concat("SP_CRUD_PRODUCCION_CONECTORES  ", IdProdConectores , ",0,0,0,0,'", iObs, "','','','',2");
            lDts = lPx.ObtenerDatos(lSql);
            if (lDts.Tables.Count > 0 && lDts.Tables[0].Rows.Count > 0)
            {
                lTbl = lDts.Tables[0].Copy();
            }

            return lTbl;
        }

        public string ObtenerTipoPorProducto(string iCodProducto)
        {
            //  ALTER PROCEDURE [dbo].[SP_Consultas_WS]
            //@Opcion INT,          //@Par1 Varchar(100),       //@Par2 Varchar(100),       //@Par3 Varchar(150),
            //@Par4 Varchar(100),   //@Par5 Varchar(100),       //@Par6 Varchar(100),       //@Par7 Varchar(100)

            DataTable lTbl = new DataTable(); DataSet lDts = new DataSet(); string lSql = "";
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient(); string lRes = "";

            lSql = string.Concat("SP_Consultas_WS 60,'", iCodProducto, "','','','','','',''");
            lDts = lPx.ObtenerDatos(lSql);
            if (lDts.Tables.Count > 0 && lDts.Tables[0].Rows.Count > 0)
            {
                lRes = lDts.Tables[0].Rows[0]["Tipo"].ToString();
            }

            return lRes;
        }


        public DataTable CargaTablaRomana(string lSql)
        {

            DataTable lTbl = new DataTable(); string lError = "";
            string lPath = ConfigurationManager.AppSettings["PathDBRomana"].ToString(); int i = 0;
            string lCnnstr = string.Concat(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=", lPath);
            //@"Provider=Microsoft.ACE.OLEDB.12.0;  Data Source=D:\BDPROBANDO2007.accdb;Persist Security Info=False";
            OleDbConnection lCnn = new OleDbConnection(lCnnstr);
            OleDbDataAdapter lAdp = new OleDbDataAdapter(lSql, lCnn);
            try
            {
                lAdp.Fill(lTbl);
            }
            catch (Exception ex)
            {
                lError = string.Concat("ClsDatos.CargaTablaRomana ", ex.Message.ToString(), " sql: ", lSql);
            }

            return lTbl;
        }



        private DataTable CargaTabla(string iSql)
        {
            DataTable lTbl = new DataTable(); string lError = "";
            //'Dim lCnnStr As String = "Data Source=localhost\SQLExpress;Initial Catalog=CubiCad;User id=CnnCubicad;Password=t.o2011;"
            string lCnnStrs = "Persist Security Info=False;Trusted_Connection=True; database=Pruebas;server=DES-RBECERRA";
            System.Data.SqlClient.SqlConnection lCnn = new System.Data.SqlClient.SqlConnection(lCnnStrs.ToString());
            //System  lCnn As New SqlClient.SqlConnection(lCnnStr)
            SqlDataAdapter lAdp = new SqlDataAdapter(iSql, lCnn);
            //Dim lAdp As New SqlClient.SqlDataAdapter(iSql, lCnn)
            //Dim lTabla As New Data.DataTable
            try
            {
                lAdp.Fill(lTbl);
            }
            catch (Exception ex)
            {
                lError = string.Concat("ClsDatos.CargaTabla ", ex.Message.ToString(), " sql: ", iSql);
            }
            //Catch ex As Exception
            //    Dim lErrror As String = "ClsDatos.CargaTabla " & ex.Message.ToString & " sql: " & iSql            
            //End Try

            //Return lTabla

            return lTbl;
        }



        #region Unir varios archivos PDF

       private string  PadExt(string iss )
        {
            iss = iss.ToUpper();

            if (iss.Length > 3)
            {
                iss = iss.Substring(1, 3);
            }

        //If s.Length > 3 Then
        //    s = s.Substring(1, 3)

        //End If

        return iss;

        }



           private int   GetPageCount(string  sFolderPath )
        {
            int iRet = 0; int i = 0;
            String[] oFiles = Directory.GetFiles(sFolderPath);
            // Dim sFromFilePath As String = oFiles(i)
            string sFromFilePath = "";
           
            //  Dim sFileType As String = cbFileType.SelectedItem
            string sExt = "";

            for (i = 0; i < oFiles.Length; i++)
            {
                sFromFilePath = oFiles[i];
                FileInfo oFileInfo = new FileInfo(sFromFilePath);
                sExt = "";
                sExt = PadExt(oFileInfo.Extension);

                if (sExt == "PDF")
                    iRet += 1;
                        
               }

            return iRet;
          }

        //ProccessFolder(sFromPath)
        private string AddBookmark(ref iTextSharp.text.Document oPdfDoc, string sFromFilePath)
        {
              iTextSharp.text.Chapter oChapter = new iTextSharp.text.Chapter("", 0);
             oChapter.NumberDepth = 0;
            FileInfo oFileInfo = new FileInfo(sFromFilePath);

            oChapter.BookmarkTitle = oFileInfo.Name;
            oPdfDoc.Add(oChapter);
                return "";
   }

        private string  AddPdf(string  sInFilePath , ref iTextSharp.text.Document  oPdfDoc  , ref PdfWriter oPdfWriter  )
        {


            AddBookmark(ref oPdfDoc, sInFilePath);


            iTextSharp.text.pdf.PdfContentByte oDirectContent = oPdfWriter.DirectContent;
            iTextSharp.text.pdf.PdfReader oPdfReader = new iTextSharp.text.pdf.PdfReader(sInFilePath);

            int iNumberOfPages = oPdfReader.NumberOfPages;  int iPage = 0;


            //Do While(iPage<iNumberOfPages)
            while (iPage < iNumberOfPages)
            {
                iPage += 1;
                int iRotation = oPdfReader.GetPageRotation(iPage);
                iTextSharp.text.pdf.PdfImportedPage oPdfImportedPage = oPdfWriter.GetImportedPage(oPdfReader, iPage);


                //If chkResize.Checked Then
                if (oPdfImportedPage.Width <= oPdfImportedPage.Height)
                    oPdfDoc.SetPageSize(iTextSharp.text.PageSize.LETTER);
                else
                    oPdfDoc.SetPageSize(iTextSharp.text.PageSize.LETTER.Rotate());


               oPdfDoc.NewPage();
                Single iWidthFactor = oPdfDoc.PageSize.Width / oPdfReader.GetPageSize(iPage).Width;
                Single iHeightFactor = oPdfDoc.PageSize.Height / oPdfReader.GetPageSize(iPage).Height;
                Single iFactor = Math.Min(iWidthFactor, iHeightFactor);
                Single iOffsetX = (oPdfDoc.PageSize.Width - (oPdfImportedPage.Width * iFactor)) / 2;
                Single iOffsetY = (oPdfDoc.PageSize.Height - (oPdfImportedPage.Height * iFactor)) / 2;


                oDirectContent.AddTemplate(oPdfImportedPage, iFactor, 0, 0, iFactor, iOffsetX, iOffsetY);

			//Else
   //             oPdfDoc.SetPageSize(oPdfReader.GetPageSizeWithRotation(iPage))
			//	oPdfDoc.NewPage()


   //             If(iRotation = 90) Or(iRotation = 270) Then
   //               oDirectContent.AddTemplate(oPdfImportedPage, 0, -1.0F, 1.0F, 0, 0, oPdfReader.GetPageSizeWithRotation(iPage).Height)
			//	Else
   //                 oDirectContent.AddTemplate(oPdfImportedPage, 1.0F, 0, 0, 1.0F, 0, 0)

   //             End If

   //         End If

      }

            return "";
   }


        public string UnirOdf(String sFolderPath)
        {
            DataTable lTblArchivos = new DataTable(); DataRow lFila = null; DataView lVista = null;
            Boolean bOutputfileAlreadyExists = false;
            DirectoryInfo oFolderInfo = new DirectoryInfo(sFolderPath);
            String sOutFilePath = string.Concat(sFolderPath,  oFolderInfo.Name, ".pdf");

            if (File.Exists(sOutFilePath))
            {
                try
                {
                    File.Delete(sOutFilePath);
                }
                catch (Exception exc)
                {
                    throw exc;
                }
            }

            iTextSharp.text.Document oPdfDoc = new iTextSharp.text.Document(); int i = 0; string sFromFilePath = "";
            PdfWriter oPdfWriter = PdfWriter.GetInstance(oPdfDoc, new FileStream(sOutFilePath, FileMode.Create));
            int iPageCount = GetPageCount(sFolderPath);int lCont = 1;
            if ((iPageCount > 0) && (bOutputfileAlreadyExists == false))
            {
                string[] oFiles = Directory.GetFiles(sFolderPath);
                lTblArchivos.Columns.Add("Nombre", Type.GetType("System.String"));
                lTblArchivos.Columns.Add("Orden", Type.GetType("System.Int32"));

                for (i = 0; i < oFiles.Length; i++)
                {
                    lFila = lTblArchivos.NewRow();
                    lFila["Nombre"]= oFiles[i].ToString ();
                    if (oFiles[i].ToString().IndexOf("P.pdf") > -1)
                        lFila["Orden"] = 1;
                    if (oFiles[i].ToString().IndexOf("D.pdf") > -1)
                        lFila["Orden"] = 2;

                    // agregamos la fila a la tabla
                    lTblArchivos.Rows.Add(lFila);
                }

                    oPdfDoc.Open();
                //System.Array.Sort(Of String)(oFiles)
                // Debemos Ordenar los pdf para crear el nuevo
                lVista = new DataView(lTblArchivos, "", "Nombre asc ", DataViewRowState.CurrentRows);
                for (i = 0; i < lVista.Count ; i++)
                //for (i = 0; i< oFiles.Length; i++)
                {
                    //sFromFilePath = oFiles[i];
                    sFromFilePath = lVista[i]["Nombre"].ToString ();
                    if (!sOutFilePath.ToString().Equals(sFromFilePath))
                    { 
                    FileInfo oFileInfo = new FileInfo(sFromFilePath);
                    string sExt = PadExt(oFileInfo.Extension);
                    string sFileType = "PDF";

                    try
                    {
                        if (sExt == "PDF")
                            AddPdf(sFromFilePath, ref oPdfDoc, ref oPdfWriter);
                    }

                    catch (Exception exc)
                    {
                        throw exc;
                    }
                    }
                }
            }

            try
            {
                oPdfDoc.Close();
                oPdfWriter.Close();
            }
            catch (Exception exc)
            {
                throw exc;
            }

            //  If chkDeleteSourceFiles.Checked Then
            //          For i As Integer = 0 To oFiles.Length - 1

            //              Dim sFromFilePath As String = oFiles(i)

            //              If IO.File.Exists(sFromFilePath) Then
            //                  Try

            //                      IO.File.Delete(sFromFilePath)
            //Catch ex As Exception

            //                      txtOutput.Text += "Could not delete " & sFromFilePath & _
            //	 ", " & ex.Message & vbCrLf
            //                  End Try
            //              End If
            //          Next

            //ProgressBar1.Value = 0
            //End If
            return sOutFilePath.ToString() ;
        }

        #endregion

    }


}
