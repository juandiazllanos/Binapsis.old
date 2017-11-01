using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Datos
{
    public interface IPrimaryKey
    {
        object Get(IObjetoDatos od);
        object Get();
    }
}
