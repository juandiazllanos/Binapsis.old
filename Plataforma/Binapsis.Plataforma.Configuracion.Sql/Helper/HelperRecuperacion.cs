using Binapsis.Plataforma.Configuracion.Sql.Builder;
using Binapsis.Plataforma.Configuracion.Sql.Clave;
using Binapsis.Plataforma.Configuracion.Sql.Comandos;
using Binapsis.Plataforma.Configuracion.Sql.SqlBuilder;
using System.Collections.Generic;

namespace Binapsis.Plataforma.Configuracion.Sql.Helper
{
    internal class HelperRecuperacion
    {
        Dictionary<string, ConfiguracionBase> _cache;        
        Contexto _contexto;

        public HelperRecuperacion(string cadenaConexion)
            : this (new Contexto(cadenaConexion))
        {
        }

        public HelperRecuperacion(Contexto contexto)
        {
            _cache = new Dictionary<string, ConfiguracionBase>();
            _contexto = contexto;
        }
        
        public Ensamblado RecuperarEnsamblado(string clave)
        {
            return Recuperar(new SqlBuilderSeleccionarEnsamblado(clave), new BuilderEnsamblado(this), clave);
        }

        public Definicion RecuperarDefinicion(string definicion)
        {
            return RecuperarDefinicion(definicion, null);
        }

        public Definicion RecuperarDefinicion(string definicion, string clave)
        {
            return Recuperar(new SqlBuilderSeleccionarDefinicion(definicion, clave), new BuilderDefinicion(this), clave);
        }

        public Tabla RecuperarTabla(string clave)
        {
            return Recuperar(new SqlBuilderSeleccionar(typeof(Tabla), clave), new BuilderTabla(this), clave);
        }

        public Tipo RecuperarTipo(string clave)
        {
            return Recuperar(new SqlBuilderSeleccionarTipo(clave), new BuilderTipo(this), clave);
        }

        public Uri RecuperarUri(string clave)
        {
            return Recuperar(new SqlBuilderSeleccionarUri(clave), new BuilderUri(this), clave);
        }

        public T Recuperar<T>(ClaveBase clave) where T : ConfiguracionBase
        {
            return Recuperar<T>(clave?.ToString());
        }

        public T Recuperar<T>(string clave) where T : ConfiguracionBase
        {
            BuilderConfiguracion<T> builder = new BuilderConfiguracion<T>(this);
            ISqlBuilder sql = new SqlBuilderSeleccionar(typeof(T), clave);
            return Recuperar(sql, builder, clave);
        }

        public T Recuperar<T>(ISqlBuilder builderSql, BuilderConfiguracion<T> builder, string clave) where T : ConfiguracionBase
        {
            // recuperar de cache
            T item = null;

            if (!string.IsNullOrEmpty(clave))
                item = Obtener<T>(clave);

            if (item != null) return item;

            // ejecutar consulta            
            ComandoLectura comando = new ComandoLectura(builderSql);
            _contexto.Ejecutar(comando);
            
            if (comando.Resultado.Length == 0) return null;

            // construir objeto             
            item = (T)Fabrica.Instancia.Crear(typeof(T));

            // agregar al cache (antes de construir para evitar recursividad infinita)
            if (!string.IsNullOrEmpty(clave))
                Agregar(clave, item);

            builder.Construir(item, comando.Resultado[0]);
            
            return item;
        }
        
        internal void RecuperarItems<T>(ISqlBuilder builderSql, BuilderConfiguracion<T> builder) where T : ConfiguracionBase
        {            
            // ejecutar consulta            
            ComandoLectura comando = new ComandoLectura(builderSql);
            _contexto.Ejecutar(comando);

            if (comando.Resultado.Length == 0) return;

            // construir objeto           
            builder.Construir(comando.Resultado);            
        }

        private T Obtener<T>(string clave) where T : ConfiguracionBase
        {
            string key = $"{typeof(T).Name}.{clave}";
            T item = default(T);

            if (_cache.ContainsKey(key))
                item = (T)_cache[key];

            return item;
        }

        private void Agregar<T>(string clave, T item) where T : ConfiguracionBase
        {
            string key = $"{typeof(T).Name}.{clave}";

            if (!_cache.ContainsKey(key))
                _cache.Add(key, item);
        }
    }
}
