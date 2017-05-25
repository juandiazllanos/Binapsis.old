using Binapsis.Presentacion.MVVM.Definicion;
using Binapsis.Presentacion.MVVM.Observador;
using System.Collections.Generic;

namespace Binapsis.Presentacion.MVVM.Observable
{
    internal class ObservableVista
    {
        List<ObservadorVista> _observadores;

		public ObservableVista()
        {
            _observadores = new List<ObservadorVista>();
		}
        
		public void Agregar(ObservadorVista observador)
        {
            if (!_observadores.Contains(observador))
                _observadores.Add(observador);
		}
        
		public void Remover(ObservadorVista observador)
        {
            if (_observadores.Contains(observador))
                _observadores.Remove(observador);

		}

		public void RemoverTodo()
        {
            _observadores.Clear();
		}

        internal void Notificar(PropiedadInfo propiedad)
        {
            foreach (ObservadorVista observador in _observadores)
                observador.Notificar(propiedad);
        }        
	}

}