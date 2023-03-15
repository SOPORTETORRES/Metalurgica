using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Metalurgica.Maquinas
{
    public partial class Frm_IngresoRepuestos : Form
    {
        private string mIdAveria = "";
        private string mtextoAveria = "";
        private string mIdMecanico = "";
        private string midSucursal = "";
        private string midMaquina = "";
        private string mItemGasto = "";
        private DataTable mTblRespuestosMaq = new DataTable();
        public Frm_IngresoRepuestos()
        {
            InitializeComponent();
        }

        private void txt_Repuesto_Validated(object sender, EventArgs e)
        {
            Clases.ClsComun lCom = new Clases.ClsComun(); 
            string sql = string.Concat("SP_CRUD_Repuestos 12,'','','", txt_Repuesto.Text, "' ,'','','','','','M','','','',''");
            Ws_TO .Ws_ToSoapClient  lDal = new Ws_TO.Ws_ToSoapClient();DataSet lDts = new DataSet();
            DataTable lTbl = new DataTable(); string lIdRepuesto    = ""; int i = 0; Boolean lPuedeSeguir = false;
            lDts = lDal.ObtenerDatos(sql);

            if (lCom.Val(txt_Repuesto.Text) > 0)
            {
                if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                {
                    lTbl = lDts.Tables[0].Copy();
                    lIdRepuesto = lTbl.Rows[0]["Id"].ToString();
                    sql = string.Concat("SP_CRUD_Repuestos 16,'','',' ' ,'','','','','','M','','", lIdRepuesto, "','',''");
                    lDts = lDal.ObtenerDatos(sql);
                    if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                    {
                        for (i = 0; i < lDts.Tables[0].Rows.Count; i++)
                        {
                            if (midMaquina == lDts.Tables[0].Rows[i]["Par2"].ToString())
                                lPuedeSeguir = true;
                        }
                    }
                    if (lPuedeSeguir == true)
                    {
                        Lbl_NomnreRep.Text = lTbl.Rows[0]["Item"].ToString();
                        Tx_PU.Text = lCom.Val(lTbl.Rows[0]["Valor"].ToString().Replace (".","")).ToString("N0");
                    }
                    else
                    {

                        MessageBox.Show("El Repuesto Ingresado No se puede utilzar en esta Máquina ", "Avisos Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Lbl_NomnreRep.Text = "";
                        Tx_PU.Text = "";
                        txt_Repuesto.Text = "";
                        txt_cantidad.Text = "";
                        txt_Repuesto.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("El Repuesto Ingresado No Existe ", "Avisos Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Lbl_NomnreRep.Text = "";
                    Tx_PU.Text = "";
                    txt_Repuesto.Text = "";
                    txt_cantidad.Text = "";
                    txt_Repuesto.Focus();
                }
            }
        }

        public void inicializar(string idAveria, string textoAveria, string idMecanico, string idSucursal, string idMaquina)
        {
            //Creamos las columnas de la tabla de repuestos
            CreaColumnas();

            mIdAveria = idAveria;
            mtextoAveria = textoAveria;
            mIdMecanico = idMecanico;
            midSucursal = idSucursal;
            midMaquina = idMaquina;
            lb_Averia.Text = mtextoAveria;
            Lbl_IdAveria.Text = idAveria;

            string sql = string.Concat("SP_CRUD_Repuestos  13,'','',' ' ,'','','','','', '','','", idAveria, "','','' ");
            Ws_TO.Ws_ToSoapClient lDal = new Ws_TO.Ws_ToSoapClient(); DataSet lDts = new DataSet();
            DataTable lTbl = new DataTable();
            lDts = lDal.ObtenerDatos(sql);

            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                lbl_Maquina.Text = lDts.Tables[0].Rows[0]["Maq_Nombre"].ToString();
                mItemGasto = lDts.Tables[0].Rows[0]["MAQ_ITEM_GASTO"].ToString();
            }
                         

            sql = string.Concat("SP_CRUD_Repuestos  14,'", idSucursal,"','',' ' ,'','','','','', '','','','','' ");
            lDts = lDal.ObtenerDatos(sql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                lbl_Sucursal .Text = lDts.Tables[0].Rows[0]["Nombre"].ToString();

            sql = string.Concat("SP_CRUD_Repuestos 15,'", idMecanico, "','',' ' ,'','','','','', '','','','','' ");
            lDts = lDal.ObtenerDatos(sql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                lbl_NombreMecanico .Text = lDts.Tables[0].Rows[0]["Usuario"].ToString();


        }


        private DataTable CreaColumnas()
        {
            //DataTable mTblRespuestosMaq = new DataTable();
            mTblRespuestosMaq.Columns.Add("IdRepuesto", Type.GetType("System.String"));
            mTblRespuestosMaq.Columns.Add("Repuesto", Type.GetType("System.String"));
            mTblRespuestosMaq.Columns.Add("IdAveria", Type.GetType("System.String"));
            mTblRespuestosMaq.Columns.Add("IdMaquina", Type.GetType("System.String"));
            mTblRespuestosMaq.Columns.Add("IdUsuario", Type.GetType("System.String"));
            mTblRespuestosMaq.Columns.Add("Stock", Type.GetType("System.String"));
            mTblRespuestosMaq.Columns.Add("NroUnidades", Type.GetType("System.String"));
            mTblRespuestosMaq.Columns.Add("PU", Type.GetType("System.String"));
            mTblRespuestosMaq.Columns.Add("SubTotal", Type.GetType("System.String"));
            return mTblRespuestosMaq;
        }

        private void Btn_Agregar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos() == true)
            {
                AgregaFila();
                Lbl_NomnreRep.Text = "";
                Tx_PU.Text = "";
                txt_Repuesto.Text = "";
                txt_cantidad.Text = "";
                Tx_CodSeleccionado.Text = "";
                txt_Repuesto.Focus();
            }

        }

        private void GrabarDatos() //(string IdRepuesto, int iCantidad)
        {
            int i = 0; string lSql = "";string IdRepuesto=""; string iCantidad = "";    string iPrecioUnitario = "";
            string Codigo = ""; string iPU = "";  Clases.ClsComun lCom = new Clases.ClsComun(); string lIdrepuestosAverias = "0";
            Ws_TO.Ws_ToSoapClient lDal = new Ws_TO.Ws_ToSoapClient(); DataSet lDts = new DataSet();
            if (Dgt_Datos.Rows.Count > 1)
            {
                for (i = 0; i < Dgt_Datos.RowCount; i++)
                {
                    if (Dgt_Datos.Rows[i].Cells["IdRepuesto"].Value != null)
                    {
                        IdRepuesto = Dgt_Datos.Rows[i].Cells["IdRepuesto"].Value.ToString();
                        iCantidad = Dgt_Datos.Rows[i].Cells["NroUnidades"].Value.ToString();
                        iPrecioUnitario = Dgt_Datos.Rows[i].Cells["PU"].Value.ToString().Replace(".", "");
                        lSql = "  Insert into repuestosAverias (IdAveria,IdRepuesto,Cantidad,FechaRegistro,IdUsuario,Estado,IdSucursal, IdMaquina ,PrecioUnitario)  ";
                        lSql = string.Concat(lSql, "  Values (", mIdAveria, ",", IdRepuesto, ",", iCantidad, ", Getdate(),");
                        lSql = string.Concat(lSql, mIdMecanico, ",'Inicial',", midSucursal, ",", midMaquina, ",", iPrecioUnitario, ")  select @@identity ");

                        lDts= lDal.ObtenerDatos(lSql);

                        if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                        {
                            if (lCom.Val(lDts.Tables[0].Rows[0][0].ToString()) >0)
                            {
                                lIdrepuestosAverias = lDts.Tables[0].Rows[0][0].ToString();
                                Codigo = IdRepuesto.ToString();
                                iCantidad = iCantidad.ToString();
                                iPU = iPrecioUnitario.ToString();

                                integraRepuesto(Codigo, iCantidad, iPU, lbl_NombreMecanico.Text, lbl_Maquina.Text, mItemGasto, lIdrepuestosAverias, mIdAveria.ToString ());

                            }
                        }
                    }
                }
                mTblRespuestosMaq.Clear();
                // Se debe verificar si hay errores despues de la Integracion, de haber errore hay que enviar un correo con el detalle
                //Se debe enviar correo con el error a jarias - scampos - Lgallardo  -  Carlos Vázquez.
                VerificaIntegracionINET(mIdAveria.ToString());

            }
        }


        private void VerificaIntegracionINET(string iIdAveria)
        {
            //si hay error en la integracion se debe enviar un correo informando del error
            Ws_TO.Ws_ToSoapClient lDal = new Ws_TO.Ws_ToSoapClient(); DataSet lDts = new DataSet(); string lSql = "";
            Clases.ClsComun lCom = new Clases.ClsComun(); DataTable lTbl = new DataTable(); int i = 0;
            string lRes = "";Boolean lHayError = false;string lTitulo = ""; string lResp = "";
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient();

            try
            {

                lSql = string.Concat("SP_CRUD_Repuestos 18,'','',' ' ,'','','','','', '','','", iIdAveria, "','','' ");
                lDts = lDal.ObtenerDatos(lSql);
                if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                {
                    lTbl = lDts.Tables[0].Copy();

                    lRes = String.Concat(" Señores:  ", "  <br> ", "  <br> ");
                    lRes = String.Concat(lRes, " Se ha intentado integrar con INET los repuestos utilizados de  una notificación de Averia", "  <br> ", "  <br> ");
                    lRes = String.Concat(lRes, " Pero la Integracion No ha sido Satisfactoria, se han generado los siguientes errores:  ", "  <br> ");
                    lRes = String.Concat(lRes, " ID Averia          :", iIdAveria, "  <br> ");
                    lRes = String.Concat(lRes, " Motivo averia      :", lTbl.Rows[0]["TextoIncidencia"].ToString(), "  <br> ");
                    lRes = String.Concat(lRes, " Maquina Afectada   :", lTbl.Rows[0]["Maq_nombre"].ToString(), "  <br> ");
                    lRes = String.Concat(lRes, " Fecha Notificacion :", lTbl.Rows[0]["FechaRegistro"].ToString(), "  <br> ", "  <br> ");
                }

                lRes = String.Concat(lRes, "  <br> ", " Detalle de los Repuestos con error al Integrar con INET ", "  <br> ");
                lSql = string.Concat("SP_CRUD_Repuestos 17,'','',' ' ,'','','','','', '','','", iIdAveria, "','','' ");
                lDts = lDal.ObtenerDatos(lSql);
                if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                {
                    lTbl = lDts.Tables[0].Copy();
                    for (i = 0; i < lTbl.Rows.Count; i++)
                    {
                        if (lTbl.Rows[i]["EstadoEnvio"].ToString().ToUpper().Equals("ERR"))
                        {
                            lResp = lTbl.Rows[i]["Xml_Respuesta"].ToString().Replace("&amp;gt;", "");
                            lResp = lResp.ToString().Replace("&amp;lt;", "");
                            lRes = String.Concat(lRes, " Repuesto : ", lTbl.Rows[i]["Item"].ToString(), "  <br> ");
                            lRes = String.Concat(lRes, " Cantidad : ", lTbl.Rows[i]["Cantidad"].ToString(), "  <br> ");
                            lRes = String.Concat(lRes, " Error  : ", lResp, "  <br> ");
                            lHayError = true;
                        }
                        lRes = String.Concat(lRes, "  <br> ");
                    }

                    lRes = String.Concat(lRes, "Este mail ha sido enviado de forma automática por el sistema,  FAVOR NO CONTESTAR A ESTA CASILLA DE CORREO", "  <br> ");
                }
                if (lHayError) // si hay error debemos enviar el correo
                {
                    lTitulo = "Notificación  de error en la Integración de Repuestos con INET ";
                    lPx.EnviaNotificacionesEnviaMsgDeNotificacion("", lRes, -2100, lTitulo);

                }
            }
            catch (Exception iex)
            {

            }

        }

        private void CalculaTotales( )
        {
            Int64 lSubTotal = 0;int i = 0; Clases.ClsComun lCom = new Clases.ClsComun();
            //Dgt_Datos.Rows[0].Cells["Repuesto"].Value = "0";
            //Dgt_Datos.Rows[0].Cells["subtotal"].Value = ""; //lSubTotal.ToString("N0");
            for (i = 0; i < mTblRespuestosMaq.Rows.Count; i++)
            {
                if (mTblRespuestosMaq.Rows[i]["IdRepuesto"].ToString().Length > 0)
                {
                    lSubTotal = lSubTotal + lCom.Val(mTblRespuestosMaq.Rows[i]["SubTotal"].ToString().Replace(".", ""));
                }
            }
            Dgt_Datos.Rows[i].Cells["Repuesto"].Value = "Totales";
            Dgt_Datos.Rows[i].Cells["subtotal"].Value = lSubTotal.ToString("N0");
        }

        private void AgregaFila()
        {
            Int64 lSubTotal = 0; Clases.ClsComun lCom = new Clases.ClsComun();int i = 0;
            DataRow lFila = mTblRespuestosMaq.NewRow(); DataView lVista = null;string lWheres = "";
           

            lWheres = string .Concat ("IdRepuesto='",txt_Repuesto .Text ,"'")  ;
            lVista = new DataView(mTblRespuestosMaq, lWheres, "", DataViewRowState.CurrentRows);
            if (lVista.Count > 0)
            {
                lVista[0]["PU"] = lCom.Val( Tx_PU.Text.Replace (".","")).ToString ("N0");
                lVista[0]["NroUnidades"] = txt_cantidad.Text;
                lSubTotal = lCom.Val(txt_cantidad.Text) * lCom.Val(Tx_PU.Text.Replace(".", ""));
                lVista[0]["SubTotal"] = lSubTotal.ToString("N0");
            }
            else
            {
                lFila["IdRepuesto"] = txt_Repuesto.Text;
                lFila["Repuesto"] = Lbl_NomnreRep.Text;
                lFila["IdAveria"] = Lbl_IdAveria.Text;
                lFila["IdMaquina"] = midMaquina;
                lFila["IdUsuario"] = mIdMecanico;
                lFila["PU"] = lCom.Val(Tx_PU.Text.Replace(".", "")).ToString("N0");
                lSubTotal = lCom.Val(txt_cantidad.Text) * lCom.Val(Tx_PU.Text.Replace(".", ""));
                lFila["Stock"] = "";
                lFila["SubTotal"] = lSubTotal.ToString("N0");
                lFila["NroUnidades"] = txt_cantidad.Text;
                mTblRespuestosMaq.Rows.Add(lFila);
            }
            //lSubTotal = 0;
            //for (i = 0; i < mTblRespuestosMaq.Rows.Count; i++)
            //{
            //    if (mTblRespuestosMaq.Rows[i]["IdRepuesto"].ToString().Length > 0)
            //    {
            //        lSubTotal = lSubTotal + lCom.Val(mTblRespuestosMaq.Rows[i]["SubTotal"].ToString().Replace (".",""));
            //    }
            //}

            Dgt_Datos.DataSource = mTblRespuestosMaq;
            Dgt_Datos.Columns["IdAveria"].Visible = false;
            Dgt_Datos.Columns["IdMaquina"].Visible = false;
            Dgt_Datos.Columns["IdUsuario"].Visible = false;
            //Dgt_Datos.Rows[i].Cells["Repuesto"].Value = "Totales";
            //Dgt_Datos.Rows[i].Cells["subtotal"].Value = lSubTotal.ToString ("N0");
            Dgt_Datos.Columns["SubTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            Dgt_Datos.Columns["PU"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            Dgt_Datos.Columns["NroUnidades"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            Dgt_Datos.Columns["Repuesto"].Width = 440;
            Dgt_Datos.Columns["PU"].Width = 60;
            Dgt_Datos.Columns["NroUnidades"].Width = 80;
            Dgt_Datos.Columns["Stock"].Width = 80;
            Dgt_Datos.Columns["IdRepuesto"].Width = 80;
            CalculaTotales();
        }

        private Boolean ValidarDatos()
        {
            Boolean lRes = true; string lMsg = ""; Clases.ClsComun lCom = new Clases.ClsComun();
            if (txt_Repuesto.Text.Trim().ToString().Length == 0)
            {
                lMsg = "Debe Ingresar un Repuesto ";
                lRes = false;
            }
            if (lCom.Val(txt_cantidad.Text) == 0)
            {
                lMsg = "Debe Ingresar una Cantidad ";
                lRes = false;
            }
            if (lCom.Val(Tx_PU .Text.Replace (".","")) == 0)
            {
                lMsg = "El código de repuesto Ingresado NO es válido.";
                lRes = false;
            }


            if (lMsg.Trim().Length > 0)
                MessageBox.Show(lMsg, "Avisos Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            
            return lRes;
        }

        private void Btn_Salir_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void Btn_Grabar_Click(object sender, EventArgs e)
        {
            GrabarDatos();
            this.Close();
        }

        private void Btn_Eliminar_Click(object sender, EventArgs e)
        {
            Clases.ClsComun lCom = new Clases.ClsComun();DataTable lTbl = new DataTable();
            if (lCom.Val(Tx_CodSeleccionado.Text) > 0)
            {
                lTbl =(DataTable )  Dgt_Datos.DataSource ;
                DataView lVista = new DataView(lTbl, string.Concat("IdRepuesto=", Tx_CodSeleccionado.Text), "", DataViewRowState.CurrentRows);
                if (lVista.Count > 0)
                    lVista[0].Delete();


                CalculaTotales();
            }
        }

        private void Dgt_Datos_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
       
            int lfila = e.RowIndex;  

            string lCodigo = Dgt_Datos.Rows[lfila].Cells["idRepuesto"].Value.ToString();
            Tx_CodSeleccionado.Text   = lCodigo;
        }

        private void Btn_INET_Click(object sender, EventArgs e)
        {
            //string Codigo = "";string idMecanico = ""; string iNombreMaquina = "";
            //string iCantidad = ""; string iPU = "";
            //if (this.Dgt_Datos .Rows.Count > 0)
            //{
            //    try
            //    {
            //        Codigo = Dgt_Datos.Rows[0].Cells["IdRepuesto"].Value.ToString();
            //        iCantidad = Dgt_Datos.Rows[0].Cells["NroUnidades"].Value.ToString();
            //        iPU = Dgt_Datos.Rows[0].Cells["PU"].Value.ToString();
            //        idMecanico = lbl_NombreMecanico.Text;
            //        iNombreMaquina = lbl_Maquina.Text;
            //        integraRepuesto(Codigo, iCantidad, iPU, idMecanico, iNombreMaquina, mItemGasto);
            //    }
            //    catch (Exception iEx)
            //    {
            //    }

            //}

        }

        private Integracion_INET.Tipo_InvocaWS integraRepuesto(string codigo, string iCantidad, string iPU, string glosa1, string glosa2, string iItemGasto, string iIdRepuestoAveria, string iIdAveria)
        {
            Integracion_INET.Tipo_InvocaWS lRes = new Integracion_INET.Tipo_InvocaWS();
            Integracion_INET.MovExistencias mov = new Integracion_INET.MovExistencias();
            Integracion_INET.MovExistenciasAll cabecera = new Integracion_INET.MovExistenciasAll();
            Integracion_INET.MovExistenciasDet detalle = new Integracion_INET.MovExistenciasDet();
            //Servicio WEB INET
            Px_MovExistenciasINET.wsmovexiallSoapPortClient lPxMovEx = new Px_MovExistenciasINET.wsmovexiallSoapPortClient(); //Servicio web de Inet
            Px_MovExistenciasINET.ExecuteRequest lObjEntradaMov = new Px_MovExistenciasINET.ExecuteRequest(); //OBJETO INET
            Px_MovExistenciasINET.ExecuteResponse lResMovEx = new Px_MovExistenciasINET.ExecuteResponse();
            string resultadoWS = ""; Clases.ClsComun lCom = new Clases.ClsComun();// StringBuilder strDataXml = new StringBuilder();
            string lSql = ""; WsCrud.CrudSoapClient lDAl = new WsCrud.CrudSoapClient(); WsCrud.ListaDataSet lDts = new WsCrud.ListaDataSet();
            string lMovNumDoc = "";
            try
            {

                Integracion_INET.Cls_LN Ln = new Integracion_INET.Cls_LN();
                //(idRepuesto As String, iCantidad As String, iPU As String, iGlosa1 As String, iGlosa2 As String)
                string iXml = Ln.CreaXmlConsumoRepuestos_INET_VistaClara(codigo, iCantidad, iPU, glosa1, glosa2, iItemGasto);
                lMovNumDoc = Ln.ObtenerCampo_MovNumDoc().ToString ();

                lObjEntradaMov.Intrasnporte = iXml; // Ln.CreaXmlEntradaProductosTErminados_INET(mov);//Esto genera un XML
                lRes.XML_Enviado = lObjEntradaMov.Intrasnporte;
                lRes.URL_WS = lPxMovEx.Endpoint.ListenUri.AbsoluteUri;//Con esto guardamos el url del servicio web
                lResMovEx.Outtansporte = lPxMovEx.Execute(lObjEntradaMov.Intrasnporte);//Ejecutar el serivico web de inet
                System.IO.StringWriter strDataXml = new System.IO.StringWriter();


                System.Xml.Serialization.XmlSerializer lXmlSal = new System.Xml.Serialization.XmlSerializer(lResMovEx.Outtansporte.GetType());

                lXmlSal.Serialize(strDataXml, lResMovEx.Outtansporte);
                lRes.XML_Respuesta = strDataXml.ToString();//Guardamos lo que recibimos

                if (lRes.XML_Respuesta.ToUpper().IndexOf("OK") > -1)
                {
                    resultadoWS = "OK";
                   
                }
                else
                {
                    resultadoWS = "ERR";
                }
                lRes.XML_Respuesta = lRes.XML_Respuesta.Replace("&amp;lt;", "<");
                lRes.XML_Respuesta = lRes.XML_Respuesta.Replace("&amp;gt;", ">");
            }
            catch (Exception iex)
            {
                lRes.Err = String.Concat(iex.Message.ToString(), " - ", iex.StackTrace.ToString());
                lRes.XML_Respuesta = iex.Message.ToString();
            }
            finally
            {
                
                lSql = string.Concat("exec SP_CRUD_LOG_WS_INET 1,", lRes.Id.ToString(), ",", iIdAveria.ToString());
                lSql = string.Concat(lSql, ",'", lRes.PatenteCamion, "',", iIdRepuestoAveria,", '", lRes.XML_Enviado.Replace("'", "''"), "',");
                lSql = string.Concat(lSql, "'", lRes.XML_Respuesta, "','", lRes.URL_WS, "','IntegracionRepuestos',", lMovNumDoc);
                lSql = string.Concat(lSql, ",'", resultadoWS, "'");
                lDts = lDAl.ListarAyudaSql(lSql);
                if ((lDts.DataSet.Tables.Count > 0) && (lDts.DataSet.Tables[0].Rows.Count > 0))
                    lRes.Id = lCom .Val(lDts.DataSet.Tables[0].Rows[0][0].ToString());
                
            }
            return lRes;
        }

    }
}
