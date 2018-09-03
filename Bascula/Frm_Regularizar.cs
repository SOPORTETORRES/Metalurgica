using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Metalurgica.Bascula
{
    public partial class Frm_Regularizar : Form
    {
        public Frm_Regularizar()
        {
            InitializeComponent();
        }

        private void Frm_Regularizar_Load(object sender, EventArgs e)
        {
            CargaDatos();
        }

        private void CargaDatos()
        {
            string lSql = ""; Ws_TO.Ws_ToSoap wsOperacion = new Ws_TO.Ws_ToSoapClient();
            DataSet lDts = new DataSet(); Clases.ClsComun lCom = new Clases.ClsComun();
            DataTable lTbl = new DataTable(); Clases.ClsComun lDAL = new Clases.ClsComun();
            int i = 0; string lTmp = "";

            lSql = " select DES_CAM_ID IdDesp, DES_CAM_CAMION Patente, DES_CAM_FECHA, NroGuiaInet, Codigo, ";
            lSql = String.Concat(lSql, "(Select round(SUM(d.kgspaquete), 1)  from DetallePaquetesPieza d where d.IdViaje = v.Id) KgsCUB, ");
            lSql = String.Concat(lSql, "(Select a.AteProCan from TORRESOCARANZA.dbo.ATECLIEN A where a.ATENUM = NroGuiaInet ) KgsINET ,v.cuadradoConINET , '' GuiasCorr");
            lSql = String.Concat(lSql, " from DESPACHO_CAMION  , Viaje v where DES_CAM_FECHA > '31/07/2018 23:59' "); // and (v.cuadradoConINET is null or v.cuadradoConINET<>'S') ");
            lSql = String.Concat(lSql, " and DES_CAM_USUARIO not in ('cmamani','lyanez') and DES_CAM_ID not in (32862,33152) and v.IdDespachoCamion = DES_CAM_ID ");
            lSql = String.Concat(lSql, " Order by  NroGuiaInet  , DES_CAM_FECHA,  DES_CAM_CAMION  ");

           lDts = wsOperacion.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                //for (i = 0; i < lDts.Tables[0].Rows.Count; i++)
                //{
                //    lDts.Tables[0].Rows[i]["GuiasCorr"] = ObtenerCorrelativoPorGuiaDespacho(lDts.Tables[0].Rows[i]["NroGuiaInet"].ToString());

                //}


                dataGridView1.DataSource = lDts.Tables[0].Copy();
                dataGridView1.Columns[0].Width = 60;
                dataGridView1.Columns[1].Width = 60;
                dataGridView1.Columns[2].Width = 100;
                dataGridView1.Columns[3].Width = 60;
                dataGridView1.Columns[4].Width = 90;
                dataGridView1.Columns["cuadradoConINET"].Width = 60;

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int lIndex = e.RowIndex;
            Cursor.Current = Cursors.WaitCursor;
            string lGuiaINET = dataGridView1.Rows[lIndex].Cells["NroGuiaInet"].Value.ToString();
            string lCorrelativo = dataGridView1.Rows[lIndex].Cells["GuiasCorr"].Value.ToString();
            string lFechaDesp = dataGridView1.Rows[lIndex].Cells["des_Cam_Fecha"].Value.ToString();
            string lPatente = dataGridView1.Rows[lIndex].Cells["Patente"].Value.ToString();

            string[] split = lFechaDesp.ToString().Split(new Char[] { ' ' });

            Tx_Patente.Text = lPatente;
            if (split.Length == 2)
            {
                Tx_FechaDesp.Text = split[0];
                Tx_HoraDesp .Text = split[1];
            }

            Lbl_nroGuia.Text = lGuiaINET;
            Tx_Correlativo.Text = lCorrelativo;
            dataGridView2.DataSource = null;
            CargaDatosBascula(lGuiaINET);
            Cursor.Current = Cursors.Default;


        }
        private void CargaDatosBascula(string iNroGuiaINET)
        {

            string lSql = ""; Ws_TO.Ws_ToSoap wsOperacion = new Ws_TO.Ws_ToSoapClient();
            DataSet lDts = new DataSet(); Clases.ClsComun lCom = new Clases.ClsComun();
            DataTable lTbl = new DataTable(); Clases.ClsComun lDAL = new Clases.ClsComun();
            string lIdPesaje = ""; DataTable lTbl2 = new DataTable();int i = 0; int j = 0;
            int lNroreg = 0; int lTotalKgs = 0;

            try
            {
                dataGridView3.DataSource = null;
                dataGridView4.DataSource = null;

                lSql = string.Concat (" Select a.AteProCan , a.AtePatVeh  from TORRESOCARANZA.dbo.ATECLIEN a where a.atenum=", iNroGuiaINET);
                lDts = wsOperacion.ObtenerDatos(lSql);
                if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                {
                    Tx_PatenteINET.Text = lDts.Tables[0].Rows[0]["AtePatVeh"].ToString().Trim(); 
                }

                //lSql = " SELECT distinct pc.estado,pesobruto-pesotara PasoBascula, ";
                //lSql = String.Concat(lSql, " ( Select a.AteProCan   from TORRESOCARANZA.dbo.ATECLIEN A where a.ATENUM=NroGuiaInet ) KgsINET, ");
                //lSql = String.Concat(lSql, " ( Select a.AtePatVeh   from TORRESOCARANZA.dbo.ATECLIEN A where a.ATENUM=NroGuiaInet ) PatenteINET, ");
                //lSql = String.Concat(lSql, " (pesobruto-pesotara) - ( Select convert(int,a.AteProCan)   from TORRESOCARANZA.dbo.ATECLIEN A where a.ATENUM=NroGuiaInet ) Dif ,  ");
                //lSql = String.Concat(lSql, "( Select a.AteFchAte   from TORRESOCARANZA.dbo.ATECLIEN A where a.ATENUM=NroGuiaInet ) FechaINET,  pc.* ");
                //lSql = String.Concat(lSql, " FROM PesajeCamion pc, DetallePesajeCamion dpc  , DESPACHO_CAMION  , Viaje v  ");
                //lSql = String.Concat(lSql, " where  pc.id =dpc.IdPesajeCamion  and DES_CAM_ID =dpc .IdDespachoCamion  and DES_CAM_ID =v.IdDespachoCamion    ");
                //lSql = String.Concat(lSql, " and v.NroGuiaInet =", iNroGuiaINET);
                lSql = " SELECT distinct Pc.id    ";
                lSql = String.Concat(lSql, " FROM PesajeCamion pc, DetallePesajeCamion dpc  , DESPACHO_CAMION  , Viaje v   ");
                lSql = String.Concat(lSql, " where  pc.id =dpc.IdPesajeCamion  and DES_CAM_ID =dpc .IdDespachoCamion  and DES_CAM_ID =v.IdDespachoCamion    ");
                lSql = String.Concat(lSql, " and v.NroGuiaInet=", iNroGuiaINET);
                lDts = wsOperacion.ObtenerDatos(lSql);
                if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                {
                    lIdPesaje = lDts.Tables[0].Rows[0]["Id"].ToString();
                }

                    lSql = " SELECT distinct pc.IdCorrelativo,  Pc.id , pc.estado,pesobruto,pesotara , pesobruto-pesotara PasoBascula, SUM(pesoGuiaINET) KgsINT, ";
                lSql = String.Concat(lSql, " (pesobruto-pesotara) -  SUM(pesoGuiaINET) Dif  ");
                lSql = String.Concat(lSql, " FROM PesajeCamion pc, DetallePesajeCamion dpc  , DESPACHO_CAMION  , Viaje v   ");
                lSql = String.Concat(lSql, " where  pc.id =dpc.IdPesajeCamion  and DES_CAM_ID =dpc .IdDespachoCamion  and DES_CAM_ID =v.IdDespachoCamion    ");
                lSql = String.Concat(lSql, " and pc.id=", lIdPesaje) ;
                lSql = String.Concat(lSql, " group by pc.IdCorrelativo,pc.Id , pc.estado,pesobruto,pesotara, pc.patente  ");
                //lSql = String.Concat(lSql, " where  pc.id =dpc.IdPesajeCamion  and DES_CAM_ID =dpc .IdDespachoCamion  and DES_CAM_ID =v.IdDespachoCamion    ");
                //lSql = String.Concat(lSql, " and v.NroGuiaInet =", iNroGuiaINET);

                lDts = wsOperacion.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                lIdPesaje = lDts.Tables[0].Rows[0]["Id"].ToString();
                lTbl = lDts.Tables[0].Copy();
                dataGridView2.DataSource = lTbl;

                dataGridView2.Columns[0].Width = 70;
                dataGridView2.Columns[1].Width = 70;
                dataGridView2.Columns[2].Width = 60;
                dataGridView2.Columns[3].Width = 60;
                dataGridView2.Columns[4].Width = 70;
                dataGridView2.Columns[5].Width = 60;

                   


                lSql = String.Concat( " SELECT *  from detallepesajeCamion where idpesajeCamion=", lIdPesaje );
                lDts = wsOperacion.ObtenerDatos(lSql);
                if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                {
                    lTbl2= lDts.Tables[0].Copy();
                    dataGridView3.DataSource = lTbl2;
                    for (i = 0; i < dataGridView3.Rows.Count; i++)
                    {
                        if (dataGridView3.Rows[i].Cells[2].Value!=null)
                        {
                        for (j = 0; j < dataGridView1.Rows.Count; j++)
                        {
                                if (dataGridView1.Rows[j].Cells[0].Value != null)
                                    {
                                    if ((lCom.Val(dataGridView3.Rows[i].Cells[2].Value.ToString())==lCom.Val(dataGridView1.Rows[j].Cells[0].Value.ToString())))
                                    {
                                        lNroreg = lNroreg + 1;
                                        lTotalKgs = lTotalKgs+lCom.Val(dataGridView1.Rows[j].Cells["KgsCUB"].Value.ToString());
                                            //dataGridView3.Rows[i].Cells["NroGuiaInet"].Value = dataGridView1.Rows[j].Cells["NroGuiaInet"].Value.ToString();
                                            //dataGridView3.Rows[i].Cells["PesoGuiaInet"].Value = dataGridView1.Rows[j].Cells["KgsCub"].Value.ToString();
                                            PintaFila(j);
                                        j = dataGridView1.Rows.Count;
                                    }
                                }

                            }
                        }
                            dataGridView3.Columns[0].Width = 60;
                            dataGridView3.Columns[1].Width = 60;
                            dataGridView3.Columns[2].Width = 60;
                            dataGridView3.Columns[3].Width = 60;
                            dataGridView3.Columns[4].Width = 60;
                            dataGridView3.Columns[5].Width = 60;

                        }
                        Tx_nroIts.Text = lNroreg.ToString ();
                        Tx_totalKgs.Text = lTotalKgs.ToString();

                }

                   
                }
                //Cargamos Datos de la bascula 
                if (lCom.Val(Tx_Correlativo.Text) > 0)
                {
                    CargaDatosPorCorrelativo(Tx_Correlativo.Text);
                }
                else
                {
                    CargaDatosPorFechas(Tx_PatenteINET .Text ,Tx_FechaDesp.Text , Tx_HoraDesp .Text );
                }

                //Cargamos Los datos de INET para una fecha y guia dada
                CargaDatosINET(Tx_FechaDesp.Text, Tx_PatenteINET.Text);
                //Cargamos los datos de los despachos cubiges
                CargaDatosDespacho(Tx_FechaDesp.Text, Tx_PatenteINET.Text);

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void CargaDatosPorFechas(string patente, string iFecha, string iHora)
        {
           string lRes = "0"; Clases.SqlBascula lTipoSql = new Clases.SqlBascula();
            DataTable lTblGuiasCorr = new DataTable(); Clases.ClsComun lDAL = new Clases.ClsComun();
            DataTable lTbmTmp = new DataTable(); string lTicketAsoc = ""; DataRow lFila = null;
            string lFecha = DateTime.Now.ToShortDateString(); //int lPesoTara = int.Parse(Tx_Tara.Text);

            string[] split = iFecha.ToString().Split(new Char[] { '/' });
            if (split.Length == 3)
            {
           
            lTblGuiasCorr = lDAL.CargaTablaRomana(lTipoSql.ObtenerSqlPorPatenteFecha(patente,  split [2],split [0],split [1], iHora));

            if (lTblGuiasCorr.Rows.Count > 0)
            {
                //if (lDAL.Val(lTblGuiasCorr.Rows[0]["Ticketasociado"].ToString()) > 0)
                //{
                //    lTicketAsoc = lTblGuiasCorr.Rows[0]["Ticketasociado"].ToString();
                //    lTbmTmp = lDAL.CargaTablaRomana(lTipoSql.ObtenerSqlCorrelativo(lTicketAsoc));
                //    if (lTbmTmp.Rows.Count > 0)
                //    {
                //        lFila = lTblGuiasCorr.NewRow();
                //        lFila["correlativo"] = lTbmTmp.Rows[0]["correlativo"];
                //        lFila["fecha"] = lTbmTmp.Rows[0]["fecha"];
                //        lFila["hora"] = lTbmTmp.Rows[0]["hora"];
                //        lFila["ticketasociado"] = lTbmTmp.Rows[0]["ticketasociado"];
                //        lFila["patente"] = lTbmTmp.Rows[0]["patente"];
                //        lFila["pesoBruto"] = lTbmTmp.Rows[0]["pesoBruto"];
                //        lFila["pesoTara"] = lTbmTmp.Rows[0]["pesoTara"];
                //        lFila["Bascula"] = lTbmTmp.Rows[0]["Bascula"];

                //        lTblGuiasCorr.Rows.Add(lFila);
                //    }
                //}

                dataGridView4.DataSource = lTblGuiasCorr;
                dataGridView4.Columns[0].Width = 70;
                dataGridView4.Columns[1].Width = 70;
                dataGridView4.Columns[2].Width = 70;
                dataGridView4.Columns[3].Width = 70;
                dataGridView4.Columns[4].Width = 70;
                dataGridView4.Columns[5].Width = 70;
                dataGridView4.Columns[6].Width = 70;
                }
            }
        }


        private void CargaDatosPorCorrelativo(string iCorrelativo)
        {
            //ObtenerSqlEstadoProceso
            string lRes = "0"; Clases.SqlBascula lTipoSql = new Clases.SqlBascula(); 
            DataTable lTblGuiasCorr = new DataTable(); Clases.ClsComun lDAL = new Clases.ClsComun();
            DataTable lTbmTmp = new DataTable(); string lTicketAsoc = "";DataRow lFila = null;
            string lFecha = DateTime.Now.ToShortDateString(); //int lPesoTara = int.Parse(Tx_Tara.Text);

           
            lTblGuiasCorr = lDAL.CargaTablaRomana(lTipoSql.ObtenerSqlCorrelativo(iCorrelativo));

            if (lTblGuiasCorr.Rows.Count > 0)
            {
                if (lDAL.Val(lTblGuiasCorr.Rows[0]["Ticketasociado"].ToString() ) > 0)
                {
                    lTicketAsoc = lTblGuiasCorr.Rows[0]["Ticketasociado"].ToString();
                    lTbmTmp= lDAL.CargaTablaRomana(lTipoSql.ObtenerSqlCorrelativo(lTicketAsoc));
                    if (lTbmTmp.Rows.Count > 0)
                    {
                        lFila = lTblGuiasCorr.NewRow();
                        lFila["correlativo"] = lTbmTmp.Rows [0]["correlativo"];
                        lFila["fecha"] = lTbmTmp.Rows[0]["fecha"];
                        lFila["hora"] = lTbmTmp.Rows[0]["hora"];
                        lFila["ticketasociado"] = lTbmTmp.Rows[0]["ticketasociado"];
                        lFila["patente"] = lTbmTmp.Rows[0]["patente"];
                        lFila["pesoBruto"] = lTbmTmp.Rows[0]["pesoBruto"];
                        lFila["pesoTara"] = lTbmTmp.Rows[0]["pesoTara"];
                        lFila["Bascula"] = lTbmTmp.Rows[0]["Bascula"];

                        lTblGuiasCorr.Rows.Add(lFila);
                    }
                }

            dataGridView4.DataSource = lTblGuiasCorr;
                dataGridView4.Columns[0].Width = 70;
                dataGridView4.Columns[1].Width = 70;
                dataGridView4.Columns[2].Width = 70;
                dataGridView4.Columns[3].Width = 70;
                dataGridView4.Columns[4].Width = 70;
                dataGridView4.Columns[5].Width = 70;
                dataGridView4.Columns[6].Width = 70;
            }
        }

        private void PintaFila(int iFila)
        {
            int k = 0;
            Color iColor = Color.LightGreen;
            for (k = 0; k < dataGridView1.ColumnCount; k++)
            {
                dataGridView1.Rows[iFila].Cells[k].Style.BackColor = iColor;
            }


        }

        private void Btn_Estado_Click(object sender, EventArgs e)
        {
            Clases.ClsComun lCom = new Clases.ClsComun();string lIdPesaje = "";

            if (lCom.EsNumero(Lbl_nroGuia.Text) == true)
            {
                if (dataGridView2.RowCount > 0)
                {
                    lIdPesaje = dataGridView2.Rows[0].Cells["Id"].Value.ToString();
                    CambiaEstado(Lbl_nroGuia.Text, lIdPesaje);
                }

            }
        }

        private void CambiaEstado(string iNroGuia, string iIdPesaje)
        {

            string lSql = ""; Ws_TO.Ws_ToSoap wsOperacion = new Ws_TO.Ws_ToSoapClient();
            DataSet lDts = new DataSet(); Clases.ClsComun lCom = new Clases.ClsComun();
            DataTable lTbl = new DataTable(); Clases.ClsComun lDAL = new Clases.ClsComun();
            
            lSql = String.Concat(lSql, " Update viaje set CuadradoConINET='S' where nroguiaInet=", iNroGuia);
            lDts = wsOperacion.ObtenerDatos(lSql);

            lSql = String.Concat(  " Update PesajeCamion set CuadradoConINET='S' where Id=", iIdPesaje);
            lDts = wsOperacion.ObtenerDatos(lSql);

            CargaDatos();

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int lIndex = e.RowIndex;
            if (lIndex >-1)
            { 
            Cursor.Current = Cursors.WaitCursor;
            string lfecha= dataGridView1.Rows[lIndex].Cells["FechaINET"].Value.ToString();
            string lPatente = dataGridView1.Rows[lIndex].Cells["lPatente"].Value.ToString();
            string lGuiaINET = Lbl_nroGuia.Text;

        
           
            Lbl_nroGuia.Text = lGuiaINET;
            dataGridView2.DataSource = null;
            CargaDatosBascula(lGuiaINET );
            Cursor.Current = Cursors.Default;
            }
        }

        private void CargaDatosBasculaAccess(string iNroGuia, string iFechaDesp, string iPatente)
        {
            string lRes = "0"; string lSql = ""; Clases.SqlBascula lTipoSql = new Clases.SqlBascula();
            DataTable lTblGuiasCorr = new DataTable(); Clases.ClsComun lDAL = new Clases.ClsComun();
            string lFecha = DateTime.Now.ToShortDateString(); //int lPesoTara = int.Parse(Tx_Tara.Text);
            string lCorrelativo = "0";

            lTblGuiasCorr = lDAL.CargaTablaRomana(lTipoSql.ObtenerSqlGuiasCorrelativos(iNroGuia));

            if (lTblGuiasCorr.Rows.Count > 0)
            {
                lCorrelativo = lTblGuiasCorr.Rows[0][0].ToString();
            }
            else
            {


            }
            


        }

        private string  ObtenerCorrelativoPorGuiaDespacho(string iNroGuia )
        {
            string lRes = "0";  Clases.SqlBascula lTipoSql = new Clases.SqlBascula();
            DataTable lTblGuiasCorr = new DataTable(); Clases.ClsComun lDAL = new Clases.ClsComun();
            string lFecha = DateTime.Now.ToShortDateString(); //int lPesoTara = int.Parse(Tx_Tara.Text);

            if (iNroGuia.Trim().Length > 0)
            {
                lTblGuiasCorr = lDAL.CargaTablaRomana(lTipoSql.ObtenerSqlGuiasCorrelativos(iNroGuia));

                if (lTblGuiasCorr.Rows.Count > 0)
                {
                    lRes = lTblGuiasCorr.Rows[0]["Correlativo"].ToString();

                }
            }
           
            return lRes;


        }

        private void Btn_actualiza_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            ActualizaDatosDesdeBascula();
            Cursor.Current = Cursors.Default;

        }
        private void ActualizaDatosDesdeBascula()
        {
            string lsql = ""; Clases.SqlBascula lTipoSql = new Clases.SqlBascula();int i = 0;
            DataTable lTblGuiasCorr = new DataTable(); Clases.ClsComun lDAL = new Clases.ClsComun();
            string lPesoT = ""; string FechaTara = ""; string IdUserTara = "1"; string PesoBruto = ""; string FechaPesoBruto = ""; string IdUserPesoBruto = "1";
            string IdCorrelativo = ""; string PesoGD = ""; string IdCorrelativoCarga = ""; string lIdPC = "0";
            DataView lVista = null; DataTable lTblD = new DataTable(); string lwheres = "";

            lTblD = (DataTable ) dataGridView4.DataSource;
            lwheres = string.Concat ("correlativo=",Tx_CorrSel .Text );
            lVista = new DataView(lTblD, lwheres, "", DataViewRowState.CurrentRows);
            if (lVista.Count > 0)
            {
                string[] split = lVista[0]["Fecha"].ToString().Split(new Char[] { ' ' });
                if (split .Length ==2)
                {
                    FechaTara = string.Concat(split[0], " ", lVista[0]["Hora"].ToString());

                }
                 split = lVista[0]["Fecha"].ToString().Split(new Char[] { ' ' });
                if (split.Length == 2)
                {
                    FechaPesoBruto = string.Concat(split[0], " ", lVista[0]["Hora"].ToString());

                }

                lPesoT = lVista[0]["PesoTara"].ToString();
                PesoBruto = lVista[0]["PesoBruto"].ToString();
                 //= string.Concat(lVista[0]["Fecha"].ToString(), " ", lVista[0]["Hora"].ToString());
                IdCorrelativo = lVista[0]["correlativo"].ToString();
                PesoGD = Tx_totalKgs .Text ;
                lIdPC = dataGridView2.Rows[0].Cells["Id"].Value.ToString();

                //tabla Cabecera 
                lsql =string.Concat ( " Update PesajeCamion  set  PesoTara=", lPesoT ,", FechaTara='", FechaTara,"', IdUserTara=", IdUserTara,"," );
            lsql = string.Concat(lsql, " PesoBruto=", PesoBruto, ", FechaPesoBruto='", FechaPesoBruto, "', IdUserPesoBruto=", IdUserPesoBruto, ", ");
            lsql = string.Concat(lsql, "  IdCorrelativo=",IdCorrelativo,", PesoGD=", PesoGD,", IdCorrelativoCarga=", Tx_CorrSel.Text  );
            lsql = string.Concat(lsql, "  Where Id=", lIdPC);
                DataSet lDts = new DataSet();   Ws_TO.Ws_ToSoap wsOperacion = new Ws_TO.Ws_ToSoapClient();
                lDts = wsOperacion.ObtenerDatos(lsql);
                CargaDatosBascula(Lbl_nroGuia.Text);
            }
            //tabla Detalle
            //for (i = 0; i < dataGridView3.Rows.Count; i++)
            //{
            //    lsql = string.Concat(" Update PesajeCamion PesoTara=", lPesoT, ", FechaTara='", FechaTara, "', IdUserTara=", IdUserTara, ",");
            //    lsql = string.Concat(lsql, " PesoBruto=", PesoBruto, ", FechaPesoBruto='", FechaPesoBruto, "', IdUserPesoBruto=", IdUserPesoBruto, ", ");
            //    lsql = string.Concat(lsql, "  IdCorrelativo=", IdCorrelativo, ", PesoGD=", PesoGD, ", IdCorrelativoCarga=", IdCorrelativoCarga);
            //    lsql = string.Concat(lsql, "  Where Id=    ");

            //}
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int lIndex = e.RowIndex;
            if (lIndex > -1)
            {
                Cursor.Current = Cursors.WaitCursor;
               Tx_CorrSel .Text  = dataGridView4.Rows[lIndex].Cells["Correlativo"].Value.ToString();
                Cursor.Current = Cursors.Default;
            }
        }

        private void Btn_inserta_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            InsertaDatosDesdeBascula();
            Cursor.Current = Cursors.Default;
        }

        private void InsertaDatosDesdeBascula()
        {
            string lsql = ""; Clases.SqlBascula lTipoSql = new Clases.SqlBascula(); int i = 0;
            DataTable lTblGuiasCorr = new DataTable(); Clases.ClsComun lDAL = new Clases.ClsComun();
            string lPesoT = ""; string FechaTara = "";   string PesoBruto = ""; string FechaPesoBruto = "";  
            string IdCorrelativo = ""; string PesoGD = "";  string lIdPC = "0";  string patente = ""; 
            DataView lVista = null; DataTable lTblD = new DataTable(); string lwheres = "";int lTotalKgs = 0;
            DataSet lDts = new DataSet(); Ws_TO.Ws_ToSoap wsOperacion = new Ws_TO.Ws_ToSoapClient();

            lTblD = (DataTable)dataGridView4.DataSource;
            lwheres = string.Concat("correlativo=", Tx_CorrSel.Text);
            lVista = new DataView(lTblD, lwheres, "", DataViewRowState.CurrentRows);
            if (lVista.Count > 0)
            {
                string[] split = lVista[0]["Fecha"].ToString().Split(new Char[] { ' ' });
                if (split.Length == 2)
                {
                    FechaTara = string.Concat(split[0], " ", lVista[0]["Hora"].ToString());

                }
                split = lVista[0]["Fecha"].ToString().Split(new Char[] { ' ' });
                if (split.Length == 2)
                {
                    FechaPesoBruto = string.Concat(split[0], " ", lVista[0]["Hora"].ToString());

                }
                patente= lVista[0]["patente"].ToString();
                lPesoT = lVista[0]["PesoTara"].ToString();
                PesoBruto = lVista[0]["PesoBruto"].ToString();
                //= string.Concat(lVista[0]["Fecha"].ToString(), " ", lVista[0]["Hora"].ToString());
                IdCorrelativo = lVista[0]["correlativo"].ToString();

                //Recorremos  el Detalle  para saber los kilos de la Guia 
                lTblD = (DataTable)dataGridView1.DataSource;
                lwheres = string.Concat("GuiasCorr=", Tx_CorrSel.Text);
                //lVista = new DataView(lTblD, lwheres, "", DataViewRowState.CurrentRows);
                //if (lVista.Count > 0)
                //{
                //    for (i = 0; i < lVista.Count; i++)
                //    {
                //        if (lDAL.EsNumero(lVista[i]["KgsCub"].ToString()) == true)
                //        {
                //            lTotalKgs = lTotalKgs + lDAL.Val(lVista[i]["KgsCub"].ToString());
                //        }
                //    }


                //}
                Tx_totalKgs.Text = lTotalKgs.ToString ();
               PesoGD = Tx_totalKgs.Text;
             //   lIdPC = dataGridView2.Rows[0].Cells["Id"].Value.ToString();

                //tabla Cabecera 
                lsql = string.Concat(" Insert into  PesajeCamion (Patente, PesoTara ,FechaTara ,IdUserTara ,PesoBruto ,");
                lsql = string.Concat(lsql ," FechaPesoBruto , IdUserPesoBruto ,IdCorrelativo ,NroGD ,	PesoGD,IdCorrelativoCarga, estado)");
                lsql = string.Concat(lsql, " values ('", patente, "', ", lPesoT, ",'" , FechaTara, "',1,", PesoBruto,",'");
                lsql = string.Concat(lsql, FechaPesoBruto, "',1,",Tx_CorrSel .Text ,",",Lbl_nroGuia.Text ,", ");
                lsql = string.Concat(lsql, Tx_totalKgs .Text , ",", Tx_CorrSel.Text, ", 'FIN' )  select @@identity  ");

               
                lDts = wsOperacion.ObtenerDatos(lsql);
                if ((lDts .Tables .Count >0) && (lDts.Tables[0].Rows .Count >0))
                    lIdPC = lDts.Tables[0].Rows[0][0].ToString ();

                //Grabamos el Detalle
                lTblD = (DataTable)dataGridView1.DataSource;
                //lwheres = string.Concat("GuiasCorr=", Tx_CorrSel.Text);
                //lVista = new DataView(lTblD, lwheres, "", DataViewRowState.CurrentRows);
                //if (lVista.Count > 0)
                //{
                //    for (i = 0; i < lVista.Count; i++)
                //    {
                //        lsql = string.Concat(" Insert into  DetallePesajeCamion (IdPesajeCamion ,  IdDespachoCamion, FechaRegistro ) ");
                //        lsql = string.Concat(lsql, " values (", lIdPC, ", ", lVista[i]["IdDesp"].ToString (),",getdate())");
                //        lDts = wsOperacion.ObtenerDatos(lsql);
                //    }

                   
                //}
            }
            CargaDatosBascula(Lbl_nroGuia.Text);

        }

        private void Btn_quitar_Click(object sender, EventArgs e)
        {
            DataSet lDts = new DataSet(); Ws_TO.Ws_ToSoap wsOperacion = new Ws_TO.Ws_ToSoapClient();
            string lSql = "";
            if (Tx_DPC.Text.Trim().Length > 0)
            {
                lSql = string.Concat (" Update detallepesajeCamion set IdPesajeCamion=( IdPesajeCamion*-1) where id=", Tx_DPC.Text);
                lDts = wsOperacion.ObtenerDatos(lSql);
                CargaDatosBascula(Lbl_nroGuia.Text);
            }

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int lIndex = e.RowIndex;
            if (lIndex > -1)
            {
                Cursor.Current = Cursors.WaitCursor;
                Tx_DPC .Text = dataGridView3.Rows[lIndex].Cells["Id"].Value.ToString();
                Cursor.Current = Cursors.Default;
            }
        }

        private void Btn_BuscarEnBascula_Click(object sender, EventArgs e)
        {
            string lsql = "ObtenerSqlPorPatenteFecha";


        }

        private void CargaDatosINET(string iFechaDespINET, string iPatINET)
        {
            DataSet lDts = new DataSet(); Ws_TO.Ws_ToSoap wsOperacion = new Ws_TO.Ws_ToSoapClient();
            string lSql = ""; DataTable lTbl = new DataTable();
            lSql = string.Concat(" Select a.AteFchDoc , a.AtePatVeh , a.AteProCan , a.atenum,  a.AteObsDos , a.Doccod, * ");
            lSql = string.Concat(lSql, " from TORRESOCARANZA.dbo.ATECLIEN a ");
            lSql = string.Concat(lSql, " where a.AteFchDoc = '", iFechaDespINET,"' and a.AtePatVeh = '", iPatINET,"' ");

            lDts = wsOperacion.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                lTbl = lDts.Tables[0].Copy();
                DtgINET .DataSource = lTbl;
            }

            }

        private void CargaDatosDespacho(string iFechaDespINET, string iPatINET)
        {
            DataSet lDts = new DataSet(); Ws_TO.Ws_ToSoap wsOperacion = new Ws_TO.Ws_ToSoapClient();
            string lSql = ""; DataTable lTbl = new DataTable();
            lSql = string.Concat(" select Des_cam_id, DES_CAM_FECHA, round(sum(d.kgspaquete), 2) Kgs , v.NroGuiaInet , v.Codigo ");
            lSql = string.Concat(lSql, " from DESPACHO_CAMION dc, DetallePaquetesPieza d, viaje v, PIEZA_PRODUCCION  ");
            lSql = string.Concat(lSql, " where d.Id = PIE_ETIQUETA_PIEZA and v.Id = d.IdViaje  and DES_CAM_ID = PIE_DESPACHO_CAMION  ");
            lSql = string.Concat(lSql, " and DES_CAM_CAMION = '", iPatINET,"' and DES_CAM_FECHA  > '", iFechaDespINET,"' ");
            lSql = string.Concat(lSql, "  group by Des_cam_id, DES_CAM_FECHA,v.NroGuiaInet  , v.Codigo    order by DES_CAM_FECHA ");



          lDts = wsOperacion.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                lTbl = lDts.Tables[0].Copy();
                Dtg_DespachoPAtente.DataSource = lTbl;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet lDts = new DataSet(); Ws_TO.Ws_ToSoap wsOperacion = new Ws_TO.Ws_ToSoapClient();
            string lSql = "";int i = 0;
            if (Tx_IdPesaje .Text.Trim().Length > 0)
            {
                string[] split = Tx_despachos.Text  .ToString().Split(new Char[] { ',' });
                if (split.Length > 0)
                {
                    for (i = 0; i < split.Length; i++)
                    {
                        lSql = string.Concat(" Insert into  detallepesajeCamion (IdPesajeCamion,IddespachoCamion, FechaRegistro) ");
                        lSql = string.Concat(lSql, " values (", Tx_IdPesaje.Text , "," , split[i], ",  getdate() )" );
                        //lSql = string.Concat(" Update detallepesajeCamion set IdPesajeCamion=( IdPesajeCamion*-1) where id=", Tx_DPC.Text);
                        lDts = wsOperacion.ObtenerDatos(lSql);
                    }
                }
                Tx_IdPesaje.Text = "";
                CargaDatosBascula(Lbl_nroGuia.Text);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataSet lDts = new DataSet(); Ws_TO.Ws_ToSoap wsOperacion = new Ws_TO.Ws_ToSoapClient();
            string lSql = ""; int i = 0;
            if (Tx_nroGuiaI.Text.Trim().Length > 0)
            {
              
                lSql = string.Concat(" update  detallepesajeCamion set NroGuiaINET=",Tx_nroGuiaI .Text , "," );
                lSql = string.Concat(lSql, "  PesoGuiaINET=", Tx_pesoGuiaINET.Text, " "  );
                lSql = string.Concat(lSql, "   WHERE idPesajeCamion=", Tx_idPEsajeCam.Text , " and IdDespachoCamion=", Tx_IdDespacho.Text );

                lDts = wsOperacion.ObtenerDatos(lSql);

                Tx_IdDespacho.Text = "";
                CargaDatosBascula(Lbl_nroGuia.Text);
            }
        }

        private void Dtg_DespachoPAtente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int lIndex = e.RowIndex;
            if (lIndex > -1)
            {
                Cursor.Current = Cursors.WaitCursor;
                Tx_IdDespacho.Text = Dtg_DespachoPAtente.Rows[lIndex].Cells["Des_cam_id"].Value.ToString(); 
                Tx_nroGuiaI.Text = Dtg_DespachoPAtente.Rows[lIndex].Cells["NroGuiaINET"].Value.ToString();
                Tx_idPEsajeCam.Text = "";
                Tx_pesoGuiaINET.Text = Dtg_DespachoPAtente.Rows[lIndex].Cells["Kgs"].Value.ToString();
                Cursor.Current = Cursors.Default;
            }
        }

        private void Btn_BuscaPat_Click(object sender, EventArgs e)
        {
            DataView lVista = null;DataTable lTblDatos = new DataTable();
            if (Tx_PatenteBuscar.Text.Trim().Length > 0)
            {
                lTblDatos = (DataTable ) dataGridView1.DataSource;
                lVista = new DataView(lTblDatos, string.Concat("Patente='", Tx_PatenteBuscar.Text, "'"), "", DataViewRowState.CurrentRows);
                dataGridView1.DataSource = lVista;
            }
        }
    }
}
