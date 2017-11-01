using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Helper;
using Binapsis.Plataforma.Helper.Impl;

namespace Binapsis.Plataforma.Caching
{
    public class CacheObjetoDatos : TypedCache<IObjetoDatos>
    {
        public IObjetoDatos Get(ITipo tipo, string propiedad, object valor)
        {
            return Get(tipo, tipo[propiedad], valor);
        }

        public IObjetoDatos Get(ITipo tipo, IPropiedad clave, object valor)
        {
            return Get(BuildKey(tipo, clave, valor));
        }

        public IObjetoDatos Get(ITipo tipo, int id)
        {
            return Get(tipo, "Id", id);
        }

        public IObjetoDatos Get(ITipo tipo, IKey key)
        {
            return Get(BuildKey(tipo, key));
        }
        


        public virtual void Set(IObjetoDatos valor)
        {
            IKey key = KeyHelper.Instancia.GetKey(valor);

            if (key != null) 
                Set(key, valor);
        }

        public virtual void Set(IPropiedad clave, IObjetoDatos valor)
        {
            if (clave != null && valor != null)
                Set(BuildKey(clave, valor), valor);            
        }

        public virtual void Set(IKey key, IObjetoDatos valor)
        {
            if (key != null && valor != null)
                Set(BuildKey(valor?.Tipo, key), valor);
        }



        public void Add(IColeccion col)
        {
            foreach (var item in col)
                Set(item);
        }



        public bool Exists(ITipo tipo, int id)
        {
            return Exists(tipo, tipo["Id"], id);
        }

        public virtual bool Exists(ITipo tipo, IKey key)
        {            
            return Exists(BuildKey(tipo, key));
        }

        public bool Exists(ITipo tipo, IPropiedad clave, object valor)
        {
            return Exists(BuildKey(tipo, clave, valor));
        }
        


        private string BuildKey(ITipo tipo, IKey key)
        {
            if (key == null) return null;

            if (key.Longitud == 1)
                return BuildKey(tipo, key.Properties[0], key.Values[0]);


            string[] keys = new string[key.Longitud];

            for (int i = 0; i < key.Longitud; i++)
                keys[i] = $"{key.Properties[i].Nombre}={key.Values[i]}";

            return BuildKey(tipo, keys); //$"{tipo.Uri}.{tipo.Nombre}.{string.Join("&", keys)}";
        }

        private string BuildKey(IPropiedad clave, IObjetoDatos valor)
        {
            return BuildKey(valor?.Tipo, clave, valor?.Obtener(clave));
        }

        private string BuildKey(ITipo tipo, IPropiedad clave, object valor)
        {
            if (tipo != null && clave != null && valor != null)
                return BuildKey(tipo, clave.Nombre + "=" + valor);
            else
                return null;
        }

        private string BuildKey(ITipo tipo, params string[] clave)
        {
            return $"{{{tipo.Uri}.{tipo.Nombre}}}{{{string.Join(" ", clave)}}}";
        }
    }
}
