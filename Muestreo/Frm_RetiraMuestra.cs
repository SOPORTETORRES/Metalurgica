using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using CommonLibrary2;
using System.Text;
using System.Windows.Forms;


namespace Metalurgica.Muestreo
{
    public partial class Frm_RetiraMuestra : Form
    {
        public Frm_RetiraMuestra()
        {
            InitializeComponent();
        }

        private void CargaDatosMuestreo(int iIDSolMuestreo)
        {
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient(); DataSet lDts = new DataSet();
            string lSql = "";
            lSql = string.Concat(" Select * from SolicitaRetiroMuestra s, muestreos m  where s.Id=", iIDSolMuestreo);
            lSql = string.Concat(lSql, " and  m.id=s.IdMuestreo ");                
            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables .Count >0) && (lDts.Tables[0].Rows .Count >0))
            {
                Tx_IdMuestreo.Text = lDts.Tables[0].Rows[0]["IdMuestreo"].ToString();
                Tx_Diametro.Text = lDts.Tables[0].Rows[0]["Diametro"].ToString();
                Tx_FechaSolicitud.Text = lDts.Tables[0].Rows[0]["FechaSolicitud"].ToString();
                Tx_IdSolicitudMuestreo.Text = lDts.Tables[0].Rows[0]["Id"].ToString();
                Tx_KilosMuestreo.Text = lDts.Tables[0].Rows[0]["KilosMuestreo"].ToString();
                tx_KilosProducidos.Text = lDts.Tables[0].Rows[0]["KilosProducidos"].ToString();
            }


        }

        
            public void IniciaForm(string iIDSolMuestreo)
        {
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient(); DataSet lDts = new DataSet();
            string lSql = "";
            lSql = string.Concat(" Select * from SolicitaRetiroMuestra s, muestreos m  where s.Id=", iIDSolMuestreo);
            lSql = string.Concat(lSql, " and  m.id=s.IdMuestreo ");
            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                Tx_IdMuestreo.Text = lDts.Tables[0].Rows[0]["IdMuestreo"].ToString();
                Tx_Diametro.Text = lDts.Tables[0].Rows[0]["Diametro"].ToString();
                Tx_FechaSolicitud.Text = lDts.Tables[0].Rows[0]["FechaSolicitud"].ToString();
                Tx_IdSolicitudMuestreo.Text = lDts.Tables[0].Rows[0]["Id"].ToString();
                Tx_KilosMuestreo.Text = lDts.Tables[0].Rows[0]["KilosMuestreo"].ToString();
                tx_KilosProducidos.Text = lDts.Tables[0].Rows[0]["KilosProducidos"].ToString();
                this.Tx_Obs.Text = lDts.Tables[0].Rows[0]["Obs"].ToString();
            }


        }


            private void CargaDatosUsuario()
        {
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient(); DataSet lDts = new DataSet();
            string lSql = "";
            lSql = "exec SP_ConsultasGenerales 29,'','','','',''";
            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                //Cmb_UsuarioRetira.sev
                //Cmb_UsuarioRetira.DataSource = lDts.Tables[0].Copy();
                new Forms().comboBoxFill(Cmb_UsuarioRetira, lDts.Tables[0].Copy(), "Id", "Usuario", 0);
            }
        }

        private void Btn_grabar_Click(object sender, EventArgs e)
        {
            IniciaForm("1");
        }

        private void Frm_RetiraMuestra_Load(object sender, EventArgs e)
        {
            CargaDatosUsuario();
        }   
      
    }
}
