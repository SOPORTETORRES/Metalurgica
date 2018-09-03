using System;
using System.Windows.Forms;
using CommonLibrary2;
using System.Drawing;
using System.Text;
using System.Data;
using System.IO;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;
using System.Drawing.Printing;
using System.Configuration;

namespace Metalurgica
{
    public partial class frmRecepcionColada : Form
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern SafeFileHandle CreateFile(string lpFileName, FileAccess dwDesiredAccess, uint dwShareMode, IntPtr lpSecurityAttributes, FileMode dwCreationDisposition, uint dwFlagsAndAttributes, IntPtr hTemplateFile);

        private CurrentUser mUserLog = new CurrentUser();
        private const string COLUMNNAME_MARCA = "MARCA";
        private const string COLUMNNAME_ETIQUETA_COLADA = "ETIQUETA_COLADA";
        private Clases.TipoImprimeColada mObjImpCol = new Clases.TipoImprimeColada();

        public frmRecepcionColada()
        {
            InitializeComponent();
            this.dgvRecepciones.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(dgvRecepciones_RowPostPaint);
            this.dgvEtiquetasColadas.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(dgvEtiquetasColadas_RowPostPaint);
            this.dgvDespachosBodegaMP.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(dgvDespachosBodegaMP_RowPostPaint);
            Clases.ClsComun lCom = new Clases.ClsComun();
            this.Text += " - versión: " + lCom.ObtenerVersionRC();  
        }

        private void dgvRecepciones_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvRecepciones.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvEtiquetasColadas_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvEtiquetasColadas.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDespachosBodegaMP_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDespachosBodegaMP.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void tlbNuevo_Click(object sender, EventArgs e)
        {
            switch (tabOperaciones.SelectedIndex)
            {
                case 0:
                    tlbDesactivar.Enabled = false;
                    lblId.Text = "0";
                    //txtPatente.Clear();
                    lblTransportista.Text = ".";
                    txtColada.Clear();
                    lblDiametro.Text = ".";
                    lblLargo.Text = ".";
                    lblNroCertificado.Text = ".";
                    LblKilos.Text = "0";
                    txtPatente.Focus();
                    break;
                case 1:
                    txtBodegaMP.Clear();
                    txtObs.Clear();
                    txtEtiquetaColada.Clear();
                    dgvEtiquetasColadas.DataSource = null;
                    lblCantidadEtiquetasColadas.Text = "Registro(s): 0";
                    txtBodegaMP.Focus();
                    break;
            }
        }

        private string eliminarCaracteresEspeciales(string entrada)
        {
            StringUtility stringUtility = new StringUtility();
            string salida = entrada;
            if (!salida.Trim().Equals(""))
                salida = stringUtility.removeInvalidCharacters(salida, stringUtility.RegexPattern_Address);
            return salida;
        }

        private string validarControlesRequeridos()
        {
            StringBuilder sb = new StringBuilder();

            switch (tabOperaciones.SelectedIndex)
            {
                case 0:
                    //if (txtPatente.Text.Trim().Equals(""))
                    //    sb.Append("- Patente\n");
                    if (txtColada.Text.Trim().Equals(""))
                        sb.Append("- Colada\n");
                    break;
                case 1:
                    if (txtBodegaMP.Text.Trim().Equals(""))
                        sb.Append("- Bodega MP\n");
                    if (!txtBodegaMP.Text.Trim().Equals("") && !new CommonLibrary2.Information().isNumber(txtBodegaMP.Text))
                        sb.Append("- Bodega MP (valor numérico)\n");
                    if (dgvEtiquetasColadas.Rows.Count == 0)
                        sb.Append("- Etiqueta(s)\n");
                    break;
            }
            return sb.ToString();
        }

        private void tlbGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = validarControlesRequeridos();
            if (mensaje.Equals(""))
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();

