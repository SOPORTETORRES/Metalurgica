﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Metalurgica.Produccion
{
    public partial class Frm_VinculaQR : Form
    {

        private WsOperacion.TipoEtiquetaAza mEtiqueta_Qr = new WsOperacion.TipoEtiquetaAza();
        private string mIdEtiquetaColada = "0";
        private string mTipoColada = "";
        private CurrentUser mUserLog = new CurrentUser();

        public string mTotalKgsOk = "N";
        public Frm_VinculaQR()
        {
            InitializeComponent();
        }


        public void Grabar(string iEt_TO, string iQR , string iKgsVin)
        {

            string lSql = ""; DataSet lDts = new DataSet(); DataTable lTbl = new DataTable();
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient();

            lSql = " insert into   EtiquetasVinculadas(IdEtiquetaTO, IdQR, Tipo, KgsVinculados, FechaRegistro) ";
            lSql = string.Concat(lSql, "values(", iEt_TO, ",", iQR, ",'P',", iKgsVin, ", Getdate())");
            lPx.ObtenerDatos(lSql);

        }


        private void CargaGrilla(string iEt_TO )
        {

            string lSql = ""; DataSet lDts = new DataSet(); DataTable lTbl = new DataTable();
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient();
            lSql = string.Concat("  Select *  from    EtiquetasVinculadas where IdEtiquetaTO=", iEt_TO);
            lDts = lPx.ObtenerDatos(lSql);

            if (lDts.Tables.Count > 0)
            {
                Dtg_Resultado.DataSource = lDts.Tables[0].Copy();
            }

        }

        public void IniciaForm(string IdEtqTO, string iEtiq, string iKgsEt, string iKgsVinc, string iKgsSaldo, string iQR)
        {
            string lSql = "";DataSet lDts = new DataSet();DataTable lTbl = new DataTable();
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient();

            Tx_Id.Text = IdEtqTO.ToString();
            Tx_Etiqueta.Text = iEtiq.ToString();
            Tx_KgsEtiqueta.Text = iKgsEt.ToString();
            Tx_Vinculados.Text = iKgsVinc.ToString();
            Tx_Saldo.Text = iKgsSaldo.ToString();

            Grabar(Tx_Id.Text, iQR, iKgsVinc);
            CargaGrilla(Tx_Id.Text);
                 
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Tx_etiquetaQR_Validating(object sender, CancelEventArgs e)
        {
            int lSaldoColada = 0; Clases.ClsComun lCom = new Clases.ClsComun();
            int lSaldoEtiquetaTO = 0;
            ProcesaColadaOriginal_QR(this.Tx_etiquetaQR.Text);
            lSaldoColada = lCom.Val(Lbl_SaldoKilosColada.Text);
            lSaldoEtiquetaTO = lCom.Val(Tx_Saldo.Text);
            if ( lSaldoColada >=lSaldoEtiquetaTO  )
            {
                //grabamos y volvemos a la pantalla anterior
                GrabarDatos();
            }

        }
        private void ProcesaColadaOriginal_QR(string iTx)
        {
            string lTmp = "";
            WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
            WsOperacion.ListaDataSet listaDataSet = new WsOperacion.ListaDataSet();
            int lSaldoColada = 0;

            DataTable dt = new DataTable(); Clases.ClsComun lCom = new Clases.ClsComun();
            if (!Tx_etiquetaQR.Text.Trim().Equals(""))
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    //Inicializamos las variables
                    lblColada.Text = ".";
                    lblDiametro.Text = ".";
                    lblLargo.Text = ".";

                    string lValidaColadaEnProduccion = ConfigurationManager.AppSettings["ValidaColadaEnProduccion"].ToString().ToUpper();

                    lTmp = iTx.Replace("ñ", ";");
                    lTmp = lTmp.Replace("Ñ", ":");
                    lTmp = lTmp.Replace("'", "-");
                    lTmp = lTmp.Replace(")", "(");
                    lTmp = lTmp.Replace("=", ")");

                    mEtiqueta_Qr = lCom.ObtenerEtiquetaAZA(lTmp, true);

                    if (mEtiqueta_Qr.Errors.Trim().Length == 0)     //NO hay error 
                    {
                        mIdEtiquetaColada = mEtiqueta_Qr.Id.ToString();    // el Id de la etiqueta Aza

                        //ValidaColadaEnProduccion
                        lSaldoColada = (lCom.Val(mEtiqueta_Qr.PesoBulto.ToString()) - lCom.Val(mEtiqueta_Qr.KgsProducidos.ToString()));
                        Lbl_SaldoKilosColada.Text = lSaldoColada.ToString();
                        Lbl_KgsProd.Text = mEtiqueta_Qr.KgsProducidos.ToString();
                        lblColada.Text = mEtiqueta_Qr.Lote.ToString();
                        lblDiametro.Text = mEtiqueta_Qr.Diam.ToString();
                        lblLargo.Text = mEtiqueta_Qr.Largo.ToString();
                        lblKilos.Text = mEtiqueta_Qr.PesoBulto.ToString();
                        Tx_etiquetaQR.Tag = mIdEtiquetaColada;

                        if (lSaldoColada < 1)
                        {
                            MessageBox.Show("La Colada ingresada ya se ha consumido en su totalidad, NO se puede vincular mas producción, Debe indicar  otra Calada ", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Cursor.Current = Cursors.Default;
            }
        }


        private void GrabarDatos()
        {
            int lSaldoEtiqueta = 0; int lKgsColada = 0; int lKgsVinc = 0; int i = 0;

            if ((mEtiqueta_Qr.Errors == ""))
            {
                lSaldoEtiqueta =  int.Parse (Tx_Saldo.Text);
                lKgsColada = int.Parse(Lbl_SaldoKilosColada.Text);

                if (lSaldoEtiqueta <= lKgsColada)  //todo OK.
                {
                    mTotalKgsOk = "S";
                    lKgsVinc = lSaldoEtiqueta;
                    Grabar(Tx_Id.Text, mIdEtiquetaColada, lKgsVinc.ToString());
                    AppDomain.CurrentDomain.SetData("KgsOK", "S");
                    this.Close();
                }

                else  // Hay que vincular Otra etiqueta
                {
                    mTotalKgsOk = "N";
                    lKgsVinc = lKgsColada;
                    Grabar(Tx_Id.Text, mIdEtiquetaColada, lKgsVinc.ToString());
                    CargaGrilla(Tx_Id.Text);
                    Lbl_Msg.Text = string.Concat("Debe Leer otra etiqueta de colada ");
                    // Limpiar Datos Colada
                    Tx_etiquetaQR.Text = "";
                    lblColada.Text = "";
                    lblDiametro.Text = "";
                    lblLargo.Text = "";
                    Lbl_SaldoKilosColada.Text = "";
                    Lbl_KgsProd.Text = "";
                    lblColada.Text = "";
                    lblDiametro.Text = "";
                    lblLargo.Text = "";
                    lblKilos.Text = "";
                    Tx_etiquetaQR.Tag = "0";
                    // Actualizar los Datos
                    lKgsVinc = 0;
                    for (i = 0; i < this.Dtg_Resultado.Rows.Count; i++)
                    {
                        if ( Dtg_Resultado.Rows[i].Cells["KgsVinculados"].Value!=null)
                                lKgsVinc = lKgsVinc + int.Parse(Dtg_Resultado.Rows[i].Cells["KgsVinculados"].Value.ToString());

                    }
                    Tx_Vinculados.Text = lKgsVinc.ToString();
                    lSaldoEtiqueta = int.Parse(Tx_KgsEtiqueta.Text) - lKgsVinc;
                    Tx_Saldo.Text = lSaldoEtiqueta.ToString ();



                }

            }
        }

               private void txtEtiquetaColada_Validating(object sender, CancelEventArgs e)
        {


           



        }

        private void Btn_Aceptar_Click(object sender, EventArgs e)
        {
            GrabarDatos();
        }
    }
}