using Binapsis.Plataforma.Estructura;
using System;

namespace Binapsis.Plataforma.Helper
{
    public interface ITypeHelper
    {
        ITipo Obtener(string uri, string nombre);
        ITipo Obtener(Type type);
        ITipo Definir(IObjetoDatos tipo);
    }
}
