using Binapsis.Plataforma.Configuracion;
using Binapsis.Plataforma.Datos.Builder;
using Binapsis.Plataforma.Estructura;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Binapsis.Plataforma.Datos.Mapeo
{
    class MapeoCatalogo
    {
        static Dictionary<string, MapeoTabla> _mapeoTabla;
        static Dictionary<string, MapeoRelacion> _mapeoRelacion;

        public MapeoCatalogo()
        {
            _mapeoRelacion = new Dictionary<string, MapeoRelacion>();
            _mapeoTabla = new Dictionary<string, MapeoTabla>();
        }

        #region MpaeoTabla
        public MapeoTabla ObtenerMapeoTabla(string uri, string tipo)
        {
            string clave = $"{uri}.{tipo}";

            if (_mapeoTabla.ContainsKey(clave))
                return _mapeoTabla[clave];
            else
                return CrearMapeoTabla(uri, tipo);
        }

        public MapeoTabla ObtenerMapeoTabla(string uri, string tipo, string tabla)
        {
            ITipo tipoItem = Configuracion?.ObtenerTipo(uri, tipo);
            return ObtenerMapeoTabla(tipo, tabla);
        }

        public MapeoTabla ObtenerMapeoTabla(ITipo tipo)
        {
            string clave = $"{tipo.Uri}.{tipo.Nombre}";

            if (_mapeoTabla.ContainsKey(clave))
                return _mapeoTabla[clave];
            else
                return CrearMapeoTabla(tipo);
        }

        public MapeoTabla ObtenerMapeoTabla(ITipo tipo, string tabla)
        {
            Tabla tablaItem = Configuracion.ObtenerTabla(tabla);
            return ObtenerMapeoTabla(tipo, tablaItem);
        }

        public MapeoTabla ObtenerMapeoTabla(ITipo tipo, Tabla tabla)
        {
            if (tipo == null || tabla == null) return null;

            MapeoTabla mapeoTabla = null;
            string clave = $"{tipo.Uri}.{tipo.Nombre}";

            if (_mapeoTabla.ContainsKey(clave))
                mapeoTabla = _mapeoTabla[clave];

            if (mapeoTabla == null)
                mapeoTabla = CrearMapeoTabla(tipo, tabla);
            else if (mapeoTabla.Tabla.Nombre != tabla.Nombre)
                mapeoTabla = null;
            
            return mapeoTabla;
        }

        private MapeoTabla CrearMapeoTabla(string uri, string tipo)
        {
            return CrearMapeoTabla(Configuracion.ObtenerTipo(uri, tipo));
        }

        private MapeoTabla CrearMapeoTabla(ITipo tipo)
        {
            Tabla tabla = Configuracion.ObtenerTabla(tipo.Uri, tipo.Nombre);
            return CrearMapeoTabla(tipo, tabla);            
        }

        private MapeoTabla CrearMapeoTabla(ITipo tipo, Tabla tabla)
        {
            // crear tabla si no existe
            if (tabla == null) tabla = CrearTabla(tipo);
                
            MapeoTabla mapeoTabla = new MapeoTabla();
            BuilderMapeoTabla builder = new BuilderMapeoTabla(mapeoTabla);

            builder.Configuracion = Configuracion;
            builder.MapeoCatalogo = this;

            builder.Construir(tipo, tabla);

            string clave = $"{tipo.Uri}.{tipo.Nombre}";
            _mapeoTabla.Add(clave, mapeoTabla);

            CrearMapeoRelacion(mapeoTabla);

            return mapeoTabla;
        }

        private Tabla CrearTabla(ITipo tipo)
        {
            Tabla tabla = Fabrica.Instancia.Crear<Tabla>();
            tabla.Nombre = tipo.Nombre;
            return tabla;
        }
        #endregion


        #region MapeoColumna
        public MapeoColumna ObtenerMapeoColumna(string tabla, string columna)
        {
            MapeoTabla tablaItem = _mapeoTabla.Values.FirstOrDefault(item => item.Tabla.Nombre == tabla);
            
            if (tablaItem == null) return null;

            return ObtenerMapeoColumna(tabla, columna);
        }

        public MapeoColumna ObtenerMapeoColumna(MapeoTabla mapeoTabla, Columna columna)
        {
            return ObtenerMapeoColumna(mapeoTabla, columna.Nombre);
        }

        public MapeoColumna ObtenerMapeoColumna(MapeoTabla mapeoTabla, string columna)
        {
            MapeoColumna mapeoColumna = mapeoTabla?.Columnas.FirstOrDefault(item => item.Columna.Nombre == columna);

            if (mapeoColumna == null)             
                return CrearMapeoColumna(mapeoTabla, columna);
            else
                return mapeoColumna;
        }

        private MapeoColumna CrearMapeoColumna(MapeoTabla mapeoTabla, string columna)
        {
            Columna columnaItem = mapeoTabla.Tabla.ObtenerColumna(columna);

            if (columnaItem == null) return null;

            return CrearMapeoColumna(mapeoTabla, columnaItem);
        }

        private MapeoColumna CrearMapeoColumna(MapeoTabla mapeoTabla, Columna columna)
        {
            IPropiedad propiedad = mapeoTabla.Tipo.ObtenerPropiedad(columna.Propiedad);

            if (propiedad == null)
                return CrearMapeoColumnaClave(mapeoTabla, columna);
            else
                return CrearMapeoColumna(mapeoTabla, columna, propiedad);
        }

        private MapeoColumna CrearMapeoColumna(MapeoTabla mapeoTabla, Columna columna, IPropiedad propiedad)
        {            
            MapeoColumna mapeoColumna = new MapeoColumna(mapeoTabla);
            mapeoColumna.Columna = columna;
            mapeoColumna.Propiedad = propiedad;

            mapeoTabla.Columnas.Add(mapeoColumna);

            return mapeoColumna;
        }
        #endregion


        #region MapeoColumnaClave
        public MapeoColumnaClave ObtenerMapeoColumnaClave(MapeoTabla mapeoTabla, Columna columna)
        {
            return ObtenerMapeoColumnaClave(mapeoTabla, columna.Nombre);
        }

        public MapeoColumnaClave ObtenerMapeoColumnaClave(MapeoTabla mapeoTabla, string columna)
        {
            MapeoColumnaClave mapeoColumna = mapeoTabla?.Columnas.OfType<MapeoColumnaClave>().FirstOrDefault(item => item.Columna.Nombre == columna);

            if (mapeoColumna == null)
                return CrearMapeoColumnaClave(mapeoTabla, columna);
            else
                return mapeoColumna;
        }

        private MapeoColumnaClave CrearMapeoColumnaClave(MapeoTabla mapeoTabla, string columna)
        {
            Columna columnaItem = mapeoTabla.Tabla.ObtenerColumna(columna);
            if (columnaItem == null) return null;

            return CrearMapeoColumnaClave(mapeoTabla, columnaItem);
        }

        private MapeoColumnaClave CrearMapeoColumnaClave(MapeoTabla mapeoTabla, Columna columna)
        {
            IPropiedad propiedad = null;

            if (!string.IsNullOrEmpty(columna.Propiedad))
                propiedad = mapeoTabla.Tipo.ObtenerPropiedad(columna.Propiedad);

            return CrearMapeoColumnaClave(mapeoTabla, columna, propiedad);
        }

        private MapeoColumnaClave CrearMapeoColumnaClave(MapeoTabla mapeoTabla, Columna columna, IPropiedad propiedad)
        {
            MapeoColumnaClave mapeoColumnaClave = new MapeoColumnaClave(mapeoTabla);
            mapeoColumnaClave.Columna = columna;
            mapeoColumnaClave.Propiedad = propiedad;

            mapeoTabla.Columnas.Add(mapeoColumnaClave);

            return mapeoColumnaClave;
        }

        #endregion


        #region MapeoRelacion
        public MapeoRelacion ObtenerMapeoRelacion(string uri, string tipo, string propiedad)
        {
            ITipo tipoItem = Configuracion?.ObtenerTipo(uri, tipo);
            IPropiedad propiedadItem = tipoItem?.ObtenerPropiedad(propiedad);
            return ObtenerMapeoRelacion(tipoItem, propiedadItem);
        }

        public MapeoRelacion ObtenerMapeoRelacion(ITipo tipo, IPropiedad propiedad)
        {
            string clave = $"{tipo.Uri}.{tipo.Nombre}.{propiedad.Nombre}";

            if (_mapeoRelacion.ContainsKey(clave))
                return _mapeoRelacion[clave];
            else
                return CrearMapeoRelacion(tipo, propiedad);
        }

        private void CrearMapeoRelacion(MapeoTabla mapeoTabla)
        {
            var referencias = mapeoTabla.Tipo.Propiedades.Where(item => !item.Tipo.EsTipoDeDato);

            foreach (Propiedad referencia in referencias)
                CrearMapeoRelacion(mapeoTabla.Tipo, referencia);
        }

        private MapeoRelacion CrearMapeoRelacion(ITipo tipo, IPropiedad propiedad)
        {
            if (tipo == null || propiedad == null) return null;

            Relacion relacion = Configuracion?.ObtenerRelacion(tipo.Uri, tipo.Nombre, propiedad.Nombre);
            return CrearMapeoRelacion(tipo, propiedad, relacion);
        }

        private MapeoRelacion CrearMapeoRelacion(ITipo tipo, IPropiedad propiedad, Relacion relacion)
        {
            MapeoRelacion mapeoRelacion = new MapeoRelacion();
            BuilderMapeoRelacion builder = new BuilderMapeoRelacion(mapeoRelacion);

            // configurar builder
            builder.Configuracion = Configuracion;
            builder.MapeoCatalogo = this;
            // construir mapeo de relacion
            builder.Construir(tipo, propiedad, relacion);

            // agregar mapeo de relacion
            string clave = $"{tipo.Uri}.{tipo.Nombre}.{propiedad.Nombre}";
            _mapeoRelacion.Add(clave, mapeoRelacion);

            // registrar en tabla principal
            RegistrarRelacion(mapeoRelacion.TablaPrincipal, mapeoRelacion);
            // registrar en tabla secundaria
            RegistrarRelacion(mapeoRelacion.TablaSecundaria, mapeoRelacion);

            return mapeoRelacion;
        }

        private void RegistrarRelacion(MapeoTabla mapeoTabla, MapeoRelacion mapeoRelacion)
        {
            if (mapeoTabla.Relaciones.Exists(item => item.Relacion.Nombre == mapeoRelacion.Relacion.Nombre)) return;
            mapeoTabla.Relaciones.Add(mapeoRelacion);
        }
        #endregion


        #region Propiedades
        public IConfiguracion Configuracion
        {
            get;
            set;
        }
        #endregion


    }
}
