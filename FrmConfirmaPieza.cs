using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Metalurgica
{
    public partial class FrmConfirmaPieza : Form
    {
        private int mNroPiezas = 0;
        private DataTable mTblDatos = new DataTable();
        public string mPiezaProducida = "";
        int mPieza = 0;
        string mDiametro = "";
        private CurrentUser mUser = new CurrentUser();
        string mColada = "";

        public FrmConfirmaPieza()
        {
            InitializeComponent();
        }

        private void FrmConfirmaPieza_Load(object sender, EventArgs e)
        {
            //Btn_Grabar.Focus();

            Tx_Colada.Focus();
        }


        private string YaFueProducida(string iDetallePieza, string IdColadaPaquete)
        {
            string lRes = ""; int i = 0; DataTable lTbl = new DataTable(); DataSet lDts = new DataSet();

            Ws_TO.Ws_ToSoapClient ldal = new Ws_TO.Ws_ToSoapClient();
            WsOperacion.ListaDataSet listaDataSet = new WsOperacion.ListaDataSet();
            string lSql = "";
            try
            {
                listaDataSet.MensajeError = "";
                lRes = string.Concat ("La Pieza ya esta producida  ",Environment.NewLine );
                lSql = string.Concat(" exec SP_CRUD_COLADASPAQUETE 0,0,", IdColadaPaquete, ",");
                lSql = string.Concat(lSql, iDetallePieza, ",0,0,2");
                lDts = ldal.ObtenerDatos(lSql).Copy();
                if (lDts.Tables.Count > 0)
                {
                    lTbl =lDts.Tables[0];
                    for (i = 0; i < lTbl.Rows.Count; i++)
                    {
                        lRes = string.Concat(lRes, lTbl.Rows[i][""].ToString (),Environment .NewLine );

                    }
                }                
            }
            catch (Exception exc)
            {
                lRes = exc.Message.ToString();
            }
            return lRes;
        }


     internal void IniciaForm(int  iPieza,int iNroPiezas, CurrentUser iUser,string iColada, string iDiam)
        {
            mPieza = iPieza;
            Tx_IdDetallePaquete.Text = mPieza.ToString ();
            mUser = iUser;
            mNroPiezas = iNroPiezas;
            mDiametro = iDiam;
            Tx_DiamPieza.Text = mDiametro;
            mColada = iColada;
            Lbl_Msg.Text = string.Concat ("El Paquete tiene ", iNroPiezas ," piezas para ser producidas ");
            Tx_NroPiezas.Text = iNroPiezas.ToString ();
            Tx_NroPiezas.ReadOnly = true;
            //Btn_Grabar.Focus();
            Tx_Colada.Focus();

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
     private void RegistraPiezaProducida(string iColada, string iPieza, int iNroPiezas, CurrentUser iUser, int iNroPiezasProd)
     {
         WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
         Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient();
         WsOperacion.Pieza pieza = new WsOperacion.Pieza(); DataSet lDts = new DataSet();
         Clases.ClsComun lCom = new Clases.ClsComun();
         string lSql = "";

         pieza.Colada = iColada;
         pieza.Etiqueta = iPieza;
         //row.Cells[COLUMNNAME_ETIQUETA_PIEZA].Value.ToString();
         pieza.Estado = "O40";
         //pieza = wsOperacion.RegistrarPasoaProduccionPieza(pieza, Program.currentUser.Machine, Program.currentUser.Login, Program.currentUser.ComputerName, iNroPiezasProd,int.Parse (Program.currentUser.Iduser ));
         pieza = wsOperacion.RegistrarPasoaProduccionPieza(pieza, Program.currentUser.IdMaquina , Program.currentUser.Login, Program.currentUser.ComputerName, iNroPiezasProd, int.Parse(Program.currentUser.Iduser));
         if (pieza.MensajeError.Equals(""))
         {
             //grabados el detalle
             lSql = string.Concat(" exec SP_CRUD_PaquetesProducidos 0,", iPieza, ",", iUser.IdMaquina, ",");
             lSql = string.Concat(lSql, iUser.Iduser, ",0,", iNroPiezas, ",", lCom.Val (mColada), ",", iNroPiezasProd);
             lSql = string.Concat(lSql, ",1");   	
             lDts = lPx.ObtenerDatos(lSql);
             //---------------------------
             //02-07-2014 Por medificaciones funcionales se puede vincular  a un paquete muchas coladas            
             string lIdPaqueteColada = ""; int i = 0;
             for (i = 0; i < this.Dtg_ColadasIngresadas.RowCount; i++)
             {

                 if (Dtg_ColadasIngresadas.Rows[i].Cells["Id1"].Value !=null )
                 {
                     lIdPaqueteColada = Dtg_ColadasIngresadas.Rows[i].Cells["Id1"].Value.ToString();
                     lSql = string.Concat(" exec SP_CRUD_COLADASPAQUETE 0,", iPieza, ",", Tx_IdDetallePaquete.Text, ",");
                     lSql = string.Concat(lSql, lIdPaqueteColada, ",", iUser.Iduser, ",", iUser.IdMaquina, ",1");            
                     lDts = lPx.ObtenerDatos(lSql);
                 }             
             }            

             this.lbl_Res .Text = " La Etiqueta " + iPieza + " fue grabada Correctamente ";
             this.Close();
         }
         else
         {
             this.lbl_Res.Text = " La Etiqueta " + iPieza + " ha registrado un error, repita la operación ";
             MessageBox.Show(pieza.MensajeError.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }

     }
     private void Btn_Grabar_Click(object sender, EventArgs e)
     {

         //actualizamos los datos en el servidor
         if (Dtg_ColadasIngresadas.RowCount == 0)
         {
             MessageBox.Show("Debe Ingresar una Colada, Revisar ", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
         else

         {
             mPiezaProducida = "S";
             RegistraPiezaProducida(mColada, mPieza.ToString(), mNroPiezas, mUser, int.Parse(Tx_NroPiezas.Text));         
         }
         
     }

     private void Btn_Cancelar_Click(object sender, EventArgs e)
     {
         mPiezaProducida = "N";
         this.Close();
     }

     private void formateaGrilla()
     {
         Dtg_ColadasIngresadas.Columns["ID"].Visible = false;
         Dtg_ColadasIngresadas.Columns["CAMION"].Visible = false;
         Dtg_ColadasIngresadas.Columns["USUARIO"].Visible = false;
         Dtg_ColadasIngresadas.Columns["REC_ESTADO"].Visible = false;
         Dtg_ColadasIngresadas.Columns["IdColada"].Visible = false;
         Dtg_ColadasIngresadas.Columns["IdColada1"].Visible = false;

         Dtg_ColadasIngresadas.Columns["NroPaquete"].Visible = false;
         Dtg_ColadasIngresadas.Columns["TotalPaquetes"].Visible = false;
         Dtg_ColadasIngresadas.Columns["KilosPaquete"].Visible = false;
         Dtg_ColadasIngresadas.Columns["FechaRegistro"].Visible = false;
         Dtg_ColadasIngresadas.Columns["UserRegistro"].Visible = false;
         Dtg_ColadasIngresadas.Columns["FechaImpresion"].Visible = false;
         Dtg_ColadasIngresadas.Columns["NroBarras"].Visible = false;

         Dtg_ColadasIngresadas.Columns["TipoProducto"].Visible = false;
         Dtg_ColadasIngresadas.Columns["IdProducto"].Visible = false;
         Dtg_ColadasIngresadas.Columns["Estado1"].Visible = false;
         Dtg_ColadasIngresadas.Columns["Largo"].Visible = false;
         Dtg_ColadasIngresadas.Columns["Id2"].Visible = false;
         Dtg_ColadasIngresadas.Columns["Largo1"].Visible = false;
         Dtg_ColadasIngresadas.Columns["KilosCalculados"].Visible = false;

         Dtg_ColadasIngresadas.Columns["IdMateriaPrima"].Visible = false;
         Dtg_ColadasIngresadas.Columns["EnProduccion"].Visible = false;
         Dtg_ColadasIngresadas.Columns["Kilos"].Visible = false;
         Dtg_ColadasIngresadas.Columns["UsuarioCrea"].Visible = false;
         //Dtg_ColadasIngresadas.Columns["Id2"].Visible = false;
         //Dtg_ColadasIngresadas.Columns["Largo1"].Visible = false;

         Dtg_ColadasIngresadas.RowHeadersVisible = false;
         Dtg_ColadasIngresadas.ReadOnly = true;
     }

     private void Tx_Colada_Validating(object sender, CancelEventArgs e)
     {
         DataTable dt = new DataTable(); string lMsg = ""; DataView lvista = null;
         if (!Tx_Colada.Text.Trim().Equals(""))
         {
             Cursor.Current = Cursors.WaitCursor;
             try
             {
               
                 WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
                 WsOperacion.ListaDataSet listaDataSet = new WsOperacion.ListaDataSet();

                 listaDataSet = wsOperacion.ObtenerRecepcionxEtiqueta_Colada(Tx_Colada.Text);
                 if (listaDataSet.MensajeError.Equals(""))
                 {                      
                     if (listaDataSet.DataSet.Tables[0].Rows.Count > 0)
                     {
                         dt = listaDataSet.DataSet.Tables[0];
                         if (dt.Rows[0]["Diametro"].ToString().Equals(Tx_DiamPieza.Text)  )
                             {
                             if (mTblDatos .Rows .Count >0)
                                 {
                                     lvista = new DataView(mTblDatos, "Id1=" + Tx_Colada.Text, "", DataViewRowState.CurrentRows);
                                    if (lvista.Count ==0)
                                        {                                    
                                        mTblDatos.Merge(dt);
                                        }
                                 }
                             else
                                {                                    
                                 mTblDatos.Merge(dt);
                                }
                                
                                Dtg_ColadasIngresadas.DataSource = mTblDatos;
                                formateaGrilla();
                                Tx_Colada.Text = "";
                             }
                         else
                         {
                             lMsg = string.Concat ("El Diámetro de la colada es distinto al del paquete a fabricar",Environment.NewLine);
                             lMsg = string.Concat(lMsg, " Diámetro de la colada:",dt.Rows[0]["Diametro"].ToString(), Environment.NewLine);
                             lMsg = string.Concat(lMsg, " Diámetro de la pieza a Fabricar:", Tx_DiamPieza .Text , Environment.NewLine);
                             MessageBox.Show(lMsg, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                             Tx_Colada.Text = "";
                             e.Cancel = true;
                         }
                     }
                     else
                     {
                         MessageBox.Show("La etiqueta '" + Tx_Colada.Text + "' no existe, o no ha sido enviada a producción, Revisar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                         e.Cancel = true;
                     }
                 }
                 else
                     MessageBox.Show(listaDataSet.MensajeError.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                 //mTotalKilos = double.Parse(this.Lbl_KgsProd.Text);
             }
             catch (Exception exc)
             {
                 MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
             this.Tx_Colada.Focus();
             Cursor.Current = Cursors.Default;
         }
     }

     private void Btn_salir_Click(object sender, EventArgs e)
     {
         this.Close();
     }

     private void Tx_Colada_TextChanged(object sender, EventArgs e)
     {

     }

     private void Dtg_ColadasIngresadas_CellContentClick(object sender, DataGridViewCellEventArgs e)
     {

     }

     private void Dtg_ColadasIngresadas_CellClick(object sender, DataGridViewCellEventArgs e)
     {
         int lRow = e.RowIndex; int i = 0; int j = 0;

         for (j = 0; j < Dtg_ColadasIngresadas.Rows.Count - 1; j++)
         {
             for (i = 0; i < Dtg_ColadasIngresadas.ColumnCount - 1; i++)
             {
                 Dtg_ColadasIngresadas.Rows[j].Cells[i].Style.BackColor = Color.White ;
             }
         }

        for (i = 0; i < Dtg_ColadasIngresadas.ColumnCount - 1; i++)
        {
            if (Dtg_ColadasIngresadas.Rows[lRow].Cells[i].Value.ToString().Length > 0)
            {
                Dtg_ColadasIngresadas.Rows[lRow].Cells[i].Style.BackColor = Color.LightGreen;
                Tx_Colada.Tag = Dtg_ColadasIngresadas.Rows[lRow].Cells["id1"].ToString();
            }
        }

     }

     private void Btn_Eliminar_Click(object sender, EventArgs e)
     {
         int i = 0;int Id=0; int IdSel=0;
         
         //verificamos que una fila este seleccionada debe estar el color verde
         for (i = 0; i < Dtg_ColadasIngresadas.RowCount -1; i++)
         {
             if (Dtg_ColadasIngresadas.Rows[i].Cells ["Id1"].Style .BackColor ==Color.LightGreen )
             {
                 IdSel = int.Parse(Dtg_ColadasIngresadas.Rows[i].Cells["Id1"].Value.ToString());
             }
         }


         if (IdSel.ToString().Length > 0)
             {
                 Id=int.Parse (IdSel.ToString () );
                 for (i=0;i< mTblDatos.Rows .Count ;i++)
                 {
                  if (mTblDatos.Rows[i]["Id1"].ToString().Equals (Id.ToString ())==true)
                        {
                            mTblDatos.Rows.Remove(mTblDatos.Rows[i]);
                        }
                 }
              }
     }

     private void Tx_Colada_KeyPress(object sender, KeyPressEventArgs e)
     {
         if ((int)e.KeyChar == (int)Keys.Enter)
         {
             Tx_Colada_Validating(null, null); 
         }

     }

    }
}
