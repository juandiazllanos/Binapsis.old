﻿using Binapsis.Plataforma.Configuracion;
using Binapsis.Plataforma.Estructura;
using System.Collections.Generic;
using System.Linq;

namespace Binapsis.Plataforma.Datos.Mapeo
{
    class MapeoTabla
    {
        List<MapeoColumna> _columnas;
        List<MapeoRelacion> _relaciones;
        Dictionary<string, IPrimaryKey> _keys;

        #region Constructores
        public MapeoTabla()
        {
            _columnas = new List<MapeoColumna>();
            _relaciones = new List<MapeoRelacion>();
            _keys = new Dictionary<string, IPrimaryKey>();
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

        public MapeoColumna ObtenerMapeoColumnaPorColumna(Columna columna)
        {
            return ObtenerMapeoColumnaPorColumna(columna?.Nombre);
        }

        public MapeoColumna ObtenerMapeoColumnaPorColumna(string columna)
        {
            return _columnas.FirstOrDefault(item => item.Columna.Nombre == columna);
        }

        public MapeoColumna ObtenerMapeoColumnaPorPropiedad(IPropiedad propiedad)
        {
            return ObtenerMapeoColumnaPorPropiedad(propiedad?.Nombre);
        }

        public MapeoColumna ObtenerMapeoColumnaPorPropiedad(string propiedad)
        {
            return _columnas.FirstOrDefault(item => item.Propiedad?.Nombre == propiedad);
        }

        public MapeoRelacion ObtenerMapeoRelacionPorPropiedad(IPropiedad propiedad)
        {
            return ObtenerMapeoRelacionPorPropiedad(propiedad?.Nombre);
        }

        public MapeoRelacion ObtenerMapeoRelacionPorPropiedad(string propiedad)
        {
            return _relaciones.FirstOrDefault(item => item.Propiedad.Nombre == propiedad);
        }

        public IList<MapeoColumna> ObtenerMapeoColumnaClavePrincipal()
        {
            return _columnas.Where(item => item.Columna.ClavePrimaria).ToList();
        }
        
        public void AgregarPrimaryKey(string columna, IPrimaryKey pk)
        {
            if (!_keys.ContainsKey(columna))
                _keys.Add(columna, pk);
        }

        public IPrimaryKey ObtenerPrimaryKey(string columna)
        {
            if (_keys.ContainsKey(columna))
                return _keys[columna];
            else
                return null;
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
