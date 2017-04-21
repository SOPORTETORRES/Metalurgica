using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Metalurgica.Models
{
    class Tipo_DetDoc
    {

            private List <Tipo_Items > _Items=new List<Tipo_Items>() ;

        public List <Tipo_Items >   Items
        {
            get { return _Items; }
            set { _Items = value; }
        }

    //Public Property Items() As List(Of Tipo_Items)
    //    Get
    //        Items = _Items
    //    End Get
    //    Set(ByVal value As List(Of Tipo_Items))
    //        _Items = value
    //    End Set
    //End Property
    }
}
