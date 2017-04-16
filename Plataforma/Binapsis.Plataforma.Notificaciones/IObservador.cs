namespace Binapsis.Plataforma.Notificaciones
{
    public interface IObservador
    {
        void Notificar(INotificacion msg);
    }
}
