using Binapsis.Plataforma.Notificaciones;
using System.Reflection;

namespace Binapsis.Presentacion.MVVM
{
    internal class ObservadorModelo : IObservador
    {
        VistaModelo _vistaModelo;

        public ObservadorModelo(VistaModelo vistaModelo)
        {
            _vistaModelo = vistaModelo;
        }

        public void Notificar(INotificacion msg)
        {
            if (typeof(INotificacionColeccion).GetTypeInfo().IsAssignableFrom(msg.GetType().GetTypeInfo()))
                _vistaModelo.ActualizarVistaColeccion(msg.Propiedad, ((INotificacionColeccion)msg).Item, ((INotificacionColeccion)msg).Accion);
            else
                _vistaModelo.ActualizarVista(msg.Propiedad);
        }
    }
}
