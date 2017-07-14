using Binapsis.Plataforma.Configuracion;
using Binapsis.Plataforma.Estructura;
using System.Collections.Generic;
using System.Linq;

namespace Binapsis.Plataforma.Datos.Mapeo
{
    class MapeoTabla
    {
        List<MapeoColumna> _columnas;
        List<MapeoRelacion> _relaciones;

        #region Constructores
        public MapeoTabla()
        {
            _columnas = new List<MapeoColumna>();
            _relaciones = new List<MapeoRelacion>();
        }
        #endregion


        #region Metodos
        public IPropiedad ObtenerPropiedad(Columna columna)
        {
            return ObtenerPropiedad(columna.Nombre);
        }

        public IPropiedad ObtenerPropiedad(string columna)
        {
            return ObtenerMapeoColumnaPorColumna(columna)?.Propiedad;
        }

        public Columna ObtenerColumna(IPropiedad propiedad)
        {
            return ObtenerColumna(propiedad.Nombre);
        }

        public Columna ObtenerColumna(string propiedad)
        {
            return ObtenerMapeoColumnaPorPropiedad(propiedad)?.Columna;
        }

        public MapeoColumna ObtenerMapeoColumnaPorColumna(string columna)
        {
            return _columnas.FirstOrDefault(item => item.Columna.Nombre == columna);
        }

        public MapeoColumna ObtenerMapeoColumnaPorPropiedad(string propiedad)
        {
            return _columnas.FirstOrDefault(item => item.Propiedad.Nombre == propiedad);
        }

        public MapeoRelacion ObtenerMapeoRelacionPorPropiedad(IPropiedad propiedad)
        {
            return ObtenerMapeoRelacionPorPropiedad(propiedad?.Nombre);
        }

        public MapeoRelacion ObtenerMapeoRelacionPorPropiedad(string propiedad)
        {
            return _relaciones.FirstOrDefault(item => item.Propiedad.Nombre == propiedad);
        }
        #endregion


        #region Propiedades
        public List<MapeoColumna> Columnas
        {
            get => _columnas;
        }

        public List<MapeoRelacion> Relaciones
        {
            get => _relaciones;
        }

        public ITipo Tipo
        {
            get;
            set;
        }

        public Tabla Tabla
        {
            get;
            set;
        }
        #endregion
    }
}
