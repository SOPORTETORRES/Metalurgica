using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data ;
using CommonLibrary2;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.OleDb;

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

        public string ObtenerParametroAppConfig( string iParam)
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
            lPath = string.Concat(iPathIni, "\\",lArchivoIntINET );
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
                decimal resp = Convert.ToInt64 (iValor);
                iRes= true;
            }
            catch //caso contrario, es falso.
            {
                iRes= false;
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

        public int  Val(string iValor)
        {
            int  iRes = 0;

            //Sencillamente, si se logra hacer la conversión, entonces es número
            try
            {                
                iRes = int.Parse(iValor);
            }
            catch //caso contrario, es falso.
            {
                iRes = -1;
            }

            return iRes;

        }

        public string  ParteEntera(string iValor)
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
                iRes ="";
            }

            return iRes;

        }

        public  DataTable CargaTablaObras()
        {
            DataTable lTbl = new DataTable(); DataSet lDts = new DataSet(); string lSql = "";
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient();
            string lEmpresa = ConfigurationManager.AppSettings["Empresa"].ToString();
            lSql = string.Concat("  Select id, Nombre Obra  from Obras where empresa='", lEmpresa, "' and  EstadoAlta not in ('FIN') order by nombre ");
            lDts = lPx.ObtenerDatos(lSql);
            if (lDts.Tables.Count > 0 && lDts.Tables[0].Rows.Count > 0)
            {
                lTbl = lDts.Tables[0].Copy();
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

        public string ObtenerKilos (string iLargo,string iDiametro, int  iCantidad)
        {
            //El largo debe esta en Metros
            DataTable lTbl = new DataTable(); DataSet lDts = new DataSet();
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient();
            string lRes = "";

            lRes = lPx.ObtenerPesoBechtell(iLargo, iDiametro, iCantidad).ToString ();

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
            lSql= string.Concat ("SP_ConsultasGenerales 53,'','','','',''");            
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
            lSql = string.Concat("SP_ConsultasGenerales 70,'",lIdSucursal,"','','','',''");
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
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient();  string lRes = "";

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



         private DataTable   CargaTabla( string  iSql ) 
    {
        DataTable lTbl = new DataTable(); string lError = "";
        //'Dim lCnnStr As String = "Data Source=localhost\SQLExpress;Initial Catalog=CubiCad;User id=CnnCubicad;Password=t.o2011;"
        string  lCnnStrs = "Persist Security Info=False;Trusted_Connection=True; database=Pruebas;server=DES-RBECERRA";
        System.Data.SqlClient.SqlConnection lCnn=new System.Data.SqlClient.SqlConnection(lCnnStrs.ToString ());
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

        return   lTbl;
        }
    }


  
}
