using Binapsis.Presentacion.MVVM.Observador;
using System.Collections.Generic;

namespace Binapsis.Presentacion.MVVM.Observable
{
    class ObservableInvocacion
    {
        List<ObservadorInvocacion> _observadores;

        public ObservableInvocacion()
        {
            _observadores = new List<ObservadorInvocacion>();
        }

        public void Agregar(ObservadorInvocacion observador)
        {
            if (!_observadores.Contains(observador))
                _observadores.Add(observador);
        }

        public void Remover(ObservadorInvocacion observador)
        {
            if (_observadores.Contains(observador))
                _observadores.Remove(observador);
        }

        public void RemoverTodo()
        {
            _observadores.Clear();
        }

        internal void Notificar(string nombre)
        {
            foreach(ObservadorInvocacion observador in _observadores)
                observador.Notificar(nombre);
        }
    }
}
