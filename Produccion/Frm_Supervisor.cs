using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

namespace Metalurgica.Produccion
{
    public partial class Frm_Supervisor : Form
    {

        private string mNombreSup = "";
        private CurrentUser mUser = new CurrentUser();
        private double  mTolerancia = 0;
        private string mIdQr = "0";
        private string mTramaEtiqueta = "";
        private string mSucursal = "";
        private string  mKgsEtiquetaCierre = "";


        public Frm_Supervisor()
        {
            InitializeComponent();
        }

        private void Btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string EnviarArchivo(string iMgs, string iTitulo,  DataTable lTblDest)
        {
            MailMessage MMessage = new MailMessage(); int i = 0;

            string lRes = "";
            try
            {
                for (i = 0; i < lTblDest.Rows.Count; i++)
                {
                    MMessage.To.Add(lTblDest.Rows[i]["MailDest"].ToString());
                }
                

                MMessage.From = new MailAddress("notificaciones@smtyo.cl", "NoResponder", System.Text.Encoding.UTF8);


                MMessage.Subject = iTitulo; // '"Notificación por Reglas de Negocio "
                MMessage.SubjectEncoding = System.Text.Encoding.UTF8;
                MMessage.Body = iMgs;// '"Esto es una prueba";
                MMessage.BodyEncoding = System.Text.Encoding.UTF8;
                MMessage.IsBodyHtml = true; // 'Formato html
                //MMessage.Attachments.Add(new Attachment(iArchivos));

                //'Definimos nuestras credenciales para el unvio de emails a traves de Gmail
                SmtpClient SClient = new SmtpClient();
                SClient.Credentials = new System.Net.NetworkCredential("cubenotificacion@gmail.com", "cbnkfhxfmoxthxsq");
                SClient.Host = "smtp.gmail.com";  //'Servidor SMTP de Gmail
                SClient.Port = 587; // 'Puerto del SMTP de Gmail
                SClient.EnableSsl = true; // 'Habilita el SSL, necesio en Gmail
                //'Capturamos los errores en el envio


                SClient.Send(MMessage);
                lRes = "Ok";
            }
            catch (Exception iex)
            {
                // MessageBox.Show(string.Concat("Ha Ocurrido el Siguiente Error: ", iex.Message.ToString(), "Avisos Sistema")); 
                //  lRes = iex.Message.ToString();
                throw iex;
            }
            return lRes;
        }


        private void EnviaCorreo(string  iSupervisor, string iKgsQR, string iKgspr, string iKgsDes, string iPorcentDep, string iObs, string iSucursal, string iTrama)
        {
            string lCuerpo = ""; DataTable lTbl = new DataTable(); string lRes = "";

            try
            {
                lCuerpo = string.Concat(" Hola Estimados: <br>   El Supervisor: ", iSupervisor);
                lCuerpo = string.Concat(lCuerpo, " ha autorizado el cierre de una Etiqueta de Colada, superior al 10 % ");
                lCuerpo = string.Concat(lCuerpo, " los datos de la Etiqueta son:  <br>  <br>  ");
                lCuerpo = string.Concat(lCuerpo, " Kilos Totales Etiqueta:   ", iKgsQR, "  <br> ");
                lCuerpo = string.Concat(lCuerpo, " Kilos Producidos      :   ", iKgspr, "  <br> ");
                lCuerpo = string.Concat(lCuerpo, " Kilos Despunte        :   ", iKgsDes, "  <br> ");
                lCuerpo = string.Concat(lCuerpo, " Porcentaje  Despunte  :   ", iPorcentDep, "  <br>");
                lCuerpo = string.Concat(lCuerpo, " Observación del Sup.  :   ", iObs, "  <br>  ");
                lCuerpo = string.Concat(lCuerpo, " Sucursal del Totem.   :   ", iSucursal, "  <br>    ");
                lCuerpo = string.Concat(lCuerpo, " TRAMA                 :   ", iTrama, "  <br>  <br>  ");

                lCuerpo = string.Concat(lCuerpo, "  No responda a este Correo, ya que es sólo Informativo <br> ");
                switch (iSucursal.ToUpper())
                {
                    case "SANTIAGO":
                        lTbl = ObtenerDestinatarios("-1500");
                        break;
                    case "CALAMA":
                        lTbl = ObtenerDestinatarios("-1550");
                        break;
                    case "CORONEL":
                        break;
                }

                if (lTbl.Rows.Count > 0)
                {

                    lRes = EnviarArchivo(lCuerpo, "Autorización Supervidor Por Cierre Etiqueta Proveedor ", lTbl);

                }
            }
            catch (Exception iEx)
            {
                throw iEx;
            }

        }


        private DataTable ObtenerDestinatarios(string itipo)
        {
            Ws_TO.Ws_ToSoapClient lDal = new Ws_TO.Ws_ToSoapClient();
            string lSql = String.Concat(" SP_ConsultasInformes  20, '", itipo, "',' ','','',''");
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable(); int i = 0;
            try
            {
                lDts = lDal.ObtenerDatos(lSql);
                if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                {
                    lTbl = lDts.Tables[0].Copy();
                }
            }
            catch (Exception iex)
            {
                throw iex;
            }
            return lTbl;
        }



