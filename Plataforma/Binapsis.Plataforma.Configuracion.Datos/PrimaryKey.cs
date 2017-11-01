using Binapsis.Plataforma.Cambios;
using Binapsis.Plataforma.Configuracion.Helper;
using Binapsis.Plataforma.Datos;
using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Helper;

using System;
using System.Collections.Generic;

namespace Binapsis.Plataforma.Configuracion.Datos
{
    class PrimaryKey : IPrimaryKey
    {
        string _tabla;
        string _columna;

        public PrimaryKey(string tabla, string columna)
        {
            _tabla = tabla;
            _columna = columna;
        }

        object IPrimaryKey.Get(IObjetoDatos od)
        {
            IKeyHelper keyHelper = new ConfiguracionKeyHelper();
            IKey key = keyHelper.GetKey(od);

            object[] values;

            IObjetoDatos propietario;

            if (od is IObjetoCambios cambios)
                propietario = cambios.PropietarioAntiguo;
            else
                propietario = od.Propietario;

            if (propietario == null)
                values = key.Values;
            else
            {
                List<object> list = new List<object> { ((IPrimaryKey)this).Get(propietario) };
                list.AddRange(key.Values);
                values = list.ToArray();
            }
            
            return string.Join(".", values);
        }

        object IPrimaryKey.Get()
        {
            throw new NotImplementedException();
        }
    }
}
