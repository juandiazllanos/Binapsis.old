using Binapsis.Plataforma.Configuracion;
using Binapsis.Plataforma.Estructura;
using System.Collections.Generic;
using System.Linq;

namespace Binapsis.Plataforma.Datos.Mapeo
{
    class MapeoRelacion
    {
        List<MapeoRelacionClave> _claves;

        public MapeoRelacion()
        {
            _claves = new List<MapeoRelacionClave>();
        }

        public MapeoRelacionClave ObtenerMapeoRelacionClavePorColumnaPrincipal(string columna)
        {
            return _claves.FirstOrDefault(item => item.ClavePrincipal.Columna.Nombre == columna);
        }

        public MapeoRelacionClave ObtenerMapeoRelacionClavePorColumnaSecundaria(string columna)
        {
            return _claves.FirstOrDefault(item => item.ClaveSecundaria.Columna.Nombre == columna);
        }

        public List<MapeoRelacionClave> Claves
        {
            get => _claves;
        }

        public IPropiedad Propiedad
        {
            get;
            set;
        }

        public Relacion Relacion
        {
            get;
            set;
        }

        public MapeoTabla TablaPrincipal
        {
            get;
            set;
        }

        public MapeoTabla TablaSecundaria
        {
            get;
            set;
        }

        public ITipo Tipo
        {
            get;
            set;
        }
    }
}
