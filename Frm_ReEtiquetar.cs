using System;
using System.Windows.Forms;
using CommonLibrary2;
using System.Drawing;
using System.Text;
using System.Data;
using System.IO;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;
using System.ComponentModel;


namespace Metalurgica
{
    public partial class Frm_ReEtiquetar : Form
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern SafeFileHandle CreateFile(string lpFileName, FileAccess dwDesiredAccess, uint dwShareMode, IntPtr lpSecurityAttributes, FileMode dwCreationDisposition, uint dwFlagsAndAttributes, IntPtr hTemplateFile);

         private DataTable  mTblNuevasColadas =new DataTable ();
         private int mIdColada = 0;
         private int mDiam = 0;
         private int mLargo = 0;
         private int mIdProducto = 0;

        public Frm_ReEtiquetar()
        {
            InitializeComponent();
        }

        private void Tx_PaqueteColada_Validating(object sender, CancelEventArgs e)
        {
            DataTable dt = new DataTable(); Clases.ClsComun lCn = new Clases.ClsComun();
            //string lDesc = "";
              WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
                    WsOperacion.ListaDataSet listaDataSet = new WsOperacion.ListaDataSet();

                    listaDataSet = wsOperacion.ObtenerRecepcionxEtiqueta_Colada(Tx_PaqueteColada.Text);
                    if (listaDataSet.MensajeError.Equals(""))
                    {
                        if (listaDataSet.DataSet.Tables[0].Rows.Count > 0)
                        {
                            dt = listaDataSet.DataSet.Tables[0];
                            //Validamos que el Paquetecolada no este en produccion, de ser asi no se puede re etiquetar
                            if (dt.Rows[0]["EnProduccion"].ToString().Equals ("1"))
                            {
                                MessageBox.Show("No se puede Re - Etiquetar, ya que el paquete ya no esta en Materias Primas, se encuentra en Producción", "Validaciones Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                Btn_Re_Etiquetar.Enabled = false;
                                Tx_PaqueteColada.Focus();
                            }
                            else
                                {
                                    if (dt.Rows[0]["Estado1"].ToString().Equals("A"))
                                    {
                                        MessageBox.Show("No se puede Re - Etiquetar, ya que el paquete Ingresado fue Anulado ", "Validaciones Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                        Btn_Re_Etiquetar.Enabled = false;
                                        Tx_PaqueteColada.Focus();
                                    }
                                    else
                                    {
                                        if (lCn.EsNumero(dt.Rows[0]["Diametro"].ToString()))
                                        {
                                            mDiam = lCn.Val(dt.Rows[0]["Diametro"].ToString());
                                        }
                                        if (lCn.EsNumero(dt.Rows[0]["Largo"].ToString()))
                                        {
                                            mLargo = lCn.Val(dt.Rows[0]["Largo"].ToString());
                                        }
                                        mIdProducto = lCn.Val(dt.Rows[0]["IdProducto"].ToString());
                                        mIdColada = lCn.Val(dt.Rows[0]["IdColada"].ToString());
                                        //lDesc=
                                        Dgt_DatosEtiqueta.DataSource = dt;
                                        Dgt_DatosEtiqueta.Columns["ID"].Visible = false;
                                        Dgt_DatosEtiqueta.Columns["CAMION"].Visible = false;
                                        Dgt_DatosEtiqueta.Columns["COLADA"].Visible = false;
                                        Dgt_DatosEtiqueta.Columns["ETIQUETA_COLADA"].Visible = false;
                                        Dgt_DatosEtiqueta.Columns["USUARIO"].Visible = false;
                                        Dgt_DatosEtiqueta.Columns["FECHA"].Visible = false;
                                        Dgt_DatosEtiqueta.Columns["REC_ESTADO"].Visible = false;
                                        Dgt_DatosEtiqueta.Columns["Id1"].Visible = false;
                                        Dgt_DatosEtiqueta.Columns["IdColada1"].Visible = false;
                                        Dgt_DatosEtiqueta.Columns["Idcolada"].Width = 60;
                                        //Lbl_Estado.Text = Dgt_DatosEtiqueta.Rows[0].Cells["Estado"].Value.ToString();
                                        Lbl_Estado.Text = ObtenerDescripcion(Dgt_DatosEtiqueta.Rows[0].Cells["Idcolada"].Value.ToString());
                                        Dgt_DatosEtiqueta.Columns["UserRegistro"].Visible = false;
                                        Dgt_DatosEtiqueta.Columns["FechaImpresion"].Visible = false;
                                        //Dgt_DatosEtiqueta.Columns["KgsPaquete"].Visible = false;
                                        Tx_BarrasTotales.Text = Dgt_DatosEtiqueta.Rows[0].Cells["NroBarras"].Value.ToString();
                                        Tx_KilosTotales.Text = Dgt_DatosEtiqueta.Rows[0].Cells["KilosCalculados"].Value.ToString();

                                        Btn_Re_Etiquetar.Enabled = true;
                                    }
                                }
                        }
                    }

        }


        private bool imprimirEtiquetas(StringBuilder archivoSalida, string impresora_etiquetas)
        {
            //Impresora Zebra 2013-05-09
            bool isPrinter = false;
            Clases.ClsComun lCn = new Clases.ClsComun();
            //Seteo de la impresora
            archivoSalida.Insert(0, lCn .seteoImpresora());

            try
            {
                // Create a buffer with the command
                Byte[] buffer = new byte[archivoSalida.ToString().Length];
                buffer = System.Text.Encoding.ASCII.GetBytes(archivoSalida.ToString());

                // Use the CreateFile external func to connect to the LPT1 port
                //SafeFileHandle printer = CreateFile("LPT1:", FileAccess.Write, 0, IntPtr.Zero, FileMode.OpenOrCreate, 0, IntPtr.Zero);
                SafeFileHandle printer = CreateFile(impresora_etiquetas, FileAccess.Write, 0, IntPtr.Zero, FileMode.OpenOrCreate, 0, IntPtr.Zero);

                // Test si imprimant valide
                if (!printer.IsInvalid)
                {
                    isPrinter = true;
                    // Open the filestream to the lpt1 port and send the command
                    FileStream lpt1 = new FileStream(printer, FileAccess.ReadWrite);
                    lpt1.Write(buffer, 0, buffer.Length);
                    // Close the FileStream connection
                    lpt1.Close();
                }
                else
                    MessageBox.Show("La impresora '" + impresora_etiquetas + "' no esta disponible.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return isPrinter;
        }

        private void Tx_NroPaquetes_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números 
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
                if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
                {
                    e.Handled = false;
                }
                else
                {
                    //el resto de teclas pulsadas se desactivan 
                    e.Handled = true;
                } 

        }

         private void  CreaTablaPaquetes()
         {

             if (mTblNuevasColadas.Columns .Count ==0) {
                    mTblNuevasColadas.Columns.Add("IdColada", Type.GetType("System.String"));
                    mTblNuevasColadas.Columns.Add("NroPaquete", Type.GetType("System.String"));
                    mTblNuevasColadas.Columns.Add("TotalPaquetes", Type.GetType("System.String"));
                    mTblNuevasColadas.Columns.Add("PesoPaquete", Type.GetType("System.String"));
                    mTblNuevasColadas.Columns.Add("NroBarras", Type.GetType("System.String"));
                    mTblNuevasColadas.Columns.Add("PesoCalculado", Type.GetType("System.String"));
                    mTblNuevasColadas.Columns.Add("Id", Type.GetType("System.String"));
             }
         }


         private void AgregaFilas(int iNro, int IdColada)
            {
                int lCont = 0; DataRow  lFila = null ;

                for (lCont =1;lCont <iNro+1 ;lCont ++)
                {
                    lFila = mTblNuevasColadas.NewRow();
                    lFila["IdColada"] = IdColada;
                    lFila["NroPaquete"] = lCont.ToString ();
                    lFila["TotalPaquetes"] = iNro.ToString();
                    lFila["PesoPaquete"] = "0";
                    lFila["NroBarras"] = "0";
                    lFila["PesoCalculado"] = "0";
                    mTblNuevasColadas.Rows.Add(lFila);
                }
             }

        private void CargaNroPaquetes( string  iNro, int IdColada )
        {
            if (!iNro.Equals ("0"))
            {
                mTblNuevasColadas = new DataTable(); int lNro = 0;
                CreaTablaPaquetes();
                lNro = int.Parse(iNro);
                AgregaFilas(lNro, mIdColada);
                Dtg_NuevosPaq.DataSource = mTblNuevasColadas;
                Dtg_NuevosPaq.Columns["IdColada"].ReadOnly = true;
                Dtg_NuevosPaq.Columns["IdColada"].Width = 60;
                Dtg_NuevosPaq.Columns["NroPaquete"].ReadOnly = true;
                Dtg_NuevosPaq.Columns["NroPaquete"].Width = 60;
                Dtg_NuevosPaq.Columns["TotalPaquetes"].ReadOnly = true;
                Dtg_NuevosPaq.Columns["PesoPaquete"].ReadOnly = true;
                Dtg_NuevosPaq.Columns["NroBarras"].ReadOnly = false;
                Dtg_NuevosPaq.Columns["NroBarras"].Width = 60;
                Dtg_NuevosPaq.Columns["PesoCalculado"].ReadOnly = true;
                Dtg_NuevosPaq.Columns["PesoCalculado"].Width = 70;
                Dtg_NuevosPaq.Columns["Id"].ReadOnly = true;
                Dtg_NuevosPaq.RowHeadersVisible = true;
            }
        }

        private void Tx_NroPaquetes_Validating(object sender, CancelEventArgs e)
        {
            CargaNroPaquetes(Tx_NroPaquetes.Text, mIdColada);
        }

        private void Tx_PaqueteColada_TextChanged(object sender, EventArgs e)
        {

        }

        private int ObtenerPesoCalculado(string iLargo, int iCant, string iDiam)
            {
                Ws_TO .Ws_ToSoapClient  lPx =new Ws_TO .Ws_ToSoapClient ();
                int  lRes = 0;
                lRes = lPx.ObtenerPesoBechtell(iLargo, iDiam, iCant);

                return lRes;

        }
 

           private int  ObtenerPesoTotal()
           {
           int  i  = 0;  int lTotal = 0; Clases .ClsComun lCn=new Clases.ClsComun ();

                for (i = 0;i<  Dtg_NuevosPaq.RowCount ;i++)
                       {
                            if (lCn .EsNumero (Dtg_NuevosPaq.Rows[i].Cells["PesoCalculado"].Value.ToString()))
                            {
                             lTotal = lTotal + lCn.Val(Dtg_NuevosPaq.Rows[i].Cells["PesoCalculado"].Value.ToString());
                            }                   
                       }
                return lTotal;
           }
           private int ObtenerBarrasIngresadas()
           {
               int i = 0; int lTotal = 0; Clases.ClsComun lCn = new Clases.ClsComun();

               for (i = 0; i < Dtg_NuevosPaq.RowCount; i++)
               {
                   if (lCn.EsNumero(Dtg_NuevosPaq.Rows[i].Cells["NroBarras"].Value.ToString()))
                   {
                       lTotal = lTotal + lCn.Val(Dtg_NuevosPaq.Rows[i].Cells["NroBarras"].Value.ToString());
                   }
               }
               return lTotal;
           }
        


        private void Dtg_NuevosPaq_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
           
        }


        
    private string  ObtenerDescripcion( string  idColada )
    {
        string lRes = ""; string lSql = ""; Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient();
         DataSet lDts= new DataSet ();

        lSql = string.Concat (" exec SP_CRUD_PAQUETES_COLADA 0," , idColada , ",0,0,0,0,0,0,'',0,0,3");

        lDts = lPx.ObtenerDatos(lSql);

        if ((lDts.Tables.Count > 0 ) && (lDts.Tables[0].Rows.Count > 0))
        {
            lRes = lDts.Tables[0].Rows[0]["Descrip"].ToString();
        }
        //'       @id int ,        '@IdColada int,                    '@NroPaquete int,
        //'@TotalPaquetes int,     '@KilosPaquete int,	            '@UserRegistro int,	
        //'@NroBarras int,	     '@KilosCalculados int,	            '@TipoProd varchar(1),
        //'@IdProd int,               '@Opcion int 

        return  lRes;

    }

        private void Dtg_NuevosPaq_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            int lCant = 0; int lDiam = 0; int lLargo = 0; int lPesoTotal = 0; int lTmp = 0;
            Clases.ClsComun lCn = new Clases.ClsComun(); double  lPesoBarra = 0;
            if (lCn.EsNumero(Dtg_NuevosPaq.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()) == false)
            {
                MessageBox.Show(this, "Debe Ingresar un valor Numerico, Revisar", "Avisos sistema", MessageBoxButtons.OK);
                Dtg_NuevosPaq.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                Dtg_NuevosPaq.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
            }
            else
            {
                lCant = lCn.Val(Dtg_NuevosPaq.Rows[e.RowIndex].Cells["NroBarras"].Value.ToString());
                if (lCant > 0)
                {
                    //obtenemos el peso promedio por barra
                    lPesoBarra = lCn.Val(Dgt_DatosEtiqueta.Rows[0].Cells["KilosCalculados"].Value.ToString()) / lCn.Val(Dgt_DatosEtiqueta.Rows[0].Cells["NroBarras"].Value.ToString());

                    lDiam = mDiam;
                    lLargo = mLargo / 1000;
                    Dtg_NuevosPaq.Rows[e.RowIndex].Cells[5].Value = ObtenerPesoCalculado(lLargo.ToString(), lCant, lDiam.ToString());
                    //Dtg_NuevosPaq.Rows[e.RowIndex].Cells[5].Value = lPesoBarra / lCant;
                    lPesoTotal = ObtenerBarrasIngresadas();
                    lTmp = lCn.Val(Dgt_DatosEtiqueta.Rows[0].Cells["NroBarras"].Value.ToString()) - lPesoTotal;
                    Tx_BarrasPorAs.Text = lTmp.ToString();
                    lPesoTotal = ObtenerPesoTotal();
                    lTmp = lCn.Val(Dgt_DatosEtiqueta.Rows[0].Cells["KilosCalculados"].Value.ToString()) - lPesoTotal;
                    this.Tx_KilosPorAs.Text = lTmp.ToString();
                }
            }
        }

        private void Btn_Re_Etiquetar_Click(object sender, EventArgs e)
        {
            string lSql = "";  Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient();
            DataSet lDts = new DataSet(); int i = 0; Clases .ClsComun lCn=new Clases.ClsComun ();
            int iId=0; int IdColada=0; int iNroPaq=0; int iKgs=0;int iTotalPaq=0; int iNroBarras=0; int iKgsCal=0;
            // 1.- se debe validar que todos los datos esten correctos antes de realizar el proceso.
            //El Paquete de la colada No debe haber pasado a produccion
            if (ValidarDatos()==true )
                {
                   
                    // 1.- se debe crear los Nuevos Paquetes
                    for (i = 0; i < Dtg_NuevosPaq.RowCount ; i++)
                    { 
                    //    mTblNuevasColadas.Columns.Add("IdColada", Type.GetType("System.String"));
                    //mTblNuevasColadas.Columns.Add("NroPaquete", Type.GetType("System.String"));
                    //mTblNuevasColadas.Columns.Add("TotalPaquetes", Type.GetType("System.String"));
                    //mTblNuevasColadas.Columns.Add("PesoPaquete", Type.GetType("System.String"));
                    //mTblNuevasColadas.Columns.Add("NroBarras", Type.GetType("System.String"));
                    //mTblNuevasColadas.Columns.Add("PesoCalculado", Type.GetType("System.String"));
                    //mTblNuevasColadas.Columns.Add("Id", Type.GetType("System.String"));


                       iId = lCn.Val(Dtg_NuevosPaq.Rows[i].Cells["Id"].Value.ToString());
                        IdColada =lCn.Val(Dtg_NuevosPaq.Rows[i].Cells["IdColada"].Value.ToString());
                        iNroPaq = lCn.Val(Dtg_NuevosPaq.Rows[i].Cells["NroPaquete"].Value.ToString());
                        iKgs =lCn.Val(Dtg_NuevosPaq.Rows[i].Cells["TotalPaquetes"].Value.ToString());
                        iTotalPaq = 0;
                        iKgs =lCn.Val(Dtg_NuevosPaq.Rows[i].Cells["PesoCalculado"].Value.ToString());
                        iNroBarras = lCn.Val(Dtg_NuevosPaq.Rows[i].Cells["NroBarras"].Value.ToString());
                        iKgsCal = lCn.Val(Dtg_NuevosPaq.Rows[i].Cells["PesoCalculado"].Value.ToString());
                        GrabaPeso(iId, IdColada, iNroPaq, iTotalPaq, iKgs, iNroBarras, "B", iKgsCal, mIdProducto);
                          //  lRes = lRes + 1;

                    }
                    // 2.- se debe Eliminar el paquete colada Original
                    lSql = string.Concat(" exec SP_CRUD_PAQUETES_COLADA ", Tx_PaqueteColada.Text, ",",IdColada,",0,0,0,0,0,0,'',0,0,4");
                    lDts = lPx.ObtenerDatos(lSql);
                    // @id int ,           //@IdColada int,             //@NroPaquete int,            //@TotalPaquetes int,
                    //@KilosPaquete int,  //@UserRegistro int,	        //@NroBarras int,	        //@KilosCalculados int,	
                    //@TipoProd varchar(1),   //@IdProd int,            //@Opcion int 
                    // 3.- se Re Ordenan los Paquetes; 


                    // 4.- se debe Imprimir nuevamente las etiquetas de los paquetes Coladas

                    MessageBox.Show("El proceso a terminado, Revisar la información en el módulo de coladas", "Avisos Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Btn_Re_Etiquetar.Enabled = false;
                }           
        }


        private void   GrabaPeso(int  iId , int  IdColada , int iNroPaq , int iTotalPaq , int  iKgs , int iNroBarras , string iTipoProd, int iKgsCal , int iIdProd ) 
    {
    //'ALTER PROCEDURE [dbo].[SP_CRUD_PAQUETES_COLADA]
    //    '@id int ,              '@IdColada int,        '@NroPaquete int,
    //    '@TotalPaquetes int,    '@KilosPaquete int,	   '@UserRegistro int,	    
    //    '@Opcion int 
        string  lsql = ""; int lRes = 0;Clases .ClsComun lCn=new Clases.ClsComun ();
        Ws_TO .Ws_ToSoapClient  lPx=  new Ws_TO .Ws_ToSoapClient (); DataSet  lDts = new DataSet ();
        lsql =  string.Concat(  "exec SP_CRUD_PAQUETES_COLADA ", iId, ",", IdColada, ",");
        lsql = String.Concat(lsql, iNroPaq, ",", iTotalPaq, ",", iKgs, ",0,", iNroBarras, ",", iKgsCal, ",'", iTipoProd, "',", iIdProd, ",0,1");
        lDts = lPx.ObtenerDatos(lsql);
        if ( lDts.Tables.Count > 0 &&  lDts.Tables[0].Rows.Count > 0 )
        {
            lRes = lCn.Val(lDts.Tables[0].Rows[0][0].ToString());
        }
       // return  lRes;
    }
        


       private bool ValidarDatos()
         {
             bool lRes = true; Clases.ClsComun lCn = new Clases.ClsComun(); string lMsg = "";

           if (lCn.EsNumero (Tx_BarrasPorAs.Text  ))
               {
                    if (lCn.Val(Tx_BarrasPorAs.Text)>0)
                        {
                            lRes = false;
                            lMsg = "Hay un problema en el número de barras, revisar el número de barras ingresado";
                        }
               }

           if (lMsg .ToString().Length >0)
           {
               lRes = false;
               MessageBox.Show(lMsg, "Avisos Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
           }
             return lRes;
         }

            private WsOperacion.ListaDataSet ObtenerDatosColada(string iIdColada)
        {
            Ws_TO .Ws_ToSoapClient  PxWS = new  Ws_TO .Ws_ToSoapClient();
            WsOperacion.ListaDataSet listaDataSet = new WsOperacion.ListaDataSet();
            string lSql = "";DataSet lDts =new DataSet() ;
//ALTER  PROCEDURE [dbo].[SP_ConsultasGenerales]
//@Opcion INT,          //@Par1 Varchar(100),       //@Par2 Varchar(100),
//@Par3 Varchar(100),   //@Par4 Varchar(100),       //@Par5 Varchar(100)
            lSql = string.Concat (" exec SP_ConsultasGenerales 25,",iIdColada,",'','','',''") ;
            try
            {
                listaDataSet.MensajeError = "";
                lDts = PxWS.ObtenerDatos(lSql);
                listaDataSet.DataSet = lDts;
            }           
             catch (Exception exc)
                    {
                        MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        listaDataSet.MensajeError = exc.Message.ToString();                  
             }

            return listaDataSet;
        }
          private WsOperacion.ListaDataSet ObtenerDetalleColada(string iIdColada)
        {
            Ws_TO.Ws_ToSoapClient PxWS = new Ws_TO.Ws_ToSoapClient();
            WsOperacion.ListaDataSet listaDataSet = new WsOperacion.ListaDataSet();
            string lSql = ""; DataSet lDts = new DataSet();
            //ALTER  PROCEDURE [dbo].[SP_ConsultasGenerales]
            //@Opcion INT,          //@Par1 Varchar(100),       //@Par2 Varchar(100),
            //@Par3 Varchar(100),   //@Par4 Varchar(100),       //@Par5 Varchar(100)
            lSql = string.Concat(" exec SP_ConsultasGenerales 28,", iIdColada, ",'','','',''");
            try
            {
                listaDataSet.MensajeError = "";
                lDts = PxWS.ObtenerDatos(lSql);
                listaDataSet.DataSet = lDts;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                listaDataSet.MensajeError = exc.Message.ToString();
            }

            return listaDataSet;
        }



       private void Btn_Imprimir_Click(object sender, EventArgs e)
       {
            StringBuilder archivoSalida = new StringBuilder();
           Registry registry = new Registry();
           //string impresora_etiquetas = "Godex EZ2250i"; //(string)registry.GetValue(Program.regeditKeyName, "Impresora_etiquetas", "");
           string impresora_etiquetas = (string)registry.GetValue(Program.regeditKeyName, "Impresora_etiquetas", "");
            string diametro = ".", largo = ".", nroCertificado = ".", kilos = "0"; string Procedencia = "";
            string NroPaq = ""; string lTmp = ""; string lNroColada = ""; int IdPaqColada = 0;
           if (!impresora_etiquetas.Equals(""))
           {
               Cursor.Current = Cursors.WaitCursor;
               try
               {
                   WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
                   WsOperacion.Recepcion_Colada recepcion_colada = new WsOperacion.Recepcion_Colada();

                   //foreach (DataGridViewRow row in dgvRecepciones.Rows)
                   //{
                   //    if (row.Cells[COLUMNNAME_MARCA].Value != null)
                   //    {

                   //        if ((bool)row.Cells[COLUMNNAME_MARCA].Value == true)
                   //        {
                   recepcion_colada.Id = 0;// Convert.ToInt32(Tx_IdColada.Text);
                   //recepcion_colada.Colada = row.Cells[2].Value.ToString();
                   recepcion_colada.Colada =Tx_IdColada.Text;
                   recepcion_colada.Etiqueta_colada ="";
                   recepcion_colada.Usuario = Program.currentUser.Login;

                               //Otros datos ws
                               diametro = ".";
                               largo = ".";
                               nroCertificado = ".";
                               kilos = "0";
                               Procedencia = "";
                               lNroColada = "";
                               NroPaq = "";
                               IdPaqColada = 0;

                               WsOperacion.ListaDataSet listaDataSet = new WsOperacion.ListaDataSet();
                               //listaDataSet = wsOperacion.ObtenerColadasPorNro(recepcion_colada.Colada);
                               listaDataSet = ObtenerDatosColada(recepcion_colada.Colada);
                               if (listaDataSet.MensajeError.Equals(""))
                               {
                                   DataTable dt = listaDataSet.DataSet.Tables[0];
                                   if (dt.Rows.Count > 0)
                                   {
                                       diametro = dt.Rows[0]["DIAMETRO"].ToString();
                                       largo = dt.Rows[0]["LARGO"].ToString();
                                       Procedencia = dt.Rows[0]["Procedencia"].ToString();
                                       //  NroPaq = (int) dt.Rows[0]["NroPaq"];
                                       nroCertificado = dt.Rows[0]["NROCERTIFICADO"].ToString();
                                       kilos = dt.Rows[0]["KILOSCOLADA"].ToString();
                                       lNroColada = dt.Rows[0]["NroColada"].ToString();
                                       kilos = (kilos.Equals("") ? "0" : kilos);
                                       //CodInterno=""
                                   }
                               }
                               //<Etiqueta>
                               //
                               int i = 0;
                               listaDataSet = ObtenerDetalleColada(recepcion_colada.Colada);
                               if (listaDataSet.MensajeError.Equals(""))
                               {
                                   DataTable dt = listaDataSet.DataSet.Tables[0];
                                   for (i = 0; i < dt.Rows.Count; i++)
                                   {
                                       IdPaqColada = (int)dt.Rows[i]["Id"];
                                       kilos = dt.Rows[i]["KilosCalculados"].ToString();
                                       NroPaq = string.Concat(dt.Rows[i]["NroPaquete"].ToString(), " de ", dt.Rows[i]["TotalPaquetes"].ToString());
                                       //----------------------------
                                       lTmp = "Largo: " + largo + " (mm)  -  Diametro: " + diametro;
                                       archivoSalida = new StringBuilder();
                                       archivoSalida.Append("A155,10,0,4,1,1,N,\"Procedencia: " + Procedencia + "\"" + Environment.NewLine);
                                       archivoSalida.Append("A155,40,0,4,1,1,N,\"Colada: " + lNroColada + "\"" + Environment.NewLine);
                                       archivoSalida.Append("A155,70,0,4,1,1,N,\"" + lTmp + "\"" + Environment.NewLine);
                                       //   archivoSalida.Append("A155,70,0,4,1,1,N,\"Largo: " + largo + "\"" + Environment.NewLine);
                                       // archivoSalida.Append("A155,100,0,4,1,1,N,\"Diametro: " + diametro + "\"" + Environment.NewLine);
                                       // lTmp = "Peso: " + kilos + " kgs.   -  Barras: " + diametro;
                                       archivoSalida.Append("A155,100,0,4,1,1,N,\"Peso: " + kilos + " kgs.\"" + Environment.NewLine);
                                       archivoSalida.Append("A155,130,0,4,1,1,N,\"Nro. Paquete: " + NroPaq.ToString() + " \"" + Environment.NewLine);
                                       // archivoSalida.Append("A155,240,0,4,1,1,N,\"Nro.Certificado: " + nroCertificado + "\"" + Environment.NewLine);
                                       //archivoSalida.Append("B155,180,0,1,2,2,80,N,\"" + recepcion_colada.Etiqueta_colada + "\"" + Environment.NewLine);
                                       //archivoSalida.Append("A155,270,0,4,1,1,N,\"" + recepcion_colada.Etiqueta_colada + "\"" + Environment.NewLine);                                            
                                       //por modificaciones se debe imprimir el ID de paquete para 
                                       archivoSalida.Append("B155,180,0,1,2,2,80,N,\"" + IdPaqColada + "\"" + Environment.NewLine);
                                       lTmp = string.Concat(IdPaqColada, "     ", lNroColada, "-", kilos);
                                       //archivoSalida.Append("A155,270,0,4,1,1,N,\"" + IdPaqColada + "\"" + Environment.NewLine);
                                       archivoSalida.Append("A155,270,0,4,1,1,N,\"" + lTmp + "\"" + Environment.NewLine);
                                       archivoSalida.Append("P1" + Environment.NewLine);
                                       archivoSalida.Append("N" + Environment.NewLine);

                                       // archivoSalida.Append("A155,270,0,4,1,1,N,\"" + lTmp + "\"" + Environment.NewLine);
                                       //</Etiqueta>                                            
                                       imprimirEtiquetas(archivoSalida, impresora_etiquetas);
                                   }
                               }                             
                           }                     
               catch (Exception exc)
               {
                   MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
               Cursor.Current = Cursors.Default;
           }
           else
               MessageBox.Show("La impresora de etiquetas no esta definida en el registro.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

       }

       private void Btn_BuscarColada_Click(object sender, EventArgs e)
       {

       }

       private void CargaDatos()
       { 
       
       
       }

       private void Tx_IdPaqueteCol_TextChanged(object sender, EventArgs e)
       {

       }

       private void Tx_IdPaqueteCol_Validating(object sender, CancelEventArgs e)
       {
           DataTable dt = new DataTable(); Clases.ClsComun lCn = new Clases.ClsComun(); string lSql = "";
            //string lDesc = "";
              WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
                    WsOperacion.ListaDataSet listaDataSet = new WsOperacion.ListaDataSet();
                  WsCrud .CrudSoapClient   wsSession = new  WsCrud .CrudSoapClient();
                  WsCrud.ListaDataSet listaDataSet2 = new WsCrud.ListaDataSet(); int i = 0;
                  DataTable dt2 = new DataTable();DataRow lFila=null;

                  listaDataSet = wsOperacion.ObtenerRecepcionxEtiqueta_Colada(Tx_IdPaqueteCol.Text);
                    if (listaDataSet.MensajeError.Equals(""))
                    {
                        if (listaDataSet.DataSet.Tables[0].Rows.Count > 0)
                        {
                            dt = listaDataSet.DataSet.Tables[0];

                            Tx_IdColada.Text = dt.Rows[0]["IdColada"].ToString();
                            Tx_Colada.Text = dt.Rows[0]["NroColada"].ToString();
                            Tx_guiaDesp.Text = dt.Rows[0]["NroGuiaDesp"].ToString();
                            Tx_Certificado.Text = dt.Rows[0]["NroCertificado"].ToString();
                            Cmb_Proced.Text = dt.Rows[0]["Procedencia"].ToString();


                            lSql = string.Concat("exec SP_CRUD_PAQUETES_COLADA  0,", dt.Rows [0]["IdColada"].ToString (), ",0,0,0,0,0,0,'',0,0,2");
                            CreaTablaPaquetes();
                            listaDataSet2 = wsSession.ListarAyudaSql(lSql);
                            dt2 = listaDataSet2.DataSet.Tables[0];
                            for (i = 0; i < dt2.Rows .Count ; i++)
                            {
                                lFila = mTblNuevasColadas.NewRow();
                                lFila["IdColada"] = dt2.Rows[i]["IdColada"].ToString();
                                lFila["NroPaquete"] = dt2.Rows[i]["NroPaquete"].ToString();
                                lFila["TotalPaquetes"] = dt2.Rows[i]["TotalPaquetes"].ToString();
                                lFila["PesoPaquete"] = dt2.Rows[i]["KilosPaquete"].ToString();
                                lFila["NroBarras"] = dt2.Rows[i]["NroBarras"].ToString();
                                lFila["PesoCalculado"] = dt2.Rows[i]["KilosCalculados"].ToString();
                                lFila["Id"] = dt2.Rows[i]["Id"].ToString();
                                mTblNuevasColadas.Rows.Add(lFila);
                            }
                            DTG_PaquetesColada.DataSource = mTblNuevasColadas;
                            DataGridViewCheckBoxColumn check = new DataGridViewCheckBoxColumn();
                            check.Name = "Imprimir";
                            DTG_PaquetesColada.Columns.Insert(0, check);

                            for (i = 1; i < DTG_PaquetesColada.Columns .Count ; i++)
                            {
                                DTG_PaquetesColada.Columns[i].ReadOnly = true;
                            }
                        }
                    }
       }

       private void Btn_Salir_Click(object sender, EventArgs e)
       {
           this.Close();
       }

       private void DTG_PaquetesColada_CellClick(object sender, DataGridViewCellEventArgs e)
       {
           

       }

    }
}
