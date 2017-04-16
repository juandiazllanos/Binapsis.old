using Binapsis.Presentacion.Editores;

namespace Binapsis.Presentacion.MVVM.Mapeo
{
	public class MapeoReferencia : MapeoPropiedad
    {
        public MapeoReferencia(MapeoTipo mapeo, string nombre, MapeoTipo mapeoTipo)
            : this(mapeo, nombre, null, mapeoTipo)
        {            
        }

        public MapeoReferencia(MapeoTipo mapeo, string nombre, IEditor editor, MapeoTipo mapeoTipo) 
            : base(mapeo, nombre, editor)
        {
            Mapeo = mapeoTipo;
        }

        public  MapeoTipo Mapeo { get; }        		
	}

}