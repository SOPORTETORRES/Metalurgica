using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Metalurgica.Models
{
    public class Tipo_InvocaWS
    {
         private int  _Id = 0;
        private  int _IdDespachoCamion = 0;
        private string  _PatenteCamion = "";
        private int _IdObra = 0;
        private string _XML_Enviado ="";
        private string  _XML_Respuesta = "";
        private string _URL_WS = "";
        private string   _Origen = "";
        private string  _Err = "";

          public int  Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

         public int  IdDespachoCamion
        {
            get { return _IdDespachoCamion; }
            set { _IdDespachoCamion = value; }
        }

         public string  PatenteCamion
        {
            get { return _PatenteCamion; }
            set { _PatenteCamion = value; }
        }

           public int  IdObra
        {
            get { return _IdObra; }
            set { _IdObra = value; }
        }

      public string  XML_Enviado
        {
            get { return _XML_Enviado; }
            set { _XML_Enviado = value; }
        }

        public string  XML_Respuesta
        {
            get { return _XML_Respuesta; }
            set { _XML_Respuesta = value; }
        }


        public string  URL_WS
            {
                get { return _URL_WS; }
                set { _URL_WS = value; }
            }

        public string  Origen
        {
            get { return _Origen; }
            set { _Origen = value; }
        }

        public string  Err
        {
            get { return _Err; }
            set { _Err = value; }
        }

    }
}
