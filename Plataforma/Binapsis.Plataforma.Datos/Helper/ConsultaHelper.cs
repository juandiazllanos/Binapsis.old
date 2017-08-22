using Binapsis.Plataforma.Configuracion;
using Binapsis.Plataforma.Datos.Builder;
using Binapsis.Plataforma.Datos.Impl;
using Binapsis.Plataforma.Datos.Mapeo;
using Binapsis.Plataforma.Estructura;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Binapsis.Plataforma.Datos.Helper
{
    class ConsultaHelper
    {
        public ConsultaHelper(MapeoCatalogo mapeoCatalogo)
        {
            MapeoCatalogo = mapeoCatalogo;
        }

        public ComandoLectura CrearConsulta(ITipo tipo)
        {
            MapeoTabla mapeoTabla = MapeoCatalogo.ObtenerMapeoTabla(tipo);
            return CrearConsulta(mapeoTabla);
        }

        public ComandoLectura CrearConsulta(ITipo tipo, IPropiedad[] propiedades)
        {
            MapeoTabla mapeoTabla = MapeoCatalogo.ObtenerMapeoTabla(tipo);
            if (mapeoTabla == null) throw new Exception($"El tipo '{tipo.Nombre}' no esta asociado a una tabla");

            IList<MapeoColumna> mapeoColumnas = new List<MapeoColumna>();

            foreach (IPropiedad propiedad in propiedades)
                ResolverMapeoColumna(mapeoTabla, propiedad, mapeoColumnas);

            return CrearConsulta(mapeoTabla, mapeoColumnas);
        }

        private void ResolverMapeoColumna(MapeoTabla mapeoTabla, IPropiedad propiedad, IList<MapeoColumna> resultado)
        {
            if (propiedad.Tipo.EsTipoDeDato)
                ResolverMapeoColumnaAtributo(mapeoTabla, propiedad, resultado);
            else
                ResolverMapeoColumnaReferencia(mapeoTabla, propiedad, resultado);
        }

        private void ResolverMapeoColumnaAtributo(MapeoTabla mapeoTabla, IPropiedad propiedad, IList<MapeoColumna> resultado)
        {
            MapeoColumna mapeoColumna = mapeoTabla?.ObtenerMapeoColumnaPorPropiedad(propiedad.Nombre);
            if (mapeoColumna == null) throw new Exception($"La propiedad '{propiedad.Nombre}' no esta asociado a una columna.");
            resultado.Add(mapeoColumna);
        }

        private void ResolverMapeoColumnaReferencia(MapeoTabla mapeoTabla, IPropiedad propiedad, IList<MapeoColumna> resultado)
        {
            MapeoRelacion mapeoRelacion = mapeoTabla.ObtenerMapeoRelacionPorPropiedad(propiedad);
            if (mapeoRelacion == null) throw new Exception($"La propiedad '{propiedad.Nombre}' no está asociada a una relación.");

            var claves = mapeoRelacion.Claves.Select(item => item.ClaveSecundaria);
            if (claves == null) return;

            foreach (MapeoColumna mapeoColumna in claves)
                resultado.Add(mapeoColumna);
        }

        //private ComandoLectura CrearConsultaAtributo(MapeoTabla mapeoTabla, IPropiedad propiedad)
        //{
        //    MapeoColumna mapeoColumna = mapeoTabla?.ObtenerMapeoColumnaPorPropiedad(propiedad.Nombre);
        //    if (mapeoColumna == null) throw new Exception($"La propiedad '{propiedad.Nombre}' no esta asociado a una columna.");

        //    return CrearConsulta(mapeoTabla, mapeoColumna);
        //}

        //private ComandoLectura CrearConsultaReferencia(MapeoTabla mapeoTabla, IPropiedad propiedad)
        //{
        //    MapeoRelacion mapeoRelacion = mapeoTabla.ObtenerMapeoRelacionPorPropiedad(propiedad);
        //    if (mapeoRelacion == null) throw new Exception($"La propiedad '{propiedad.Nombre}' no está asociada a una relación.");

        //    IList<MapeoColumna> mapeoColumnas = mapeoRelacion.Claves.Select(item => item.ClaveSecundaria).ToList();

        //    return CrearConsulta(mapeoTabla, mapeoColumnas);
        //}

        public ComandoLectura CrearConsulta(MapeoTabla mapeoTabla)
        {
            IList<MapeoColumna> columnas = mapeoTabla.Columnas.Where(item => item.Columna.ClavePrimaria).ToList();
            if (columnas.Count == 0) throw new Exception($"La tabla '{mapeoTabla.Tabla.Nombre}' no tiene claves primarias.");

            return CrearConsulta(mapeoTabla, columnas);
        }

        private ComandoLectura CrearConsulta(MapeoTabla mapeoTabla, MapeoColumna mapeoColumna)
        {
            IList<MapeoColumna> columnas = new List<MapeoColumna> { mapeoColumna };
            return CrearConsulta(mapeoTabla, mapeoColumna);
        }

        private ComandoLectura CrearConsulta(MapeoTabla mapeoTabla, IList<MapeoColumna> mapeoColumnas)
        {
            Comando comando = Fabrica.Instancia.Crear<Comando>();
            BuilderComandoSelect builder = new BuilderComandoSelect(comando);

            builder.MapeoTabla = mapeoTabla;
            builder.ParametroColumnas = mapeoColumnas;
            // construir comando
            builder.Construir();

            return new ComandoLectura(comando, mapeoTabla);
        }

        public ComandoLectura CrearConsultaTablaSecundaria(MapeoRelacion mapeoRelacion)
        {
            IList<MapeoColumna> mapeoColumnas = mapeoRelacion.Claves.Select(item => item.ClaveSecundaria).ToList();
            return CrearConsulta(mapeoRelacion.TablaSecundaria, mapeoColumnas);
        }

        public ComandoLectura CrearConsultaTablaPrincipal(MapeoRelacion mapeoRelacion)
        {
            IList<MapeoColumna> mapeoColumnas = mapeoRelacion.Claves.Select(item => item.ClavePrincipal).ToList();
            return CrearConsulta(mapeoRelacion.TablaPrincipal, mapeoColumnas);
        }

        public ComandoLectura CrearConsulta(Comando comando)
        {
            ITipo tipo = new ResultadoTipo(comando);
            MapeoTabla mapeoTabla = MapeoCatalogo.ObtenerMapeoTabla(tipo);            
            ComandoLectura comandoLectura = new ComandoLectura(comando, mapeoTabla);

            return comandoLectura;
        }

        public MapeoCatalogo MapeoCatalogo
        {
            get;        
        }

    }
}
