using Binapsis.Plataforma.Estructura.Impl;
using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Cambios
{
    class FabricaImpl : FabricaImplBase
    {
        public FabricaImpl()
            : base()
        {
        }

        public FabricaImpl(IFabricaImpl fabrica) 
            : base(fabrica)
        {
        }

        protected override IImplementacion Crear(IImplementacion impl)
        {
            return impl;
        }
    }
}
