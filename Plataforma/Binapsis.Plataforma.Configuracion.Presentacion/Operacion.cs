using System;
using System.Collections.Generic;

namespace Binapsis.Plataforma.Configuracion.Presentacion
{
    public class Operacion
    {
        Secuencia _secuencia;
        Stack<Actividad> _actividades;
        string _actividadActual;
        

        #region Constructores
        public Operacion(Secuencia secuencia)
        {
            _secuencia = secuencia;
            _actividades = new Stack<Actividad>();
        }
        #endregion


        #region Metodos
        public void Iniciar()
        {
            Iniciar(_secuencia.Inicio);
        }

        public void Iniciar(string actividad)
        {
            Notificacion?.Iniciar(this);
            Siguiente(actividad);
        }

        private void Terminar()
        {
            Notificacion?.Terminar(this);
        }

        internal void Siguiente()
        {
            string clave = _actividades.Peek()?.Resultado;
            string actividadSiguiente = _secuencia.Siguiente(_actividadActual, clave);
            
            Siguiente(actividadSiguiente);
        }

        internal void Siguiente(string actividad)
        {
            Actividad actividadItem = Obtener(actividad);

            if (actividadItem != null)
            {
                _actividadActual = actividad;
                _actividades.Push(actividadItem);

                actividadItem.Iniciar();
            }
            else
                Terminar();
            
        }
        
        public Actividad Obtener(string actividad)
        {
            if (actividad == null) return null;

            IFabrica fabrica = Contexto.ObtenerFabrica("actividad");
            Type type = _secuencia.Obtener(actividad);
            Actividad actividadInstancia = null;

            if (type != null)             
                actividadInstancia = fabrica.Crear(type) as Actividad;

            if (actividadInstancia != null)
                actividadInstancia.Operacion = this;

            return actividadInstancia;
        }        
        #endregion


        #region Propiedades
        internal IContexto Contexto
        {
            get;
            set;
        }

        internal Parametros Parametros
        {
            get;
            set;
        }
        
        internal Notificacion Notificacion
        {
            get;
            set;
        }

        internal string Resultado
        {
            get => _actividades.Peek()?.Resultado;
        }
        #endregion

    }
}