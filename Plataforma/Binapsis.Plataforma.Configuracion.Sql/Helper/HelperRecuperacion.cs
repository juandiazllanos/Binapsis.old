using Binapsis.Plataforma.Configuracion.Sql.Builder;
using Binapsis.Plataforma.Configuracion.Sql.Comandos;
using Binapsis.Plataforma.Configuracion.Sql.SqlBuilder;
using Binapsis.Plataforma.Estructura.Impl;
using System.Collections.Generic;

namespace Binapsis.Plataforma.Configuracion.Sql.Helper
{
    internal class HelperRecuperacion
    {
        Dictionary<string, ObjetoBase> _cache;        
        Contexto _contexto;

        public HelperRecuperacion(string cadenaConexion)
            : this (new Contexto(cadenaConexion))
        {
        }

        public HelperRecuperacion(Contexto contexto)
        {
            _cache = new Dictionary<string, ObjetoBase>();
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

            //Definicion obj = Recuperar(new SqlBuilderSeleccionarDefinicion(definicion, clave), new BuilderDefinicion(this), clave);
            //RecuperarItems(obj);
            //return obj;
        }
                
        public Uri RecuperarUri(string clave)
        {
            return Recuperar(new SqlBuilderSeleccionarUri(clave), new BuilderUri(this), clave);
        }

        public Tipo RecuperarTipo(string clave)
        {
            return Recuperar(new SqlBuilderSeleccionarTipo(clave), new BuilderTipo(this), clave);

            //Tipo tipo = Recuperar(new SqlBuilderSeleccionarTipo(clave), new BuilderTipo(this), clave);
            //RecuperarItems(new SqlBuilderSeleccionarPropiedadTipo(clave), new BuilderPropiedad(this, tipo));
            //return tipo;
        }
        
        private T Recuperar<T>(ISqlBuilder builderSql, BuilderConfiguracion<T> builder, string clave) where T : ObjetoBase
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
            FabricaConfiguracion fabrica = FabricaConfiguracion.Instancia;
            item = (T)fabrica.Crear(typeof(T));

            // agregar al cache (antes de construir para evitar recursividad infinita)
            if (!string.IsNullOrEmpty(clave))
                Agregar(clave, item);

            builder.Construir(item, comando.Resultado[0]);

            //item = builder.Construir(comando.Resultado[0]);

            //// agregar al cache
            //if (!string.IsNullOrEmpty(clave))
            //    Agregar(clave, item);

            return item;
        }

        //public void RecuperarItems(Definicion definicion)
        //{
        //    RecuperarItems(new SqlBuilderSeleccionarDefinicionItem(definicion.Nombre, definicion.Valor), new BuilderDefinicion(this, definicion));
        //    foreach (Definicion definicionItem in definicion.Definiciones)
        //        RecuperarItems(definicionItem);
        //}

        internal void RecuperarItems<T>(ISqlBuilder builderSql, BuilderConfiguracion<T> builder) where T : ObjetoBase
        {            
            // ejecutar consulta            
            ComandoLectura comando = new ComandoLectura(builderSql);
            _contexto.Ejecutar(comando);

            if (comando.Resultado.Length == 0) return;

            // construir objeto           
            builder.Construir(comando.Resultado);            
        }

        private T Obtener<T>(string clave) where T : ObjetoBase
        {
            string key = $"{typeof(T).Name}.{clave}";
            T item = default(T);

            if (_cache.ContainsKey(key))
                item = (T)_cache[key];

            return item;
        }

        private void Agregar<T>(string clave, T item) where T : ObjetoBase
        {
            string key = $"{typeof(T).Name}.{clave}";

            if (!_cache.ContainsKey(key))
                _cache.Add(key, item);
        }
    }
}
