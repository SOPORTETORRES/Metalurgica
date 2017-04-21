using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Metalurgica.Models
{
    public class Tipo_DireccionDespacho
    {

        private string  _Direccion = "";
    private string  _Comuna  = "";
    private string  _Ciudad = "";


         public string   Direccion
        {
            get { return _Direccion; }
            set { _Direccion = value; }
        }

    public string  Comuna
        {
            get { return _Comuna; }
            set { _Comuna = value; }
        }

        public string  Ciudad
        {
            get { return _Ciudad; }
            set { _Ciudad = value; }
        }

      }
}
