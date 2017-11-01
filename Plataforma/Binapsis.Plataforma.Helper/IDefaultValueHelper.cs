using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Helper
{
    public interface IDefaultValueHelper
    {
        object GetDefaultValue(IPropiedad propiedad);
        object GetDefaultValue(ITipo tipo);
        bool IsDefaultValue(IPropiedad propiedad, object value);
    }
}
