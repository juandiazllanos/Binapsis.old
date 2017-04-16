using System;
using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Notificaciones.Impl
{
    internal class NotificacionColeccion : Notificacion, INotificacionColeccion
    {
        public NotificacionColeccion(IObjetoDatos propietario, IPropiedad propiedad) 
            : base(propietario, propiedad)
        {
        }

        public Accion Accion { get; set; }
        public int Indice { get; set; }
        public IObjetoDatos Item { get; set; }
    }
}
