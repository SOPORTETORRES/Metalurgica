using CommonLibrary2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Metalurgica.Maquinas
{
    public partial class CheckList : Form
    {
        private CurrentUser mUserLog = new CurrentUser();
        private string mTipoMaq = "";
        private string mTmp = "";
        public CheckList()
        {
            InitializeComponent();
        }

        private void Btn_grabar_Click(object sender, EventArgs e)
        {
            Grabar();
        }


        private void CheckList_Load(object sender, EventArgs e)
        {
            mTmp = "1";
        }

        private void Grabar()
        {
            if (ValidarAntesDeGrabar() == true)
            {

                switch (mTipoMaq)
                {
                    case "ES":   //  Estibadoras
                        //GrabarDobladora();
                        GrabarEstibadoras();
                        break;
                    case "CU":  // CURVADORA
                        GrabarCurvadora();
                        break;

                    case "CO":  // CORTADORA
                        GrabarCortadora();
                        break;

                    case "DO":  // Dobladora
                        GrabarDobladora ();
                        break;
                }
            }

           

        }


        public void IniciaForm(CurrentUser iUsuario)
        {
            DateTime lNow = DateTime.Now; int lHoras = 0;
            string lFecha = ""; string lDia = ""; string lHora = ""; string lTurno = "";
            Lbl_Operario.Text = iUsuario.Login;
            Lbl_Maquina.Text = iUsuario.DescripcionMaq;
            lFecha = lNow.ToShortDateString();
            lHora = lNow.ToShortTimeString();
            lHoras = lNow.Hour;
            if ((lHoras > 7) && (lHoras < 20))
                lTurno = "DIA";
            else
                lTurno = "NOCHE";

            mUserLog = iUsuario;
            Lbl_DiaSemana.Text = lNow.ToString("dddd", new CultureInfo("es-ES")).ToUpper ();
            Lbl_Fecha.Text = lFecha;
            Lbl_Hora .Text = lHora ;
            Lbl_Turno .Text = lTurno ;

            switch (iUsuario.IdMaquina )
            {
                case 7:   //  Estibadoras
                case 10:
                case 12:
                case 13:
                case 14:
                case 15:
                case 110:
                    tabControl1.SelectedTab = TP_Estibadoras;
                    tabControl1.TabPages.Remove(TP_Dobladora);
                    tabControl1.TabPages.Remove(SP_Cortadora );
                    tabControl1.TabPages.Remove(SP_Curvadora );
                    mTipoMaq = "ES";
                    break;
                case 21:  // CURVADORA
                    tabControl1.SelectedTab = SP_Curvadora;
                    tabControl1.TabPages.Remove(TP_Dobladora);
                    tabControl1.TabPages.Remove(SP_Cortadora);
                    tabControl1.TabPages.Remove(TP_Estibadoras);
                    mTipoMaq = "CU";
                    break;
                case 20:  // CORTADORA
                case 16:
                    tabControl1.SelectedTab = SP_Cortadora;
                    tabControl1.TabPages.Remove(TP_Dobladora);
                    tabControl1.TabPages.Remove(SP_Curvadora);
                    tabControl1.TabPages.Remove(TP_Estibadoras);
                    mTipoMaq = "CO";
                    break;
                    case 17:  // DOBLADORA
                    tabControl1.SelectedTab = TP_Dobladora;
                    tabControl1.TabPages.Remove(SP_Cortadora);
                    tabControl1.TabPages.Remove(SP_Curvadora);
                    tabControl1.TabPages.Remove(TP_Estibadoras);
                    mTipoMaq = "DO";
                    break;
            }
            // Cargamos el combox de Supervisores
            WsOperacion.OperacionSoapClient lWs = new WsOperacion.OperacionSoapClient();
            WsOperacion.ListaDataSet lDts = new WsOperacion.ListaDataSet();
            DataTable lTbl = new DataTable();DataRow lFila = null;


            lDts = lWs.ObtenerSupervisores( );
            if ((lDts.DataSet.Tables.Count > 0) && (lDts.DataSet.Tables[0].Rows.Count > 0))
            {
                lTbl = lDts.DataSet.Tables[0].Copy();
                lFila = lTbl.NewRow();
                lFila["par1"] = "Seleccionar";
                lTbl.Rows.Add(lFila);
                new Forms().comboBoxFill(Cmb_Supervisor , lTbl, "par1", "par1", 0);
                Cmb_Supervisor.SelectedIndex = lTbl.Rows.Count - 1;
               // Cmb_Supervisor.SelectedText = "Seleccionar";
            }


        }



            // Se debe grabar y luego enviar correo de Notificación a Lista de distribución 
            //la Misma que Notificacion Averias



        private string ValidaEstibadoras()
        {
            string lMsg = "";
            if ((RB_RA_S.Checked == false) && (RB_RA_N.Checked == false))
                   lMsg = "Debe Indicar una Opción para  la RUEDA DE ARRASTRE ";
          
            if ((RB_RM_S.Checked == false) && (RB_RM_N.Checked == false))
                lMsg = " Debe Indicar una Opción para  la RUEDA DE MEDIDA  ";
           
            if ((RB_RP_S.Checked == false) && (RB_RP_N.Checked == false))
                 lMsg = "Debe Indicar una Opción para  la RUEDA DE PRESIÓN ";
           
            if ((RB_RE_S.Checked == false) && (RB_RE_N.Checked == false))
                lMsg = " Debe Indicar una Opción para  la RODILLO DE ENDEREZADO  ";
           
            if ((RB_CUM_S.Checked == false) && (RB_CUM_N.Checked == false))
                lMsg = " Debe Indicar una Opción para  la CUCHILLO MOVIL  ";
            
            if ((RB_CF_S.Checked == false) && (RB_CF_N.Checked == false))
            lMsg = " Debe Indicar una Opción para  la CUCHILLO FIJO  ";

            if ((Gr_NA_S.Checked == false) && (Gr_NA_N.Checked == false))
                lMsg = " Debe Indicar una Opción para  ¿HE NOTIFICADO TODAS LAS AVERIAS? ";

            if ((Cmb_Supervisor.SelectedValue.ToString().ToUpper().Equals("SELECCIONAR")))
                lMsg = " Debe Indicar el Supervisor asignado  ";

            //Gr_NA_S
            return lMsg;
        }

        private string ValidaDobladora()
        {
            string lMsg = "";
            if ((RB_PD_S.Checked == false) && (RB_PD_N.Checked == false))
                 lMsg = "Debe Indicar una Opción para  la opción  PLATO DE DOBLADO, OPERATIVO EN CONDICIONES ";
            
            if ((RB_ED_S.Checked == false) && (RB_ED_N.Checked == false))
                      lMsg = " Debe Indicar una Opción para  la opción  EJES DE DOBLADO, OPERATIVOS EN CONDICIONES  ";

            if ((RB_FP_S.Checked == false) && (RB_FP_N.Checked == false))
                lMsg = "Debe Indicar una Opción para  la  opción FUNCIONAMIENTO DE PARTIDA, OPERACIÓN NORMAL ";
            
            if ((RB_CA_S.Checked == false) && (RB_CA_N.Checked == false))
                lMsg = " Debe Indicar una Opción para  la opción  CAMISAS, OPERATIVOS EN CONDICIONES ";
            

            if ((RB_BU_S.Checked == false) && (RB_BU_N.Checked == false))
               lMsg = " Debe Indicar una Opción para  la opción BULONES, OPERATIVOS EN CONDICIONES  ";
            
            if ((RB_CM_S.Checked == false) && (RB_CM_N.Checked == false))
               lMsg = " Debe Indicar una Opción para  la opción CONTROLES DE MANDO, OPERATIVOS EN CONDICIONES  ";

              if ((RB_PE_S.Checked == false) && (RB_PE_N.Checked == false))
                lMsg = " Debe Indicar una Opción para  la opción PARADA DE EMERGENCIA OPERATIVA ";
              
            if ((RB_OP_S.Checked == false) && (RB_OP_N.Checked == false))
                lMsg = " Debe Indicar una Opción para  la opción ORDEN DE PUESTO DE TRABAJO  ";

            if ((RB_EE_S.Checked == false) && (RB_EE_N.Checked == false))
                lMsg = " Debe Indicar una Opción para  la opción EXTENSIONES ELÉCTRICAS, OPERATIVAS EN CONDICIONES ";


            if ((RB_LM_S.Checked == false) && (RB_LM_N.Checked == false))
                 lMsg = " Debe Indicar una Opción para  la opción LIMPIEZA DE MÁQUINA, PARTES/PIEZA  ";

         
            return lMsg;
        }

        private string ValidaCortadora()
        {
            string lMsg = "";
            if ((RB_CC_S.Checked == false) && (RB_CC_N.Checked == false))
                lMsg = "Debe Indicar una Opción para  la opción  CONJUNTO DE CORTE, OPERATIVO EN CONDICIONES";

            if ((RB_PC_S.Checked == false) && (RB_PC_N.Checked == false))
                lMsg = " Debe Indicar una Opción para  la opción  PERNOS Y CUCHILLOS, OPERATIVO EN CONDICIONES  ";

            if ((RB_C_FP_S.Checked == false) && (RB_C_FP_N.Checked == false))
                lMsg = "Debe Indicar una Opción para  la  opción FUNCIONAMIENTO DE PARTIDA, OPERACIÓN NORMAL ";

            if ((RB_C_TC_S.Checked == false) && (RB_C_TC_N.Checked == false))
                lMsg = " Debe Indicar una Opción para  la opción  TRASLACION DE CARRO, OPERATIVO EN CONDICIONES ";

            if ((RB_C_RE_S.Checked == false) && (RB_C_RE_N.Checked == false))
                lMsg = " Debe Indicar una Opción para  la opción RESGUARDOS (PROTECCIONES - CUBIERTAS)  ";

            if ((RB_C_CM_S.Checked == false) && (RB_C_CM_N.Checked == false))
                lMsg = " Debe Indicar una Opción para  la opción CONTROLES DE MANDO, OPERATIVOS EN CONDICIONES  ";

            if ((RB_C_PM_S.Checked == false) && (RB_C_PM_N.Checked == false))
                lMsg = " Debe Indicar una Opción para  la opción PARADA DE EMERGENCIA OPERATIVA ";

            if ((RB_C_OP_S.Checked == false) && (RB_C_OP_N.Checked == false))
                lMsg = " Debe Indicar una Opción para  la opción ORDEN DE PUESTO DE TRABAJO ";

            if ((RB_C_LM_S.Checked == false) && (RB_C_LM_N.Checked == false))
                lMsg = " Debe Indicar una Opción para  la opción LIMPIEZA DE MÁQUINA, PARTES/PIEZA ";


            if ((RB_C_EE_S.Checked == false) && (RB_C_EE_N.Checked == false))
                lMsg = " Debe Indicar una Opción para  la opción EXTENSIONES ELÉCTRICAS, OPERATIVAS EN CONDICIONES ";

            if ((Cmb_Supervisor .SelectedValue.ToString ().ToUpper ().Equals ("SELECCIONAR")))
                lMsg = " Debe Indicar el Supervisor asignado  ";




            return lMsg;
        }

        private string ValidaCurvadora()
        {
            string lMsg = "";
            if ((RB_BM_S.Checked == false) && (RB_BM_N.Checked == false))
                lMsg = "Debe Indicar una Opción para  la opción  BULON MASTER, OPERATIVO EN CONDICIONES";

            if ((RB_BE_S.Checked == false) && (RB_BE_N.Checked == false))
                lMsg = " Debe Indicar una Opción para  la opción  BULON ESCLAVO, OPERATIVO EN CONDICIONES  ";

            if ((RB_GF_S.Checked == false) && (RB_GF_N.Checked == false))
                lMsg = "Debe Indicar una Opción para  la  opción GUIA DE FIERRO, OPERATIVA EN CONDICIONES ";

            if ((RB_TP_S.Checked == false) && (RB_TP_N.Checked == false))
                lMsg = " Debe Indicar una Opción para  la opción  TRASLACION PANEL DIGITAL, OPERATIVO EN CONDICIONES ";


            if ((RB_CU_PM_S.Checked == false) && (RB_CU_PM_N.Checked == false))
                lMsg = " Debe Indicar una Opción para  la opción PARADA DE EMERGENCIA OPERATIVA  ";

            if ((RB_CU_OP_S.Checked == false) && (RB_CU_OP_N.Checked == false))
                lMsg = " Debe Indicar una Opción para  la opción ORDEN DE PUESTO DE TRABAJO  ";

            
            if ((RB_CU_LM_S.Checked == false) && (RB_CU_LM_N.Checked == false))
                lMsg = " Debe Indicar una Opción para  la opciónLIMPIEZA DE MÁQUINA, PARTES/PIEZA ";

            if ((RB_CU_EE_S.Checked == false) && (RB_CU_EE_N.Checked == false))
                lMsg = " Debe Indicar una Opción para  la opción EXTENSIONES ELÉCTRICAS, OPERATIVAS EN CONDICIONES ";
 
            return lMsg;
        }

        private Boolean ValidarAntesDeGrabar()
        {
            Boolean lRes = true;string lMsg   = "";
            switch (mTipoMaq)
            {
                case "ES":   //  Estibadoras
                    lMsg = ValidaEstibadoras();
                    if (lMsg .Trim ().Length >0 )
                            lRes = false ;

                    break;

                case "CU":  // CURVADORA
                    lMsg = ValidaDobladora ();
                    if (lMsg.Trim().Length > 0)
                        lRes = false;

                    break;

                case "CO":  // CORTADORA
                    lMsg = ValidaCortadora();

                    if (lMsg.Trim().Length > 0)
                        lRes = false;
                    break;
            }

            if (lMsg.ToString().Length > 0)
                MessageBox.Show(lMsg, "Avisos Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return lRes;
        }


        private void GrabarEstibadoras()
        {
            DataTable lTblRes = new DataTable(); DataRow lFila = null;
            lTblRes.Columns.Add("Id", Type.GetType("System.String"));
            lTblRes.Columns.Add("NroMaq", Type.GetType("System.String"));
            lTblRes.Columns.Add("IdUsuario", Type.GetType("System.String"));
            lTblRes.Columns.Add("RespuestaRev", Type.GetType("System.String"));
            lTblRes.Columns.Add("RevisionMaq", Type.GetType("System.String"));
            lTblRes.Columns.Add("SuperVisor", Type.GetType("System.String"));

            lFila = lTblRes.NewRow();                   lFila["NroMaq"] = mUserLog.IdMaquina ;
            lFila["IdUsuario"] = mUserLog.Iduser ;      lFila["RevisionMaq"] = "RUEDA DE ARRASTRE";
            lFila["SuperVisor"] = Cmb_Supervisor.SelectedValue;
            if (RB_RA_S.Checked == true )
                lFila["RespuestaRev"] = "S";
            else
                lFila["RespuestaRev"] = "N";

            lTblRes.Rows.Add(lFila);

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["RevisionMaq"] = "RUEDA DE MEDIDA";
            lFila["SuperVisor"] = Cmb_Supervisor.SelectedValue;
            if (RB_RM_S.Checked == true)
                lFila["RespuestaRev"] = "S";
            else
                lFila["RespuestaRev"] = "N";

            lTblRes.Rows.Add(lFila);

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["RevisionMaq"] = "RUEDA DE PRESION";
            lFila["SuperVisor"] = Cmb_Supervisor.SelectedValue;
            if (RB_RP_S.Checked == true)
                lFila["RespuestaRev"] = "S";
            else
                lFila["RespuestaRev"] = "N";

            lTblRes.Rows.Add(lFila);

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["RevisionMaq"] = "RODILLO DE ENDEREZADO";
            lFila["SuperVisor"] = Cmb_Supervisor.SelectedValue;
            if (RB_RE_S.Checked == true)
                lFila["RespuestaRev"] = "S";
            else
                lFila["RespuestaRev"] = "N";

            lTblRes.Rows.Add(lFila);

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["RevisionMaq"] = "CUCHILLO MOVIL";
            lFila["SuperVisor"] = Cmb_Supervisor.SelectedValue;
            if (RB_CUM_S.Checked == true)
                lFila["RespuestaRev"] = "S";
            else
                lFila["RespuestaRev"] = "N";

            lTblRes.Rows.Add(lFila);


            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["RevisionMaq"] = "CUCHILLO FIJO";
            lFila["SuperVisor"] = Cmb_Supervisor.SelectedValue;
            if (RB_CF_S.Checked == true)
                lFila["RespuestaRev"] = "S";
            else
                lFila["RespuestaRev"] = "N";

            lTblRes.Rows.Add(lFila);

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["RevisionMaq"] = "NOTIFICADO TODAS LAS AVERIAS";
            lFila["SuperVisor"] = Cmb_Supervisor.SelectedValue;
            if (Gr_NA_S.Checked == true)
                lFila["RespuestaRev"] = "S";
            else
                lFila["RespuestaRev"] = "N";

            lTblRes.Rows.Add(lFila);

            //Se envia la Tabla al Servicio Web para la persistencia de datos.
            PersisteDatos(lTblRes);

        }


        private void PersisteDatos(DataTable iTbl)
        {
            WsOperacion.OperacionSoapClient lWs = new WsOperacion.OperacionSoapClient();
            WsOperacion.ListaDataSet lDts = new WsOperacion.ListaDataSet();
            DataSet lDatos = new DataSet();string lMsg = ""; Boolean lEnviaMail = false;
            string lCuerpoMail = "";string lTitulo = ""; string lRes = "";
            Ws_TO.Ws_ToSoapClient lWsMail = new Ws_TO.Ws_ToSoapClient();


            lDatos.Tables.Add(iTbl.Copy());
            lDts = lWs.GrabarChequeoMaquina(lDatos);
            // Se debe grabar y luego enviar correo de Notificación a Lista de distribución la Misma que Notificacion Averias


            if (lDts.MensajeError.Trim().Length > 0)
            {
                lMsg = string.Concat("NO se han grabado los datos, Ha ocurrido el Siguiente Error: ", lDts.MensajeError);
                lEnviaMail = false;
            }
            else
            {
                lMsg = "Los Datos se han grabado Correctamente ";
                lEnviaMail = true ;
                Btn_grabar.Enabled = false;
            }

            if (lEnviaMail == true)
            {
                lDts = lWs.ObtenerDatosParaEnvioMail( );
                if ((lDts.MensajeError.Trim().Length == 0) && (lDts.DataSet .Tables .Count  > 0))
                {
                    //Se debe Construir el Cuerpo del correo para posteriormente enviarlo.
                    lCuerpoMail = ObtenerCuerpoMail(lDts.DataSet.Tables[0]);
                    lTitulo = " Chequeo Maquina  ";
                    lRes = lWsMail.EnviaNotificacionesEnviaMsgDeNotificacion("", lCuerpoMail, -15, lTitulo);
                    if (lRes.ToUpper().Equals("OK"))
                    {
                        lMsg = string.Concat(lMsg, ". Se ha enviado un correo de Notificación ");
                        // lMsg = "La Notificación de Averia fue procesada  correctamente, Se enviara un mail para que se gestione la reparación de la Averia";
                    }
                    else
                    {
                        lMsg = string.Concat(lMsg, ". Pero no se ha podido enviar Correo de Notificación ");
                    }
                }
                MessageBox.Show(lMsg, " Avisos Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
               


            // MessageBox.Show(string.Concat("NO se han grabado los datos, Ha ocurrido el Siguiente Error: ", lDts.MensajeError), "Avisos Sistema");
        }

        private string ObtenerCuerpoMail( DataTable lTbl)
        {
            string lRes = "";int i = 0; string lFecha = ""; string lNomMaq = ""; string lUser = "";

            if (lTbl .Rows .Count >0)
            {
                lFecha = lTbl.Rows[0]["FechaRevision"].ToString();
                lNomMaq = lTbl.Rows[0]["NomMaq"].ToString();
                lUser = lTbl.Rows[0]["usuario"].ToString();


                lRes = String.Concat(" Señores Mantenimiento:  ", "<br> <br> ");
                lRes = String.Concat(lRes, " Con Fecha: " , lFecha , " <br> El Usuario: "  , lUser , " <br> Ha reportado un Chequeo para la  Máquina ", lNomMaq,  "  <br> ");
                lRes = String.Concat(lRes," Los Datos del  Chequeo  son: ", "  <br> ");
                for (i = 0; i < lTbl.Rows.Count; i++)
                {
                    lRes = String.Concat(lRes, " ", lTbl.Rows [i]["RevisionMaq"].ToString (), ": ", lTbl.Rows[i]["RespuestaRevision"].ToString(), "  <br> ");
                }

  
                lRes = String.Concat(lRes, "  <br> ", "  <br> ");

                lRes = String.Concat(lRes, "Este mail ha sido enviado de forma automática por el sistema", "  <br> ");
            }
            return lRes;
        }


        private void GrabarDobladora()
        {
            DataTable lTblRes = new DataTable(); DataRow lFila = null;
            lTblRes.Columns.Add("Id", Type.GetType("System.String"));
            lTblRes.Columns.Add("NroMaq", Type.GetType("System.String"));
            lTblRes.Columns.Add("IdUsuario", Type.GetType("System.String"));
            lTblRes.Columns.Add("RespuestaRev", Type.GetType("System.String"));
            lTblRes.Columns.Add("RevisionMaq", Type.GetType("System.String"));
            lTblRes.Columns.Add("SuperVisor", Type.GetType("System.String"));

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["RevisionMaq"] = "PLATO DE DOBLADO, OPERATIVO EN CONDICIONES";
            lFila["SuperVisor"] = Cmb_Supervisor.SelectedValue;
            if (RB_PD_S.Checked == true)
                lFila["RespuestaRev"] = "S";
            else
                lFila["RespuestaRev"] = "N";

            lTblRes.Rows.Add(lFila);

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["RevisionMaq"] = "EJES DE DOBLADO, OPERATIVOS EN CONDICIONES";
            lFila["SuperVisor"] = Cmb_Supervisor.SelectedValue;
            if (RB_ED_S.Checked == true)
                lFila["RespuestaRev"] = "S";
            else
                lFila["RespuestaRev"] = "N";

            lTblRes.Rows.Add(lFila);

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["RevisionMaq"] = "FUNCIONAMIENTO DE PARTIDA, OPERACIÓN NORMAL";
            lFila["SuperVisor"] = Cmb_Supervisor.SelectedValue;
            if (RB_FP_S.Checked == true)
                lFila["RespuestaRev"] = "S";
            else
                lFila["RespuestaRev"] = "N";

            lTblRes.Rows.Add(lFila);

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["RevisionMaq"] = "CAMISAS, OPERATIVOS EN CONDICIONES";
            lFila["SuperVisor"] = Cmb_Supervisor.SelectedValue;
            if (RB_CA_S.Checked == true)
                lFila["RespuestaRev"] = "S";
            else
                lFila["RespuestaRev"] = "N";

            lTblRes.Rows.Add(lFila);


            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["RevisionMaq"] = "BULONES, OPERATIVOS EN CONDICIONES";
            lFila["SuperVisor"] = Cmb_Supervisor.SelectedValue;
            if (RB_BU_S.Checked == true)
                lFila["RespuestaRev"] = "S";
            else
                lFila["RespuestaRev"] = "N";

            lTblRes.Rows.Add(lFila);

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["RevisionMaq"] = "CONTROLES DE MANDO, OPERATIVOS EN CONDICIONES";
            lFila["SuperVisor"] = Cmb_Supervisor.SelectedValue;
            if (RB_CM_S.Checked == true)
                lFila["RespuestaRev"] = "S";
            else
                lFila["RespuestaRev"] = "N";

            lTblRes.Rows.Add(lFila);

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["RevisionMaq"] = "PARADA DE EMERGENCIA OPERATIVA";
            lFila["SuperVisor"] = Cmb_Supervisor.SelectedValue;
            if (RB_PE_S.Checked == true)
                lFila["RespuestaRev"] = "S";
            else
                lFila["RespuestaRev"] = "N";

            lTblRes.Rows.Add(lFila);

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["RevisionMaq"] = "ORDEN DE PUESTO DE TRABAJO";
            lFila["SuperVisor"] = Cmb_Supervisor.SelectedValue;
            if (RB_OP_S.Checked == true)
                lFila["RespuestaRev"] = "S";
            else
                lFila["RespuestaRev"] = "N";

            lTblRes.Rows.Add(lFila);


            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["RevisionMaq"] = "EXTENSIONES ELÉCTRICAS, OPERATIVAS EN CONDICIONES";
            lFila["SuperVisor"] = Cmb_Supervisor.SelectedValue;
            if (RB_EE_S.Checked == true)
                lFila["RespuestaRev"] = "S";
            else
                lFila["RespuestaRev"] = "N";

            lTblRes.Rows.Add(lFila);

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["RevisionMaq"] = "LIMPIEZA DE MÁQUINA, PARTES/PIEZA";
            lFila["SuperVisor"] = Cmb_Supervisor.SelectedValue;
            if (RB_LM_S.Checked == true)
                lFila["RespuestaRev"] = "S";
            else
                lFila["RespuestaRev"] = "N";

            lTblRes.Rows.Add(lFila);

            //Se envia la Tabla al Servicio Web para la persistencia de datos.
            PersisteDatos(lTblRes);

        }

        private void GrabarCortadora()
        {
            DataTable lTblRes = new DataTable(); DataRow lFila = null;
            lTblRes.Columns.Add("Id", Type.GetType("System.String"));
            lTblRes.Columns.Add("NroMaq", Type.GetType("System.String"));
            lTblRes.Columns.Add("IdUsuario", Type.GetType("System.String"));
            lTblRes.Columns.Add("RespuestaRev", Type.GetType("System.String"));
            lTblRes.Columns.Add("RevisionMaq", Type.GetType("System.String"));
            lTblRes.Columns.Add("SuperVisor", Type.GetType("System.String"));

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["RevisionMaq"] = "CONJUNTO DE CORTE, OPERATIVO EN CONDICIONES";
            lFila["SuperVisor"] = Cmb_Supervisor.SelectedValue;
            if (RB_CC_S.Checked == true)
                lFila["RespuestaRev"] = "S";
            else
                lFila["RespuestaRev"] = "N";

            lTblRes.Rows.Add(lFila);

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["RevisionMaq"] = "PERNOS Y CUCHILLOS, OPERATIVO EN CONDICIONES";
            lFila["SuperVisor"] = Cmb_Supervisor.SelectedValue;
            if (RB_PC_S.Checked == true)
                lFila["RespuestaRev"] = "S";
            else
                lFila["RespuestaRev"] = "N";

            lTblRes.Rows.Add(lFila);   

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["RevisionMaq"] = "FUNCIONAMIENTO DE PARTIDA, OPERACIÓN NORMAL";
            lFila["SuperVisor"] = Cmb_Supervisor.SelectedValue;
            if (RB_C_FP_S.Checked == true)
                lFila["RespuestaRev"] = "S";
            else
                lFila["RespuestaRev"] = "N";

            lTblRes.Rows.Add(lFila);

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["RevisionMaq"] = "TRASLACION DE CARRO, OPERATIVO EN CONDICIONES";
            lFila["SuperVisor"] = Cmb_Supervisor.SelectedValue;
            if (RB_C_TC_S.Checked == true)
                lFila["RespuestaRev"] = "S";
            else
                lFila["RespuestaRev"] = "N";

            lTblRes.Rows.Add(lFila);


            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["RevisionMaq"] = "RESGUARDOS (PROTECCIONES - CUBIERTAS)";
            lFila["SuperVisor"] = Cmb_Supervisor.SelectedValue;
            if (RB_C_RE_S.Checked == true)
                lFila["RespuestaRev"] = "S";
            else
                lFila["RespuestaRev"] = "N";

            lTblRes.Rows.Add(lFila);

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["RevisionMaq"] = "CONTROLES DE MANDO, OPERATIVOS EN CONDICIONES";
            lFila["SuperVisor"] = Cmb_Supervisor.SelectedValue;
            if (RB_C_CM_S.Checked == true)
                lFila["RespuestaRev"] = "S";
            else
                lFila["RespuestaRev"] = "N";

            lTblRes.Rows.Add(lFila);


            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["RevisionMaq"] = "PARADA DE EMERGENCIA OPERATIVA";
            lFila["SuperVisor"] = Cmb_Supervisor.SelectedValue;
            if (RB_C_PM_S.Checked == true)
                lFila["RespuestaRev"] = "S";
            else
                lFila["RespuestaRev"] = "N";

            lTblRes.Rows.Add(lFila);

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["RevisionMaq"] = "ORDEN DE PUESTO DE TRABAJO";
            lFila["SuperVisor"] = Cmb_Supervisor.SelectedValue;
            if (RB_C_OP_S.Checked == true)
                lFila["RespuestaRev"] = "S";
            else
                lFila["RespuestaRev"] = "N";

            lTblRes.Rows.Add(lFila);


            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["RevisionMaq"] = "LIMPIEZA DE MÁQUINA, PARTES/PIEZA";
            lFila["SuperVisor"] = Cmb_Supervisor.SelectedValue;
            if (RB_C_LM_S.Checked == true)
                lFila["RespuestaRev"] = "S";
            else
                lFila["RespuestaRev"] = "N";

            lTblRes.Rows.Add(lFila);


            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["RevisionMaq"] = " EXTENSIONES ELÉCTRICAS, OPERATIVAS EN CONDICIONES";
            lFila["SuperVisor"] = Cmb_Supervisor.SelectedValue;
            if (RB_C_EE_S.Checked == true)
                lFila["RespuestaRev"] = "S";
            else
                lFila["RespuestaRev"] = "N";

            lTblRes.Rows.Add(lFila);


            //Se envia la Tabla al Servicio Web para la persistencia de datos.
            PersisteDatos(lTblRes);

        }

        private void GrabarCurvadora()
        {
            DataTable lTblRes = new DataTable(); DataRow lFila = null;
            lTblRes.Columns.Add("Id", Type.GetType("System.String"));
            lTblRes.Columns.Add("NroMaq", Type.GetType("System.String"));
            lTblRes.Columns.Add("IdUsuario", Type.GetType("System.String"));
            lTblRes.Columns.Add("RespuestaRev", Type.GetType("System.String"));
            lTblRes.Columns.Add("RevisionMaq", Type.GetType("System.String"));
            lTblRes.Columns.Add("SuperVisor", Type.GetType("System.String"));

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["RevisionMaq"] = "BULON MASTER, OPERATIVO EN CONDICIONES";
            lFila["SuperVisor"] = Cmb_Supervisor.SelectedValue;
            if (RB_BM_S.Checked == true)
                lFila["RespuestaRev"] = "S";
            else
                lFila["RespuestaRev"] = "N";

            lTblRes.Rows.Add(lFila);

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["RevisionMaq"] = "BULON ESCLAVO, OPERATIVO EN CONDICIONES ";
            lFila["SuperVisor"] = Cmb_Supervisor.SelectedValue;
            if (RB_BE_S.Checked == true)
                lFila["RespuestaRev"] = "S";
            else
                lFila["RespuestaRev"] = "N";

            lTblRes.Rows.Add(lFila);

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["RevisionMaq"] = "GUIA DE FIERRO, OPERATIVA EN CONDICIONES";
            lFila["SuperVisor"] = Cmb_Supervisor.SelectedValue;
            if (RB_GF_S.Checked == true)
                lFila["RespuestaRev"] = "S";
            else
                lFila["RespuestaRev"] = "N";

            lTblRes.Rows.Add(lFila);

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["RevisionMaq"] = "TRASLACION PANEL DIGITAL, OPERATIVO EN CONDICIONES ";
            lFila["SuperVisor"] = Cmb_Supervisor.SelectedValue;
            if (RB_TP_S.Checked == true)
                lFila["RespuestaRev"] = "S";
            else
                lFila["RespuestaRev"] = "N";

            lTblRes.Rows.Add(lFila);

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["RevisionMaq"] = "PARADA DE EMERGENCIA OPERATIVA";
            lFila["SuperVisor"] = Cmb_Supervisor.SelectedValue;
            if (RB_CU_PM_S.Checked == true)
                lFila["RespuestaRev"] = "S";
            else
                lFila["RespuestaRev"] = "N";

            lTblRes.Rows.Add(lFila);

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["RevisionMaq"] = "ORDEN DE PUESTO DE TRABAJO";
            lFila["SuperVisor"] = Cmb_Supervisor.SelectedValue;
            if (RB_CU_OP_S.Checked == true)
                lFila["RespuestaRev"] = "S";
            else
                lFila["RespuestaRev"] = "N";

            lTblRes.Rows.Add(lFila);


            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["RevisionMaq"] = "LIMPIEZA DE MAQUINA, PARTES/PIEZA";
            lFila["SuperVisor"] = Cmb_Supervisor.SelectedValue;
            if (RB_CU_LM_S.Checked == true)
                lFila["RespuestaRev"] = "S";
            else
                lFila["RespuestaRev"] = "N";

            lTblRes.Rows.Add(lFila);



            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["RevisionMaq"] = "EXTENSIONES ELÉCTRICAS, OPERATIVAS EN CONDICIONES";
            lFila["SuperVisor"] = Cmb_Supervisor.SelectedValue;
            if (RB_CU_EE_S.Checked == true)
                lFila["RespuestaRev"] = "S";
            else
                lFila["RespuestaRev"] = "N";

            lTblRes.Rows.Add(lFila);


            //Se envia la Tabla al Servicio Web para la persistencia de datos.
            PersisteDatos(lTblRes);

        }

        private void Btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }

}



