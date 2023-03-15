using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Metalurgica.Pruebas
{
    public partial class Frm_Impresion : Form
    {
        public Frm_Impresion()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VerImpresoras();
        }

        private void VerImpresoras()
        {
            DataTable lTbl = new DataTable(); DataRow lFila = null;


            lTbl.Columns.Add("Impresora");

            foreach (String strPrinter in System.Drawing.Printing.PrinterSettings.InstalledPrinters)

            {
                lFila = lTbl.NewRow();
                lFila["Impresora"] = strPrinter;
                lTbl.Rows.Add(lFila);
               // MessageBox.Show(strPrinter);
            }
            dtg_Impresoras.DataSource = lTbl;
        }

        private void Btn_GeneraTurno_Click(object sender, EventArgs e)
        {
            GeneraTurnoENLog();
        }

        private void GeneraTurnoENLog()
        {
            Ws_TO.Ws_ToSoap lPx = new Ws_TO.Ws_ToSoapClient(); string lSql = "";
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable();
            int i = 0; string lTurno = ""; string lHoraStr = "";
            DateTime lFecha = DateTime.Now; int lHora = 0; string lId = "";int lCon = 0;

            lSql = " Select Count(1)  from  LOG_PIEZA_PRODUCCION where  year(log_fecha)=2018 and LOG_TURNO is null";
            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                lCon = int.Parse (lDts.Tables[0].Rows[0][0].ToString());
            }

            while (lCon > 0 )
            {
            //    Console.Write(x);
            //    Console.Write(" - ");
            //    x = x + 1;
            //}

            //if (lCon > 0)
            //{
                lSql = " Select top 4000 * from   LOG_PIEZA_PRODUCCION where  year(log_fecha)=2018 and LOG_TURNO is null";
                lDts = lPx.ObtenerDatos(lSql);
                if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                {
                    lTbl = lDts.Tables[0].Copy();
                    for (i = 0; i < lTbl.Rows.Count; i++)
                    {
                        lFecha = DateTime.Parse(lTbl.Rows[i]["Log_Fecha"].ToString());
                        lHoraStr = lFecha.ToString("HH");
                        lHora = int.Parse(lHoraStr);
                        lTurno = "";
                        if ((lHora > 7) && (lHora < 20))
                        {
                            lTurno = "Dia";
                        }
                        else
                        {
                            lTurno = "Noche";

                        }

                        lId = lTbl.Rows[i]["Log_Id"].ToString();
                        if (lTurno.Trim().Length > 2)
                        {
                            lSql = string.Concat(" update LOG_PIEZA_PRODUCCION set LOG_TURNO='", lTurno, "' where log_Id=", lId);
                            Lbl_MsgTurno.Text = string.Concat(i, "  de  ", lTbl.Rows.Count);
                            this.Refresh();
                            Application.DoEvents();
                            lPx.ObtenerDatos(lSql);
                        }
                    }

                    lSql = " Select Count(1)  from  LOG_PIEZA_PRODUCCION where  year(log_fecha)=2018 and LOG_TURNO is null";
                    lDts = lPx.ObtenerDatos(lSql);
                    if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                    {
                        lCon = int.Parse(lDts.Tables[0].Rows[0][0].ToString());
                    }
                }
            }
        }

        private void Btn_Api_Click(object sender, EventArgs e)
        {

        }
    }
}
