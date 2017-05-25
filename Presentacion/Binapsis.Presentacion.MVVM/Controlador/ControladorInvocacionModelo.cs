using Binapsis.Presentacion.MVVM.Observable;
using Binapsis.Presentacion.MVVM.Observador;

namespace Binapsis.Presentacion.MVVM.Controlador
{
    class ControladorInvocacionModelo
    {
        ObservadorInvocacion _observador;
        ObservableInvocacion _observable;
        
        public ControladorInvocacionModelo()
        {
            _observador = new ObservadorInvocacion(this);            
        }

        public void Establecer(InvocacionModelo invocacionModelo)
        {
            InvocacionModelo = invocacionModelo;
            Establecer(InvocacionModelo.Invocacion);            
        }

        private void Establecer(Invocacion invocacion)
        {
            if (_observable != null) _observable.Remover(_observador);

            // obtener observable
            _observable = invocacion?.Observable;
            // asociar observador
            if (_observable != null)
                _observable.Agregar(_observador);
        }
        
        public void Ejecutar(string comando)
        {
            InvocacionModelo.Ejecutar(comando);
        }

        public InvocacionModelo InvocacionModelo
        {
            get;
            private set;
        }
    }
}
