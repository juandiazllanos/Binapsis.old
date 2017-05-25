using Binapsis.Plataforma.Estructura.Impl;
using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Notificaciones.Impl
{
    public class FabricaNotificacion : FabricaImplBase
    {
        public FabricaNotificacion()
            : base()
        {
        }        
        
        public FabricaNotificacion(IFabricaImpl fabrica) 
            : base(fabrica)
        {
        }

        public static FabricaNotificacion Instancia { get; } = new FabricaNotificacion();

        protected override IImplementacion Crear(IImplementacion impl)
        {
            return new ImplementacionNotificacion(impl);
        }        
    }
}
