using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Cambios
{
    public interface IPropiedadCambios
    {
        IPropiedad Propiedad { get; }
        object ValorAntiguo { get; }
    }
}
