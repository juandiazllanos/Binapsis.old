using Binapsis.Plataforma.Estructura;
using Binapsis.Presentacion.MVVM.Mapeo;

namespace Binapsis.Presentacion.MVVM.Vista
{
	public class VistaReferencia : VistaPropiedad
    {
        VistaObjeto _vistaReferencia;
        MapeoTipo _mapeo;

        public VistaReferencia(VistaObjeto vista, IPropiedad propiedad, MapeoTipo mapeo) 
            : base(vista, propiedad)
        {
            _mapeo = mapeo;
        }

        public VistaObjeto Crear()
        {
            if (_vistaReferencia == null)
                _vistaReferencia = Crear(Propiedad.Tipo, _mapeo);

            return _vistaReferencia;
        }

        protected virtual VistaObjeto Crear(ITipo tipo, MapeoTipo mapeo)
        {
            return new VistaObjeto(tipo, mapeo);
        }

        public void Eliminar()
        {
            //_vistaReferencia.Liberar(); (VistaModelo invoca Liberar de la Vista)
            _vistaReferencia = null;
        }

        public VistaObjeto Vista
        {
            get { return _vistaReferencia; }
        }
    }

}