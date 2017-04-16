using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Estructura.Impl;
using Binapsis.Plataforma.Test.Builders;

namespace Binapsis.Plataforma.Test
{
    public static class Helper
    {
        public static IObjetoDatos Crear(ITipo tipo)
        {
            return Fabrica.Instancia.Crear(tipo);
        }

        public static IObjetoDatos Crear(ITipo tipo, IFabrica fabrica)
        {
            return fabrica.Crear(tipo);
        }

        public static void Construir(IObjetoDatos od)
        {
            Construir(od, 0);
        }

        public static void Construir(IObjetoDatos od, int anidamiento)
        {
            Construir(od, anidamiento, 0);
        }

        public static void Construir(IObjetoDatos od, int anidamiento, int items)
        {
            BuilderObjetoDatos.Construir(od , anidamiento, items);
        }
        
    }
}
