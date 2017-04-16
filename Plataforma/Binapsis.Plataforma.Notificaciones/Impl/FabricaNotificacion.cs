using Binapsis.Plataforma.Estructura.Impl;
using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Notificaciones.Impl
{
    public class FabricaNotificacion : FabricaImplementacion
    {
        public FabricaNotificacion()
            : base()
        {
        }
        
        public FabricaNotificacion(IFabrica fabrica) 
            : base(fabrica)
        {            
        }

        static FabricaNotificacion()
        {
            Instancia = new FabricaNotificacion();
        }

        static new FabricaNotificacion Instancia { get; } 

        protected override IImplementacion CrearImplementacion(IImplementacion impl)
        {
            return new ImplementacionNotificacion(impl);
        }        
    }
}
