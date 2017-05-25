using System.Collections.Generic;
using System.Reflection;

namespace Binapsis.Plataforma.Estructura.Cache
{
    internal class CacheTipo
    {
        Dictionary<string, CacheUri> _cache;

        public CacheTipo()
        {
            _cache = new Dictionary<string, CacheUri>();
        }
        
        public CacheUri Agregar(string uri)
        {
            if (!Existe(uri))            
                _cache.Add(uri, new CacheUri(uri));
                
            return Obtener(uri);
        }
                
        public bool Existe(string uri)
        {
            return _cache.ContainsKey(uri);
        }
        
        public CacheUri Obtener(string uri)
        {
            if (Existe(uri))
                return _cache[uri];
            else
                return null;
        }
        
        public CacheUri this[string uri]
        {
            get { return Obtener(uri); }
        }
    }
}
