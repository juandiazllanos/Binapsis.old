using Binapsis.Plataforma.Configuracion;
using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Test.Builders;

namespace Binapsis.Plataforma.Test
{
    public static class HelperTipo
    {
        static Tipo _tipo;
        static Tipo _tipo2;
        static Tipo _tipo3;

        static HelperTipo()
        {
            BuilderTipo.Construir((_tipo = Fabrica.Instancia.Crear<Tipo>()));
            BuilderTipo.Construir2((_tipo2 = Fabrica.Instancia.Crear<Tipo>()), _tipo);
            BuilderTipo.Construir3((_tipo3 = Fabrica.Instancia.Crear<Tipo>()), _tipo);
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
