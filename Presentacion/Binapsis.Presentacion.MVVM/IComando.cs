using Binapsis.Plataforma.Estructura;

namespace Binapsis.Presentacion.MVVM
{
    public interface IComando
    {
        void Ejecutar(IObjetoDatos od);
    }
}
