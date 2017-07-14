using Binapsis.Plataforma.Configuracion;
using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Datos.Mapeo
{
    class MapeoColumna
    {
        public MapeoColumna(MapeoTabla tabla)
        {
            MapeoTabla = tabla;
        }

        public Columna Columna
        {
            get;
            set;
        }

        public MapeoTabla MapeoTabla
        {
            get;
        }

        public IPropiedad Propiedad
        {
            get;
            set;
        }

    }
}
