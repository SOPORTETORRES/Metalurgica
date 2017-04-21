using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Metalurgica.Models
{
    public  class Tipo_Facturacion
    {

       private string  _Moneda = "";
    private string  _Tasa = "";
    private string  _CondVenta  = "";
    private string  _Origen = "";
    private string  _DocAGenerar  = "";
    private string  _DocRef = "";
    private string  _NroDoc  = "";
    private string  _Estado  = "";
    private string  _Bodega_Salida = "";
    private string _Bodega_Entrada  = "";
    private string  _IdVendedor = "";
    private string  _Sucursal_Cod  = "";
    private string _ListaPrecio_Cod  = "";
    private  string _Fecha_Atencion = "";
    private  string _Fecha_Documento = "";



        public string   Moneda
        {
            get { return _Moneda; }
            set { _Moneda = value; }
        }

        public string   Tasa
        {
            get { return _Tasa; }
            set { _Tasa = value; }
        }
    
        public string   CondVenta
        {
            get { return _CondVenta; }
            set { _CondVenta = value; }
        }
    
        public string   Origen
        {
            get { return _Origen; }
            set { _Origen = value; }
        }
    
            public string   DocAGenerar
        {
            get { return _DocAGenerar; }
            set { _DocAGenerar = value; }
        }

            public string   NroDoc
        {
            get { return _NroDoc; }
            set { _NroDoc = value; }
        }

           public string   DocRef
        {
            get { return _DocRef; }
            set { _DocRef = value; }
        }

           public string   Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }

           public string   Bodega_Salida
        {
            get { return _Bodega_Salida; }
            set { _Bodega_Salida = value; }
        }

        public string   Bodega_Entrada
        {
            get { return _Bodega_Entrada; }
            set { _Bodega_Entrada = value; }
        }

                public string   IdVendedor
        {
            get { return _IdVendedor; }
            set { _IdVendedor = value; }
        }


           public string   Sucursal_Cod
        {
            get { return _Sucursal_Cod; }
            set { _Sucursal_Cod = value; }
        }

         public string   ListaPrecio_Cod
        {
            get { return _ListaPrecio_Cod; }
            set { _ListaPrecio_Cod = value; }
        }

                 public string   Fecha_Atencion
        {
            get { return _Fecha_Atencion; }
            set { _Fecha_Atencion = value; }
        }

                 public string   Fecha_Documento
        {
            get { return _Fecha_Documento; }
            set { _Fecha_Documento = value; }
        }

        
    }
}
