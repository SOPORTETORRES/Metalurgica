using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Metalurgica.Models
{
    public class Tipo_Identificacion
    {

        private string  _IdCliente = "";
    private string   _Secuencia  = "";


        public string   IdCliente
        {
            get { return _IdCliente; }
            set { _IdCliente = value; }
        }

        public string   Secuencia
        {
            get { return _Secuencia; }
            set { _Secuencia = value; }
        }


    }
}
