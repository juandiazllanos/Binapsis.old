using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Notificaciones
{
	public interface INotificacion
    {
        IPropiedad Propiedad { get; }
        IObjetoDatos ObjetoDatos { get; }
	}
}