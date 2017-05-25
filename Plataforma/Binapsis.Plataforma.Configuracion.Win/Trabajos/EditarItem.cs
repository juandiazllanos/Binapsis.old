using Binapsis.Plataforma.Configuracion.Win.Actividades;

namespace Binapsis.Plataforma.Configuracion.Win.Trabajos
{
    class EditarItem : Trabajo
    {
        public override IActividad CrearSiguiente(IActividad actividad)
        {
            if (actividad == null)
                return CrearActividad("RecuperarPropietario");

            else if (ResolverActividad(actividad, typeof(RecuperarPropietario)))
                return CrearActividad("RecuperarItem");

            else if (ResolverActividad(actividad, typeof(RecuperarItem)))
                return CrearActividadVista("Mostrar", Type);

            else if (ResolverActividad(actividad, typeof(Mostrar)))
                return CrearActividad("EjecutarItem");

            else
                return null;
        }
    }
}
