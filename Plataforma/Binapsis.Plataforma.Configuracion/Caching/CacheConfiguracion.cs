using Binapsis.Plataforma.Caching;
using Binapsis.Plataforma.Configuracion.Helper;
using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Helper;
using Binapsis.Plataforma.Helper.Impl;

using System;

namespace Binapsis.Plataforma.Configuracion.Caching
{
    public class CacheConfiguracion : CacheObjetoDatos
    {
        IKeyHelper _keyHelper = new ConfiguracionKeyHelper();
                
        public ConfiguracionBase Get(Type type, string nombre)
        {
            return Get(type, "Nombre", nombre);
        }

        private ConfiguracionBase Get(Type type, string clave, object valor)
        {
            ITipo tipo = Types.Instancia.Obtener(type);

            if (tipo.Nombre != "Tipo")
                return (ConfiguracionBase)Get(tipo, tipo[clave], valor);
            else
                return (ConfiguracionBase)Get(tipo, BuildKey(tipo, valor?.ToString()));            
        }

        private IKey BuildKey(ITipo tipo, string clave)
        {
            int i = clave?.LastIndexOf('.') ?? 0;

            if (i == 0) return null;

            Key key = new Key(_keyHelper.GetProperty(tipo));

            key.SetValue("Uri", clave.Substring(0, i));
            key.SetValue("Nombre", clave.Substring(i +1));

            return key;
        }
        
        public override void Set(IObjetoDatos valor)
        {
            IKey key = _keyHelper.GetKey(valor);

            if (key != null)
                Set(key, valor);
        }
        
        public bool Exists(Type type, string nombre)
        {
            return Exists(type, "Nombre", nombre);
        }

        private bool Exists(Type type, string clave, object valor)
        {
            ITipo tipo = Types.Instancia.Obtener(type);

            if (tipo.Nombre != "Tipo")
                return Exists(tipo, tipo[clave], valor);
            else
                return Exists(tipo, BuildKey(tipo, valor?.ToString()));
        }
        
    }
}
