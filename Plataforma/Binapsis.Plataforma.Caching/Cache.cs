namespace Binapsis.Plataforma.Caching
{
    public static class Cache 
    {
        static ICache _cache = new CacheImpl();

        public static bool Exists(string key)
        {
            return _cache.Exists(key);
        }

        public static object Get(string key)
        {
            if (Exists(key))
                return _cache.Get(key);
            else
                return null;
        }

        public static void Set(string key, object value)
        {
            if (!Exists(key))
                _cache.Set(key, value);
        }

        static internal ICache CacheImpl
        {
            get => _cache;            
        }

        //public static IObjetoDatos Get(ITipo tipo, IPropiedad clave, object valor)
        //{
        //    return Get(BuildKey(tipo, clave, valor));
        //}

        //public static IObjetoDatos Get(ITipo tipo, IKey key)
        //{            
        //    return Get(BuildKey(tipo, key));
        //}

        //private static IObjetoDatos Get(string key)
        //{
        //    if (string.IsNullOrEmpty(key))
        //        return _cacheManager.Get(key);
        //    else
        //        return null;
        //}


        //private static void Set(IPropiedad clave, IObjetoDatos valor)
        //{
        //    Set(BuildKey(clave, valor), valor);
        //}

        //private static void Set(IKey key, IObjetoDatos valor)
        //{
        //    Set(BuildKey(valor?.Tipo, key), valor);
        //}

        //private static void Set(string key, IObjetoDatos value)
        //{
        //    if (string.IsNullOrEmpty(key) && value != null)
        //        _cacheManager.Put(key, value);
        //}


        //public static bool Exists(ITipo tipo, IKey key)
        //{
        //    return Exists(BuildKey(tipo, key));
        //}

        //public static bool Exists(ITipo tipo, IPropiedad clave, object valor)
        //{
        //    return Exists(BuildKey(tipo, clave, valor));
        //}

        //private static bool Exists(string key)
        //{
        //    if (!string.IsNullOrEmpty(key))
        //        return _cacheManager.Exists(key);
        //    else
        //        return false;
        //}


        //private static string BuildKey(ITipo tipo, IKey key)
        //{
        //    string[] keys = new string[key.Longitud];

        //    for (int i = 0; i < key.Longitud; i++)
        //        keys[i] = $"{key.Properties[i].Nombre}.{key.Values[i]}";

        //    return $"{tipo.Uri}.{tipo.Nombre}.{string.Join("&", keys)}";
        //}

        //private static string BuildKey(IPropiedad clave, IObjetoDatos valor)
        //{
        //    return BuildKey(valor?.Tipo, clave, valor?.Obtener(clave));
        //}

        //private static string BuildKey(ITipo tipo, IPropiedad clave, object valor)
        //{
        //    if (tipo != null && clave != null && valor != null)
        //        return $"{tipo.Uri}.{tipo.Nombre}.{clave.Nombre}.{valor}";
        //    else
        //        return null;
        //}

    }
}
