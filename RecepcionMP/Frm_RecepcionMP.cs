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
        public Frm_RecepcionMP()
        {
            InitializeComponent();
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
            string[] lPartes = null;
            for (i=0; i<mTblDatos.Rows .Count;i++ )
            {
                lMaterial = mTblDatos.Rows[i]["Material"].ToString().Trim ();
                if (lMaterial.Length > 4)
                {
                    lPar = lMaterial.Substring(4, lMaterial.Length-4);
                    lPartes = lPar.Split(new Char[] { 'X' });
                    if ((lCom .Val(lPartes[0].ToString()))==(lCom .Val (iEtiqueta.Diam.ToString())) && (lCom.Val(lPartes[1].ToString())) == (lCom.Val(iEtiqueta.Largo .ToString())))
                        //&& (lPartes[1].ToString().Equals(iEtiqueta.Largo.ToString())))
                     {
                        lKgsRecep = lKgsRecep + lCom.Val (iEtiqueta.PesoBulto.ToString());
                        mTblDatos.Rows[i]["KgsRecepcionados"] = lKgsRecep.ToString ();       
                    }
                }
                //lTotalKgsOC = lTotalKgsOC + lCom.Val(mTblDatos.Rows[i]["KgsRecepcionados"].ToString());
            }
            RefescaGrilla();
        }

        private void RefescaGrilla()
        {
            int i = 0; int lTotalKgsOC = 0; int lTotalRecep = 0; Clases.ClsComun lCom = new Clases.ClsComun();
            DataRow lFila = null;
            for (i = 0; i < mTblDatos.Rows.Count; i++)
            {
                lTotalKgsOC = lTotalKgsOC + lCom.Val(mTblDatos.Rows[i]["Cantidad"].ToString());
                lTotalRecep = lTotalRecep + lCom.Val(mTblDatos.Rows[i]["KgsRecepcionados"].ToString());
                if (lTotalRecep < 0)
                    lTotalRecep = 0;
            }
            Dtg_Etiquetas.Rows [6].Cells ["Descripcion"].Value  = "TOTALES";
            Dtg_Etiquetas.Rows[6].Cells["Cantidad"].Value = lTotalKgsOC.ToString();
            Dtg_Etiquetas.Rows[6].Cells["KgsRecepcionados"].Value = lTotalRecep.ToString();

            //lFila = mTblDatos.NewRow();
            //lFila["Cantidad"] = lTotalKgsOC;
            //lFila["KgsRecepcionados"] = lTotalRecep;
            //lFila["Descripcion"] = "TOTALES";
            //mTblDatos.Rows.Add(lFila);

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


        private void CargaDatosOC(string  iOc)
        {
            WsOperacion.OperacionSoapClient lPx = new WsOperacion.OperacionSoapClient();
            WsOperacion.ListaDataSet lDts = new WsOperacion.ListaDataSet();DataTable lTbl = new DataTable();

            lDts = lPx.ObtenerDetalle_OC_Aza(iOc);
            if ((lDts.MensajeError.Trim().Length == 0) && (lDts .DataSet .Tables .Count >0))
            {
                lTbl = lDts.DataSet.Tables[0].Copy();
                lTbl.Columns.Add("KgsRecepcionados", Type.GetType("System.String"));
                mTblDatos = lTbl.Copy();
                Dtg_Etiquetas.DataSource = mTblDatos;

            }

        }


    }
}