                    switch (tabOperaciones.SelectedIndex)
                    {
                        case 0:
                            //WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
                            WsOperacion.Recepcion_Colada recepcion_colada = new WsOperacion.Recepcion_Colada();

                            recepcion_colada.Id = 0; //Convert.ToInt32(lblId.Text);
                            recepcion_colada.Colada = txtColada.Text;
                            recepcion_colada.Camion = txtPatente.Text;
                            recepcion_colada.Usuario = Program.currentUser.Login;

                            recepcion_colada = wsOperacion.GuardarRecepcion_Colada(recepcion_colada, Program.currentUser.ComputerName);
                            if (recepcion_colada.MensajeError.Equals(""))
                            {
                                tlbActualizar.PerformClick();
                                MessageBox.Show("Registro guardado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                                MessageBox.Show(recepcion_colada.MensajeError.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case 1:
                            WsOperacion.Despacho_Bodega_MP despacho_Bodega_MP = new WsOperacion.Despacho_Bodega_MP();

                            despacho_Bodega_MP.Id = 0;
                            despacho_Bodega_MP.Bodega_Id = Convert.ToInt32(txtBodegaMP.Text);
                            despacho_Bodega_MP.Usuario = Program.currentUser.Login;
                            //despacho_Bodega_MP.Fecha = ""; 
                            despacho_Bodega_MP.Obs = txtObs.Text;

                            despacho_Bodega_MP = wsOperacion.GuardarDespachoColadaBodegaMP(despacho_Bodega_MP, Program.currentUser.ComputerName);
                            if (despacho_Bodega_MP.MensajeError.Equals(""))
                            {
                                int idDespacho = despacho_Bodega_MP.Id;

                                foreach (DataGridViewRow row in dgvEtiquetasColadas.Rows)
                                {
                                    despacho_Bodega_MP = wsOperacion.AsociarEtiquetaColadaaBodegaMP(idDespacho, row.Cells[COLUMNNAME_ETIQUETA_COLADA].Value.ToString(), Program.currentUser.Login, Program.currentUser.ComputerName);
                                    if (despacho_Bodega_MP.MensajeError.Equals(""))
                                    {
                                        //tlbActualizar.PerformClick();
                                        //MessageBox.Show("Registro(s) guardado(s).", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                        MessageBox.Show(despacho_Bodega_MP.MensajeError.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                //tlbNuevo.PerformClick();
                                tlbNuevo_Click(sender, e);
                                MessageBox.Show("Registro(s) guardado(s).", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                                MessageBox.Show(despacho_Bodega_MP.MensajeError.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Cursor.Current = Cursors.Default;
            }
            else
                MessageBox.Show("Debe ingresar los siguientes datos requeridos:\n\n" + mensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void tlbEliminar_Click(object sender, EventArgs e)
        {

        }

        private void tlbDesactivar_Click(object sender, EventArgs e)
        {
            if (!lblId.Text.Trim().Equals("0"))
            {
                if (MessageBox.Show("¿Esta seguro que desea anular esta recepcion?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    try
                    {
                        WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
                        WsOperacion.Recepcion_Colada recepcion_colada = new WsOperacion.Recepcion_Colada();

                        recepcion_colada.Id = Convert.ToInt32(lblId.Text);
                        recepcion_colada.Colada = txtColada.Text;
                        recepcion_colada.Usuario = Program.currentUser.Login;

                        recepcion_colada = wsOperacion.DesactivarRecepcion_Colada(recepcion_colada, Program.currentUser.ComputerName);
                        if (recepcion_colada.MensajeError.Equals(""))
                        {
                            tlbActualizar.PerformClick();
                            MessageBox.Show("Recepcion anulada.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show(recepcion_colada.MensajeError.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        private void BloquearColumnas()
        {
            foreach (DataGridViewColumn column in dgvRecepciones.Columns)
            {
                if (column.Index > 0)
                    column.ReadOnly = true;               
            }

            int i = 0;
            for (i = 0; i < dgvRecepciones.Columns.Count; i++)
            {
                if (i > 12)
                {
                    dgvRecepciones.Columns[i].Visible = false;
                }
            }

        }

        private void tlbActualizar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                WsOperacion.OperacionSoapClient wsOperacion1 = new WsOperacion.OperacionSoapClient();
                WsOperacion.ListaDataSet listaDataSet = new WsOperacion.ListaDataSet();
                String lBodega = ConfigurationManager.AppSettings["Bodega"].ToString();

                switch (tabOperaciones.SelectedIndex)
                {
                    case 0:
                        listaDataSet = wsOperacion1.ListarRecepcionColadaPorBodega(dtpFechaRecepcion.Value,lBodega );
                        if (listaDataSet.MensajeError.Equals(""))
                        {
                            dgvRecepciones.DataSource = listaDataSet.DataSet.Tables[0];
                            if (!new Forms().dataGridViewExistsColumn(dgvRecepciones, COLUMNNAME_MARCA))
                            {
                                DataGridViewCheckBoxColumn check = new DataGridViewCheckBoxColumn();
                                check.Name = COLUMNNAME_MARCA;
                                dgvRecepciones.Columns.Insert(0, check);
                            }
                            BloquearColumnas();
                            //tlbNuevo.PerformClick();
                            tlbNuevo_Click(sender, e);
                            Forms forms = new Forms();
                            forms.dataGridViewHideColumns(dgvRecepciones, new string[] { "ID", "REC_ESTADO" });
                            forms.dataGridViewAutoSizeColumnsMode(dgvRecepciones, DataGridViewAutoSizeColumnsMode.DisplayedCells);
                            tlbEstado.Text = "Registro(s): " + dgvRecepciones.Rows.Count;
                        }
                        else
                            MessageBox.Show(listaDataSet.MensajeError.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 1:
                        break;
                    case 2:
                        if (!txtBodegaMP.Text.Trim().Equals(""))
                        {
                            lblBodegaMP.Text = txtBodegaMP.Text;
                            listaDataSet = wsOperacion1.ListarDespachoBodegaMP(Convert.ToInt32(txtBodegaMP.Text));
                            if (listaDataSet.MensajeError.Equals(""))
                            {
                                dgvDespachosBodegaMP.DataSource = listaDataSet.DataSet.Tables[0];
                                Forms forms = new Forms();
                                //forms.dataGridViewHideColumns(dgvDespachosBodegaMP, new string[] { "ID", "REC_ESTADO" });
                                forms.dataGridViewAutoSizeColumnsMode(dgvDespachosBodegaMP, DataGridViewAutoSizeColumnsMode.DisplayedCells);
                                //tlbEstado.Text = "Registro(s): " + dgvDespachosBodegaMP.Rows.Count;
                                lblCantidadDespachosBodegaMP.Text = "Registro(s): " + dgvDespachosBodegaMP.Rows.Count;
                                FormateaColumnas();
                            }
                            else
                                MessageBox.Show(listaDataSet.MensajeError.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Default;
        }

        //private void imprimirRegistro(DataGridViewRow row)
        //{
        //    //Cursor.Current = Cursors.WaitCursor;
        //    WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
        //    WsOperacion.Recepcion_Colada recepcion_colada = new WsOperacion.Recepcion_Colada();

        //    recepcion_colada.Id = Convert.ToInt32(lblId.Text);
        //    recepcion_colada.Colada = txtColada.Text;
        //    recepcion_colada.Usuario = Program.currentUser.Login;

        //    recepcion_colada = wsOperacion.ImprimirRecepcion_Colada(recepcion_colada, Program.currentUser.ComputerName);
        //    if (recepcion_colada.MensajeError.Equals(""))
        //    {
        //        //tlbActualizar.PerformClick();
        //        //MessageBox.Show("Registro guardado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    else
        //        MessageBox.Show(recepcion_colada.MensajeError.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

        //    //Cursor.Current = Cursors.Default;
        //}
        private void FormateaColumnas ()
        {
            dgvDespachosBodegaMP.Columns["Rec_id"].Visible = false;
            dgvDespachosBodegaMP.Columns["Rec_Usuario"].Visible = false;
            dgvDespachosBodegaMP.Columns["Rec_Eti_usuario"].Visible = false;
            dgvDespachosBodegaMP.Columns["Rec_Eti_Fecha"].Visible = false;

            dgvDespachosBodegaMP.Columns["Rec_des_Mp_Id"].Visible = false;
            dgvDespachosBodegaMP.Columns["Des_Mp_Id"].Visible = false;
            dgvDespachosBodegaMP.Columns["Des_Mp_Bod_Id"].Visible = false;
            dgvDespachosBodegaMP.Columns["Des_Mp_Usuario"].Visible = false;
            dgvDespachosBodegaMP.Columns["Des_Mp_Fecha"].Visible = false;
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


        private void tlbImprimir_Click(object sender, EventArgs e)
        {
            StringBuilder archivoSalida = new StringBuilder();
            string diametro = ".", largo = ".", nroCertificado = ".", kilos = "0"; string Procedencia = "";
            string NroPaq = ""; string lTmp = ""; string lNroColada = ""; int IdPaqColada = 0;
            string lNroBarras = ""; string lNroColadaTmp = ""; string lKgsTmp = "";

            txtPatente.Focus();
            int counter = new Forms().dataGridViewCountRowsChecked(dgvRecepciones, COLUMNNAME_MARCA);
            if (counter > 0)
            {
                Registry registry = new Registry();
                //string impresora_etiquetas = "Godex EZ2250i"; //(string)registry.GetValue(Program.regeditKeyName, "Impresora_etiquetas", "");
                string impresora_etiquetas =(string)registry.GetValue(Program.regeditKeyName, "Impresora_etiquetas", "");
                if (!impresora_etiquetas.Equals(""))
                {
                    Cursor.Current = Cursors.WaitCursor;
                    try
                    {
                        WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
                        WsOperacion.Recepcion_Colada recepcion_colada = new WsOperacion.Recepcion_Colada();

                        foreach (DataGridViewRow row in dgvRecepciones.Rows)
                        {
                            if (row.Cells[COLUMNNAME_MARCA].Value != null)
                            {
                               
                                if ((bool)row.Cells[COLUMNNAME_MARCA].Value == true)
                                {
                                    recepcion_colada.Id = Convert.ToInt32(row.Cells[1].Value.ToString());
                                    //recepcion_colada.Colada = row.Cells[2].Value.ToString();
                                    recepcion_colada.Colada = row.Cells["COLADA"].Value.ToString();
                                    recepcion_colada.Etiqueta_colada = row.Cells["ETIQUETA_COLADA"].Value.ToString();
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
                                    lNroBarras = "";
                                    lNroColadaTmp = "";
                                    lNroBarras = "";
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
                                            if (dt.Rows[0]["Soldable"].ToString().ToUpper().Equals("S"))
                                            {
                                                //lNroColada = string.Concat(lNroColada, " -    SOLDABLE   ");
                                                lNroColadaTmp = string.Concat(lNroColada, " -    SOLDABLE   ");
                                            }
                                            else
                                            { lNroColadaTmp = string.Concat(lNroColada); 
                                            }

                                           
                                           
                                            kilos = (kilos.Equals("") ? "0" : kilos);
                                            //CodInterno=""
                                        }
                                    }
                                    //<Etiqueta>
                                    //
                                    int i = 0; Clases.TipoImprimeColada lObjImpColada = new Clases.TipoImprimeColada();
                                    listaDataSet = ObtenerDetalleColada(recepcion_colada.Colada);
                                    if (listaDataSet.MensajeError.Equals(""))
                                    {
                                        DataTable dt = listaDataSet.DataSet.Tables[0];
                                        for (i = 0; i < dt.Rows .Count ; i++)
                                        {
                                            lNroBarras = dt.Rows[i]["NroBarras"].ToString ();
                                            IdPaqColada = (int)dt.Rows[i]["Id"];
                                            lKgsTmp = string.Concat(dt.Rows[i]["KilosCalculados"].ToString(), " kgs  - Nro. Barras:", lNroBarras);
                                            kilos = string.Concat(dt.Rows[i]["KilosCalculados"].ToString(), " kgs.");
                                            NroPaq = string.Concat(dt.Rows[i]["NroPaquete"].ToString(), " de ", dt.Rows[i]["TotalPaquetes"].ToString());
                                            lTmp = "Largo: " + largo + " (mm) - Diametro: " + diametro;

                                            lObjImpColada.Procedencia = Procedencia;
                                            lObjImpColada.Colada = lNroColadaTmp;
                                            lObjImpColada.Largo_Diametr = lTmp;
                                            lObjImpColada.Kilos = lKgsTmp;
                                            lObjImpColada.NroPaq = NroPaq;
                                            lObjImpColada.IdPaqueteColada = IdPaqColada.ToString();
                                            lObjImpColada.Resumen  = string.Concat(IdPaqColada, "     ", lNroColada, "-", kilos);

                                            EnviaImpresion(lObjImpColada);
                                            //----------------------------
                                           
                                           // archivoSalida = new StringBuilder ();
                                           // archivoSalida.Append("A155,10,0,4,1,1,N,\"Procedencia: " + Procedencia + "\"" + Environment.NewLine);
                                           // //archivoSalida.Append("A155,40,0,4,1,1,N,\"Colada: " + lNroColada + "\"" + Environment.NewLine);
                                           // archivoSalida.Append("A155,40,0,4,1,1,N,\"Colada: " + lNroColadaTmp + "\"" + Environment.NewLine);
                                           // archivoSalida.Append("A155,70,0,4,1,1,N,\"" + lTmp + "\"" + Environment.NewLine);
                                           // //   archivoSalida.Append("A155,70,0,4,1,1,N,\"Largo: " + largo + "\"" + Environment.NewLine);
                                           // // archivoSalida.Append("A155,100,0,4,1,1,N,\"Diametro: " + diametro + "\"" + Environment.NewLine);
                                           //// lTmp = "Peso: " + kilos + " kgs.   -  Barras: " + diametro;
                                           // archivoSalida.Append("A155,100,0,4,1,1,N,\"Peso: " + lKgsTmp + " \"" + Environment.NewLine);
                                           // archivoSalida.Append("A155,130,0,4,1,1,N,\"Nro. Paquete: " + NroPaq.ToString() + " \"" + Environment.NewLine);
                                           // // archivoSalida.Append("A155,240,0,4,1,1,N,\"Nro.Certificado: " + nroCertificado + "\"" + Environment.NewLine);
                                           // //archivoSalida.Append("B155,180,0,1,2,2,80,N,\"" + recepcion_colada.Etiqueta_colada + "\"" + Environment.NewLine);
                                           // //archivoSalida.Append("A155,270,0,4,1,1,N,\"" + recepcion_colada.Etiqueta_colada + "\"" + Environment.NewLine);                                            
                                           // //por modificaciones se debe imprimir el ID de paquete para 
                                           // archivoSalida.Append("B155,180,0,1,2,2,80,N,\"" + IdPaqColada + "\"" + Environment.NewLine);
                                           // lTmp = string.Concat(IdPaqColada, "     ", lNroColada, "-", kilos);
                                           // //archivoSalida.Append("A155,270,0,4,1,1,N,\"" + IdPaqColada + "\"" + Environment.NewLine);
                                           // archivoSalida.Append("A155,270,0,4,1,1,N,\"" + lTmp + "\"" + Environment.NewLine);
                                           // archivoSalida.Append("P1" + Environment.NewLine);
                                           // archivoSalida.Append("N" + Environment.NewLine);
                                            
                                           //// archivoSalida.Append("A155,270,0,4,1,1,N,\"" + lTmp + "\"" + Environment.NewLine);
                                           // //</Etiqueta>                                            
                                           // imprimirEtiquetas(archivoSalida, impresora_etiquetas);
                                        }
                                    }
                                   

                                    recepcion_colada = wsOperacion.ImprimirRecepcion_Colada(recepcion_colada, Program.currentUser.ComputerName);
                                    if (recepcion_colada.MensajeError.Equals(""))
                                        row.Cells[0].Value = false;
                                    else
                                        MessageBox.Show(recepcion_colada.MensajeError.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        //imprimirEtiquetas(archivoSalida, impresora_etiquetas);

                       
                        tlbActualizar.PerformClick();
                        MessageBox.Show("Impresion finalizada.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            else
                MessageBox.Show("No existen registros seleccionados.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        

        //using System.Diagnostics; --> Shell
        //using System.IO;          --> Escribir el archivo
        //private void imprimirEtiquetas(StringBuilder archivoSalida, string impresora_etiquetas)
        //{
        //    string FILE_NAME = string.Concat(Application.StartupPath, "\\Etiquetas.txt"); //  @"c:\Etiquetas.txt";
        //    try
        //    {
        //        //Seteo de la impresora
        //        archivoSalida.Insert(0, seteoImpresora());

        //        using (StreamWriter sw = File.CreateText(FILE_NAME))
        //        {
        //            sw.WriteLine(archivoSalida);
        //            sw.Close();
        //        }
        //        string commandToExecute = "type " + FILE_NAME + " > " + impresora_etiquetas;
        //        System.Diagnostics.Process.Start(@"cmd", @"/c " + commandToExecute);
        //    }
        //    catch (Exception exc)
        //    {
        //        MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

            private void EnviaImpresion(Clases .TipoImprimeColada iObj)
            {
               PrintDocument  printDoc= new PrintDocument ();
        //' asignamos el método de evento para cada página a imprimir
               mObjImpCol = iObj;
               //printDocument1_PrintPage
               printDoc.PrintPage += new PrintPageEventHandler(this.printDocument1_PrintPage);
        //AddHandler printDoc.PrintPage, AddressOf PrintDocument1_PrintPage //'print_PrintPage

        //'Seteamos la impresora
                PaperSize TamañoPersonal = new PaperSize ();
                int Ancho = 900; int Alto = 2000; int i = 0;
        //Dim Ancho As Short = 900
        //Dim Alto As Short = 2000, i As Integer = 0

        printDoc.Print();


            }



        private bool imprimirEtiquetas(StringBuilder archivoSalida, string impresora_etiquetas)
        {          
            //Impresora Zebra 2013-05-09
            bool isPrinter = false;
            Clases.ClsComun lCn = new Clases.ClsComun();
            //Seteo de la impresora
            archivoSalida.Insert(0, lCn.seteoImpresora());

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



        private void tlbExportar_Click(object sender, EventArgs e)
        {
            DataGridView dgvActiva = null;

            switch (tabOperaciones.SelectedIndex)
            {
                case 0:
                    dgvActiva = dgvRecepciones;
                    break;
                case 1:
                    dgvActiva = dgvEtiquetasColadas;
                    break;
                case 2:
                    dgvActiva = dgvDespachosBodegaMP;
                    break;
            }
            if (dgvActiva != null)
            { 
                if (dgvActiva.Rows.Count > 0)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    new Excel().exportar(dgvActiva);
                    Cursor.Current = Cursors.Default;
                }
                else
                    MessageBox.Show("No existen registros a exportar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tlbSalir_Click(object sender, EventArgs e)

        {
            ValidarSalir();
            Application.Exit();
        }

        protected virtual void ValidarSalir()
        {
            //Salir();
            // registramos que el usuario  salio de sistema 
            WsSesion.WS_SesionSoapClient lSesion = new WsSesion.WS_SesionSoapClient();
            string lRes = "";

            lRes = lSesion.RegistraLogOUT(mUserLog.Iduser.ToString(), mUserLog.IdMaquina.ToString());



        }
        private void dgvDetalle_DoubleClick(object sender, EventArgs e)
        {
            DataGridViewRow currentRow = dgvRecepciones.CurrentRow;
            if (currentRow != null)
            {
                tlbDesactivar.Enabled = true;
                lblId.Text = currentRow.Cells[1].Value.ToString();
                txtPatente.Text = currentRow.Cells["CAMION"].Value.ToString();
                txtColada.Text = currentRow.Cells["COLADA"].Value.ToString();
                txtCamion_Validating(sender, new System.ComponentModel.CancelEventArgs());
                txtColada_Validating(sender, new System.ComponentModel.CancelEventArgs());
                txtPatente.Focus();
            }
        }

        private void frmRecepcionColada_Shown(object sender, EventArgs e)
        {
            tlbActualizar_Click(sender, e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    this.SelectNextControl(this.ActiveControl, true, true, true, true);
                    //e.SuppressKeyPress = true;
                    break;
                default:
                    base.OnKeyDown(e);
                    break;
            }
        }

        private void btnHlpColada_Click(object sender, EventArgs e)
        {
            Coladas.Frm_IngresoColada lFrm = new Coladas.Frm_IngresoColada();
            String lBodega=  ConfigurationManager.AppSettings["Bodega"].ToString();
            lFrm.IniciaForm("B", lBodega,"N");
            lFrm.ShowDialog();
            string lRes = "";
            if (AppDomain.CurrentDomain.GetData("IdColada") != null)
            {
                lRes = AppDomain.CurrentDomain.GetData("IdColada").ToString();
                txtColada.Text = lRes;
                txtColada.Focus();
            }
        }

        private void btnCrudColada_Click(object sender, EventArgs e)
        {
            Coladas.Frm_IngresoColada lFrm = new Coladas.Frm_IngresoColada();
            String lBodega = ConfigurationManager.AppSettings["Bodega"].ToString();
            lFrm.IniciaForm("N", lBodega, "N");
            lFrm.ShowDialog();
            string lRes = "";
            if  (AppDomain.CurrentDomain.GetData("NroColada")!= null)
            {
                lRes = AppDomain.CurrentDomain.GetData("NroColada").ToString();
                txtColada.Text = lRes;
                AppDomain.CurrentDomain.SetData("NroColada", null);
                txtColada_Validating(null, null);
                ////txtColada.Focus();
            }
          
        }

        private void btnHlpCamion_Click(object sender, EventArgs e)
        {
            txtPatente_KeyUp(sender, new KeyEventArgs(Keys.F1));
        }

        private void btnCrudCamion_Click(object sender, EventArgs e)
        {
            new frmCrudCamion().ShowDialog();
            txtPatente.Focus();
        }

        private void dtpFechaRecepcion_ValueChanged(object sender, EventArgs e)
        {
            tlbActualizar.PerformClick();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new frmCrudMaquina().ShowDialog();
        }

        private void btnCrudBodega_Click(object sender, EventArgs e)
        {
            new frmCrudBodega0().ShowDialog();
            txtBodegaMP.Focus();
        }

        private void tabOperaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool visible = tabOperaciones.SelectedIndex == 0;
            tlbGuardar.Visible = visible || tabOperaciones.SelectedIndex == 1;
            tlbDesactivar.Visible = visible;
            tlbActualizar.Visible = visible || tabOperaciones.SelectedIndex == 2;
            tlbImprimir.Visible = visible;

            switch (tabOperaciones.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    txtBodegaMP.Focus();
                    break;
                case 2:
                    break;
            }
        }

        private void txtCamion_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!txtPatente.Text.Trim().Equals(""))
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    lblTransportista.Text = ".";

                    WsCrud.CrudSoapClient wsCrud = new WsCrud.CrudSoapClient();
                    WsCrud.Camion camion = new WsCrud.Camion();

                    camion = wsCrud.ObtenerCamion(txtPatente.Text); //Patente
                    if (camion.MensajeError.Equals(""))
                    {
                        if (camion.Activo.Equals("S"))
                            lblTransportista.Text = camion.Transportista;
                        else
                        {
                            MessageBox.Show("El camión '" + txtPatente.Text + "' no existe o esta inactivo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            e.Cancel = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show(camion.MensajeError.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Cursor.Current = Cursors.Default;
            }
        }

        private void txtBodegaMP_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!txtBodegaMP.Text.Trim().Equals(""))
            {
                if (new CommonLibrary2.Information().isNumber(txtBodegaMP.Text))
                {
                    Cursor.Current = Cursors.WaitCursor;
                    try
                    {
                        //lblTransportista.Text = ".";

                        WsCrud.CrudSoapClient wsCrud = new WsCrud.CrudSoapClient();
                        WsCrud.Bodega bodega = new WsCrud.Bodega();

                        bodega = wsCrud.ObtenerBodega(Convert.ToInt32(txtBodegaMP.Text)); //Bodega
                        if (bodega.MensajeError.Equals(""))
                        {
                            if (bodega.Activa.Equals("S") && bodega.Tipo.Equals("0"))
                            {
                                //    lblTransportista.Text = camion.Transportista;
                            }
                            else
                            {
                                MessageBox.Show("La bodega '" + txtBodegaMP.Text + "' no existe, esta inactiva o no es una bodega de MP.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                e.Cancel = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show(bodega.MensajeError.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            e.Cancel = true;
                        }
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    Cursor.Current = Cursors.Default;
                }
                else
                {
                    MessageBox.Show("Debe ingresar un valor numérico.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                }
            }
        }

        private void txtBodegaMP_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtEtiquetaColada_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Forms forms = new Forms();

            if (!txtEtiquetaColada.Text.Trim().Equals(""))
            {
                if (forms.dataGridViewSearchText(dgvEtiquetasColadas, COLUMNNAME_ETIQUETA_COLADA, txtEtiquetaColada.Text) == -1)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    try
                    {
                        WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
                        WsOperacion.ListaDataSet listaDataSet = new WsOperacion.ListaDataSet();

                        listaDataSet = wsOperacion.ObtenerRecepcionxEtiqueta_Colada(txtEtiquetaColada.Text);
                        if (listaDataSet.MensajeError.Equals(""))
                        {
                            if (listaDataSet.DataSet.Tables[0].Rows.Count > 0)
                            {
                                if (dgvEtiquetasColadas.DataSource == null)
                                    dgvEtiquetasColadas.DataSource = listaDataSet.DataSet.Tables[0];
                                else
                                {
                                    DataTable dataTable = (DataTable)dgvEtiquetasColadas.DataSource;
                                    DataRow row = dataTable.NewRow();

                                    foreach (DataGridViewColumn column in dgvEtiquetasColadas.Columns)
                                    {
                                        row[column.Index] = listaDataSet.DataSet.Tables[0].Rows[0][column.Index];
                                    }
                                    dataTable.Rows.Add(row);
                                }
                                //tlbNuevo.PerformClick();
                                //Forms forms = new Forms();
                                forms.dataGridViewHideColumns(dgvEtiquetasColadas, new string[] { "ID", "REC_ESTADO" });
                                forms.dataGridViewAutoSizeColumnsMode(dgvEtiquetasColadas, DataGridViewAutoSizeColumnsMode.DisplayedCells);
                                //tlbEstado.Text = "Registro(s): " + dgvRecepciones.Rows.Count;
                                lblCantidadEtiquetasColadas.Text = "Registro(s): " + dgvEtiquetasColadas.Rows.Count;
                            }
                            else
                                MessageBox.Show("La etiqueta '" + txtEtiquetaColada.Text + "' no existe.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                else
                {

                }
                txtEtiquetaColada.Clear();
                txtEtiquetaColada.Focus();
            }
        }

        private WsOperacion.ListaDataSet ObtenerDatosColadaPorId( string iIdColada)
        {
             WsOperacion.ListaDataSet lDts= new WsOperacion.ListaDataSet() ;string lSql="";
            Ws_TO .Ws_ToSoapClient  lDal= new Ws_TO .Ws_ToSoapClient  ();
            try
            {
// [SP_ConsultasGenerales]   @Opcion INT, @Par1 Varchar(100), @Par2 Varchar(100), @Par3 Varchar(100),
//@Par4 Varchar(100),//@Par5 Varchar(100)
                lSql=string.Concat ("exec SP_ConsultasGenerales 25,'",iIdColada .ToString (),"','','','',''");
                lDts.DataSet = lDal.ObtenerDatos(lSql);
                lDts.MensajeError = "";
            }
        catch (Exception exc)
            {
                lDts.MensajeError = exc.Message .ToString ();
            }
            return lDts;

        }
        private void txtColada_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!txtColada.Text.Trim().Equals(""))
            {
                //if (new CommonLibrary2.Information().isNumber(txtColada.Text))
                //{
                    Cursor.Current = Cursors.WaitCursor;
                    try
                    {
                        lblDiametro.Text = ".";
                        lblLargo.Text = ".";
                        lblNroCertificado.Text = ".";

                        //Px_Ws_InterfazProd.Ws_InterfazProdSoapClient ldal = new Px_Ws_InterfazProd.Ws_InterfazProdSoapClient();
                        //DataSet lDts = ldal.ObtenerColadasPorNro(txtColada.Text.Trim());
                        //DataTable dt = lDts.Tables[0];

                        try
                        {
                            WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
                            WsOperacion.ListaDataSet listaDataSet = new WsOperacion.ListaDataSet();
                            //listaDataSet = wsOperacion.ObtenerColadasPorNro(txtColada.Text.Trim());
                            listaDataSet = ObtenerDatosColadaPorId(txtColada.Text.Trim());

                            if (listaDataSet.MensajeError.Equals(""))
                            {
                                DataTable dt = listaDataSet.DataSet.Tables[0];
                                if (dt.Rows.Count > 0)
                                {
                                    lblDiametro.Text = dt.Rows[0]["DIAMETRO"].ToString();
                                    lblLargo.Text = dt.Rows[0]["LARGO"].ToString();
                                    lblNroCertificado.Text = dt.Rows[0]["NROCERTIFICADO"].ToString();
                                    this.LblKilos .Text = dt.Rows[0]["KILOSColada"].ToString();
                                    this.lblId .Text = dt.Rows[0]["ID"].ToString();

                                }
                                else
                                {
                                    MessageBox.Show("La colada '" + txtColada.Text + "' no existe.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    e.Cancel = true;
                                }
                            }
                        }
                        catch (Exception exc)
                        {
                            MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    Cursor.Current = Cursors.Default;
                //}
                //else
                //{
                //    MessageBox.Show("Debe ingresar un valor numérico.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    e.Cancel = true;
                //}
            }
        }

        private void txtPatente_Leave(object sender, EventArgs e)
        {
            txtPatente.Text = eliminarCaracteresEspeciales(txtPatente.Text.Trim()).ToUpper();
        }

        private void frmRecepcionColada_Load(object sender, EventArgs e)
        {
            tlbActualizar.PerformClick();
        }
        public void IniciaFormulario(CurrentUser iUserLog)
        {
            mUserLog = iUserLog;
            ctlInformacionUsuario1.CargaDatosUserLog(iUserLog);
        }
        private void txtColada_Leave(object sender, EventArgs e)
        {
            txtColada.Text = eliminarCaracteresEspeciales(txtColada.Text.Trim());
        }

        private void txtBodegaMP_Leave(object sender, EventArgs e)
        {
            txtBodegaMP.Text = eliminarCaracteresEspeciales(txtBodegaMP.Text.Trim());
        }

        private void txtObs_Leave(object sender, EventArgs e)
        {
            txtObs.Text = eliminarCaracteresEspeciales(txtObs.Text.Trim());
        }

        private void txtEtiquetaColada_Leave(object sender, EventArgs e)
        {
            txtEtiquetaColada.Text = eliminarCaracteresEspeciales(txtEtiquetaColada.Text.Trim());
        }

        private void txtPatente_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                CommonHelp.frmHelp frmHelp = new CommonHelp.frmHelp();                
                frmHelp.setShowHelp("Busca: Camiones", "patente", txtPatente.Text, "Muestra un listado de los camiones activos.", "SELECT patente, transportista, observacion FROM vw_camion WHERE activo = 'S'", "");
                frmHelp.ShowDialog();
                if (frmHelp.getResultRow() != null)
                {
                    txtPatente.Text = frmHelp.getResultRow()[0].ToString();
                    lblTransportista.Text = frmHelp.getResultRow()[1].ToString();                    
                    txtColada.Focus();
                }
                frmHelp.Dispose();
            }
        }

        private void btnHlpBodega_Click(object sender, EventArgs e)
        {
            txtBodegaMP_KeyUp(sender, new KeyEventArgs(Keys.F1));
        }

        private void txtBodegaMP_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                CommonHelp.frmHelp frmHelp = new CommonHelp.frmHelp();
                frmHelp.setShowHelp("Busca: Bodegas de MP", "nombre", "", "Muestra un listado de las bodegas de MP activas.", "SELECT id, nombre, descripcion FROM vw_bodega WHERE bod_tipo=0 and activa='S'", "");
                frmHelp.ShowDialog();
                if (frmHelp.getResultRow() != null)
                {
                    txtBodegaMP.Text = frmHelp.getResultRow()[0].ToString();
                    txtObs.Focus();
                }
                frmHelp.Dispose();
            }
        }

        private void Btn_REEtiquetar_Click(object sender, EventArgs e)
        {
            Frm_ReEtiquetar lFrm = new Frm_ReEtiquetar();
            lFrm.ShowDialog(this);
        }

        private void Btn_Consumo_Click(object sender, EventArgs e)
        {
            try
            {
                Integracion_INET.Frm_Movimientos lFrm = new Integracion_INET.Frm_Movimientos();
                lFrm.ShowDialog(this);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
        }

        private void dgvRecepciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Btn_MtoMP_Click(object sender, EventArgs e)
        {
            Frm_MtoMPrima lForm = new Frm_MtoMPrima();
            lForm.IniciaForm();
            lForm.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {


            e.Graphics.DrawString(String .Concat ("Procedencia: ",mObjImpCol .Procedencia ), new System.Drawing.Font("Arial", 10, FontStyle.Bold), Brushes.Black, 20, 20);
            e.Graphics.DrawString(String .Concat ("Colada     : ",mObjImpCol.Colada  ), new System.Drawing.Font("Arial", 10, FontStyle.Bold), Brushes.Black, 20, 35);
            e.Graphics.DrawString(String .Concat ("Largo      : ",mObjImpCol.Largo_Diametr   ), new System.Drawing.Font("Arial", 10, FontStyle.Bold), Brushes.Black, 20, 50);
            e.Graphics.DrawString(String .Concat ("Peso       : ",mObjImpCol.Kilos    ), new System.Drawing.Font("Arial", 10, FontStyle.Bold), Brushes.Black, 20, 65);
            e.Graphics.DrawString(String .Concat ("Nro Paquete: ",mObjImpCol.NroPaq     ), new System.Drawing.Font("Arial", 10, FontStyle.Bold), Brushes.Black, 20, 80);
            //imprimimos el codigo de barra
            e.Graphics.DrawString(FormatBarCode(mObjImpCol.IdPaqueteColada), new Font("Code 3 de 9", 24, FontStyle.Regular), Brushes.Black, 40, 110);
            e.Graphics.DrawString(String .Concat (mObjImpCol.Resumen      ), new System.Drawing.Font("Arial", 10, FontStyle.Bold), Brushes.Black, 20, 150);

            e.HasMorePages = false ;

        }

    //        ''' <summary>
    //''' Incluye al Código los * para que el lector lea correctamente el Código. 
    //''' </summary>
    //''' <param name="icode">Código a Formatear.</param>
    //''' <returns>Código con los *</returns>
    private string  FormatBarCode(string  icode ) 
    {
        string barcode = String.Empty;
        barcode = String.Format("*{0}*", icode);
        return barcode;
    }

    private void Btn_Consignacion_Click(object sender, EventArgs e)
    {
        Consignacion.Frm_Consignacion lFrm = new Consignacion.Frm_Consignacion();
        lFrm.CargaDatos(mUserLog);
        lFrm.ShowDialog();
    }

    private void Btn_IngPeso_Click(object sender, EventArgs e)
    {
            //Frm_IngPesoRomana lFrm = new Frm_IngPesoRomana();
            Bascula.Frm_PesajeCamion lFrm = new Bascula.Frm_PesajeCamion();
            lFrm.IniciaForm(mUserLog);
            lFrm.ShowDialog();
    }

    private void Btn_ImportarRomana_Click(object sender, EventArgs e)
    {
        DTS.Frm_ImportaCorrelativo lFrm = new DTS.Frm_ImportaCorrelativo();
        lFrm.ShowDialog(this );
    }

        private void Btn_RegularizaDespachos_Click(object sender, EventArgs e)
        {
            Bascula.Frm_Regularizar lFrm = new Bascula.Frm_Regularizar();
            lFrm.ShowDialog(this);

        }



        //private void button1_Click_1(object sender, EventArgs e)
        //{
        //    EnviaImpresion();
        //}
    }
}