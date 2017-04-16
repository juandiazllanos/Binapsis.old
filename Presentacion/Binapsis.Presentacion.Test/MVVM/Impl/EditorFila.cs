using Binapsis.Presentacion.Editores;

namespace Binapsis.Presentacion.Test.MVVM.Impl
{
    class EditorFila : EditorObjetoBase, IEditorFila
    {
        EditorColeccion _propietario;

        public EditorFila(EditorColeccion propietario)
        {
            _propietario = propietario;
        }

        public IEditorAtributo Crear(IEditorColumna col)
        {
            IEditorAtributo editor = new EditorCelda(this, this, col) { Nombre = col.Nombre };
            _editores.Add(editor);
            return editor;
        }

        public int Indice { get { return _propietario.Indice(this); } }

        public override string Nombre
        {
            get { return string.Format("{0}.Fila[{1}]", _propietario.Nombre, Indice); }
            set { base.Nombre = value; }
        }
    }
}
