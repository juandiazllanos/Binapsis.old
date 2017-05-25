using Binapsis.Presentacion.Editores;

namespace Binapsis.Presentacion.MVVM.Mapeo
{
	public class MapeoPropiedad
    {
        MapeoTipo _mapeo;

        public MapeoPropiedad(MapeoTipo mapeo)
        {
            _mapeo = mapeo;
        }
        
        public MapeoPropiedadDefinicion Propiedad
        {
            get;
            set;
        }
                
        public IEditor Editor
        {
            get;
            set;
        }
    }

}