using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Configuration;

namespace Metalurgica.Informes
{
    public partial class Frm_Visualizador : Form
    {
        DataSet mDtsInforme = new DataSet();
        DataSet mDatos = new DataSet();
        string mInforme = "";
        string mViaje = "";
        string mPathPdf = "";
        Boolean mEliminaArchivo = false;
        private string mDespachos="";

        public Frm_Visualizador()
        {
            InitializeComponent();
        }
        public void Inicia(string lDespachos)
        {
            mDespachos = lDespachos;        
        }
        public void InicializaInforme(String lTipoInf, DataSet iDts, string lVIaje, Boolean iEliminaArchivo)
        {
            mDtsInforme = iDts;
            mInforme = lTipoInf;
            mViaje = lVIaje;
            mEliminaArchivo = iEliminaArchivo;
            mPathPdf = ConfigurationManager.AppSettings["PathPdf"].ToString();
        }

        public void InciaPathPdf()
        {
            //value="C:\Cubigest\Informes\" 



        }

        public void CargarInforme(DataSet  lDts ) 
        {
       
            Rpt_DetalleDespacho mReport=new Rpt_DetalleDespacho ();

            //Dim mReport As New CrystalReport1
            if  (lDts != null )
            {
                if (lDts.Tables .Count >0 )
                {
                    mDatos = lDts;
                    mReport.SetDataSource(lDts);
                    this .crystalReportViewer1 .ReportSource =mReport ;
                    //CrystalReportViewer1.ReportSource = mReport
                
                }
              
            }

    }
        private string ObtenerViajes()
        {
            DataTable lTbl = new DataTable();
            string lViajes = ""; int i = 0;
            lTbl = mDatos.Tables["Detalle"].Copy();
            for (i = 0; i < lTbl.Rows.Count; i++)
            {
                lViajes = string.Concat(lViajes, lTbl.Rows[0][0].ToString (), "-");
            }


            return lViajes;
        }

        public void GeneraPdf_DetalleDespacho(DataSet lDts )
        {
            //este Siempre sera un Archivo
            string lPathArchivo = mPathPdf; //string.Concat("c:\\Informes\\TMP\\");
            string lArchivo = "";
            try
            {
                Rpt_DetalleDespacho mReport = new Rpt_DetalleDespacho();
                if (Directory.Exists(lPathArchivo) == false)
                {
                    Directory.CreateDirectory(lPathArchivo);
                }

                if (lDts != null)
                {
                    if (lDts.Tables.Count > 0)
                    {
                        mDatos = lDts;
                        mReport.SetDataSource(lDts);
                        this.crystalReportViewer1.ReportSource = mReport;
                        lArchivo = string.Concat(lPathArchivo, "DD.pdf");
                        if (File.Exists(lArchivo) == true)
                            File.Delete(lArchivo);
                        mReport.ExportToDisk (CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, lArchivo);
                    }
                }            
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        public void GeneraPdf()
        {
            int lRes = 0;
            if (mDtsInforme != null)
            {
                //string lPathArchivo = "X:\\Gerencia de Logistica\\Guias de Despacho\\Escaneados\\IT\\";
                string lPathArchivo = mPathPdf;//string.Concat ("C:\\Informes\\TMP\\") ;
                string lArchivo = "";
                // CargarInforme(mDtsInforme, lInforme);
                Cursor = Cursors.WaitCursor;
                try
                {
                    string[] separators = { "-" };
                    if (mViaje.ToString ().Length ==0)
                    {
                        mViaje = ObtenerViajes();
                    }
                    string[] lPartes = mViaje.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                    if (lPartes.Length > 1)
                    {
                        lPathArchivo = string.Concat(lPathArchivo, lPartes[0], "\\");
                        if (Directory.Exists(lPathArchivo) == false)
                        {
                            Directory.CreateDirectory(lPathArchivo);
                        }
                        switch (mInforme.ToUpper())
                        {
                            case "P":
                                lArchivo = string.Concat(lPathArchivo, mViaje.Replace("/", "_"), "C.pdf");
                                if (mEliminaArchivo == true)
                                {
                                    if (File.Exists(lArchivo) == true)
                                        File.Delete(lArchivo);
                                }
                                Rpt_PortadaPLDesp  mReport = new Rpt_PortadaPLDesp();
                                mReport.SetDataSource(mDtsInforme);
                                this.crystalReportViewer1.ReportSource = mReport;
                                mReport.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, lArchivo);
                                GrabaGeneracion_PL(mViaje, lPathArchivo, "P");


                                break;

                            case "D":
                                //lArchivo = string.Concat(lArchivo, mViaje.Replace("/", "_"), "D.pdf");
                                lArchivo = string.Concat(lPathArchivo, mViaje.Replace("/", "_"), "D.pdf");
                                if (mEliminaArchivo == true)
                                {
                                    if (File.Exists(lArchivo) == true)
                                        File.Delete(lArchivo);
                                }

                                Rpt_DetallePLDesp mReportD = new Rpt_DetallePLDesp();
                                mReportD.SetDataSource(mDtsInforme);
                                this.crystalReportViewer1.ReportSource = mReportD;
                                mReportD.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, lArchivo);
                                GrabaGeneracion_PL(mViaje, lPathArchivo, "D");
                                break;

                        }
                    }
                    if (lRes == 2)
                    { }
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }

        private void GrabaGeneracion_PL(string iViaje, string iPath, string iTipo)
        {
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient(); DataSet lDts = new DataSet();
            //WsMensajeria.Ws_To lPx = new WsMensajeria.Ws_To(); DataSet lDts = new DataSet();

            string lSql = string.Concat(" insert into ViajesImpresos (codigo, Tipo, FechaImpresion, Path ) Values ('");
            lSql = string.Concat(lSql, iViaje, "','", iTipo, "',getdate(),'", iPath, "') ");
            lDts = lPx.ObtenerDatos(lSql);


        }
        private void Frm_Visualizador_Load(object sender, EventArgs e)
        {
            //ImprimeInformeCarga();
        }
    }
}
