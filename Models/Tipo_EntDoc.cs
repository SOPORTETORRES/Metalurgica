using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Metalurgica.Models
{
    public class Tipo_EntDoc
    {

        private Tipo_RefDoc  _RefDoc=new Tipo_RefDoc ();
    private Tipo_Cliente  _Cliente =new Tipo_Cliente ();

        public Tipo_RefDoc   RefDoc
        {
            get { return _RefDoc; }
            set { _RefDoc = value; }
        }

        public Tipo_Cliente   Cliente
        {
            get { return _Cliente; }
            set { _Cliente = value; }
        }

    }
}
