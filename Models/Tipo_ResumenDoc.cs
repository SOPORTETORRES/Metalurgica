using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Metalurgica.Models
{
   public  class Tipo_ResumenDoc
    {       
    private string  _TotalNeto  = "";
    private string _CodigoDescuento = "";
    private string  _TotalDescuento  = "";
    private string  _TotalIVA = "";
    private string  _TotalOtrosImpuestos = "";
    private string  _TotalDoc = "";

           public string  TotalNeto
        {
            get { return _TotalNeto; }
            set { _TotalNeto = value; }
        }

       public string  CodigoDescuento
        {
            get { return _CodigoDescuento; }
            set { _CodigoDescuento = value; }
        }

        public string  TotalDescuento
        {
            get { return _TotalDescuento; }
            set { _TotalDescuento = value; }
        }


           public string  TotalIVA
        {
            get { return _TotalIVA; }
            set { _TotalIVA = value; }
        }

            public string  TotalOtrosImpuestos
        {
            get { return _TotalOtrosImpuestos; }
            set { _TotalOtrosImpuestos = value; }
        }

       public string  TotalDoc
        {
            get { return _TotalDoc; }
            set { _TotalDoc = value; }
        }

    }
}
