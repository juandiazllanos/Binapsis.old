using Binapsis.Plataforma.Configuracion.Base;
using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Estructura.Impl;
using Binapsis.Plataforma.Estructura.Impl.Extension;
using System;

namespace Binapsis.Plataforma.Configuracion
{
    public class Fabrica : FabricaBase<ConfiguracionBase>
    {
        #region Constructores
        public Fabrica()
        {            
        }

        public Fabrica(IFabricaImpl fabrica) 
            : base(fabrica)
        {
        }
        #endregion


        public static Fabrica Instancia { get; } = new Fabrica();


        #region Metodos
        public ConfiguracionBase Crear(Type type)
        {
            ITipo tipo = BaseTypes.Obtener(type);
            if (tipo != null)
                return Crear(tipo);            
            else
                return null;
        }

        //public ConfiguracionBase Crear(Type type, IObjetoDatos od)
        //{
        //    ITipo tipo = BaseTypes.Obtener(type);
        //    if (tipo != null)
        //        return Crear(tipo);
        //    else
        //        return null;
        //}

        public T Crear<T>() where T : ConfiguracionBase
        {
            return (T)Crear(typeof(T));
        }

        internal ConfiguracionBase Crear(Type type, IFabricaImpl impl)
        {
            ITipo tipo = BaseTypes.Obtener(type);
            if (tipo != null)
                return Crear(impl.Crear(tipo));
            else
                return null;
        }

        public override ConfiguracionBase Crear(IImplementacion impl)
        {
            Type type = Type.GetType(string.Format("{0}.{1}", impl.Tipo.Uri, impl.Tipo.Nombre));
            object instancia = Activator.CreateInstance(type, impl);
            return (ConfiguracionBase)instancia;
        }

        public T Crear<T>(IObjetoDatos od) where T : ConfiguracionBase
        {
            return (T)Crear(od as ObjetoBase);
        }

        public ConfiguracionBase Crear(IObjetoDatos od) 
        {
            return base.Crear(od as ObjetoBase);
        }
        #endregion

    }
}
