using Binapsis.Plataforma.Configuracion.Win.Actividades;

namespace Binapsis.Plataforma.Configuracion.Win.Trabajos
{
    class Editar : Trabajo
    {
        public override IActividad CrearSiguiente(IActividad actividad)
        {
            if (actividad == null)
                return CrearActividad("Recuperar");

            else if (ResolverActividad(actividad, typeof(Recuperar)))
                return CrearActividadVista("Mostrar", Type);

            else if (ResolverActividad(actividad, typeof(Mostrar)))
                return CrearActividad("Ejecutar");

            else
                return null;            
        }
    }
}
