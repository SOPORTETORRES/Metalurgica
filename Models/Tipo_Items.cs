using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Metalurgica.Models
{
    public class Tipo_Items
    {

    //    '    <NumItem>1</NumItem>
    //'<Producto>

    //'</Producto>
    //'<PrecioRef>460.0000</PrecioRef>
    //'<Cantidad>292.0000</Cantidad>
    //'<TotalDocLin>134320.00</TotalDocLin>

    private string _NumItem ="";
    private string _Producto_Vta ="";
    private string _PrecioRef ="";
    private string _Cantidad ="";
    private string _TotalDocLin ="";


    public string   NumItem
        {
            get { return _NumItem; }
            set { _NumItem = value; }
        }

    public string   Producto_Vta
        {
            get { return _Producto_Vta; }
            set { _Producto_Vta = value; }
        }

    public string   PrecioRef
        {
            get { return _PrecioRef; }
            set { _PrecioRef = value; }
        }

    public string   Cantidad
        {
            get { return _Cantidad; }
            set { _Cantidad = value; }
        }

    public string   TotalDocLin
        {
            get { return _TotalDocLin; }
            set { _TotalDocLin = value; }
        }

    }
}
