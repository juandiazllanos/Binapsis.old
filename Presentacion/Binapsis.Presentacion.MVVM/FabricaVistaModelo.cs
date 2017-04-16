using Binapsis.Plataforma.Estructura;
using Binapsis.Presentacion.MVVM.Mapeo;
using Binapsis.Presentacion.MVVM.Vista;

namespace Binapsis.Presentacion.MVVM
{
    public class FabricaVistaModelo
    {
        MapeoTipo _mapeo;

        public FabricaVistaModelo(MapeoTipo mapeo)
        {
            _mapeo = mapeo;
        }

        public VistaModelo Crear(IObjetoDatos modelo)
        {
            VistaModelo vistaModelo;
            VistaObjeto vista = new VistaObjeto(modelo.Tipo, _mapeo);

            vistaModelo = new VistaModelo(modelo, vista);

            return vistaModelo;
        }
        
    }
}
