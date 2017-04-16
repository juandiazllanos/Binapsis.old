using System.Collections.Generic;

namespace Binapsis.Plataforma.Estructura
{
    public interface IColeccion : IEnumerable<IObjetoDatos>
    {
        bool Contiene(IObjetoDatos item);
        int Indice(IObjetoDatos item);
        int Longitud { get; }
                
        IObjetoDatos this[int indice] { get; }
    }
}
