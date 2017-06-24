using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Cambios.Analisis
{
    class AnalisisPropiedadCambios
    {
        public AnalisisPropiedadCambios(AnalisisObjetoCambios aoc, IPropiedad propiedad)
        {
            AnalisisObjetoCambios = aoc;
            Propiedad = propiedad;
        }

        public virtual void Resolver()
        {
        }

        public AnalisisObjetoCambios AnalisisObjetoCambios
        {
            get;
        }

        public Cambio Cambio
        {
            get;
            protected set;
        }

        public IPropiedad Propiedad
        {
            get;
        }
        
    }
}
