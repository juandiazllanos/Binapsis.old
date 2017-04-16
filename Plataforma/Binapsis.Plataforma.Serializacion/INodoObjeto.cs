using Binapsis.Plataforma.Estructura;
using System.Collections.Generic;

namespace Binapsis.Plataforma.Serializacion
{
    public interface INodoObjeto
    {
        int Id { get; }
        string Propietario { get; }
        IObjetoDatos ObjetoDatos { get; }
        IEnumerable<IPropiedad> Atributos { get; }
        IEnumerable<INodoReferencia> Referencias { get; }
        ITipo Tipo { get; }
    }
}
