using Binapsis.Plataforma.Notificaciones.Impl;

namespace Binapsis.Plataforma.Configuracion.Win.Actividades
{
    class Instanciar : Actividad
    {
        public override void Iniciar()
        {
            FabricaConfiguracion fabrica = new FabricaConfiguracion(new FabricaNotificacion());
            Estado = fabrica.Crear(Type);
            Terminar();
        }                
    }
}
