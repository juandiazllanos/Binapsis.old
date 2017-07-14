using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Helper
{
    public interface IEqualityHelper
    {
        bool Igual(IObjetoDatos od1, IObjetoDatos od2);
        bool IgualSuperficial(IObjetoDatos od1, IObjetoDatos od2);
    }
}
