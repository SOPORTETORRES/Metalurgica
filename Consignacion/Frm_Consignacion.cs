using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Metalurgica.Consignacion
{
    public partial class Frm_Consignacion : Form
    {
        private DataTable mTblDatos = new DataTable();
        private CurrentUser mUserLog = new CurrentUser();
        private int mIdSeleccionado = 0;
        private bool mCargaResumen = true;
        private int mNroCbLeidos = 0;
        public Frm_Consignacion()
        {
            InitializeComponent();
        }

        private void FormateaGrilla()
        {
            if (Dtg_MP.DataSource  != null)
            {
                Dtg_MP.Columns["Pos"].Visible = false;
                Dtg_MP.Columns["Pos1"].Visible = false;
                Dtg_MP.Columns["Ce"].Visible = false;
                Dtg_MP.Columns["UMB"].Visible = false;
                Dtg_MP.Columns["Usuario"].Visible = false;
                Dtg_MP.Columns["Alm"].Visible = false;
                Dtg_MP.Columns["IdArchivo"].Visible = false;
                //Dtg_MP.Columns["Estado"].Visible = false;
                Dtg_MP.Columns["UM"].Visible = false;
                Dtg_MP.Columns["UnidadAlmacen"].Visible = false;
                Dtg_MP.Columns["StockDisponible1"].Visible = false;

                Dtg_MP.Columns["Id"].Width = 50;
                Dtg_MP.Columns["Transporte"].Width = 70;
                Dtg_MP.Columns["Entrega"].Width = 70;
                Dtg_MP.Columns["Material"].Width = 70;
                Dtg_MP.Columns["lote"].Width = 70;
                Dtg_MP.Columns["fecha"].Width = 70;
                Dtg_MP.Columns["Hora"].Width = 50;

                Dtg_MP.Columns["TextoMaterial"].Width = 230;
                Dtg_MP.Columns["Codbarras"].Width = 300;

            }
        }


        public  void CargaDatos(CurrentUser iUseLog)
        {
            mUserLog = iUseLog;
            string lSql = ""; DataSet lDts = new DataSet(); Px_WS.Ws_ToSoapClient lPx = new Px_WS.Ws_ToSoapClient();

            if (Rb_Pistoleo1.Checked == true)
                lSql = String.Concat("Exec SP_CRUD_ConsignacionGerdau 0,'','','','','','','','','','','','','','','','','','','','','','',4,0");
            else
                lSql = String.Concat("Exec SP_CRUD_ConsignacionGerdau 0,'','','','','','','','','','','','','','','','','','','','','','',6,0");
            
            
            
            lDts = lPx.ObtenerDatos(lSql);
            Dtg_MP.DataSource = null;
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                mTblDatos = lDts.Tables[0].Copy();
                Dtg_MP.DataSource = mTblDatos;
                
            }        
        }


        public void CargaTodosLosDatos(CurrentUser iUseLog)
        {
            mUserLog = iUseLog;
            string lSql = ""; DataSet lDts = new DataSet(); Px_WS.Ws_ToSoapClient lPx = new Px_WS.Ws_ToSoapClient();

            
                lSql = String.Concat("Exec SP_CRUD_ConsignacionGerdau 0,'','','','','','','','','','','','','','','','','','','','','','',8,0");



            lDts = lPx.ObtenerDatos(lSql);
            Dtg_MP.DataSource = null;
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                mTblDatos = lDts.Tables[0].Copy();
                Dtg_MP.DataSource = mTblDatos;

            }

        }

        private void Btn_CargaDatos_Click(object sender, EventArgs e)
        {
             string lSql = ""; DataSet lDts = new DataSet(); Px_WS.Ws_ToSoapClient lPx = new Px_WS.Ws_ToSoapClient();
            

            if (Tx_GuiaDespacho .Text .Trim().Length >0)
            {
                lSql = String.Concat("Exec SP_CRUD_ConsignacionGerdau 0,'", Tx_GuiaDespacho .Text, "','',''");
                lSql = String.Concat(lSql, ",'','','','','','','','','','','','','','','','','','',2,0");
                lDts = lPx.ObtenerDatos(lSql);
                if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                {
                    Dtg_MP.DataSource = lDts.Tables[0].Copy();
                    FormateaGrilla();
                }


            }
        }

        private void Frm_Consignacion_Load(object sender, EventArgs e)
        {
            //CargaDatos();
            FormateaGrilla();
        }

        private void Tx_CB_Validating(object sender, CancelEventArgs e)
        {
            Clases.ClsComun lCom = new Clases.ClsComun(); int mSaldo = 0;

            if (Rb_Pistoleo1.Checked == true)
            {
                if (Tx_GuiaDespacho.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Debe Ingresar el Número de Guía de Despacho, Revisar", "Validaciones Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Tx_GuiaDespacho.Focus();
                }
                else
                {
                    if (Tx_CB.Text.Trim().Length > 0)
                    {
                        if (LeeCodigoBarras(Tx_CB.Text) == true)
                        {
                            mNroCbLeidos = mNroCbLeidos + 1;
                            mSaldo = lCom.Val(Tx_NroPaq.Text) - mNroCbLeidos;
                        }                        
                        Lbl_Msg.Text = string.Concat(" Lea los codigos de barra, Pendientes por leer ", mSaldo);
                        Tx_CB.Text = "";
                        Tx_CB.Focus();
                    }
                }
            }
            else
            {
                LeeCodigoBarras(Tx_CB.Text);
                Tx_CB.Text = "";
                Tx_CB.Focus();
            }

        }



        private int GrabaDatosColadas(DataGridViewRow iFila)
        { 
            //Insertamos en la tabla coladas
            Px_WS.TipoColada lColada = new Px_WS.TipoColada(); Px_WS.Ws_ToSoapClient lDal = new Px_WS.Ws_ToSoapClient();
            DataSet lDatos = new DataSet(); string lNroColada = ""; string lIdPaqueteColada = "";
            string lSql = ""; int i = 0;
            char[] delimiterChars = { ' ', '\t' }; string[] lPartes= iFila.Cells ["TextoMaterial"].Value .ToString ().Split(delimiterChars);

            for (i = 0; i < lPartes.Length; i++)
            {
                //B HORMIGON 28mm 8m A630-420H (N) 
                if (lPartes[i].IndexOf("mm") > -1)
                {
                    lNroColada = iFila.Cells["CodBarras"].Value.ToString().Substring(29, 10);
                    lColada.Diametro = int.Parse (lPartes[i].Substring(0, lPartes[i].Length - 2));
                    lColada.Largo  = (lPartes[i+1].Substring(0, lPartes[i+1].Length - 1));
                    lColada.NroCertificado ="";
                    lColada.NroColada = lNroColada;
                    lColada.Procedencia = "Gerdau Aza";
                    lColada.NroGuiaDespacho = iFila.Cells["NroGuiaDespacho"].Value.ToString();
                    lColada.Id = 0;
                    lColada.Kilos = int.Parse(iFila.Cells["StockDisponible"].Value.ToString());

                    lSql = String.Concat(" exec SP_CRUD_COLADA ", lColada.Id, ",", lColada.Diametro, ",'", lColada.NroColada, "','");
                    lSql = String.Concat(lSql, lColada.NroCertificado, "','", lColada.Procedencia, "','", lColada.NroGuiaDespacho, "',");
                    lSql = String.Concat(lSql, mUserLog .Iduser ,",'", lColada.Largo, "',0,1");
                    lDatos = lDal.ObtenerDatos(lSql);
                    if ((lDatos.Tables.Count > 0) && (lDatos.Tables[0].Rows.Count > 0))
                    {
                        lColada.Id = int.Parse (lDatos.Tables[0].Rows[0][0].ToString ());
                        i = lPartes.Length;
                        //Insertamos en la tabla PaquetesColada

                        lSql = String.Concat("exec SP_CRUD_PAQUETES_COLADA 0,", lColada.Id, ",");
                       lSql = String.Concat(lSql, "1,1", ",", lColada.Kilos, ",0,1,1000,'B',72,",lColada.Largo,",1");
                        lDatos = lDal.ObtenerDatos(lSql);                            
                       if (( lDatos.Tables.Count > 0) && (lDatos.Tables[0].Rows.Count > 0))
                        {
                            lIdPaqueteColada = lDatos.Tables[0].Rows[0][0].ToString();
                        }

                       WsOperacion.Recepcion_Colada lRc = new WsOperacion.Recepcion_Colada();
                       WsOperacion.OperacionSoapClient lOp = new WsOperacion.OperacionSoapClient();
                       lRc.Id = 0;
                       lRc.Colada = lColada.Id.ToString ();
                       lRc.Camion = "NNNN";
                       lRc.Etiqueta_colada = "000000";
                       lRc.Usuario = "";
                       lRc.Fecha = DateTime .Now ;
                       lRc.Estado = "";
                       lRc = lOp.GuardarRecepcion_Colada(lRc, Program.currentUser.ComputerName);

                       //if (lRc.MensajeError.Equals(""))
                       //{
                       //    MessageBox.Show("Registro guardado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                       //}
                       //else
                       //    MessageBox.Show(lRc.MensajeError.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);



                       break;
                    }                        
                }            
            }
            return lColada.Id;
        }

        private bool  LeeCodigoBarras(string iCB)
        {
            string lSql = ""; DataSet lDts = new DataSet(); Px_WS.Ws_ToSoapClient lPx = new Px_WS.Ws_ToSoapClient();
            int i = 0; int j = 0; int lId = 0; int lIdColada = 0;
            bool lRes = false;

            for (i = 0; i < Dtg_MP.Rows.Count; i++)
            {
                if (Dtg_MP.Rows[i].Cells["CodBarras"].Value.ToString().Trim ().Equals(iCB.Trim()))
                {
                    lId=int.Parse ((Dtg_MP.Rows[i].Cells["Id"].Value.ToString()));

                    //Insertamos en la tabla coladas
                    //Insertamos en la tabla PaquetesColada
                    //Insertamos en la tabla recepcion_colada                    
                    lIdColada=GrabaDatosColadas((Dtg_MP.Rows[i]));

                    lSql = String.Concat("Exec SP_CRUD_ConsignacionGerdau ", lId, ",'','',''");

                    if (Rb_Pistoleo1.Checked ==true)
                        lSql = String.Concat(lSql, ",'','','','','','','','','','','','','','','", iCB, "','','CON','", mUserLog.Iduser, "','", Tx_GuiaDespacho.Text, "',5,",lIdColada);
                    else
                        lSql = String.Concat(lSql, ",'','','','','','','','','','','','','','','", iCB, "','','EPR','", mUserLog.Iduser, "','", Tx_GuiaDespacho.Text, "',7,", lIdColada);

                                      
                    lDts = lPx.ObtenerDatos(lSql);
                    if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                    {
                        for (j = 0; j < Dtg_MP.Columns.Count; j++)
                        {
                            //Debe cambiar  de estado de NUll a Recibido en TO.
                            Dtg_MP.Rows[i].Cells[j].Style.BackColor = Color.LightGreen;
                        }
                        lRes = true;
                    }      
              


                }                                    
            }

            return lRes;
        }

        private void Tx_CB_TextChanged(object sender, EventArgs e)
        {

        }

        private void Tx_GuiaDespacho_Validating(object sender, CancelEventArgs e)
        {
            if (Tx_GuiaDespacho.Text.Trim().Length > 0)
            {
                Tx_CB.Focus();
            }
            else
            {
                Tx_GuiaDespacho.Focus();
            }
        }

        private void Btn_IniciaProceso_Click(object sender, EventArgs e)
        {
            gr_GuiaDespacho.Enabled = true;

            Lbl_Msg.Text = "Para continuar,  debe Ingresar la Guía de Despacho ";
            Tx_GuiaDespacho.Focus();

        }


        private void Btn_OK_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro que el Dato ingresado el Correcto?", "Validaciones Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                gr_GuiaDespacho.Enabled = false;
                gr_NroPaquetes.Enabled = true;
                Tx_NroPaq.Focus();
            }
            else
            {
                Tx_GuiaDespacho.Focus();
            }
        }

        private void Btn_OK1_Click(object sender, EventArgs e)
        {
            Clases.ClsComun lCom = new Clases.ClsComun(); int mSaldo = 0;

            if (lCom.Val(Tx_NroPaq.Text) > 0)
            {
                if (MessageBox.Show("¿Esta seguro que el Dato ingresado el Correcto?", "Validaciones Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    mSaldo = lCom.Val(Tx_NroPaq.Text) - mNroCbLeidos;
                    Lbl_Msg.Text = string.Concat(" Lea los codigos de barra, Pendientes por leer ", mSaldo);
                    gr_NroPaquetes.Enabled = false;
                    gr_CB.Enabled = true;
                    Tx_CB.Focus();
                }
                else
                {
                    Tx_NroPaq.Focus();
                }
            }
            else
            {
                MessageBox.Show("El Dato ingresado NO es Correcto, Debe ingresar un valor numérico, Revisar", "Validaciones Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Tx_NroPaq.Focus();
            }
        }

        private void Rb_Pistoleo1_CheckedChanged(object sender, EventArgs e)
        {
            if (Rb_Pistoleo1.Checked == true)
            {
                gr_GuiaDespacho.Enabled = false;
                gr_NroPaquetes .Enabled = false;
                gr_CB.Enabled = false;
                CargaDatos(mUserLog);
                FormateaGrilla();
            }

        }

        private void Rb_Pistoleo2_CheckedChanged(object sender, EventArgs e)
        {
            if (Rb_Pistoleo2.Checked == true)
            {
                gr_GuiaDespacho.Enabled = false;
                gr_NroPaquetes.Enabled = false;
                gr_CB.Enabled = true ;
                CargaDatos(mUserLog);
                FormateaGrilla();
            }
        }

        private void Rb_Todos_CheckedChanged(object sender, EventArgs e)
        {
            CargaTodosLosDatos(mUserLog);
            FormateaGrilla();
        }

        private void Dtg_MP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string lFila = "";

            
            //lFila = string.Concat("Fila: ", e.RowIndex, " - Columna: ", e.ColumnIndex);

            //MessageBox.Show(lFila);

        }

        private void Dtg_MP_MouseDown(object sender, MouseEventArgs e)
        {
            int lIndex = 0; 
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                DataGridView.HitTestInfo Mi_Test = Dtg_MP.HitTest(e.X, e.Y);
                if (Mi_Test.Type == DataGridViewHitTestType.Cell)
                {
                    if (Mi_Test.RowIndex > -1)
                    {
                        lIndex = Mi_Test.RowIndex;
                        Dtg_MP.CurrentCell = Dtg_MP.Rows[Mi_Test.RowIndex].Cells[Mi_Test.ColumnIndex];
                        Dtg_MP.Rows[Mi_Test.RowIndex].Selected = true ;
                        mIdSeleccionado = int.Parse (Dtg_MP.Rows[Mi_Test.RowIndex].Cells["Id"].Value .ToString ());
                        Dtg_MP.ContextMenuStrip = mn_Trazabilidad;
                    }                       
                 }

            }

        }

        private void mn_Trazabilidad_Click(object sender, EventArgs e)
        {
            Frm_Detalle lFrm = new Frm_Detalle();
            lFrm.CargaTrazabilidad(mIdSeleccionado.ToString ());
            lFrm.ShowDialog();
        }

        private void Rb_ColadasPiezas_CheckedChanged(object sender, EventArgs e)
        {
            if (Rb_ColadasPiezas.Checked == true)
            {
                string lSql = ""; DataSet lDts = new DataSet(); Px_WS.Ws_ToSoapClient lPx = new Px_WS.Ws_ToSoapClient();
                lSql = String.Concat("Exec SP_CRUD_ConsignacionGerdau 0,'','',''");
                lSql = String.Concat(lSql, ",'','','','','','','','','','','','','','','','','CON','','',10,0");
                    lDts = lPx.ObtenerDatos(lSql);
                    if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                    {
                        Dtg_MP.DataSource = lDts.Tables[0].Copy();
                    }

            }
        }

        private void Btn_Finaliza_Click(object sender, EventArgs e)
        {

            if (mNroCbLeidos > 0)
            { 
                if (MessageBox.Show(string.Concat ("¿Esta seguro que desea finalizar el proceso, aun cuando hay ", mNroCbLeidos ," códigos pendientes de  leer ?"), "Validaciones Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Close();
                }            
            }
        }

       


    }
}
