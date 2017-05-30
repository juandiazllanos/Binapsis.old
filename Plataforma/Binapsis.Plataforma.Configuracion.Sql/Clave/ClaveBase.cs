using System;

namespace Binapsis.Plataforma.Configuracion.Sql.Clave
{
    class ClaveBase
    {
        ConfiguracionBase _objeto;

        public ClaveBase(ConfiguracionBase obj)
        {
            _objeto = obj;
        }

        public virtual string CrearClave(ConfiguracionBase obj)
        {
            return null;
        }

        public override string ToString()
        {
            if (_objeto != null)
                return CrearClave(_objeto);
            else
                return null;
        }

        public static ClaveBase Crear(ConfiguracionBase objeto)
        {
            return Crear(objeto?.GetType(), objeto);
        }

        public static ClaveBase Crear(Type type, ConfiguracionBase objeto)
        {
            if (type == null || objeto == null) return null;

            Type typeBase = typeof(ClaveBase);
            Type typeClave = Type.GetType($"{typeBase.Namespace}.Clave{type.Name}");

            if (typeClave != null)
                return (ClaveBase)Activator.CreateInstance(typeClave, new object[] { objeto });
            else
                return null;
        }
    }
}
