using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Notificaciones;
using Binapsis.Plataforma.Notificaciones.Impl.Extension;
using Binapsis.Presentacion.MVVM.Vista;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Reflection;

namespace Binapsis.Presentacion.MVVM
{
    public class VistaModelo
    {
        IObjetoDatos _modelo;
        VistaObjeto _vista;

        IObservable _observableModelo;
        IObservador _observadorModelo;
        ObservableVista _observableVista;
        ObservadorVista _observadorVista;
                
        Dictionary<IPropiedad, VistaModeloPropiedad> _vistaModeloPropiedad;
        
        internal VistaModelo(IObjetoDatos modelo, VistaObjeto vista)
        {
            _modelo = modelo;
            _vista = vista;
            _vistaModeloPropiedad = new Dictionary<IPropiedad, VistaModeloPropiedad>();            

            // observables
            _observableModelo = _modelo.Obervable();
            _observableVista = _vista.Observable;

            // si el modelo implementa notificaciones, enalzar observadores
            if (_observableModelo != null)
            {
                // observadores
                _observadorModelo = new ObservadorModelo(this);
                _observadorVista = new ObservadorVista(this);

                // asociar 
                _observableModelo.Agregar(_observadorModelo);
                _observableVista.Agregar(_observadorVista);
            }

            // construir vista modelo
            Construir();

            // actualizar vista
            ActualizarVistaInicial();
        }

        public void Construir()
        {
            foreach (IPropiedad propiedad in _vista.VistaPropiedad.Where((item) => !item.Propiedad.Tipo.EsTipoDeDato).Select((item) => item.Propiedad))
                CrearVistaModelo(propiedad);
        }

        public void ActualizarModelo()
        {
            foreach (IPropiedad propiedad in _vista.VistaPropiedad.Where((item) => !item.Propiedad.EsColeccion).Select((item) => item.Propiedad))
                ActualizarModelo(propiedad);
        }

        internal void ActualizarModelo(IPropiedad propiedad)
        {
            _modelo.Establecer(propiedad, _vista.Obtener(propiedad));
        }

        // solo se ejecuta cuando se instancia el vistaModelo, solo actualiza la vista asociada
        private void ActualizarVistaInicial()
        {
            foreach (IPropiedad propiedad in _vista.VistaPropiedad.Where((item) => item.Propiedad.Tipo.EsTipoDeDato).Select((item) => item.Propiedad))
                ActualizarVista(propiedad);
        }

        public void ActualizarVista()
        {
            foreach (IPropiedad propiedad in _vista.VistaPropiedad.Where((item) => !item.Propiedad.EsColeccion).Select((item) => item.Propiedad))
                ActualizarVista(propiedad);
        }

        internal void ActualizarVista(IPropiedad propiedad)
        {
            if (propiedad.Tipo.EsTipoDeDato)
                _vista.Establecer(propiedad, _modelo.Obtener(propiedad));
            else
                ActualizarVistaReferencia(propiedad);
        }

        private void ActualizarVistaReferencia(IPropiedad propiedad)
        {
            if (propiedad.Tipo.EsTipoDeDato || propiedad.EsColeccion) return;

            IObjetoDatos od = _modelo.ObtenerObjetoDatos(propiedad);

            if (od == null)
                EliminarVistaModelo(propiedad);
            else
                CrearVistaModelo(propiedad, od);
        }

        internal void ActualizarVistaColeccion(IPropiedad propiedad, IObjetoDatos item, Accion accion)
        {
            if (accion == Accion.Agregar)
                CrearVistaModelo(propiedad, item);
            else if (accion == Accion.Remover)            
                EliminarVistaModelo(propiedad, item);
        }

        private void CrearVistaModelo(IPropiedad propiedad)
        {
            if (propiedad.Tipo.EsTipoDeDato) return;

            if (propiedad.EsColeccion)
                foreach (IObjetoDatos item in _modelo.ObtenerColeccion(propiedad))
                    CrearVistaModelo(propiedad, item);            
            else
                CrearVistaModelo(propiedad, _modelo.ObtenerObjetoDatos(propiedad));                     
        }

        private void CrearVistaModelo(IPropiedad propiedad, IObjetoDatos modelo)
        {
            if (modelo == null) return;
            VistaModeloPropiedad vistaModeloPropiedad = CrearVistaModeloPropiedad(propiedad);
            if (vistaModeloPropiedad == null) return;
            vistaModeloPropiedad.Crear(modelo);            
        }
        
        private VistaModeloPropiedad CrearVistaModeloPropiedad(IPropiedad propiedad)
        {
            VistaModeloPropiedad vistaModeloPropiedad = ObtenerVistaModeloPropiedad(propiedad);
            if (vistaModeloPropiedad != null) return vistaModeloPropiedad;

            if (propiedad.EsColeccion)
                vistaModeloPropiedad =  new VistaModeloColeccion(this, propiedad);
            else if (!propiedad.Tipo.EsTipoDeDato)
                vistaModeloPropiedad = new VistaModeloReferencia(this, propiedad);

            if (vistaModeloPropiedad != null)
                _vistaModeloPropiedad.Add(propiedad, vistaModeloPropiedad);

            return vistaModeloPropiedad;
        }

        private VistaModeloPropiedad ObtenerVistaModeloPropiedad(IPropiedad propiedad)
        {
            if (!_vistaModeloPropiedad.ContainsKey(propiedad)) return null;
            return _vistaModeloPropiedad[propiedad];
        }

        private void EliminarVistaModelo(IPropiedad propiedad)
        {
            EliminarVistaModelo(propiedad, null);
        }

        private void EliminarVistaModelo(IPropiedad propiedad, IObjetoDatos modelo)
        {
            VistaModeloPropiedad vistaModeloPropiedad = ObtenerVistaModeloPropiedad(propiedad);
            if (vistaModeloPropiedad == null) return;

            if (modelo == null)
                vistaModeloPropiedad.Eliminar();
            else
                vistaModeloPropiedad.Eliminar(modelo);
        }
        
        public void Liberar()
        {
            _vista.Liberar();

            foreach (VistaModeloPropiedad vistaModeloPropiedad in _vistaModeloPropiedad.Values)
                vistaModeloPropiedad.EliminarTodo();

            _vistaModeloPropiedad.Clear();

            if (_observableModelo != null && _observadorModelo != null)
                _observableModelo.Remover(_observadorModelo);

            if (_observableVista != null && _observadorVista != null)
                _observableVista.Remover(_observadorVista);
        }
        
        internal IObjetoDatos Modelo
        {
            get { return _modelo; }
        }

        internal VistaObjeto Vista
        {
            get { return _vista; }
        }
    }
}
