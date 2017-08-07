using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Metalurgica.Clases
{
    public class SqlBascula
    {
        public string ObtenerSqlTara(string iPatente, string iFecha)
        {
            string lSq = "";string lFechaIni = string.Concat(iFecha, " 00:00:00");
            string lFechaFin = string.Concat(iFecha, " 23:59:59");
            string[] lPartes = null; string lDia = ""; string lMes = ""; string lYear = "";


            lPartes = iFecha.Split(new Char[] { '/' });
            if (lPartes.Length  == 1)
            {
                lPartes = iFecha.Split(new Char[] { '-' });
            }

            if (lPartes.Length > 0)
            {
                lDia = lPartes[0].ToString (); lMes = lPartes[1].ToString();
                lYear = lPartes[2].ToString();
                lSq = string.Concat(" select *  from correlativos where patente='", iPatente, "'  and PesoBruto=0 ");
                //lSq = string.Concat(lSq, " and (Fecha BETWEEN #", lFechaIni, "# AND #", lFechaFin, "#) ");
                lSq = string.Concat(lSq, " and  DatePart('yyyy', Fecha)=", lYear, "   ");
                lSq = string.Concat(lSq, " and  DatePart('d', Fecha)=", lDia, "   ");
                lSq = string.Concat(lSq, " and  DatePart('m', Fecha)=", lMes, "   ");
            }

              
            return lSq;
        }


        public string ObtenerSqlPesoBruto(string iPatente, string iFecha, int iPesoTara)
        {
            string lSq = ""; string lFechaIni = string.Concat(iFecha, " 00:00:00");
            string lFechaFin = string.Concat(iFecha, " 23:59:59");
            string[] lPartes = null; int lDia = 0; string lMes = ""; string lYear = "";


            lPartes = iFecha.Split(new Char[] { '/' });
            if (lPartes.Length == 1)
            {
                lPartes = iFecha.Split(new Char[] { '-' });
            }

            if (lPartes.Length > 0)
            {
                lDia = int.Parse (lPartes[0].ToString())-1; lMes = lPartes[1].ToString();
                lYear = lPartes[2].ToString();
                lSq = string.Concat(" select top 1 *  from correlativos where patente='", iPatente, "'   ");
                //lSq = string.Concat(lSq, " and (Fecha BETWEEN #", lFechaIni, "# AND #", lFechaFin, "#) ");
                lSq = string.Concat(lSq, " and  DatePart('yyyy', Fecha)=", lYear, "   and PesoTara=", iPesoTara);
                lSq = string.Concat(lSq, " and  ( DatePart('d', Fecha)>", lDia, " or   ( DatePart('d', Fecha)=", lDia,"))");
                lSq = string.Concat(lSq, " and  DatePart('m', Fecha)=", lMes, " order by correlativo desc  ");
            }


            return lSq;
        }


    }
}
