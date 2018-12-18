﻿using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Text;
using System.Windows.Forms;
using CommonLibrary2;
using System.Drawing;

namespace Metalurgica.Controls
{
    public partial class CtlProduccion : UserControl
    {
        private CurrentUser mUserLog = new CurrentUser();
        private Boolean EvaluaTimer = true;
        private const string COLUMNNAME_ETIQUETA_PIEZA = "ETIQUETA_PIEZA";
        private const string COLUMNNAME_PIE_ESTADO = "PIE_ESTADO";
        private const string COLUMNNAME_ESTADO = "ESTADO";
        private double mTotalKilos = 0;
        private string mIdUser = "0";
        private string mIdEtiquetaColada = "0";
        private string mEstadoMaquina = "";
        private string mIdNotificacion = "";
        private string mMsgMaquina = "";
        private string mTipoAveria = "";
        private string mMaquinaActiva = "";
        private string mIdSolicitudMP = "";
        DataTable mTblDatos = new DataTable();
        DataView mVistaPr = null;
        private string mlValidarSolictud_MP = "";
        DataTable mTblDiametrosMaq = new DataTable();
        string mSoloDiamPermitidos = "N";
        public EventHandler BotonClick;

        public CtlProduccion()
        {
            InitializeComponent();
        }

        private void txtEtiquetaPieza_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEtiquetaPieza_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                this.txtEtiquetaPieza_Validating(null, null);
            }
        }


        private void AjustaColumnaGrilla()
        {
            if (this.dgvEtiquetasPiezas.DataSource != null)
            {
                dgvEtiquetasPiezas.ReadOnly = false;
                dgvEtiquetasPiezas.Enabled = false;
                dgvEtiquetasPiezas.Columns["Obra"].Width = 500;
                dgvEtiquetasPiezas.Columns["idpaquete"].Width = 10;
                dgvEtiquetasPiezas.Columns["diametro"].Width = 20;
                dgvEtiquetasPiezas.Columns["NroPaq"].Width = 30;
                dgvEtiquetasPiezas.Columns["totalpaq"].Width = 40;
                dgvEtiquetasPiezas.Refresh();
                dgvEtiquetasPiezas.ReadOnly = true;
            }

        }
        private void txtEtiquetaPieza_Validating(object sender, CancelEventArgs e)
        {
            string lValidarColadas = ConfigurationManager.AppSettings["ValidaColadaEnProduccion"].ToString();

            string lValidarSolictud_MP = ConfigurationManager.AppSettings["ValidaSolicitud_MP"].ToString();

            if (PuedeProducirEtiqueta() == true)
            {
                //Se debe validar las producciones v/s las solicitudes de material
                WsOperacion.OperacionSoapClient lPxOp = new WsOperacion.OperacionSoapClient();
                WsOperacion.ListaDataSet lDts = new WsOperacion.ListaDataSet();
                string lFecha = DateTime.Now.ToShortDateString().Replace("-", "/");

                if (lValidarSolictud_MP.ToString().ToUpper().Equals("S"))
                {
                    lDts = lPxOp.ObtenerSolicitudesMP_PorTotem(mUserLog.IdTotem.ToString(), lFecha, mUserLog.IdMaquina.ToString(), txtEtiquetaPieza.Text);
                    if (ValidaSolicitud_MP(lDts.DataSet) == true)
                    {
                        if (lValidarColadas.ToUpper().Equals("S"))
                        {
                            RegistraDatosConColadas();
                        }
                        else
                        {
                            RegistraDatosSinColadas();
                        }
                    }
                }
                else
                {
                    if (lValidarColadas.ToUpper().Equals("S"))
                    {
                        RegistraDatosConColadas();
                    }
                    else
                    {
                        RegistraDatosSinColadas();
                    }
                
                }
                AjustaColumnaGrilla();
            }
        }

        private void txtEtiquetaPieza_Leave(object sender, EventArgs e)
        {
            txtEtiquetaPieza.Text = eliminarCaracteresEspeciales(txtEtiquetaPieza.Text.Trim());
        }


