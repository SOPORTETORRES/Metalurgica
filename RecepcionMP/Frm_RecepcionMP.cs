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

namespace Metalurgica.RecepcionMP
{
    public partial class Frm_RecepcionMP : Form
    {
        DataTable mTblDatos = new DataTable();
        DataTable mTBlMP = new DataTable();
        DataTable mTBlCodigosIntercambio = new DataTable();
        private CurrentUser mUserLog = new CurrentUser();

        public Frm_RecepcionMP()
        {
            InitializeComponent();
        }

        public void Inicia(CurrentUser iUser)
        {
            mUserLog = iUser;

        }

        private void Tx_EtiquetaAza_Validating(object sender, CancelEventArgs e)
        {
            DataTable dt = new DataTable();   Clases.ClsComun lCom = new Clases.ClsComun();
            if (!Tx_EtiquetaAza.Text.Trim().Equals(""))
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    

                    ProcesaColada(Tx_EtiquetaAza.Text);

                    Tx_EtiquetaAza.Text = "";
                    Tx_EtiquetaAza.Focus();




                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Cursor.Current = Cursors.Default;
            }
        }

        private void RevisaEnOC(WsOperacion.TipoEtiquetaAza iEtiqueta )
        {
            int i = 0;string lMaterial = "";string lPar = ""; int lKgsRecep = 0;Clases.ClsComun lCom = new Clases.ClsComun();
            string[] lPartes = null;DataView lVista = null;int lKgsSol = 0;int lRecep = 0;string lTipo = "";
            string lEsSoldable = "";

            try
            {
                for (i = 0; i < mTblDatos.Rows.Count - 1; i++)
                {
                    lMaterial = mTblDatos.Rows[i]["Codigo"].ToString().Trim();
                    lKgsSol = lCom.Val(mTblDatos.Rows[i]["Kilos Oc"].ToString());

                    lPar = mTblDatos.Rows[i]["IdEtiquetaAZA"].ToString();

                    if (iEtiqueta.Producto.ToString().ToUpper().IndexOf("ROLLO") > -1)
                        lTipo = "R";
                    else
                        lTipo = "B";

                    lEsSoldable = new Clases.ClsComun().ObtenerSoldable(iEtiqueta.Producto);

                    lVista = new DataView(mTBlMP, string.Concat(" Codigo='", lMaterial, "' and Tipo='", lTipo, "' and Soldable='", lEsSoldable, "'"), "", DataViewRowState.CurrentRows);
                    if ((lVista.Count > 0) && (lVista[0]["Descripcion"].ToString().ToUpper().IndexOf("ROLLO") > -1))
                    {
                        if ((lVista.Count > 0) && ((lPar.IndexOf(iEtiqueta.Id.ToString()) < 0)))      //(lMaterial.Length > 4)
                        {
                            if ((lCom.Val(lVista[0]["NombreMedidas"].ToString()) == (lCom.Val(iEtiqueta.Diam.ToString()))))
                            {
                                lKgsRecep = lCom.Val(mTblDatos.Rows[i]["Kilos recibidos"].ToString());
                                if (lKgsRecep > 0)
                                    lKgsRecep = lKgsRecep + lCom.Val(iEtiqueta.PesoBulto.ToString()) + lCom.Val(mTblDatos.Rows[i][4].ToString());
                                else
                                    lKgsRecep = lCom.Val(iEtiqueta.PesoBulto.ToString());


                                lKgsSol = lCom.Val(mTblDatos.Rows[i]["Kilos OC"].ToString());

                                mTblDatos.Rows[i]["Kilos Pendientes"] = (lKgsSol - lKgsRecep).ToString();
                                mTblDatos.Rows[i][4] = lCom.Val(mTblDatos.Rows[i][4].ToString()) + lCom.Val(iEtiqueta.PesoBulto.ToString());
                                mTblDatos.Rows[i]["IdEtiquetaAza"] = string.Concat(mTblDatos.Rows[i]["IdEtiquetaAza"].ToString(), iEtiqueta.Id, "-");
                            }
                        }
                    }
                    else
                    {
                        if ((lVista.Count > 0) && ((lPar.IndexOf(iEtiqueta.Id.ToString()) < 0)))      //(lMaterial.Length > 4)
                        {
                            if ((lCom.Val(lVista[0]["NombreMedidas"].ToString()) == (lCom.Val(iEtiqueta.Diam.ToString())) && (lCom.Val(lVista[0]["Largo"].ToString())) == (lCom.Val(iEtiqueta.Largo.ToString()))))
                            {
                                lKgsRecep = lCom.Val(mTblDatos.Rows[i]["Kilos recibidos"].ToString());
                                if (lKgsRecep > 0)
                                    lKgsRecep = lKgsRecep + lCom.Val(iEtiqueta.PesoBulto.ToString()) + lCom.Val(mTblDatos.Rows[i][4].ToString());
                                else
                                    lKgsRecep = lCom.Val(iEtiqueta.PesoBulto.ToString());


                                lKgsSol = lCom.Val(mTblDatos.Rows[i]["Kilos OC"].ToString());

                                mTblDatos.Rows[i]["Kilos Pendientes"] = (lKgsSol - lKgsRecep).ToString();
                                mTblDatos.Rows[i][4] = lCom.Val(mTblDatos.Rows[i][4].ToString()) + lCom.Val(iEtiqueta.PesoBulto.ToString());
                                mTblDatos.Rows[i]["IdEtiquetaAza"] = string.Concat(mTblDatos.Rows[i]["IdEtiquetaAza"].ToString(), iEtiqueta.Id, "-");
                            }
                        }
                        else
                        {
                            // CAlidad 440

                        }
                    }


                }
            }
            catch (Exception ex)
            {

            }
            RefescaGrilla();
        }

