using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Metalurgica.Tools
{
    public partial class Frm_DetalleCliente : Form
    {
        private  string mRut  ="";
        public Frm_DetalleCliente()
        {
            InitializeComponent();
        }
        public void  InicializaDatos(string iRut)
        {
            mRut = iRut;

        }

        private void CargaDatos(string iRut)
        {
            WsCrud.CrudSoapClient lDAl = new WsCrud.CrudSoapClient(); DataSet lDtsNoFact = new DataSet();
            DataView lVista = null; DataView lVista2 = null;
            //Obtenemos los datos
            lDtsNoFact = lDAl.ObtenerDetalleDespachadoSinFacturar(iRut);
            lVista = new DataView(lDtsNoFact.Tables[0], "ValorKgs>0", "atenum", DataViewRowState.CurrentRows);
            Dtg_LC.DataSource = lVista;

            DataTable lTblGuiasXVicular = new DataTable();
              lTblGuiasXVicular=  ObtenerGuiasPorVincular(iRut);

            if (lTblGuiasXVicular.Rows.Count >0 )
            {

                lVista2 = new DataView(lTblGuiasXVicular, "Vinculada='S/V'", "atenum", DataViewRowState.CurrentRows);
                Dtg_PorVinc.DataSource = lVista2;
            }

            int i = 0; int k = 0;string lNro = "";
            for (i = 0; i < Dtg_LC.Rows.Count; i++)
            {
                if (Dtg_LC.Rows[i].Cells["AteNum"].Value!=null)
                { 
                lNro = Dtg_LC.Rows[i].Cells["AteNum"].Value.ToString();
                    for (k = 0; k < Dtg_PorVinc.Rows.Count; k++)
                    {
                        if ((Dtg_PorVinc.Rows[k].Cells["AteNum"].Value != null) && (lNro.Equals(Dtg_PorVinc.Rows[k].Cells["AteNum"].Value.ToString())))
                        {
                            Dtg_LC.Rows[i].Cells["AteNum"].Style.BackColor = Color.LightGreen;
                        }
                    }      
                }
            }

        }

        private DataTable ObtenerGuiasPorVincular(string irut)
        {
            WsCrud.CrudSoapClient lDAl = new WsCrud.CrudSoapClient(); string CodGuiaINET = ""; string CodGuia = "";
            string lSql = " "; DataTable lTbl = new DataTable(); string lrut = ""; int i = 0;
            DataTable lTbl2 = new DataTable(); int k = 0; DataTable lTblFinal = new DataTable();
            WsCrud.ListaDataSet listaDataSet = new WsCrud.ListaDataSet();
            DataView lVista = null;

            lSql = String.Concat(" select  distinct cliente, estadoalta,  codigo_inet,  Empresa  from obras  ");
            lSql = String.Concat(lSql, " Where rutCliente like '%", irut, "%'  and estadoalta<>'FIN' ");

            listaDataSet = lDAl.ListarAyudaSql(lSql);
            if ((listaDataSet.MensajeError.Trim().Length == 0) && (listaDataSet.DataSet.Tables.Count > 0))
            {
                lTbl = listaDataSet.DataSet.Tables[0].Copy();

                for (i = 0; i < lTbl.Rows.Count; i++)
                {
                    CodGuiaINET = lTbl.Rows[i]["Codigo_INET"].ToString();
                    //CodGuia = lTbl.Rows[i]["CodigoGuia_INET"].ToString();
                    CodGuia = "";
                    lrut = irut; // lTbl.Rows[i]["RutCliente"].ToString();

                    switch (lTbl.Rows[i]["Empresa"].ToString().ToUpper())
                    {
                        case "TO":
                            lSql = String.Concat(" exec SP_Consultas_WS  172,'", CodGuia, "','", lrut, "','", CodGuiaINET, "','','','','' ");
                            listaDataSet = lDAl.ListarAyudaSql(lSql);
                            if ((listaDataSet.MensajeError.Trim().Length == 0) && (listaDataSet.DataSet.Tables.Count > 0))
                            {
                                lTbl2 = listaDataSet.DataSet.Tables[0].Copy();
                                lTblFinal.Merge(lTbl2);
                            }

                            break;
                        case "TOSOL":
                            lSql = String.Concat(" exec SP_Consultas_WS  186,'", CodGuia, "','", lrut, "','", CodGuiaINET, "','','','','' ");
                            listaDataSet = lDAl.ListarAyudaSql(lSql);
                            if ((listaDataSet.MensajeError.Trim().Length == 0) && (listaDataSet.DataSet.Tables.Count > 0))
                            {
                                lTbl2 = listaDataSet.DataSet.Tables[0].Copy();
                                lTblFinal.Merge(lTbl2);
                            }
                            break;

                    }

                }

            }



            return lTblFinal;
        }


       

        private void Btn_RevisaDatos_Click(object sender, EventArgs e)
        {
            string lGuiaXVin = "";int i = 0;
            //if (Dtg_LC.Rows.Count < Dtg_PorVinc.Rows.Count)
            //{
                for (i = 0; i < Dtg_PorVinc.Rows.Count; i++)
                {
                    if (Dtg_PorVinc.Rows[i].Cells["AteNum"].Value!=null )
                        lGuiaXVin = Dtg_PorVinc.Rows[i].Cells["AteNum"].Value .ToString();
                        if (ExisteGuiaEn_Gr_LC(lGuiaXVin) == false)
                        {
                            InsertaGuiaVinculada(lGuiaXVin, mRut, "834");
                        }
                //}
                

            }

        }

        private void InsertaGuiaVinculada(string iNroGuia, string iRut, string idObra)
        {
            string lSql = ""; WsCrud.CrudSoapClient lDAl = new WsCrud.CrudSoapClient();
            lSql = string.Concat("  insert into GuiasPorFactura(NroGuiaINET, NroFactura, IdUser, FechaRegistro, RutCliente, IdObra )");
            lSql = string.Concat(lSql, "  values(", iNroGuia,", 0, 1, getdate(), '", iRut, "',", idObra,")  select @@identity");


            WsCrud.ListaDataSet listaDataSet = new WsCrud.ListaDataSet();
            listaDataSet = lDAl.ListarAyudaSql(lSql);
        }

        private Boolean ExisteGuiaEn_Gr_LC(string iGuiaXVincular)
        {
            int i = 0;Boolean lRes = false;

            for (i = 0; i < Dtg_LC.Rows.Count; i++)
            {
                if (Dtg_LC.Rows[i].Cells["AteNum"].Value!=null )
                    if (Dtg_LC.Rows[i].Cells["AteNum"].Value.ToString().Equals(iGuiaXVincular))
                    {
                        lRes = true;
                        i = Dtg_LC.Rows.Count;
                    }
                  
            }


            return lRes;
        }

        private void Frm_DetalleCliente_Load(object sender, EventArgs e)
        {
            CargaDatos(mRut);
        }
    }
}
