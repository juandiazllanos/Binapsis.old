using Binapsis.Presentacion.Editores;
using System.Collections.Generic;
using Binapsis.Plataforma.Estructura;
using Binapsis.Presentacion.MVVM.Mapeo;

namespace Binapsis.Presentacion.MVVM.Vista
{
	public class VistaColeccion : VistaPropiedad
    {
		List<VistaFila> _filas;
        MapeoTipo _mapeo;

        public VistaColeccion(VistaObjeto vista, IPropiedad propiedad, MapeoTipo mapeo, IEditorColeccion editor) 
            : base(vista, propiedad)
        {
            _mapeo = mapeo;
            _filas = new List<VistaFila>();
            Editor = editor;
        }

        public VistaFila Crear()
        {
            VistaFila fila = new VistaFila(Propiedad.Tipo, _mapeo, Editor.Crear());
            _filas.Add(fila);
            return fila;
        }

        public void Remover(VistaFila fila)
        {
            if (!_filas.Contains(fila)) return;
            Editor.Remover(fila.Editor);
            _filas.Remove(fila);
        }
        
        public IEditorColeccion Editor { get; }
    }

}