        private void RevisaEnOC_PorTablaDeCodigo(WsOperacion.TipoEtiquetaAza iEtiqueta)
        {
            int i = 0; string lMaterial = ""; string lPar = ""; int lKgsRecep = 0; Clases.ClsComun lCom = new Clases.ClsComun();
            string[] lPartes = null; DataView lVista = null; int lKgsSol = 0; int lRecep = 0; string lTipo = "";DataView lVistaCod = null;
            string lEsSoldable = "";string lCodTO = "";

            try
            {
                lVista = new DataView(mTblDatos, string.Concat(" Codigo='", iEtiqueta.Codigo, "'"), "", DataViewRowState.CurrentRows);
                if (lVista.Count > 0)
                {
                    lKgsSol = lCom.Val(lVista[0]["Kilos Oc"].ToString());
                    lPar = lVista[0]["IdEtiquetaAZA"].ToString();

                    lKgsRecep = lCom.Val(lVista[0]["Kilos recibidos"].ToString());
                    if (lKgsRecep > 0)
                        lKgsRecep = lKgsRecep + lCom.Val(iEtiqueta.PesoBulto.ToString()) + lCom.Val(lVista[0][4].ToString());
                    else
                        lKgsRecep = lCom.Val(iEtiqueta.PesoBulto.ToString());


                    lKgsSol = lCom.Val(lVista[0]["Kilos OC"].ToString());

                    lVista[0]["Kilos Pendientes"] = (lKgsSol - lKgsRecep).ToString();
                    lVista[0][4] = lCom.Val(lVista[0][4].ToString()) + lCom.Val(iEtiqueta.PesoBulto.ToString());
                    lVista[0]["IdEtiquetaAza"] = string.Concat(lVista[0]["IdEtiquetaAza"].ToString(), iEtiqueta.Id, "-");
                }
                else
                {
                    lVistaCod = new DataView(mTBlCodigosIntercambio, string.Concat("PAr1='", iEtiqueta.Codigo, "'"), "", DataViewRowState.CurrentRows);
                    if (lVistaCod.Count > 0)
                    //for (i = 0; i < mTblDatos.Rows.Count - 1; i++)
                    {
                        lCodTO = lVistaCod[0]["Par2"].ToString();
                        lVista = new DataView(mTblDatos, string.Concat(" Codigo='", lCodTO, "'"), "", DataViewRowState.CurrentRows);
                        if (lVista.Count > 0)
                        {
                            lKgsSol = lCom.Val(lVista[0]["Kilos Oc"].ToString());
                            lPar = lVista[0]["IdEtiquetaAZA"].ToString();

                            lKgsRecep = lCom.Val(lVista[0]["Kilos recibidos"].ToString());
                            if (lKgsRecep > 0)
                                lKgsRecep = lKgsRecep + lCom.Val(iEtiqueta.PesoBulto.ToString()) + lCom.Val(lVista[0][4].ToString());
                            else
                                lKgsRecep = lCom.Val(iEtiqueta.PesoBulto.ToString());


                            lKgsSol = lCom.Val(lVista[0]["Kilos OC"].ToString());

                            lVista[0]["Kilos Pendientes"] = (lKgsSol - lKgsRecep).ToString();
                            lVista[0][4] = lCom.Val(lVista[0][4].ToString()) + lCom.Val(iEtiqueta.PesoBulto.ToString());
                            lVista[0]["IdEtiquetaAza"] = string.Concat(lVista[0]["IdEtiquetaAza"].ToString(), iEtiqueta.Id, "-");
                        }
                    }
                    else
                    {
                        MessageBox.Show("El Código leido, No esta en la Base de datos, Avisar a Logistica ", "Avisos Sistema");
                    }
                }
            }
            catch (Exception ex)
            {

            }
            RefescaGrilla();
        }


