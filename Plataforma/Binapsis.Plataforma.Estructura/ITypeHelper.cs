using System;

namespace Binapsis.Plataforma.Estructura
{
    public interface ITypeHelper
    {
        ITipo Obtener(string uri, string nombre);
        ITipo Obtener(Type type);
        ITipo Definir(IObjetoDatos tipo);
    }
}
