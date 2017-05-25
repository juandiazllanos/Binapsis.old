using System;
using System.Collections.Generic;
using System.Text;

namespace Binapsis.Plataforma.Configuracion.Sql.Clave
{
    class ClaveUri
    {
        Uri _obj;

        public ClaveUri(Uri obj)
        {
            _obj = obj;
        }

        public override string ToString()
        {
            return $"{_obj.Nombre}";
        }
    }
}
