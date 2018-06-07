using CommonLibrary2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
        private int mIdPesajeCamion = 0;
        private int mToleranciaBascula = 0;
        private int mKilosCargadosCamion = 0;
        private string mIdCorrelativo = "";


        public Frm_PesajeCamion()
        {
            InitializeComponent();
        }

        private void Btn_ObtenerTara_Click(object sender, EventArgs e)
        {
            string lTara = ObtenerTara();
            this.Tx_Tara.Text = lTara;
            Tx_Carga.Text = "";

            Tx_Carga.Text = "";
            Tx_ToleranciaReal.Text = "";

            Tx_KgsCargados.Text = "";
            Tx_DiferenciaKilos.Text = "";

            Tx_Bruto.Text = "";
            this.Tx_IdCorrCarga.Text = "";


        }

        public void IniciaForm( CurrentUser iUseActivo)
        {
            mUserLog = iUseActivo;
            this.Dtp_FechaActual.Value = DateTime.Now;
            this.Dtp_FechaActual.MaxDate = DateTime.Now;
            this.Dtp_FechaActual.MinDate = DateTime.Now .AddDays(-1);
            Rb_Tara.Checked = true;
            MuestraDatosSegunCheck();
            string lToleranciaBascula = ConfigurationManager.AppSettings["ToleranciaBascula"].ToString();

            if (lToleranciaBascula.Length > 0)
                mToleranciaBascula = int.Parse(lToleranciaBascula);

            Tx_ToleranciaBascula.Text = mToleranciaBascula.ToString();

        }


        #region Metodos privados de la clase

        private string ObtenerPesoBruto()
        {
            string lRes = "0"; string lSql = ""; Clases.SqlBascula lTipoSql = new Clases.SqlBascula();
            DataTable lTbl = new DataTable(); Clases.ClsComun lDAL = new Clases.ClsComun();
            string lFecha = DateTime.Now.ToShortDateString(); int lPesoTara = int.Parse(Tx_Tara.Text);

            lTbl = lDAL.CargaTablaRomana(lTipoSql.ObtenerSqlPesoBruto(Cmb_Patente .SelectedValue .ToString (), lFecha, lPesoTara));

            if (lTbl.Rows.Count > 0)
            {
                lRes = lTbl.Rows[0]["PesoBruto"].ToString();
                mIdCorrelativo = lTbl.Rows[0]["Correlativo"].ToString();
                Tx_IdCorrCarga.Text = mIdCorrelativo;
            }
            return lRes;
        }


        private string ObtenerTara()
        {
            string lRes = "";string lSql = ""; Clases.SqlBascula lTipoSql=new Clases.SqlBascula ();
            DataTable lTbl = new DataTable();Clases.ClsComun lDAL = new Clases.ClsComun();
            string lFecha = Dtp_FechaActual.Value.ToShortDateString();  //DateTime.Now.ToShortDateString();

            if (Tx_Patente.Text.Length == 0)
            {
                MessageBox.Show("Debe Ingresar una Patente para poder Obtener la Tara, revisar. . . ", "Validaciones Sistema", MessageBoxButtons.OK);
            }
            else
            {
                lSql = lTipoSql.ObtenerSqlTara(Tx_Patente.Text, lFecha);
                Tx_sql.Text = lSql;
                lTbl = lDAL.CargaTablaRomana(lSql);

                if (lTbl.Rows.Count > 0)
                {
                    lRes = lTbl.Rows[0]["PesoBruto"].ToString();
                    Tx_IdCorrTara.Text = lTbl.Rows[0]["Correlativo"].ToString();
                    mIdCorrelativo = lTbl.Rows[0]["Correlativo"].ToString();
                }
            }
            return lRes;
        }

        private string ObtenerPesoCargaCamion(string iPatente)
        {
            string lres = "0";



            return lres;

        }

        private void MuestraDatosSegunCheck()
        {

            try
            {
                if (Rb_Tara.Checked == true)
                {
                    Cmb_Patente.Visible = false;
                    Btn_ObtenerTara.Enabled = true;
                }

                if (Rb_Carga.Checked == true)
                {
                    //cargamos el desplegable con los datos de las patentes con camion cargado
                    WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
                    WsOperacion.ListaDataSet lLIstaDts = new WsOperacion.ListaDataSet(); DataTable lTbl = new DataTable();
                    DataRow lFila = null;

                    lLIstaDts = wsOperacion.ObtenerPatentesParaCalculoCarga();
                    if (lLIstaDts.DataSet.Tables.Count > 0)
                    {
                        lTbl = lLIstaDts.DataSet.Tables[0].Copy();
                        lFila = lTbl.NewRow();
                        lFila["patente"] = "Seleccionar";
                        lTbl.Rows.Add(lFila);
                        new Forms().comboBoxFill(Cmb_Patente, lTbl, "patente", "patente", 0);
                        Cmb_Patente.SelectedText = "Seleccionar";
                    }

                    Cmb_Patente.Visible = true;
                    Btn_ObtenerTara.Enabled = false;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private String GrabarDatos()
        {
                WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
                WsOperacion.PesajeCamion lObjCam = new WsOperacion.PesajeCamion();
            WsOperacion.ListaDataSet lDts = new WsOperacion.ListaDataSet();Clases.ClsComun lCom = new Clases.ClsComun();
            string lTxMsg = "";
            try
            {
                if (Rb_Tara.Checked == true)
                {
                    lObjCam.Id = 0;
                    lObjCam.Patente = Tx_Patente.Text;
                    lObjCam.PesoTara = int.Parse(Tx_Tara.Text);
                    lObjCam.FechaTara = DateTime.Now.ToString();
                    lObjCam.IdUserTara = int.Parse(mUserLog.Iduser);
                    lObjCam.PesoBruto = 0;
                    lObjCam.IdDespachoCam = 0;
                    lObjCam.Estado = "PesoTara";
                    lObjCam.IdCorrelativo = lCom.Val(mIdCorrelativo.ToString ()).ToString ();
                    lObjCam = wsOperacion.GrabarDatosPesajeCamion(lObjCam);
                    if (lObjCam.errors.Trim().Length == 0)
                    {
                        MessageBox.Show("Los Datos han sido Grabados Correctamente ", "Avisos Sistema", MessageBoxButtons.OK);
                        mIdCorrelativo = "0";
                        Btn_Grabar.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show(string.Concat ("Ha ocurrido el siguiente error:",lObjCam .errors .ToString ()), "Avisos Sistema", MessageBoxButtons.OK);
                    }
                }

                if (Rb_Carga.Checked == true)
                {
                    lObjCam.Id = mIdPesajeCamion;
                    lObjCam.Patente = Cmb_Patente.SelectedValue.ToString();
                    lObjCam.PesoTara = int.Parse(Tx_Tara.Text);
                    lObjCam.PesoBruto = int.Parse(Tx_Bruto.Text); ;
                    lObjCam.IdUserPesoBruto = int.Parse(mUserLog.Iduser);
                    lObjCam.Estado = "PesoCarga";
                    lObjCam.IdCorrelativo = mIdCorrelativo;
                    lObjCam = wsOperacion.GrabarDatosPesajeCamion(lObjCam);
                    if (lObjCam.Id > 0)
                    {
                        //enviar Correo para informar.
                        lDts = wsOperacion.ObtenerDatosPesajeCamion(lObjCam.Id.ToString());
                        if (lDts.MensajeError.Trim().Length == 0)
                        {
                            lTxMsg = EnviaCorreoNotificacion(lDts.DataSet.Copy());
                        }
                        MessageBox.Show("Los Datos han sido Grabados Correctamente ", "Avisos Sistema", MessageBoxButtons.OK);
                        mIdCorrelativo = "0";
                        Btn_Grabar.Enabled = false;
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return "";
        }

        private string EnviaCorreoNotificacion(DataSet lDts  )
        {
            string lTx = "";string lRes = "";DataTable lTbl = new DataTable();DataTable lTblDespacho = new DataTable();
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient(); string lTx_Caso = "";
            string lPatente = ""; string lFechaDespacho = ""; string lPesoGuia = "";string lKgsNeto = ""; string lKgsDesarrollo = "";
            string lDesviacion= ""; string lJefeTurno = "Sin Datos "; string lResultadoPesaje = "";string lObra = " Sin Datos ";
            string lPorDesviacion = "";  double  lPGD = 0; double lPbascula = 0; double lPD = 0;
            int lPs = 0; string lDesviacionDesa = ""; string lPorDesviacionDesa = "";

           lResultadoPesaje = Btn_PesoBruto.Tag.ToString ();


            switch (lResultadoPesaje.ToUpper())
            {
                case "+":   //Se despacha mas 
                    lTx_Caso = " Para la Obra xxx  se ha generado un <b> despacho con sobre peso </b> con los siguientes resultados";
                    break;
                case "-":      // Se despacha menos
                    lTx_Caso = " Para la Obra xxx  se ha generado un <b>  despacho con Ausencia de Material  </b> con los siguientes resultados";
                    break;
                default:
                    lTx_Caso = " Para la Obra xxx  se ha realizado un <b> despacho conforme </b> con los siguientes resultados";
                    break;
            }
            lTx = string.Concat("<table   border='1'>    <tr>  ");
            lTx = string.Concat(lTx, "  <td style = 'color: #FFFFFF; background-color: #000000 ;font-weight: normal; font-size: small;'>Patente Camión</td> ");
            lTx = string.Concat(lTx, " <td style = 'color: #FFFFFF; background-color: #000000 ;font-weight: normal; font-size: small;'>Fecha GD</td>");
            lTx = string.Concat(lTx, " <td style = 'color: #FFFFFF; background-color: #000000 ;font-weight: normal; font-size: small;'>Peso GD&nbsp; (KG)</td> ");
            lTx = string.Concat(lTx, " <td style = 'color: #FFFFFF; background-color: #000000 ;font-weight: normal; font-size: small;'>Peso Desarrollo (KG)</td> ");
            lTx = string.Concat(lTx, " <td style = 'color: #FFFFFF; background-color: #000000 ;font-weight: normal; font-size: small;'>Peso Báscula(KG)</td> ");
            lTx = string.Concat(lTx, " <td style = 'color: #FFFFFF; background-color: #000000 ;font-weight: normal; font-size: small;'>Desviación Teórica (KG)</td>");
            lTx = string.Concat(lTx, " <td style = 'color: #FFFFFF; background-color: #000000 ;font-weight: normal; font-size: small;'>Desviación Teórica(%)</td>");

            lTx = string.Concat(lTx, " <td style = 'color: #FFFFFF; background-color: #000000 ;font-weight: normal; font-size: small;'>Desviación Desarrollo (KG)</td>");
            lTx = string.Concat(lTx, " <td style = 'color: #FFFFFF; background-color: #000000 ;font-weight: normal; font-size: small;'>Desviación Desarrollo (%)</td>");


            lTx = string.Concat(lTx, " <td style = 'color: #FFFFFF; background-color: #000000 ;font-weight: normal; font-size: small;' > Nombre Jefe Turno</td>");
            lTx = string.Concat(lTx, "  </tr> ");

            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                lTbl = lDts.Tables[0].Copy();
                lPatente = lTbl.Rows[0]["Patente"].ToString();
                lPGD = int.Parse(lTbl.Rows[0]["KgsSistema"].ToString());
                lPbascula = int.Parse(lTbl.Rows[0]["KsgBascula"].ToString());
                lPesoGuia = lPbascula.ToString("N0");
               
                lKgsNeto = lPGD.ToString("N0");
                lPD = int.Parse(lTbl.Rows[0]["KgsDesarrollo"].ToString());
                lKgsDesarrollo = lPD.ToString("N0");
               
                //lPN = int.Parse(lTbl.Rows[0]["KsgBascula"].ToString());

                // % respecto al peso teórico (Peso GD) = (peso teórico – peso báscula)/Peso teórico
                lDesviacion = (lPGD - lPbascula).ToString();
                lPorDesviacion = Math.Round((((lPGD - lPbascula) * 100) / lPGD), 2).ToString();

                // calculo  desviación desarrollo
                // % respecto al peso con desarrollo = (peso con desarrollo – peso báscula)/ Peso con desarrollo
                lDesviacionDesa= (lPD - lPbascula).ToString();

                lPorDesviacionDesa = Math.Round((((lPD - lPbascula) * 100) / lPD), 2).ToString();

                //lPD = int.Parse(lTbl.Rows[0]["KgsDesarrollo"].ToString());                                
                //lDesviacionDesa = ""; lPorDesviacionDesa = "";

                lTx = string.Concat(lTx, "  <tr> ");
                lTx = string.Concat(lTx, "  <td>", lTbl.Rows[0]["Patente"].ToString()  , "</td> ");
                lTx = string.Concat(lTx, "  <td>", lTbl.Rows[0]["FechaPesoBruto"].ToString() , "</td> ");
                lTx = string.Concat(lTx, "  <td>", lPesoGuia , "</td> ");
                lTx = string.Concat(lTx, "  <td>", lKgsDesarrollo, "</td> ");
                lTx = string.Concat(lTx, "  <td>", lKgsNeto, "</td> ");
                lTx = string.Concat(lTx, "  <td>", lDesviacion, "</td> ");
                lTx = string.Concat(lTx, "  <td>", lPorDesviacion.ToString(), "</td>  ");

                lTx = string.Concat(lTx, "  <td>", lDesviacionDesa, "</td> ");
                lTx = string.Concat(lTx, "  <td>", lPorDesviacionDesa.ToString(), "</td>  ");

                if ((lDts.Tables.Count == 2) && (lDts.Tables[1].Rows.Count > 0))
                {
                    lTblDespacho = lDts.Tables[1].Copy();
                    lJefeTurno = lTblDespacho.Rows[0]["UsuarioDespacha"].ToString();
                    lObra = lTblDespacho.Rows[0]["Nombre"].ToString();
                }
                lTx = string.Concat(lTx, "  <td>", lJefeTurno.ToString(), "</td>   </tr>   </table>  ");

                //lTx = string.Concat(lTx, " Jefe de Turno a Cargo    :", lJefeTurno, "<Br>");
                lTx = string.Concat(lTx, " <BR> <BR> <BR> " );
                lTx = string.Concat(lTx, "  Este mensaje a sido generado de forma Automatica, favor NO responder este correo <BR>");
                lTx = string.Concat(lTx, "  Los acentos y caracteres especiales han sido eliminado del correo <BR>");

                lTx_Caso = lTx_Caso.Replace("xxx", lObra);

                lTx = string.Concat(lTx_Caso, " <BR> <BR>", lTx);

            }

            lRes = lPx.EnviaNotificacionesEnviaMsgDeNotificacion("", lTx, -900, string.Concat ("Detalle de Pesaje Camión Patente: ", lPatente));
            //if (lRes.ToUpper().Equals("OK"))

                return lRes;


        }

        


        #endregion

        private void Btn_Grabar_Click(object sender, EventArgs e)
        {
            GrabarDatos();
        }

        private void Btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frm_PesajeCamion_Load(object sender, EventArgs e)
        {

        }

        private void Rb_Tara_CheckedChanged(object sender, EventArgs e)
        {
            if (Rb_Tara.Checked == true)
            {
                MuestraDatosSegunCheck();
            }
        }

        private void Rb_Carga_CheckedChanged(object sender, EventArgs e)
        {
            if (Rb_Carga.Checked == true)
            {
                MuestraDatosSegunCheck();
            }
        }

        private void Cmb_Patente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((Cmb_Patente.SelectedValue!=null ) && (Cmb_Patente .SelectedValue.ToString ()!="Seleccionar" ))
                {
                CargaDatosPesoTaraPorPatente(Cmb_Patente.SelectedValue.ToString ());
            }
        }

        private void CargaDatosPesoTaraPorPatente(string iPatente)
        {
            WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
            WsOperacion.ListaDataSet lLIstaDts = new WsOperacion.ListaDataSet(); DataTable lTbl = new DataTable();

            lLIstaDts = wsOperacion.ObtenerPesoTaraPorPatente(iPatente);
            if (lLIstaDts.DataSet.Tables.Count > 0)
            {
                lTbl = lLIstaDts.DataSet.Tables[0].Copy();
                if (lTbl.Rows.Count > 0)
                {
                    Tx_Tara.Text = lTbl.Rows[0]["PesoTara"].ToString();
                    mIdPesajeCamion = int.Parse(lTbl.Rows[0]["IdPesajeCamion"].ToString());
                    Tx_IdCorrTara.Text = mIdPesajeCamion.ToString ();
                    mKilosCargadosCamion = int.Parse (lTbl.Rows[0]["KgsCargados"].ToString());
                    Tx_Tara.ReadOnly = true;
                }
            }
        }

        private void Btn_PesoBruto_Click(object sender, EventArgs e)
        {
            int lDiferencia = 0;Double lToleranciaReal = 0;
            //ObtenerPesoBruto
            int lPesoBruto = int.Parse(ObtenerPesoBruto());
            int lPesoTara = int.Parse(Tx_Tara.Text);
            int lPesoGD = int.Parse(mKilosCargadosCamion.ToString ());

            this.Tx_Bruto.Text = lPesoBruto.ToString();
            this.Tx_Carga.Text = (lPesoBruto - lPesoTara).ToString();

            lDiferencia = Math.Abs (lPesoGD - int.Parse (Tx_Carga.Text));
            Tx_DiferenciaKilos.Text = lDiferencia.ToString();
            if (lDiferencia > 0)
            {
                // % diferencia = ((Peso Guía de Despacho - Peso Neto)*100)/ (Peso Guía de Despacho) 

                lToleranciaReal = (double.Parse (lDiferencia.ToString ()) / double.Parse (lPesoGD.ToString ())) * 100;
                Tx_ToleranciaReal.Text = Math.Round (lToleranciaReal,2).ToString();
                Tx_KgsCargados.Text = mKilosCargadosCamion.ToString();
                if (lToleranciaReal > Double .Parse(Tx_ToleranciaBascula.Text))
                {
                    Tx_Semaforo.BackColor = Color.Red;
                } else
                    Tx_Semaforo.BackColor = Color.Green ;


                //Obtenemos el dato para el correo electronico
                Btn_PesoBruto.Tag = " ";
                if ((double.Parse(Tx_Carga.Text) > mKilosCargadosCamion) && (lToleranciaReal > Double.Parse(Tx_ToleranciaBascula.Text)))
                {
                     Btn_PesoBruto.Tag = "+";
                }

                if ((double.Parse(Tx_Carga.Text) < mKilosCargadosCamion) && (lToleranciaReal > Double.Parse(Tx_ToleranciaBascula.Text)))
                {
                    Btn_PesoBruto.Tag = "-";
                }
            }

            Tx_Carga.ReadOnly = true;

        }

        private void Btn_GeneraDatos_Click(object sender, EventArgs e)
        {
            GeneraDatos();
        }

        private void GeneraDatos ()
        {
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient(); DataSet lDts = new DataSet();
            string lSql = ""; DataTable lTbl = new DataTable();string lIdPesaje = "";int i = 0;
            DataTable lTblTmp = new DataTable();
            string lNroGD = ""; string lPesoGD = ""; string lDif_basculaGD=""; string lDesviacion_GD_Bascula = "";
            string lPesoConDesarrollo = ""; string lDesviacion_PD_Bascula = "";

            try
            {
                lSql = String.Concat(" SP_CRUD_PesajeCamion 0, ' ',0,'',0,0,'',0,0,'',0,8 ");
                lDts = lPx.ObtenerDatos(lSql);
                if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                {
                    //NroGD - PesoGD - Dif_basculaGD - Desviación_GD_Bascula - PesoConDesarrollo  - Desviacion_PD_Bascula
                    lTbl = lDts.Tables[0].Copy();
                    for (i = 0; i < lTbl.Rows.Count; i++)
                    {
                        lIdPesaje = lTbl.Rows[i]["Id"].ToString();
                        lSql = String.Concat(" SP_CRUD_PesajeCamion ", lIdPesaje, ", ' ',0,'',0,0,'',0,0,'',0,9 ");
                        lDts = lPx.ObtenerDatos(lSql);
                        if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                        {
                            lTblTmp = lDts.Tables[0].Copy();
                            lNroGD = lTblTmp.Rows[0]["NroGuiaInet"].ToString(); lPesoGD = lTblTmp.Rows[0]["KgsGD"].ToString();
                            lDif_basculaGD = lTbl.Rows[i]["Dif KgsGD"].ToString(); lDesviacion_GD_Bascula = lTbl.Rows[i]["% Dif KgsGD"].ToString().Replace(",", ".");
                            lPesoConDesarrollo = lTbl.Rows[i]["ConDesarrollo"].ToString(); lDesviacion_PD_Bascula = lTbl.Rows[i]["% Dif KgsDesa"].ToString().Replace(",", ".");
                            lSql = string.Concat(" Update PesajeCamion set NroGD='", lNroGD, "',PesoGD=", lPesoGD, " ,Dif_basculaGD=", lDif_basculaGD);
                            lSql = string.Concat(lSql, ",Desviacion_GD_Bascula='", lDesviacion_GD_Bascula, "',PesoConDesarrollo=", lPesoConDesarrollo);
                            lSql = string.Concat(lSql, ",Desviacion_PD_Bascula='", lDesviacion_PD_Bascula, "' where id=", lIdPesaje);
                            lDts = lPx.ObtenerDatos(lSql);
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
