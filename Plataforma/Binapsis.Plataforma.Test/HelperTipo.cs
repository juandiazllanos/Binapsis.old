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
        static TestKeyHelper _keyHelper;

        static HelperTipo()
        {
            BuilderTipo.Construir((_tipo = Fabrica.Instancia.Crear<Tipo>()));
            BuilderTipo.Construir2((_tipo2 = Fabrica.Instancia.Crear<Tipo>()), _tipo);
            BuilderTipo.Construir3((_tipo3 = Fabrica.Instancia.Crear<Tipo>()), _tipo);

            _keyHelper = new TestKeyHelper();

            _keyHelper.Establecer(_tipo, "atributoId");
            _keyHelper.Establecer(_tipo2, "atributoId");
            _keyHelper.Establecer(_tipo3, "atributoId");
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

        public static TestKeyHelper KeyHelper
        {
            get => _keyHelper;
        }
    }
}
