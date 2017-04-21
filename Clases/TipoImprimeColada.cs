using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Metalurgica.Clases
{
    public  class TipoImprimeColada
    {

        private string _Procedencia;
        private string _Colada;
        private string _Largo_Diametro;
        private string _Kilos;
        private string _NroPaq;
        private string _IdPaqueteColada;
        private string _Resumen;


        public string Procedencia
        {
            get { return _Procedencia; }
            set { _Procedencia = value; }
        }

        public string Colada
        {
            get { return _Colada; }
            set { _Colada = value; }
        }

        public string Largo_Diametr
        {
            get { return _Largo_Diametro; }
            set { _Largo_Diametro = value; }
        }

        public string Kilos
        {
            get { return _Kilos; }
            set { _Kilos = value; }
        }

        public string NroPaq
        {
            get { return _NroPaq; }
            set { _NroPaq = value; }
        }

        public string IdPaqueteColada
        {
            get { return _IdPaqueteColada; }
            set { _IdPaqueteColada = value; }
        }

        public string Resumen
        {
            get { return _Resumen; }
            set { _Resumen = value; }
        }


    }
}
