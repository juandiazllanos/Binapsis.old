using System;
using System.Reflection;

namespace Binapsis.Plataforma.Configuracion.Win.Trabajos
{
    internal abstract class Trabajo : ITrabajo
    {
        public abstract IActividad CrearSiguiente(IActividad actividad);

        protected IActividad CrearActividad(string nombre)
        {
            return Fabrica.CrearActividad(nombre);
        }

        protected IActividad CrearActividadVista(string nombre, Type type)
        {
            return Fabrica.CrearActividadVista(nombre, Fabrica.CrearVista(type));
        }

        protected bool ResolverActividad(IActividad actividad, Type type)
        {
            return (actividad != null && actividad.Resultado == Resultado.OK && 
                   (actividad.GetType() == type || actividad.GetType().GetTypeInfo().IsSubclassOf(type)));
        }

        public Type Type
        {
            get;
            set;
        }
    }
}
