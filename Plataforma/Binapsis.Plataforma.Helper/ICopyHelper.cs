using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Helper
{
    public interface ICopyHelper
    {
        IObjetoDatos Copiar(IObjetoDatos od);
        IObjetoDatos CopiarSuperficial(IObjetoDatos od);
    }
}
