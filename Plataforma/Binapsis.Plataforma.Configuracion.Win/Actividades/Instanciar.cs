using Binapsis.Plataforma.Notificaciones.Impl;
using FabricaConfig = Binapsis.Plataforma.Configuracion.Fabrica;

namespace Binapsis.Plataforma.Configuracion.Win.Actividades
{
    class Instanciar : Actividad
    {
        public override void Iniciar()
        {
            FabricaConfig fabrica = new FabricaConfig(new FabricaNotificacion());
            Estado = fabrica.Crear(Type);
            Terminar();
        }                
    }
}
