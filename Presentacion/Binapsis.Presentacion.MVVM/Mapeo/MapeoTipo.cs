using Binapsis.Presentacion.Editores;
using System.Collections.Generic;

namespace Binapsis.Presentacion.MVVM.Mapeo
{
	public class MapeoTipo
    {
		List<MapeoPropiedad> _propiedades;

		public MapeoTipo()
        {
            _propiedades = new List<MapeoPropiedad>();
		}
        
        public void Establecer(string nombre, IEditor editor)
        {
            Establecer(nombre, editor, null);
        }

        public void Establecer(string nombre, MapeoTipo mapeo)
        {
            Establecer(nombre, null, mapeo);
        }
        
        public void Establecer(string nombre, IEditor editor, MapeoTipo mapeo)
        {
            if (editor == null && mapeo == null) return;

            MapeoPropiedad mapeoPropiedad = null;

            if (mapeo != null)
                mapeoPropiedad = new MapeoReferencia(this, nombre, editor, mapeo);
            else
                mapeoPropiedad = new MapeoPropiedad(this, nombre, editor);

            //else if (EsEditor<IEditorAtributo>(editor))              //(typeof(IEditorAtributo).GetTypeInfo().IsAssignableFrom(editor.GetType().GetTypeInfo()))
            //    mapeoPropiedad = new MapeoAtributo(this, nombre, (IEditorAtributo)editor);
            //else if (EsEditor<IEditorColumna>(editor))          //(typeof(IEditorColumna) editor.GetType() == )
            //    mapeoPropiedad = new MapeoColumna(this, nombre, (IEditorColumna)editor);
            //else if (EsEditor<IEditorColeccion>(editor) && mapeo != null)       //(editor.GetType() == typeof(IEditorColeccion) && mapeo != null)
            //    mapeoPropiedad = new MapeoColeccion(this, nombre, mapeo, (IEditorColeccion)editor);
            
            if (mapeoPropiedad == null) return;

            _propiedades.Add(mapeoPropiedad);
        }
        
        public IReadOnlyList<MapeoPropiedad> Propiedades
        {
            get { return _propiedades; }
        }
	}

}