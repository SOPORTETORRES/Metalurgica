using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Metalurgica.Clases.Obj
{
    public class Obj_ElementoProd
    {

        private string _IdUserReporta;
        private string _IdElemento;
       private string _DescripcionElemento;


        public string IdUserReporta
        {
            get { return _IdUserReporta; }
            set { _IdUserReporta = value; }
        }

        public string IdElemento
        {
            get { return _IdElemento; }
            set { _IdElemento = value; }
        }

        public string DescripcionElemento
        {
            get { return _DescripcionElemento; }
            set { _DescripcionElemento = value; }
        }

    }
}
