using Binapsis.Plataforma.Estructura.Impl;
using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Cambios.Impl;

namespace Binapsis.Plataforma.Cambios
{
    class Fabrica : FabricaBase<ObjetoCambios>
    {
        public override ObjetoCambios Crear(IImplementacion impl)
        {
            return new ObjetoCambios(impl);
        }
    }
}
