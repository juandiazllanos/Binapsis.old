using System;
using System.Collections.Generic;
using System.Text;

namespace Binapsis.Plataforma.Configuracion.Sql.Clave
{
    class ClavePropiedad
    {
        Propiedad _obj;

        public ClavePropiedad(Propiedad obj)
        {
            _obj = obj;
        }

        public override string ToString()
        {
            return $"{_obj.Propietario.Uri.Nombre}.{_obj.Propietario.Nombre}.{_obj.Nombre}";
        }
    }
}
