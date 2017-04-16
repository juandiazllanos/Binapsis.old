using Binapsis.Presentacion.Editores;

namespace Binapsis.Presentacion.MVVM.Mapeo
{
	public class MapeoPropiedad
    {
        MapeoTipo _mapeo;
        
		public MapeoPropiedad(MapeoTipo mapeo, string nombre, IEditor editor)
        {
            _mapeo = mapeo;
            Nombre = nombre;
            Editor = editor;
		}

        public string Nombre { get; }
        
        public IEditor Editor { get; }
    }

}