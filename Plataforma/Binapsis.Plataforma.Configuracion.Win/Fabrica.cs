using Binapsis.Plataforma.Configuracion.Win.Actividades;
using Binapsis.Plataforma.Configuracion.Win.Trabajos;
using Binapsis.Plataforma.Configuracion.Win.Vistas;
using System;

namespace Binapsis.Plataforma.Configuracion.Win
{
    class Fabrica
    {   
        public static Actividad CrearActividad(string nombre)
        {
            return Crear<Actividad>(nombre);            
        }

        public static Actividad CrearActividad(string nombre, Type type)
        {
            return CrearActividad($"{nombre}{type.Name}");
        }

        public static Actividad CrearActividadVista(string nombre, VistaBase vista)
        {
            return Crear<Actividad>(nombre, new object[] { vista });
        }

        public static Actividad CrearActividadVista(string nombre, Type type, VistaBase vista)
        {
            return CrearActividadVista($"{nombre}{type.Name}", vista);
        }

        public static VistaBase CrearVista(Type type)
        {
            return Crear<VistaBase>($"Vista{type.Name}");
        }

        public static Trabajo CrearTrabajo(Accion accion)
        {
            return Crear<Trabajo>(accion.Nombre);            
        }

        public static Trabajo CrearTrabajo(Accion accion, Type type)
        {
            return Crear<Trabajo>($"{accion.Nombre}{type.Name}");            
        }

        private static T Crear<T>(string type)
        {
            return Crear<T>(type, null);
        }

        private static T Crear<T>(string type, object[] arg)
        {
            Type typeBase = typeof(T);
            return Crear<T>(typeBase.Namespace, type, arg);            
        }

        private static T Crear<T>(string uri, string type, object[] arg)
        {            
            Type typeInstancia = Type.GetType($"{uri}.{type}");

            if (typeInstancia == null) return default(T);

            if (arg == null)
                return (T)Activator.CreateInstance(typeInstancia);
            else
                return (T)Activator.CreateInstance(typeInstancia, arg);
        }
    }
}
