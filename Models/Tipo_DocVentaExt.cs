using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Metalurgica.Models
{
    public class Tipo_DocVentaExt
    {

        private Tipo_EntDoc  _EntDoc =new Tipo_EntDoc() ;
        //private object  _DetDoc = new object ();
        private List<Tipo_Items> _DetDoc =new List<Tipo_Items>() ;
        private Tipo_ResumenDoc  _ResumenDoc =new Tipo_ResumenDoc ();


        public Tipo_EntDoc  EntDoc
        {
            get { return _EntDoc; }
            set { _EntDoc = value; }
        }

        public List<Tipo_Items> DetDoc
        {
            get { return _DetDoc; }
            set { _DetDoc = value; }
        }


           public Tipo_ResumenDoc  ResumenDoc
        {
            get { return _ResumenDoc; }
            set { _ResumenDoc = value; }
        }


    }
}
