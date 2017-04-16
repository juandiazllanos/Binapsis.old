using Binapsis.Plataforma.Estructura;

namespace Binapsis.Presentacion.MVVM
{
    internal class VistaModeloReferencia : VistaModeloPropiedad
    {
        VistaModelo _vistaModelo;

        public VistaModeloReferencia(VistaModelo vistaModelo, IPropiedad propiedad) 
            : base(vistaModelo, propiedad)
        {            
        }

        protected override void Crear(VistaModelo vistaModelo)
        {
            _vistaModelo = vistaModelo;
        }

        public override void Eliminar()
        {
            Eliminar(_vistaModelo);
            _vistaModelo = null;
        }

        public override void Eliminar(IObjetoDatos modelo)
        {
            Eliminar();
        }

        public override void EliminarTodo()
        {
            Eliminar();
        }

        public override VistaModelo Obtener()
        {
            return _vistaModelo;
        }

        public override VistaModelo Obtener(IObjetoDatos item)
        {
            return null;
        }
    }
}
