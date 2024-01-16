using System;
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
        private string mEmpresa = "";
        public string mTotalKgsOk = "N";
        public Frm_VinculaQR()
        {
            InitializeComponent();
        }


        public void Grabar(string iEt_TO, string iQR , string iKgsVin, int iIdMaquinaProd )
        {

            string lSql = ""; DataSet lDts = new DataSet(); DataTable lTbl = new DataTable();
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient();

            lSql = " insert into   EtiquetasVinculadas(IdEtiquetaTO, IdQR, Tipo, KgsVinculados, FechaRegistro, IdMaquinaProduce) ";
            lSql = string.Concat(lSql, "values(", iEt_TO, ",", iQR, ",'P',", iKgsVin, ", Getdate(),", iIdMaquinaProd,")");
            lPx.ObtenerDatos(lSql);

        }


        private void CargaGrilla(string iEt_TO)
        {

            string lSql = ""; DataSet lDts = new DataSet(); DataTable lTbl = new DataTable();
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient();
            if (mEmpresa == "TO")
            {
                lSql = string.Concat("Select *  from    EtiquetasVinculadas where IdEtiquetaTO=", iEt_TO);
            } else
            {
                lSql = string.Concat("Select *  from    EtiquetasVinculadasTosol where IdEtiquetaTosol=", iEt_TO);
            }
            lDts = lPx.ObtenerDatos(lSql);
            if (lDts.Tables.Count > 0)
            {
                Dtg_Resultado.DataSource = lDts.Tables[0].Copy();
            }

        }

        public void IniciaForm(string IdEtqTO, string iEtiq, string iKgsEt, string iKgsVinc, string iKgsSaldo, string iQR, CurrentUser iUser, string iDiam, string iEmpresa)
        {
            string lSql = "";DataSet lDts = new DataSet();DataTable lTbl = new DataTable();
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient();
            mEmpresa = iEmpresa;
            Tx_Id.Text = IdEtqTO.ToString();
            Tx_Etiqueta.Text = iEtiq.ToString();
            Tx_KgsEtiqueta.Text = iKgsEt.ToString();
            Tx_Vinculados.Text = iKgsVinc.ToString();
            Tx_Saldo.Text = iKgsSaldo.ToString();
            Tx_Diam.Text = iDiam;
            mUserLog = iUser;

            Grabar(Tx_Id.Text, iQR, iKgsVinc, mUserLog.IdMaquina);
            CargaGrilla(Tx_Id.Text);
            Tx_etiquetaQR.Focus();
                 
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Tx_etiquetaQR_Validating(object sender, CancelEventArgs e)
        {
            if (mEmpresa == "TO")
            {
                int lSaldoColada = 0; Clases.ClsComun lCom = new Clases.ClsComun();
                int lSaldoEtiquetaTO = 0;
                ProcesaColadaOriginal_QR(this.Tx_etiquetaQR.Text);
                lSaldoColada = lCom.Val(Lbl_SaldoKilosColada.Text);
                lSaldoEtiquetaTO = lCom.Val(Tx_Saldo.Text);
                //while (lSaldoEtiquetaTO> 0 )
                if (lSaldoColada > 0) // >=lSaldoEtiquetaTO  )
                {
                    // Verificamos que el diametro de la colada es igual al de la pieza
                    if (Tx_Diam.Text == lblDiametro.Text)
                    {
                        //grabamos y volvemos a la pantalla anterior
                        GrabarDatos();
                    }
                    else
                    {
                        MessageBox.Show("La colada Ingresada es distinta al diametro de la Paquete, no se puede vincular la colada. Ingrese Una Colada ", "Avisos sistema");
                        Tx_etiquetaQR.Text = "";
                    }
                }
            } else
            {
                int lSaldoColada = 0; Clases.ClsComun lCom = new Clases.ClsComun();
                int lSaldoEtiquetaTO = 0;
                ProcesaColadaOriginal_QR_Tosol(this.Tx_etiquetaQR.Text);
                lSaldoColada = lCom.Val(Lbl_SaldoKilosColada.Text);
                lSaldoEtiquetaTO = lCom.Val(Tx_Saldo.Text);
                //while (lSaldoEtiquetaTO> 0 )
                if (lSaldoColada > 0) // >=lSaldoEtiquetaTO  )
                {
                    // Verificamos que el diametro de la colada es igual al de la pieza
                    if (Tx_Diam.Text == lblDiametro.Text)
                    {
                        //grabamos y volvemos a la pantalla anterior
                        GrabarDatos();
                    }
                    else
                    {
                        MessageBox.Show("La colada Ingresada es distinta al diametro de la Paquete, no se puede vincular la colada. Ingrese Una Colada ", "Avisos sistema");
                        Tx_etiquetaQR.Text = "";
                    }
                }
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
                            lSaldoColada = 0;
                            Lbl_SaldoKilosColada.Text = "";
                            Lbl_KgsProd.Text = "";
                            lblColada.Text = "";
                            lblDiametro.Text = "";
                            lblLargo.Text = "";
                            lblKilos.Text = "";
                            Tx_etiquetaQR.Tag =0;
                            Tx_etiquetaQR.Text = "";
                            Tx_etiquetaQR.Focus();
                        }
                    }
                    else
                        MessageBox.Show("Ha ocurrido el siguiente error:  " + mEtiqueta_Qr.Errors.ToString (), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Cursor.Current = Cursors.Default;
            }
        }

        private void ProcesaColadaOriginal_QR_Tosol(string iTx)
        {
            string lTmp = "";
            WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
            WsOperacion.ListaDataSet listaDataSet = new WsOperacion.ListaDataSet();
            Ws_TO.Ws_ToSoapClient lpx = new Ws_TO.Ws_ToSoapClient();
            DataSet ldts = new DataSet(); string lsql = "";
            DataTable ltbl = new DataTable();
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
                    mIdEtiquetaColada = iTx.ToString();   // el Id de la etiqueta Aza
                        //ValidaColadaEnProduccion
                        lsql = string.Concat("exec SP_CRUD_EtiquetasVinculadasTosol '',", iTx.ToString(), ",'','','','','','','','',2");
                        ldts = lpx.ObtenerDatos(lsql);
                    if ((ldts.Tables.Count > 0) && (ldts.Tables[0].Rows.Count > 0))
                    {
                        ltbl = ldts.Tables[0].Copy();
                        Lbl_SaldoKilosColada.Text = ltbl.Rows[0]["KgsSaldo"].ToString();
                        Lbl_KgsProd.Text = ltbl.Rows[0]["KgsProducidos"].ToString();
                        lblColada.Text = iTx.ToString();
                        lblDiametro.Text = ltbl.Rows[0]["Diametro"].ToString();
                        lblLargo.Text = ltbl.Rows[0]["largo"].ToString();
                        lblKilos.Text = ltbl.Rows[0]["KgsPaquete"].ToString();
                        //lSaldoColada = (ltbl.Rows[0]["KgsSaldo"].ToString()) - lCom.Val(mEtiqueta_Qr.KgsProducidos.ToString()));
                        Tx_etiquetaQR.Tag = mIdEtiquetaColada;

                        if (lSaldoColada < 1)
                        {
                            MessageBox.Show("La Colada ingresada ya se ha consumido en su totalidad, NO se puede vincular mas producción, Debe indicar  otra Calada ", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            lSaldoColada = 0;
                            Lbl_SaldoKilosColada.Text = "";
                            Lbl_KgsProd.Text = "";
                            lblColada.Text = "";
                            lblDiametro.Text = "";
                            lblLargo.Text = "";
                            lblKilos.Text = "";
                            Tx_etiquetaQR.Tag = 0;
                            Tx_etiquetaQR.Text = "";
                            Tx_etiquetaQR.Focus();
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

                if (int.Parse (mIdEtiquetaColada)>0)
                {
                    if (lSaldoEtiqueta <= lKgsColada)  //todo OK.
                    {
                        mTotalKgsOk = "S";
                        lKgsVinc = lSaldoEtiqueta;
                        Grabar(Tx_Id.Text, mIdEtiquetaColada, lKgsVinc.ToString(), mUserLog.IdMaquina);
                        AppDomain.CurrentDomain.SetData("KgsOK", "S");
                        AppDomain.CurrentDomain.SetData("Colada", this.Tx_etiquetaQR.Text);
                        this.Close();
                    }

                    else  // Hay que vincular Otra etiqueta
                    {
                        mTotalKgsOk = "N";
                        lKgsVinc = lKgsColada;
                        Grabar(Tx_Id.Text, mIdEtiquetaColada, lKgsVinc.ToString(), mUserLog.IdMaquina);
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
                            if (Dtg_Resultado.Rows[i].Cells["KgsVinculados"].Value != null)
                                lKgsVinc = lKgsVinc + int.Parse(Dtg_Resultado.Rows[i].Cells["KgsVinculados"].Value.ToString());

                        }
                        Tx_Vinculados.Text = lKgsVinc.ToString();
                        lSaldoEtiqueta = int.Parse(Tx_KgsEtiqueta.Text) - lKgsVinc;
                        Tx_Saldo.Text = lSaldoEtiqueta.ToString();

                    }

                }
                 else
                    MessageBox.Show(" La etiqueta colada NO puede ser 0, revisar :  " , this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
        }

               private void txtEtiquetaColada_Validating(object sender, CancelEventArgs e)
        {


           



        }

        private void Btn_Aceptar_Click(object sender, EventArgs e)
        {
            GrabarDatos();
        }

        private void Tx_etiquetaQR_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                this.Tx_etiquetaQR_Validating(null, null);
            }
        }

        private void Tx_etiquetaQR_TextChanged(object sender, EventArgs e)
        {

        }

        private void Frm_VinculaQR_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Mostrar un mensaje de porqué se está cerrando
            // MessageBox.Show(e.CloseReason.ToString());
            // Estos son los valores posibles
            string lKgsOK = "N";
            lKgsOK =AppDomain.CurrentDomain.GetData ("KgsOK").ToString ();
            switch (e.CloseReason)
            {
                case CloseReason.ApplicationExitCall:
                    break;
                case CloseReason.FormOwnerClosing:
                    break;
                case CloseReason.MdiFormClosing:
                    break;
                case CloseReason.None:
                    break;
                case CloseReason.TaskManagerClosing:
                    break;
                case CloseReason.UserClosing:
                    if (lKgsOK == "N")
                    {
                        MessageBox.Show("Debe registrar la etiqueta QR, si no lo hace NO se puede salir del formulario ", "Avisos sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        e.Cancel = true;
                    }
                    break;
                case CloseReason.WindowsShutDown:
                    break;
            }
        }
    }
}
