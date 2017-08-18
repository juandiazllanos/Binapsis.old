using Binapsis.Plataforma.Notificaciones.Impl;
using System;

namespace Binapsis.Plataforma.Configuracion.Presentacion.Win
{
    class ControladorEntidad : IFabrica
    {
        public ControladorEntidad()
        {
            Fabrica = new Fabrica(FabricaNotificacion.Instancia);
        }

        static ControladorEntidad()
        {
            Instancia = new ControladorEntidad();
        }

        public static ControladorEntidad Instancia
        {
            get;
        }

        public Fabrica Fabrica
        {
            get;
        }
        
        object IFabrica.Crear()
        {
            throw new NotImplementedException();
        }

        object IFabrica.Crear(params object[] param)
        {
            Type type = null;

            if (param[0].GetType() == typeof(Type) || 
                param[0].GetType().IsSubclassOf(typeof(Type)))
                type = param[0] as Type;

            if (type != null)
                return Fabrica.Crear(type);
            else
                return null;
        }
    }
}
