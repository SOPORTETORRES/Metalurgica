using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace Metalurgica.Maquinas
{
    public partial class NotificaAveria : Form
    {
        private CurrentUser mUserLog = new CurrentUser();
        private string mIdMaquina = "";
        private string mTipoNotificacion = "";
        private string mIdMecanico = "";
        private string mIdSucursal = "";
        private string mTipoAveria = "";
        private string mIdAveria = "";
        private Clases.Obj.Obj_ElementoProd mObjEP = new Clases.Obj.Obj_ElementoProd();


        public NotificaAveria()
        {
            InitializeComponent();
        }


        private bool MaquinaConAveria()
        {
            bool lRes = false;
            Ws_TO.Ws_ToSoapClient ldal = new Ws_TO.Ws_ToSoapClient();
            WsOperacion.ListaDataSet listaDataSet = new WsOperacion.ListaDataSet();
            string lSql = "";  DataTable lTbl = new DataTable();

            lSql = string.Concat("exec  SP_CRUD_NOTIFICACION_AVERIA 0,0,'','','',0,'',", mIdMaquina, ",'',3 ");
                listaDataSet.DataSet = ldal.ObtenerDatos(lSql);
                if ((listaDataSet.DataSet.Tables.Count > 0) && (listaDataSet.DataSet.Tables[0].Rows.Count > 0))
                {
                    lTbl = listaDataSet.DataSet.Tables[0].Copy();
                    if (lTbl.Rows[0]["estado"].ToString().ToUpper().Equals("OP"))
                        lRes = false;
                    else
                    {
                        //if (lTbl.Rows[0]["EstadoMaq"].ToString().ToUpper().Equals("CAMBIO DE ROLLO"))
                        if ((lTbl.Rows[0]["TextoIncidencia"].ToString().ToUpper().Equals("CAMBIO DE ROLLO")) && (lTbl.Rows[0]["EstadoMaq"].ToString().ToUpper().Equals("OP")))
                        {
                            lRes = false;
                        }
                        else
                        {
                            lRes = true;
                        }
                    }
                }
            return lRes;
        }

        private bool ElementoDeProduccion_ConAveria(string iIdNotificacion)
        {
            bool lRes = false;
            Ws_TO.Ws_ToSoapClient ldal = new Ws_TO.Ws_ToSoapClient();
            WsOperacion.ListaDataSet listaDataSet = new WsOperacion.ListaDataSet();
            string lSql = ""; DataTable lTbl = new DataTable();

            lSql = string.Concat("exec  SP_CRUD_NOTIFICACION_AVERIA ", iIdNotificacion, ", 0,'','','',0,'',0,'',6 ");
            listaDataSet.DataSet = ldal.ObtenerDatos(lSql);
            if ((listaDataSet.DataSet.Tables.Count > 0) && (listaDataSet.DataSet.Tables[0].Rows.Count > 0))
            {
                lTbl = listaDataSet.DataSet.Tables[0].Copy();
                if (lTbl.Rows[0]["EstadoSupervisor"].ToString().ToUpper().Equals("OK"))
                    lRes = false;
                else
                {
                    //if (lTbl.Rows[0]["EstadoMaq"].ToString().ToUpper().Equals("CAMBIO DE ROLLO"))
                    if ((lTbl.Rows[0]["TextoIncidencia"].ToString().ToUpper().Equals("CAMBIO DE ROLLO")) && (lTbl.Rows[0]["EstadoMaq"].ToString().ToUpper().Equals("OP")))
                    {
                        lRes = false;
                    }
                    else
                    {
                        lRes = true;
                    }
                }
            }
            return lRes;
        }

        private void   CargarDatosNotificacionAveria()
        {
            Ws_TO.Ws_ToSoapClient ldal = new Ws_TO.Ws_ToSoapClient(); string lIdSolAveria = "";
            WsOperacion.ListaDataSet listaDataSet = new WsOperacion.ListaDataSet();
            string lSql = ""; string lMsg = ""; string lEstadoMaq = "";
            DataTable lTbl = new DataTable(); DateTime lFechaRegistro;
            try
            {
                listaDataSet.MensajeError = "";
                mTipoNotificacion = "NA";
                lSql = string.Concat("exec  SP_CRUD_NOTIFICACION_AVERIA 0,0,'','','',0,'',", mIdMaquina, ",'',3 ");
                listaDataSet.DataSet = ldal.ObtenerDatos(lSql);
                if ((listaDataSet.DataSet.Tables.Count > 0) && (listaDataSet.DataSet.Tables[0].Rows.Count > 0))
                {
                    lTbl = listaDataSet.DataSet.Tables[0].Copy();
                    lEstadoMaq = lTbl.Rows[0]["EstadoMaq"].ToString().ToUpper();
                    lIdSolAveria = lTbl.Rows[0]["IdSolucion"].ToString().ToUpper();
                    //CmbOperador - CmbMaquinaAveria -  Dtp_Fecha  - Tx_Id   - Rb_Averia - Rb_cambioRollo  - 
                    //Rb_Operativa - Rb_Detenida  - Tx_TextoAveria   - groupBox1
                  
                    switch (lEstadoMaq.ToUpper() )
                    {
                        case "CR":   //Cambio de rollo
                            Rb_cambioRollo.Checked = true;
                            Rb_Operativa.Checked = false;
                            Rb_Detenida.Checked = false;
                            break;
                        case "OP":      // 
                            Rb_cambioRollo.Checked = false;
                            Rb_Averia.Checked = true;
                            Rb_Operativa.Checked = true ;
                            Rb_Detenida.Checked = false ;
                            break;
                        case "DET":      // Queda Operativa
                            Rb_cambioRollo.Checked = false;
                            Rb_Averia.Checked = true;
                            Rb_Operativa.Checked = false;
                            Rb_Detenida.Checked = true ;
                              CmbOperador.SelectedValue = lTbl.Rows[0]["IdOperador"];
                             CmbMaquinaAveria.SelectedValue = lTbl.Rows[0]["IdMaquina"];
                            Tx_Id.Text = lTbl.Rows[0]["IdNotificacion"].ToString ();
                            Tx_TextoAveria.Text = lTbl.Rows[0]["TextoIncidencia"].ToString();
                            if (Tx_TextoAveria.Text.Equals("Cambio de Rollo"))
                                Rb_cambioRollo.Checked = true;

                            Tx_Mecanico.Text = mUserLog.Login;
                            Tx_Mecanico.Tag = mUserLog.Iduser ; 
                            groupBox1.Enabled = false;
                            mTipoNotificacion = "SA";
                            break;
                    }
                    
                    lFechaRegistro = DateTime.Parse(lTbl.Rows[0]["FechaRegistro"].ToString());
                    Dtp_Fecha.Value = lFechaRegistro;
                    if (lTbl.Rows[0]["EstadoMaq"].ToString().ToUpper().Equals("OP") && lTbl.Rows[0]["EstadoSupervisor"].ToString().ToUpper().Equals("NOOK"))
                    { mTipoNotificacion = "NOOK";  }

                }

                CargarDatosLiberacionAveria();

                switch (mTipoNotificacion)
                {
                    case "NA":   //notificacion de averia
                        GB_Reparacion.Enabled = false;
                        groupBox1.Enabled = true;
                        Gr_Supervisor.Enabled = false;
                        if (lIdSolAveria.Trim().Length == 0)
                        {
                            this.Width = 906;
                            this.Height = 265;                        
                        }

                        break;
                    case "SA":      // SOlucion Averia
                        //dgvActiva = dgvEtiquetasPiezasExcepciones;
                        GB_Reparacion.Enabled = true;
                        groupBox1.Enabled = false;
                        Gr_Supervisor.Enabled = false;
                        this.Width = 906;
                        this.Height = 688;
                        if (lEstadoMaq.ToUpper().Equals("DET"))  
                                CargarDatosSolucionAveria();
                        break;
                    case "NOOK":      // SOlucion Averia
                        //dgvActiva = dgvEtiquetasPiezasExcepciones;
                        GB_Reparacion.Enabled = false;
                        groupBox1.Enabled = false;
                        Gr_Supervisor.Enabled = true ;
                        this.Width = 906;
                        this.Height = 780;
                              CmbOperador.SelectedValue = lTbl.Rows[0]["IdOperador"];
                             CmbMaquinaAveria.SelectedValue = lTbl.Rows[0]["IdMaquina"];
                            Tx_Id.Text = lTbl.Rows[0]["IdNotificacion"].ToString ();
                            Tx_TextoAveria.Text = lTbl.Rows[0]["TextoIncidencia"].ToString();
                            if (Tx_TextoAveria.Text.Equals("Cambio de Rollo"))
                                Rb_cambioRollo.Checked = true;
                            CargarDatosSolucionAveria();

                            Tx_Supervisor.Text = mUserLog.Login;
                            Tx_Supervisor.Tag = mUserLog.Iduser;
                            CargarDatosLiberacionAveria();
                            break;
                }

            }
            catch (Exception exc)
            {
                listaDataSet.MensajeError = exc.Message.ToString();
            }                      

         //   return lRes;

        }


        private void CargarDatosSolucionAveria()
        {
            Ws_TO.Ws_ToSoapClient ldal = new Ws_TO.Ws_ToSoapClient();
            WsOperacion.ListaDataSet listaDataSet = new WsOperacion.ListaDataSet();
            string lSql = "";   DataTable lTbl = new DataTable(); 
            try
            {
                //---------------------------------
    // ALTER PROCEDURE [dbo].[SP_CRUD_SOLUCION_AVERIA]
    //@Id int,                              //@IdNotificacion int,	                     //@Obs varchar(max) ,
    //@IdUsuarioRegistra varchar(5) ,       //@Estado varchar(50),	                    //@Par1 varchar(10),
    //@Par2 varchar(10),                    //@Opcion int 
                //------------------------------------
                listaDataSet.MensajeError = "";
                mTipoNotificacion = "NA";
                lSql = string.Concat("exec  SP_CRUD_SOLUCION_AVERIA 0,",Tx_Id.Text ,",'','','','SA','',2 ");
                listaDataSet.DataSet = ldal.ObtenerDatos(lSql);
                if ((listaDataSet.DataSet.Tables.Count > 0) && (listaDataSet.DataSet.Tables[0].Rows.Count > 0))
                {
                    lTbl = listaDataSet.DataSet.Tables[0].Copy();
                    Dtg_SolucionAveria.DataSource = lTbl;
                    Dtg_SolucionAveria.Columns["Id"].Width = 50;
                    Dtg_SolucionAveria.Columns["IdNotificacion"].Visible = false;
                    Dtg_SolucionAveria.Columns["Obs"].Width = 500;
                    Dtg_SolucionAveria.Columns["UsuarioRegistra"].Width = 100;
                    Dtg_SolucionAveria.Columns["FechaRegistro"].Width = 100;
                    Dtg_SolucionAveria.Columns["Estado"].Width = 60;
                }                
            }
            catch (Exception exc)
            {
                listaDataSet.MensajeError = exc.Message.ToString();
            }            
        }

        private void CargarDatosLiberacionAveria()
        {
            Ws_TO.Ws_ToSoapClient ldal = new Ws_TO.Ws_ToSoapClient();
            WsOperacion.ListaDataSet listaDataSet = new WsOperacion.ListaDataSet();
            string lSql = ""; DataTable lTbl = new DataTable();
            try
            {
                //---------------------------------
                // ALTER PROCEDURE [dbo].[SP_CRUD_SOLUCION_AVERIA]
                //@Id int,                              //@IdNotificacion int,	                     //@Obs varchar(max) ,
                //@IdUsuarioRegistra varchar(5) ,       //@Estado varchar(50),	                    //@Par1 varchar(10),
                //@Par2 varchar(10),                    //@Opcion int 
                //------------------------------------
                listaDataSet.MensajeError = "";
                //mTipoNotificacion = "NA";
                lSql = string.Concat("exec  SP_CRUD_SOLUCION_AVERIA 0,", Tx_Id.Text, ",'','','','LA','',2 ");
                listaDataSet.DataSet = ldal.ObtenerDatos(lSql);
                if ((listaDataSet.DataSet.Tables.Count > 0) && (listaDataSet.DataSet.Tables[0].Rows.Count > 0))
                {
                    lTbl = listaDataSet.DataSet.Tables[0].Copy();
                    Dtg_LiberacionAveria.DataSource = lTbl;
                    Dtg_LiberacionAveria.Columns["Id"].Width = 50;
                    Dtg_LiberacionAveria.Columns["IdNotificacion"].Visible = false;
                    Dtg_LiberacionAveria.Columns["Obs"].Width = 500;
                    Dtg_LiberacionAveria.Columns["UsuarioRegistra"].Width = 100;
                    Dtg_LiberacionAveria.Columns["FechaRegistro"].Width = 100;
                    Dtg_LiberacionAveria.Columns["Estado"].Width = 60;
                }
            }
            catch (Exception exc)
            {
                listaDataSet.MensajeError = exc.Message.ToString();
            }
        }



        private void CargaCmb(string  iIdMaquina)
        {
            string lSql = ""; Clases.ClsComun lCom = new Clases.ClsComun();
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient(); DataSet lDts = new DataSet();
            DataTable lTblOperario = new DataTable(); DataView lVista = null;
            string lEmpresa = ConfigurationManager.AppSettings["Empresa"].ToString();


            switch (lEmpresa.ToUpper())
            {
                case "TO":   //Cambio de rollo
                    lSql = string.Concat("exec SP_CONSULTAS_NOTIFICACION_AVERIA  'Produccion','TO','','','',1");
                    break;
                case "TOSOL":      // 
                    lSql = string.Concat("exec SP_CONSULTAS_NOTIFICACION_AVERIA  '",iIdMaquina,"','','','','',3");
                    break;                
            }
                    

            
            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                lTblOperario = lDts.Tables[0].Copy();
                 CmbOperador.DisplayMember = "Usuario";
                 CmbOperador.ValueMember = "Id";
                 CmbOperador.DataSource = lTblOperario;
                 if (lCom.Val(mUserLog.Iduser) > 0)
                 {
                     CmbOperador.SelectedValue = mUserLog.Iduser;
                     lVista = new DataView(lTblOperario, string.Concat("Id=", mUserLog.Iduser), "", DataViewRowState.CurrentRows);
                     if (lVista.Count > 0)
                         CmbOperador.Enabled = false;
                     else
                         CmbOperador.Enabled = true  ;
                 }
            }

             lSql = string.Concat("exec SP_CONSULTAS_NOTIFICACION_AVERIA  '','','','','',2");
            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                CmbMaquinaAveria.DisplayMember = "Maq_Nombre";
                CmbMaquinaAveria.ValueMember = "Maq_NRO";
                CmbMaquinaAveria.DataSource = lDts.Tables[0].Copy();
                if (lCom.Val(mUserLog.IdMaquina.ToString () ) > 0)
                {
                    CmbMaquinaAveria.SelectedValue = mUserLog.IdMaquina;
                    lVista = new DataView(lDts.Tables[0], string.Concat("Maq_NRO=", mUserLog.IdMaquina), "", DataViewRowState.CurrentRows);
                    if (lVista.Count > 0)
                        CmbMaquinaAveria.Enabled = false;
                    else
                        CmbMaquinaAveria.Enabled = true;
                }
            }

        }

        private void VerFormulario(string iTipo)
        {
            if (iTipo.ToUpper().Equals("EP"))
            {
                Rb_cambioRollo.Enabled = false;
                Rb_Operativa.Text = " Elemento de Producción Queda Operativo";
                Rb_Detenida.Text = " Elemento de Producción Queda Detenido";
            }
            else
            {

            }
        }

        private void CargaCmb_ElementosProd(string iIdElemento)
        {
            string lSql = ""; Clases.ClsComun lCom = new Clases.ClsComun();
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient(); DataSet lDts = new DataSet();
            WsOperacion.OperacionSoapClient lDal = new WsOperacion.OperacionSoapClient();

            DataTable lTblOperario = new DataTable(); DataView lVista = null;
            string lEmpresa = ConfigurationManager.AppSettings["Empresa"].ToString();


            switch (lEmpresa.ToUpper())
            {
                case "TO":   //Cambio de rollo
                    lSql = string.Concat("exec SP_CONSULTAS_NOTIFICACION_AVERIA  'Produccion','TO','','','',1");
                    break;
                case "TOSOL":      // 
                    lSql = string.Concat("exec SP_CONSULTAS_NOTIFICACION_AVERIA  'Produccion','TOSOL','','','',1");
                    break;
            }

            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                lTblOperario = lDts.Tables[0].Copy();
                CmbOperador.DisplayMember = "Usuario";
                CmbOperador.ValueMember = "Id";
                CmbOperador.DataSource = lTblOperario;
                if (lCom.Val(mUserLog.Iduser) > 0)
                {
                    CmbOperador.SelectedValue = mUserLog.Iduser;
                    lVista = new DataView(lTblOperario, string.Concat("Id=", mUserLog.Iduser), "", DataViewRowState.CurrentRows);
                    if (lVista.Count > 0)
                        CmbOperador.Enabled = false;
                    else
                        CmbOperador.Enabled = true;
                }
            }

            string lIdSucursal = ConfigurationManager.AppSettings["IdSucursal"].ToString();

            lDts = lDal.ObtenerDatosIniciales("EP", lIdSucursal);

            //lSql = string.Concat("exec SP_CONSULTAS_NOTIFICACION_AVERIA  '", lIdSucursal,"','','','','',4");
            //lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                CmbMaquinaAveria.DisplayMember = "Elemento";
                CmbMaquinaAveria.ValueMember = "Id";
                CmbMaquinaAveria.DataSource = lDts.Tables[0].Copy();
                if (lCom.Val(iIdElemento) > 0)
                {
                    CmbMaquinaAveria.SelectedValue = iIdElemento;
                    lVista = new DataView(lDts.Tables[0], string.Concat("Id=", iIdElemento), "", DataViewRowState.CurrentRows);
                    if (lVista.Count > 0)
                        CmbMaquinaAveria.Enabled = false;
                    else
                        CmbMaquinaAveria.Enabled = true;
                }
            }

        }


        private bool DatosOKParaGrabar( string iTipo )
        {
            bool lRes = true; string lMsg = "";
            if (iTipo == "NA")
            {
                if ((Rb_Operativa.Checked == false) && (Rb_Detenida.Checked == false))
                {
                    lMsg = string.Concat(lMsg, " Debe indicar el estado de la Notificación  (Operativa o Detenida)", Environment.NewLine);
                    lRes = false;
                }
                if (Tx_TextoAveria.Text.Trim().Length < 3)
                {
                    lMsg = string.Concat("Debe Ingresar  más de 3 caracteres en el campo Motivo Averia", Environment.NewLine);
                    lRes = false;
                    Tx_TextoAveria.Focus();
                }
            }
            if (iTipo == "SA")
            {
                if (Rb_cambioRollo.Checked == true)
                {
                    if (Tx_ReparacionAveria.Text.Trim().Length < 3)
                    {
                        lMsg = string.Concat("Debe Ingresar  más de 3 caracteres en el campo Detalle de Reparación", Environment.NewLine);
                        lRes = false;
                        Tx_TextoAveria.Focus();
                    }
                }
                if ((Rb_RepOperativa.Checked == false) && (Rb_RepDetenida.Checked ==false))
                {
                    lMsg = string.Concat( lMsg ," Debe indicar el estado de la reparación (Operativa o Detenida)", Environment.NewLine);
                    lRes = false;                    
                }
                else
                     if (Tx_ReparacionAveria.Text.Trim().Length < 3)
                        {
                            lMsg = string.Concat("Debe Ingresar  más de 3 caracteres en el campo Detalle de Reparación", Environment.NewLine);
                            lRes = false;
                            Tx_TextoAveria.Focus();
                        }

            }

            if (iTipo == "LA")
            {
           
                    if ((this.Rb_LiberarOperativa.Checked == false) && (Rb_LiberarDetenida.Checked == false))
                    {
                        lMsg = string.Concat(lMsg, " Debe indicar el estado de la reparación (Operativa o Detenida)", Environment.NewLine);
                        lRes = false;
                    }
                    else 
                         if (Tx_LiberarTotem.Text.Trim().Length < 3)
                            {
                                lMsg = string.Concat("Debe Ingresar  más de 3 caracteres en el campo Liberación de  Averia", Environment.NewLine);
                                lRes = false;
                                Tx_TextoAveria.Focus();
                            }
                }
            

            if (lMsg.ToString().Trim().Length > 0)
            {
                MessageBox.Show(lMsg, " Avisos Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return lRes;
        }

        private void Btn_Grabar_Click(object sender, EventArgs e)
        {
           

        }

 private string  ObtenerCuerpoMail(string iUser, string iTxAveria, string iMaq, string iFecha, string iEstado, string iIdAveria ) 
    {
        string  lRes  = "";
            //lRes = String.Concat(" Señores Mantenimiento:  ", Environment.NewLine, Environment.NewLine);
            //lRes = String.Concat(" Se ha reportado una nueva notificación de Averia, con los siguientes datos ", Environment.NewLine);
            //lRes = String.Concat(lRes, " ID Averia          :", iIdAveria, Environment.NewLine);
            //lRes = String.Concat(lRes, " El Usuario         :", iUser, Environment.NewLine );
            //lRes = String.Concat(lRes, " Motivo averia      :", iTxAveria , Environment .NewLine);
            //lRes = String.Concat(lRes, " Maquina Afectada   :", iMaq, Environment.NewLine);
            //lRes = String.Concat(lRes, " Fecha Notificacion :", iFecha, Environment.NewLine);
            //lRes = String.Concat(lRes, " Estado de Maquina  :", iEstado, Environment.NewLine);
            lRes = String.Concat(" Señores Mantenimiento:  ", "<br> <br> " );
            lRes = String.Concat(" Se ha reportado una nueva notificación de Averia, con los siguientes datos ", "  <br> ");
            lRes = String.Concat(lRes, " ID Averia          :", iIdAveria, "  <br> ");
            lRes = String.Concat(lRes, " El Usuario         :", iUser, "  <br> ");
            lRes = String.Concat(lRes, " Motivo averia      :", iTxAveria, "  <br> ");
            lRes = String.Concat(lRes, " Maquina Afectada   :", iMaq, "  <br> ");
            lRes = String.Concat(lRes, " Fecha Notificacion :", iFecha, "  <br> ");
            lRes = String.Concat(lRes, " Estado de Maquina  :", iEstado, "  <br> ");

            if (iTxAveria.Equals ("Cambio de Rollo"))
     {
         lRes = String.Concat(lRes, " Notificación Informativa no requiere reparación.", "  <br> "); 
     }
     else
     { 
         lRes = String.Concat(lRes, " Favor revisar la averia reportada.", "  <br> "); 
     }
        
        
        lRes = String.Concat(lRes, "  <br> ", "  <br> ");

        lRes = String.Concat(lRes, "Este mail ha sido enviado de forma automática por el sistema", "  <br> ");

        return lRes ;
        }

 private string ObtenerCuerpoMailSolucionAveria()
 {
        //@Id int,                              //@IdNotificacion int,	                      //@Obs varchar(max) ,
        //@IdUsuarioRegistra varchar(1) ,       //@Estado varchar(50),	                    //@Par1 varchar(10),
        //@Par2 varchar(10),                    //@Opcion int 
     string lRes = ""; DataTable lTbl = new DataTable(); int i = 0; DateTime lFechaSolucion; double  lMinutos = 0;
            DateTime lFechaAveria;
            lRes = String.Concat(" Señores:  ", "  <br> ", "  <br> ");
     lRes = String.Concat(lRes," Se ha Solucionado una notificación de Averia", "  <br> ", "  <br> ");
     lRes = String.Concat(lRes," Datos de la Notificación de Averia: ", "  <br> ");
     lRes = String.Concat(lRes, " ID Averia          :", Tx_Id .Text, "  <br> ");
     lRes = String.Concat(lRes, " Motivo averia      :", Tx_TextoAveria.Text, "  <br> ");     
     lRes = String.Concat(lRes, " Maquina Afectada   :", CmbMaquinaAveria.SelectedValue.ToString(), "  <br> ");
     lRes = String.Concat(lRes, " Fecha Notificacion :", Dtp_Fecha.Value .ToShortDateString(), "  <br> ");

     lRes = String.Concat(lRes, "  <br> ", " Datos de la Solución de la  Averia: ", "  <br> ");
     lRes = String.Concat( lRes," Se ingresaron las siguientes observaciones : ", "  <br> ");
     lRes = String.Concat(lRes," Fecha Registro - Estado - Usuario Registra  -  Comentario ", "  <br> ");
     lTbl = ObtenerDatosSolucionAveria(Tx_Id.Text);
     for (i = 0; i < lTbl.Rows.Count; i++)
     {
         lRes = String.Concat(lRes, lTbl.Rows [i]["FechaRegistro"].ToString ()," - ", lTbl.Rows [i]["Estado"].ToString ()," - ",lTbl.Rows [i]["UsuarioRegistra"].ToString ()," - ", lTbl.Rows [i]["Obs"].ToString (), "  <br> ");
         if (lTbl.Rows[i]["Estado"].ToString().ToUpper().Equals("OP"))
         {
             lFechaSolucion = DateTime.Parse(lTbl.Rows[i]["FechaRegistro"].ToString());
                    lFechaAveria = DateTime.Parse(lTbl.Rows[i]["FechaAveria"].ToString());
                    lMinutos = (lFechaSolucion - lFechaAveria).TotalMinutes  ;
         }
     }

     //Obtenemos los datos de la liberación de la maquina por el supervisor
     lRes = String.Concat(lRes, "  <br> ", "  <br> ", " Datos de la Liberación de la  Averia por el Supervisor: ", "  <br> ");
     lRes = String.Concat(lRes, " Se ingresaron las siguientes observaciones : ", "  <br> ");
     lRes = String.Concat(lRes, " Fecha Registro - Estado - Usuario Registra  -  Comentario ", "  <br> ");
     lTbl = ObtenerDatosLiberacionAveria(Tx_Id.Text);
     for (i = 0; i < lTbl.Rows.Count; i++)
     {
         lRes = String.Concat(lRes, lTbl.Rows[i]["FechaRegistro"].ToString(), " - ", lTbl.Rows[i]["Estado"].ToString(), " - ", lTbl.Rows[i]["UsuarioRegistra"].ToString(), " - ", lTbl.Rows[i]["Obs"].ToString(), "  <br> ");
         if (lTbl.Rows[i]["Estado"].ToString().ToUpper().Equals("OP"))
         {
             lFechaSolucion = DateTime.Parse(lTbl.Rows[i]["FechaRegistro"].ToString());
             lMinutos = (lFechaSolucion - Dtp_Fecha.Value).TotalMinutes;
         }
     }


     lRes = String.Concat(lRes, "  <br> ", " El Tiempo (en minutos) que estuvo detenida la máquina fue de ", Math.Round( lMinutos,0).ToString (), "  <br> ");
     //lRes = String.Concat(lRes, " Estado de Maquina  :", iEstado, Environment.NewLine);
     

     lRes = String.Concat(lRes, "  <br> ", "  <br> ");

     lRes = String.Concat(lRes, "Este mail ha sido enviado de forma automática por el sistema", "  <br> ");

     return lRes;
 }

 private string ObtenerCuerpoMailLIberacionAveria()
 {
     //@Id int,                              //@IdNotificacion int,	                      //@Obs varchar(max) ,
     //@IdUsuarioRegistra varchar(1) ,       //@Estado varchar(50),	                    //@Par1 varchar(10),
     //@Par2 varchar(10),                    //@Opcion int 
     string lRes = ""; DataTable lTbl = new DataTable(); int i = 0; DateTime lFechaSolucion; double lMinutos = 0;
     lRes = String.Concat(" Señores:  ", "  <br> ", "  <br> ");
     lRes = String.Concat(lRes, " Se ha Liberado una notificación de Averia", "  <br> ", "  <br> ");
     lRes = String.Concat(lRes, " Datos de la Liberación de Averia: ", "  <br> ");
     lRes = String.Concat(lRes, " ID Averia          :", Tx_Id.Text, "  <br> ");
     lRes = String.Concat(lRes, " Motivo averia      :", Tx_TextoAveria.Text, "  <br> ");
     lRes = String.Concat(lRes, " Maquina Afectada   :", CmbMaquinaAveria.SelectedValue.ToString(), "  <br> ");
     lRes = String.Concat(lRes, " Fecha Notificacion :", Dtp_Fecha.Value.ToShortDateString(), "  <br> ");

     lRes = String.Concat(lRes, "  <br> ", " Datos de la Solución de la  Averia: ", "  <br> ");
     lRes = String.Concat(lRes, " Se ingresaron las siguientes observaciones : ", "  <br> ");
     lRes = String.Concat(lRes, " Fecha Registro - Estado - Usuario Registra  -  Comentario ", "  <br> ");
     lTbl = ObtenerDatosSolucionAveria(Tx_Id.Text);
     for (i = 0; i < lTbl.Rows.Count; i++)
     {
         lRes = String.Concat(lRes, lTbl.Rows[i]["FechaRegistro"].ToString(), " - ", lTbl.Rows[i]["Estado"].ToString(), " - ", lTbl.Rows[i]["UsuarioRegistra"].ToString(), " - ", lTbl.Rows[i]["Obs"].ToString(), "  <br> ");
         if (lTbl.Rows[i]["Estado"].ToString().ToUpper().Equals("OP"))
         {
             lFechaSolucion = DateTime.Parse(lTbl.Rows[i]["FechaRegistro"].ToString());
             lMinutos = (lFechaSolucion - Dtp_Fecha.Value).TotalHours;
         }
     }

     lRes = String.Concat(lRes, "  <br> ", " Se ingresaron las siguientes observaciones : ", "  <br> ");
     lRes = String.Concat(lRes, "  <br> ", " El Tiempo (en Horas) que estuvo detenida ma máquina fue de ", Math.Round(lMinutos, 0).ToString(), "  <br> ");
     //lRes = String.Concat(lRes, " Estado de Maquina  :", iEstado, Environment.NewLine);


     lRes = String.Concat(lRes, "  <br> ", "  <br> ");

     lRes = String.Concat(lRes, "Este mail ha sido enviado de forma automática por el sistema", "  <br> ");

     return lRes;
 }

         private DataTable ObtenerDatosSolucionAveria(string iIdAveria)
         {
             DataTable lTbl = new DataTable();string lSql="";
             Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient(); DataSet lDts = new DataSet();
             lSql = string.Concat("exec SP_CRUD_SOLUCION_AVERIA 0,", Tx_Id.Text,",'','','','SA','',2" );                
            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                lTbl = lDts.Tables[0].Copy();
            }
             return lTbl;
         }


         private DataTable ObtenerDatosLiberacionAveria(string iIdAveria)
         {
             DataTable lTbl = new DataTable(); string lSql = "";
             Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient(); DataSet lDts = new DataSet();
             lSql = string.Concat("exec SP_CRUD_SOLUCION_AVERIA 0,", Tx_Id.Text, ",'','','','LA','',2");
             lDts = lPx.ObtenerDatos(lSql);
             if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
             {
                 lTbl = lDts.Tables[0].Copy();
             }
             return lTbl;
         }

        private void NotificaAveria_Load(object sender, EventArgs e)
        {
            if (mTipoAveria.ToUpper().Equals("EP"))
            {
                CargaCmb_ElementosProd (mObjEP .IdElemento );
                VerFormulario("EP");
                if (ElementoDeProduccion_ConAveria(mIdAveria) == true)
                    CargarDatosNotificacionAveria_EP();
            }
            else
            {
                CargaCmb(mIdMaquina.ToString() );
                if (MaquinaConAveria()==true)
                    CargarDatosNotificacionAveria();

            }

        }


        private void Btn_Cargar_Click(object sender, EventArgs e)
        {
            string lSql = ""; Clases.ClsComun lCom = new Clases.ClsComun();
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient(); DataSet lDts = new DataSet();
            DataTable lTblOperario = new DataTable();
            string lTexto = "";
            lTexto = Tx_TextoAveria.Text.Replace("\n", "|");

            lSql = string.Concat("select * from NotificacionAveria  where ID=15");            
            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                //Si la grabación es OK se debe enviar mail de notificación  y persistir ma notificación.
                Tx_TextoAveria.Text = lDts.Tables[0].Rows[0]["TextoIncidencia"].ToString();

            }
        }

        public  void IniciaForm(CurrentUser iUser)
        {
            AppDomain.CurrentDomain.SetData("TipoAveria","EP") ;
            mUserLog = iUser;
            mIdMaquina = mUserLog.IdMaquina.ToString () ;
            mIdMecanico = iUser.Iduser;
            mIdSucursal = ObtenerIdSucursalActual();
        }

        public void IniciaFormElementoProd(Clases .Obj.Obj_ElementoProd  iObj)
        {
            mObjEP = iObj;
            mTipoAveria = "EP";
            mIdSucursal = ObtenerIdSucursalActual();
        }

        public void IniciaReparacion_EP(string iIdAveria, CurrentUser iUser)
        {
            mIdAveria = iIdAveria;
            mTipoAveria = "EP";
            mUserLog = iUser;
            mIdMaquina = mUserLog.IdMaquina.ToString();
            mIdMecanico = iUser.Iduser;
        }


        private void Tx_TextoAveria_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == Convert.ToChar(Keys.Enter))
            //{
            //            mIdSucursal = ConfigurationManager.AppSettings["IdSucursal"].ToString();
            //    Tx_TextoAveria.Text = string.Concat(Tx_TextoAveria.Text, Environment.NewLine);
            //    Tx_TextoAveria.Focus();
            //}
        }

        private void Btn_Grabar_Click_1(object sender, EventArgs e)
        {
            //  ALTER PROCEDURE [dbo].[SP_CRUD_NOTIFICACION_AVERIA]
     //@Id int,                         //@IdOperador int,          //@TipoMaquina varchar(50) ,
     //@TextoIncidencia varchar(max) ,  //@MailEnviado varchar(1) , //@IdUserCrea int   ,
     //@Estado varchar(50),            //@IdMaquina int,            //@Opcion int   

            if (groupBox1.Enabled == true)  // Estamos ingresando un Notificacion de averia
            {
                GrabaNotificacionAveria();
            }
            else
                if (Gr_Supervisor.Enabled == true) // Estamos ingresando una Liberación de Averia
                {
                    GrabaLiberacionAveria();
                }
                else  // Estamos ingresando una Liberación de Averia
                        {
                            GrabaSolucionAveria();
                        }           
        }

        private void GrabaSolucionAveria()
        {
            string lTipoNot = ""; int idListadistribucion = 0;
            try
            {
                if (DatosOKParaGrabar("SA") == true)
                {
                    string lSql = ""; Clases.ClsComun lCom = new Clases.ClsComun(); string lIdAveria = "";
                    Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient(); DataSet lDts = new DataSet();
                    DataTable lTblOperario = new DataTable(); string lMsg = ""; string EstadoMaq = "";
                    string lTexto = ""; string lTxMsg = ""; string lTitulo = ""; string lRes = "";
                    lTexto = Tx_TextoAveria.Text.Replace("\n", Environment.NewLine);

                    if (Rb_RepOperativa.Checked == true)
                        EstadoMaq = "OP";

                    if (this.Rb_RepDetenida.Checked == true)
                        EstadoMaq = "DET";

                    //*****************************************************
                    lSql = string.Concat("exec SP_CRUD_SOLUCION_AVERIA ", lCom.Val(Tx_IdSolucion.Text), ",", Tx_Id.Text, ",'");
                    lSql = string.Concat(lSql, Tx_ReparacionAveria.Text, "','", lCom.Val(mIdMecanico), "','", EstadoMaq, "','SA','',1");
                    lDts = lPx.ObtenerDatos(lSql);
                    if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                    {
                        lIdAveria = lDts.Tables[0].Rows[0][0].ToString();
                        //Si la grabación es OK se debe enviar mail de notificación  y persistir ma notificación.
                        lTxMsg = ObtenerCuerpoMailSolucionAveria();

                        switch (mIdSucursal)
                        {
                            case "1":
                                idListadistribucion = -11;
                                lTitulo = "Notificación   Solucion de Averias para  Planta Calama ";
                                break;
                            case "4":
                                idListadistribucion = -10;
                                lTitulo = "Notificación Solucion de  Averias para   para Planta Santiago ";
                                break;
                            case "7":
                                idListadistribucion = -12;
                                lTitulo = "Notificación de   Solucion de Averias para  Planta TOSOL ";
                                break;
                            case "15":
                                idListadistribucion = -15;
                                lTitulo = "Notificación de Averias Planta Coronel ";
                                break;
                        }


                        lRes = lPx.EnviaNotificacionesEnviaMsgDeNotificacion("", lTxMsg, idListadistribucion, lTitulo);
                        //lRes = lPx.EnviaNotificacionesEnviaMsgDeNotificacion("", lTxMsg, -10, lTitulo);
                        if (lRes.ToUpper().Equals("OK"))
                        {
                            lMsg = "La Solución  de Averia fue procesada  correctamente";
                            if (Rb_Averia.Checked == true)
                            {
                                //if (EstadoMaq.Equals("OP"))
                                //    lMsg = string.Concat(lMsg, Environment.NewLine, " El sistema se cerrara, debe ingresar nuevamente");
                            }


                            MessageBox.Show(lMsg, " Avisos Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);


                            //if (EstadoMaq.Equals("OP"))
                            //{
                            //    lTipoNot = AppDomain.CurrentDomain.GetData("TipoAveria").ToString();
                            //    if ((mTipoAveria == "EP"))
                            //        this.Close();
                            //    else
                            //         if ((lTipoNot == "MM"))
                            //        this.Close();
                            //    else
                            //    {
                            //        LogOut();
                            //        Application.Exit();
                            //    }
                            //}
                            //else
                            //{
                            //    this.Close();
                            //}

                        }
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox .Show (string.Concat ("Ha ocurrido el siguiente error: " , exc.Message.ToString()));
            }
        }

        private void LogOut()
        {
            WsSesion.WS_SesionSoapClient lSesion = new WsSesion.WS_SesionSoapClient();
            string lRes = "";

        lRes = lSesion.RegistraLogOUT(mUserLog.Iduser.ToString(), mUserLog.IdMaquina.ToString());
        }
        

        private void GrabaLiberacionAveria()
        {
            int idListadistribucion = 0;
            try
            { 

            if (DatosOKParaGrabar("LA") == true)
            {
                string lSql = ""; Clases.ClsComun lCom = new Clases.ClsComun(); string lIdAveria = "";
                Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient(); DataSet lDts = new DataSet();
                DataTable lTblOperario = new DataTable(); string lMsg = ""; string EstadoMaq = "";
                string lTexto = ""; string lTxMsg = ""; string lTitulo = ""; string lRes = "";
                lTexto = Tx_TextoAveria.Text.Replace("\n", Environment.NewLine);

                if (Rb_LiberarOperativa.Checked == true)
                    EstadoMaq = "OP";

                if (this.Rb_LiberarDetenida .Checked == true)
                    EstadoMaq = "DET";

                //*****************************************************
                //@Id int,                             //@IdNotificacion int,	                //@Obs varchar(max) ,
                //@IdUsuarioRegistra varchar(1) ,    //@Estado varchar(50),	                    //@Par1 varchar(10),
                //@Par2 varchar(10),                //@Opcion int 

                lSql = string.Concat("exec SP_CRUD_SOLUCION_AVERIA ", lCom.Val(Tx_IdSolucion.Text), ",", Tx_Id.Text, ",'");
                lSql = string.Concat(lSql, this.Tx_LiberarTotem .Text, "','", lCom.Val(mUserLog .Iduser ), "','", EstadoMaq, "','LA','',1");
                lDts = lPx.ObtenerDatos(lSql);
                if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                {
                    lIdAveria = lDts.Tables[0].Rows[0][0].ToString();
                    //Si la grabación es OK se debe enviar mail de notificación  y persistir ma notificación.
                    lTxMsg = ObtenerCuerpoMailSolucionAveria();
                    lTitulo = "Notificación por Solución  de Averias: ";

                        //if (mIdSucursal.Equals("1")) // es Calama
                        //    idListadistribucion = -11;

                        //if (mIdSucursal.Equals("4")) // es Calama
                        //    idListadistribucion = -10;

                        switch (mIdSucursal)
                        {
                            case "1":
                                idListadistribucion = -11;
                                lTitulo = "Notificación de Liberación  de Averias para  Planta Calama ";
                                break;
                            case "4":
                                idListadistribucion = -10;
                                lTitulo = "Notificación de   Liberación de Averias para Planta Santiago ";
                                break;
                            case "7":
                                idListadistribucion = -12;
                                lTitulo = "Notificación de   Liberación de Averias para  Planta TOSOL ";
                                break;
                            case "15":
                                idListadistribucion = -15;
                                lTitulo = "Notificación de Averias Planta Coronel ";
                                break;
                        }

                        lRes = lPx.EnviaNotificacionesEnviaMsgDeNotificacion("", lTxMsg, idListadistribucion, lTitulo);

                        //lRes = lPx.EnviaNotificacionesEnviaMsgDeNotificacion("", lTxMsg, -10, lTitulo);
                    if (lRes.ToUpper().Equals("OK"))
                    {
                        lMsg = "La Solución  de Averia fue procesada  correctamente";
                        MessageBox.Show(lMsg, " Avisos Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }

            }
            }
            catch (Exception exc)
            {
                MessageBox.Show(string.Concat("Ha ocurrido el siguiente error: ", exc.Message.ToString()));
            }
        }

        private void GrabaNotificacionAveria()
        {
            int idListadistribucion = -1;
            if (DatosOKParaGrabar("NA") == true)
            {
                string lSql = ""; Clases.ClsComun lCom = new Clases.ClsComun(); string lIdAveria = "";
                Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient(); DataSet lDts = new DataSet();
                DataTable lTblOperario = new DataTable(); string lMsg = ""; string EstadoMaq = "";
                string lTexto = ""; string lTxMsg = ""; string lTitulo = ""; string lRes = "";
                lTexto = Tx_TextoAveria.Text.Replace("\n", Environment.NewLine);

                if (Rb_Detenida.Checked == true)
                    EstadoMaq = "DET";

                if (this.Rb_Operativa.Checked == true)
                    EstadoMaq = "OP";
                

                lSql = string.Concat("exec SP_CRUD_NOTIFICACION_AVERIA ", lCom.Val(Tx_Id.Text), ",", CmbOperador.SelectedValue);
                lSql = string.Concat(lSql, ",'", mTipoAveria,"','", lTexto, "','N',0,'", EstadoMaq,"',", this.CmbMaquinaAveria.SelectedValue, ",'", EstadoMaq, "',1");
                lDts = lPx.ObtenerDatos(lSql);
                if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                {
                    lIdAveria = lDts.Tables[0].Rows[0][0].ToString();
                    //Si la grabación es OK se debe enviar mail de notificación  y persistir ma notificación.
                    lTxMsg = ObtenerCuerpoMail(CmbOperador.Text, lTexto, CmbMaquinaAveria.Text, Dtp_Fecha.Value.ToString(), EstadoMaq, lIdAveria);
                    lTitulo = "Notificación por Notificación de Averias: ";


                    switch (mIdSucursal)
                    {
                        case "1":
                            idListadistribucion = -11;
                            lTitulo = "Notificación de Averias Planta Calama ";
                            break;
                        case "4":
                            idListadistribucion = -10;
                            lTitulo = "Notificación de Averias Planta Santiago  ";
                            break;
                        case "7":
                            idListadistribucion = -12;
                            lTitulo = "Notificación de Averias Planta TOSOL ";
                            break;
                        case "15":
                            idListadistribucion = -15;
                            lTitulo = "Notificación de Averias Planta Coronel ";
                            break;
                    }                       

                    lRes = lPx.EnviaNotificacionesEnviaMsgDeNotificacion("", lTxMsg, idListadistribucion, lTitulo);
                    //lRes = lPx.EnviaNotificacionesEnviaMsgDeNotificacion("", lTxMsg, -10, lTitulo);
                    if (lRes.ToUpper().Equals("OK"))
                    {
                        lMsg = "La Notificación de Averia fue procesada  correctamente, Se enviara un mail para que se gestione la reparación de la Averia";
                        MessageBox.Show(lMsg, " Avisos Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Close();
                    }
                }
            }              
        }

        private void Btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_Limpiar_Click(object sender, EventArgs e)
        {
            Tx_TextoAveria.Text = "";
        }

        private void Rb_cambioRollo_CheckedChanged(object sender, EventArgs e)
        {
            if (Rb_cambioRollo.Checked == true)
            {
                Tx_TextoAveria.Text = "Cambio de Rollo";
                Rb_Detenida.Checked = true;
                Gb_Averia.Enabled = false;
            }
            else
            {
                Gb_Averia.Enabled = true;
            }
        }

        private void Rb_Averia_CheckedChanged(object sender, EventArgs e)
        {
            if (Rb_Averia.Checked == true)
            {
                Tx_TextoAveria.Text = "";
                Rb_Averia.Enabled = false;
            }
            else
            {
                Rb_Averia.Enabled = true;
            }
        }


        private string ObtenerIdSucursalActual()
        {
            string lIdSucursal = "0";

             lIdSucursal = ConfigurationManager.AppSettings["IdSucursal"].ToString();

            return lIdSucursal;
        }


        #region Notificación elemento de Produccion
        private void CargarDatosNotificacionAveria_EP()
        {
            Ws_TO.Ws_ToSoapClient ldal = new Ws_TO.Ws_ToSoapClient(); string lIdSolAveria = "";
            WsOperacion.ListaDataSet listaDataSet = new WsOperacion.ListaDataSet();
            string lSql = ""; string lMsg = ""; string lEstadoMaq = "";
            DataTable lTbl = new DataTable(); DateTime lFechaRegistro;
            try
            {
                listaDataSet.MensajeError = "";
                mTipoNotificacion = "NA";
                lSql = string.Concat("exec  SP_CRUD_NOTIFICACION_AVERIA ", mIdAveria , ", 0,'','','',0,'',0,'',6 ");
                listaDataSet.DataSet = ldal.ObtenerDatos(lSql);
                if ((listaDataSet.DataSet.Tables.Count > 0) && (listaDataSet.DataSet.Tables[0].Rows.Count > 0))
                {
                    lTbl = listaDataSet.DataSet.Tables[0].Copy();
                    lEstadoMaq = lTbl.Rows[0]["EstadoMaq"].ToString().ToUpper();
                    lIdSolAveria = lTbl.Rows[0]["IdSolucion"].ToString().ToUpper();
                    //CmbOperador - CmbMaquinaAveria -  Dtp_Fecha  - Tx_Id   - Rb_Averia - Rb_cambioRollo  - 
                    //Rb_Operativa - Rb_Detenida  - Tx_TextoAveria   - groupBox1

                    switch (lEstadoMaq.ToUpper())
                    {
                        case "CR":   //Cambio de rollo
                            Rb_cambioRollo.Checked = true;
                            Rb_Operativa.Checked = false;
                            Rb_Detenida.Checked = false;
                            break;
                        case "OP":      // 
                            Rb_cambioRollo.Checked = false;
                            Rb_Averia.Checked = true;
                            Rb_Operativa.Checked = true;
                            Rb_Detenida.Checked = false;
                            break;
                        case "DET":      // Queda Operativa
                            Rb_cambioRollo.Checked = false;
                            Rb_Averia.Checked = true;
                            Rb_Operativa.Checked = false;
                            Rb_Detenida.Checked = true;
                            CmbOperador.SelectedValue = lTbl.Rows[0]["IdOperador"];
                            CmbMaquinaAveria.SelectedValue = lTbl.Rows[0]["IdMaquina"];
                            Tx_Id.Text = lTbl.Rows[0]["IdNotificacion"].ToString();
                            Tx_TextoAveria.Text = lTbl.Rows[0]["TextoIncidencia"].ToString();
                            if (Tx_TextoAveria.Text.Equals("Cambio de Rollo"))
                                Rb_cambioRollo.Checked = true;

                            Tx_Mecanico.Text = mUserLog.Login;
                            Tx_Mecanico.Tag = mUserLog.Iduser;
                            groupBox1.Enabled = false;
                            mTipoNotificacion = "SA";
                            break;
                    }

                    lFechaRegistro = DateTime.Parse(lTbl.Rows[0]["FechaRegistro"].ToString());
                    Dtp_Fecha.Value = lFechaRegistro;
                    if (lTbl.Rows[0]["EstadoMaq"].ToString().ToUpper().Equals("OP") && lTbl.Rows[0]["EstadoSup"].ToString().ToUpper().Equals("NOOK"))
                    { mTipoNotificacion = "NOOK"; }

                }

         

                switch (mTipoNotificacion)
                {
                    case "NA":   //notificacion de averia
                        GB_Reparacion.Enabled = false;
                        groupBox1.Enabled = true;
                        Gr_Supervisor.Enabled = false;
                        if (lIdSolAveria.Trim().Length == 0)
                        {
                            this.Width = 906;
                            this.Height = 265;
                        }

                        break;
                    case "SA":      // SOlucion Averia
                        //dgvActiva = dgvEtiquetasPiezasExcepciones;
                        GB_Reparacion.Enabled = true;
                        groupBox1.Enabled = false;
                        Gr_Supervisor.Enabled = false;
                        this.Width = 906;
                        this.Height = 688;
                        if (lEstadoMaq.ToUpper().Equals("DET"))
                            CargarDatosSolucionAveria();
                        break;
                    case "NOOK":      // SOlucion Averia
                        //dgvActiva = dgvEtiquetasPiezasExcepciones;
                        GB_Reparacion.Enabled = false;
                        groupBox1.Enabled = false;
                        Gr_Supervisor.Enabled = true;
                        this.Width = 906;
                        this.Height = 780;
                        CmbOperador.SelectedValue = lTbl.Rows[0]["IdOperador"];
                        CmbMaquinaAveria.SelectedValue = lTbl.Rows[0]["IdMaquina"];
                        Tx_Id.Text = lTbl.Rows[0]["IdNotificacion"].ToString();
                        Tx_TextoAveria.Text = lTbl.Rows[0]["TextoIncidencia"].ToString();
                        if (Tx_TextoAveria.Text.Equals("Cambio de Rollo"))
                            Rb_cambioRollo.Checked = true;


                        CargarDatosSolucionAveria();

                        Tx_Supervisor.Text = mUserLog.Login;
                        Tx_Supervisor.Tag = mUserLog.Iduser;
                        CargarDatosLiberacionAveria();
                     
                        break;
                }

            }
            catch (Exception exc)
            {
                listaDataSet.MensajeError = exc.Message.ToString();
            }

            //   return lRes;

        }

        #endregion


    }
}
