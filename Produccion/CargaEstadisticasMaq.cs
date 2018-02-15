using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Metalurgica.Produccion
{
    public partial class CargaEstadisticasMaq : Form
    {
        private DataTable mTblMaq = new DataTable();
        private DataTable mTblDiam = new DataTable();
        private DataTable mTblFinal = new DataTable();

        public CargaEstadisticasMaq()
        {
            InitializeComponent();
        }

        private void Btn_buscar_Click(object sender, EventArgs e)
        {
            //CargaDatos();
            //CargaDatos_PorHora();
            InsertaRegistrosPorHora( );
        }

        private void CargaDatos()

        {
            string lSql = ""; WsCrud.CrudSoapClient lDal = new WsCrud.CrudSoapClient();
            WsCrud.ListaDataSet lDts = new WsCrud.ListaDataSet(); int i = 0;int j = 0;
            int k = 0;DataTable lTmp = new DataTable(); DataRow lFila = null;
         
            lSql = string.Concat("exec  SP_GeneraStadisticasProduccion 1,'','','','','','','' ");
            lDts = lDal.ListarAyudaSql(lSql);
            if ((lDts.MensajeError.Trim().Length == 0) && (lDts.DataSet.Tables.Count > 0))
            {
                mTblMaq = lDts.DataSet.Tables[0];
            }
            lSql = string.Concat("exec  SP_GeneraStadisticasProduccion 2,'','','','','','','' ");
            lDts = lDal.ListarAyudaSql(lSql);
            if ((lDts.MensajeError.Trim().Length == 0) && (lDts.DataSet.Tables.Count > 0))
            {
                mTblDiam  = lDts.DataSet.Tables[0];
            }
            //dia	turno	NroMaq	diam	Inicio	Fin	Kgs	NroHoras
            mTblFinal.Columns.Add("Fecha", Type.GetType("System.String"));
            mTblFinal.Columns.Add("Turno", Type.GetType("System.String"));
            mTblFinal.Columns.Add("NroMaq", Type.GetType("System.String"));
            mTblFinal.Columns.Add("diam", Type.GetType("System.String"));
            mTblFinal.Columns.Add("Inicio", Type.GetType("System.String"));
            mTblFinal.Columns.Add("Fin", Type.GetType("System.String"));
            mTblFinal.Columns.Add("Kgs", Type.GetType("System.String"));
            mTblFinal.Columns.Add("NroHoras", Type.GetType("System.String"));

            for (i = 0; i < mTblMaq.Rows.Count; i++)
            {
                for (j = 0; j < mTblDiam.Rows.Count; j++)
                {
                    for (k = 1; k <32; k++)
                    {
                        lSql = string.Concat("exec  SP_GeneraStadisticasProduccion 3,'", mTblMaq.Rows [i]["Maq_Nro"].ToString (), "','", mTblDiam.Rows[j]["par1"].ToString(),"','2018','1','",k,"','','' ");
                        lDts = lDal.ListarAyudaSql(lSql);
                        if ((lDts.MensajeError.Trim().Length == 0) && (lDts.DataSet.Tables.Count > 0))
                        {
                            lTmp = lDts.DataSet.Tables[0];
                            if (lTmp.Rows.Count > 0)
                            {
                           
                            lFila = mTblFinal.NewRow();
                            lFila["Fecha"] = string.Concat (k,"/01/2018");
                            lFila["Turno"] = "Dia";
                            lFila["NroMaq"] = mTblMaq.Rows [i]["Maq_nro"].ToString ();
                            lFila["diam"] = mTblDiam.Rows[j]["PAr1"].ToString();
                            lFila["Inicio"] = lTmp.Rows[0]["Inicio"].ToString(); 
                            lFila["Fin"] = lTmp.Rows[0]["Fin"].ToString();
                            lFila["Kgs"] = lTmp.Rows[0]["Kgs"].ToString();
                            lFila["NroHoras"] = lTmp.Rows[0]["Dif"].ToString();
                            mTblFinal.Rows.Add(lFila);
                            }
                        }
                    }
                }
            }
            Dtg_Datos.DataSource = mTblFinal;
        }


        private void CargaDatos_PorMes()

        {
            string lSql = ""; WsCrud.CrudSoapClient lDal = new WsCrud.CrudSoapClient();
            WsCrud.ListaDataSet lDts = new WsCrud.ListaDataSet(); int i = 0; int j = 0;
            int k = 0; DataTable lTmp = new DataTable(); DataRow lFila = null;

            lSql = string.Concat("exec  SP_GeneraStadisticasProduccion 1,'','','','','','','' ");
            lDts = lDal.ListarAyudaSql(lSql);
            if ((lDts.MensajeError.Trim().Length == 0) && (lDts.DataSet.Tables.Count > 0))
            {
                mTblMaq = lDts.DataSet.Tables[0];
            }
            //lSql = string.Concat("exec  SP_GeneraStadisticasProduccion 2,'','','','','','','' ");
            //lDts = lDal.ListarAyudaSql(lSql);
            //if ((lDts.MensajeError.Trim().Length == 0) && (lDts.DataSet.Tables.Count > 0))
            //{
            //    mTblDiam = lDts.DataSet.Tables[0];
            //}
            //dia	turno	NroMaq	diam	Inicio	Fin	Kgs	NroHoras
            mTblFinal.Columns.Add("NroMaq", Type.GetType("System.String"));
            mTblFinal.Columns.Add("Year", Type.GetType("System.String"));
            mTblFinal.Columns.Add("Mes", Type.GetType("System.String"));
            mTblFinal.Columns.Add("Diametro", Type.GetType("System.String"));
            mTblFinal.Columns.Add("KgsProducido", Type.GetType("System.String"));

        

            for (i = 0; i < mTblMaq.Rows.Count; i++)
            {
                for (j = 0; j < mTblDiam.Rows.Count; j++)
                {
                    for (k = 1; k < 32; k++)
                    {
                        lSql = string.Concat("exec  SP_GeneraStadisticasProduccion 3,'", mTblMaq.Rows[i]["Maq_Nro"].ToString(), "','", mTblDiam.Rows[j]["par1"].ToString(), "','2018','1','", k, "','','' ");
                        lDts = lDal.ListarAyudaSql(lSql);
                        if ((lDts.MensajeError.Trim().Length == 0) && (lDts.DataSet.Tables.Count > 0))
                        {
                            lTmp = lDts.DataSet.Tables[0];
                            if (lTmp.Rows.Count > 0)
                            {

                                lFila = mTblFinal.NewRow();
                                lFila["Fecha"] = string.Concat(k, "/01/2018");
                                lFila["Turno"] = "Dia";
                                lFila["NroMaq"] = mTblMaq.Rows[i]["Maq_nro"].ToString();
                                lFila["diam"] = mTblDiam.Rows[j]["PAr1"].ToString();
                                lFila["Inicio"] = lTmp.Rows[0]["Inicio"].ToString();
                                lFila["Fin"] = lTmp.Rows[0]["Fin"].ToString();
                                lFila["Kgs"] = lTmp.Rows[0]["Kgs"].ToString();
                                lFila["NroHoras"] = lTmp.Rows[0]["Dif"].ToString();
                                mTblFinal.Rows.Add(lFila);
                            }
                        }
                    }
                }
            }
            Dtg_Datos.DataSource = mTblFinal;
        }


        private void CargaDatos_PorHora()

        {
            string lSql = ""; WsCrud.CrudSoapClient lDal = new WsCrud.CrudSoapClient();
            WsCrud.ListaDataSet lDts = new WsCrud.ListaDataSet(); int i = 0; int j = 0;
            int k = 0; DataTable lTmp = new DataTable(); DataRow lFila = null;
            string lInicio = ""; string lFin = ""; int p = 0; int lHini = 0;  

            lSql = string.Concat("exec  SP_GeneraStadisticasProduccion 1,'','','','','','','' ");
            lDts = lDal.ListarAyudaSql(lSql);
            if ((lDts.MensajeError.Trim().Length == 0) && (lDts.DataSet.Tables.Count > 0))
            {
                mTblMaq = lDts.DataSet.Tables[0];
            }
            lSql = string.Concat("exec  SP_GeneraStadisticasProduccion 2,'','','','','','','' ");
            lDts = lDal.ListarAyudaSql(lSql);
            if ((lDts.MensajeError.Trim().Length == 0) && (lDts.DataSet.Tables.Count > 0))
            {
                mTblDiam = lDts.DataSet.Tables[0];
            }
            //dia	turno	NroMaq	diam	Inicio	Fin	Kgs	NroHoras
            mTblFinal.Columns.Add("Fecha", Type.GetType("System.String"));
            mTblFinal.Columns.Add("NroMaq", Type.GetType("System.String"));
            mTblFinal.Columns.Add("00-01", Type.GetType("System.String"));
            mTblFinal.Columns.Add("01-02", Type.GetType("System.String"));
            mTblFinal.Columns.Add("02-03", Type.GetType("System.String"));
            mTblFinal.Columns.Add("03-04", Type.GetType("System.String"));
            mTblFinal.Columns.Add("04-05", Type.GetType("System.String"));
            mTblFinal.Columns.Add("05-06", Type.GetType("System.String"));
            mTblFinal.Columns.Add("06-07", Type.GetType("System.String"));
            mTblFinal.Columns.Add("07-08", Type.GetType("System.String"));
            mTblFinal.Columns.Add("08-09", Type.GetType("System.String"));
            mTblFinal.Columns.Add("09-10", Type.GetType("System.String"));
            mTblFinal.Columns.Add("10-11", Type.GetType("System.String"));
            mTblFinal.Columns.Add("11-12", Type.GetType("System.String"));
            mTblFinal.Columns.Add("12-13", Type.GetType("System.String"));
            mTblFinal.Columns.Add("13-14", Type.GetType("System.String"));
            mTblFinal.Columns.Add("14-15", Type.GetType("System.String"));
            mTblFinal.Columns.Add("15-16", Type.GetType("System.String"));
            mTblFinal.Columns.Add("16-17", Type.GetType("System.String"));
            mTblFinal.Columns.Add("17-18", Type.GetType("System.String"));
            mTblFinal.Columns.Add("18-19", Type.GetType("System.String"));
            mTblFinal.Columns.Add("19-20", Type.GetType("System.String"));
            mTblFinal.Columns.Add("20-21", Type.GetType("System.String"));
            mTblFinal.Columns.Add("21-22", Type.GetType("System.String"));
            mTblFinal.Columns.Add("22-23", Type.GetType("System.String"));
            mTblFinal.Columns.Add("23-00", Type.GetType("System.String"));


            for (k = 1; k < 32; k++)  //(i = 0; i < mTblMaq.Rows.Count; i++)
            {
                //for (j = 0; j < mTblDiam.Rows.Count; j++)
                //{
                    for (i = 0; i < mTblMaq.Rows.Count; i++)  //(k = 1; k < 32; k++)  //
                {
                    lFila = mTblFinal.NewRow();
                    lFila["Fecha"] = string.Concat(k, "/01/2018");
                    lFila["NroMaq"] = mTblMaq.Rows[i]["Maq_nombre"].ToString();
                    for (p = 0; p < 24; p++)
                        {
                           lHini = p;
                            lInicio = string.Concat ("'",k,"/01/2018 ", lHini.ToString (),":00:00'");
                           
                            lFin =  string.Concat("'", k, "/01/2018 ", lHini.ToString(), ":59:59'");
                            lSql = string.Concat("exec  SP_GeneraStadisticasProduccion 4,'", mTblMaq.Rows[i]["Maq_Nro"].ToString(), "',", lInicio, ",", lFin ,",'','','','' ");
                            lDts = lDal.ListarAyudaSql(lSql);                         
                            if ((lDts.MensajeError.Trim().Length == 0) && (lDts.DataSet.Tables.Count > 0))
                            {
                                lTmp = lDts.DataSet.Tables[0];
                                if (lTmp.Rows.Count > 0)
                                {
                                    lFila[p + 2] = lTmp.Rows[0]["Kgs"].ToString();
                                }
                                else
                                    lFila[p + 2] = "0";
                            }
                        }
                    mTblFinal.Rows.Add(lFila);
                }
               
                //}
            }
            Dtg_Datos.DataSource = mTblFinal;
        }

        private void InsertaRegistrosPorHora()

        {
            string lSql = ""; WsCrud.CrudSoapClient lDal = new WsCrud.CrudSoapClient();
            WsCrud.ListaDataSet lDts = new WsCrud.ListaDataSet(); int i = 0; int j = 0;int lcont = 0;
            int k = 0; DataTable lTmp = new DataTable(); DataRow lFila = null;string lMes = ""; string lAño = "";
            string lInicio = ""; string lFin = ""; int p = 0; int lHini = 0;DateTime lFechaIni = new DateTime(2015,12, 1);
            DataTable lTblTmp = new DataTable(); WsCrud.ListaDataSet lDtsTmp = new WsCrud.ListaDataSet();

            lSql = string.Concat("exec  SP_GeneraStadisticasProduccion 1,'','','','','','','' ");
            lDts = lDal.ListarAyudaSql(lSql);
            if ((lDts.MensajeError.Trim().Length == 0) && (lDts.DataSet.Tables.Count > 0))
            {
                mTblMaq = lDts.DataSet.Tables[0];
            }
            lSql = string.Concat("exec  SP_GeneraStadisticasProduccion 2,'','','','','','','' ");
            lDts = lDal.ListarAyudaSql(lSql);
            if ((lDts.MensajeError.Trim().Length == 0) && (lDts.DataSet.Tables.Count > 0))
            {
                mTblDiam = lDts.DataSet.Tables[0];
            }

            int lNroDias = DateTime.DaysInMonth(lFechaIni.Year, lFechaIni.Month);
            string  ldiam = ""; string lKgs = "";
            for (lcont  = 1; lcont <25; lcont++)
            {
                lFechaIni = lFechaIni.AddMonths (1);
                 lNroDias = DateTime.DaysInMonth(lFechaIni.Year, lFechaIni.Month);
                for (k = 1; k < (lNroDias+1); k++)  //(i = 0; i < mTblMaq.Rows.Count; i++)
            {
                //for (j = 0; j < mTblDiam.Rows.Count; j++)
                //{
                for (i = 0; i < mTblMaq.Rows.Count; i++)  //(k = 1; k < 32; k++)  //
                {
                    //lFila = mTblFinal.NewRow();
                    //lFila["Fecha"] = string.Concat(k, "/01/2018");
                    //lFila["NroMaq"] = mTblMaq.Rows[i]["Maq_nombre"].ToString();
                    for (p = 0; p < 24; p++)
                    {
                        lMes = lFechaIni.Month.ToString ();lAño = lFechaIni.Year.ToString ();
                        lHini = p;
                        lInicio = string.Concat("'", k, "/0",lMes  , "/", lAño ," ", lHini.ToString(), ":00:00'");

                        lFin = string.Concat("'", k, "/0",lMes ,"/", lAño,  " ", lHini.ToString(), ":59:59'");
                        lSql = string.Concat("exec  SP_GeneraStadisticasProduccion 4,'", mTblMaq.Rows[i]["Maq_Nro"].ToString(), "',", lInicio, ",", lFin, ",'','','','' ");
                        lDts = lDal.ListarAyudaSql(lSql);
                        if ((lDts.MensajeError.Trim().Length == 0) && (lDts.DataSet.Tables.Count > 0))
                        {
                            lTmp = lDts.DataSet.Tables[0];
                            if (lTmp.Rows.Count > 0)
                            {
                                ldiam = lTmp.Rows[0]["Diametro"].ToString();
                                lKgs= lTmp.Rows[0]["Kgs"].ToString();
                               // lFila[p + 2] = lTmp.Rows[0]["Kgs"].ToString();
                            }
                            else
                            {
                                // lFila[p + 2] = "0";
                                ldiam = "";
                                lKgs = "";
                            }

                            if ((ldiam.Trim().Length > 0) && (lKgs.Trim().Length > 0))
                            {
                                lSql = "Insert into Prod_PorHora (MaqNro,Year,Mes,Dia,Hora,Diametro,KgsProducido) values (";
                                lSql = string.Concat(lSql, mTblMaq.Rows[i]["Maq_Nro"].ToString(), ",",lAño ,",",lMes ,",", k, ",", lHini, ",", ldiam, ",", lKgs, ")");
                                lDtsTmp = lDal.ListarAyudaSql(lSql);
                            }

                            label3.Text = string.Concat("Revisando  registro;", k, " de ", (lNroDias + 1));
                            label3.Refresh();Application.DoEvents();
                            //lTblTmp
                        }
                    }
                    //mTblFinal.Rows.Add(lFila);
                }

                //}
            }
            }
            MessageBox.Show("Fin");
          //  Dtg_Datos.DataSource = mTblFinal;
        }


    }
}
