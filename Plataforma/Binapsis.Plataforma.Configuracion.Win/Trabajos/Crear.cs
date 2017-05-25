using Binapsis.Plataforma.Configuracion.Win.Actividades;
//using Binapsis.Plataforma.Configuracion.Win.Vistas;

namespace Binapsis.Plataforma.Configuracion.Win.Trabajos
{
    internal class Crear : Trabajo
    {
        public override IActividad CrearSiguiente(IActividad actividad)
        {
            if (actividad == null)
                return CrearActividad("Instanciar");            

            else if (ResolverActividad(actividad, typeof(Instanciar))) 
                return CrearActividad("Construir");

            else if (ResolverActividad(actividad, typeof(Construir)))
                return CrearActividadVista("Mostrar", Type);

            else if (ResolverActividad(actividad, typeof(Mostrar)))
                return CrearActividad("Ejecutar");

            else
                return null;
        }
    }
}
