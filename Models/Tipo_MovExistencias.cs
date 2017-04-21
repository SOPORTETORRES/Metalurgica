using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Metalurgica.Models
{
    public class Tipo_MovExistencias
    {

         private Tipo_MovExistenciasAll  _ExistenciasAll =new Tipo_MovExistenciasAll ();
    private Tipo_MovExistenciasDet  _ExistenciasDet =new Tipo_MovExistenciasDet ();

          public Tipo_MovExistenciasAll  ExistenciasAll
        {
            get { return _ExistenciasAll; }
            set { _ExistenciasAll = value; }
        }


           public Tipo_MovExistenciasDet  ExistenciasDet
        {
            get { return _ExistenciasDet; }
            set { _ExistenciasDet = value; }
        }



    }
}
