using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Estructura.Impl;
using Binapsis.Plataforma.Notificaciones.Impl;
using Binapsis.Plataforma.Notificaciones.Impl.Extension;
using Binapsis.Plataforma.Notificaciones;

namespace Binapsis.Plataforma.Test.Notificacion.Impl
{
    public class Observador : IObservador
    {

        public Observador(IObjetoDatos od)
        {
            ObjetoDatos = od;            
        }

        public IObjetoDatos ObjetoDatos { get; }

        public Observable Observable { get; set; }
        
        void IObservador.Notificar(INotificacion msg)
        {
            if (typeof(INotificacionColeccion).IsAssignableFrom(msg.GetType()))
                ActualizarColeccion((INotificacionColeccion)msg);            
            else
                ActualizarPropiedad(msg.ObjetoDatos, msg.Propiedad);
        }

        void CrearObservador(IObjetoDatos od1, IObjetoDatos od2)
        {
            if (od1 == null || od2 == null) return;

            Observable observable = ((ObjetoBase)od1).Observable();
            Observador observador = new Observador(od2);
            observable.Agregar(observador);            
        }

        private void ActualizarColeccion(INotificacionColeccion msg)
        {
            ActualizarColeccion(msg.ObjetoDatos, msg.Propiedad, msg.Accion, msg.Item, msg.Indice);
        }

        private void ActualizarColeccion(IObjetoDatos od, IPropiedad propiedad, Accion accion, IObjetoDatos item, int indice)
        {
            if (accion == Accion.Agregar)
                CrearObservador(item, ObjetoDatos.CrearObjetoDatos(propiedad));
            else if (accion == Accion.Remover)
                ObjetoDatos.RemoverObjetoDatos(propiedad, ObjetoDatos.ObtenerColeccion(propiedad)[indice]);
        }

        private void ActualizarPropiedad(IObjetoDatos od, IPropiedad propiedad)
        {
            if (propiedad.Tipo.EsTipoDeDato || propiedad.Asociacion == Asociacion.Agregacion || od.ObtenerObjetoDatos(propiedad) == null)
                ObjetoDatos.Establecer(propiedad, od.Obtener(propiedad));
            else if (propiedad.Asociacion == Asociacion.Composicion)
                CrearObservador(od.ObtenerObjetoDatos(propiedad), ObjetoDatos.CrearObjetoDatos(propiedad));
            
        }       

    }
}
