using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Metalurgica.SolicitudMP
{
    public partial class FrmDevolucionMP : Form
    {
        private string mDet_Id = "";
        private string mDiam = "";
        private string mLargo = "";
        private CurrentUser mUserLog = new CurrentUser();

        public FrmDevolucionMP()
        {
            InitializeComponent();
        }

        private string  ObtenerKilos(int iCantidad, int iLargo, int iDiametro)
        {
            Clases.ClsComun lDal = new Clases.ClsComun(); string lKilos = "";
            int lCantidad =  iCantidad;
            lKilos = lDal.ObtenerKilos(iLargo.ToString (), iDiametro.ToString (), lCantidad);
            return lKilos.ToString();
        }

        public void IniciaForm(string lDet_Id, CurrentUser iObjUser)
        {
            DataTable lTbl = new DataTable();
            mDet_Id = lDet_Id;
            mUserLog = iObjUser;
            WsOperacion.OperacionSoapClient lPXO = new WsOperacion.OperacionSoapClient();
            WsOperacion.ListaDataSet lListaDts = new WsOperacion.ListaDataSet();
            lListaDts = lPXO.ObtenerResumenSMP_PorSolId(lDet_Id);
            if (lListaDts.MensajeError.Length == 0)
            {
                lTbl = lListaDts.DataSet.Tables[0].Copy();

                if (lTbl.Rows.Count > 0)
                {
                      mDiam = lTbl.Rows[0]["Diam"].ToString(); ;
                      mLargo = lTbl.Rows[0]["Largo"].ToString(); ;
                    Tx_Codigo.Text = lTbl.Rows[0]["Codigo"].ToString();
                    this .Tx_Des.Text = lTbl.Rows[0]["Descripcion"].ToString();
                    this.Tx_Origen .Text = lTbl.Rows[0]["Origen"].ToString();
                    this.Tx_soldable .Text = lTbl.Rows[0]["Soldable"].ToString();
                    //Solicitud
                    this.Tx_FechaSol .Text = lTbl.Rows[0]["FechaSol"].ToString();
                    this.Tx_KgsSol .Text = lTbl.Rows[0]["KgsSolicitados"].ToString();
                    this.Tx_NroBarrasSol .Text = lTbl.Rows[0]["BarrasSol"].ToString();
                    //Recepción
                    this.Tx_FechaRecep .Text = lTbl.Rows[0]["Det_Fecha_Recep"].ToString();
                    this.Tx_KgsRecep .Text = lTbl.Rows[0]["KgsRecep"].ToString();
                    this.Tx_NroBarrasRecep .Text = lTbl.Rows[0]["BarrasRecep"].ToString();

                    //Producido
                    this.Tx_KgsProd .Text = lTbl.Rows[0]["KgsProd"].ToString();
                    double lBarras = 0;double lTotalBarras = 0;
                    lBarras = int.Parse(this.Tx_KgsProd.Text) * int.Parse (this.Tx_NroBarrasSol.Text ) / int.Parse(this.Tx_KgsSol.Text);
                    //lTotalBarras = int.Parse(this.Tx_KgsProd.Text) / lBarras;
                    this.Tx_NroBarrasProd.Text = Math.Round (lBarras, 2).ToString ();

                    // a devolver
                    //Tx_NroBarrasDev.Text = int.Parse();
                }

            }
        }

        private void Tx_NroBarrasDev_Validating(object sender, CancelEventArgs e)
        {
            string lKilos = "";Clases.ClsComun lCom = new Clases.ClsComun();
            int lCant = 0; int lLargo = 0;int lDiam = 0;
            if (!Tx_NroBarrasDev.Text.Trim().Equals(""))
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    if (lCom.EsNumero(Tx_NroBarrasDev.Text) == true)
                        lCant = int.Parse(Tx_NroBarrasDev.Text);

                    if (lCom.EsNumero(mDiam ) == true)
                        lDiam = int.Parse(mDiam );

                    if (lCom.EsNumero(mLargo ) == true)
                        lLargo = int.Parse(mLargo);


                    lKilos = ObtenerKilos(lCant, lLargo, lDiam);
                    Tx_KgsDev.Text = lKilos;


                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Cursor.Current = Cursors.Default;
            }
        }

        private void Btn_Devolver_Click(object sender, EventArgs e)
        {
            WsOperacion.OperacionSoapClient lPx = new WsOperacion.OperacionSoapClient();
            string lRes = "";

            lRes = lPx.DevolucionDeMP(mDet_Id, Tx_NroBarrasDev.Text, Tx_KgsDev.Text , mUserLog.Iduser);


        }
    }
}
