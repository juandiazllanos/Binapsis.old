using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Notificaciones.Impl
{
    internal class Notificacion : INotificacion
    {
        public Notificacion(IObjetoDatos od, IPropiedad propiedad)
        {
            ObjetoDatos = od;
            Propiedad = propiedad;
        }

        public IObjetoDatos ObjetoDatos { get; set; }
        public IPropiedad Propiedad { get; set; }        
    }
}
