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
                    case "PR":  // PROCEME
                         GrabarProceme ();
                        break;
                }
            }

           

        }

        private string  Validar_Por_Item( string iITEM)
        {
          string lMsg = "";
            //2.- DEBE HABER POR  LO MENOS UN DATO INGRESDO POR EL USUARIO EN Recomencion y Observacion, 
            // sino no se puede cerrar la aplicación

            switch (iITEM)
            {
                case "1_1":  
                    if ((Rb_SI_1_1.Checked == false) && (Rb_NO_1_1.Checked == false) && (Rb_NA_1_1.Checked == false))
                            lMsg = "Debe seleccionar una Opción de Cumple";
                       
                    
                    if ((Tx_Obs_1_1.Text.Trim().Length == 0) && (Tx_Rec_1_1.Text.Trim().Length == 0))
                            lMsg = string.Concat (lMsg  , " - Debe Ingresar por lo menos una dato en Recomencion y Observacion"); 
                    break;
                case "2_1":    
                    if ((Rb_SI_2_1.Checked == false) && (Rb_NO_2_1.Checked == false) && (Rb_NA_2_1.Checked == false))
                        lMsg = "Debe seleccionar una Opción de Cumple";


                    if ((Tx_Obs_2_1.Text.Trim().Length == 0) && (Tx_Rec_2_1.Text.Trim().Length == 0))
                        lMsg = string.Concat(lMsg, " - Debe Ingresar por lo menos una dato en Recomencion y Observacion");
                    break;
                case "3_1":    
                    if ((Rb_SI_3_1.Checked == false) && (Rb_NO_3_1.Checked == false) && (Rb_NA_3_1.Checked == false))
                        lMsg = "Debe seleccionar una Opción de Cumple";


                    if ((Tx_Obs_3_1.Text.Trim().Length == 0) && (Tx_Rec_3_1.Text.Trim().Length == 0))
                        lMsg = string.Concat(lMsg, " - Debe Ingresar por lo menos una dato en Recomencion y Observacion");
                    break;
                case "1_2":    
                    if ((Rb_SI_1_2.Checked == false) && (Rb_NO_1_2.Checked == false) && (Rb_NA_1_2.Checked == false))
                        lMsg = "Debe seleccionar una Opción de Cumple";


                    if ((Tx_Obs_1_2.Text.Trim().Length == 0) && (Tx_Rec_1_2.Text.Trim().Length == 0))
                        lMsg = string.Concat(lMsg, " - Debe Ingresar por lo menos una dato en Recomencion y Observacion");
                    break;
                case "2_2":
                    if ((Rb_SI_2_2.Checked == false) && (Rb_NO_2_2.Checked == false) && (Rb_NA_2_2.Checked == false))
                        lMsg = "Debe seleccionar una Opción de Cumple";


                    if ((Tx_Obs_2_2.Text.Trim().Length == 0) && (Tx_Rec_2_2.Text.Trim().Length == 0))
                        lMsg = string.Concat(lMsg, " - Debe Ingresar por lo menos una dato en Recomencion y Observacion");
                    break;
                case "3_2":
                    if ((Rb_SI_3_2.Checked == false) && (Rb_NO_3_2.Checked == false) && (Rb_NA_3_2.Checked == false))
                        lMsg = "Debe seleccionar una Opción de Cumple";


                    if ((Tx_Obs_3_2.Text.Trim().Length == 0) && (Tx_Rec_3_2.Text.Trim().Length == 0))
                        lMsg = string.Concat(lMsg, " - Debe Ingresar por lo menos una dato en Recomencion y Observacion");
                    break;
                case "4_2":
                    if ((Rb_SI_4_2.Checked == false) && (Rb_NO_4_2.Checked == false) && (Rb_NA_4_2.Checked == false))
                        lMsg = "Debe seleccionar una Opción de Cumple";


                    if ((Tx_Obs_4_2.Text.Trim().Length == 0) && (Tx_Rec_4_2.Text.Trim().Length == 0))
                        lMsg = string.Concat(lMsg, " - Debe Ingresar por lo menos una dato en Recomencion y Observacion");
                    break;
                case "5_2":
                    if ((Rb_SI_5_2.Checked == false) && (Rb_NO_5_2.Checked == false) && (Rb_NA_5_2.Checked == false))
                        lMsg = "Debe seleccionar una Opción de Cumple";


                    if ((Tx_Obs_5_2.Text.Trim().Length == 0) && (Tx_Rec_5_2.Text.Trim().Length == 0))
                        lMsg = string.Concat(lMsg, " - Debe Ingresar por lo menos una dato en Recomencion y Observacion");
                    break;
                case "6_2":
                    if ((Rb_SI_6_2.Checked == false) && (Rb_NO_6_2.Checked == false) && (Rb_NA_6_2.Checked == false))
                        lMsg = "Debe seleccionar una Opción de Cumple";


                    if ((Tx_Obs_6_2.Text.Trim().Length == 0) && (Tx_Rec_6_2.Text.Trim().Length == 0))
                        lMsg = string.Concat(lMsg, " - Debe Ingresar por lo menos una dato en Recomencion y Observacion");
                    break;
                case "7_2":
                    if ((Rb_SI_7_2.Checked == false) && (Rb_NO_7_2.Checked == false) && (Rb_NA_7_2.Checked == false))
                        lMsg = "Debe seleccionar una Opción de Cumple";


                    if ((Tx_Obs_7_2.Text.Trim().Length == 0) && (Tx_Rec_7_2.Text.Trim().Length == 0))
                        lMsg = string.Concat(lMsg, " - Debe Ingresar por lo menos una dato en Recomencion y Observacion");
                    break;
                case "1_3":
                    if ((Rb_SI_1_3.Checked == false) && (Rb_NO_1_3.Checked == false) && (Rb_NA_1_3.Checked == false))
                        lMsg = "Debe seleccionar una Opción de Cumple";


                    if ((Tx_Obs_1_3.Text.Trim().Length == 0) && (Tx_Rec_1_3.Text.Trim().Length == 0))
                        lMsg = string.Concat(lMsg, " - Debe Ingresar por lo menos una dato en Recomencion y Observacion");
                    break;
                case "2_3":
                    if ((Rb_SI_2_3.Checked == false) && (Rb_NO_2_3.Checked == false) && (Rb_NA_2_3.Checked == false))
                        lMsg = "Debe seleccionar una Opción de Cumple";


                    if ((Tx_Obs_2_3.Text.Trim().Length == 0) && (Tx_Rec_2_3.Text.Trim().Length == 0))
                        lMsg = string.Concat(lMsg, " - Debe Ingresar por lo menos una dato en Recomencion y Observacion");
                    break;
                case "3_3":
                    if ((Rb_SI_3_3.Checked == false) && (Rb_NO_3_3.Checked == false) && (Rb_NA_3_3.Checked == false))
                        lMsg = "Debe seleccionar una Opción de Cumple";


                    if ((Tx_Obs_3_3.Text.Trim().Length == 0) && (Tx_Rec_3_3.Text.Trim().Length == 0))
                        lMsg = string.Concat(lMsg, " - Debe Ingresar por lo menos una dato en Recomencion y Observacion");
                    break;
                case "4_3":
                    if ((Rb_SI_4_3.Checked == false) && (Rb_NO_4_3.Checked == false) && (Rb_NA_4_3.Checked == false))
                        lMsg = "Debe seleccionar una Opción de Cumple";


                    if ((Tx_Obs_4_3.Text.Trim().Length == 0) && (Tx_Rec_4_3.Text.Trim().Length == 0))
                        lMsg = string.Concat(lMsg, " - Debe Ingresar por lo menos una dato en Recomencion y Observacion");
                    break;
                case "5_3":
                    if ((Rb_SI_5_3.Checked == false) && (Rb_NO_5_3.Checked == false) && (Rb_NA_5_3.Checked == false))
                        lMsg = "Debe seleccionar una Opción de Cumple";


                    if ((Tx_Obs_5_3.Text.Trim().Length == 0) && (Tx_Rec_5_3.Text.Trim().Length == 0))
                        lMsg = string.Concat(lMsg, " - Debe Ingresar por lo menos una dato en Recomencion y Observacion");
                    break;
                case "6_3":
                    if ((Rb_SI_6_3.Checked == false) && (Rb_NO_6_3.Checked == false) && (Rb_NA_6_3.Checked == false))
                        lMsg = "Debe seleccionar una Opción de Cumple";


                    if ((Tx_Obs_6_3.Text.Trim().Length == 0) && (Tx_Rec_6_3.Text.Trim().Length == 0))
                        lMsg = string.Concat(lMsg, " - Debe Ingresar por lo menos una dato en Recomencion y Observacion");
                    break;
                case "7_3":
                    if ((Rb_SI_7_3.Checked == false) && (Rb_NO_7_3.Checked == false) && (Rb_NA_7_3.Checked == false))
                        lMsg = "Debe seleccionar una Opción de Cumple";


                    if ((Tx_Obs_7_3.Text.Trim().Length == 0) && (Tx_Rec_7_3.Text.Trim().Length == 0))
                        lMsg = string.Concat(lMsg, " - Debe Ingresar por lo menos una dato en Recomencion y Observacion");
                    break;
                case "1_4":
                    if ((Rb_SI_1_4.Checked == false) && (Rb_NO_1_4.Checked == false) && (Rb_NA_1_4.Checked == false))
                        lMsg = "Debe seleccionar una Opción de Cumple";


                    if ((Tx_Obs_1_4.Text.Trim().Length == 0) && (Tx_Rec_1_4.Text.Trim().Length == 0))
                        lMsg = string.Concat(lMsg, " - Debe Ingresar por lo menos una dato en Recomencion y Observacion");
                    break;
                case "2_4":
                    if ((Rb_SI_2_4.Checked == false) && (Rb_NO_2_4.Checked == false) && (Rb_NA_2_4.Checked == false))
                        lMsg = "Debe seleccionar una Opción de Cumple";


                    if ((Tx_Obs_2_4.Text.Trim().Length == 0) && (Tx_Rec_2_4.Text.Trim().Length == 0))
                        lMsg = string.Concat(lMsg, " - Debe Ingresar por lo menos una dato en Recomencion y Observacion");
                    break;
                case "3_4":
                    if ((Rb_SI_3_4.Checked == false) && (Rb_NO_3_4.Checked == false) && (Rb_NA_3_4.Checked == false))
                        lMsg = "Debe seleccionar una Opción de Cumple";


                    if ((Tx_Obs_3_4.Text.Trim().Length == 0) && (Tx_Rec_3_4.Text.Trim().Length == 0))
                        lMsg = string.Concat(lMsg, " - Debe Ingresar por lo menos una dato en Recomencion y Observacion");
                    break;
                case "4_4":
                    if ((Rb_SI_4_4.Checked == false) && (Rb_NO_4_4.Checked == false) && (Rb_NA_4_4.Checked == false))
                        lMsg = "Debe seleccionar una Opción de Cumple";

                    if ((Tx_Obs_4_4.Text.Trim().Length == 0) && (Tx_Rec_4_4.Text.Trim().Length == 0))
                        lMsg = string.Concat(lMsg, " - Debe Ingresar por lo menos una dato en Recomencion y Observacion");
                    break;
                case "5_4":
                    if ((Rb_SI_5_4.Checked == false) && (Rb_NO_5_4.Checked == false) && (Rb_NA_5_4.Checked == false))
                        lMsg = "Debe seleccionar una Opción de Cumple";

                    if ((Tx_Obs_5_4.Text.Trim().Length == 0) && (Tx_Rec_5_4.Text.Trim().Length == 0))
                        lMsg = string.Concat(lMsg, " - Debe Ingresar por lo menos una dato en Recomencion y Observacion");
                    break;
                case "1_5":
                    if ((Rb_SI_1_5.Checked == false) && (Rb_NO_1_5.Checked == false) && (Rb_NA_1_5.Checked == false))
                        lMsg = "Debe seleccionar una Opción de Cumple";

                    if ((Tx_Obs_1_5.Text.Trim().Length == 0) && (Tx_Rec_1_5.Text.Trim().Length == 0))
                        lMsg = string.Concat(lMsg, " - Debe Ingresar por lo menos una dato en Recomencion y Observacion");
                    break;
                case "2_5":
                    if ((Rb_SI_2_5.Checked == false) && (Rb_NO_2_5.Checked == false) && (Rb_NA_2_5.Checked == false))
                        lMsg = "Debe seleccionar una Opción de Cumple";

                    if ((Tx_Obs_2_5.Text.Trim().Length == 0) && (Tx_Rec_2_5.Text.Trim().Length == 0))
                        lMsg = string.Concat(lMsg, " - Debe Ingresar por lo menos una dato en Recomencion y Observacion");
                    break;
                case "3_5":
                    if ((Rb_SI_3_5.Checked == false) && (Rb_NO_3_5.Checked == false) && (Rb_NA_3_5.Checked == false))
                        lMsg = "Debe seleccionar una Opción de Cumple";

                    if ((Tx_Obs_3_5.Text.Trim().Length == 0) && (Tx_Rec_3_5.Text.Trim().Length == 0))
                        lMsg = string.Concat(lMsg, " - Debe Ingresar por lo menos una dato en Recomencion y Observacion");
                    break;
                case "4_5":
                    if ((Rb_SI_4_5.Checked == false) && (Rb_NO_4_5.Checked == false) && (Rb_NA_4_5.Checked == false))
                        lMsg = "Debe seleccionar una Opción de Cumple";

                    if ((Tx_Obs_4_5.Text.Trim().Length == 0) && (Tx_Rec_4_5.Text.Trim().Length == 0))
                        lMsg = string.Concat(lMsg, " - Debe Ingresar por lo menos una dato en Recomencion y Observacion");
                    break;
                case "5_5":
                    if ((Rb_SI_5_5.Checked == false) && (Rb_NO_5_5.Checked == false) && (Rb_NA_5_5.Checked == false))
                        lMsg = "Debe seleccionar una Opción de Cumple";

                    if ((Tx_Obs_5_5.Text.Trim().Length == 0) && (Tx_Rec_5_5.Text.Trim().Length == 0))
                        lMsg = string.Concat(lMsg, " - Debe Ingresar por lo menos una dato en Recomencion y Observacion");
                    break;
            }
                 
            return lMsg;
        }


        private Boolean Validar_PROCEME()
        {
            Boolean lRes = true;string lMsg = "";
            //2.- DEBE HABER POR  LO MENOS UN DATO INGRESDO POR EL USUARIO EN Recomencion y Observacion, 
            // sino no se puede cerrar la aplicación

            lMsg = Validar_Por_Item("1_1");
            if (lMsg.Length > 0)
            {
                MessageBox.Show(lMsg, " Avisos sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lRes = false;
                tabControl2.SelectedTab = tabPage1;
                Tx_Obs_1_1.Focus(); 
            }
            lMsg = Validar_Por_Item("2_1");
            if (lMsg.Length > 0)
            {
                MessageBox.Show(lMsg, " Avisos sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lRes = false;
                tabControl2.SelectedTab = tabPage1;
                Tx_Obs_2_1.Focus();
            }
            lMsg = Validar_Por_Item("3_1");
            if (lMsg.Length > 0)
            {
                MessageBox.Show(lMsg, " Avisos sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lRes = false;
                tabControl2.SelectedTab = tabPage1;
                Tx_Obs_3_1.Focus();
            }
            lMsg = Validar_Por_Item("1_2");
            if (lMsg.Length > 0)
            {
                MessageBox.Show(lMsg, " Avisos sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lRes = false;
                tabControl2.SelectedTab = tabPage2;
                Tx_Obs_1_2.Focus();
            }
            lMsg = Validar_Por_Item("2_2");
            if (lMsg.Length > 0)
            {
                MessageBox.Show(lMsg, " Avisos sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lRes = false;
                tabControl2.SelectedTab = tabPage2;
                Tx_Obs_2_2.Focus();
            }
            lMsg = Validar_Por_Item("3_2");
            if (lMsg.Length > 0)
            {
                MessageBox.Show(lMsg, " Avisos sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lRes = false;
                tabControl2.SelectedTab = tabPage2;
                Tx_Obs_3_2.Focus();
            }
            lMsg = Validar_Por_Item("4_2");
            if (lMsg.Length > 0)
            {
                MessageBox.Show(lMsg, " Avisos sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lRes = false;
                tabControl2.SelectedTab = tabPage2;
                Tx_Obs_4_2.Focus();
            }
            lMsg = Validar_Por_Item("5_2");
            if (lMsg.Length > 0)
            {
                MessageBox.Show(lMsg, " Avisos sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lRes = false;
                tabControl2.SelectedTab = tabPage2;
                Tx_Obs_5_2.Focus();
            }
            lMsg = Validar_Por_Item("6_2");
            if (lMsg.Length > 0)
            {
                MessageBox.Show(lMsg, " Avisos sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lRes = false;
                tabControl2.SelectedTab = tabPage2;
                Tx_Obs_6_2.Focus();
            }
            lMsg = Validar_Por_Item("7_2");
            if (lMsg.Length > 0)
            {
                MessageBox.Show(lMsg, " Avisos sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lRes = false;
                tabControl2.SelectedTab = tabPage2;
                Tx_Obs_7_2.Focus();
            }
            lMsg = Validar_Por_Item("1_3");
            if (lMsg.Length > 0)
            {
                MessageBox.Show(lMsg, " Avisos sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lRes = false;
                tabControl2.SelectedTab = tabPage3;
                Tx_Obs_1_3.Focus();
            }
            lMsg = Validar_Por_Item("2_3");
            if (lMsg.Length > 0)
            {
                MessageBox.Show(lMsg, " Avisos sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lRes = false;
                tabControl2.SelectedTab = tabPage3;
                Tx_Obs_2_3.Focus();
            }
            lMsg = Validar_Por_Item("3_3");
            if (lMsg.Length > 0)
            {
                MessageBox.Show(lMsg, " Avisos sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lRes = false;
                tabControl2.SelectedTab = tabPage3;
                Tx_Obs_3_3.Focus();
            }
            lMsg = Validar_Por_Item("4_3");
            if (lMsg.Length > 0)
            {
                MessageBox.Show(lMsg, " Avisos sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lRes = false;
                tabControl2.SelectedTab = tabPage3;
                Tx_Obs_4_3.Focus();
            }

            return lRes;
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
                    mTipoMaq = "PR";
                    break;
                case 21:  // CURVADORA
                    tabControl1.SelectedTab = SP_Curvadora;
                    tabControl1.TabPages.Remove(TP_Dobladora);
                    tabControl1.TabPages.Remove(SP_Cortadora);
                    tabControl1.TabPages.Remove(TP_Estibadoras);
                    mTipoMaq = "PR";
                    break;
                case 20:  // CORTADORA
                case 16:
                    tabControl1.SelectedTab = SP_Cortadora;
                    tabControl1.TabPages.Remove(TP_Dobladora);
                    tabControl1.TabPages.Remove(SP_Curvadora);
                    tabControl1.TabPages.Remove(TP_Estibadoras);
                    mTipoMaq = "PR";
                    break;
                    case 17:  // DOBLADORA
                    tabControl1.SelectedTab = TP_Dobladora;
                    tabControl1.TabPages.Remove(SP_Cortadora);
                    tabControl1.TabPages.Remove(SP_Curvadora);
                    tabControl1.TabPages.Remove(TP_Estibadoras);
                    mTipoMaq = "PR";
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

        private string Valida_Proceme()
        {
            string lMsg = "";
            if ((Rb_SI_1_1.Checked == false) && (Rb_NO_1_1.Checked == false) && (Rb_NA_1_1.Checked == false))
            {
                lMsg = "Debe Indicar una Opción de CUMPLE, para Los sistemas de transmisión y partes móviles se encuentran completamente protegidos.";
                tabControl2.SelectedTab = tabPage1;
                Tx_Obs_1_1.Focus();
            }
            else
                if ((Rb_NO_1_1.Checked == true ) && ((Tx_Obs_1_1.Text.Trim().Length < 2) || (Tx_Rec_1_1.Text.Trim().Length < 2)))
            {
                lMsg = "Debe Ingresar por lo menos un dato en Observación y Recomendación, para Los sistemas de transmisión y partes móviles se encuentran completamente protegidos.";
                tabControl2.SelectedTab = tabPage1;
                Tx_Obs_1_1.Focus();
            }

            if ((Rb_SI_2_1.Checked == false) && (Rb_NO_2_1.Checked == false) && (Rb_NA_2_1.Checked == false))
            {
                lMsg = "Debe Indicar una Opción de CUMPLE, para Las defensas fijas están sólidamente aseguradas..";
                tabControl2.SelectedTab = tabPage1;
                Tx_Obs_2_1.Focus();
            }
            else
              if ((Rb_NO_2_1.Checked == true) &&  ((Tx_Obs_2_1.Text.Trim().Length < 2) || (Tx_Rec_2_1.Text.Trim().Length < 2)))
            {
                lMsg = "Debe Ingresar por lo menos un dato en Observación y Recomendación, para Las defensas fijas están sólidamente aseguradas..";
                tabControl2.SelectedTab = tabPage1;
                Tx_Obs_2_1.Focus();
            }

            if ((Rb_SI_3_1.Checked == false) && (Rb_NO_3_1.Checked == false) && (Rb_NA_3_1.Checked == false))
            {
                lMsg = "Debe Indicar una Opción de CUMPLE, Están señalizados los puntos de peligro.";
                tabControl2.SelectedTab = tabPage1;
                Tx_Obs_3_1.Focus();
            }
            else
          if ((Rb_NO_3_1.Checked == true) && ((Tx_Obs_3_1.Text.Trim().Length < 2) || (Tx_Rec_3_1.Text.Trim().Length < 2)))
            {
                lMsg = "Debe Ingresar por lo menos un dato en Observación y Recomendación, para Están señalizados los puntos de peligro.";
                tabControl2.SelectedTab = tabPage1;
                Tx_Obs_3_1.Focus();
            }

            if ((Rb_SI_1_2.Checked == false) && (Rb_NO_1_2.Checked == false) && (Rb_NA_1_2.Checked == false))
            {
                lMsg = "Debe Indicar una Opción de CUMPLE, Las partes móviles de la máquina, equipo o herramienta motriz  son completamente inaccesibles.";
                tabControl2.SelectedTab = tabPage2;
                Tx_Obs_1_2.Focus();
            }
            else
             if ((Rb_NO_1_2.Checked == true ) && ((Tx_Obs_1_2.Text.Trim().Length < 2) || (Tx_Rec_1_2.Text.Trim().Length < 2)))
            {
                lMsg = "Debe Ingresar por lo menos un dato en Observación y Recomendación, Las partes móviles de la máquina, equipo o herramienta motriz  se encuentran cerrados o protegidas.";
                tabControl2.SelectedTab = tabPage2;
                Tx_Obs_1_2.Focus();
            }
            if ((Rb_SI_2_2.Checked == false) && (Rb_NO_2_2.Checked == false) && (Rb_NA_2_2.Checked == false))
            {
                lMsg = "Debe Indicar una Opción de CUMPLE, Existen los dispositivos de seguridad en los puntos de operación.";
                tabControl2.SelectedTab = tabPage2;
                Tx_Obs_2_2.Focus();
            }
            else
             if ((Rb_NO_2_2.Checked == true) && ((Tx_Obs_2_2.Text.Trim().Length < 2) || (Tx_Rec_2_2.Text.Trim().Length < 2)))
            {
                lMsg = "Debe Ingresar por lo menos un dato en Observación y Recomendación, Existen los dispositivos de seguridad en los puntos de operación.";
                tabControl2.SelectedTab = tabPage2;
                Tx_Obs_2_2.Focus();
            }
            if ((Rb_SI_3_2.Checked == false) && (Rb_NO_3_2.Checked == false) && (Rb_NA_3_2.Checked == false))
            {
                lMsg = "Debe Indicar una Opción de CUMPLE, Existen dispositivos de bloqueo .";
                tabControl2.SelectedTab = tabPage2;
                Tx_Obs_3_2.Focus();
            }
            else
            if ((Rb_NO_3_2.Checked == true) && ((Tx_Obs_3_2.Text.Trim().Length < 2) || (Tx_Rec_3_2.Text.Trim().Length < 2)))
            {
                lMsg = "Debe Ingresar por lo menos un dato en Observación y Recomendación, Existen dispositivos de bloqueo .";
                tabControl2.SelectedTab = tabPage2;
                Tx_Obs_3_2.Focus();
            }
            if ((Rb_SI_4_2.Checked == false) && (Rb_NO_4_2.Checked == false) && (Rb_NA_4_2.Checked == false))
            {
                lMsg = "Debe Indicar una Opción de CUMPLE, Están bien señalizados los puntos de peligro y partes en movimiento de la máquinas, equipo o herramienta motriz.";
                tabControl2.SelectedTab = tabPage2;
                Tx_Obs_4_2.Focus();
            }
            else
           if ((Rb_NO_4_2.Checked == true) && ((Tx_Obs_4_2.Text.Trim().Length < 2) || (Tx_Rec_4_2.Text.Trim().Length < 2)))
            {
                lMsg = "Debe Ingresar por lo menos un dato en Observación y Recomendación, Están bien señalizados los puntos de peligro y partes en movimiento de la máquinas, equipo o herramienta motriz.";
                tabControl2.SelectedTab = tabPage2;
                Tx_Obs_4_2.Focus();
            }
            if ((Rb_SI_5_2.Checked == false) && (Rb_NO_5_2.Checked == false) && (Rb_NA_5_2.Checked == false))
            {
                lMsg = "Debe Indicar una Opción de CUMPLE, Se utilizan herramientas o dispositivos para alimentar la máquinas, equipo o herramienta motriz.";
                tabControl2.SelectedTab = tabPage2;
                Tx_Obs_5_2.Focus();
            }
            else
         if ((Rb_NO_5_2.Checked == true) && ((Tx_Obs_5_2.Text.Trim().Length < 2) || (Tx_Rec_5_2.Text.Trim().Length < 2)))
            {
                lMsg = "Debe Ingresar por lo menos un dato en Observación y Recomendación, Se utilizan herramientas o dispositivos para alimentar la máquinas, equipo o herramienta motriz .";
                tabControl2.SelectedTab = tabPage2;
                Tx_Obs_5_2.Focus();
            }
            if ((Rb_SI_6_2.Checked == false) && (Rb_NO_6_2.Checked == false) && (Rb_NA_6_2.Checked == false))
            {
                lMsg = "Debe Indicar una Opción de CUMPLE,La operación de carga y descarga de materia prima y residuos representa peligro para los operarios.";
                tabControl2.SelectedTab = tabPage2;
                Tx_Obs_6_2.Focus();
            }
            else
         if ((Rb_NO_6_2.Checked == true) && ((Tx_Obs_6_2.Text.Trim().Length < 2) || (Tx_Rec_6_2.Text.Trim().Length < 2)))
            {
                lMsg = "Debe Ingresar por lo menos un dato en Observación y Recomendación, La operación de carga y descarga de materia prima y residuos no representa peligro para los operarios.";
                tabControl2.SelectedTab = tabPage2;
                Tx_Obs_6_2.Focus();
            }

            if ((Rb_SI_7_2.Checked == false) && (Rb_NO_7_2.Checked == false) && (Rb_NA_7_2.Checked == false))
            {
                lMsg = "Debe Indicar una Opción de CUMPLE, El puesto de trabajo se encuentra libre de materiales o elementos que dificulten el desarrollo de la operación.";
                tabControl2.SelectedTab = tabPage2;
                Tx_Obs_7_2.Focus();
            }
            else
         if ((Rb_NO_7_2.Checked == true) && ((Tx_Obs_7_2.Text.Trim().Length < 2) || (Tx_Rec_7_2.Text.Trim().Length < 2)))
            {
                lMsg = "Debe Ingresar por lo menos un dato en Observación y Recomendación, El puesto de trabajo se encuentra libre de materiales o elementos que dificulten el desarrollo de la operación.";
                tabControl2.SelectedTab = tabPage2;
                Tx_Obs_7_2.Focus();
            }

            if ((Rb_SI_1_3.Checked == false) && (Rb_NO_1_3.Checked == false) && (Rb_NA_1_3.Checked == false))
            {
                lMsg = "Debe Indicar una Opción de CUMPLE, dispositivos de control son visibles, están claramente identificados,  de fácil alcance por el operario  y ubicados fuera de las zonas peligrosas.";
                tabControl2.SelectedTab = tabPage3;
                Tx_Obs_1_3.Focus();
            }
            else
            if ((Rb_NO_1_3.Checked == true) &&  ((Tx_Obs_1_3.Text.Trim().Length < 2) || (Tx_Rec_1_3.Text.Trim().Length < 2)))
            {
                lMsg = "Debe Ingresar por lo menos un dato en Observación y Recomendación, dispositivos de control son visibles, están claramente identificados,  de fácil alcance por el operario  y ubicados fuera de las zonas peligrosas.";
                tabControl2.SelectedTab = tabPage3;
                Tx_Obs_1_3.Focus();
            }

            if ((Rb_SI_2_3.Checked == false) && (Rb_NO_2_3.Checked == false) && (Rb_NA_2_3.Checked == false))
            {
                lMsg = "Debe Indicar una Opción de CUMPLE, Su accionamiento sólo es posible de manera intencionada.";
                tabControl2.SelectedTab = tabPage3;
                Tx_Obs_2_3.Focus();
            }
            else
           if ((Rb_NO_2_3.Checked == true) && ((Tx_Obs_2_3.Text.Trim().Length < 2) || (Tx_Rec_2_3.Text.Trim().Length < 2)))
            {
                lMsg = "Debe Ingresar por lo menos un dato en Observación y Recomendación, Su accionamiento sólo es posible de manera intencionada.";
                tabControl2.SelectedTab = tabPage3;
                Tx_Obs_2_3.Focus();
            }

            if ((Rb_SI_3_3.Checked == false) && (Rb_NO_3_3.Checked == false) && (Rb_NA_3_3.Checked == false))
            {
                lMsg = "Debe Indicar una Opción de CUMPLE, Las paradas de emergencia tienen enclavamiento (quedan bloqueadas).";
                tabControl2.SelectedTab = tabPage3;
                Tx_Obs_3_3.Focus();
            }
            else
            if ((Rb_NO_3_3.Checked == true) && ((Tx_Obs_3_3.Text.Trim().Length < 2) || (Tx_Rec_3_3.Text.Trim().Length < 2)))
            {
                lMsg = "Debe Ingresar por lo menos un dato en Observación y Recomendación, Las paradas de emergencia tienen enclavamiento (quedan bloqueadas).";
                tabControl2.SelectedTab = tabPage3;
                Tx_Obs_3_3.Focus();
            }

            if ((Rb_SI_4_3.Checked == false) && (Rb_NO_4_3.Checked == false) && (Rb_NA_4_3.Checked == false))
            {
                lMsg = "Debe Indicar una Opción de CUMPLE, Desde el punto de mando el operador ve todas las zonas de peligro de la máquinas, equipo o herramienta motriz  o en su defecto existe una señal acústica o visible de puesta en marcha.";
                tabControl2.SelectedTab = tabPage3;
                Tx_Obs_4_3.Focus();
            }
            else
          if ((Rb_NO_4_3.Checked == true) && ((Tx_Obs_4_3.Text.Trim().Length < 2) || (Tx_Rec_4_3.Text.Trim().Length < 2)))
            {
                lMsg = "Debe Ingresar por lo menos un dato en Observación y Recomendación, Desde el punto de mando el operador ve todas las zonas de peligro de la máquinas, equipo o herramienta motriz  o en su defecto existe una señal acústica o visible de puesta en marcha.";
                tabControl2.SelectedTab = tabPage3;
                Tx_Obs_4_3.Focus();
            }

            if ((Rb_SI_5_3.Checked == false) && (Rb_NO_5_3.Checked == false) && (Rb_NA_5_3.Checked == false))
            {
                lMsg = "Debe Indicar una Opción de CUMPLE, Existen uno o mas dispositivos de parada de emergencia y se encuentran cerca de los puntos de peligro.";
                tabControl2.SelectedTab = tabPage3;
                Tx_Obs_5_3.Focus();
            }
            else
          if ((Rb_NO_5_3.Checked == true) && ((Tx_Obs_5_3.Text.Trim().Length < 2) || (Tx_Rec_5_3.Text.Trim().Length < 2)))
            {
                lMsg = "Debe Ingresar por lo menos un dato en Observación y Recomendación, Existen uno o mas dispositivos de parada de emergencia y se encuentran cerca de los puntos de peligro.";
                tabControl2.SelectedTab = tabPage3;
                Tx_Obs_5_3.Focus();
            }

            if ((Rb_SI_6_3.Checked == false) && (Rb_NO_6_3.Checked == false) && (Rb_NA_6_3.Checked == false))
            {
                lMsg = "Debe Indicar una Opción de CUMPLE, Los cables y conexiones eléctricas no tienen partes expuestas y están bien canalizados.";
                tabControl2.SelectedTab = tabPage3;
                Tx_Obs_6_3.Focus();
            }
            else
                 if ((Rb_NO_6_3.Checked == true) && ((Tx_Obs_6_3.Text.Trim().Length < 2) || (Tx_Rec_6_3.Text.Trim().Length < 2)))
            {
                lMsg = "Debe Ingresar por lo menos un dato en Observación y Recomendación, Los cables y conexiones eléctricas no tienen partes expuestas y están bien canalizados.";
                tabControl2.SelectedTab = tabPage3;
                Tx_Obs_6_3.Focus();
            }


            if ((Rb_SI_7_3.Checked == false) && (Rb_NO_7_3.Checked == false) && (Rb_NA_7_3.Checked == false))
            {
                lMsg = "Debe Indicar una Opción de CUMPLE, Se tiene establecido el procedimiento para el bloqueo de energías  peligrosas.";
                tabControl2.SelectedTab = tabPage3;
                Tx_Obs_7_3.Focus();
            }
            else
                if ((Rb_NO_7_3.Checked == true) && ((Tx_Obs_7_3.Text.Trim().Length < 2) || (Tx_Rec_7_3.Text.Trim().Length < 2)))
            {
                lMsg = "Debe Ingresar por lo menos un dato en Observación y Recomendación, Se tiene establecido el procedimiento para el bloqueo de energías  peligrosas.";
                tabControl2.SelectedTab = tabPage3;
                Tx_Obs_7_3.Focus();
            }


            if ((Rb_SI_1_4.Checked == false) && (Rb_NO_1_4.Checked == false) && (Rb_NA_1_4.Checked == false))
            {
                lMsg = "Debe Indicar una Opción de CUMPLE, El operador está instrudo en el Procedimiento de Trabajo seguro de la máquina, equipo o herramienta motriz.";
                tabControl2.SelectedTab = tabPage4;
                Tx_Obs_1_4.Focus();
            }
            else
                if ((Rb_NO_1_3.Checked == true) && ((Tx_Obs_1_4.Text.Trim().Length < 2) || (Tx_Rec_1_4.Text.Trim().Length < 2)))
            {
                lMsg = "Debe Ingresar por lo menos un dato en Observación y Recomendación, El operador está instrudo en el Procedimiento de Trabajo seguro de la máquina, equipo o herramienta motriz.";
                tabControl2.SelectedTab = tabPage4;
                Tx_Obs_1_4.Focus();
            }


            if ((Rb_SI_2_4.Checked == false) && (Rb_NO_2_4.Checked == false) && (Rb_NA_2_4.Checked == false))
            {
                lMsg = "Debe Indicar una Opción de CUMPLE, El operador usa los elementos de protección personal requeridos.";
                tabControl2.SelectedTab = tabPage4;
                Tx_Obs_2_4.Focus();
            }
            else
                if ((Rb_NO_2_4.Checked == true) && ((Tx_Obs_2_4.Text.Trim().Length < 2) || (Tx_Rec_2_4.Text.Trim().Length < 2)))
            {
                lMsg = "Debe Ingresar por lo menos un dato en Observación y Recomendación, El operador usa los elementos de protección personal requeridos.";
                tabControl2.SelectedTab = tabPage4;
                Tx_Obs_2_4.Focus();
            }

            if ((Rb_SI_3_4.Checked == false) && (Rb_NO_3_4.Checked == false) && (Rb_NA_3_4.Checked == false))
            {
                lMsg = "Debe Indicar una Opción de CUMPLE, El operador no porta cadenas, anillos, ropa suelta u otro tipo de accesorios que le signifiquen peligro.";
                tabControl2.SelectedTab = tabPage4;
                Tx_Obs_3_4.Focus();
            }
            else
                if ((Rb_NO_3_4.Checked == true) && ((Tx_Obs_3_4.Text.Trim().Length < 2) || (Tx_Rec_3_4.Text.Trim().Length < 2)))
            {
                lMsg = "Debe Ingresar por lo menos un dato en Observación y Recomendación, El operador no porta cadenas, anillos, ropa suelta u otro tipo de accesorios que le signifiquen peligro.";
                tabControl2.SelectedTab = tabPage4;
                Tx_Obs_3_4.Focus();
            }

            if ((Rb_SI_4_4.Checked == false) && (Rb_NO_4_4.Checked == false) && (Rb_NA_4_4.Checked == false))
            {
                lMsg = "Debe Indicar una Opción de CUMPLE, El operador usa en forma segura las herramientas manuales y de operación de la máquina, equipo o herramienta motriz.";
                tabControl2.SelectedTab = tabPage4;
                Tx_Obs_4_4.Focus();
            }
            else
               if ((Rb_NO_4_4.Checked == true) && ((Tx_Obs_4_4.Text.Trim().Length < 2) || (Tx_Rec_4_4.Text.Trim().Length < 2)))
            {
                lMsg = "Debe Ingresar por lo menos un dato en Observación y Recomendación, El operador usa en forma segura las herramientas manuales y de operación de la máquina, equipo o herramienta motriz.";
                tabControl2.SelectedTab = tabPage4;
                Tx_Obs_4_4.Focus();
            }

            if ((Rb_SI_5_4.Checked == false) && (Rb_NO_5_4.Checked == false) && (Rb_NA_5_4.Checked == false))
            {
                lMsg = "Debe Indicar una Opción de CUMPLE, El operador no se distrae usando  celular, no realizando juegos o bromas.";
                tabControl2.SelectedTab = tabPage4;
                Tx_Obs_5_4.Focus();
            }
            else
            if ((Rb_NO_5_4.Checked == true) && ((Tx_Obs_5_4.Text.Trim().Length < 2) || (Tx_Rec_5_4.Text.Trim().Length < 2)))
            {
                lMsg = "Debe Ingresar por lo menos un dato en Observación y Recomendación, El operador no se distrae usando  celular, no realizando juegos o bromas.";
                tabControl2.SelectedTab = tabPage4;
                Tx_Obs_5_4.Focus();
            }

            if ((Rb_SI_1_5.Checked == false) && (Rb_NO_1_5.Checked == false) && (Rb_NA_1_5.Checked == false))
            {
                lMsg = "Debe Indicar una Opción de CUMPLE, El área de desplazamiento de los operarios esta libre de obstáculos que impidan su caminar y operación.";
                tabControl2.SelectedTab = tabPage5;
                Tx_Obs_1_5.Focus();
            }
            else
            if ((Rb_NO_1_5.Checked == true) && ((Tx_Obs_1_5.Text.Trim().Length < 2) || (Tx_Rec_1_5.Text.Trim().Length < 2)))
            {
                lMsg = "Debe Ingresar por lo menos un dato en Observación y Recomendación, El área de desplazamiento de los operarios esta libre de obstáculos que impidan su caminar y operación.";
                tabControl2.SelectedTab = tabPage5;
                Tx_Obs_1_5.Focus();
            }

            if ((Rb_SI_2_5.Checked == false) && (Rb_NO_2_5.Checked == false) && (Rb_NA_2_5.Checked == false))
            {
                lMsg = "Debe Indicar una Opción de CUMPLE, Las luminarias se encuentran en condiciones adecuadas para su funcionamiento. ";
                tabControl2.SelectedTab = tabPage5;
                Tx_Obs_2_5.Focus();
            }
            else
            if ((Rb_NO_2_5.Checked == true) && ((Tx_Obs_2_5.Text.Trim().Length < 2) || (Tx_Rec_2_5.Text.Trim().Length < 2)))
            {
                lMsg = "Debe Ingresar por lo menos un dato en Observación y Recomendación, Las luminarias se encuentran en condiciones adecuadas para su funcionamiento. ";
                tabControl2.SelectedTab = tabPage5;
                Tx_Obs_2_5.Focus();
            }

            if ((Rb_SI_3_5.Checked == false) && (Rb_NO_3_5.Checked == false) && (Rb_NA_3_5.Checked == false))
            {
                lMsg = "Debe Indicar una Opción de CUMPLE, Los pisos se encuentran libres de grietas, desniveles, grasa, aceite o agua alrededor de la máquina. ";
                tabControl2.SelectedTab = tabPage5;
                Tx_Obs_3_5.Focus();
            }
            else
            if ((Rb_NO_3_5.Checked == true) && ((Tx_Obs_3_5.Text.Trim().Length < 2) || (Tx_Rec_3_5.Text.Trim().Length < 2)))
            {
                lMsg = "Debe Ingresar por lo menos un dato en Observación y Recomendación, Los pisos se encuentran libres de grietas, desniveles, grasa, aceite o agua alrededor de la máquina. ";
                tabControl2.SelectedTab = tabPage5;
                Tx_Obs_3_5.Focus();
            }

            if ((Rb_SI_4_5.Checked == false) && (Rb_NO_4_5.Checked == false) && (Rb_NA_4_5.Checked == false))
            {
                lMsg = "Debe Indicar una Opción de CUMPLE, Las escaleras cuentan con pasamanos, peldaños  con superficie antideslizante,  libres de fisuras y grasas. ";
                tabControl2.SelectedTab = tabPage5;
                Tx_Obs_4_5.Focus();
            }
            else
            if ((Rb_NO_4_5.Checked == true) && ((Tx_Obs_4_5.Text.Trim().Length < 2) || (Tx_Rec_4_5.Text.Trim().Length < 2)))
            {
                lMsg = "Debe Ingresar por lo menos un dato en Observación y Recomendación, Las escaleras cuentan con pasamanos, peldaños  con superficie antideslizante,  libres de fisuras y grasas. ";
                tabControl2.SelectedTab = tabPage5;
                Tx_Obs_4_5.Focus();
            }

            if ((Rb_SI_5_5.Checked == false) && (Rb_NO_5_5.Checked == false) && (Rb_NA_5_5.Checked == false))
            {
                lMsg = "Debe Indicar una Opción de CUMPLE, Existen bordes cortantes, superficies salientes u otras condiciones irregulares. ";
                tabControl2.SelectedTab = tabPage5;
                Tx_Obs_5_5.Focus();
            }
            else
          if ((Rb_NO_5_5.Checked == true) && ((Tx_Obs_5_5.Text.Trim().Length < 2) || (Tx_Rec_5_5.Text.Trim().Length < 2)))
            {
                lMsg = "Debe Ingresar por lo menos un dato en Observación y Recomendación, Existen bordes cortantes, superficies salientes u otras condiciones irregulares. ";
                tabControl2.SelectedTab = tabPage5;
                Tx_Obs_5_5.Focus();
            }

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
                case "PR":  // Funcionalidad mormativa Proceme 31/08/2022
                    lMsg = Valida_Proceme();

                    if (lMsg.Trim().Length > 0)
                        lRes = false;
                    break;
            }

            if (lMsg.ToString().Length > 0)
                MessageBox.Show(lMsg, "Avisos Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return lRes;
        }

        private void PersisteDatos_Proceme(DataTable iTbl, string iMaquina, string iUsuario)
        {
            WsOperacion.OperacionSoapClient lWs = new WsOperacion.OperacionSoapClient();
            WsOperacion.ListaDataSet lDts = new WsOperacion.ListaDataSet();string lNroMaq = "";
            DataSet lDatos = new DataSet(); string lMsg = ""; Boolean lEnviaMail = false;
            string lCuerpoMail = ""; string lTitulo = ""; string lRes = "";
            Ws_TO.Ws_ToSoapClient lWsMail = new Ws_TO.Ws_ToSoapClient();


            lDatos.Tables.Add(iTbl.Copy());
            lDts = lWs.GrabarChequeoMaquina_Proceme(lDatos);
            // Se debe grabar y luego enviar correo de Notificación a Lista de distribución la Misma que Notificacion Averias


            if (lDts.MensajeError.Trim().Length > 0)
            {
                lMsg = string.Concat("NO se han grabado los datos, Ha ocurrido el Siguiente Error: ", lDts.MensajeError);
                lEnviaMail = false;
            }
            else
            {
                lMsg = "Los Datos se han grabado Correctamente ";
                lEnviaMail = true;
                Btn_grabar.Enabled = false;
                lNroMaq = lDts.DataSet.Tables[0].Rows[0]["NroMaq"].ToString();
            }

            if (lEnviaMail == true)
            {
                //lDts = lWs.ObtenerDatosParaEnvioMail(lNroMaq);
                if ((lDts.MensajeError.Trim().Length == 0) && (lDts.DataSet.Tables.Count > 0))
                {
                    //Se debe Construir el Cuerpo del correo para posteriormente enviarlo.
                    lCuerpoMail = ObtenerCuerpoMail(lDts.DataSet.Tables[0], iMaquina,iUsuario );
                    lTitulo = " PROSEMEH  ( Programa seguridad en máquinas equipos y herramientas ) ";
                    lRes = lWsMail.EnviaNotificacionesEnviaMsgDeNotificacion("", lCuerpoMail, -25, lTitulo);
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
                //lDts = lWs.ObtenerDatosParaEnvioMail( );
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
          }

        private string ObtenerCuerpoMail( DataTable lTbl)
        {
            string lRes = "";int i = 0; string lFecha = ""; string lNomMaq = ""; string lUser = "";
            try
            {
                if (lTbl.Rows.Count > 0)
                {
                    lFecha = lTbl.Rows[0]["FechaRevision"].ToString();
                    lNomMaq = lTbl.Rows[0]["NomMaq"].ToString();
                    lUser = lTbl.Rows[0]["usuario"].ToString();


                    lRes = String.Concat(" Señores Mantenimiento:  ", "<br> <br> ");
                    lRes = String.Concat(lRes, " Con Fecha: ", lFecha, " <br> El Usuario: ", lUser, " <br> Ha reportado un Chequeo para la  Máquina ", lNomMaq, "  <br> ");
                    lRes = String.Concat(lRes, " Los Datos del  Chequeo  son: ", "  <br> ");
                    for (i = 0; i < lTbl.Rows.Count; i++)
                    {
                        lRes = String.Concat(lRes, " ", lTbl.Rows[i]["RevisionMaq"].ToString(), ": ", lTbl.Rows[i]["RespuestaRevision"].ToString(), "  <br> ");
                    }


                    lRes = String.Concat(lRes, "  <br> ", "  <br> ");

                    lRes = String.Concat(lRes, "Este mail ha sido enviado de forma automática por el sistema", "  <br> ");
                }
            }
            catch (Exception iEx)
            {

            }
            return lRes;
        }

        private string ObtenerCuerpoMail(DataTable lTbl, string iMaquina , string iUsuario)
        {
            string lRes = ""; int i = 0; string lFecha = ""; string lNomMaq = ""; string lUser = "";
            string Body = "";
            try
            {
                if (lTbl.Rows.Count > 0)
                {
                    lFecha = DateTime.Now.ToLongDateString () ;
                    lNomMaq = iMaquina; // lTbl.Rows[0]["NomMaq"].ToString();
                    lUser = iUsuario; // lTbl.Rows[0]["usuario"].ToString();


                    Body = String.Concat(" Señores Mantenimiento:  ", "<br> <br> ");
                    Body = String.Concat(Body, " El Usuario: ", lUser, " Con Fecha: ", lFecha, " <br>   Ha reportado un Chequeo para la  Máquina ", lNomMaq, "  <br> ");
                    Body = String.Concat(Body, " Los Datos del  Chequeo  son: ", "  <br>  <br> ");

                    //----------------------------------------------------------------------------
                    Body = string.Concat(Body, " <table align = 'center' border = '1' width = '1200px' >          ");
                    Body = string.Concat(Body, "  <tr> <td align = 'center' > PARTE DE LA MAQUINA O EQUIPO </td>  ");
                    Body = string.Concat(Body, "  <td align = 'center' > VARIABLE A VERIFICAR</ td> <td align = 'center' > CUMPLE </td>   ");
                    Body = string.Concat(Body, "  <td>OBSERVACIONES</td>  <td >RECOMENDACIONES</td>  </tr>  <tr> ");

                    Body = string.Concat(Body, " <td style = 'font-family: Arial; font-size: small' rowspan='3' > 'Sistema de transmisión y partes móviles' </td>");
                    Body = string.Concat(Body, " <td style = 'font-family: Arial; font-size: small' > Los sistemas de transmisión y partes móviles se encuentran completamente protegidos.</td>");
                    Body = string.Concat(Body, "<td style = 'font-family: Arial; font-size: small' >", lTbl.Rows[0]["Cumple"].ToString (), "</td>  <td style = 'font-family: Arial; font-size: small' > ", lTbl.Rows[0]["Obs"].ToString(), " </td> ");
                  Body = string.Concat(Body, " <td style = 'font-family: Arial; font-size: small' >", lTbl.Rows[0]["Recomendacion"].ToString(), " </td> </tr>");
                    Body = string.Concat(Body, "   <tr> <td style = 'font-family: Arial; font-size: small' > Las defensas fijas están sólidamente aseguradas.</td> ");
                    Body = string.Concat(Body, "  <td style = 'font-family: Arial; font-size: small' >", lTbl.Rows[1]["Cumple"].ToString(), "</td> <td style = 'font-family: Arial; font-size: small' > ", lTbl.Rows[1]["Obs"].ToString(), "</td> ");
                    Body = string.Concat(Body, "  <td style = 'font-family: Arial; font-size: small' > ", lTbl.Rows[1]["Recomendacion"].ToString(), " </td>       </tr>                 <tr>");
                    Body = string.Concat(Body, "   <td style = 'font-family: Arial; font-size: small' > Están señalizados los puntos de peligro.</td> ");
                    Body = string.Concat(Body, "  <td style = 'font-family: Arial; font-size: small' >", lTbl.Rows[2]["Cumple"].ToString(), " </td> <td style = 'font-family: Arial; font-size: small' >", lTbl.Rows[2]["Obs"].ToString(), " </td> ");
                    Body = string.Concat(Body, "  <td style = 'font-family: Arial; font-size: small' > ", lTbl.Rows[2]["Recomendacion"].ToString(), " </td>   </tr>   <tr>");
                    Body = string.Concat(Body, "  <td style = 'font-family: Arial; font-size: small' rowspan='7' >     Punto de Operación             </td>  ");
                    Body = string.Concat(Body, " <td style = 'font-family: Arial; font-size: small' > Las partes móviles de la máquina, equipo o herramienta motriz son completamente inaccesibles</td> ");
                    Body = string.Concat(Body, " <td style = 'font-family: Arial; font-size: small' > ", lTbl.Rows[3]["Cumple"].ToString(), " </td>    <td style = 'font-family: Arial; font-size: small' > ", lTbl.Rows[3]["Obs"].ToString(), "</td>");
                    Body = string.Concat(Body, "  <td style = 'font-family: Arial; font-size: small' > ", lTbl.Rows[3]["Recomendacion"].ToString(), "</td>     </tr>    <tr> ");
                    Body = string.Concat(Body, "  <td style = 'font-family: Arial; font-size: small' > Existen los dispositivos de seguridad en los puntos de operación</td> ");
                    Body = string.Concat(Body, "   <td style = 'font-family: Arial; font-size: small' >", lTbl.Rows[4]["Cumple"].ToString(), "</td>  <td style = 'font-family: Arial; font-size: small' > ", lTbl.Rows[4]["Obs"].ToString(), " </td> ");
                    Body = string.Concat(Body, "   <td style = 'font-family: Arial; font-size: small' > ", lTbl.Rows[4]["Recomendacion"].ToString(), " </td>     </tr>   <tr> ");
                    Body = string.Concat(Body, "  <td style = 'font-family: Arial; font-size: small' > Existen dispositivos de bloqueo</td>  ");
                    Body = string.Concat(Body, "   <td style = 'font-family: Arial; font-size: small' >", lTbl.Rows[5]["Cumple"].ToString(), "</td> <td style = 'font-family: Arial; font-size: small' > ", lTbl.Rows[5]["Obs"].ToString(), "</td> ");
                    Body = string.Concat(Body, "    <td style = 'font-family: Arial; font-size: small' > ", lTbl.Rows[5]["Recomendacion"].ToString(), "</td>   </tr>   <tr> ");
                    Body = string.Concat(Body, "  <td style = 'font-family: Arial; font-size: small' > Están bien señalizados los puntos de peligro y partes en movimiento de la máquinas, equipo o herramienta motriz</td> ");
                    Body = string.Concat(Body, " <td style = 'font-family: Arial; font-size: small' > ", lTbl.Rows[6]["Cumple"].ToString(), "</td>  <td style = 'font-family: Arial; font-size: small' > ", lTbl.Rows[6]["Obs"].ToString(), "  </td>  ");
                    Body = string.Concat(Body, "  <td style = 'font-family: Arial; font-size: small' > ", lTbl.Rows[6]["Recomendacion"].ToString(), " </td>  </tr>   <tr> ");
                    Body = string.Concat(Body, "  <td style = 'font-family: Arial; font-size: small' > Se utilizan herramientas o dispositivos para alimentar la máquinas, equipo o herramienta motriz</td> ");
                    Body = string.Concat(Body, "   <td style = 'font-family: Arial; font-size: small' > ", lTbl.Rows[7]["Cumple"].ToString(), "</td>     <td style = 'font-family: Arial; font-size: small' > ", lTbl.Rows[7]["Obs"].ToString(), " </td>");
                    Body = string.Concat(Body, " <td style = 'font-family: Arial; font-size: small' >  ", lTbl.Rows[7]["Recomendacion"].ToString(), "</td>  </tr>  <tr> ");
                    Body = string.Concat(Body, "  <td style = 'font-family: Arial; font-size: small' > La operación de carga y descarga de materia prima y residuos no representa peligro para los operarios.</td> ");
                    Body = string.Concat(Body, "  <td style = 'font-family: Arial; font-size: small' > ", lTbl.Rows[8]["Cumple"].ToString(), " </td> <td style = 'font-family: Arial; font-size: small' >  ", lTbl.Rows[8]["Obs"].ToString(), "  </td> ");
                    Body = string.Concat(Body, " <td style = 'font-family: Arial; font-size: small' >    ", lTbl.Rows[8]["Recomendacion"].ToString(), " </td>   </tr>   <tr>  ");
                    Body = string.Concat(Body, " <td style = 'font-family: Arial; font-size: small' > El puesto de trabajo se encuentra libre de materiales o elementos que dificulten el desarrollo de la operación.</td> ");
                    Body = string.Concat(Body, " <td style = 'font-family: Arial; font-size: small' >  ", lTbl.Rows[9]["Cumple"].ToString(), " </td> <td style = 'font-family: Arial; font-size: small' > ", lTbl.Rows[9]["Obs"].ToString(), "  </td> ");
                    Body = string.Concat(Body, " <td style = 'font-family: Arial; font-size: small' >  ", lTbl.Rows[9]["Recomendacion"].ToString(), "  </td> </tr>  <tr> ");
                    Body = string.Concat(Body, "  <td style = 'font-family: Arial; font-size: small' rowspan='7' >   Dispositivos de Control         </td>  ");
                    Body = string.Concat(Body, " <td style = 'font-family: Arial; font-size: small' > Los dispositivos de control son visibles, están claramente identificados, de fácil alcance por el operario y ubicados fuera de las zonas peligrosas.</td> ");
                    Body = string.Concat(Body, " <td style = 'font-family: Arial; font-size: small' >", lTbl.Rows[10]["Cumple"].ToString(), "</td> <td style = 'font-family: Arial; font-size: small' >", lTbl.Rows[10]["Obs"].ToString(), " </td>  ");
                    Body = string.Concat(Body, " <td style = 'font-family: Arial; font-size: small' > ", lTbl.Rows[10]["Recomendacion"].ToString(), " </td> </tr> <tr> ");
                    Body = string.Concat(Body, " <td style = 'font-family: Arial; font-size: small' > Su accionamiento sólo es posible de manera intencionada.</td> ");
                    Body = string.Concat(Body, " <td style = 'font-family: Arial; font-size: small' >", lTbl.Rows[11]["Cumple"].ToString(), " </td>  <td style = 'font-family: Arial; font-size: small' > ", lTbl.Rows[11]["Obs"].ToString(), " </td> ");
                    Body = string.Concat(Body, "  <td style = 'font-family: Arial; font-size: small' > ", lTbl.Rows[11]["Recomendacion"].ToString(), " </td>   </tr>   <tr> ");
                    Body = string.Concat(Body, " <td style = 'font-family: Arial; font-size: small' > Las paradas de emergencia tienen enclavamiento(quedan bloqueadas).</td>  ");
                    Body = string.Concat(Body, "  <td style = 'font-family: Arial; font-size: small' > ", lTbl.Rows[12]["Cumple"].ToString(), "   </td> ");
                    Body = string.Concat(Body, " <td style = 'font-family: Arial; font-size: small' >", lTbl.Rows[12]["Obs"].ToString(), " </td>");
                    Body = string.Concat(Body, " <td style = 'font-family: Arial; font-size: small' > ", lTbl.Rows[12]["Recomendacion"].ToString(), " </td>  </tr>  <tr> ");
               Body = string.Concat(Body, " <td style = 'font-family: Arial; font-size: small' > Desde el punto de mando el operador ve todas las zonas de peligro de la máquinas, equipo o herramienta motriz o en su defecto existe una señal acústica o visible de puesta en marcha.</td> ");
                    Body = string.Concat(Body, " <td style = 'font-family: Arial; font-size: small' >  ", lTbl.Rows[13]["Cumple"].ToString(), "  </td> <td style = 'font-family: Arial; font-size: small' >", lTbl.Rows[13]["Obs"].ToString(), "  </td>  ");
                    Body = string.Concat(Body, " <td style = 'font-family: Arial; font-size: small' > ", lTbl.Rows[13]["Recomendacion"].ToString(), " </td>  </tr>         <tr> ");
                    Body = string.Concat(Body, " <td style = 'font-family: Arial; font-size: small' > Existen uno o mas dispositivos de parada de emergencia y se encuentran cerca de los puntos de peligro.</td>");
                    Body = string.Concat(Body, " <td style = 'font-family: Arial; font-size: small' > ", lTbl.Rows[14]["Cumple"].ToString(), "</td>                 <td style = 'font-family: Arial; font-size: small' >", lTbl.Rows[14]["Obs"].ToString(), "</td> ");
                Body = string.Concat(Body, " <td style = 'font-family: Arial; font-size: small' >", lTbl.Rows[14]["Recomendacion"].ToString(), "</td>             </tr>           <tr>");

                    Body = string.Concat(Body, "  <td style = 'font-family: Arial; font-size: small' > Los cables y conexiones eléctricas no tienen partes expuestas y están bien canalizados.</td> ");
                    Body = string.Concat(Body, " <td style = 'font-family: Arial; font-size: small' > ", lTbl.Rows[15]["Cumple"].ToString(), " </td>     <td style = 'font-family: Arial; font-size: small' > ", lTbl.Rows[15]["Obs"].ToString(), " </td>  ");
                    Body = string.Concat(Body, " <td style = 'font-family: Arial; font-size: small' > ", lTbl.Rows[15]["Recomendacion"].ToString(), " </td>    </tr>     <tr> ");
                    Body = string.Concat(Body, " <td style = 'font-family: Arial; font-size: small' > Se tiene establecido el procedimiento para el bloqueo de energías peligrosas</td> ");
                    Body = string.Concat(Body, "  <td style = 'font-family: Arial; font-size: small' >", lTbl.Rows[16]["Cumple"].ToString(), "</td> <td style = 'font-family: Arial; font-size: small' > ", lTbl.Rows[16]["Obs"].ToString(), " </td>  ");
                    Body = string.Concat(Body, " <td style = 'font-family: Arial; font-size: small' > ", lTbl.Rows[16]["Recomendacion"].ToString(), " </td>  </tr>   <tr> ");
                    Body = string.Concat(Body, " <td style = 'font-family: Arial; font-size: small' rowspan='5' >   Comportamiento seguro  </td>  ");
                    Body = string.Concat(Body, " <td style = 'font-family: Arial; font-size: small' > El operador está instrudo en el Procedimiento de Trabajo seguro de la máquina, equipo o herramienta motriz</td> ");
                    Body = string.Concat(Body, " <td style = 'font-family: Arial; font-size: small' > ", lTbl.Rows[17]["Cumple"].ToString(), " </td> <td style = 'font-family: Arial; font-size: small' > ", lTbl.Rows[17]["Obs"].ToString(), "</td> ");
                    Body = string.Concat(Body, " <td style = 'font-family: Arial; font-size: small' > ", lTbl.Rows[17]["Recomendacion"].ToString(), " </td>    </tr>         <tr>  ");
                    Body = string.Concat(Body, " <td style = 'font-family: Arial; font-size: small' > El operador usa los elementos de protección personal requeridos.</td> ");
                    Body = string.Concat(Body, " <td style = 'font-family: Arial; font-size: small' > ", lTbl.Rows[18]["Cumple"].ToString(), "</td> <td style = 'font-family: Arial; font-size: small' >", lTbl.Rows[18]["Obs"].ToString(), " </td>  ");
                    Body = string.Concat(Body, " <td style = 'font-family: Arial; font-size: small' > ", lTbl.Rows[18]["Recomendacion"].ToString(), "</td>      </tr>    <tr>  ");
                    Body = string.Concat(Body, " <td style = 'font-family: Arial; font-size: small' > El operador no porta cadenas, anillos, ropa suelta u otro tipo de accesorios que le signifiquen peligro.</td> ");
                    Body = string.Concat(Body, " <td style = 'font-family: Arial; font-size: small' >", lTbl.Rows[19]["Cumple"].ToString(), " </td> <td style = 'font-family: Arial; font-size: small' > ", lTbl.Rows[19]["Obs"].ToString(), " </td>  ");
                    Body = string.Concat(Body, " <td style = 'font-family: Arial; font-size: small' >", lTbl.Rows[19]["Recomendacion"].ToString(), " </td>   </tr>    <tr>  ");
                    Body = string.Concat(Body, " <td style = 'font-family: Arial; font-size: small' > El operador usa en forma segura las herramientas manuales y de operación de la máquina, equipo o herramienta motriz</td> ");
                    Body = string.Concat(Body, " <td style = 'font-family: Arial; font-size: small' > ", lTbl.Rows[20]["Cumple"].ToString(), "</td>   <td style = 'font-family: Arial; font-size: small' > ", lTbl.Rows[20]["Obs"].ToString(), " </td>  ");
                    Body = string.Concat(Body, " <td style = 'font-family: Arial; font-size: small' >", lTbl.Rows[20]["Recomendacion"].ToString(), " </td>      </tr>    <tr>  ");
                    Body = string.Concat(Body, " <td style = 'font-family: Arial; font-size: small' > El operador no se distrae usando celular, no realizando juegos o bromas.</td> ");
                    Body = string.Concat(Body, " <td style = 'font-family: Arial; font-size: small' >", lTbl.Rows[21]["Cumple"].ToString(), " </td>           <td style = 'font-family: Arial; font-size: small' >", lTbl.Rows[21]["Obs"].ToString(), " </td>");
                    Body = string.Concat(Body, " <td style = 'font-family: Arial; font-size: small' >", lTbl.Rows[21]["Recomendacion"].ToString(), " </td>        </tr>        <tr>  ");
                    Body = string.Concat(Body, " <td style = 'font-family: Arial; font-size: small' rowspan='5' > Entorno      </td>");
                    Body = string.Concat(Body, "  <td style = 'font-family: Arial; font-size: small' > El área de desplazamiento de los operarios esta libre de obstáculos que impidan su caminar y operación</td> ");
                    Body = string.Concat(Body, " <td style = 'font-family: Arial; font-size: small' > ", lTbl.Rows[22]["Cumple"].ToString(), " </td>   <td style = 'font-family: Arial; font-size: small' > ", lTbl.Rows[22]["Obs"].ToString(), "</td> ");
                    Body = string.Concat(Body, " <td style = 'font-family: Arial; font-size: small' >", lTbl.Rows[22]["Recomendacion"].ToString(), "  </td>    </tr>     <tr> ");

                    Body = string.Concat(Body, " <td style = 'font-family: Arial; font-size: small' class='auto-style5'>Las luminarias se encuentran en condiciones adecuadas para su funcionamiento. </td> ");
                    Body = string.Concat(Body, "  <td style = 'font-family: Arial; font-size: small' class='auto-style5'>  ", lTbl.Rows[23]["Cumple"].ToString(), "  </td>  <td style = 'font-family: Arial; font-size: small' class='auto-style5'>  ", lTbl.Rows[23]["Obs"].ToString(), "</td> ");
                    Body = string.Concat(Body, " <td style = 'font-family: Arial; font-size: small' class='auto-style5'  > ", lTbl.Rows[23]["Recomendacion"].ToString(), "  </td>    </tr>    <tr> ");
                    Body = string.Concat(Body, " <td style = 'font-family: Arial; font-size: small' > Los pisos se encuentran libres de grietas, desniveles, grasa, aceite o agua alrededor de la máquina.</td> ");
                    Body = string.Concat(Body, " <td style = 'font-family: Arial; font-size: small' >", lTbl.Rows[24]["Cumple"].ToString(), "</td> <td style = 'font-family: Arial; font-size: small' > ", lTbl.Rows[24]["Obs"].ToString(), "</td>   ");
                    Body = string.Concat(Body, " <td style = 'font-family: Arial; font-size: small' > ", lTbl.Rows[24]["Recomendacion"].ToString(), "</td>  </tr>     <tr> ");
                    Body = string.Concat(Body, " <td style = 'font-family: Arial; font-size: small' > Las escaleras cuentan con pasamanos, peldaños con superficie antideslizante, libres de fisuras y grasas.</td> ");
                    Body = string.Concat(Body, "  <td style = 'font-family: Arial; font-size: small' >", lTbl.Rows[25]["Cumple"].ToString(), " </td>         <td style = 'font-family: Arial; font-size: small' > ", lTbl.Rows[25]["Obs"].ToString(), "</td>  ");
                    Body = string.Concat(Body, " <td style = 'font-family: Arial; font-size: small' > ", lTbl.Rows[25]["Recomendacion"].ToString(), " </td>    </tr>     <tr> ");
                    Body = string.Concat(Body, " <td style = 'font-family: Arial; font-size: small' > Existen bordes cortantes, superficies salientes u otras condiciones irregulares.</td> ");
                    Body = string.Concat(Body, " <td style = 'font-family: Arial; font-size: small' >", lTbl.Rows[26]["Cumple"].ToString(), " </td>    <td style = 'font-family: Arial; font-size: small' > ", lTbl.Rows[26]["Obs"].ToString(), " </td>  ");
                    Body = string.Concat(Body, "  <td style = 'font-family: Arial; font-size: small' >", lTbl.Rows[26]["Recomendacion"].ToString(), " </td>    </tr>      ");
                    //Body = string.Concat(Body, " <td style = 'font-family: Arial; font-size: small' > ", lTbl.Rows[27]["Cumple"].ToString(), "</td>  <td style = 'font-family: Arial; font-size: small' >", lTbl.Rows[27]["Obs"].ToString(), "</td> ");
                    //   Body = string.Concat(Body, " <td style = 'font-family: Arial; font-size: small' > ", lTbl.Rows[27]["Recomendacion"].ToString(), " </td>          <td style = 'font-family: Arial; font-size: small' > &nbsp;</td> ");
                    //   Body = string.Concat(Body, " <td style = 'font-family: Arial; font-size: small' > &nbsp;</td>     </tr>   ");

                    Body = string.Concat(Body, " </table>  ");


                    ////---------------------------------------------------------
                    //for (i = 0; i < lTbl.Rows.Count; i++)
                    //{
                    //    lRes = String.Concat(lRes, " ", lTbl.Rows[i]["RevisionMaq"].ToString(), ": ", lTbl.Rows[i]["RespuestaRevision"].ToString(), "  <br> ");
                    //}


                   Body = String.Concat(Body, "  <br> ", "  <br> ");

                    Body = String.Concat(Body, "Este mail ha sido enviado de forma automática por el sistema", "  <br> ");
                }
            }
            catch (Exception iEx)
            {

            }
            return Body;
        }

        private DataRow ObtenerFilaParaGrabar(DataRow iFila, string iTipo)
        {
            //lFila["Familia"] = "";
            //lFila["RevisionMaq"] = "";
            //lFila["Cumple"] = "";
            //lFila["Obs"] = "";
            //lFila["Recomendacion"] = "";

            switch (iTipo)
            {
                case "1_1":
                    iFila["Familia"] = "Sistema de transmisión y partes móviles";
                    iFila["RevisionMaq"] = "Los sistemas de transmisión y partes móviles se encuentran completamente protegidos.";
                    if (Rb_SI_1_1.Checked == true)
                        iFila["Cumple"] = "SI";
                    if (Rb_NO_1_1.Checked == true)
                        iFila["Cumple"] = "NO";
                    if (Rb_NA_1_1.Checked == true)
                        iFila["Cumple"] = "NA";

                    iFila["Obs"] = Tx_Obs_1_1.Text;
                    iFila["Recomendacion"] = Tx_Rec_1_1.Text;
                    break;
                case "2_1":
                    iFila["Familia"] = "Sistema de transmisión y partes móviles";
                    iFila["RevisionMaq"] = "Las defensas fijas están sólidamente aseguradas.";
                    if (Rb_SI_2_1.Checked == true)
                        iFila["Cumple"] = "SI";
                    if (Rb_NO_2_1.Checked == true)
                        iFila["Cumple"] = "NO";
                    if (Rb_NA_2_1.Checked == true)
                        iFila["Cumple"] = "NA";

                    iFila["Obs"] = Tx_Obs_2_1.Text;
                    iFila["Recomendacion"] = Tx_Rec_2_1.Text;
                    break;
                case "3_1":
                    iFila["Familia"] = "Sistema de transmisión y partes móviles";
                    iFila["RevisionMaq"] = "    Están señalizados los puntos de peligro.";
                    if (Rb_SI_3_1.Checked == true)
                        iFila["Cumple"] = "SI";
                    if (Rb_NO_3_1.Checked == true)
                        iFila["Cumple"] = "NO";
                    if (Rb_NA_3_1.Checked == true)
                        iFila["Cumple"] = "NA";

                    iFila["Obs"] = Tx_Obs_3_1.Text;
                    iFila["Recomendacion"] = Tx_Rec_3_1.Text;
                    break;
                case "1_2":
                    iFila["Familia"] = "Punto de operación ";
                    iFila["RevisionMaq"] = "  Las partes móviles de la máquina, equipo o herramienta motriz  son completamente inaccesibles.";
                    if (Rb_SI_1_2.Checked == true)
                        iFila["Cumple"] = "SI";
                    if (Rb_NO_1_2.Checked == true)
                        iFila["Cumple"] = "NO";
                    if (Rb_NA_1_2.Checked == true)
                        iFila["Cumple"] = "NA";

                    iFila["Obs"] = Tx_Obs_1_2.Text;
                    iFila["Recomendacion"] = Tx_Rec_1_2.Text;
                    break;
                case "2_2":
                    iFila["Familia"] = "Punto de operación ";
                    iFila["RevisionMaq"] = "  Existen los dispositivos de seguridad en los puntos de operación.";
                    if (Rb_SI_2_2.Checked == true)
                        iFila["Cumple"] = "SI";
                    if (Rb_NO_2_2.Checked == true)
                        iFila["Cumple"] = "NO";
                    if (Rb_NA_2_2.Checked == true)
                        iFila["Cumple"] = "NA";

                    iFila["Obs"] = Tx_Obs_2_2.Text;
                    iFila["Recomendacion"] = Tx_Rec_2_2.Text;
                    break;
                case "3_2":
                    iFila["Familia"] = "Punto de operación ";
                    iFila["RevisionMaq"] = " Existen dispositivos de bloqueo.";
                    if (Rb_SI_3_2.Checked == true)
                        iFila["Cumple"] = "SI";
                    if (Rb_NO_3_2.Checked == true)
                        iFila["Cumple"] = "NO";
                    if (Rb_NA_3_2.Checked == true)
                        iFila["Cumple"] = "NA";

                    iFila["Obs"] = Tx_Obs_3_2.Text;
                    iFila["Recomendacion"] = Tx_Rec_3_2.Text;
                    break;
                case "4_2":
                    iFila["Familia"] = "Punto de operación ";
                    iFila["RevisionMaq"] = "Están bien señalizados los puntos de peligro y partes en movimiento de la máquinas, equipo o herramienta motriz.";
                    if (Rb_SI_4_2.Checked == true)
                        iFila["Cumple"] = "SI";
                    if (Rb_NO_4_2.Checked == true)
                        iFila["Cumple"] = "NO";
                    if (Rb_NA_4_2.Checked == true)
                        iFila["Cumple"] = "NA";

                    iFila["Obs"] = Tx_Obs_4_2.Text;
                    iFila["Recomendacion"] = Tx_Rec_4_2.Text;
                    break;
                case "5_2":
                    iFila["Familia"] = "Punto de operación ";
                    iFila["RevisionMaq"] = " Se utilizan herramientas o dispositivos para alimentar la máquinas, equipo o herramienta motriz.";
                    if (Rb_SI_5_2.Checked == true)
                        iFila["Cumple"] = "SI";
                    if (Rb_NO_5_2.Checked == true)
                        iFila["Cumple"] = "NO";
                    if (Rb_NA_5_2.Checked == true)
                        iFila["Cumple"] = "NA";

                    iFila["Obs"] = Tx_Obs_5_2.Text;
                    iFila["Recomendacion"] = Tx_Rec_5_2.Text;
                    break;
                case "6_2":
                    iFila["Familia"] = "Punto de operación ";
                    iFila["RevisionMaq"] = " La operación de carga y descarga de materia prima y residuos no representa peligro para los operarios.";
                    if (Rb_SI_6_2.Checked == true)
                        iFila["Cumple"] = "SI";
                    if (Rb_NO_6_2.Checked == true)
                        iFila["Cumple"] = "NO";
                    if (Rb_NA_6_2.Checked == true)
                        iFila["Cumple"] = "NA";

                    iFila["Obs"] = Tx_Obs_6_2.Text;
                    iFila["Recomendacion"] = Tx_Rec_6_2.Text;
                    break;
                case "7_2":
                    iFila["Familia"] = "Punto de operación ";
                    iFila["RevisionMaq"] = " El puesto de trabajo se encuentra libre de materiales o elementos que dificulten el desarrollo de la operación.";
                    if (Rb_SI_7_2.Checked == true)
                        iFila["Cumple"] = "SI";
                    if (Rb_NO_7_2.Checked == true)
                        iFila["Cumple"] = "NO";
                    if (Rb_NA_7_2.Checked == true)
                        iFila["Cumple"] = "NA";

                    iFila["Obs"] = Tx_Obs_7_2.Text;
                    iFila["Recomendacion"] = Tx_Rec_7_2.Text;
                    break;
                case "1_3":
                    iFila["Familia"] = "Dispositivos de Control ";
                    iFila["RevisionMaq"] = " Los dispositivos de control son visibles, están claramente identificados,  de fácil alcance por el operario  y ubicados fuera de las zonas peligrosas.";
                    if (Rb_SI_1_3.Checked == true)
                        iFila["Cumple"] = "SI";
                    if (Rb_NO_1_3.Checked == true)
                        iFila["Cumple"] = "NO";
                    if (Rb_NA_1_3.Checked == true)
                        iFila["Cumple"] = "NA";

                    iFila["Obs"] = Tx_Obs_1_3.Text;
                    iFila["Recomendacion"] = Tx_Rec_1_3.Text;
                    break;
                case "2_3":
                    iFila["Familia"] = "Dispositivos de Control ";
                    iFila["RevisionMaq"] = " Su accionamiento sólo es posible de manera intencionada. ";
                    if (Rb_SI_2_3.Checked == true)
                        iFila["Cumple"] = "SI";
                    if (Rb_NO_2_3.Checked == true)
                        iFila["Cumple"] = "NO";
                    if (Rb_NA_2_3.Checked == true)
                        iFila["Cumple"] = "NA";

                    iFila["Obs"] = Tx_Obs_2_3.Text;
                    iFila["Recomendacion"] = Tx_Rec_2_3.Text;
                    break;
                case "3_3":
                    iFila["Familia"] = "Dispositivos de Control ";
                    iFila["RevisionMaq"] = " Las paradas de emergencia tienen enclavamiento (quedan bloqueadas). ";
                    if (Rb_SI_3_3.Checked == true)
                        iFila["Cumple"] = "SI";
                    if (Rb_NO_3_3.Checked == true)
                        iFila["Cumple"] = "NO";
                    if (Rb_NA_3_3.Checked == true)
                        iFila["Cumple"] = "NA";

                    iFila["Obs"] = Tx_Obs_3_3.Text;
                    iFila["Recomendacion"] = Tx_Rec_3_3.Text;
                    break;
                case "4_3":
                    iFila["Familia"] = "Dispositivos de Control ";
                    iFila["RevisionMaq"] = " Desde el punto de mando el operador ve todas las zonas de peligro de la máquinas, equipo o herramienta motriz  o en su defecto existe una señal acústica o visible de puesta en marcha. ";
                    if (Rb_SI_4_3.Checked == true)
                        iFila["Cumple"] = "SI";
                    if (Rb_NO_4_3.Checked == true)
                        iFila["Cumple"] = "NO";
                    if (Rb_NA_4_3.Checked == true)
                        iFila["Cumple"] = "NA";

                    iFila["Obs"] = Tx_Obs_4_3.Text;
                    iFila["Recomendacion"] = Tx_Rec_4_3.Text;
                    break;
                case "5_3":
                    iFila["Familia"] = "Dispositivos de Control ";
                    iFila["RevisionMaq"] = " Existen uno o mas dispositivos de parada de emergencia y se encuentran cerca de los puntos de peligro. ";
                    if (Rb_SI_5_3.Checked == true)
                        iFila["Cumple"] = "SI";
                    if (Rb_NO_5_3.Checked == true)
                        iFila["Cumple"] = "NO";
                    if (Rb_NA_5_3.Checked == true)
                        iFila["Cumple"] = "NA";

                    iFila["Obs"] = Tx_Obs_5_3.Text;
                    iFila["Recomendacion"] = Tx_Rec_5_3.Text;
                    break;
                case "6_3":
                    iFila["Familia"] = "Dispositivos de Control ";
                    iFila["RevisionMaq"] = " Los cables y conexiones eléctricas no tienen partes expuestas y están bien canalizados. ";
                    if (Rb_SI_6_3.Checked == true)
                        iFila["Cumple"] = "SI";
                    if (Rb_NO_6_3.Checked == true)
                        iFila["Cumple"] = "NO";
                    if (Rb_NA_6_3.Checked == true)
                        iFila["Cumple"] = "NA";

                    iFila["Obs"] = Tx_Obs_6_3.Text;
                    iFila["Recomendacion"] = Tx_Rec_6_3.Text;
                    break;
                case "7_3":
                    iFila["Familia"] = "Dispositivos de Control ";
                    iFila["RevisionMaq"] = " Se tiene establecido el procedimiento para el bloqueo de energías  peligrosas. ";
                    if (Rb_SI_7_3.Checked == true)
                        iFila["Cumple"] = "SI";
                    if (Rb_NO_7_3.Checked == true)
                        iFila["Cumple"] = "NO";
                    if (Rb_NA_7_3.Checked == true)
                        iFila["Cumple"] = "NA";

                    iFila["Obs"] = Tx_Obs_7_3.Text;
                    iFila["Recomendacion"] = Tx_Rec_7_3.Text;
                    break;
                case "1_4":
                    iFila["Familia"] = "Comportamiento seguro ";
                    iFila["RevisionMaq"] = " El operador está instrudo en el Procedimiento de Trabajo seguro de la máquina, equipo o herramienta motriz. ";
                    if (Rb_SI_1_4.Checked == true)
                        iFila["Cumple"] = "SI";
                    if (Rb_NO_1_4.Checked == true)
                        iFila["Cumple"] = "NO";
                    if (Rb_NA_1_4.Checked == true)
                        iFila["Cumple"] = "NA";

                    iFila["Obs"] = Tx_Obs_1_4.Text;
                    iFila["Recomendacion"] = Tx_Rec_1_4.Text;
                    break;
                case "2_4":
                    iFila["Familia"] = "Comportamiento seguro ";
                    iFila["RevisionMaq"] = " El operador usa los elementos de protección personal requeridos. ";
                    if (Rb_SI_2_4.Checked == true)
                        iFila["Cumple"] = "SI";
                    if (Rb_NO_2_4.Checked == true)
                        iFila["Cumple"] = "NO";
                    if (Rb_NA_2_4.Checked == true)
                        iFila["Cumple"] = "NA";

                    iFila["Obs"] = Tx_Obs_2_4.Text;
                    iFila["Recomendacion"] = Tx_Rec_2_4.Text;
                    break;
                case "3_4":
                    iFila["Familia"] = "Comportamiento seguro ";
                    iFila["RevisionMaq"] = " El operador no porta cadenas, anillos, ropa suelta u otro tipo de accesorios que le signifiquen peligro. ";
                    if (Rb_SI_3_4.Checked == true)
                        iFila["Cumple"] = "SI";
                    if (Rb_NO_3_4.Checked == true)
                        iFila["Cumple"] = "NO";
                    if (Rb_NA_3_4.Checked == true)
                        iFila["Cumple"] = "NA";

                    iFila["Obs"] = Tx_Obs_3_4.Text;
                    iFila["Recomendacion"] = Tx_Rec_3_4.Text;
                    break;
                case "4_4":
                    iFila["Familia"] = "Comportamiento seguro ";
                    iFila["RevisionMaq"] = " operador usa en forma segura las herramientas manuales y de operación de la máquina, equipo o herramienta motriz. ";
                    if (Rb_SI_4_4.Checked == true)
                        iFila["Cumple"] = "SI";
                    if (Rb_NO_4_4.Checked == true)
                        iFila["Cumple"] = "NO";
                    if (Rb_NA_4_4.Checked == true)
                        iFila["Cumple"] = "NA";

                    iFila["Obs"] = Tx_Obs_4_4.Text;
                    iFila["Recomendacion"] = Tx_Rec_4_4.Text;
                    break;
                case "5_4":
                    iFila["Familia"] = "Comportamiento seguro ";
                    iFila["RevisionMaq"] = " El operador no se distrae usando  celular, no realizando juegos o bromas. ";
                    if (Rb_SI_5_4.Checked == true)
                        iFila["Cumple"] = "SI";
                    if (Rb_NO_5_4.Checked == true)
                        iFila["Cumple"] = "NO";
                    if (Rb_NA_5_4.Checked == true)
                        iFila["Cumple"] = "NA";

                    iFila["Obs"] = Tx_Obs_5_4.Text;
                    iFila["Recomendacion"] = Tx_Rec_5_4.Text;
                    break;
                case "1_5":
                    iFila["Familia"] = " Entorno";
                    iFila["RevisionMaq"] = " El área de desplazamiento de los operarios esta libre de obstáculos que impidan su caminar y operación. ";
                    if (Rb_SI_1_5.Checked == true)
                        iFila["Cumple"] = "SI";
                    if (Rb_NO_1_5.Checked == true)
                        iFila["Cumple"] = "NO";
                    if (Rb_NA_1_5.Checked == true)
                        iFila["Cumple"] = "NA";

                    iFila["Obs"] = Tx_Obs_1_5.Text;
                    iFila["Recomendacion"] = Tx_Rec_1_5.Text;
                    break;
                case "2_5":
                    iFila["Familia"] = " Entorno";
                    iFila["RevisionMaq"] = " Las luminarias se encuentran en condiciones adecuadas para su funcionamiento.  ";
                    if (Rb_SI_2_5.Checked == true)
                        iFila["Cumple"] = "SI";
                    if (Rb_NO_2_5.Checked == true)
                        iFila["Cumple"] = "NO";
                    if (Rb_NA_2_5.Checked == true)
                        iFila["Cumple"] = "NA";

                    iFila["Obs"] = Tx_Obs_2_5.Text;
                    iFila["Recomendacion"] = Tx_Rec_2_5.Text;
                    break;

                case "3_5":
                    iFila["Familia"] = " Entorno";
                    iFila["RevisionMaq"] = " Los pisos se encuentran libres de grietas, desniveles, grasa, aceite o agua alrededor de la máquina. ";
                    if (Rb_SI_3_5.Checked == true)
                        iFila["Cumple"] = "SI";
                    if (Rb_NO_3_5.Checked == true)
                        iFila["Cumple"] = "NO";
                    if (Rb_NA_3_5.Checked == true)
                        iFila["Cumple"] = "NA";

                    iFila["Obs"] = Tx_Obs_3_5.Text;
                    iFila["Recomendacion"] = Tx_Rec_3_5.Text;
                    break;
                case "4_5":
                    iFila["Familia"] = " Entorno";
                    iFila["RevisionMaq"] = " Las escaleras cuentan con pasamanos, peldaños  con superficie antideslizante,  libres de fisuras y grasas. ";
                    if (Rb_SI_4_5.Checked == true)
                        iFila["Cumple"] = "SI";
                    if (Rb_NO_4_5.Checked == true)
                        iFila["Cumple"] = "NO";
                    if (Rb_NA_4_5.Checked == true)
                        iFila["Cumple"] = "NA";

                    iFila["Obs"] = Tx_Obs_4_5.Text;
                    iFila["Recomendacion"] = Tx_Rec_4_5.Text;
                    break;
                case "5_5":
                    iFila["Familia"] = " Entorno";
                    iFila["RevisionMaq"] = " Existen bordes cortantes, superficies salientes u otras condiciones irregulares. ";
                    if (Rb_SI_5_5.Checked == true)
                        iFila["Cumple"] = "SI";
                    if (Rb_NO_5_5.Checked == true)
                        iFila["Cumple"] = "NO";
                    if (Rb_NA_5_5.Checked == true)
                        iFila["Cumple"] = "NA";

                    iFila["Obs"] = Tx_Obs_5_5.Text;
                    iFila["Recomendacion"] = Tx_Rec_5_5.Text;
                    break;
            }

            return iFila;
        }

        private void GrabarProceme()
        {
            //******************************************
            //PCM_Id                PCM_NroMaquina          PCM_IdUsuario        PCM_supervisor    PCM_Familia             
            //PCM_RevisionMaq        PCM_Cumple                  PCM_Obs            PCM_Rec
            //***************************************
            DataTable lTblRes = new DataTable(); DataRow lFila = null;
            lTblRes.Columns.Add("Id", Type.GetType("System.String"));
            lTblRes.Columns.Add("NroMaq", Type.GetType("System.String"));
            lTblRes.Columns.Add("IdUsuario", Type.GetType("System.String"));
            lTblRes.Columns.Add("Supervisor", Type.GetType("System.String"));
            lTblRes.Columns.Add("Familia", Type.GetType("System.String"));
            lTblRes.Columns.Add("RevisionMaq", Type.GetType("System.String"));
            lTblRes.Columns.Add("Cumple", Type.GetType("System.String"));
            lTblRes.Columns.Add("Obs", Type.GetType("System.String"));
            lTblRes.Columns.Add("Recomendacion", Type.GetType("System.String"));

            lFila = lTblRes.NewRow();                    lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser;        lFila["SuperVisor"] = Cmb_Supervisor.SelectedValue;
            lFila = ObtenerFilaParaGrabar(lFila,"1_1");  lTblRes.Rows.Add(lFila);

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["SuperVisor"] = Cmb_Supervisor.SelectedValue;
            lFila = ObtenerFilaParaGrabar(lFila, "2_1"); lTblRes.Rows.Add(lFila);

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["SuperVisor"] = Cmb_Supervisor.SelectedValue;
            lFila = ObtenerFilaParaGrabar(lFila, "3_1"); lTblRes.Rows.Add(lFila);

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["SuperVisor"] = Cmb_Supervisor.SelectedValue;
            lFila = ObtenerFilaParaGrabar(lFila, "1_2"); lTblRes.Rows.Add(lFila);

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["SuperVisor"] = Cmb_Supervisor.SelectedValue;
            lFila = ObtenerFilaParaGrabar(lFila, "2_2"); lTblRes.Rows.Add(lFila);

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["SuperVisor"] = Cmb_Supervisor.SelectedValue;
            lFila = ObtenerFilaParaGrabar(lFila, "3_2"); lTblRes.Rows.Add(lFila);

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["SuperVisor"] = Cmb_Supervisor.SelectedValue;
            lFila = ObtenerFilaParaGrabar(lFila, "4_2"); lTblRes.Rows.Add(lFila);

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["SuperVisor"] = Cmb_Supervisor.SelectedValue;
            lFila = ObtenerFilaParaGrabar(lFila, "5_2"); lTblRes.Rows.Add(lFila);

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["SuperVisor"] = Cmb_Supervisor.SelectedValue;
            lFila = ObtenerFilaParaGrabar(lFila, "6_2"); lTblRes.Rows.Add(lFila);

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["SuperVisor"] = Cmb_Supervisor.SelectedValue;
            lFila = ObtenerFilaParaGrabar(lFila, "7_2"); lTblRes.Rows.Add(lFila);

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["SuperVisor"] = Cmb_Supervisor.SelectedValue;
            lFila = ObtenerFilaParaGrabar(lFila, "1_3"); lTblRes.Rows.Add(lFila);

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["SuperVisor"] = Cmb_Supervisor.SelectedValue;
            lFila = ObtenerFilaParaGrabar(lFila, "2_3"); lTblRes.Rows.Add(lFila);

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["SuperVisor"] = Cmb_Supervisor.SelectedValue;
            lFila = ObtenerFilaParaGrabar(lFila, "3_3"); lTblRes.Rows.Add(lFila);

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["SuperVisor"] = Cmb_Supervisor.SelectedValue;
            lFila = ObtenerFilaParaGrabar(lFila, "4_3"); lTblRes.Rows.Add(lFila);

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["SuperVisor"] = Cmb_Supervisor.SelectedValue;
            lFila = ObtenerFilaParaGrabar(lFila, "5_3"); lTblRes.Rows.Add(lFila);

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["SuperVisor"] = Cmb_Supervisor.SelectedValue;
            lFila = ObtenerFilaParaGrabar(lFila, "6_3"); lTblRes.Rows.Add(lFila);

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["SuperVisor"] = Cmb_Supervisor.SelectedValue;
            lFila = ObtenerFilaParaGrabar(lFila, "7_3"); lTblRes.Rows.Add(lFila);

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["SuperVisor"] = Cmb_Supervisor.SelectedValue;
            lFila = ObtenerFilaParaGrabar(lFila, "1_4"); lTblRes.Rows.Add(lFila);

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["SuperVisor"] = Cmb_Supervisor.SelectedValue;
            lFila = ObtenerFilaParaGrabar(lFila, "2_4"); lTblRes.Rows.Add(lFila);

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["SuperVisor"] = Cmb_Supervisor.SelectedValue;
            lFila = ObtenerFilaParaGrabar(lFila, "3_4"); lTblRes.Rows.Add(lFila);

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["SuperVisor"] = Cmb_Supervisor.SelectedValue;
            lFila = ObtenerFilaParaGrabar(lFila, "4_4"); lTblRes.Rows.Add(lFila);

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["SuperVisor"] = Cmb_Supervisor.SelectedValue;
            lFila = ObtenerFilaParaGrabar(lFila, "5_4"); lTblRes.Rows.Add(lFila);

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["SuperVisor"] = Cmb_Supervisor.SelectedValue;
            lFila = ObtenerFilaParaGrabar(lFila, "1_5"); lTblRes.Rows.Add(lFila);

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["SuperVisor"] = Cmb_Supervisor.SelectedValue;
            lFila = ObtenerFilaParaGrabar(lFila, "2_5"); lTblRes.Rows.Add(lFila);

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["SuperVisor"] = Cmb_Supervisor.SelectedValue;
            lFila = ObtenerFilaParaGrabar(lFila, "3_5"); lTblRes.Rows.Add(lFila);

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["SuperVisor"] = Cmb_Supervisor.SelectedValue;
            lFila = ObtenerFilaParaGrabar(lFila, "4_5"); lTblRes.Rows.Add(lFila);

            lFila = lTblRes.NewRow(); lFila["NroMaq"] = mUserLog.IdMaquina;
            lFila["IdUsuario"] = mUserLog.Iduser; lFila["SuperVisor"] = Cmb_Supervisor.SelectedValue;
            lFila = ObtenerFilaParaGrabar(lFila, "5_5"); lTblRes.Rows.Add(lFila);



            //Se envia la Tabla al Servicio Web para la persistencia de datos.
            PersisteDatos_Proceme(lTblRes, mUserLog.DescripcionMaq , mUserLog.Login );

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
            CerrarFormulario();
                 }

        private void CerrarFormulario()
        {
            if (Btn_grabar.Enabled == false)
                this.Close();
            else
            {
                MessageBox.Show("No ha grabado los Datos, debe realizar el CheckList. ", "Avisos sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //this.Close();
            }
               
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void CheckList_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Mostrar un mensaje de porqué se está cerrando
           // MessageBox.Show(e.CloseReason.ToString());
            // Estos son los valores posibles
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
                    if (Btn_grabar.Enabled == true)
                    {
                        MessageBox.Show("No ha grabado los Datos, debe realizar el CheckList. ", "Avisos sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        e.Cancel = true;
                    }
                    break;
                case CloseReason.WindowsShutDown:
                    break;
            }
        }
    }

}



