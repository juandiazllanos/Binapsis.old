using Binapsis.Plataforma.Notificaciones;
using Binapsis.Presentacion.MVVM.Controlador;
using System.Reflection;

namespace Binapsis.Presentacion.MVVM.Observador
{
    internal class ObservadorModelo : IObservador
    {
        ControladorVistaModelo _controlador;

        public ObservadorModelo(ControladorVistaModelo vistaModelo)
        {
            _controlador = vistaModelo;
        }

        public void Notificar(INotificacion msg)
        {
            INotificacionColeccion msgcol = null;

            if (typeof(INotificacionColeccion).GetTypeInfo().IsAssignableFrom(msg.GetType().GetTypeInfo()))
                msgcol = (INotificacionColeccion)msg;

            if (msgcol == null)
                _controlador.ActualizarVista(msg);
            else
                _controlador.ActualizarVista(msgcol);
        }
    }
}
