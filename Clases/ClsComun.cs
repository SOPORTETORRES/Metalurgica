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
using System.Collections;

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

        public decimal  CDBl(string iValor)
        {
            decimal iRes = 0;

            //Sencillamente, si se logra hacer la conversión, entonces es número
            try
            {
                iRes = decimal.Parse(iValor);
            }
            catch (Exception exc)  //caso contrario, es falso.
            {
                iRes = 0;
            }

            return iRes;

        }

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
                iRes = 0;
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


        #region Lectura de etiqueta AZA


        public string ObtenerCodigoCubigest(string iTx , DataTable iTBlSuc)
        {

            string lRes = ""; Clases.ClsComun lCom = new Clases.ClsComun();  
            DataView lVista = new DataView(iTBlSuc, string.Concat("Par1='", iTx ,"'"), "", DataViewRowState.CurrentRows);
            if ((iTx.Length > 0)  && (lVista.Count >0))
            {
                lRes = lVista[0]["Par2"].ToString();
            }

            return lRes;
        }

        public string  ObtenerCalidadAcero(string iTx)
        {
             
             string  lRes = "";      Clases.ClsComun lCom = new Clases.ClsComun();

            if (iTx.Length > 0)
            {

                if (iTx.IndexOf("A630") > -1)
                {
                    lRes = "A630";

                }
                else
                    if (iTx.IndexOf("A440") > -1)
                {
                    lRes = "A440";
                }                    
            }

            return lRes;
        }


        public  int ObtenerDiametro(string iTx)
        {
            char[] delimiterChars = { ' ' }; string[] words = iTx.Split(delimiterChars);
            string lTmp = words[2].ToString(); int lRes = 1; string lAux = "";int i = 0;
              Clases.ClsComun lCom =  new Clases.ClsComun();

            if (words.Length >0 )
            {
                for (i = 1; i < words.Length; i++)
                {
                    lTmp = words[i].ToString();
                    if (lTmp.IndexOf("mm") > -1)
                    // if ((lTmp.IndexOf("mm") > -1) || (lTmp.IndexOf("MM") > -1))
                    {
                        lAux = lTmp.Replace("mm", "");
                        lRes = new Clases.ClsComun().Val(lAux);
                        //if (lCom.Val(lAux) > 0)
                        //{
                        //    lRes = lCom.Val(lAux);
                        //}
                        //else
                        //{
                        //    lAux = lTmp.Replace("MM", "");
                        //    lRes = lCom.Val(lAux);
                        //}

                    }
                }
            }

            return lRes;
        }


        public string  ObtenerSoldable(string iTx)
        {
            char[] delimiterChars = { ' ' }; string[] words = iTx.Split(delimiterChars);
            string lTmp = words[3].ToString(); int lRes = 1; string lAux = "";
            string lResultado = "";

            char[] lChar = { 'H' }; string[] lparte;

            //para el caso.  ROLLO HORMIGON 16mm A630-420H
            if (words.Length == 4)
            {
                    lResultado = "N";
            }

            //para el caso.  ROLLO HORMIGON S 16mm A630-420H
            if (words.Length == 5)
            {
                if (iTx.IndexOf("ROLLO") > -1)
                {
                    if (words[2].ToString().Equals("S"))
                        lResultado = "S";
                    else
                        lResultado = "N";
                }
                else  //para el caso.  B HORMIGON 16mm 9m A630-420H (N)
                {
                    lResultado = "N";
                }
            }

            if (words.Length == 6)
            {
                lResultado = "N";
            }


            //B HORMIGON S 22 mm 12m A630-420H (N)
            if (words.Length==8)
            {
                if (words[2].ToString().Equals ("S"))
                    lResultado = "S";
                else
                    lResultado = "N";
            }



            return lResultado;
        }

        private DataTable ObtenerDatosMP_TO(String iCodAZA, DataTable iTblDePara, DataTable iMP, string iCodSucursal )
        {
            DataTable lTblDatos = new DataTable();DataView lVistaCod = null;String lCodTO = "";
            DataView lVista = null; DataRow lFila = null;string lSucursal = "";

            if (iCodSucursal == "1")
                lSucursal = "Calama";

            if (iCodSucursal == "4")
                lSucursal = "Santiago";



            lVistaCod = new DataView(iTblDePara, string.Concat("PAr1='", iCodAZA, "' and par3='", lSucursal, "'"), "", DataViewRowState.CurrentRows);
            if (lVistaCod.Count > 0)
            {
                lCodTO = lVistaCod[0]["Par2"].ToString();
                lVista = new DataView(iMP, string.Concat(" Codigo='", lCodTO, "'"), "", DataViewRowState.CurrentRows);
                if (lVista.Count > 0)
                {
                    lTblDatos = iMP.Copy();
                    lTblDatos.Clear();
                    lFila = lTblDatos.NewRow();
                    lFila["Tipo"] = lVista[0]["Tipo"];
                    lFila["NombreMedidas"] = lVista[0]["NombreMedidas"];
                    lFila["largo"] = lVista[0]["largo"];
                    lFila["Soldable"] = lVista[0]["Soldable"];
                    lFila["CalidadAcero"] = lVista[0]["CalidadAcero"];
                    lFila["Descripcion"] = lVista[0]["Descripcion"];

                    lTblDatos.Rows.Add(lFila);
                }
            }


            return lTblDatos;
        }

        public WsOperacion.TipoEtiquetaAza ObtenerEtiquetaAZA(string lTx, Boolean incluyeProduccion)
        {
            WsOperacion.TipoEtiquetaAza lEt = new WsOperacion.TipoEtiquetaAza(); Clases.ClsComun lCom = new Clases.ClsComun();
            WsOperacion.OperacionSoapClient lPx = new WsOperacion.OperacionSoapClient(); DataTable lTbl = new DataTable();
            DataTable lTBlMP = new DataTable(); DataTable lTBlCodigosIntercambio = new DataTable();
            char[] delimiterChars = { ';' }; string[] words = lTx.Split(delimiterChars);
            string lIdSucursal = "";

            //******************
            try
            {
                lIdSucursal = OBtenerIdSucursal().ToString();
                WsOperacion.ListaDataSet lDts = new WsOperacion.ListaDataSet();
                lDts = lPx.Obtener_MP();
                if ((lDts.MensajeError.Trim().Length == 0) && (lDts.DataSet.Tables.Count > 0))
                {
                    if (lDts.DataSet.Tables.Count == 3)
                    {
                        lTBlMP = lDts.DataSet.Tables["MP"].Copy();
                        lTBlCodigosIntercambio = lDts.DataSet.Tables["Codigos_Intercambio"].Copy();
                        lEt.Lote = words[0].ToString().Trim();
                        if (lEt.Lote.Trim().Length == 10)
                            lEt.Procedencia = "AZA";

                        lEt.FechaFabricacion = words[1].ToString().Trim();
                        lEt.Bulto = lCom.Val(words[2].ToString());
                        if (incluyeProduccion == true)
                        {
                            // se debe ir a la base de datos y verificar que exista la información y cargar todos los datos
                            //la llave es Lote + Bulto 
                            lEt.KgsProducidos = 0;
                            lEt = lPx.ObtenerEtiqueta(lEt.Lote, lEt.Bulto.ToString());
                        }
                        lEt.Producto = words[3].ToString().Trim();
                        lEt.Codigo = words[4].ToString().Trim();
                        lEt.PesoBulto = lCom.Val(words[5].ToString());
                        lEt.Errors = "";
                        lEt.TipoProduccion = "P";

                        lEt.Trama = lTx;
                        // con el codigo de Aza, vamos a la tabla de intercambio, obtenemos el codigo de  TO y con este vamos a la tabla de MP y obtenemos los datos
                        lTbl = ObtenerDatosMP_TO(lEt.Codigo, lTBlCodigosIntercambio, lTBlMP, lIdSucursal);
                        if (lTbl.Rows.Count > 0)
                        {
                            lEt.CalidadAcero = lTbl.Rows[0]["CalidadAcero"].ToString();  // lCom.ObtenerCalidadAcero(lEt.Producto);
                            lEt.Diam = int.Parse(lTbl.Rows[0]["NombreMedidas"].ToString());  // lCom.ObtenerDiametro(lEt.Producto);
                            lEt.Largo = lTbl.Rows[0]["Largo"].ToString();  // lCom.ObtenerLargo(lEt.Producto);
                            lEt.EsSoldable = lTbl.Rows[0]["Soldable"].ToString();
                            if (lEt.EsSoldable.Equals("S"))
                            {
                                lEt.CalidadAcero = string.Concat(lTbl.Rows[0]["CalidadAcero"].ToString().Trim(), "S");  // lCom.ObtenerCalidadAcero(lEt.Producto);
                            }

                            if ((lTbl.Rows[0]["Descripcion"].ToString().Trim().Length > 3))
                                lEt.Producto = lTbl.Rows[0]["Descripcion"].ToString();
                        }
                        else
                        {  //buscamos el codigo en TO
                            DataView lvista = new DataView(lTBlMP, string.Concat("Codigo='", lEt.Codigo, "'"), "", DataViewRowState.CurrentRows);
                            if (lvista.Count > 0)
                            {

                                lEt.Diam = int.Parse(lvista[0]["NombreMedidas"].ToString());  // lCom.ObtenerDiametro(lEt.Producto);
                                lEt.Largo = lvista[0]["Largo"].ToString();  // lCom.ObtenerLargo(lEt.Producto);
                                lEt.CalidadAcero = string.Concat(lvista[0]["CalidadAcero"].ToString());
                                lEt.EsSoldable = lvista[0]["Soldable"].ToString();
                                if (lEt.EsSoldable.Equals("S"))
                                {
                                    lEt.CalidadAcero = string.Concat(lvista[0]["CalidadAcero"].ToString().Trim(), "S");  // lCom.ObtenerCalidadAcero(lEt.Producto);
                                }
                            }
                            else
                            {
                                lEt.Errors = string.Concat("El Código de producto  No se Encuentra en la Base de datos");
                            }
                        }
                    }
                    else
                    {
                        lEt.Errors = " La colada ingresada NO es Valida, Revisar.";
                    }

                }
            }
            catch (Exception iex)
            {
                lEt = new WsOperacion.TipoEtiquetaAza();
                lEt.Errors = " La colada ingresada NO es Valida, Revisar.";
            }

                        return lEt;
        }

        public string   ObtenerLargo(string iTx)
        {
            char[] delimiterChars = { ' ' }; string[] words = iTx.Split(delimiterChars);
            string lTmp = words[3].ToString(); string   lRes = ""; string lAux = "";int i = 0;

            iTx = iTx.Replace("mm", "nn");
            words = iTx.Split(delimiterChars);
            if (words.Length >0)
            {
                for (i = 1; i < words.Length; i++)
                {
                    lTmp = words[i].ToString();
                    if ((lTmp.ToUpper().ToString() != "HORMIGON") && ((lTmp.IndexOf("m") > -1) || (lTmp.IndexOf("M") > -1)))
                    {
                        lAux = lTmp.Replace("m", "");
                        if (Val(lAux) < 1)
                            lAux = lTmp.Replace("M", "");

                        lRes = lAux;
                    }
                }
                //    lAux = lTmp.Replace("m", "");
                //lRes = new Clases.ClsComun().Val(lAux);
            }
            return lRes;


            //if (words.Length > 0)
            //{
            //    for (i = 1; i < words.Length; i++)
            //    {
            //        lTmp = words[i].ToString();
            //        if (lTmp.IndexOf("mm") > -1)
            //        {
            //            lAux = lTmp.Replace("mm", "");
            //            lRes = new Clases.ClsComun().Val(lAux);
            //        }
            //    }
            //}


        }

        #endregion


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


        public  string ObtenerInicioFIn_Turno( string idTotem)
        {
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient(); DataSet lDts = new DataSet();
            string lSql = " SP_ConsultasGenerales 77,'','','','',''"; string lRes = "";
             Clases.ClsComun lCom = new Clases.ClsComun();

            lSql = string.Concat(" SP_ConsultasGenerales 132,'", idTotem, "','','','',''");

            lDts = lPx.ObtenerDatos(lSql);

            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                lRes = string.Concat(lDts.Tables[0].Rows[0]["FInicio"].ToString(), " - ", lDts.Tables[0].Rows[0]["Ffin"].ToString());
            }

            return lRes;
        }

        public string ObtenerInicioFIn_Turno_CierreAutom(string iFechaSol)
        {
            string lRes = "";
            //Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient(); DataSet lDts = new DataSet();
            //string lSql = " SP_ConsultasGenerales 77,'','','','',''";
            //Clases.ClsComun lCom = new Clases.ClsComun();

            //lSql = string.Concat(" SP_ConsultasGenerales 132,'", idTotem, "','','','',''");

            //lDts = lPx.ObtenerDatos(lSql);

            //if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            //{
            //    lRes = string.Concat(lDts.Tables[0].Rows[0]["FInicio"].ToString(), " - ", lDts.Tables[0].Rows[0]["Ffin"].ToString());
            //}

            lRes = string.Concat("Fecha Recepcion: ", iFechaSol);

            return lRes;
        }

        public  bool Agregar_IdSolicitud(ArrayList iList, string lDato)
        {
            bool lres = true; int i = 0;

            for (i = 0; i < iList.Count; i++)
            {
                if (iList[i].ToString().ToUpper().Equals(lDato.ToUpper()))
                {
                    lres = false;
                }
            }
            return lres;
        }

        public  int OBtenerIdSucursal()
        {
            int iIdSucursal = 0; string lAux = ""; Clases.ClsComun lCom = new Clases.ClsComun();

            lAux = ConfigurationManager.AppSettings["IdSucursal"].ToString();
            if (lCom.EsNumero(lAux) == true)
            {
                iIdSucursal = lCom.Val(lAux);
            }

            return iIdSucursal;

        }

        public string  OBtenerSucursal()
        {
            string lAux = "";  

            lAux = ConfigurationManager.AppSettings["Sucursal"].ToString();
            
            return lAux;

        }


        public  string buscarTagError(string texto)
        {
            string result = "INI";
            int pos1 = -1, pos2 = -1;

            pos1 = texto.Trim().ToUpper().IndexOf("<ACCION>OK</ACCION>");
            if (pos1.Equals(-1)) //ERROR
            {
                pos1 = texto.Trim().ToUpper().IndexOf("<DESCERROR>");
                pos2 = texto.Trim().ToUpper().IndexOf("</DESCERROR>");
                while (!pos1.Equals(-1) && !pos2.Equals(-1))
                {
                    result += !result.Equals("") ? ";" : "";
                    result += texto.Substring(pos1, pos2 - pos1).Replace("<DESCERROR>", "");
                    pos1 = texto.Trim().ToUpper().IndexOf("<DESCERROR>", pos1 + 1);
                    pos2 = texto.Trim().ToUpper().IndexOf("</DESCERROR>", pos2 + 1);
                }
            }
            return (result.Equals("INI") ? "OK" : result);
        }

        private DataSet ObtenerDTSConDatos_SMP(string iIdSolicitudes)
        {
            string[] lPartes = null; string lSql = ""; DataSet lDtsDatos = new DataSet(); int i = 0;
            Ws_TO.Ws_ToSoapClient lPX = new Ws_TO.Ws_ToSoapClient();

            lPartes = iIdSolicitudes.Split(new Char[] { ',' });

            for (i = 0; i < lPartes.Length; i++)
            {
                if (lPartes[i].ToString().Trim().Length > 0)
                {
                    lSql = string.Concat(" SP_Consultas_WS 67,'", lPartes[i].ToString(), "','','','','','',''");
                    lDtsDatos.Merge(lPX.ObtenerDatos(lSql));
                }
            }


            return lDtsDatos;
        }

        public  void EnvioCorreo(string iIdSolicitudes, string iUsuario, string iMaq)
        {
            Ws_TO.Ws_ToSoapClient lPX = new Ws_TO.Ws_ToSoapClient(); DataSet lDts = new DataSet();
            int i = 0; string lTblHtml = ""; DataTable lTbl = new DataTable(); Clases.ClsComun lCom = new Clases.ClsComun();
            string lFuente = ""; string lUrl = "";



            //  lSql = string.Concat (" SP_Consultas_WS 67,'", iIdSolicitudes, "','','','','','',''");
            //lDts = lPX.ObtenerDatos(lSql);

            lDts = ObtenerDTSConDatos_SMP(iIdSolicitudes);

            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                lTbl = lDts.Tables[0].Copy();
                //Concatenamos el texto de la cabecera
                lTblHtml = string.Concat(" Hola Estimados:  <br>  A continuación se muestra el estado de la Solicitud de Materia Prima al momento del cierre de turno <br> ");
                lTblHtml = string.Concat(lTblHtml, "    El Usuario <b>", iUsuario, "</b> de la maquina <b>", iMaq, "</b>, ha Solicitado y producido lo siguiente:  <br> ");
                lTblHtml = string.Concat(lTblHtml, "  <br> <br>   <table border = '1' >  <tr>   ");
                lTblHtml = string.Concat(lTblHtml, " <td style = 'font - family: Arial; font - weight: bold; font - size: 12px;'>  Id Solicitud </ td >  ");
                lTblHtml = string.Concat(lTblHtml, " <td style = 'font-family: Arial; font-weight: bold; font-size: 12px;'>Fecha Sol </ td >   ");
                lTblHtml = string.Concat(lTblHtml, " <td style = 'font-family: Arial; font-weight: bold; font-size: 12px;'>Codigo </ td >   ");
                lTblHtml = string.Concat(lTblHtml, " <td style = 'font-family: Arial; font-weight: bold; font-size: 12px;'>Descripcion </ td >");
                lTblHtml = string.Concat(lTblHtml, " <td style = 'font-family: Arial; font-weight: bold; font-size: 12px;'>Observaciones </ td >");
                lTblHtml = string.Concat(lTblHtml, " <td style = 'font-family: Arial; font-weight: bold; font-size: 12px;'>Origen </ td >");
                lTblHtml = string.Concat(lTblHtml, " <td style = 'font-family: Arial; font-weight: bold; font-size: 12px;'>Soldable </ td > ");
                lTblHtml = string.Concat(lTblHtml, " <td style = 'font-family: Arial; font-weight: bold; font-size: 12px;'>Kgs Solicitados </ td >");
                lTblHtml = string.Concat(lTblHtml, " <td style = 'font-family: Arial; font-weight: bold; font-size: 12px;'>Kgs Recepcionados </ td >");
                lTblHtml = string.Concat(lTblHtml, " <td style = 'font-family: Arial;font-weight: bold; font-size: 12px;'>Kgs Producidos </ td >");
                lTblHtml = string.Concat(lTblHtml, " <td style = 'font-family: Arial ; font-weight: bold; font-size: 12px;'>% Producido </ td >");
                lTblHtml = string.Concat(lTblHtml, " <td style = 'font-family: Arial ; font-weight: bold; font-size: 12px;'>Saldo (kgs)  </ td >");
                lTblHtml = string.Concat(lTblHtml, " <td style = 'font-family: Arial;font-weight: bold; font-size: 12px;'>Integrado INET </ td >");
                lTblHtml = string.Concat(lTblHtml, " <td style = 'font-family: Arial;font-weight: bold; font-size: 12px;'>Es Recuperado </ td >");
                lTblHtml = string.Concat(lTblHtml, " </tr> ");

                for (i = 0; i < lTbl.Rows.Count; i++)
                {
                    lTblHtml = string.Concat(lTblHtml, " <tr> ");
                    //if (lCom.Val(lCom.ParteEntera(lTbl.Rows[i]["% producido"].ToString())) < 95)
                    //{
                    lFuente = "<td style='font-family: Arial;font - weight: bold; font-size: 12px;'> ";
                    //}
                    //else
                    //{ lFuente = "<td style='font-family: Arial;  font-size: 12px;'> "; }

                   
                    //lTblHtml = string.Concat(lTblHtml, lFuente, " <A HREF='", lUrl,"'>",  lTbl.Rows[i]["IdSol"].ToString(), "</A> </td >");
                    lTblHtml = string.Concat(lTblHtml, lFuente, lTbl.Rows[i]["IdSol"].ToString(), " </td >");
                    lTblHtml = string.Concat(lTblHtml, lFuente, lTbl.Rows[i]["FechaSol"].ToString(), "</td >");
                    lTblHtml = string.Concat(lTblHtml, lFuente, lTbl.Rows[i]["Codigo"].ToString(), "</td >");
                    lTblHtml = string.Concat(lTblHtml, lFuente, lTbl.Rows[i]["Descripcion"].ToString(), "</td >");
                    lTblHtml = string.Concat(lTblHtml, lFuente, lTbl.Rows[i]["DET_OBS_RECEP"].ToString(), "</td >");

                    lTblHtml = string.Concat(lTblHtml, lFuente, lTbl.Rows[i]["Origen"].ToString(), "</td >");
                    lTblHtml = string.Concat(lTblHtml, lFuente, lTbl.Rows[i]["Soldable"].ToString(), "</td >");
                    lTblHtml = string.Concat(lTblHtml, lFuente, lTbl.Rows[i]["DET_KILOS"].ToString(), "</td >");
                    lTblHtml = string.Concat(lTblHtml, lFuente, lTbl.Rows[i]["DET_KILOS_RECEP"].ToString(), "</td >");
                    lTblHtml = string.Concat(lTblHtml, lFuente, lTbl.Rows[i]["DET_KILOS_PRODUCIDOS"].ToString(), "</td >");
                    lTblHtml = string.Concat(lTblHtml, lFuente, lTbl.Rows[i]["% producido"].ToString(), "</td >");
                    lTblHtml = string.Concat(lTblHtml, lFuente, lTbl.Rows[i]["Saldo"].ToString(), "</td >");
                    lTblHtml = string.Concat(lTblHtml, lFuente, lTbl.Rows[i]["DET_INET_MSG"].ToString(), "</td >");
                    lTblHtml = string.Concat(lTblHtml, lFuente, lTbl.Rows[i]["SOL_ES_RECUPERADO"].ToString(), "</td >");


                    lTblHtml = string.Concat(lTblHtml, " </tr>  ");
                }
            }


            lTblHtml = string.Concat(lTblHtml, "</table>  <br> <br> No responder a este correo, ya que fue generado de forma automatica <br> <br> ");
            lTblHtml = string.Concat(lTblHtml, "  Los acentos han sido eliminados para evitar problemas con caracteres extaños ");


            //[SP_Consultas_WS]         @Opcion INT, @Par1 Varchar(100), @Par2 Varchar(100), @Par3 Varchar(150), @Par4 Varchar(100),
            //@Par5 Varchar(100),  @Par6 Varchar(100), @Par7 Varchar(100)

            //MessageBox.Show("Asunto: Cierre de solicitudes" + Environment.NewLine + "Cuerpo:" + Environment.NewLine + cuerpo);
            //WsMensajeria.Ws_ToSoapClient wsMensajeria = new WsMensajeria.Ws_ToSoapClient();
            string result = lPX.EnviaNotificacionesEnviaMsgDeNotificacion("Sistema de notificaciones S.M.P.", lTblHtml, -600, "Gestion de Materia Prima ");
        }

        public void EnvioCorreo_Notificacion_RRHH( string iUsuario, string iMaq)
        {
            Ws_TO.Ws_ToSoapClient lPX = new Ws_TO.Ws_ToSoapClient();  
              string lTblHtml = "";   Clases.ClsComun lCom = new Clases.ClsComun();
            string lFuente = ""; string lFecha = string.Concat(DateTime.Now.ToShortDateString(), " ", DateTime.Now.ToShortTimeString());

        lTblHtml = string.Concat("<b> Estimados Supervisores : </b>  <br>");

            lTblHtml = string.Concat(lTblHtml, "  Se les comunica que siendo  las <b>", lFecha, " </b>, la aplicación de <b> SOLICITUD DE MATERIA  <br> ");
            lTblHtml = string.Concat(lTblHtml, " PRIMA </b>  detectó  que el usuario   <b>", iUsuario, " </b> no cerró oportunamente se sesión en la máquina  <br> ");
            lTblHtml = string.Concat(lTblHtml,  iMaq, ". Ante esto, favor proceder  con la reinstrucción  del usuario y su correspondiente   <br> ");
            lTblHtml = string.Concat(lTblHtml,  " firma de registro .  <br>  <br>  <br>  ");

            // ", iUsuario, "</b> de la maquina <b>", iMaq, "</b>, ha Solicitado y producido lo siguiente:  <br> ");
            lTblHtml = string.Concat(lTblHtml, " Estimados Sres. RRHH: <br>  ");
            lTblHtml = string.Concat(lTblHtml, " Si esta  notificación tiene carácter  de reincidencia para el usuario  <b> ", iUsuario , " </b>  Favor  proceder <br>");
            lTblHtml = string.Concat(lTblHtml, " con la Notificación  <b> (Carta de Advertencia al usuario) </b>  por incumplimiento reiterado de las  <br>  ");
            lTblHtml = string.Concat(lTblHtml, " instrucciones impartidas por su superior directo  <br><br>  ");

            lTblHtml = string.Concat(lTblHtml, " No responda este mensaje, ya que ha sido  creado de forma  automática<br><br>  ");

          
            string result = lPX.EnviaNotificacionesEnviaMsgDeNotificacion("Sistema de notificaciones cierre automatico S.M.P.", lTblHtml, -650, "Gestion de Materia Prima ");
        }


        public string CreaXmlEntradaProductosTerminados_INET_SolicitudMP(Ws_TO.Objeto_WsINET iObj)
        {
            String lRes = ""; int i = 0;
            //Dim lRes As String, lEntDoc As New Tipo_EntDoc, i As Integer = 0
            //Dim lDetDoc As New Tipo_DetDoc, lResumenDoc As New Tipo_ResumenDoc
            String lXML = ""; String lRes1 = ""; String lXmlFinal = "";

            //sb.Append("<SDT_TRANSPORTE xmlns=\"http://www.informat.cl/ws\">");

            lRes = String.Concat("<SDT_TRANSPORTE xmlns=\"http://www.informat.cl/ws\">", Environment.NewLine);
            lRes = String.Concat(lRes, "<ACCION>ins</ACCION> ", Environment.NewLine);
            lRes = String.Concat(lRes, " <XML>", Environment.NewLine);
            lXML = String.Concat(lXML, "	<SDT_MOVEXISTENCIASALL xmlns=&quot;http://www.informat.cl/ws&quot;>", Environment.NewLine);
            lXML = String.Concat(lXML, "  <SDT_MOVEXISTENCIASALL.MOVIMIENTO> ", Environment.NewLine);
            lXML = String.Concat(lXML, "  	<TMETIP>", iObj.Tmetip.ToString(), "</TMETIP> ", Environment.NewLine);
            lXML = String.Concat(lXML, "  	<TMECOD>", iObj.Tmecod.ToString(), "</TMECOD> ", Environment.NewLine);
            lXML = String.Concat(lXML, "  	<MOVSUCCOD>", iObj.Movsuccod.ToString(), "</MOVSUCCOD> ", Environment.NewLine);
            lXML = String.Concat(lXML, "  	<MOVNUMDOC>", iObj.Movnumdoc.ToString(), "</MOVNUMDOC> ", Environment.NewLine);
            lXML = String.Concat(lXML, "  	<MOVFECDOC>", iObj.Movfecdoc.ToString(), "</MOVFECDOC> ", Environment.NewLine);
            lXML = String.Concat(lXML, "  	<MOVFECDIG>", iObj.Movfecdig.ToString(), "</MOVFECDIG>  ", Environment.NewLine);
            lXML = String.Concat(lXML, "  	<MOVHORDIG>", iObj.Movhordig.ToString(), "</MOVHORDIG>  ", Environment.NewLine);
            lXML = String.Concat(lXML, "  	<MOVBODCOD>", iObj.Movbodcod.ToString(), "</MOVBODCOD> ", Environment.NewLine);
            lXML = String.Concat(lXML, "  	<MOVBODSUC>", iObj.Movbodsuc.ToString(), "</MOVBODSUC> ", Environment.NewLine);
            lXML = String.Concat(lXML, "  	<MOVGLO1>", iObj.Movglo1.ToString(), "</MOVGLO1> ", Environment.NewLine);
            lXML = String.Concat(lXML, "  	<MOVGLO2>", iObj.Movglo2.ToString(), "</MOVGLO2> ", Environment.NewLine);
            lXML = String.Concat(lXML, "  	<MOVSIS>", iObj.Movsis.ToString(), "</MOVSIS> ", Environment.NewLine);
            lXML = String.Concat(lXML, "  	<MOVULTSEC>", iObj.Movultsec.ToString(), "</MOVULTSEC>", Environment.NewLine);

            for (i = 0; i < iObj.DetalleMov.Length; i++)
            {
                lXML = String.Concat(lXML, "  	<DETALLE>", Environment.NewLine);
                lXML = String.Concat(lXML, "  	            <SDT_MOVEXISTENCIASALL.MOVIMIENTO.DET_MOVTO>", Environment.NewLine);
                lXML = String.Concat(lXML, "  	            <DMONUMSEC>", iObj.DetalleMov[i].Dmonumsec.ToString(), "</DMONUMSEC>", Environment.NewLine);
                lXML = String.Concat(lXML, "  	            <PRDCOD>", iObj.DetalleMov[i].Prdcod.ToString(), "</PRDCOD>", Environment.NewLine);
                lXML = String.Concat(lXML, "  	            <PRDEXIPLA>", iObj.DetalleMov[i].Prdexipla.ToString(), "</PRDEXIPLA>", Environment.NewLine);
                lXML = String.Concat(lXML, "  	            <DMOPLACOD>", iObj.DetalleMov[i].Dmoplacod.ToString(), "</DMOPLACOD>", Environment.NewLine);
                lXML = String.Concat(lXML, "  	            <DMOCENCOD>", iObj.DetalleMov[i].Dmocencod.ToString(), "</DMOCENCOD>", Environment.NewLine);
                lXML = String.Concat(lXML, "  	            <DMOITECOD>", iObj.DetalleMov[i].Dmoitecod.ToString(), "</DMOITECOD>", Environment.NewLine);
                lXML = String.Concat(lXML, "  	            <DMOARECOD>", iObj.DetalleMov[i].Dmoarecod.ToString(), "</DMOARECOD>", Environment.NewLine);
                lXML = String.Concat(lXML, "  	            <DMOCAN>", iObj.DetalleMov[i].Dmocan.ToString(), "</DMOCAN>", Environment.NewLine);
                lXML = String.Concat(lXML, "  	            <DMOPREUNI>", iObj.DetalleMov[i].Dmopreuni.ToString(), "</DMOPREUNI>", Environment.NewLine);
                lXML = String.Concat(lXML, "  	            <DMOVALTOT>", iObj.DetalleMov[i].Dmovaltot.ToString(), "</DMOVALTOT>", Environment.NewLine);
                lXML = String.Concat(lXML, "  	            <INVMOV11>", iObj.DetalleMov[i].Invmov11.ToString(), "</INVMOV11>", Environment.NewLine);

                lXML = String.Concat(lXML, "  	            <INVMOV12>", iObj.DetalleMov[i].Invmov12.ToString(), "</INVMOV12>", Environment.NewLine);

                lXML = String.Concat(lXML, "  	            <INVMOV13>", iObj.DetalleMov[i].Invmov13.ToString(), "</INVMOV13>", Environment.NewLine);
                lXML = String.Concat(lXML, "  	            <INVMOV14>", iObj.DetalleMov[i].Invmov14.ToString(), "</INVMOV14>", Environment.NewLine);
                lXML = String.Concat(lXML, "  	            <INVMOV15>", iObj.DetalleMov[i].Invmov15.ToString(), "</INVMOV15>", Environment.NewLine);
                lXML = String.Concat(lXML, "  	            <INVMOV16>", iObj.DetalleMov[i].Invmov16.ToString(), "</INVMOV16>", Environment.NewLine);
                lXML = String.Concat(lXML, "  	            <INVMOV17>", iObj.DetalleMov[i].Invmov17.ToString(), "</INVMOV17>", Environment.NewLine);
                lXML = String.Concat(lXML, "  	  </SDT_MOVEXISTENCIASALL.MOVIMIENTO.DET_MOVTO>", Environment.NewLine);
                lXML = String.Concat(lXML, "</DETALLE> ", Environment.NewLine);
            }



            lXML = String.Concat(lXML, "<MOVVALTOT>", iObj.Movvaltot.ToString(), "</MOVVALTOT> ", Environment.NewLine);
            lXML = String.Concat(lXML, "</SDT_MOVEXISTENCIASALL.MOVIMIENTO> ", Environment.NewLine);
            lXML = String.Concat(lXML, "</SDT_MOVEXISTENCIASALL> ", Environment.NewLine);

            lRes1 = String.Concat(lRes1, "</XML>", Environment.NewLine);
            lRes1 = String.Concat(lRes1, "</SDT_TRANSPORTE>", Environment.NewLine);

            //'cambiamos los caracteres 
            //'        NOTA: Se realizó un encoding al XML con transporte, por lo cual:
            //'el signo < se reemplazó por &lt; 
            //'el signo > se reemplazó por &gt;
            lXML = lXML.Replace("<", "&lt;");
            lXML = lXML.Replace(">", "&gt;");

            lXmlFinal = String.Concat(lRes, lXML, lRes1);
            return lXmlFinal;

        }

        public Integracion_INET.MovExistencias CargaObjEntradaBodegaProdTerm_INET(Ws_TO.Objeto_WsINET iObjINET)
        {
            Integracion_INET.MovExistencias lRes = new Integracion_INET.MovExistencias();
            Integracion_INET.MovExistenciasAll lExAll = new Integracion_INET.MovExistenciasAll();
            Integracion_INET.MovExistenciasDet lExDet = new Integracion_INET.MovExistenciasDet();
            int i = 0;


            // 'Secuencia del detalle

            lRes.ExistenciasDet.DMONUMSEC = iObjINET.DetalleMov[0].Dmonumsec;// Dmonumsec; //"1";
            lRes.ExistenciasDet.PRDCOD = iObjINET.DetalleMov[0].Prdcod;// iCodProd '"63OGP1"
            lRes.ExistenciasDet.PRDEXIPLA = iObjINET.DetalleMov[0].Prdexipla;// "1109009"
            lRes.ExistenciasDet.DMOPLACOD = iObjINET.DetalleMov[0].Dmoplacod;// "1109008"
            lRes.ExistenciasDet.DMOCENCOD = iObjINET.DetalleMov[0].Dmocencod;// "0"
            lRes.ExistenciasDet.DMOITECOD = iObjINET.DetalleMov[0].Dmoitecod;//  "0"
            lRes.ExistenciasDet.DMOARECOD = iObjINET.DetalleMov[0].Dmoarecod;// "0"


            lRes.ExistenciasDet.DMOCAN = iObjINET.DetalleMov[0].Dmocan;// String.Concat(iTotalKgs.ToString, ".0000") '"15523.0000"  '--Kilos
            lRes.ExistenciasDet.DMOPREUNI = iObjINET.DetalleMov[0].Dmopreuni;// String.Concat(iPrecioCosto.ToString, ".00") ' "420.00"      'Precio Unitario COSTO
            lRes.ExistenciasDet.DMOVALTOT = iObjINET.DetalleMov[0].Dmovaltot;// String.Concat(mTotalCosto.ToString, ".00") ' "6519660.00"   '--Total
            lRes.ExistenciasDet.INVMOV11 = iObjINET.DetalleMov[0].Invmov11;// "0.0000"
            lRes.ExistenciasDet.INVMOV12 = iObjINET.DetalleMov[0].Invmov12;// "0.00"
            lRes.ExistenciasDet.INVMOV13 = iObjINET.DetalleMov[0].Invmov13;// "0.00"
            lRes.ExistenciasDet.INVMOV14 = iObjINET.DetalleMov[0].Invmov14;// "0.0000"
            lRes.ExistenciasDet.INVMOV15 = iObjINET.DetalleMov[0].Invmov15;// "0.00"
            lRes.ExistenciasDet.INVMOV16 = iObjINET.DetalleMov[0].Invmov16;// "0.0000"
            lRes.ExistenciasDet.INVMOV17 = iObjINET.DetalleMov[0].Invmov17;// "0.0000"


            //'Indica el tipo movimiento (1=Entrada,2=salida)
            lRes.ExistenciasAll.TMETIP = iObjINET.Tmetip;// "1";//   'Entrada a productos terminados
            //'Indica el código del movimiento (T)
            lRes.ExistenciasAll.TMECOD = iObjINET.Tmecod;// "30"
            //'Código de sucursal (T)
            lRes.ExistenciasAll.MOVSUCCOD = iObjINET.Movsuccod;// mCodigoSucursal_INET '"1"    '1casa matriz stgo  2 calama
            //'Numero de movimiento  debe ser un correlativo y se debe aumentar en uno actualmente va en 90001
            //'      MessageBox.Show("Antes de ObtenerCampo_MovNumDoc.ToString ")
            //mMOVNUMDOC = ObtenerCampo_MovNumDoc.ToString

            lRes.ExistenciasAll.MOVNUMDOC = iObjINET.Movnumdoc;// mMOVNUMDOC    '"90002"
            //'Fecha del movimiento (aaaa-mm-dd)
            //'  MessageBox.Show("ANtes de ObtenerFechaActual ")
            lRes.ExistenciasAll.MOVFECDOC = iObjINET.Movfecdoc;// ObtenerFechaActual("A") '  "2013-08-19"
            //'   MessageBox.Show("Fechas :" & lObj.MOVFECDOC)
            //'Fecha de digitación del movimiento (aaaa-mm-dd)
            lRes.ExistenciasAll.MOVFECDIG = iObjINET.Movfecdig;  //ObtenerFechaActual("A")  '  "2013-08-19"
            //'Hora del movimiento (hh:mm:ss)
            lRes.ExistenciasAll.MOVHORDIG = iObjINET.Movhordig;// ObtenerHoraActual() ' "21:59:59"
            //'código de bodega (T)
            //'lObj.MOVBODCOD = "1"  '105 para santiag0  69 para calama
            lRes.ExistenciasAll.MOVBODCOD = iObjINET.Movbodcod;//  mCodigoBodega //' "105"  '105 para santiag0  69 para calama

            //'código de sucursal (T)
            lRes.ExistenciasAll.MOVBODSUC = iObjINET.Movbodsuc;// mCodigoSucursal_INET '"1"  ' '1casa matriz stgo  2 calama
            //'Glosa del movimiento (opcional)
            lRes.ExistenciasAll.MOVGLO1 = iObjINET.Movglo1;// iObs1 '"PRUEBAS DE INTEGRACION"
            //'Glosa del movimiento (opcional)
            lRes.ExistenciasAll.MOVGLO2 = iObjINET.Movglo2;
            //'Sistema (1=Existencias,4=importaciones),por defecto =1
            lRes.ExistenciasAll.MOVSIS = iObjINET.Movsis;// "1"
            //'Cantidad de líneas del detalle
            lRes.ExistenciasAll.MOVULTSEC = iObjINET.Movultsec;// "1"
            //'Valor total sumando todas las líneas
            lRes.ExistenciasAll.MOVVALTOT = iObjINET.Movvaltot;// String.Concat(mTotalCosto, ".00") // '"6519660.00"

            //lExDet = CargaObjMovExistenciaDet(mCodigoINET, mKilosCargados, mPrecioCostoKilo, mTotalCosto)
            //lExAll = CargaObjMovExistenciaAll(mViajesCargados)

            //lRes.ExistenciasAll = lExAll

            //lRes.ExistenciasDet = lExDet

            return lRes;
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
