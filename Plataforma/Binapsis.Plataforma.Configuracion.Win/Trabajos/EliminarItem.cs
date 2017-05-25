using Binapsis.Plataforma.Configuracion.Win.Actividades;

namespace Binapsis.Plataforma.Configuracion.Win.Trabajos
{
    class EliminarItem : Trabajo
    {
        public override IActividad CrearSiguiente(IActividad actividad)
        {
            if (actividad == null)
                return CrearActividad("RecuperarPropietario");

            else if (ResolverActividad(actividad, typeof(RecuperarPropietario)))
                return CrearActividad("RecuperarItem");

            else if (ResolverActividad(actividad, typeof(RecuperarItem)))
                return CrearActividad("Confirmar");

            else if (ResolverActividad(actividad, typeof(Confirmar)))
                return Fabrica.CrearActividad("EjecutarItem");

            else
                return null;
        }
    }
}
