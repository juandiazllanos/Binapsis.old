using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Datos
{
    public interface IClave
    {
        object Obtener(IObjetoDatos od, string columna);
    }
}
