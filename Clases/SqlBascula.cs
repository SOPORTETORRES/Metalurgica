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
                lSq = string.Concat(" select  top 1 *  from correlativos where patente='", iPatente, "'  and PesoTara=0 ");
                //lSq = string.Concat(lSq, " and (Fecha BETWEEN #", lFechaIni, "# AND #", lFechaFin, "#) ");

                lSq = string.Concat(lSq, " and pesoBruto>0 and Fecha>#", iFecha, "#   ");
                //lSq = string.Concat(lSq, " and  DatePart('d', Fecha)=", lDia, "   ");
                //lSq = string.Concat(lSq, " and  DatePart('m', Fecha)=", lMes, "   ");
                lSq = string.Concat(lSq, "  order by correlativo desc ");
            }

              
            return lSq;
        }

        public string ObtenerSqlPesoBruto(string iPatente, string iFecha)
        {
            string lSq = ""; string lFechaIni = string.Concat(iFecha, " 00:00:00");
            string lFechaFin = string.Concat(iFecha, " 23:59:59");
            string[] lPartes = null; string lDia = ""; string lMes = ""; string lYear = "";


            lPartes = iFecha.Split(new Char[] { '/' });
            if (lPartes.Length == 1)
            {
                lPartes = iFecha.Split(new Char[] { '-' });
            }

            if (lPartes.Length > 0)
            {
                lDia = lPartes[0].ToString(); lMes = lPartes[1].ToString();
                lYear = lPartes[2].ToString();
                lSq = string.Concat(" select  top 1 *  from correlativos where patente='", iPatente, "'  and PesoTara>0 ");
                //lSq = string.Concat(lSq, " and (Fecha BETWEEN #", lFechaIni, "# AND #", lFechaFin, "#) ");
                lSq = string.Concat(lSq, " and pesoBruto>0 and  DatePart('yyyy', Fecha)=", lYear, "   ");
                lSq = string.Concat(lSq, " and  DatePart('d', Fecha)=", lDia, "   ");
                lSq = string.Concat(lSq, " and  DatePart('m', Fecha)=", lMes, "   ");
                lSq = string.Concat(lSq, "  order by correlativo desc ");
            }


            return lSq;
        }

        public string ObtenerSqlTaraInicial( string iFecha)
        {
            string lSq = ""; string lFechaIni = string.Concat(iFecha, " 00:00:00");
            string lFechaFin = string.Concat(iFecha, " 23:59:59");
            string[] lPartes = null; string lDia = ""; string lMes = ""; string lYear = "";


            lPartes = iFecha.Split(new Char[] { '/' });
            if (lPartes.Length == 1)
            {
                lPartes = iFecha.Split(new Char[] { '-' });
            }

            if (lPartes.Length > 0)
            {
                lDia = lPartes[0].ToString(); lMes = lPartes[1].ToString();
                lYear = lPartes[2].ToString();
                lSq = string.Concat(" select  top 1 *  from correlativos where   PesoTara=0 ");
                //lSq = string.Concat(lSq, " and (Fecha BETWEEN #", lFechaIni, "# AND #", lFechaFin, "#) ");
                lSq = string.Concat(lSq, " and pesoBruto>0 and  DatePart('yyyy', Fecha)=", lYear, "   ");
                lSq = string.Concat(lSq, " and  DatePart('d', Fecha)=", lDia, "   ");
                lSq = string.Concat(lSq, " and  DatePart('m', Fecha)=", lMes, "   ");
                lSq = string.Concat(lSq, "  order by correlativo desc ");
            }


            return lSq;
        }

        public string ObtenerSqlPesoBrutoPorFecha(string iPatente, string iFecha)
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
                lDia = int.Parse(lPartes[0].ToString()) - 1; lMes = lPartes[1].ToString();
                lYear = lPartes[2].ToString();
                lSq = string.Concat(" select  *  from correlativos where patente='", iPatente, "'   ");
                //lSq = string.Concat(lSq, " and (Fecha BETWEEN #", lFechaIni, "# AND #", lFechaFin, "#) ");
                lSq = string.Concat(lSq, " and  DatePart('yyyy', Fecha)=", lYear  );
                lSq = string.Concat(lSq, " and  ( DatePart('d', Fecha)>", lDia, " or   ( DatePart('d', Fecha)=", lDia, "))");
                lSq = string.Concat(lSq, " and  DatePart('m', Fecha)=", lMes, " order by correlativo desc  ");
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

        public string ObtenerSqlEstadoProceso(string iCorrelativo)
        {
            string lSq = "";
                lSq = string.Concat(" select  *  from correlativos where correlativo=",iCorrelativo    );
            return lSq;
        }

        public string ObtenerSqlCorrelativo(string iCorrelativo)
        {
            string lSq = "";
            lSq = string.Concat(" select  correlativo, fecha, hora, ticketasociado, patente ,");
            lSq = string.Concat(lSq, " pesoBruto, pesoTara, (pesoBruto- pesoTara) as Bascula ");
            lSq = string.Concat(lSq, "  from correlativos where correlativo=", iCorrelativo);
            return lSq;
        }

        public string ObtenerSqlPorPatenteFecha(string patente, string lYear, string lDia, string lMes, string iHora)
        {
            string lSq = "";
            Clases.ClsComun lcom = new ClsComun();  int dia = lcom .Val (lDia)-1;
            lSq = string.Concat(" select  correlativo, fecha, hora, ticketasociado, patente ,");
            lSq = string.Concat(lSq, " pesoBruto, pesoTara, (pesoBruto- pesoTara) as Bascula ");
            lSq = string.Concat(lSq, "  from correlativos where patente='", patente,"'");
            lSq = string.Concat(lSq, " and  DatePart('yyyy', Fecha)=", lYear   );
            lSq = string.Concat(lSq, " and DatePart('d', Fecha)>", dia);
            lSq = string.Concat(lSq, " and  DatePart('m', Fecha)=", lMes );

            return lSq;
        }

        public string ObtenerSqlGuiasCorrelativos(string iNroGuia)
        {
            string lSq = "";
            lSq = string.Concat(" select  *  from GuiasCorrelativos where NumeroGuia='", iNroGuia,"'");
            return lSq;
        }

        public string ObtenerSqlPesajesDespacho(string iPatente, string iFecha)
        {
            string lSq = "";
            lSq = string.Concat(" select  *  from correlativos where patente='", iPatente,"' and ");
            return lSq;
        }

        public string ObtenerSqlBasculaPorPatente(  int iNroReg, string iPatente)
        {
            string lSq = "";

            lSq = string.Concat(" select top ,", iNroReg ,"  *  from correlativos " );
            lSq = string.Concat("  where patente='", iPatente ,"'");
            return lSq;
        }

        public string ObtenerSqlBascula(int iNroReg, string iPatente)
        {
            string lSq = "";

            lSq = string.Concat(" select top ,", iNroReg, "  *  from correlativos ");
           
            return lSq;
        }


        public string ObtenerSqlPatentesBascula(  )
        {
            string lSq = "";
            //string lFecha = string.Concat("#", iFechaInicio, "#");
            lSq = string.Concat(" SELECT        Patente, COUNT(1) NroReg  FROM            Correlativos ");
            //lSq = string.Concat(" WHERE (Fecha >", lFecha ,")    GROUP BY Patente ");
            lSq = string.Concat(" WHERE(Fecha > #1/1/2018#)    GROUP BY Patente ");
            return lSq;
        }

    }
}
