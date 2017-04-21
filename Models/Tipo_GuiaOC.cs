using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Metalurgica.Models
{
    public class Tipo_GuiaOC
    {

        private string _OC = "";
        private string _Viajes = "";
        private string _IdIt = "";
        private string _DespachosCamion = "";

        public string OC
        {
            get { return _OC; }
            set { _OC = value; }
        }

        public string Viajes
        {
            get { return _Viajes; }
            set { _Viajes = value; }
        }


        public string DespachosCamion
        {
            get { return _DespachosCamion; }
            set { _DespachosCamion = value; }
        }

        public string IdIt
        {
            get { return _IdIt; }
            set { _IdIt = value; }
        }

    }
}
