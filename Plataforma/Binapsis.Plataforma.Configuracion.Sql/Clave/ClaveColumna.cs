using System;
using System.Collections.Generic;
using System.Text;

namespace Binapsis.Plataforma.Configuracion.Sql.Clave
{
    class ClaveColumna : ClaveBase
    {
        public ClaveColumna(ConfiguracionBase obj) : base(obj)
        {
        }

        public override string CrearClave(ConfiguracionBase obj)
        {
            Columna columna = (obj as Columna);
            Tabla tabla = columna?.Propietario as Tabla;

            return $"{new ClaveTabla(tabla)}.{columna.Nombre}";
        }
    }
}
