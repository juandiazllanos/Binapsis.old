using Binapsis.Plataforma.Helper.Impl;
using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Test
{
    class TestClaveHelper : ClaveHelper
    {
        private TestClaveHelper()
        {
        }

        static TestClaveHelper()
        {
            Instancia = new TestClaveHelper();
        }

        internal new void Establecer(ITipo tipo, IPropiedad propiedad)
        {
            base.Establecer(tipo, propiedad);
        }

        internal new void Establecer(ITipo tipo, string propiedad)
        {
            base.Establecer(tipo, propiedad);
        }

        public static TestClaveHelper Instancia
        {
            get;
        }
    }
}
