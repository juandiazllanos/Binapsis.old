using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Estructura.Impl;
using Binapsis.Plataforma.Test.Builders;

namespace Binapsis.Plataforma.Test
{
    public static class HelperTipo
    {
        static ITipo _tipo;
        static ITipo _tipo2;
        static ITipo _tipo3;

        static HelperTipo()
        {
            BuilderTipo.Construir((Tipo)(_tipo = new Tipo()));
            BuilderTipo.Construir2((Tipo)(_tipo2 = new Tipo()), (Tipo)_tipo);
            BuilderTipo.Construir3((Tipo)(_tipo3 = new Tipo()), (Tipo)_tipo);
        }

        public static ITipo ObtenerTipo()
        {
            return _tipo;
        }

        public static ITipo ObtenerTipo2()
        {
            return _tipo2;
        }

        public static ITipo ObtenerTipo3()
        {
            return _tipo3;
        }
    }
}
