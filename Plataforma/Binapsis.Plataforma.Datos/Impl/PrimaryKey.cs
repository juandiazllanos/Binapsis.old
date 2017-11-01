using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Datos.Mapeo;

namespace Binapsis.Plataforma.Datos.Impl
{
    class PrimaryKey : IPrimaryKey
    {
        MapeoColumna _mapeoColumna;

        public PrimaryKey(MapeoColumna mapeoColumna)
        {
            _mapeoColumna = mapeoColumna;
        }

        object IPrimaryKey.Get(IObjetoDatos od)
        {
            if (_mapeoColumna.Propiedad != null)
                return od.Obtener(_mapeoColumna.Propiedad);
            else
                return null;
        }

        object IPrimaryKey.Get()
        {
            return null;
        }
    }
}
