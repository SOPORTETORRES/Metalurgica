using System;
using System.Data;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Serialization;
using CommonLibrary2;
using System.Text;
using System.Collections;

namespace Metalurgica
{
    public partial class frmCierreMaterial : Form
    {
        private const string COLUMNNAME_MARCA = "MARCA";
        private const string COLUMNNAME_ID = "ID";
        private const string COLUMNNAME_PRODUCTO = "PRODUCTO";
        private const string COLUMNNAME_PRODUCTO_DESCRIPCION = "DESC_PRODUCTO";
        private const string COLUMNNAME_DIAMETRO = "DIAMETRO";
        private const string COLUMNNAME_LARGO = "LARGO";
        private const string COLUMNNAME_ORIGEN = "ORIGEN";
        private const string COLUMNNAME_ORIGEN_DESCRIPCION = "DESC_ORIGEN";
        private const string COLUMNNAME_TIPO = "TIPO";
        private const string COLUMNNAME_CANTIDAD = "CANTIDAD";
        private const string COLUMNNAME_KILOS = "KILOS";
        private const string COLUMNNAME_CANTIDAD_RECEP = "CANTIDAD_RECEP";

        private Forms forms = new Forms();
        private CurrentUser mUserLog = new CurrentUser();


        public frmCierreMaterial()
        {
            InitializeComponent();
            this.dgvProductos.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(dgvProductos_RowPostPaint);
        }

        private void dgvProductos_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvProductos.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void tlbSelectAll_Click(object sender, EventArgs e)
        {
            dtpFechaRecepcion.Focus();
            forms.dataGridViewRowsChecked(dgvProductos, COLUMNNAME_MARCA, true);
        }

        private void tlbUndoSelectAll_Click(object sender, EventArgs e)
        {
            dtpFechaRecepcion.Focus();
            forms.dataGridViewRowsChecked(dgvProductos, COLUMNNAME_MARCA, false);
        }


          private bool Agregar_IdSolicitud( ArrayList iList, string lDato)
        {
            bool lres = true;int i = 0;

            for (i = 0; i < iList.Count; i++)
            {
                if (iList[i].ToString().ToUpper().Equals(lDato.ToUpper()))
                {
                    lres = false;
                }
            }
            return lres;
        }



