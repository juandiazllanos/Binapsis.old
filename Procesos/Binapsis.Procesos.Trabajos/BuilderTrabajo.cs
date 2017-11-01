using Binapsis.Consola.Definicion;
using Binapsis.Consola.Helpers;

namespace Binapsis.Procesos.Trabajos
{
    public class BuilderTrabajo
    {
        public BuilderTrabajo(Trabajo trabajo)
        {
            Trabajo = trabajo;
        }

        #region Metodos
        public void Construir()
        {
            ConstruirResultados(Trabajo.TrabajoInfo);
            ConstruirActividades(Trabajo.TrabajoInfo);
            ConstruirAsociaciones(Trabajo.TrabajoInfo);
        }

        private void ConstruirResultados(TrabajoInfo trabajoInfo)
        {
            foreach (ResultadoInfo resultadoInfo in trabajoInfo.Resultados)
                Trabajo.Resultados.Crear(resultadoInfo);
        }

        private void ConstruirActividades(TrabajoInfo trabajoInfo)
        {
            foreach (ActividadInfo actividadInfo in trabajoInfo.Actividades)
                Trabajo.Actividades.Agregar(CrearActividad(actividadInfo));
        }

        private void ConstruirAsociaciones(TrabajoInfo trabajoInfo)
        {
            foreach (AsociacionInfo asociacionInfo in trabajoInfo.Asociaciones)
                Trabajo.Asociaciones.Agregar(CrearAsociacion(asociacionInfo));
        }

        private Actividad CrearActividad(ActividadInfo actividadInfo)
        {
            Actividad actividad = TypeInfoHelper.Crear(actividadInfo.TypeInfo, actividadInfo) as Actividad;
            return actividad;
        }

        private Asociacion CrearAsociacion(AsociacionInfo asociacionInfo)
        {
            Asociacion asociacion = new Asociacion();
            asociacion.ActividadOrigen = Trabajo.Actividades[asociacionInfo.ActividadOrigen];
            asociacion.ActividadDestino = Trabajo.Actividades[asociacionInfo.ActividadDestino];
            asociacion.Resultado = Trabajo.Resultados[asociacionInfo.Nombre];

            return asociacion;
        }
        #endregion


        #region Propiedades
        public Trabajo Trabajo
        {
            get;
        }
        #endregion
    }
}