        private void RefescaGrilla()
        {
            int i = 0; int lTotalKgsOC = 0; int lTotalRecep = 0; Clases.ClsComun lCom = new Clases.ClsComun();
            DataRow lFila = null;DataView lVista = null; int lTotal_a_Recep = 0;

            try
            {
                for (   i = 0; i < mTblDatos.Rows.Count; i++)
                {
                    if (mTblDatos.Rows[i]["Descripcion"].ToString().ToUpper ()!="TOTALES")
                    { 
                    lTotalKgsOC = lTotalKgsOC + lCom.Val(mTblDatos.Rows[i]["Kilos OC"].ToString());
                    lTotalRecep = lTotalRecep + lCom.Val(mTblDatos.Rows[i][5].ToString());
                    lTotal_a_Recep = lTotal_a_Recep + lCom.Val(mTblDatos.Rows[i][4].ToString());

                    if (lTotalRecep < 0)
                        lTotalRecep = 0;
                    }
                }
                lVista = new DataView(mTblDatos, "Descripcion='TOTALES'", "", DataViewRowState.CurrentRows);
                if (lVista .Count ==0)
                {
                    lFila = mTblDatos.NewRow();
                    lFila["Kilos OC"] = lTotalKgsOC;
                    lFila[5] = lTotalRecep;
                    lFila[4] = lTotal_a_Recep;
                    lFila["Descripcion"] = "TOTALES";
                    mTblDatos.Rows.Add(lFila);
                }
                else
                {
                    lVista[0]["Kilos OC"] = lTotalKgsOC;
                    lVista[0][5] = lTotalRecep;
                    lVista[0][4] = lTotal_a_Recep;
                }

                //Dtg_Etiquetas.Rows[6].Cells["Descripcion"].Value = "TOTALES";
                //Dtg_Etiquetas.Rows[6].Cells["Cantidad"].Value = lTotalKgsOC.ToString();
                //Dtg_Etiquetas.Rows[6].Cells["KgsRecepcionados"].Value = lTotalRecep.ToString();

                Font lFuente = new Font("Arial", 12, FontStyle.Bold);
                for (i = 0; i < this.Dtg_Etiquetas.Rows.Count - 2; i++)
                {
                    Dtg_Etiquetas.Rows[i].Cells[4].Style.BackColor = Color.Black;
                    Dtg_Etiquetas.Rows[i].Cells[4].Style.ForeColor  = Color.White ;
                    Dtg_Etiquetas.Rows[i].Cells[4].Style.Font = lFuente;
                }

             }
            catch (Exception iEx)
            {
                MessageBox.Show("Se ha producido el siguiente error: " + iEx.Message.ToString());
            }

        }




        private void ProcesaColada(string iTx)
        {
            WsOperacion.TipoEtiquetaAza lEt = new WsOperacion.TipoEtiquetaAza();
            string lTmp = "";Clases.ClsComun lCom = new Clases.ClsComun();
            WsOperacion.OperacionSoapClient lDal = new WsOperacion.OperacionSoapClient();
            DataTable lTblDatos = new DataTable();string lSucursal = "";

            //if (iTx.IndexOf("ñ") > -1)  //es etiqueta de AZA ya que el ; es el separador de Caracteres
            //{
                lTmp = iTx.Replace("ñ", ";");
                lTmp = lTmp.Replace("Ñ", ":");
                lTmp = lTmp.Replace("'", "-");
                lTmp = lTmp.Replace(")", "(");
                lTmp = lTmp.Replace("=", ")");

                lEt = lCom.ObtenerEtiquetaAZA(lTmp,false );
            if (lEt.Errors.Trim().Length > 3)
            {
                MessageBox.Show(lEt.Errors.ToString(), " Error en el sistema ", MessageBoxButtons.OK);
            }
            else
            {
                lSucursal = new Clases .ClsComun ().OBtenerSucursal().ToString();

                lEt = lDal.PersistirEtiquetaAZA(lEt, lSucursal);
                if (Dtg_Etiquetas.Rows.Count > 0)
                {
                    //RevisaEnOC(lEt);
                    // debemos crear tabla que almacene IdEtiquetaAza   -  OC 
                    RevisaEnOC_PorTablaDeCodigo(lEt);
                }
            }
        }

