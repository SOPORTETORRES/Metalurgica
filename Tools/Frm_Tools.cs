using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Metalurgica.Tools
{
    public partial class Frm_Tools : Form
    {
        private string mOpcion = "";
        private DataTable mTblDAtos = new DataTable();
        public Frm_Tools()
        {
            InitializeComponent();
        }


        private void Frm_Tools_Load(object sender, EventArgs e)
        {

        }

        private void Btn_CargarDatos_Click(object sender, EventArgs e)
        {
            mOpcion = "CD";
            CargaDiferencias();
        }

        private void CargaDiferencias()
        {
            string lSql = ""; DataTable lTbl = new DataTable(); int i = 0;
            WsCrud.CrudSoapClient lDAl = new WsCrud.CrudSoapClient(); string lId = "";
            WsCrud.ListaDataSet listaDataSet = new WsCrud.ListaDataSet();
            lSql = string.Concat("  exec SP_Tools '','','','','',1");

            lSql = string.Concat("  exec SP_Tools '','','','','',2");
            listaDataSet = lDAl.ListarAyudaSql(lSql);
            if (listaDataSet.MensajeError.Equals(""))
            {
                if (listaDataSet.DataSet.Tables.Count > 0)
                {
                    lTbl = listaDataSet.DataSet.Tables[0].Copy();

                    Dtg_Datos.DataSource = lTbl;

                    for (i = 0; i < Dtg_Datos.Rows.Count; i++)
                    {
                        if ((Dtg_Datos.Rows[i].Cells["RutGuia"].Value != null) && (Dtg_Datos.Rows[i].Cells["RutGuia"].Value.ToString().Equals((Dtg_Datos.Rows[i].Cells["RutFact"].Value.ToString()))))
                            PintaFila(i, Color.LightGreen, Dtg_Datos);
                        else
                        {
                            if (Dtg_Datos.Rows[i].Cells["Id"].Value != null)
                            {
                                lId = Dtg_Datos.Rows[i].Cells["Id"].Value.ToString();
                                PintaFila(i, Color.LightSalmon, Dtg_Datos);
                                //EliminarRegistro(lId);
                            }

                        }
                        //   PintaFila(i, Color.LightSalmon, Dtg_Datos);

                    }
                    DataGridViewCheckBoxColumn check = new DataGridViewCheckBoxColumn();
                    check.Name = "Eliminar";
                    Dtg_Datos.Columns.Insert(0, check);

                }



            }
        }


        private void PintaFila(int iFila, Color iColor, DataGridView iDtg)
        {
            int i = 0;
            for (i = 0; i < iDtg.ColumnCount; i++)
            {
                iDtg.Rows[iFila].Cells[i].Style.BackColor = iColor;
            }
        }

        private void Btn_eliminar_Click(object sender, EventArgs e)
        {
            DataTable lTbl = new DataTable(); int i = 0;
            WsCrud.CrudSoapClient lDAl = new WsCrud.CrudSoapClient();


            //lSql = string.Concat("  delete from  GuiasPorFactura   where id =", tx_Id .Text );
            //listaDataSet = lDAl.ListarAyudaSql(lSql);

            //for (i=0; i<Dtg_Datos .RowCount;i++)
            //{

            foreach (DataGridViewRow lRow in this.Dtg_Datos.Rows)
            {
                if (lRow.Cells[0].Value != null)
                    if (lRow.Cells[0].Value.ToString() == "True")
                    {
                        tx_Id.Text = lRow.Cells["id"].Value.ToString();
                        EliminarRegistro(tx_Id.Text);
                    }

            }




            CargaDiferencias();
        }

        private void EliminarRegistro(string lId)
        {
            string lSql = ""; WsCrud.CrudSoapClient lDAl = new WsCrud.CrudSoapClient();
            lSql = string.Concat("  delete from  GuiasPorFactura   where id =", lId);
            WsCrud.ListaDataSet listaDataSet = new WsCrud.ListaDataSet();
            listaDataSet = lDAl.ListarAyudaSql(lSql);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RevisaClientes();
        }


        private void RevisaClientes()
        {
            string lSql = "";  WsCrud.CrudSoapClient   lDAl = new  WsCrud.CrudSoapClient (); int i = 0; string lTxAux = "";
            lSql = string.Concat("  select distinct  rutcliente, cliente , '0' NroGuiasXFact, '0' NroGuiasXVinc  from obras where EstadoAlta <> 'FIN' ");
            WsCrud.ListaDataSet listaDataSet = new WsCrud.ListaDataSet(); DataTable lTbl = new DataTable(); DataView lVista = null;
            listaDataSet = lDAl.ListarAyudaSql(lSql); string lRut = ""; DataSet lDtsNoFact = new DataSet();
            DataTable lTblGuiasXVicular = new DataTable();Clases.ClsComun lCom = new Clases.ClsComun();
            lTbl = listaDataSet.DataSet.Tables[0].Copy();

            Pb_.Maximum = lTbl.Rows.Count;
            Pb_.Minimum = 1;
            Pb_.Value = 1;
            for (i = 0; i < lTbl.Rows.Count; i++)
            {
                if (Pb_.Value < Pb_.Maximum)
                    Pb_.Value = Pb_.Value + 1;
                else
                    Pb_.Value = Pb_.Value - 1;

                lRut = lTbl.Rows[i]["rutcliente"].ToString().Substring(0, lTbl.Rows[i]["rutcliente"].ToString().Length - 2);
                lDtsNoFact = lDAl.ObtenerDetalleDespachadoSinFacturar(lRut);
                lVista = new DataView(lDtsNoFact.Tables[0], "ValorKgs>0", "", DataViewRowState.CurrentRows);
                lTxAux = lCom.ObtenerTotalDespachadoSinFacturar(lVista, "GXF");
                //lTxAux = lVista.Count.ToString();
                //lTxAux = lDtsNoFact.Tables[0].Rows.Count.ToString();
                lTbl.Rows[i]["NroGuiasXFact"] = lTxAux;

                lTblGuiasXVicular = ObtenerGuiasPorVincular(lRut);
                if (lTblGuiasXVicular.Rows.Count > 0)
                {
                    lVista = new DataView(lTblGuiasXVicular, "Vinculada='S/V'", "", DataViewRowState.CurrentRows);
                    // lTxAux = lVista.Count.ToString();
                    lTxAux = lCom.ObtenerTotalDespachadoSinFacturar(lVista, "SV");
                    //lTxAux = lDtsNoFact.Tables[0].Rows.Count.ToString();
                    lTbl.Rows[i]["NroGuiasXVinc"] = lTxAux;
                }

            }

            mTblDAtos = lTbl.Copy();
            Dtg_Datos.DataSource = mTblDAtos;
            // lVista = new DataView(lTbl, "NroGuiasXFact<>NroGuiasXVinc", "cliente", DataViewRowState.CurrentRows);
            //Dtg_Datos.DataSource = lVista; // lTbl;
            for (i = 0; i < Dtg_Datos.Rows.Count; i++)
            {
                if (Dtg_Datos.Rows[i].Cells["NroGuiasXFact"].Value != null)
                    if (Dtg_Datos.Rows[i].Cells["NroGuiasXFact"].Value.ToString().Equals(Dtg_Datos.Rows[i].Cells["NroGuiasXVinc"].Value.ToString()))
                    {
                        Dtg_Datos.Rows[i].Cells["NroGuiasXFact"].Style.BackColor = Color.LightGreen;
                        Dtg_Datos.Rows[i].Cells["NroGuiasXVinc"].Style.BackColor = Color.LightGreen;
                    }

                }

            }

        private DataTable ObtenerGuiasPorVincular(string irut)
        {
            WsCrud.CrudSoapClient lDAl = new WsCrud.CrudSoapClient(); string CodGuiaINET = ""; string CodGuia = "";
            string lSql = " "; DataTable lTbl = new DataTable(); string lrut = ""; int i = 0;
            DataTable lTbl2 = new DataTable(); int k = 0; DataTable lTblFinal = new DataTable();
            WsCrud.ListaDataSet listaDataSet = new WsCrud.ListaDataSet();
            lSql = String.Concat(" select distinct cliente, estadoalta,  codigo_inet,  Empresa  from obras  ");
            lSql = String.Concat(lSql, " Where rutCliente like '%", irut, "%'  and estadoalta<>'FIN' ");



            listaDataSet = lDAl.ListarAyudaSql(lSql);
            if ((listaDataSet.MensajeError.Trim().Length == 0) && (listaDataSet.DataSet.Tables.Count > 0))
            {
                lTbl = listaDataSet.DataSet.Tables[0].Copy();

                for (i = 0; i < lTbl.Rows.Count; i++)
                {
                    CodGuiaINET = lTbl.Rows[i]["Codigo_INET"].ToString();
                    CodGuia = ""; // lTbl.Rows[i]["CodigoGuia_INET"].ToString();
                    lrut = irut; // lTbl.Rows[i]["RutCliente"].ToString();

                    switch (lTbl.Rows[i]["Empresa"].ToString().ToUpper())
                    {
                        case "TO":
                            lSql = String.Concat(" exec SP_Consultas_WS  172,'", CodGuia, "','", lrut, "','", CodGuiaINET, "','','','','' ");
                            listaDataSet = lDAl.ListarAyudaSql(lSql);
                            if ((listaDataSet.MensajeError.Trim().Length == 0) && (listaDataSet.DataSet.Tables.Count > 0))
                            {
                                lTbl2 = listaDataSet.DataSet.Tables[0].Copy();
                                lTblFinal.Merge(lTbl2);
                            }

                            break;
                       case "TOSOL":
                            lSql = String.Concat(" exec SP_Consultas_WS  186,'", CodGuia, "','", lrut, "','", CodGuiaINET, "','','','','' ");
                            listaDataSet = lDAl.ListarAyudaSql(lSql);
                            if ((listaDataSet.MensajeError.Trim().Length == 0) && (listaDataSet.DataSet.Tables.Count > 0))
                            {
                                lTbl2 = listaDataSet.DataSet.Tables[0].Copy();
                                lTblFinal.Merge(lTbl2);
                            }
                            break;

                    }

                }

            }



            return lTblFinal;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string lRut = Tx_rut.Text;
            if (Tx_rut.Text.Length > 0)
            {
                Metalurgica.Tools.Frm_DetalleCliente lFrm = new Metalurgica.Tools.Frm_DetalleCliente();
                lFrm.InicializaDatos(lRut);
                lFrm.Show();
            }
        }

        private void Dtg_Datos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //int index = e.RowIndex;
            //string lRut = Dtg_Datos.Rows[index].Cells["RutCliente"].Value.ToString();

            //Tx_rut.Text = lRut;

        }

        private void Btn_SoloDif_Click(object sender, EventArgs e)
        {
            //Dtg_Datos.DataSource = mTblDAtos;
            int i = 0;
            DataView  lVista = new DataView(mTblDAtos, "NroGuiasXFact<>NroGuiasXVinc", "cliente", DataViewRowState.CurrentRows);
            Dtg_Datos.DataSource = lVista; // lTbl;
            for (i = 0; i < Dtg_Datos.Rows.Count; i++)
            {
                if (Dtg_Datos.Rows[i].Cells["NroGuiasXFact"].Value != null)
                    if (Dtg_Datos.Rows[i].Cells["NroGuiasXFact"].Value.ToString().Equals(Dtg_Datos.Rows[i].Cells["NroGuiasXVinc"].Value.ToString()))
                    {
                        Dtg_Datos.Rows[i].Cells["NroGuiasXFact"].Style.BackColor = Color.LightGreen;
                        Dtg_Datos.Rows[i].Cells["NroGuiasXVinc"].Style.BackColor = Color.LightGreen;
                    }

            }
        }

        private void Btn_Todos_Click(object sender, EventArgs e)
        {
            int i = 0;
            DataView lVista = new DataView(mTblDAtos, "", "cliente", DataViewRowState.CurrentRows);
            Dtg_Datos.DataSource = lVista; // lTbl;
            for (i = 0; i < Dtg_Datos.Rows.Count; i++)
            {
                if (Dtg_Datos.Rows[i].Cells["NroGuiasXFact"].Value != null)
                    if (Dtg_Datos.Rows[i].Cells["NroGuiasXFact"].Value.ToString().Equals(Dtg_Datos.Rows[i].Cells["NroGuiasXVinc"].Value.ToString()))
                    {
                        Dtg_Datos.Rows[i].Cells["NroGuiasXFact"].Style.BackColor = Color.LightGreen;
                        Dtg_Datos.Rows[i].Cells["NroGuiasXVinc"].Style.BackColor = Color.LightGreen;
                    }

            }
        }

        private void Btn_CargaMonNumDoc_Click(object sender, EventArgs e)
        {
            WsCrud.CrudSoapClient lDAl = new WsCrud.CrudSoapClient();  
            string lSql = " "; DataTable lTbl = new DataTable(); 
            DataTable lTbl2 = new DataTable(); int k = 0; DataTable lTblFinal = new DataTable();
            WsCrud.ListaDataSet listaDataSet = new WsCrud.ListaDataSet();
            lSql = String.Concat(" select MOVNUMDOC , Url_WS ,   FechaRegistro , EstadoEnvio , Origen ,  *    ");
            lSql = String.Concat(lSql, "  from Log_WS_INET where MOVNUMDOC=", Tx_MovNumDoc.Text);

              listaDataSet = lDAl.ListarAyudaSql(lSql);

            listaDataSet = lDAl.ListarAyudaSql(lSql);
            if ((listaDataSet.MensajeError.Trim().Length == 0) && (listaDataSet.DataSet.Tables.Count > 0))
            {
                lTbl = listaDataSet.DataSet.Tables[0].Copy();
                Dtg_Datos.DataSource = lTbl;

            }


        }


        private DataTable ObtenerTablaINET()
        {
            DataTable lTblINET = new DataTable();
            lTblINET.Columns.Add("Codigo", Type.GetType(("System.String")));
            lTblINET.Columns.Add("Cantidad", Type.GetType(("System.String")));
            lTblINET.Columns.Add("FechaMov", Type.GetType(("System.String")));
            lTblINET.Columns.Add("Glosa1", Type.GetType(("System.String")));
            lTblINET.Columns.Add("Glosa2", Type.GetType(("System.String")));
            lTblINET.Columns.Add("Procesado", Type.GetType(("System.String")));

            return lTblINET;

        }

        private string ObtenerDatosXml(string iTag, string iDato)
        {
            string lRes = "";string lDatosXml = "";int lIndexIni = 0; int lIndexFin = 0;

            lDatosXml = iDato.Replace("&lt;", "<");
            lDatosXml = lDatosXml.Replace("&gt;", ">");
            lDatosXml = lDatosXml.Replace("&amp;lt;", "<");
            lDatosXml = lDatosXml.Replace("&amp;gt;", ">");

            switch (iTag)
            {
                case "Codigo":  // debemos encontrar el valor del tag de Codigo
                    //<PRDCOD>CRA6310 </PRDCOD>
                    lIndexIni = lDatosXml.IndexOf("<PRDCOD>")+8;
                    lIndexFin = lDatosXml.IndexOf("</PRDCOD>");
                    lRes = lDatosXml.Substring(lIndexIni, (lIndexFin - lIndexIni)).Trim ();
                    break;
                case "Cantidad":  // debemos encontrar el valor del tag de Codigo
                    //<DMOCAN>569</DMOCAN> 
                    lIndexIni = lDatosXml.IndexOf("<DMOCAN>") + 8;
                    lIndexFin = lDatosXml.IndexOf("</DMOCAN>");
                    lRes = lDatosXml.Substring(lIndexIni, (lIndexFin - lIndexIni)).Trim();

                    break;
                case "MovNumDoc":  // debemos encontrar el valor del tag de Codigo
                    //<MOVNUMDOC>281843</MOVNUMDOC> 
                    lIndexIni = lDatosXml.IndexOf("<MOVNUMDOC>") + 11;
                    lIndexFin = lDatosXml.IndexOf("</MOVNUMDOC>");
                    lRes = lDatosXml.Substring(lIndexIni, (lIndexFin - lIndexIni)).Trim();

                    break;
                case "Glosa":  // debemos encontrar el valor del tag de Codigo
                    //<MOVGLO1>cmonatano -  -</MOVGLO1> 
                    lIndexIni = lDatosXml.IndexOf("<MOVGLO1>") + 9;
                    lIndexFin = lDatosXml.IndexOf("</MOVGLO1>");
                    lRes = lDatosXml.Substring(lIndexIni, (lIndexFin - lIndexIni)).Trim();

                    break;
            }

                    return lRes;
        }

        private void Btn_InvocarWS_Click(object sender, EventArgs e)
        {
            DataTable lTblINET = new DataTable(); DataRow iROw = null; string lXmEnviado = "";
            string lSql = ""; Clases.ClsComun lCom = new Clases.ClsComun(); string lFechaMov = "";
            Ws_TO.Ws_ToSoapClient lPX = new Ws_TO.Ws_ToSoapClient(); string New_MovNumDoc = "";
            Ws_TO.Objeto_WsINET lObjINET = new Ws_TO.Objeto_WsINET(); string inet_msg = "";
            Integracion_INET.Tipo_InvocaWS lRespuestaWS_INET = new Integracion_INET.Tipo_InvocaWS();
            string lGlosa1 = ""; string lGlosa2 = ""; string lCodMaterial = ""; string lCantidad = "";
            string Old_MovNumDoc = ""; string lId_LogWS = "";string lEstado = "";

            // 1.- Se Integra con INET
            DataTable lTblFinal = new DataTable(); DataSet lDts = new DataSet();
         //   DataView lVista = null; string lEstado = "";
            //try
            //{

                lXmEnviado = Dtg_Datos.Rows[0].Cells["Xml_Enviado"].Value.ToString();
            Old_MovNumDoc = Dtg_Datos.Rows[0].Cells["MOVNUMDOC"].Value.ToString();
            lId_LogWS = Dtg_Datos.Rows[0].Cells["Id"].Value.ToString();
            lCodMaterial = ObtenerDatosXml("Codigo", lXmEnviado);
                lCantidad = ObtenerDatosXml("Cantidad", lXmEnviado);
            lGlosa1 = ObtenerDatosXml("Glosa", lXmEnviado);
            lFechaMov = DateTime.Now.ToString();

                lFechaMov = lFechaMov.Replace("/", "-");
                //Debemos saber que  sucursal esta haciendo la invocaión
                int lIdSucursal = lCom.OBtenerIdSucursal();
                string lIdDetalle = "0"; DataSet lDtsTmp = new DataSet();

                //Por cada Fila son 2 Integraciones 1.- Producido 2.- Despuente si lo hay.
                //Primero lo Produccido 
                //Obtenemos el Objeto con los datos
                lTblFinal = ObtenerTablaINET();
                lTblINET = ObtenerTablaINET();
                iROw = lTblINET.NewRow();
                iROw["Codigo"] = lCodMaterial; // iFila.Cells["CodMaterial"].Value.ToString();
                iROw["Cantidad"] = lCantidad; // lCom.Val(iFila.Cells["KgsProducidos"].Value.ToString());
                iROw["FechaMov"] = lFechaMov;
                //lGlosa1 = string.Concat(Program.currentUser.Login, " - ", lCom.ObtenerInicioFIn_Turno(Program.currentUser.IdTotem.ToString()));
                iROw["Glosa1"] = lGlosa1;
                lGlosa2 = "Producido";
                iROw["Glosa2"] = lGlosa2;

                lTblINET.Rows.Add(iROw);
                lDts.Tables.Add(lTblINET.Copy());
            //if (lIdSucursal == 1)   //Calama
                //lObjINET = lPX.ObtenerObjetoINET_Calama(lDts, lFechaMov, lGlosa1, lGlosa2);




            //if ((lIdSucursal == 4) || (lIdSucursal == 2))   // Santiago
            lObjINET = lPX.ObtenerObjetoINET(lDts, lFechaMov, lGlosa1, lGlosa2);

            lRespuestaWS_INET = InvocarWS_INET(lObjINET);

                inet_msg = lCom.buscarTagError(lRespuestaWS_INET.XML_Respuesta.ToString());
                if (inet_msg.Trim().ToUpper().Equals("OK"))
                {
                    lEstado = "OK";
                    New_MovNumDoc = lObjINET.Movnumdoc;

                    lSql = string.Concat(" Update   ProductosIntegradosINET  set movnumdoc=", New_MovNumDoc, " where movnumdoc=", Old_MovNumDoc);
                    lDtsTmp = lPX.ObtenerDatos(lSql);
                    lSql = string.Concat(" Update   DetalleProductoIntegrado  set movnumdoc=", New_MovNumDoc, " , EstadoIntegracion='OK' where movnumdoc=", Old_MovNumDoc);
                    lDtsTmp = lPX.ObtenerDatos(lSql);
                    //Eliminamos el Registro con Error 
                    lSql = string.Concat(" Delete from     Log_WS_INET  where id=", lId_LogWS);
                    lDtsTmp = lPX.ObtenerDatos(lSql);
            }
                else
                    lEstado = "ER";

 
            //}
        }

       

        private Integracion_INET.Tipo_InvocaWS InvocarWS_INET(Ws_TO.Objeto_WsINET iObjINET)
        {
            Px_MovExistenciasINET.wsmovexiallSoapPortClient lPxMovEx = new Px_MovExistenciasINET.wsmovexiallSoapPortClient();
            Px_MovExistenciasINET.ExecuteRequest lObjEntradaMov = new Px_MovExistenciasINET.ExecuteRequest();
            Px_MovExistenciasINET.ExecuteResponse lResMovEx = new Px_MovExistenciasINET.ExecuteResponse();
            Integracion_INET.Tipo_InvocaWS lResultado = new Integracion_INET.Tipo_InvocaWS();
            Integracion_INET.MovExistencias lTipoEntradaEx = new Integracion_INET.MovExistencias();
            XmlSerializer lXmlSal = null; StringWriter strDataXml = new StringWriter(); string lEstadoProceso = "";
            String lSql = ""; WsCrud.CrudSoapClient lDAl = new WsCrud.CrudSoapClient();
            WsCrud.ListaDataSet lDts = new WsCrud.ListaDataSet(); Clases.ClsComun lCom = new Clases.ClsComun();
            //lDts As New ListaDataSet
            //DataSet   lDts =new DataSet ();

            //Integracion_INET .MovExistencias             
            try
            {
                // iEstado.Text = iEstado.Text & vbCrLf & "Cargando Objeto Entrada Bodega Productos Terminados  " : iEstado.Refresh()
                lTipoEntradaEx = lCom.CargaObjEntradaBodegaProdTerm_INET(iObjINET);
                // lObjEntradaMov.Intrasnporte = lTipoEntradaEx.ToString ();
                lObjEntradaMov.Intrasnporte = lCom.CreaXmlEntradaProductosTerminados_INET_SolicitudMP(iObjINET);// CreaXmlEntradaProductosTErminados_INET(lTipoEntradaEx);

               
                lResultado.XML_Enviado = lObjEntradaMov.Intrasnporte;

                lResultado.URL_WS = lPxMovEx.Endpoint.ListenUri.AbsoluteUri;
                lResMovEx.Outtansporte = lPxMovEx.Execute(lObjEntradaMov.Intrasnporte);
                lXmlSal = new XmlSerializer(lResMovEx.Outtansporte.GetType());
                lXmlSal.Serialize(strDataXml, lResMovEx.Outtansporte);
                lResultado.XML_Respuesta = strDataXml.ToString();
                //    iEstado.Text = iEstado.Text & vbCrLf & "Estado P1  :" & lResultado.XML_Respuesta.ToUpper.IndexOf("OK") : iEstado.Refresh()
                if (lResultado.XML_Respuesta.ToUpper().IndexOf("OK") > -1)
                    lEstadoProceso = "OK";
                else
                    lEstadoProceso = "ER";

                lResultado.XML_Respuesta = lResultado.XML_Respuesta.Replace("&lt;", "<");
                lResultado.XML_Respuesta = lResultado.XML_Respuesta.Replace("&gt;", ">");
                lResultado.XML_Respuesta = lResultado.XML_Respuesta.Replace("&amp;lt;", "<");
                lResultado.XML_Respuesta = lResultado.XML_Respuesta.Replace("&amp;gt;", ">");
            }

            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                lSql = string.Concat("exec SP_CRUD_LOG_WS_INET 1,", lResultado.Id, ",", lResultado.IdDespachoCamion);
                lSql = string.Concat(lSql, ",'", lResultado.PatenteCamion, "',0,'", lResultado.XML_Enviado.Replace("'", "''"));
                lSql = string.Concat(lSql, "','", lResultado.XML_Respuesta, "','", lResultado.URL_WS, "','SolicitudMaterial',", lTipoEntradaEx.ExistenciasAll.MOVNUMDOC);
                lSql = string.Concat(lSql, ",'", lEstadoProceso, "'");
                lDts = lDAl.ListarAyudaSql(lSql);
            }
            return lResultado;
        }


    }
}
