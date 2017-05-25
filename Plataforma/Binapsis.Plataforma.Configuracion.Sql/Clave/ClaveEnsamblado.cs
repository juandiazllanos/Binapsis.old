using System;
using System.Collections.Generic;
using System.Text;

namespace Binapsis.Plataforma.Configuracion.Sql.Clave
{
    class ClaveEnsamblado
    {
        Ensamblado _obj;

        public ClaveEnsamblado(Ensamblado obj)
        {
            _obj = obj;
        }

        public override string ToString()
        {
            return $"{_obj.Nombre}";
        }
    }
}