        private void AgregaEtiqueta(WsOperacion.TipoEtiquetaAza lEt_AZA)
        {
            DataRow lFila = mTblDatos.NewRow();
            lFila["Lote"] = lEt_AZA.Lote.ToString ();
            lFila["FechaFabricacion"] = lEt_AZA.FechaFabricacion .ToString();
            lFila["Bulto"] = lEt_AZA.Bulto.ToString();
            lFila["Producto"] = lEt_AZA.Producto .ToString();
            lFila["Codigo"] = lEt_AZA.Codigo.ToString();
            lFila["PesoBulto"] = lEt_AZA.PesoBulto.ToString();
            lFila["Diam"] = lEt_AZA.Diam.ToString();
            lFila["Largo"] = lEt_AZA.Largo .ToString();

            mTblDatos.Rows.Add(lFila);

        }

        private void Frm_RecepcionMP_Load(object sender, EventArgs e)
        {
            //Cargamos las materias Primas 
            WsOperacion.OperacionSoapClient lPx = new WsOperacion.OperacionSoapClient();
            WsOperacion.ListaDataSet lDts = new WsOperacion.ListaDataSet(); DataTable lTbl = new DataTable();
            string lSucursal = ConfigurationManager.AppSettings["Sucursal"].ToString();
            int lIndexSel = 0;  int i = 0;

            lDts = lPx.Obtener_MP( );
            if ((lDts.MensajeError.Trim().Length == 0) && (lDts.DataSet.Tables.Count > 0))
            {
                if (lDts.DataSet.Tables.Count == 3)
                {
                    mTBlMP = lDts.DataSet.Tables["MP"].Copy();
                    mTBlCodigosIntercambio= lDts.DataSet.Tables["Codigos_Intercambio"].Copy();

                    lTbl = lDts.DataSet.Tables["Sucursales"].Copy();
                    for (i = 0; i < lTbl.Rows.Count; i++)
                    {
                        if (lTbl.Rows[i]["Sucursal"].ToString().ToUpper().Equals(lSucursal.ToUpper()))
                        {
                            lIndexSel = i;
                        }
                    }
                    
                  
                        new Forms().comboBoxFill(Cmb_Sucursal, lTbl, "Id", "Sucursal", lIndexSel);
                   
                    

                   // Cmb_Sucursal.SelectedText = lSucursal;

                }
              
            }

            mTblDatos = new DataTable();
            mTblDatos.Columns.Add("Lote", Type.GetType("System.String"));
            mTblDatos.Columns.Add("FechaFabricacion", Type.GetType("System.String"));
            mTblDatos.Columns.Add("Bulto", Type.GetType("System.String"));
            mTblDatos.Columns.Add("Producto", Type.GetType("System.String"));
            mTblDatos.Columns.Add("Codigo", Type.GetType("System.String"));
            mTblDatos.Columns.Add("PesoBulto", Type.GetType("System.String"));
            mTblDatos.Columns.Add("Diam", Type.GetType("System.String"));
            mTblDatos.Columns.Add("Largo", Type.GetType("System.String"));

            Dtg_Etiquetas.DataSource = mTblDatos;

            Tx_EtiquetaAza.Enabled = false;
        }

