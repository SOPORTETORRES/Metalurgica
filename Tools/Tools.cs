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
   
    public partial class Tools : Form
    {
        private string mOpcion = ""; 
        public Tools()
        {
            InitializeComponent();
        }

        private void Btn_CargarDatos_Click(object sender, EventArgs e)
        {
            mOpcion = "CD";
            CargaDiferencias();
        }

        private void CargaDiferencias()
        {
            string lSql = ""; DataTable lTbl = new DataTable();int i = 0;
            WsCrud.CrudSoapClient lDAl = new WsCrud.CrudSoapClient();string lId = "";
            WsCrud.ListaDataSet listaDataSet = new WsCrud.ListaDataSet();
            lSql = string.Concat("  exec SP_Tools '','','','','',1");

            lSql = string.Concat("  exec SP_Tools '','','','','',2");
            listaDataSet = lDAl.ListarAyudaSql(lSql);
            if (listaDataSet.MensajeError.Equals(""))
            {
                if (listaDataSet.DataSet.Tables.Count > 0)
                {
                    lTbl = listaDataSet.DataSet.Tables[0].Copy();

                    Dtg_Datos.DataSource = lTbl;

                    for (i = 0; i < Dtg_Datos.Rows.Count; i++)
                    {
                        if ((Dtg_Datos.Rows[i].Cells["RutGuia"].Value != null) && (Dtg_Datos.Rows[i].Cells["RutGuia"].Value.ToString().Equals((Dtg_Datos.Rows[i].Cells["RutFact"].Value.ToString()))))
                            PintaFila(i, Color.LightGreen, Dtg_Datos);
                        else
                        {
                            if (Dtg_Datos.Rows[i].Cells["Id"].Value != null)
                            {
                                lId = Dtg_Datos.Rows[i].Cells["Id"].Value.ToString();
                                PintaFila(i, Color.LightSalmon, Dtg_Datos);
                                //EliminarRegistro(lId);
                            }
                         
                        }
                         //   PintaFila(i, Color.LightSalmon, Dtg_Datos);

                    }
                    DataGridViewCheckBoxColumn check = new DataGridViewCheckBoxColumn();
                    check.Name = "Eliminar";
                    Dtg_Datos.Columns.Insert(0, check);

                }


            
            }
        }

        private void PintaFila(int  iFila, Color iColor, DataGridView iDtg)
        {
            int i = 0;
            for (i = 0; i < iDtg.ColumnCount; i++)
            {
                iDtg.Rows[iFila].Cells[i].Style.BackColor = iColor;
            }
        }

        private void Dtg_Datos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (mOpcion == "CD")
                    tx_Id.Text = Dtg_Datos.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                else
                    Tx_rut .Text = Dtg_Datos.Rows[e.RowIndex].Cells["rutcliente"].Value.ToString();
            }
                     
        }

        private void Btn_eliminar_Click(object sender, EventArgs e)
        {
            string lSql = ""; DataTable lTbl = new DataTable();int i = 0;
            WsCrud.CrudSoapClient lDAl = new WsCrud.CrudSoapClient();
           

            //lSql = string.Concat("  delete from  GuiasPorFactura   where id =", tx_Id .Text );
            //listaDataSet = lDAl.ListarAyudaSql(lSql);

            //for (i=0; i<Dtg_Datos .RowCount;i++)
            //{

                foreach (DataGridViewRow lRow in this.Dtg_Datos.Rows)
                {
                if (lRow.Cells[0].Value != null)
                    if (lRow.Cells[0].Value.ToString() == "True")
                    {
                        tx_Id.Text = lRow.Cells["id"].Value.ToString();
                        EliminarRegistro(tx_Id.Text);
                    }
                    
                }



           
            CargaDiferencias();
        }

        private void EliminarRegistro(string lId)
        {
            string lSql = ""; WsCrud.CrudSoapClient lDAl = new WsCrud.CrudSoapClient();
            lSql = string.Concat("  delete from  GuiasPorFactura   where id =", lId);
            WsCrud.ListaDataSet listaDataSet = new WsCrud.ListaDataSet();
           listaDataSet = lDAl.ListarAyudaSql(lSql);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RevisaClientes();
        }
        private void RevisaClientes()
        {
            string lSql = ""; WsCrud.CrudSoapClient lDAl = new WsCrud.CrudSoapClient(); int i = 0; string lTxAux = "";
            lSql = string.Concat("  select distinct  rutcliente, cliente , '0' NroGuiasXFact, '0' NroGuiasXVinc  from obras where EstadoAlta <> 'FIN' ");
            WsCrud.ListaDataSet listaDataSet = new WsCrud.ListaDataSet(); DataTable lTbl = new DataTable();DataView lVista = null;
            listaDataSet = lDAl.ListarAyudaSql(lSql); string lRut = "";DataSet lDtsNoFact = new DataSet();
            DataTable lTblGuiasXVicular = new DataTable();
            lTbl = listaDataSet.DataSet.Tables[0].Copy();

            Pb_.Maximum = lTbl.Rows.Count;
            Pb_.Minimum = 1;
            Pb_.Value = 1;
            for (i = 0; i < lTbl.Rows.Count; i++)
            {
                if (Pb_.Value < Pb_.Maximum)
                    Pb_.Value = Pb_.Value + 1;
                else
                    Pb_.Value = Pb_.Value - 1;

                lRut =lTbl.Rows [i]["rutcliente"].ToString ().Substring (0, lTbl.Rows[i]["rutcliente"].ToString().Length -2);
                lDtsNoFact = lDAl.ObtenerDetalleDespachadoSinFacturar(lRut);
                lVista = new DataView(lDtsNoFact.Tables[0], "ValorKgs>0", "", DataViewRowState.CurrentRows);
                lTxAux = lVista.Count.ToString ();
                //lTxAux = lDtsNoFact.Tables[0].Rows.Count.ToString();
                lTbl.Rows[i]["NroGuiasXFact"] = lTxAux;

                lTblGuiasXVicular = ObtenerGuiasPorVincular(lRut);
                if (lTblGuiasXVicular.Rows.Count > 0)
                {
                    lVista = new DataView(lTblGuiasXVicular, "Vinculada='S/V'", "", DataViewRowState.CurrentRows);
                    lTxAux = lVista.Count.ToString();
                    //lTxAux = lDtsNoFact.Tables[0].Rows.Count.ToString();
                    lTbl.Rows[i]["NroGuiasXVinc"] = lTxAux;
                }             

            }
            Dtg_Datos.DataSource = lTbl;

        }

        private DataTable ObtenerGuiasPorVincular(string irut)
        {
            WsCrud.CrudSoapClient lDAl = new WsCrud.CrudSoapClient(); string CodGuiaINET = ""; string CodGuia = "";
            string lSql = " "; DataTable lTbl = new DataTable();string lrut = ""; int i = 0;
            DataTable lTbl2 = new DataTable(); int k = 0;DataTable lTblFinal = new DataTable();
            WsCrud.ListaDataSet listaDataSet = new WsCrud.ListaDataSet();
            lSql = String.Concat(" select cliente, estadoalta, codigoGuia_INET, codigo_inet,  Empresa  from obras  ");
            lSql = String.Concat(lSql, " Where rutCliente like '%",irut , "%'  and estadoalta<>'FIN' ");

            listaDataSet = lDAl.ListarAyudaSql(lSql);
            if ((listaDataSet.MensajeError.Trim().Length == 0) && (listaDataSet.DataSet.Tables.Count > 0))
            {
                lTbl = listaDataSet.DataSet.Tables[0].Copy();

                for (i = 0; i < lTbl.Rows.Count; i++)
                {
                    CodGuiaINET = lTbl.Rows[i]["Codigo_INET"].ToString();
                    CodGuia = lTbl.Rows[i]["CodigoGuia_INET"].ToString();
                    lrut = irut; // lTbl.Rows[i]["RutCliente"].ToString();

                    switch (lTbl.Rows[i]["Empresa"].ToString().ToUpper())
                    {
                        case "TO":
                            lSql = String.Concat(" exec SP_Consultas_WS  172,'", CodGuia, "','", lrut, "','", CodGuiaINET, "','','','','' ");
                            listaDataSet = lDAl.ListarAyudaSql(lSql);
                            if ((listaDataSet.MensajeError.Trim().Length == 0) && (listaDataSet.DataSet.Tables.Count > 0))
                            {
                                lTbl2= listaDataSet.DataSet.Tables[0].Copy();
                                lTblFinal.Merge(lTbl2);
                                //for (i = 0; i < lTbl2.Rows.Count; i++)
                                //{
                                //    lSql = String.Concat(" Select AteNum, DocCod  , * from TORRESOCARANZA .dbo.ateclien a ");
                                //    lSql = String.Concat(lSql, " where  CliCod =", lrut, "  and  AteObsUno like ' % ", lTbl2.Rows(i)("AteNUm").ToString, " %'");  


                                //}

                            }

                            break;
                        case "A":
                            break;
                 
                    }

                }

            }


                
            return lTblFinal;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Tx_rut.Text.Length > 0)
            {
                Metalurgica.Tools.Frm_DetalleCliente lFrm = new Metalurgica.Tools.Frm_DetalleCliente();
                lFrm.Show();
            }

        }

        private void Tools_Load(object sender, EventArgs e)
        {

        }
    }
}
