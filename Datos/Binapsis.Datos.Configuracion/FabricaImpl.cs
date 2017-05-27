using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Estructura.Impl;

namespace Binapsis.Datos.Configuracion
{
    internal class FabricaImpl : FabricaImplBase
    {
        private FabricaImpl()
            : base()
        {
        }

        public static IFabricaImpl Instancia { get; } = new FabricaImpl();

        protected override IImplementacion Crear(IImplementacion impl)
        {
            return impl;
        }
    }
}