#region Metodos Privados de la clase


        private bool ValidaSolicitud_MP(DataSet iDts)
        {
            WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
            WsOperacion.ListaDataSet listaDataSet = new WsOperacion.ListaDataSet();
            int lKilosSolicitados = 0; int lKilosProducidos = 0; int lKilosSaldo = 0;
            bool lRes = true; Clases .ClsComun lcom=new Clases.ClsComun ();int i = 0;
            string lMsg = "";       int lPesoEtiqueta = 0; int lDiam = 0;DataTable lTbl = new DataTable ();
            string lToleranciaSMP= ConfigurationManager.AppSettings["Tolerancia_SMP"].ToString();

            if ((iDts != null) && (iDts.Tables.Count > 1))
            {
                // for (i = 1; i < iDts.Tables["Solicitudes_MP"].Rows.Count; i++)
                if (iDts.Tables["Solicitudes_MP"].Rows.Count > 0)
                {
                    while (i < iDts.Tables["Solicitudes_MP"].Rows.Count)
                    {
                        if (iDts.Tables["Solicitudes_MP"].Rows.Count > 0)
                        {
                            lKilosSolicitados = lcom.Val(iDts.Tables["Solicitudes_MP"].Rows[i]["Det_Kilos_Recep"].ToString());
                            lKilosProducidos = lcom.Val(iDts.Tables["Solicitudes_MP"].Rows[i]["Det_Kilos_producidos"].ToString());
                        }
                        //if (iDts.Tables["KgsProducido"].Rows.Count > 0)
                        //    lKilosProducidos = lcom.Val(iDts.Tables["KgsProducido"].Rows[0][0].ToString());

                        //debemos obtener el peso de la etiqueta para poder realizar los calculos y saber si se puede procesar o no
                        listaDataSet = wsOperacion.ObtenerDatosConsultaGenerica(8, txtEtiquetaPieza.Text, "", "", "", "");

                        DataTable dataTable = listaDataSet.DataSet.Tables[0];
                        if (dataTable.Rows.Count > 0)
                        {
                            lPesoEtiqueta = lcom.Val(dataTable.Rows[0]["PesoPaquete"].ToString());
                            lDiam = int.Parse(dataTable.Rows[0]["Diametro"].ToString());
                            // A los Kilos Solicitados le agregamos la Tolerancia definida
                            if (lcom.Val(lToleranciaSMP) > 0)
                            {
                                lKilosSolicitados= lKilosSolicitados+(lKilosSolicitados* lcom.Val(lToleranciaSMP)/100);
                            }
                            // Fin
                            lKilosSaldo = lKilosSolicitados - (lKilosProducidos + lPesoEtiqueta);

                            if (lKilosSolicitados == 0)
                            {
                                lMsg = string.Concat("No se ha realizado Solicitud de Materia Prima ", Environment.NewLine, "No se puede registrar la Etiqueta Producida");
                                lRes = false;
                                mIdSolicitudMP = "0";
                            }
                            else
                                if (lKilosSaldo < 0)
                            {
                                lMsg = string.Concat("La materia prima solicitada ya ha sido consumida ", Environment.NewLine, "Realice una nueva solicitud ");
                                lRes = false;
                                mIdSolicitudMP = "0";
                            }
                            else
                            {
                                mIdSolicitudMP = iDts.Tables["Solicitudes_MP"].Rows[i]["det_Id"].ToString();
                                i = iDts.Tables["Solicitudes_MP"].Rows.Count;
                                lRes = true;
                                lMsg = "";
                            }
                        }
                        i++;
                    }
                }
                else
                {
                    lMsg = string.Concat("No se ha realizado Solicitud de Materia Prima ", Environment.NewLine, "No se puede registrar la Etiqueta Producida");
                    lRes = false;
                    mIdSolicitudMP = "0";
                }

            }
            else
            {
                lMsg = string.Concat("No se ha realizado Solicitud de Materia Prima ", Environment.NewLine, "No se puede registrar la Etiqueta Producida");
                lRes = false;
                mIdSolicitudMP = "0";
            }
            if (lMsg.Trim().Length > 1)
            {
                if (mIdNotificacion.ToString().Trim().Length == 0)
                {
                    txtEtiquetaPieza.Text = "";
                    MessageBox.Show(lMsg, "Avisos Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    lRes = true;
                }
               
            }
            //else
            //{
            //    //mIdSolicitudMP = iDts.Tables["Solicitudes_MP"].Rows[0]["det_Id"].ToString();           
            //}

            return lRes;
        }


        private bool PuedeProducirEtiqueta()
        {
            bool lEtiquetaImpresa = true ;Clases.ClsComun lCom = new Clases.ClsComun();
            WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
            WsOperacion.ListaDataSet listaDataSet = new WsOperacion.ListaDataSet();
            Ws_TO.Ws_ToSoap lPx = new Ws_TO.Ws_ToSoapClient(); string lSql = "";
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable();

            string lMsg = "Esta etiqueta no ha sido impresa, avisar a su jefe"; string lCuerpoMsg = "";
            //80  verifica la sucursal por la it
            //listaDataSet = wsOperacion.ObtenerDatosConsultaGenerica(80, txtEtiquetaPieza.Text, "", "", "", "");

            //93 verifica la sucursal por la Etiqueta
            listaDataSet = wsOperacion.ObtenerDatosConsultaGenerica(93, txtEtiquetaPieza.Text, "", "", "", "");
            if (listaDataSet.MensajeError.Equals(""))
            {
                if (listaDataSet.DataSet.Tables[0].Rows.Count > 0)
                {
                    lTbl = listaDataSet.DataSet.Tables[0].Copy();
                    // Verificamos que la Etiqueta haya sido Impresa.

                    if (lTbl.Rows[0]["Impresa"].ToString().ToUpper().Equals("N"))
                    {
                        lEtiquetaImpresa = false;
                        // Cuando ocurra esto en pantalla de totem se indicará al operario 
                        // "Esta etiqueta no ha sido impresa, avisar a su jefe", dejando un registro en log   
                        // para ver la ocurrencia aposterior y enviando un correo a la lista definida a continuación.                            
                        //1.- Mostramos el Mensaje 
                        MessageBox.Show(lMsg, "Avisos Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ////2.- Enviamos el Mail de Notificación IdOBra =-400
                        //lCuerpoMsg = string.Concat("Hola estimados: ", Environment.NewLine, " Se ha detectado que la Etiqueta leida NO ha sido impresa", Environment.NewLine);
                        //lCuerpoMsg = string.Concat(lCuerpoMsg, Environment.NewLine, "Los datos recopilados son:");
                        //lCuerpoMsg = string.Concat(lCuerpoMsg, Environment.NewLine, "Fecha :", DateTime.Now.ToShortDateString());
                        //lCuerpoMsg = string.Concat(lCuerpoMsg, Environment.NewLine, "Usuario:", mUserLog.Login);
                        //lCuerpoMsg = string.Concat(lCuerpoMsg, Environment.NewLine, "Viaje:", lTbl.Rows[0]["Codigo"].ToString());
                        //lCuerpoMsg = string.Concat(lCuerpoMsg, Environment.NewLine, "Id Totem:", mUserLog.IdTotem);
                        //lCuerpoMsg = string.Concat(lCuerpoMsg, Environment.NewLine, "Máquina:", mUserLog.IdMaquina);
                        //lCuerpoMsg = string.Concat(lCuerpoMsg, Environment.NewLine, "Número de Etiqueta:", lTbl.Rows[0]["Etiqueta"].ToString());
                        //lPx.EnviaNotificacionesEnviaMsgDeNotificacion("Etiqueta", lCuerpoMsg, -400, "Etiqueta Producida Sin estar Impresa");
                        //3.- Insertamos en la Tabla de Log
                        // listaDataSet = wsOperacion.ObtenerDatosConsultaGenerica(8, txtEtiquetaPieza.Text, "", "", "", "");
                        //lSql = string.Concat("SP_Consultas_WS 54,'", mUserLog.Iduser, "','", mUserLog.IdTotem, "','", lTbl.Rows[0]["Etiqueta"].ToString(), "','");
                        //lSql = string.Concat(lSql, lTbl.Rows[0]["Codigo"].ToString(), "','", txtEtiquetaPieza.Text, "'");
                        
                        //lDts = lPx.ObtenerDatos(lSql);
                    }
                    // Verificamos que se este pistolemado la etiqueta en la sucursal Programada.
                    // Obtenemos las variables de sesion Sucursal e IdSucursal
                    string lIdSucursal = ConfigurationManager.AppSettings["IdSucursal"].ToString();
                    string lSucursal = ConfigurationManager.AppSettings["Sucursal"].ToString();
                    if (!(lTbl.Rows[0]["IdSucursal"].ToString().ToUpper().Equals(lIdSucursal)))
                    {
                        lEtiquetaImpresa = false;
                        lMsg = string.Concat("Esta etiqueta No puede ser producida, ya que esta asignada a la sucursal de ", lTbl.Rows[0]["SucursalAsiganda"].ToString().ToUpper() , Environment.NewLine);
                        lMsg = string.Concat(lMsg," Este Tótem esta configurado como Sucursal ", lSucursal, Environment.NewLine);
                        MessageBox.Show(lMsg, "Avisos Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    // Verificamos que la maquina pistolee solo los  diametros permitidos
                    if (mSoloDiamPermitidos.ToUpper ().ToString ().Equals ("S"))
                    {
                        //pasos   1.- Identificar el díametro de la etiqueta leida
                        string lDiam = lTbl.Rows[0]["Diametro"].ToString();
                        string lMaq = mUserLog.IdMaquina.ToString();string lWheres = "";
                        //2.- Obtener los diametros permitidos por maquina.
                        lWheres = string.Concat(" MAQ_NRO=",lMaq , " and diametro='",lDiam ,"'");
                        DataView lVista = new DataView(mTblDiametrosMaq, lWheres, "", DataViewRowState.CurrentRows);
                        if (lVista.Count == 0)  //El diametro no esta permitido.
                        {
                            lWheres = string.Concat(" MAQ_NRO=", lMaq);
                            DataView lVistaDiam = new DataView(mTblDiametrosMaq, lWheres, "", DataViewRowState.CurrentRows);
                            int i = 0; string lDiamPermitidos = "";
                            for (i = 0; i < lVistaDiam.Count; i++)
                            {
                                lDiamPermitidos = string.Concat(lVistaDiam[i]["diametro"], "-", lDiamPermitidos);
                            }
                            lDiamPermitidos = lDiamPermitidos.Substring(0, lDiamPermitidos.Length - 1);
                            MessageBox.Show(string.Concat(" Los diámetros permitidos en esta máquina son: ", lDiamPermitidos), "Avisos Sistema", MessageBoxButtons.OK);
                            lEtiquetaImpresa = false;
                            txtEtiquetaPieza.Text = "";
                        }
                    }
                    //****************************************************************************************
                    if ((txtEtiquetaColada.Text.Trim ().Length >0) && (lCom.Val (txtEtiquetaColada.Text )<0 ))
                    {
                        //pasos   2.- si el campo tiene dato debe ser numero
                       
                            MessageBox.Show(string.Concat(" El número ingresado en el campo Colada NO es Válido, Revisar el número de Colada"), "Avisos Sistema", MessageBoxButtons.OK);
                            lEtiquetaImpresa = false;
                              txtEtiquetaColada.Text = "";
                      }
                }
            }
            return lEtiquetaImpresa;
        }

        private string eliminarCaracteresEspeciales(string entrada)
        {
            StringUtility stringUtility = new StringUtility();
            string salida = entrada;
            if (!salida.Trim().Equals(""))
                salida = stringUtility.removeInvalidCharacters(salida, stringUtility.RegexPattern_Address);
            return salida;
        }


        private void RegistraPiezaProducida(string iColada, string iPieza, int iNroPiezas, CurrentUser iUser, int iNroPiezasProd)
        {
            WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
            WsOperacion.Pieza pieza = new WsOperacion.Pieza(); int lIdUser = 0;
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient(); DataSet lDts = new DataSet();
            string lSql = ""; Clases.ClsComun lCom = new Clases.ClsComun();
            pieza.Colada = iColada;
            pieza.Etiqueta = iPieza;
            //row.Cells[COLUMNNAME_ETIQUETA_PIEZA].Value.ToString();
            pieza.Estado = "O40";
            lIdUser = int.Parse(mIdUser);
            pieza = wsOperacion.RegistrarPasoaProduccionPieza(pieza, Program.currentUser.IdMaquina, Program.currentUser.Login, Program.currentUser.ComputerName, 0, lIdUser);
            //pieza = wsOperacion.RegistrarPasoaProduccionPieza(pieza, Program.currentUser.Machine, Program.currentUser.Login, Program.currentUser.ComputerName);
            if (pieza.MensajeError.Equals(""))
            {
                //grabados el detalle
                lSql = string.Concat(" exec SP_CRUD_PaquetesProducidos 0,", iPieza, ",", iUser.IdMaquina, ",");
                lSql = string.Concat(lSql, iUser.Iduser, ",0,", iNroPiezas, ",", lCom.Val(iColada), ",", iNroPiezasProd);
                lSql = string.Concat(lSql, ",1");
                lDts = lPx.ObtenerDatos(lSql);
                //---------------------------
                //02-07-2014 Por medificaciones funcionales se puede vincular  a un paquete muchas coladas            

                lSql = string.Concat(" exec SP_CRUD_COLADASPAQUETE 0,", iPieza, ",", iPieza, ",");
                lSql = string.Concat(lSql, lCom.Val(iColada), ",", iUser.Iduser, ",", iUser.IdMaquina, ",1");
                lDts = lPx.ObtenerDatos(lSql);

                //this.lbl_Res.Text = " La Etiqueta " + iPieza + " fue grabada Correctamente ";
                //this.Close();
                if (lCom.Val(mIdSolicitudMP) > 0)
                { 
                    lSql = string.Concat(" Update DetallePaquetesPieza set IdSolicitudMP=", mIdSolicitudMP, " Where id=", pieza.Etiqueta);
                    lDts = lPx.ObtenerDatos(lSql);
                    lSql = string.Concat(" SP_Consultas_WS 66, '", mIdSolicitudMP,"', '", pieza.Etiqueta,"', '', '', '', '', ''");
                    lDts = lPx.ObtenerDatos(lSql);

                }
            }
            else
            {
                //this.lbl_Res.Text = " La Etiqueta " + iPieza + " ha registrado un error, repita la operación ";
                MessageBox.Show(pieza.MensajeError.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void RegistraDatosConColadas()
        {
            DataGridView dgvActiva = null; bool lPuedeContinuar = false;
            Forms forms = new Forms(); string diametro = "";
            WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
            WsOperacion.ListaDataSet listaDataSet = new WsOperacion.ListaDataSet();

            if (!txtEtiquetaPieza.Text.Trim().Equals(""))
            {
                switch (tabOperaciones.SelectedIndex)
                {
                    case 0:
                        dgvActiva = dgvEtiquetasPiezas;
                        break;
                    case 1:
                        dgvActiva = dgvEtiquetasPiezasExcepciones;
                        break;
                }
                if (dgvActiva != null)
                {
                    if (forms.dataGridViewSearchText(dgvActiva, COLUMNNAME_ETIQUETA_PIEZA, txtEtiquetaPieza.Text) == -1)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        try
                        {
                            //listaDataSet = wsOperacion.ObtenerPieza(Convert.ToInt32(txtEtiquetaPieza.Text));
                            //22/05/2013 por solicitud de TO, para los datos a visualizar 
                            listaDataSet = wsOperacion.ObtenerDatosConsultaGenerica(8, txtEtiquetaPieza.Text, "", "", "", "");
                            if (listaDataSet.MensajeError.Equals(""))
                            {
                                if (listaDataSet.DataSet.Tables[0].Rows.Count > 0)
                                {
                                    //verificamos que el paquete no este  despachado
                                    if (PaqueteEstaProducido(listaDataSet.DataSet.Tables[0].Copy()) == false)
                                    {
                                        //Verifica que la colada y la pieza tengan el mismo diametro
                                        //Se desactiva la restriccion por marcha blanca 07/04/2014
                                        diametro = listaDataSet.DataSet.Tables[0].Rows[0]["DIAMETRO"].ToString();

                                        //if (lblDiametro.Text.Equals(diametro))
                                        //{
                                        if (Chk_MultiplesColadas.Checked == true)
                                        {
                                            ////abrimos el formulario para registrar las  coladas
                                            FrmConfirmaPieza lFrom = new FrmConfirmaPieza();
                                            lFrom.IniciaForm(int.Parse(txtEtiquetaPieza.Text), int.Parse(listaDataSet.DataSet.Tables[0].Rows[0]["PiezasPaq"].ToString()), Program.currentUser, txtEtiquetaColada.Text, diametro);
                                            lFrom.ShowDialog();
                                            if (lFrom.mPiezaProducida.ToUpper().Equals("S"))
                                                lPuedeContinuar = true;
                                            else
                                                lPuedeContinuar = false;
                                        }
                                        else
                                        {
                                            ////actualizamos los datos en el servidor
                                            if (lblDiametro.Text.Equals(diametro))
                                            {
                                                double lPesoEtiqueta = 0;
                                                listaDataSet = wsOperacion.ObtenerDatosConsultaGenerica(8, txtEtiquetaPieza.Text, "", "", "", "");
                                                DataTable dataTable = listaDataSet.DataSet.Tables[0];
                                                if (dataTable.Rows.Count > 0)
                                                {
                                                    lPesoEtiqueta = double.Parse(dataTable.Rows[0]["PesoPaquete"].ToString());
                                                    //dataTable.Rows[0][COLUMNNAME_ESTADO] = (tabOperaciones.SelectedIndex == 0 ? "" : cboExcepciones.SelectedValue.ToString());
                                                    //dataTable.Rows[0][COLUMNNAME_PIE_ESTADO] = cboExcepciones.SelectedValue.ToString();
                                                    //dataTable.Rows[0][COLUMNNAME_ESTADO] = cboExcepciones.Text;
                                                }

                                                //validamos los kilos de la colada con los kilos ya producidos
                                                //Se comenta ya que aun no esta 100% en funcionamiento Recepción de colada
                                                //Cuando el Modulo este OK se debe descomentar la siguiente seccion
                                                //***********************************************************************************
                                                if (Lbl_KgsProd.Text.Trim().Length == 0)
                                                    Lbl_KgsProd.Text = "0";

                                                double KgsProducidos = double.Parse(Lbl_KgsProd.Text) + lPesoEtiqueta;
                                                double LimiteKgs = double.Parse(ConfigurationManager.AppSettings["LimiteKgs"].ToString()) + 1;
                                                double KgsColada = double.Parse(this.lblKilos.Text); double KgsTmp = Math.Abs(KgsColada - KgsProducidos);

                                                //if (mTotalKilos + double.Parse(row["PesoPaquete"].ToString()) > double.Parse(this.lblKilos.Text))
                                                if (mTotalKilos + lPesoEtiqueta > double.Parse(this.lblKilos.Text))
                                                {
                                                    if (KgsTmp < LimiteKgs)
                                                    {

                                                        int lPiezasPaq = (int)listaDataSet.DataSet.Tables[0].Rows[0]["PiezasPaq"];
                                                        RegistraPiezaProducida(mIdEtiquetaColada, txtEtiquetaPieza.Text, lPiezasPaq, mUserLog, lPiezasPaq);
                                                        //RegistraPiezaProducida(txtEtiquetaColada.Text, txtEtiquetaPieza.Text, lPiezasPaq, mUserLog, lPiezasPaq);
                                                        lPuedeContinuar = true;
                                                        string lMsgLim = (Math.Abs(double.Parse(Lbl_SaldoKilosColada.Text) - LimiteKgs)).ToString();
                                                        MessageBox.Show(string.Concat("La Kilos Producidos son Superiores a los de la colada, queda de limite ", lMsgLim), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("Se ha sobrepasado el Exceso de Kilos de la  colada ", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                        lPuedeContinuar = false;
                                                    }
                                                }
                                                else
                                                {
                                                    int lPiezasPaq = (int)listaDataSet.DataSet.Tables[0].Rows[0]["PiezasPaq"];
                                                    //
                                                    RegistraPiezaProducida(mIdEtiquetaColada, txtEtiquetaPieza.Text, lPiezasPaq, mUserLog, lPiezasPaq);
                                                    //RegistraPiezaProducida(txtEtiquetaColada.Text, txtEtiquetaPieza.Text, lPiezasPaq, mUserLog, lPiezasPaq);
                                                    lPuedeContinuar = true;
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("La etiqueta '" + txtEtiquetaPieza.Text + "' tiene un diametro (" + diametro + ") distinto al de la colada.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                lPuedeContinuar = false;
                                            }
                                        }
                                        if (lPuedeContinuar == true)
                                        {
                                            if (dgvActiva.DataSource == null)
                                            {
                                                listaDataSet = wsOperacion.ObtenerDatosConsultaGenerica(8, txtEtiquetaPieza.Text, "", "", "", "");
                                                DataTable dataTable = listaDataSet.DataSet.Tables[0];
                                                if (dataTable.Rows.Count > 0)
                                                {
                                                    //dataTable.Rows[0][COLUMNNAME_ESTADO] = (tabOperaciones.SelectedIndex == 0 ? "" : cboExcepciones.SelectedValue.ToString());
                                                    dataTable.Rows[0][COLUMNNAME_PIE_ESTADO] = cboExcepciones.SelectedValue.ToString();
                                                    dataTable.Rows[0][COLUMNNAME_ESTADO] = cboExcepciones.Text;
                                                }
                                                                                       

                                                mTblDatos = dataTable.Copy();
                                                //dgvActiva.DataSource = dataTable;
                                                mVistaPr = new DataView(mTblDatos, "", "FechaProduccion desc", DataViewRowState.CurrentRows);
                                                dgvActiva.DataSource = mVistaPr;
                                               
                                            }
                                            else
                                            {
                                                //DataTable dataTable = (DataTable)dgvActiva.DataSource;
                                                //DataRow row = dataTable.NewRow();
                                                listaDataSet = wsOperacion.ObtenerDatosConsultaGenerica(8, txtEtiquetaPieza.Text, "", "", "", "");
                                                DataRow row = mTblDatos.NewRow();
                                                foreach (DataGridViewColumn column in dgvActiva.Columns)
                                                {
                                                    row[column.Index] = listaDataSet.DataSet.Tables[0].Rows[0][column.Index];
                                                }

                                                row[COLUMNNAME_PIE_ESTADO] = cboExcepciones.SelectedValue.ToString();
                                                row[COLUMNNAME_ESTADO] = cboExcepciones.Text;
                                                mTotalKilos = mTotalKilos + double.Parse(row["PesoPaquete"].ToString());
                                                //dataTable.Rows.Add(row);
                                                mTblDatos.Rows.Add(row);
                                            }
                                            //tlbNuevo.PerformClick();
                                            //Forms forms = new Forms();
                                            if (tabOperaciones.SelectedIndex == 0)
                                                forms.dataGridViewHideColumns(dgvEtiquetasPiezas, new string[] { "ERR", "PIE_ESTADO", "ESTADO" });
                                            else
                                                forms.dataGridViewHideColumns(dgvEtiquetasPiezasExcepciones, new string[] { "ERR", "PIE_ESTADO" });

                                            forms.dataGridViewAutoSizeColumnsMode(dgvEtiquetasPiezas, DataGridViewAutoSizeColumnsMode.DisplayedCells);
                                            //tlbEstado.Text = "Registro(s): " + dgvRecepciones.Rows.Count;
                                            lblCantidadEtiquetasPiezas.Text = "Registro(s): " + dgvEtiquetasPiezas.Rows.Count;
                                            lblCantidadEtiquetasPiezasExcepciones.Text = "Registro(s): " + dgvEtiquetasPiezasExcepciones.Rows.Count;
                                            //txtEtiquetaPieza.Text = (int.Parse(txtEtiquetaPieza.Text) + 1).ToString() ;                                           

                                        }
                                        //}
                                        //else
                                        //    MessageBox.Show("La etiqueta '" + txtEtiquetaPieza.Text + "' tiene un diametro (" + diametro + ") distinto al de la colada.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }

                                else
                                    MessageBox.Show("La etiqueta '" + txtEtiquetaPieza.Text + "' no existe.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                                MessageBox.Show(listaDataSet.MensajeError.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        catch (Exception exc)
                        {
                            MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        Cursor.Current = Cursors.Default;
                    }
                    else
                    {

                    }
                  
                    if (mIdEtiquetaColada.ToString().Trim().Length > 0)
                    //if (txtEtiquetaColada.Text.Trim().Length > 0)
                    {
                        listaDataSet = wsOperacion.ObtenerDatosProduccionPorColada(mIdEtiquetaColada);
                        //listaDataSet = wsOperacion.ObtenerDatosProduccionPorColada(txtEtiquetaColada.Text);
                        if (listaDataSet.MensajeError.Equals(""))
                        {
                            if (listaDataSet.DataSet.Tables[0].Rows.Count > 0)
                            {
                                Lbl_SaldoKilosColada.Text = listaDataSet.DataSet.Tables[0].Rows[0]["SaldoKiloscolada"].ToString();
                                Lbl_KgsProd.Text = listaDataSet.DataSet.Tables[0].Rows[0]["Kilosproducidos"].ToString();
                                Lbl_NroPiezas.Text = listaDataSet.DataSet.Tables[0].Rows[0]["PiezasProducidas"].ToString();
                                Lbl_NroEtiq.Text = listaDataSet.DataSet.Tables[0].Rows[0]["NroEtiquetas"].ToString();
                            }
                            else
                            {
                                Lbl_SaldoKilosColada.Text = lblKilos.Text;
                            }
                        }
                    }
                    ActualizaKilosProducidos();
                    txtEtiquetaPieza.Clear();
                    txtEtiquetaPieza.Focus();
                }
            }
            //lblKilos.Text = dt.Rows[0]["KILOS"].ToString();
            //01/11/2014 Segun proyecto de muestreo se agrega llamada
            //VerificaMuestreo(diametro);

        }


        private void RegistraDatosSinColadas()
        {
            DataGridView dgvActiva = null; bool lPuedeContinuar = false;
            Forms forms = new Forms(); string diametro = "";
            WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
            WsOperacion.ListaDataSet listaDataSet = new WsOperacion.ListaDataSet(); string iDiam = "";

            if (!txtEtiquetaPieza.Text.Trim().Equals(""))
            {
                switch (tabOperaciones.SelectedIndex)
                {
                    case 0:
                        dgvActiva = dgvEtiquetasPiezas;
                        break;
                    case 1:
                        dgvActiva = dgvEtiquetasPiezasExcepciones;
                        break;
                }
                if (dgvActiva != null)
                {
                    if (forms.dataGridViewSearchText(dgvActiva, COLUMNNAME_ETIQUETA_PIEZA, txtEtiquetaPieza.Text) == -1)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        try
                        {

                            //listaDataSet = wsOperacion.ObtenerPieza(Convert.ToInt32(txtEtiquetaPieza.Text));
                            //22/05/2013 por solicitud de TO, para los datos a visualizar 
                            listaDataSet = wsOperacion.ObtenerDatosConsultaGenerica(8, txtEtiquetaPieza.Text, "", "", "", "");
                            if (listaDataSet.MensajeError.Equals(""))
                            {
                                if (listaDataSet.DataSet.Tables[0].Rows.Count > 0)
                                {
                                    //verificamos que el paquete no este  despachado
                                    if (PaqueteEstaProducido(listaDataSet.DataSet.Tables[0].Copy()) == false)
                                    {
                                        double lPesoEtiqueta = 0;
                                        //listaDataSet = wsOperacion.ObtenerDatosConsultaGenerica(8, txtEtiquetaPieza.Text, "", "", "", "");
                                        DataTable dataTable = listaDataSet.DataSet.Tables[0];
                                        if (dataTable.Rows.Count > 0)
                                        {
                                            lPesoEtiqueta = double.Parse(dataTable.Rows[0]["PesoPaquete"].ToString());
                                        }
                                        int lPiezasPaq = (int)listaDataSet.DataSet.Tables[0].Rows[0]["PiezasPaq"];
                                        RegistraPiezaProducida(mIdEtiquetaColada, txtEtiquetaPieza.Text, lPiezasPaq, mUserLog, lPiezasPaq);
                                        //RegistraPiezaProducida(txtEtiquetaColada.Text, txtEtiquetaPieza.Text, lPiezasPaq, mUserLog, lPiezasPaq);
                                        lPuedeContinuar = true;
                                    }
                                    if (lPuedeContinuar == true)
                                    {
                                        if (dgvActiva.DataSource == null)
                                        {
                                            listaDataSet = wsOperacion.ObtenerDatosConsultaGenerica(8, txtEtiquetaPieza.Text, "", "", "", "");
                                            DataTable dataTable = listaDataSet.DataSet.Tables[0];
                                            if (dataTable.Rows.Count > 0)
                                            {
                                                //dataTable.Rows[0][COLUMNNAME_ESTADO] = (tabOperaciones.SelectedIndex == 0 ? "" : cboExcepciones.SelectedValue.ToString());
                                                dataTable.Rows[0][COLUMNNAME_PIE_ESTADO] = cboExcepciones.SelectedValue.ToString();
                                                dataTable.Rows[0][COLUMNNAME_ESTADO] = cboExcepciones.Text;
                                            }
                                            //mTotalKilos =double.Parse (dataTable.Rows[0]["Pesopaquete"].ToString ());                                            
                                            mTblDatos = dataTable.Copy();
                                            //dgvActiva.DataSource = dataTable;
                                            mVistaPr = new DataView(mTblDatos, "", "FechaProduccion desc", DataViewRowState.CurrentRows);
                                            dgvActiva.DataSource = mVistaPr;
                                            dgvActiva.Columns["Obra"].Width = 500;
                                        }
                                        else
                                        {
                                            //DataTable dataTable = (DataTable)dgvActiva.DataSource;
                                            //DataRow row = dataTable.NewRow();
                                            listaDataSet = wsOperacion.ObtenerDatosConsultaGenerica(8, txtEtiquetaPieza.Text, "", "", "", "");
                                            DataRow row = mTblDatos.NewRow();

                                            foreach (DataGridViewColumn column in dgvActiva.Columns)
                                            {
                                                row[column.Index] = listaDataSet.DataSet.Tables[0].Rows[0][column.Index];
                                            }

                                            row[COLUMNNAME_PIE_ESTADO] = cboExcepciones.SelectedValue.ToString();
                                            row[COLUMNNAME_ESTADO] = cboExcepciones.Text;
                                            mTotalKilos = mTotalKilos + double.Parse(row["PesoPaquete"].ToString());
                                            //dataTable.Rows.Add(row);
                                            mTblDatos.Rows.Add(row);
                                        }
                                        //tlbNuevo.PerformClick();
                                        //Forms forms = new Forms();
                                        if (tabOperaciones.SelectedIndex == 0)
                                            forms.dataGridViewHideColumns(dgvEtiquetasPiezas, new string[] { "ERR", "PIE_ESTADO", "ESTADO" });
                                        else
                                            forms.dataGridViewHideColumns(dgvEtiquetasPiezasExcepciones, new string[] { "ERR", "PIE_ESTADO" });

                                        forms.dataGridViewAutoSizeColumnsMode(dgvEtiquetasPiezas, DataGridViewAutoSizeColumnsMode.DisplayedCells);
                                        //tlbEstado.Text = "Registro(s): " + dgvRecepciones.Rows.Count;
                                        lblCantidadEtiquetasPiezas.Text = "Registro(s): " + dgvEtiquetasPiezas.Rows.Count;
                                        lblCantidadEtiquetasPiezasExcepciones.Text = "Registro(s): " + dgvEtiquetasPiezasExcepciones.Rows.Count;
                                        //txtEtiquetaPieza.Text = (int.Parse(txtEtiquetaPieza.Text) + 1).ToString() ;                                           

                                    }
                                    //}
                                    //else
                                    //    MessageBox.Show("La etiqueta '" + txtEtiquetaPieza.Text + "' tiene un diametro (" + diametro + ") distinto al de la colada.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }

                            else
                                MessageBox.Show("La etiqueta '" + txtEtiquetaPieza.Text + "' no existe.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //}
                            //else
                            //    MessageBox.Show(listaDataSet.MensajeError.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        catch (Exception exc)
                        {
                            MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        Cursor.Current = Cursors.Default;
                    }
                    else
                    {

                    }
                    // WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
                    // WsOperacion.ListaDataSet listaDataSet = new WsOperacion.ListaDataSet();
                    //
                    if (mIdEtiquetaColada.ToString().Trim().Length > 0)
                    //if (txtEtiquetaColada.Text.Trim().Length > 0)
                    {
                        listaDataSet = wsOperacion.ObtenerDatosProduccionPorColada(mIdEtiquetaColada);
                        //listaDataSet = wsOperacion.ObtenerDatosProduccionPorColada(txtEtiquetaColada.Text);
                        if (listaDataSet.MensajeError.Equals(""))
                        {
                            if (listaDataSet.DataSet.Tables[0].Rows.Count > 0)
                            {
                                Lbl_SaldoKilosColada.Text = listaDataSet.DataSet.Tables[0].Rows[0]["SaldoKiloscolada"].ToString();
                                Lbl_KgsProd.Text = listaDataSet.DataSet.Tables[0].Rows[0]["Kilosproducidos"].ToString();
                                Lbl_NroPiezas.Text = listaDataSet.DataSet.Tables[0].Rows[0]["PiezasProducidas"].ToString();
                                Lbl_NroEtiq.Text = listaDataSet.DataSet.Tables[0].Rows[0]["NroEtiquetas"].ToString();
                            }
                            else
                            {
                                Lbl_SaldoKilosColada.Text = lblKilos.Text;
                            }
                        }
                    }
                    ActualizaKilosProducidos();
                    txtEtiquetaPieza.Clear();
                    txtEtiquetaPieza.Focus();
                }
            }
            //lblKilos.Text = dt.Rows[0]["KILOS"].ToString();
            //01/11/2014 Segun proyecto de muestreo se agrega llamada
            //VerificaMuestreo(diametro);

        }

        private void ActualizaKilosProducidos()
        {
            WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
            WsOperacion.ListaDataSet listaDataSet = new WsOperacion.ListaDataSet();
            string lMaq = mUserLog.IdMaquina.ToString();
            string lUser = mUserLog.Login.ToString();

            listaDataSet = wsOperacion.ObtenerDatosConsultaGenerica(9, lMaq, lUser, "", "", "");
            if (listaDataSet.MensajeError.Equals(""))
            {
                if (listaDataSet.DataSet.Tables[0].Rows.Count > 0)
                {
                    Lbl_MsgKgsProd.Text = string.Concat("Total Kilos producidos durante el día: ", listaDataSet.DataSet.Tables[0].Rows[0][0].ToString());
                }

            }
            //Lbl_MsgKgsProd.Visible = false;
        }

        private void VerificaMuestreo(string iDiametro)
        {
            //        ALTER  PROCEDURE [dbo].[SP_CRUD_MUESTREOS]
            //@ID INT,                  //@FechaInicio VARCHAR(10),     //@FechaFin VARCHAR(10) ,    //@Diametro int,
            //@Estado VARCHAR(20),      //@KilosMuestreo int,	        //@OPCION INT

            int lIdMuestreo = 0; DataSet lDts = new DataSet(); string lSql = ""; int lKgsMuestreo = 0;
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient(); int lKgsProd = 0; Clases.ClsComun lCom = new Clases.ClsComun();
            DataTable mTblMuestreo = new DataTable();

            //Revisamos que exista un muestreo para el diametro ingresado
            if (lCom.EsNumero(iDiametro) == true)
            {
                lSql = string.Concat("exec SP_CRUD_MUESTREOS  0,'','',", iDiametro, ",'',0,2");
                lDts = lPx.ObtenerDatos(lSql);
                if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                {
                    mTblMuestreo = lDts.Tables[0].Copy();
                    lIdMuestreo = (int)lDts.Tables[0].Rows[0]["Id"];
                    lKgsMuestreo = (int)lDts.Tables[0].Rows[0]["KilosMuestreo"];
                    if (lIdMuestreo > 0)  // si existe un muetreo verificamos los kilos que lleva
                    {
                        lSql = string.Concat("exec SP_CRUD_MUESTREOS ", lIdMuestreo, ",'','',0,'',0,4");
                        lDts = new DataSet();
                        lDts = lPx.ObtenerDatos(lSql);
                        if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                        {

                            lKgsProd = (int)lDts.Tables[0].Rows[0][0];
                        }
                        //Comparamos
                        //La regla es que si los Kilos Producidos son mayor que lo kilos del muestreo, debe abrir
                        //una pantalla indicando que se debe tomar la muestra de material
                        // 08/09/2014
                        lKgsProd = 33000;
                        if (lKgsProd > lKgsMuestreo)
                        {
                            Muestreo.Frm_SolicitaMuestreo lFrm = new Muestreo.Frm_SolicitaMuestreo();
                            lFrm.CargaDatos(mTblMuestreo, mUserLog, lKgsProd.ToString());
                            lFrm.ShowDialog(this);
                        }
                    }
                }
            }
            //A partir del diametro de la pieza:  si hay un muestreo vigente ==> Obtener su Id
            //                else: Insertar una muestreo nuevo y obtener su id






        }

        private WsOperacion.ListaDataSet ObtenerColadasPorId(string IdColada)
        {
            Ws_TO.Ws_ToSoapClient ldal = new Ws_TO.Ws_ToSoapClient();
            WsOperacion.ListaDataSet listaDataSet = new WsOperacion.ListaDataSet();
            string lSql = "";
            try
            {
                listaDataSet.MensajeError = "";
                //  [SP_ConsultasGenerales] @Opcion INT,  @Par1 Varchar(100),  @Par2 Varchar(100),  @Par3 Varchar(100),
                //@Par4 Varchar(100),     @Par5 Varchar(100)

                lSql = string.Concat("exec SP_ConsultasGenerales 25,'", IdColada.ToString(), "','','','',''");
                listaDataSet.DataSet = ldal.ObtenerDatos(lSql);
            }
            catch (Exception exc)
            {
                listaDataSet.MensajeError = exc.Message.ToString();
            }
            return listaDataSet;
        }


        private bool PaqueteEstaProducido(DataTable iTblPaquete)
        {
            bool lRes = false;
            if (iTblPaquete.Rows[0]["Pie_estado"].ToString().ToUpper().Equals("O60"))
            {
                //this.lbl_Res.Text = " La Etiqueta " + iPieza + " ha registrado un error, repita la operación ";
                lRes = true;
                MessageBox.Show("Esta etiqueta fue despachada, avisar a supervisor ", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //"Esta etiqueta fue despachada, avisar a supervisor".
            }

            //this.lbl_Res.Text = " La Etiqueta " + iPieza + " ha registrado un error, repita la operación ";
            // MessageBox.Show("Se ha Producido el siguiente error: " + pieza.MensajeError.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return lRes;
        }

        private string validarControlesRequeridos()
        {
            StringBuilder sb = new StringBuilder();
            //quitamos de forma temporal lavalidacion
            //if (txtEtiquetaColada.Text.Trim().Equals(""))
            //    sb.Append("- Colada\n");

            if (dgvEtiquetasPiezas.Rows.Count == 0 && dgvEtiquetasPiezasExcepciones.Rows.Count == 0)
                sb.Append("- Pieza(s)\n");
            //        break;
            //}
            return sb.ToString();
        }

        

#endregion


        #region Metodos Publicos de la Clase


        public  void VerificaEstadoMaquina(string lIdMaquina)
        {
            //           [SP_CRUD_NOTIFICACION_AVERIA]  @Id int,
            //@IdOperador int,                  //@TipoMaquina varchar(50) ,	//@TextoIncidencia varchar(max) ,
            //@MailEnviado varchar(1) ,         //@IdUserCrea int   ,           //@Estado varchar(50),
            //@IdMaquina int,                   //@EstadoMaq varchar(10),       //@Opcion int 

            Ws_TO.Ws_ToSoapClient ldal = new Ws_TO.Ws_ToSoapClient();
            WsOperacion.ListaDataSet listaDataSet = new WsOperacion.ListaDataSet();
            string lSql = ""; string lMsg = ""; Btn_Desbloquea.Visible = false;
            try
            {
                listaDataSet.MensajeError = "";

                lSql = string.Concat("exec  SP_CRUD_NOTIFICACION_AVERIA 0,0,'','','',0,'',", lIdMaquina, ",'',3 ");
                listaDataSet.DataSet = ldal.ObtenerDatos(lSql);
                if ((listaDataSet.DataSet.Tables.Count > 0) && (listaDataSet.DataSet.Tables[0].Rows.Count > 0))
                {
                    mEstadoMaquina = listaDataSet.DataSet.Tables[0].Rows[0]["EstadoMaq"].ToString().ToUpper();
                    if (listaDataSet.DataSet.Tables[0].Rows[0]["TextoIncidencia"].ToString().Equals("Cambio de Rollo"))
                    { mTipoAveria = "CB"; }
                    else
                    { mTipoAveria = "AV"; }

                    if (mEstadoMaquina.ToUpper().Equals("DET"))
                    {
                        mIdNotificacion = listaDataSet.DataSet.Tables[0].Rows[0]["Id"].ToString();
                        mMsgMaquina = string.Concat(" El Tótem Esta asociado a la Maquina ", listaDataSet.DataSet.Tables[0].Rows[0]["Maquina"].ToString());
                        mMsgMaquina = string.Concat(mMsgMaquina, " La cual se encuentra en estado Detenida ", Environment.NewLine);
                        mMsgMaquina = string.Concat(mMsgMaquina, " Por notificación del Usuario: ", listaDataSet.DataSet.Tables[0].Rows[0]["Nombre"].ToString(), Environment.NewLine);
                        mMsgMaquina = string.Concat(mMsgMaquina, " Con el motivo de: ", listaDataSet.DataSet.Tables[0].Rows[0]["TextoIncidencia"].ToString(), Environment.NewLine);
                        mMsgMaquina = string.Concat(mMsgMaquina, " La notificación se realizo con fecha:  ", listaDataSet.DataSet.Tables[0].Rows[0]["FechaRegistro"].ToString(), Environment.NewLine);
                        groupBox1.Enabled = false;
                        tabOperaciones.Enabled = false;
                        //tlsToolBar.Enabled = false;
                        lbl_MsgBloqueo.Text = mMsgMaquina;
                        lbl_MsgBloqueo.Top = groupBox1.Top; lbl_MsgBloqueo.Left = groupBox1.Left;
                        lbl_MsgBloqueo.Width = groupBox1.Width; lbl_MsgBloqueo.Height = groupBox1.Height;
                        lbl_MsgBloqueo.Visible = true;
                        txtEtiquetaPieza.Enabled = false;
                        Chk_MultiplesColadas.Enabled = false;
                        groupBox2.Visible = false;
                        Btn_CheckList.Visible = false;
                        Btn_Desbloquea.Visible = true;

                        this.Refresh();
                    }
                    else
                    {
                        if ((listaDataSet.DataSet.Tables[0].Rows[0]["EstadoSupervisor"].ToString().Equals("NOOK")) && (mTipoAveria.ToUpper().Equals("AV")) && listaDataSet.DataSet.Tables[0].Rows[0]["Estado"].ToString().Equals("DET"))
                        {
                            mIdNotificacion = listaDataSet.DataSet.Tables[0].Rows[0]["Id"].ToString();
                            mMsgMaquina = string.Concat(" El Tótem Esta asociado a la Maquina ", listaDataSet.DataSet.Tables[0].Rows[0]["Maquina"].ToString());
                            mMsgMaquina = string.Concat(mMsgMaquina, " Ha sido reparada, pero falta el OK por el supervisor de turno ", Environment.NewLine);
                            mMsgMaquina = string.Concat(mMsgMaquina, " Para que quede operativa el supervisor debe validar la mantención ", Environment.NewLine);
                            groupBox1.Enabled = false;
                            tabOperaciones.Enabled = false;
                           // tlsToolBar.Enabled = false;
                            lbl_MsgBloqueo.Text = mMsgMaquina;
                            lbl_MsgBloqueo.Top = groupBox1.Top; lbl_MsgBloqueo.Left = groupBox1.Left;
                            lbl_MsgBloqueo.Width = groupBox1.Width; lbl_MsgBloqueo.Height = groupBox1.Height;
                            lbl_MsgBloqueo.Visible = true;
                            txtEtiquetaPieza.Enabled = false;
                            Chk_MultiplesColadas.Enabled = false;
                            groupBox2.Visible = false;
                            Btn_CheckList.Visible = false;
                            //groupBox1.Visible = false;
                            if (mUserLog.PerfilUsuario.ToUpper().Equals("SUPERVISOR"))
                            {
                                Btn_Desbloquea.Text = "Liberar Totém ";
                            }

                            Btn_Desbloquea.Visible = true;
                            this.Refresh();
                        }
                        else
                        {
                            groupBox1.Enabled = true;
                            tabOperaciones.Enabled = true;
                            tlsToolBar.Enabled = true;
                            lbl_MsgBloqueo.Visible = false;
                            txtEtiquetaPieza.Enabled = true;
                            Chk_MultiplesColadas.Enabled = true;
                            groupBox2.Visible = true ;
                            Btn_CheckList.Visible = true;
                        }
                    }
                }
                else
                {
                    groupBox1.Enabled = true;
                    tabOperaciones.Enabled = true;
                    tlsToolBar.Enabled = true;
                    lbl_MsgBloqueo.Visible = false;
                    txtEtiquetaPieza.Enabled = true;
                    Chk_MultiplesColadas.Enabled = true;
                    groupBox2.Visible = true;
                    Btn_CheckList.Visible = true;
                }
            }
            catch (Exception exc)
            {
                listaDataSet.MensajeError = exc.Message.ToString();
            }


        }


        public void VerificaEstadoMaquina_MM(string lIdMaquina)
        {
            //           [SP_CRUD_NOTIFICACION_AVERIA]  @Id int,
            //@IdOperador int,                  //@TipoMaquina varchar(50) ,	//@TextoIncidencia varchar(max) ,
            //@MailEnviado varchar(1) ,         //@IdUserCrea int   ,           //@Estado varchar(50),
            //@IdMaquina int,                   //@EstadoMaq varchar(10),       //@Opcion int 

            Ws_TO.Ws_ToSoapClient ldal = new Ws_TO.Ws_ToSoapClient();
            WsOperacion.ListaDataSet listaDataSet = new WsOperacion.ListaDataSet();
            string lSql = ""; string lMsg = ""; Btn_Desbloquea.Visible = false;
            try
            {
                listaDataSet.MensajeError = "";

                lSql = string.Concat("exec  SP_CRUD_NOTIFICACION_AVERIA 0,0,'','','',0,'',", lIdMaquina, ",'',3 ");
                listaDataSet.DataSet = ldal.ObtenerDatos(lSql);
                if ((listaDataSet.DataSet.Tables.Count > 0) && (listaDataSet.DataSet.Tables[0].Rows.Count > 0))
                {
                    mEstadoMaquina = listaDataSet.DataSet.Tables[0].Rows[0]["EstadoMaq"].ToString().ToUpper();
                    if (listaDataSet.DataSet.Tables[0].Rows[0]["TextoIncidencia"].ToString().Equals("Cambio de Rollo"))
                    { mTipoAveria = "CB"; }
                    else
                    { mTipoAveria = "AV"; }

                    if (mEstadoMaquina.ToUpper().Equals("DET"))
                    {
                        mIdNotificacion = listaDataSet.DataSet.Tables[0].Rows[0]["Id"].ToString();
                        mMsgMaquina = string.Concat(" El Tótem Esta asociado a la Maquina ", listaDataSet.DataSet.Tables[0].Rows[0]["Maquina"].ToString());
                        mMsgMaquina = string.Concat(mMsgMaquina, " La cual se encuentra en estado Detenida ", Environment.NewLine);
                        mMsgMaquina = string.Concat(mMsgMaquina, " Por notificación del Usuario: ", listaDataSet.DataSet.Tables[0].Rows[0]["Nombre"].ToString(), Environment.NewLine);
                        mMsgMaquina = string.Concat(mMsgMaquina, " Con el motivo de: ", listaDataSet.DataSet.Tables[0].Rows[0]["TextoIncidencia"].ToString(), Environment.NewLine);
                        mMsgMaquina = string.Concat(mMsgMaquina, " La notificación se realizo con fecha:  ", listaDataSet.DataSet.Tables[0].Rows[0]["FechaRegistro"].ToString(), Environment.NewLine);
                        groupBox1.Enabled = false;
                        tabOperaciones.Enabled = false;
                        //tlsToolBar.Enabled = false;
                        lbl_MsgBloqueo.Text = mMsgMaquina;
                        lbl_MsgBloqueo.Top = groupBox1.Top; lbl_MsgBloqueo.Left = groupBox1.Left;
                        lbl_MsgBloqueo.Width = groupBox1.Width; lbl_MsgBloqueo.Height = groupBox1.Height;
                        lbl_MsgBloqueo.Visible = true;
                        txtEtiquetaPieza.Enabled = false;
                        Chk_MultiplesColadas.Enabled = false;
                        groupBox2.Visible = false;
                        Btn_CheckList.Visible = false;
                        //groupBox1.Visible = false;
                        Btn_Desbloquea.Visible = true;
                        this.Refresh();
                    }
                    else
                    {
                      
                            groupBox1.Enabled = true;
                            tabOperaciones.Enabled = true;
                            tlsToolBar.Enabled = true;
                            lbl_MsgBloqueo.Visible = false;
                            txtEtiquetaPieza.Enabled = true;
                            Chk_MultiplesColadas.Enabled = true;
                        groupBox2.Visible = true ;
                        Btn_CheckList.Visible = true;
                    }
                    
                }
                else
                {
                    groupBox1.Enabled = true;
                    tabOperaciones.Enabled = true;
                    tlsToolBar.Enabled = true;
                    lbl_MsgBloqueo.Visible = false;
                    txtEtiquetaPieza.Enabled = true;
                    Chk_MultiplesColadas.Enabled = true;
                    groupBox2.Visible = true;
                    Btn_CheckList.Visible = true;
                }
            }
            catch (Exception exc)
            {
                listaDataSet.MensajeError = exc.Message.ToString();
            }


        }

        public void HabilitaControl(Boolean iHabilita)
        {
            this.Enabled = iHabilita;
                    
        }


        public void HabilitaOpcionSolicitudMaterial()
        {
            //obtenemos la variable para la solicitud de materia prima
            mlValidarSolictud_MP = ConfigurationManager.AppSettings["ValidaSolicitud_MP"].ToString();
            // si no esta habilitada la opción de MP no se muestra en el Menu
            if (mlValidarSolictud_MP.ToUpper().Equals("N"))
            {
                this.TlbNuevaSolicitud.Visible = false;
                tlbRecepcion.Visible = false;
                tlbCierre.Visible = false;
                TlbVer.Visible = false;
            }
            else
            {
                this.TlbNuevaSolicitud.Visible = true;
                this.tlbRecepcion.Visible = true;
                this.tlbRecepcion.Visible = true;
                tlbCierre.Visible = true;
            }
        }



        public void IniciaFormulario(CurrentUser iUserLog)
        {

            try
            {
               
                //Visualizamos la version
                Clases.ClsComun lCom = new Clases.ClsComun();
                this.Text += " - versión: " + lCom.ObtenerVersion();  //Application.ProductVersion;
                ctlInformacionUsuario1.CargaDatosUserLog(iUserLog);
                mUserLog = iUserLog;
                Lbl_Usuario.Text = mUserLog.Login; 

                //Cargar motivos/excepciones
                WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
                WsOperacion.ListaDataSet listaDataSet = new WsOperacion.ListaDataSet();

                listaDataSet = wsOperacion.ObtenerMotivosExcepcionProduccion();
                if (listaDataSet.MensajeError.Equals(""))
                {
                    DataTable dataTable = listaDataSet._dataSet.Tables[0];
                    new Forms().comboBoxFill(cboExcepciones, dataTable, "par_codint", "par_descripcion", 0);
                }
                else
                    MessageBox.Show(listaDataSet.MensajeError.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);


                ActualizaKilosProducidos();
                VerificaEstadoMaquina(mUserLog.IdMaquina.ToString());
                //CArgamos los diametros permitidos por maquina, para posteriores validaciones
                mSoloDiamPermitidos = ConfigurationManager.AppSettings["SoloDiametrosPermitidos"].ToString();
                string lIdSucursal = ConfigurationManager.AppSettings["IdSucursal"].ToString();
                if (mSoloDiamPermitidos.ToUpper().Equals("S"))
                {
                    listaDataSet = wsOperacion.ObtenerDatosConsultaGenerica(84, lIdSucursal, "", "", "", "");
                    if (listaDataSet.MensajeError.Equals(""))
                    {
                        if (listaDataSet.DataSet.Tables[0].Rows.Count > 0)
                        {
                            mTblDiametrosMaq  = listaDataSet.DataSet.Tables[0].Copy();
                        }
                    }
                }
                //para la contrata
                    //< add key = "CambioPR_Desp" value = "S" />
                string lPuedeCambiar =  ConfigurationManager.AppSettings["CambioPR_Desp"].ToString();
                if (lPuedeCambiar.ToUpper().Equals("S"))
                    Btn_A_Despacho.Visible = true;
                else
                    Btn_A_Despacho.Visible = false;


                string lVerificaCheck = ConfigurationManager.AppSettings["ChequeoMaquina"].ToString();
                if (lVerificaCheck.ToUpper().Equals("S"))
                    Btn_CheckList.Visible = true;
                else
                    Btn_CheckList.Visible = false;

            }
                      
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //mUserLog = iUserLog;
            //mIdUser = iUserLog.Iduser;
            //ctlInformacionUsuario1.CargaDatosUserLog(iUserLog);

        }

        public void PuedeIngresarReparacion()
        {
            // ALTER PROCEDURE [dbo].[SP_CRUD_SOLUCION_AVERIA]
            //@Id int,                          //@IdNotificacion int,	            //@Obs varchar(max) ,
            //@IdUsuarioRegistra varchar(5) ,   //@Estado varchar(50),	            //@Par1 varchar(10),
            //@Par2 varchar(10),                //@Opcion int 


            // Si es cambio de Rollo No requiere validacion del perfil del mecanico.

            if (mTipoAveria.Equals("AV"))
            {
                Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient(); DataSet lDts = new DataSet();
                string lSql = ""; string lPerfil = mUserLog.PerfilUsuario; string lMsg = "";


                //Verificamos el estado de la averia
                lSql = string.Concat("exec  SP_CRUD_NOTIFICACION_AVERIA 0,0,'','','',0,'',", mUserLog.IdMaquina, ",'',3 ");
                lDts = lPx.ObtenerDatos(lSql);
                if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                {
                    if (lDts.Tables[0].Rows[0]["EstadoSupervisor"].ToString().Equals("NOOK") && lDts.Tables[0].Rows[0]["EstadoMaq"].ToString().Equals("OP"))
                    {
                        if (lPerfil.ToString().ToUpper().Equals("SUPERVISOR"))
                        {
                            Maquinas.NotificaAveria lFrm = new Maquinas.NotificaAveria();
                            lFrm.IniciaForm(mUserLog);
                            lFrm.ShowDialog();
                        }
                        else
                        {
                            lMsg = String.Concat(" Solamente los Usuarios con Perfil de SUPERVISOR puedes Ingresar las liberaciones de  reparaciones ", Environment.NewLine, " No esta autorizado realizar la liberación de Reparaciones ");
                            MessageBox.Show(lMsg, "Avisos Sistema", MessageBoxButtons.OK);
                        }
                    }
                    else
                    {
                        if (lPerfil.ToString().ToUpper().Equals("MECANICO"))
                        {
                            Maquinas.NotificaAveria lFrm = new Maquinas.NotificaAveria();
                            lFrm.IniciaForm(mUserLog);
                            lFrm.ShowDialog();
                        }
                        else
                        {
                            lMsg = String.Concat(" Solamente los Usuarios con Perfil de Mecanicos puedes Ingresar las reparaciones ", Environment.NewLine, " No esta autorizado a ingresar Reparaciones ");
                            MessageBox.Show(lMsg, "Avisos Sistema", MessageBoxButtons.OK);
                        }
                        //}
                    }
                }


            }

            else
            {
                Maquinas.NotificaAveria lFrm = new Maquinas.NotificaAveria();
                lFrm.IniciaForm(mUserLog);
                lFrm.ShowDialog();
            }


            VerificaEstadoMaquina(mUserLog.IdMaquina.ToString());

        }

    


    public void EstablecerMaquinaActiva(Boolean iHabilitado)
        {
            groupBox1.Enabled = iHabilitado;
        }


        public void EstablecerFocoEtiqueta()
        {

            txtEtiquetaPieza.Focus(); 
        }

        public void CargaUsuarioActual(CurrentUser iUsuarioActual)
        {
            mUserLog = iUsuarioActual;
            mIdUser = iUsuarioActual.Iduser;
            ctlInformacionUsuario1.CargaDatosUserLog(iUsuarioActual);
            Lbl_Usuario.Text = iUsuarioActual.Login;
        }

        public void CargaMaqActual(string iIdMaq, string iNomreMaq)
        {
            mMaquinaActiva = iIdMaq;
            mUserLog.IdMaquina = int.Parse (iIdMaq);
            mUserLog.DescripcionMaq = iNomreMaq;

            ctlInformacionUsuario1.CargaDatosMaq(iIdMaq, iNomreMaq);
        }

        #endregion

        private void txtEtiquetaColada_Leave(object sender, EventArgs e)
        {
            txtEtiquetaColada.Text = eliminarCaracteresEspeciales(txtEtiquetaColada.Text.Trim());
        }

        private void txtEtiquetaColada_Validating(object sender, CancelEventArgs e)
        {
            DataTable dt = new DataTable(); int lTmp = 0; Clases.ClsComun lCom = new Clases.ClsComun();
            if (!txtEtiquetaColada.Text.Trim().Equals(""))
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {

                    //lTmp= int.TryParse(txtEtiquetaColada.Text.ToString (), lTmp);
                    if (lCom.EsNumero(txtEtiquetaColada.Text) == true)
                    {

                        lblColada.Text = ".";
                        lblDiametro.Text = ".";
                        lblLargo.Text = ".";
                        lblNroCertificado.Text = ".";

                        WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
                        WsOperacion.ListaDataSet listaDataSet = new WsOperacion.ListaDataSet();

                        string lValidaColadaEnProduccion = ConfigurationManager.AppSettings["ValidaColadaEnProduccion"].ToString().ToUpper();
                        //ValidaColadaEnProduccion

                        if (txtEtiquetaColada.Text.ToString().Trim().Length == 48)
                        {  //Debemos ir a buscar el Id Paquete Colada
                            listaDataSet = wsOperacion.obtenerIdRC_PorColada(txtEtiquetaColada.Text);
                            if (listaDataSet.MensajeError.Equals(""))
                            {
                                mIdEtiquetaColada = listaDataSet.DataSet.Tables[0].Rows[0][0].ToString();
                            }
                        }
                        else
                            mIdEtiquetaColada = txtEtiquetaColada.Text;

                        listaDataSet = wsOperacion.ObtenerRecepcionxEtiqueta_Colada(mIdEtiquetaColada);
                        //listaDataSet = wsOperacion.ObtenerRecepcionxEtiqueta_Colada(txtEtiquetaColada.Text);
                        if (listaDataSet.MensajeError.Equals(""))
                        {
                            if ((listaDataSet.DataSet.Tables[0].Rows.Count > 0))// && (!listaDataSet.DataSet.Tables[0].Rows[0]["EnProduccion"].ToString ().Equals ("0")))
                            {
                                dt = listaDataSet.DataSet.Tables[0];
                                lblKilos.Text = dt.Rows[0]["KILOSCalculados"].ToString();

                                //<info. colada> etiqueta_colada != colada
                                string colada = listaDataSet.DataSet.Tables[0].Rows[0]["COLADA"].ToString();
                                //listaDataSet = wsOperacion.ObtenerColadasPorNro(colada);
                                listaDataSet = ObtenerColadasPorId(colada);
                                if (listaDataSet.MensajeError.Equals(""))
                                {

                                    dt = listaDataSet.DataSet.Tables[0];
                                    if (dt.Rows.Count > 0)
                                    {
                                        lblColada.Text = colada;
                                        lblDiametro.Text = dt.Rows[0]["DIAMETRO"].ToString();
                                        lblLargo.Text = dt.Rows[0]["LARGO"].ToString();
                                        lblNroCertificado.Text = dt.Rows[0]["NROCERTIFICADO"].ToString();
                                        //obtenemos el detalle de las piezas producidas por la colada
                                        listaDataSet = wsOperacion.ObtenerDatosProduccionPorColada(mIdEtiquetaColada);
                                        //listaDataSet = wsOperacion.ObtenerDatosProduccionPorColada(txtEtiquetaColada.Text);
                                        if (listaDataSet.MensajeError.Equals(""))
                                        {
                                            if (listaDataSet.DataSet.Tables[0].Rows.Count > 0)
                                            {
                                                Lbl_SaldoKilosColada.Text = listaDataSet.DataSet.Tables[0].Rows[0]["SaldoKiloscolada"].ToString();
                                                Lbl_KgsProd.Text = listaDataSet.DataSet.Tables[0].Rows[0]["Kilosproducidos"].ToString();
                                                Lbl_NroPiezas.Text = listaDataSet.DataSet.Tables[0].Rows[0]["PiezasProducidas"].ToString();
                                                Lbl_NroEtiq.Text = listaDataSet.DataSet.Tables[0].Rows[0]["NroEtiquetas"].ToString();
                                            }
                                            else
                                            {
                                                Lbl_SaldoKilosColada.Text = lblKilos.Text;
                                                Lbl_KgsProd.Text = "0";
                                                Lbl_NroPiezas.Text = "0";
                                                Lbl_NroEtiq.Text = "0";
                                            }
                                        }

                                        else
                                        {
                                            MessageBox.Show(listaDataSet.MensajeError.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            tlbNuevo_Click(null, null);
                                            e.Cancel = true;
                                        }
                                    }
                                }

                            }
                            else
                            {
                                //   MessageBox.Show("La etiqueta '" + txtEtiquetaColada.Text + "' no existe, o no ha sido enviada a producción, Revisar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                MessageBox.Show("La etiqueta '" + txtEtiquetaColada.Text + "' no existe, Revisar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                tlbNuevo_Click(null, null);
                                e.Cancel = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show(listaDataSet.MensajeError.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tlbNuevo_Click(null, null);
                            e.Cancel = true;
                        }

                        if (this.Lbl_KgsProd.Text.ToString().Trim().Length > 0)
                        {
                            mTotalKilos = double.Parse(this.Lbl_KgsProd.Text);
                        }
                    }
                    else
                    {
                        MessageBox.Show("La Colada ingresada debe ser un número Entero, y se ha ingresado el valor (" + txtEtiquetaColada.Text + "), Revise y corrija el dato de la colada", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tlbNuevo_Click(null, null);
                        e.Cancel = true;
                    }

                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Cursor.Current = Cursors.Default;
            }
        }

        private void tlbNuevo_Click(object sender, EventArgs e)
        {
            txtEtiquetaColada.Clear();
            txtObs.Clear();
            txtEtiquetaPieza.Clear();
            //limpiamos los datos 
            lblColada.Text = "";
            lblDiametro.Text = "";
            lblLargo.Text = "";
            lblNroCertificado.Text = "";
            lblKilos.Text = "";
            Lbl_SaldoKilosColada.Text = "";
            Lbl_KgsProd.Text = "";
            Lbl_NroPiezas.Text = "";
            Lbl_NroEtiq.Text = "";

            dgvEtiquetasPiezas.DataSource = null;
            if (cboExcepciones.Items.Count > 0)
                cboExcepciones.SelectedIndex = 0;
            dgvEtiquetasPiezasExcepciones.DataSource = null;
            lblCantidadEtiquetasPiezas.Text = "Registro(s): 0";
            lblCantidadEtiquetasPiezasExcepciones.Text = "Registro(s): 0";
            tabOperaciones.TabIndex = 0;
            mTotalKilos = 0;
            txtEtiquetaColada.Focus();
        }

        private void txtObs_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                txtEtiquetaPieza.Focus();
            }
        }

        private void txtObs_Leave(object sender, EventArgs e)
        {
            txtObs.Text = eliminarCaracteresEspeciales(txtObs.Text.Trim());
        }

        private void CtlProduccion_Load(object sender, EventArgs e)
        {
            
        }

        private void TlbNuevaSolicitud_Click(object sender, EventArgs e)
        {
            frmSolicitudMaterial frm = new frmSolicitudMaterial();
            frm.IniciaForm(mUserLog);
            frm.ShowDialog(this);
        }

        private void tlbRecepcion_Click(object sender, EventArgs e)
        {
            frmRecepcionMaterial frm = new frmRecepcionMaterial();
            frm.IniciaForm(mUserLog);
            frm.ShowDialog(this);
        }

        private void tlbCierre_Click(object sender, EventArgs e)
        {
            frmCierreMaterial frm = new frmCierreMaterial();
            frm.IniciaForm(mUserLog);
            frm.ShowDialog(this);
        }

        private void Btn_Desbloquea_Click(object sender, EventArgs e)
        {
            //Maquinas.NotificaAveria lFrm = new Maquinas.NotificaAveria();
            //lFrm.IniciaForm(mUserLog);
            //lFrm.ShowDialog();
            //VerificaEstadoMaquina(mUserLog.IdMaquina.ToString());
            PuedeIngresarReparacion();
        }

        private void Btn_NotificacionAveria_Click(object sender, EventArgs e)
        {
            Maquinas.NotificaAveria lFrm = new Maquinas.NotificaAveria();
            //mUserLog.DescripcionMaq = mMaquinaActiva;
            if (MessageBox.Show(string.Concat ("¿Esta seguro que desea reportar una Averia para la Máquina ",mUserLog .DescripcionMaq .ToUpper() ," "),"Avisos sistema", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                    lFrm.IniciaForm(mUserLog);
                    lFrm.ShowDialog();
                    VerificaEstadoMaquina(mUserLog.IdMaquina.ToString());
            }
           
        }

        private void TlbVer_Click(object sender, EventArgs e)
        {
            SolicitudMP.frmVisializar lfrm = new SolicitudMP.frmVisializar();
            lfrm.IniciaFormulario(mUserLog.Login , mUserLog);
            lfrm.ShowDialog();
        }

        private void tlbSalir_Click(object sender, EventArgs e)
        {
            string lMsg = "";
            //1.-Revisamos en el archivo de configuracion si tiene habilitado la validacion de SMP
            // 1.5.- Si la maquina esta con notificación de averias debe poder salir sin problemas

            if (mIdNotificacion.ToString().Trim().Length == 0)
            {
                if (mlValidarSolictud_MP.ToUpper().Equals("S"))
                {
                    //2.- Debemos chequear que cerro el turno
                    if (TurnoEstaCerrado() == false)
                    {
                        //3.- SI NO cerro, se visualiza mensaje y NO sale de la aplicación
                        lMsg = string.Concat("NO se puede Salir de la aplicación, ya que NO se ha  cerrado el turno", Environment.NewLine, "Debe Cerrar el Turno Para poder Salir de la Aplicación");
                        MessageBox.Show(lMsg, "Avisos Sistema", MessageBoxButtons.OK);
                    }
                    else
                    {
                        //3.- Si cerro, sale de la aplicacion
                        //MessageBox.Show("SI se puede cerrar el turno", "Avisos Sistema", MessageBoxButtons.OK);
                        ValidarSalir();
                        // BotonClick(this, e);
                    }
                }
                else
                    ValidarSalir(); //BotonClick(this, e);
            }
            else
                ValidarSalir(); //BotonClick(this, e);
        }

        protected virtual void ValidarSalir()
        {
            //Salir();
            // registramos que el usuario  salio de sistema 
            WsSesion.WS_SesionSoapClient lSesion = new WsSesion.WS_SesionSoapClient();
            string lRes = "";

            lRes = lSesion.RegistraLogOUT(mUserLog.Iduser.ToString(), mUserLog.IdMaquina.ToString());

            BotonClick(this, null);

        }

        private bool TurnoEstaCerrado()
        {
            bool lres = true; SolicitudMP.frmVisializar lFrm = new SolicitudMP.frmVisializar();
            int i = 0;
            lFrm.IniciaFormulario(mUserLog.Iduser, mUserLog);
            DataTable lTblDatos = lFrm.ObtenerSMP_PorTurno();
            lFrm = null;

            for (i = 0; i < lTblDatos.Rows.Count; i++)
            {
                if (lTblDatos.Rows[i]["DET_INET_MSG"].ToString().Trim().Length == 0)
                    lres = false;
            }
    

            return lres;
        }

        private void Btn_NotificaAveriaElemento_Click(object sender, EventArgs e)
        {
            Clases.Obj.Obj_ElementoProd lObj = new Clases.Obj.Obj_ElementoProd();
            Maquinas.Frm_ElementosProduccion lFrm = new Maquinas.Frm_ElementosProduccion();
            lFrm.IniciaFormulario(mUserLog .Iduser );
            lFrm.ShowDialog(this);
            lObj=(Clases.Obj.Obj_ElementoProd) AppDomain.CurrentDomain.GetData("ElementoSel" );
           
            if (lObj != null)
            {
                if ((lObj.IdElemento.Trim().Length > 0) && (lObj.IdUserReporta.Trim().Length > 0))
                {
                    Maquinas.NotificaAveria lFrmAV = new Maquinas.NotificaAveria();
                    //mUserLog.DescripcionMaq = mMaquinaActiva;
                    if (MessageBox.Show(string.Concat("¿Esta seguro que desea reportar una Averia para el elemento de Producción ", lObj.DescripcionElemento, " ? "), "Avisos sistema", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        lFrmAV.IniciaFormElementoProd(lObj );
                        lFrmAV.ShowDialog();
                        //VerificaEstadoMaquina(mUserLog.IdMaquina.ToString());

                        ////*************************************************
                        //Maquinas.NotificaAveria lFrms = new Maquinas.NotificaAveria();
                        ////mUserLog.DescripcionMaq = mMaquinaActiva;
                        //if (MessageBox.Show(string.Concat("¿Esta seguro que desea reportar una Averia para la Máquina ", mUserLog.DescripcionMaq.ToUpper(), " "), "Avisos sistema", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        //{
                        //    lFrms.IniciaForm(mUserLog);
                        //    lFrms.ShowDialog();
                        //   // VerificaEstadoMaquina(mUserLog.IdMaquina.ToString());
                        //}

                        //******************************************************
                    }
                }
            }
            else
            {
                CurrentUser mUserTmp = new CurrentUser();Clases.ClsComun lcom = new Clases.ClsComun();
                string lSolucion= AppDomain.CurrentDomain.GetData ("IdAveria").ToString ();
                string lIdUser = AppDomain.CurrentDomain.GetData("IdUser").ToString();
                string lUser = AppDomain.CurrentDomain.GetData("User" ).ToString ();
                if (lcom.EsNumero(lSolucion))
                {
                    //lObjProd.IdElemento =
                    Maquinas.NotificaAveria lFrms = new Maquinas.NotificaAveria();
                    mUserTmp.IdMaquina = new Clases.ClsComun().Val(lSolucion);
                    mUserTmp.Iduser = lIdUser;
                    mUserTmp.Login = lUser;
                    lFrms.IniciaReparacion_EP( lSolucion, mUserTmp);
                    lFrms.ShowDialog();
                }
            }
        }

        private void Btn_A_Despacho_Click(object sender, EventArgs e)
        {
            string lPath = ""; string lApp = "";
            if (MessageBox.Show("¿ Esta seguro que desea cambiar el sistema a modo Despacho? ", "Avisos Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                  MessageBox.Show("Cuando el sistema le indique menu de confirmación, Presaionar SI ", "Avisos Sistema", MessageBoxButtons.OK);
                lPath = ConfigurationManager.AppSettings["Path_Regedit"].ToString();
                lApp = "Regedit.exe";
                lPath = string .Concat (lPath,"DC.reg");
                System.Diagnostics.Process.Start(lApp, lPath);
                System.Threading.Thread.Sleep(3000);
                MessageBox.Show("El Sistema se cerrara, debe iniciar nuevamente el sistema, para cambiar a Modo Despacho  ", "Avisos Sistema", MessageBoxButtons.OK);
                Application.Exit();
            }
        }

        private void Btn_CheckList_Click(object sender, EventArgs e)
        {
            Maquinas.CheckList lFrm = new Maquinas.CheckList();
            lFrm.IniciaForm(mUserLog);
            lFrm.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (EvaluaTimer==true )
            {
                EvaluaTimer = false;
                VerificaChequeoMaquina();
                EvaluaTimer = true;
            }
            


        }
        private void VerificaChequeoMaquina()
        {
            WsOperacion.OperacionSoapClient lWs = new WsOperacion.OperacionSoapClient();
            string lRes = "";
            string lVerificaCheck = ConfigurationManager.AppSettings["ChequeoMaquina"].ToString();
            
            if (lVerificaCheck.ToUpper() .Equals ("S"))
            {
                lRes = lWs.VerificaChequeo(mUserLog.IdMaquina.ToString());

                if (lRes.ToString().ToUpper().Equals("S"))
                {
                    MessageBox.Show("Debe Realizar Chequeo de Máquina, para poder seguir registrando la Producción. Por favor Responda el Cuestionario", "Avisos Sistema", MessageBoxButtons.OK);
                    Maquinas.CheckList lForm = new Maquinas.CheckList();
                    lForm.IniciaForm(mUserLog);
                    lForm.ShowDialog();
                }

            }


           



        }
    }
}
