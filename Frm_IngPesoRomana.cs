using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using CommonLibrary2;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Metalurgica
{
    public partial class Frm_IngPesoRomana : Form
    {
        private DataTable lTblRes = new DataTable();
       
        public Frm_IngPesoRomana()
        {
            InitializeComponent();
        }

        private void Btn_Grabar_Click(object sender, EventArgs e)
        {
            if (VerificaDatos() == true)
            {
                string lSql = "";// string.Concat("SP_ConsultasGenerales 51,'", Tx_PesoRomana.Text, "','", Cmb_IT.SelectedValue.ToString(), "','','',''");
                DataTable lTbl = new DataTable(); DataSet lDts = new DataSet();
                Px_WS.Ws_ToSoapClient lPx = new Px_WS.Ws_ToSoapClient(); int lFilasAfectadas = 0;
                Clases .ClsComun lCom=new Clases.ClsComun ();
                lDts = lPx.ObtenerDatos(lSql);
                if (lDts.Tables.Count > 0 && lDts.Tables[0].Rows.Count > 0)
                {
                    lFilasAfectadas = lCom.Val(lDts.Tables[0].Rows[0][0].ToString());
                    if (lFilasAfectadas > 0)
                    {
                        MessageBox.Show("Los datos se han grabado correctamente", "Avisos Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Los datos NO se han grabado correctamente, intente nuevamente la Operación ", "Avisos Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning );
                }
            }
        }



        private bool VerificaDatos()
        {
            bool lRes = true; Clases.ClsComun lComun = new Clases.ClsComun();
            string lMsg = "";

            if (lComun.EsNumero(Tx_PesoRomana.Text ) == false)
            {
                lMsg = "Debe Ingresar un número en el campo Peso Romana ";
                lRes = false;
            }

            if (lComun.Val (Tx_PesoRomana.Text) ==0)
            {
                lMsg = string.Concat(lMsg, Environment.NewLine, "El campo Peso Romana debe ser mayor que cero ");
                lRes = false;
            }

            if (lMsg .Trim ().Length >0)
                MessageBox.Show(lMsg, "Avisos Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            return lRes;
        }


        private void CargaDatosIniciales()
        {
            Clases.ClsComun lcom = new Clases.ClsComun(); DataTable lTbl = new DataTable();

            lTblRes = CreaColumnasTabla();

            lTbl = lcom.CargaTablaObras_ParaIngresoRomana();            
            if (lTbl.Rows.Count > 0)
            {                
                new Forms().comboBoxFill(Cmb_Obra , lTbl, "Id", "Obra", 0);
            }
           
       }


        private void CargaPatentes(string iObraSel)
        {
            string lSql = string.Concat ("SP_ConsultasGenerales 49,'",iObraSel ,"','','','',''");
            DataTable lTbl = new DataTable(); DataSet lDts = new DataSet(); 
            Px_WS.Ws_ToSoapClient lPx = new Px_WS.Ws_ToSoapClient();                       
            lDts = lPx.ObtenerDatos(lSql);
            if (lDts.Tables.Count > 0 && lDts.Tables[0].Rows.Count > 0)
            {
                lTbl = lDts.Tables[0].Copy();
                new Forms().comboBoxFill(Cmb_Patente, lTbl, "patente", "patente", 0);
            }
        }

        private void CargaPesoCamionRomana(string iPatente)
        {

            string lSql = string.Concat(" Select * from Correlativos where patente ='", iPatente ,"' and ticketAsociado>0 ");
            DataTable lTbl = new DataTable(); DateTime lFecha = DateTime.Now.AddDays(-3); string lTxFecha = "";
            string lPath = ConfigurationManager.AppSettings["PathDBRomana"].ToString(); int i = 0;
            DataRow lFila = null;

            lTxFecha = string.Concat(lFecha.Month, "/", lFecha.Day, "/", lFecha.Year);
            lSql = string.Concat(lSql, " and Fecha > #", lTxFecha, "# ");
            string lCnnstr = string.Concat(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=", lPath);
            OleDbConnection lCnn=new OleDbConnection(lCnnstr );
            OleDbDataAdapter lAdp=new OleDbDataAdapter (lSql ,lCnn );
            
            try
            {
                lAdp.Fill(lTbl);
                lTblRes.Clear();
                for (i = 0; i < lTbl.Rows.Count; i++)
                {
                    lFila = lTblRes.NewRow();

                    lFila["Bruto"] = lTbl.Rows[i]["PesoBruto"].ToString();
                    lFila["Tara"] = lTbl.Rows[i]["PesoTara"].ToString();
                    lFila["Carga"] = int.Parse(lTbl.Rows[i]["PesoBruto"].ToString()) - int.Parse(lTbl.Rows[i]["PesoTara"].ToString());
                    lFila["Correlativo"] = lTbl.Rows[i]["Correlativo"].ToString();
                    lFila["Destino"] = lTbl.Rows[i]["Destino"].ToString();
                    lFila["Fecha"] = string.Concat (lTbl.Rows[i]["Fecha"].ToString().Substring (0,12)," ",lTbl.Rows[i]["hora"].ToString()) ;

                    lFila["patente"] = lTbl.Rows[i]["patente"].ToString();
                    lTblRes.Rows.Add(lFila);
                }

                Dtg_Resultado.DataSource = lTblRes;
                if (lTblRes.Rows.Count == 1)
                {
                    Tx_PesoRomana.Text = lTblRes.Rows[0]["Carga"].ToString();
                }
              

            }
            catch (Exception exc)
            {
                MessageBox.Show("Se ha Producido el siguiente error: " +exc.Message.ToString (), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }


        //lTblRes
        private DataTable CreaColumnasTabla()
        {
            DataTable lTbl = new DataTable();

            lTbl.Columns.Add("Bruto", Type.GetType("System.String"));
            lTbl.Columns.Add("Tara", Type.GetType("System.String"));
            lTbl.Columns.Add("Carga", Type.GetType("System.String"));
            lTbl.Columns.Add("Destino", Type.GetType("System.String"));
            lTbl.Columns.Add("Correlativo", Type.GetType("System.String"));
            lTbl.Columns.Add("Fecha", Type.GetType("System.String"));
            lTbl.Columns.Add("Patente", Type.GetType("System.String"));

            return lTbl;
        }

        private void CargaItsPorPatente(string iIdObra, string iPatente)
        {

            string lSql = string.Concat("SP_ConsultasGenerales 50,'", iPatente, "','", iIdObra, "','','',''");
            DataTable lTbl = new DataTable(); DataSet lDts = new DataSet();
            Px_WS.Ws_ToSoapClient lPx = new Px_WS.Ws_ToSoapClient();
            string lViajes = ""; int i = 0;

            lDts = lPx.ObtenerDatos(lSql);
            if (lDts.Tables.Count > 0 && lDts.Tables[0].Rows.Count > 0)
            {
                lTbl = lDts.Tables[0].Copy();
                
                for (i = 0; i < lTbl.Rows.Count; i++)
                {
                    lViajes = string.Concat(lViajes, lTbl.Rows[i]["Codigo"].ToString(), " , ");
                }

                Tx_ViajesCargados.Text = lViajes;
                Tx_FechaDespacho.Text = lTbl.Rows[0]["FechaDes"].ToString();
            }

            MuestraDatos();

        }


        private void Btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Cmb_Obra_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargaPatentes(Cmb_Obra.SelectedValue.ToString ());
        }

        private void Frm_IngPesoRomana_Load(object sender, EventArgs e)
        {
            CargaDatosIniciales();
        }

        private void Cmb_IT_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Debemos verficar si ya se ha ingresado el dato y visualizarlo.

        }

        private void Cmb_Patente_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (Cmb_Patente.SelectedValue != null)
            {
                CargaPesoCamionRomana(Cmb_Patente.SelectedValue.ToString());
                CargaItsPorPatente(Cmb_Obra.SelectedValue.ToString(), Cmb_Patente.SelectedValue.ToString());
            }
        }

        private void Dtg_Resultado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            string lCarga = Dtg_Resultado.Rows[e.RowIndex].Cells["Carga"].Value.ToString();


            Tx_PesoRomana.Text = lCarga;
            MuestraDatos();

        }

        private void MuestraDatos()
        {
            Ws_TO.Ws_ToSoapClient lPxs = new Ws_TO.Ws_ToSoapClient(); decimal lPorcentaje = 0; Clases.ClsComun lCom = new Clases.ClsComun();
            decimal lPesoRom = 0; decimal lDif = 0;
            Tx_PesoViaje.Text = lPxs.ObtenerKgsViajes(Tx_ViajesCargados.Text);
            lDif = Math.Abs(lCom.Val(Tx_PesoRomana.Text) - lCom.Val(Tx_PesoViaje.Text));
            lPesoRom = lCom.Val(Tx_PesoRomana.Text);
            lPorcentaje = (lDif / lPesoRom) * 100;

            Tx_Dif.Text = Math.Round(lPorcentaje, 2).ToString();
            if (lPorcentaje < 5)
            {
                Tx_Estado.BackColor = Color.LightGreen;
            }
            else
                Tx_Estado.BackColor = Color.LightSalmon;
        
        }


    }
}
