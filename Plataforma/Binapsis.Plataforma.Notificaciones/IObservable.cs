namespace Binapsis.Plataforma.Notificaciones
{
    public interface IObservable
    {
        void Agregar(IObservador observador);
        void Remover(IObservador observador);
        void RemoverTodo();
    }
}