        private void tlbGuardar_Click(object sender, EventArgs e)
        {
            Ws_TO.Ws_ToSoapClient lPX = new Ws_TO.Ws_ToSoapClient();int i = 0;string lIds_SMP = "";
            Ws_TO.Objeto_WsINET lObjINET = new Ws_TO.Objeto_WsINET(); ArrayList lLista = new ArrayList();
            Integracion_INET.Tipo_InvocaWS lRespuestaWS_INET = new Integracion_INET.Tipo_InvocaWS();
            
            int counter = 0;
            string inet_msg = "", email_msg = "", newLine = Environment.NewLine, tab = "\t";

            string lCodigo="";string lCantidad="";string lFechaMov =""; string lGlosa1=""; string lGlosa2="";

            DataTable lTblINET = new DataTable(); DataRow iFila = null;
            lTblINET .Columns .Add("Codigo",Type.GetType (("System.String")));
            lTblINET.Columns.Add("Cantidad", Type.GetType(("System.String")));
            lTblINET.Columns.Add("FechaMov", Type.GetType(("System.String")));
            lTblINET.Columns.Add("Glosa1", Type.GetType(("System.String")));
            lTblINET.Columns.Add("Glosa2", Type.GetType(("System.String")));
            lTblINET.Columns.Add("Procesado", Type.GetType(("System.String")));



            dtpFechaRecepcion.Focus();
            counter = forms.dataGridViewCountRowsChecked(dgvProductos, COLUMNNAME_MARCA);
            if (counter > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
                    WsOperacion.Solicitud_Material_Detalle solicitud_Material_Detalle = new WsOperacion.Solicitud_Material_Detalle();

                    counter = 0;
                    foreach (DataGridViewRow row in dgvProductos.Rows)
                    {
                        if (row.Cells[COLUMNNAME_MARCA].Value != null)
                        {
                            if ((bool)row.Cells[COLUMNNAME_MARCA].Value == true)
                            {
                                lTblINET.Clear();
                                if (Agregar_IdSolicitud(lLista, row.Cells["SOL_ID"].Value.ToString()))
                                {
                                    lLista.Add(row.Cells["SOL_ID"].Value.ToString());
                                }
                                lCodigo =row.Cells[COLUMNNAME_PRODUCTO].Value.ToString ();
                                //lCantidad=row.Cells[COLUMNNAME_CANTIDAD].Value.ToString ();
                                lCantidad = row.Cells[COLUMNNAME_KILOS].Value.ToString();
                                lFechaMov = DateTime.Now.ToString();
                                lGlosa1=Program.currentUser.Login;
                                lGlosa2 = ObtenerTurno();

                                iFila = lTblINET.NewRow();
                                iFila["Codigo"] = lCodigo;
                                iFila["Cantidad"] = lCantidad;
                                iFila["FechaMov"] = lFechaMov;
                                iFila["Glosa1"] = lGlosa1;
                                iFila["Glosa2"] = lGlosa2;
                                iFila["Procesado"] = "N";                                
                                lTblINET.Rows.Add(iFila);

                                //if (!inet_msg.Trim().ToUpper().Equals("OK"))
                                //    inet_msg = "ERROR NO EXISTE STOCK DEL MATERIAL";

                                // 1.- Se Integra con INET
                                DataTable lTblFinal = new DataTable(); DataSet lDts = new DataSet();
                                //lTblFinal = ObtenerDatosIntegracionINET(lTblINET);
                                lDts.Tables.Add(lTblINET.Copy ());

                                lObjINET = lPX.ObtenerObjetoINET(lDts, lFechaMov, lGlosa1, lGlosa2);
                                lRespuestaWS_INET = InvocarWS_INET(lObjINET);

                                inet_msg = buscarTagError(lRespuestaWS_INET.XML_Respuesta.ToString());
                                if (inet_msg.Trim().ToUpper().Equals("OK"))
                                {
                                    counter++;
                                    if (email_msg.Equals(""))
                                    {
                                        email_msg += "Producto(s):" + newLine + newLine;
                                        email_msg += "Cod.Producto" + tab + "Descripción" + tab + "Cantidad" + newLine;
                                    }
                                    email_msg += row.Cells[COLUMNNAME_PRODUCTO].Value.ToString() + tab + row.Cells[COLUMNNAME_PRODUCTO_DESCRIPCION].Value.ToString() + tab + row.Cells[COLUMNNAME_CANTIDAD_RECEP].Value.ToString() + newLine;
                                }
                                // 2.-  Se Registra el cierre del Producto

                                solicitud_Material_Detalle.Id = Convert.ToInt32(row.Cells[COLUMNNAME_ID].Value.ToString());
                                solicitud_Material_Detalle.Producto = row.Cells[COLUMNNAME_PRODUCTO].Value.ToString();
                                solicitud_Material_Detalle.Usuario_Cierre = Program.currentUser.Login;
                                //solicitud_Material_Detalle.Fecha_Cierre = "";
                                solicitud_Material_Detalle.Tipo = row.Cells[COLUMNNAME_TIPO].Value.ToString().Substring(0, 1);
                                solicitud_Material_Detalle.Cantidad = Convert.ToInt32(row.Cells[COLUMNNAME_CANTIDAD_RECEP].Value.ToString());
                                solicitud_Material_Detalle.Inet_Msg = inet_msg;

                                solicitud_Material_Detalle = wsOperacion.GuardarCierreMaterial(solicitud_Material_Detalle, inet_msg, Program.currentUser.Login, Program.currentUser.ComputerName, Program.currentUser.IdTotem);
                                if (solicitud_Material_Detalle.MensajeError.Equals(""))
                                {
                                    //2) Cargamos el Objeto de INET       
                                    //    DataTable lTblFinal = new DataTable(); DataSet lDts = new DataSet();
                                    //lTblFinal = ObtenerDatosIntegracionINET(lTblINET);
                                    //lDts.Tables.Add(lTblFinal);

                                    //lObjINET = lPX.ObtenerObjetoINET(lDts, lFechaMov, lGlosa1, lGlosa2);
                                    //lRespuestaWS_INET = InvocarWS_INET(lObjINET);


                                    //lObjINET = lPX.ObtenerObjetoINETPorProducto(solicitud_Material_Detalle.Producto.ToString(), lCantidad.ToString(), lFechaMov, lGlosa1, lGlosa2);
                                    //lRespuestaWS_INET = InvocarWS_INET_V1(lObjINET);
                                    //// Invocamos el WS de INET
                                    //// Comunicacion con el WS INET.

                                    row.Cells[0].Value = false;
                                }
                                else
                                    MessageBox.Show(solicitud_Material_Detalle.MensajeError.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

      


                                //3) Notificacion de los productos cerrados correctamente por email.
                                //if (counter > 0)
                                //    EnvioCorreo(email_msg,"",""); 


                                //1) Se registra el cierre del producto.
                                //    solicitud_Material_Detalle.Id = Convert.ToInt32(row.Cells[COLUMNNAME_ID].Value.ToString());
                                //solicitud_Material_Detalle.Producto = row.Cells[COLUMNNAME_PRODUCTO].Value.ToString();
                                //solicitud_Material_Detalle.Usuario_Cierre = Program.currentUser.Login;
                                ////solicitud_Material_Detalle.Fecha_Cierre = "";
                                //solicitud_Material_Detalle.Tipo = row.Cells[COLUMNNAME_TIPO].Value.ToString().Substring(0, 1);
                                //solicitud_Material_Detalle.Cantidad = Convert.ToInt32(row.Cells[COLUMNNAME_CANTIDAD_RECEP].Value.ToString());
                                //solicitud_Material_Detalle.Inet_Msg = inet_msg;

                                //solicitud_Material_Detalle = wsOperacion.GuardarCierreMaterial(solicitud_Material_Detalle, inet_msg, Program.currentUser.Login, Program.currentUser.ComputerName, Program.currentUser.IdTotem);
                                //if (solicitud_Material_Detalle.MensajeError.Equals(""))

                            }
                        }
                    }
                    for (i = 0; i < lLista.Count; i++)
                    {
                        lIds_SMP = string.Concat(lIds_SMP, ",", lLista[i]);
                    }
                    EnvioCorreo(lIds_SMP, Program.currentUser.Login, "Linea de Corte");
                    //2) Cargamos el Objeto de INET
                    //Se debe informar en solo un movimiento todos los productos
                    //Recorremos los productos y si hay repetidos los consolidamos en solo una linea
                    //DataTable lTblFinal = new DataTable(); DataSet lDts = new DataSet();
                    //lTblFinal = ObtenerDatosIntegracionINET(lTblINET);
                    //lDts.Tables.Add(lTblFinal);

                    //lObjINET = lPX.ObtenerObjetoINET(lDts, lFechaMov, lGlosa1, lGlosa2);
                    //lRespuestaWS_INET = InvocarWS_INET_V1(lObjINET);
                    //// Invocamos el WS de INET
                    //// Comunicacion con el WS INET.
                    //inet_msg = buscarTagError(lRespuestaWS_INET.XML_Respuesta.ToString());

                    //inet_msg = Microsoft.VisualBasic.Interaction.InputBox("Ingrese la accion resultante del WS (ok/error)", this.Text, "OK", -1, -1);

                    tlbActualizar.PerformClick();
                    MessageBox.Show("Proceso finalizado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Cursor.Current = Cursors.Default;
            }
            else
                MessageBox.Show("No existen registros seleccionados.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private DataTable ObtenerDatosIntegracionINET(DataTable iTblOrigen)
        {
            DataTable lTblFinal = new DataTable(); int i = 0; int k = 0;
            string lCodigo = ""; DataView lVista1 = null; string lTmp = "";
            int iCanTotal = 0; Clases.ClsComun lCom = new Clases.ClsComun();
            DataRow lFilaFinal = null; string lCodigoPr = "";
            string[] lPartes = null; //iTextNodo.Split(new Char[] { '\\' });
            try                         
            {
                lCodigoPr = CodigosPorProcesar(iTblOrigen);
                lPartes = lCodigoPr.Split(new Char[] { '-' });
                if (iTblOrigen.Rows.Count > 0)
                {
                    //lCodigo = iTblOrigen.Rows[0]["codigo"].ToString();
                    lTblFinal = iTblOrigen.Clone();
                    if (lPartes.Length > 0)
                    {
                        for (k = 0; k < lPartes.Length; k++)
                        {
                            if (lTmp.ToString().IndexOf(lPartes [k]) < 0)
                            {
                                //lVista1 = new DataView(iTblOrigen, string.Concat ("Procesado='N' and codigo=",lPartes [k].ToString ()), "", DataViewRowState.CurrentRows);
                                lVista1 = new DataView(iTblOrigen, string.Concat("codigo=", lPartes[k].ToString()), "", DataViewRowState.CurrentRows);
                                if (lVista1.Count > 0)
                                {
                                    iCanTotal = 0;
                                    for (i = 0; i < lVista1.Count; i++)
                                    {
                                        iCanTotal = iCanTotal + lCom.Val(lVista1[i]["cantidad"].ToString());
                                        lVista1[i]["Procesado"] = "S";
                                    }
                                    if (iCanTotal > 0)
                                    {
                                        lFilaFinal = lTblFinal.NewRow();
                                        lFilaFinal["Codigo"] = lPartes[k].ToString();
                                        lFilaFinal["Cantidad"] = iCanTotal;
                                        lFilaFinal["Glosa1"] = lVista1[i-1]["glosa1"].ToString();
                                        lFilaFinal["Glosa2"] = lVista1[i-1]["glosa2"].ToString();
                                        lFilaFinal["Procesado"] = "S";
                                        lTblFinal.Rows.Add(lFilaFinal);
                                        iCanTotal = 0;
                                    }
                                }
                                lTmp = string.Concat(lTmp,lPartes[k], "-");
                            }
                        }
                    }                    
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return lTblFinal;
        
        }

        private string CodigosPorProcesar(DataTable iTblOrigen)
        {
            string lRes = ""; int i = 0;

            for (i = 0; i < iTblOrigen.Rows.Count; i++)
            {
                if (lRes.IndexOf(iTblOrigen.Rows[i]["codigo"].ToString()) < 0)
                {
                    lRes = string.Concat(lRes, iTblOrigen.Rows[i]["codigo"].ToString(),"-");
                }
            }

            return lRes;
        }

        private string ObtenerTurno()
        {
            Px_WS.Ws_ToSoapClient lPx = new Px_WS.Ws_ToSoapClient();  DataSet lDts = new DataSet();
            string lSql = " SP_ConsultasGenerales 77,'','','','',''"; string lRes = "";
            int lHora = 0; Clases.ClsComun lCom = new Clases.ClsComun();


            lDts = lPx.ObtenerDatos(lSql);

            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                lHora =lCom.Val  (lDts.Tables[0].Rows[0]["Hora"].ToString());
                if ((lHora > 7) && (lHora < 19))
                    lRes = "Turno Día";
                else
                    lRes = "Turno Noche";
            }

            return lRes;                   
        }


        public  string  CreaXmlEntradaProductosTErminados_INET(Integracion_INET.MovExistencias  iObj)
    {
            String lRes="";int i=0;
        //Dim lRes As String, lEntDoc As New Tipo_EntDoc, i As Integer = 0
        //Dim lDetDoc As New Tipo_DetDoc, lResumenDoc As New Tipo_ResumenDoc
        String lXML   = "";String lRes1   = "";String  lXmlFinal   = "";

              //sb.Append("<SDT_TRANSPORTE xmlns=\"http://www.informat.cl/ws\">");

        lRes = String.Concat("<SDT_TRANSPORTE xmlns=\"http://www.informat.cl/ws\">" , Environment.NewLine );
        lRes = String.Concat(lRes, "<ACCION>ins</ACCION> ", Environment.NewLine );
        lRes = String.Concat(lRes, " <XML>",  Environment.NewLine );
        lXML = String.Concat(lXML, "	<SDT_MOVEXISTENCIASALL xmlns=&quot;http://www.informat.cl/ws&quot;>",  Environment.NewLine );
        lXML = String.Concat(lXML, "  <SDT_MOVEXISTENCIASALL.MOVIMIENTO> ",  Environment.NewLine );

        lXML = String.Concat(lXML, "  	<TMETIP>", iObj.ExistenciasAll.TMETIP.ToString(), "</TMETIP> ",  Environment.NewLine );

        lXML = String.Concat(lXML, "  	<TMECOD>", iObj.ExistenciasAll.TMECOD.ToString(), "</TMECOD> ", Environment.NewLine );
        lXML = String.Concat(lXML, "  	<MOVSUCCOD>", iObj.ExistenciasAll.MOVSUCCOD.ToString(), "</MOVSUCCOD> ",  Environment.NewLine );
        lXML = String.Concat(lXML, "  	<MOVNUMDOC>", iObj.ExistenciasAll.MOVNUMDOC.ToString(), "</MOVNUMDOC> ", Environment.NewLine );
        lXML = String.Concat(lXML, "  	<MOVFECDOC>", iObj.ExistenciasAll.MOVFECDOC.ToString(), "</MOVFECDOC> ",  Environment.NewLine );
        //'lXML = String.Concat(lXML, "  	<MOVFECDOC>", "2013-12-31", "</MOVFECDOC> ", vbCrLf)
        lXML = String.Concat(lXML, "  	<MOVFECDIG>", iObj.ExistenciasAll.MOVFECDIG.ToString(), "</MOVFECDIG>  ",  Environment.NewLine );
        lXML = String.Concat(lXML, "  	<MOVHORDIG>", iObj.ExistenciasAll.MOVHORDIG.ToString(), "</MOVHORDIG>  ",  Environment.NewLine );
        lXML = String.Concat(lXML, "  	<MOVBODCOD>", iObj.ExistenciasAll.MOVBODCOD.ToString(), "</MOVBODCOD> ",  Environment.NewLine );
        lXML = String.Concat(lXML, "  	<MOVBODSUC>", iObj.ExistenciasAll.MOVBODSUC.ToString(), "</MOVBODSUC> ",  Environment.NewLine );
        lXML = String.Concat(lXML, "  	<MOVGLO1>", iObj.ExistenciasAll.MOVGLO1.ToString(), "</MOVGLO1> ",  Environment.NewLine );
        lXML = String.Concat(lXML, "  	<MOVGLO2/> ", iObj.ExistenciasAll.MOVGLO2.ToString(), "</MOVGLO1> ", Environment.NewLine);
        lXML = String.Concat(lXML, "  	<MOVSIS>", iObj.ExistenciasAll.MOVSIS.ToString(), "</MOVSIS> ",  Environment.NewLine );
        lXML = String.Concat(lXML, "  	<MOVULTSEC>", iObj.ExistenciasAll.MOVULTSEC.ToString(), "</MOVULTSEC>",  Environment.NewLine );

        lXML = String.Concat(lXML, "  	<DETALLE>",  Environment.NewLine );
        lXML = String.Concat(lXML, "  	            <SDT_MOVEXISTENCIASALL.MOVIMIENTO.DET_MOVTO>",  Environment.NewLine );
        lXML = String.Concat(lXML, "  	            <DMONUMSEC>", iObj.ExistenciasDet.DMONUMSEC.ToString(), "</DMONUMSEC>",  Environment.NewLine );

        lXML = String.Concat(lXML, "  	            <PRDCOD>", iObj.ExistenciasDet.PRDCOD.ToString(), "</PRDCOD>",  Environment.NewLine );
        lXML = String.Concat(lXML, "  	            <PRDEXIPLA>", iObj.ExistenciasDet.PRDEXIPLA.ToString(), "</PRDEXIPLA>",  Environment.NewLine );
        lXML = String.Concat(lXML, "  	            <DMOPLACOD>", iObj.ExistenciasDet.DMOPLACOD.ToString(), "</DMOPLACOD>",  Environment.NewLine );
        lXML = String.Concat(lXML, "  	            <DMOCENCOD>", iObj.ExistenciasDet.DMOCENCOD.ToString(), "</DMOCENCOD>",  Environment.NewLine );
        lXML = String.Concat(lXML, "  	            <DMOITECOD>", iObj.ExistenciasDet.DMOITECOD.ToString(), "</DMOITECOD>",  Environment.NewLine );

        lXML = String.Concat(lXML, "  	            <DMOARECOD>", iObj.ExistenciasDet.DMOARECOD.ToString(), "</DMOARECOD>",  Environment.NewLine );
        lXML = String.Concat(lXML, "  	            <DMOCAN>", iObj.ExistenciasDet.DMOCAN.ToString(), "</DMOCAN>",  Environment.NewLine );
        lXML = String.Concat(lXML, "  	            <DMOPREUNI>", iObj.ExistenciasDet.DMOPREUNI.ToString(), "</DMOPREUNI>",  Environment.NewLine );
        lXML = String.Concat(lXML, "  	            <DMOVALTOT>", iObj.ExistenciasDet.DMOVALTOT.ToString(), "</DMOVALTOT>",  Environment.NewLine );
        lXML = String.Concat(lXML, "  	            <INVMOV11> 0.0000 </INVMOV11>", Environment.NewLine);
        lXML = String.Concat(lXML, "  	            <INVMOV12>0.00 </INVMOV12>", Environment.NewLine);
        lXML = String.Concat(lXML, "  	            <INVMOV13>0.00 </INVMOV13>", Environment.NewLine);
        lXML = String.Concat(lXML, "  	            <INVMOV14>0.0000 </INVMOV14>", Environment.NewLine);
        lXML = String.Concat(lXML, "  	            <INVMOV15>0.00 </INVMOV15>", Environment.NewLine);
        lXML = String.Concat(lXML, "  	            <INVMOV16>0.0000 </INVMOV16>", Environment.NewLine);
        lXML = String.Concat(lXML, "  	            <INVMOV17>0.0000 </INVMOV17>", Environment.NewLine);
        lXML = String.Concat(lXML, "  	  </SDT_MOVEXISTENCIASALL.MOVIMIENTO.DET_MOVTO>",  Environment.NewLine );
        lXML = String.Concat(lXML, "</DETALLE> ",  Environment.NewLine );
        lXML = String.Concat(lXML, "<MOVVALTOT>", iObj.ExistenciasAll.MOVVALTOT.ToString(), "</MOVVALTOT> ",  Environment.NewLine );
        lXML = String.Concat(lXML, "</SDT_MOVEXISTENCIASALL.MOVIMIENTO> ",  Environment.NewLine );
        lXML = String.Concat(lXML, "</SDT_MOVEXISTENCIASALL> ",  Environment.NewLine );

        lRes1 = String.Concat(lRes1, "</XML>",  Environment.NewLine );
        lRes1 = String.Concat(lRes1, "</SDT_TRANSPORTE>", Environment.NewLine);

        //'cambiamos los caracteres 
        //'        NOTA: Se realizó un encoding al XML con transporte, por lo cual:
        //'el signo < se reemplazó por &lt; 
        //'el signo > se reemplazó por &gt;
        lXML = lXML.Replace("<", "&lt;");
        lXML = lXML.Replace(">", "&gt;");

        lXmlFinal =String.Concat(lRes , lXML , lRes1);
        return lXmlFinal;

        }

        public string CreaXmlEntradaProductosTerminados_INET_SolicitudMP(Ws_TO .Objeto_WsINET   iObj)
        {
            String lRes = ""; int i = 0;
            //Dim lRes As String, lEntDoc As New Tipo_EntDoc, i As Integer = 0
            //Dim lDetDoc As New Tipo_DetDoc, lResumenDoc As New Tipo_ResumenDoc
            String lXML = ""; String lRes1 = ""; String lXmlFinal = "";

            //sb.Append("<SDT_TRANSPORTE xmlns=\"http://www.informat.cl/ws\">");

            lRes = String.Concat("<SDT_TRANSPORTE xmlns=\"http://www.informat.cl/ws\">", Environment.NewLine);
            lRes = String.Concat(lRes, "<ACCION>ins</ACCION> ", Environment.NewLine);
            lRes = String.Concat(lRes, " <XML>", Environment.NewLine);
            lXML = String.Concat(lXML, "	<SDT_MOVEXISTENCIASALL xmlns=&quot;http://www.informat.cl/ws&quot;>", Environment.NewLine);
            lXML = String.Concat(lXML, "  <SDT_MOVEXISTENCIASALL.MOVIMIENTO> ", Environment.NewLine);
            lXML = String.Concat(lXML, "  	<TMETIP>", iObj.Tmetip .ToString(), "</TMETIP> ", Environment.NewLine);
            lXML = String.Concat(lXML, "  	<TMECOD>", iObj.Tmecod .ToString(), "</TMECOD> ", Environment.NewLine);
            lXML = String.Concat(lXML, "  	<MOVSUCCOD>", iObj.Movsuccod .ToString(), "</MOVSUCCOD> ", Environment.NewLine);
            lXML = String.Concat(lXML, "  	<MOVNUMDOC>", iObj.Movnumdoc.ToString(), "</MOVNUMDOC> ", Environment.NewLine);
            lXML = String.Concat(lXML, "  	<MOVFECDOC>", iObj.Movfecdoc.ToString(), "</MOVFECDOC> ", Environment.NewLine);            
            lXML = String.Concat(lXML, "  	<MOVFECDIG>", iObj.Movfecdig.ToString(), "</MOVFECDIG>  ", Environment.NewLine);
            lXML = String.Concat(lXML, "  	<MOVHORDIG>", iObj.Movhordig .ToString(), "</MOVHORDIG>  ", Environment.NewLine);
            lXML = String.Concat(lXML, "  	<MOVBODCOD>", iObj.Movbodcod .ToString(), "</MOVBODCOD> ", Environment.NewLine);
            lXML = String.Concat(lXML, "  	<MOVBODSUC>", iObj.Movbodsuc .ToString(), "</MOVBODSUC> ", Environment.NewLine);
            lXML = String.Concat(lXML, "  	<MOVGLO1>", iObj.Movglo1 .ToString(), "</MOVGLO1> ", Environment.NewLine);
            lXML = String.Concat(lXML, "  	<MOVGLO2>", iObj.Movglo2.ToString(), "</MOVGLO2> ", Environment.NewLine);
            lXML = String.Concat(lXML, "  	<MOVSIS>", iObj.Movsis.ToString(), "</MOVSIS> ", Environment.NewLine);
            lXML = String.Concat(lXML, "  	<MOVULTSEC>", iObj.Movultsec.ToString(), "</MOVULTSEC>", Environment.NewLine);

            for (i = 0; i < iObj.DetalleMov.Length; i++)
            {
                lXML = String.Concat(lXML, "  	<DETALLE>", Environment.NewLine);
                lXML = String.Concat(lXML, "  	            <SDT_MOVEXISTENCIASALL.MOVIMIENTO.DET_MOVTO>", Environment.NewLine);
                lXML = String.Concat(lXML, "  	            <DMONUMSEC>", iObj.DetalleMov[i].Dmonumsec.ToString(), "</DMONUMSEC>", Environment.NewLine);
                lXML = String.Concat(lXML, "  	            <PRDCOD>", iObj.DetalleMov[i].Prdcod .ToString(), "</PRDCOD>", Environment.NewLine);
                lXML = String.Concat(lXML, "  	            <PRDEXIPLA>", iObj.DetalleMov[i].Prdexipla .ToString(), "</PRDEXIPLA>", Environment.NewLine);
                lXML = String.Concat(lXML, "  	            <DMOPLACOD>", iObj.DetalleMov[i].Dmoplacod.ToString(), "</DMOPLACOD>", Environment.NewLine);
                lXML = String.Concat(lXML, "  	            <DMOCENCOD>", iObj.DetalleMov[i].Dmocencod .ToString(), "</DMOCENCOD>", Environment.NewLine);
                lXML = String.Concat(lXML, "  	            <DMOITECOD>", iObj.DetalleMov[i].Dmoitecod .ToString(), "</DMOITECOD>", Environment.NewLine);
                lXML = String.Concat(lXML, "  	            <DMOARECOD>", iObj.DetalleMov[i].Dmoarecod .ToString(), "</DMOARECOD>", Environment.NewLine);
                lXML = String.Concat(lXML, "  	            <DMOCAN>", iObj.DetalleMov[i].Dmocan .ToString(), "</DMOCAN>", Environment.NewLine);
                lXML = String.Concat(lXML, "  	            <DMOPREUNI>", iObj.DetalleMov[i].Dmopreuni .ToString(), "</DMOPREUNI>", Environment.NewLine);
                lXML = String.Concat(lXML, "  	            <DMOVALTOT>", iObj.DetalleMov[i].Dmovaltot .ToString(), "</DMOVALTOT>", Environment.NewLine);
                lXML = String.Concat(lXML, "  	            <INVMOV11>", iObj.DetalleMov[i].Invmov11 .ToString(), "</INVMOV11>", Environment.NewLine);

                lXML = String.Concat(lXML, "  	            <INVMOV12>", iObj.DetalleMov[i].Invmov12.ToString(), "</INVMOV12>", Environment.NewLine);

                lXML = String.Concat(lXML, "  	            <INVMOV13>", iObj.DetalleMov[i].Invmov13.ToString(), "</INVMOV13>", Environment.NewLine);
                lXML = String.Concat(lXML, "  	            <INVMOV14>", iObj.DetalleMov[i].Invmov14.ToString(), "</INVMOV14>", Environment.NewLine);
                lXML = String.Concat(lXML, "  	            <INVMOV15>", iObj.DetalleMov[i].Invmov15.ToString(), "</INVMOV15>", Environment.NewLine);
                lXML = String.Concat(lXML, "  	            <INVMOV16>", iObj.DetalleMov[i].Invmov16.ToString(), "</INVMOV16>", Environment.NewLine);
                lXML = String.Concat(lXML, "  	            <INVMOV17>", iObj.DetalleMov[i].Invmov17.ToString(), "</INVMOV17>", Environment.NewLine);
                lXML = String.Concat(lXML, "  	  </SDT_MOVEXISTENCIASALL.MOVIMIENTO.DET_MOVTO>", Environment.NewLine);
                lXML = String.Concat(lXML, "</DETALLE> ", Environment.NewLine);            
            }


            
            lXML = String.Concat(lXML, "<MOVVALTOT>", iObj.Movvaltot.ToString(), "</MOVVALTOT> ", Environment.NewLine);
            lXML = String.Concat(lXML, "</SDT_MOVEXISTENCIASALL.MOVIMIENTO> ", Environment.NewLine);
            lXML = String.Concat(lXML, "</SDT_MOVEXISTENCIASALL> ", Environment.NewLine);

            lRes1 = String.Concat(lRes1, "</XML>", Environment.NewLine);
            lRes1 = String.Concat(lRes1, "</SDT_TRANSPORTE>", Environment.NewLine);

            //'cambiamos los caracteres 
            //'        NOTA: Se realizó un encoding al XML con transporte, por lo cual:
            //'el signo < se reemplazó por &lt; 
            //'el signo > se reemplazó por &gt;
            lXML = lXML.Replace("<", "&lt;");
            lXML = lXML.Replace(">", "&gt;");

            lXmlFinal = String.Concat(lRes, lXML, lRes1);
            return lXmlFinal;

        }


        private string consumirWsINET(Clases.ObjetoWsINET objetoWsINET)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<SDT_TRANSPORTE xmlns=\"http://www.informat.cl/ws\">");
            sb.Append("<ACCION>ins</ACCION>");
            sb.Append("<XML>");
            sb.Append("<SDT_MOVEXISTENCIASALL xmlns=\"http://www.informat.cl/ws\">");
            sb.Append("<SDT_MOVEXISTENCIASALL.MOVIMIENTO>");
            sb.Append("	<TMETIP>" + objetoWsINET.Tmetip + "</TMETIP>");
            sb.Append("	<TMECOD>" + objetoWsINET.Tmecod + "</TMECOD>");
            sb.Append("	<MOVSUCCOD>" + objetoWsINET.Movsuccod + "</MOVSUCCOD>");
            sb.Append("	<MOVNUMDOC>" + objetoWsINET.Movnumdoc + "</MOVNUMDOC>");
            sb.Append("	<MOVFECDOC>" + objetoWsINET.Movfecdoc + "</MOVFECDOC>");
            sb.Append("	<MOVFECDIG>" + objetoWsINET.Movfecdig + "</MOVFECDIG>");
            sb.Append("	<MOVHORDIG>" + objetoWsINET.Movhordig + "</MOVHORDIG>");
            sb.Append("	<MOVBODCOD>" + objetoWsINET.Movbodcod + "</MOVBODCOD>");
            sb.Append("	<MOVBODSUC>" + objetoWsINET.Movbodsuc + "</MOVBODSUC>");
            sb.Append("	<MOVGLO1>" + objetoWsINET.Movglo1 + "</MOVGLO1>");
            sb.Append("	<MOVGLO2/>");
            sb.Append("	<MOVSIS>" + objetoWsINET.Movsis + "</MOVSIS>");
            sb.Append("	<MOVULTSEC>" + objetoWsINET.Movultsec + "</MOVULTSEC>");
            sb.Append("	<DETALLE>");
            sb.Append("			<SDT_MOVEXISTENCIASALL.MOVIMIENTO.DET_MOVTO>");
            sb.Append("			<DMONUMSEC>" + objetoWsINET.Dmonumsec + "</DMONUMSEC>");
            sb.Append("			<PRDCOD>" + objetoWsINET.Prdcod + "</PRDCOD>");
            sb.Append("			<PRDEXIPLA>" + objetoWsINET.Prdexipla + "</PRDEXIPLA>");
            sb.Append("			<DMOPLACOD>" + objetoWsINET.Dmoplacod + "</DMOPLACOD>");
            sb.Append("			<DMOCENCOD>" + objetoWsINET.Dmocencod + "</DMOCENCOD>");
            sb.Append("			<DMOITECOD>" + objetoWsINET.Dmoitecod + "</DMOITECOD>");
            sb.Append("			<DMOARECOD>" + objetoWsINET.Dmoarecod + "</DMOARECOD>");
            sb.Append("			<DMOCAN>" + objetoWsINET.Dmocan + "</DMOCAN>");
            sb.Append("			<DMOPREUNI>" + objetoWsINET.Dmopreuni + "</DMOPREUNI>");
            sb.Append("			<DMOVALTOT>" + objetoWsINET.Dmovaltot + "</DMOVALTOT>");
            sb.Append("			<INVMOV11>" + objetoWsINET.Invmov11 + "</INVMOV11>");
            sb.Append("			<INVMOV12>" + objetoWsINET.Invmov12 + "</INVMOV12>");
            sb.Append("			<INVMOV13>" + objetoWsINET.Invmov13 + "</INVMOV13>");
            sb.Append("			<INVMOV14>" + objetoWsINET.Invmov14 + "</INVMOV14>");
            sb.Append("			<INVMOV15>" + objetoWsINET.Invmov15 + "</INVMOV15>");
            sb.Append("			<INVMOV16>" + objetoWsINET.Invmov16 + "</INVMOV16>");
            sb.Append("			<INVMOV17>" + objetoWsINET.Invmov17 + "</INVMOV17>");
            sb.Append("			</SDT_MOVEXISTENCIASALL.MOVIMIENTO.DET_MOVTO>");
            sb.Append("	</DETALLE>");
            sb.Append("	<MOVVALTOT>" + objetoWsINET.Movvaltot + "</MOVVALTOT>");
            sb.Append("	</SDT_MOVEXISTENCIASALL.MOVIMIENTO>");
            sb.Append("</SDT_MOVEXISTENCIASALL>");
            sb.Append("</XML>");
            sb.Append("</SDT_TRANSPORTE>");

            return sb.ToString();
        }


        private Integracion_INET.Tipo_InvocaWS InvocarWS_INET_V1(Ws_TO .Objeto_WsINET iObjINET)
        {
            Px_MovExistenciasINET.wsmovexiallSoapPortClient lPxMovEx = new Px_MovExistenciasINET.wsmovexiallSoapPortClient();
            Px_MovExistenciasINET.ExecuteRequest lObjEntradaMov = new Px_MovExistenciasINET.ExecuteRequest();
            Px_MovExistenciasINET.ExecuteResponse lResMovEx = new Px_MovExistenciasINET.ExecuteResponse();    
            Integracion_INET.Tipo_InvocaWS lResultado=new Integracion_INET.Tipo_InvocaWS ();
             Integracion_INET.MovExistencias lTipoEntradaEx=new Integracion_INET.MovExistencias ();
            XmlSerializer lXmlSal=null ; StringWriter strDataXml =new  StringWriter(); string lEstadoProceso = "";
            String  lSql = "";  WsCrud .CrudSoapClient  lDAl=new WsCrud.CrudSoapClient();
            WsCrud .ListaDataSet lDts=new WsCrud.ListaDataSet ();
            
            try
            {
               // iEstado.Text = iEstado.Text & vbCrLf & "Cargando Objeto Entrada Bodega Productos Terminados  " : iEstado.Refresh()
                    lTipoEntradaEx = CargaObjEntradaBodegaProdTerm_INET(iObjINET);
                lObjEntradaMov.Intrasnporte =  CreaXmlEntradaProductosTErminados_INET(lTipoEntradaEx);
                //    'Cargamos el log para la el invocación del WS
                //    iEstado.Text = iEstado.Text & vbCrLf & " Objeto Entrada Bodega Productos Terminados-- OK " & lResultado.Err
                //   lResultado = New Tipo_InvocaWS
                //    Application.DoEvents()
                    lResultado.XML_Enviado = lObjEntradaMov.Intrasnporte;
                //    lResultado.IdDespachoCamion = mIdDespachoCamion
                    lResultado.URL_WS = lPxMovEx.Endpoint.ListenUri.AbsoluteUri;
                //    iEstado.Text = iEstado.Text & vbCrLf & " Antes de  Invocar  WS INET :" & vbCrLf & lResultado.XML_Enviado : iEstado.Refresh()
                    lResMovEx.Outtansporte = lPxMovEx.Execute(lObjEntradaMov.Intrasnporte);
                     //Dim lXmlSal As New XmlSerializer(lResMovEx.Outtansporte.GetType)
                lXmlSal =new XmlSerializer(lResMovEx.Outtansporte.GetType());
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
                    lSql = string .Concat ("exec SP_CRUD_LOG_WS_INET 1,", lResultado.Id, ",", lResultado.IdDespachoCamion);
                    lSql = string .Concat (lSql, ",'", lResultado.PatenteCamion, "',0,'", lResultado.XML_Enviado.Replace("'", "''"));
                    lSql = string .Concat (lSql, "','", lResultado.XML_Respuesta, "','" , lResultado.URL_WS, "','SolicitudMaterial',", lTipoEntradaEx.ExistenciasAll.MOVNUMDOC );
                    lSql = string .Concat (lSql, ",'" , lEstadoProceso , "'");
                    lDts = lDAl.ListarAyudaSql(lSql);
            }
            return lResultado;              
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
            WsCrud.ListaDataSet lDts = new WsCrud.ListaDataSet();
            //lDts As New ListaDataSet
            //DataSet   lDts =new DataSet ();

            //Integracion_INET .MovExistencias             
            try
            {
                // iEstado.Text = iEstado.Text & vbCrLf & "Cargando Objeto Entrada Bodega Productos Terminados  " : iEstado.Refresh()
                lTipoEntradaEx = CargaObjEntradaBodegaProdTerm_INET(iObjINET);
              // lObjEntradaMov.Intrasnporte = lTipoEntradaEx.ToString ();
                lObjEntradaMov.Intrasnporte = CreaXmlEntradaProductosTerminados_INET_SolicitudMP(iObjINET);// CreaXmlEntradaProductosTErminados_INET(lTipoEntradaEx);

                //    'Cargamos el log para la el invocación del WS
                //    iEstado.Text = iEstado.Text & vbCrLf & " Objeto Entrada Bodega Productos Terminados-- OK " & lResultado.Err
                //   lResultado = New Tipo_InvocaWS
                //    Application.DoEvents()
                lResultado.XML_Enviado = lObjEntradaMov.Intrasnporte;
                //    lResultado.IdDespachoCamion = mIdDespachoCamion
                lResultado.URL_WS = lPxMovEx.Endpoint.ListenUri.AbsoluteUri;
                //    iEstado.Text = iEstado.Text & vbCrLf & " Antes de  Invocar  WS INET :" & vbCrLf & lResultado.XML_Enviado : iEstado.Refresh()
                lResMovEx.Outtansporte = lPxMovEx.Execute(lObjEntradaMov.Intrasnporte);
                //Dim lXmlSal As New XmlSerializer(lResMovEx.Outtansporte.GetType)
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

        public Integracion_INET.MovExistencias CargaObjEntradaBodegaProdTerm_INET(Ws_TO.Objeto_WsINET iObjINET)
        {
            Integracion_INET.MovExistencias lRes = new Integracion_INET.MovExistencias();
            Integracion_INET.MovExistenciasAll lExAll = new Integracion_INET.MovExistenciasAll();
            Integracion_INET.MovExistenciasDet lExDet = new Integracion_INET.MovExistenciasDet();
            int i = 0;


            // 'Secuencia del detalle

            lRes.ExistenciasDet.DMONUMSEC = iObjINET.DetalleMov[0].Dmonumsec;// Dmonumsec; //"1";
            lRes.ExistenciasDet.PRDCOD = iObjINET.DetalleMov[0].Prdcod;// iCodProd '"63OGP1"
            lRes.ExistenciasDet.PRDEXIPLA = iObjINET.DetalleMov[0].Prdexipla;// "1109009"
            lRes.ExistenciasDet.DMOPLACOD = iObjINET.DetalleMov[0].Dmoplacod;// "1109008"
            lRes.ExistenciasDet.DMOCENCOD = iObjINET.DetalleMov[0].Dmocencod;// "0"
            lRes.ExistenciasDet.DMOITECOD = iObjINET.DetalleMov[0].Dmoitecod;//  "0"
            lRes.ExistenciasDet.DMOARECOD = iObjINET.DetalleMov[0].Dmoarecod;// "0"


            lRes.ExistenciasDet.DMOCAN = iObjINET.DetalleMov[0].Dmocan;// String.Concat(iTotalKgs.ToString, ".0000") '"15523.0000"  '--Kilos
            lRes.ExistenciasDet.DMOPREUNI = iObjINET.DetalleMov[0].Dmopreuni;// String.Concat(iPrecioCosto.ToString, ".00") ' "420.00"      'Precio Unitario COSTO
            lRes.ExistenciasDet.DMOVALTOT = iObjINET.DetalleMov[0].Dmovaltot;// String.Concat(mTotalCosto.ToString, ".00") ' "6519660.00"   '--Total
            lRes.ExistenciasDet.INVMOV11 = iObjINET.DetalleMov[0].Invmov11;// "0.0000"
            lRes.ExistenciasDet.INVMOV12 = iObjINET.DetalleMov[0].Invmov12;// "0.00"
            lRes.ExistenciasDet.INVMOV13 = iObjINET.DetalleMov[0].Invmov13;// "0.00"
            lRes.ExistenciasDet.INVMOV14 = iObjINET.DetalleMov[0].Invmov14;// "0.0000"
            lRes.ExistenciasDet.INVMOV15 = iObjINET.DetalleMov[0].Invmov15;// "0.00"
            lRes.ExistenciasDet.INVMOV16 = iObjINET.DetalleMov[0].Invmov16;// "0.0000"
            lRes.ExistenciasDet.INVMOV17 = iObjINET.DetalleMov[0].Invmov17;// "0.0000"


            //'Indica el tipo movimiento (1=Entrada,2=salida)
            lRes.ExistenciasAll.TMETIP = iObjINET.Tmetip;// "1";//   'Entrada a productos terminados
            //'Indica el código del movimiento (T)
            lRes.ExistenciasAll.TMECOD = iObjINET.Tmecod;// "30"
            //'Código de sucursal (T)
            lRes.ExistenciasAll.MOVSUCCOD = iObjINET.Movsuccod;// mCodigoSucursal_INET '"1"    '1casa matriz stgo  2 calama
            //'Numero de movimiento  debe ser un correlativo y se debe aumentar en uno actualmente va en 90001
            //'      MessageBox.Show("Antes de ObtenerCampo_MovNumDoc.ToString ")
            //mMOVNUMDOC = ObtenerCampo_MovNumDoc.ToString

            lRes.ExistenciasAll.MOVNUMDOC = iObjINET.Movnumdoc;// mMOVNUMDOC    '"90002"
            //'Fecha del movimiento (aaaa-mm-dd)
            //'  MessageBox.Show("ANtes de ObtenerFechaActual ")
            lRes.ExistenciasAll.MOVFECDOC = iObjINET.Movfecdoc;// ObtenerFechaActual("A") '  "2013-08-19"
            //'   MessageBox.Show("Fechas :" & lObj.MOVFECDOC)
            //'Fecha de digitación del movimiento (aaaa-mm-dd)
            lRes.ExistenciasAll.MOVFECDIG = iObjINET.Movfecdig;  //ObtenerFechaActual("A")  '  "2013-08-19"
            //'Hora del movimiento (hh:mm:ss)
            lRes.ExistenciasAll.MOVHORDIG = iObjINET.Movhordig;// ObtenerHoraActual() ' "21:59:59"
            //'código de bodega (T)
            //'lObj.MOVBODCOD = "1"  '105 para santiag0  69 para calama
            lRes.ExistenciasAll.MOVBODCOD = iObjINET.Movbodcod;//  mCodigoBodega //' "105"  '105 para santiag0  69 para calama

            //'código de sucursal (T)
            lRes.ExistenciasAll.MOVBODSUC = iObjINET.Movbodsuc;// mCodigoSucursal_INET '"1"  ' '1casa matriz stgo  2 calama
            //'Glosa del movimiento (opcional)
            lRes.ExistenciasAll.MOVGLO1 = iObjINET.Movglo1;// iObs1 '"PRUEBAS DE INTEGRACION"
            //'Glosa del movimiento (opcional)
            lRes.ExistenciasAll.MOVGLO2 = iObjINET.Movglo2;
            //'Sistema (1=Existencias,4=importaciones),por defecto =1
            lRes.ExistenciasAll.MOVSIS = iObjINET.Movsis;// "1"
            //'Cantidad de líneas del detalle
            lRes.ExistenciasAll.MOVULTSEC = iObjINET.Movultsec;// "1"
            //'Valor total sumando todas las líneas
            lRes.ExistenciasAll.MOVVALTOT = iObjINET.Movvaltot;// String.Concat(mTotalCosto, ".00") // '"6519660.00"

            //lExDet = CargaObjMovExistenciaDet(mCodigoINET, mKilosCargados, mPrecioCostoKilo, mTotalCosto)
            //lExAll = CargaObjMovExistenciaAll(mViajesCargados)

            //lRes.ExistenciasAll = lExAll

            //lRes.ExistenciasDet = lExDet

            return lRes;
        }
    

        private string buscarTagError(string texto)
        {
            string result = "";
            int pos1 = -1, pos2 = -1;

            pos1 = texto.Trim().ToUpper().IndexOf("<ACCION>OK</ACCION>");
            if (pos1.Equals(-1)) //ERROR
            {
                pos1 = texto.Trim().ToUpper().IndexOf("<DESCERROR>");
                pos2 = texto.Trim().ToUpper().IndexOf("</DESCERROR>");
                while (!pos1.Equals(-1) && !pos2.Equals(-1))
                {
                    result += !result.Equals("") ? ";" : "";
                    result += texto.Substring(pos1, pos2 - pos1).Replace("<DESCERROR>", "");
                    pos1 = texto.Trim().ToUpper().IndexOf("<DESCERROR>", pos1 + 1);
                    pos2 = texto.Trim().ToUpper().IndexOf("</DESCERROR>", pos2 + 1);
                }
            }
            return (result.Equals("") ? "OK" : result);
        }

        private void EnvioCorreo(string iIdSolicitudes,string iUsuario , string iMaq )
        {
            Ws_TO.Ws_ToSoapClient lPX = new Ws_TO.Ws_ToSoapClient(); DataSet lDts = new DataSet();
            int i = 0; string lTblHtml = ""; DataTable lTbl = new DataTable();
            string[] lPartes = null; string lSql = "";

            lPartes = iIdSolicitudes.Split(new Char[] { ',' });

            for (i = 0; i < lPartes.Length; i++)
            {
                if (lPartes[i].ToString().Trim().Length > 0)
                {
                    lSql = string.Concat(" SP_Consultas_WS 67,'", lPartes[i].ToString (), "','','','','','',''");
                    lDts.Merge(lPX.ObtenerDatos(lSql));
                }
            }

            //  lSql = string.Concat (" SP_Consultas_WS 67,'", iIdSolicitudes, "','','','','','',''");
            //lDts = lPX.ObtenerDatos(lSql);

            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                lTbl = lDts.Tables[0].Copy();
                //Concatenamos el texto de la cabecera
                lTblHtml = string.Concat(" Hola Estimados:  <br>  A continuación se muestra el estado de la Solicitud de Materia Prima al momento del cierre de turno <br> ");
                lTblHtml = string.Concat(lTblHtml,"    El Usuario <b>",iUsuario , "</b> de la maquina <b>", iMaq , "</b>, ha Solicitado y producido lo siguiente:  <br> ");
                lTblHtml = string.Concat(lTblHtml, "  <br> <br>   <table border = '1' >  <tr>   ");
                lTblHtml = string.Concat(lTblHtml, " <td style = 'font - family: Arial; font - weight: bold; font - size: 12px;'> Id Solicitud </ td >  ");
                lTblHtml = string.Concat(lTblHtml, " <td style = 'font-family: Arial; font-weight: bold; font-size: 12px;'>Codigo </ td >   ");
                lTblHtml = string.Concat(lTblHtml, " <td style = 'font-family: Arial; font-weight: bold; font-size: 12px;'>Descripcion </ td >");
                lTblHtml = string.Concat(lTblHtml, " <td style = 'font-family: Arial; font-weight: bold; font-size: 12px;'>Origen </ td >");
                lTblHtml = string.Concat(lTblHtml, " <td style = 'font-family: Arial; font-weight: bold; font-size: 12px;'>Soldable </ td > ");
                lTblHtml = string.Concat(lTblHtml, " <td style = 'font-family: Arial; font-weight: bold; font-size: 12px;'>Kgs Solicitados </ td >");
                lTblHtml = string.Concat(lTblHtml, " <td style = 'font-family: Arial; font-weight: bold; font-size: 12px;'>Kgs Recepcionados </ td >");
                lTblHtml = string.Concat(lTblHtml, " <td style = 'font-family: Arial;font-weight: bold; font-size: 12px;'>Kgs Producidos </ td >");
                lTblHtml = string.Concat(lTblHtml, " <td style = 'font-family: Arial ; font-weight: bold; font-size: 12px;'>% Producido </ td >");
                lTblHtml = string.Concat(lTblHtml, " <td style = 'font-family: Arial ; font-weight: bold; font-size: 12px;'>Saldo  </ td >");
                lTblHtml = string.Concat(lTblHtml, " <td style = 'font-family: Arial;font-weight: bold; font-size: 12px;'>Integrado INET </ td >");
                lTblHtml = string.Concat(lTblHtml, " </tr> ");

                for (i = 0; i < lTbl.Rows.Count; i++)
                {
                    lTblHtml = string.Concat(lTblHtml, " <tr> ");
                    lTblHtml = string.Concat(lTblHtml, " <td style='font-family: Arial;  font-size: 12px;'>", lTbl .Rows[i]["IdSol"].ToString (), "</td >" );
                    lTblHtml = string.Concat(lTblHtml, " <td style='font-family: Arial;  font-size: 12px;'>", lTbl.Rows[i]["Codigo"].ToString(), "</td >");
                    lTblHtml = string.Concat(lTblHtml, " <td style='font-family: Arial;  font-size: 12px;'>", lTbl.Rows[i]["Descripcion"].ToString(), "</td >");
                    lTblHtml = string.Concat(lTblHtml, " <td style='font-family: Arial;  font-size: 12px;'>", lTbl.Rows[i]["Origen"].ToString(), "</td >");
                    lTblHtml = string.Concat(lTblHtml, " <td style='font-family: Arial;  font-size: 12px;'>", lTbl.Rows[i]["Soldable"].ToString(), "</td >");
                    lTblHtml = string.Concat(lTblHtml, " <td style='font-family: Arial;  font-size: 12px;'>", lTbl.Rows[i]["DET_KILOS"].ToString(), "</td >");
                    lTblHtml = string.Concat(lTblHtml, " <td style='font-family: Arial;  font-size: 12px;'>", lTbl.Rows[i]["DET_KILOS_RECEP"].ToString(), "</td >");
                    lTblHtml = string.Concat(lTblHtml, " <td style='font-family: Arial;  font-size: 12px;'>", lTbl.Rows[i]["DET_KILOS_PRODUCIDOS"].ToString(), "</td >");
                    lTblHtml = string.Concat(lTblHtml, " <td style='font-family: Arial;  font-size: 12px;'>", lTbl.Rows[i]["% producido"].ToString(), "</td >");
                    lTblHtml = string.Concat(lTblHtml, " <td style='font-family: Arial;  font-size: 12px;'>", lTbl.Rows[i]["Saldo"].ToString(), "</td >");
                    lTblHtml = string.Concat(lTblHtml, " <td style='font-family: Arial;  font-size: 12px;'>", lTbl.Rows[i]["DET_INET_MSG"].ToString(), "</td >");

                    lTblHtml = string.Concat(lTblHtml, " </tr>  ");
                }
            }


            lTblHtml = string.Concat(lTblHtml, "</table>  <br> <br> No responder a este correo, ya que fue generado de forma automatica <br> <br> ");
            lTblHtml = string.Concat(lTblHtml, "  Los acentos han sido eliminados para evitar problemas con caracteres extaños ");


            //[SP_Consultas_WS]         @Opcion INT, @Par1 Varchar(100), @Par2 Varchar(100), @Par3 Varchar(150), @Par4 Varchar(100),
            //@Par5 Varchar(100),  @Par6 Varchar(100), @Par7 Varchar(100)

            //MessageBox.Show("Asunto: Cierre de solicitudes" + Environment.NewLine + "Cuerpo:" + Environment.NewLine + cuerpo);
            //WsMensajeria.Ws_ToSoapClient wsMensajeria = new WsMensajeria.Ws_ToSoapClient();
            string result = lPX.EnviaNotificacionesEnviaMsgDeNotificacion("Sistema de notificaciones S.M.P.", lTblHtml,-600, "Gestion de Materia Prima " );
        }

        private void BloquearColumnas(DataGridView dgv)
        {
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                if (column.Index > 0)
                    column.ReadOnly = true;
            }
        }

        private void tlbActualizar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                //tlbNuevo_Click(sender, e);
                WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
                WsOperacion.ListaDataSet listaDataSet = new WsOperacion.ListaDataSet();

                listaDataSet = wsOperacion.ListarSolicitudMaterial_Cierre(dtpFechaRecepcion.Value, Program.currentUser.IdTotem, cboCriterio.Text.Substring(0,1));
                if (listaDataSet.MensajeError.Equals(""))
                {
                    dgvProductos.DataSource = listaDataSet.DataSet.Tables[0];
                    if (!forms.dataGridViewExistsColumn(dgvProductos, COLUMNNAME_MARCA))
                    {
                        DataGridViewCheckBoxColumn check = new DataGridViewCheckBoxColumn();
                        check.Name = COLUMNNAME_MARCA;
                        dgvProductos.Columns.Insert(0, check);
                    }
                    BloquearColumnas(dgvProductos);
                    //tlbNuevo.PerformClick();
                    //tlbNuevo_Click(sender, e);
                    //ID, USUARIO, FECHA, TOTEM, COMPLETA, SOL_ID, PRODUCTO, DIAMETRO, LARGO, ORIGEN, TIPO CANTIDAD, USUARIO_RECEP, FECHA_RECEP, CANTIDAD_RECEP, OBS_RECEP, USUARIO_CIERRE, FECHA_CIERRE, INET_MSG, INET_FECHA
                    forms.dataGridViewHideColumns(dgvProductos, new string[] { "ID", "USUARIO", "FECHA", "TOTEM", "COMPLETA", "CANTIDAD", "USUARIO_RECEP", "OBS_RECEP", "FECHA_RECEP", "USUARIO_CIERRE", "FECHA_CIERRE" });
                    forms.dataGridViewAutoSizeColumnsMode(dgvProductos, DataGridViewAutoSizeColumnsMode.DisplayedCells);
                    tlsEstado.Text = "Registro(s): " + dgvProductos.Rows.Count;
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

        private void tlbImprimir_Click(object sender, EventArgs e)
        {

        }

        private void tlbExportar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.Rows.Count > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                new Excel().exportar(dgvProductos);
                Cursor.Current = Cursors.Default;
            }
            else
                MessageBox.Show("No existen registros a exportar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tlbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCierreMaterial_Load(object sender, EventArgs e)
        {
            bool enabledAdmin = Program.currentUser.PerfilUsuario.Equals("ADMIN");

            if (Program.currentUser.PerfilUsuario.ToString().IndexOf("Adm") > -1)
                enabledAdmin = true;
            else
                enabledAdmin = false;


            tlbGuardar.Enabled = !enabledAdmin;
            tlbReprocesar.Enabled = enabledAdmin;
            cboCriterio.SelectedIndex = 0;

            lblAccion.Visible = enabledAdmin;
            cboAccion.Visible = enabledAdmin;
            cboAccion.SelectedIndex = 0;

            lblNota.Visible = !enabledAdmin;

            tlbActualizar.PerformClick();
        }

        private void dgvProductos_DoubleClick(object sender, EventArgs e)
        {
            DataGridViewRow currentRow = dgvProductos.CurrentRow;
            if (currentRow != null)
            {
                if (!cboAccion.Visible || (cboAccion.Visible && cboAccion.SelectedIndex == 0))
                {
                    frmLogProducto frm = new frmLogProducto();
                    frm.sol_id = Convert.ToInt32(currentRow.Cells[COLUMNNAME_ID].Value.ToString());
                    frm.producto = currentRow.Cells[COLUMNNAME_PRODUCTO].Value.ToString();
                    frm.ShowDialog(this);
                    frm.Dispose();
                }
                else
                {
                    frmCierreMaterialAdmin frm = new frmCierreMaterialAdmin();
                    frm.producto = currentRow.Cells[COLUMNNAME_PRODUCTO_DESCRIPCION].Value.ToString();
                    frm.diametro = currentRow.Cells[COLUMNNAME_DIAMETRO].Value.ToString();
                    frm.largo = currentRow.Cells[COLUMNNAME_LARGO].Value.ToString();
                    frm.origen = currentRow.Cells[COLUMNNAME_ORIGEN_DESCRIPCION].Value.ToString();
                    frm.tipo = currentRow.Cells[COLUMNNAME_TIPO].Value.ToString();
                    frm.cantidad = currentRow.Cells[COLUMNNAME_CANTIDAD].Value.ToString();
                    frm.tipo_cierre = currentRow.Cells[COLUMNNAME_TIPO].Value.ToString();
                    frm.cantidad_cierre = Convert.ToInt32(currentRow.Cells[COLUMNNAME_CANTIDAD_RECEP].Value.ToString());
                    frm.ShowDialog(this);
                    if (frm.ok)
                    {
                        currentRow.Cells[COLUMNNAME_TIPO].Value = frm.tipo_cierre;    
                        currentRow.Cells[COLUMNNAME_CANTIDAD_RECEP].Value = frm.cantidad_cierre.ToString();
                    }
                    frm.Dispose();
                }
            }
        }

        private void dtpFechaRecepcion_ValueChanged(object sender, EventArgs e)
        {
            tlbActualizar.PerformClick();
        }

        private void cboCriterio_SelectedIndexChanged(object sender, EventArgs e)
        {
            tlbActualizar.PerformClick();
        }

        private void tlbDesactivar_Click(object sender, EventArgs e)
        {
            //EnvioCorreo();
        }

        private void tlbReprocesar_Click(object sender, EventArgs e)
        {
            tlbGuardar_Click(sender, e);
        }


        public void IniciaForm(CurrentUser iUserLog)
        {
            mUserLog = iUserLog;
            ctlInformacionUsuario1.CargaDatosUserLog(mUserLog);            
        }

        private void Rb_MarcarTodas_CheckedChanged(object sender, EventArgs e)
        {

        }


        private void Marca_DesmarcaTodas(Boolean iValor)
        {
            int i = 0;


            for (i = 0; i < dgvProductos.RowCount; i++)
            {
                dgvProductos.Rows[i].Cells["Marca"].Value = iValor;

            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            EnvioCorreo("40,41", Program.currentUser.Login, "Linea de Corte");
        }
    }
}