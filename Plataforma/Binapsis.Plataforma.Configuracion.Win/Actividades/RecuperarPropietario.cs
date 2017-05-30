using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Estructura.Impl;
using Binapsis.Plataforma.Notificaciones.Impl;

namespace Binapsis.Plataforma.Configuracion.Win.Actividades
{
    class RecuperarPropietario : Actividad
    {
        public override void Iniciar()
        {
            IRepositorio repositorio = Controlador.Contexto.Repositorio;
            IElemento elementoPropietario = Controlador.Contexto.ElementoPropietario;
            ConfiguracionBase propietario = null;
            IFabricaImpl impl = new FabricaNotificacion();

            if (repositorio != null && elementoPropietario != null)
                propietario = repositorio.Obtener(elementoPropietario.Type, elementoPropietario.Valor, impl);

            if (propietario == null)
            {
                Cancelar();
                return;
            }

            Estado = propietario;

            Terminar();
        }
    }
}
