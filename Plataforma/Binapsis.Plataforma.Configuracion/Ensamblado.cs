using Binapsis.Plataforma.Estructura.Impl;
using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Configuracion
{
    public class Ensamblado : ObjetoBase
    {
        public Ensamblado(IImplementacion impl) 
            : base(impl)
        {
        }

        public string Nombre
        {
            get
            {
                return ObtenerString("Nombre");
            }
            set
            {
                EstablecerString("Nombre", value);
            }
        }
    }
}
