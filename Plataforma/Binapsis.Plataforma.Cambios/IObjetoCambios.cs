using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Cambios
{
    public interface IObjetoCambios : IObjetoDatos
    {
        Cambio Cambio { get; set; }
        string Referencia { get; set; }
    }
}
