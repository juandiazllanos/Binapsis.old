using System.Collections.Generic;
using System.Diagnostics;

namespace Binapsis.Plataforma.Caching
{
    class CacheImpl : ICache
    {
        IDictionary<string, object> _cache = new Dictionary<string, object>();

        public bool Exists(string key)
        {
            Debug.WriteLine($"Cache.Exists => key={key}", "Caching");
            
            return _cache.ContainsKey(key);
        }

        public object Get(string key)
        {
            Debug.WriteLine($"Cache.Get => key={key}", "Caching");

            if (!string.IsNullOrEmpty(key) && Exists(key))
                return _cache[key]; 
            else
                return null;
        }

        public void Set(string key, object value)
        {
            if (key == null) return;

            if (!Exists(key))
                _cache.Add(key, value);
            else
                _cache[key] = value;

            Debug.WriteLine($"Cache.Set => key={key}", "Caching");
        }
    }
}
