using System;
using System.Collections.Generic;

namespace Binapsis.Plataforma.Estructura.Cache
{
    internal class CacheUri
    {
        string _uri;
        Dictionary<string, ITipo> _cache;

        public CacheUri(string uri)
        {
            _uri = uri;
            _cache = new Dictionary<string, ITipo>();
        }

        public void Agregar(ITipo tipo)
        {
            if (Existe(tipo)) return;

            if (tipo.Uri != _uri)
                throw new Exception(string.Format("El tipo '{0}' no pertenece a la uri '{1}'", tipo.Nombre, _uri));

            _cache.Add(tipo.Nombre, tipo);
        }

        public bool Existe(string nombre)
        {
            return _cache.ContainsKey(nombre);
        }

        public bool Existe(ITipo tipo)
        {
            return Existe(tipo.Nombre);
        }
        
        public ITipo Obtener(string nombre)
        {
            if (Existe(nombre))
                return _cache[nombre];
            else
                return null;
        }

        public ITipo this[string nombre]
        {
            get { return Obtener(nombre); }
        }

    }
}