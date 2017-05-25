using Binapsis.Presentacion.Editores;
using Binapsis.Presentacion.MVVM.Mapeo;
using System.Collections.Generic;

namespace Binapsis.Presentacion.MVVM.VistaEditor
{
	internal class VistaColeccion : VistaPropiedad
    {
		List<VistaItem> _filas;

        public VistaColeccion(VistaTipo vistaTipo, IEditorColeccion editor) 
            : base(vistaTipo)
        {            
            _filas = new List<VistaItem>();
            Editor = editor;
        }

        //public VistaFila Crear()
        //{
        //    IEditorFila item = Editor.Crear();
        //    VistaFila fila = new VistaFila(MapeoReferencia, item);
        //    _filas.Add(fila);
        //    return fila;
        //}

        public void Agregar(VistaItem item)
        {
            _filas.Add(item);
        }

        public void Remover(VistaItem item)
        {
            if (!_filas.Contains(item)) return;
            Editor.Remover(item.Item);
            _filas.Remove(item);
        }
        
        public IEditorColeccion Editor
        {
            get;
        }

        public MapeoTipo MapeoReferencia
        {
            get;
            set;
        }
    }

}