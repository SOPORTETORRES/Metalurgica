using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Metalurgica.DTS
{
    public partial class Frm_ImportaCorrelativo : Form
    {
        private DataTable mTblDatos = new DataTable();

        private void CargaDatos()
        {

            string lSql = "Select * from correlativos "; DataTable lTbl = new DataTable();
            Clases.ClsComun lCom = new Clases.ClsComun(); DataSet lDts = new DataSet();
            lSql = "Select max(correlativo)  from correlativosRomana  ";
            Px_WS.Ws_ToSoapClient lPx = new Px_WS.Ws_ToSoapClient(); string LtlCorrCubigest = "";

            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                LtlCorrCubigest = lDts.Tables[0].Rows[0][0].ToString();

            lSql = string.Concat ("Select * from correlativos where correlativo>",LtlCorrCubigest ,"");
            mTblDatos = lCom.CargaTablaRomana(lSql);
            Dtg_Corr.DataSource = mTblDatos;


        
        }


        public Frm_ImportaCorrelativo()
        {
            InitializeComponent();
        }

        private void Btn_Cargar_Click(object sender, EventArgs e)
        {
            CargaDatos();
        }

        private void Btn_Insertar_Click(object sender, EventArgs e)
        {

            InsertarRegistros();

        }


        private void InsertarRegistros()
        {
            DataTable lTbl = new DataTable(); string lSql = "";
            Clases.ClsComun lCom = new Clases.ClsComun(); DataSet lDts = new DataSet();
            Px_WS.Ws_ToSoapClient lPx = new Px_WS.Ws_ToSoapClient(); string LtlCorrCubigest = "";

            //1.-Tabla correlativos
            DTS.DtsDatos.CorrelativosRomanaDataTable lTblRom = new DtsDatos.CorrelativosRomanaDataTable();
            DTS.DtsDatos.CorrelativosRomanaRow lFila = null;
            DTS.DtsDatosTableAdapters.CorrelativosRomanaTableAdapter lAdp = new DtsDatosTableAdapters.CorrelativosRomanaTableAdapter();
            int i = 0;
            int lCor = 0; int TicketAso = 0; int lPt = 0; int lPB = 0; int lBas = 0; float lVel = 0;
            lAdp.Connection.ConnectionString = "Data Source=192.168.1.192;Initial Catalog=Cubigest;Persist Security Info=True;User ID=informat;password=centauro";
            for (i = 0; i < mTblDatos.Rows.Count; i++)
            {
                lCor = int.Parse(mTblDatos.Rows[i]["Correlativo"].ToString());
                TicketAso = int.Parse(mTblDatos.Rows[i]["TicketAsociado"].ToString());
                lPB = int.Parse(mTblDatos.Rows[i]["PesoBruto"].ToString());
                lPt = int.Parse(mTblDatos.Rows[i]["PesoTara"].ToString());
                lBas = int.Parse(mTblDatos.Rows[i]["Bascula"].ToString());
                lVel = float.Parse(mTblDatos.Rows[i]["Velocidad"].ToString());

                lAdp.Insert(lCor, mTblDatos.Rows[i]["fecha"].ToString(), mTblDatos.Rows[i]["hora"].ToString(), mTblDatos.Rows[i]["nulo"].ToString(), mTblDatos.Rows[i]["metodo"].ToString(), mTblDatos.Rows[i]["TipoTicket"].ToString(), TicketAso, mTblDatos.Rows[i]["RutConductor"].ToString(), mTblDatos.Rows[i]["Destino"].ToString(), lPB, lPt, mTblDatos.Rows[i]["Patente"].ToString(), lBas, mTblDatos.Rows[i]["TipoCamion"].ToString(), lVel, mTblDatos.Rows[i]["RutUsuario"].ToString(), mTblDatos.Rows[i]["Envases"].ToString());

                Lbl_Msg.Text = string.Concat("PROCESANDO TABLA correlativos . . . ", i.ToString(), " de ", mTblDatos.Rows.Count.ToString());
                Lbl_Msg.Refresh();
                Application.DoEvents();
            }

            //2.-Tabla MAEDestinos                                             
            lSql = string.Concat("  select * from maedestinos ", "");
            mTblDatos = lCom.CargaTablaRomana(lSql);           
            for (i = 0; i < mTblDatos.Rows.Count; i++)
            {
               lSql=string.Concat ("exec  SP_Consultas_Bascula 1,'",mTblDatos.Rows[i]["codigo"].ToString(),"','','','','",mTblDatos.Rows[i]["descripcion"].ToString(),"'");
               lPx.ObtenerDatos(lSql);
               Lbl_Msg.Text = string.Concat("PROCESANDO TABLA MAEDestinos . . . ", i.ToString(), " de ", mTblDatos.Rows.Count.ToString());
                Lbl_Msg.Refresh();
                Application.DoEvents();
            }

            //2.-Tabla Destinos Correlativo                      
            lSql = string.Concat("  select * from destinoscorrelativos ", "");
            mTblDatos = lCom.CargaTablaRomana(lSql);
            
            for (i = 0; i < mTblDatos.Rows.Count; i++)
            {
                lSql = string.Concat("exec  SP_Consultas_Bascula 2,'", mTblDatos.Rows[i]["correlativo"].ToString(), "','",mTblDatos.Rows[i]["CodigoDestino"].ToString(),"','','',''");
                lPx.ObtenerDatos(lSql);
                Lbl_Msg.Text = string.Concat("PROCESANDO TABLA Destinos Correlativo  . . . ", i.ToString(), " de ", mTblDatos.Rows.Count.ToString());
                Lbl_Msg.Refresh();
                Application.DoEvents();
            }

            //3.-Tabla guiascorrelativos                     
            lSql = string.Concat("  select * from guiascorrelativos ", "");
            mTblDatos = lCom.CargaTablaRomana(lSql);

            for (i = 0; i < mTblDatos.Rows.Count; i++)
            {
                lSql = string.Concat("exec  SP_Consultas_Bascula 3,'", mTblDatos.Rows[i]["correlativo"].ToString(), "','", mTblDatos.Rows[i]["numeroGuia"].ToString(), "','','',''");
                lPx.ObtenerDatos(lSql);
                Lbl_Msg.Text = string.Concat("PROCESANDO TABLA MAEDestinos . . . ", i.ToString(), " de ", mTblDatos.Rows.Count.ToString());
                Lbl_Msg.Refresh();
                Application.DoEvents();
            }

            //4.-Tabla MaeVehiculo
            lSql = string.Concat("  select * from maevehiculos ", "");
            mTblDatos = lCom.CargaTablaRomana(lSql);

            for (i = 0; i < mTblDatos.Rows.Count; i++)
            {
                lSql = string.Concat("exec  SP_Consultas_Bascula 4,'", mTblDatos.Rows[i]["patente"].ToString(), "','", mTblDatos.Rows[i]["fecha"].ToString(), "','", mTblDatos.Rows[i]["hora"].ToString(), "','", mTblDatos.Rows[i]["ticketasociado"].ToString(), "',''");
                lPx.ObtenerDatos(lSql);
                Lbl_Msg.Text = string.Concat("PROCESANDO TABLA MAEDestinos . . . ", i.ToString(), " de ", mTblDatos.Rows.Count.ToString());
                Lbl_Msg.Refresh();
                Application.DoEvents();
            }
        
        
        }





    }
}
