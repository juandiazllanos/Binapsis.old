using Binapsis.Plataforma.Estructura;
using System.Collections.Generic;

namespace Binapsis.Plataforma.Serializacion
{
    public interface INodoReferencia
    {
        IPropiedad Propiedad { get; }
        IEnumerable<INodoObjeto> Objetos { get; }
    }
}