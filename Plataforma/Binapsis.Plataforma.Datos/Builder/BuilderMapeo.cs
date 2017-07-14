using Binapsis.Plataforma.Datos.Mapeo;

namespace Binapsis.Plataforma.Datos.Builder
{
    abstract class BuilderMapeo
    {
        public IConfiguracion Configuracion
        {
            get;
            set;
        }

        public MapeoCatalogo MapeoCatalogo
        {
            get;
            set;
        }
    }
}
