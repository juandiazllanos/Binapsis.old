using Binapsis.Plataforma;
using Binapsis.Plataforma.Estructura;

namespace Binapsis.Modelo
{
    public class Provincia : EntidadBase
    {
        protected Provincia(IImplementacion impl) 
            : base(impl)
        {
        }

        public string Codigo
        {
            get => ObtenerString("Codigo");
            set => EstablecerString("Codigo", value);
        }

        public string Nombre
        {
            get => ObtenerString("Nombre");
            set => EstablecerString("Nombre", value);
        }
    }
}
