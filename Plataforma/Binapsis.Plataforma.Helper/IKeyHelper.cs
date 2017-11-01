using Binapsis.Plataforma.Estructura;
using System;

namespace Binapsis.Plataforma.Helper
{
    public interface IKeyHelper
    {
        IPropiedad[] GetProperty(ITipo tipo);
        IKey GetKey(IObjetoDatos od);
    }

    public interface IKey : IEquatable<IKey>
    {        
        int Longitud
        {
            get;
        }

        IPropiedad[] Properties
        {
            get;
        }

        object[] Values
        {
            get;
        }
    }
}
