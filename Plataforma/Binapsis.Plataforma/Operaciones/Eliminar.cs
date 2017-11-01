using Binapsis.Plataforma.AgenteDatos;
using Binapsis.Plataforma.Estructura.Impl;
using Binapsis.Plataforma.Helper;
using System.Collections.Generic;

namespace Binapsis.Plataforma.Operaciones
{
    class Eliminar
    {
        string _url;
        string _contexto;

        public Eliminar(string url, string contexto)
        {
            _url = url;
            _contexto = contexto;
        }

        public void Ejecutar(EntidadBase entidad)
        {
            ServicioDatos servicio = new ServicioDatos(_url, _contexto, HelperProvider.DataFactory);
            servicio.EliminarObjetoDatos(entidad);
        }

        public void Ejecutar(IEnumerable<EntidadBase> items)
        {
            Coleccion coleccion = null;

            if (items is Coleccion col)
                coleccion = col;
            else
                coleccion = new Coleccion(items);

            ServicioDatos servicio = new ServicioDatos(_url, _contexto, HelperContext.DataFactory);
            servicio.EliminarColeccion(coleccion);
        }
    }
}
