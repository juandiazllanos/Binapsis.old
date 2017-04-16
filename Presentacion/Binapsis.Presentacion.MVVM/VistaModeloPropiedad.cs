using Binapsis.Plataforma.Estructura;
using Binapsis.Presentacion.MVVM.Vista;

namespace Binapsis.Presentacion.MVVM
{
    internal abstract class VistaModeloPropiedad
    {
        VistaModelo _vistaModelo;

        public VistaModeloPropiedad(VistaModelo vistaModelo, IPropiedad propiedad)
        {
            _vistaModelo = vistaModelo;
            Propiedad = propiedad;
        }

        public IPropiedad Propiedad { get; }

        public void Crear(IObjetoDatos modelo)
        {
            VistaObjeto vista = _vistaModelo.Vista.CrearVista(Propiedad);
            VistaModelo vistaModelo = new VistaModelo(modelo, vista);
            // controlar en clase concreta
            Crear(vistaModelo);
        }

        protected abstract void Crear(VistaModelo vistaModelo);

        public abstract void Eliminar();

        public abstract void Eliminar(IObjetoDatos modelo);

        public abstract void EliminarTodo();

        public abstract VistaModelo Obtener();

        public abstract VistaModelo Obtener(IObjetoDatos modelo);

        protected void Eliminar(VistaModelo vistaModelo)
        {
            if (vistaModelo == null) return;

            vistaModelo.Liberar();
            _vistaModelo.Vista.EliminarVista(Propiedad, vistaModelo.Vista);                       
        }

    }
}