        private void Tx_OC_Validating(object sender, CancelEventArgs e)
        {
            if (!Tx_OC.Text.Trim().Equals(""))
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    CargaDatosOC(Cmb_Sucursal.SelectedValue.ToString ()  , Tx_OC.Text);
                    RefescaGrilla();
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Cursor.Current = Cursors.Default;
            }
        }

        private Boolean  VerificaGuiaDespacho(string iNroGuia)
        {
            WsOperacion.OperacionSoapClient lPx = new WsOperacion.OperacionSoapClient();
            WsOperacion.ListaDataSet lDts = new WsOperacion.ListaDataSet(); DataTable lTbl = new DataTable();
            int i = 0;   Clases.ClsComun lCom = new Clases.ClsComun();Boolean lRes = true;

            lDts = lPx.VerificaNroGuiaDespacho(iNroGuia);
            if ((lDts.MensajeError.Trim().Length == 0) && (lDts.DataSet.Tables.Count > 0))
            {
                lTbl = lDts.DataSet.Tables[0].Copy();
                if (lTbl.Rows.Count > 0)
                    lRes = false;
            }

            return lRes;
        }


        private void CargaDatosOC(string  lCodSuc ,  string  iOc)
        {
            WsOperacion.OperacionSoapClient lPx = new WsOperacion.OperacionSoapClient();
            WsOperacion.ListaDataSet lDts = new WsOperacion.ListaDataSet();DataTable lTbl = new DataTable();
            int i = 0; int lSaldo = 0; Clases.ClsComun lCom = new Clases.ClsComun();

            Dtg_Etiquetas.DataSource = null;
            lDts = lPx.ObtenerDetalle_OC_Aza(lCodSuc,iOc);
            if ((lDts.MensajeError.Trim().Length == 0) && (lDts .DataSet .Tables .Count >0))
            {
                lTbl = lDts.DataSet.Tables[0].Copy();
                //lTbl.Columns.Add("KgsRecepcionados", Type.GetType("System.String"));
                //lTbl.Columns.Add("Kgs_a_Recepcionar", Type.GetType("System.String"));
                //lTbl.Columns.Add("KgsXRecepcionar", Type.GetType("System.String"));
                lTbl.Columns.Add("IdEtiquetaAZA", Type.GetType("System.String"));
                mTblDatos = lTbl.Copy();

                for (i = 0; i < mTblDatos.Rows.Count; i++)
                {
                    lSaldo = lCom.Val(mTblDatos.Rows[i]["Kilos OC"].ToString()) - lCom.Val(mTblDatos.Rows[i][5].ToString());
                    mTblDatos.Rows[i][6] = lSaldo.ToString ();
                }

                Dtg_Etiquetas.DataSource = mTblDatos;
                Dtg_Etiquetas.Columns["UnidadMedida"].Visible = false;
                Dtg_Etiquetas.Columns["Precio"].Visible = false;
                Dtg_Etiquetas.Columns["Monto"].Visible = false;
                Dtg_Etiquetas.Columns["IdEtiquetaAza"].Visible = false;

                Dtg_Etiquetas.Columns["Codigo"].Width = 150;
                Dtg_Etiquetas.Columns["Descripcion"].Width = 350;
                Dtg_Etiquetas.Columns["Kilos OC"].Width = 80;
                Dtg_Etiquetas.Columns[3].Width = 130;
                Dtg_Etiquetas.Columns[4].Width = 110;
                Dtg_Etiquetas.Columns[6].Width = 110;


            }

        }


        private void Dtg_Etiquetas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int iFila = e.RowIndex;
            Tx_producto.Text = Dtg_Etiquetas.Rows[iFila].Cells["Descripcion"].Value.ToString();


        }

        private void Btn_ImprimeQR_Click(object sender, EventArgs e)
        {
            //ImprimirQR.Form1 lFrm = new ImprimirQR.Form1();
            //lFrm.IniciaForm("");
            //lFrm.ShowDialog(this);
            string lEt_TX = ""; string lProducto = "";


            lProducto = string.Concat("HORMIGON ", Tx_diametro.Text, "mm ", Tx_largo.Text, "m  A630-420H (N)");
            lEt_TX = string.Concat(Tx_lote.Text, ";", DateTime.Now.ToShortDateString() , ";", Tx_nroBulto.Text, ";", lProducto, ";Codigo,", Tx_PesoBulto.Text);
            Tx_CB.Text = lEt_TX;

        }

        private void Btn_grabar_Click(object sender, EventArgs e)
        {
            PersistirDatos();

        }


        private Boolean ValidarDatosAntesDeGrabar()
        {
            Clases.ClsComun lCom = new Clases.ClsComun();
            string lMsg = "";Boolean lRes = true;

            if (lCom.Val(Tx_GuiaDesp.Text) < 1)
            {
                lRes = false;
                lMsg = string.Concat(" Debe Indicar el Nro de Guia de despacho ", Environment .NewLine );
            }
            if (lCom.Val(Tx_TotalKgsGD .Text) < 1)
            {
                lRes = false;
                lMsg = string.Concat(" Debe Indicar el Peso  según la Guía de Despacho ", Environment.NewLine);
            }

            if (lCom.Val(Tx_OC .Text) < 1)
            {
                lRes = false;
                lMsg = string .Concat (lMsg , " Debe Indicar el Nro de Orden de Compra ", Environment.NewLine);
            }

            //Revisamos el detalle
            if (Dtg_Etiquetas.Rows.Count == 0)
            {
                lRes = false;
                lMsg = string.Concat(lMsg, " No se registran Lecturas de etiquetas ", Environment.NewLine);
             }

          

            // revisamos que el peso de la GD es igual a lo pistoleado.
            DataView lVista = null;int lTotalIng = 0;
            lVista = new DataView(mTblDatos, "Descripcion='TOTALES'", "", DataViewRowState.CurrentRows);
            if (lVista.Count == 0)
            {
                lTotalIng = 0;
            }
            else
            {
                lTotalIng = lCom.Val(lVista[0][4].ToString());
            }

            if (lTotalIng!=lCom.Val(Tx_TotalKgsGD.Text))
            {
                lRes = false;
                lMsg = string.Concat(lMsg, " La suma de las etiquetas Leidas es distinto a los kilos de la guia de despacho", Environment.NewLine);
            }

            if (lMsg.Length > 0)
            {
                MessageBox.Show(lMsg, "Avisos Sistema", MessageBoxButtons.OK);
            }
            return lRes;

        }

        private WsOperacion.Recepcion_MP CargarObj()
        {
            WsOperacion.Recepcion_MP lObj = new WsOperacion.Recepcion_MP();Clases.ClsComun lCom = new Clases.ClsComun();
            WsOperacion.Detalle_Recepcion_MP  lObjDet  = new WsOperacion.Detalle_Recepcion_MP();
            int lCont = 0; DataTable lTblFinal = new DataTable();int lNroDetalle = 0;
           

            //List<WsOperacion.Detalle_Recepcion_MP> lDetalle = new List<WsOperacion.Detalle_Recepcion_MP>() ;
           
            int i = 0; int j = 0; string[] lPartes = null;
            //lPartes = lPar.Split(new Char[] { '-' });

            lObj.FechaGD = Dtp_Fecha.Value.ToShortDateString();
            lObj.IdUserGraba = lCom.Val(mUserLog.Iduser.ToString()); //; // 1;
            lObj.NroGD =lCom .Val(Tx_GuiaDesp.Text);
            lObj.KgsGD  = lCom.Val(Tx_TotalKgsGD.Text);
            lObj.OC = lCom.Val (Tx_OC.Text);
            lObj.SucCod = lCom.Val(Cmb_Sucursal.SelectedValue.ToString());

            //mTblDatos.Rows
            lTblFinal = mTblDatos.GetChanges();
            lNroDetalle = 0;
            //  for (i = 0; i < Dtg_Etiquetas.Rows.Count; i++)
            //  obtenemos el nro de etiquetas leidas
            for (i = 0; i < lTblFinal.Rows.Count; i++)
            {
                lPartes = lTblFinal.Rows[i]["IdEtiquetaAZA"].ToString().Split(new Char[] { '-' });
                lNroDetalle = lNroDetalle + lPartes.Length -1;

            }
            WsOperacion.Detalle_Recepcion_MP[] lDetalle = new WsOperacion.Detalle_Recepcion_MP[lNroDetalle];
            for (i = 0; i < lTblFinal.Rows.Count; i++)
                {
                lPartes = lTblFinal.Rows[i] ["IdEtiquetaAZA"]. ToString().Split(new Char[] { '-' });
               
                for (j = 0; j < lPartes.Length ; j++)
                {
                    if ( lPartes [j].ToString ().Length>0)
                    {
                        lObjDet = new WsOperacion.Detalle_Recepcion_MP();
                        lObjDet.CodMaterial = lTblFinal.Rows[i] ["Codigo"]. ToString().Trim();
                        lObjDet.IdEtiquetaAza =  lPartes[j].ToString();
                        lObjDet.IdRecepcionMP = 0;
                        lObjDet.Kgs = lCom.Val(lTblFinal.Rows[i]["Kilos Oc"]. ToString().Trim());
                        lObjDet.FechaEntrega_OC  = lTblFinal.Rows[i]["Fecha de entrega"]. ToString();

                        lDetalle[lCont] =lObjDet;
                        lCont = lCont + 1;
                    }
                }
                //lObj.Detalle =(Metalurgica.) lDetalle;
                
                
            }
            if (lCont > 0)
            {
                lObj.Detalle = lDetalle;
                lCont = 0;
            }

            return lObj;

        }

        private WsOperacion.Recepcion_MP CargarObj_Desde_Archivo( DataTable lTblData)
        {
            WsOperacion.Recepcion_MP lObj = new WsOperacion.Recepcion_MP(); Clases.ClsComun lCom = new Clases.ClsComun();
            WsOperacion.Detalle_Recepcion_MP lObjDet = new WsOperacion.Detalle_Recepcion_MP();
            int lCont = 0; DataTable lTblFinal = new DataTable(); int lNroDetalle = 0;
            WsOperacion.TipoEtiquetaAza lEt = new WsOperacion.TipoEtiquetaAza();

            //List<WsOperacion.Detalle_Recepcion_MP> lDetalle = new List<WsOperacion.Detalle_Recepcion_MP>() ;

            int i = 0; int j = 0; string[] lPartes = null;
            //lPartes = lPar.Split(new Char[] { '-' });

            try
            {
                lObj.FechaGD = "03/02/2020 19:20";
                lObj.IdUserGraba = 1;
                lObj.NroGD = lCom.Val("1114");
                lObj.KgsGD = lCom.Val(Tx_TotalKgsGD.Text);
                lObj.OC = lCom.Val("1114");
                lObj.SucCod = lCom.Val("1");

                //mTblDatos.Rows
                lTblFinal = lTblData;


                lNroDetalle = 0;
                //  for (i = 0; i < Dtg_Etiquetas.Rows.Count; i++)
                //  obtenemos el nro de etiquetas leidas
                //for (i = 0; i < lTblFinal.Rows.Count; i++)
                //{
                //    lPartes = lTblFinal.Rows[i]["IdEtiquetaAZA"].ToString().Split(new Char[] { '-' });
                //    lNroDetalle = lNroDetalle + lPartes.Length - 1;

                //}
                lNroDetalle = lTblData.Rows.Count;
                WsOperacion.Detalle_Recepcion_MP[] lDetalle = new WsOperacion.Detalle_Recepcion_MP[lNroDetalle];
                for (i = 0; i < lTblFinal.Rows.Count; i++)
                {

                    if (lTblFinal.Rows[i][0].ToString().Length > 0)
                    {

                        lEt = ProcesaColada_MAsiva((lTblFinal.Rows[i][0].ToString()));

                        lObjDet = new WsOperacion.Detalle_Recepcion_MP();
                        lObjDet.CodMaterial = lEt.Codigo;  //lTblFinal.Rows[i]["Codigo"].ToString().Trim();
                        lObjDet.IdEtiquetaAza = lEt.Id.ToString();  //lPartes[j].ToString();
                        lObjDet.IdRecepcionMP = 0;
                        lObjDet.Kgs = 0;
                        lObjDet.FechaEntrega_OC = "03/02/2020 ";

                        lDetalle[lCont] = lObjDet;
                        lCont = lCont + 1;
                    }

                    //lObj.Detalle =(Metalurgica.) lDetalle;


                }
                if (lCont > 0)
                {
                    lObj.Detalle = lDetalle;
                    lCont = 0;
                }

            }
            catch (Exception iex)
            {
                MessageBox.Show(string.Concat("Ha ocurrido el siguiente error: ", iex.Message.ToString()), "Avisos Sistema");

            }
            return lObj;

        }

        private void PersistirDatos()
        {
            // Se deben Peristir los datos.
            //SP_CRUD_Recepcion_MP
            WsOperacion.OperacionSoapClient lPx = new WsOperacion.OperacionSoapClient();
            WsOperacion.Recepcion_MP lObj = new WsOperacion.Recepcion_MP();

            if (ValidarDatosAntesDeGrabar() == true)
            {
                lObj = CargarObj();
                lObj = lPx.GrabarRecepcion_MP(lObj);
                MessageBox.Show("Los Datos  Se han Grabado Correctamente ");
                Btn_grabar.Enabled = false ;
            }
        }

        private Boolean ValidaDatos()
        {
            Boolean lRes = true ;string lTx = "";
            Clases.ClsComun lCom = new Clases.ClsComun();

            if (lCom.EsNumero(Tx_GuiaDesp.Text ) == false)
            {
                lTx = string.Concat(" Debe Indicar el Número de la Guía de Despacho -  ", Environment.NewLine);
                lRes = false;
            }
            if (lCom.EsNumero(Tx_OC.Text) == false)
            {
                lTx = string .Concat (  lTx, " Debe Indicar el Número de Orden de Compra - ", Environment.NewLine);
                lRes = false;
            }
            if (lCom.EsNumero(Tx_TotalKgsGD.Text) == false)
            {
               // lTx = " Debe Indicar el Número de la Guía de Despacho ";
                lTx = string.Concat( lTx  , " Debe Indicar el Total de Kilos de la Guía de Despacho - ", Environment.NewLine);
                lRes = false;
            }

            if  (Dtg_Etiquetas.Rows.Count ==1)
            {
                lTx = string.Concat(Environment.NewLine, lTx, " No existe detalle, revise la Orden de Compra ");
                lRes = false;
            }

            if (lTx.Trim().Length > 0)
                MessageBox.Show(lTx, "Avisos Sistema");

            return lRes;
        }

        private void Btn_InicioL_Click(object sender, EventArgs e)
        {
            if (ValidaDatos() == true)
            {
                Tx_EtiquetaAza.Enabled = false;
                Gr_datos.Enabled = false;
                Tx_EtiquetaAza.Enabled = true;
                Tx_EtiquetaAza.Focus();
            }
            
        }

        private void Btn_Nueva_Click(object sender, EventArgs e)
        {
            Tx_EtiquetaAza.Enabled = false ;
            Gr_datos.Enabled = true;
            Tx_GuiaDesp.Text = "";
            Tx_OC.Text = "";
            Tx_TotalKgsGD.Text = "";
            Btn_grabar.Enabled = true;
            mTblDatos.Clear();

            Tx_GuiaDesp.Focus();
        }

        private void Tx_GuiaDesp_Leave(object sender, EventArgs e)
        {
            Dtp_Fecha.Focus();
        }

        private void Dtp_Fecha_Leave(object sender, EventArgs e)
        {
            Cmb_Sucursal .Focus();
        }

        private void Tx_OC_Leave(object sender, EventArgs e)
        {
            Tx_TotalKgsGD.Focus();
        }

        private void Tx_TotalKgsGD_Leave(object sender, EventArgs e)
        {
            Btn_InicioL.Focus();
        }

        private void Tx_GuiaDesp_Validating(object sender, CancelEventArgs e)
        {
            if (!Tx_GuiaDesp.Text.Trim().Equals(""))
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    if (VerificaGuiaDespacho(Tx_GuiaDesp.Text ) == false)
                    {
                        MessageBox.Show(" El Número de Guía Ingresado ya se encuentra Registrado, No se puede continuar ");
                        Btn_Nueva_Click(null, null);
                      }
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Cursor.Current = Cursors.Default;
            }
        }

        private void Cmb_Sucursal_Leave(object sender, EventArgs e)
        {
            Tx_OC.Focus();
        }

        private void Tx_OC_TextChanged(object sender, EventArgs e)
        {

        }


        private WsOperacion.TipoEtiquetaAza   ProcesaColada_MAsiva(string iTx)
        {
            WsOperacion.TipoEtiquetaAza lEt = new WsOperacion.TipoEtiquetaAza();
            string lTmp = ""; Clases.ClsComun lCom = new Clases.ClsComun();
            WsOperacion.OperacionSoapClient lDal = new WsOperacion.OperacionSoapClient();
            DataTable lTblDatos = new DataTable();string lSucursal = "";

            lTmp = iTx.Replace("ñ", ";");
            lTmp = lTmp.Replace("Ñ", ":");
            lTmp = lTmp.Replace("'", "-");
            lTmp = lTmp.Replace(")", "(");
            lTmp = lTmp.Replace("=", ")");

            lEt = lCom.ObtenerEtiquetaAZA(lTmp, false);
            lSucursal = new Clases.ClsComun().OBtenerSucursal().ToString();
            lEt = lDal.PersistirEtiquetaAZA(lEt, lSucursal);

            return lEt;
        }


        private void Frm_DesdeArchivo_Click(object sender, EventArgs e)
        {
            string lPAth = @"C:\Roberto Becerra\TO\Requerimientos\2020\Produccion\Procesos de Corte y Doblado\Coladas para fabricación con despunte.txt";
            DataTable lTbDatos = new DataTable(); DataRow lFila = null;
            WsOperacion.TipoEtiquetaAza lEt = new WsOperacion.TipoEtiquetaAza();
            WsOperacion.Recepcion_MP lObj = new WsOperacion.Recepcion_MP();
            WsOperacion.OperacionSoapClient lPx = new WsOperacion.OperacionSoapClient();
            string line; 

            lTbDatos.Columns.Add("Etiqueta", Type.GetType("System.String"));

            // Read the file and display it line by line.  
            System.IO.StreamReader file =                 new System.IO.StreamReader(lPAth);
            while ((line = file.ReadLine()) != null)
            {
                if (line.ToString().Trim().Length > 10)
                {
                    lFila = lTbDatos.NewRow();
                    lFila["Etiqueta"] = line;
                    lTbDatos.Rows.Add(lFila);
                }
            }
            file.Close();

            lObj = CargarObj_Desde_Archivo(lTbDatos);

            lObj = lPx.GrabarRecepcion_MP(lObj);
            MessageBox.Show("Los Datos  Se han Grabado Correctamente ");
            Btn_grabar.Enabled = false;

        }

        private void Tx_EtiquetaAza_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
