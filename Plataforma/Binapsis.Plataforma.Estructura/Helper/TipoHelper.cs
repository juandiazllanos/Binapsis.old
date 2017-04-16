using System;

namespace Binapsis.Plataforma.Estructura.Helpers
{
    public static class TipoHelper
    {
        public static Type ObtenerType(ITipo tipo)
        {
            return Type.GetType(string.Format("{0}.{1}", tipo.Uri, tipo.Nombre));
        }
        
    }
}
