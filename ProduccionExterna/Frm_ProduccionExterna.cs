using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Metalurgica.ProduccionExterna
{
    public partial class Frm_ProduccionExterna : Form
    {
        private CurrentUser mUserLog = new CurrentUser();
        private String mTipo = "";
        private DataTable mTblObrasProdExterna = new DataTable();
        private DataTable mTblEtiquetas = new DataTable();
        private Boolean CargaInicial = true;
        private DataTable mTblErrorProd = new DataTable();
        public Frm_ProduccionExterna()
        {
            InitializeComponent();
        }

        public void InicializaForm(CurrentUser iUserLog, string iTipo)
        {
            WsOperacion.ListaDataSet lDts = new WsOperacion.ListaDataSet();
            WsOperacion.OperacionSoapClient lPx = new WsOperacion.OperacionSoapClient();
            DataTable lTblEx = new DataTable(); DataTable lTblObras = new DataTable();
            DataView lVistaPE = null; DataView lVistaObras = null;
            string lEmpresa = ConfigurationManager.AppSettings["Empresa"].ToString();
            DataRow lFila = null;
            try
            {
                mUserLog = iUserLog;
                mTipo = iTipo;
                Tx_fechaEnvio.Text = DateTime.Now.ToShortDateString();
                CargaInicial = true;
                lDts = lPx.ObtenerDatosIniciales_PE("I", "");
                if (lDts.MensajeError.Trim().Length == 0)
                {
                    lTblEx = lDts.DataSet.Tables["Externos"].Copy();
                    lFila = lTblEx.NewRow();
                    lFila["Par1"] = " Seleccionar";
                    lFila["Par2"] = lEmpresa;
                    lTblEx.Rows.Add(lFila);

                    lTblObras = lDts.DataSet.Tables["Obras"].Copy();
                    lFila = lTblObras.NewRow();
                    lFila["Nombre"] = "Seleccionar";
                    lFila["Id"] = "0";
                    lFila["Empresa"] = lEmpresa ;
                    lTblObras.Rows.Add(lFila);

                    lVistaPE = new DataView(lTblEx, string.Concat(" Par2='", lEmpresa, "'"), "", DataViewRowState.CurrentRows);

                    Cmb_Externo.DataSource = lVistaPE; // lTblEx.Copy ();
                    Cmb_Externo.DisplayMember = "Par1";
                    Cmb_Externo.ValueMember = "Par1";
                    Cmb_Externo.SelectedIndex = lVistaPE. Count - 1;

                    lVistaObras = new DataView(lTblObras, string.Concat(" Empresa='", lEmpresa, "'"), "", DataViewRowState.CurrentRows);
                    Cmb_Obra.DataSource = lVistaObras;
                    Cmb_Obra.DisplayMember = "Nombre";
                    Cmb_Obra.ValueMember = "Id";
                    Cmb_Obra.SelectedIndex = lVistaObras. Count - 1;
                    CargaInicial = false;

                    //mTblErrorProd
                    mTblErrorProd = lDts.DataSet.Tables["ErrProduccion"].Copy();
                    Cmb_Problemas.DataSource = mTblErrorProd;
                    Cmb_Problemas.DisplayMember = "Par1";
                    Cmb_Problemas.ValueMember = "Par1";
                }

                Tx_NroEtiquetas.Text = "0";
                Tx_TotalKgs.Text = "0";

                mTblEtiquetas = new DataTable();
                mTblEtiquetas.Columns.Add("IdPaquete", Type.GetType("System.String"));
                mTblEtiquetas.Columns.Add("IT", Type.GetType("System.String"));
                mTblEtiquetas.Columns.Add("Etiqueta", Type.GetType("System.String"));
                mTblEtiquetas.Columns.Add("Kgs", Type.GetType("System.String"));
                mTblEtiquetas.Columns.Add("Cantidad", Type.GetType("System.String"));
                mTblEtiquetas.Columns.Add("ProdExterna", Type.GetType("System.String"));

                //Habilitamos las Opciones
                switch (mTipo)
                {
                    case "O":  // oficina tecnica 
                        tabPage1.Enabled = true;
                        tabPage2.Enabled = false;
                        tabPage3.Enabled = false;
                        tabControl1.SelectedIndex = 0;
                        break;
                    case "A":  // Sucursal de Armacero
                        tabPage1.Enabled = false;
                        tabPage2.Enabled = true;
                        tabPage3.Enabled = true;
                        tabControl1.SelectedIndex = 1;
                        break;
                    case "C":  // Calidad registro de produccion 
                        tabPage1.Enabled = false;
                        tabPage2.Enabled = true;
                        tabPage3.Enabled = true;
                        tabControl1.SelectedIndex = 1;
                        break;
                    case "T":  // TOSOL, puede enviar, producir y despachar 
                        tabPage1.Enabled = true;
                        tabPage2.Enabled = true;
                        tabPage3.Enabled = true;
                        tabControl1.SelectedIndex = 0;
                        break;
                    default:
                        //Console.WriteLine("Other");
                        break;
                }

                //Obtenemos la Versión de la Aplicación
                //VersionPE
                string VersionPE = ConfigurationManager.AppSettings["VersionPE"].ToString();

                if (VersionPE != null)
                    this.Text = string.Concat(this.Text, VersionPE.ToString());
            }
            catch (Exception iex)
            {
                MessageBox.Show(string.Concat(" Se ha Producido el siguiente error: ", iex.Message.ToString()), "Avisos Sistema");
            }

        }

        private void Frm_ProduccionExterna_Load(object sender, EventArgs e)
        {
          
        }

        private void TX_Etiqueta_Validating(object sender, CancelEventArgs e)
        {
            Clases.ClsComun lCom = new Clases.ClsComun();
            if ((TX_Etiqueta.Text.Trim().Length > 0) && (lCom.Val(TX_Etiqueta.Text) > 0))
            {
                ProcesaEtiqueta(TX_Etiqueta.Text);
                CalculaTotales();
                TX_Etiqueta.Text = "";
            }
            else
            {
                MessageBox.Show("Debe ingresar solo Número, Revisar", "Avisos Sistema");

            }
        }

        private Boolean ObraPermiteProduccionExterna(string iIdObra)
        {
            Boolean lRes = false;
            string lWhere = string.Concat(" par1='", iIdObra.ToString(), "'");
            DataView lVista = new DataView(mTblObrasProdExterna, lWhere, "", DataViewRowState.CurrentRows);

            if (lVista.Count > 0)
                lRes = true;
            else
                lRes = false;


            return lRes;

        }

        private void AgregaFila(DataRow ifila)
        {
            DataRow lNewFile = null;int i = 0;int j = 0;

            lNewFile = mTblEtiquetas.NewRow();
            lNewFile["IdPaquete"] = ifila["IdPaquete"].ToString();
            lNewFile["IT"] = ifila["Codigo"].ToString();
            lNewFile["Etiqueta"] = ifila["Etiqueta"].ToString();
            lNewFile["Kgs"] = ifila["PesoPaquete"].ToString();
            lNewFile["Cantidad"] = ifila["PiezasPaq"].ToString();
            lNewFile["ProdExterna"] = ifila["ProdExterna"].ToString();

            mTblEtiquetas.Rows.Add(lNewFile);

            Dtg_Etiquetas.DataSource = mTblEtiquetas;
            Dtg_Etiquetas.Columns[0].Width = 80;
            Dtg_Etiquetas.Columns[1].Width = 70;
            Dtg_Etiquetas.Columns[2].Width = 100;
            Dtg_Etiquetas.Columns[3].Width = 50;
            Dtg_Etiquetas.Columns[4].Width = 70;

           for (i=0;i< Dtg_Etiquetas.Rows .Count;i++)
            {
                if (Dtg_Etiquetas.Rows [i].Cells ["ProdExterna"].Value .ToString().ToUpper ().Equals ("S"))
                {
                    for (j = 0; j < Dtg_Etiquetas.Columns .Count; j++)
                    {
                        Dtg_Etiquetas.Rows[i].Cells[j].Style.BackColor = Color.LightSalmon;
                    }
                }
                else
                    for (j = 0; j < Dtg_Etiquetas.Columns.Count; j++)
                    {
                        Dtg_Etiquetas.Rows[i].Cells[j].Style.BackColor = Color.LightGreen;
                    }

            }

        }

        private void CalculaTotales_Recepcion()
        {
            int i = 0; double lTotalKgsOK = 0; Clases.ClsComun lCom = new Clases.ClsComun();
            int lTotalETOK = 0; double lTotalKgsNOOK = 0; double lTotalETNoOK = 0; double lTotalKgs = 0;

            Tx_EtEnviadas.Text = Dtg_Recepcion.Rows.Count.ToString ();


            for (i = 0; i < Dtg_Recepcion.Rows.Count; i++)
            {
                if (Dtg_Recepcion.Rows[i].Cells["ObsNC"].Value.ToString().Trim ().Length >0)
                {
                    lTotalKgsNOOK = lTotalKgsNOOK + lCom.CDBL(Dtg_Recepcion.Rows[i].Cells["KgsPaquete"].Value.ToString());
                    lTotalETNoOK = lTotalETNoOK + 1;
                }
                else
                 if (Dtg_Recepcion.Rows[i].Cells["OK"].Value.ToString().Equals ("OK"))
                    {
                        lTotalKgsOK = lTotalKgsOK + lCom.CDBL(Dtg_Recepcion.Rows[i].Cells["KgsPaquete"].Value.ToString());
                        lTotalETOK = lTotalETOK + 1;
                    }

                lTotalKgs= lTotalKgs+ lCom.CDBL(Dtg_Recepcion.Rows[i].Cells["KgsPaquete"].Value.ToString());
            }

            Tx_KgsEnviadas.Text = lTotalKgs.ToString();
            Tx_EtOK.Text = lTotalETOK.ToString();
            Tx_KgsNOOK.Text = lTotalKgsNOOK.ToString();
            Tx_EtNOOK.Text = lTotalETNoOK.ToString();
            Tx_KgsOK .Text = lTotalKgsOK.ToString();
            Tx_saldoEstiquetas.Text = (lCom.Val(Tx_EtEnviadas.Text) - (lTotalETOK + lTotalETNoOK)).ToString();
            Tx_saldoKgs  .Text = (lTotalKgs - (lTotalKgsOK + lTotalKgsNOOK)).ToString();

        }

        private void CalculaTotales()
        {
            int i = 0; double  lTotalKgs = 0; Clases.ClsComun lCom = new Clases.ClsComun();
            int lCantTotal = 0;

            for (i = 0; i < Dtg_Etiquetas.Rows.Count; i++)
            {
                //if (Dtg_Etiquetas.Rows[i].Cells["ProdExterna"].Value.ToString().ToUpper ().Equals ("N"))
                //{ 
                lTotalKgs = lTotalKgs + lCom.CDBL (Dtg_Etiquetas.Rows[i].Cells["Kgs"].Value.ToString());
                 lCantTotal = lCantTotal +1;
                //}
            }
            Tx_NroEtiquetas.Text = lCantTotal.ToString ();
            Tx_TotalKgs.Text = lTotalKgs.ToString ();

         

        }

        private bool  ProcesaEtiqueta(string iIdPaquete)
        {
            Boolean  lRes = true   ; DataTable lTb = new DataTable();
            WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
            WsOperacion.ListaDataSet listaDataSet = new WsOperacion.ListaDataSet();
            string lMsg = "";

            listaDataSet = wsOperacion.ObtenerDatosConsultaGenerica(8, iIdPaquete.ToString(), "", "", "", "");
            if ((listaDataSet.DataSet.Tables.Count > 0) && (listaDataSet.DataSet.Tables[0].Rows.Count > 0))
            {
                lTb = listaDataSet.DataSet.Tables[0].Copy();
                //Validaciones
                //1.- Debe ser de  una Obra Configurada para Envio a produccion Externa
                //if (ObraPermiteProduccionExterna(lTb.Rows[0]["IdObra"].ToString()) == true)
                //{
                    //1.- Etiqueta fue enviada a Produccion Externa
                    if (lTb.Rows[0]["ProdExterna"].ToString().ToUpper().Equals("S"))
                    {
                    //OK  
                    //2.- Verificar que ya no este producida
                        if ((lTb.Rows[0]["Pie_estado"].ToString().Trim ().Length >0) &&(lTb.Rows[0]["Pie_estado"].ToString()!="O90" ) )
                        {
                            lMsg = string.Concat(lMsg, "  -  La Etiqueta ingresada, ya esta producida con fecha: ", lTb.Rows[0]["FechaProduccion"].ToString());
                            lRes = false;
                        }

                    //if (lTb.Rows[0]["FechaProduccion"].ToString().Trim ().Length >0)
                    //{
                    //    lMsg = string.Concat(lMsg,  "  -  La Etiqueta ingresada, ya esta producida con fecha: ", lTb.Rows[0]["FechaProduccion"].ToString());
                    //    lRes = false;
                    //}

                }
                else
                    {
                        lMsg = string.Concat(lMsg, "  -  La etiqueta ingresada, No  ha sido enviada a Produccion Externa ");
                        lRes = false;
                    // No ha sifo enviada a Produccion externa. 
                    // No se debe realizar el registro
                }

       
                if (lMsg.Trim().Length > 0)
                {
                    MessageBox.Show(lMsg, "Avisos Sistema");
                }

            }



            return lRes;
        }

        private void Btn_Grabar_Click(object sender, EventArgs e)
        {
            GrabarDatos();
        }

        private DataTable CreaColumnas(DataTable iTbl)
        {
            iTbl = new DataTable();
            iTbl.Columns.Add("Id", Type.GetType("System.String"));
            iTbl.Columns.Add("Idpaquete", Type.GetType("System.String"));
            iTbl.Columns.Add("Externo", Type.GetType("System.String"));
            iTbl.Columns.Add("IdUserenvia", Type.GetType("System.String"));
            iTbl.Columns.Add("Estado", Type.GetType("System.String"));
            iTbl.Columns.Add("ProdExterna", Type.GetType("System.String"));

            //

            return iTbl;
        }

        private void GrabarDatos()
        {
            string lTx = ""; int i = 0; WsOperacion.ListaDataSet lListDts = new WsOperacion.ListaDataSet();
            WsOperacion.OperacionSoapClient lPx = new WsOperacion.OperacionSoapClient();
            DataTable lTbl = new DataTable(); DataRow lfila = null; DataSet lDts = new DataSet();
            if (Dtg_Etiquetas.Rows.Count == 0)
            {
                MessageBox.Show(" Debe Ingresar las Etiquetas que seran enviadas, Revisar  ", "Avisos Sistema");

            }
            else
            {
                if (Cmb_Externo.SelectedValue.ToString().ToUpper().Equals("SELECCIONAR"))
                {
                    MessageBox.Show(" Debe Seleccionar donde se enviara la Produccion , Revisar  ", "Avisos Sistema");
                    Cmb_Externo.Focus();
                }
                else
                {
                    lTbl = CreaColumnas(lTbl);
                    for (i = 0; i < Dtg_Etiquetas.Rows.Count; i++)
                    {
                        if (Dtg_Etiquetas.Rows[i].Cells["ProdExterna"].Value.ToString().ToUpper().Equals("N"))
                        {
                            lfila = lTbl.NewRow();
                            lfila["Idpaquete"] = Dtg_Etiquetas.Rows[i].Cells["Idpaquete"].Value.ToString();
                            lfila["Externo"] = Cmb_Externo.SelectedValue;
                            lfila["IdUserenvia"] = mUserLog.Iduser ;
                            lfila["Estado"] = "";
                            lfila["Id"] = "0";
                            lTbl.Rows.Add(lfila);
                        }
                    }
                    if (lTbl.Rows.Count == 0)
                    {
                        MessageBox.Show(" Debe Ingresar las Etiquetas que seran enviadas, Revisar  ", "Avisos Sistema");
                    }
                    else
                    {
                        lDts = new DataSet();
                        lDts.Tables.Add(lTbl);
                        lListDts.DataSet = lDts;
                        lListDts = lPx.PersisteEnviosProdEx(lListDts);
                        if (lListDts .MensajeError .Trim ().Length ==0)
                        { 
                             MessageBox.Show(" Los Datos se Grabaron Correctamente   ", "Avisos Sistema");
                            Btn_Grabar.Enabled = false;
                        }
                        else
                            MessageBox.Show(string .Concat ("Ha Ocurrido el Siguiente Error  ", lListDts .MensajeError ), "Avisos Sistema");
                    }
                }
            }



        }

        private void TX_Etiqueta_TextChanged(object sender, EventArgs e)
        {

        }

        private void Btn_Buscar_Click(object sender, EventArgs e)
        {
            BuscarDatos();
        }

        private void BuscarDatos()
        {
            WsOperacion.ListaDataSet lListDts = new WsOperacion.ListaDataSet();
            WsOperacion.OperacionSoapClient lPx = new WsOperacion.OperacionSoapClient();
            DataTable lTbl = new DataTable();int i = 0;

            string lfechaIni = ""; string lFechaFin = ""; string iTipo = "";
            if (Rb_todas.Checked == true)
            {
                iTipo = "T";

            }
            else
            {
                iTipo = "F";
                lfechaIni = string.Concat(Dtp_Inicio.Value.ToShortDateString()," 00:00:01");
                lFechaFin = string.Concat(Dtp_Fin.Value.ToShortDateString() , " 23:59:59");
            }

            lListDts = lPx.ObtenerEnviosSinRecepcion(iTipo, lfechaIni, lFechaFin);
            if (lListDts.MensajeError.Trim().Length == 0)
            {
                if (lListDts.DataSet.Tables.Count > 0)
                {
                    lTbl = lListDts.DataSet.Tables[0].Copy();
                 //  lTbl.Columns.Add("Viajes", Type.GetType("System.String"));

                    lTbl = CargaDetalle(lTbl);
                    Dtg_EnviosRealizados.DataSource = lTbl;
                }
            }
            else
            {

                MessageBox.Show(String.Concat("Ha ocurrido el Siguiente ERROR: ", lListDts.MensajeError), "Avisos Sistema");
            }
        }

        private DataTable CargaDetalle(DataTable iTbl)
        {
            WsOperacion.ListaDataSet lListDts = new WsOperacion.ListaDataSet();
            WsOperacion.OperacionSoapClient lPx = new WsOperacion.OperacionSoapClient();
            DataTable lTbl = new DataTable(); int i = 0;int k = 0; string iViajes = "";
            double  lKgsOK = 0;Clases.ClsComun lCom = new Clases.ClsComun();

            for (i = 0; i < iTbl.Rows.Count; i++)
            {
                lListDts = lPx.ObtenerDetalleRecepcion(iTbl.Rows[i]["FechaEnvio"].ToString());
                if ((lListDts.DataSet.Tables["OK"] != null) && (lListDts.DataSet.Tables["OK"].Rows.Count > 0))
                {
                    lTbl = lListDts.DataSet.Tables["OK"].Copy();
                    for (k = 0; k < lTbl.Rows.Count; k++)
                    {
                        lKgsOK = lKgsOK + lCom.CDBL (lTbl.Rows[k]["KgsPaquete"].ToString());
                    }
                    iTbl.Rows[i]["KgsOk"] = lKgsOK;
                    iTbl.Rows[i]["NroEtiquetasOk"] = k;
                }
                if ((lListDts.DataSet.Tables["NOOK"] != null) && (lListDts.DataSet.Tables["NOOK"].Rows.Count > 0))
                {
                    lTbl = lListDts.DataSet.Tables["NOOK"].Copy();
                    for (k = 0; k < lTbl.Rows.Count; k++)
                    {
                        lKgsOK = lKgsOK + lCom.Val(lTbl.Rows[k]["KgsPaquete"].ToString());
                    }
                    iTbl.Rows[i]["KgsNO"] = lKgsOK;
                    iTbl.Rows[i]["NroEtiquetas_NOOk"] = k;
                }

                iViajes = "";
                if ((lListDts.DataSet.Tables["Viajes"] != null) && (lListDts.DataSet.Tables["Viajes"].Rows.Count > 0))
                {
                    lTbl = lListDts.DataSet.Tables["Viajes"].Copy();
                    for (k = 0; k < lTbl.Rows.Count; k++)
                    {
                        iViajes =string.Concat (  lTbl.Rows[k]["Codigo"].ToString(), " | ", iViajes);
                    }
                    iTbl.Rows[i]["Viajes"] = iViajes;
                    //iTbl.Rows[i]["KgsNO"] = lKgsOK;
                    //iTbl.Rows[i]["NroEtiquetas_NOOk"] = k;
                }

            }


            return iTbl;
        }

        private void Cmb_Viaje_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CargaIts(string iIdObra)
        {
            WsOperacion.ListaDataSet lDts = new WsOperacion.ListaDataSet();
            WsOperacion.OperacionSoapClient lPx = new WsOperacion.OperacionSoapClient();
            DataTable lTblIT = new DataTable();             DataRow lFila = null;
            string lProdExt = Cmb_Externo.SelectedValue .ToString();

            Tx_fechaEnvio.Text = DateTime.Now.ToShortDateString();


            lDts = lPx.ObtenerIt_PorObra_ProdEx( iIdObra, lProdExt);
            if (lDts.MensajeError.Trim().Length == 0)
            {
                lTblIT = lDts.DataSet.Tables["IT"].Copy();
                lFila = lTblIT.NewRow();
                lFila["Codigo"] = " Seleccionar";
                lTblIT.Rows.Add(lFila);

                Cmb_Viaje .DataSource = lTblIT.Copy();
                Cmb_Viaje.DisplayMember = "Codigo";
                Cmb_Viaje.ValueMember = "Codigo";
                Cmb_Viaje.SelectedIndex = lTblIT.Rows.Count - 1;
            }
        }

        private void Cmb_Obra_SelectedIndexChanged(object sender, EventArgs e)
        {
           //int lIndex = Cmb_Obra.SelectedIndex;
            if ((Cmb_Obra.SelectedValue  != null) && (CargaInicial == false))
            {
                CargaIts(Cmb_Obra.SelectedValue.ToString ());

            }
        }

        private void Btn_Agregar_Click(object sender, EventArgs e)
        {
            //if (mViajesCargados.Trim ().Length >0)
            //        mViajesCargados = string.Concat(mViajesCargados, ",", Cmb_Viaje.SelectedValue.ToString());
            //else
            //    mViajesCargados = string.Concat(  Cmb_Viaje.SelectedValue.ToString());
            if (Cmb_Viaje.SelectedValue!=null)
                  CargaEtiquetas(Cmb_Viaje.SelectedValue.ToString());

        }

        private void CargaEtiquetas(string iCodViaje)
        {
            //'ObtenerEtiquetasPorViaje'
            WsOperacion.ListaDataSet lDts = new WsOperacion.ListaDataSet();
            WsOperacion.OperacionSoapClient lPx = new WsOperacion.OperacionSoapClient();
            DataTable lTbl = new DataTable(); int i = 0;
            Tx_fechaEnvio.Text = DateTime.Now.ToShortDateString();

            lDts = lPx.ObtenerEtiquetasPorViaje(iCodViaje);
            if (lDts.MensajeError.Trim().Length == 0)
            {
                lTbl = lDts.DataSet.Tables["Etiquetas"].Copy();

                for (i = 0; i < lTbl.Rows.Count; i++)
                {
                    AgregaFila(lTbl.Rows[i]);

                }

                CalculaTotales();

            }
        }

        private void Dtg_EnviosRealizados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int lIndex = e.RowIndex;
            string lFecha = Dtg_EnviosRealizados.Rows[lIndex].Cells["FechaEnvio"].Value.ToString();
            CargaRecepcionEtiquetas(lFecha);

        }

        private void CargaRecepcionEtiquetas(string ifecha)
        {
            //'ObtenerEtiquetasPorViaje'
            WsOperacion.ListaDataSet lDts = new WsOperacion.ListaDataSet();
            WsOperacion.OperacionSoapClient lPx = new WsOperacion.OperacionSoapClient();
            DataTable lTbl = new DataTable(); int i = 0;
            Tx_fechaEnvio.Text = DateTime.Now.ToShortDateString();

            Tx_Dia.Text = ifecha;
            lDts = lPx.ObtenerEnviosParaRecepcion(ifecha);
            if (lDts.MensajeError.Trim().Length == 0)
            {
                lTbl = lDts.DataSet.Tables[0].Copy();

              
                Dtg_Recepcion.DataSource = lTbl;
                if (lTbl .Rows .Count >0)
                { 
                Dtg_Recepcion.Columns[0].Width = 65;
                Dtg_Recepcion.Columns[1].Width = 80;
                Dtg_Recepcion.Columns[2].Width = 70;
                Dtg_Recepcion.Columns[3].Width = 60;
                Dtg_Recepcion.Columns[4].Width = 110;
                Dtg_Recepcion.Columns[5].Width = 90;
                Dtg_Recepcion.Columns[6].Width = 140;
                Dtg_Recepcion.Columns[7].Width = 65;
                }
                CalculaTotales_Recepcion();
                //   PintaFila(Color.LightGreen, i);
                tabControl1.SelectedIndex=2;
            }

        }

        private void PintaDetalleRecepcion()
        {
            int i = 0;
            for (i = 0; i < Dtg_Recepcion.Rows.Count; i++)
            {
                if (Dtg_Recepcion.Rows[i].Cells["ObsNC"].Value.ToString().Length > 0)
                {
                    PintaFila(Color.LightSalmon, i);
                }
                if (Dtg_Recepcion.Rows[i].Cells["OK"].Value.ToString().Length > 0)
                {
                    PintaFila(Color.LightGreen, i);
                }

            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void Btn_Producida_Click(object sender, EventArgs e)
        {
            Clases.ClsComun lCom = new Clases.ClsComun();

            if (lCom.Val(Tx_PaqueteRecep.Text) > 0)
            {
                if (ProcesaEtiqueta(Tx_PaqueteRecep.Text) ==true )
                {
                    DejaEtiquetaComoProducida(Tx_PaqueteRecep.Text);
                    CalculaTotales_Recepcion();
                }
                Tx_PaqueteRecep.Text = "";
            }
        }

        private  void DejaEtiquetaComoProducida(string iIdPaquete)
        {
            string lProdExterna = "";int i = 0; Clases.ClsComun lCom = new Clases.ClsComun();
            string lRes = "";WsOperacion.OperacionSoapClient lPx = new WsOperacion.OperacionSoapClient();

            for (i=0;i< Dtg_Recepcion.Rows .Count;i++)
            {
                if (lCom.Val(Dtg_Recepcion.Rows[i].Cells["Id"].Value.ToString()) == lCom.Val(iIdPaquete))
                {
                    lProdExterna = Dtg_Recepcion.Rows[i].Cells["externo"].Value.ToString();
                    lRes = lPx.GrabarProduccionExterna(iIdPaquete, lProdExterna, 1);
                    if ( lRes.ToUpper ().Equals ("OK"))
                    {
                        Dtg_Recepcion.Rows[i].Cells["OK"].Value = "OK";
                        PintaFila(Color.LightGreen, i);
                        Tx_PaqueteRecep.Text = "";
                        Tx_PaqueteRecep.Focus();
                    }
                }
            }

        }

        private void PintaFila(Color iColor, int iFila)
        {
            int i = 0;

            for (i = 0; i < Dtg_Recepcion.Columns.Count; i++)
            {
                Dtg_Recepcion.Rows[iFila].Cells[i].Style.BackColor = iColor;
            }
        }

        private void Btn_NoConforme_Click(object sender, EventArgs e)
        {
            string lProdExterna = ""; int i = 0; Clases.ClsComun lCom = new Clases.ClsComun();
            string lRes = ""; WsOperacion.OperacionSoapClient lPx = new WsOperacion.OperacionSoapClient();

            for (i = 0; i < Dtg_Recepcion.Rows.Count; i++)
            {
                if (lCom.Val(Dtg_Recepcion.Rows[i].Cells["Id"].Value.ToString()) == lCom.Val(Tx_PaqueteRecep.Text ))
                {
                    lProdExterna = Dtg_Recepcion.Rows[i].Cells["externo"].Value.ToString();
                    lRes = lPx.GrabarNoConformidadProdExt(Tx_PaqueteRecep.Text, Cmb_Problemas .SelectedValue.ToString () , 1);
                    if (lCom.Val(lRes) > 0)
                    {
                        Dtg_Recepcion.Rows[i].Cells["ObsNC"].Value = Cmb_Problemas.SelectedValue.ToString();
                        PintaFila(Color.LightSalmon , i);
                        Tx_PaqueteRecep.Text = "";
                        Tx_PaqueteRecep.Focus();
                    }
                }
            }
            CalculaTotales_Recepcion();
        }

        


        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 2)
            {
                PintaDetalleRecepcion();
            }
        }

        private void Tx_PaqueteRecep_Validated(object sender, EventArgs e)
        {

        }

        private void Dtg_EnviosRealizados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Tx_PaqueteRecep_Validating(object sender, CancelEventArgs e)
        {

            if (Rb_Producida.Checked == true)
            {

                Clases.ClsComun lCom = new Clases.ClsComun();

                if (lCom.Val(Tx_PaqueteRecep.Text) > 0)
                {
                    if (ProcesaEtiqueta(Tx_PaqueteRecep.Text) == true)
                    {
                        DejaEtiquetaComoProducida(Tx_PaqueteRecep.Text);
                        CalculaTotales_Recepcion();
                    }
                    Tx_PaqueteRecep.Text = "";
                }
            }
            else
            {
                string lProdExterna = ""; int i = 0; Clases.ClsComun lCom = new Clases.ClsComun();
                string lRes = ""; WsOperacion.OperacionSoapClient lPx = new WsOperacion.OperacionSoapClient();

                for (i = 0; i < Dtg_Recepcion.Rows.Count; i++)
                {
                    if (lCom.Val(Dtg_Recepcion.Rows[i].Cells["Id"].Value.ToString()) == lCom.Val(Tx_PaqueteRecep.Text))
                    {
                        lProdExterna = Dtg_Recepcion.Rows[i].Cells["externo"].Value.ToString();
                        lRes = lPx.GrabarNoConformidadProdExt(Tx_PaqueteRecep.Text, Cmb_Problemas.SelectedValue.ToString(), 1);
                        if (lCom.Val(lRes) > 0)
                        {
                            Dtg_Recepcion.Rows[i].Cells["ObsNC"].Value = Cmb_Problemas.SelectedValue.ToString();
                            PintaFila(Color.LightSalmon, i);
                            Tx_PaqueteRecep.Text = "";
                            Tx_PaqueteRecep.Focus();
                        }
                    }
                }
                CalculaTotales_Recepcion();

            }

                       
        }

        private void Tx_PaqueteRecep_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                this.Tx_PaqueteRecep_Validating(null, null);
            }
        }
    }
}
