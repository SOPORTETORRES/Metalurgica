using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            string[] lPartes = null;DataView lVista = null;int lKgsSol = 0;

            for (i = 0; i < mTblDatos.Rows.Count; i++)
            {
                lMaterial = mTblDatos.Rows[i]["Material"].ToString().Trim();
                lKgsSol = lCom .Val (mTblDatos.Rows[i]["Material"].ToString());
                lVista = new DataView(mTBlMP, string.Concat(" Codigo='", lMaterial, "'"), "", DataViewRowState.CurrentRows);
                lPar = mTblDatos.Rows[i]["IdEtiquetaAZA"].ToString();
                //if (lPar.IndexOf(iEtiqueta.Id.ToString()) < 0)
                //{

                //}
                //else
                if ((lVista .Count >0)  && (  (lPar.IndexOf(iEtiqueta.Id.ToString()) <0)))      //(lMaterial.Length > 4)
                {
                
                    if ((lCom .Val (lVista[0]["NombreMedidas"].ToString ()) == (lCom.Val(iEtiqueta.Diam.ToString())) && (lCom.Val(lVista[0]["Largo"].ToString())) == (lCom.Val(iEtiqueta.Largo.ToString()))))

                     {
                        lKgsRecep = lCom.Val(mTblDatos.Rows[i]["KgsRecepcionados"].ToString());
                        if (lKgsRecep >0)
                         lKgsRecep = lKgsRecep + lCom.Val(iEtiqueta.PesoBulto.ToString());
                        else
                            lKgsRecep =  lCom.Val(iEtiqueta.PesoBulto.ToString());


                        lKgsSol = lCom .Val ( mTblDatos.Rows[i]["Cantidad"].ToString ());

                        mTblDatos.Rows[i]["KgsXRecepcionar"] = (lKgsSol - lKgsRecep).ToString ();
                        mTblDatos.Rows[i]["KgsRecepcionados"] = lKgsRecep.ToString ();
                        //    Cantidad
                        mTblDatos.Rows[i]["IdEtiquetaAza"] = string.Concat(mTblDatos.Rows[i]["IdEtiquetaAza"].ToString(), iEtiqueta.Id, "-");
                    }
                }
            }
            RefescaGrilla();
        }


        private void RefescaGrilla()
        {
            int i = 0; int lTotalKgsOC = 0; int lTotalRecep = 0; Clases.ClsComun lCom = new Clases.ClsComun();
            DataRow lFila = null;DataView lVista = null;

            try
            {
                for (   i = 0; i < mTblDatos.Rows.Count-2; i++)
                {
                    lTotalKgsOC = lTotalKgsOC + lCom.Val(mTblDatos.Rows[i]["Cantidad"].ToString());
                    lTotalRecep = lTotalRecep + lCom.Val(mTblDatos.Rows[i]["KgsRecepcionados"].ToString());
                    if (lTotalRecep < 0)
                        lTotalRecep = 0;
                }
                lVista = new DataView(mTblDatos, "Descripcion='TOTALES'", "", DataViewRowState.CurrentRows);
                if (lVista .Count ==0)
                {
                    lFila = mTblDatos.NewRow();
                    lFila["Cantidad"] = lTotalKgsOC;
                    lFila["KgsRecepcionados"] = lTotalRecep;
                    lFila["Descripcion"] = "TOTALES";
                    mTblDatos.Rows.Add(lFila);
                }
                else
                {
                    lVista[0]["Cantidad"] = lTotalKgsOC;
                    lVista[0]["KgsRecepcionados"] = lTotalRecep;
                }

                //Dtg_Etiquetas.Rows[6].Cells["Descripcion"].Value = "TOTALES";
                //Dtg_Etiquetas.Rows[6].Cells["Cantidad"].Value = lTotalKgsOC.ToString();
                //Dtg_Etiquetas.Rows[6].Cells["KgsRecepcionados"].Value = lTotalRecep.ToString();

         
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
            DataTable lTblDatos = new DataTable();

            if (iTx.IndexOf("ñ") > -1)  //es etiqueta de AZA ya que el ; es el separador de Caracteres
            {
                lTmp = iTx.Replace("ñ", ";");
                lTmp = lTmp.Replace("Ñ", ":");
                lTmp = lTmp.Replace("'", "-");
                lTmp = lTmp.Replace(")", "(");
                lTmp = lTmp.Replace("=", ")");

                lEt = lCom.ObtenerEtiquetaAZA(lTmp);
                lEt = lDal.PersistirEtiquetaAZA(lEt);
                if (Dtg_Etiquetas.Rows.Count > 0)
                {
                    RevisaEnOC(lEt);
                   // debemos crear tabla que almacene IdEtiquetaAza   -  OC 

                }
               
            }
            else
            {

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

            lDts = lPx.Obtener_MP( );
            if ((lDts.MensajeError.Trim().Length == 0) && (lDts.DataSet.Tables.Count > 0))
            {
                mTBlMP  = lDts.DataSet.Tables[0].Copy();
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
                    CargaDatosOC(Tx_OC.Text);
                    RefescaGrilla();
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Cursor.Current = Cursors.Default;
            }
        }

        private void VerificaGuiaDespacho(string iNroGuia)
        {
            WsOperacion.OperacionSoapClient lPx = new WsOperacion.OperacionSoapClient();
            WsOperacion.ListaDataSet lDts = new WsOperacion.ListaDataSet(); DataTable lTbl = new DataTable();
            int i = 0;   Clases.ClsComun lCom = new Clases.ClsComun();

            //lDts = lPx.ObtenerDetalle_OC_Aza(iOc);
            //if ((lDts.MensajeError.Trim().Length == 0) && (lDts.DataSet.Tables.Count > 0))
            //{
            //    lTbl = lDts.DataSet.Tables[0].Copy();
            //    //lTbl.Columns.Add("KgsRecepcionados", Type.GetType("System.String"));
            //    lTbl.Columns.Add("KgsXRecepcionar", Type.GetType("System.String"));
            //    lTbl.Columns.Add("IdEtiquetaAZA", Type.GetType("System.String"));
            //    mTblDatos = lTbl.Copy();

               

            //   }
        }


        private void CargaDatosOC(string  iOc)
        {
            WsOperacion.OperacionSoapClient lPx = new WsOperacion.OperacionSoapClient();
            WsOperacion.ListaDataSet lDts = new WsOperacion.ListaDataSet();DataTable lTbl = new DataTable();
            int i = 0; int lSaldo = 0; Clases.ClsComun lCom = new Clases.ClsComun();

            lDts = lPx.ObtenerDetalle_OC_Aza(iOc);
            if ((lDts.MensajeError.Trim().Length == 0) && (lDts .DataSet .Tables .Count >0))
            {
                lTbl = lDts.DataSet.Tables[0].Copy();
                //lTbl.Columns.Add("KgsRecepcionados", Type.GetType("System.String"));
                lTbl.Columns.Add("KgsXRecepcionar", Type.GetType("System.String"));
                lTbl.Columns.Add("IdEtiquetaAZA", Type.GetType("System.String"));
                mTblDatos = lTbl.Copy();

                for (i = 0; i < mTblDatos.Rows.Count; i++)
                {
                    lSaldo = lCom.Val(mTblDatos.Rows[i]["cantidad"].ToString()) - lCom.Val(mTblDatos.Rows[i]["KgsRecepcionados"].ToString());
                    mTblDatos.Rows[i]["KgsXRecepcionar"] = lSaldo.ToString ();
                }

                Dtg_Etiquetas.DataSource = mTblDatos;
                Dtg_Etiquetas.Columns["UnidadMedida"].Visible = false;
                Dtg_Etiquetas.Columns["Precio"].Visible = false;
                Dtg_Etiquetas.Columns["Monto"].Visible = false;
                Dtg_Etiquetas.Columns["IdEtiquetaAza"].Visible = false;

                Dtg_Etiquetas.Columns["Material"].Width = 200;
                Dtg_Etiquetas.Columns["Descripcion"].Width = 400;
                Dtg_Etiquetas.Columns["Cantidad"].Width = 100;
                Dtg_Etiquetas.Columns["FechaEstimadaEntrega"].Width = 200;
                Dtg_Etiquetas.Columns["KgsRecepcionados"].Width = 150;
                Dtg_Etiquetas.Columns["KgsXRecepcionar"].Width = 150;


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
                lTotalIng = lCom.Val(lVista[0]["KgsRecepcionados"].ToString());
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
                        lObjDet.CodMaterial = lTblFinal.Rows[i] ["Material"]. ToString().Trim();
                        lObjDet.IdEtiquetaAza =  lPartes[j].ToString();
                        lObjDet.IdRecepcionMP = 0;
                        lObjDet.Kgs = lCom.Val(lTblFinal.Rows[i]["Cantidad"]. ToString().Trim());
                        lObjDet.FechaEntrega_OC  = lTblFinal.Rows[i]["FechaEstimadaEntrega"]. ToString();

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
            Tx_OC.Focus();
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
                    CargaDatosOC(Tx_GuiaDesp.Text);
                    //RefescaGrilla();
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Cursor.Current = Cursors.Default;
            }
        }
    }
}
