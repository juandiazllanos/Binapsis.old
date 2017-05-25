using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Notificaciones.Impl;


namespace Binapsis.Plataforma.Configuracion.Win.Actividades
{
    internal class Recuperar : Actividad
    {
        public override void Iniciar()
        {
            if (Controlador.Contexto.ElementoSeleccionado == null)
            {
                Cancelar();
                return;
            }                

            IRepositorio repositorio = Controlador.Contexto.Repositorio;
            IFabricaImpl impl = new FabricaNotificacion();
            string clave = Controlador.Contexto.ElementoSeleccionado.Valor;

            Estado = repositorio.Obtener(Type, clave, impl);
            Terminar();
        }
    }
}
