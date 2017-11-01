using System;

namespace Binapsis.Plataforma.Caching
{
    public abstract class TypedCache<T> : ICache
    {
        ICache _cache;

        #region Constructores
        public TypedCache()
            : this(Cache.CacheImpl)
        {
        }

        protected TypedCache(ICache cache)
        {
            _cache = cache;
        }
        #endregion


        #region Metodos
        protected bool Exists(string key)
        {
            return _cache.Exists(key);
        }

        protected T Get(string key)
        {
            return (T)_cache.Get(key);
        }

        protected void Set(string key, T value)
        {
            _cache.Set(key, value);
        }
        #endregion


        #region ICache
        bool ICache.Exists(string key)
        {
            return Exists(key);
        }

        object ICache.Get(string key)
        {
            return Get(key);
        }

        void ICache.Set(string key, object value)
        {
            if (value is T typeValue)
                Set(key, typeValue);
            else
                throw new ArgumentException();
        }
        #endregion
    }
}
