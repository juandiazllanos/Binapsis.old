using System.Collections.Generic;
using System.Linq;
using Binapsis.Consola.Definicion;
using Binapsis.Procesos.Orquestacion;

namespace Binapsis.Procesos.Trabajos
{
    public class Trabajo : Comando
    {
        Stack<Actividad> _pila = new Stack<Actividad>();
        Actividad _actividadActual;

        public Trabajo(TrabajoInfo trabajoInfo)
            : base()
        {
            Actividades = new Actividades();
            Asociaciones = new Asociaciones();
            Resultados = new Resultados();
            TrabajoInfo = trabajoInfo;
        }


        #region Metodos
        public override void Ejecutar()
        {
            Actividad actividad = Actividades[TrabajoInfo.ActividadInicio];

            if (actividad != null)
                Ejecutar(actividad);
        }

        internal void Ejecutar(Actividad actividad)
        {            
            // estabecer actividad actual
            _actividadActual = actividad;
            // establecer parametros
            _actividadActual.Parametros.Establecer(Parametros);
            // ejecutar actividad
            actividad.Ejecutar();
            // agregar en la pila de actividades ejecutadas
            _pila.Push(actividad);
            // recuperar parametros
            Parametros.Establecer(_actividadActual.Parametros);
            // ejecutar siguiente actividad
            Siguiente();
        }

        internal void Siguiente()
        {
            if (_actividadActual == null) return;

            Resultado resultado = Resultados[_actividadActual.Resultado];
            if (resultado == null) return;

            Actividad actividad = Asociaciones.FirstOrDefault(item => 
                item.ActividadOrigen == _actividadActual && 
                item.Resultado == resultado)?.ActividadDestino;

            if (actividad != null)
                Ejecutar(actividad);
        }
        #endregion


        #region Propiedades
        public Actividades Actividades
        {
            get;
        }

        public Asociaciones Asociaciones
        {
            get;
        }

        public Resultados Resultados
        {
            get;
        }

        public TrabajoInfo TrabajoInfo
        {
            get;
        }
        #endregion

    }
}
