using Binapsis.Plataforma.Configuracion.Win.Actividades;

namespace Binapsis.Plataforma.Configuracion.Win.Trabajos
{
    class CrearItem : Trabajo
    {
        public override IActividad CrearSiguiente(IActividad actividad)
        {
            if (actividad == null)
                return CrearActividad("RecuperarPropietario");

            else if (ResolverActividad(actividad, typeof(RecuperarPropietario)))
                return CrearActividad("InstanciarItem");

            else if (ResolverActividad(actividad, typeof(InstanciarItem)))                
                return CrearActividadVista("Mostrar", Type);

            else if (ResolverActividad(actividad, typeof(Mostrar)))
                return CrearActividad("EjecutarItem");

            else
                return null;
        }
    }
}