        private void Btn_Grabar_Click(object sender, EventArgs e)
        {
            string KgsProd = "0"; Clases.ClsComun lCom = new Clases.ClsComun();
            //Verificar si la clave esta OK.
            try
            {
                if (ValidaClave(Tx_clave.Text) == true)
                {
                    //Persistir los datos de la autorización 
                    PersistirAutorizacion();
                    //Poder seguir con el proceso
                    // Notificacion por Correo electronico
                    KgsProd = (lCom.Val(Tx_KgsPr.Text) - lCom.Val(Tx_KgsCierre.Text)).ToString();
                   EnviaCorreo(mNombreSup, Tx_KgsPr.Text, KgsProd, Tx_KgsCierre.Text, Tx_Depunte.Text, Tx_Obs.Text, mSucursal, mTramaEtiqueta);

                }
            }
            catch (Exception iex)
            {
                MessageBox.Show(string.Concat("Ha ocurrido el siguiente error: ", iex.Message.ToString()), "Avisos Sistema");
            }
            finally
            {
                AppDomain.CurrentDomain.SetData("ValidacionSupervisor", "OK");
                this.Close();
            }

        }


        private Boolean ValidaClave(string iClave)
        {
            DataSet lDts = new DataSet();Boolean lRes = false;
            Ws_TO.Ws_ToSoapClient lDAl = new Ws_TO.Ws_ToSoapClient();
            string lSql = "Select Par3 from to_parametros where ";
            lSql = string.Concat(lSql, "  subtabla = 'SupervisoresPR' and par4='", iClave, "'");

            lDts =lDAl.ObtenerDatos(lSql);

            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                mNombreSup = lDts.Tables[0].Rows[0][0].ToString();
                lRes = true;
            }
            else
            {
                lRes = false;
                MessageBox.Show("La Clave Ingresada, no es  Válida", "Avisos Sistema ");
            }


            if (Tx_Obs.Text.Trim().Length < 5)
            {
                lRes = false;
                MessageBox.Show("Debe Ingresar una Observación de mas de 5 carácteres, Revisar", "Avisos Sistema "); 
            }

           
            return lRes;
        }

        private void PersistirAutorizacion()
        {
            DataSet lDts = new DataSet(); Clases.ClsComun lCom = new Clases.ClsComun();
            Ws_TO.Ws_ToSoapClient lDAl = new Ws_TO.Ws_ToSoapClient();string lIdAutorizacion = "";
            string lRes = ""; string lSql = "";

            lSql= " insert  into  AprobacionesSupervisor ( Supervisor, Obs, IdUserGraba, MailEnviado,IdQr) Values ('";
            lSql = string.Concat(lSql,  mNombreSup   , "','" , Tx_Obs .Text ,"',", lCom .Val (mUser .Iduser ),",'N',", mIdQr ,")");
            lSql = string.Concat(lSql, "  select @@identity  ");

           lDts = lDAl.ObtenerDatos(lSql);

            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                lIdAutorizacion = lDts.Tables[0].Rows[0][0].ToString();
            }


            lSql = " insert into   EtiquetasVinculadas(IdEtiquetaTO, IdQR, Tipo, KgsVinculados, FechaRegistro, IdMaquinaProduce) ";
            lSql = string.Concat(lSql, "values(0,", mIdQr.ToString(), ",'D',", lCom .Val (mKgsEtiquetaCierre), ", Getdate(),", lCom.Val(mUser.IdMaquina.ToString ()), ")");
            lDts = lDAl.ObtenerDatos(lSql);


            //return mNombreSup;
        }

        public void IniciaForm(CurrentUser iUsuario, string iKgsEtiqueta, string iDespunte, string iPor, string IdQr, string iTrama, string  iSucursal)
        {
            Clases.ClsComun lCom = new Clases.ClsComun();
            mUser = iUsuario;
            mIdQr = IdQr;
            mTramaEtiqueta = iTrama;
            mSucursal = iSucursal;
            mKgsEtiquetaCierre = iDespunte;
            mTolerancia  =lCom .CDBL ( ConfigurationManager.AppSettings["PorcentajeQR"].ToString());
            label3.Text = string.Concat(" Esta Autorizando el cierre de una Etiqueta de Proveedor con mas de un ", mTolerancia.ToString (), " %");
            Tx_KgsCierre.Text = iDespunte ;
            Tx_KgsPr.Text = iKgsEtiqueta;
            Tx_Depunte.Text = Math.Round(lCom.CDBL(iDespunte) / lCom.CDBL(iKgsEtiqueta) * 100, 2).ToString();
            Tx_trama .Text =iTrama ;

            AppDomain.CurrentDomain.SetData("ValidacionSupervisor", "");

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Frm_Supervisor_Load(object sender, EventArgs e)
        {

        }
    }
}
