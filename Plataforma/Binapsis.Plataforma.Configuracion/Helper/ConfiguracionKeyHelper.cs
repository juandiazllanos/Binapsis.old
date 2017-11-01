using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Helper.Impl;

namespace Binapsis.Plataforma.Configuracion.Helper
{
    public class ConfiguracionKeyHelper : KeyHelper
    {
        public override IPropiedad[] GetProperty(ITipo tipo)
        {            
            if (tipo.Nombre == "Tipo")
                return new IPropiedad[] { tipo["Uri"], tipo["Nombre"] };
            else
                return new IPropiedad[] { tipo["Nombre"] };            
        }
    }    
}
