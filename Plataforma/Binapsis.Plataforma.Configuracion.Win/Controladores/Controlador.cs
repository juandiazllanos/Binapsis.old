using Binapsis.Plataforma.Estructura.Impl;
using Binapsis.Plataforma.Configuracion.Win.Trabajos;
using System;

namespace Binapsis.Plataforma.Configuracion.Win.Controladores
{
    internal class Controlador : IControlador 
    {
        IContexto _contexto;
        Accion _accion;
        Trabajo _trabajo;
        IActividad _actividad;

        internal Controlador(IContexto contexto, Accion accion)
        {
            _contexto = contexto;
            _accion = accion;
            _trabajo = CrearTrabajo(contexto.Type);

            Type = contexto.Type;
        }

        private Trabajo CrearTrabajo(Type type)
        {
            Trabajo trabajo = null;
            
            trabajo = Fabrica.CrearTrabajo(_accion, type);

            if (trabajo == null)
                trabajo = Fabrica.CrearTrabajo(_accion);

            trabajo.Type = type;

            return trabajo;
        }

        public void Ejecutar()
        {            
            Siguiente();
        }

        public void Siguiente()
        {
            if (_actividad != null && _actividad.Resultado == Resultado.OK)
                Estado = _actividad.Estado;

            _actividad = _trabajo?.CrearSiguiente( _actividad);

            if (_actividad != null)
            {
                _actividad.Controlador = this;
                _actividad.Estado = Estado;
                _actividad.Type = Type;
                _actividad.Iniciar();
            }
            else
                Terminar();
        }

        private void Terminar()
        {
            _contexto.Refrescar();
        }

        public Accion Accion
        {
            get { return _accion; }
        }

        public IActividad Actividad
        {
            get { return _actividad; }
        }

        public IContexto Contexto
        {
            get => _contexto;
        }

        protected ObjetoBase Estado
        {
            get;
            set;
        }
        
        public Type Type
        {
            get;
            private set;
        }
    }
}
