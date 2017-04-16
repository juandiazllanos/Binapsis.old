using Binapsis.Plataforma.Estructura;
using System.Collections.Generic;

namespace Binapsis.Plataforma.Notificaciones.Impl
{
    public class Observable : IObservable
    {        
        List<IObservador> _observadores;

        public Observable()
        {
            _observadores = new List<IObservador>();
        }
        
        public void Agregar(IObservador observador)
        {
            if (!_observadores.Contains(observador))
                _observadores.Add(observador);
        }

        public void Remover(IObservador observador)
        {
            if (_observadores.Contains(observador))
                _observadores.Remove(observador);
        }

        public void RemoverTodo()
        {
            _observadores.Clear();
        }

        private void Notificar(INotificacion msg)
        {
            if (msg.ObjetoDatos == null || msg.Propiedad == null) return;

            foreach (IObservador observador in _observadores)
                observador.Notificar(msg);
        }

        internal void Notificar(IPropiedad propiedad)
        {
            Notificar(new Notificacion(ObjetoDatos, propiedad));
        }

        internal void NotificarAgregar(IPropiedad propiedad, IObjetoDatos item, int indice)
        {
            Notificar(new NotificacionColeccion(ObjetoDatos, propiedad) { Accion = Accion.Agregar, Item = item, Indice = indice });
        }

        internal void NotificarRemover(IPropiedad propiedad, IObjetoDatos item, int indice)
        {
            Notificar(new NotificacionColeccion(ObjetoDatos, propiedad) { Accion = Accion.Remover, Item = item, Indice = indice });
        }

        public IObjetoDatos ObjetoDatos { get; internal set; }

    }
}
