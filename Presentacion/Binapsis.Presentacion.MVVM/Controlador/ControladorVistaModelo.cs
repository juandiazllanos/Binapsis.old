using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Notificaciones;
using Binapsis.Plataforma.Notificaciones.Impl.Extension;
using Binapsis.Presentacion.MVVM.Helper;
using Binapsis.Presentacion.MVVM.Definicion;
using Binapsis.Presentacion.MVVM.Observador;
using Binapsis.Presentacion.MVVM.Observable;

namespace Binapsis.Presentacion.MVVM.Controlador
{
    internal class ControladorVistaModelo
    {        
        HelperModelo _helper;
        
        IObservable _observableModelo;
        IObservador _observadorModelo;

        ObservableVista _observableVista;
        ObservadorVista _observadorVista;

        public ControladorVistaModelo()
        {
            _observadorModelo = new ObservadorModelo(this);
            _observadorVista = new ObservadorVista(this);
        }
        
        public void Establecer(VistaModelo vistaModelo)
        {
            VistaModelo = vistaModelo;
            Establecer(VistaModelo.Modelo, VistaModelo.Vista);
        }

        private void Establecer(IObjetoDatos modelo, Vista vista)
        {
            Modelo = modelo;
            Vista = vista;

            // establecer helper
            _helper = new HelperModelo(Modelo);

            // remover observadores
            if (_observableModelo != null) _observableModelo.Remover(_observadorModelo);
            if (_observableVista != null) _observableVista.Remover(_observadorVista);

            // obtener observables
            _observableModelo = Modelo?.Observable();
            _observableVista = Vista?.Observable;

            // modelo debe implementar un observable
            if (_observableModelo == null) return;
            
            // asociar observadores
            _observableModelo.Agregar(_observadorModelo);
            _observableVista.Agregar(_observadorVista);
            
        }
        
        internal void ActualizarModelo(PropiedadInfo propiedad)
        {
            if (propiedad.TipoInfo.EsTipoDeDato)
                _helper.Establecer(propiedad, Vista.Obtener(propiedad));
        }
        
        public void ActualizarVista(INotificacion msg)
        {
            PropiedadInfo propiedad = Vista.TipoInfo[msg.Propiedad.Nombre];
            if (propiedad == null) return;

            ActualizarVista(propiedad);
        }

        public void ActualizarVista(INotificacionColeccion msg)
        {
            PropiedadInfo propiedad = Vista.TipoInfo[msg.Propiedad.Nombre];
            if (propiedad == null) return;

            if (msg.Accion == Accion.Agregar)
                VistaModelo.AgregarVistaModelo(propiedad, msg.Item);
            else if (msg.Accion == Accion.Remover)
                VistaModelo.RemoverVistaModelo(propiedad, msg.Item);
        }

        internal void ActualizarVista(PropiedadInfo propiedad)
        {
            if (propiedad.TipoInfo.EsTipoDeDato)
                Vista.Establecer(propiedad, _helper.Obtener(propiedad));
            else if (!propiedad.EsColeccion)
                VistaModelo.EstablecerVistaModelo(propiedad, (IObjetoDatos)_helper.Obtener(propiedad));
        }
          

        #region Propiedades
        public IObjetoDatos Modelo
        {
            get;
            private set;
        }

        public Vista Vista
        {
            get;
            private set;
        }

        public VistaModelo VistaModelo
        {
            get;
            private set;
        }
        #endregion
    }
}
