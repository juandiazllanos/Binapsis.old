namespace Binapsis.Plataforma.Caching
{
    public interface ICache
    {
        bool Exists(string key);
        object Get(string key);
        void Set(string key, object value);
    }
}
