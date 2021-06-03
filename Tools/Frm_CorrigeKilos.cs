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
    public partial class Frm_CorrigeKilos : Form
    {
        public Frm_CorrigeKilos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CorrigeKgs();
        }


        private void  CorrigeKgs()
        {
            char[] delimiterChars = { '-' }; string[] words = Tx_tx .Text .Split(delimiterChars);
            int i = 0;

            for (i = 0; i < words.Length; i++)
            {
                ProcesaKgsPieza(words[i].ToString());
            }



        }


        private void ProcesaKgsPieza(string  iIdPiezaTipoB)
        {
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient(); DataTable lTbl = new DataTable();
            string lSql = string.Concat (" select * from piezastipob where ID=", iIdPiezaTipoB); int ldiferencia = 0;
            DataTable lTBlP = new DataTable(); string lKgs = "0"; string lKgsReales = "0"; string lKgsMal = "0";
            string lIdPieza = "0"; string lIdMov = "0"; DataSet lDts = new DataSet(); string lIdPaquete = "0";

            lDts = lPx.ObtenerDatos(lSql);
            if (lDts.Tables.Count > 0 && lDts.Tables[0].Rows.Count > 0)
            {
                lTbl = lDts.Tables[0].Copy();
                lKgs = lTbl.Rows[0]["TotalKgs"].ToString();
                lKgsReales = lTbl.Rows[0]["PesoReal"].ToString();
                lSql = string.Concat(" select * from piezas  where IdPiezaTipoB=", iIdPiezaTipoB);
                lDts = lPx.ObtenerDatos(lSql);
                if (lDts.Tables.Count > 0 && lDts.Tables[0].Rows.Count > 0)
                {
                    lTbl = lDts.Tables[0].Copy();
                    lIdPieza = lTbl.Rows[0]["Id"].ToString();
                    lIdMov = lTbl.Rows[0]["IdMov"].ToString();
                    lKgsMal = lTbl.Rows[0]["TotalKgs"].ToString();
                    lSql = string.Concat(" Select Count (1) from detallepaquetesPieza where  IdPieza=", lIdPieza);
                    lDts = lPx.ObtenerDatos(lSql);
                    if ((lDts.Tables[0].Rows.Count > 0) && (int.Parse(lDts.Tables[0].Rows[0][0].ToString()) == 1))
                    {
                        lSql = string.Concat(" update  piezas set totalKgs='", lKgs, "',  pesoReal='", lKgsReales, "' where IDpiezaTipoB=", iIdPiezaTipoB);
                        lPx.ObtenerDatos(lSql);
                        // lSql = string.Concat(" select * from piezas  where IdPiezaTipoB=", iIdPiezaTipoB);

                        lSql = string.Concat(" update  detallepaquetesPieza set KgsPaquete='", lKgs, "',  kgsReales='", lKgsReales, "' where IdPieza=", lIdPieza);
                        lDts = lPx.ObtenerDatos(lSql);

                        lSql = string.Concat(" update  Movimientos set PesoAsignado='", lKgs, "',  kilosTotales='", lKgsReales, "' where Id=", lIdMov);
                        lDts = lPx.ObtenerDatos(lSql);
                    }
                    else
                    {
                        lSql = string.Concat(" Select  top 1 id  from detallepaquetesPieza where  IdPieza=", lIdPieza, " Order by id desc ");
                        lDts = lPx.ObtenerDatos(lSql);
                        ldiferencia = int.Parse(lKgsMal) - int.Parse(lKgs);
                        if ((lDts.Tables[0].Rows.Count > 0))
                        {
                            lIdPaquete = lDts.Tables[0].Rows[0][0].ToString();
                            lSql = string.Concat(" update  piezas set totalKgs='", lKgs, "',  pesoReal='", lKgsReales, "' where IDpiezaTipoB=", iIdPiezaTipoB);
                            lPx.ObtenerDatos(lSql);

                            lSql = string.Concat(" update   detallepaquetesPieza set  KgsPaquete=KgsPaquete-'", ldiferencia, "',  kgsReales=kgsReales-'", ldiferencia, "' where Id=", lIdPaquete);
                            lPx.ObtenerDatos(lSql);

                            lSql = string.Concat(" update  Movimientos set PesoAsignado='", lKgs, "',  kilosTotales='", lKgsReales, "' where Id=", lIdMov);
                            lDts = lPx.ObtenerDatos(lSql);

                        }
                    }
                }

            }

        }


    }
}
