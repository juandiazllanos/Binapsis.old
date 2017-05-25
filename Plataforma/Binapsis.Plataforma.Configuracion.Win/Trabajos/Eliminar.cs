using Binapsis.Plataforma.Configuracion.Win.Actividades;

namespace Binapsis.Plataforma.Configuracion.Win.Trabajos
{
    class Eliminar : Trabajo
    {
        public override IActividad CrearSiguiente(IActividad actividad)
        {
            if (actividad == null)
                return CrearActividad("Recuperar");

            else if (ResolverActividad(actividad, typeof(Recuperar)))
                return CrearActividad("Confirmar");

            else if (ResolverActividad(actividad, typeof(Confirmar)))
                return Fabrica.CrearActividad("Ejecutar");

            else
                return null;
        }
    }
}
