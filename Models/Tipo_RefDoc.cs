using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Metalurgica.Models
{
    public class Tipo_RefDoc
    {
        private string _NroRefCliente = "";
    private string  _Modulo  = "";
    private string _ObsUno = "";
    private  string _ObsDos = "";
    private string _ObsTre = "";
    private string _NroOrdCom = "";



         public string   NroRefCliente
        {
            get { return _NroRefCliente; }
            set { _NroRefCliente = value; }
        }


        public string   Modulo
        {
            get { return _Modulo; }
            set { _Modulo = value; }
        }

        public string   ObsUno
        {
            get { return _ObsUno; }
            set { _ObsUno = value; }
        }


        public string   ObsDos
        {
            get { return _ObsDos; }
            set { _ObsDos = value; }
        }

    public string   ObsTre
        {
            get { return _ObsTre; }
            set { _ObsTre = value; }
        }

    
        public string   NroOrdCom
        {
            get { return _NroOrdCom; }
            set { _NroOrdCom = value; }
        }

    
    }
}
