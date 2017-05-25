using System;

namespace Binapsis.Plataforma.Estructura.Impl
{
	public class FabricaDatos : FabricaBase<ObjetoDatos>
    {
        private FabricaDatos()
            : base()
        {
        }

        public FabricaDatos(IFabricaImpl fabrica) 
            : base(fabrica)
        {
        }

        public static FabricaDatos Instancia { get; } = new FabricaDatos();
                
        public override ObjetoDatos Crear(IImplementacion impl)
        {
            return new ObjetoDatos(impl);
        }
    }
}