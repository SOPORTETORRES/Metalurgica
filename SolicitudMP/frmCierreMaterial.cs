using System;
using System.Data;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Serialization;
using CommonLibrary2;
using System.Text;
using System.Collections;
using System.Configuration;

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
        private const string COLUMNNAME_CANTIDAD = "CANTIDAD_SOL";
        private const string COLUMNNAME_KILOS = "CANTIDAD_PROD";
        private const string COLUMNNAME_CANTIDAD_RECEP = "KILOS_PROD";
        private string  mIdSucursal ="";
        private DataTable mTblOriginal = new DataTable();
        private DataTable mTblDetalle = new DataTable();

        private Forms forms = new Forms();
        private CurrentUser mUserLog = new CurrentUser();
        private string mTipoColada = "";


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



        private string  IntegracionInet(   DataGridViewRow iFila )
        {
            string lRes = ""; DataTable lTblINET = new DataTable();  DataRow iROw = null;
            string lSql = ""; Clases.ClsComun lCom = new Clases.ClsComun(); string lFechaMov = "";
            Ws_TO.Ws_ToSoapClient lPX = new Ws_TO.Ws_ToSoapClient(); int i = 0;  
            Ws_TO.Objeto_WsINET lObjINET = new Ws_TO.Objeto_WsINET(); string inet_msg = "", email_msg = "";
            Integracion_INET.Tipo_InvocaWS lRespuestaWS_INET = new Integracion_INET.Tipo_InvocaWS();
            string lGlosa1 = ""; string lGlosa2 = "";

            // 1.- Se Integra con INET
            DataTable lTblFinal = new DataTable(); DataSet lDts = new DataSet();
            DataView lVista = null;

     
            lFechaMov = DateTime.Now.ToString();
            //lDts.Tables.Add(lTblINET.Copy());
            lFechaMov = lFechaMov.Replace("/", "-");

            //Debemos saber que  sucursal esta haciendo la invocaión
            int lIdSucursal = lCom.OBtenerIdSucursal();
            string lIdDetalle = "0"; DataSet lDtsTmp = new DataSet();

            //Por cada Fila son 2 Integraciones 1.- Producido 2.- Despuente si lo hay.
            //Primero lo Produccido 
            if (lCom.Val(iFila.Cells["KgsProducidos"].Value.ToString().ToString()) > 0)
            {
                //Obtenemos el Objeto con los datos
                lTblFinal = ObtenerTablaINET();
                lTblINET = ObtenerTablaINET();

                iROw = lTblINET.NewRow();
                iROw["Codigo"] = iFila.Cells["CodMaterial"].Value.ToString();
                iROw["Cantidad"] = lCom.Val(iFila.Cells["KgsProducidos"].Value.ToString());
                iROw["FechaMov"] = lFechaMov;
                lGlosa1 = string.Concat(Program.currentUser.Login, " - ", lCom.ObtenerInicioFIn_Turno(Program.currentUser.IdTotem.ToString()));
                iROw["Glosa1"] = lGlosa1;
                   lGlosa2 = "Producido";
                iROw["Glosa2"] = lGlosa2;
                //iROw["Procesado"] = "N";
             
                lTblINET.Rows.Add(iROw);

                lDts.Tables.Add(lTblINET.Copy());

                if (lIdSucursal == 1)   //Calama
                    lObjINET = lPX.ObtenerObjetoINET_Calama(lDts, lFechaMov, lGlosa1, lGlosa2);

                if ((lIdSucursal == 4) || (lIdSucursal == 2))   // Santiago
                    lObjINET = lPX.ObtenerObjetoINET(lDts, lFechaMov, lGlosa1, lGlosa2);

                lSql = string.Concat(" insert into ProductosIntegradosINET (CodProducto,MovNumDoc,IdUsuario,IdSucursal, Tipo ,Kgs , IdMaquinaIntegra) ");
                lSql = string.Concat(lSql, " values ('", (iFila.Cells["CodMaterial"].Value.ToString()), "',", lCom.Val(lObjINET.Movnumdoc), ",");
                lSql = string.Concat(lSql, mUserLog.Iduser, ",", mIdSucursal, ",'P',", lCom.Val(iFila.Cells["KgsProducidos"].Value.ToString()),",", mUserLog .IdMaquina ,")   select @@Identity  ");
                lDtsTmp = lPX.ObtenerDatos(lSql);
                if ((lDtsTmp.Tables.Count > 0) && (lDtsTmp.Tables[0].Rows.Count > 0))
                    lIdDetalle = lDtsTmp.Tables[0].Rows[0][0].ToString();

                string lEstado = "";
                //lObjINET = lPX.ObtenerObjetoINET(lDts, lFechaMov, lGlosa1, lGlosa2);
                lRespuestaWS_INET = InvocarWS_INET(lObjINET);

                inet_msg = lCom.buscarTagError(lRespuestaWS_INET.XML_Respuesta.ToString());
                if (inet_msg.Trim().ToUpper().Equals("OK"))
                {
                    lEstado = "OK";
                }
                else
                    lEstado = "ER";

                //Ahora Persistimo el detalle 
                lVista = new DataView(mTblDetalle, string.Concat(" tipo='P' and CodMaterial='", iFila.Cells["CodMaterial"].Value.ToString(), "'"), "", DataViewRowState.CurrentRows);
                for (i = 0; i < lVista.Count; i++)
                {
                    lSql = string.Concat(" insert into DetalleProductoIntegrado (IdQr,FechaRegistro,MovNumDoc,IdUsuario, IdProductoIntegrado, KgsVinculados, EstadoIntegracion)  ");
                    lSql = string.Concat(lSql, " values ('", lVista[i]["Id"].ToString(), "',getdate(),");
                    lSql = string.Concat(lSql, lCom.Val(lObjINET.Movnumdoc), ",", mUserLog.Iduser, ",", lIdDetalle, ",", lVista[i]["KgsVinculados"].ToString(), ",'", lEstado, "')  ");
                    lDtsTmp = lPX.ObtenerDatos(lSql);
                }


                //*********************************************************
                //Ahora el Despunte 
                if (lCom.Val(iFila.Cells["KgsDespunte"].Value.ToString()) > 0)
                {
                    lTblINET.Clear();
                    lDts.Tables.Clear();
                    lDts.Clear();
                    lTblFinal = ObtenerTablaINET();
                    iROw = lTblINET.NewRow();
                    iROw["Codigo"] = iFila.Cells["CodMaterial"].Value.ToString();
                    iROw["Cantidad"] = lCom.Val(iFila.Cells["KgsDespunte"].Value.ToString());
                    iROw["FechaMov"] = lFechaMov;
                    lGlosa1 = string.Concat(Program.currentUser.Login, " - ", lCom.ObtenerInicioFIn_Turno(Program.currentUser.IdTotem.ToString()));
                    iROw["Glosa1"] = lGlosa1;
                    lGlosa2 = "Despunte";
                    iROw["Glosa2"] = lGlosa2;
                    //iROw["Procesado"] = "N";

                    lTblINET.Rows.Add(iROw);

                    lDts.Tables.Add(lTblINET.Copy());

                    //Obtenemos el Objeto con los datos
                    if (lIdSucursal == 1)   //Calama
                        lObjINET = lPX.ObtenerObjetoINET_Calama(lDts, lFechaMov, lGlosa1, lGlosa2);

                    if ((lIdSucursal == 4) || (lIdSucursal == 2))   // Santiago
                        lObjINET = lPX.ObtenerObjetoINET(lDts, lFechaMov, lGlosa1, lGlosa2);


                    lSql = string.Concat(" insert into ProductosIntegradosINET (CodProducto,MovNumDoc,IdUsuario,IdSucursal, Tipo ,Kgs , IdMaquinaIntegra) ");
                    lSql = string.Concat(lSql, " values ('", iFila.Cells["CodMaterial"].Value.ToString(), "',", lCom.Val(lObjINET.Movnumdoc), ",");
                    lSql = string.Concat(lSql, mUserLog.Iduser, ",", mIdSucursal, ",'D',", lCom.Val(iFila.Cells["KgsDespunte"].Value.ToString()), ",", mUserLog.IdMaquina, ")   select @@Identity  ");
                    lDtsTmp = lPX.ObtenerDatos(lSql);
                    if ((lDtsTmp.Tables.Count > 0) && (lDtsTmp.Tables[0].Rows.Count > 0))
                        lIdDetalle = lDtsTmp.Tables[0].Rows[0][0].ToString();

            
                    //lObjINET = lPX.ObtenerObjetoINET(lDts, lFechaMov, lGlosa1, lGlosa2);
                    lRespuestaWS_INET = InvocarWS_INET(lObjINET);

                    inet_msg = lCom.buscarTagError(lRespuestaWS_INET.XML_Respuesta.ToString());
                    if (inet_msg.Trim().ToUpper().Equals("OK"))
                    {
                        lEstado = "OK";
                    }
                    else
                        lEstado = "ER";

                    //Ahora Persistimo el detalle 
                    lVista = new DataView(mTblDetalle, string.Concat(" tipo='D' and CodMaterial='", iFila.Cells["CodMaterial"].Value.ToString(), "'"), "", DataViewRowState.CurrentRows);
                    for (i = 0; i < lVista.Count; i++)
                    {
                        lSql = string.Concat(" insert into DetalleProductoIntegrado (IdQr,FechaRegistro,MovNumDoc,IdUsuario, IdProductoIntegrado, KgsVinculados, EstadoIntegracion)  ");
                        lSql = string.Concat(lSql, " values ('", lVista[i]["Id"].ToString(), "',getdate(),");
                        lSql = string.Concat(lSql, lCom.Val(lObjINET.Movnumdoc), ",", mUserLog.Iduser, ",", lIdDetalle, ",", lVista[i]["KgsVinculados"].ToString(), ",'", lEstado, "')  ");
                        lDtsTmp = lPX.ObtenerDatos(lSql);
                    }



                }

            }

            return lRes;
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

        private void Guardar_Version_Re_Etiquetado()
        {
            Ws_TO.Ws_ToSoapClient lPX = new Ws_TO.Ws_ToSoapClient(); int i = 0; string lIds_SMP = "";
            Ws_TO.Objeto_WsINET lObjINET = new Ws_TO.Objeto_WsINET(); ArrayList lLista = new ArrayList();
            Integracion_INET.Tipo_InvocaWS lRespuestaWS_INET = new Integracion_INET.Tipo_InvocaWS();
            int lIdDetalleSM = 0;

            int counter = 0;
            string inet_msg = "", email_msg = "", newLine = Environment.NewLine, tab = "\t";

            string lCodigo = ""; string lCantidad = ""; string lFechaMov = ""; string lGlosa1 = ""; string lGlosa2 = "";

            DataTable lTblINET = new DataTable(); DataRow iFila = null;
            lTblINET.Columns.Add("Codigo", Type.GetType(("System.String")));
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
                    int lKgsProd = 0; Clases.ClsComun lCom = new Clases.ClsComun();
                    counter = 0;
                    foreach (DataGridViewRow row in dgvProductos.Rows)
                    {
                        if (row.Cells[COLUMNNAME_MARCA].Value != null)
                        {
                            if (((bool)row.Cells[COLUMNNAME_MARCA].Value == true)) // && (!row.Cells["ES_RECUPERADO"].Value.ToString().Equals("S")))
                            {
                                lKgsProd = lCom.Val(row.Cells["KILOS_PROD"].Value.ToString());
                                // if (((int)row.Cells["KILOS_PROD"].Value> 0) )
                                if ((lKgsProd > 0))
                                {
                                    lTblINET.Clear();
                                    if (lCom.Agregar_IdSolicitud(lLista, row.Cells["SOL_ID"].Value.ToString()))
                                    {
                                        lLista.Add(row.Cells["SOL_ID"].Value.ToString());
                                    }
                                    inet_msg = "";
                                    if ((!row.Cells["ES_RECUPERADO"].Value.ToString().Equals("S")))
                                    {
                                        lCodigo = row.Cells[COLUMNNAME_PRODUCTO].Value.ToString();
                                        //lCantidad=row.Cells[COLUMNNAME_CANTIDAD].Value.ToString ();
                                        lCantidad = row.Cells["KILOS_RECEP"].Value.ToString();
                                        lFechaMov = DateTime.Now.ToString();
                                        lGlosa1 = Program.currentUser.Login;
                                        //lGlosa1 = "Adm (Cierre Administrativo)";
                                        //lGlosa2 = "22/10/2018 "; // ObtenerTurno();
                                        lGlosa2 = lCom.ObtenerInicioFIn_Turno(Program.currentUser.IdTotem.ToString());// ObtenerTurno();

                                        iFila = lTblINET.NewRow();
                                        iFila["Codigo"] = lCodigo;
                                        iFila["Cantidad"] = lCantidad;
                                        iFila["FechaMov"] = lFechaMov;
                                        iFila["Glosa1"] = lGlosa1;
                                        iFila["Glosa2"] = lGlosa2;
                                        iFila["Procesado"] = "N";
                                        lTblINET.Rows.Add(iFila);


                                        // 1.- Se Integra con INET
                                        DataTable lTblFinal = new DataTable(); DataSet lDts = new DataSet();
                                        //lTblFinal = ObtenerDatosIntegracionINET(lTblINET);
                                        lDts.Tables.Add(lTblINET.Copy());
                                        lFechaMov = lFechaMov.Replace("/", "-");

                                        //Debemos saber que  sucursal esta haciendo la invocaión
                                        int lIdSucursal = lCom.OBtenerIdSucursal();

                                        if (lIdSucursal == 1)   //Calama
                                            lObjINET = lPX.ObtenerObjetoINET_Calama(lDts, lFechaMov, lGlosa1, lGlosa2);

                                        if (lIdSucursal == 4)   // Santiago
                                            lObjINET = lPX.ObtenerObjetoINET(lDts, lFechaMov, lGlosa1, lGlosa2);

                                        //lObjINET = lPX.ObtenerObjetoINET(lDts, lFechaMov, lGlosa1, lGlosa2);
                                        lRespuestaWS_INET = InvocarWS_INET(lObjINET);

                                        inet_msg = lCom.buscarTagError(lRespuestaWS_INET.XML_Respuesta.ToString());
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
                                        row.Cells[0].Value = false;
                                    }
                                    else
                                        MessageBox.Show(solicitud_Material_Detalle.MensajeError.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                                }
                                else
                                {
                                    lIdDetalleSM = new Clases.ClsComun().Val(row.Cells["DET_ID"].Value.ToString());
                                    wsOperacion.AnularDetalleSolicitudMateriaPrima(lIdDetalleSM);
                                }
                            }
                        }
                    }
                    for (i = 0; i < lLista.Count; i++)
                    {
                        lIds_SMP = string.Concat(lLista[i], ",", lIds_SMP);
                    }
                    lCom.EnvioCorreo(lIds_SMP, Program.currentUser.Login, "Linea de Corte");


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

        private void Guardar_Version_QR()
        {
            Ws_TO.Ws_ToSoapClient lPX = new Ws_TO.Ws_ToSoapClient(); int i = 0; string lIds_SMP = "";
            Ws_TO.Objeto_WsINET lObjINET = new Ws_TO.Objeto_WsINET(); ArrayList lLista = new ArrayList();
            Integracion_INET.Tipo_InvocaWS lRespuestaWS_INET = new Integracion_INET.Tipo_InvocaWS();
            int lIdDetalleSM = 0;

            int counter = 0;
            string inet_msg = "", email_msg = "", newLine = Environment.NewLine, tab = "\t";

            string lCodigo = ""; string lCantidad = ""; string lFechaMov = ""; string lGlosa1 = ""; string lGlosa2 = "";

            DataTable lTblINET = new DataTable(); DataRow iFila = null;
            lTblINET.Columns.Add("Codigo", Type.GetType(("System.String")));
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
                    int lKgsProd = 0; Clases.ClsComun lCom = new Clases.ClsComun();
                    counter = 0;
                    foreach (DataGridViewRow row in dgvProductos.Rows)
                    {
                        if (row.Cells[COLUMNNAME_MARCA].Value != null)
                        {
                            if (((bool)row.Cells[COLUMNNAME_MARCA].Value == true)) // && (!row.Cells["ES_RECUPERADO"].Value.ToString().Equals("S")))
                            {
                                inet_msg = "";
                                IntegracionInet(row);
                            }
                        }
                    }
                    // Falta Cambiar el Envio del Correo 

                    //for (i = 0; i < lLista.Count; i++)
                    //{
                    //    lIds_SMP = string.Concat(lLista[i], ",", lIds_SMP);
                    //}
                    //lCom.EnvioCorreo(lIds_SMP, Program.currentUser.Login, "Linea de Corte");


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


        private void tlbGuardar_Click(object sender, EventArgs e)
        {
            if (mTipoColada.ToUpper().ToString().Equals("QR"))
            {
                Guardar_Version_QR();
            }

            else { Guardar_Version_Re_Etiquetado(); }
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

        private void VerificaCierresAnteriores()
        {
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient(); DataSet lDts = new DataSet();
            string lSql = String.Concat ( " SP_ConsultasGenerales 133,'", mUserLog .IdTotem ,"','','','',''");
            //1.- Verificamos si hay SMP del turno anterior abiertas
            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                //2.- Si las Hay, Se  debe hacer un cierre automatico
                CierreAutomatico(lDts.Tables[0].Copy());

                //3.- Enviar correo electronico a una lista de distribución y con un cuerpo por definir.
                // Por Definir

            }


        }

        private void CierreAutomatico(DataTable iTbl )
        {
            Ws_TO.Ws_ToSoapClient lPX = new Ws_TO.Ws_ToSoapClient(); int i = 0; string lIds_SMP = "";
            Ws_TO.Objeto_WsINET lObjINET = new Ws_TO.Objeto_WsINET(); ArrayList lLista = new ArrayList();
            Integracion_INET.Tipo_InvocaWS lRespuestaWS_INET = new Integracion_INET.Tipo_InvocaWS();
            int lIdDetalleSM = 0;

            int counter = 0;
            string inet_msg = "", email_msg = "", newLine = Environment.NewLine, tab = "\t";

            string lCodigo = ""; string lCantidad = ""; string lFechaMov = ""; string lGlosa1 = ""; string lGlosa2 = "";

            DataTable lTblINET = new DataTable(); DataRow iFila = null;
            lTblINET.Columns.Add("Codigo", Type.GetType(("System.String")));
            lTblINET.Columns.Add("Cantidad", Type.GetType(("System.String")));
            lTblINET.Columns.Add("FechaMov", Type.GetType(("System.String")));
            lTblINET.Columns.Add("Glosa1", Type.GetType(("System.String")));
            lTblINET.Columns.Add("Glosa2", Type.GetType(("System.String")));
            lTblINET.Columns.Add("Procesado", Type.GetType(("System.String")));



            dtpFechaRecepcion.Focus();
            counter = iTbl.Rows.Count; // forms.dataGridViewCountRowsChecked(dgvProductos, COLUMNNAME_MARCA);
            if (counter > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
                    WsOperacion.Solicitud_Material_Detalle solicitud_Material_Detalle = new WsOperacion.Solicitud_Material_Detalle();
                    int lKgsProd = 0; Clases.ClsComun lCom = new Clases.ClsComun();
                    counter = 0;
                    //foreach (DataGridViewRow row in dgvProductos.Rows)
                    for (i=0; i<iTbl .Rows.Count;i++)
                    {
                        if (iTbl.Rows[i]["Marca"] != null) // (row.Cells[COLUMNNAME_MARCA].Value != null)
                        {
                            //if (((bool)row.Cells[COLUMNNAME_MARCA].Value == true) && (row.Cells["ES_RECUPERADO"].Value.ToString().Equals("N")))
                            //{
                                lKgsProd = lCom.Val(iTbl.Rows[i]["KILOS_PROD"].ToString());
                          
                                if ((lKgsProd > 0))
                                {
                                    lTblINET.Clear();
                                    if (lCom.Agregar_IdSolicitud(lLista, iTbl.Rows[i]["SOL_ID"]. ToString()))
                                    {
                                        lLista.Add(iTbl.Rows[i]["SOL_ID"]. ToString());
                                    }
                                    lCodigo = iTbl.Rows[i][COLUMNNAME_PRODUCTO].ToString();                          
                                    lCantidad = iTbl.Rows[i]["KILOS_RECEP"]. ToString();
                                    lFechaMov = DateTime.Now.ToString();
                                    lGlosa1 = Program.currentUser.Login;
                                    lGlosa2 = lCom.ObtenerInicioFIn_Turno(Program.currentUser.IdTotem.ToString()); // ObtenerTurno(); // pero de la sesion anterior 

                                    iFila = lTblINET.NewRow();
                                    iFila["Codigo"] = lCodigo;
                                    iFila["Cantidad"] = lCantidad;
                                    iFila["FechaMov"] = lFechaMov;
                                    iFila["Glosa1"] = lGlosa1;
                                    iFila["Glosa2"] = lGlosa2;
                                    iFila["Procesado"] = "N";
                                    lTblINET.Rows.Add(iFila);


                                    // 1.- Se Integra con INET
                                    DataTable lTblFinal = new DataTable(); DataSet lDts = new DataSet();
                                    //lTblFinal = ObtenerDatosIntegracionINET(lTblINET);
                                    lDts.Tables.Add(lTblINET.Copy());
                                    lFechaMov = lFechaMov.Replace("/", "-");

                                    //Debemos saber que  sucursal esta haciendo la invocaión
                                    int lIdSucursal = lCom.OBtenerIdSucursal();

                                    if (lIdSucursal == 1)   //Calama
                                        lObjINET = lPX.ObtenerObjetoINET_Calama(lDts, lFechaMov, lGlosa1, lGlosa2);

                                    if (lIdSucursal == 4)   // Santiago
                                        lObjINET = lPX.ObtenerObjetoINET(lDts, lFechaMov, lGlosa1, lGlosa2);

                                    //lObjINET = lPX.ObtenerObjetoINET(lDts, lFechaMov, lGlosa1, lGlosa2);
                                    lRespuestaWS_INET = InvocarWS_INET(lObjINET);

                                    inet_msg = lCom.buscarTagError(lRespuestaWS_INET.XML_Respuesta.ToString());
                                    if (inet_msg.Trim().ToUpper().Equals("OK"))
                                    {
                                        counter++;
                                        if (email_msg.Equals(""))
                                        {
                                            email_msg += "Producto(s):" + newLine + newLine;
                                            email_msg += "Cod.Producto" + tab + "Descripción" + tab + "Cantidad" + newLine;
                                        }
                                        email_msg += iTbl.Rows[i][COLUMNNAME_PRODUCTO].ToString() + tab + iTbl.Rows[i][COLUMNNAME_PRODUCTO_DESCRIPCION].ToString() + tab + iTbl.Rows[i][COLUMNNAME_CANTIDAD_RECEP]. ToString() + newLine;
                                    }
                                    // 2.-  Se Registra el cierre del Producto

                                    solicitud_Material_Detalle.Id = Convert.ToInt32(iTbl.Rows[i][COLUMNNAME_ID]. ToString());
                                    solicitud_Material_Detalle.Producto = iTbl.Rows[i][COLUMNNAME_PRODUCTO]. ToString();
                                    solicitud_Material_Detalle.Usuario_Cierre = Program.currentUser.Login;
                                    //solicitud_Material_Detalle.Fecha_Cierre = "";
                                    solicitud_Material_Detalle.Tipo = iTbl.Rows[i][COLUMNNAME_TIPO].ToString().Substring(0, 1);
                                    solicitud_Material_Detalle.Cantidad = Convert.ToInt32(iTbl.Rows[i][COLUMNNAME_CANTIDAD_RECEP].ToString());
                                    solicitud_Material_Detalle.Inet_Msg = inet_msg;

                                    solicitud_Material_Detalle = wsOperacion.GuardarCierreMaterial(solicitud_Material_Detalle, inet_msg, Program.currentUser.Login, Program.currentUser.ComputerName, Program.currentUser.IdTotem);
                                    if (solicitud_Material_Detalle.MensajeError.Equals(""))
                                    {
                                        //row.Cells[0].Value = false;
                                    }
                                    else
                                        MessageBox.Show(solicitud_Material_Detalle.MensajeError.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    lIdDetalleSM = new Clases.ClsComun().Val(iTbl.Rows[i]["DET_ID"].ToString());
                                    wsOperacion.AnularDetalleSolicitudMateriaPrima(lIdDetalleSM);
                                }

                            //}
                        }
                    }
                    for (i = 0; i < lLista.Count; i++)
                    {
                        lIds_SMP = string.Concat(lLista[i], ",", lIds_SMP);
                    }
                    lCom.EnvioCorreo(lIds_SMP, Program.currentUser.Login, "Linea de Corte");

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
            WsCrud .ListaDataSet lDts=new WsCrud.ListaDataSet (); Clases.ClsComun lCom = new Clases.ClsComun();
            
            try
            {
               // iEstado.Text = iEstado.Text & vbCrLf & "Cargando Objeto Entrada Bodega Productos Terminados  " : iEstado.Refresh()
                    lTipoEntradaEx = lCom.CargaObjEntradaBodegaProdTerm_INET(iObjINET);
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




        private DataTable ObtenerTablaFinal(DataTable iOrigen)
        {
            DataTable lTblFinal = new DataTable();DataRow lFila = null;Clases.ClsComun lCom = new Clases.ClsComun();
            string lProd = "";int i = 0; DataView lVista = null;string lWhere = "";


            lTblFinal.Columns.Add("CodMaterial", Type.GetType("System.String"));
            lTblFinal.Columns.Add("KgsProducidos", Type.GetType("System.String"));
            lTblFinal.Columns.Add("KgsDespunte", Type.GetType("System.String"));
            lTblFinal.Columns.Add("Producto", Type.GetType("System.String"));

            if (iOrigen.Rows.Count > 0)
            {
                for (i = 0; i < iOrigen.Rows.Count; i++)
                {
                    lWhere = string.Concat("CodMaterial='", iOrigen.Rows[i]["CodMaterial"].ToString(),"'") ;
                    lVista = new DataView(lTblFinal, lWhere, "", DataViewRowState.CurrentRows);
                    if (lVista.Count == 0)
                    {
                        lFila = lTblFinal.NewRow();
                        lFila["CodMaterial"] = iOrigen.Rows[i]["CodMaterial"].ToString();
                        lFila["Producto"] = iOrigen.Rows[i]["Producto"].ToString();
                        if (iOrigen.Rows[i]["Tipo"].ToString().ToUpper().Equals("D"))
                            lFila["KgsDespunte"] = iOrigen.Rows[i]["TotalKgs"].ToString();
                        else
                            lFila["KgsProducidos"] = iOrigen.Rows[i]["TotalKgs"].ToString();


                        lTblFinal.Rows.Add(lFila);
                    }
                    else
                        if(lVista.Count == 1)
                    {
                        //lFila = lTblFinal.NewRow();
                        //lFila["CodMaterial"] = iOrigen.Rows[i]["CodMaterial"].ToString();
                        //lFila["Producto"] = iOrigen.Rows[i]["Producto"].ToString();
                        if (lCom.Val(lVista[0]["KgsProducidos"].ToString()) < 1)
                        {
                            lVista[0]["KgsProducidos"] = iOrigen.Rows[i]["TotalKgs"].ToString();
                        }
                        else
                        if (lCom.Val(lVista[0]["KgsDespunte"].ToString()) > 0)
                        {
                            lVista[0]["KgsDespunte"] = iOrigen.Rows[i]["TotalKgs"].ToString();
                        }



                    }
                }

             

            }


            return lTblFinal;
        }

       
       
        private void BloquearColumnas(DataGridView dgv)
        {
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                if (column.Index > 0)
                    column.ReadOnly = true;
            }
        }

        private void Cierre_Version_Re_Etiquetado()
        {
            try
            {
                //tlbNuevo_Click(sender, e);
                WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
                WsOperacion.ListaDataSet listaDataSet = new WsOperacion.ListaDataSet();

                //******Temporal por regularizacion de datos
                DateTime lFecha = DateTime.Parse(string.Concat(dtpFechaRecepcion.Value.ToShortDateString(), " 05:00:00"));
                listaDataSet = wsOperacion.ListarSolicitudMaterial_Cierre(lFecha, Program.currentUser.IdTotem, cboCriterio.Text.Substring(0, 1));
                //******Temporal por regularizacion de datos  fin 
                //listaDataSet = wsOperacion.ListarSolicitudMaterial_Cierre(dtpFechaRecepcion.Value,int .Parse ( mIdSucursal), cboCriterio.Text.Substring(0,1));
                if (listaDataSet.MensajeError.Equals(""))
                {
                    //lVista = new DataView(listaDataSet.DataSet.Tables[0], "Es_Recuperado='N'", "", DataViewRowState.CurrentRows);

                    //  dgvProductos.DataSource = ObtenerTablaFinal(  listaDataSet.DataSet.Tables[0].Copy ());

                    dgvProductos.DataSource = listaDataSet.DataSet.Tables[0].Copy();

                    //mTblOriginal = listaDataSet.DataSet.Tables[0].Copy ();
                    //mTblDetalle = listaDataSet.DataSet.Tables[1];

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
        }

        private void Cierre_Version_QR()
        {
            try
            {
                WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
                WsOperacion.ListaDataSet listaDataSet = new WsOperacion.ListaDataSet();
                listaDataSet = wsOperacion.ListarSolicitudMaterial_Cierre_QR(dtpFechaRecepcion.Value, int.Parse(mIdSucursal), cboCriterio.Text.Substring(0, 1),mUserLog .IdMaquina.ToString () );
                if (listaDataSet.MensajeError.Equals(""))
                {
                   dgvProductos.DataSource = ObtenerTablaFinal(  listaDataSet.DataSet.Tables[0].Copy ());
                    mTblOriginal = listaDataSet.DataSet.Tables[0].Copy();
                    mTblDetalle = listaDataSet.DataSet.Tables[1];

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
        }

        private void tlbActualizar_Click(object sender, EventArgs e)
        {
            DataView lVista = null;
            Cursor.Current = Cursors.WaitCursor;

            mTipoColada = ConfigurationManager.AppSettings["TipoColada"].ToString();

            if (mTipoColada.ToUpper().ToString().Equals("QR"))
            {
                Cierre_Version_QR();
            }

            else { Cierre_Version_Re_Etiquetado(); }

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

            mIdSucursal=ConfigurationManager.AppSettings["IdSucursal"].ToString();
            bool enabledAdmin = Program.currentUser.PerfilUsuario.Equals("ADMIN");

            if (Program.currentUser.PerfilUsuario.ToString().IndexOf("Adm") > -1)
                enabledAdmin = true;
            else
                enabledAdmin = false;


            tlbGuardar.Enabled = !enabledAdmin;
            tlbReprocesar.Enabled = enabledAdmin;
            cboCriterio.SelectedIndex = 0;

            mTipoColada = ConfigurationManager.AppSettings["TipoColada"].ToString();

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
          //  new Clases .ClsComun ().EnvioCorreo("562", Program.currentUser.Login, "Linea de Corte");
        }

        private void Btn_repara_Click(object sender, EventArgs e)
        {
            ReparaInconsistencia();
        }


        private void ReparaInconsistencia()

        {
            DataTable lTbl = new DataTable(); DataSet ldts = new DataSet(); DataSet ldtsTMP = new DataSet();
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient(); int i = 0;
            string lSql = "   select dr.id IdDetalleRecep, CodMaterial, Codigo, Producto, count(1)  from DetalleRecepcion_MP dr , ";
            lSql = string.Concat(lSql, "  Recepcion_MP r, EtiquetaMP_Recepcionada er , EtiquetaAZA e, EtiquetasVinculadas ev , ");
            lSql = string.Concat(lSql, "    detallePaquetesPieza d,    PIEZA_PRODUCCION ");
            lSql = string.Concat(lSql, "    where r.Id = dr.Id_Detalle_RMP  and er.Id_DR_MP = dr.id  and e.Id = Id_EtiquetaAZA ");
            lSql = string.Concat(lSql, "     and ev.IdQr = e.id  and d.id = ev.idetiquetaTO  and d.id = pie_etiqueta_Pieza  and r.SucCodINET = 1");
            lSql = string.Concat(lSql, "     and ev.estado is null  and ev.fechaRegistro < '17/02/2020 00:00:00'    and CodMaterial<>Codigo ");
            lSql = string.Concat(lSql, "    and   exists (Select 1 from DetalleProductoIntegrado dpi where dpi.IdQr = ev.IdQr  and EstadoIntegracion = 'ER') ");
            lSql = string.Concat(lSql, " group by   dr.id  , CodMaterial , Codigo , Producto   ");
            lSql = string.Concat(lSql, "     order by count(1) desc  ");

            ldts = lPx.ObtenerDatos(lSql);
            if  ((ldts .Tables.Count >0) && (ldts.Tables[0].Rows .Count >0))
            {
                lTbl = ldts.Tables[0].Copy();
                for (i=0;i<lTbl .Rows .Count;i++)
                {
                    lSql = string.Concat("   update  DetalleRecepcion_MP set  CodMaterial ='", lTbl .Rows [i]["Codigo"].ToString (),"' where  ");
                    lSql = string.Concat(lSql, "   Id=", lTbl.Rows[i]["IdDetalleRecep"].ToString());
                    ldts = lPx.ObtenerDatos(lSql);

                }
             



            }

        

        }
    }
}