using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Metalurgica.Models
{
    public class Tipo_Cliente
    {
        private Tipo_Identificacion  _Identificacion =new Tipo_Identificacion ();
    private Tipo_DireccionDespacho  _DirDespacho=new Tipo_DireccionDespacho ();
    private  Tipo_Facturacion  _Facturacion=new Tipo_Facturacion ();
    

      public Tipo_Identificacion   Identificacion 
        {
            get { return _Identificacion ; }
            set { _Identificacion  = value; }
        }

        public Tipo_DireccionDespacho   DirDespacho
        {
            get { return _DirDespacho ; }
            set { _DirDespacho  = value; }
        }


        public Tipo_Facturacion   Facturacion
        {
            get { return _Facturacion ; }
            set { _Facturacion  = value; }
        }

      }
}
