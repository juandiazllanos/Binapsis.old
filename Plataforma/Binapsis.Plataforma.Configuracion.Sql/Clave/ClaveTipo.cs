using System;
using System.Collections.Generic;
using System.Text;

namespace Binapsis.Plataforma.Configuracion.Sql.Clave
{
    class ClaveTipo
    {
        Tipo _obj;

        public ClaveTipo(Tipo obj)
        {
            _obj = obj;
        }

        public override string ToString()
        {
            if (_obj != null)
                return $"{_obj.Uri.Nombre}.{_obj.Nombre}";
            else
                return string.Empty;
        }
    }
}
