using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Metalurgica.Models
{
    public class Tipo_MovExistenciasAll
    {

    //     ' <TMETIP>2</TMETIP>                        1
    //'<TMECOD>30</TMECOD>                        2
    //'<MOVSUCCOD>1</MOVSUCCOD>                   3
    //'<MOVNUMDOC>433</MOVNUMDOC>                 4
    //'<MOVFECDOC>2013-07-06</MOVFECDOC>          5
    //'<MOVFECDIG>2013-07-06</MOVFECDIG>          6
    //'<MOVHORDIG>15:35:56</MOVHORDIG>            7
    //'<MOVBODCOD>1</MOVBODCOD>                   8
    //'<MOVBODSUC>1</MOVBODSUC>                   9
    //'<MOVGLO1>CONSUMO DIARIO-DICIEMBRE</MOVGLO1>10
    //'<MOVGLO2/>                                 11
    //'<MOVSIS>1</MOVSIS>                         12
    //'<MOVULTSEC>1</MOVULTSEC>                   13
    //'<MOVVALTOT>2038264.00</MOVVALTOT>          14

    private string  _TMETIP = ""; //         '1
    private string _TMECOD = ""; //         '2
    private string _MOVSUCCOD = ""; //     '3
    private string  _MOVNUMDOC= ""; //      '4
    private string  _MOVFECDOC = ""; //    '5
    private string  _MOVFECDIG = ""; //    '6
    private string  _MOVHORDIG = ""; //    '7
    private string  _MOVBODCOD= ""; //   '8
    private string  _MOVBODSUC = ""; //    '9
    private string  _MOVGLO1 = ""; //    '10
    private string  _MOVGLO2= ""; //    '11
    private string  _MOVSIS = ""; //   '12
    private string  _MOVULTSEC = ""; //   '13
    private string  _MOVVALTOT = ""; //    '14
    private string  _ERR = ""; //    '15




    //'1
         public string  TMETIP
        {
            get { return _TMETIP; }
            set { _TMETIP = value; }
        }

    //'2
          public string  TMECOD
        {
            get { return _TMECOD; }
            set { _TMECOD = value; }
        }


    //'3
        public string  MOVSUCCOD
        {
            get { return _MOVSUCCOD; }
            set { _MOVSUCCOD = value; }
        }


    //'4
        public string  MOVNUMDOC
        {
            get { return _MOVNUMDOC; }
            set { _MOVNUMDOC = value; }
        }


    //'5
           public string  MOVFECDOC
        {
            get { return _MOVFECDOC; }
            set { _MOVFECDOC = value; }
        }


    //'6
               public string  MOVFECDIG
        {
            get { return _MOVFECDIG; }
            set { _MOVFECDIG = value; }
        }


    //'7
         public string  MOVHORDIG
        {
            get { return _MOVHORDIG; }
            set { _MOVHORDIG = value; }
        }


    //'8
               public string  MOVBODCOD
        {
            get { return _MOVBODCOD; }
            set { _MOVBODCOD = value; }
        }


    //'9
        public string  MOVBODSUC
        {
            get { return _MOVBODSUC; }
            set { _MOVBODSUC = value; }
        }


    //'10
        public string  MOVGLO1
        {
            get { return _MOVGLO1; }
            set { _MOVGLO1 = value; }
        }


    //'11
              public string  MOVGLO2
        {
            get { return _MOVGLO2; }
            set { _MOVGLO2 = value; }
        }


    //'12
         public string  MOVSIS
        {
            get { return _MOVSIS; }
            set { _MOVSIS = value; }
        }


    //'13
                public string  MOVULTSEC
        {
            get { return _MOVULTSEC; }
            set { _MOVULTSEC = value; }
        }

    //'14
                        public string  MOVVALTOT
        {
            get { return _MOVVALTOT; }
            set { _MOVVALTOT = value; }
        }


    //'15
                         public string  ERR
        {
            get { return _ERR; }
            set { _ERR = value; }
        }


    }
}
