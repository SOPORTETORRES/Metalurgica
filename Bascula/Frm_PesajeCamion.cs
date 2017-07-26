using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Metalurgica.Bascula
{
    
    public partial class Frm_PesajeCamion : Form
    {
        private CurrentUser mUserLog = new CurrentUser();
        public Frm_PesajeCamion()
        {
            InitializeComponent();
        }

        private void Btn_ObtenerTara_Click(object sender, EventArgs e)
        {
            string lTara = ObtenerTara();
            this.Tx_Tara.Text = lTara;
            

        }

        public void IniciaForm( CurrentUser iUseActivo)
        {
            mUserLog = iUseActivo;
            this.Dtp_FechaActual.Value = DateTime.Now;
            this.Dtp_FechaActual.MaxDate = DateTime.Now;
            this.Dtp_FechaActual.MinDate = DateTime.Now .AddDays(-1);
        }


        #region Metodos privados de la clase

        private string ObtenerTara()
        {
            string lRes = "";string lSql = ""; Clases.SqlBascula lTipoSql=new Clases.SqlBascula ();
            DataTable lTbl = new DataTable();Clases.ClsComun lDAL = new Clases.ClsComun();
            string lFecha = DateTime.Now.ToShortDateString();

            lTbl = lDAL.CargaTablaRomana(lTipoSql.ObtenerSqlTara(Tx_Patente.Text, lFecha));

            if (lTbl.Rows.Count > 0)
            {
                lRes = lTbl.Rows[0]["PesoTara"].ToString();

            }
            return lRes;
        }


        private String GrabarDatos()
        {
            WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
            WsOperacion.PesajeCamion lObjCam = new WsOperacion.PesajeCamion();
            lObjCam.Id = 0;
            lObjCam.Patente = Tx_Patente.Text;
            lObjCam.PesoTara = int.Parse ( Tx_Tara.Text);
            lObjCam.FechaTara = DateTime.Now.ToString();
            lObjCam.IdUserTara = int.Parse (mUserLog.Iduser);
            lObjCam.PesoBruto = 0;
            lObjCam.IdDespachoCam = 0;
            lObjCam.Estado = "PesoTara";
            lObjCam = wsOperacion.GrabarDatosPesajeCamion(lObjCam);

            return "";
        }


        #endregion

        private void Btn_Grabar_Click(object sender, EventArgs e)
        {
            GrabarDatos();
        }
    }
}
