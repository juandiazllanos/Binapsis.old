using Binapsis.Plataforma.Estructura;
using System.Collections.Generic;

namespace Binapsis.Plataforma.Helper
{
    public interface IClaveHelper
    {
        IEnumerable<IClave> Obtener(IObjetoDatos od);
        string ObtenerString(IObjetoDatos od);
    }
}
