using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Metalurgica.Muestreo
{

    public partial class Frm_SolicitaMuestreo : Form
    {
        private CurrentUser mUserLog=new CurrentUser() ;
        private string mKilosMuestreo = "0";
         private string mIdMuestreo = "0";

        public Frm_SolicitaMuestreo()
        {
            InitializeComponent();
        }



        private void Btn_grabar_Click(object sender, EventArgs e)
        {
            // al grabar se deben persistir los datos, se debe enviar mail a lista de distribucion para notificar
            // El Muestreo debe quedar en estado Pendiente de Retiro de Muestra

            GrabaSolicitud();

        }

        private void GrabaSolicitud()
             {
    //        ALTER  PROCEDURE [dbo].[SP_CRUD_SolicitaRetiroMuestra]
     //@id int ,                     //@FechaSolicitud datetime,      //@IdUser int,        /@IdMaquina int,
    //@KilosProducidos  int,        //@IdMuestreo int,              //@Estado varchar(20),	/@MailEnviado varchar(1),
    //@Obs varchar(max),	    //@Par1 varchar(20),                //@Par2 varchar(20),    //@Opcion int 
                 Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient(); DataSet lDts = new DataSet();
                 string lSql = ""; Boolean lMailenviado = false;
         //   try
                {
                 lMailenviado = EnviaMail();
                 lSql = string.Concat(" exec SP_CRUD_SolicitaRetiroMuestra 0,'", DateTime.Now, "',", mUserLog.Iduser, ",");
                 lSql = string.Concat(lSql, mUserLog.IdMaquina, ",", tx_KilosProdicidos.Text, ",", mIdMuestreo, ",'','", lMailenviado, "','");
                 lSql = string.Concat(lSql, Tx_Obs .Text ,"','','',1");                 
                 lDts = lPx.ObtenerDatos(lSql);
                }
             }

        private Boolean EnviaMail()
        {
            Boolean lRes = true ; string lMsg = "";
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient();

            lMsg = string.Concat(" Hola Estimados: ", Environment.NewLine, "  EL usuario: ", Tx_Nombre.Text, " ha generado un Retiro de muestra, según los sigiuente datos  ", Environment.NewLine);
            lMsg = string.Concat(lMsg, " Diámetro: ", TX_Daimetro.Text, Environment.NewLine);
            lMsg = string.Concat(lMsg, " Kilos Muestreo: ", mKilosMuestreo.ToString(), " - Kilos Producidos : ", tx_KilosProdicidos.Text, Environment.NewLine);
            lMsg = string.Concat(lMsg, " fecha solicitud: ", tx_FechaHora.Text, Environment.NewLine);
            lMsg = string.Concat(lMsg, " Máquina que solicita la muestra: ",Tx_Maquina .Text , Environment.NewLine);

            lPx.EnviaNotificacionesEnviaMsgDeNotificacion(" Solicitud de Retiro Muestra ", lMsg, -300, "Solicitud de Retiro Muestra");

            return lRes;
        }

        public  void CargaDatos(DataTable  iTblMuestreo, CurrentUser iUserLog, string iKgsProducidos)
        {
            mUserLog = iUserLog;
            Tx_Nombre.Text = mUserLog.Name;
            tx_FechaHora .Text =DateTime.Today.ToShortDateString ();
            Tx_Maquina.Text = mUserLog.IdMaquina.ToString ();

            TX_Daimetro.Text = iTblMuestreo.Rows[0]["Diametro"].ToString();
            Tx_Kilos.Text = iTblMuestreo.Rows[0]["KilosMuestreo"].ToString();
            Tx_fechaInicio.Text = iTblMuestreo.Rows[0]["FechaInicio"].ToString();
            tx_KilosProdicidos.Text = iKgsProducidos;
            mKilosMuestreo = iTblMuestreo.Rows[0]["KilosMuestreo"].ToString();
            mIdMuestreo= iTblMuestreo.Rows[0]["Id"].ToString();
        }

        private void Btn_Salir_Click(object sender, EventArgs e)
        {
            EnviaMail();
            Close();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Frm_RetiraMuestra lFrm = new Frm_RetiraMuestra();
            lFrm.IniciaForm(mIdMuestreo);
            lFrm.ShowDialog();                       
        }
    }
}
