using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Configuracion
{
    public class Contexto : ConfiguracionBase
    {
        public Contexto(IImplementacion impl) 
            : base(impl)
        {
        }

        public string Nombre
        {
            get => ObtenerString("Nombre");
            set => EstablecerString("Nombre", value);
        }

        public string Url
        {
            get => ObtenerString("Url");
            set => EstablecerString("Url", value);
        }
    }
}
