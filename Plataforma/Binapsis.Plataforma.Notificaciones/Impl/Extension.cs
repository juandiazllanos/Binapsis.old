using System.Reflection;
using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Estructura.Impl;
using Binapsis.Plataforma.Estructura.Impl.Extension;

namespace Binapsis.Plataforma.Notificaciones.Impl.Extension
{
    public static class Extension
    {
        public static Observable Obervable(this IObjetoDatos objetoDatos)
        {
            if (objetoDatos.GetType() == typeof(ObjetoBase) || objetoDatos.GetType().GetTypeInfo().IsSubclassOf(typeof(ObjetoBase)))
                return Observable((ObjetoBase)objetoDatos);
            else
                return null;
        }

        public static Observable Observable (this ObjetoBase objetoBase)
        {
            IImplementacion impl = objetoBase.Implementacion();
            Observable observable = Observable(impl);

            if (observable != null)
                observable.ObjetoDatos = objetoBase;

            return observable;            
        }

        private static Observable Observable(IImplementacion impl)
        {
            if (impl.GetType().GetTypeInfo().IsSubclassOf(typeof(ImplementacionBase)))
                return Observable((ImplementacionBase)impl);
            else
                return null;
        }

        public static Observable Observable(this ImplementacionBase impl)
        {
            if (impl.GetType() == typeof(ImplementacionNotificacion))
                return ((ImplementacionNotificacion)impl).Observable;
            else 
                return Observable(impl.Impl);            
        }
    }
}
