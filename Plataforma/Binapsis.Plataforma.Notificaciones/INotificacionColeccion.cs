using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Notificaciones
{
	public interface INotificacionColeccion : INotificacion
    {
        Accion Accion { get; }
        int Indice { get; }
        IObjetoDatos Item { get; }        
	}
}