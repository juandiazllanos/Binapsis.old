using Binapsis.Plataforma.Estructura;
using System;

namespace Binapsis.Plataforma.Helper
{
    public interface IClave : IEquatable<IClave>
    {
        IObjetoDatos ObjetoDatos { get; }
        IPropiedad Propiedad { get; }
    }
}
