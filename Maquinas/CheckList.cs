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
        public CheckList()
        {
            InitializeComponent();
        }

        private void Btn_grabar_Click(object sender, EventArgs e)
        {

        }


        private void CheckList_Load(object sender, EventArgs e)
        {

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
                     
                        break;

                    case "CO":  // CORTADORA
                        
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
                    tabControl1.SelectedTab = SP_Cortadora;
                    tabControl1.TabPages.Remove(TP_Dobladora);
                    tabControl1.TabPages.Remove(SP_Curvadora);
                    tabControl1.TabPages.Remove(TP_Estibadoras);
                    mTipoMaq = "CO";
                    break;
            }
        }

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
           

            return lMsg;
        }

        private string ValidaDobladora()
        {
            string lMsg = "";
            if ((RB_PD_S.Checked == false) && (RB_PD_N.Checked == false))
                 lMsg = "Debe Indicar una Opción para  la opción  PLATO DE DOBLADO, OPERATIVO EN CONDICIONES ";
            
            if ((RB_ED_S.Checked == false) && (RB_ED_N.Checked == false))
                      lMsg = " Debe Indicar una Opción para  la opción  EJES DE DOBLADO, OPERATIVOS EN CONDICIONES  ";

            if ((RB_FP_S.Checked == false) && (RB_FP_S.Checked == false))
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
                    lRes = false ;
                    break;

                case "CU":  // CURVADORA
                    lMsg = ValidaDobladora ();
                    lRes = false;
                    break;

                case "CO":  // CORTADORA
                    lMsg = ValidaCortadora();
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
            lTblRes.Columns.Add("NroMaq", Type.GetType("System.String"));
            lTblRes.Columns.Add("IdUsuario", Type.GetType("System.String"));
            lTblRes.Columns.Add("RespuestaRev", Type.GetType("System.String"));
            lTblRes.Columns.Add("RevisionMaq", Type.GetType("System.String"));

            lFila = lTblRes.NewRow();                   lFila["NroMaq"] = mUserLog.IdMaquina ;
            lFila["IdUsuario"] = mUserLog.Iduser ;      lFila["RevisionMaq"] = "RUEDA DE ARRASTRE";
            if (RB_RA_S.Checked == true )
                lFila["RespuestaRev"] = "S";
            else
                lFila["RespuestaRev"] = "N";

            lTblRes.Rows.Add(lFila);

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["RevisionMaq"] = "RUEDA DE MEDIDA";
            if (RB_RM_S.Checked == true)
                lFila["RespuestaRev"] = "S";
            else
                lFila["RespuestaRev"] = "N";

            lTblRes.Rows.Add(lFila);

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["RevisionMaq"] = "RUEDA DE PRESION";
            if (RB_RP_S.Checked == true)
                lFila["RespuestaRev"] = "S";
            else
                lFila["RespuestaRev"] = "N";

            lTblRes.Rows.Add(lFila);

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["RevisionMaq"] = "RODILLO DE ENDEREZADO";
            if (RB_RE_S.Checked == true)
                lFila["RespuestaRev"] = "S";
            else
                lFila["RespuestaRev"] = "N";

            lTblRes.Rows.Add(lFila);

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["RevisionMaq"] = "CUCHILLO MOVIL";
            if (RB_CUM_S.Checked == true)
                lFila["RespuestaRev"] = "S";
            else
                lFila["RespuestaRev"] = "N";

            lTblRes.Rows.Add(lFila);


            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["RevisionMaq"] = "CUCHILLO FIJO";
            if (RB_CF_S.Checked == true)
                lFila["RespuestaRev"] = "S";
            else
                lFila["RespuestaRev"] = "N";

            lTblRes.Rows.Add(lFila);

            //Se envia la Tabla al Servicio Web para la persistencia de datos.

        }


        private void GrabarDobladora()
        {
            DataTable lTblRes = new DataTable(); DataRow lFila = null;
            lTblRes.Columns.Add("Id", Type.GetType("System.String"));
            lTblRes.Columns.Add("NroMaq", Type.GetType("System.String"));
            lTblRes.Columns.Add("IdUsuario", Type.GetType("System.String"));
            lTblRes.Columns.Add("RespuestaRev", Type.GetType("System.String"));
            lTblRes.Columns.Add("RevisionMaq", Type.GetType("System.String"));

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["RevisionMaq"] = "PLATO DE DOBLADO, OPERATIVO EN CONDICIONES";
            if (RB_PD_S.Checked == true)
                lFila["RespuestaRev"] = "S";
            else
                lFila["RespuestaRev"] = "N";

            lTblRes.Rows.Add(lFila);

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["RevisionMaq"] = "EJES DE DOBLADO, OPERATIVOS EN CONDICIONES";
            if (RB_ED_S.Checked == true)
                lFila["RespuestaRev"] = "S";
            else
                lFila["RespuestaRev"] = "N";

            lTblRes.Rows.Add(lFila);

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["RevisionMaq"] = "FUNCIONAMIENTO DE PARTIDA, OPERACIÓN NORMAL";
            if (RB_FP_S.Checked == true)
                lFila["RespuestaRev"] = "S";
            else
                lFila["RespuestaRev"] = "N";

            lTblRes.Rows.Add(lFila);

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["RevisionMaq"] = "CAMISAS, OPERATIVOS EN CONDICIONES";
            if (RB_CA_S.Checked == true)
                lFila["RespuestaRev"] = "S";
            else
                lFila["RespuestaRev"] = "N";

            lTblRes.Rows.Add(lFila);


            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["RevisionMaq"] = "BULONES, OPERATIVOS EN CONDICIONES";
            if (RB_BU_S.Checked == true)
                lFila["RespuestaRev"] = "S";
            else
                lFila["RespuestaRev"] = "N";

            lTblRes.Rows.Add(lFila);

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["RevisionMaq"] = "CONTROLES DE MANDO, OPERATIVOS EN CONDICIONES";
            if (RB_CM_S.Checked == true)
                lFila["RespuestaRev"] = "S";
            else
                lFila["RespuestaRev"] = "N";

            lTblRes.Rows.Add(lFila);

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["RevisionMaq"] = "PARADA DE EMERGENCIA OPERATIVA";
            if (RB_PE_S.Checked == true)
                lFila["RespuestaRev"] = "S";
            else
                lFila["RespuestaRev"] = "N";

            lTblRes.Rows.Add(lFila);

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["RevisionMaq"] = "ORDEN DE PUESTO DE TRABAJO";
            if (RB_OP_S.Checked == true)
                lFila["RespuestaRev"] = "S";
            else
                lFila["RespuestaRev"] = "N";

            lTblRes.Rows.Add(lFila);


            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["RevisionMaq"] = "EXTENSIONES ELÉCTRICAS, OPERATIVAS EN CONDICIONES";
            if (RB_EE_S.Checked == true)
                lFila["RespuestaRev"] = "S";
            else
                lFila["RespuestaRev"] = "N";

            lTblRes.Rows.Add(lFila);

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["RevisionMaq"] = "LIMPIEZA DE MÁQUINA, PARTES/PIEZA";
            if (RB_LM_S.Checked == true)
                lFila["RespuestaRev"] = "S";
            else
                lFila["RespuestaRev"] = "N";

            lTblRes.Rows.Add(lFila);

            //Se envia la Tabla al Servicio Web para la persistencia de datos.

        }

        private void GrabarCortadora()
        {
            DataTable lTblRes = new DataTable(); DataRow lFila = null;
            lTblRes.Columns.Add("NroMaq", Type.GetType("System.String"));
            lTblRes.Columns.Add("IdUsuario", Type.GetType("System.String"));
            lTblRes.Columns.Add("RespuestaRev", Type.GetType("System.String"));
            lTblRes.Columns.Add("RevisionMaq", Type.GetType("System.String"));

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["RevisionMaq"] = "CONJUNTO DE CORTE, OPERATIVO EN CONDICIONES";
            if (RB_CC_S.Checked == true)
                lFila["RespuestaRev"] = "S";
            else
                lFila["RespuestaRev"] = "N";

            lTblRes.Rows.Add(lFila);

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["RevisionMaq"] = "PERNOS Y CUCHILLOS, OPERATIVO EN CONDICIONES";
            if (RB_PC_S.Checked == true)
                lFila["RespuestaRev"] = "S";
            else
                lFila["RespuestaRev"] = "N";

            lTblRes.Rows.Add(lFila);   

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["RevisionMaq"] = "FUNCIONAMIENTO DE PARTIDA, OPERACIÓN NORMAL";
            if (RB_C_FP_S.Checked == true)
                lFila["RespuestaRev"] = "S";
            else
                lFila["RespuestaRev"] = "N";

            lTblRes.Rows.Add(lFila);

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["RevisionMaq"] = "TRASLACION DE CARRO, OPERATIVO EN CONDICIONES";
            if (RB_C_TC_S.Checked == true)
                lFila["RespuestaRev"] = "S";
            else
                lFila["RespuestaRev"] = "N";

            lTblRes.Rows.Add(lFila);


            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["RevisionMaq"] = "RESGUARDOS (PROTECCIONES - CUBIERTAS)";
            if (RB_C_RE_S.Checked == true)
                lFila["RespuestaRev"] = "S";
            else
                lFila["RespuestaRev"] = "N";

            lTblRes.Rows.Add(lFila);

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["RevisionMaq"] = "CONTROLES DE MANDO, OPERATIVOS EN CONDICIONES";
            if (RB_C_CM_S.Checked == true)
                lFila["RespuestaRev"] = "S";
            else
                lFila["RespuestaRev"] = "N";

            lTblRes.Rows.Add(lFila);


            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["RevisionMaq"] = "PARADA DE EMERGENCIA OPERATIVA";
            if (RB_C_PM_S.Checked == true)
                lFila["RespuestaRev"] = "S";
            else
                lFila["RespuestaRev"] = "N";

            lTblRes.Rows.Add(lFila);

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["RevisionMaq"] = "ORDEN DE PUESTO DE TRABAJO";
            if (RB_C_OP_S.Checked == true)
                lFila["RespuestaRev"] = "S";
            else
                lFila["RespuestaRev"] = "N";

            lTblRes.Rows.Add(lFila);


            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["RevisionMaq"] = "LIMPIEZA DE MÁQUINA, PARTES/PIEZA";
            if (RB_C_LM_S.Checked == true)
                lFila["RespuestaRev"] = "S";
            else
                lFila["RespuestaRev"] = "N";

            lTblRes.Rows.Add(lFila);


            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["RevisionMaq"] = " EXTENSIONES ELÉCTRICAS, OPERATIVAS EN CONDICIONES";
            if (RB_C_EE_S.Checked == true)
                lFila["RespuestaRev"] = "S";
            else
                lFila["RespuestaRev"] = "N";

            lTblRes.Rows.Add(lFila);

           
            //Se envia la Tabla al Servicio Web para la persistencia de datos.

        }

        private void GrabarCurvadora()
        {
            DataTable lTblRes = new DataTable(); DataRow lFila = null;
            lTblRes.Columns.Add("NroMaq", Type.GetType("System.String"));
            lTblRes.Columns.Add("IdUsuario", Type.GetType("System.String"));
            lTblRes.Columns.Add("RespuestaRev", Type.GetType("System.String"));
            lTblRes.Columns.Add("RevisionMaq", Type.GetType("System.String"));

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["RevisionMaq"] = "BULON MASTER, OPERATIVO EN CONDICIONES";
            if (RB_BM_S.Checked == true)
                lFila["RespuestaRev"] = "S";
            else
                lFila["RespuestaRev"] = "N";

            lTblRes.Rows.Add(lFila);

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["RevisionMaq"] = "BULON ESCLAVO, OPERATIVO EN CONDICIONES ";
            if (RB_BE_S.Checked == true)
                lFila["RespuestaRev"] = "S";
            else
                lFila["RespuestaRev"] = "N";

            lTblRes.Rows.Add(lFila);

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["RevisionMaq"] = "GUIA DE FIERRO, OPERATIVA EN CONDICIONES";
            if (RB_GF_S.Checked == true)
                lFila["RespuestaRev"] = "S";
            else
                lFila["RespuestaRev"] = "N";

            lTblRes.Rows.Add(lFila);

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["RevisionMaq"] = "TRASLACION PANEL DIGITAL, OPERATIVO EN CONDICIONES ";
            if (RB_TP_S.Checked == true)
                lFila["RespuestaRev"] = "S";
            else
                lFila["RespuestaRev"] = "N";

            lTblRes.Rows.Add(lFila);

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["RevisionMaq"] = "PARADA DE EMERGENCIA OPERATIVA";
            if (RB_CU_PM_S.Checked == true)
                lFila["RespuestaRev"] = "S";
            else
                lFila["RespuestaRev"] = "N";

            lTblRes.Rows.Add(lFila);

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["RevisionMaq"] = "ORDEN DE PUESTO DE TRABAJO";
            if (RB_CU_OP_S.Checked == true)
                lFila["RespuestaRev"] = "S";
            else
                lFila["RespuestaRev"] = "N";

            lTblRes.Rows.Add(lFila);


            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["RevisionMaq"] = "LIMPIEZA DE MAQUINA, PARTES/PIEZA";
            if (RB_CU_LM_S.Checked == true)
                lFila["RespuestaRev"] = "S";
            else
                lFila["RespuestaRev"] = "N";

            lTblRes.Rows.Add(lFila);



            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["RevisionMaq"] = "EXTENSIONES ELÉCTRICAS, OPERATIVAS EN CONDICIONES";
            if (RB_CU_EE_S.Checked == true)
                lFila["RespuestaRev"] = "S";
            else
                lFila["RespuestaRev"] = "N";

            lTblRes.Rows.Add(lFila);


            //Se envia la Tabla al Servicio Web para la persistencia de datos.

        }


    }

}



